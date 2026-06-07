using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class TbsCertificateList : Asn1Encodable
	{
		private class RevokedCertificatesEnumeration : IEnumerable
		{
			private class RevokedCertificatesEnumerator : IEnumerator
			{
				private readonly IEnumerator e;

				public object Current => null;

				internal RevokedCertificatesEnumerator(IEnumerator e)
				{
				}

				public bool MoveNext()
				{
					return false;
				}

				public void Reset()
				{
				}
			}

			private readonly IEnumerable en;

			internal RevokedCertificatesEnumeration(IEnumerable en)
			{
			}

			public IEnumerator GetEnumerator()
			{
				return null;
			}
		}

		internal Asn1Sequence seq;

		internal DerInteger version;

		internal AlgorithmIdentifier signature;

		internal X509Name issuer;

		internal Time thisUpdate;

		internal Time nextUpdate;

		internal Asn1Sequence revokedCertificates;

		internal X509Extensions crlExtensions;

		public int Version => 0;

		public DerInteger VersionNumber => null;

		public AlgorithmIdentifier Signature => null;

		public X509Name Issuer => null;

		public Time ThisUpdate => null;

		public Time NextUpdate => null;

		public X509Extensions Extensions => null;

		public static TbsCertificateList GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static TbsCertificateList GetInstance(object obj)
		{
			return null;
		}

		internal TbsCertificateList(Asn1Sequence seq)
		{
		}

		public CrlEntry[] GetRevokedCertificates()
		{
			return null;
		}

		public IEnumerable GetRevokedCertificateEnumeration()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
