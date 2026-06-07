using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/RestorationLocoUpdate (v14 -> v15)")]
public class Upgrade_V14_to_V15_RestorationLocoUpdate : ASaveSnapshotUpgrader
{
	public override int InputVersion => 14;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		JObject jObject = data.GetJObject("Restoration_Locos");
		if (jObject != null)
		{
			foreach (KeyValuePair<string, JToken> item in jObject)
			{
				if (!(item.Value is JObject dataObject))
				{
					continue;
				}
				int? num = dataObject.GetInt("state");
				if (!num.HasValue)
				{
					Debug.LogError("Unexpected state: LocoRestorationController save data missing! Something is wrong!");
					continue;
				}
				switch (num.Value)
				{
				case 1:
					dataObject.SetInt("state", 2);
					break;
				case 2:
					dataObject.SetInt("state", 3);
					break;
				case 3:
					dataObject.SetInt("state", 4);
					break;
				}
			}
			data.SetJObject("Restoration_Locos", jObject);
		}
		return data;
	}
}
