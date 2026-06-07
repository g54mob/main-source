using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : Weapon
{
	public List<GameObject> orbs;

	public GameObject orbPivotCC;

	public GameObject orbPivotCCW;

	public GameObject orbMid;

	public override void CastSpell()
	{
		List<Monster> list = new List<Monster>(base.dungeon.livingEnemies);
		bool flag = false;
		foreach (Monster item in list)
		{
			if (item.speedMult < 1f)
			{
				flag = true;
				item.Hurt(3, null, noDeathrattle: false, 2, owner);
				Hit(item);
				Color color = Utils.GetColor("00CDF9");
				Dungeon.Instance.animationManager.CreateDust(item.transform.position, color);
				Dungeon.Instance.animationManager.CreateLaser(new List<Vector3>
				{
					base.transform.position,
					item.transform.position
				}, "00CDF9");
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Ice);
		}
	}

	public override void ProcessFrame()
	{
		orbMid.transform.localEulerAngles += new Vector3(0f, 0f, 9f);
		orbPivotCC.transform.localEulerAngles += new Vector3(0f, 0f, -5f);
		orbPivotCCW.transform.localEulerAngles += new Vector3(0f, 0f, 12f);
		foreach (GameObject orb in orbs)
		{
			orb.transform.localEulerAngles += new Vector3(0f, 0f, 5f);
		}
		base.ProcessFrame();
	}

	public override IEnumerator Spin()
	{
		yield break;
	}
}
