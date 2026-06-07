using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationStartedEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public UIElement ManipulationContainer => null;

		public Point ManipulationOrigin => default(Point);

		internal ManipulationStartedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ManipulationStartedEventArgs obj)
		{
			return default(HandleRef);
		}

		~ManipulationStartedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ManipulationStartedEventArgs(object source, RoutedEvent ev, Visual container, Point origin)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr CreateHelper(object source, RoutedEvent ev, Visual container, Point origin)
		{
			return (IntPtr)0;
		}

		public bool Cancel()
		{
			return false;
		}

		public void Complete()
		{
		}

		private UIElement GetManipulationContainerHelper()
		{
			return null;
		}
	}
}
