using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableUndoRedoValidator", fileName = "EnableUndoRedoValidator", order = 0)]
	public class EnableUndoRedoValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.CanUndoRedo;
			}
			return true;
		}
	}
}
