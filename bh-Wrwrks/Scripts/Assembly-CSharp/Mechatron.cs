using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechatron : Weapon
{
	private float width = 3f;

	private float height = 3f;

	private float t;

	private int attackTimer = 60;

	private int attackTimerMax = 60;

	private bool rocket;

	public GameObject proj;

	private List<Monster> monsters => owner.dungeon.livingEnemies;

	public override void ProcessFrame()
	{
		Vector3 vector = new Vector3((width + 2f) * Mathf.Cos(t), (height + 2f) * Mathf.Sin(t));
		vector = new Vector3(Mathf.Clamp(vector.x, 0f - width, width), Mathf.Clamp(vector.y, 0f - height, height));
		t += 0.05f * owner.accelMult;
		base.transform.localPosition = vector;
		if (attackTimer > 0)
		{
			attackTimer--;
		}
		if (monsters.Count <= 0 || attackTimer > 0)
		{
			return;
		}
		Monster monster = null;
		foreach (Monster monster2 in monsters)
		{
			if (Vector3.Distance(monster2.transform.position, base.transform.position) < 3f)
			{
				monster = monster2;
				break;
			}
		}
		if (!(monster == null))
		{
			attackTimer = attackTimerMax;
			if (rocket)
			{
				ShootRocket(monster);
			}
			else
			{
				Zap(monster);
			}
			rocket = !rocket;
		}
	}

	private void ShootRocket(Monster m)
	{
		if (owner.dungeon.livingEnemies.Count != 0 && !(m == null))
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Rocket, 1f, 1.15f, 1f);
			float z = 180f + 180f / MathF.PI * Mathf.Atan2(base.transform.position.y - m.pos.y, base.transform.position.x - m.pos.x);
			Drone_Proj component = UnityEngine.Object.Instantiate(proj).GetComponent<Drone_Proj>();
			component.source = this;
			component.transform.position = base.transform.position;
			component.transform.localEulerAngles = new Vector3(0f, 0f, z);
			component.sharedWeapon = true;
			component.transform.localScale = base.transform.localScale;
			if (owner.UPGRADED)
			{
				component.transform.localScale += Vector3.one * 0.3f;
			}
			Vector3 normalized = (m.transform.position - base.transform.position).normalized;
			owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
			owner.dungeon.animationManager.Fade(component.gameObject, 3, 240);
		}
	}

	private void Zap(Monster m)
	{
		float num = 3.5f;
		int num2 = 3;
		LightningEffect component = Dungeon.Instance.InstantiateExternal(Dungeon.Instance.LightningEffect).GetComponent<LightningEffect>();
		List<Monster> list = new List<Monster> { m };
		Monster monster = m;
		num2 += owner.dungeon.board.CountAuras(Aura.Type.PerkConductor);
		for (int i = 0; i < num2 - 1; i++)
		{
			List<Monster> list2 = new List<Monster>();
			foreach (Monster livingEnemy in Dungeon.Instance.livingEnemies)
			{
				if (Vector3.Distance(livingEnemy.pos, monster.pos) < num && !list.Contains(livingEnemy))
				{
					list2.Add(livingEnemy);
				}
			}
			if (list2.Count == 0)
			{
				break;
			}
			Monster monster2 = Utils.RandElem(list2);
			monster = monster2;
			list.Add(monster2);
		}
		List<Vector3> list3 = new List<Vector3> { base.transform.position };
		foreach (Monster item in list)
		{
			item.Hurt(base.damage, null, noDeathrattle: false, 2, owner);
			list3.Add(item.pos);
		}
		component.SetPoints(list3);
	}

	public override IEnumerator Spin()
	{
		Vector3 last = base.transform.position;
		while (true)
		{
			Vector3 position = base.transform.position;
			if (position.x > last.x)
			{
				GetComponent<SpriteRenderer>().flipX = true;
			}
			else if (position.x < last.x)
			{
				GetComponent<SpriteRenderer>().flipX = false;
			}
			last = base.transform.position;
			yield return Dungeon.Wait(1);
		}
	}
}
