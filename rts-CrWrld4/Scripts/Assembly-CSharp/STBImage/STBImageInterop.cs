using System;
using System.Runtime.InteropServices;

namespace STBImage
{
	public static class STBImageInterop
	{
		private const string DllPath = "stb_image";

		[PreserveSig]
		private static extern IntPtr _loadFromMemory(IntPtr buffer, int len, ref int x, ref int y, ref int channelsInFile, int desiredChannels);

		[PreserveSig]
		private static extern void _imageFree(IntPtr buffer);

		public static IntPtr LoadFromMemoryPointer(IntPtr inDataPointer, int inDataLength, out int outX, out int outY, out int outChannelsInFile, int desiredChannels, out int dataLength)
		{
			outX = default(int);
			outY = default(int);
			outChannelsInFile = default(int);
			dataLength = default(int);
			return (IntPtr)0;
		}

		public static IntPtr LoadFromMemory(byte[] data, out int outX, out int outY, out int outChannelsInFile, int desiredChannels, out int dataLength)
		{
			outX = default(int);
			outY = default(int);
			outChannelsInFile = default(int);
			dataLength = default(int);
			return (IntPtr)0;
		}

		public static void ImageFree(IntPtr dataPtr)
		{
		}

		private static GCHandle LockGc(object value)
		{
			return default(GCHandle);
		}
	}
}
