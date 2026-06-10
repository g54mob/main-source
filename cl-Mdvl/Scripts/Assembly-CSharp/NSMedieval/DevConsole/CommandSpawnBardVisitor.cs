using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnBardVisitor : ConsoleCommand
	{
		private bool active;

		private string bardId;

		private int gender;

		private RaycastHit hit;

		private Ray ray;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnBardVisitor()
		{
			Command = "spawnBardVisitor";
			Description = "Spawns a bard visitor on mouse click.";
			Help = "Use this command to spawn a bard visitor.";
			bardId = string.Empty;
			gender = 0;
		}

		private void CommandMethod(string enemyId, int gender)
		{
			if (bardId.Equals(enemyId) && active)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnBard;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnBard;
			}
			bardId = enemyId;
			this.gender = gender;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {bardId} {gender}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnBard()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				BodyType bodyType = ((gender == 0) ? BodyType.Male : BodyType.Female);
				Vector3 point = hit.point;
				float minFriendliness = GlobalSaveController.CurrentVillageData.WorldMapData.FactionSettings.NeutralRange.Min;
				VillagePlace originVillage = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Where((VillagePlace f) => f.FactionInstance.PlayerFriendliness > minFriendliness).PickRandom();
				HumanoidInstance bardNPC = MonoSingleton<NPCManager>.Instance.SpawnBardVisitor(bardId, bodyType, point, "bard", originVillage);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					bardNPC.GetGoapAgent()?.StartTicker();
				});
			}
		}

		private void OnRightMouseDown()
		{
			CommandMethod(bardId, gender);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(bardId, gender);
		}
	}
}
