using UnityEngine;

namespace Data.FeatureFlags.Validators
{
	public abstract class FeatureFlagValidator : ScriptableObject
	{
		[SerializeField]
		protected FeatureFlags _featureFlags;

		public abstract bool IsEnabledFeatureFlag();
	}
}
