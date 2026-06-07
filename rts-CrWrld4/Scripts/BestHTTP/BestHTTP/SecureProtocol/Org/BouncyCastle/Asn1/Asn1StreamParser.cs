using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class Asn1StreamParser
	{
		private readonly Stream _in;

		private readonly int _limit;

		private readonly byte[][] tmpBuffers;

		public Asn1StreamParser(Stream inStream)
		{
		}

		public Asn1StreamParser(Stream inStream, int limit)
		{
		}

		public Asn1StreamParser(byte[] encoding)
		{
		}

		internal IAsn1Convertible ReadIndef(int tagValue)
		{
			return null;
		}

		internal IAsn1Convertible ReadImplicit(bool constructed, int tag)
		{
			return null;
		}

		internal Asn1Object ReadTaggedObject(bool constructed, int tag)
		{
			return null;
		}

		public virtual IAsn1Convertible ReadObject()
		{
			return null;
		}

		private void Set00Check(bool enabled)
		{
		}

		internal Asn1EncodableVector ReadVector()
		{
			return null;
		}
	}
}
