using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfWeapon : Weapon
{
	private List<Aura> dmgBuffs = new List<Aura>();

	private Monster target;

	private float speed = 0.115f;

	private Vector3 last = Vector3.zero;

	public int attackInterval = 40;

	private int c;

	private bool init;

	private bool knock;

	private Vector3 home = Vector3.zero;

	public List<Sprite> idleAnim;

	public List<Sprite> runAnim;

	private List<Monster> enemies => owner.dungeon.livingEnemies;

	private float attackSpeed => owner.accelMult * (float)attackInterval;

	public void SetDamage()
	{
		if (owner.name == Module.Name.Wolf)
		{
			int num = owner.GetEmptyNeighbors() * 3;
			if (owner.UPGRADED)
			{
				num *= 2;
			}
			while (num > dmgBuffs.Count)
			{
				Aura aura = new Aura(Aura.Type.Damage);
				owner.AddAura(aura);
				dmgBuffs.Add(aura);
			}
			while (num < dmgBuffs.Count)
			{
				owner.RemoveAura(dmgBuffs[0]);
				dmgBuffs.Remove(dmgBuffs[0]);
			}
			base.transform.localScale = Vector3.one;
		}
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			init = true;
			last = Dungeon.Instance.player.transform.position + 1.5f * Utils.RandDir();
			home = last;
		}
		if (target != null && target.health <= 0)
		{
			target = null;
		}
		if (enemies.Count > 0 && target == null)
		{
			List<Monster> list = new List<Monster>();
			foreach (Monster enemy in enemies)
			{
				if (Vector3.Distance(enemy.transform.position, base.transform.position) <= 6f)
				{
					list.Add(enemy);
				}
			}
			if (list.Count > 0)
			{
				target = Utils.RandElem(list);
			}
		}
		if (target != null)
		{
			if (GetComponent<Animator>().frames[0] == idleAnim[0])
			{
				GetComponent<Animator>().CustomAnim(runAnim, 8f);
			}
			Vector3 normalized = (target.transform.position - base.transform.position).normalized;
			if (Vector3.Distance(target.transform.position, base.transform.position) > 0.2f && !knock)
			{
				last += normalized * speed;
			}
			else
			{
				knock = true;
			}
			if (knock)
			{
				GetComponent<Rigidbody2D>().simulated = false;
				if ((float)c >= 25f / owner.accelMult)
				{
					GetComponent<Rigidbody2D>().simulated = true;
					c = 0;
					knock = false;
				}
				else
				{
					last += normalized * speed * -6f / 25f * owner.accelMult;
					c++;
				}
			}
		}
		else
		{
			Vector3 normalized2 = (home - base.transform.position).normalized;
			if (Vector3.Distance(home, base.transform.position) > 1.5f)
			{
				last += normalized2 * speed * owner.accelMult;
			}
			else if (GetComponent<Animator>().frames[0] == runAnim[0])
			{
				GetComponent<Animator>().CustomAnim(idleAnim, 4f);
			}
		}
		base.transform.position = last;
	}

	public override IEnumerator Spin()
	{
		Vector3 last = pos;
		while (true)
		{
			float x = base.transform.position.x;
			float x2 = last.x;
			if (!knock)
			{
				GetComponent<SpriteRenderer>().flipX = x2 < x;
			}
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 90f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
