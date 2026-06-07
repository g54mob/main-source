using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableProgressionPageValidator", fileName = "EnableProgressionPageValidator", order = 0)]
	public class EnableProgressionPageValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.ProgressionPage;
			}
			return true;
		}
	}
}
