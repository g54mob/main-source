using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerOctetString : DerOctetString, IEnumerable
	{
		private static readonly int DefaultChunkSize;

		private readonly int chunkSize;

		private readonly Asn1OctetString[] octs;

		public static BerOctetString FromSequence(Asn1Sequence seq)
		{
			return null;
		}

		private static byte[] ToBytes(Asn1OctetString[] octs)
		{
			return null;
		}

		private static Asn1OctetString[] ToOctetStringArray(IEnumerable e)
		{
			return null;
		}

		public BerOctetString(IEnumerable e)
			: base((byte[])null)
		{
		}

		public BerOctetString(byte[] str)
			: base((byte[])null)
		{
		}

		public BerOctetString(Asn1OctetString[] octs)
			: base((byte[])null)
		{
		}

		public BerOctetString(byte[] str, int chunkSize)
			: base((byte[])null)
		{
		}

		public BerOctetString(Asn1OctetString[] octs, int chunkSize)
			: base((byte[])null)
		{
		}

		private BerOctetString(byte[] str, Asn1OctetString[] octs, int chunkSize)
			: base((byte[])null)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public IEnumerator GetObjects()
		{
			return null;
		}

		private IList GenerateOcts()
		{
			return null;
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}
	}
}
