using System;
using System.Collections;
using UnityEngine;

public class Archer : Monster
{
	public GameObject projectile;

	public override void InitStats()
	{
		attackDistance = 3f;
	}

	public override IEnumerator Movement()
	{
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		float num = base.speed / 16f;
		base.pos += normalized * num;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	public override IEnumerator Attack()
	{
		yield return Wait(20);
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		base.animator.StopAnim();
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Bow_Shoot, 0.9f, 1.1f, 1f);
		ShootProjectile(projectile, 15, normalized, spin: false);
		yield return Wait(7);
		base.animator.StartAnim();
		float ang = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		float dist = Vector3.Distance(base.pos, base.player.pos);
		float jump = Utils.RandSign(UnityEngine.Random.Range(MathF.PI / 4f, MathF.PI * 2f / 5f));
		int time = 25;
		time = (int)((float)time / speedMult);
		for (int i = 0; i < time; i++)
		{
			float num = dist + 0.75f * Mathf.Sin(MathF.PI * (float)i / (float)time);
			ang += jump / (float)time;
			base.pos = base.player.pos + new Vector3(Mathf.Cos(ang), Mathf.Sin(ang)) * num;
			yield return Dungeon.Wait(1);
		}
		yield return Wait(20);
	}
}
