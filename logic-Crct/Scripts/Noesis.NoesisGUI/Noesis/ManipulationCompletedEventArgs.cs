using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationCompletedEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public UIElement ManipulationContainer => null;

		public Point ManipulationOrigin => default(Point);

		public ManipulationVelocities FinalVelocities => null;

		public ManipulationDelta TotalManipulation => null;

		public bool IsInertial => false;

		internal ManipulationCompletedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ManipulationCompletedEventArgs obj)
		{
			return default(HandleRef);
		}

		~ManipulationCompletedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ManipulationCompletedEventArgs(object source, RoutedEvent ev, Visual container, Point origin, ManipulationVelocities velocities, ManipulationDelta totalManipulation, bool isInertial)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr CreateHelper(object source, RoutedEvent ev, Visual container, Point origin, ManipulationVelocities velocities, ManipulationDelta totalManipulation, bool isInertial)
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
	}
}
