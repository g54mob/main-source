using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Tsp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public class TimeStampTokenInfo
	{
		private TstInfo tstInfo;

		private DateTime genTime;

		public bool IsOrdered => false;

		public Accuracy Accuracy => null;

		public DateTime GenTime => default(DateTime);

		public GenTimeAccuracy GenTimeAccuracy => null;

		public string Policy => null;

		public BigInteger SerialNumber => null;

		public GeneralName Tsa => null;

		public BigInteger Nonce => null;

		public AlgorithmIdentifier HashAlgorithm => null;

		public string MessageImprintAlgOid => null;

		public TstInfo TstInfo => null;

		public TimeStampTokenInfo(TstInfo tstInfo)
		{
		}

		public byte[] GetMessageImprintDigest()
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}
	}
}
