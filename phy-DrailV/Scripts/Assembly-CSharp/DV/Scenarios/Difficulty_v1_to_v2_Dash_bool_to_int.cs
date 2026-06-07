using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v1_to_v2_Dash_bool_to_int : AJSONDataUpgrader
	{
		public override int InputVersion => 1;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("Dash") && obj["Dash"].Type != JTokenType.Integer)
			{
				obj["Dash"] = (obj["Dash"].Value<bool>() ? 2 : 0);
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
