using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO
{
	public class DigestSink : BaseOutputStream
	{
		private readonly IDigest mDigest;

		public virtual IDigest Digest => null;

		public DigestSink(IDigest digest)
		{
		}

		public override void WriteByte(byte b)
		{
		}

		public override void Write(byte[] buf, int off, int len)
		{
		}
	}
}
