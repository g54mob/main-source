using UnityEngine;
using UnityEngine.Rendering;

namespace ModularOptions
{
	public abstract class PostProcessingSlider<T> : SliderOption where T : VolumeComponent
	{
		[Tooltip("Reference to global baseline profile.")]
		public VolumeProfile postProcessingProfile;

		protected T setting;

		protected override void Awake()
		{
		}
	}
}
