using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : Weapon
{
	private float t;

	public void ZapEnemies()
	{
		float num = 2.6f;
		int num2 = base.dungeon.board.CountAuras(Aura.Type.PerkConductor);
		Module module = owner;
		List<Monster> list = new List<Monster>();
		foreach (Monster livingEnemy in base.dungeon.livingEnemies)
		{
			if (Vector3.Distance(livingEnemy.transform.position, module.weapon.transform.position) > num)
			{
				continue;
			}
			List<Monster> list2 = new List<Monster> { livingEnemy };
			for (int i = 0; i < num2; i++)
			{
				Monster closestMonster = base.dungeon.GetClosestMonster(livingEnemy.transform.position, null, list2);
				if (!(closestMonster == null) && !list2.Contains(closestMonster) && !(Vector3.Distance(list2[list2.Count - 1].transform.position, closestMonster.transform.position) > num))
				{
					list2.Add(closestMonster);
				}
			}
			list.AddRange(list2);
		}
		foreach (Monster item in list)
		{
			List<Vector3> points = new List<Vector3>
			{
				item.transform.position,
				module.weapon.transform.position
			};
			base.dungeon.animationManager.CreateLightning(points, "94FDFF");
			item.HitWeapon(this);
		}
	}

	public override void ProcessFrame()
	{
		t += 0.1f;
		if (t > MathF.PI * 2f)
		{
			t -= MathF.PI * 2f;
			if (owner.UPGRADED)
			{
				ZapEnemies();
			}
		}
		base.transform.localEulerAngles += new Vector3(0f, 0f, 2f);
		base.transform.localPosition = Vector3.zero;
		scale += Mathf.Sin(t) * 0.05f * Vector3.one;
		base.transform.localScale = scale;
	}

	public override IEnumerator Spin()
	{
		yield return null;
	}
}
