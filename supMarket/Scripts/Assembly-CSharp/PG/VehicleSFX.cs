using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class VehicleSFX : MonoBehaviour
	{
		[Serializable]
		public struct ColissionEvent
		{
			public AudioClip AudioClip;

			public LayerMask CollisionMask;

			public float MinMagnitudeCollision;

			public float MaxMagnitudeCollision;
		}

		public class FrictionSoundData
		{
			public AudioSource Source;

			public float LastFrictionTime;
		}

		public enum GlassShardsType
		{
			None = 0,
			Easy = 1,
			Medium = 2,
			Hard = 3
		}

		[Serializable]
		public class GroundSound
		{
			public GroundType GroundType;

			public AudioClip IdleGroundClip;

			public AudioClip SlipGroundClip;

			public AudioSource Source { get; set; }

			public float Slip { get; set; }

			public int WheelsCount { get; set; }
		}

		[Header("VehicleSFX")]
		[Header("Suspension sounds")]
		[SerializeField]
		private float LowSuspensionForce;

		[SerializeField]
		private AudioClip LowSuspensionClip;

		[SerializeField]
		private float MediumSuspensionForce;

		[SerializeField]
		private AudioClip MediumSuspensionClip;

		[SerializeField]
		private float HighSuspensionForce;

		[SerializeField]
		private AudioClip HighSuspensionClip;

		[SerializeField]
		private float MinTimeBetweenSuspensionSounds;

		[Header("Ground effects")]
		[SerializeField]
		private AudioSource WheelsEffectSourceRef;

		[SerializeField]
		private List<GroundSound> GroundSounds;

		[Header("Collisions")]
		[SerializeField]
		private float MinTimeBetweenCollisions;

		[SerializeField]
		private float DefaultMagnitudeDivider;

		[SerializeField]
		private AudioClip DefaultCollisionClip;

		[SerializeField]
		private List<ColissionEvent> CollisionEvents;

		[Header("Frictions")]
		[SerializeField]
		private AudioSource FrictionEffectSourceRef;

		[SerializeField]
		private float PlayFrictionTime;

		[SerializeField]
		private AudioClip DefaultFrictionClip;

		[SerializeField]
		private List<ColissionEvent> FrictionEvents;

		[Header("Shards settings")]
		[SerializeField]
		private AudioClip EasyShardsClip;

		[SerializeField]
		private AudioClip MediumShardsClip;

		[SerializeField]
		private AudioClip HardShardsClip;

		[Header("Other settings")]
		public AudioSource OtherEffectsSource;

		private Dictionary<GroundType, GroundSound> WheelSounds;

		private Dictionary<AudioClip, FrictionSoundData> FrictionSounds;

		protected VehicleController Vehicle;

		private AudioClip CurrentFrictionClip;

		private float LastCollisionTime;

		private Dictionary<AudioClip, float> LastPlaySoundTime;

		private float EasyLastPlayTime;

		private float MediumLastPlayTime;

		private float HardLastPlayTime;

		protected event Action UpdateAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Start()
		{
		}

		public void AddStudioListiner()
		{
		}

		public void RemoveStudioListiner()
		{
		}

		protected virtual void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateWheels()
		{
		}

		private void UpdateFrictions()
		{
		}

		public void PlayCollisionStayAction(VehicleController vehicle, Collision collision)
		{
		}

		public void PlayCollisionSound(VehicleController vehicle, Collision collision)
		{
		}

		private void PlayFrictionSound(Collision collision, float magnitude)
		{
		}

		private AudioClip GetClipForCollision(int layer, float collisionMagnitude, out float magnitudeDivider)
		{
			magnitudeDivider = default(float);
			return null;
		}

		private AudioClip GetClipForFriction(int layer, float collisionMagnitude)
		{
			return null;
		}

		public void PlayGlassShards(GlassShardsType shardsType, Vector3 position)
		{
		}
	}
}
