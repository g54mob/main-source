using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal class DtlsRecordLayer : DatagramTransport, TlsCloseable
	{
		private const int RECORD_HEADER_LENGTH = 13;

		private const int MAX_FRAGMENT_LENGTH = 16384;

		private const long TCP_MSL = 120000L;

		private const long RETRANSMIT_TIMEOUT = 240000L;

		private readonly DatagramTransport mTransport;

		private readonly TlsContext mContext;

		private readonly TlsPeer mPeer;

		private readonly ByteQueue mRecordQueue;

		private bool mClosed;

		private bool mFailed;

		private ProtocolVersion mReadVersion;

		private ProtocolVersion mWriteVersion;

		private bool mInHandshake;

		private int mPlaintextLimit;

		private DtlsEpoch mCurrentEpoch;

		private DtlsEpoch mPendingEpoch;

		private DtlsEpoch mReadEpoch;

		private DtlsEpoch mWriteEpoch;

		private DtlsHandshakeRetransmit mRetransmit;

		private DtlsEpoch mRetransmitEpoch;

		private long mRetransmitExpiry;

		internal bool IsClosed => false;

		internal virtual int ReadEpoch => 0;

		internal virtual ProtocolVersion ReadVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal DtlsRecordLayer(DatagramTransport transport, TlsContext context, TlsPeer peer, byte contentType)
		{
		}

		internal virtual void SetPlaintextLimit(int plaintextLimit)
		{
		}

		internal virtual void SetWriteVersion(ProtocolVersion writeVersion)
		{
		}

		internal virtual void InitPendingEpoch(TlsCipher pendingCipher)
		{
		}

		internal virtual void HandshakeSuccessful(DtlsHandshakeRetransmit retransmit)
		{
		}

		internal virtual void ResetWriteEpoch()
		{
		}

		public virtual int GetReceiveLimit()
		{
			return 0;
		}

		public virtual int GetSendLimit()
		{
			return 0;
		}

		public virtual int Receive(byte[] buf, int off, int len, int waitMillis)
		{
			return 0;
		}

		public virtual void Send(byte[] buf, int off, int len)
		{
		}

		public virtual void Close()
		{
		}

		internal virtual void Failed()
		{
		}

		internal virtual void Fail(byte alertDescription)
		{
		}

		internal virtual void Warn(byte alertDescription, string message)
		{
		}

		private void CloseTransport()
		{
		}

		private void RaiseAlert(byte alertLevel, byte alertDescription, string message, Exception cause)
		{
		}

		private int ReceiveRecord(byte[] buf, int off, int len, int waitMillis)
		{
			return 0;
		}

		private void SendRecord(byte contentType, byte[] buf, int off, int len)
		{
		}

		private static long GetMacSequenceNumber(int epoch, long sequence_number)
		{
			return 0L;
		}
	}
}
