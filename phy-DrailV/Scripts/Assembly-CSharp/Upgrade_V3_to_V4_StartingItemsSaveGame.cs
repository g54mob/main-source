using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/Inventory (v3 -> v4)")]
public class Upgrade_V3_to_V4_StartingItemsSaveGame : ASaveSnapshotUpgrader
{
	public override int InputVersion => 3;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		string text = data.GetString("Game_mode");
		if (string.IsNullOrWhiteSpace(text))
		{
			Debug.LogError("Missing save entry for game mode. Savegame upgrade will assume Career mode for resolving starting items.");
			text = "Career";
		}
		bool flag = text == "Career";
		bool flag2 = text == "FreeRoam";
		if (!flag && !flag2)
		{
			Debug.LogError("Unknown save entry for game mode: " + text + ". Savegame upgrade will assume Career mode for resolving starting items.");
			flag = true;
		}
		data.SetInt("Starting_items", (!flag) ? 1 : 0);
		return data;
	}
}
