using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LineSegment : PathSegment
	{
		public static DependencyProperty PointProperty => null;

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

		internal new static LineSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LineSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LineSegment obj)
		{
			return default(HandleRef);
		}

		public LineSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public LineSegment(Point point, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
