using UnityEngine;

public class Swipe : Weapon
{
	public GameObject swipeObj;

	private bool swipeHit;

	public override void ProjectileHit(Monster monster)
	{
		base.ProjectileHit(monster);
	}

	public override void HitTrigger(Monster monster)
	{
		if (swipeHit)
		{
			if (!(monster == null))
			{
				swipeHit = false;
				Projectile component = Object.Instantiate(swipeObj).GetComponent<Projectile>();
				component.transform.position = monster.transform.position;
				component.transform.localScale = base.transform.localScale + Vector3.one * 0.15f;
				base.animationManager.LerpZoom(component.gameObject, base.transform.localScale, 10f, 0.1f);
				component.source = this;
				component.forceDamage = base.damage * 2;
				base.animationManager.Fade(component.gameObject, 5, 15);
				owner.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Swipe, 0.9f, 1.1f, 1f);
			}
		}
	}

	public override void CastSpell()
	{
		swipeHit = true;
	}
}
