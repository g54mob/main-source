using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class AnyItemPresentCondition : AQuickTutorialCondition
	{
		private string message;

		private string[] itemPrefabNames;

		public AnyItemPresentCondition(string[] itemPrefabNames, string message = null)
		{
			this.itemPrefabNames = itemPrefabNames;
			if (string.IsNullOrEmpty(message))
			{
				this.message = "You need to have a " + itemPrefabNames[0];
			}
			else
			{
				this.message = message;
			}
		}

		public AnyItemPresentCondition(string itemPrefabName, string message = null)
		{
			itemPrefabNames = new string[1] { itemPrefabName };
			if (string.IsNullOrEmpty(message))
			{
				this.message = "You need to have a " + itemPrefabNames[0];
			}
			else
			{
				this.message = message;
			}
		}

		public override string Check()
		{
			StorageController instance = SingletonBehaviour<StorageController>.Instance;
			if (!instance)
			{
				return message;
			}
			foreach (StorageBase allStorage in instance.allStorages)
			{
				if (allStorage == instance.StorageLostAndFound)
				{
					continue;
				}
				foreach (ItemBase storageItem in allStorage.GetStorageItemList())
				{
					if (storageItem == null)
					{
						continue;
					}
					string[] array = itemPrefabNames;
					foreach (string text in array)
					{
						if (storageItem.InventorySpecs.ItemPrefabName == text)
						{
							if (allStorage == instance.StorageInventory)
							{
								return string.Empty;
							}
							if (allStorage == instance.StorageWorld && Vector3.SqrMagnitude(storageItem.transform.position - PlayerManager.PlayerTransform.position) < 225f)
							{
								return string.Empty;
							}
						}
					}
				}
			}
			return message;
		}
	}
}
