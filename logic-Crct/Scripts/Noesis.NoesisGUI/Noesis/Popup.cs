using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Popup : FrameworkElement
	{
		public delegate void ClosedHandler(object sender, EventArgs e);

		internal delegate void RaiseClosedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		public delegate void OpenedHandler(object sender, EventArgs e);

		internal delegate void RaiseOpenedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);

		private static RaiseClosedCallback _raiseClosed;

		internal static Dictionary<long, ClosedHandler> _Closed;

		private static RaiseOpenedCallback _raiseOpened;

		internal static Dictionary<long, OpenedHandler> _Opened;

		public static DependencyProperty AllowsTransparencyProperty => null;

		public static DependencyProperty ChildProperty => null;

		public static DependencyProperty HasDropShadowProperty => null;

		public static DependencyProperty HorizontalOffsetProperty => null;

		public static DependencyProperty IsOpenProperty => null;

		public static DependencyProperty PlacementProperty => null;

		public static DependencyProperty PlacementRectangleProperty => null;

		public static DependencyProperty PlacementTargetProperty => null;

		public static DependencyProperty PopupAnimationProperty => null;

		public static DependencyProperty StaysOpenProperty => null;

		public static DependencyProperty VerticalOffsetProperty => null;

		public bool AllowsTransparency
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UIElement Child
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public PopupAnimation PopupAnimation
		{
			get
			{
				return default(PopupAnimation);
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

		public event ClosedHandler Closed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event OpenedHandler Opened
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Popup CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Popup(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Popup obj)
		{
			return default(HandleRef);
		}

		[MonoPInvokeCallback(typeof(RaiseClosedCallback))]
		private static void RaiseClosed(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		[MonoPInvokeCallback(typeof(RaiseOpenedCallback))]
		private static void RaiseOpened(IntPtr cPtr, IntPtr sender, IntPtr e)
		{
		}

		public Popup()
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
