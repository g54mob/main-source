using System.Collections;
using System.Collections.Generic;
using BestHTTP.Logger;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public interface TlsClient : TlsPeer
	{
		LoggingContext LoggingContext { get; set; }

		List<string> HostNames { get; set; }

		bool ExpectEmptyCertificateStatusExtension { get; }

		CertificateStatus CertificateStatus { get; set; }

		ProtocolVersion ClientHelloRecordLayerVersion { get; }

		ProtocolVersion ClientVersion { get; }

		bool IsFallback { get; }

		void Init(TlsClientContext context);

		TlsSession GetSessionToResume();

		int[] GetCipherSuites();

		byte[] GetCompressionMethods();

		IDictionary GetClientExtensions();

		void NotifyServerVersion(ProtocolVersion selectedVersion);

		void NotifySessionID(byte[] sessionID);

		void NotifySelectedCipherSuite(int selectedCipherSuite);

		void NotifySelectedCompressionMethod(byte selectedCompressionMethod);

		void ProcessServerExtensions(IDictionary serverExtensions);

		void ProcessServerSupplementalData(IList serverSupplementalData);

		TlsKeyExchange GetKeyExchange();

		TlsAuthentication GetAuthentication();

		IList GetClientSupplementalData();

		void NotifyNewSessionTicket(NewSessionTicket newSessionTicket);
	}
}
