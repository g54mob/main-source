using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ThicknessKeyFrame : Freezable
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

		public Thickness Value
		{
			get
			{
				return default(Thickness);
			}
			set
			{
			}
		}

		internal new static ThicknessKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ThicknessKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ThicknessKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected ThicknessKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
