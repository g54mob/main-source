using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class SubjectDirectoryAttributes : Asn1Encodable
	{
		private readonly IList attributes;

		public IEnumerable Attributes => null;

		public static SubjectDirectoryAttributes GetInstance(object obj)
		{
			return null;
		}

		private SubjectDirectoryAttributes(Asn1Sequence seq)
		{
		}

		[Obsolete]
		public SubjectDirectoryAttributes(ArrayList attributes)
		{
		}

		public SubjectDirectoryAttributes(IList attributes)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
