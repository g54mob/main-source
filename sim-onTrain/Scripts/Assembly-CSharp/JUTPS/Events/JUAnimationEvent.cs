using System;
using UnityEngine.Events;

namespace JUTPS.Events
{
	[Serializable]
	public class JUAnimationEvent
	{
		public string EventName;

		public UnityEvent Event;
	}
}
