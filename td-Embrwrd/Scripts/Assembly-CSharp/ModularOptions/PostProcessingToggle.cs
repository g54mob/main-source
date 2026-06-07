using UnityEngine;
using UnityEngine.Rendering;

namespace ModularOptions
{
	public abstract class PostProcessingToggle<T> : ToggleOption where T : VolumeComponent
	{
		[Tooltip("Reference to global baseline profile.")]
		public VolumeProfile postProcessingProfile;

		protected T setting;

		protected override void Awake()
		{
		}

		protected override void ApplySetting(bool _value)
		{
		}
	}
}
