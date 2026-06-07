using System.Collections.Generic;
using DV.Utils;
using UnityEngine;
using VLB;

namespace DV.VFX
{
	public class ItemLightOptimizer : SingletonBehaviour<ItemLightOptimizer>
	{
		private const float SHADOW_DISTANCE_SQR = 225f;

		private const float HERO_DISTANCE_SQR = 25f;

		private const float FADE_DURATION = 0.2f;

		private const float LIGHT_CHECK_RATE = 1f;

		private HashSet<ItemLight> activeLights = new HashSet<ItemLight>();

		private HashSet<ItemLight> updatingLights = new HashSet<ItemLight>();

		private ItemLight heroLight;

		private float timer;

		public new static string AllowAutoCreate()
		{
			return "[ItemLightOptimizer]";
		}

		protected override void Awake()
		{
			base.Awake();
			GamePreferences.RegisterToPreferenceUpdated(Preferences.ShadowsQualityIndex, OnShadowQualityChanged);
			OnShadowQualityChanged();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.ShadowsQualityIndex, OnShadowQualityChanged);
		}

		private void OnShadowQualityChanged()
		{
			bool flag = GamePreferences.Get<int>(Preferences.ShadowsQualityIndex) >= SingletonBehaviour<GraphicsOptions>.Instance.ShadowsQuality_LOC.Length - 1;
			base.enabled = flag;
		}

		private void Update()
		{
			if (!PlayerManager.ActiveCamera)
			{
				return;
			}
			timer += Time.unscaledDeltaTime;
			if (timer > 1f)
			{
				timer = 0f;
				if ((bool)heroLight)
				{
					CheckHeroLightStillValid();
				}
				else
				{
					SearchHeroLight();
				}
			}
			foreach (ItemLight updatingLight in updatingLights)
			{
				updatingLight.light.shadowStrength = Mathf.MoveTowards(updatingLight.light.shadowStrength, updatingLight.desiredShadowIntensity, Time.unscaledDeltaTime / 0.2f);
				updatingLight.light.shadows = ((updatingLight.light.shadowStrength != 0f) ? LightShadows.Soft : LightShadows.None);
			}
			updatingLights.RemoveWhere((ItemLight itemLight) => itemLight.light.shadowStrength.Approximately(itemLight.desiredShadowIntensity));
		}

		private void OnEnable()
		{
			SearchHeroLight();
		}

		private void OnDisable()
		{
			SetHeroLight(null);
			foreach (ItemLight updatingLight in updatingLights)
			{
				updatingLight.light.shadowStrength = 0f;
				updatingLight.light.shadows = LightShadows.None;
			}
			updatingLights.Clear();
		}

		private void CheckHeroLightStillValid()
		{
			if (!heroLight.light.isActiveAndEnabled)
			{
				SearchHeroLight();
				return;
			}
			Vector3 position = PlayerManager.ActiveCamera.transform.position;
			if (Vector3.SqrMagnitude(heroLight.transform.position - position) > 25f)
			{
				SearchHeroLight();
			}
		}

		private void SearchHeroLight()
		{
			ItemLight closest = GetClosest();
			if (closest != heroLight)
			{
				SetHeroLight(closest);
			}
		}

		private void SetHeroLight(ItemLight itemLight)
		{
			if ((bool)heroLight)
			{
				heroLight.desiredShadowIntensity = 0f;
				updatingLights.Add(heroLight);
			}
			heroLight = itemLight;
			if ((bool)heroLight)
			{
				heroLight.desiredShadowIntensity = 1f;
				updatingLights.Add(heroLight);
			}
		}

		private ItemLight GetClosest()
		{
			if (!PlayerManager.ActiveCamera)
			{
				return null;
			}
			Vector3 position = PlayerManager.ActiveCamera.transform.position;
			float num = 225f;
			ItemLight result = null;
			foreach (ItemLight activeLight in activeLights)
			{
				if (activeLight.light.enabled)
				{
					float num2 = Vector3.SqrMagnitude(activeLight.transform.position - position);
					if (num2 < num)
					{
						num = num2;
						result = activeLight;
					}
				}
			}
			return result;
		}

		public void AddLight(ItemLight light)
		{
			activeLights.Add(light);
		}

		public void RemoveLight(ItemLight light)
		{
			activeLights.Remove(light);
			updatingLights.Remove(light);
			light.light.shadowStrength = 0f;
			light.light.shadows = LightShadows.None;
		}
	}
}
