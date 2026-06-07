using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BooleanAnimationUsingKeyFrames : AnimationTimeline
	{
		public BooleanKeyFrameCollection KeyFrames => null;

		internal new static BooleanAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BooleanAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BooleanAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public BooleanAnimationUsingKeyFrames()
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
