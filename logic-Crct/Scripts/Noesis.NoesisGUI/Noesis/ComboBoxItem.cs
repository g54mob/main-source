using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ComboBoxItem : ListBoxItem
	{
		public static DependencyProperty IsHighlightedProperty => null;

		public bool IsHighlighted => false;

		internal new static ComboBoxItem CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ComboBoxItem(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ComboBoxItem obj)
		{
			return default(HandleRef);
		}

		public ComboBoxItem()
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
