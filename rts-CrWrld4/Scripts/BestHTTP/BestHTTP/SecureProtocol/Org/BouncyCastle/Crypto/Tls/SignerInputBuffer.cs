using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal class SignerInputBuffer : MemoryStream
	{
		private class SigStream : BaseOutputStream
		{
			private readonly ISigner s;

			internal SigStream(ISigner s)
			{
			}

			public override void WriteByte(byte b)
			{
			}

			public override void Write(byte[] buf, int off, int len)
			{
			}
		}

		internal void UpdateSigner(ISigner s)
		{
		}
	}
}
