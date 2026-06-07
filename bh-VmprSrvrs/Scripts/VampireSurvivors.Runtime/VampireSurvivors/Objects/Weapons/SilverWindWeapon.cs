namespace VampireSurvivors.Objects.Weapons
{
	public class SilverWindWeapon : Weapon
	{
		protected override void FakeConstruct()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
