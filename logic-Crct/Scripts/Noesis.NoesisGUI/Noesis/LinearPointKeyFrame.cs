using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearPointKeyFrame : PointKeyFrame
	{
		internal new static LinearPointKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearPointKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearPointKeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearPointKeyFrame()
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
