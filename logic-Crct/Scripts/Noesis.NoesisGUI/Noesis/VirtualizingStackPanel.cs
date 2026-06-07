using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VirtualizingStackPanel : VirtualizingPanel, IScrollInfo
	{
		public static DependencyProperty OrientationProperty => null;

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

		public bool CanHorizontallyScroll
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CanVerticallyScroll
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float ExtentWidth => 0f;

		public float ExtentHeight => 0f;

		public float ViewportWidth => 0f;

		public float ViewportHeight => 0f;

		public float HorizontalOffset => 0f;

		public float VerticalOffset => 0f;

		public ScrollViewer ScrollOwner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static VirtualizingStackPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VirtualizingStackPanel(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(VirtualizingStackPanel obj)
		{
			return default(HandleRef);
		}

		public VirtualizingStackPanel()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
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

		public void MouseWheelLeft(float delta)
		{
		}

		public void MouseWheelLeft()
		{
		}

		public void MouseWheelRight(float delta)
		{
		}

		public void MouseWheelRight()
		{
		}

		public void MouseWheelUp(float delta)
		{
		}

		public void MouseWheelUp()
		{
		}

		public void MouseWheelDown(float delta)
		{
		}

		public void MouseWheelDown()
		{
		}

		public void SetHorizontalOffset(float offset)
		{
		}

		public void SetVerticalOffset(float offset)
		{
		}

		public Rect MakeVisible(Visual visual, Rect rect)
		{
			return default(Rect);
		}
	}
}
