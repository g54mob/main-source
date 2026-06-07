using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Thumb : Control
	{
		public static DependencyProperty IsDraggingProperty => null;

		public static RoutedEvent DragCompletedEvent => null;

		public static RoutedEvent DragDeltaEvent => null;

		public static RoutedEvent DragStartedEvent => null;

		public bool IsDragging => false;

		public event DragCompletedEventHandler DragCompleted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragDeltaEventHandler DragDelta
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DragStartedEventHandler DragStarted
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Thumb CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Thumb(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Thumb obj)
		{
			return default(HandleRef);
		}

		public Thumb()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void CancelDrag()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
