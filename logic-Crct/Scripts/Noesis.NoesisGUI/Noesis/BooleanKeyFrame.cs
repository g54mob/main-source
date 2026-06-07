using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BooleanKeyFrame : Freezable
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

		public bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal new static BooleanKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BooleanKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BooleanKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected BooleanKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
