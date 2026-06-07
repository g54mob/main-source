using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Channel : Module
{
	private int t;

	private const float upgboost = 0.5f;

	public GameObject proj;

	private float x => 180f / (accelMult + (UPGRADED ? 0.5f : 0f));

	public override IEnumerator Increment()
	{
		while (true)
		{
			t++;
			if ((float)t >= x)
			{
				t = 0;
				StartCoroutine(Wave());
			}
			yield return Dungeon.Wait(1);
			while (!base.dungeon.combat || bankItem)
			{
				yield return Dungeon.Wait(1);
			}
		}
	}

	private IEnumerator Wave()
	{
		int num = 9;
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Beam, 0.85f, 1.15f, 1f);
		float time = 90f;
		List<GameObject> balls = new List<GameObject>();
		int dir = Utils.RandSign();
		for (int i = 0; i < num; i++)
		{
			Projectile component = UnityEngine.Object.Instantiate(proj).GetComponent<Projectile>();
			component.transform.position = base.dungeon.player.pos;
			component.transform.parent = base.transform;
			component.sourceModule = this;
			component.forceDamage = damage;
			component.sharedWeapon = true;
			base.dungeon.animationManager.Spin(component.gameObject, dir * 5);
			balls.Add(component.gameObject);
		}
		float offset = MathF.PI * 2f / (float)balls.Count;
		float r = 0f;
		float accel = 0.15f;
		float wave = 0.1f;
		for (int t = 0; (float)t < time; t++)
		{
			r += accel;
			for (int j = 0; j < balls.Count; j++)
			{
				balls[j].transform.position = base.dungeon.player.transform.position + r * Utils.Dir((float)j * offset + (float)(t * dir) * wave);
				if (t % 2 == 0)
				{
					base.dungeon.animationManager.CreateFallingGibs(Utils.Rand("0098DC", "00CDF9"), balls[j].transform.position, 1f, 0.15f, unmasked: false, 0.85f, -1f, oldStyle: true);
				}
			}
			yield return Dungeon.Wait(1);
		}
		foreach (GameObject item in balls)
		{
			base.dungeon.animationManager.LerpZoom(item, Vector3.zero, 5f, 0f, destroy: true);
		}
	}
}
