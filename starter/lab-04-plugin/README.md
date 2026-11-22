# Lab 4 starter — Event Check-in registration rules plug-in

This folder is the starting point for Lab 4 of the workshop. It is built on the `pac plugin init` template from the Power Platform CLI.

| Folder or file | What it is |
|---|---|
| `UgWorkshop.Plugins.slnx` | Solution with both projects. Build and test from this folder: `dotnet build` and `dotnet test`. |
| `src/UgWorkshop.Plugins/` | Signed plug-in project (.NET Framework 4.6.2, `Microsoft.CrmSdk.CoreAssemblies`). `RegistrationRulesPlugin.cs` is empty; `PluginBase.cs` comes from the template. |
| `tests/UgWorkshop.Plugins.Tests/` | NUnit test project on .NET 10, so tests run on Windows and macOS. No tests yet. |
| `tests/UgWorkshop.Plugins.Tests/Fakes/` | `FakeOrganizationService` (in-memory Dataverse) and `FakePluginPipeline` (builds the plug-in context with `Target`, message, stage and images). |

## Rules for GitHub Copilot

- Only the .NET 10 SDK is needed. Do not add test or mocking packages (for example FakeXrmEasy or Moq); use the fakes in `Fakes/`. Extend them if a test needs it.
- Keep the plug-in on `net462`, keep it signed with `UgWorkshop.Plugins.snk`, and do not add dependent assemblies: it is registered as a single plug-in assembly.
- `UgWorkshop.Plugins.snk` is a signing key. Dataverse only accepts signed plug-in assemblies; the key gives the DLL a fixed identity but grants no access to anything. This key is public, so use it only for the workshop. For real projects, create your own key (in Visual Studio: project **Properties → Signing → New**) and keep it in your team's own repository.
- Use `Entity` targets in tests, as Dataverse does. On Update, the target contains only the changed columns; read the rest from the pre-image `PreImage`.
- Throw `InvalidPluginExecutionException` with a clear message for errors the user should see.

## Event Check-in schema used by the plug-in

| Table | Column | Type |
|---|---|---|
| `sara_registration` | `sara_event` | Lookup to `sara_event`, required |
| `sara_registration` | `sara_contact` | Lookup to `contact`, required |
| `sara_registration` | `sara_status` | Choice: 100000000 Registered (default), 100000001 Checked-in, 100000002 Waitlisted, 100000003 Cancelled |
| `sara_event` | `sara_name` | Text, primary name |
| `sara_event` | `sara_capacity` | Whole number, required |

Registered and Checked-in are *active* and use a seat. Waitlisted and Cancelled do not.
