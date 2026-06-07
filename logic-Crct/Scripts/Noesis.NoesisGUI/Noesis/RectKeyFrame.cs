using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RectKeyFrame : Freezable
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

		public Rect Value
		{
			get
			{
				return default(Rect);
			}
			set
			{
			}
		}

		internal new static RectKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RectKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RectKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected RectKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
