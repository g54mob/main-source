using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ClockGroup : Clock
	{
		public int ChildrenCount => 0;

		public new TimelineGroup Timeline => null;

		internal new static ClockGroup CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ClockGroup(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ClockGroup obj)
		{
			return default(HandleRef);
		}

		protected ClockGroup()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ClockGroup(TimelineGroup timelineGroup, bool controllable)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public void Add(Clock clock)
		{
		}

		public Clock GetChild(uint index)
		{
			return null;
		}

		public bool Tick(double time, ClockState parentState)
		{
			return false;
		}
	}
}
