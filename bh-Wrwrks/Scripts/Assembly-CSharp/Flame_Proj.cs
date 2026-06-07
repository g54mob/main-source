using UnityEngine;

public class Flame_Proj : Projectile
{
	private bool b;

	private void Boom()
	{
		if (!b)
		{
			b = true;
			Projectile projectile = Dungeon.Instance.animationManager.CreateExplosion("C42430", "EA323C", 10, insta: true);
			projectile.source = source;
			source.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion);
			projectile.transform.position = base.transform.position;
			projectile.transform.localScale = Vector3.one * 1.125f;
			projectile.sharedWeapon = true;
			Object.Destroy(base.gameObject);
		}
	}

	public override void HitTrigger(Monster monster)
	{
		Boom();
		base.transform.localScale = Vector3.zero;
		GetComponent<Rigidbody2D>().simulated = false;
		source.ProjectileHit(monster);
		Object.Destroy(base.gameObject);
	}
}
