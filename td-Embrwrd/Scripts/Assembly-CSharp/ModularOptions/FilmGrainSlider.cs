using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/PostProcessing/Film Grain Slider")]
	public sealed class FilmGrainSlider : PostProcessingSlider<FilmGrain>
	{
		[Tooltip("Slider value is multiplied by this for final intensity value. Default 0.01 is for use with 0 to 100% slider.")]
		public float intensityFactor;

		protected override void ApplySetting(float _value)
		{
		}
	}
}
