using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO.Pem
{
	public class PemWriter
	{
		private const int LineLength = 64;

		private readonly TextWriter writer;

		private readonly int nlLength;

		private char[] buf;

		public TextWriter Writer => null;

		public PemWriter(TextWriter writer)
		{
		}

		public int GetOutputSize(PemObject obj)
		{
			return 0;
		}

		public void WriteObject(PemObjectGenerator objGen)
		{
		}

		private void WriteEncoded(byte[] bytes)
		{
		}

		private void WritePreEncapsulationBoundary(string type)
		{
		}

		private void WritePostEncapsulationBoundary(string type)
		{
		}
	}
}
