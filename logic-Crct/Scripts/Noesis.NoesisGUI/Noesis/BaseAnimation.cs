using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BaseAnimation : AnimationTimeline
	{
		public static DependencyProperty EasingFunctionProperty => null;

		public EasingFunctionBase EasingFunction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static BaseAnimation CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BaseAnimation(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BaseAnimation obj)
		{
			return default(HandleRef);
		}

		protected BaseAnimation()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
