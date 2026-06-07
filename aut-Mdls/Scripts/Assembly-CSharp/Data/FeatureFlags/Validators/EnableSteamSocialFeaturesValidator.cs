using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableSteamSocialFeaturesValidator", fileName = "EnableSteamSocialFeaturesValidator", order = 0)]
	public class EnableSteamSocialFeaturesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.SteamSocialFeatures;
			}
			return true;
		}
	}
}
