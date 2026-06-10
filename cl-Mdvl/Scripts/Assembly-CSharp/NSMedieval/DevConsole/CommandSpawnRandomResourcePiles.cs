using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnRandomResourcePiles : ConsoleCommand
	{
		private bool active;

		private int amount;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnRandomResourcePiles()
		{
			Command = "spawnRandomResources";
			Description = "Spawns random resource piles on mouse click";
			Help = "Use this command with resource types as string array argument to enable on click pile spawn";
		}

		private void CommandMethod(int amount)
		{
			if (active)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnRandomPiles;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnPile Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnRandomPiles;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {amount}" });
			this.amount = amount;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnRandomPiles Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnRandomPiles()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				for (int i = 0; i < amount; i++)
				{
					Resource blueprint = Repository<ResourceRepository, Resource>.Instance.GetAllItems().PickRandom();
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(blueprint, 1), hit.point);
				}
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
