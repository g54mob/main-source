using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.UI
{
	public class MissionDescriptionUi : MonoBehaviour
	{
		public UILabel MissionText;

		public bool ShowDescriptionAsTooltip;

		[HideIf("ShowDescriptionAsTooltip", true)]
		public UILabel MissionDescription;

		private EMissionType _mission;

		public void Init(EMissionType mission)
		{
			_mission = mission;
			MissionText.text = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMissionTitle(_mission);
			if (!ShowDescriptionAsTooltip)
			{
				MissionDescription.text = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMissionDescription(_mission);
			}
		}

		public void OnTooltip(bool show)
		{
			if (ShowDescriptionAsTooltip)
			{
				string missionDescription = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMissionDescription(_mission);
				NimbatusToolTip.Show(show ? missionDescription : null);
			}
		}
	}
}
