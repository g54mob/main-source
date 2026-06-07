using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableDayNightCycleValidator", fileName = "EnableDayNightCycleValidator", order = 0)]
	public class EnableDayNightCycleValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.DayNightCycle;
			}
			return true;
		}
	}
}
