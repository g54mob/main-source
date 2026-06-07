using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MatrixAnimationUsingKeyFrames : AnimationTimeline
	{
		public MatrixKeyFrameCollection KeyFrames => null;

		internal new static MatrixAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MatrixAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MatrixAnimationUsingKeyFrames obj)
		{
			return default(HandleRef);
		}

		public MatrixAnimationUsingKeyFrames()
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
