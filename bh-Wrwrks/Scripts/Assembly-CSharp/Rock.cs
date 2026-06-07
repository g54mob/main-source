using System;
using System.Collections;
using UnityEngine;

public class Rock : Weapon
{
	public GameObject[] pebbleObjs;

	public override void HitTrigger(Monster monster)
	{
		if (Utils.RNG(owner.UPGRADED ? 60 : 30))
		{
			pebs();
		}
	}

	public override void KillTrigger(Monster monster)
	{
	}

	private void pebs()
	{
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Rocks, 0.9f, 1.1f, 1f);
		for (int i = 0; i < 8; i++)
		{
			Projectile component = UnityEngine.Object.Instantiate(Utils.RandElem(pebbleObjs)).GetComponent<Projectile>();
			component.source = this;
			component.damage = ((!owner.UPGRADED) ? 1 : 2);
			component.transform.position = base.transform.position;
			float f = (float)(i * 2) * MathF.PI / 8f + UnityEngine.Random.Range(-MathF.PI / 9f, MathF.PI / 9f);
			Vector3 vector = new Vector3(Mathf.Cos(f), Mathf.Sin(f));
			float num = UnityEngine.Random.Range(2f, 3f);
			owner.dungeon.animationManager.TossEffect(component.gameObject, component.transform.position + num * vector, 30);
		}
	}

	public IEnumerator pebMotion(GameObject p, int ind, float off)
	{
		float randAng = off + (float)(ind * 2) * MathF.PI / 8f + base.transform.localEulerAngles.z * MathF.PI / 180f;
		int i = 0;
		float v = 0.2f + UnityEngine.Random.Range(0f, 0.2f);
		do
		{
			if (p == null)
			{
				yield break;
			}
			p.transform.position += v * new Vector3(Mathf.Cos(randAng), Mathf.Sin(randAng));
			v -= 0.00075f;
			v = Mathf.Max(0.1f, v);
			yield return Wait(1);
		}
		while (i++ <= 300);
		UnityEngine.Object.Destroy(p.gameObject);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			KillTrigger(null);
		}
	}
}
