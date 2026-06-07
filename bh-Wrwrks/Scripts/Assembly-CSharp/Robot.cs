using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Weapon
{
	private Monster target;

	private float speed = 0.085f;

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
		if (target != null)
		{
			Vector3 normalized = (target.transform.position - base.transform.position).normalized;
			if (Vector3.Distance(base.transform.position, target.pos) <= 2f)
			{
				anim = true;
				StartCoroutine(Knockback(target));
			}
			else
			{
				base.transform.position += normalized * speed * owner.accelMult;
			}
		}
		else if (base.dungeon.livingEnemies.Count > 0)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Robot_Mechanism, 1f, 0.85f);
			target = Utils.RandElem(base.dungeon.livingEnemies);
		}
		else
		{
			target = null;
		}
	}

	private IEnumerator Knockback(Monster tar)
	{
		anim = true;
		float rad = (base.UPGRADED ? 4.5f : 3.5f);
		for (int i = 0; i < 3; i++)
		{
			if (i != 0)
			{
				yield return Dungeon.Wait((int)(20f / owner.accelMult));
			}
			bool flag = false;
			List<Monster> list = new List<Monster>(base.dungeon.livingEnemies);
			if (list.Count == 0)
			{
				break;
			}
			foreach (Monster item in list)
			{
				if (!(item == null) && !(Vector3.Distance(base.transform.position, item.transform.position) > rad))
				{
					item.HitWeapon(this);
					List<Vector3> points = new List<Vector3>
					{
						item.transform.position,
						base.transform.position + new Vector3(0f, 0.375f)
					};
					base.dungeon.animationManager.CreateLaser(points, "C42430", 0.25f);
					base.dungeon.animationManager.CreateDust(item.transform.position, "C42430", 5, 0.75f);
					flag = true;
				}
			}
			if (flag)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Magic_Bolt, 0.9f + (float)i * 0.1f, 0.8f);
			}
		}
		yield return Dungeon.Wait(2);
		anim = false;
	}

	public override IEnumerator Spin()
	{
		Vector3 last = pos;
		while (true)
		{
			float x = base.transform.position.x;
			float x2 = last.x;
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 90f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
