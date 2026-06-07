using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SizeAnimationUsingKeyFrames : AnimationTimeline
	{
		public SizeKeyFrameCollection KeyFrames => null;

		internal new static SizeAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SizeAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SizeAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public SizeAnimationUsingKeyFrames()
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
