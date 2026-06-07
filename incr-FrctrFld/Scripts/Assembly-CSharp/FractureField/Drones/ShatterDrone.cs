using Reactivity;
using UnityEngine;

namespace FractureField.Drones
{
	public class ShatterDrone : Drone
	{
		public const float BaseRadius = 2f;

		public CFloat BlastRadius;

		private const int MAX_OVERLAP_RESULTS = 256;

		private readonly Collider2D[] _overlapCache;

		private readonly ContactFilter2D _contactFilter;

		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;

		public override void PerformHit()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
