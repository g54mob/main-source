using System.Collections;

namespace Mono.Security.X509
{
	public class X509Store
	{
		private string _storePath;

		private X509CertificateCollection _certificates;

		private ArrayList _crls;

		private bool _crl;

		private bool _newFormat;

		public X509CertificateCollection Certificates => null;

		public ArrayList Crls => null;

		internal X509Store(string path, bool crl, bool newFormat)
		{
		}

		private byte[] Load(string filename)
		{
			return null;
		}

		private X509Certificate LoadCertificate(string filename)
		{
			return null;
		}

		private X509Crl LoadCrl(string filename)
		{
			return null;
		}

		private bool CheckStore(string path, bool throwException)
		{
			return false;
		}

		private X509CertificateCollection BuildCertificatesCollection(string storeName)
		{
			return null;
		}

		private ArrayList BuildCrlsCollection(string storeName)
		{
			return null;
		}
	}
}
