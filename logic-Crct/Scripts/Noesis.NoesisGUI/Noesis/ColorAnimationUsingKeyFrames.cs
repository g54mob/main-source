using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ColorAnimationUsingKeyFrames : AnimationTimeline
	{
		public ColorKeyFrameCollection KeyFrames => null;

		internal new static ColorAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ColorAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ColorAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public ColorAnimationUsingKeyFrames()
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
