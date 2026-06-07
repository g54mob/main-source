namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Icao
{
	public class LdsVersionInfo : Asn1Encodable
	{
		private DerPrintableString ldsVersion;

		private DerPrintableString unicodeVersion;

		public LdsVersionInfo(string ldsVersion, string unicodeVersion)
		{
		}

		private LdsVersionInfo(Asn1Sequence seq)
		{
		}

		public static LdsVersionInfo GetInstance(object obj)
		{
			return null;
		}

		public virtual string GetLdsVersion()
		{
			return null;
		}

		public virtual string GetUnicodeVersion()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
