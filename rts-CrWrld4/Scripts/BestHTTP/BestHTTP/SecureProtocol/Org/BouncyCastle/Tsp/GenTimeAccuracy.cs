using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public class GenTimeAccuracy
	{
		private Accuracy accuracy;

		public int Seconds => 0;

		public int Millis => 0;

		public int Micros => 0;

		public GenTimeAccuracy(Accuracy accuracy)
		{
		}

		private int GetTimeComponent(DerInteger time)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
