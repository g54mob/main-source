using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Span : Inline
	{
		public InlineCollection Inlines => null;

		internal new static Span CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Span(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Span obj)
		{
			return default(HandleRef);
		}

		public Span()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Span(Inline childInline)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
