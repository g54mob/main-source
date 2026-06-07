using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PolyBezierSegment : PathSegment
	{
		public static DependencyProperty PointsProperty => null;

		public PointCollection Points
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static PolyBezierSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PolyBezierSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PolyBezierSegment obj)
		{
			return default(HandleRef);
		}

		public PolyBezierSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public PolyBezierSegment(ref Point points, uint numPoints, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
