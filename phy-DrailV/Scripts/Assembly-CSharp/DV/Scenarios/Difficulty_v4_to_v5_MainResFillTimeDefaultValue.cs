using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v4_to_v5_MainResFillTimeDefaultValue : AJSONDataUpgrader
	{
		public override int InputVersion => 4;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (!obj.ContainsKey("MainResFillTime"))
			{
				obj["MainResFillTime"] = 1f;
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
