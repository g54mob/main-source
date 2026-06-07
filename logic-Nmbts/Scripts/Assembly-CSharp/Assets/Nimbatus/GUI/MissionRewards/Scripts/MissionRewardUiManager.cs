using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionRewards.Scripts
{
	public class MissionRewardUiManager : MonoBehaviour
	{
		public MissionSuccessPanel SuccessPanel;

		public MissionFailedPanel FailedPanel;

		public void Start()
		{
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				EMissionType mission = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.Mission;
				if ((SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.MissionRewards == null || SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.MissionRewards.Count <= 0) && (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.MissionPenalties == null || SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.MissionPenalties.Count <= 0))
				{
					Continue();
					return;
				}
				if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.IsLocalMissionCompleted(mission))
				{
					SuccessPanel.Init(SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.MissionRewards);
					MissionRewardNavigator.Instance.NavigateTowards(EMissionRewardPage.Success);
					return;
				}
				FailedPanel.Init(this, SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.MissionPenalties);
				MissionRewardNavigator.Instance.NavigateTowards(EMissionRewardPage.Failure);
				NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
				if (activeMission != null && !activeMission.IsFailed())
				{
					MissionManager.InvokeMissionFailed(activeMission);
				}
				if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.OverrideEndAnimationOnFailure)
				{
					TravelManager.OverrideEndAnimation = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.EndAnimation;
				}
				return;
			}
			BossfightLocationData bossfightLocationData;
			if ((bossfightLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as BossfightLocationData) != null)
			{
				if (bossfightLocationData.MissionCompleted && !bossfightLocationData.RewardScreenShown)
				{
					SuccessPanel.Init(bossfightLocationData.MissionRewards);
					MissionRewardNavigator.Instance.NavigateTowards(EMissionRewardPage.Success);
					bossfightLocationData.RewardScreenShown = true;
				}
				else
				{
					Continue();
				}
				return;
			}
			PlanetLocationData planetLocationData;
			if ((planetLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as PlanetLocationData) != null && planetLocationData.IsEndPlanet && planetLocationData.MissionCompleted)
			{
				planetLocationData.LoadEndScene();
				return;
			}
			bool num = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null;
			bool flag = num && SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.IsCompleted();
			if (num && SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.CompleteOnExit)
			{
				MissionManager.InvokeMissionCompleted(SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission);
			}
			if (!num || !flag || SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.RewardScreenShown || (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionRewards.Count <= 0 && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionPenalties.Count <= 0))
			{
				Continue();
				return;
			}
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionRewards.Count > 0)
			{
				SuccessPanel.Init(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionRewards);
				MissionRewardNavigator.Instance.NavigateTowards(EMissionRewardPage.Success);
			}
			else if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionPenalties.Count > 0)
			{
				FailedPanel.Init(this, SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.MissionPenalties);
				MissionRewardNavigator.Instance.NavigateTowards(EMissionRewardPage.Failure);
			}
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.RewardScreenShown = true;
		}

		public void Continue()
		{
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ResetLocalMissionProgress();
			WormHoleLocationData wormHoleLocationData;
			if ((wormHoleLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as WormHoleLocationData) != null)
			{
				wormHoleLocationData.TravelToNextGalaxy();
				return;
			}
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				NimbatusSceneManager.LoadScene("TravelScene");
				return;
			}
			string returnScene = NimbatusSceneManager.GetReturnScene();
			NimbatusSceneManager.LoadScene((!string.IsNullOrEmpty(returnScene)) ? returnScene : "MissionControlScene");
		}
	}
}
