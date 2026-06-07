public class BitStreamReader
{
	private byte[] _byteArray;

	private uint _bufferLengthInBits;

	private int _byteArrayIndex;

	private byte _partialByte;

	private int _cbitsInPartialByte;

	internal bool EndOfStream => false;

	internal int CurrentIndex => 0;

	internal BitStreamReader(byte[] buffer)
	{
	}

	internal BitStreamReader(byte[] buffer, int startIndex)
	{
	}

	internal BitStreamReader(byte[] buffer, uint bufferLengthInBits)
	{
	}

	internal long ReadUInt64(int countOfBits)
	{
		return 0L;
	}

	internal ushort ReadUInt16(int countOfBits)
	{
		return 0;
	}

	internal uint ReadUInt16Reverse(int countOfBits)
	{
		return 0u;
	}

	internal uint ReadUInt32(int countOfBits)
	{
		return 0u;
	}

	internal uint ReadUInt32Reverse(int countOfBits)
	{
		return 0u;
	}

	internal bool ReadBit()
	{
		return false;
	}

	internal byte ReadByte(int countOfBits)
	{
		return 0;
	}
}
