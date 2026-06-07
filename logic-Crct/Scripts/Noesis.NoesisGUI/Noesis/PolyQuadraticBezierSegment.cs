using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PolyQuadraticBezierSegment : PathSegment
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

		internal new static PolyQuadraticBezierSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PolyQuadraticBezierSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PolyQuadraticBezierSegment obj)
		{
			return default(HandleRef);
		}

		public PolyQuadraticBezierSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public PolyQuadraticBezierSegment(ref Point points, uint numPoints, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
