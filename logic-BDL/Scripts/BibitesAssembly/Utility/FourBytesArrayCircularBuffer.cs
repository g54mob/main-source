using System;
using System.Collections.Generic;
using System.Linq;
using ScriptHelpers;

namespace Utility
{
	public abstract class FourBytesArrayCircularBuffer<T> : CircularBuffer<T[]>, ISaveableBin where T : struct
	{
		public FourBytesArrayCircularBuffer(int size)
			: base(size)
		{
		}

		public void Push(List<T> val)
		{
			Push(val.ToArray());
		}

		public int BytesSpace()
		{
			return 4 * buffer.Sum((T[] e) => (e != null) ? (e.Length + 1) : 0);
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			for (int i = n - 1; i >= 0; i++)
			{
				T[] obj = buffer[i];
				int num = obj.Length;
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, bytes, offset, 4);
				Buffer.BlockCopy(obj, 0, bytes, offset + 4, num * 4);
			}
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			if (nBytes < 1)
			{
				nBytes = bytes.Length;
			}
			int num = offset + nBytes;
			int num2 = 0;
			while (offset < num)
			{
				int num3 = BitConverter.ToInt32(bytes, offset);
				T[] array = new T[num3];
				Buffer.BlockCopy(bytes, offset + 4, array, offset, 4 * num3);
				Push(array);
				offset += 4 + num3 * 4;
				num2++;
			}
		}
	}
}
