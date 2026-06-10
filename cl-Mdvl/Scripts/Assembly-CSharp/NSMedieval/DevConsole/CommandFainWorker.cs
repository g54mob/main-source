using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandFainWorker : ConsoleCommand
	{
		private float consiousnessLevel;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandFainWorker()
		{
			Command = "setConsciousness";
			Description = "Set consciousness level of workers or enemies.";
			Help = "Set consciousness level of workers or enemies. 0 = unconscious, 100 = totally conscious.";
		}

		private void CommandMethod(float value)
		{
			string result = $"Set consciousness level to {value}%.";
			consiousnessLevel = value;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent != null && agent.AgentOwner is CreatureBase creatureBase && creatureBase.Stats?.GetStat(StatType.Consciousness) != null)
			{
				creatureBase.Stats.GetStat(StatType.Consciousness).SetCurrent(consiousnessLevel);
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
