using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ItemsPanelTemplate : FrameworkTemplate
	{
		internal new static ItemsPanelTemplate CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ItemsPanelTemplate(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ItemsPanelTemplate obj)
		{
			return default(HandleRef);
		}

		public ItemsPanelTemplate()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
