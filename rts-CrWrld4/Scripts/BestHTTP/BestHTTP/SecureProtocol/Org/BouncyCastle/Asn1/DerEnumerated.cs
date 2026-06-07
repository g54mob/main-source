using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerEnumerated : Asn1Object
	{
		private readonly byte[] bytes;

		private readonly int start;

		private static readonly DerEnumerated[] cache;

		public BigInteger Value => null;

		public int IntValueExact => 0;

		public static DerEnumerated GetInstance(object obj)
		{
			return null;
		}

		public static DerEnumerated GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public DerEnumerated(int val)
		{
		}

		public DerEnumerated(long val)
		{
		}

		public DerEnumerated(BigInteger val)
		{
		}

		public DerEnumerated(byte[] bytes)
		{
		}

		public bool HasValue(BigInteger x)
		{
			return false;
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		protected override int Asn1GetHashCode()
		{
			return 0;
		}

		internal static DerEnumerated FromOctetString(byte[] enc)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
