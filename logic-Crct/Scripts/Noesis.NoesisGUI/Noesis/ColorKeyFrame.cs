using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ColorKeyFrame : Freezable
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

		public Color Value
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		internal new static ColorKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ColorKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ColorKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected ColorKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
