using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO
{
	public class SignerSink : BaseOutputStream
	{
		private readonly ISigner mSigner;

		public virtual ISigner Signer => null;

		public SignerSink(ISigner signer)
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
