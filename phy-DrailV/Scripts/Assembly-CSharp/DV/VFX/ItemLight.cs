using System;
using DV.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV.VFX
{
	public class ItemLight : MonoBehaviour
	{
		public Light light;

		[NonSerialized]
		public float desiredShadowIntensity;

		private void Awake()
		{
			if (light == null)
			{
				Debug.LogError("ItemLight needs light assigned!", base.gameObject);
				base.enabled = false;
			}
			else if ((bool)GetComponent<LightShadowQuality>())
			{
				Debug.LogError("ItemLight and LightShadowQuality are not compatible with each other! Remove one!");
				base.enabled = false;
			}
			else
			{
				light.shadows = LightShadows.Soft;
				light.shadowStrength = 0f;
				light.shadowResolution = LightShadowResolution.Medium;
			}
		}

		private void OnEnable()
		{
			SingletonBehaviour<ItemLightOptimizer>.Instance.AddLight(this);
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ItemLightOptimizer>.Instance.RemoveLight(this);
			}
		}
	}
}
