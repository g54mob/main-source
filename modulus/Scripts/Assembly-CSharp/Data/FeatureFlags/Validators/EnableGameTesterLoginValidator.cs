using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableGameTesterLoginValidator", fileName = "EnableGameTesterLoginValidator", order = 0)]
	public class EnableGameTesterLoginValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.GameTesterLogin;
			}
			return true;
		}
	}
}
