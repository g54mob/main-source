using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Encoders
{
	public class Base64Encoder : IEncoder
	{
		protected readonly byte[] encodingTable;

		protected byte padding;

		protected readonly byte[] decodingTable;

		protected void InitialiseDecodingTable()
		{
		}

		public int Encode(byte[] data, int off, int length, Stream outStream)
		{
			return 0;
		}

		private bool ignore(char c)
		{
			return false;
		}

		public int Decode(byte[] data, int off, int length, Stream outStream)
		{
			return 0;
		}

		private int nextI(byte[] data, int i, int finish)
		{
			return 0;
		}

		public int DecodeString(string data, Stream outStream)
		{
			return 0;
		}

		private int decodeLastBlock(Stream outStream, char c1, char c2, char c3, char c4)
		{
			return 0;
		}

		private int nextI(string data, int i, int finish)
		{
			return 0;
		}
	}
}
