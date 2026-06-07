using System;
using System.Collections;
using UnityEngine;

public class Fish : Weapon
{
	private bool init;

	private float a;

	private float b;

	private float t;

	private float t2;

	private float t3;

	public override void ProcessFrame()
	{
		if (!init)
		{
			a += UnityEngine.Random.Range(-0.25f, 0.25f);
			b += UnityEngine.Random.Range(-0.25f, 0.25f);
			init = true;
		}
		t += 0.15f * owner.accelMult;
		t2 += 0.06f * owner.accelMult;
		t3 += 0.0075f * owner.accelMult;
		base.transform.localPosition = new Vector3(Mathf.Sin(t2) * (4f + a), Mathf.Sin(t) * 0.5f + Mathf.Sin(t3) * (3f + b));
		if (t > MathF.PI * 2f)
		{
			t -= MathF.PI * 2f;
		}
		if (t2 > MathF.PI * 2f)
		{
			t2 -= MathF.PI * 2f;
		}
		if (t3 > MathF.PI * 2f)
		{
			t2 -= MathF.PI * 2f;
		}
	}

	public override IEnumerator Spin()
	{
		Vector3 OP = base.transform.position;
		float lastAng = base.transform.localEulerAngles.z;
		while (true)
		{
			GetComponent<SpriteRenderer>().flipX = base.transform.position.x < OP.x;
			float num = Weapon.PointTo(OP, base.transform.position, 90f);
			if (Mathf.Abs(lastAng + 360f - num) < Mathf.Abs(lastAng - num))
			{
				lastAng += 360f;
			}
			else if (Mathf.Abs(lastAng - 360f - num) < Mathf.Abs(lastAng - num))
			{
				lastAng -= 360f;
			}
			if (Mathf.Abs(num - lastAng) >= 1f)
			{
				num = Mathf.Lerp(lastAng, num, 0.2f);
			}
			base.transform.localEulerAngles = new Vector3(0f, 0f, num);
			lastAng = num;
			OP = base.transform.position;
			yield return Dungeon.Wait(1);
		}
	}
}
