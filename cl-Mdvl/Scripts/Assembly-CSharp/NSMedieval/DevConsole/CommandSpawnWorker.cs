using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnWorker : ConsoleCommand
	{
		private bool active;

		private int amount;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnWorker()
		{
			Command = "spawnWorker";
			Description = "Spawns humanoid on mouse click.";
			Help = "Use this command to spawn new humanoid.";
		}

		private void CommandMethod(int amount)
		{
			if (active && this.amount == amount)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnWorker;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnWorker Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnWorker;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {amount}" });
			this.amount = amount;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnWorker Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnWorker()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				return;
			}
			for (int i = 0; i < amount; i++)
			{
				HumanoidInstance humanoid = MonoSingleton<WorkerGenerator>.Instance.GenerateWorker();
				humanoid.UpdatePosition(hit.point);
				MonoSingleton<WorkerController>.Instance.CreateWorker(humanoid);
				MonoSingleton<TaskController>.Instance.WaitFor(0.5f).Then(delegate
				{
					humanoid.GetGoapAgent()?.StartTicker();
				});
			}
		}

		private void OnRightMouseDown()
		{
			CommandMethod(amount);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(amount);
		}
	}
}
