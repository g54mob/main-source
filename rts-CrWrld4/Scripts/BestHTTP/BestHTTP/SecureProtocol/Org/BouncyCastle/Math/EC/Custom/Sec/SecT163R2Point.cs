namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.Sec
{
	internal class SecT163R2Point : AbstractF2mPoint
	{
		public override ECFieldElement YCoord => null;

		protected internal override bool CompressionYTilde => false;

		public SecT163R2Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
			: base(null, null, null, withCompression: false)
		{
		}

		public SecT163R2Point(ECCurve curve, ECFieldElement x, ECFieldElement y, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		internal SecT163R2Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		protected override ECPoint Detach()
		{
			return null;
		}

		public override ECPoint Add(ECPoint b)
		{
			return null;
		}

		public override ECPoint Twice()
		{
			return null;
		}

		public override ECPoint TwicePlus(ECPoint b)
		{
			return null;
		}

		public override ECPoint Negate()
		{
			return null;
		}
	}
}
