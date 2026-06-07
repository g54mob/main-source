using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class QuadraticEase : EasingFunctionBase
	{
		internal new static QuadraticEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal QuadraticEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(QuadraticEase obj)
		{
			return default(HandleRef);
		}

		public QuadraticEase()
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
