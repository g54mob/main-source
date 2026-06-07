using Events;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Base Event Caller", fileName = "BaseEventCaller", order = 10)]
	public class BaseEventCallerSubQuestEventSO : AbstractSubQuestEventSO
	{
		public BaseEvent Event;

		public override void Execute()
		{
			Event.Fire();
		}
	}
}
