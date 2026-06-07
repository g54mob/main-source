using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class QuarticEase : EasingFunctionBase
	{
		internal new static QuarticEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal QuarticEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(QuarticEase obj)
		{
			return default(HandleRef);
		}

		public QuarticEase()
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
