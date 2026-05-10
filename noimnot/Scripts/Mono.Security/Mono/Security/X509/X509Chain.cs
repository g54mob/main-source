namespace Mono.Security.X509
{
	public class X509Chain
	{
		private X509CertificateCollection roots;

		private X509CertificateCollection certs;

		private X509Certificate _root;

		private X509CertificateCollection _chain;

		private X509ChainStatusFlags _status;

		public X509CertificateCollection TrustAnchors => null;

		public void LoadCertificates(X509CertificateCollection collection)
		{
		}

		public bool Build(X509Certificate leaf)
		{
			return false;
		}

		public void Reset()
		{
		}

		private bool IsValid(X509Certificate cert)
		{
			return false;
		}

		private X509Certificate FindCertificateParent(X509Certificate child)
		{
			return null;
		}

		private X509Certificate FindCertificateRoot(X509Certificate potentialRoot)
		{
			return null;
		}

		private bool IsTrusted(X509Certificate potentialTrusted)
		{
			return false;
		}

		private bool IsParent(X509Certificate child, X509Certificate parent)
		{
			return false;
		}
	}
}
