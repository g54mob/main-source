using UnityEngine;
using UnityEngine.Audio;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Audio/Volume Slider")]
	public sealed class VolumeSlider : SliderOption
	{
		[Tooltip("Mixer with exposed Volume parameter matching OptionName.")]
		public AudioMixer mixer;

		protected override void ApplySetting(float _value)
		{
		}

		public float ConvertToDecibel(float _value)
		{
			return 0f;
		}
	}
}
