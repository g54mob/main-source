using System;
using System.Collections;
using System.IO;
using BestHTTP.Logger;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsProtocol : TlsCloseable
	{
		internal class HandshakeMessage : MemoryStream
		{
			internal HandshakeMessage(byte handshakeType)
			{
			}

			internal HandshakeMessage(byte handshakeType, int length)
			{
			}

			internal void Write(byte[] data)
			{
			}

			internal void WriteToRecordStream(TlsProtocol protocol)
			{
			}
		}

		protected const short CS_START = 0;

		protected const short CS_CLIENT_HELLO = 1;

		protected const short CS_SERVER_HELLO = 2;

		protected const short CS_SERVER_SUPPLEMENTAL_DATA = 3;

		protected const short CS_SERVER_CERTIFICATE = 4;

		protected const short CS_CERTIFICATE_STATUS = 5;

		protected const short CS_SERVER_KEY_EXCHANGE = 6;

		protected const short CS_CERTIFICATE_REQUEST = 7;

		protected const short CS_SERVER_HELLO_DONE = 8;

		protected const short CS_CLIENT_SUPPLEMENTAL_DATA = 9;

		protected const short CS_CLIENT_CERTIFICATE = 10;

		protected const short CS_CLIENT_KEY_EXCHANGE = 11;

		protected const short CS_CERTIFICATE_VERIFY = 12;

		protected const short CS_CLIENT_FINISHED = 13;

		protected const short CS_SERVER_SESSION_TICKET = 14;

		protected const short CS_SERVER_FINISHED = 15;

		protected const short CS_END = 16;

		protected const short ADS_MODE_1_Nsub1 = 0;

		protected const short ADS_MODE_0_N = 1;

		protected const short ADS_MODE_0_N_FIRSTONLY = 2;

		private ByteQueue mApplicationDataQueue;

		private ByteQueue mAlertQueue;

		private ByteQueue mHandshakeQueue;

		internal RecordStream mRecordStream;

		protected SecureRandom mSecureRandom;

		private TlsStream mTlsStream;

		private bool mClosed;

		private bool mFailedWithError;

		private bool mAppDataReady;

		private bool mAppDataSplitEnabled;

		private int mAppDataSplitMode;

		private byte[] mExpectedVerifyData;

		protected TlsSession mTlsSession;

		protected SessionParameters mSessionParameters;

		protected SecurityParameters mSecurityParameters;

		protected Certificate mPeerCertificate;

		protected int[] mOfferedCipherSuites;

		protected byte[] mOfferedCompressionMethods;

		protected IDictionary mClientExtensions;

		protected IDictionary mServerExtensions;

		protected short mConnectionState;

		protected bool mResumedSession;

		protected bool mReceivedChangeCipherSpec;

		protected bool mSecureRenegotiation;

		protected bool mAllowCertificateStatus;

		protected bool mExpectSessionTicket;

		protected bool mBlocking;

		protected ByteQueueStream mInputBuffers;

		protected ByteQueueStream mOutputBuffer;

		protected LoggingContext LoggingContext;

		protected abstract TlsContext Context { get; }

		internal abstract AbstractTlsContext ContextAdmin { get; }

		protected abstract TlsPeer Peer { get; }

		public virtual Stream Stream => null;

		public virtual bool IsClosed => false;

		public TlsProtocol(Stream stream, SecureRandom secureRandom)
		{
		}

		public TlsProtocol(Stream input, Stream output, SecureRandom secureRandom)
		{
		}

		public TlsProtocol(SecureRandom secureRandom)
		{
		}

		protected virtual void HandleAlertMessage(byte alertLevel, byte alertDescription)
		{
		}

		protected virtual void HandleAlertWarningMessage(byte alertDescription)
		{
		}

		protected virtual void HandleChangeCipherSpecMessage()
		{
		}

		protected virtual void HandleClose(bool user_canceled)
		{
		}

		protected virtual void HandleException(byte alertDescription, string message, Exception cause)
		{
		}

		protected virtual void HandleFailure()
		{
		}

		protected abstract void HandleHandshakeMessage(byte type, MemoryStream buf);

		protected virtual void ApplyMaxFragmentLengthExtension()
		{
		}

		protected virtual void CheckReceivedChangeCipherSpec(bool expected)
		{
		}

		protected virtual void CleanupHandshake()
		{
		}

		protected virtual void BlockForHandshake()
		{
		}

		protected virtual void CompleteHandshake()
		{
		}

		protected internal void ProcessRecord(byte protocol, byte[] buf, int off, int len)
		{
		}

		private void ProcessHandshakeQueue(ByteQueue queue)
		{
		}

		private void ProcessApplicationDataQueue()
		{
		}

		private void ProcessAlertQueue()
		{
		}

		private void ProcessChangeCipherSpec(byte[] buf, int off, int len)
		{
		}

		protected internal virtual int ApplicationDataAvailable()
		{
			return 0;
		}

		protected internal virtual int ReadApplicationData(byte[] buf, int offset, int len)
		{
			return 0;
		}

		protected virtual void SafeCheckRecordHeader(byte[] recordHeader)
		{
		}

		protected virtual void SafeReadRecord()
		{
		}

		protected virtual void SafeWriteRecord(byte type, byte[] buf, int offset, int len)
		{
		}

		protected internal virtual void WriteData(byte[] buf, int offset, int len)
		{
		}

		protected virtual void SetAppDataSplitMode(int appDataSplitMode)
		{
		}

		protected virtual void WriteHandshakeMessage(byte[] buf, int off, int len)
		{
		}

		public virtual void CloseInput()
		{
		}

		public virtual void OfferInput(byte[] input)
		{
		}

		public virtual void OfferInput(byte[] input, int inputOff, int inputLen)
		{
		}

		public virtual int GetAvailableInputBytes()
		{
			return 0;
		}

		public virtual int ReadInput(byte[] buffer, int offset, int length)
		{
			return 0;
		}

		public virtual void OfferOutput(byte[] buffer, int offset, int length)
		{
		}

		public virtual int GetAvailableOutputBytes()
		{
			return 0;
		}

		public virtual int ReadOutput(byte[] buffer, int offset, int length)
		{
			return 0;
		}

		protected virtual void InvalidateSession()
		{
		}

		protected virtual void ProcessFinishedMessage(MemoryStream buf)
		{
		}

		protected virtual void RaiseAlertFatal(byte alertDescription, string message, Exception cause)
		{
		}

		protected virtual void RaiseAlertWarning(byte alertDescription, string message)
		{
		}

		protected virtual void SendCertificateMessage(Certificate certificate)
		{
		}

		protected virtual void SendChangeCipherSpecMessage()
		{
		}

		protected virtual void SendFinishedMessage()
		{
		}

		protected virtual void SendSupplementalDataMessage(IList supplementalData)
		{
		}

		protected virtual byte[] CreateVerifyData(bool isServer)
		{
			return null;
		}

		public virtual void Close()
		{
		}

		protected internal virtual void Flush()
		{
		}

		protected virtual short ProcessMaxFragmentLengthExtension(IDictionary clientExtensions, IDictionary serverExtensions, byte alertDescription)
		{
			return 0;
		}

		protected virtual void RefuseRenegotiation()
		{
		}

		protected internal static void AssertEmpty(MemoryStream buf)
		{
		}

		protected internal static byte[] CreateRandomBlock(bool useGmtUnixTime, IRandomGenerator randomGenerator)
		{
			return null;
		}

		protected internal static byte[] CreateRenegotiationInfo(byte[] renegotiated_connection)
		{
			return null;
		}

		protected internal static void EstablishMasterSecret(TlsContext context, TlsKeyExchange keyExchange)
		{
		}

		protected internal static byte[] GetCurrentPrfHash(TlsContext context, TlsHandshakeHash handshakeHash, byte[] sslSender)
		{
			return null;
		}

		protected internal static IDictionary ReadExtensions(MemoryStream input)
		{
			return null;
		}

		protected internal static IList ReadSupplementalDataMessage(MemoryStream input)
		{
			return null;
		}

		protected internal static void WriteExtensions(Stream output, IDictionary extensions)
		{
		}

		protected internal static void WriteSelectedExtensions(Stream output, IDictionary extensions, bool selectEmpty)
		{
		}

		protected internal static void WriteSupplementalData(Stream output, IList supplementalData)
		{
		}

		protected internal static int GetPrfAlgorithm(TlsContext context, int ciphersuite)
		{
			return 0;
		}
	}
}
