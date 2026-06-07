using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearThicknessKeyFrame : ThicknessKeyFrame
	{
		internal new static LinearThicknessKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearThicknessKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearThicknessKeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearThicknessKeyFrame()
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
