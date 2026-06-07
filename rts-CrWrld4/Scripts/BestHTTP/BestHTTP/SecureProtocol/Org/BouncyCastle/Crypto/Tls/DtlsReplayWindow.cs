namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal class DtlsReplayWindow
	{
		private const long VALID_SEQ_MASK = 281474976710655L;

		private const long WINDOW_SIZE = 64L;

		private long mLatestConfirmedSeq;

		private long mBitmap;

		internal bool ShouldDiscard(long seq)
		{
			return false;
		}

		internal void ReportAuthenticated(long seq)
		{
		}

		internal void Reset()
		{
		}
	}
}
