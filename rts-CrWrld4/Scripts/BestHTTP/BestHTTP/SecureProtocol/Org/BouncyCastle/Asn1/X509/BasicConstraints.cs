using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class BasicConstraints : Asn1Encodable
	{
		private readonly DerBoolean cA;

		private readonly DerInteger pathLenConstraint;

		public BigInteger PathLenConstraint => null;

		public static BasicConstraints GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static BasicConstraints GetInstance(object obj)
		{
			return null;
		}

		public static BasicConstraints FromExtensions(X509Extensions extensions)
		{
			return null;
		}

		private BasicConstraints(Asn1Sequence seq)
		{
		}

		public BasicConstraints(bool cA)
		{
		}

		public BasicConstraints(int pathLenConstraint)
		{
		}

		public bool IsCA()
		{
			return false;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
