using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO
{
	public class MemoryInputStream : MemoryStream
	{
		public sealed override bool CanWrite => false;

		public MemoryInputStream(byte[] buffer)
		{
		}
	}
}
