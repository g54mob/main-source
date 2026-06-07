using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableTechTreeValidator", fileName = "EnableTechTreeValidator", order = 0)]
	public class EnableTechTreeValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.TechTree;
			}
			return true;
		}
	}
}
