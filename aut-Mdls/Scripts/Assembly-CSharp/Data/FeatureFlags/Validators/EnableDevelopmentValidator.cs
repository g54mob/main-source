using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableDevelopmentValidator", fileName = "EnableDevelopmentValidator", order = 0)]
	public class EnableDevelopmentValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.IsDevelopment;
			}
			return true;
		}
	}
}
