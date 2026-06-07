using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class MouseBinding : InputBinding
	{
		public static DependencyProperty MouseActionProperty => null;

		public static DependencyProperty ModifiersProperty => null;

		public MouseAction MouseAction
		{
			get
			{
				return default(MouseAction);
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

		internal new static MouseBinding CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MouseBinding(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(MouseBinding obj)
		{
			return default(HandleRef);
		}

		public MouseBinding(ICommand command, MouseGesture gesture)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public MouseBinding(ICommand command, MouseAction action, ModifierKeys modifiers)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static MouseAction ParseMouseAction(string source)
		{
			return default(MouseAction);
		}

		internal static MouseGesture ParseMouseGesture(string source)
		{
			return null;
		}

		public MouseBinding()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		private static IntPtr CreateMouseBinding(object command, MouseGesture gesture)
		{
			return (IntPtr)0;
		}

		private static uint ParseMouseActionHelper(string str)
		{
			return 0u;
		}

		private static IntPtr ParseMouseGestureHelper(string str)
		{
			return (IntPtr)0;
		}
	}
}
