using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Missions.UI
{
	public class ShowMissionStatus : SerializedMonoBehaviour
	{
		public MissionUi MissionDisplay;

		private bool _started;

		public void Update()
		{
			if (!RuntimeGlobals.IsGameLoading && !_started)
			{
				ShowMission();
				_started = true;
			}
		}

		public void ShowMission()
		{
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			if (activeMission != null && activeMission.MissionType != EMissionType.None)
			{
				MissionDisplay.gameObject.SetActive(true);
				MissionDisplay.Init(activeMission.MissionType);
			}
			else
			{
				MissionDisplay.gameObject.SetActive(false);
			}
		}
	}
}
