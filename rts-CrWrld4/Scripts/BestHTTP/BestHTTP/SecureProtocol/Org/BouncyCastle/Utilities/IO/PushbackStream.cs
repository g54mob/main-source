using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO
{
	public class PushbackStream : FilterStream
	{
		private int buf;

		public PushbackStream(Stream s)
			: base(null)
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public virtual void Unread(int b)
		{
		}
	}
}
