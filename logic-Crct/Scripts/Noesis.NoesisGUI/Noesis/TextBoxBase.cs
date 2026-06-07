using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TextBoxBase : Control
	{
		public static DependencyProperty AcceptsReturnProperty => null;

		public static DependencyProperty AcceptsTabProperty => null;

		public static DependencyProperty CaretBrushProperty => null;

		public static DependencyProperty HorizontalScrollBarVisibilityProperty => null;

		public static DependencyProperty IsReadOnlyProperty => null;

		public static DependencyProperty IsSelectionActiveProperty => null;

		public static DependencyProperty PanningModeProperty => null;

		public static DependencyProperty SelectionBrushProperty => null;

		public static DependencyProperty SelectionOpacityProperty => null;

		public static DependencyProperty VerticalScrollBarVisibilityProperty => null;

		public static RoutedEvent SelectionChangedEvent => null;

		public static RoutedEvent TextChangedEvent => null;

		public bool AcceptsReturn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AcceptsTab
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Brush CaretBrush
		{
			get
			{
				return null;
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

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSelectionActive => false;

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

		public Brush SelectionBrush
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float SelectionOpacity
		{
			get
			{
				return 0f;
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

		public float ExtentWidth => 0f;

		public float ExtentHeight => 0f;

		public float ViewportWidth => 0f;

		public float ViewportHeight => 0f;

		public float HorizontalOffset => 0f;

		public float VerticalOffset => 0f;

		public event RoutedEventHandler SelectionChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler TextChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static TextBoxBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TextBoxBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TextBoxBase obj)
		{
			return default(HandleRef);
		}

		protected TextBoxBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public void LineLeft()
		{
		}

		public void LineRight()
		{
		}

		public void PageLeft()
		{
		}

		public void PageRight()
		{
		}

		public void LineUp()
		{
		}

		public void LineDown()
		{
		}

		public void PageUp()
		{
		}

		public void PageDown()
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

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
