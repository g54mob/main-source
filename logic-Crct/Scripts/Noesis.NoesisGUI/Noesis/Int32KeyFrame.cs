using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int32KeyFrame : Freezable
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

		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal new static Int32KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int32KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int32KeyFrame obj)
		{
			return default(HandleRef);
		}

		protected Int32KeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
