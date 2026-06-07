using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancy : Weapon
{
	private float t;

	public GameObject skeletonObj;

	public List<Necro_Skele> skeletonList = new List<Necro_Skele>();

	public override void ProjectileHit(Monster monster)
	{
		Hit(monster);
	}

	public override void CastSpell()
	{
		if (skeletonList.Count < 100)
		{
			Necro_Skele component = UnityEngine.Object.Instantiate(skeletonObj).GetComponent<Necro_Skele>();
			Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.RandomBoneSound, 0.9f, 1.1f, 1f);
			component.source = this;
			component.transform.position = base.transform.position;
			component.transform.localScale = Vector3.zero;
			base.animationManager.LerpZoom(component.gameObject, Vector3.one, 15f);
			component.StartPathing();
			skeletonList.Add(component);
		}
	}

	public void KillSkeletons()
	{
		foreach (Necro_Skele skeleton in skeletonList)
		{
			Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.RandomBoneSound, 0.9f, 1.1f, 1f);
			skeleton.Death();
		}
		skeletonList.Clear();
	}

	public override void ProcessFrame()
	{
		base.transform.localPosition = new Vector3(Mathf.Cos(t), Mathf.Sin(t));
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

	public override void Fire()
	{
		Fire component = currentModule.GetComponent<Fire>();
		List<Necro_Skele> list = new List<Necro_Skele>();
		if (component.trigger)
		{
			foreach (Necro_Skele skeleton in skeletonList)
			{
				if (skeleton == null)
				{
					list.Add(skeleton);
				}
				else
				{
					component.CreateFireParticle(skeleton);
				}
			}
		}
		foreach (Necro_Skele item in list)
		{
			skeletonList.Remove(item);
		}
	}

	public override void Capacitor()
	{
		Capacitor component = currentModule.GetComponent<Capacitor>();
		if (component.t != 0)
		{
			return;
		}
		List<Necro_Skele> list = new List<Necro_Skele>();
		foreach (Necro_Skele skeleton in skeletonList)
		{
			if (skeleton == null)
			{
				list.Add(skeleton);
				continue;
			}
			base.dungeon.audioManager.PlaySound(AudioManager.Sound.Explosion_Electric);
			Projectile projectile = base.dungeon.animationManager.CreateExplosion("FFA214", "FFC825", 10, insta: true);
			projectile.sourceModule = component;
			projectile.transform.position = skeleton.transform.position;
			projectile.transform.localScale = skeleton.transform.localScale * 1.2f;
		}
		foreach (Necro_Skele item in list)
		{
			skeletonList.Remove(item);
		}
	}
}
