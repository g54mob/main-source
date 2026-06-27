using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using UnityEngine;

namespace Restory.Gameplay.Inventory
{
	[Serializable]
	public class Inventory : MonoBehaviour, IInventory, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private string title = "Inventory";

		[SerializeField]
		private StorageElasticElements storageElements = new StorageElasticElements(0);

		public string Title => title;

		public StorageElasticElements StorageElements => storageElements;

		public void RestoreState(object state)
		{
			try
			{
				storageElements.Clear();
				foreach (StorageItemElement storageItem in DataMigrationWizard.Migrate<InventorySaveData>(state, base.gameObject).StorageItems)
				{
					storageElements.AddItem(storageItem);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				List<StorageItemElement> list = new List<StorageItemElement>();
				foreach (IReadOnlyStorageSlot storageElement in storageElements)
				{
					if (storageElement.Item is StorageItemElement item)
					{
						list.Add(item);
					}
				}
				return new InventorySaveData
				{
					StorageItems = list
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
