using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class QuadraticBezierSegment : PathSegment
	{
		public static DependencyProperty Point1Property => null;

		public static DependencyProperty Point2Property => null;

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

		internal new static QuadraticBezierSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal QuadraticBezierSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(QuadraticBezierSegment obj)
		{
			return default(HandleRef);
		}

		public QuadraticBezierSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public QuadraticBezierSegment(Point point1, Point point2, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
