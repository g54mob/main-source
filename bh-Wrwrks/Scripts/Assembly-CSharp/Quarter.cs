using System;
using System.Collections;
using UnityEngine;

public class Quarter : Module
{
	public float angle = 90f;

	public float ratio = 0.5f;

	public float maxAmp = 4f;

	public float t;

	private int division
	{
		get
		{
			if (!UPGRADED)
			{
				return 4;
			}
			return 2;
		}
	}

	public override void SetDial(float x)
	{
		angle = 360f * x;
	}

	public override void SetSlider(float x)
	{
		ratio = 1f - x * 0.5f;
		base.amp = maxAmp * x;
	}

	public override IEnumerator Increment()
	{
		while (true)
		{
			t += base.accel * ratio * (float)damage;
			if (Mathf.Abs(t) > MathF.PI / (float)division)
			{
				damage *= -1;
			}
			yield return Dungeon.Wait(1);
		}
	}
}
