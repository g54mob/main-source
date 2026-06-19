using System;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	internal struct StringTableReaderHandle : IDisposable
	{
		private unsafe readonly byte* _stringTableData;

		private readonly uint _stringTableDataSize;

		public unsafe StringTableReaderHandle(DotsSerializationReader.NodeHandle stringTableNode)
		{
			_stringTableDataSize = (uint)stringTableNode.DataSize;
			_stringTableData = (byte*)UnsafeUtility.Malloc(stringTableNode.DataSize, 4, Allocator.TempJob);
			stringTableNode.ReadData(_stringTableData, 0L, -1L);
		}

		public unsafe void Dispose()
		{
			UnsafeUtility.Free(_stringTableData, Allocator.TempJob);
		}

		public unsafe string GetString(int offset)
		{
			int stringLength = GetStringLength(offset);
			if (stringLength == -1)
			{
				return $"Offset out of range {offset}";
			}
			return Encoding.UTF8.GetString(_stringTableData + offset + 4, stringLength);
		}

		public unsafe FixedString32Bytes GetString32(int offset)
		{
			int stringLength = GetStringLength(offset);
			if (stringLength == -1)
			{
				return new FixedString32Bytes($"Invalid Offset {offset}");
			}
			FixedString32Bytes fs = default(FixedString32Bytes);
			FixedStringMethods.Append(ref fs, _stringTableData + offset + 4, Math.Min(stringLength, 32));
			return fs;
		}

		public unsafe FixedString64Bytes GetString64(int offset)
		{
			int stringLength = GetStringLength(offset);
			if (stringLength == -1)
			{
				return new FixedString64Bytes($"Invalid Offset {offset}");
			}
			FixedString64Bytes fs = default(FixedString64Bytes);
			FixedStringMethods.Append(ref fs, _stringTableData + offset + 4, Math.Min(stringLength, 64));
			return fs;
		}

		public unsafe FixedString128Bytes GetString128(int offset)
		{
			int stringLength = GetStringLength(offset);
			if (stringLength == -1)
			{
				return new FixedString128Bytes($"Invalid Offset {offset}");
			}
			FixedString128Bytes fs = default(FixedString128Bytes);
			FixedStringMethods.Append(ref fs, _stringTableData + offset + 4, Math.Min(stringLength, 128));
			return fs;
		}

		public unsafe FixedString512Bytes GetString512(int offset)
		{
			int stringLength = GetStringLength(offset);
			if (stringLength == -1)
			{
				return new FixedString512Bytes($"Invalid Offset {offset}");
			}
			FixedString512Bytes fs = default(FixedString512Bytes);
			FixedStringMethods.Append(ref fs, _stringTableData + offset + 4, Math.Min(stringLength, 512));
			return fs;
		}

		public unsafe FixedString4096Bytes GetString4096(int offset)
		{
			int stringLength = GetStringLength(offset);
			if (stringLength == -1)
			{
				return new FixedString4096Bytes($"Invalid Offset {offset}");
			}
			FixedString4096Bytes fs = default(FixedString4096Bytes);
			FixedStringMethods.Append(ref fs, _stringTableData + offset + 4, Math.Min(stringLength, 4096));
			return fs;
		}

		public unsafe int GetStringLength(int offset)
		{
			if (offset < 0 || offset >= _stringTableDataSize)
			{
				return -1;
			}
			return *(int*)(_stringTableData + offset);
		}
	}
}
