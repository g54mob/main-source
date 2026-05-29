using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Spine
{
	internal class EventQueue
	{
		private struct EventQueueEntry
		{
			public EventType type;

			public TrackEntry entry;

			public Event e;

			public EventQueueEntry(EventType eventType, TrackEntry trackEntry, Event e = null)
			{
				type = default(EventType);
				entry = null;
				this.e = null;
			}
		}

		private enum EventType
		{
			Start = 0,
			Interrupt = 1,
			End = 2,
			Dispose = 3,
			Complete = 4,
			Event = 5
		}

		private readonly List<EventQueueEntry> eventQueueEntries;

		internal bool drainDisabled;

		private readonly AnimationState state;

		private readonly Pool<TrackEntry> trackEntryPool;

		internal event Action AnimationsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal EventQueue(AnimationState state, Action HandleAnimationsChanged, Pool<TrackEntry> trackEntryPool)
		{
		}

		internal void Start(TrackEntry entry)
		{
		}

		internal void Interrupt(TrackEntry entry)
		{
		}

		internal void End(TrackEntry entry)
		{
		}

		internal void Dispose(TrackEntry entry)
		{
		}

		internal void Complete(TrackEntry entry)
		{
		}

		internal void Event(TrackEntry entry, Event e)
		{
		}

		internal void Drain()
		{
		}

		internal void Clear()
		{
		}
	}
}
