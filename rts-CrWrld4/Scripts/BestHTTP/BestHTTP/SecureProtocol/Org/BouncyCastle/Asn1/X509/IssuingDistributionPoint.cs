using System.Text;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class IssuingDistributionPoint : Asn1Encodable
	{
		private readonly DistributionPointName _distributionPoint;

		private readonly bool _onlyContainsUserCerts;

		private readonly bool _onlyContainsCACerts;

		private readonly ReasonFlags _onlySomeReasons;

		private readonly bool _indirectCRL;

		private readonly bool _onlyContainsAttributeCerts;

		private readonly Asn1Sequence seq;

		public bool OnlyContainsUserCerts => false;

		public bool OnlyContainsCACerts => false;

		public bool IsIndirectCrl => false;

		public bool OnlyContainsAttributeCerts => false;

		public DistributionPointName DistributionPoint => null;

		public ReasonFlags OnlySomeReasons => null;

		public static IssuingDistributionPoint GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static IssuingDistributionPoint GetInstance(object obj)
		{
			return null;
		}

		public IssuingDistributionPoint(DistributionPointName distributionPoint, bool onlyContainsUserCerts, bool onlyContainsCACerts, ReasonFlags onlySomeReasons, bool indirectCRL, bool onlyContainsAttributeCerts)
		{
		}

		private IssuingDistributionPoint(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		private void appendObject(StringBuilder buf, string sep, string name, string val)
		{
		}
	}
}
