using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(MouseGestureConverter))]
	public class MouseGesture : InputGesture
	{
		public MouseAction MouseAction => default(MouseAction);

		public ModifierKeys Modifiers => default(ModifierKeys);

		internal new static MouseGesture CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MouseGesture(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MouseGesture obj)
		{
			return default(HandleRef);
		}

		public MouseGesture()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public MouseGesture(MouseAction key, ModifierKeys modifiers)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public MouseGesture(MouseAction key)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
