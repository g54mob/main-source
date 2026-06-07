using System;
using System.Collections.Generic;
using FractureField.Rocks;
using Reactivity;
using UnityEngine;

namespace FractureField.Drones
{
	public class Drone : DroneSaveData, ISaveData<Drone, DroneSaveData>
	{
		private Vector2 _position;

		private Rock _target;

		protected Rock _hittingTarget;

		protected int _retargetCountDuringFlight;

		protected float _timeSinceLastRetargetCheck;

		protected const float RetargetCheckInterval = 0.25f;

		public const float BaseIdleTime = 1f;

		public CFloat IdleTime;

		public const float BaseMovementSpeed = 1.5f;

		private CFloat _movementSpeed;

		public const float BaseHitSpeed = 2f;

		private CFloat _hitSpeed;

		public const float BaseDamageMultiplier = 0.5f;

		private CFloat _damageMultiplier;

		public const float BaseRestDuration = 10f;

		public const float HoverHeight = 0.5f;

		private readonly CatLogger _logger;

		public DroneBuffManager BuffManager { get; private set; }

		public virtual DroneType Type { get; }

		public int SlotCost => 0;

		public int HardLimit => 0;

		public virtual float MoveSpeedModifier => 0f;

		public virtual float HitSpeedModifier => 0f;

		public virtual float DamageModifier => 0f;

		public virtual CFloat PierceMultiplier { get; }

		public float TimeInActive { get; set; }

		public float TimeInRest { get; set; }

		public float TimeInIdle { get; set; }

		public float TimeSinceLastHit { get; set; }

		public float TargetIdleDuration { get; set; }

		public float TargetActiveDuration { get; set; }

		public Ref<DroneState> State { get; set; }

		public long TargetRockId { get; set; }

		public Vector2 Position
		{
			get
			{
				return default(Vector2);
			}
			protected set
			{
			}
		}

		public Rock Target => null;

		public CFloat MovementSpeed => null;

		public CFloat HitSpeed => null;

		public CFloat DamageMultiplier => null;

		public virtual float BaseActiveDuration => 0f;

		public RTrigger OnHitStarted { get; }

		public bool HasTarget => false;

		public bool HasTargetWhichIsInvalid => false;

		public bool CanHit => false;

		public virtual bool ShouldRest => false;

		public static RTrigger OnDroneStartedResting { get; }

		public Drone Load()
		{
			return null;
		}

		public DroneSaveData Save()
		{
			return null;
		}

		public void SetupAndInit()
		{
		}

		public virtual void Init()
		{
		}

		protected void SetTarget(Rock value)
		{
		}

		public void FixedTick()
		{
		}

		protected virtual void CustomFixedTick()
		{
		}

		protected virtual void TryTickIdle()
		{
		}

		protected virtual void TryTickMovingToTarget()
		{
		}

		protected virtual void TryTickHitting()
		{
		}

		private void StartHit()
		{
		}

		public virtual void PerformHit()
		{
		}

		public void EndHit()
		{
		}

		protected virtual float CalculateDroneDamage()
		{
			return 0f;
		}

		protected virtual Vector2 GetSpawnPosition()
		{
			return default(Vector2);
		}

		public void SetPosition(Vector2 position)
		{
		}

		public void ClearTarget()
		{
		}

		protected void TrySetTarget()
		{
		}

		protected (Rock, List<Rock>) SharedFindTargetLogic(Func<Rock, bool> AdditionalPredicate = null)
		{
			return default((Rock, List<Rock>));
		}

		protected virtual Rock TryFindTarget()
		{
			return null;
		}

		private Rock TryFindCloserUntargetedRock()
		{
			return null;
		}

		protected void TryTickResting()
		{
		}

		protected void ChangeState(DroneState newState)
		{
		}

		public void StartResting()
		{
		}

		public bool CanReactivate()
		{
			return false;
		}

		public void Reactivate()
		{
		}

		public void WakeUp()
		{
		}

		public void RefreshBuff(BuffType type, float multiplier, float duration, string source, DroneBuffSourceType sourceType)
		{
		}

		public void RefreshMultipleBuffs(BuffType[] types, float[] multipliers, float duration, string source, DroneBuffSourceType sourceType)
		{
		}

		public float GetBuffMultiplier(BuffType type)
		{
			return 0f;
		}

		public bool HasAnyBuffForSourceType(DroneBuffSourceType sourceType)
		{
			return false;
		}

		public bool HasBuffFromDifferentSource(DroneBuffSourceType sourceType, string currentSource)
		{
			return false;
		}

		public virtual void OnDestroy()
		{
		}

		protected virtual bool IsValidTarget(Rock rock)
		{
			return false;
		}
	}
}
