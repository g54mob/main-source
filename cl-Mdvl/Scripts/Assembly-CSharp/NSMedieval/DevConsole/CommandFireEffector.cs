using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandFireEffector : ConsoleCommand
	{
		private bool active;

		private string effectorName;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandFireEffector()
		{
			Command = "fireEffector";
			Description = "Click on a humanoid to apply effector to it";
			Help = "Use this command to trigger effector on humanoid with mouse click.";
		}

		private void CommandMethod(string effectorName)
		{
			if (Repository<EffectorRepository, StatEffector>.Instance.GetByID(effectorName) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Effector " + effectorName + " not found", ConsoleMessageType.Error);
				active = false;
				return;
			}
			if (active && this.effectorName == effectorName)
			{
				active = false;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnAgentSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Console command " + Command + " disabled");
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnAgentSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			}
			this.effectorName = effectorName;
			string result = "Click on a humanoid to fire effector " + effectorName;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnAgentSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent.AgentOwner is IStatsOwner statsOwner)
			{
				statsOwner.Stats.StartEffector(effectorName);
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnAgentSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			active = false;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
