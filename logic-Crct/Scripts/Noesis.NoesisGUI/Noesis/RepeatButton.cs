using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RepeatButton : ButtonBase
	{
		public static DependencyProperty DelayProperty => null;

		public static DependencyProperty IntervalProperty => null;

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

		internal new static RepeatButton CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RepeatButton(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RepeatButton obj)
		{
			return default(HandleRef);
		}

		public RepeatButton()
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
