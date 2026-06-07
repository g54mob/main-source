using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Encoders
{
	public sealed class Hex
	{
		private static readonly HexEncoder encoder;

		private Hex()
		{
		}

		public static string ToHexString(byte[] data)
		{
			return null;
		}

		public static string ToHexString(byte[] data, int off, int length)
		{
			return null;
		}

		public static byte[] Encode(byte[] data)
		{
			return null;
		}

		public static byte[] Encode(byte[] data, int off, int length)
		{
			return null;
		}

		public static int Encode(byte[] data, Stream outStream)
		{
			return 0;
		}

		public static int Encode(byte[] data, int off, int length, Stream outStream)
		{
			return 0;
		}

		public static byte[] Decode(byte[] data)
		{
			return null;
		}

		public static byte[] Decode(string data)
		{
			return null;
		}

		public static int Decode(string data, Stream outStream)
		{
			return 0;
		}

		public static byte[] DecodeStrict(string str)
		{
			return null;
		}

		public static byte[] DecodeStrict(string str, int off, int len)
		{
			return null;
		}
	}
}
