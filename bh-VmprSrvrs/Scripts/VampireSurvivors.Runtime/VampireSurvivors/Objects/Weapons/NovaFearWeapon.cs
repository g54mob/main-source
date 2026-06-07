using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class NovaFearWeapon : NovaWeapon
	{
		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void TrySlowEffect(EnemyController enemy)
		{
		}
	}
}
