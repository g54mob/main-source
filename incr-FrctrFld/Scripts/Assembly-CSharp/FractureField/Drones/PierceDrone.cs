using FractureField.Rocks;
using Reactivity;

namespace FractureField.Drones
{
	public class PierceDrone : Drone
	{
		public const float BasePierceMultiplier = 5f;

		private bool _isFacingRight;

		private readonly CatLogger _pierceLogger;

		public override DroneType Type => default(DroneType);

		public override float MoveSpeedModifier => 0f;

		public override float HitSpeedModifier => 0f;

		public override float DamageModifier => 0f;

		public override CFloat PierceMultiplier { get; }

		protected override Rock TryFindTarget()
		{
			return null;
		}

		protected override void TryTickHitting()
		{
		}

		protected override void CustomFixedTick()
		{
		}

		private Rock TryFindBetterPierceTarget()
		{
			return null;
		}

		protected override void TryTickMovingToTarget()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
