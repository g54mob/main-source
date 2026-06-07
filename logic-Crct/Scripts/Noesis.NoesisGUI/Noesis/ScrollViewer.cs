using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ScrollViewer : ContentControl
	{
		public static DependencyProperty CanContentScrollProperty => null;

		public static DependencyProperty ComputedHorizontalScrollBarVisibilityProperty => null;

		public static DependencyProperty ComputedVerticalScrollBarVisibilityProperty => null;

		public static DependencyProperty ExtentHeightProperty => null;

		public static DependencyProperty ExtentWidthProperty => null;

		public static DependencyProperty HorizontalOffsetProperty => null;

		public static DependencyProperty HorizontalScrollBarVisibilityProperty => null;

		public static DependencyProperty IsDeferredScrollingEnabledProperty => null;

		public static DependencyProperty ScrollableHeightProperty => null;

		public static DependencyProperty ScrollableWidthProperty => null;

		public static DependencyProperty VerticalOffsetProperty => null;

		public static DependencyProperty VerticalScrollBarVisibilityProperty => null;

		public static DependencyProperty ViewportHeightProperty => null;

		public static DependencyProperty ViewportWidthProperty => null;

		public static DependencyProperty PanningModeProperty => null;

		public static DependencyProperty PanningDecelerationProperty => null;

		public static DependencyProperty PanningRatioProperty => null;

		public static RoutedEvent ScrollChangedEvent => null;

		public bool CanContentScroll
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ScrollBarVisibility HorizontalScrollBarVisibility
		{
			get
			{
				return default(ScrollBarVisibility);
			}
			set
			{
			}
		}

		public ScrollBarVisibility VerticalScrollBarVisibility
		{
			get
			{
				return default(ScrollBarVisibility);
			}
			set
			{
			}
		}

		public bool IsDeferredScrollingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PanningMode PanningMode
		{
			get
			{
				return default(PanningMode);
			}
			set
			{
			}
		}

		public float PanningDeceleration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float PanningRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Visibility ComputedHorizontalScrollBarVisibility => default(Visibility);

		public Visibility ComputedVerticalScrollBarVisibility => default(Visibility);

		public float ExtentWidth => 0f;

		public float ExtentHeight => 0f;

		public float HorizontalOffset => 0f;

		public float VerticalOffset => 0f;

		public float ScrollableWidth => 0f;

		public float ScrollableHeight => 0f;

		public float ViewportWidth => 0f;

		public float ViewportHeight => 0f;

		public event ScrollChangedEventHandler ScrollChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static ScrollViewer CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ScrollViewer(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ScrollViewer obj)
		{
			return default(HandleRef);
		}

		public ScrollViewer()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public static bool GetCanContentScroll(DependencyObject element)
		{
			return false;
		}

		public static void SetCanContentScroll(DependencyObject element, bool canScroll)
		{
		}

		public static ScrollBarVisibility GetHorizontalScrollBarVisibility(DependencyObject element)
		{
			return default(ScrollBarVisibility);
		}

		public static void SetHorizontalScrollBarVisibility(DependencyObject element, ScrollBarVisibility visibility)
		{
		}

		public static ScrollBarVisibility GetVerticalScrollBarVisibility(DependencyObject element)
		{
			return default(ScrollBarVisibility);
		}

		public static void SetVerticalScrollBarVisibility(DependencyObject element, ScrollBarVisibility visibility)
		{
		}

		public static bool GetIsDeferredScrollingEnabled(DependencyObject element)
		{
			return false;
		}

		public static void SetIsDeferredScrollingEnabled(DependencyObject element, bool value)
		{
		}

		public static PanningMode GetPanningMode(DependencyObject element)
		{
			return default(PanningMode);
		}

		public static void SetPanningMode(DependencyObject element, PanningMode panningMode)
		{
		}

		public static float GetPanningDeceleration(DependencyObject element)
		{
			return 0f;
		}

		public static void SetPanningDeceleration(DependencyObject element, float deceleration)
		{
		}

		public static float GetPanningRatio(DependencyObject element)
		{
			return 0f;
		}

		public static void SetPanningRatio(DependencyObject element, float panningRatio)
		{
		}

		public void LineLeft()
		{
		}

		public void LineRight()
		{
		}

		public void LineUp()
		{
		}

		public void LineDown()
		{
		}

		public void PageLeft()
		{
		}

		public void PageRight()
		{
		}

		public void PageUp()
		{
		}

		public void PageDown()
		{
		}

		public void ScrollToLeftEnd()
		{
		}

		public void ScrollToRightEnd()
		{
		}

		public void ScrollToTop()
		{
		}

		public void ScrollToBottom()
		{
		}

		public void ScrollToHome()
		{
		}

		public void ScrollToEnd()
		{
		}

		public void ScrollToHorizontalOffset(float offset)
		{
		}

		public void ScrollToVerticalOffset(float offset)
		{
		}

		public void InvalidateScrollInfo()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
