using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableChallengesValidator", fileName = "EnableChallengesValidator", order = 0)]
	public class EnableChallengesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.Challenges;
			}
			return true;
		}
	}
}
