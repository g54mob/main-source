namespace Mono.Security.X509.Extensions
{
	public class AuthorityKeyIdentifierExtension : X509Extension
	{
		private byte[] aki;

		public byte[] Identifier => null;

		public AuthorityKeyIdentifierExtension(X509Extension extension)
			: base((ASN1)null)
		{
		}

		protected override void Decode()
		{
		}

		protected override void Encode()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
