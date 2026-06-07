using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	internal class DefiniteLengthInputStream : LimitedInputStream
	{
		private static readonly byte[] EmptyBytes;

		private readonly int _originalLength;

		private int _remaining;

		internal int Remaining => 0;

		internal DefiniteLengthInputStream(Stream inStream, int length, int limit)
			: base(null, 0)
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buf, int off, int len)
		{
			return 0;
		}

		internal void ReadAllIntoByteArray(byte[] buf)
		{
		}

		internal byte[] ToArray()
		{
			return null;
		}
	}
}
