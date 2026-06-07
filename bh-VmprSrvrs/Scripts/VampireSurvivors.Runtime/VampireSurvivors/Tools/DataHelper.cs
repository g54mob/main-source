using Newtonsoft.Json.Linq;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Tools
{
	public static class DataHelper
	{
		public static JObject UpgradeJsonData(JObject baseData, JObject newData)
		{
			return null;
		}

		public static JObject UpgradeStageJsonData(JObject baseData, JObject newData)
		{
			return null;
		}

		public static bool GetWeaponDataForLevel(JArray dataArray, int level, out WeaponData concreteData)
		{
			concreteData = null;
			return false;
		}

		public static JToken GetMinuteDataFromStageDataList(int requiredMinute, JArray stageDataArray)
		{
			return null;
		}
	}
}
