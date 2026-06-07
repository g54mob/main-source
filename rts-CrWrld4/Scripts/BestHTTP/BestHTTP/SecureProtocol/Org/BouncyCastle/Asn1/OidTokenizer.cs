namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class OidTokenizer
	{
		private string oid;

		private int index;

		public bool HasMoreTokens => false;

		public OidTokenizer(string oid)
		{
		}

		public string NextToken()
		{
			return null;
		}
	}
}
