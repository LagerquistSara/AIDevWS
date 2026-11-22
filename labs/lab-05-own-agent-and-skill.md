# Lab 5 — Build your own agent and skill

**Time:** 25 minutes  
**Goal:** understand how a custom agent and a skill change what GitHub Copilot does, by building and testing one of each.

## Part A — Create a Requirements Coach (10 minutes)

A custom agent is a Markdown file that gives GitHub Copilot a role, instructions and a limited set of tools. You ask the default agent to write it.

1. In your `UG Workshop` workspace, start a new chat. Select the **+** at the bottom left of the chat box, choose **Agent…**, then **Agent**. This is the general-purpose agent that will write your new one. Ask:

   > Create a new custom agent in `.github/agents/requirements-coach.agent.md` named Requirements Coach. Include a short description in the file header.
   >
   > Its job is to help Power Platform makers turn a business request into a testable user story, without building anything. It should ask a few focused questions at a time about the audience, roles and permissions, timing, exceptions, data quality, and failure handling. It should not invent answers; record unknowns as open questions. Once it has enough information, it should return a problem statement, a user story, numbered acceptance criteria, assumptions, and unresolved questions.
   >
   > In the file header, set `tools: ['read', 'search']` and no other tools. In the agent's instructions, prohibit editing files, running commands, and changing Dataverse. While creating the agent, do not change any other files, run commands, or connect to Dataverse. Explain the definition in plain language and show me the proposed edit.

2. Open the proposed file from Chat and review it:
   - The file is `.github/agents/requirements-coach.agent.md`. Check the spelling: the file name decides which file you edit later.
   - The name is **Requirements Coach**, and the header lists only `read` and `search` under `tools`. The header is the section between the `---` lines at the top.
   - The instructions say what questions to ask and what to produce, and say not to implement, run commands, or change Dataverse.

   If anything is missing or different, ask GitHub Copilot to correct it. When you are happy with the file, select **Keep**. Creating this file does not change Dataverse.

### Test your agent

After you create and keep the agent file, test it in a new chat:

1. Select the **+** at the bottom left of the chat box, choose **Agent…**, then **Requirements Coach**. Try:

   > We want to send reminders to attendees before events.

2. Answer its questions. Check that it asks about audience/roles, timing, exceptions, data quality, permissions, and failure handling before proposing acceptance criteria. The questions may come over several messages.
3. Check that the result includes a user story and acceptance criteria. Inspect the transcript and verify the agent did not call a write tool.

Now verify where VS Code found your agent:

1. Open **Explorer** and expand **.github → agents**. VS Code automatically picks up every `.agent.md` file in this folder.
2. Select the **+** at the bottom left of the chat box, then **Agent…**. **Requirements Coach** should be in the list.
3. Scroll to the bottom of that list and select **Configure Custom Agents…**. Your agent is listed under **Workspace**. You can also create an empty agent file from this page with **+**.

   > **Workspace or user agent?** An agent in `.github/agents` belongs to this workspace. It appears in the agent picker only when the `UG Workshop` folder is open, and anyone who gets the folder gets the agent too. To use an agent in all your workspaces, create it under **User** on the **Configure Custom Agents** page instead. User agents are stored in your VS Code profile, so only you have them.

## Part B — Create a table-icons skill (15 minutes)

An agent is a role you choose. A skill is know-how that GitHub Copilot loads by itself when a task needs it. In Lab 3, `/model-apps:app-builder` drew your table icons using Microsoft's rules. Now you write stricter rules for a proper table icon in a skill, and see what happens when Copilot reviews the same icons with them.

