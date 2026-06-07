namespace VampireSurvivors.Objects.Weapons
{
	public class NovaIceWeapon : NovaWeapon
	{
		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
