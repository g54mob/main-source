using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/MicroShunterBobGarageUpgrade (v10 -> v11)")]
public class Upgrade_V10_to_V11_MicroShunterBobGarageSaveGame : ASaveSnapshotUpgrader
{
	public override int InputVersion => 10;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		string[] array = data.GetStringArray("Garages");
		if (array != null)
		{
			if (array.Any((string garageId) => garageId == "Bob"))
			{
				array = array.Where((string garageId) => garageId != "Bob").ToArray();
				data.SetStringArray("Garages", array);
				if (session.GameMode == "Career" && data["Game_mode"].Value<string>() == "Career" && !ExtractItemsFromStorages(data, "Storage_Inventory", "Storage_LostAndFound", "Storage_World", "Storage_Belt").Contains("Key"))
				{
					JObject jObject = data.GetJObject("Shop_item_amount_data");
					if (jObject.Remove("Key"))
					{
						data.SetJObject("Shop_item_amount_data", jObject);
					}
				}
				Vector3? vector = data.GetVector3("Player_position");
				if (vector.HasValue)
				{
					Vector3 vector2 = new Vector3(1590f, 137.4275f, 12220f);
					if ((vector.Value - vector2).magnitude < 15f)
					{
						data.SetVector3("Player_position", new Vector3?(new Vector3(1591.257f, 137.4275f, 12229.23f)).Value);
					}
				}
			}
			if (session.GameMode == "FreeRoam" && data["Game_mode"].Value<string>() == "FreeRoam")
			{
				JObject jObject2 = session.Owner.ReadProgressionState();
				string[] garageProgression = jObject2["Unlocked_garages"].ToObject<string[]>();
				array = array.Where((string garageId) => garageProgression.Contains(garageId)).ToArray();
				data.SetStringArray("Garages", array);
			}
		}
		return data;
	}

	private static HashSet<string> ExtractItemsFromStorages(JObject data, params string[] storageNames)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string propertyName in storageNames)
		{
			if (data.ContainsKey(propertyName))
			{
				hashSet.UnionWith(from item in JArray.Parse(data[propertyName].Value<string>()).ToList()
					where item.Type == JTokenType.Object
					select item["itemPrefabName"].Value<string>());
			}
		}
		return hashSet;
	}
}
