using DV.Damage;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.Cargo
{
	public class CargoReactionToDamage : MonoBehaviour
	{
		[Header("Model - optional")]
		public GameObject regularModel;

		public GameObject fullyDamagedModelPrefab;

		[Header("Audio - optional")]
		public AudioClip[] idleAudio;

		public float idleAudioPeriodMax = 120f;

		public float idleAudioPeriodMin = 5f;

		public AudioClip[] collisionAudio;

		public AudioClip[] fullyDamagedAudio;

		private TrainCar car;

		private bool isDestroyed;

		private GameObject fullyDamagedModel;

		private bool initialized;

		private float scheduledIdleAudioTime;

		private bool playerNotNear;

		private bool SkipIdleAudio
		{
			get
			{
				if (!playerNotNear)
				{
					if (SingletonBehaviour<WeatherDriver>.Instance != null)
					{
						if (SingletonBehaviour<WeatherDriver>.Instance.IsDay)
						{
							return SingletonBehaviour<WeatherDriver>.Instance.IsRaining;
						}
						return true;
					}
					return false;
				}
				return true;
			}
		}

		private void Start()
		{
			car = TrainCar.Resolve(base.transform);
			if (car == null || car.CargoDamage == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: Car not found on CargoReactionToDamage.");
				Object.Destroy(this);
				return;
			}
			OnCargoDamaged(0f);
			car.CargoDamage.CargoDamaged += OnCargoDamaged;
			car.CargoDamage.CargoSeverelyDamaged += OnCargoSeverelyDamaged;
			if (idleAudio != null && idleAudio.Length == 0)
			{
				idleAudio = null;
			}
			if (fullyDamagedAudio != null && fullyDamagedAudio.Length == 0)
			{
				fullyDamagedAudio = null;
			}
			if (collisionAudio != null && collisionAudio.Length == 0)
			{
				collisionAudio = null;
			}
			scheduledIdleAudioTime = GetScheduledIdleAudioTime();
			if (idleAudio != null)
			{
				SingletonBehaviour<CargoReactionToDamageChecker>.Instance.Register(this);
			}
			initialized = true;
		}

		private void OnDestroy()
		{
			if (!(car == null) && !(car.CargoDamage == null))
			{
				car.CargoDamage.CargoDamaged -= OnCargoDamaged;
				car.CargoDamage.CargoSeverelyDamaged -= OnCargoSeverelyDamaged;
				if (idleAudio != null)
				{
					SingletonBehaviour<CargoReactionToDamageChecker>.Instance.Unregister(this);
				}
			}
		}

		private void OnCargoSeverelyDamaged()
		{
			if (collisionAudio != null && !isDestroyed)
			{
				float pitch = Mathf.Lerp(0.9f, 1.1f, Random.value);
				collisionAudio.Play(car.transform.position, 1f, pitch, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}

		private void OnCargoDamaged(float _)
		{
			if (car.CargoDamage.currentDamageState != DamageState.Destroyed || isDestroyed)
			{
				return;
			}
			isDestroyed = true;
			if (regularModel != null)
			{
				regularModel.SetActive(value: false);
				if (fullyDamagedModelPrefab != null)
				{
					fullyDamagedModel = Object.Instantiate(fullyDamagedModelPrefab, regularModel.transform.parent);
				}
			}
			if (initialized && fullyDamagedAudio != null)
			{
				float pitch = Mathf.Lerp(0.9f, 1.1f, Random.value);
				fullyDamagedAudio.Play(car.transform.position, 1f, pitch, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}

		public void TickIdleAudio()
		{
			if (idleAudio == null || isDestroyed)
			{
				return;
			}
			if (scheduledIdleAudioTime < Time.time)
			{
				scheduledIdleAudioTime = GetScheduledIdleAudioTime();
				if (SkipIdleAudio)
				{
					playerNotNear = false;
					return;
				}
				float pitch = Mathf.Lerp(0.9f, 1.1f, Random.value);
				idleAudio.Play(car.transform.position, 1f, pitch, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			playerNotNear = false;
		}

		public void SetPlayerNotNear()
		{
			playerNotNear = true;
		}

		private float GetScheduledIdleAudioTime()
		{
			return Time.time + Random.Range(idleAudioPeriodMin, idleAudioPeriodMax);
		}
	}
}
