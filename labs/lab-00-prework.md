# Lab 0 — Get ready before the workshop

**When:** before the workshop. Allow 20–30 minutes, plus time for any administrator approvals.  
**Goal:** install VS Code, let GitHub Copilot install the other tools for you, and check that you have a safe Power Platform environment.

## How to do this lab

Work through the sections in order. You install VS Code yourself and sign in to GitHub Copilot. After that, GitHub Copilot installs the remaining tools: it shows each command and waits for you to select **Allow**. You never type commands yourself. If something is blocked, section 3 has a manual fallback.

You need:

- A GitHub account with a **paid GitHub Copilot licence**.
- A Windows or macOS computer, internet access, and permission to install software. On a managed work computer, ask IT before you start; they may install the tools for you from a company portal such as Company Portal or Self Service.
- A non-production Power Platform environment with Dataverse, or help from your administrator to get one (section 5).

Never put passwords, tokens, customer data or confidential information in GitHub Copilot Chat.

### Find out which processor you have

Several downloads ask you to choose between **x64** (Intel/AMD) and **Arm64**.

- **Windows:** open **Settings → System → About**. Under **Device specifications**, read **System type**. “x64-based processor” means x64; “ARM-based processor” means Arm64.
- **macOS:** open the **Apple menu → About This Mac**. If **Chip** says *Apple M…*, you have Apple silicon (Arm64). If it says **Processor … Intel**, you have Intel (x64).

## 1. Install Visual Studio Code

1. Open the official download page: <https://code.visualstudio.com/download>.
2. Download the right installer:
   - **Windows:** under the Windows logo, choose **User Installer** and then **x64** or **Arm64**. The User Installer does not need administrator rights.
   - **macOS:** select **Apple silicon** or **Intel chip** to match your Mac. A `.zip` file is downloaded.
3. Install it:
   - **Windows:** run the downloaded `VSCodeUserSetup-….exe`. Accept the licence agreement and keep the default folder. On **Select Additional Tasks**, keep **Add to PATH** ticked and also tick **Add "Open with Code" action to Windows Explorer file context menu** and **Add "Open with Code" action to Windows Explorer directory context menu**. Select **Install**, then **Finish** with **Launch Visual Studio Code** ticked.
   - **macOS:** open the downloaded `.zip` file in **Downloads**. Drag **Visual Studio Code.app** into the **Applications** folder. Open it from **Applications** and select **Open** if macOS asks whether you want to open an app downloaded from the internet.
4. Optional: keep VS Code in the Dock (macOS) or pin it to the taskbar (Windows).

