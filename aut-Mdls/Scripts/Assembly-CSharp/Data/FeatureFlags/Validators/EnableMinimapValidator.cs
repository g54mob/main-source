using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableMinimapValidator", fileName = "EnableMinimapValidator", order = 0)]
	public class EnableMinimapValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.Minimap;
			}
			return true;
		}
	}
}
