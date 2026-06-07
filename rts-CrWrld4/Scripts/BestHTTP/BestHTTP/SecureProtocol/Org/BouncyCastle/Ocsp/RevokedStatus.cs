using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	public class RevokedStatus : CertificateStatus
	{
		internal readonly RevokedInfo info;

		public DateTime RevocationTime => default(DateTime);

		public bool HasRevocationReason => false;

		public int RevocationReason => 0;

		public RevokedStatus(RevokedInfo info)
		{
		}

		public RevokedStatus(DateTime revocationDate, int reason)
		{
		}
	}
}
