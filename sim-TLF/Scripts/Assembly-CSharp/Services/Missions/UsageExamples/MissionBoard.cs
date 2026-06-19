using UnityEngine;
using Zenject;

namespace Services.Missions.UsageExamples
{
	public class MissionBoard : MonoBehaviour
	{
		[Inject]
		private IMissionService _missionService;

		[Inject]
		private MissionFactory _missionFactory;

		private void Start()
		{
			_missionService.OnMissionStarted += delegate(MissionInstance m)
			{
				Debug.Log("Розпочато: " + m.MissionId);
			};
			_missionService.OnMissionCompleted += delegate(MissionInstance m)
			{
				Debug.Log("Завершено: " + m.MissionId);
			};
			_missionService.OnObjectiveUpdated += delegate(MissionInstance m, ObjectiveInstance o)
			{
				Debug.Log($"Прогрес [{m.MissionId}] {o.ObjectiveId}: {o.CurrentAmount}");
			};
		}

		public void GiveRandomMission(int difficulty)
		{
			Random.Range(0, 3);
			MissionDefinition def = _missionFactory.Create($"mission_{Random.Range(1000, 9999)}").WithTitle("Випадкова місія").WithDescription("Виконайте завдання, щоб отримати нагороду.")
				.WithReward(difficulty * 100)
				.Reach("island_3")
				.Build();
			_missionService.StartMission(def);
		}
	}
}
