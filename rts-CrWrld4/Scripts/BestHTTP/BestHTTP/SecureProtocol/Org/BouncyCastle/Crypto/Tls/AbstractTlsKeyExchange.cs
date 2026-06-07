using System.Collections;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AbstractTlsKeyExchange : TlsKeyExchange
	{
		protected readonly int mKeyExchange;

		protected IList mSupportedSignatureAlgorithms;

		protected TlsContext mContext;

		public virtual bool RequiresServerKeyExchange => false;

		protected AbstractTlsKeyExchange(int keyExchange, IList supportedSignatureAlgorithms)
		{
		}

		protected virtual DigitallySigned ParseSignature(Stream input)
		{
			return null;
		}

		public virtual void Init(TlsContext context)
		{
		}

		public abstract void SkipServerCredentials();

		public virtual void ProcessServerCertificate(Certificate serverCertificate)
		{
		}

		public virtual void ProcessServerCredentials(TlsCredentials serverCredentials)
		{
		}

		public virtual byte[] GenerateServerKeyExchange()
		{
			return null;
		}

		public virtual void SkipServerKeyExchange()
		{
		}

		public virtual void ProcessServerKeyExchange(Stream input)
		{
		}

		public abstract void ValidateCertificateRequest(CertificateRequest certificateRequest);

		public virtual void SkipClientCredentials()
		{
		}

		public abstract void ProcessClientCredentials(TlsCredentials clientCredentials);

		public virtual void ProcessClientCertificate(Certificate clientCertificate)
		{
		}

		public abstract void GenerateClientKeyExchange(Stream output);

		public virtual void ProcessClientKeyExchange(Stream input)
		{
		}

		public abstract byte[] GeneratePremasterSecret();
	}
}
