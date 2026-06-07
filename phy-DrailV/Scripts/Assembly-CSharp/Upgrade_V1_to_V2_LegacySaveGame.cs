using System.Collections.Generic;
using System.IO;
using System.Linq;
using DV.InventorySystem;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Legacy save game upgrader (v1 -> v2)")]
public class Upgrade_V1_to_V2_LegacySaveGame : ASaveSnapshotUpgrader
{
	private static string OldKeyBindingsDirectoryPath => Path.Combine(Application.dataPath, "SaveGameData");

	private static string OldKeyBindingsFilePath => Path.Combine(OldKeyBindingsDirectoryPath, "keybindings.ini");

	public override int InputVersion => 1;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		if (data == null)
		{
			Debug.LogError("Savegame is null, savegame upgrade aborted.");
			return null;
		}
		int? num = data.GetInt("Version");
		if (!num.HasValue)
		{
			Debug.LogError("Loaded savegame doesn't have version info, savegame upgrade aborted.");
			return null;
		}
		int upgradeStepVersion = num.Value;
		if (upgradeStepVersion < 1)
		{
			Debug.LogError($"Unexpected save game version value: {upgradeStepVersion}, save game upgrade aborted.");
			return null;
		}
		if (upgradeStepVersion > 8)
		{
			Debug.LogError($"Loaded savegame version {upgradeStepVersion} is greater than the supported version {8}, savegame upgrade aborted.");
			return null;
		}
		if (8 == upgradeStepVersion)
		{
			return data;
		}
		Debug.Log($"About to upgrade savegame to version {8}.");
		if (upgradeStepVersion == 1)
		{
			RecordVersions(data, ref upgradeStepVersion);
			string[] array = new string[6] { "Map", "junction_remote", "wallet", "shovel", "MapSchematic", "lighter" };
			List<string> list = new List<string>();
			string[] array2 = data.GetStringArray("Player_inventory_items");
			if (array2 == null)
			{
				Debug.LogWarning("Couldn't find any inventory items while migrating inventory data to storage.");
				array2 = new string[0];
			}
			else if (array2.Length > SingletonBehaviour<Inventory>.Instance.Capacity)
			{
				Debug.LogWarning($"Number of items in savegame ({array2.Length}) is larger than inventory capacity {SingletonBehaviour<Inventory>.Instance.Capacity}");
			}
			list = array2.Where((string n) => !string.IsNullOrWhiteSpace(n)).ToList();
			if (list.Count != array2.Length)
			{
				Debug.LogWarning("Savegame contained null/whitespace inventory items");
			}
			string[] array3 = array;
			foreach (string item in array3)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			List<string> list2 = list.Take(SingletonBehaviour<Inventory>.Instance.Capacity).ToList();
			List<string> list3 = list.Skip(SingletonBehaviour<Inventory>.Instance.Capacity).ToList();
			List<StorageItemData> list4 = new List<StorageItemData>();
			foreach (string item2 in list2)
			{
				list4.Add(new StorageItemData(item2, Vector3.zero, Quaternion.identity, array.Contains(item2)));
			}
			data.SetObjectViaJSON("Storage_Inventory", list4);
			List<StorageItemData> list5 = new List<StorageItemData>();
			foreach (string item3 in list3)
			{
				list5.Add(new StorageItemData(item3, Vector3.zero, Quaternion.identity, belongsToPlayer: true));
			}
			data.SetObjectViaJSON("Storage_LostAndFound", list5);
			data.SetObjectViaJSON("Storage_World", new List<StorageItemData>());
			if (array2 != null)
			{
				data.Remove("Player_inventory_items");
			}
		}
		if (upgradeStepVersion == 2)
		{
			RecordVersions(data, ref upgradeStepVersion);
			data.SetObjectViaJSON("Storage_Belt", new List<StorageItemData>());
		}
		if (upgradeStepVersion == 3)
		{
			RecordVersions(data, ref upgradeStepVersion);
			if (Directory.Exists(OldKeyBindingsDirectoryPath) && File.Exists(OldKeyBindingsFilePath))
			{
				File.Delete(OldKeyBindingsFilePath);
			}
			data = SaveGameManager.MakeEmptySave().GetJsonObject();
			data.SetBool("PreOverhaul_Player", value: true);
		}
		if (upgradeStepVersion == 4)
		{
			RecordVersions(data, ref upgradeStepVersion);
			bool? flag = data.GetBool("Tutorial_01_completed");
			if (flag.HasValue && flag.Value)
			{
				data.SetBool("Tutorial_02_completed", value: true);
			}
		}
		if (upgradeStepVersion == 5)
		{
			RecordVersions(data, ref upgradeStepVersion);
			bool? flag2 = data.GetBool("Garage_Caboose");
			if (flag2.HasValue && flag2.Value)
			{
				data.SetBool("Caboose_In_Range", value: true);
				data.SetString("Last_Tracks_Hash", "BF661822ABCA40C186A7580C1EF5E0A5");
			}
		}
		if (upgradeStepVersion == 6)
		{
			RecordVersions(data, ref upgradeStepVersion);
			data.SetString("World", "World1");
			data.SetString("Game_mode", "Career");
		}
		List<string> list6 = new List<string>();
		foreach (KeyValuePair<string, JToken> datum in data)
		{
			if (datum.Key.StartsWith("Jobs#") || datum.Key.StartsWith("Cars#"))
			{
				list6.Add(datum.Key);
			}
		}
		foreach (string item4 in list6)
		{
			data.Remove(item4);
		}
		return data;
	}

	public static void RecordVersions(JObject data, ref int upgradeStepVersion)
	{
		if (!data.GetInt("Version_initial").HasValue)
		{
			if (upgradeStepVersion >= 7)
			{
				Debug.LogWarning("Save games with version 7 or newer should definitely already have Save_version_initial");
			}
			data.SetInt("Version_initial", upgradeStepVersion);
		}
		if (string.IsNullOrWhiteSpace(data.GetString("Game_version_initial")))
		{
			if (upgradeStepVersion >= 7)
			{
				Debug.LogWarning("Save games with version 7 or newer should definitely already have Game_version_initial");
			}
			data.SetString("Game_version_initial", "pre-93");
		}
		upgradeStepVersion++;
		data.SetInt("Version", upgradeStepVersion);
	}
}
