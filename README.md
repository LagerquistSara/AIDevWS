# Agent-assisted Power Platform workshop

**DynUG Høstkonferanse · 24 November 2026 · 10:00–15:10**

This workshop is for Power Platform makers and professionals who want to work with VS Code and GitHub Copilot without needing to become full-time developers. Slides and lab instructions are in English; discussion can be in English or Swedish.

## Start here

- Participants: complete [pre-work](labs/lab-00-prework.md) before the workshop, then follow Labs 1–5 in order, including Lab 3b. Labs 6 and 7 are optional.
- **Scope:** we replace the Maker Portal with an agent-assisted way of working. Dataverse, solutions, security and ALM stay the same. Licensing for building solutions is not covered.
- **Read it. Get it. Then run it.** The labs are not a race. The text between the prompts is the lesson. Guess what a prompt will do before you send it, review before you select Keep, and make sure you can explain what you built.
- Event Check-in app: you import it in [Lab 3](labs/lab-03-event-checkin-icons.md). Demo data is generated through the prompt in [Lab 3, Part C](labs/lab-03-event-checkin-icons.md#part-c--ask-for-icons-and-sample-data-and-review-the-plan-20-min).

## Labs

| Lab | Topic | Time |
|---|---|---:|
| 0 | Pre-work and environment check | 20–30 min before the event, plus approval lead time |
| 1 | Install and inspect Power Platform plugins | 15 min |
| 2 | Your workspace: folder, MCP servers, sign in to your environment | 35 min |
| 3 | Improve the Event Check-in app with the app-builder skill (icons and sample data) | 50 min |
| [3b](labs/lab-03b-check-in-desk.md) | Build and test a Check-in desk generative page | 30 min |
| 4 | Build and test a Dataverse plugin | 40 min |
| 5 | Make a custom agent and skill | 25 min |
| 6 | Optional: create a Copilot Studio agent from VS Code | 30 min, take-home/fast finishers |
| [7](labs/lab-07-challenges.md) | Optional: challenges — confetti, registration counts, waitlist promotion and more | Any time, take-home/fast finishers |

## Which starter files do I need?

You do **not** need to download or copy the whole starter folder. Use each item when its lab introduces it.

| Item | When and where to use it |
|---|---|
| MCP configuration | Copy the JSON directly from [Lab 2](labs/lab-02-workspace-mcp-instructions.md) into Chat to create `.vscode/mcp.json`. No separate template is needed. |
| [copilot-instructions.md](starter/copilot-instructions.md) | Optional Lab 2 exercise: copy its contents into `.github/copilot-instructions.md` for automatic project guidance. It is not required for MCP or sign-in. |
| [EventCheckIn_1_0_0_0.zip](starter/EventCheckIn_1_0_0_0.zip) | Lab 3: import into your developer environment. Unmanaged solution, without data. |
| [lab-04-plugin.zip](starter/lab-04-plugin.zip) | Lab 4: unzip into your workshop workspace. Contains the plugin project and test scaffolding. |

## Important safety and preparation notes

- Use a **dedicated developer environment**, never production. Participants need permission to work with solutions and the Dataverse MCP client must be allowed by the environment administrator.
- You install VS Code and click through marketplace and plugin setup and solution imports yourself in the VS Code or Maker Portal UI. Everything else, including installing the other tools in Lab 0, happens in GitHub Copilot Chat in VS Code: GitHub Copilot runs each command only after you approve it.
- Do not put credentials, access tokens, customer data, or connection secrets in workspace files or prompts.
- Interface labels, marketplace availability, and CLI options can change. When an instruction says to use a VS Code command or inspect CLI help, prefer the current UI/help output over a guessed command.

## Useful references

- [Dataverse MCP with GitHub Copilot in VS Code](https://learn.microsoft.com/power-apps/maker/data-platform/data-platform-mcp-vscode)
- [Add MCP servers in VS Code](https://code.visualstudio.com/docs/agent-customization/mcp-servers)
- [Custom agents in VS Code](https://code.visualstudio.com/docs/agent-customization/custom-agents)

## License

© 2026 Sara Lagerquist. You may use these materials for your own learning and reuse the Lab 4 code in your own projects. Republishing them or using them to run training requires permission. See [LICENSE.md](LICENSE.md).
