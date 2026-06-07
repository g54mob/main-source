using System.IO;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal sealed class RecordStream
	{
		private class HandshakeHashUpdateStream : BaseOutputStream
		{
			private readonly RecordStream mOuter;

			public HandshakeHashUpdateStream(RecordStream mOuter)
			{
			}

			public override void Write(byte[] buf, int off, int len)
			{
			}
		}

		private class SequenceNumber
		{
			private long value;

			private bool exhausted;

			internal long NextValue(byte alertDescription)
			{
				return 0L;
			}
		}

		private const int DEFAULT_PLAINTEXT_LIMIT = 16384;

		internal const int TLS_HEADER_SIZE = 5;

		internal const int TLS_HEADER_TYPE_OFFSET = 0;

		internal const int TLS_HEADER_VERSION_OFFSET = 1;

		internal const int TLS_HEADER_LENGTH_OFFSET = 3;

		private TlsProtocol mHandler;

		private Stream mInput;

		private Stream mOutput;

		private TlsCompression mPendingCompression;

		private TlsCompression mReadCompression;

		private TlsCompression mWriteCompression;

		private TlsCipher mPendingCipher;

		private TlsCipher mReadCipher;

		private TlsCipher mWriteCipher;

		private SequenceNumber mReadSeqNo;

		private SequenceNumber mWriteSeqNo;

		private MemoryStream mBuffer;

		private TlsHandshakeHash mHandshakeHash;

		private readonly BaseOutputStream mHandshakeHashUpdater;

		private ProtocolVersion mReadVersion;

		private ProtocolVersion mWriteVersion;

		private bool mRestrictReadVersion;

		private int mPlaintextLimit;

		private int mCompressedLimit;

		private int mCiphertextLimit;

		internal ProtocolVersion ReadVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal TlsHandshakeHash HandshakeHash => null;

		internal Stream HandshakeHashUpdater => null;

		internal RecordStream(TlsProtocol handler, Stream input, Stream output)
		{
		}

		internal void Init(TlsContext context)
		{
		}

		internal int GetPlaintextLimit()
		{
			return 0;
		}

		internal void SetPlaintextLimit(int plaintextLimit)
		{
		}

		internal void SetWriteVersion(ProtocolVersion writeVersion)
		{
		}

		internal void SetRestrictReadVersion(bool enabled)
		{
		}

		internal void SetPendingConnectionState(TlsCompression tlsCompression, TlsCipher tlsCipher)
		{
		}

		internal void SentWriteCipherSpec()
		{
		}

		internal void ReceivedReadCipherSpec()
		{
		}

		internal void FinaliseHandshake()
		{
		}

		internal void CheckRecordHeader(byte[] recordHeader)
		{
		}

		internal bool ReadRecord()
		{
			return false;
		}

		internal BufferSegment DecodeAndVerify(byte type, Stream input, int len)
		{
			return default(BufferSegment);
		}

		internal void WriteRecord(byte type, byte[] plaintext, int plaintextOffset, int plaintextLength)
		{
		}

		internal void NotifyHelloComplete()
		{
		}

		internal TlsHandshakeHash PrepareToFinish()
		{
			return null;
		}

		internal void SafeClose()
		{
		}

		internal void Flush()
		{
		}

		private byte[] GetBufferContents()
		{
			return null;
		}

		private static void CheckType(byte type, byte alertDescription)
		{
		}

		private static void CheckLength(int length, int limit, byte alertDescription)
		{
		}
	}
}
