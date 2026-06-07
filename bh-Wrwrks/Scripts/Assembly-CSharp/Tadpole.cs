using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tadpole : Monster
{
	public List<Monster> pack = new List<Monster>();

	public bool scatter;

	private float rad = 9f;

	private float angle;

	private float t;

	private float accel = 0.01f;

	public override void HitEffect()
	{
		base.HitEffect();
		if (scatter)
		{
			return;
		}
		scatter = true;
		foreach (Monster item in pack)
		{
			if (!(item == null))
			{
				item.GetComponent<Tadpole>().scatter = true;
				item.GetComponent<Tadpole>().StartCoroutine(item.GetComponent<Tadpole>().fear());
			}
		}
	}

	public override void InitStats()
	{
		base.InitStats();
		angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		accel = Utils.RandSign(Random.Range(0.01f, 0.02f));
	}

	public IEnumerator fear()
	{
		float decel = base.speed / 16f * 5f;
		float d = Random.Range(0.01f, 0.02f);
		while (decel >= 0f)
		{
			if (knockbacking)
			{
				yield return Wait(1);
			}
			rad += decel;
			decel -= d;
			yield return Wait(2);
		}
	}

	public override IEnumerator Movement()
	{
		if (knockbacking)
		{
			rad = Vector3.Distance(base.pos, base.player.pos);
			yield break;
		}
		float num = base.speed / 16f;
		rad -= num;
		base.transform.position = rad * new Vector3(Mathf.Cos(angle + t), Mathf.Sin(angle + t)) + base.player.pos;
		if (scatter)
		{
			t += accel * speedMult;
		}
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}
}
