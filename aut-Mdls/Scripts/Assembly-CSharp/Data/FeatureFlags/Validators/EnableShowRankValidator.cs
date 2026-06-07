using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableShowRankValidator", fileName = "EnableShowRankValidator", order = 0)]
	public class EnableShowRankValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.ShowRank;
			}
			return true;
		}
	}
}
