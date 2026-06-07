using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Slider : RangeBase
	{
		public static DependencyProperty DelayProperty => null;

		public static DependencyProperty IntervalProperty => null;

		public static DependencyProperty IsDirectionReversedProperty => null;

		public static DependencyProperty IsMoveToPointEnabledProperty => null;

		public static DependencyProperty IsSelectionRangeEnabledProperty => null;

		public static DependencyProperty IsSnapToTickEnabledProperty => null;

		public static DependencyProperty OrientationProperty => null;

		public static DependencyProperty SelectionEndProperty => null;

		public static DependencyProperty SelectionStartProperty => null;

		public static DependencyProperty TickFrequencyProperty => null;

		public static DependencyProperty TickPlacementProperty => null;

		public static DependencyProperty TicksProperty => null;

		public static RoutedCommand DecreaseLargeCommand => null;

		public static RoutedCommand DecreaseSmallCommand => null;

		public static RoutedCommand IncreaseLargeCommand => null;

		public static RoutedCommand IncreaseSmallCommand => null;

		public static RoutedCommand MaximizeValueCommand => null;

		public static RoutedCommand MinimizeValueCommand => null;

		public int Delay
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Interval
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsDirectionReversed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsMoveToPointEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSelectionRangeEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSnapToTickEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Orientation Orientation
		{
			get
			{
				return default(Orientation);
			}
			set
			{
			}
		}

		public float SelectionStart
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SelectionEnd
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TickFrequency
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TickPlacement TickPlacement
		{
			get
			{
				return default(TickPlacement);
			}
			set
			{
			}
		}

		public string Ticks
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Slider CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Slider(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Slider obj)
		{
			return default(HandleRef);
		}

		public Slider()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
