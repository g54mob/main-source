using System;
using DV.Debugging;
using DV.Utils;
using DV.VFX;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.Rain
{
	public class RainParticles : MonoBehaviour
	{
		[Serializable]
		public struct System
		{
			public ParticleSystem system;

			public ParticleSystemRenderer renderer;

			public float distanceByVelocityOffset;

			public bool doVel;

			public float deadzoneDistance;

			public float brightnessMultiplierWhenTAA;

			[Range(0f, 4f)]
			public int minimumQualityIndex;

			[NonSerialized]
			public float emissionRate;

			[NonSerialized]
			public Vector3 initialLocalPos;

			[NonSerialized]
			public Quaternion initialLocalRot;

			[NonSerialized]
			public Shader originalShader;
		}

		private const int HQ_SHADER_INDEX = 3;

		private const int GLOBAL_EMISSIONS_INDEX = 3;

		private const float GLOBAL_EMISSIONS_LOW_MULT = 0.5f;

		private readonly int BRIGHTNESS_MULTIPLIER_ID = Shader.PropertyToID("_BrightnessMultiplier");

		public System[] particleSystems;

		public float distanceModifier = 1f;

		public float speedModifier = 1f;

		public Shader highQualityShader;

		public Shader lowQualityShader;

		private static readonly int sp_ColorMap = Shader.PropertyToID("_Particle_VolumeMap");

		private static readonly int sp_InvBoxTransform = Shader.PropertyToID("_Particle_InvBoxTransform");

		private static readonly int sp_BoxTransform = Shader.PropertyToID("_Particle_RainBoxTransform");

		private static readonly int sp_LightVolumeParams = Shader.PropertyToID("_Particle_LightVolumeParams");

		private CookeryLightVolumeRenderer lastVolume;

		private static Texture3D dummyVolume = null;

		private float globalEmissionMultiplier;

		private bool debugDisable;

		private void Start()
		{
			if (dummyVolume == null)
			{
				dummyVolume = new Texture3D(1, 1, 1, TextureFormat.RGB24, mipChain: false);
				dummyVolume.SetPixel(0, 0, 0, Color.black);
				dummyVolume.Apply();
			}
			if (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				Debug.LogError($"Missing {typeof(WeatherDriver)} instance!");
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			for (int i = 0; i < particleSystems.Length; i++)
			{
				System system = particleSystems[i];
				system.emissionRate = system.system.emission.rateOverTimeMultiplier;
				system.initialLocalPos = system.system.transform.localPosition;
				system.initialLocalRot = system.system.transform.localRotation;
				system.originalShader = system.system.GetComponent<Renderer>().sharedMaterial.shader;
				system.system.gameObject.AddComponent<WorldMoverParticleSimulationSpace>();
				particleSystems[i] = system;
			}
			SingletonBehaviour<WeatherDriver>.Instance.OnRainStart += OnRainStart;
			if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
			{
				SingletonBehaviour<EffectsTogglerDebug>.Instance.SubscribeChanged(EffectsTogglerDebug.EffectType.RainParticles, RainDebugChanged);
			}
			GamePreferences.RegisterToPreferenceUpdated(Preferences.RainQualityIndex, RainQualityChanged);
			GamePreferences.RegisterToPreferenceUpdated(Preferences.AntiAliasingDeferredLevelsIndex, RainQualityChanged);
			RainQualityChanged();
		}

		private void RainDebugChanged(bool on)
		{
			debugDisable = !on;
			RainQualityChanged();
		}

		private void RainQualityChanged()
		{
			int num = GamePreferences.Get<int>(Preferences.RainQualityIndex);
			if (debugDisable)
			{
				num = 0;
			}
			Shader shader = ((num >= 3) ? highQualityShader : lowQualityShader);
			bool flag = CameraGraphicsUpdater.DeferredAntiAliasingMode == GraphicsOptions.AntiAliasingDeferred.TAA;
			System[] array = particleSystems;
			for (int i = 0; i < array.Length; i++)
			{
				System system = array[i];
				system.system.gameObject.SetActive(system.minimumQualityIndex <= num);
				Renderer component = system.system.GetComponent<Renderer>();
				if (component.material.shader != shader)
				{
					component.material.shader = shader;
				}
				component.material.SetFloat(BRIGHTNESS_MULTIPLIER_ID, flag ? system.brightnessMultiplierWhenTAA : 1f);
			}
			globalEmissionMultiplier = ((num >= 3) ? 1f : 0.5f);
		}

		private void OnRainStart()
		{
			base.gameObject.SetActive(value: true);
		}

		private void OnDestroy()
		{
			System[] array = particleSystems;
			for (int i = 0; i < array.Length; i++)
			{
				System system = array[i];
				system.system.GetComponent<Renderer>().sharedMaterial.shader = system.originalShader;
			}
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RainQualityIndex, RainQualityChanged);
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.AntiAliasingDeferredLevelsIndex, RainQualityChanged);
			if ((bool)SingletonBehaviour<WeatherDriver>.Instance)
			{
				SingletonBehaviour<WeatherDriver>.Instance.OnRainStart -= OnRainStart;
			}
			if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
			{
				SingletonBehaviour<EffectsTogglerDebug>.Instance.UnsubscribeChanged(EffectsTogglerDebug.EffectType.RainParticles, RainDebugChanged);
			}
		}

		private void Update()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera || !SingletonBehaviour<WeatherDriver>.Instance)
			{
				return;
			}
			float num = SingletonBehaviour<WeatherDriver>.Instance.RainValue;
			bool flag = false;
			System[] array = particleSystems;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].system.isStopped)
				{
					flag = true;
				}
			}
			if (!flag && num == 0f)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			Vector3 vector = (PlayerManager.Car ? PlayerManager.Car.rb.velocity : Vector3.zero);
			vector.y = 0f;
			bool flag2 = Mathf.Approximately(Time.timeScale, 0f);
			for (int j = 0; j < particleSystems.Length; j++)
			{
				System system = particleSystems[j];
				if (system.system.gameObject.activeInHierarchy)
				{
					ParticleSystem.EmissionModule emission = system.system.emission;
					emission.rateOverTimeMultiplier = system.emissionRate * num * globalEmissionMultiplier;
					if (emission.rateOverTimeMultiplier == 0f && system.system.isEmitting && !flag2)
					{
						system.system.Stop();
					}
					else if (emission.rateOverTimeMultiplier != 0f && !system.system.isEmitting && !flag2)
					{
						system.system.Play();
					}
					if (system.doVel && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
					{
						ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = system.system.velocityOverLifetime;
						ParticleSystem.MinMaxCurve x = velocityOverLifetime.x;
						x.constantMin = vector.x * speedModifier;
						x.constantMax = vector.x * speedModifier;
						velocityOverLifetime.x = x;
						ParticleSystem.MinMaxCurve z = velocityOverLifetime.z;
						z.constantMin = vector.z * speedModifier;
						z.constantMax = vector.z * speedModifier;
						velocityOverLifetime.z = z;
					}
					Vector3 vector2 = system.initialLocalPos + activeCamera.transform.position + system.distanceByVelocityOffset * vector * distanceModifier;
					if (system.deadzoneDistance == 0f || Vector3.Distance(system.system.transform.position, vector2) > system.deadzoneDistance)
					{
						system.system.transform.position = vector2;
						system.system.transform.rotation = system.initialLocalRot;
					}
				}
			}
			if (lastVolume != CookeryVolumeTracker.CurrentVolume)
			{
				lastVolume = CookeryVolumeTracker.CurrentVolume;
				Texture value = ((lastVolume != null) ? lastVolume.lightMaterial.GetTexture("_ColorMap") : dummyVolume);
				Shader.SetGlobalTexture(sp_ColorMap, value);
			}
			Shader.SetGlobalMatrix(sp_InvBoxTransform, (lastVolume != null) ? lastVolume.InverseBoxTransform : Matrix4x4.identity);
			Shader.SetGlobalMatrix(sp_BoxTransform, (lastVolume != null) ? lastVolume.BoxRotationTransform : Matrix4x4.identity);
			Shader.SetGlobalVector(sp_LightVolumeParams, (lastVolume != null) ? lastVolume.LightVolumeParameters : Vector4.zero);
		}
	}
}
