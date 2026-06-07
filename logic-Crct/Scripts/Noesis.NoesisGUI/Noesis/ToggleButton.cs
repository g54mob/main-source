using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ToggleButton : ButtonBase
	{
		public static DependencyProperty IsCheckedProperty => null;

		public static DependencyProperty IsThreeStateProperty => null;

		public static RoutedEvent CheckedEvent => null;

		public static RoutedEvent IndeterminateEvent => null;

		public static RoutedEvent UncheckedEvent => null;

		public bool? IsChecked
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsThreeState
		{
			get
			{
				return false;
			}
			set
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

		public event RoutedEventHandler Indeterminate
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

		internal new static ToggleButton CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ToggleButton(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ToggleButton obj)
		{
			return default(HandleRef);
		}

		public ToggleButton()
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
