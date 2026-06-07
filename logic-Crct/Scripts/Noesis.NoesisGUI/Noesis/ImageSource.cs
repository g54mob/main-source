using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ImageSource : Animatable
	{
		public float Width => 0f;

		public float Height => 0f;

		internal new static ImageSource CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ImageSource(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ImageSource obj)
		{
			return default(HandleRef);
		}

		protected ImageSource()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
