using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Difficulty_v8_to_v9_BrakeWarningsRename : AJSONDataUpgrader
	{
		public override int InputVersion => 8;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			if (obj.ContainsKey("HandbrakeLight"))
			{
				obj["BrakeWarnings"] = obj["HandbrakeLight"];
				obj["HandbrakeLight"] = null;
			}
			obj["DataVersion"] = targetVersion;
		}
	}
}
