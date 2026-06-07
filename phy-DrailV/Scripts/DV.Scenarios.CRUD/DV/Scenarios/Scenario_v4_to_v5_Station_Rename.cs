using DV.JObjectExtstensions;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public class Scenario_v4_to_v5_Station_Rename : AJSONDataUpgrader
	{
		public override int InputVersion => 4;

		public override void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion)
		{
			switch (obj.GetString("StartingTrackID"))
			{
			case "[Y]_[CM]_[B-02-O]":
				obj.SetString("StartingTrackID", "[Y]_[CME]_[B-02-O]");
				break;
			case "[Y]_[CSW]_[C-05-O]":
				obj.SetString("StartingTrackID", "[Y]_[CW]_[C-05-O]");
				break;
			}
			obj[Thing.DATA_VERSION_KEY] = targetVersion;
		}
	}
}
