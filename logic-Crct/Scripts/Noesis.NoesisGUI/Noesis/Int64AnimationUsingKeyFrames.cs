using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int64AnimationUsingKeyFrames : AnimationTimeline
	{
		public Int64KeyFrameCollection KeyFrames => null;

		internal new static Int64AnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int64AnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int64AnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public Int64AnimationUsingKeyFrames()
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
