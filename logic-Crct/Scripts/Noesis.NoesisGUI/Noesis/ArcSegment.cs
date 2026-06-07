using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ArcSegment : PathSegment
	{
		public static DependencyProperty PointProperty => null;

		public static DependencyProperty SizeProperty => null;

		public static DependencyProperty RotationAngleProperty => null;

		public static DependencyProperty IsLargeArcProperty => null;

		public static DependencyProperty SweepDirectionProperty => null;

		public Point Point
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Size Size
		{
			get
			{
				return default(Size);
			}
			set
			{
			}
		}

		public float RotationAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsLargeArc
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SweepDirection SweepDirection
		{
			get
			{
				return default(SweepDirection);
			}
			set
			{
			}
		}

		internal new static ArcSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ArcSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ArcSegment obj)
		{
			return default(HandleRef);
		}

		public ArcSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public ArcSegment(Point point, Size size, float rotationAngle, bool isLargeArc, SweepDirection sweepDirection, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
