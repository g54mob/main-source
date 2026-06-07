using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableFreightersValidator", fileName = "EnableFreightersValidator", order = 0)]
	public class EnableFreightersValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.Freighters;
			}
			return true;
		}
	}
}
