using System;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Scenarios
{
	public class Train_v2_to_v3_StockCar_and_Renamed_Chickens : AJSONDataUpgrader
	{
		public override int InputVersion => 2;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("Cars"))
			{
				try
				{
					if (obj["Cars"] is JArray jArray)
					{
						foreach (JToken item in jArray)
						{
							string text = item["Name"]?.ToString();
							string text2 = item["CargoType"]?.ToString();
							switch (text)
							{
							case "BoxcarBrown":
							case "BoxcarGreen":
							case "BoxcarRed":
							case "BoxcarPink":
								switch (text2)
								{
								case "Pigs":
								case "Goats":
								case "Sheep":
								case "Cows":
								case "Chickens":
									item["Name"] = "StockBrown";
									break;
								}
								break;
							}
							if (text2 == "Chickens")
							{
								item["CargoType"] = "Poultry";
							}
							item["DataVersion"] = targetVersion;
						}
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("Caught the following error while upgrading train cars in " + fileName);
					Debug.LogException(exception);
				}
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
