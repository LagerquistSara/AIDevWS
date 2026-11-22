using Microsoft.Xrm.Sdk;
using System;

namespace UgWorkshop.Plugins
{
    /// <summary>
    /// Lab 4: duplicate and capacity rules for Event Check-in registrations (table sara_registration).
    /// See the registration card in Lab 4 for the table, columns, steps, filtering attributes and pre-image.
    /// </summary>
    public class RegistrationRulesPlugin : PluginBase
    {
        public RegistrationRulesPlugin(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(RegistrationRulesPlugin))
        {
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            // TODO (Lab 4): implement the duplicate and capacity rules.
        }
    }
}
