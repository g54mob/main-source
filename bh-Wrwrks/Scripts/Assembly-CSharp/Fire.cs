using System;
using System.Collections;
using UnityEngine;

public class Fire : Module
{
	public bool trigger;

	public GameObject arrow;

	public int particles;

	private int ticker
	{
		get
		{
			if (particles <= 150)
			{
				return 3;
			}
			return 15;
		}
	}

	public override IEnumerator Increment()
	{
		while (true)
		{
			counter++;
			trigger = counter >= ticker;
			if (trigger)
			{
				counter = 0;
			}
			yield return Dungeon.Wait(1);
		}
	}

	public void CreateFireParticle(MonoBehaviour source)
	{
		Projectile component = UnityEngine.Object.Instantiate(arrow).GetComponent<Projectile>();
		component.GetComponent<SpriteRenderer>().color = Utils.GetColor(Utils.Rand("FF5000", "FFC825", 75f));
		component.sourceModule = this;
		component.transform.localEulerAngles = base.transform.localEulerAngles + new Vector3(0f, 0f, 0f);
		component.transform.localScale = source.transform.localScale * 0.55f;
		float num = UnityEngine.Random.Range(-MathF.PI / 3f, MathF.PI / 3f);
		float num2 = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		Vector3 normalized = (source.transform.position + new Vector3(Mathf.Cos(num2), Mathf.Sin(num2)) - source.transform.position).normalized;
		component.transform.position = source.transform.position;
		float num3 = Mathf.Abs(num) / (MathF.PI / 3f) * 10f;
		if (UPGRADED)
		{
			num3 -= 15f;
		}
		base.dungeon.animationManager.Fade(component.gameObject, 2, 35 - (int)num3);
		base.dungeon.animationManager.MoveDir(component.gameObject, normalized, UnityEngine.Random.Range(0.005f, 0.01f));
		StartCoroutine(Spinner(component.gameObject));
	}

	private IEnumerator Spinner(GameObject p)
	{
		particles++;
		p.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		int d = Utils.RandSign();
		p.transform.localEulerAngles += new Vector3(0f, 0f, d);
		yield return Dungeon.Wait(7);
		if (p == null)
		{
			particles--;
			yield break;
		}
		p.transform.localEulerAngles += new Vector3(0f, 0f, d * 2);
		yield return Dungeon.Wait(3);
		if (p == null)
		{
			particles--;
			yield break;
		}
		p.transform.localEulerAngles = new Vector3(0f, 0f, d * 8);
		yield return Dungeon.Wait(7);
		if (p == null)
		{
			particles--;
			yield break;
		}
		do
		{
			p.transform.localEulerAngles = new Vector3(0f, 0f, -d * 8);
			yield return Dungeon.Wait(4);
			if (p == null)
			{
				particles--;
				yield break;
			}
			p.transform.localEulerAngles = new Vector3(0f, 0f, d * 8);
			yield return Dungeon.Wait(4);
		}
		while (!(p == null));
		particles--;
	}
}
