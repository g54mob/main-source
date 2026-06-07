using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RectAnimationUsingKeyFrames : AnimationTimeline
	{
		public RectKeyFrameCollection KeyFrames => null;

		internal new static RectAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RectAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RectAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public RectAnimationUsingKeyFrames()
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
