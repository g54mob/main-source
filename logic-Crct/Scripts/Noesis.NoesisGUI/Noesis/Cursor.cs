using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Cursor : BaseComponent
	{
		public CursorType Type => default(CursorType);

		public string Filename => null;

		internal new static Cursor CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Cursor(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Cursor obj)
		{
			return default(HandleRef);
		}

		protected Cursor()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public Cursor(string filename)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