More help: [Set up VS Code on Windows](https://code.visualstudio.com/docs/setup/windows) · [Set up VS Code on macOS](https://code.visualstudio.com/docs/setup/mac).

## 2. Sign in to GitHub Copilot in VS Code

GitHub Copilot is built into current versions of VS Code.

1. In VS Code, hover over the **GitHub Copilot icon** in the Status Bar at the bottom of the window and select **Use AI Features**. If you see **Sign in to use GitHub Copilot** instead, select that.
2. Choose **Continue with GitHub**. If your GitHub Copilot licence belongs to a GitHub Enterprise account on GHE.com, choose **Continue with GHE.com** instead.
3. Your browser opens. Sign in with the GitHub account that has your **paid** GitHub Copilot licence and select **Authorize Visual Studio Code**.
4. If the browser asks to open Visual Studio Code, allow it. Return to VS Code.
5. Open the Chat view with **Ctrl+Alt+I** (Windows) or **Ctrl+Cmd+I** (macOS), or from **View → Chat**.
6. Make sure **Agent** is selected in the mode picker at the bottom of the chat box. Type *“In one sentence, what can you help me do in a Power Platform workshop?”* and press Enter. GitHub Copilot should answer.
7. Check that you are using the right account: select the **Accounts** icon in the bottom-left corner of VS Code. It should show the GitHub account with your paid licence. If not, select **Sign out** and repeat steps 1–4.

More help: [Set up GitHub Copilot in VS Code](https://code.visualstudio.com/docs/setup/copilot).

## 3. Let GitHub Copilot install the developer tools

The Power Platform plugins and labs need four tools in the background: **Git** (downloads the plugin marketplaces in Lab 1), **Node.js** (runs plugin servers), the **.NET 10 SDK** (builds the plugin in Lab 4) and **Azure CLI** (signs you in to your environment in Lab 2). You don't have to install them one by one: GitHub Copilot checks what is missing and installs it.

This is also your first taste of how the workshop works: describe the task, let the agent work, and check the result.

1. Close all other VS Code windows, so that only one is open.
2. Open the Chat view (**Ctrl+Alt+I** on Windows, **Ctrl+Cmd+I** on macOS), start a new chat with **+** and check that **Agent** is selected.
3. Paste this prompt and press Enter:

   > Check whether these tools are installed on this computer: Git, Node.js LTS, .NET 10 SDK and Azure CLI. Show me a table with what you found. Then install what is missing, using winget on Windows or Homebrew on macOS, without interactive prompts.

4. Follow the prompts in Chat to run the checks and installations.

5. **Windows:** a window asking *“Do you want to allow this app to make changes to your device?”* may appear for some installs. Check that it names the tool being installed and select **Yes**. The window may be hidden behind VS Code; look for a flashing shield icon on the taskbar.
6. When GitHub Copilot is done, **quit VS Code completely and open it again**. New tools are only found after a restart.
7. Start a new chat and ask:

   > Check again which versions of Git, Node.js, the .NET SDK and Azure CLI are installed. Show a table. Do not install anything.

   All four should show a version. The .NET SDK version must start with **10.0**.

**macOS: Git and Homebrew.**

- Git is part of Apple's Command Line Tools. If GitHub Copilot says Git is missing, open the **Source Control** view (**Ctrl+Shift+G**). If macOS shows a dialog saying the `git` command requires the command line developer tools, select **Install** and then **Agree**, then restart VS Code.
- If GitHub Copilot reports that **Homebrew** is not installed, don't let it install Homebrew; that needs your Mac password in a terminal. Use the manual fallback below for Node.js and .NET, and contact the facilitator about Azure CLI before the workshop.

### Fallback: install manually

Use this only if your computer blocks the commands, for example on a managed work laptop. Ask IT first: they may install the tools for you from a company portal such as Company Portal or Self Service.

| Tool | Official download | Tips |
|---|---|---|
| Git | Windows: <https://git-scm.com/install/windows> · macOS: see *macOS: Git and Homebrew* above | Keep the recommended defaults. |
| Node.js (LTS) | <https://nodejs.org/en/download> | Choose the **LTS** version and the **Windows Installer (.msi)** or **macOS Installer (.pkg)**. On Windows, leave **Automatically install the necessary tools** unticked. |
| .NET 10 SDK | <https://dotnet.microsoft.com/en-us/download/dotnet/10.0> | Choose the **SDK** installer (under *Build apps*), not the Runtime. |
| Azure CLI | Windows: <https://aka.ms/installazurecliwindowsx64> · macOS: [Homebrew only](https://learn.microsoft.com/cli/azure/install-azure-cli-macos) | Accept the defaults. |

Choose **x64** or **Arm64** to match your processor (see the start of this lab). Restart VS Code after installing, then run the check in step 7.

## 4. Install Power Platform Tools in VS Code

The [Power Platform Tools extension](https://marketplace.visualstudio.com/items?itemName=microsoft-IsvExpTools.powerplatform-vscode) adds Power Platform features to VS Code. It is a VS Code **extension**; the AI **plugins** you add in Lab 1 are something different.

1. In VS Code, open the **Extensions** view: **Ctrl+Shift+X** (Windows) or **Cmd+Shift+X** (macOS), or the four-squares icon in the Activity Bar.
2. In the search box, type `Power Platform Tools`.
3. Select the result **Power Platform Tools** published by **Microsoft** (check for the verified-publisher tick).
4. Select **Install**. If VS Code asks whether you trust the publisher, select **Trust Publisher & Install**.
5. If VS Code asks you to reload or restart, do so.
6. Check that a **Power Platform** icon now appears in the Activity Bar on the left. Select it to see the **Auth Profiles** and **Environments & Solutions** panels.

You do not need to sign in to Power Platform Tools now.

More help: [Install Power Platform Tools](https://learn.microsoft.com/power-platform/developer/howto/install-vs-code-extension).

## 5. Check your Power Platform environment

1. Open [Power Apps](https://make.powerapps.com/) and sign in with the work or school account you will use for the workshop. This may be a different account from your GitHub account.
2. Select the environment picker in the top-right corner and choose your **non-production** environment. It must have Dataverse, and you need permission to import an unmanaged solution, create records and register a plugin. Ask your environment administrator if you are unsure.
3. Check that Dataverse is available: select **Tables** in the left navigation. If you see a list of tables such as *Account* and *Contact*, Dataverse is there.
4. Find the environment address: select the **gear icon → Session details** and note the **Instance URL**, for example `https://contoso-dev.crm4.dynamics.com/`. You need it in Lab 2, where you give it to GitHub Copilot so that it connects to the right environment.

If you need an environment, talk to your administrator early. Since **15 November 2026**, signing up for the [Power Apps Developer Plan](https://learn.microsoft.com/power-platform/developer/plan) no longer creates a developer environment, and nobody can create new **unmanaged** developer environments. You can still create **one managed developer environment** per user, if your tenant allows it. Existing unmanaged developer environments still work on the workshop day, but Microsoft suspends them from 15 December 2026 and deletes them from 15 January 2027 ([details](https://learn.microsoft.com/power-platform/important-changes-coming)). If you want to keep your work, use a managed developer environment or another non-production environment. A *managed environment* is not the same thing as a *managed solution*.

## 6. Ask your administrator about Dataverse MCP

In Lab 2, GitHub Copilot reads your Dataverse environment through **Dataverse MCP**. Your environment administrator must allow the **Microsoft GitHub Copilot** MCP client.

1. Send your administrator the [official Dataverse MCP configuration guide](https://learn.microsoft.com/power-apps/maker/data-platform/data-platform-mcp-disable) and the name of your workshop environment.
2. Ask them to do the following in the [Power Platform admin center](https://admin.powerplatform.microsoft.com/):
   1. **Manage → Environments**, then select your workshop environment.
   2. **Settings → Product → Features**.
   3. Under **Dataverse Model Context Protocol**, turn on **Allow MCP clients to interact with Dataverse MCP server** and open **Advanced Settings**.
   4. Open the **Microsoft GitHub Copilot** client record, set **Is Enabled** to **Yes**, then select **Save & Close**.
3. Ask them to confirm by email when it is done.

If it cannot be enabled, tell the facilitator. You can still do the parts of the workshop that use local files.

Signing in alone does not enable this client. [Lab 2](lab-02-workspace-mcp-instructions.md) repeats the setup steps and explains how to distinguish a blocked client from an account, consent or permissions error.

> Optional: GitHub Copilot Chat in VS Code can write the request for you. Open Chat and ask: *“Write a short, polite request to my Power Platform administrator to enable the Microsoft GitHub Copilot client for Dataverse MCP in my non-production workshop environment. Include this guide: https://learn.microsoft.com/power-apps/maker/data-platform/data-platform-mcp-disable.”*

## 7. Optional tools

- **GitHub Copilot app:** a desktop app for agent sessions. [Download and installation instructions](https://github.com/features/ai/github-app). It is optional; the labs use VS Code.
- **Power Platform AI plugins:** [browse Microsoft's Power Platform plugins](https://microsoft.github.io/power-platform-skills/) to see what is available. We add them together in Lab 1. Do not use the “quick install” terminal command on that site.

## Checklist

Before the workshop, confirm:

- [ ] VS Code opens, and GitHub Copilot Chat answers in **Agent** mode while signed in with my paid account.
- [ ] After restarting VS Code, GitHub Copilot's check shows versions for **Git**, **Node.js**, **.NET SDK 10.0** and **Azure CLI**.
- [ ] **Power Platform Tools** is installed, and its icon appears in VS Code.
- [ ] I can open my non-production Dataverse environment, and I have noted its Instance URL.
- [ ] My administrator has enabled the Dataverse MCP client, or I have told the facilitator that it is blocked.

Bring screenshots of any error messages to the workshop. Never share passwords or tokens.
