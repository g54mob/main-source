using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class Asn1Generator
	{
		private Stream _out;

		protected Stream Out => null;

		protected Asn1Generator(Stream outStream)
		{
		}

		public abstract void AddObject(Asn1Encodable obj);

		public abstract Stream GetRawOutputStream();

		public abstract void Close();
	}
}
