using UnityEngine;

namespace Restory.Gameplay
{
	public class LightTimeView : MonoBehaviour
	{
		[SerializeField]
		private Light light;

		[SerializeField]
		[Min(0f)]
		private float intensityModifier = 1f;

		public void Reset()
		{
			light = GetComponent<Light>();
		}

		public void Apply(float intensity, float temperatureK, Color color)
		{
			float b = intensity * intensityModifier;
			light.intensity = Mathf.Max(0f, b);
			light.colorTemperature = Mathf.Clamp(temperatureK, 1500f, 20000f);
			light.color = color;
		}

		public void SetIntensityModifier(float modifier)
		{
			intensityModifier = Mathf.Max(0f, modifier);
		}
	}
}
