using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ResetMissionProgress : MonoBehaviour
	{
		public void OnClick()
		{
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ResetLocalMissionProgress();
		}
	}
}
