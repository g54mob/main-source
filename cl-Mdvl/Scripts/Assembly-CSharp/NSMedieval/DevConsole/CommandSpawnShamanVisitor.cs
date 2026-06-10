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
	public class CommandSpawnShamanVisitor : ConsoleCommand
	{
		private bool active;

		private int gender;

		private RaycastHit hit;

		private Ray ray;

		private string shamanId;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnShamanVisitor()
		{
			Command = "spawnShamanVisitor";
			Description = "Spawns a shaman visitor on mouse click.";
			Help = "Use this command to spawn a shaman visitor.";
			shamanId = string.Empty;
			gender = 0;
		}

		private void CommandMethod(string enemyId, int gender)
		{
			if (shamanId.Equals(enemyId) && active)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnShaman;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnShaman;
			}
			shamanId = enemyId;
			this.gender = gender;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {shamanId} {gender}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnShaman()
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
				HumanoidInstance shamanNPC = MonoSingleton<NPCManager>.Instance.SpawnShamanVisitor(shamanId, bodyType, point, "shaman", originVillage);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					shamanNPC.GetGoapAgent()?.StartTicker();
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
			CommandMethod(shamanId, gender);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(shamanId, gender);
		}
	}
}
