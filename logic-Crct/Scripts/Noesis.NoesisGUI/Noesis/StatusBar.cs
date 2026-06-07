using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StatusBar : ItemsControl
	{
		public static DependencyProperty SeparatorStyleKey => null;

		internal new static StatusBar CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StatusBar(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(StatusBar obj)
		{
			return default(HandleRef);
		}

		public StatusBar()
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
