using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class AnimationTimeline : Timeline
	{
		public static DependencyProperty IsAdditiveProperty => null;

		public static DependencyProperty IsCumulativeProperty => null;

		public Type TargetPropertyType => null;

		public bool IsAdditive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsCumulative
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal new static AnimationTimeline CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal AnimationTimeline(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(AnimationTimeline obj)
		{
			return default(HandleRef);
		}

		protected AnimationTimeline()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
		{
			return null;
		}

		internal bool IsValidTarget(DependencyProperty dp)
		{
			return false;
		}

		private IntPtr GetCurrentValueHelper(object defValSrc, object defValDest, AnimationClock clock)
		{
			return (IntPtr)0;
		}
	}
}
