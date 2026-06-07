using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Scenario_v2_to_v3_StockCar_and_Renamed_Chickens : AJSONDataUpgrader
	{
		public override int InputVersion => 2;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("Train") && obj["Train"] is JObject obj2)
			{
				new Train_v2_to_v3_StockCar_and_Renamed_Chickens().Upgrade(obj2, fileName, storage, targetVersion);
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
