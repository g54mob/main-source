using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/NewMountHoleFill (v18 -> v19)")]
public class Upgrade_V18_to_V19_NewMountHoleFill : ASaveSnapshotUpgrader
{
	public override int InputVersion => 18;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		string[] array = new string[4] { "SteamEngineChecklist", "ShelfSmall", "SunVisor", "Hanger" };
		int[] array2 = new int[4] { 4, 4, 2, 2 };
		JObject jObject = new JObject();
		jObject.SetInt("state", 1);
		jObject.SetBool("onGlass", value: false);
		List<StorageItemData> objectViaJSON = data.GetObjectViaJSON<List<StorageItemData>>("Storage_InstalledGadgets");
		if (objectViaJSON != null)
		{
			foreach (StorageItemData item in objectViaJSON)
			{
				if (item?.state == null)
				{
					continue;
				}
				int num = Array.IndexOf(array, item.itemPrefabName);
				if (num == -1)
				{
					continue;
				}
				JObject jObject2 = item.state.GetJObject("gadgetData");
				if (jObject2 == null)
				{
					continue;
				}
				JObject[] jObjectArray = jObject2.GetJObjectArray("holes");
				if (jObjectArray == null)
				{
					jObjectArray = new JObject[array2[num]];
					for (int i = 0; i < jObjectArray.Length; i++)
					{
						jObjectArray[i] = jObject.DeepClone() as JObject;
					}
					jObject2.SetJObjectArray("holes", jObjectArray);
					item.state.SetJObject("gadgetData", jObject2);
				}
			}
			data.SetObjectViaJSON("Storage_InstalledGadgets", objectViaJSON);
		}
		return data;
	}
}
