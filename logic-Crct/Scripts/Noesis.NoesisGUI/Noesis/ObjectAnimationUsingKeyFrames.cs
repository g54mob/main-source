using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ObjectAnimationUsingKeyFrames : AnimationTimeline
	{
		public ObjectKeyFrameCollection KeyFrames => null;

		internal new static ObjectAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ObjectAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ObjectAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public ObjectAnimationUsingKeyFrames()
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
