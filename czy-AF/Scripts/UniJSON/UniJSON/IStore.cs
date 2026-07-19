using System;

namespace UniJSON
{
	public interface IStore
	{
		ArraySegment<byte> Bytes { get; }

		void Clear();

		void Write(byte value);

		void Write(sbyte value);

		void WriteBigEndian(ushort value);

		void WriteBigEndian(uint value);

		void WriteBigEndian(ulong value);

		void WriteBigEndian(short value);

		void WriteBigEndian(int value);

		void WriteBigEndian(long value);

		void WriteBigEndian(float value);

		void WriteBigEndian(double value);

		void WriteLittleEndian(ushort value);

		void WriteLittleEndian(uint value);

		void WriteLittleEndian(ulong value);

		void WriteLittleEndian(short value);

		void WriteLittleEndian(int value);

		void WriteLittleEndian(long value);

		void WriteLittleEndian(float value);

		void WriteLittleEndian(double value);

		void Write(ArraySegment<byte> bytes);

		void Write(string src);

		void Write(char c);
	}
}
