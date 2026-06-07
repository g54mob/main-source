using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Separator : Control
	{
		internal new static Separator CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Separator(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Separator obj)
		{
			return default(HandleRef);
		}

		public Separator()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
