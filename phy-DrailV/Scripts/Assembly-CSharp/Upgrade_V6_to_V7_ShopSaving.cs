using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/Shop Upgrade (v6 -> v7)")]
public class Upgrade_V6_to_V7_ShopSaving : ASaveSnapshotUpgrader
{
	public override int InputVersion => 6;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		Dictionary<string, int> shopItemPrefabNamesAndInitialAmounts = new Dictionary<string, int>
		{
			{ "shovel", 2 },
			{ "lighter", 3 },
			{ "ManualSteamBooklet", 2 },
			{ "RemoteController", 1 },
			{ "Key", 1 },
			{ "Stopwatch", 2 },
			{ "GoldenShovel", 1 },
			{ "KeyCaboose", 1 },
			{ "ExpertShovel", 1 },
			{ "Boombox", 1 },
			{ "Cassette_Album01", 1 },
			{ "Cassette_Album02", 1 },
			{ "Cassette_Album03", 1 },
			{ "Cassette_Album04", 1 },
			{ "Cassette_Album05", 1 },
			{ "Cassette_Album06", 1 },
			{ "Cassette_Album07", 1 },
			{ "Cassette_Album08", 1 },
			{ "Cassette_Album09", 1 },
			{ "Cassette_Album10", 1 },
			{ "Cassette_Album11", 1 },
			{ "Cassette_Album12", 1 },
			{ "Cassette_Album13", 1 },
			{ "Cassette_Album14", 1 },
			{ "Cassette_Album15", 1 },
			{ "Cassette_Album16", 1 },
			{ "Cassette_Playlist01", 1 },
			{ "Cassette_Playlist02", 1 },
			{ "Cassette_Playlist03", 1 },
			{ "Cassette_Playlist04", 1 },
			{ "Cassette_Playlist05", 1 },
			{ "Cassette_Playlist06", 1 },
			{ "Cassette_Playlist07", 1 },
			{ "Cassette_Playlist08", 1 },
			{ "Cassette_Playlist09", 1 },
			{ "Flashlight", 2 },
			{ "Lantern", 3 }
		};
		bool expandedStartingItems = (data.GetInt("Starting_items") ?? 0) == 1;
		HashSet<string> shopExpandedStartingItems = new HashSet<string> { "Flashlight", "Lantern", "RemoteController", "lighter", "shovel", "Boombox", "Stopwatch" };
		List<StorageItemData> itemSaveDataCollection = data.GetObjectViaJSON<List<StorageItemData>>("Storage_World") ?? new List<StorageItemData>();
		List<StorageItemData> itemSaveDataCollection2 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_LostAndFound") ?? new List<StorageItemData>();
		List<StorageItemData> itemSaveDataCollection3 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_Belt") ?? new List<StorageItemData>();
		List<StorageItemData> itemSaveDataCollection4 = data.GetObjectViaJSON<List<StorageItemData>>("Storage_Inventory") ?? new List<StorageItemData>();
		Dictionary<string, int> shopItemAmounts = new Dictionary<string, int>();
		UpdateRestockerData(ref itemSaveDataCollection);
		UpdateRestockerData(ref itemSaveDataCollection2);
		UpdateRestockerData(ref itemSaveDataCollection3);
		UpdateRestockerData(ref itemSaveDataCollection4);
		data.SetObjectViaJSON("Storage_World", itemSaveDataCollection);
		data.SetObjectViaJSON("Storage_LostAndFound", itemSaveDataCollection2);
		data.SetObjectViaJSON("Storage_Belt", itemSaveDataCollection3);
		data.SetObjectViaJSON("Storage_Inventory", itemSaveDataCollection4);
		JObject jObject = new JObject();
		foreach (KeyValuePair<string, int> item in shopItemAmounts)
		{
			jObject[item.Key] = item.Value;
		}
		data.SetJObject("Shop_item_amount_data", jObject);
		return data;
		void UpdateRestockerData(ref List<StorageItemData> reference)
		{
			Dictionary<string, int>.KeyCollection keys = shopItemPrefabNamesAndInitialAmounts.Keys;
			for (int num = reference.Count - 1; num >= 0; num--)
			{
				StorageItemData storageItemData = reference[num];
				string text = storageItemData?.itemPrefabName;
				if (!string.IsNullOrWhiteSpace(text) && keys.Contains(text))
				{
					if (expandedStartingItems && shopExpandedStartingItems.Contains(text))
					{
						shopExpandedStartingItems.Remove(text);
					}
					else
					{
						JObject jObject2 = storageItemData.state ?? new JObject();
						jObject2.SetBool("Restock", value: true);
						storageItemData.state = jObject2;
						reference[num] = storageItemData;
						int value = ((!shopItemAmounts.TryGetValue(text, out value)) ? (shopItemPrefabNamesAndInitialAmounts[text] - 1) : (value - 1));
						if (value < 0)
						{
							value = 0;
						}
						shopItemAmounts[text] = value;
					}
				}
			}
		}
	}
}
