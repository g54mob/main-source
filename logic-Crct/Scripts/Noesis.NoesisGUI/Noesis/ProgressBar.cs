using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ProgressBar : RangeBase
	{
		public static DependencyProperty IsIndeterminateProperty => null;

		public static DependencyProperty OrientationProperty => null;

		public bool IsIndeterminate
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

		internal new static ProgressBar CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ProgressBar(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ProgressBar obj)
		{
			return default(HandleRef);
		}

		public ProgressBar()
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
