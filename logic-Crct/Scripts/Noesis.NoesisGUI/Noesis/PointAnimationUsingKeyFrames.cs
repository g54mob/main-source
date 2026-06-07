using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PointAnimationUsingKeyFrames : AnimationTimeline
	{
		public PointKeyFrameCollection KeyFrames => null;

		internal new static PointAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PointAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PointAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public PointAnimationUsingKeyFrames()
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
