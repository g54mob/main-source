using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Int16KeyFrame : Freezable
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

		public short Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal new static Int16KeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Int16KeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Int16KeyFrame obj)
		{
			return default(HandleRef);
		}

		protected Int16KeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
