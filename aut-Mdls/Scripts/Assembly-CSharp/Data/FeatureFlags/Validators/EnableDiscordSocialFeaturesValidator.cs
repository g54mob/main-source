using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableDiscordSocialFeaturesValidator", fileName = "EnableDiscordSocialFeaturesValidator", order = 0)]
	public class EnableDiscordSocialFeaturesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.DiscordSocialFeatures;
			}
			return true;
		}
	}
}
