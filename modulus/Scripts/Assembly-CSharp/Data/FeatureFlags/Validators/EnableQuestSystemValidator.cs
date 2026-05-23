using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableQuestSystemValidator", fileName = "EnableQuestSystemValidator", order = 0)]
	public class EnableQuestSystemValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			_ = _featureFlags != null;
			return true;
		}
	}
}
