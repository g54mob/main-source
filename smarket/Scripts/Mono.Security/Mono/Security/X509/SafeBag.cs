namespace Mono.Security.X509
{
	internal class SafeBag
	{
		private string _bagOID;

		private ASN1 _asn1;

		public string BagOID => null;

		public ASN1 ASN1 => null;

		public SafeBag(string bagOID, ASN1 asn1)
		{
		}
	}
}
