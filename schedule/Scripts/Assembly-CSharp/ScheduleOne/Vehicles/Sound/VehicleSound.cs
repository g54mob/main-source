using ScheduleOne.Audio;
using UnityEngine;

namespace ScheduleOne.Vehicles.Sound
{
	public class VehicleSound : MonoBehaviour
	{
		public const float COLLISION_SOUND_COOLDOWN = 0.5f;

		public const float AUDIO_LERP_SPEED = 2f;

		public const float MinCollisionMomentum = 4000f;

		public const float MaxCollisionMomentum = 25000f;

		public const float MinCollisionVolume = 0.2f;

		public const float MaxCollisionVolume = 0.8f;

		public const float MinCollisionPitch = 0.6f;

		public const float MaxCollisionPitch = 1.1f;

		public float EngineVolumeMultiplier;

		public float EnginePitchMultiplier;

		[Header("References")]
		public AudioSourceController EngineStartSource;

		public AudioSourceController EngineIdleSource;

		public AudioSourceController EngineLoopSource;

		public AudioSourceController HandbrakeSource;

		public AudioSourceController ImpactSound;

		[Header("Engine Loop Settings")]
		public AnimationCurve EngineLoopPitchCurve;

		public AnimationCurve EngineLoopVolumeCurve;

		private float lastCollisionTime;

		private float lastCollisionMomentum;

		private Coroutine volumeRoutine;

		public LandVehicle Vehicle { get; private set; }

		protected virtual void Awake()
		{
		}

		private void EngineStart()
		{
		}

		private void HandbrakeApplied()
		{
		}

		private void StartUpdateVolume()
		{
		}

		private void UpdateIdle(bool engineRunning)
		{
		}

		private void UpdateEngineLoop(bool engineRunning, float normalizedspeed)
		{
		}

		private void OnCollision(Collision collision)
		{
		}
	}
}
