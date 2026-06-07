using System.Linq;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Missions.Objectives;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowTimerCondition : MonoBehaviour
	{
		public UILabel TimerLabel;

		private bool _showTimer;

		private TimerObjective _timer;

		public void Start()
		{
			if (!(SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null))
			{
				return;
			}
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			if (activeMission.GetMissionObjectives().FirstOrDefault((MissionObjective f) => f is TimerObjective) != null)
			{
				_timer = activeMission.GetMissionObjectives().FirstOrDefault((MissionObjective f) => f is TimerObjective) as TimerObjective;
				_showTimer = !activeMission.IsCompleted();
			}
			if (activeMission.GetMissionFailstates().FirstOrDefault((MissionObjective f) => f is TimerObjective) != null)
			{
				_timer = activeMission.GetMissionFailstates().FirstOrDefault((MissionObjective f) => f is TimerObjective) as TimerObjective;
				_showTimer = !activeMission.IsFailed();
			}
		}

		public void Update()
		{
			if (!_showTimer)
			{
				TimerLabel.text = "";
			}
			else
			{
				TimerLabel.text = _timer.GetStatusText();
			}
		}
	}
}
