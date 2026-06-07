using UnityEngine;

public class Explosive : Module
{
	public GameObject projectile;

	public override void ActivateButton()
	{
		if (!(base.weapon == null) && base.weapon.cooldown <= 0)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion);
			Projectile obj = base.dungeon.animationManager.CreateExplosion("C42430", "EA323C", 10, insta: true);
			obj.source = base.weapon;
			obj.transform.localScale = base.weapon.transform.localScale;
			obj.transform.position = base.weapon.transform.position;
			base.weapon.SetCooldown(cooldown);
		}
	}
}
