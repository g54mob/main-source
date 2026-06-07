using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CrlIdentifier : Asn1Encodable
	{
		private readonly X509Name crlIssuer;

		private readonly DerUtcTime crlIssuedTime;

		private readonly DerInteger crlNumber;

		public X509Name CrlIssuer => null;

		public DateTime CrlIssuedTime => default(DateTime);

		public BigInteger CrlNumber => null;

		public static CrlIdentifier GetInstance(object obj)
		{
			return null;
		}

		private CrlIdentifier(Asn1Sequence seq)
		{
		}

		public CrlIdentifier(X509Name crlIssuer, DateTime crlIssuedTime)
		{
		}

		public CrlIdentifier(X509Name crlIssuer, DateTime crlIssuedTime, BigInteger crlNumber)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
