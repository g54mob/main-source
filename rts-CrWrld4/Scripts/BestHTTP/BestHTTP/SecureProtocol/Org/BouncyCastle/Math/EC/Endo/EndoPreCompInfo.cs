using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo
{
	public class EndoPreCompInfo : PreCompInfo
	{
		protected ECEndomorphism m_endomorphism;

		protected ECPoint m_mappedPoint;

		public virtual ECEndomorphism Endomorphism
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual ECPoint MappedPoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
