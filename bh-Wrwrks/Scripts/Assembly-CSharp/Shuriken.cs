using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Weapon
{
	public GameObject arrow;

	private int timer;

	public int shotIntervalFrames = 60;

	public List<GameObject> projectiles = new List<GameObject>();

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	private void ShootArrow()
	{
		float t = owner.amp / owner.GetComponent<Horizontal>().maxAmp;
		float num = Mathf.Lerp(5f, 25f, t);
		int num2 = 3;
		int num3 = 0;
		if (owner.UPGRADED)
		{
			num2 = 4;
			num3 = 1;
		}
		for (int i = 0; i < num2; i++)
		{
			Projectile component = UnityEngine.Object.Instantiate(arrow).GetComponent<Projectile>();
			component.source = this;
			component.transform.position = base.transform.position;
			component.transform.localEulerAngles = base.transform.localEulerAngles;
			component.transform.localScale = base.transform.localScale;
			float f = (base.transform.localEulerAngles.z + 90f + (float)(-num3) * num / 4f - num + num / (float)(num2 - 2) * (float)(i + num3)) * MathF.PI / 180f;
			Vector3 normalized = (base.transform.position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) - base.transform.position).normalized;
			owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.25f);
			owner.dungeon.animationManager.Spin(component.gameObject, (normalized.x > 0f) ? (-10) : 10);
			owner.dungeon.animationManager.Fade(component.gameObject, 3, 40);
			projectiles.Add(component.gameObject);
			StartCoroutine(remover(component.gameObject));
		}
	}

	private IEnumerator remover(GameObject p)
	{
		yield return Dungeon.Wait(31);
		projectiles.Remove(p);
	}

	public override void ProcessFrame()
	{
		if (timer++ == shotIntervalFrames)
		{
			timer = 0;
			ShootArrow();
		}
		Vector3 normalized = pos.normalized;
		base.transform.localPosition = normalized * Mathf.Min(pos.magnitude, 1f);
		base.transform.localScale = scale;
	}

	public override IEnumerator Spin()
	{
		_ = base.transform.position;
		_ = base.transform.localEulerAngles;
		while (true)
		{
			float num = Mathf.Atan2(base.transform.position.y - base.transform.parent.position.y, base.transform.position.x - base.transform.parent.position.x);
			num -= MathF.PI / 2f;
			num *= 180f / MathF.PI;
			base.transform.localEulerAngles = new Vector3(0f, 0f, num);
			yield return Wait(1);
		}
	}

	public override void Fire()
	{
		Fire component = currentModule.GetComponent<Fire>();
		if (!component.trigger)
		{
			return;
		}
		foreach (GameObject projectile in projectiles)
		{
			component.CreateFireParticle(projectile.GetComponent<Projectile>());
		}
	}

	public override void Capacitor()
	{
		Capacitor component = currentModule.GetComponent<Capacitor>();
		if (component.t != 0)
		{
			return;
		}
		base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
		foreach (GameObject projectile2 in projectiles)
		{
			Projectile projectile = base.dungeon.animationManager.CreateExplosion("FFA214", "FFC825", 10, insta: true);
			projectile.sourceModule = component;
			projectile.transform.position = projectile2.transform.position;
			projectile.transform.localScale = projectile2.transform.localScale * 1.2f;
		}
	}
}
