namespace Mono.Security.X509
{
	public class X509Stores
	{
		private string _storePath;

		private bool _newFormat;

		private X509Store _trusted;

		public X509Store TrustedRoot => null;

		internal X509Stores(string path, bool newFormat)
		{
		}

		public X509Store Open(string storeName, bool create)
		{
			return null;
		}
	}
}
