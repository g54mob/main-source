using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StringAnimationUsingKeyFrames : AnimationTimeline
	{
		public StringKeyFrameCollection KeyFrames => null;

		internal new static StringAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StringAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(StringAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public StringAnimationUsingKeyFrames()
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
