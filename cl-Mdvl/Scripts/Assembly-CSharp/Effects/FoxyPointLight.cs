using NSEipix.Base;
using UnityEngine;

namespace Effects
{
	[RequireComponent(typeof(Light))]
	public class FoxyPointLight : MonoBehaviour
	{
		public enum MaxRenderDistance
		{
			VeryShort = 50,
			Short = 70,
			Medium = 100,
			Far = 140,
			VeryFar = 250
		}

		[SerializeField]
		private MaxRenderDistance maxRenderDistance = MaxRenderDistance.Medium;

		public Light Light { get; private set; }

		public int MaxRenderDistanceSquared { get; private set; }

		private void Start()
		{
			Light = GetComponent<Light>();
			int num = (int)maxRenderDistance;
			MaxRenderDistanceSquared = num * num;
		}

		private void OnEnable()
		{
			if (MonoSingleton<FoxyPointLightManager>.IsInstantiated())
			{
				MonoSingleton<FoxyPointLightManager>.Instance.AddLight(this);
			}
		}

		private void OnDisable()
		{
			if (MonoSingleton<FoxyPointLightManager>.IsInstantiated())
			{
				MonoSingleton<FoxyPointLightManager>.Instance.RemoveLight(this);
			}
		}
	}
}
