using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int16AnimationUsingKeyFrames : AnimationTimeline
	{
		public Int16KeyFrameCollection KeyFrames => null;

		internal new static Int16AnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int16AnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int16AnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public Int16AnimationUsingKeyFrames()
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
