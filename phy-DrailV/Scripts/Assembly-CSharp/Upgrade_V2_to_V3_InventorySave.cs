using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/Inventory (v2 -> v3)")]
public class Upgrade_V2_to_V3_InventorySave : ASaveSnapshotUpgrader
{
	public override int InputVersion => 2;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		int? num = data.GetInt("Version");
		if (!num.HasValue)
		{
			Debug.LogError("Loaded savegame doesn't have version info, savegame upgrade aborted.");
			return null;
		}
		int upgradeStepVersion = num.Value;
		HashSet<string> essentialItemPrefabsNames;
		HashSet<string> unprocessedEssentialItemPrefabNames;
		List<int> duplicateItemIndices;
		if (upgradeStepVersion == 7)
		{
			Upgrade_V1_to_V2_LegacySaveGame.RecordVersions(data, ref upgradeStepVersion);
			essentialItemPrefabsNames = new HashSet<string> { "Map", "MapSchematic", "CommsRadio", "wallet", "DVGuide", "ControlsNonVR" };
			unprocessedEssentialItemPrefabNames = new HashSet<string>(essentialItemPrefabsNames);
			duplicateItemIndices = new List<int>();
			int num2 = 0;
			List<StorageItemData> list = data.GetObjectViaJSON<List<StorageItemData>>("Storage_Inventory");
			if (list != null)
			{
				int num3 = 0;
				for (int i = 0; i < list.Count; i++)
				{
					StorageItemData storageItemData = list[i];
					string itemPrefabName = storageItemData.itemPrefabName;
					if (IsEssential(itemPrefabName) && IsDuplicateEssentialItem(itemPrefabName, i))
					{
						num3++;
						continue;
					}
					storageItemData.inventorySlotIndex = i;
					storageItemData.isDropped = false;
					storageItemData.inLockedSlot = false;
					list[i] = storageItemData;
					num2 = i - num3;
				}
				for (int num4 = duplicateItemIndices.Count - 1; num4 >= 0; num4--)
				{
					int index = duplicateItemIndices[num4];
					list.RemoveAt(index);
				}
				data.SetObjectViaJSON("Storage_Inventory", list);
			}
			List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound");
			if (objectViaJSON != null)
			{
				duplicateItemIndices.Clear();
				for (int j = 0; j < objectViaJSON.Count; j++)
				{
					StorageItemData storageItemData2 = objectViaJSON[j];
					string itemPrefabName2 = storageItemData2.itemPrefabName;
					int inventorySlotIndex = -1;
					bool isDropped = false;
					if (IsEssential(itemPrefabName2))
					{
						if (IsDuplicateEssentialItem(itemPrefabName2, j))
						{
							continue;
						}
						inventorySlotIndex = ++num2;
						isDropped = true;
					}
					storageItemData2.inventorySlotIndex = inventorySlotIndex;
					storageItemData2.isDropped = isDropped;
					objectViaJSON[j] = storageItemData2;
				}
				for (int num5 = duplicateItemIndices.Count - 1; num5 >= 0; num5--)
				{
					int index2 = duplicateItemIndices[num5];
					objectViaJSON.RemoveAt(index2);
				}
				data.SetObjectViaJSON("Storage_LostAndFound", objectViaJSON);
			}
			List<StorageItemData> objectViaJSON2 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_World");
			if (objectViaJSON2 != null)
			{
				duplicateItemIndices.Clear();
				for (int k = 0; k < objectViaJSON2.Count; k++)
				{
					StorageItemData storageItemData3 = objectViaJSON2[k];
					string itemPrefabName3 = storageItemData3.itemPrefabName;
					int inventorySlotIndex2 = -1;
					bool isDropped2 = false;
					if (IsEssential(itemPrefabName3))
					{
						if (IsDuplicateEssentialItem(itemPrefabName3, k))
						{
							continue;
						}
						inventorySlotIndex2 = ++num2;
						isDropped2 = true;
					}
					storageItemData3.inventorySlotIndex = inventorySlotIndex2;
					storageItemData3.isDropped = isDropped2;
					objectViaJSON2[k] = storageItemData3;
				}
				for (int num6 = duplicateItemIndices.Count - 1; num6 >= 0; num6--)
				{
					int index3 = duplicateItemIndices[num6];
					objectViaJSON2.RemoveAt(index3);
				}
				data.SetObjectViaJSON("Storage_World", objectViaJSON2);
			}
			List<StorageItemData> objectViaJSON3 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_Belt");
			if (objectViaJSON3 != null)
			{
				bool flag = false;
				for (int l = 0; l < objectViaJSON3.Count; l++)
				{
					StorageItemData storageItemData4 = objectViaJSON3[l];
					if (storageItemData4 == null)
					{
						continue;
					}
					string itemPrefabName4 = storageItemData4.itemPrefabName;
					if (!IsEssential(itemPrefabName4) || !IsDuplicateEssentialItem(itemPrefabName4, l))
					{
						flag = true;
						storageItemData4.inventorySlotIndex = 33 + l;
						storageItemData4.isDropped = false;
						storageItemData4.inLockedSlot = false;
						storageItemData4.isGrabbed = false;
						if (list == null)
						{
							list = new List<StorageItemData>();
						}
						list.Add(storageItemData4);
					}
				}
				data.Remove("Storage_Belt");
				if (flag)
				{
					data.SetObjectViaJSON("Storage_Inventory", list);
				}
			}
		}
		return data;
		bool IsDuplicateEssentialItem(string prefabName, int item)
		{
			if (unprocessedEssentialItemPrefabNames.Remove(prefabName))
			{
				return false;
			}
			duplicateItemIndices.Add(item);
			return true;
		}
		bool IsEssential(string prefabName)
		{
			return essentialItemPrefabsNames.Contains(prefabName);
		}
	}
}
