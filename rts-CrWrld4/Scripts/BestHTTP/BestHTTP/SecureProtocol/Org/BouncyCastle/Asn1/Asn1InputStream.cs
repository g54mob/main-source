using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class Asn1InputStream : FilterStream
	{
		private readonly int limit;

		private readonly byte[][] tmpBuffers;

		internal virtual int Limit => 0;

		internal static int FindLimit(Stream input)
		{
			return 0;
		}

		public Asn1InputStream(Stream inputStream)
			: base(null)
		{
		}

		public Asn1InputStream(Stream inputStream, int limit)
			: base(null)
		{
		}

		public Asn1InputStream(byte[] input)
			: base(null)
		{
		}

		private Asn1Object BuildObject(int tag, int tagNo, int length)
		{
			return null;
		}

		internal virtual Asn1EncodableVector ReadVector(DefiniteLengthInputStream dIn)
		{
			return null;
		}

		internal virtual DerSequence CreateDerSequence(DefiniteLengthInputStream dIn)
		{
			return null;
		}

		internal virtual DerSet CreateDerSet(DefiniteLengthInputStream dIn)
		{
			return null;
		}

		public Asn1Object ReadObject()
		{
			return null;
		}

		internal static int ReadTagNumber(Stream s, int tag)
		{
			return 0;
		}

		internal static int ReadLength(Stream s, int limit, bool isParsing)
		{
			return 0;
		}

		private static byte[] GetBuffer(DefiniteLengthInputStream defIn, byte[][] tmpBuffers)
		{
			return null;
		}

		private static char[] GetBmpCharBuffer(DefiniteLengthInputStream defIn)
		{
			return null;
		}

		internal static Asn1Object CreatePrimitiveDerObject(int tagNo, DefiniteLengthInputStream defIn, byte[][] tmpBuffers)
		{
			return null;
		}
	}
}
