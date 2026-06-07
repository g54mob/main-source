using System;
using STBImage;

namespace STB
{
	public static class STBImageLoader
	{
		public static IntPtr LoadTextureDataFromByteArray(byte[] bytes, out int width, out int height, out int channelsInFile, out int dataLength)
		{
			return STBImageInterop.LoadFromMemory(bytes, out width, out height, out channelsInFile, 4, out dataLength);
		}

		public static IntPtr LoadTextureFromDataPointer(IntPtr inDataPointer, int inDataLength, out int width, out int height, out int channelsInFile, out int dataLength)
		{
			return STBImageInterop.LoadFromMemoryPointer(inDataPointer, inDataLength, out width, out height, out channelsInFile, 4, out dataLength);
		}

		public static void UnloadTextureData(IntPtr dataPointer)
		{
			STBImageInterop.ImageFree(dataPointer);
		}
	}
}
