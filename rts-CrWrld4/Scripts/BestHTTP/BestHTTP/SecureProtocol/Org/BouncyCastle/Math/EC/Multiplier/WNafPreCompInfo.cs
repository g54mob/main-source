namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public class WNafPreCompInfo : PreCompInfo
	{
		internal int m_promotionCountdown;

		protected int m_confWidth;

		protected ECPoint[] m_preComp;

		protected ECPoint[] m_preCompNeg;

		protected ECPoint m_twice;

		protected int m_width;

		internal int PromotionCountdown
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual bool IsPromoted => false;

		public virtual int ConfWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual ECPoint[] PreComp
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual ECPoint[] PreCompNeg
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual ECPoint Twice
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual int Width
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal int DecrementPromotionCountdown()
		{
			return 0;
		}
	}
}
