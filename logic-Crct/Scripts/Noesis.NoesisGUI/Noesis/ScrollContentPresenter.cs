using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ScrollContentPresenter : ContentPresenter, IScrollInfo
	{
		public static DependencyProperty CanContentScrollProperty => null;

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

		internal new static ScrollContentPresenter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ScrollContentPresenter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ScrollContentPresenter obj)
		{
			return default(HandleRef);
		}

		public ScrollContentPresenter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public AdornerLayer GetAdornerLayer()
		{
			return null;
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
