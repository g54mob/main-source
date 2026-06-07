using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int32AnimationUsingKeyFrames : AnimationTimeline
	{
		public Int32KeyFrameCollection KeyFrames => null;

		internal new static Int32AnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int32AnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int32AnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public Int32AnimationUsingKeyFrames()
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
