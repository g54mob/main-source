using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ParallelTimeline : TimelineGroup
	{
		public static DependencyProperty SlipBehaviorProperty => null;

		public SlipBehavior SlipBehavior
		{
			get
			{
				return default(SlipBehavior);
			}
			set
			{
			}
		}

		internal new static ParallelTimeline CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ParallelTimeline(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ParallelTimeline obj)
		{
			return default(HandleRef);
		}

		public ParallelTimeline()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
