using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.UI
{
	public class MissionUi : MonoBehaviour
	{
		public UILabel MissionText;

		public GameObject Completed;

		public GameObject NotCompleted;

		private EMissionType _mission;

		private bool _isCompleted;

		public void Init(EMissionType mission)
		{
			_isCompleted = SerializableMonobehaviour<MissionManager, MissionData>.Instance.IsLocalMissionCompleted(mission);
			_mission = mission;
			Completed.SetActive(_isCompleted);
			NotCompleted.SetActive(!_isCompleted);
			MissionText.text = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetStatusText(_mission);
			StartCoroutine(UpdateMissionStatus());
		}

		public IEnumerator UpdateMissionStatus()
		{
			while (true)
			{
				bool flag = SerializableMonobehaviour<MissionManager, MissionData>.Instance.IsLocalMissionCompleted(_mission);
				MissionText.text = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetStatusText(_mission);
				if (flag != _isCompleted)
				{
					Completed.SetActive(flag);
					NotCompleted.SetActive(!flag);
					_isCompleted = flag;
				}
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
