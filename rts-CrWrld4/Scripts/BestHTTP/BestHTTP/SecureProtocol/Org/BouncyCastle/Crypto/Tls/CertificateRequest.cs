using System.Collections;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class CertificateRequest
	{
		protected readonly byte[] mCertificateTypes;

		protected readonly IList mSupportedSignatureAlgorithms;

		protected readonly IList mCertificateAuthorities;

		public virtual byte[] CertificateTypes => null;

		public virtual IList SupportedSignatureAlgorithms => null;

		public virtual IList CertificateAuthorities => null;

		public CertificateRequest(byte[] certificateTypes, IList supportedSignatureAlgorithms, IList certificateAuthorities)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static CertificateRequest Parse(TlsContext context, Stream input)
		{
			return null;
		}
	}
}
