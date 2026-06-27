using System.Collections.Generic;
using Restory.Gameplay.Elements;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using Zenject;

namespace Restory.Gameplay.Inventory
{
	public class StorageElasticElementsDropService
	{
		private readonly List<IReadOnlyStorageSlot> droppedSlots = new List<IReadOnlyStorageSlot>();

		private StorageElasticElements currentStorage;

		private ElementService elementService;

		public bool IsProcess { get; private set; }

		[Inject]
		public void Construct(ElementService elementService)
		{
			this.elementService = elementService;
		}

		public void DropItems(StorageElasticElements storage, IEnumerable<IReadOnlyStorageSlot> slots)
		{
			if (!elementService.IsPlacementProcess && !IsProcess)
			{
				IsProcess = true;
				currentStorage = storage;
				elementService.OnItemReadyToDrop += OnItemReadyToDrop;
				elementService.OnPostDrop += OnPostDrop;
				elementService.DropItemsFromStorage(slots);
			}
		}

		private void OnItemReadyToDrop(IReadOnlyStorageSlot storageItemElement)
		{
			droppedSlots.Add(storageItemElement);
		}

		private void OnPostDrop()
		{
			elementService.OnItemReadyToDrop -= OnItemReadyToDrop;
			elementService.OnPostDrop -= OnPostDrop;
			for (int i = 0; i < droppedSlots.Count; i++)
			{
				currentStorage.ClearItem(droppedSlots[i].Index);
			}
			droppedSlots.Clear();
			IsProcess = false;
		}
	}
}
