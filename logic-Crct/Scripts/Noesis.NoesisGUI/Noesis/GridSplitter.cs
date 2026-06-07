using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GridSplitter : Thumb
	{
		public static DependencyProperty DragIncrementProperty => null;

		public static DependencyProperty KeyboardIncrementProperty => null;

		public static DependencyProperty ResizeDirectionProperty => null;

		public static DependencyProperty ResizeBehaviorProperty
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static DependencyProperty ShowsPreviewProperty => null;

		public static DependencyProperty PreviewStyleProperty => null;

		public float DragIncrement
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float KeyboardIncrement
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public GridResizeDirection ResizeDirection
		{
			get
			{
				return default(GridResizeDirection);
			}
			set
			{
			}
		}

		public GridResizeBehavior ResizeBehavior
		{
			get
			{
				return default(GridResizeBehavior);
			}
			set
			{
			}
		}

		public bool ShowsPreview
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Style PreviewStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static GridSplitter CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GridSplitter(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GridSplitter obj)
		{
			return default(HandleRef);
		}

		public GridSplitter()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
