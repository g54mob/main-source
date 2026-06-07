using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	public class OcspResp
	{
		private OcspResponse resp;

		public int Status => 0;

		public OcspResp(OcspResponse resp)
		{
		}

		public OcspResp(byte[] resp)
		{
		}

		public OcspResp(Stream inStr)
		{
		}

		private OcspResp(Asn1InputStream aIn)
		{
		}

		public object GetResponseObject()
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
