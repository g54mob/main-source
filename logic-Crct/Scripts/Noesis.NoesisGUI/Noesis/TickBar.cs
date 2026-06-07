using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TickBar : FrameworkElement
	{
		public static DependencyProperty FillProperty => null;

		public static DependencyProperty IsDirectionReversedProperty => null;

		public static DependencyProperty IsSelectionRangeEnabledProperty => null;

		public static DependencyProperty MaximumProperty => null;

		public static DependencyProperty MinimumProperty => null;

		public static DependencyProperty PlacementProperty => null;

		public static DependencyProperty ReservedSpaceProperty => null;

		public static DependencyProperty SelectionEndProperty => null;

		public static DependencyProperty SelectionStartProperty => null;

		public static DependencyProperty TickFrequencyProperty => null;

		public static DependencyProperty TicksProperty => null;

		public Brush Fill
		{
			get
			{
				return null;
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

		public float Maximum
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Minimum
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TickBarPlacement Placement
		{
			get
			{
				return default(TickBarPlacement);
			}
			set
			{
			}
		}

		public float ReservedSpace
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

		internal new static TickBar CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TickBar(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TickBar obj)
		{
			return default(HandleRef);
		}

		public TickBar()
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
