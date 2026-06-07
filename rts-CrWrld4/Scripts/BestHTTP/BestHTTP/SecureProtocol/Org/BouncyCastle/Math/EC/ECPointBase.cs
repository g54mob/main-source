namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC
{
	public abstract class ECPointBase : ECPoint
	{
		protected internal ECPointBase(ECCurve curve, ECFieldElement x, ECFieldElement y, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		protected internal ECPointBase(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		public override byte[] GetEncoded(bool compressed)
		{
			return null;
		}

		public override ECPoint Multiply(BigInteger k)
		{
			return null;
		}
	}
}
