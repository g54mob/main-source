using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DoubleAnimationUsingKeyFrames : AnimationTimeline
	{
		public DoubleKeyFrameCollection KeyFrames => null;

		internal new static DoubleAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DoubleAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DoubleAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public DoubleAnimationUsingKeyFrames()
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
