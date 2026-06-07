using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BackEase : EasingFunctionBase
	{
		public static DependencyProperty AmplitudeProperty => null;

		public float Amplitude
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static BackEase CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BackEase(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BackEase obj)
		{
			return default(HandleRef);
		}

		public BackEase()
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
