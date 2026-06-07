using UnityEngine;

namespace SCPE
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Light))]
	public class FogLightSource : MonoBehaviour
	{
		public Light sunLight;

		public static Vector3 sunDirection;

		public static Color color;

		public static float intensity;

		private void OnEnable()
		{
			sunDirection = -base.transform.forward;
			if (!sunLight)
			{
				sunLight = GetComponent<Light>();
				if ((bool)sunLight)
				{
					color = sunLight.color;
					intensity = sunLight.intensity;
				}
			}
		}

		private void OnDisable()
		{
			sunDirection = Vector3.zero;
			Fog.LightDirection = Vector3.zero;
		}

		private void Update()
		{
			sunDirection = -base.transform.forward;
			Fog.LightDirection = sunDirection;
			if ((bool)sunLight)
			{
				color = sunLight.color;
				intensity = sunLight.intensity;
			}
		}
	}
}