1. Start a new chat. Select the **+** at the bottom left of the chat box, choose **Agent…**, then **Agent**. Ask:

   > Create a new agent skill in `.github/skills/table-icons/SKILL.md`. Set its `name` to `table-icons`. Its `description` must say that it is used when creating or reviewing icons for custom Dataverse tables in model-driven apps.
   >
   > The skill should describe how a proper table icon is made:
   >
   > - Every custom table has its own SVG icon; icons are never shared between tables. Do not use PNG or JPG icons.
   > - The icon shows what the table is for, such as a calendar for an event. It is never just a letter or a coloured tile.
   > - It matches the built-in Fluent icons for tables such as Account and Contact: a single colour, simple outlines with an even line weight, and no background.
   > - It is square, with `width`, `height` and `viewBox` set (for example 24 × 24), has a transparent background and is no larger than 10 KB.
   > - It uses `currentColor` so the app theme can colour it. It has no fixed colour codes, `<style>` blocks or CSS classes.
   > - The SVG file is kept in the workspace, deployed as an SVG web resource in the same solution and set as the table's icon. It is never created only in the maker portal.
   > - Before drawing an icon, describe in words what it will show.
   >
   > Add a review checklist that marks each rule as pass, fail or cannot check, with evidence. Do not change any other files, run commands or connect to Dataverse. Show me the proposed file.

2. Open the proposed file from Chat and review it:
   - The file is `.github/skills/table-icons/SKILL.md`, and the folder name matches the `name` in the header.
   - The `description` says when to use the skill. GitHub Copilot reads this description to decide whether to load the skill, so a vague description means the skill is not used.
   - Each rule above is included, together with the review checklist.

   If anything is missing, ask GitHub Copilot to correct it. When you are happy with the file, select **Keep**.

   > **Workspace or user skill?** Like your agent, a skill in `.github/skills` belongs to this workspace. It is available only when the `UG Workshop` folder is open, and anyone who gets the folder gets the skill too. To use a skill in all your workspaces, put its folder in your user profile instead: `%USERPROFILE%\.copilot\skills\table-icons\SKILL.md` on Windows or `~/.copilot/skills/table-icons/SKILL.md` on Mac. Only you have user skills.

### Test your skill

After you create and keep the skill file, test it in a new chat. Do not mention the skill by name yet.

1. Start a new chat with **+ → Agent… → Agent** and ask:

   > Review the table icons in `event-checkin/icons/` from Lab 3. List the rules you used and which file they came from. Mark each rule as pass, fail or cannot check, with evidence. Do not change anything.

   If you have no icon files from Lab 3, ask instead: *“Describe in words an icon for the Event table that follows the table-icons rules. Do not create files.”*

2. Check whether the skill was used: expand the steps in the answer and look for `table-icons/SKILL.md`, or check that the rules listed come from it. If it was not used, type `/table-icons` in a new chat, select it from the suggestions, and ask again.
3. Read the review. Do not fix anything. Some icons may fail rules even though they looked fine in Lab 3. They aren't wrong; app-builder just didn't know these rules. That is what a skill adds.

## Done when

The agent appears in the workspace agent picker and returns a user story/acceptance criteria without modifying files. The `table-icons` skill is used to review your table icons, either automatically or with `/table-icons`.

## Try Chronicle tips

You've now had several chats. Chronicle can look at your recent Copilot sessions and suggest ways to improve how you work.

> **Before you try it:** Chronicle may use chat history from other projects, not just this workshop, and send relevant content to the AI model. Run it only if you are comfortable with that. Review the response before sharing it.

1. Start a new chat and select **+ → Agent… → Agent** at the bottom left of the chat box.
2. Type `/chronicle:tips`, select it from the suggestions, and send it.
3. Read the suggestions and choose one you would like to try in a future chat. You do not need to make any changes now.

If the command is not available in your VS Code setup, skip it. If you are new to Copilot, Chronicle may need more session history before its tips are useful. See [VS Code's session history guide](https://code.visualstudio.com/docs/agents/run/sessions/session-history#_query-session-history-with-chronicle).

> **For later:** teams share agents and skills by packaging them as a plugin in their own marketplace, like the Microsoft plugins from Lab 1. That needs a repository, which is one of the terms on the "dictionary for the future" slide. It is not part of today.
