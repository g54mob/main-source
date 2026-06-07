using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableCraneLimitValidator", fileName = "EnableCraneLimitValidator", order = 0)]
	public class EnableCraneLimitValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.UseCraneLimits;
			}
			return true;
		}
	}
}
