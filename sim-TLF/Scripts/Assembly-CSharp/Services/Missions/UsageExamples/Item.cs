using UnityEngine;
using Zenject;

namespace Services.Missions.UsageExamples
{
	public class Item : MonoBehaviour
	{
		[SerializeField]
		private string itemId = "herb";

		[Inject]
		private MissionEventBus _eventBus;

		public void PickUp()
		{
			_eventBus.Emit("collect", itemId);
			Object.Destroy(base.gameObject);
		}
	}
}
