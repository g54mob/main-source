using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v6_to_v7_BrakesHeavyParamRemovals : AJSONDataUpgrader
	{
		public override int InputVersion => 6;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			obj.Remove("StuckBrakesWarning");
			obj.Remove("HeavyTrainWarning");
			obj.Remove("SessionLimitInMinutes");
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
