using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Weapon
{
	private Monster target;

	private Vector3 last = Vector3.zero;

	public int attackInterval = 40;

	private int c;

	private bool init;

	private bool knock;

	private float speed
	{
		get
		{
			if (!owner.UPGRADED)
			{
				return 0.1f;
			}
			return 0.115f;
		}
	}

	private List<Monster> enemies => owner.dungeon.livingEnemies;

	private float attackSpeed => owner.accelMult * (float)attackInterval;

	public override void KillTrigger(Monster monster)
	{
		owner.counter++;
		owner.TriggerBounce();
		if (owner.counter % 40 == 0)
		{
			PlaySound(AudioManager.Sound.Chicken);
			owner.board.CreateModuleSmall(Module.Name.Egg);
		}
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			init = true;
			last = Dungeon.Instance.player.transform.position;
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
				if (Vector3.Distance(enemy.transform.position, base.transform.position) <= 5f)
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
			Vector3 normalized = (target.transform.position - base.transform.position).normalized;
			if (Vector3.Distance(target.transform.position, base.transform.position) > 0.25f && !knock)
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
				if ((float)c >= 20f / owner.accelMult)
				{
					GetComponent<Rigidbody2D>().simulated = true;
					c = 0;
					knock = false;
				}
				else
				{
					last += normalized * speed * -1f / 4f * owner.accelMult;
					c++;
				}
			}
		}
		else
		{
			Vector3 normalized2 = (Dungeon.Instance.player.transform.position - base.transform.position).normalized;
			if (Vector3.Distance(Dungeon.Instance.player.transform.position, base.transform.position) > 1.5f)
			{
				last += normalized2 * speed * owner.accelMult;
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
				GetComponent<SpriteRenderer>().flipX = x2 > x;
			}
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 90f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
