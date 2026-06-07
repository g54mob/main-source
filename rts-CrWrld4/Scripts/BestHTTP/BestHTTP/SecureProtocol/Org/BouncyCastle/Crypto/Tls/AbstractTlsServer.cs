using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AbstractTlsServer : AbstractTlsPeer, TlsServer, TlsPeer
	{
		protected TlsCipherFactory mCipherFactory;

		protected TlsServerContext mContext;

		protected ProtocolVersion mClientVersion;

		protected int[] mOfferedCipherSuites;

		protected byte[] mOfferedCompressionMethods;

		protected IDictionary mClientExtensions;

		protected bool mEncryptThenMacOffered;

		protected short mMaxFragmentLengthOffered;

		protected bool mTruncatedHMacOffered;

		protected IList mSupportedSignatureAlgorithms;

		protected bool mEccCipherSuitesOffered;

		protected int[] mNamedCurves;

		protected byte[] mClientECPointFormats;

		protected byte[] mServerECPointFormats;

		protected ProtocolVersion mServerVersion;

		protected int mSelectedCipherSuite;

		protected byte mSelectedCompressionMethod;

		protected IDictionary mServerExtensions;

		protected virtual bool AllowEncryptThenMac => false;

		protected virtual bool AllowTruncatedHMac => false;

		protected virtual ProtocolVersion MaximumVersion => null;

		protected virtual ProtocolVersion MinimumVersion => null;

		public AbstractTlsServer()
		{
		}

		public AbstractTlsServer(TlsCipherFactory cipherFactory)
		{
		}

		protected virtual IDictionary CheckServerExtensions()
		{
			return null;
		}

		protected abstract int[] GetCipherSuites();

		protected byte[] GetCompressionMethods()
		{
			return null;
		}

		protected virtual bool SupportsClientEccCapabilities(int[] namedCurves, byte[] ecPointFormats)
		{
			return false;
		}

		public virtual void Init(TlsServerContext context)
		{
		}

		public virtual void NotifyClientVersion(ProtocolVersion clientVersion)
		{
		}

		public virtual void NotifyFallback(bool isFallback)
		{
		}

		public virtual void NotifyOfferedCipherSuites(int[] offeredCipherSuites)
		{
		}

		public virtual void NotifyOfferedCompressionMethods(byte[] offeredCompressionMethods)
		{
		}

		public virtual void ProcessClientExtensions(IDictionary clientExtensions)
		{
		}

		public virtual ProtocolVersion GetServerVersion()
		{
			return null;
		}

		public virtual int GetSelectedCipherSuite()
		{
			return 0;
		}

		public virtual byte GetSelectedCompressionMethod()
		{
			return 0;
		}

		public virtual IDictionary GetServerExtensions()
		{
			return null;
		}

		public virtual IList GetServerSupplementalData()
		{
			return null;
		}

		public abstract TlsCredentials GetCredentials();

		public virtual CertificateStatus GetCertificateStatus()
		{
			return null;
		}

		public abstract TlsKeyExchange GetKeyExchange();

		public virtual CertificateRequest GetCertificateRequest()
		{
			return null;
		}

		public virtual void ProcessClientSupplementalData(IList clientSupplementalData)
		{
		}

		public virtual void NotifyClientCertificate(Certificate clientCertificate)
		{
		}

		public override TlsCompression GetCompression()
		{
			return null;
		}

		public override TlsCipher GetCipher()
		{
			return null;
		}

		public virtual NewSessionTicket GetNewSessionTicket()
		{
			return null;
		}
	}
}
