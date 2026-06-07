using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class UIElementCollection : UICollection<UIElement>
	{
		internal new static UIElementCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal UIElementCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(UIElementCollection obj)
		{
			return default(HandleRef);
		}

		protected UIElementCollection()
		{
		}

		public UIElementCollection(UIElement visualParent, FrameworkElement logicalParent)
		{
		}
	}
}
