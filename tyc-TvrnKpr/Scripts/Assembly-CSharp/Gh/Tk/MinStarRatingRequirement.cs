using System;

namespace Gh.Tk
{
	public class MinStarRatingRequirement : Requirement
	{
		private readonly string _starType;

		private readonly float _starRating;

		protected MinStarRatingRequirement()
		{
		}

		public MinStarRatingRequirement(string titleKey, string starType, float starRating)
		{
		}

		private void OnStarRatingChanged(object sender, EventArgs e)
		{
		}

		private void OnStarRatingInfoChanged(object sender, EventArgs e)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		protected override void AttachListeners()
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
