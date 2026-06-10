using System;

namespace NSMedieval.Model
{
	[Serializable]
	public class EventInteractionTypeFloatPair : SerializablePair<EventInteractionType, float>
	{
		public EventInteractionTypeFloatPair()
		{
		}

		public EventInteractionTypeFloatPair(EventInteractionType key, float value)
			: base(key, value)
		{
		}
	}
}
