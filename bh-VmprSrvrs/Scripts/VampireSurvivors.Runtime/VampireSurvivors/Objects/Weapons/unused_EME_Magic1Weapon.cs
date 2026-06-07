namespace VampireSurvivors.Objects.Weapons
{
	public class unused_EME_Magic1Weapon : Weapon
	{
		private float FireInterval => 0f;

		public override bool LevelUp(bool skipFire)
		{
			return false;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
