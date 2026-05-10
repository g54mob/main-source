namespace Mono.Security.X509.Extensions
{
	public class BasicConstraintsExtension : X509Extension
	{
		private bool cA;

		private int pathLenConstraint;

		public bool CertificateAuthority => false;

		public BasicConstraintsExtension(X509Extension extension)
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
