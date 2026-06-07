using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableLevelEditorValidator", fileName = "EnableLevelEditorValidator", order = 0)]
	public class EnableLevelEditorValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.LevelEditor;
			}
			return true;
		}
	}
}
