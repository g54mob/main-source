using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableCreativeModeValidator", fileName = "EnableCreativeModeValidator", order = 0)]
	public class EnableCreativeModeValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.CreativeMode;
			}
			return true;
		}
	}
}
