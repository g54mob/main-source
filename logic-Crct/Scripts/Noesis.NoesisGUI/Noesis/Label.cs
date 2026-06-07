using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Label : ContentControl
	{
		internal new static Label CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Label(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Label obj)
		{
			return default(HandleRef);
		}

		public Label()
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
