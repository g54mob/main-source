using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.StorageUniversal;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandFillStorage : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandFillStorage()
		{
			Command = "fillStorage";
			Description = "Click on storage to fill it with random allowed piles";
			Help = "Use this command to fill storage with random allowed piles and destroy old ones.";
		}

		private void CommandMethod()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string description = Description;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(description);
		}

		private void OnSelected(SelectableObject obj)
		{
			if (obj == null)
			{
				return;
			}
			WorldObject asWorldObject = obj.GetAsWorldObject();
			if (asWorldObject == null || !(asWorldObject is BaseBuildingInstance baseBuildingInstance) || baseBuildingInstance.Blueprint == null || string.IsNullOrEmpty(baseBuildingInstance.Blueprint.ShelfComponentID) || Repository<ShelfComponentRepository, ShelfComponentBlueprint>.Instance.GetByID(baseBuildingInstance.Blueprint.ShelfComponentID) == null)
			{
				return;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			if (map == null)
			{
				return;
			}
			ShelfComponentInstance componentInstance = map.ShelfComponentManager.GetComponentInstance(asWorldObject);
			if (componentInstance == null)
			{
				return;
			}
			foreach (ResourcePileInstance storedPile in componentInstance.GetStoredPiles())
			{
				(storedPile.Stats?.GetStat(StatType.Health)).SetCurrent(0f);
			}
			foreach (UniversalStorage item in componentInstance.AllStorage)
			{
				StorageSlot[] storageSlots = item.StorageSlots;
				foreach (StorageSlot storageSlot in storageSlots)
				{
					Resource resource = item.ResourcesFilter.AllowedResourceTypes.PickRandom();
					if (!(resource == null))
					{
						int amount = ((resource.StackingLimit <= 1) ? 1 : Random.Range(resource.StackingLimit / 2, resource.StackingLimit));
						ResourceInstance resource2 = new ResourceInstance(resource, amount);
						item.StoreResourcePile(resource2, storageSlot);
						if (Random.Range(0, 100) < 100 / item.StorageSlots.Count())
						{
							break;
						}
					}
				}
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
