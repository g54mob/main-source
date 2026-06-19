using UnityEngine;
using Zenject;

namespace Services.Missions.UsageExamples
{
	public class NPC : MonoBehaviour
	{
		[SerializeField]
		private string npcId = "npc_merchant";

		[Inject]
		private MissionEventBus _eventBus;

		public void Talk()
		{
			_eventBus.Emit("talk", npcId);
		}
	}
}
