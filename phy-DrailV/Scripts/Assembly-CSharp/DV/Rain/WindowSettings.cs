using DV.Utils;
using UnityEngine;

namespace DV.Rain
{
	public class WindowSettings : SingletonBehaviour<WindowSettings>
	{
		public ComputeShader computeShader;

		public Material copyStepMaterial;

		public Material highQualityWindowMaterial;

		public Material medQualityWindowMaterial;

		public Material lowQualityWindowMaterial;

		public Texture2D perlinTexture;

		public Texture2D noiseTexture;

		public Texture2D wiperNoiseTexture;

		public int pixelsPerMeter = 1024;

		public int maxDropletCountPerSquareMeter = 2048;

		public float minDropletSize = 0.015f;

		public float maxDropletSize = 0.019f;

		public float timeToFadeDropletMinRain = 0.1f;

		public float timeToFadeDropletMaxRain = 1f;

		public float timeToFadeMistMinRain = 60f;

		public float timeToFadeMistMaxRain = 10f;

		public float velocityMultiplierAtMaxRain = 1f;

		public float velocityMultiplierAtMinRain = 0.1f;

		public float respawnRateMinRain = 0.1f;

		public float respawnRateMaxRain = 1f;

		public float wiperEdgeMaxDistance = 0.001f;

		public Vector2Int maxWindowResolution = new Vector2Int(4096, 4096);

		public Vector2[] resolutionMultiplierLOD;

		public new static string AllowAutoCreate()
		{
			return null;
		}
	}
}
