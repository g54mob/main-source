using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationStartingEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public UIElement ManipulationContainer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ManipulationModes Mode
		{
			get
			{
				return default(ManipulationModes);
			}
			set
			{
			}
		}

		internal ManipulationStartingEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ManipulationStartingEventArgs obj)
		{
			return default(HandleRef);
		}

		~ManipulationStartingEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ManipulationStartingEventArgs(object source, RoutedEvent ev, Visual container)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr CreateHelper(object source, RoutedEvent ev, Visual container)
		{
			return (IntPtr)0;
		}

		public bool Cancel()
		{
			return false;
		}

		private UIElement GetManipulationContainerHelper()
		{
			return null;
		}

		private void SetManipulationContainerHelper(UIElement container)
		{
		}
	}
}
