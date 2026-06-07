using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Missions.UI
{
	public class ShowMissionOverview : SerializedMonoBehaviour
	{
		public MissionDescriptionUi MissionDisplay;

		public void Start()
		{
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission != EMissionType.None)
			{
				MissionDisplay.gameObject.SetActive(true);
				MissionDisplay.Init(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission);
			}
			else
			{
				MissionDisplay.gameObject.SetActive(false);
			}
		}
	}
}
