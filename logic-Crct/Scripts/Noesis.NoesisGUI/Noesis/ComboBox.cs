using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ComboBox : Selector
	{
		public static DependencyProperty IsDropDownOpenProperty => null;

		public static DependencyProperty IsEditableProperty => null;

		public static DependencyProperty IsReadOnlyProperty => null;

		public static DependencyProperty MaxDropDownHeightProperty => null;

		public static DependencyProperty PlaceholderProperty => null;

		public static DependencyProperty SelectionBoxItemProperty => null;

		public static DependencyProperty SelectionBoxItemTemplateProperty => null;

		public static DependencyProperty StaysOpenOnEditProperty => null;

		public static DependencyProperty TextProperty => null;

		public bool IsDropDownOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsEditable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MaxDropDownHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public object SelectionBoxItem => null;

		public DataTemplate SelectionBoxItemTemplate => null;

		public bool StaysOpenOnEdit
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Placeholder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ComboBox CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ComboBox(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ComboBox obj)
		{
			return default(HandleRef);
		}

		public ComboBox()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void ScrollIntoView(object item)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
