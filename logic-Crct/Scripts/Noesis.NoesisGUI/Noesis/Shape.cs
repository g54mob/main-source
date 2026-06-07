using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Shape : FrameworkElement
	{
		public static DependencyProperty FillProperty => null;

		public static DependencyProperty StretchProperty => null;

		public static DependencyProperty StrokeProperty => null;

		public static DependencyProperty StrokeDashArrayProperty => null;

		public static DependencyProperty StrokeDashCapProperty => null;

		public static DependencyProperty StrokeDashOffsetProperty => null;

		public static DependencyProperty StrokeEndLineCapProperty => null;

		public static DependencyProperty StrokeLineJoinProperty => null;

		public static DependencyProperty StrokeMiterLimitProperty => null;

		public static DependencyProperty StrokeStartLineCapProperty => null;

		public static DependencyProperty StrokeThicknessProperty => null;

		public static DependencyProperty TrimStartProperty => null;

		public static DependencyProperty TrimEndProperty => null;

		public static DependencyProperty TrimOffsetProperty => null;

		public Brush Fill
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Stretch Stretch
		{
			get
			{
				return default(Stretch);
			}
			set
			{
			}
		}

		public Brush Stroke
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string StrokeDashArray
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PenLineCap StrokeDashCap
		{
			get
			{
				return default(PenLineCap);
			}
			set
			{
			}
		}

		public float StrokeDashOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PenLineCap StrokeEndLineCap
		{
			get
			{
				return default(PenLineCap);
			}
			set
			{
			}
		}

		public PenLineJoin StrokeLineJoin
		{
			get
			{
				return default(PenLineJoin);
			}
			set
			{
			}
		}

		public float StrokeMiterLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PenLineCap StrokeStartLineCap
		{
			get
			{
				return default(PenLineCap);
			}
			set
			{
			}
		}

		public float StrokeThickness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TrimStart
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TrimEnd
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TrimOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static Shape CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Shape(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Shape obj)
		{
			return default(HandleRef);
		}

		protected Shape()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
