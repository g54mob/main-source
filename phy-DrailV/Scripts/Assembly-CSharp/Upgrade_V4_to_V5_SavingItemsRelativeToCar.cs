using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/ItemsSavingRelativeToCars (v4 -> v5)")]
public class Upgrade_V4_to_V5_SavingItemsRelativeToCar : ASaveSnapshotUpgrader
{
	public override int InputVersion => 4;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>("Storage_World");
		if (objectViaJSON == null)
		{
			return data;
		}
		List<StorageItemData> list = data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound");
		if (list == null)
		{
			list = new List<StorageItemData>();
		}
		for (int num = objectViaJSON.Count - 1; num >= 0; num--)
		{
			StorageItemData storageItemData = objectViaJSON[num];
			if (storageItemData.carGuid != null)
			{
				storageItemData.carGuid = null;
				objectViaJSON.RemoveAt(num);
				list.Add(storageItemData);
			}
		}
		data.SetObjectViaJSON("Storage_World", objectViaJSON);
		data.SetObjectViaJSON("Storage_LostAndFound", list);
		return data;
	}
}
