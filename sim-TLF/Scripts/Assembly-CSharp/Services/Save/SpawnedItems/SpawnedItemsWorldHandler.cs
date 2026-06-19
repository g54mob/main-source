using Services.Save.Inventory;
using UnityEngine;
using Zenject;

namespace Services.Save.SpawnedItems
{
	public class SpawnedItemsWorldHandler : MonoBehaviour
	{
		[Inject]
		private SpawnedItemsRegistry _spawnedItemsRegistry;

		[Inject]
		private InventorySaveService _inventorySaveService;
	}
}
