using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Italic : Span
	{
		internal new static Italic CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Italic(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Italic obj)
		{
			return default(HandleRef);
		}

		public Italic()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public Italic(Inline childInline)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
