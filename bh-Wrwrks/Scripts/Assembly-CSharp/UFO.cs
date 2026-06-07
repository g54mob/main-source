using System;
using System.Collections;
using UnityEngine;

public class UFO : Monster
{
	private int dir = 1;

	private bool reached;

	public float accel = 0.01f;

	public float limit = 5f;

	public float range = 1f;

	private int timer = 30;

	public int attackTime = 60;

	public float waveAccel = 0.045f;

	private float angle;

	public GameObject projectile;

	public override void InitStats()
	{
		base.InitStats();
		range += UnityEngine.Random.Range(-0.25f, 0.25f);
		limit += UnityEngine.Random.Range(-0.5f, 0.5f);
		angle = Mathf.Atan2(base.transform.position.y - base.player.transform.position.y, base.transform.position.x - base.player.transform.position.x);
		dir = Utils.RandSign();
	}

	public override void HitEffect()
	{
	}

	public override IEnumerator Movement()
	{
		if (knockbacking)
		{
			reached = false;
			yield break;
		}
		float num = Vector3.Distance(base.transform.position, base.player.transform.position);
		if (reached)
		{
			_ = limit + 0.1f;
		}
		if (num >= limit && !reached)
		{
			num -= base.speed / 16f;
		}
		else
		{
			reached = true;
		}
		if (reached)
		{
			float num2 = limit - 1f;
			Vector3 vector = new Vector3(limit * Mathf.Cos(angle), limit * Mathf.Sin(angle));
			vector = new Vector3(Mathf.Clamp(vector.x, 0f - num2, num2), Mathf.Clamp(vector.y, 0f - num2, num2));
			angle += (float)dir * accel * speedMult;
			base.transform.position = Vector3.Lerp(base.transform.position, base.player.transform.position + vector, 0.25f);
			if (timer <= 0 && (int)(Mathf.Abs(angle) * 180f / MathF.PI % 90f) < 10)
			{
				Shoot();
				timer = (int)((float)attackTime * speedMult);
			}
			else
			{
				timer--;
			}
		}
		else
		{
			base.transform.position = base.player.transform.position + Utils.Dir(angle) * num;
		}
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		yield return Wait(2);
	}

	private void Shoot()
	{
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser);
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		ShootProjectile(projectile, 15, normalized, spin: false);
	}
}
