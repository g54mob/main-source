using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/Belt Storage Upgrade (v7 -> v8)")]
public class Upgrade_V7_to_V8_BeltStorageRemoval : ASaveSnapshotUpgrader
{
	public override int InputVersion => 7;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		if (data.GetObjectViaJSON<List<StorageItemData>>("Storage_Belt") != null)
		{
			data.Remove("Storage_Belt");
		}
		return data;
	}
}
