using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/MountHoleDataUpdate (v16 -> v17)")]
public class Upgrade_V16_to_V17_MountHoleDataUpdate : ASaveSnapshotUpgrader
{
	public override int InputVersion => 16;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		string[] array = new string[3] { "Hanger", "ShelfSmall", "SteamEngineChecklist" };
		int[] array2 = new int[3] { 2, 4, 4 };
		List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>("Storage_InstalledGadgets");
		if (objectViaJSON != null)
		{
			foreach (StorageItemData item in objectViaJSON)
			{
				int num = Array.IndexOf(array, item.itemPrefabName);
				num = ((num != -1) ? array2[num] : 0);
				if (item?.state == null)
				{
					if (item == null || num == 0)
					{
						continue;
					}
					item.state = new JObject();
				}
				JObject jObject = item.state.GetJObject("gadgetData");
				if (jObject == null)
				{
					if (num == 0)
					{
						continue;
					}
					jObject = new JObject();
				}
				int[] array3 = jObject.GetIntArray("hole_states");
				if (array3 == null)
				{
					if (num == 0)
					{
						continue;
					}
					array3 = new int[num];
				}
				jObject.Remove("hole_states");
				JObject[] array4 = new JObject[array3.Length];
				for (int i = 0; i < array4.Length; i++)
				{
					array4[i] = new JObject();
					array4[i].SetInt("state", array3[i]);
					array4[i].SetBool("onGlass", value: false);
				}
				jObject.SetJObjectArray("holes", array4);
				item.state.SetJObject("gadgetData", jObject);
			}
			data.SetObjectViaJSON("Storage_InstalledGadgets", objectViaJSON);
		}
		return data;
	}
}
