using System.Collections.Generic;
using UnityEngine;

public class Cold : Weapon
{
	private float radius
	{
		get
		{
			if (!base.UPGRADED)
			{
				return 4.5f;
			}
			return 5f;
		}
	}

	public override void CastSpell()
	{
		bool flag = false;
		Color color = Utils.GetColor("00CDF9");
		foreach (Monster item in new List<Monster>(base.dungeon.livingEnemies))
		{
			if (!(Vector3.Distance(item.transform.position, base.transform.position) > radius))
			{
				flag = true;
				item.Hurt(base.damage, null, noDeathrattle: false, 2, owner);
				Hit(item);
				item.ApplyDebuff(Monster.Debuff.Slow, base.UPGRADED ? 180 : 120);
				Dungeon.Instance.animationManager.CreateDust(item.transform.position, color, 10, 0.75f);
				Dungeon.Instance.animationManager.CreateLaser(new List<Vector3>
				{
					base.transform.position,
					item.transform.position
				}, "00CDF9", 0.25f);
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Ice);
		}
		else
		{
			Dungeon.Instance.animationManager.CreateDust(base.transform.position, color, 10, 0.75f);
		}
	}
}
