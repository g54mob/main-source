using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableSandboxMapValidator", fileName = "EnableSandboxMapValidator", order = 0)]
	public class EnableSandboxMapValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			_ = _featureFlags != null;
			return true;
		}
	}
}
