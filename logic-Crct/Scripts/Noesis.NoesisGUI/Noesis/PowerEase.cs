using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PowerEase : EasingFunctionBase
	{
		public static DependencyProperty PowerProperty => null;

		public float Power
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static PowerEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PowerEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PowerEase obj)
		{
			return default(HandleRef);
		}

		public PowerEase()
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
