using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class KeyboardNavigation : BaseComponent
	{
		public static DependencyProperty AcceptsReturnProperty => null;

		public static DependencyProperty ControlTabNavigationProperty => null;

		public static DependencyProperty DirectionalNavigationProperty => null;

		public static DependencyProperty IsTabStopProperty => null;

		public static DependencyProperty TabIndexProperty => null;

		public static DependencyProperty TabNavigationProperty => null;

		internal new static KeyboardNavigation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal KeyboardNavigation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeyboardNavigation obj)
		{
			return default(HandleRef);
		}

		public KeyboardNavigation()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public KeyboardNavigation(Keyboard keyboard, Visual root)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static KeyboardNavigationMode GetTabNavigation(DependencyObject element)
		{
			return default(KeyboardNavigationMode);
		}

		public static void SetTabNavigation(DependencyObject element, KeyboardNavigationMode mode)
		{
		}

		public static KeyboardNavigationMode GetControlTabNavigation(DependencyObject element)
		{
			return default(KeyboardNavigationMode);
		}

		public static void SetControlTabNavigation(DependencyObject element, KeyboardNavigationMode mode)
		{
		}

		public static KeyboardNavigationMode GetDirectionalNavigation(DependencyObject element)
		{
			return default(KeyboardNavigationMode);
		}

		public static void SetDirectionalNavigation(DependencyObject element, KeyboardNavigationMode mode)
		{
		}

		public static bool GetAcceptsReturn(DependencyObject element)
		{
			return false;
		}

		public static void SetAcceptsReturn(DependencyObject element, bool value)
		{
		}

		public static bool GetIsTabStop(DependencyObject element)
		{
			return false;
		}

		public static void SetIsTabStop(DependencyObject element, bool value)
		{
		}

		public static int GetTabIndex(DependencyObject element)
		{
			return 0;
		}

		public static void SetTabIndex(DependencyObject element, int value)
		{
		}

		public bool MoveFocus(FrameworkElement source, TraversalRequest request)
		{
			return false;
		}

		public FrameworkElement PredictFocus(FrameworkElement source, FocusNavigationDirection direction)
		{
			return null;
		}
	}
}
