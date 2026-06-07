using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableHeatmapValidator", fileName = "EnableHeatmapValidator", order = 0)]
	public class EnableHeatmapValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.Heatmap;
			}
			return true;
		}
	}
}
