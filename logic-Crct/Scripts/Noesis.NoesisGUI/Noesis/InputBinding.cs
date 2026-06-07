using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class InputBinding : Freezable
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

		public static DependencyProperty CommandProperty => null;

		public static DependencyProperty CommandParameterProperty => null;

		public static DependencyProperty CommandTargetProperty => null;

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

		public InputGesture Gesture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static InputBinding CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal InputBinding(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(InputBinding obj)
		{
			return default(HandleRef);
		}

		public InputBinding(ICommand command, InputGesture gesture)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public InputBinding()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		private static IntPtr CreateInputBinding(object command, InputGesture gesture)
		{
			return (IntPtr)0;
		}

		private object GetCommandHelper()
		{
			return null;
		}

		private void SetCommandHelper(object command)
		{
		}
	}
}
