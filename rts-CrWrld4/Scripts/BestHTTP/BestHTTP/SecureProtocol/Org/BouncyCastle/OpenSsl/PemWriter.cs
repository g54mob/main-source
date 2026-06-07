using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO.Pem;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.OpenSsl
{
	public class PemWriter : BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO.Pem.PemWriter
	{
		public PemWriter(TextWriter writer)
			: base(null)
		{
		}

		public void WriteObject(object obj)
		{
		}

		public void WriteObject(object obj, string algorithm, char[] password, SecureRandom random)
		{
		}
	}
}
