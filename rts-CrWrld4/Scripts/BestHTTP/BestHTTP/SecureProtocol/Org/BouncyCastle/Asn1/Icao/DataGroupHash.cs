namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Icao
{
	public class DataGroupHash : Asn1Encodable
	{
		private readonly DerInteger dataGroupNumber;

		private readonly Asn1OctetString dataGroupHashValue;

		public int DataGroupNumber => 0;

		public Asn1OctetString DataGroupHashValue => null;

		public static DataGroupHash GetInstance(object obj)
		{
			return null;
		}

		private DataGroupHash(Asn1Sequence seq)
		{
		}

		public DataGroupHash(int dataGroupNumber, Asn1OctetString dataGroupHashValue)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
