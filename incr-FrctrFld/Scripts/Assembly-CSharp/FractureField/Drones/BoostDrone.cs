using System.Collections.Generic;
using FractureField.Rocks;
using Reactivity;
using UnityEngine;

namespace FractureField.Drones
{
	public class BoostDrone : Drone
	{
		public const float BaseAuraRadius = 2.5f;

		public CFloat AuraRadius;

		public const float BaseAuraOfSpeed = 2f;

		public CFloat SpeedBuffMultiplier;

		public const float BaseEfficiencyBuffMultiplier = 3f;

		public CFloat EfficiencyBuffMultiplier;

		public const float BaseBuffDuration = 5f;

		public CFloat BuffDuration;

		private Vector2 _roamTarget;

		private float _timeSinceLastRoamTargetChange;

		private const float RoamTargetChangeInterval = 12f;

		private const float MinDistanceBeforeNewTarget = 0.5f;

		private int _droneIndex;

		private int _totalDroneCount;

		private static List<BoostDrone> _activeBoostDrones;

		private Dictionary<Drone, float> _lastBuffRefreshTime;

		private const float BuffRefreshCooldown = 1f;

		private static readonly BuffType[] _buffTypes;

		private readonly float[] _buffMultipliers;

		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;

		public override float BaseActiveDuration => 0f;

		public override void Init()
		{
		}

		private void RegisterDrone()
		{
		}

		private Vector2 GetZoneCenter()
		{
			return default(Vector2);
		}

		private float GetZoneRadius()
		{
			return 0f;
		}

		public static void ResetActiveDrones()
		{
		}

		protected override Rock TryFindTarget()
		{
			return null;
		}

		protected override void CustomFixedTick()
		{
		}

		private void UpdateDroneCount()
		{
		}

		private void UpdateRoaming()
		{
		}

		private void SetNewRoamTarget()
		{
		}

		private void ApplyAuraBuffs()
		{
		}

		protected override float CalculateDroneDamage()
		{
			return 0f;
		}

		public override void OnDestroy()
		{
		}
	}
}
