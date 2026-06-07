using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableBlueprintsValidator", fileName = "EnableBlueprintsValidator", order = 0)]
	public class EnableBlueprintsValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.Blueprints;
			}
			return true;
		}
	}
}
