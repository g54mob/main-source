using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableTechTreeFiltersValidator", fileName = "EnableTechTreeFiltersValidator", order = 0)]
	public class EnableTechTreeFiltersValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.TechTreeFilters;
			}
			return true;
		}
	}
}
