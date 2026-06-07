using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v3_to_v4_NewParamsDefaultValue : AJSONDataUpgrader
	{
		public override int InputVersion => 3;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (!obj.ContainsKey("MultiServicing"))
			{
				obj["MultiServicing"] = true;
			}
			if (!obj.ContainsKey("SleepCooldownInHours"))
			{
				obj["SleepCooldownInHours"] = 6;
			}
			if (!obj.ContainsKey("VRRemoteDriving"))
			{
				obj["VRRemoteDriving"] = true;
			}
			if (!obj.ContainsKey("SteamStartupMultiplier") || obj["SteamStartupMultiplier"].Value<float>() == 0f)
			{
				obj["SteamStartupMultiplier"] = 1f;
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
