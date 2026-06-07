using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO
{
	public class TeeOutputStream : BaseOutputStream
	{
		private readonly Stream output;

		private readonly Stream tee;

		public TeeOutputStream(Stream output, Stream tee)
		{
		}

		public override void Close()
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte b)
		{
		}
	}
}
