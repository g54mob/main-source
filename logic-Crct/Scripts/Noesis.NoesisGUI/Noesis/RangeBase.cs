using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RangeBase : Control
	{
		public static DependencyProperty LargeChangeProperty => null;

		public static DependencyProperty MaximumProperty => null;

		public static DependencyProperty MinimumProperty => null;

		public static DependencyProperty SmallChangeProperty => null;

		public static DependencyProperty ValueProperty => null;

		public static RoutedEvent ValueChangedEvent => null;

		public float LargeChange
		{
			get
			{
				return 0f;
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

		public float SmallChange
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event RoutedPropertyChangedEventHandler<float> ValueChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static RangeBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RangeBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RangeBase obj)
		{
			return default(HandleRef);
		}

		protected RangeBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
