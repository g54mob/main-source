public class Encoder
{
	private static uint div;

	private static uint offset;

	public static char[] ALPHABET;

	public static bool CheckKey(string key, out uint id, out uint randomNumber)
	{
		id = default(uint);
		randomNumber = default(uint);
		return false;
	}

	private static void WriteBit(byte[] data, int loc, byte bit)
	{
	}

	private static byte ReadBit(byte[] data, int loc)
	{
		return 0;
	}

	private static void WriteByte(byte[] data, int loc, byte b)
	{
	}

	private static byte ReadByte(byte[] data, int loc)
	{
		return 0;
	}

	private static ushort Digest(byte[] data, int l)
	{
		return 0;
	}

	public static string Encode(byte[] data)
	{
		return null;
	}

	public static byte[] Decode(string data)
	{
		return null;
	}

	private static string AlphaMap(int v)
	{
		return null;
	}

	private static byte AlphaUnmap(char c1, char c2)
	{
		return 0;
	}

	private static string InsertDashes(string data)
	{
		return null;
	}

	private static string RemoveDashes(string data)
	{
		return null;
	}
}
