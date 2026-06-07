using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : Module
{
	private int timer = 60;

	private int baseTimer = 60;

	private int maxTimer => (int)((float)baseTimer / accelMult);

	public override IEnumerator Increment()
	{
		timer = maxTimer;
		while (true)
		{
			timer--;
			if (timer == 0)
			{
				FireBeams();
				timer = maxTimer;
			}
			yield return Dungeon.Wait(1);
		}
	}

	private void FireBeams()
	{
		if (base.dungeon.livingEnemies.Count <= 0)
		{
			return;
		}
		bool flag = false;
		foreach (Module adjacent in GetAdjacents())
		{
			if (adjacent.MECH && !(adjacent.weapon == null))
			{
				Monster closestMonster = base.dungeon.GetClosestMonster(adjacent.weapon.transform.position);
				if (!(closestMonster == null))
				{
					List<Vector3> points = new List<Vector3>
					{
						adjacent.weapon.transform.position,
						closestMonster.transform.position
					};
					base.dungeon.animationManager.CreateLaser(points, "C42430", 0.25f);
					base.dungeon.animationManager.CreateDust(closestMonster.transform.position, "C42430", 5, 0.75f);
					closestMonster.Hurt(damage, null, noDeathrattle: false, 2, this);
					SpecTrig(adjacent.weapon, closestMonster, closestMonster.health <= 0);
					adjacent.weapon.SpecialTriggers(closestMonster);
					flag = true;
				}
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Magic_Bolt, 1.1f, 1.2f, 1f);
		}
	}

	private void SpecTrig(Weapon wep, Monster monster, bool kill)
	{
		foreach (Trigger trigger in triggers)
		{
			trigger.ActivateTrigger(wep, monster, global::Trigger.Type.Hit);
			if (kill)
			{
				trigger.ActivateTrigger(wep, monster, global::Trigger.Type.Kill);
			}
		}
		foreach (Module input in inputs)
		{
			if (Module.wireMods.Contains(input.name))
			{
				continue;
			}
			foreach (Trigger trigger2 in input.triggers)
			{
				trigger2.ActivateTrigger(wep, monster, global::Trigger.Type.Hit);
				if (kill)
				{
					trigger2.ActivateTrigger(wep, monster, global::Trigger.Type.Kill);
				}
			}
		}
	}
}
