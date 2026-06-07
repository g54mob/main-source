using UnityEngine;

namespace DV
{
	public class MainMenuSkyboxEffect : MonoBehaviour
	{
		private static readonly int EXPOSURE = Shader.PropertyToID("_Exposure");

		[Range(0f, 10f)]
		public float minExposure = 1f;

		[Range(0f, 10f)]
		public float maxExposure = 1.1f;

		[Range(0f, 10f)]
		public float timeScale = 1f;

		private Material mat;

		private bool exposureWasChanged;

		private void Start()
		{
			mat = RenderSettings.skybox;
			if (!mat.HasProperty(EXPOSURE))
			{
				Debug.LogError("Skybox material does not have _Exposure property, destroying self");
				Object.Destroy(this);
			}
		}

		private void OnDisable()
		{
			if (exposureWasChanged)
			{
				mat.SetFloat(EXPOSURE, 1f);
				exposureWasChanged = false;
			}
		}

		private void Update()
		{
			float t = Mathf.PerlinNoise(Time.time * timeScale, 0f);
			float value = Mathf.Lerp(minExposure, maxExposure, t);
			mat.SetFloat(EXPOSURE, value);
			exposureWasChanged = true;
		}
	}
}
