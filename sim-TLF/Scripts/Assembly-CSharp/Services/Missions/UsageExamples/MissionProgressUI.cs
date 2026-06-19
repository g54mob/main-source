using UnityEngine;
using Zenject;

namespace Services.Missions.UsageExamples
{
	public class MissionProgressUI : MonoBehaviour
	{
		[Inject]
		private IMissionService _missionService;

		private void Start()
		{
			_missionService.OnObjectiveUpdated += OnObjectiveUpdated;
			_missionService.OnMissionCompleted += OnMissionCompleted;
		}

		private void OnObjectiveUpdated(MissionInstance mission, ObjectiveInstance objective)
		{
			Debug.Log("[UI] " + mission.MissionId + " → " + objective.ObjectiveId + ": " + $"{objective.CurrentAmount} / ? (IsComplete: {objective.IsComplete})");
		}

		private void OnMissionCompleted(MissionInstance mission)
		{
			Debug.Log("[UI] Місія завершена! " + mission.MissionId);
		}

		private void OnDestroy()
		{
			if (_missionService != null)
			{
				_missionService.OnObjectiveUpdated -= OnObjectiveUpdated;
				_missionService.OnMissionCompleted -= OnMissionCompleted;
			}
		}
	}
}
