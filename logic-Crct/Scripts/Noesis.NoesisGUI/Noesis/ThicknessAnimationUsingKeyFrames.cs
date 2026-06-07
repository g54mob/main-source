using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ThicknessAnimationUsingKeyFrames : AnimationTimeline
	{
		public ThicknessKeyFrameCollection KeyFrames => null;

		internal new static ThicknessAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ThicknessAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ThicknessAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public ThicknessAnimationUsingKeyFrames()
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
