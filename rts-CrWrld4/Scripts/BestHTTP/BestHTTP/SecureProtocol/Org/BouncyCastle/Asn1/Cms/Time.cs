using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class Time : Asn1Encodable, IAsn1Choice
	{
		private readonly Asn1Object time;

		public string TimeString => null;

		public DateTime Date => default(DateTime);

		public static Time GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public Time(Asn1Object time)
		{
		}

		public Time(DateTime date)
		{
		}

		public static Time GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
