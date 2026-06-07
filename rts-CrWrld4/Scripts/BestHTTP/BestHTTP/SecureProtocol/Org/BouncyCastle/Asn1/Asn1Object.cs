using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class Asn1Object : Asn1Encodable
	{
		public static Asn1Object FromByteArray(byte[] data)
		{
			return null;
		}

		public static Asn1Object FromStream(Stream inStr)
		{
			return null;
		}

		public sealed override Asn1Object ToAsn1Object()
		{
			return null;
		}

		internal abstract void Encode(DerOutputStream derOut);

		protected abstract bool Asn1Equals(Asn1Object asn1Object);

		protected abstract int Asn1GetHashCode();

		internal bool CallAsn1Equals(Asn1Object obj)
		{
			return false;
		}

		internal int CallAsn1GetHashCode()
		{
			return 0;
		}
	}
}
