using DV.JObjectExtstensions;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Scenarios
{
	public class Difficulty_v5_to_v6_PausedPhotoMode : AJSONDataUpgrader
	{
		public override int InputVersion => 5;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			int valueOrDefault = obj.GetValueOrDefault("WeatherEditorMode", 0);
			if (valueOrDefault > 0)
			{
				obj["WeatherEditorMode"] = Mathf.Clamp(valueOrDefault + 1, 0, 3);
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
