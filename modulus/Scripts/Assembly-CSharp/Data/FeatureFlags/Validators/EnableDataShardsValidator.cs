using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableDataShardsValidator", fileName = "EnableDataShardsValidator", order = 0)]
	public class EnableDataShardsValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.UseDataShards;
			}
			return true;
		}
	}
}
