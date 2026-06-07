using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchstick : Module
{
	public GameObject fireballObj;

	public List<GameObject> currentBalls = new List<GameObject>();

	protected override void CastSpell()
	{
		bool flag = false;
		foreach (Module output in outputs)
		{
			if (output.weapon == null)
			{
				continue;
			}
			flag = true;
			switch (output.name)
			{
			case Name.Shuriken:
				foreach (GameObject projectile in output.weapon.GetComponent<Shuriken>().projectiles)
				{
					if (projectile != null)
					{
						StartCoroutine(FireOrbit(projectile.GetComponent<MonoBehaviour>()));
					}
				}
				break;
			case Name.Bow:
				foreach (GameObject projectile2 in output.weapon.GetComponent<Bow>().projectiles)
				{
					if (projectile2 != null)
					{
						StartCoroutine(FireOrbit(projectile2.GetComponent<MonoBehaviour>()));
					}
				}
				break;
			case Name.Bolt:
				foreach (GameObject projectile3 in output.weapon.GetComponent<Bolt>().projectiles)
				{
					if (projectile3 != null)
					{
						StartCoroutine(FireOrbit(projectile3.GetComponent<MonoBehaviour>()));
					}
				}
				break;
			case Name.Necromancy:
				if (output.weapon.GetComponent<Necromancy>().skeletonList.Count == 0)
				{
					break;
				}
				foreach (Necro_Skele skeleton in output.weapon.GetComponent<Necromancy>().skeletonList)
				{
					StartCoroutine(FireOrbit(skeleton));
				}
				break;
			default:
				StartCoroutine(FireOrbit(output.weapon));
				break;
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Imp_Fire, 0.85f, 1.1f, 1f);
		}
	}

	public IEnumerator FireOrbit(MonoBehaviour w)
	{
		int num = (UPGRADED ? 3 : 2);
		int dir = Utils.RandSign();
		List<GameObject> balls = new List<GameObject>();
		for (int i = 0; i < num; i++)
		{
			Projectile component = UnityEngine.Object.Instantiate(fireballObj).GetComponent<Projectile>();
			component.sourceModule = this;
			component.transform.localScale = Vector3.zero;
			base.dungeon.animationManager.LerpZoom(component.gameObject, base.transform.localScale, 7f, 0.1f);
			base.dungeon.animationManager.Spin(component.gameObject, dir * 10);
			balls.Add(component.gameObject);
		}
		float time = 90f;
		float rad = 1.5f + UnityEngine.Random.Range(-0.35f, 0.35f) + (UPGRADED ? 0.2f : 0f);
		foreach (GameObject item in balls)
		{
			currentBalls.Add(item);
		}
		float offset = MathF.PI * 2f / (float)balls.Count;
		for (int t = 0; (float)t < time; t++)
		{
			if (w == null)
			{
				break;
			}
			float num2 = rad + 0.2f * Mathf.Sin((float)t * 0.1f);
			for (int j = 0; j < balls.Count; j++)
			{
				if (!(balls[j] == null))
				{
					int num3 = ((base.dungeon.animationManager.gibCount >= 250) ? 6 : 2);
					balls[j].transform.position = w.transform.position + num2 * Utils.Dir((float)j * offset + (float)(t * dir) * 0.1f * accelMult);
					if (t % num3 == 0)
					{
						base.dungeon.animationManager.CreateFallingGibs(Utils.Rand("FF5000", "FFA214"), balls[j].transform.position, 1f, 0.15f, unmasked: false, 0.85f, -1f, oldStyle: true);
					}
				}
			}
			yield return Dungeon.Wait(1);
		}
		foreach (GameObject item2 in balls)
		{
			currentBalls.Remove(item2);
			base.dungeon.animationManager.LerpZoom(item2, Vector3.zero, 5f, 0f, destroy: true);
		}
	}

	private void OnDestroy()
	{
		foreach (GameObject currentBall in currentBalls)
		{
			UnityEngine.Object.Destroy(currentBall.gameObject);
		}
		currentBalls.Clear();
	}
}
