using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Noesis
{
	[TypeConverter(typeof(GeometryConverter))]
	public class Geometry : Animatable
	{
		public Rect Bounds => default(Rect);

		public static DependencyProperty TransformProperty => null;

		public Transform Transform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Geometry CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Geometry(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Geometry obj)
		{
			return default(HandleRef);
		}

		protected Geometry()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Geometry Parse(string source)
		{
			return null;
		}

		public virtual bool IsEmpty()
		{
			return false;
		}

		public Rect GetRenderBounds(Pen pen)
		{
			return default(Rect);
		}

		public bool FillContains(Point point)
		{
			return false;
		}

		public bool StrokeContains(Pen pen, Point point)
		{
			return false;
		}

		private void GetBoundsHelper(out Rect bounds)
		{
			bounds = default(Rect);
		}

		private static IntPtr ParseHelper(string str)
		{
			return (IntPtr)0;
		}
	}
}
