using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	internal abstract class LimitedInputStream : BaseInputStream
	{
		protected readonly Stream _in;

		private int _limit;

		internal virtual int Limit => 0;

		internal LimitedInputStream(Stream inStream, int limit)
		{
		}

		protected virtual void SetParentEofDetect(bool on)
		{
		}
	}
}
