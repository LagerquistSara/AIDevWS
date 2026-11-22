# Lab 6 — Optional: create a Copilot Studio agent from VS Code

**Time:** 30 minutes; for fast finishers or as take-home  
**Goal:** use the same way of working — describe, review, approve — to create a Copilot Studio agent from GitHub Copilot Chat, with Microsoft's **mcs-assistant** plugin.

**You need:** a Copilot Studio licence, your workshop developer environment, and the **mcs-assistant** plugin from the optional part of [Lab 1](lab-01-install-plugins.md).

> Use only your workshop developer environment. Do not publish the agent in this lab.

## What you will have after this lab

| You do | What it gives you |
|---|---|
| Ask `/create-agent` for a new agent | A Copilot Studio agent in your environment, with instructions, and its files in your workspace. |
| Add a knowledge source | The agent answers from Microsoft Learn's Power Platform documentation. |
| Test it in Copilot Studio | Proof that the agent works, before anyone publishes it. |

## Part A — Create the agent (12 min)

1. In VS Code, open **Chat: Open Customizations** and check that **mcs-assistant** is installed and enabled under **Plugins**. If it is not, install it as described in the optional part of Lab 1.
2. In Chat, start a **new chat** with **+** and select **Agent** mode.
3. Type `/create-agent` followed by your request:

   > /create-agent Create an agent called "Power Platform Dev Helper" in my workshop developer environment, in a folder called dev-helper-agent in this workspace. It helps makers who are new to developing Power Platform solutions in VS Code. It answers questions about solutions, publishers, tables, plugins and environments in short, plain language, and says so when it does not know. Keep it instructions-only for now and show me the values before you create anything.

4. Check the values GitHub Copilot shows: the display name, your workshop environment and the project folder. Reply *“Create it.”*
5. GitHub Copilot signs you in to Power Platform CLI if needed and creates the agent.
6. Open the `dev-helper-agent` folder and find the agent's instructions. This is the same agent you will see in Copilot Studio.

## Part B — Add knowledge and push the change (8 min)

1. In the same chat, ask:

   > Add the public website https://learn.microsoft.com/power-apps/developer/ as a knowledge source for the agent. Show me the change before you push it to Copilot Studio.

2. Review the changed files in Chat and select **Keep**.
3. Ask GitHub Copilot to push the change to Copilot Studio, and approve the command. Do not publish.

## Part C — Test the agent in Copilot Studio (10 min)

1. Open [Copilot Studio](https://copilotstudio.microsoft.com/), check the environment in the top-right corner and open **Power Platform Dev Helper**.
2. In the **Test** pane, ask:
   - *“What is a publisher prefix?”*
   - *“When should I use a plugin instead of a Power Automate flow?”*
   - *“What is the weather tomorrow?”* — the agent should say this is outside its scope.
3. Check that the answers are short, plain and refer to Microsoft Learn.
4. Change something in the instructions file in VS Code — for example *“Always end with a link to read more.”* — ask GitHub Copilot to push it, and test again.

## Done when

- [ ] The agent exists in Copilot Studio in your workshop environment.
- [ ] It answers from Microsoft Learn in the test pane, and you have changed it once from VS Code.

## Troubleshooting

| Problem | What to do |
|---|---|
| `/create-agent` does not appear when you type `/` | Check that **mcs-assistant** is installed and enabled, then reload VS Code. |
| Power Platform CLI asks you to sign in | Approve the sign-in command and sign in with the work account you use for Copilot Studio. |
| The agent does not appear in Copilot Studio | Check that Copilot Studio shows the same environment as the one GitHub Copilot used, and refresh the page. |
| The push fails because the agent changed in Copilot Studio | Ask GitHub Copilot to pull the latest version first, then push again. |
