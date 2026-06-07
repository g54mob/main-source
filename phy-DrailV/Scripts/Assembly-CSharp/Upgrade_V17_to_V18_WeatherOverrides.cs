using System.Collections.Generic;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/WeatherOverridesUpgrade (v17 -> v18)")]
public class Upgrade_V17_to_V18_WeatherOverrides : ASaveSnapshotUpgrader
{
	private const string OLD_KEY = "Weather_overrides";

	private const string NEW_KEY = "Overrides";

	private const string SUBKEY = "Time_and_date";

	private static readonly Dictionary<string, string> KeyTranslation = new Dictionary<string, string>
	{
		{ "Raininess", "RainValue" },
		{ "Wetness", "WetnessValue" },
		{ "Thunderness", "ThunderValue" },
		{ "DaySpeed", "DayLengthInMinutes" },
		{ "TimeOfDay", "TimeOfDayHours" },
		{ "WindDir", "WindDirection" },
		{ "OverrideX", "WeatherPointX" },
		{ "OverrideY", "WeatherPointY" },
		{ "CloudSpeed", "WindSpeed" }
	};

	private static readonly Dictionary<string, Vector2> ScalingAndOffset = new Dictionary<string, Vector2> { 
	{
		"TimeOfDay",
		new Vector2(24f, 0f)
	} };

	public override int InputVersion => 17;

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		if (data["Weather_overrides"] != null && data["Weather_overrides"].Type == JTokenType.Object)
		{
			JObject obj = data["Weather_overrides"] as JObject;
			JObject jObject = new JObject();
			foreach (JProperty item in obj.Properties())
			{
				if (KeyTranslation.TryGetValue(item.Name, out var value) && item.Value.Type.Equals(JTokenType.Float))
				{
					float num = item.Value.Value<float>();
					if (ScalingAndOffset.TryGetValue(item.Name, out var value2))
					{
						num = num * value2.x + value2.y;
					}
					jObject.Add(value, num);
				}
			}
			data.Remove("Weather_overrides");
			if (!data.ContainsKey("Time_and_date"))
			{
				data.Add("Time_and_date", new JObject());
			}
			data["Time_and_date"]["Overrides"] = jObject;
		}
		return data;
	}
}
