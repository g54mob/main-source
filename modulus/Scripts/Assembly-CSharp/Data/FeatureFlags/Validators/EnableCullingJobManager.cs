using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableCullingJobManager", fileName = "EnableCullingJobManager", order = 0)]
	public class EnableCullingJobManager : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.CullingJobManager;
			}
			return true;
		}
	}
}
