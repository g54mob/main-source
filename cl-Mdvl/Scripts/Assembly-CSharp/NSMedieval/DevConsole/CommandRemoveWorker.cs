using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.DevConsole
{
	public class CommandRemoveWorker : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandRemoveWorker()
		{
			Command = "removeWorker";
			Description = "Click on a humanoid to remove it";
			Help = "Use this command to remove humanoid with mouse click.";
		}

		private void CommandMethod()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Click on a humanoid to remove";
			if (GlobalSaveController.CurrentVillageData.Workers.Count <= 0)
			{
				result = "No Workers to remove";
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnWorkerSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent.AgentOwner is HumanoidInstance humanoid)
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorker(humanoid);
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
