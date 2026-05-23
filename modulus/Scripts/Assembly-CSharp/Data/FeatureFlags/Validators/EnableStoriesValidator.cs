using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableStoriesValidator", fileName = "EnableStoriesValidator", order = 0)]
	public class EnableStoriesValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.UseStories;
			}
			return true;
		}
	}
}
