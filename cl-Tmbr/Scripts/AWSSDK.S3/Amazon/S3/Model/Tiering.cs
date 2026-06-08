namespace Amazon.S3.Model
{
	public class Tiering
	{
		private int? days;

		private IntelligentTieringAccessTier accessTier;

		public int? Days
		{
			get
			{
				return days;
			}
			set
			{
				days = value;
			}
		}

		public IntelligentTieringAccessTier AccessTier
		{
			get
			{
				return accessTier;
			}
			set
			{
				accessTier = value;
			}
		}

		internal bool IsSetDays()
		{
			return days.HasValue;
		}

		internal bool IsSetAccessTier()
		{
			return accessTier != null;
		}
	}
}
