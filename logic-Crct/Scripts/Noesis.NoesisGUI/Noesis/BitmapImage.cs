using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BitmapImage : BitmapSource
	{
		public static DependencyProperty UriSourceProperty => null;

		public Uri UriSource
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static BitmapImage CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BitmapImage(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BitmapImage obj)
		{
			return default(HandleRef);
		}

		public BitmapImage(Uri uriSource)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public BitmapImage()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
