using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UgWorkshop.Plugins.Tests.Fakes
{
    /// <summary>
    /// Small in-memory IOrganizationService for plug-in unit tests. No packages or licences needed.
    /// Supports Create, Retrieve, Update, Delete and RetrieveMultiple with a QueryExpression whose
    /// criteria use AND and the Equal, NotEqual, In, Null and NotNull operators, plus TopCount.
    /// Anything else throws NotSupportedException so a test never passes by accident.
    /// </summary>
    public class FakeOrganizationService : IOrganizationService
    {
        private readonly Dictionary<string, Dictionary<Guid, Entity>> _tables =
            new Dictionary<string, Dictionary<Guid, Entity>>();

        /// <summary>Every QueryExpression the plug-in ran, so tests can assert that no query happened.</summary>
        public List<QueryExpression> Queries { get; } = new List<QueryExpression>();

        /// <summary>Adds a row directly, for test setup. Sets statecode to 0 (Active) if it is missing.</summary>
        public Entity Seed(Entity row)
        {
            if (row.Id == Guid.Empty)
            {
                row.Id = Guid.NewGuid();
            }

            row[row.LogicalName + "id"] = row.Id;
            if (!row.Contains("statecode"))
            {
                row["statecode"] = new OptionSetValue(0);
            }

            Table(row.LogicalName)[row.Id] = Copy(row);
            return row;
        }

        public Guid Create(Entity entity) => Seed(Copy(entity)).Id;

        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            if (!Table(entityName).TryGetValue(id, out var row))
            {
                throw new InvalidOperationException($"{entityName} with id {id} does not exist.");
            }

            return Project(row, columnSet);
        }

        public void Update(Entity entity)
        {
            var row = Table(entity.LogicalName)[entity.Id];
            foreach (var attribute in entity.Attributes)
            {
                row[attribute.Key] = attribute.Value;
            }
        }

        public void Delete(string entityName, Guid id) => Table(entityName).Remove(id);

        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            if (!(query is QueryExpression expression))
            {
                throw new NotSupportedException("FakeOrganizationService supports QueryExpression only.");
            }

            if (expression.LinkEntities.Count > 0 || expression.Criteria.Filters.Count > 0
                || expression.Criteria.FilterOperator != LogicalOperator.And)
            {
                throw new NotSupportedException("FakeOrganizationService supports one AND filter without link-entities.");
            }

            Queries.Add(expression);
            IEnumerable<Entity> rows = Table(expression.EntityName).Values
                .Where(row => expression.Criteria.Conditions.All(condition => Matches(row, condition)));
            if (expression.TopCount.HasValue)
            {
                rows = rows.Take(expression.TopCount.Value);
            }

            return new EntityCollection(rows.Select(row => Project(row, expression.ColumnSet)).ToList())
            {
                EntityName = expression.EntityName
            };
        }

        public OrganizationResponse Execute(OrganizationRequest request) =>
            throw new NotSupportedException($"FakeOrganizationService does not support {request.RequestName}.");

        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities) =>
            throw new NotSupportedException();

        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities) =>
            throw new NotSupportedException();

        private Dictionary<Guid, Entity> Table(string logicalName)
        {
            if (!_tables.TryGetValue(logicalName, out var table))
            {
                table = new Dictionary<Guid, Entity>();
                _tables[logicalName] = table;
            }

            return table;
        }

        private static bool Matches(Entity row, ConditionExpression condition)
        {
            var actual = Normalize(row.Contains(condition.AttributeName) ? row[condition.AttributeName] : null);
            var values = condition.Values.Select(Normalize).ToList();
            switch (condition.Operator)
            {
                case ConditionOperator.Equal:
                    return actual != null && actual.Equals(values.Single());
                case ConditionOperator.NotEqual:
                    return actual != null && !actual.Equals(values.Single());
                case ConditionOperator.In:
                    return actual != null && values.Contains(actual);
                case ConditionOperator.Null:
                    return actual == null;
                case ConditionOperator.NotNull:
                    return actual != null;
                default:
                    throw new NotSupportedException($"FakeOrganizationService does not support the {condition.Operator} operator.");
            }
        }

        // Compare lookups by id and choices by number, as Dataverse does in query conditions.
        private static object Normalize(object value)
        {
            switch (value)
            {
                case EntityReference reference:
                    return reference.Id;
                case OptionSetValue option:
                    return option.Value;
                default:
                    return value;
            }
        }

        private static Entity Project(Entity row, ColumnSet columnSet)
        {
            var result = new Entity(row.LogicalName, row.Id);
            foreach (var attribute in row.Attributes)
            {
                if (columnSet == null || columnSet.AllColumns || columnSet.Columns.Contains(attribute.Key))
                {
                    result[attribute.Key] = attribute.Value;
                }
            }

            return result;
        }

        private static Entity Copy(Entity row)
        {
            var copy = new Entity(row.LogicalName, row.Id);
            foreach (var attribute in row.Attributes)
            {
                copy[attribute.Key] = attribute.Value;
            }

            return copy;
        }
    }
}
