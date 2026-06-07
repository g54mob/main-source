using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class PointKeyFrame : Freezable
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

		public Point Value
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal new static PointKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal PointKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(PointKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected PointKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
