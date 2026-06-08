using Rhizomatic.Utility;

namespace GRP
{
	public class MissionItem : Item<MissionItemConfig>
	{
		[JsonData]
		public bool completed;

		[JsonData]
		public string missionDataKey;

		private GameSession gameSession;

		private string missionDataPath => null;

		public override void OnContext()
		{
		}

		public void ClearMissionData()
		{
		}

		public void WriteMissionData(MissionData data)
		{
		}

		public MissionData ReadMissionData()
		{
			return null;
		}
	}
}
