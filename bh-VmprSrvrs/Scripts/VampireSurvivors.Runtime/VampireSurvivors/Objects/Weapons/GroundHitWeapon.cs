namespace VampireSurvivors.Objects.Weapons
{
	public class GroundHitWeapon : SwordWeapon
	{
		public override float PAmount()
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
