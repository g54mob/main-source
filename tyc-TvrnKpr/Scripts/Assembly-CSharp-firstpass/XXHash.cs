public class XXHash : HashFunction
{
	private uint seed;

	private const uint PRIME32_1 = 2654435761u;

	private const uint PRIME32_2 = 2246822519u;

	private const uint PRIME32_3 = 3266489917u;

	private const uint PRIME32_4 = 668265263u;

	private const uint PRIME32_5 = 374761393u;

	public XXHash(int seed)
	{
	}

	public uint GetHash(byte[] buf)
	{
		return 0u;
	}

	public uint GetHash(params uint[] buf)
	{
		return 0u;
	}

	public override uint GetHash(params int[] buf)
	{
		return 0u;
	}

	public override uint GetHash(int buf)
	{
		return 0u;
	}

	private static uint CalcSubHash(uint value, byte[] buf, int index)
	{
		return 0u;
	}

	private static uint CalcSubHash(uint value, uint read_value)
	{
		return 0u;
	}

	private static uint RotateLeft(uint value, int count)
	{
		return 0u;
	}
}
