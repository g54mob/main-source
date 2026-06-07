using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_Soldier : Monster
{
	public GameObject projectile;

	private float rad = 9f;

	private float angle;

	private float t;

	private float last;

	public List<Sprite> baseAnim;

	public List<Sprite> fireAnim;

	public override void InitStats()
	{
		attackDistance = 2.25f;
	}

	public override void InitPosition(float presetAngle = -1f)
	{
		base.InitPosition(presetAngle);
		rad = Vector3.Distance(base.pos, base.player.pos);
		angle = Mathf.Atan2(base.pos.y - base.player.pos.y, base.pos.x - base.player.pos.x);
		last = base.pos.x;
	}

	public override IEnumerator Movement()
	{
		float num = base.speed / 16f;
		rad -= num;
		base.transform.position = rad * new Vector3(Mathf.Cos(angle + t), Mathf.Sin(angle + t)) + base.player.pos;
		t += 0.01f * speedMult;
		base.spriteRenderer.flipX = base.pos.x < base.player.pos.x;
		if (!(Vector3.Distance(base.pos, base.player.pos) <= attackDistance))
		{
			yield return Wait(2);
		}
	}

	public override IEnumerator Attack()
	{
		yield return Wait(15);
		Vector3 dir = (base.player.transform.position - base.transform.position).normalized;
		base.animator.StopAnim();
		ShootProjectile(projectile, 15, dir, spin: false);
		AudioManager.Sound c = Utils.RandElem(new List<AudioManager.Sound>
		{
			AudioManager.Sound.Underwater_Bubble_0,
			AudioManager.Sound.Underwater_Bubble_1,
			AudioManager.Sound.Underwater_Bubble_2
		});
		base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
		base.dungeon.audioManager.PlaySoundRandomized_Repeatable(c, 0.9f, 1.1f, 0.9f, 0.9f);
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Enemy_Slash, 0.9f, 1.1f, 0.9f, 0.9f);
		float dist = 0.25f;
		base.transform.position += dir * dist;
		base.animator.CustomAnim(fireAnim, base.animator.fps, oneshot: false, base.animator.currFrame);
		for (int i = 0; i < 4; i++)
		{
			base.transform.position += dir * (0f - dist) / 4f;
			yield return Wait(2);
		}
		base.animator.CustomAnim(baseAnim, base.animator.fps, oneshot: false, base.animator.currFrame);
		yield return Wait(40);
	}
}
