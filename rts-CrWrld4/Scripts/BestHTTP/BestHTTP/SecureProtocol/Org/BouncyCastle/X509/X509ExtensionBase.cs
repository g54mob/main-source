using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public abstract class X509ExtensionBase : IX509Extension
	{
		protected abstract X509Extensions GetX509Extensions();

		protected virtual ISet GetExtensionOids(bool critical)
		{
			return null;
		}

		public virtual ISet GetNonCriticalExtensionOids()
		{
			return null;
		}

		public virtual ISet GetCriticalExtensionOids()
		{
			return null;
		}

		public Asn1OctetString GetExtensionValue(string oid)
		{
			return null;
		}

		public virtual Asn1OctetString GetExtensionValue(DerObjectIdentifier oid)
		{
			return null;
		}
	}
}
