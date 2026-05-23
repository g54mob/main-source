using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableWindParticlesValidator", fileName = "EnableWindParticlesValidator", order = 0)]
	public class EnableWindParticlesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.WindParticles;
			}
			return true;
		}
	}
}
