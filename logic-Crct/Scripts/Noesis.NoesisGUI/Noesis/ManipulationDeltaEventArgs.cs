using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationDeltaEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public UIElement ManipulationContainer => null;

		public Point ManipulationOrigin => default(Point);

		public ManipulationDelta DeltaManipulation => null;

		public ManipulationDelta CumulativeManipulation => null;

		public ManipulationVelocities Velocities => null;

		public bool IsInertial => false;

		internal ManipulationDeltaEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ManipulationDeltaEventArgs obj)
		{
			return default(HandleRef);
		}

		~ManipulationDeltaEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ManipulationDeltaEventArgs(object source, RoutedEvent ev, Visual container, Point origin, ManipulationDelta delta, ManipulationDelta cumulative, ManipulationVelocities velocities, bool isInertial)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr CreateHelper(object source, RoutedEvent ev, Visual container, Point origin, ManipulationDelta delta, ManipulationDelta cumulative, ManipulationVelocities velocities, bool isInertial)
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
