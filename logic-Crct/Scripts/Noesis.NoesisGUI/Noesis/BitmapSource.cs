using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BitmapSource : ImageSource
	{
		public enum Format
		{
			BGRA8 = 0,
			BGR8 = 1,
			RGBA8 = 2,
			RGB8 = 3
		}

		public float DpiX => 0f;

		public float DpiY => 0f;

		public int PixelWidth => 0;

		public int PixelHeight => 0;

		internal new static BitmapSource CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BitmapSource(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BitmapSource obj)
		{
			return default(HandleRef);
		}

		protected BitmapSource()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static BitmapSource Create(int pixelWidth, int pixelHeight, double dpiX, double dpiY, byte[] pixels, int stride, Format format)
		{
			return null;
		}

		public void CopyPixels(byte[] pixels, int stride, int offset)
		{
		}

		public Format GetFormat()
		{
			return default(Format);
		}

		private static IntPtr CreateHelper(int pixelWidth, int pixelHeight, float dpiX, float dpiY, byte[] buffer, int stride, uint format)
		{
			return (IntPtr)0;
		}

		private void CopyPixelsHelper(byte[] buffer, uint bufferSize, int stride, int offset)
		{
		}
	}
}
