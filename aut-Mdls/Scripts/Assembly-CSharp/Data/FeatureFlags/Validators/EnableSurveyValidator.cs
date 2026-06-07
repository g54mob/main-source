using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableSurveyValidator", fileName = "EnableSurveyValidator", order = 0)]
	public class EnableSurveyValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.HasSurvey;
			}
			return true;
		}
	}
}
