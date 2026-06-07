using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearInt16KeyFrame : Int16KeyFrame
	{
		internal new static LinearInt16KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearInt16KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearInt16KeyFrame obj)
		{
			return default(HandleRef);
		}

		public LinearInt16KeyFrame()
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
