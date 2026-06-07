namespace Gh.Tk
{
	public class StarRatingManagerManualMode : StarRatingManager
	{
		private float _manualStarRating;

		public float ManualStarRating
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected StarRatingManagerManualMode()
		{
		}

		public StarRatingManagerManualMode(string starType, string titleKey)
		{
		}

		protected override float ModifyNewStarRating(float starRating)
		{
			return 0f;
		}

		public (bool, float) ShouldUpgradeRating()
		{
			return default((bool, float));
		}
	}
}
