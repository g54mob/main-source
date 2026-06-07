using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Track : FrameworkElement
	{
		public static DependencyProperty IsDirectionReversedProperty => null;

		public static DependencyProperty MaximumProperty => null;

		public static DependencyProperty MinimumProperty => null;

		public static DependencyProperty OrientationProperty => null;

		public static DependencyProperty ValueProperty => null;

		public static DependencyProperty ViewportSizeProperty => null;

		public RepeatButton DecreaseRepeatButton
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RepeatButton IncreaseRepeatButton
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

		public Thumb Thumb
		{
			get
			{
				return null;
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

		public float ViewportSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static Track CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Track(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Track obj)
		{
			return default(HandleRef);
		}

		public Track()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public float ValueFromDistance(float horizontal, float vertical)
		{
			return 0f;
		}

		public float ValueFromPoint(Point point)
		{
			return 0f;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
