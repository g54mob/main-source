using System.Collections.Generic;
using UnityEngine;

public class Blast : Weapon
{
	private bool trig;

	public override void ProcessFrame()
	{
		trig = false;
		base.ProcessFrame();
	}

	public override void CastSpell()
	{
		if (!trig)
		{
			trig = true;
			Monster closestMonster = base.dungeon.GetClosestMonster(base.transform.position);
			bool flag = false;
			if (closestMonster == null)
			{
				flag = true;
			}
			else if (Vector3.Distance(closestMonster.transform.position, base.transform.position) > 5f)
			{
				flag = true;
			}
			if (flag)
			{
				base.dungeon.audioManager.PlayModSound(owner, 0.75f);
				Dungeon.Instance.animationManager.CreateDust(base.transform.position, "C64524", 10, 0.75f);
				return;
			}
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Balloon);
			Dungeon.Instance.animationManager.CreateDust(closestMonster.transform.position, "C64524", 10, 0.75f);
			Dungeon.Instance.animationManager.CreateLaser(new List<Vector3>
			{
				base.transform.position,
				closestMonster.transform.position
			}, "C64524", 0.25f);
			Projectile projectile = base.dungeon.animationManager.CreateExplosion("C64524", "C64524", 10, insta: true);
			projectile.source = this;
			projectile.transform.localScale = base.transform.localScale * 0.9f + (base.UPGRADED ? (Vector3.one * 0.3f) : Vector3.zero);
			projectile.transform.position = closestMonster.transform.position;
		}
	}
}
