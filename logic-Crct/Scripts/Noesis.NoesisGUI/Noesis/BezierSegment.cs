using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BezierSegment : PathSegment
	{
		public static DependencyProperty Point1Property => null;

		public static DependencyProperty Point2Property => null;

		public static DependencyProperty Point3Property => null;

		public Point Point1
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Point Point2
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Point Point3
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal new static BezierSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BezierSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BezierSegment obj)
		{
			return default(HandleRef);
		}

		public BezierSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public BezierSegment(Point point1, Point point2, Point point3, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
