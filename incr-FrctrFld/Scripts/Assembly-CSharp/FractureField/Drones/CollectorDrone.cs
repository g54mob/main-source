using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Shared.Enums;
using Reactivity;
using UnityEngine;

namespace FractureField.Drones
{
	public class CollectorDrone : Drone
	{
		public const float BaseSiphonRate = 3f;

		public CFloat SiphonRate;

		public const float BaseSiphonRange = 2f;

		public CFloat SiphonRange;

		private Dictionary<CurrencyType, float> _siphonAccumulators;

		private float _timeSinceLastAward;

		private const float AwardInterval = 1f;

		private static readonly Dictionary<RockLayerType, float> _cachedLayerResourceValues;

		private static readonly Dictionary<RockLayerType, float> _cachedLayerPenetrationMultipliers;

		private static readonly Dictionary<RockLayerType, float> _cachedLayerDamageMultipliers;

		private static readonly Dictionary<RockLayerType, float> _cachedLayerMaxHealth;

		private static float _cachedFracture;

		private const float CacheRefreshInterval = 1f;

		private Vector2 _roamTarget;

		private float _timeAtRoamTarget;

		private const float MinRoamDuration = 2f;

		private const float MaxRoamDuration = 5f;

		private float _currentRoamDuration;

		private float _accumulatedTime;

		private static float _lastCacheAccumulationTime;

		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;

		public Vector2 MovementDirection { get; private set; }

		public override void Init()
		{
		}

		protected override Rock TryFindTarget()
		{
			return null;
		}

		protected override void CustomFixedTick()
		{
		}

		protected override void TryTickHitting()
		{
		}

		protected override void TryTickIdle()
		{
		}

		protected override void TryTickMovingToTarget()
		{
		}

		private void SiphonResources()
		{
		}

		private static void TryRefreshStaticCache()
		{
		}

		private static void RefreshStaticCache()
		{
		}

		private float CalculateDamageRatioFast(float health, RockLayerType layerType)
		{
			return 0f;
		}

		private static float GetCachedLayerResourceValue(RockLayerType layerType, float damageRatio)
		{
			return 0f;
		}

		private void AwardAccumulatedResources()
		{
		}

		private void HandleRoaming()
		{
		}

		private void PickNewRoamTarget()
		{
		}

		protected override float CalculateDroneDamage()
		{
			return 0f;
		}

		public override void PerformHit()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
