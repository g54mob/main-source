using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class KeyBinding : InputBinding
	{
		public static DependencyProperty KeyProperty => null;

		public static DependencyProperty ModifiersProperty => null;

		public Key Key
		{
			get
			{
				return default(Key);
			}
			set
			{
			}
		}

		public ModifierKeys Modifiers
		{
			get
			{
				return default(ModifierKeys);
			}
			set
			{
			}
		}

		internal new static KeyBinding CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal KeyBinding(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeyBinding obj)
		{
			return default(HandleRef);
		}

		public KeyBinding(ICommand command, KeyGesture gesture)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public KeyBinding(ICommand command, Key key, ModifierKeys modifiers)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static Key ParseKey(string source)
		{
			return default(Key);
		}

		internal static ModifierKeys ParseModifierKeys(string source)
		{
			return default(ModifierKeys);
		}

		internal static KeyGesture ParseKeyGesture(string source)
		{
			return null;
		}

		public KeyBinding()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		private static IntPtr CreateKeyBinding(object command, KeyGesture gesture)
		{
			return (IntPtr)0;
		}

		private static uint ParseKeyHelper(string str)
		{
			return 0u;
		}

		private static uint ParseModifierKeysHelper(string str)
		{
			return 0u;
		}

		private static IntPtr ParseKeyGestureHelper(string str)
		{
			return (IntPtr)0;
		}
	}
}
