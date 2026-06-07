using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Underline : Span
	{
		internal new static Underline CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Underline(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Underline obj)
		{
			return default(HandleRef);
		}

		public Underline()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Underline(Inline childInline)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
