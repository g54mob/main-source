using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : Monster
{
	public GameObject charger;

	public override void InitStats()
	{
		attackDistance = 4f;
	}

	public override void InitPosition(float presetAngle = -1f)
	{
		presetAngle = (float)Utils.RandSign() * (MathF.PI / 180f * (float)(UnityEngine.Random.Range(-30, 30) + Utils.Rand(0, 180)));
		base.InitPosition(presetAngle);
		StartCoroutine(floatAnim());
	}

	private IEnumerator floatAnim()
	{
		float t = 0f;
		while (true)
		{
			base.pos += new Vector3(Mathf.Cos(t), Mathf.Sin(t)) * -0.1f / 16f;
			t += 0.05f;
			yield return Wait(1);
		}
	}

	public override IEnumerator Attack()
	{
		float chargeFrames = 120f;
		charger.transform.localPosition = new Vector3(-0.9f * (float)((!base.spriteRenderer.flipX) ? 1 : (-1)), 1f / 32f);
		base.dungeon.animationManager.Spin(charger, -10f, (int)chargeFrames + 10);
		for (float i = 0f; i < chargeFrames; i += 1f)
		{
			if (i == 0f)
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Laser_Charge, 2f);
			}
			if (i == (float)(int)(chargeFrames * 0.5f))
			{
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Laser_Charge, 2f);
			}
			charger.transform.localScale = Vector3.Lerp(Vector3.one * 0.25f, Vector3.one * 0.75f, (i + 1f) / chargeFrames);
			yield return Wait(1);
		}
		charger.transform.localScale = Vector3.zero;
		List<Vector3> points = new List<Vector3>
		{
			charger.transform.position,
			base.player.pos
		};
		base.dungeon.animationManager.CreateLaser(points, "EA323C", 0.25f);
		base.dungeon.animationManager.CreateDust(base.player.pos, "EA323C", 5, 0.65f);
		base.dungeon.player.Hurt(damage);
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser);
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser, 1.5f);
		base.dungeon.audioManager.PlaySound_Repeatable(AudioManager.Sound.Laser, 0.5f);
		yield return Wait(120);
	}
}
