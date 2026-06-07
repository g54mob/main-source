using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ExponentialEase : EasingFunctionBase
	{
		public static DependencyProperty ExponentProperty => null;

		public float Exponent
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static ExponentialEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ExponentialEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExponentialEase obj)
		{
			return default(HandleRef);
		}

		public ExponentialEase()
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
