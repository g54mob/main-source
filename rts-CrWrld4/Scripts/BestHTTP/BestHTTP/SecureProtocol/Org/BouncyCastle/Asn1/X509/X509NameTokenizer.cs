using System.Text;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class X509NameTokenizer
	{
		private string value;

		private int index;

		private char separator;

		private StringBuilder buffer;

		public X509NameTokenizer(string oid)
		{
		}

		public X509NameTokenizer(string oid, char separator)
		{
		}

		public bool HasMoreTokens()
		{
			return false;
		}

		public string NextToken()
		{
			return null;
		}
	}
}
