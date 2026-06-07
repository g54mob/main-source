using System;
using System.Runtime.InteropServices;

namespace STBImage
{
	public static class STBImageInterop
	{
		private const string DllPath = "stb_image";

		[DllImport("stb_image", EntryPoint = "loadFromMemory")]
		private static extern IntPtr _loadFromMemory(IntPtr buffer, int len, ref int x, ref int y, ref int channelsInFile, int desiredChannels);

		[DllImport("stb_image", EntryPoint = "imageFree")]
		private static extern void _imageFree(IntPtr buffer);

		public static IntPtr LoadFromMemoryPointer(IntPtr inDataPointer, int inDataLength, out int outX, out int outY, out int outChannelsInFile, int desiredChannels, out int dataLength)
		{
			outX = 0;
			outY = 0;
			outChannelsInFile = 0;
			IntPtr result = _loadFromMemory(inDataPointer, inDataLength, ref outX, ref outY, ref outChannelsInFile, desiredChannels);
			dataLength = outX * outY * desiredChannels;
			return result;
		}

		public static IntPtr LoadFromMemory(byte[] data, out int outX, out int outY, out int outChannelsInFile, int desiredChannels, out int dataLength)
		{
			GCHandle gCHandle = LockGc(data);
			outX = 0;
			outY = 0;
			outChannelsInFile = 0;
			IntPtr result = _loadFromMemory(gCHandle.AddrOfPinnedObject(), data.Length, ref outX, ref outY, ref outChannelsInFile, desiredChannels);
			gCHandle.Free();
			dataLength = outX * outY * desiredChannels;
			return result;
		}

		public static void ImageFree(IntPtr dataPtr)
		{
			_imageFree(dataPtr);
		}

		private static GCHandle LockGc(object value)
		{
			return GCHandle.Alloc(value, GCHandleType.Pinned);
		}
	}
}
