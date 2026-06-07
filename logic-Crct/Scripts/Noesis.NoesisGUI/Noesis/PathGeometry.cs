using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PathGeometry : Geometry
	{
		public static DependencyProperty FiguresProperty => null;

		public static DependencyProperty FillRuleProperty => null;

		public PathFigureCollection Figures
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FillRule FillRule
		{
			get
			{
				return default(FillRule);
			}
			set
			{
			}
		}

		internal new static PathGeometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PathGeometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PathGeometry obj)
		{
			return default(HandleRef);
		}

		public override string ToString()
		{
			return null;
		}

		public PathGeometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public override bool IsEmpty()
		{
			return false;
		}

		private string ToStringHelper()
		{
			return null;
		}
	}
}
