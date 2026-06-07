using System;
using System.Collections.Generic;
using Dhs5.Utility.Updates;

public interface IUpdateTimeline
{
	[Serializable]
	public struct Event
	{
		public float normalizedTime;

		public ushort id;
	}

	int UID { get; }

	EUpdateChannel UpdateChannel { get; }

	float Duration { get; }

	bool Loop { get; }

	float Timescale { get; }

	IEnumerable<Event> GetSortedEvents();
}
