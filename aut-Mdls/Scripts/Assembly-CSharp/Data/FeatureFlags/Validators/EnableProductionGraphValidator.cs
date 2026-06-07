using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableProductionGraphValidator", fileName = "EnableProductionGraphValidator", order = 0)]
	public class EnableProductionGraphValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.ProductionGraph;
			}
			return true;
		}
	}
}
