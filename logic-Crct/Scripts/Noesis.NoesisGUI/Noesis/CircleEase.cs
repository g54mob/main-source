using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CircleEase : EasingFunctionBase
	{
		internal new static CircleEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CircleEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CircleEase obj)
		{
			return default(HandleRef);
		}

		public CircleEase()
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
