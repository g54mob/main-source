using UnityEngine;
using Zenject;

namespace Services.Missions.UsageExamples
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField]
		private string enemyId = "goblin";

		[Inject]
		private MissionEventBus _eventBus;

		public void Die()
		{
			_eventBus.Emit("kill", enemyId);
			Object.Destroy(base.gameObject);
		}
	}
}
