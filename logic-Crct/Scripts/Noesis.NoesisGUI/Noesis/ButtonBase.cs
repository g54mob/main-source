using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class ButtonBase : ContentControl
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

		public static DependencyProperty ClickModeProperty => null;

		public static DependencyProperty CommandProperty => null;

		public static DependencyProperty CommandParameterProperty => null;

		public static DependencyProperty CommandTargetProperty => null;

		public static DependencyProperty IsPressedProperty => null;

		public static RoutedEvent ClickEvent => null;

		public ClickMode ClickMode
		{
			get
			{
				return default(ClickMode);
			}
			set
			{
			}
		}

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

		public bool IsPressed => false;

		public event RoutedEventHandler Click
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static ButtonBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ButtonBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ButtonBase obj)
		{
			return default(HandleRef);
		}

		protected ButtonBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
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
