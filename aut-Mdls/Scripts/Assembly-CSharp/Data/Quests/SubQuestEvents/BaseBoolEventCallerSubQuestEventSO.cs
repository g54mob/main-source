using Events;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Base Bool Event Caller", fileName = "BaseBoolEventCaller", order = 10)]
	public class BaseBoolEventCallerSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private bool _value;

		public BaseEvent<bool> Event;

		public override void Execute()
		{
			Event.Fire(_value);
		}
	}
}
