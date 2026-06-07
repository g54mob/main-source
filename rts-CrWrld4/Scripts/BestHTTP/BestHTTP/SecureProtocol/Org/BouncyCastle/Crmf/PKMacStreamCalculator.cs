using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	internal class PKMacStreamCalculator : IStreamCalculator
	{
		private readonly MacSink _stream;

		public Stream Stream => null;

		public PKMacStreamCalculator(IMac mac)
		{
		}

		public object GetResult()
		{
			return null;
		}
	}
}
