using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ToolBarPanel : StackPanel
	{
		internal new static ToolBarPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ToolBarPanel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ToolBarPanel obj)
		{
			return default(HandleRef);
		}

		public ToolBarPanel()
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
