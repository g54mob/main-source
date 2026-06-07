using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PolyLineSegment : PathSegment
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

		internal new static PolyLineSegment CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PolyLineSegment(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PolyLineSegment obj)
		{
			return default(HandleRef);
		}

		public PolyLineSegment()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public PolyLineSegment(ref Point points, uint numPoints, bool isStroked)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
