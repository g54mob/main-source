public class Oil : Weapon
{
	public override void HitTrigger(Monster monster)
	{
		if (cooldown <= 0)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Barrel_Splash);
			Projectile projectile = owner.dungeon.animationManager.CreateExplosion("657392", "424C6E", 10, insta: true);
			projectile.source = this;
			projectile.sharedWeapon = true;
			projectile.transform.position = monster.transform.position;
			projectile.debuff = Monster.Debuff.Oil;
			projectile.debuffValue = (owner.UPGRADED ? 60 : 120);
			SetCooldown(owner.cooldown);
		}
	}
}
