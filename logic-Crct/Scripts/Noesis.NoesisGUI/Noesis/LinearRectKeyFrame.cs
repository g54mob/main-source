using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearRectKeyFrame : RectKeyFrame
	{
		internal new static LinearRectKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearRectKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearRectKeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearRectKeyFrame()
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
