using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearDoubleKeyFrame : DoubleKeyFrame
	{
		internal new static LinearDoubleKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearDoubleKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearDoubleKeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearDoubleKeyFrame()
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
