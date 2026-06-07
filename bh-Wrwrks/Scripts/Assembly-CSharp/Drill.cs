using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : Monster
{
	public List<Sprite> vertAnim;

	public override void InitPosition(float presetAngle = -1f)
	{
		presetAngle = Utils.RandElem(new List<float>
		{
			0f,
			MathF.PI / 2f,
			MathF.PI,
			4.712389f
		});
		if (presetAngle == MathF.PI / 2f || presetAngle == 4.712389f)
		{
			StartCoroutine(animchange());
			GetComponent<BoxCollider2D>().size = new Vector2(0.8125f, 1.0625f);
			if (presetAngle == 4.712389f)
			{
				base.spriteRenderer.flipY = true;
			}
		}
		base.InitPosition(presetAngle);
	}

	public IEnumerator animchange()
	{
		yield return Wait(1);
		base.animator.CustomAnim(vertAnim, base.animator.fps);
	}

	public override IEnumerator Attack()
	{
		Vector3 dir = (base.player.transform.position - base.transform.position).normalized;
		float dist = 0.25f;
		base.transform.position += dir * dist;
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Drill, 0.9f, 1.1f, 1f);
		for (int i = 0; i < 3; i++)
		{
			base.player.Hurt(damage);
			yield return Wait(10);
		}
		for (int i = 0; i < 4; i++)
		{
			base.transform.position += dir * (0f - dist) / 4f;
			yield return Wait(2);
		}
		yield return Wait(10);
	}
}
