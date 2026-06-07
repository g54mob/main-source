using System;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Scenarios
{
	public class Train_v3_to_v4_HopperCovered_Refrigerator_and_Renamed_LocalFruits : AJSONDataUpgrader
	{
		public override int InputVersion => 3;

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
							case "HopperBrown":
							case "HopperTeal":
							case "HopperYellow":
								switch (text2)
								{
								case "Corn":
								case "SunflowerSeeds":
								case "Wheat":
									break;
								default:
									goto IL_00d3;
								}
								item["Name"] = "HopperCoveredBrown";
								break;
							default:
								goto IL_00d3;
								IL_00d3:
								switch (text)
								{
								case "BoxcarBrown":
								case "BoxcarGreen":
								case "BoxcarRed":
								case "BoxcarPink":
									if (text2 == "Eggs" || text2 == "LocalFruits")
									{
										item["Name"] = "RefrigeratorWhite";
									}
									break;
								}
								break;
							}
							if (text2 == "LocalFruits")
							{
								item["CargoType"] = "TemperateFruits";
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
