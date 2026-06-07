using System.Collections.Generic;
using FractureField.Rocks;
using Reactivity;

namespace FractureField.Drones
{
	public class SupervisorDrone : Drone
	{
		public const float BaseWakeRange = 0.5f;

		public const float BaseBuffDuration = 10f;

		public CFloat BuffDuration;

		public const float BaseBuffMultiplier = 1.5f;

		public CFloat BuffMultiplier;

		private Drone _targetRestingDrone;

		private static Dictionary<Drone, SupervisorDrone> _restingDroneTargets;

		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;

		public override float BaseActiveDuration => 0f;

		public override bool ShouldRest => false;

		public static void ClearAllTargetTracking()
		{
		}

		protected override Rock TryFindTarget()
		{
			return null;
		}

		protected override void CustomFixedTick()
		{
		}

		private void UpdateRoaming()
		{
		}

		private void FindNearestRestingDrone()
		{
		}

		private void WakeNearbySleepingDrones()
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
