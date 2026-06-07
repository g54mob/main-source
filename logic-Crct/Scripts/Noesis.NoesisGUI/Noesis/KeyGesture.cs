using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(KeyGestureConverter))]
	public class KeyGesture : InputGesture
	{
		public Key Key => default(Key);

		public ModifierKeys Modifiers => default(ModifierKeys);

		public string DisplayString => null;

		internal new static KeyGesture CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal KeyGesture(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(KeyGesture obj)
		{
			return default(HandleRef);
		}

		public KeyGesture()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public KeyGesture(Key key, ModifierKeys modifiers)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public KeyGesture(Key key)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
