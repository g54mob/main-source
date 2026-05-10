using System.Collections.Generic;
using UnityEngine;

namespace PG
{
	public class CarSFX : VehicleSFX
	{
		[Header("CarSFX")]
		[SerializeField]
		private AudioSource EngineSourceRef;

		[SerializeField]
		private AudioClip StartEngineClip;

		[SerializeField]
		private AudioClip StopEngineClip;

		[SerializeField]
		private AudioClip LowEngineClip;

		[SerializeField]
		private AudioClip MediumEngineClip;

		[SerializeField]
		private AudioClip HighEngineClip;

		[SerializeField]
		private float MinEnginePitch;

		[SerializeField]
		private float MaxEnginePitch;

		[Header("Additional settings")]
		[SerializeField]
		private AudioSource TurboSource;

		[SerializeField]
		private AudioClip TurboBlowOffClip;

		[SerializeField]
		private float MaxBlowOffVolume;

		[SerializeField]
		private float MinTimeBetweenBlowOffSounds;

		[SerializeField]
		private float MaxTurboVolume;

		[SerializeField]
		private float MinTurboPith;

		[SerializeField]
		private float MaxTurboPith;

		[SerializeField]
		private AudioSource BoostSource;

		[SerializeField]
		private List<AudioClip> BackFireClips;

		[Header("Wind Sound")]
		[SerializeField]
		private AudioSource SpeedWindSource;

		[SerializeField]
		private float WindSoundStartSpeed;

		[SerializeField]
		private float WindSoundMaxSpeed;

		[SerializeField]
		private float WindSoundStartPitch;

		[SerializeField]
		private float WindSoundMaxPitch;

		private CarController Car;

		private float LastBlowOffTime;

		private float[] EngineSourcesRanges;

		private List<AudioSource> EngineSources;

		protected override void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void StartEngine(float startDellay)
		{
		}

		private void StopEngine()
		{
		}

		private void UpdateEngine()
		{
		}

		private void UpdateTurbo()
		{
		}

		private void UpdateBoost()
		{
		}

		private void UpdateWindEffect()
		{
		}

		private void OnBackFire()
		{
		}
	}
}
