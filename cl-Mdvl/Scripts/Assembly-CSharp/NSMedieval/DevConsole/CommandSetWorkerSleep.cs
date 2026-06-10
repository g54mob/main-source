using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandSetWorkerSleep : ConsoleCommand
	{
		private float sleepLevel;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWorkerSleep()
		{
			Command = "setSleep";
			Description = "Set creature's sleep level (if it has a sleep stat)";
			Help = "Usage: setSleep <sleep_level>";
		}

		private void CommandMethod(float value)
		{
			sleepLevel = value;
			string result = "Click on a creature to set its sleep level.";
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {value}" });
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				(agent.AgentOwner as CreatureBase)?.Stats.GetStat(StatType.Sleep)?.SetCurrent(sleepLevel);
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
