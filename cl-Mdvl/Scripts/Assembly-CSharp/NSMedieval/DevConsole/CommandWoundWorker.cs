using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.DevConsole
{
	public class CommandWoundWorker : ConsoleCommand
	{
		private string woundId;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandWoundWorker()
		{
			Command = "woundWorker";
			Description = "Click on a humanoid to wound it";
			Help = "Use this command to wound humanoid with mouse click.";
			woundId = "shallow_cut_arm";
		}

		private void CommandMethod(string woundId)
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Click on a humanoid to wound";
			if (GlobalSaveController.CurrentVillageData.Workers.Count <= 0)
			{
				result = "No Workers to wound";
			}
			this.woundId = woundId;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnWorkerSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent.AgentOwner is CreatureBase creatureBase)
			{
				creatureBase.Stats.StartEffector(woundId);
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
