using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class AnimationClock : Clock
	{
		internal new static AnimationClock CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal AnimationClock(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(AnimationClock obj)
		{
			return default(HandleRef);
		}

		protected AnimationClock()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public AnimationClock(AnimationTimeline animation, bool controllable)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
