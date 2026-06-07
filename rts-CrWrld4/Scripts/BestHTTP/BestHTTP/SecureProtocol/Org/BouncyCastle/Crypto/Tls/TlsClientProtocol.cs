using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsClientProtocol : TlsProtocol
	{
		protected TlsClient mTlsClient;

		internal TlsClientContextImpl mTlsClientContext;

		protected byte[] mSelectedSessionID;

		protected TlsKeyExchange mKeyExchange;

		protected TlsAuthentication mAuthentication;

		protected CertificateRequest mCertificateRequest;

		protected override TlsContext Context => null;

		internal override AbstractTlsContext ContextAdmin => null;

		protected override TlsPeer Peer => null;

		public TlsClientProtocol(Stream stream, SecureRandom secureRandom)
			: base(null, null)
		{
		}

		public TlsClientProtocol(Stream input, Stream output, SecureRandom secureRandom)
			: base(null, null)
		{
		}

		public TlsClientProtocol(SecureRandom secureRandom)
			: base(null, null)
		{
		}

		public virtual void Connect(TlsClient tlsClient)
		{
		}

		protected override void CleanupHandshake()
		{
		}

		protected override void HandleHandshakeMessage(byte type, MemoryStream buf)
		{
		}

		protected virtual void HandleSupplementalData(IList serverSupplementalData)
		{
		}

		protected virtual void ReceiveNewSessionTicketMessage(MemoryStream buf)
		{
		}

		protected virtual void ReceiveServerHelloMessage(MemoryStream buf)
		{
		}

		protected virtual void SendCertificateVerifyMessage(DigitallySigned certificateVerify)
		{
		}

		protected virtual void SendClientHelloMessage()
		{
		}

		protected virtual void SendClientKeyExchangeMessage()
		{
		}
	}
}
