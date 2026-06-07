using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class Time : Asn1Encodable, IAsn1Choice
	{
		private readonly Asn1Object time;

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

		public string GetTime()
		{
			return null;
		}

		public DateTime ToDateTime()
		{
			return default(DateTime);
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
