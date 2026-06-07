using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableDemoFeaturesValidator", fileName = "EnableDemoFeaturesValidator", order = 0)]
	public class EnableDemoFeaturesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.DemoFeatures;
			}
			return true;
		}
	}
}
