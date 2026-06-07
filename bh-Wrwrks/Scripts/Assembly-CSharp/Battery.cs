using System.Collections.Generic;
using UnityEngine;

public class Battery : Module
{
	private float range = 4f;

	protected override void CastSpell()
	{
		List<Module> network = base.board.GetNetwork(this);
		bool flag = false;
		int num = base.dungeon.board.CountAuras(Aura.Type.PerkConductor);
		foreach (Module item in network)
		{
			if (!item.MECH || !item.WEAPON || item.weapon == null)
			{
				continue;
			}
			List<Monster> list = new List<Monster>();
			foreach (Monster livingEnemy in base.dungeon.livingEnemies)
			{
				if (Vector3.Distance(livingEnemy.transform.position, item.weapon.transform.position) > range)
				{
					continue;
				}
				List<Monster> list2 = new List<Monster> { livingEnemy };
				for (int i = 0; i < num; i++)
				{
					Monster closestMonster = base.dungeon.GetClosestMonster(livingEnemy.transform.position, null, list2);
					if (!(closestMonster == null) && !list2.Contains(closestMonster) && !(Vector3.Distance(list2[list2.Count - 1].transform.position, closestMonster.transform.position) > range))
					{
						list2.Add(closestMonster);
					}
				}
				list.AddRange(list2);
			}
			foreach (Monster item2 in list)
			{
				List<Vector3> points = new List<Vector3>
				{
					item2.transform.position,
					item.weapon.transform.position
				};
				base.dungeon.animationManager.CreateLightning(points, "FFEB57");
				item2.Hurt(damage, null, noDeathrattle: false, 2, this);
				flag = true;
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlayModSound(this, 0.75f);
		}
	}
}
