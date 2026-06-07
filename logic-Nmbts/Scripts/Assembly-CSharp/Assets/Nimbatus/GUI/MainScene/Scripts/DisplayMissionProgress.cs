using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class DisplayMissionProgress : MonoBehaviour
	{
		public UILabel Label;

		public void Update()
		{
			string text = "";
			if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null)
			{
				text += SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.GetStatusText();
			}
			Label.text = text;
		}
	}
}
