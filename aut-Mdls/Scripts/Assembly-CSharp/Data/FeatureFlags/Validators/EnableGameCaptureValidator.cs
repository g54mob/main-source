using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableGameCaptureValidator", fileName = "EnableGameCaptureValidator", order = 0)]
	public class EnableGameCaptureValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.GameCaptureShortcuts;
			}
			return true;
		}
	}
}
