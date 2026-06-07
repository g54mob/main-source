using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Scenario_v3_to_v4_HopperCovered_Refrigerator_and_Renamed_LocalFruits : AJSONDataUpgrader
	{
		public override int InputVersion => 3;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("Train") && obj["Train"] is JObject obj2)
			{
				new Train_v3_to_v4_HopperCovered_Refrigerator_and_Renamed_LocalFruits().Upgrade(obj2, fileName, storage, targetVersion);
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
