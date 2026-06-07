using UnityEngine;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_StoneSkull_Character : TP_Character
	{
		private float cachedSize;

		public override bool HasThorns => false;

		public override bool DrainWeaponsImmunity => false;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		public override void AfterFullInitialization()
		{
		}

		protected override Vector2 ProcessMovementVector(Vector2 v)
		{
			return default(Vector2);
		}

		public override float GetThornDamage(EnemyController enemy)
		{
			return 0f;
		}

		protected override void OnStop()
		{
		}

		public void SetMechaDamageEmitter()
		{
		}
	}
}
