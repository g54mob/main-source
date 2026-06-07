using System;
using System.Collections;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartDamageEffect : MonoBehaviour
	{
		[Serializable]
		public struct KeyframeData
		{
			public int Index;

			public float Time;

			public float Value;
		}

		[Serializable]
		public class ParticleSystemConfiguration
		{
			public int EmissionRate = 20;

			public float Lifetime = 1f;

			public KeyframeData[] TextureSheetKeyframeOverrides;
		}

		[SerializeField]
		private float _destroyDelay = 3f;

		[SerializeField]
		private bool _destroyUnderWater = true;

		[SerializeField]
		private float _distanceEmissionThreshold = 10f;

		private float _distanceEmissionThresholdSquared = 100f;

		[SerializeField]
		private float _duration = 60f;

		private float _elapsedTime;

		private FuelTankData _fuelTank;

		private Coroutine _lerpParticleSystemConfigsCoroutine;

		[SerializeField]
		private float _outOfFuelDestroyDelay = 10f;

		private float _outOfFuelTime;

		private ParticleSystem.EmissionModule _particleSystemEmissions;

		private ParticleSystem.MainModule _particleSystemMain;

		[SerializeField]
		private ParticleSystemConfiguration _particleSystemSettingsDistance;

		[SerializeField]
		private ParticleSystemConfiguration _particleSystemSettingsTime;

		[SerializeField]
		private bool _requiresFuel;

		[SerializeField]
		private AnimationCurve _textureSheetCurve;

		public AudioSource AudioSource { get; private set; }

		public float DestroyDelay
		{
			get
			{
				return _destroyDelay;
			}
			set
			{
				_destroyDelay = value;
			}
		}

		public bool Destroyed { get; private set; }

		public bool DestroyUnderWater
		{
			get
			{
				return _destroyUnderWater;
			}
			set
			{
				_destroyUnderWater = value;
			}
		}

		public float DistanceEmissionThreshold
		{
			get
			{
				return _distanceEmissionThreshold;
			}
			set
			{
				_distanceEmissionThreshold = value;
				_distanceEmissionThresholdSquared = value * value;
			}
		}

		public float Duration
		{
			get
			{
				return _duration;
			}
			set
			{
				_duration = value;
			}
		}

		public float OutOfFuelDestroyDelay
		{
			get
			{
				return _outOfFuelDestroyDelay;
			}
			set
			{
				_outOfFuelDestroyDelay = value;
			}
		}

		public ParticleSystem ParticleSystem { get; private set; }

		public PartScript PartScript { get; private set; }

		public bool RequiresFuel
		{
			get
			{
				return _requiresFuel;
			}
			set
			{
				_requiresFuel = value;
			}
		}

		public void DestroyEffect()
		{
			if (!Destroyed)
			{
				Destroyed = true;
				_particleSystemEmissions.enabled = false;
				if (AudioSource != null)
				{
					AudioSource.Stop();
				}
				UnityEngine.Object.Destroy(base.gameObject, _destroyDelay);
			}
		}

		public void Initialize(PartScript part, AudioFile audioFile)
		{
			PartScript = part;
			ParticleSystem = GetComponent<ParticleSystem>();
			_particleSystemMain = ParticleSystem.main;
			_particleSystemEmissions = ParticleSystem.emission;
			if (_requiresFuel)
			{
				FuelTankScript componentInChildren = part.GetComponentInChildren<FuelTankScript>();
				if (componentInChildren != null)
				{
					_fuelTank = componentInChildren.FuelTank;
				}
			}
			if (audioFile != null)
			{
				AudioSource = AudioManager.CreateAudioSource(audioFile, base.gameObject);
				AudioStore.SetupAudioSource(AudioSource, audioFile, audioFile.Resource);
				AudioSource.Play();
			}
			UpdateParticleSystemConfiguration(applyImmediately: true);
		}

		protected virtual void Update()
		{
			if (Destroyed)
			{
				return;
			}
			if (_destroyUnderWater)
			{
				float? floatingOriginSeaLevel = GameWorld.Instance.FloatingOriginSeaLevel;
				if (floatingOriginSeaLevel.HasValue && base.transform.position.y <= floatingOriginSeaLevel.Value)
				{
					DestroyEffect();
				}
			}
			if (_requiresFuel && ((_fuelTank != null) ? _fuelTank.Fuel : PartScript.Aircraft.Fuel) <= 0f)
			{
				_outOfFuelTime += Time.deltaTime;
				if (_outOfFuelTime >= _outOfFuelDestroyDelay)
				{
					DestroyEffect();
				}
			}
			_elapsedTime += Time.deltaTime;
			if (_elapsedTime >= Duration)
			{
				DestroyEffect();
			}
			if (!Destroyed && _particleSystemMain.simulationSpace == ParticleSystemSimulationSpace.World)
			{
				UpdateParticleSystemConfiguration(applyImmediately: false);
			}
		}

		private void ApplyParticleSystemConfiguration(bool isTimeBased, ParticleSystemConfiguration config, bool applyImmediately)
		{
			_particleSystemEmissions.rateOverTime = (isTimeBased ? config.EmissionRate : 0);
			_particleSystemEmissions.rateOverDistance = ((!isTimeBased) ? config.EmissionRate : 0);
			if (_lerpParticleSystemConfigsCoroutine != null)
			{
				StopCoroutine(_lerpParticleSystemConfigsCoroutine);
			}
			_lerpParticleSystemConfigsCoroutine = StartCoroutine(LerpParticleSystemConfigs(config, applyImmediately ? 0f : 2f));
		}

		private IEnumerator LerpParticleSystemConfigs(ParticleSystemConfiguration target, float duration)
		{
			ParticleSystem.TextureSheetAnimationModule animation = ParticleSystem.textureSheetAnimation;
			Keyframe[] tsaKeys = _textureSheetCurve.keys;
			float lifetime = _particleSystemMain.startLifetime.constantMax;
			if ((double)duration < 0.001)
			{
				duration = 0.001f;
			}
			float time = 0f;
			while (true)
			{
				yield return null;
				float t = time / duration;
				_particleSystemMain.startLifetime = Mathf.Lerp(lifetime, target.Lifetime, t);
				for (int i = 0; i < target.TextureSheetKeyframeOverrides.Length; i++)
				{
					KeyframeData keyframeData = target.TextureSheetKeyframeOverrides[i];
					Keyframe key = new Keyframe(Mathf.Lerp(tsaKeys[keyframeData.Index].time, keyframeData.Time, t), Mathf.Lerp(tsaKeys[keyframeData.Index].value, keyframeData.Value, t));
					_textureSheetCurve.MoveKey(keyframeData.Index, key);
				}
				animation.frameOverTime = new ParticleSystem.MinMaxCurve(1f, _textureSheetCurve);
				if (!(time >= duration))
				{
					time += Time.deltaTime;
					continue;
				}
				break;
			}
		}

		private void UpdateParticleSystemConfiguration(bool applyImmediately)
		{
			if (PartScript.Body.Velocity.sqrMagnitude > _distanceEmissionThresholdSquared)
			{
				if (_particleSystemEmissions.rateOverDistance.constantMax == 0f)
				{
					ApplyParticleSystemConfiguration(isTimeBased: false, _particleSystemSettingsDistance, applyImmediately);
				}
			}
			else if (_particleSystemEmissions.rateOverTime.constantMax == 0f)
			{
				ApplyParticleSystemConfiguration(isTimeBased: true, _particleSystemSettingsTime, applyImmediately);
			}
		}
	}
}
