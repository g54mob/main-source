using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class QuinticEase : EasingFunctionBase
	{
		internal new static QuinticEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal QuinticEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(QuinticEase obj)
		{
			return default(HandleRef);
		}

		public QuinticEase()
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
