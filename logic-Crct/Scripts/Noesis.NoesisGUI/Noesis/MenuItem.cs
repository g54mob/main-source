using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class MenuItem : HeaderedItemsControl
	{
		public ICommand Command
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static DependencyProperty CommandParameterProperty => null;

		public static DependencyProperty CommandProperty => null;

		public static DependencyProperty CommandTargetProperty => null;

		public static DependencyProperty IconProperty => null;

		public static DependencyProperty InputGestureTextProperty => null;

		public static DependencyProperty IsCheckableProperty => null;

		public static DependencyProperty IsCheckedProperty => null;

		public static DependencyProperty IsHighlightedProperty => null;

		public static DependencyProperty IsPressedProperty => null;

		public static DependencyProperty IsSubmenuOpenProperty => null;

		public static DependencyProperty RoleProperty => null;

		public static DependencyProperty StaysOpenOnClickProperty => null;

		public static DependencyProperty SeparatorStyleKey => null;

		public static RoutedEvent CheckedEvent => null;

		public static RoutedEvent ClickEvent => null;

		public static RoutedEvent SubmenuClosedEvent => null;

		public static RoutedEvent SubmenuOpenedEvent => null;

		public static RoutedEvent UncheckedEvent => null;

		public object CommandParameter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UIElement CommandTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Icon
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string InputGestureText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsCheckable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsChecked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsHighlighted => false;

		public bool IsPressed => false;

		public bool IsSubmenuOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MenuItemRole Role => default(MenuItemRole);

		public bool StaysOpenOnClick
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event RoutedEventHandler Click
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Checked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Unchecked
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler SubmenuClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler SubmenuOpened
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static MenuItem CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MenuItem(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MenuItem obj)
		{
			return default(HandleRef);
		}

		public MenuItem()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		private object GetCommandHelper()
		{
			return null;
		}

		private void SetCommandHelper(object command)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
