using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v2_to_v3_KeyboardDriving_bool_to_int : AJSONDataUpgrader
	{
		public override int InputVersion => 2;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("KeyboardDriving") && obj["KeyboardDriving"].Type != JTokenType.Integer)
			{
				obj["KeyboardDriving"] = ((!obj["KeyboardDriving"].Value<bool>()) ? 1 : 2);
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
