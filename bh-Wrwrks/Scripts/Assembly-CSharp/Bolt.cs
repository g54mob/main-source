using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : Weapon
{
	private Vector3 targetPos = Vector3.zero;

	private Monster m;

	private Vector3 p = Vector3.zero;

	public GameObject arrow;

	public List<GameObject> projectiles = new List<GameObject>();

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	public override void ProcessFrame()
	{
		if (targetPos == Vector3.zero)
		{
			targetPos = new Vector3(1f, 0f);
		}
		new Vector3(1f, 0f);
		if (base.dungeon.livingEnemies.Count != 0 && m == null)
		{
			m = Utils.RandElem(base.dungeon.livingEnemies);
		}
		if (m != null)
		{
			targetPos = Vector3.Lerp(targetPos, m.transform.position - base.player.transform.position, 0.125f + 0.025f * owner.manaRegen);
		}
		else
		{
			targetPos = Vector3.Lerp(targetPos, new Vector3(1f, 0f), 0.15f);
		}
		Vector3 normalized = targetPos.normalized;
		base.transform.localPosition = normalized * 1f;
		base.transform.localScale = scale;
	}

	public override void HitTrigger(Monster monster)
	{
		if (m == monster)
		{
			m = null;
		}
	}

	public override void CastSpell()
	{
		Projectile component = UnityEngine.Object.Instantiate(arrow).GetComponent<Projectile>();
		component.source = this;
		component.forceDamage = base.damage;
		component.transform.localEulerAngles = base.transform.localEulerAngles;
		component.transform.localScale = base.transform.localScale;
		float f = (base.transform.localEulerAngles.z + 90f) * MathF.PI / 180f;
		Vector3 normalized = (base.transform.position + new Vector3(Mathf.Cos(f), Mathf.Sin(f)) - base.transform.position).normalized;
		component.transform.position = base.transform.position;
		owner.dungeon.animationManager.MoveDir(component.gameObject, normalized, 0.4f);
		owner.dungeon.animationManager.Fade(component.gameObject, 3, 40);
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Magic_Bolt, 0.9f, 1.1f, 0.75f, 0.75f);
		projectiles.Add(component.gameObject);
		StartCoroutine(remover(component.gameObject));
	}

	private IEnumerator remover(GameObject p)
	{
		yield return Dungeon.Wait(31);
		projectiles.Remove(p);
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
		foreach (GameObject projectile2 in projectiles)
		{
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
			Projectile projectile = base.dungeon.animationManager.CreateExplosion("FFA214", "FFC825", 10, insta: true);
			projectile.sourceModule = component;
			projectile.transform.position = projectile2.transform.position;
			projectile.transform.localScale = projectile2.transform.localScale * 1.2f;
		}
	}
}
