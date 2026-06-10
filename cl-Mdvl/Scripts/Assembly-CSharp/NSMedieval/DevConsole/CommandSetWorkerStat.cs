using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandSetWorkerStat : ConsoleCommand
	{
		private StatType category;

		private int statAmount;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWorkerStat()
		{
			Command = "setWorkerStat";
			Description = "Set humanoid stat by clicking on a humanoid.";
			Help = "Usage: setWorkerStat <StatType> <amount>. Note that StatType equals to StatType enum (capital letters too).";
			category = StatType.None;
		}

		private void CommandMethod(string category, string amount)
		{
			if (!Enum.TryParse<StatType>(category, out this.category))
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown stat category", ConsoleMessageType.Error);
				return;
			}
			statAmount = int.Parse(amount);
			string result = "Click on a creature to set its hunger level.";
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {category} {statAmount}" });
		}

		private void OnWorkerSelected(Agent agent)
		{
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
