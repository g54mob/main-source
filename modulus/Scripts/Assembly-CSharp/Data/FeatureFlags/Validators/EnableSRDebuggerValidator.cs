using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	[CreateAssetMenu(menuName = "FeatureFlags/Validators/EnableSRDebuggerValidator", fileName = "EnableSRDebuggerValidator", order = 0)]
	public class EnableSRDebuggerValidator : FeatureFlagValidator
	{
		public override bool IsEnabledFeatureFlag()
		{
			if (_featureFlags != null)
			{
				return _featureFlags.Current.SRDebugger;
			}
			return true;
		}
	}
}
