using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
	public GameObject arrow;

	private int timer;

	public int shotIntervalFrames = 60;

	public int burst = 3;

	public List<GameObject> projectiles = new List<GameObject>();

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	private void ShootArrow()
	{
		Projectile component = UnityEngine.Object.Instantiate(arrow).GetComponent<Projectile>();
		component.GetComponent<SpriteRenderer>().color = Utils.GetColor(Utils.Rand("FF5000", "FFC825", 75f));
		component.source = this;
		component.transform.localEulerAngles = base.transform.localEulerAngles + new Vector3(0f, 0f, UnityEngine.Random.Range(-45, 45));
		component.transform.localScale = base.transform.localScale * 0.5f;
		float num = UnityEngine.Random.Range(-MathF.PI / 3f, MathF.PI / 3f);
		float f = (base.transform.localEulerAngles.z + 90f) * MathF.PI / 180f + num;
		Vector3 normalized = (base.transform.position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) - base.transform.position).normalized;
		component.transform.parent = base.transform;
		component.transform.localPosition = new Vector3((float)((!GetComponent<SpriteRenderer>().flipX) ? 1 : (-1)) * 0.25f, 0.9f, 0f);
		component.transform.parent = base.dungeon.transform;
		owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, UnityEngine.Random.Range(0.02f, 0.06f));
		float num2 = Mathf.Abs(num) / (MathF.PI / 3f) * 10f;
		if (owner.UPGRADED)
		{
			num2 -= 15f;
		}
		owner.dungeon.animationManager.Fade(component.gameObject, 2, 25 - (int)num2);
		projectiles.Add(component.gameObject);
		StartCoroutine(remover(component.gameObject));
	}

	private IEnumerator remover(GameObject p)
	{
		yield return Dungeon.Wait(31);
		projectiles.Remove(p);
	}

	public override void ProcessFrame()
	{
		if (timer++ == shotIntervalFrames)
		{
			timer = 0;
			for (int i = 0; i < burst; i++)
			{
				ShootArrow();
			}
		}
		Vector3 vector = pos.normalized;
		if (pos == Vector3.zero)
		{
			vector = new Vector3(1f, 0f);
		}
		base.transform.localPosition = vector * Mathf.Min(pos.magnitude + 1.5f, 1.5f);
		base.transform.localScale = scale;
	}

	public override IEnumerator Spin()
	{
		_ = base.transform.position;
		_ = base.transform.localEulerAngles;
		while (true)
		{
			float num = Mathf.Atan2(base.transform.position.y - base.transform.parent.position.y, base.transform.position.x - base.transform.parent.position.x);
			num -= MathF.PI / 2f;
			num *= 180f / MathF.PI;
			base.transform.localEulerAngles = new Vector3(0f, 0f, num);
			GetComponent<SpriteRenderer>().flipX = base.transform.position.x < base.dungeon.player.transform.position.x;
			yield return Wait(1);
		}
	}
}
