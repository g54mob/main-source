using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BlurEffect : Effect
	{
		public static DependencyProperty RadiusProperty => null;

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal new static BlurEffect CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BlurEffect(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BlurEffect obj)
		{
			return default(HandleRef);
		}

		public BlurEffect()
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
