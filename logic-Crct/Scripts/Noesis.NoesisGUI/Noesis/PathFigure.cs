using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PathFigure : Animatable
	{
		public static DependencyProperty IsClosedProperty => null;

		public static DependencyProperty IsFilledProperty => null;

		public static DependencyProperty SegmentsProperty => null;

		public static DependencyProperty StartPointProperty => null;

		public bool IsClosed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsFilled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PathSegmentCollection Segments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		internal new static PathFigure CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PathFigure(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PathFigure obj)
		{
			return default(HandleRef);
		}

		public override string ToString()
		{
			return null;
		}

		public PathFigure()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public bool IsEmpty()
		{
			return false;
		}

		private string ToStringHelper()
		{
			return null;
		}
	}
}
