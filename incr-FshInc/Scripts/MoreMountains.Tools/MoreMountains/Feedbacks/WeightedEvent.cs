using System;
using UnityEngine.Events;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class WeightedEvent
	{
		public int Weight;

		public UnityEvent Event;
	}
}
