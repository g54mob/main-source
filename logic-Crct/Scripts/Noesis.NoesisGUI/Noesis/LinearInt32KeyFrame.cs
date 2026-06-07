using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearInt32KeyFrame : Int32KeyFrame
	{
		internal new static LinearInt32KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearInt32KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearInt32KeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearInt32KeyFrame()
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
