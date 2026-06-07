using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ContextMenu : MenuBase
	{
		public static DependencyProperty HasDropShadowProperty => null;

		public static DependencyProperty HorizontalOffsetProperty => null;

		public static DependencyProperty IsOpenProperty => null;

		public static DependencyProperty PlacementProperty => null;

		public static DependencyProperty PlacementRectangleProperty => null;

		public static DependencyProperty PlacementTargetProperty => null;

		public static DependencyProperty StaysOpenProperty => null;

		public static DependencyProperty VerticalOffsetProperty => null;

		public static RoutedEvent ClosedEvent => null;

		public static RoutedEvent OpenedEvent => null;

		public bool HasDropShadow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float HorizontalOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PlacementMode Placement
		{
			get
			{
				return default(PlacementMode);
			}
			set
			{
			}
		}

		public Rect PlacementRectangle
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public UIElement PlacementTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool StaysOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float VerticalOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event RoutedEventHandler Closed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Opened
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static ContextMenu CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ContextMenu(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ContextMenu obj)
		{
			return default(HandleRef);
		}

		public ContextMenu()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
