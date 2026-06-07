using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RadialGradientBrush : GradientBrush
	{
		public static DependencyProperty CenterProperty => null;

		public static DependencyProperty GradientOriginProperty => null;

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

		public Point GradientOrigin
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

		internal new static RadialGradientBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RadialGradientBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RadialGradientBrush obj)
		{
			return default(HandleRef);
		}

		public RadialGradientBrush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
