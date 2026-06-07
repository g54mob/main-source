using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GradientBrush : Brush
	{
		public static DependencyProperty ColorInterpolationModeProperty => null;

		public static DependencyProperty GradientStopsProperty => null;

		public static DependencyProperty MappingModeProperty => null;

		public static DependencyProperty SpreadMethodProperty => null;

		public ColorInterpolationMode ColorInterpolationMode
		{
			get
			{
				return default(ColorInterpolationMode);
			}
			set
			{
			}
		}

		public GradientStopCollection GradientStops
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BrushMappingMode MappingMode
		{
			get
			{
				return default(BrushMappingMode);
			}
			set
			{
			}
		}

		public GradientSpreadMethod SpreadMethod
		{
			get
			{
				return default(GradientSpreadMethod);
			}
			set
			{
			}
		}

		internal new static GradientBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GradientBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GradientBrush obj)
		{
			return default(HandleRef);
		}

		protected GradientBrush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
