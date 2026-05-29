using UnityEngine;
using UnityEngine.UI;

namespace CorgiGodRays
{
	public class DemoUI : MonoBehaviour
	{
		[Header("Renderer References")]
		public GodRaysRenderFeature feature;

		[Header("Settings References")]
		public Text frametime;

		public Dropdown VolumeTextureQuality;

		public Dropdown VolumeStepQuality;

		public Dropdown BilateralBlurSamples;

		public Toggle blurToggle;

		public Slider blurSlider;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OnDropdownVolumeTextureQuality(int index)
		{
		}

		public void OnDropdownVolumeStepQuality(int index)
		{
		}

		public void OnDropdownBilateralBlurSamples(int index)
		{
		}

		public void OnToggleblurToggle(bool enabled)
		{
		}

		public void OnBlurSlider(float value)
		{
		}
	}
}
