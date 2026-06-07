using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Keyboard : BaseComponent
	{
		public static RoutedEvent GotKeyboardFocusEvent => null;

		public static RoutedEvent KeyDownEvent => null;

		public static RoutedEvent KeyUpEvent => null;

		public static RoutedEvent LostKeyboardFocusEvent => null;

		public static RoutedEvent PreviewGotKeyboardFocusEvent => null;

		public static RoutedEvent PreviewKeyDownEvent => null;

		public static RoutedEvent PreviewKeyUpEvent => null;

		public static RoutedEvent PreviewLostKeyboardFocusEvent => null;

		public ModifierKeys Modifiers => default(ModifierKeys);

		public UIElement FocusedElement => null;

		internal new static Keyboard CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Keyboard(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Keyboard obj)
		{
			return default(HandleRef);
		}

		protected Keyboard()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public KeyStates GetKeyStates(Key key)
		{
			return default(KeyStates);
		}

		public bool IsKeyDown(Key key)
		{
			return false;
		}

		public bool IsKeyUp(Key key)
		{
			return false;
		}

		public bool IsKeyToggled(Key key)
		{
			return false;
		}

		public UIElement Focus(UIElement element)
		{
			return null;
		}

		public void ClearFocus()
		{
		}
	}
}
