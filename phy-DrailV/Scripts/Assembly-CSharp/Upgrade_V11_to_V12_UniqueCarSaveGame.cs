using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/UniqueCarSaveGameUpgrade (v11 -> v12)")]
public class Upgrade_V11_to_V12_UniqueCarSaveGame : ASaveSnapshotUpgrader
{
	public override int InputVersion => 11;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		if (session.GameMode != "Career")
		{
			return data;
		}
		HashSet<int> hashSet = new HashSet<int> { 45, 70, 700, 750 };
		foreach (KeyValuePair<string, JToken> datum in data)
		{
			if (!datum.Key.StartsWith("Cars#") || !(datum.Value is JObject dataObject))
			{
				continue;
			}
			JObject[] jObjectArray = dataObject.GetJObjectArray("carsData");
			JObject[] array = jObjectArray;
			foreach (JObject dataObject2 in array)
			{
				int? num = dataObject2.GetInt("type");
				if (num.HasValue && hashSet.Contains(num.Value))
				{
					dataObject2.SetBool("unique", value: true);
				}
			}
			dataObject.SetJObjectArray("carsData", jObjectArray);
		}
		return data;
	}
}
