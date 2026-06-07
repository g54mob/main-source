using System.Collections.Generic;

internal class BitStreamWriter
{
	private List<byte> _targetBuffer;

	private int _remaining;

	internal BitStreamWriter(List<byte> bufferToWriteTo)
	{
	}

	internal void Write(uint bits, int countOfBits)
	{
	}

	internal void WriteReverse(uint bits, int countOfBits)
	{
	}

	internal void Write(byte bits, int countOfBits)
	{
	}
}
