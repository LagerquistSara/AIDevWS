using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace UgWorkshop.Plugins.Tests.Fakes
{
    /// <summary>
    /// Builds the IServiceProvider that Dataverse passes to IPlugin.Execute, backed by a FakeOrganizationService.
    /// Usage:
    ///   var pipeline = new FakePluginPipeline(service);
    ///   pipeline.Context.MessageName = "Update";
    ///   pipeline.Context.InputParameters["Target"] = new Entity("sara_registration", id);
    ///   pipeline.Context.PreEntityImages["PreImage"] = preImage;
    ///   pipeline.Execute(new RegistrationRulesPlugin(null, null));
    /// </summary>
    public class FakePluginPipeline : IServiceProvider, IOrganizationServiceFactory, ITracingService
    {
        public FakePluginPipeline(FakeOrganizationService service, string primaryEntityName = "sara_registration")
        {
            Service = service;
            Context = new FakePluginExecutionContext
            {
                PrimaryEntityName = primaryEntityName,
                MessageName = "Create",
                Stage = 20,
                Mode = 0
            };
        }

        public FakeOrganizationService Service { get; }

        public FakePluginExecutionContext Context { get; }

        /// <summary>Everything the plug-in traced, for debugging failed tests.</summary>
        public List<string> Traces { get; } = new List<string>();

        public void Execute(IPlugin plugin) => plugin.Execute(this);

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IPluginExecutionContext) || serviceType == typeof(IExecutionContext))
            {
                return Context;
            }

            if (serviceType == typeof(IOrganizationServiceFactory))
            {
                return this;
            }

            if (serviceType == typeof(ITracingService))
            {
                return this;
            }

            return null;
        }

        public IOrganizationService CreateOrganizationService(Guid? userId) => Service;

        public void Trace(string format, params object[] args) =>
            Traces.Add(args == null || args.Length == 0 ? format : string.Format(format, args));
    }

    public class FakePluginExecutionContext : IPluginExecutionContext
    {
        public int Stage { get; set; }
        public IPluginExecutionContext ParentContext { get; set; }
        public int Mode { get; set; }
        public int IsolationMode { get; set; } = 2;
        public int Depth { get; set; } = 1;
        public string MessageName { get; set; }
        public string PrimaryEntityName { get; set; }
        public Guid? RequestId { get; set; }
        public string SecondaryEntityName { get; set; } = "none";
        public ParameterCollection InputParameters { get; } = new ParameterCollection();
        public ParameterCollection OutputParameters { get; } = new ParameterCollection();
        public ParameterCollection SharedVariables { get; } = new ParameterCollection();
        public Guid UserId { get; set; } = Guid.NewGuid();
        public Guid InitiatingUserId { get; set; } = Guid.NewGuid();
        public Guid BusinessUnitId { get; set; } = Guid.NewGuid();
        public Guid OrganizationId { get; set; } = Guid.NewGuid();
        public string OrganizationName { get; set; } = "workshop";
        public Guid PrimaryEntityId { get; set; }
        public EntityImageCollection PreEntityImages { get; } = new EntityImageCollection();
        public EntityImageCollection PostEntityImages { get; } = new EntityImageCollection();
        public EntityReference OwningExtension { get; set; }
        public Guid CorrelationId { get; set; } = Guid.NewGuid();
        public bool IsExecutingOffline { get; set; }
        public bool IsOfflinePlayback { get; set; }
        public bool IsInTransaction { get; set; } = true;
        public Guid OperationId { get; set; } = Guid.NewGuid();
        public DateTime OperationCreatedOn { get; set; } = DateTime.UtcNow;
    }
}
