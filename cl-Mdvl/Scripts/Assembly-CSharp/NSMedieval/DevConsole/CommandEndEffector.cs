using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandEndEffector : ConsoleCommand
	{
		private string effectorName;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandEndEffector()
		{
			Command = "endEffector";
			Description = "Click on a humanoid to end effector";
			Help = "Use this command to end effector on humanoid with mouse click.";
		}

		private void CommandMethod(string effectorName)
		{
			if (Repository<EffectorRepository, StatEffector>.Instance.GetByID(effectorName) == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Effector " + effectorName + " not found", ConsoleMessageType.Error);
				return;
			}
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnAgentSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			this.effectorName = effectorName;
			string result = "Click on a humanoid to end effector " + effectorName;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnAgentSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent.AgentOwner is IStatsOwner statsOwner)
			{
				statsOwner.Stats.EndEffector(effectorName);
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnAgentSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
