using System;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Scenarios
{
	public class Train_v1_to_v2_Renamed_S282 : AJSONDataUpgrader
	{
		public override int InputVersion => 1;

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
							string text = item["Name"].ToString();
							if (text == "LocoS282")
							{
								item["Name"] = "LocoS282A";
							}
							else if (text == "Tender")
							{
								item["Name"] = "LocoS282B";
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
