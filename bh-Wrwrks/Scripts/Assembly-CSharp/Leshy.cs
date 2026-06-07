using System.Collections;
using UnityEngine;

public class Leshy : Weapon
{
	private Monster target;

	private float speed = 0.05f;

	private int attackTime = 10;

	private int t = 10;

	private bool init;

	private bool anim;

	private float accelMult => owner.accelMult;

	public override void CastSpell()
	{
		int num = 120;
		bool flag = false;
		foreach (Module item in owner.board.GetBoard())
		{
			if (item.PET && !(item == owner))
			{
				item.BuffParticles("33984B", num);
				flag = true;
				item.AddAura(new Aura(Aura.Type.Damage, foreign: false, temp: true, null, base.UPGRADED ? 6 : 3), num);
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlayModSound(owner, 0.85f);
		}
	}

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
			if (Vector3.Distance(base.transform.position, target.pos) <= 1f)
			{
				if (t == 0)
				{
					t = (int)((float)attackTime / accelMult);
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
				base.transform.position += normalized * speed * accelMult;
			}
			GetComponent<SpriteRenderer>().flipX = target.pos.x > base.transform.position.x;
		}
		else
		{
			target = base.dungeon.GetClosestMonster(base.transform.position);
			t = 10;
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
