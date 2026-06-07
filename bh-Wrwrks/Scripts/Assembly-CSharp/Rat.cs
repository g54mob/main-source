using System.Collections;
using UnityEngine;

public class Rat : Weapon
{
	private Monster target;

	private float speed = 0.15f;

	private int t = 30;

	private bool init;

	private bool anim;

	public override void ProcessFrame()
	{
		if (!init)
		{
			init = true;
			base.transform.position = base.player.pos + Utils.RandDir() * 2f;
		}
		if (anim)
		{
			return;
		}
		if (target != null && target.health > 0)
		{
			Vector3 normalized = (target.transform.position - base.transform.position).normalized;
			if (Vector3.Distance(base.transform.position, target.pos) <= 0.75f)
			{
				if (t == 0)
				{
					t = (int)(30f / owner.accelMult);
					StartCoroutine(Knockback(target));
					target.HitWeapon(this);
				}
				else
				{
					t--;
				}
			}
			else
			{
				base.transform.position += normalized * speed * owner.accelMult;
			}
			GetComponent<SpriteRenderer>().flipX = target.pos.x > base.transform.position.x;
		}
		else
		{
			target = base.dungeon.GetClosestMonster(base.transform.position);
			t = 0;
		}
	}

	private IEnumerator Knockback(Monster m)
	{
		Vector3 dir = (m.transform.position - base.transform.position).normalized;
		anim = true;
		float dist = 0.1f;
		base.transform.position += dir * dist;
		for (int i = 0; i < 4; i++)
		{
			base.transform.position += dir * (0f - dist) / 4f;
			yield return Dungeon.Wait(2);
		}
		yield return Dungeon.Wait(2);
		anim = false;
	}

	public override IEnumerator Spin()
	{
		yield break;
	}
}
