using UnityEngine;

public class Toxic : Weapon
{
	public GameObject projectile;

	public override void HitTrigger(Monster monster)
	{
		if (cooldown <= 0)
		{
			int duration = (owner.UPGRADED ? 180 : 120);
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Potion);
			Projectile obj = owner.dungeon.animationManager.CreateExplosion("33984B", "5AC54F", duration, insta: false, ticks: true);
			obj.source = this;
			obj.transform.position = monster.transform.position;
			SetCooldown(owner.cooldown);
		}
	}
}
