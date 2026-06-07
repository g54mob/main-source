using System;

namespace STB
{
	public static class STBImageLoader
	{
		public static IntPtr LoadTextureDataFromByteArray(byte[] bytes, out int width, out int height, out int channelsInFile, out int dataLength)
		{
			width = default(int);
			height = default(int);
			channelsInFile = default(int);
			dataLength = default(int);
			return (IntPtr)0;
		}

		public static IntPtr LoadTextureFromDataPointer(IntPtr inDataPointer, int inDataLength, out int width, out int height, out int channelsInFile, out int dataLength)
		{
			width = default(int);
			height = default(int);
			channelsInFile = default(int);
			dataLength = default(int);
			return (IntPtr)0;
		}

		public static void UnloadTextureData(IntPtr dataPointer)
		{
		}
	}
}
