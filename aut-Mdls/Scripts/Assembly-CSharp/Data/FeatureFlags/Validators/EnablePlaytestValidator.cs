using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnablePlaytestValidator", fileName = "EnablePlaytestValidator", order = 0)]
	public class EnablePlaytestValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.Playtest;
			}
			return true;
		}
	}
}
