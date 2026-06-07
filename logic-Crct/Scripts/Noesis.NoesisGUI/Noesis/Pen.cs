using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Pen : Animatable
	{
		public static DependencyProperty BrushProperty => null;

		public static DependencyProperty DashCapProperty => null;

		public static DependencyProperty DashStyleProperty => null;

		public static DependencyProperty EndLineCapProperty => null;

		public static DependencyProperty LineJoinProperty => null;

		public static DependencyProperty MiterLimitProperty => null;

		public static DependencyProperty StartLineCapProperty => null;

		public static DependencyProperty ThicknessProperty => null;

		public static DependencyProperty TrimStartProperty => null;

		public static DependencyProperty TrimEndProperty => null;

		public static DependencyProperty TrimOffsetProperty => null;

		public Brush Brush
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PenLineCap DashCap
		{
			get
			{
				return default(PenLineCap);
			}
			set
			{
			}
		}

		public DashStyle DashStyle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PenLineCap EndLineCap
		{
			get
			{
				return default(PenLineCap);
			}
			set
			{
			}
		}

		public PenLineJoin LineJoin
		{
			get
			{
				return default(PenLineJoin);
			}
			set
			{
			}
		}

		public float MiterLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PenLineCap StartLineCap
		{
			get
			{
				return default(PenLineCap);
			}
			set
			{
			}
		}

		public float Thickness
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

		internal new static Pen CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Pen(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Pen obj)
		{
			return default(HandleRef);
		}

		public Pen()
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
