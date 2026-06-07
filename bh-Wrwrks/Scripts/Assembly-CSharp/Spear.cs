using System;
using System.Collections;
using UnityEngine;

public class Spear : Weapon
{
	public GameObject arrow;

	public int timer;

	public int shotIntervalFrames = 60;

	private bool anim;

	public float amp = 1f;

	public override void ProcessFrame()
	{
		int num = (owner.UPGRADED ? 20 : 15);
		float num2 = (owner.UPGRADED ? 0.175f : 0.15f);
		if (pos == Vector3.zero)
		{
			pos = new Vector3(1f, 0f);
		}
		if (!anim)
		{
			if (timer++ == shotIntervalFrames)
			{
				anim = true;
				timer = num * 2;
			}
		}
		else
		{
			if (timer == 0)
			{
				anim = false;
				timer = 0;
				amp = 1f;
			}
			if (timer > num)
			{
				amp += num2;
			}
			else
			{
				amp -= num2;
			}
			timer--;
		}
		Vector3 normalized = pos.normalized;
		base.transform.localPosition = normalized * amp;
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
}
