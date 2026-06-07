using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Smime
{
	public class SmimeCapabilities : Asn1Encodable
	{
		public static readonly DerObjectIdentifier PreferSignedData;

		public static readonly DerObjectIdentifier CannotDecryptAny;

		public static readonly DerObjectIdentifier SmimeCapabilitesVersions;

		public static readonly DerObjectIdentifier Aes256Cbc;

		public static readonly DerObjectIdentifier Aes192Cbc;

		public static readonly DerObjectIdentifier Aes128Cbc;

		public static readonly DerObjectIdentifier IdeaCbc;

		public static readonly DerObjectIdentifier Cast5Cbc;

		public static readonly DerObjectIdentifier DesCbc;

		public static readonly DerObjectIdentifier DesEde3Cbc;

		public static readonly DerObjectIdentifier RC2Cbc;

		private Asn1Sequence capabilities;

		public static SmimeCapabilities GetInstance(object obj)
		{
			return null;
		}

		public SmimeCapabilities(Asn1Sequence seq)
		{
		}

		public ArrayList GetCapabilities(DerObjectIdentifier capability)
		{
			return null;
		}

		public IList GetCapabilitiesForOid(DerObjectIdentifier capability)
		{
			return null;
		}

		private void DoGetCapabilitiesForOid(DerObjectIdentifier capability, IList list)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
