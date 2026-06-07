using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TileBrush : Brush
	{
		public static DependencyProperty AlignmentXProperty => null;

		public static DependencyProperty AlignmentYProperty => null;

		public static DependencyProperty StretchProperty => null;

		public static DependencyProperty TileModeProperty => null;

		public static DependencyProperty ViewboxProperty => null;

		public static DependencyProperty ViewboxUnitsProperty => null;

		public static DependencyProperty ViewportProperty => null;

		public static DependencyProperty ViewportUnitsProperty => null;

		public AlignmentX AlignmentX
		{
			get
			{
				return default(AlignmentX);
			}
			set
			{
			}
		}

		public AlignmentY AlignmentY
		{
			get
			{
				return default(AlignmentY);
			}
			set
			{
			}
		}

		public Stretch Stretch
		{
			get
			{
				return default(Stretch);
			}
			set
			{
			}
		}

		public TileMode TileMode
		{
			get
			{
				return default(TileMode);
			}
			set
			{
			}
		}

		public Rect Viewbox
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public BrushMappingMode ViewboxUnits
		{
			get
			{
				return default(BrushMappingMode);
			}
			set
			{
			}
		}

		public Rect Viewport
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		public BrushMappingMode ViewportUnits
		{
			get
			{
				return default(BrushMappingMode);
			}
			set
			{
			}
		}

		internal new static TileBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TileBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TileBrush obj)
		{
			return default(HandleRef);
		}

		protected TileBrush()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
