namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal class DtlsEpoch
	{
		private readonly DtlsReplayWindow mReplayWindow;

		private readonly int mEpoch;

		private readonly TlsCipher mCipher;

		private long mSequenceNumber;

		internal TlsCipher Cipher => null;

		internal int Epoch => 0;

		internal DtlsReplayWindow ReplayWindow => null;

		internal long SequenceNumber => 0L;

		internal DtlsEpoch(int epoch, TlsCipher cipher)
		{
		}

		internal long AllocateSequenceNumber()
		{
			return 0L;
		}
	}
}
