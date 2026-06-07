using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class DtlsServerProtocol : DtlsProtocol
	{
		protected internal class ServerHandshakeState
		{
			internal TlsServer server;

			internal TlsServerContextImpl serverContext;

			internal TlsSession tlsSession;

			internal SessionParameters sessionParameters;

			internal SessionParameters.Builder sessionParametersBuilder;

			internal int[] offeredCipherSuites;

			internal byte[] offeredCompressionMethods;

			internal IDictionary clientExtensions;

			internal IDictionary serverExtensions;

			internal bool resumedSession;

			internal bool secure_renegotiation;

			internal bool allowCertificateStatus;

			internal bool expectSessionTicket;

			internal TlsKeyExchange keyExchange;

			internal TlsCredentials serverCredentials;

			internal CertificateRequest certificateRequest;

			internal short clientCertificateType;

			internal Certificate clientCertificate;
		}

		protected bool mVerifyRequests;

		public virtual bool VerifyRequests
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public DtlsServerProtocol(SecureRandom secureRandom)
			: base(null)
		{
		}

		public virtual DtlsTransport Accept(TlsServer server, DatagramTransport transport)
		{
			return null;
		}

		internal virtual void AbortServerHandshake(ServerHandshakeState state, DtlsRecordLayer recordLayer, byte alertDescription)
		{
		}

		internal virtual DtlsTransport ServerHandshake(ServerHandshakeState state, DtlsRecordLayer recordLayer)
		{
			return null;
		}

		protected virtual void InvalidateSession(ServerHandshakeState state)
		{
		}

		protected virtual byte[] GenerateCertificateRequest(ServerHandshakeState state, CertificateRequest certificateRequest)
		{
			return null;
		}

		protected virtual byte[] GenerateCertificateStatus(ServerHandshakeState state, CertificateStatus certificateStatus)
		{
			return null;
		}

		protected virtual byte[] GenerateNewSessionTicket(ServerHandshakeState state, NewSessionTicket newSessionTicket)
		{
			return null;
		}

		protected virtual byte[] GenerateServerHello(ServerHandshakeState state)
		{
			return null;
		}

		protected virtual void NotifyClientCertificate(ServerHandshakeState state, Certificate clientCertificate)
		{
		}

		protected virtual void ProcessClientCertificate(ServerHandshakeState state, byte[] body)
		{
		}

		protected virtual void ProcessCertificateVerify(ServerHandshakeState state, byte[] body, TlsHandshakeHash prepareFinishHash)
		{
		}

		protected virtual void ProcessClientHello(ServerHandshakeState state, byte[] body)
		{
		}

		protected virtual void ProcessClientKeyExchange(ServerHandshakeState state, byte[] body)
		{
		}

		protected virtual void ProcessClientSupplementalData(ServerHandshakeState state, byte[] body)
		{
		}

		protected virtual bool ExpectCertificateVerifyMessage(ServerHandshakeState state)
		{
			return false;
		}
	}
}
