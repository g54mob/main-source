using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace ScriptHelpers
{
	public class SaveableBinStack : ISaveableBin
	{
		public List<ISaveableBin> stack;

		public int BytesSpace()
		{
			return stack.Sum((ISaveableBin s) => s.BytesSpace() + 4);
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			foreach (ISaveableBin item in stack)
			{
				int num = item.BytesSpace();
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, bytes, offset, 4);
				item.SaveStateBin(bytes, offset + 4);
				offset += num + 4;
			}
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Utility.Version version, int offset = 0, int nBytes = -1)
		{
			if (nBytes < 1)
			{
				nBytes = bytes.Length;
			}
			int num = offset + nBytes;
			foreach (ISaveableBin item in stack)
			{
				if (offset >= num)
				{
					break;
				}
				int num2 = BitConverter.ToInt32(bytes, offset);
				item.LoadStateBin(bytes, version, offset + 4, num2);
				offset += 4 + num2;
			}
		}
	}
}
