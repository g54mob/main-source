using System;
using System.IO;
using System.Runtime.InteropServices;

namespace EasyRoads3Dv3
{
	public class BinaryWriterEx : BinaryWriter
	{
		public BinaryWriterEx()
		{
		}

		public BinaryWriterEx(string fileName)
		{
		}

		public long Seek(long offset, SeekOrigin origin)
		{
			Flush();
			return BaseStream.Seek(offset, origin);
		}

		public void WriteStruct(object theStruct)
		{
			byte[] array = new byte[Marshal.SizeOf(theStruct.GetType())];
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			Marshal.StructureToPtr(theStruct, gCHandle.AddrOfPinnedObject(), fDeleteOld: false);
			gCHandle.Free();
			Write(array);
		}

		public void Write(int[] array)
		{
			byte[] array2 = new byte[4 * array.Length];
			int num = 0;
			foreach (int value in array)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				array2[num++] = bytes[0];
				array2[num++] = bytes[1];
				array2[num++] = bytes[2];
				array2[num++] = bytes[3];
			}
			Write(array2);
		}

		public void Write(float[] array)
		{
			byte[] array2 = new byte[4 * array.Length];
			int num = 0;
			foreach (float value in array)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				array2[num++] = bytes[0];
				array2[num++] = bytes[1];
				array2[num++] = bytes[2];
				array2[num++] = bytes[3];
			}
			Write(array2);
		}
	}
}
