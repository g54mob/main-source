using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Animatable : Freezable
	{
		internal new static Animatable CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Animatable(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Animatable obj)
		{
			return default(HandleRef);
		}

		protected Animatable()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public void BeginAnimation(DependencyProperty dp, AnimationTimeline animation)
		{
		}

		public void BeginAnimation(DependencyProperty dp, AnimationTimeline animation, HandoffBehavior handoffBehavior)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
