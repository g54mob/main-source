using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LinearGradientBrush : GradientBrush
	{
		public static DependencyProperty EndPointProperty => null;

		public static DependencyProperty StartPointProperty => null;

		public Point StartPoint
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Point EndPoint
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal new static LinearGradientBrush CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LinearGradientBrush(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LinearGradientBrush obj)
		{
			return default(HandleRef);
		}

		public LinearGradientBrush()
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
