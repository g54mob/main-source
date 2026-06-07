using System;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class ReturnFromFlight : MonoBehaviour
	{
		public string NextScene;

		public bool DifferentSceneWhenMissionCompleted;

		[ShowIf("DifferentSceneWhenMissionCompleted", true)]
		public string DifferentSceneName;

		public void OnClick()
		{
			if (string.IsNullOrEmpty(NextScene))
			{
				throw new Exception("return scene not set");
			}
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			string returnScene = NextScene;
			if (DifferentSceneWhenMissionCompleted && activeMission != null && activeMission.IsCompleted())
			{
				returnScene = DifferentSceneName;
			}
			NimbatusSceneManager.SetReturnScene("MissionRewardScene", returnScene);
			NimbatusSceneManager.LoadScene("MissionRewardScene");
		}
	}
}
