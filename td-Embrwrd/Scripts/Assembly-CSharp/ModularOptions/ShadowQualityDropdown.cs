using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Builtin Render Pipeline/Shadow Quality Dropdown")]
	public sealed class ShadowQualityDropdown : DropdownOption
	{
		public enum ShadowCascades
		{
			None = 1,
			Two = 2,
			Four = 4
		}

		[Tooltip("Setting for the corresponding dropdown index plus 1, index 0 is 'Off'.")]
		public ShadowResolution[] shadowResolutionOptions;

		[Tooltip("Setting for the corresponding dropdown index plus 1, index 0 is 'Off'.")]
		public float[] shadowDistanceOptions;

		[Tooltip("Setting for the corresponding dropdown index plus 1, index 0 is 'Off'.")]
		public ShadowCascades[] shadowCascadeOptions;

		protected override void ApplySetting(int _value)
		{
		}
	}
}
