using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class DamagingZonePrefab : GameMonoBehaviour
	{
		public enum SpawnType
		{
			TARGETED = 0,
			HORIZONTAL_FIXED = 1,
			HORIZONTAL_RANDOM = 2,
			VERTICAL_FIXED = 3,
			VERTICAL_RANDOM = 4,
			CROSSHATCH = 5
		}

		[HideInInspector]
		public float damage;

		[HideInInspector]
		public float duration;

		[HideInInspector]
		public float respawnCooldown;

		[FormerlySerializedAs("timeBeforeEnable")]
		[HideInInspector]
		public float timeBeforeActivation;

		[FormerlySerializedAs("activationDelay")]
		[HideInInspector]
		public float hitDelayMillis;

		[HideInInspector]
		public bool hasWarningMark;

		[HideInInspector]
		public float warningTime;

		[HideInInspector]
		public bool enableGroundVisuals;

		[HideInInspector]
		public bool isCircle;

		[HideInInspector]
		public float width;

		[HideInInspector]
		public float height;

		[HideInInspector]
		public float radius;

		[HideInInspector]
		public SpawnType spawnType;

		[FormerlySerializedAs("verticalSpawnCounts")]
		[FormerlySerializedAs("horizontalSpawnCount")]
		[HideInInspector]
		public int verticalSpawnCount;

		[FormerlySerializedAs("verticalSpawnCount")]
		[HideInInspector]
		public int horizontalSpawnCount;

		[HideInInspector]
		public bool follow;

		[HideInInspector]
		public float followSpeed;

		[HideInInspector]
		public bool lockX;

		[HideInInspector]
		public bool lockY;

		[HideInInspector]
		public bool isAnimated;

		[HideInInspector]
		public string frameLocation;

		[HideInInspector]
		public int framePadding;

		[HideInInspector]
		public float frameScale;

		[HideInInspector]
		public string frameName;

		[HideInInspector]
		public int startingFrameNumber;

		[HideInInspector]
		public int endingFrameNumber;

		[HideInInspector]
		public int fps;

		[HideInInspector]
		public float offsetX;

		[HideInInspector]
		public float offsetY;

		[HideInInspector]
		public bool usingParticles;

		[HideInInspector]
		public bool setSpeed;

		[HideInInspector]
		public bool setAngle;

		[HideInInspector]
		public bool setRotation;

		[HideInInspector]
		public bool setScale;

		[HideInInspector]
		public DamageZoneFlexible.ZoneAlignment alignment;

		[HideInInspector]
		public int particleQuantity;

		[HideInInspector]
		public float particleFrequency;

		[HideInInspector]
		public float particleLifespan;

		[HideInInspector]
		public float minParticleSpeed;

		[HideInInspector]
		public float maxParticleSpeed;

		[HideInInspector]
		public float minParticleAngle;

		[HideInInspector]
		public float maxParticleAngle;

		[HideInInspector]
		public float minParticleRotation;

		[HideInInspector]
		public float maxParticleRotation;

		[HideInInspector]
		public float minParticleScale;

		[HideInInspector]
		public float maxParticleScale;

		[HideInInspector]
		public bool doParticlesBounce;

		protected float _zoneWidth;

		protected float _zoneHeight;

		protected float _zoneRadius;

		private float2 _originLocation;

		private Unity.Mathematics.Random _random;

		protected Camera MainCamera => null;

		public void SpawnZone(uint seed, float2 originLocation)
		{
		}

		protected virtual void SpawnPattern()
		{
		}

		protected virtual void SpawnCrosshatchPattern()
		{
		}

		protected void SetupVisualElement(Vector3 pos, DamageZoneFlexible zone, DamageZoneFlexible.ZoneAlignment newAlignment)
		{
		}

		protected List<float2> GetSpawnLocations()
		{
			return null;
		}

		protected VampireSurvivors.Objects.Characters.CharacterController GetRandomCharacterController()
		{
			return null;
		}

		private float2 GetTargetedSpawnLocation()
		{
			return default(float2);
		}

		protected List<float2> GetVerticalFixedSpawnLocations()
		{
			return null;
		}

		private List<float2> GetVerticalRandomSpawnLocations(float zoneSizeAdjustment)
		{
			return null;
		}

		protected List<float2> GetHorizontalFixedSpawnLocations()
		{
			return null;
		}

		private List<float2> GetHorizontalRandomSpawnLocations(float zoneSizeAdjustment)
		{
			return null;
		}
	}
}
