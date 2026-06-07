using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class EasingFunctionBase : Animatable
	{
		public static DependencyProperty EasingModeProperty => null;

		public EasingMode EasingMode
		{
			get
			{
				return default(EasingMode);
			}
			set
			{
			}
		}

		internal new static EasingFunctionBase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal EasingFunctionBase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(EasingFunctionBase obj)
		{
			return default(HandleRef);
		}

		protected EasingFunctionBase()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public float Ease(float normalizedTime)
		{
			return 0f;
		}
	}
}
