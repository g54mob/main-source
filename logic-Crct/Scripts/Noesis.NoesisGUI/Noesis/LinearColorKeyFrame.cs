using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearColorKeyFrame : ColorKeyFrame
	{
		internal new static LinearColorKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearColorKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearColorKeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearColorKeyFrame()
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
