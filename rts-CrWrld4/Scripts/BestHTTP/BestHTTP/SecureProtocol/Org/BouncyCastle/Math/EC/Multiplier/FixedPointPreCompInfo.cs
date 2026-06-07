namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public class FixedPointPreCompInfo : PreCompInfo
	{
		protected ECPoint m_offset;

		protected ECLookupTable m_lookupTable;

		protected int m_width;

		public virtual ECLookupTable LookupTable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual ECPoint Offset
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
	}
}
