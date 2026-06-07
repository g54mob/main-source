using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : Weapon
{
	private float t;

	private int timer = 60;

	private int f;

	private bool init;

	private int attackTime => (int)(60f / owner.accelMult);

	public void BeamMonster()
	{
		if (f <= 0)
		{
			f = 1;
			if (base.dungeon.livingEnemies.Count > 0)
			{
				Monster closestMonster = base.dungeon.GetClosestMonster(base.transform.position);
				List<Vector3> points = new List<Vector3>
				{
					base.transform.position,
					closestMonster.transform.position
				};
				base.dungeon.animationManager.CreateLaser(points, "33984B", 0.25f);
				base.dungeon.animationManager.CreateGibs("33984B", closestMonster.transform.position, 8f, 0.66f);
				Projectile projectile = Dungeon.Instance.animationManager.CreateExplosion("33984B", "33984B", 10, insta: true);
				projectile.source = this;
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Small);
				base.dungeon.audioManager.PlaySound(AudioManager.Sound.Monitor);
				projectile.transform.position = closestMonster.transform.position;
				projectile.transform.localScale = scale + Vector3.one * 0.25f;
			}
		}
	}

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	public override void ProcessFrame()
	{
		if (!init)
		{
			t = UnityEngine.Random.Range(0f, MathF.PI * 2f);
			init = true;
		}
		if (f > 0)
		{
			f--;
		}
		timer--;
		if (timer == 0)
		{
			BeamMonster();
			timer = attackTime;
		}
		base.transform.localPosition = 1.5f * new Vector3(Mathf.Cos(t), Mathf.Sin(t));
		t += 0.01f;
		base.transform.localScale = Vector3.one;
		if (t >= MathF.PI * 2f)
		{
			t = 0f;
		}
	}

	public override IEnumerator Spin()
	{
		Vector3 last = pos;
		while (true)
		{
			float x = base.transform.position.x;
			float x2 = last.x;
			float z = (0f - Mathf.Clamp(x - x2, -2f, 2f)) * 90f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, z);
			last = base.transform.position;
			yield return null;
		}
	}
}
