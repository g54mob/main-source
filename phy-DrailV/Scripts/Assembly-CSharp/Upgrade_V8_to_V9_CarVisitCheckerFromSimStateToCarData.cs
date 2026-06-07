using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/CarVisitChecker from sim to car data migration (v8 -> v9)")]
public class Upgrade_V8_to_V9_CarVisitCheckerFromSimStateToCarData : ASaveSnapshotUpgrader
{
	public override int InputVersion => 8;

	public override JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		bool flag = false;
		string text = data.GetString("Last_Tracks_Hash");
		if (text != null)
		{
			JObject jObject = data.GetJObject(SaveGameKeys.GetCarsSaveKeyForDesiredTracksHash(text));
			if (jObject != null)
			{
				JObject[] jObjectArray = jObject.GetJObjectArray("carsData");
				if (jObjectArray != null)
				{
					JObject[] array = jObjectArray;
					foreach (JObject jObject2 in array)
					{
						if (jObject2 == null)
						{
							continue;
						}
						JObject jObject3 = jObject2.GetJObject("simCarState");
						if (jObject3 != null)
						{
							float? num = jObject3.GetFloat("visit");
							if (num.HasValue)
							{
								flag = true;
								jObject2.SetFloat("visit", num.Value);
							}
						}
					}
					if (flag)
					{
						jObject.SetJObjectArray("carsData", jObjectArray);
						data.SetJObject(SaveGameKeys.GetCarsSaveKeyForDesiredTracksHash(text), jObject);
					}
				}
			}
		}
		return data;
	}
}
