using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Bold : Span
	{
		internal new static Bold CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Bold(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Bold obj)
		{
			return default(HandleRef);
		}

		public Bold()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Bold(Inline childInline)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
