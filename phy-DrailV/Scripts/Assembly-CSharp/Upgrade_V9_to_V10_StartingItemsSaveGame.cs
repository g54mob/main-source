using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/Inventory (v9 -> v10)")]
public class Upgrade_V9_to_V10_StartingItemsSaveGame : ASaveSnapshotUpgrader
{
	public override int InputVersion => 9;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		HashSet<string> essentialItems = new HashSet<string> { "CommsRadio", "Map", "MapSchematic", "wallet", "Compass" };
		List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>("Storage_Inventory");
		if (objectViaJSON != null)
		{
			UpdateEssentialFlag(objectViaJSON);
			data.SetObjectViaJSON("Storage_Inventory", objectViaJSON);
		}
		List<StorageItemData> objectViaJSON2 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_World");
		if (objectViaJSON2 != null)
		{
			UpdateEssentialFlag(objectViaJSON2);
			data.SetObjectViaJSON("Storage_World", objectViaJSON2);
		}
		List<StorageItemData> objectViaJSON3 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound");
		if (objectViaJSON3 != null)
		{
			UpdateEssentialFlag(objectViaJSON3);
			data.SetObjectViaJSON("Storage_LostAndFound", objectViaJSON3);
		}
		return data;
		void UpdateEssentialFlag(List<StorageItemData> items)
		{
			foreach (StorageItemData item in items)
			{
				if (item != null)
				{
					string itemPrefabName = item.itemPrefabName;
					if (!string.IsNullOrWhiteSpace(itemPrefabName) && !essentialItems.Contains(itemPrefabName) && item.isDropped && (!item.inLockedSlot || !item.isGrabbed))
					{
						item.isDropped = false;
						item.inventorySlotIndex = -1;
					}
				}
			}
		}
	}
}
