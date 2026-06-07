namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Custom.GM
{
	internal class SM2P256V1Point : AbstractFpPoint
	{
		public SM2P256V1Point(ECCurve curve, ECFieldElement x, ECFieldElement y)
			: base(null, null, null, withCompression: false)
		{
		}

		public SM2P256V1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, bool withCompression)
			: base(null, null, null, withCompression: false)
		{
		}

		internal SM2P256V1Point(ECCurve curve, ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
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

		public override ECPoint ThreeTimes()
		{
			return null;
		}

		public override ECPoint Negate()
		{
			return null;
		}
	}
}
