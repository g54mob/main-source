using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnPriestVisitor : ConsoleCommand
	{
		private bool active;

		private int gender;

		private RaycastHit hit;

		private string priestId;

		private Ray ray;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnPriestVisitor()
		{
			Command = "spawnPriestVisitor";
			Description = "Spawns a priest visitor on mouse click.";
			Help = "Use this command to spawn a priest visitor.";
			priestId = string.Empty;
			gender = 0;
		}

		private void CommandMethod(string enemyId, int gender)
		{
			if (priestId.Equals(enemyId) && active)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnPriest;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnPriest;
			}
			priestId = enemyId;
			this.gender = gender;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {priestId} {gender}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnPriest()
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
				HumanoidInstance priestNPC = MonoSingleton<NPCManager>.Instance.SpawnVisitorPriest(priestId, bodyType, point, "priest", originVillage);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					priestNPC.GetGoapAgent()?.StartTicker();
				});
			}
		}

		private void SpawnBodyguard(VillagePlace villagePlace, Vector3 position)
		{
			BodyType bodyType = ((Random.value >= 0.5f) ? BodyType.Male : BodyType.Female);
			HumanoidInstance npcInstance = MonoSingleton<NPCManager>.Instance.SpawnTraderBodyguard(Repository<NPCRepository, NPC>.Instance.GetAllItems().PickRandom().GetID(), bodyType, position, villagePlace, villagePlace?.FactionInstance);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				npcInstance.GetGoapAgent()?.StartTicker();
			});
		}

		private void OnRightMouseDown()
		{
			CommandMethod(priestId, gender);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(priestId, gender);
		}
	}
}
