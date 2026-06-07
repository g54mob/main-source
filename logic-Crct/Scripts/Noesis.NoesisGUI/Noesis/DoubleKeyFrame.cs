using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DoubleKeyFrame : Freezable
	{
		public static DependencyProperty KeyTimeProperty => null;

		public static DependencyProperty ValueProperty => null;

		public KeyTime KeyTime
		{
			get
			{
				return default(KeyTime);
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

		internal new static DoubleKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DoubleKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DoubleKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected DoubleKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
