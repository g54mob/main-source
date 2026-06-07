using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearInt64KeyFrame : Int64KeyFrame
	{
		internal new static LinearInt64KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearInt64KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearInt64KeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearInt64KeyFrame()
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
