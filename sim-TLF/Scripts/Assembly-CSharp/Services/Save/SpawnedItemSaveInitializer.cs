using AssembleSystem;
using Items;
using Items.Box;
using Services.Save.ActiveItems;
using Services.Save.Assemble;
using Services.Save.Boxes;
using Services.Save.Inventory;
using Services.Save.SpawnedItems;
using UnityEngine;
using Zenject;

namespace Services.Save
{
	public static class SpawnedItemSaveInitializer
	{
		public static void Init(GameObject go, string instanceId, string addressableKey, DiContainer diContainer)
		{
			InitSpawnedItem(go, instanceId, addressableKey, diContainer);
			TryInitBox(go, instanceId, diContainer);
			TryInitAssemble(go, instanceId, diContainer);
			TryInitInventory(go, diContainer);
			TryInitConsumable(go, instanceId, diContainer);
			TryInitActiveItem(go, instanceId, diContainer);
		}

		private static void InitSpawnedItem(GameObject go, string instanceId, string addressableKey, DiContainer diContainer)
		{
			if (!go.TryGetComponent<SpawnedItemSaveHandler>(out var component))
			{
				component = go.AddComponent<SpawnedItemSaveHandler>();
			}
			diContainer.Inject(component);
			component.Init(instanceId, addressableKey);
		}

		private static void TryInitBox(GameObject go, string instanceId, DiContainer diContainer)
		{
			if (go.TryGetComponent<ItemBoxView>(out var _))
			{
				if (!go.TryGetComponent<SpawnedBoxSaveHandler>(out var component2))
				{
					component2 = go.AddComponent<SpawnedBoxSaveHandler>();
				}
				diContainer.Inject(component2);
				component2.Init(go.GetComponent<ItemBoxView>(), instanceId);
			}
		}

		private static void TryInitAssemble(GameObject go, string instanceId, DiContainer diContainer)
		{
			if (go.TryGetComponent<AssembleObjectParent>(out var component))
			{
				if (!go.TryGetComponent<SpawnedAssembleSaveHandler>(out var component2))
				{
					component2 = go.AddComponent<SpawnedAssembleSaveHandler>();
				}
				diContainer.Inject(component2);
				component2.Init(component, instanceId);
			}
		}

		private static void TryInitInventory(GameObject go, DiContainer diContainer)
		{
			if (go.TryGetComponent<IInventoryManagable>(out var _))
			{
				if (!go.TryGetComponent<InventoryItemSaveMarker>(out var component2))
				{
					component2 = go.AddComponent<InventoryItemSaveMarker>();
				}
				diContainer.Inject(component2);
				component2.Init(isSceneItem: false);
			}
		}

		private static void TryInitConsumable(GameObject go, string instanceId, DiContainer diContainer)
		{
			if (go.TryGetComponent<IConsumeChangeProgressable>(out var _))
			{
				if (!go.TryGetComponent<SpawnedConsumableSaveHandler>(out var component2))
				{
					component2 = go.AddComponent<SpawnedConsumableSaveHandler>();
				}
				diContainer.Inject(component2);
				component2.Init(instanceId);
			}
		}

		private static void TryInitActiveItem(GameObject go, string instanceId, DiContainer diContainer)
		{
			if (go.TryGetComponent<IActiveStateSaveable>(out var _))
			{
				if (!go.TryGetComponent<ActiveItemSaveHandler>(out var component2))
				{
					component2 = go.AddComponent<ActiveItemSaveHandler>();
				}
				diContainer.Inject(component2);
				component2.Init(instanceId);
			}
		}
	}
}
