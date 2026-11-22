# Lab 7 — Optional: challenges

**Time:** as long as you like; for fast finishers or as take-home  **Goal:** practise the same way of working on your own, with less guidance.
These are loose tasks. There are no step-by-step prompts, only an idea, a hint and what to check. Pick any task, in any order.

> **The rules from the other labs still apply.** Use only your workshop developer environment. Ask GitHub Copilot to show you a plan before it changes anything, read what it proposes, approve one tool call at a time and review files before you select **Keep**.

## 1. 🎉 Confetti at check-in

*Needs: Lab 3b*

Make the Check-in desk celebrate: a short confetti burst when someone is checked in.

- **Hint:** use `/model-apps:genpage` to update the existing page. Ask for confetti without external scripts or CDNs, and only after the save has succeeded.
- **Check:** the confetti appears after a successful check-in, but not when the save fails or the attendee is already checked in.

## 2. 📊 How many are registered?

*Needs: Lab 4*

An Event has a **Capacity**, but you can't see how many people are registered for it. In Lab 4 you also noticed that you could lower an event's capacity below the number of attendees who are already registered.

1. Show the number of registered attendees on the Event.
2. Stop anyone from setting **Capacity** lower than that number.

- **Hint:** start in **Ask** mode. Ask GitHub Copilot to compare a rollup column, a plugin-maintained count and a count on the form, and which statuses should be counted. Ask which option you can trust when a plugin blocks a save, and why.
- **Check:** the number matches the Event's Registered and Checked-in registrations, and lowering Capacity below it shows a clear error message. Raising it still works.

## 3. ⏫ Promote from the waitlist

*Needs: Lab 4*

When a registration is **Cancelled**, the first **Waitlisted** registration for the same event should become **Registered** automatically.

- **Hint:** ask GitHub Copilot to write a failing test first, then the code. Ask which plugin stage fits and what "first" means.
- **Check:** cancel a registration for a full event, then confirm in the app that the oldest waitlisted attendee is now Registered.

## 4. 📈 Check-in progress

*Needs: Lab 3b*

Show staff how far they've got: for example, *"18 of 25 checked in"* with a progress bar for the selected event.

- **Hint:** describe what you want and let GitHub Copilot update the wireframe first, as in Lab 3b.
- **Check:** the numbers change right after each check-in, without reloading the page.

## 5. 🖼️ Fix your icons

*Needs: Lab 5*

In Lab 5 your `table-icons` skill reviewed your table icons and some may have failed. Now fix them.

- **Hint:** ask GitHub Copilot to fix only the rules that failed, show you the new icons first, and then update the web resources in the solution.
- **Check:** run the same review again. Every rule passes, and the new icons show in the app.

## 6. 🔘 A "Build this" button

*Needs: Lab 5*

Give your Requirements Coach a **handoff**: a button under its answer that passes the finished user story to the default Agent.

- **Hint:** the button should only fill in the prompt, not send it.
- **Check:** after a user story, **Build this** appears. Selecting it pre-fills a prompt in the default Agent, and nothing is sent until you send it.

## 7. 📝 Your own slash command

*Needs: Lab 2*

A prompt file is a saved prompt that you start yourself with `/`. Create one that explains the Event Check-in solution in plain language: its tables, how they relate and which rules protect the data.

- **Hint:** ask GitHub Copilot to create it in `.github/prompts/` and to keep it read-only.
- **Check:** typing `/` in a new chat shows your command, and running it changes nothing.

## 8. 🗓️ Summarise your day

Type `/chronicle:standup` in a new chat. Chronicle summarises what you did in your recent Copilot sessions. Compare it with what you remember from today.

Chronicle can read chat history from other projects too, and it sends relevant content to the AI model. Run it only if you are comfortable with that.
