using System.IO;
using NSEipix.Repository;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class DateTimeSettingsData : DynamicSettingsData<DateTimeSettingsData, DateTimeSettings>
	{
		protected override string JsonFile()
		{
			return "Settings/DateTimeSettings.json";
		}

		public static DateTimeSettings GetDebugDefault()
		{
			return JsonUtility.FromJson<DateTimeSettings>(File.ReadAllText(Path.Combine(Application.dataPath, "StreamingAssets/Settings/DateTimeSettings.json")));
		}
	}
}
