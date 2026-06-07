using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SizeKeyFrame : Freezable
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

		public Size Value
		{
			get
			{
				return default(Size);
			}
			set
			{
			}
		}

		internal new static SizeKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal SizeKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SizeKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected SizeKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
