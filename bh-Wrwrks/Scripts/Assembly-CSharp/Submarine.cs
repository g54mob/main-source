using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : Monster
{
	private float t;

	private float rad = 4f;

	private int attackTimer = 40;

	private int f;

	private bool firstFrame;

	private float angle;

	private float r;

	private float t2;

	private int dir = 1;

	public GameObject proj;

	public override void InitStats()
	{
		base.InitStats();
		rad = Random.Range(3f, 4f);
		dir = ((base.player.pos.x < base.pos.x) ? 1 : (-1));
	}

	public override void HitEffect()
	{
	}

	public override IEnumerator Movement()
	{
		if (knockbacking)
		{
			firstFrame = false;
			t = 0f;
			r = rad;
			t2 = 0f;
			angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		}
		else if (firstFrame)
		{
			f++;
			base.transform.position = r * new Vector3(Mathf.Cos(angle + t), Mathf.Sin(angle + t)) + base.player.pos;
			r = rad + 0.5f * Mathf.Sin(t2);
			base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
			t += 0.02f * speedMult;
			t2 += 0.1f * speedMult;
			if (f == attackTimer)
			{
				Vector3 normalized = (base.player.transform.position - base.transform.position).normalized;
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Rocket, 0.85f, 0.6f);
				AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
				{
					AudioManager.Sound.Underwater_Bubble_0,
					AudioManager.Sound.Underwater_Bubble_1,
					AudioManager.Sound.Underwater_Bubble_2
				});
				base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
				base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
				base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
				ShootProjectile(proj, 15, normalized, spin: false);
				f = 0;
			}
			yield return Wait(2);
		}
		else if (Vector3.Distance(base.pos, base.player.pos) > rad)
		{
			Vector3 normalized2 = (base.player.transform.position - base.transform.position).normalized;
			base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
			float num = base.speed / 16f;
			base.pos += normalized2 * num + 0.01f * new Vector3(0f, Mathf.Sin(t));
			t += 0.1f * speedMult;
			if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
			{
				yield return Wait(2);
			}
		}
		else if (!firstFrame)
		{
			firstFrame = true;
			t = 0f;
			r = rad;
			angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		}
	}
}
