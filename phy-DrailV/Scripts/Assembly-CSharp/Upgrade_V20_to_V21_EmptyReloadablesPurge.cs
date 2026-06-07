using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/EmptyReloadablesPurge (v20 -> v21)")]
public class Upgrade_V20_to_V21_EmptyReloadablesPurge : ASaveSnapshotUpgrader
{
	public override int InputVersion => 20;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		List<StorageItemData>[] array = new List<StorageItemData>[5]
		{
			data.GetObjectViaJSON<List<StorageItemData>>("Storage_World"),
			data.GetObjectViaJSON<List<StorageItemData>>("Storage_Inventory"),
			data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound"),
			data.GetObjectViaJSON<List<StorageItemData>>("Storage_InstalledGadgets"),
			data.GetObjectViaJSON<List<StorageItemData>>("Storage_ItemContainers")
		};
		for (int i = 0; i < array.Length; i++)
		{
			List<StorageItemData> list = array[i];
			if (array[i] == null)
			{
				array[i] = new List<StorageItemData>();
				continue;
			}
			for (int num = list.Count - 1; num >= 0; num--)
			{
				StorageItemData storageItemData = list[num];
				if (storageItemData != null)
				{
					string itemPrefabName = storageItemData.itemPrefabName;
					if (!(itemPrefabName != "SolderingWireReelEmpty") || !(itemPrefabName != "PaintCanOpen"))
					{
						if (i == 4 && (storageItemData.containerId.StartsWith("PaintSprayer") || storageItemData.containerId.StartsWith("SolderingGun")))
						{
							storageItemData.belongsToPlayer = false;
						}
						else
						{
							list.RemoveAt(num);
						}
					}
				}
			}
		}
		data.SetObjectViaJSON("Storage_World", array[0]);
		data.SetObjectViaJSON("Storage_Inventory", array[1]);
		data.SetObjectViaJSON("Storage_LostAndFound", array[2]);
		data.SetObjectViaJSON("Storage_InstalledGadgets", array[3]);
		data.SetObjectViaJSON("Storage_ItemContainers", array[4]);
		return data;
	}
}
