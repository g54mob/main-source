using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RectangleGeometry : Geometry
	{
		public static DependencyProperty RadiusXProperty => null;

		public static DependencyProperty RadiusYProperty => null;

		public static DependencyProperty RectProperty => null;

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

		public Rect Rect
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		internal new static RectangleGeometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RectangleGeometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RectangleGeometry obj)
		{
			return default(HandleRef);
		}

		public RectangleGeometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public RectangleGeometry(Rect rect, float rX, float rY)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RectangleGeometry(Rect rect, float rX)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RectangleGeometry(Rect rect)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public override bool IsEmpty()
		{
			return false;
		}
	}
}
