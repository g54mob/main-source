using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ObjectKeyFrame : Freezable
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

		public object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ObjectKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ObjectKeyFrame(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ObjectKeyFrame obj)
		{
			return default(HandleRef);
		}

		protected ObjectKeyFrame()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
