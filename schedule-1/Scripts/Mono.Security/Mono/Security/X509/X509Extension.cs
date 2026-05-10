using System.Text;

namespace Mono.Security.X509
{
	public class X509Extension
	{
		protected string extnOid;

		protected bool extnCritical;

		protected ASN1 extnValue;

		public string Oid => null;

		public bool Critical => false;

		public ASN1 Value => null;

		public X509Extension(ASN1 asn1)
		{
		}

		public X509Extension(X509Extension extension)
		{
		}

		protected virtual void Decode()
		{
		}

		protected virtual void Encode()
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private void WriteLine(StringBuilder sb, int n, int pos)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
