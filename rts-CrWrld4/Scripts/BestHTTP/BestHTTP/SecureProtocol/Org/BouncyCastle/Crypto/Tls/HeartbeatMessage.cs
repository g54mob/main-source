using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class HeartbeatMessage
	{
		internal class PayloadBuffer : MemoryStream
		{
			internal byte[] ToTruncatedByteArray(int payloadLength)
			{
				return null;
			}
		}

		protected readonly byte mType;

		protected readonly byte[] mPayload;

		protected readonly int mPaddingLength;

		public HeartbeatMessage(byte type, byte[] payload, int paddingLength)
		{
		}

		public virtual void Encode(TlsContext context, Stream output)
		{
		}

		public static HeartbeatMessage Parse(Stream input)
		{
			return null;
		}
	}
}
