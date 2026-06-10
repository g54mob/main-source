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
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnTrader : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		private string traderId;

		private int gender;

		private int bodyguardsCount;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnTrader()
		{
			Command = "spawnTrader";
			Description = "Spawns a trader on mouse click.";
			Help = "Use this command to spawn a trader.";
			traderId = string.Empty;
			gender = 0;
		}

		private void CommandMethod(string enemyId, int gender, int bodyguardsCount)
		{
			if (traderId.Equals(enemyId) && active)
			{
				active = false;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent -= OnSelectionPanelToggle;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnTrader;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<UIController>.Instance.SelectionPanelToggleEvent += OnSelectionPanelToggle;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnTrader;
			}
			traderId = enemyId;
			this.gender = gender;
			this.bodyguardsCount = bodyguardsCount;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {traderId} {gender}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnTrader Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnTrader()
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
			BodyType bodyType = ((gender == 0) ? BodyType.Male : BodyType.Female);
			Vector3 spawnPosition = hit.point;
			float minFriendliness = GlobalSaveController.CurrentVillageData.WorldMapData.FactionSettings.NeutralRange.Min;
			VillagePlace villagePlace = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Where((VillagePlace f) => f.FactionInstance.PlayerFriendliness > minFriendliness).PickRandom();
			TraderType traderType = Repository<TraderTypeRepository, TraderType>.Instance.GetAllItems().PickRandom();
			HumanoidInstance traderHumanoid = MonoSingleton<NPCManager>.Instance.SpawnTrader(traderId, bodyType, spawnPosition, villagePlace, villagePlace?.FactionInstance);
			List<CreatureBase> addedCreatures = new List<CreatureBase>();
			TradingManager.InitTrader(traderHumanoid, traderType, out addedCreatures, null);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				traderHumanoid.GetGoapAgent()?.StartTicker();
			});
			if (bodyguardsCount <= 0)
			{
				return;
			}
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(VillageManager.ActiveVillage.Map.GetNode(GridUtils.GetGridPosition(spawnPosition, 0.01f)), 1000f, (MapNode n) => Vector3.Distance(spawnPosition, n.WorldPosition) < 2f))
			{
				bodyguardsCount--;
				SpawnBodyguard(villagePlace, item.WorldPosition);
				if (bodyguardsCount <= 0)
				{
					break;
				}
			}
		}

		private void SpawnBodyguard(VillagePlace villagePlace, Vector3 position)
		{
			BodyType bodyType = ((Random.value >= 0.5f) ? BodyType.Male : BodyType.Female);
			HumanoidInstance humanoidInstance = MonoSingleton<NPCManager>.Instance.SpawnTraderBodyguard(Repository<NPCRepository, NPC>.Instance.GetAllItems().PickRandom().GetID(), bodyType, position, villagePlace, villagePlace?.FactionInstance);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				humanoidInstance.GetGoapAgent()?.StartTicker();
			});
		}

		private void OnRightMouseDown()
		{
			CommandMethod(traderId, gender, bodyguardsCount);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod(traderId, gender, bodyguardsCount);
		}
	}
}
