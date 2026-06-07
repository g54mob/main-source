using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EllipseGeometry : Geometry
	{
		public static DependencyProperty CenterProperty => null;

		public static DependencyProperty RadiusXProperty => null;

		public static DependencyProperty RadiusYProperty => null;

		public Point Center
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public float RadiusX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RadiusY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static EllipseGeometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EllipseGeometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EllipseGeometry obj)
		{
			return default(HandleRef);
		}

		public EllipseGeometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public EllipseGeometry(Point center, float rX, float rY)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override bool IsEmpty()
		{
			return false;
		}
	}
}
