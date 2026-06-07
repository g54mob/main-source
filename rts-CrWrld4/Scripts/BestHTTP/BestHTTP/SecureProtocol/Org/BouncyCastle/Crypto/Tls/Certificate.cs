using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class Certificate
	{
		public static readonly Certificate EmptyChain;

		protected readonly X509CertificateStructure[] mCertificateList;

		public virtual int Length => 0;

		public virtual bool IsEmpty => false;

		public Certificate(X509CertificateStructure[] certificateList)
		{
		}

		public virtual X509CertificateStructure[] GetCertificateList()
		{
			return null;
		}

		public virtual X509CertificateStructure GetCertificateAt(int index)
		{
			return null;
		}

		public virtual void Encode(Stream output)
		{
		}

		public static Certificate Parse(Stream input)
		{
			return null;
		}

		protected virtual X509CertificateStructure[] CloneCertificateList()
		{
			return null;
		}
	}
}
