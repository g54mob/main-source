using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : Weapon
{
	public List<GameObject> balls;

	private bool trig;

	public List<GameObject> projectiles = new List<GameObject>();

	private void OnDestroy()
	{
		foreach (GameObject projectile in projectiles)
		{
			UnityEngine.Object.Destroy(projectile.gameObject);
		}
	}

	public override void CastSpell()
	{
		if (!trig)
		{
			trig = true;
			Vector3 position = base.transform.position;
			int num = (base.UPGRADED ? 9 : 6);
			float num2 = UnityEngine.Random.Range(0f, 360f);
			base.dungeon.audioManager.PlayModSound(owner, 0.85f);
			for (int i = 0; i < num; i++)
			{
				float f = num2 * MathF.PI / 180f;
				Vector3 vector = position + new Vector3(Mathf.Cos(f), Mathf.Sin(f));
				vector = (vector - position).normalized;
				GameObject gameObject = UnityEngine.Object.Instantiate(balls[i % 4]);
				projectiles.Add(gameObject);
				Projectile component = gameObject.GetComponent<Projectile>();
				component.source = this;
				component.transform.position = position;
				component.transform.localScale = base.transform.localScale;
				StartCoroutine(bouncer(gameObject, vector));
				float num3 = 360f / (float)num;
				num2 += UnityEngine.Random.Range(num3 - 15f, num3 + 15f);
			}
		}
	}

	public override void ProcessFrame()
	{
		trig = false;
		base.ProcessFrame();
	}

	private void sfx()
	{
		base.dungeon.audioManager.PlaySoundRandomized(Utils.Rand(AudioManager.Sound.Boing0, AudioManager.Sound.Boing1), 0.9f, 1.1f, 1f);
	}

	private IEnumerator bouncer(GameObject g, Vector3 dir)
	{
		int frames = UnityEngine.Random.Range(30, 50);
		float dist = UnityEngine.Random.Range(1.5f, 2f);
		base.animationManager.TossEffect(g, g.transform.position + dir * dist, frames, destroy: false, 2f);
		yield return Wait(frames);
		if (g == null)
		{
			projectiles.Remove(g);
			yield break;
		}
		dist *= 0.9f;
		frames = (int)((float)frames * 0.75f);
		base.animationManager.TossEffect(g, g.transform.position + dir * dist, frames, destroy: false, 1.5f);
		sfx();
		yield return Wait(frames);
		if (g == null)
		{
			projectiles.Remove(g);
			yield break;
		}
		dist *= 0.9f;
		frames = (int)((float)frames * 0.75f);
		base.animationManager.TossEffect(g, g.transform.position + dir * dist, frames, destroy: true, 1.125f);
		sfx();
		g.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.5f);
		yield return Wait(5);
		if (g == null)
		{
			projectiles.Remove(g);
			yield break;
		}
		g.GetComponent<SpriteRenderer>().enabled = true;
		g.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, 0.5f);
		yield return Wait(10);
		if (g == null)
		{
			projectiles.Remove(g);
			yield break;
		}
		g.GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, -0.5f);
		projectiles.Remove(g);
	}

	public override void Fire()
	{
		Fire component = currentModule.GetComponent<Fire>();
		List<GameObject> list = new List<GameObject>();
		if (component.trigger)
		{
			foreach (GameObject projectile in projectiles)
			{
				if (projectile == null)
				{
					list.Add(projectile);
				}
				else
				{
					component.CreateFireParticle(projectile.GetComponent<Projectile>());
				}
			}
		}
		foreach (GameObject item in list)
		{
			projectiles.Remove(item);
		}
	}

	public override void Capacitor()
	{
		Capacitor component = currentModule.GetComponent<Capacitor>();
		if (component.t != 0)
		{
			return;
		}
		List<GameObject> list = new List<GameObject>();
		foreach (GameObject projectile2 in projectiles)
		{
			if (projectile2 == null)
			{
				list.Add(projectile2);
				continue;
			}
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
			Projectile projectile = base.dungeon.animationManager.CreateExplosion("FFA214", "FFC825", 10, insta: true);
			projectile.sourceModule = component;
			projectile.transform.position = projectile2.transform.position;
			projectile.transform.localScale = projectile2.transform.localScale * 1.2f;
		}
		foreach (GameObject item in list)
		{
			projectiles.Remove(item);
		}
	}
}
