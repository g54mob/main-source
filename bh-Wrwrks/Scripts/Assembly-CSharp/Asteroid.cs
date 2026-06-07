using System;
using System.Collections;
using UnityEngine;

public class Asteroid : Monster
{
	public enum Size
	{
		Large = 0,
		Medium = 1,
		Small = 2
	}

	private int dir = 1;

	public float accel = 0.01f;

	public float limit = 5f;

	public float range = 1f;

	public int attackTime = 60;

	public float waveAccel = 0.045f;

	public Size size;

	public override void InitStats()
	{
		attackDistance = 1.4f;
		if (size == Size.Medium)
		{
			attackDistance = 0.85f;
		}
		else if (size == Size.Small)
		{
			attackDistance = 0.6f;
		}
		range += UnityEngine.Random.Range(-0.25f, 0.25f);
		limit += UnityEngine.Random.Range(-0.5f, 0.5f);
		base.spriteRenderer.flipX = Utils.RNG(50f);
		base.spriteRenderer.flipY = Utils.RNG(50f);
		dir = Utils.RandSign();
	}

	public override void HitEffect()
	{
	}

	public override IEnumerator Movement()
	{
		if (!knockbacking)
		{
			float num = Mathf.Atan2(base.transform.position.y - base.player.transform.position.y, base.transform.position.x - base.player.transform.position.x);
			float num2 = Vector3.Distance(base.transform.position, base.player.transform.position);
			num += (float)dir * accel * speedMult;
			num2 -= base.speed / 16f;
			base.transform.position = base.player.transform.position + Utils.Dir(num) * num2;
			yield return Wait(2);
		}
	}

	public void StartIntro()
	{
		StartCoroutine(_intro());
	}

	private IEnumerator _intro()
	{
		float dp = accel;
		accel += 0.03f;
		float op = accel;
		GetComponent<BoxCollider2D>().enabled = false;
		float frames = 20f;
		float oSpeed = base.speed;
		float dSpeed = (0f - base.speed) * 1.25f;
		for (float i = 0f; i < frames; i += 1f)
		{
			accel = Mathf.Lerp(op, dp, (i + 1f) / frames);
			base.speed = Mathf.Lerp(dSpeed, oSpeed, (i + 1f) / frames);
			if (i == 9f)
			{
				GetComponent<BoxCollider2D>().enabled = true;
			}
			yield return Wait(1);
		}
	}

	public override void DeathEffect()
	{
		if (size == Size.Large)
		{
			float num = Mathf.Atan2(base.pos.y - base.dungeon.player.pos.y, base.pos.x - base.dungeon.player.pos.x) * 180f / MathF.PI;
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Smash0, 0.9f, 1.1f, 1f);
			Asteroid component = base.dungeon.SpawnMonster(Type.Asteroid_M0).GetComponent<Asteroid>();
			Asteroid component2 = base.dungeon.SpawnMonster(Type.Asteroid_M1).GetComponent<Asteroid>();
			component.transform.position = base.transform.position + Utils.DirEuler(UnityEngine.Random.Range(-20f, 20f) - num);
			component2.transform.position = base.transform.position + Utils.DirEuler(180f + UnityEngine.Random.Range(-20f, 20f) - num);
			component.dir = ((component.pos.x > component2.pos.x) ? 1 : (-1));
			component.dir = -component2.dir;
			component2.StartIntro();
			component.StartIntro();
		}
		else if (size == Size.Medium)
		{
			float num2 = Mathf.Atan2(base.pos.y - base.dungeon.player.pos.y, base.pos.x - base.dungeon.player.pos.x) * 180f / MathF.PI;
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Smash1, 0.9f, 1.1f, 1f);
			Asteroid component3 = base.dungeon.SpawnMonster(Type.Asteroid_S).GetComponent<Asteroid>();
			Asteroid component4 = base.dungeon.SpawnMonster(Type.Asteroid_S).GetComponent<Asteroid>();
			component3.transform.position = base.transform.position + Utils.DirEuler(UnityEngine.Random.Range(-20f, 20f) - num2);
			component4.transform.position = base.transform.position + Utils.DirEuler(180f + UnityEngine.Random.Range(-20f, 20f) - num2);
			component3.dir = ((component3.pos.x > component4.pos.x) ? 1 : (-1));
			component3.dir = -component4.dir;
			component4.StartIntro();
			component3.StartIntro();
		}
	}

	public override IEnumerator Attack()
	{
		yield return Wait(1);
		base.player.Hurt(damage);
		AudioManager.Sound c = AudioManager.Sound.Smash0;
		if (size == Size.Medium)
		{
			c = AudioManager.Sound.Smash0;
		}
		else if (size == Size.Small)
		{
			c = AudioManager.Sound.Smash1;
		}
		base.dungeon.audioManager.PlaySoundRandomized(c, 0.9f, 1.1f, 1f);
		Hurt(health, null, noDeathrattle: true);
	}
}
