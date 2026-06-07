using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableKioskFeaturesValidator", fileName = "EnableKioskFeaturesValidator", order = 0)]
	public class EnableKioskFeaturesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.KioskFeatures;
			}
			return true;
		}
	}
}
