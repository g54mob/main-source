using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MenuBase : ItemsControl
	{
		internal new static MenuBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MenuBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MenuBase obj)
		{
			return default(HandleRef);
		}

		protected MenuBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
