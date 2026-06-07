using FractureField.Rocks;
using Reactivity;
using UnityEngine;

namespace FractureField.Drones
{
	public class SentryDrone : Drone
	{
		public const float BaseAttackRange = 2.5f;

		public CFloat AttackRange;

		private readonly CatLogger _logger;

		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;

		public bool IsBeingDragged { get; set; }

		protected override Vector2 GetSpawnPosition()
		{
			return default(Vector2);
		}

		protected override Rock TryFindTarget()
		{
			return null;
		}

		protected override void TryTickIdle()
		{
		}

		protected override void TryTickMovingToTarget()
		{
		}

		protected override void TryTickHitting()
		{
		}

		public override void PerformHit()
		{
		}

		private void StartHit()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
