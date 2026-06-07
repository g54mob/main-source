using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO.Pem
{
	public class PemReader
	{
		private const string BeginString = "-----BEGIN ";

		private const string EndString = "-----END ";

		private readonly TextReader reader;

		public TextReader Reader => null;

		public PemReader(TextReader reader)
		{
		}

		public PemObject ReadPemObject()
		{
			return null;
		}

		private PemObject LoadObject(string type)
		{
			return null;
		}
	}
}
