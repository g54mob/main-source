using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/Magazines (v19 -> v20)")]
public class Upgrade_V19_to_V20_Magazines : ASaveSnapshotUpgrader
{
	private const string CONTAINER_ID_SAVE_KEY = "ContainerId";

	private const string INSERTED_CASSETTE_SAVE_KEY = "cassette";

	private const string SOLDER_REMAINING_UNITS = "AMMO";

	private const string CONTAINER_ID_FORMAT = "{0}{1}";

	private const string INSERTED_PAINT_CAN_SOCKET = "reloadable_socket_inserted_item";

	private const string INSERTED_CAN_ITEM_PREFAB_NAME = "prefabName";

	private const string INSERTED_CAN_ITEM_BELONGS_TO_PLAYER = "belongsToPlayer";

	private const string INSERTED_CAN_ITEM_SAVE_DATA = "data";

	public override int InputVersion => 19;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		List<StorageItemData>[] savedItems = new List<StorageItemData>[5];
		savedItems[0] = data.GetObjectViaJSON<List<StorageItemData>>("Storage_World");
		savedItems[1] = data.GetObjectViaJSON<List<StorageItemData>>("Storage_Inventory");
		savedItems[2] = data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound");
		savedItems[3] = data.GetObjectViaJSON<List<StorageItemData>>("Storage_InstalledGadgets");
		savedItems[4] = data.GetObjectViaJSON<List<StorageItemData>>("Storage_ItemContainers");
		for (int i = 0; i < savedItems.Length; i++)
		{
			if (savedItems[i] == null)
			{
				savedItems[i] = new List<StorageItemData>();
			}
		}
		List<(StorageItemData, int, int)> list = FindItemData("Boombox", fuzzy: false);
		List<(StorageItemData, int, int)> list2 = FindItemData("SolderingGun", fuzzy: false);
		List<(StorageItemData, int, int)> list3 = FindItemData("PaintSprayer", fuzzy: false);
		FindItemData("PaintCan", fuzzy: true);
		for (int j = 0; j < list.Count; j++)
		{
			var (storageItemData, num, index) = list[j];
			if (storageItemData != null)
			{
				JObject jObject = storageItemData.state;
				if (jObject == null)
				{
					jObject = new JObject();
				}
				string text = $"{storageItemData.itemPrefabName}{j}";
				jObject["ContainerId"] = text;
				savedItems[num][index].containerId = text;
				savedItems[num][index].state = jObject;
				string text2 = jObject.GetString("cassette");
				if (!string.IsNullOrEmpty(text2))
				{
					StorageItemData item = new StorageItemData(text2, Vector3.zero, Quaternion.identity, belongsToPlayer: true, isGrabbed: false, null, null, -1, 0, inLockedSlot: false, isDropped: false, text);
					savedItems[4].Add(item);
					jObject.Remove(text2);
				}
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			var (storageItemData2, num2, index2) = list2[k];
			if (storageItemData2 != null)
			{
				JObject jObject2 = storageItemData2.state;
				if (jObject2 == null)
				{
					jObject2 = new JObject();
				}
				string text3 = $"{storageItemData2.itemPrefabName}{k}";
				jObject2["ContainerId"] = text3;
				savedItems[num2][index2].containerId = text3;
				savedItems[num2][index2].state = jObject2;
				if ((jObject2.GetInt("AMMO") ?? 0) > 0)
				{
					StorageItemData item2 = new StorageItemData("SolderingWireReel", Vector3.zero, Quaternion.identity, belongsToPlayer: true, isGrabbed: false, null, null, -1, 0, inLockedSlot: false, isDropped: false, text3);
					savedItems[4].Add(item2);
				}
			}
		}
		for (int l = 0; l < list3.Count; l++)
		{
			var (storageItemData3, num3, index3) = list3[l];
			if (storageItemData3 == null)
			{
				continue;
			}
			JObject jObject3 = storageItemData3.state;
			if (jObject3 == null)
			{
				jObject3 = new JObject();
			}
			string text4 = $"{storageItemData3.itemPrefabName}{0}";
			jObject3["ContainerId"] = text4;
			savedItems[num3][index3].containerId = text4;
			savedItems[num3][index3].state = jObject3;
			JObject jObject4 = jObject3.GetJObject("reloadable_socket_inserted_item");
			if (jObject4 != null)
			{
				string text5 = jObject4.GetString("prefabName");
				if (string.IsNullOrEmpty(text5))
				{
					jObject3.Remove("prefabName");
					savedItems[num3][index3].state = jObject3;
					continue;
				}
				bool belongsToPlayer = jObject4.GetBool("belongsToPlayer") ?? false;
				JObject jObject5 = jObject4.GetJObject("data");
				StorageItemData item3 = new StorageItemData(text5, Vector3.zero, Quaternion.identity, belongsToPlayer, isGrabbed: false, null, jObject5, -1, 0, inLockedSlot: false, isDropped: false, text4);
				savedItems[4].Add(item3);
			}
		}
		data.SetObjectViaJSON("Storage_World", savedItems[0]);
		data.SetObjectViaJSON("Storage_Inventory", savedItems[1]);
		data.SetObjectViaJSON("Storage_LostAndFound", savedItems[2]);
		data.SetObjectViaJSON("Storage_InstalledGadgets", savedItems[3]);
		data.SetObjectViaJSON("Storage_ItemContainers", savedItems[4]);
		return data;
		List<(StorageItemData itemData, int storageIndex, int itemIndex)> FindItemData(string itemPrefabName, bool fuzzy)
		{
			List<(StorageItemData, int, int)> list4 = new List<(StorageItemData, int, int)>();
			for (int m = 0; m < savedItems.Length; m++)
			{
				List<StorageItemData> list5 = savedItems[m];
				if (list5 != null)
				{
					for (int n = 0; n < list5.Count; n++)
					{
						StorageItemData storageItemData4 = list5[n];
						if (storageItemData4 != null)
						{
							if (fuzzy)
							{
								if (!storageItemData4.itemPrefabName.Contains(itemPrefabName))
								{
									continue;
								}
							}
							else if (storageItemData4.itemPrefabName != itemPrefabName)
							{
								continue;
							}
							list4.Add((storageItemData4, m, n));
						}
					}
				}
			}
			return list4;
		}
	}
}
