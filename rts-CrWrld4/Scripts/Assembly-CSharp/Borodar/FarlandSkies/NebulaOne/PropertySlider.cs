using UnityEngine;
using UnityEngine.UI;

namespace Borodar.FarlandSkies.NebulaOne
{
	public class PropertySlider : MonoBehaviour
	{
		public enum Type
		{
			StarsBrightnessMin = 0,
			StarsBrightnessMax = 1,
			NebulaBackgroundAlpha = 2,
			NebulaBasementAlpha = 3,
			NebulaRipples1Alpha = 4,
			NebulaRipples2Alpha = 5,
			NebulaRotationX = 6,
			NebulaRotationY = 7,
			NebulaRotationZ = 8,
			NebulaThresholdLow = 9,
			NebulaThresholdHigh = 10,
			NebulaRipplesDistortionX = 11,
			NebulaRipplesDistortionY = 12,
			NebulaRipplesDistortionZ = 13,
			Exposure = 14
		}

		public Type SliderType;

		private Slider _slider;

		protected void Awake()
		{
		}

		protected void Start()
		{
		}

		public void OnValueChanged(float value)
		{
		}
	}
}
