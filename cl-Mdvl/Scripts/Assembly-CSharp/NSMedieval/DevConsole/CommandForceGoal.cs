using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandForceGoal : ConsoleCommand
	{
		private string goalName;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandForceGoal()
		{
			Command = "forceGoal";
			Description = "Force run goal on the agent.";
			Help = "Usage: forceGoal <goal_name>";
		}

		private void CommandMethod(string name)
		{
			goalName = name;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			string result = "Set goal '" + goalName + "'";
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " " + goalName });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (obj == null)
			{
				return;
			}
			IGoapAgentOwner goapAgentOwner = obj.GetAsCreature();
			if (goapAgentOwner == null)
			{
				if (!(obj.GetAsWorldObject() is IGoapAgentOwner goapAgentOwner2))
				{
					return;
				}
				goapAgentOwner = goapAgentOwner2;
			}
			if (goapAgentOwner.GetGoapAgent() != null && goapAgentOwner.GetGoapAgent().ForceNextGoal(goalName) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + "</9CFF92><#E61212> " + goalName + " not found!" });
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult($"Goal {goalName} not found for agent: {goapAgentOwner}");
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
