using System;
using UnityEngine.Playables;

namespace TH20.Timeline
{
	[Serializable]
	internal sealed class EventPlayable : PlayableBehaviour
	{
		public string EventName;

		public string EventTag;
	}
}
