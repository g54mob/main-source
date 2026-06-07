using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LineGeometry : Geometry
	{
		public static DependencyProperty EndPointProperty => null;

		public static DependencyProperty StartPointProperty => null;

		public Point StartPoint
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Point EndPoint
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal new static LineGeometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LineGeometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LineGeometry obj)
		{
			return default(HandleRef);
		}

		public LineGeometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public LineGeometry(Point p1, Point p2)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override bool IsEmpty()
		{
			return false;
		}
	}
}
