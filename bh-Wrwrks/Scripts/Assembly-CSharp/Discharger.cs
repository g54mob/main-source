using System.Collections.Generic;
using UnityEngine;

public class Discharger : Weapon
{
	public override void CastSpell()
	{
		int num = base.dungeon.board.CountAuras(Aura.Type.PerkConductor);
		List<Monster> list = new List<Monster>();
		bool flag = false;
		foreach (Monster item in new List<Monster>(base.dungeon.livingEnemies))
		{
			if (item == null || item.health <= 0)
			{
				continue;
			}
			flag = true;
			list.Clear();
			list.Add(item);
			for (int i = 0; i < num; i++)
			{
				list.Add(base.dungeon.GetClosestMonster(item.transform.position, null, list));
			}
			List<Vector3> list2 = new List<Vector3> { base.transform.position };
			foreach (Monster item2 in list)
			{
				if (!(item2 == null))
				{
					item2.Hurt(base.damage, null, noDeathrattle: false, 2, owner);
					Hit(item2);
					if (base.UPGRADED)
					{
						item2.Stun(0.5f);
					}
					list2.Add(item2.transform.position);
				}
			}
			base.dungeon.animationManager.CreateLightning(list2, "94FDFF", silent: true);
		}
		if (flag)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Shock_Wep);
		}
	}
}
