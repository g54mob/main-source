using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int64KeyFrame : Freezable
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

		public long Value
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		internal new static Int64KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int64KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int64KeyFrame obj)
		{
			return default(HandleRef);
		}

		protected Int64KeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
