using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public abstract class X9IntegerConverter
	{
		public static int GetByteLength(ECFieldElement fe)
		{
			return 0;
		}

		public static int GetByteLength(ECCurve c)
		{
			return 0;
		}

		public static byte[] IntegerToBytes(BigInteger s, int qLength)
		{
			return null;
		}
	}
}
