using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationInertiaStartingEventArgs : InputEventArgs
	{
		private HandleRef swigCPtr;

		public UIElement ManipulationContainer => null;

		public Point ManipulationOrigin
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public ManipulationVelocities InitialVelocities => null;

		public InertiaRotationBehavior RotationBehavior
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public InertiaExpansionBehavior ExpansionBehavior
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public InertiaTranslationBehavior TranslationBehavior
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal ManipulationInertiaStartingEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ManipulationInertiaStartingEventArgs obj)
		{
			return default(HandleRef);
		}

		~ManipulationInertiaStartingEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public ManipulationInertiaStartingEventArgs(object source, RoutedEvent ev, Visual container, Point origin, ManipulationVelocities velocities)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr CreateHelper(object source, RoutedEvent ev, Visual container, Point origin, ManipulationVelocities velocities)
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
