using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Monster
{
	private float burst;

	private float timer = 10f;

	private const float baseTime = 30f;

	public List<Sprite> upSprites;

	public List<Sprite> downSprites;

	private float startSpeed => base.speed / 16f * 5f;

	public override void InitStats()
	{
		base.InitStats();
		burst = startSpeed;
		timer = 30f;
	}

	public override IEnumerator Movement()
	{
		if (timer > 0f)
		{
			timer -= 1f;
			if (timer == 10f)
			{
				base.animator.CustomAnim(downSprites, 6f);
			}
			if (timer == 0f)
			{
				burst = startSpeed;
				base.animator.CustomAnim(upSprites, 6f);
			}
			yield return Wait(1);
			yield break;
		}
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		base.pos += normalized * burst;
		burst -= 0.01f;
		if (burst <= 0f)
		{
			burst = 0f;
			timer = 30f;
		}
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	public override IEnumerator Attack()
	{
		_ = base.transform.position;
		Vector3 dir = (base.player.transform.position - base.transform.position).normalized;
		base.player.Hurt(damage);
		float dist = 0.25f;
		base.transform.position += dir * dist;
		base.animator.CustomAnim(upSprites, 6f);
		for (int i = 0; i < 4; i++)
		{
			base.transform.position += dir * (0f - dist) / 4f;
			yield return Wait(2);
		}
		yield return Wait(30);
		base.animator.CustomAnim(downSprites, 6f);
		yield return Wait(10);
	}
}
