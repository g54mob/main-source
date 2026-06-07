using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CubicEase : EasingFunctionBase
	{
		internal new static CubicEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CubicEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CubicEase obj)
		{
			return default(HandleRef);
		}

		public CubicEase()
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
