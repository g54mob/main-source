public class ChemVial : Projectile
{
	private void Awake()
	{
		Dungeon.Instance.animationManager.projGibsAlt++;
	}

	private void OnDestroy()
	{
		Dungeon.Instance.animationManager.projGibsAlt--;
		int duration = 120;
		Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.Explosion_Potion);
		Projectile projectile = Dungeon.Instance.animationManager.CreateExplosion("33984B", "5AC54F", duration, insta: false, ticks: true, spin: true, shake: true, 40, alt: true);
		projectile.sourceModule = Dungeon.Instance.player.sentinel;
		projectile.forceDamage = 2;
		projectile.transform.position = base.transform.position;
	}
}
