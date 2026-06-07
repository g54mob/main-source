using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class ExtendedKeyUsage : Asn1Encodable
	{
		internal readonly IDictionary usageTable;

		internal readonly Asn1Sequence seq;

		public int Count => 0;

		public static ExtendedKeyUsage GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static ExtendedKeyUsage GetInstance(object obj)
		{
			return null;
		}

		public static ExtendedKeyUsage FromExtensions(X509Extensions extensions)
		{
			return null;
		}

		private ExtendedKeyUsage(Asn1Sequence seq)
		{
		}

		public ExtendedKeyUsage(params KeyPurposeID[] usages)
		{
		}

		[Obsolete]
		public ExtendedKeyUsage(ArrayList usages)
		{
		}

		public ExtendedKeyUsage(IEnumerable usages)
		{
		}

		public bool HasKeyPurposeId(KeyPurposeID keyPurposeId)
		{
			return false;
		}

		public ArrayList GetUsages()
		{
			return null;
		}

		public IList GetAllUsages()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
