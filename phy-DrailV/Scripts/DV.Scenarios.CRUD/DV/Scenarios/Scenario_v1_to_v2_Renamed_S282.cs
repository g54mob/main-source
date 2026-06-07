using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Scenario_v1_to_v2_Renamed_S282 : AJSONDataUpgrader
	{
		public override int InputVersion => 1;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("Train") && obj["Train"] is JObject obj2)
			{
				new Train_v1_to_v2_Renamed_S282().Upgrade(obj2, fileName, storage, targetVersion);
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
