using System;
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
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnResourceCategory : ConsoleCommand
	{
		private bool active;

		private ResourceCategory category;

		private Ray ray;

		private RaycastHit hit;

		private readonly HashSet<string> carcassIds = new HashSet<string> { "enemy_carcass", "human_carcass" };

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnResourceCategory()
		{
			Command = "spawnResourceCtg";
			Description = "Spawns resource piles by category on mouse click";
			Help = "Use this command with resource type as string argument to enable on click pile spawn";
			category = ResourceCategory.None;
		}

		private void CommandMethod(string category)
		{
			if (!Enum.TryParse<ResourceCategory>(category, out this.category))
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Unknown resource category", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.Reset();
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent += SpawnPile;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {category}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnResourceCtg Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnPile()
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				return;
			}
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			List<Resource> list = Repository<ResourceRepository, Resource>.Instance.GetAllResourcesByResourceCategory(category).ToList();
			if (category == ResourceCategory.CtgAll)
			{
				list = Repository<ResourceRepository, Resource>.Instance.GetAllItems().ToList();
			}
			if (!Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer))
			{
				return;
			}
			foreach (Resource item in list)
			{
				if (carcassIds.Contains(item.GetID()))
				{
					VillagePlace villagePlace = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePlaces[0];
					BodyType bodyType = ((UnityEngine.Random.Range(0, 2) == 0) ? BodyType.Male : BodyType.Female);
					MonoSingleton<NPCManager>.Instance.SpawnBlank(Repository<NPCRepository, NPC>.Instance.GetAllItems().PickRandom().GetID(), bodyType, hit.point, villagePlace, villagePlace?.FactionInstance).GetStat(StatType.Health).SetCurrent(0f);
					break;
				}
				if (!MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(item.GetID()))
				{
					if (string.IsNullOrEmpty(item.BuildingBlueprintID))
					{
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(item, 1), hit.point);
					}
					else
					{
						MonoSingleton<ResourcePileManager>.Instance.SpawnPile(item, hit.point, item.GetID());
					}
				}
			}
		}

		private void Deactivate()
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= Deactivate;
				MonoSingleton<DebugInputController>.Instance.MouseDownEvent -= SpawnPile;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnResourceCtg Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
			}
		}
	}
}
