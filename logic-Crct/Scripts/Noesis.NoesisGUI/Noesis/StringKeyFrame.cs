using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StringKeyFrame : Freezable
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

		public string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static StringKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StringKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(StringKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected StringKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
