using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class CrlNumber : DerInteger
	{
		public BigInteger Number => null;

		public CrlNumber(BigInteger number)
			: base(0)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
