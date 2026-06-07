using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v7_to_v8_StartingItemsEnumChange : AJSONDataUpgrader
	{
		public override int InputVersion => 7;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("StartingItems") && obj["StartingItems"].Type == JTokenType.Integer && obj["StartingItems"].Value<int>() == 2)
			{
				obj["StartingItems"] = 3;
			}
			obj["DataVersion"] = targetVersion;
		}
	}
}
