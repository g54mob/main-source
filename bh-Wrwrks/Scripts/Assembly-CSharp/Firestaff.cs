using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestaff : Weapon
{
	public GameObject proj;

	public int rings;

	private List<GameObject> currentBalls = new List<GameObject>();

	public override void CastSpell()
	{
		if (rings < 10)
		{
			base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Imp_Fire, 0.85f, 1.1f, 1f);
			int num = (base.UPGRADED ? 4 : 3);
			float rad = 2f + UnityEngine.Random.Range(-0.35f, 0.35f) + (base.UPGRADED ? 0.2f : 0f);
			List<GameObject> list = new List<GameObject>();
			int num2 = Utils.RandSign();
			for (int i = 0; i < num; i++)
			{
				Projectile component = UnityEngine.Object.Instantiate(proj).GetComponent<Projectile>();
				component.source = this;
				component.transform.localScale = Vector3.zero;
				base.animationManager.LerpZoom(component.gameObject, base.transform.localScale, 7f, 0.1f);
				base.animationManager.Spin(component.gameObject, num2 * 10);
				list.Add(component.gameObject);
			}
			StartCoroutine(spinner(list, num2, rad));
		}
	}

	private IEnumerator spinner(List<GameObject> balls, int dir, float rad)
	{
		float time = 90f;
		rings++;
		foreach (GameObject ball in balls)
		{
			currentBalls.Add(ball);
		}
		float offset = MathF.PI * 2f / (float)balls.Count;
		for (int t = 0; (float)t < time; t++)
		{
			float num = rad + 0.2f * Mathf.Sin((float)t * 0.1f);
			int num2 = ((base.dungeon.animationManager.gibCount >= 250) ? 6 : 2);
			for (int i = 0; i < balls.Count; i++)
			{
				balls[i].transform.position = base.transform.position + num * Utils.Dir((float)i * offset + (float)(t * dir) * 0.1f);
				if (t % num2 == 0)
				{
					base.animationManager.CreateFallingGibs(Utils.Rand("FF5000", "FFA214"), balls[i].transform.position, 1f, 0.15f, unmasked: false, 0.85f, -1f, oldStyle: true);
				}
			}
			yield return Dungeon.Wait(1);
		}
		rings--;
		foreach (GameObject ball2 in balls)
		{
			currentBalls.Remove(ball2);
			base.animationManager.LerpZoom(ball2, Vector3.zero, 5f, 0f, destroy: true);
		}
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
		foreach (GameObject currentBall in currentBalls)
		{
			UnityEngine.Object.Destroy(currentBall.gameObject);
		}
	}
}
