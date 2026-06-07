using System.Collections;
using UnityEngine;

public class Sapper : Monster
{
	public override IEnumerator Attack()
	{
		yield return null;
		base.player.Hurt(damage);
		Projectile projectile = base.dungeon.animationManager.CreateExplosion("C42430", "EA323C", 10, insta: true, ticks: false, spin: false);
		projectile.damage = damage;
		projectile.transform.position = base.pos;
		projectile.transform.localScale = Vector3.one * 0.7f;
		projectile.transform.localEulerAngles = Vector3.zero;
		base.dungeon.animationManager.Screenshake(Utils.RandSign(), Utils.RandSign());
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Sapper_Boom, Random.Range(0.95f, 1.05f));
		Hurt(health, null, noDeathrattle: true);
	}

	public override void DeathEffect()
	{
		Projectile projectile = base.dungeon.animationManager.CreateExplosion("C42430", "EA323C", 10, insta: true, ticks: false, spin: false);
		projectile.damage = damage;
		projectile.transform.position = base.pos;
		projectile.transform.localScale = Vector3.one * 0.7f;
		if (Vector3.Distance(base.pos, base.player.pos) <= 1.2f)
		{
			base.player.Hurt(damage);
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Sapper_Boom, Random.Range(0.95f, 1.05f));
		}
		projectile.transform.localEulerAngles = Vector3.zero;
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion);
	}
}
