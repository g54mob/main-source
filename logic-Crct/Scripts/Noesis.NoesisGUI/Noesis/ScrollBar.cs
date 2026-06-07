using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ScrollBar : RangeBase
	{
		public static DependencyProperty OrientationProperty => null;

		public static DependencyProperty ViewportSizeProperty => null;

		public static RoutedEvent ScrollEvent => null;

		public static RoutedCommand DeferScrollToHorizontalOffsetCommand => null;

		public static RoutedCommand DeferScrollToVerticalOffsetCommand => null;

		public static RoutedCommand LineDownCommand => null;

		public static RoutedCommand LineLeftCommand => null;

		public static RoutedCommand LineRightCommand => null;

		public static RoutedCommand LineUpCommand => null;

		public static RoutedCommand PageDownCommand => null;

		public static RoutedCommand PageLeftCommand => null;

		public static RoutedCommand PageRightCommand => null;

		public static RoutedCommand PageUpCommand => null;

		public static RoutedCommand ScrollHereCommand => null;

		public static RoutedCommand ScrollToBottomCommand => null;

		public static RoutedCommand ScrollToEndCommand => null;

		public static RoutedCommand ScrollToHomeCommand => null;

		public static RoutedCommand ScrollToHorizontalOffsetCommand => null;

		public static RoutedCommand ScrollToLeftEndCommand => null;

		public static RoutedCommand ScrollToRightEndCommand => null;

		public static RoutedCommand ScrollToTopCommand => null;

		public static RoutedCommand ScrollToVerticalOffsetCommand => null;

		public Orientation Orientation
		{
			get
			{
				return default(Orientation);
			}
			set
			{
			}
		}

		public float ViewportSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Track Track => null;

		public event ScrollEventHandler Scroll
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static ScrollBar CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ScrollBar(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ScrollBar obj)
		{
			return default(HandleRef);
		}

		public ScrollBar()
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
