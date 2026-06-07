using System.Collections;
using UnityEngine;

public class Rocketeer : Monster
{
	private int dir = 1;

	private bool reached;

	public float accel = 0.01f;

	private float t;

	public float limit = 5f;

	public float range = 1f;

	private int timer = 30;

	public int attackTime = 60;

	public float waveAccel = 0.045f;

	public GameObject projectile;

	public override void InitStats()
	{
		base.InitStats();
		range += Random.Range(-0.25f, 0.25f);
		limit += Random.Range(-0.5f, 0.5f);
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
			t = 0f;
			yield break;
		}
		float num = Mathf.Atan2(base.transform.position.y - base.player.transform.position.y, base.transform.position.x - base.player.transform.position.x);
		float num2 = Vector3.Distance(base.transform.position, base.player.transform.position);
		num += (float)dir * accel * speedMult;
		if (reached && num2 >= limit + range)
		{
			reached = false;
			t = 0f;
		}
		if (num2 >= limit && !reached)
		{
			num2 -= base.speed / 16f;
		}
		else
		{
			reached = true;
		}
		if (reached)
		{
			num2 = limit - range * Mathf.Sin(t);
			t += waveAccel * speedMult;
			if (timer <= 0 && num2 < limit - 0.5f * range)
			{
				Shoot();
				timer = (int)((float)attackTime * speedMult);
			}
			else
			{
				timer--;
			}
		}
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		base.transform.position = base.player.transform.position + Utils.Dir(num) * num2;
		yield return Wait(2);
	}

	private void Shoot()
	{
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser);
		Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
		ShootProjectile(projectile, 15, normalized, spin: false);
	}
}
