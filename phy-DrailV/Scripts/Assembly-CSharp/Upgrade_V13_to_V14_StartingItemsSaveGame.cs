using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/StartingItemsSaveGameUpgrade (v13 -> v14)")]
public class Upgrade_V13_to_V14_StartingItemsSaveGame : ASaveSnapshotUpgrader
{
	public override int InputVersion => 13;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound");
		if (objectViaJSON == null)
		{
			return data;
		}
		foreach (StorageItemData item in objectViaJSON)
		{
			item.itemPositionX = 0f;
			item.itemPositionY = 0f;
			item.itemPositionZ = 0f;
		}
		data.SetObjectViaJSON("Storage_LostAndFound", objectViaJSON);
		return data;
	}
}
