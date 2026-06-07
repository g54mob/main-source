using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class DtlsClientProtocol : DtlsProtocol
	{
		protected internal class ClientHandshakeState
		{
			internal TlsClient client;

			internal TlsClientContextImpl clientContext;

			internal TlsSession tlsSession;

			internal SessionParameters sessionParameters;

			internal SessionParameters.Builder sessionParametersBuilder;

			internal int[] offeredCipherSuites;

			internal IDictionary clientExtensions;

			internal IDictionary serverExtensions;

			internal byte[] selectedSessionID;

			internal bool resumedSession;

			internal bool secure_renegotiation;

			internal bool allowCertificateStatus;

			internal bool expectSessionTicket;

			internal TlsKeyExchange keyExchange;

			internal TlsAuthentication authentication;

			internal CertificateStatus certificateStatus;

			internal CertificateRequest certificateRequest;

			internal TlsCredentials clientCredentials;
		}

		public DtlsClientProtocol(SecureRandom secureRandom)
			: base(null)
		{
		}

		public virtual DtlsTransport Connect(TlsClient client, DatagramTransport transport)
		{
			return null;
		}

		internal virtual void AbortClientHandshake(ClientHandshakeState state, DtlsRecordLayer recordLayer, byte alertDescription)
		{
		}

		internal virtual DtlsTransport ClientHandshake(ClientHandshakeState state, DtlsRecordLayer recordLayer)
		{
			return null;
		}

		protected virtual byte[] GenerateCertificateVerify(ClientHandshakeState state, DigitallySigned certificateVerify)
		{
			return null;
		}

		protected virtual byte[] GenerateClientHello(ClientHandshakeState state, TlsClient client)
		{
			return null;
		}

		protected virtual byte[] GenerateClientKeyExchange(ClientHandshakeState state)
		{
			return null;
		}

		protected virtual void InvalidateSession(ClientHandshakeState state)
		{
		}

		protected virtual void ProcessCertificateRequest(ClientHandshakeState state, byte[] body)
		{
		}

		protected virtual void ProcessCertificateStatus(ClientHandshakeState state, byte[] body)
		{
		}

		protected virtual byte[] ProcessHelloVerifyRequest(ClientHandshakeState state, byte[] body)
		{
			return null;
		}

		protected virtual void ProcessNewSessionTicket(ClientHandshakeState state, byte[] body)
		{
		}

		protected virtual Certificate ProcessServerCertificate(ClientHandshakeState state, byte[] body)
		{
			return null;
		}

		protected virtual void ProcessServerHello(ClientHandshakeState state, byte[] body)
		{
		}

		protected virtual void ProcessServerKeyExchange(ClientHandshakeState state, byte[] body)
		{
		}

		protected virtual void ProcessServerSupplementalData(ClientHandshakeState state, byte[] body)
		{
		}

		protected virtual void ReportServerVersion(ClientHandshakeState state, ProtocolVersion server_version)
		{
		}

		protected static byte[] PatchClientHelloWithCookie(byte[] clientHelloBody, byte[] cookie)
		{
			return null;
		}
	}
}
