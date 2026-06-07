using System;
using System.Collections;
using UnityEngine;

public class Horizontal : Module
{
	public float t;

	public float maxAmp = 4f;

	public float maxAccel = 0.2f;

	public float ratio = 0.5f;

	public float x;

	public int dir = 1;

	public override void ResetPhase()
	{
		t = 0f;
	}

	public override void SetSlider(float x)
	{
		ratio = 1f - x * 0.5f;
		base.amp = maxAmp * x;
	}

	public override void SetDial(float x)
	{
		_ = base.accel;
		base.accel = maxAccel * x;
	}

	public override IEnumerator Increment()
	{
		while (true)
		{
			switch (name)
			{
			case Name.Wave:
				t += base.accel * ratio;
				if (t > MathF.PI * 2f)
				{
					t -= MathF.PI * 2f;
				}
				x += base.accel * ratio * (float)dir;
				if (Mathf.Abs(x) > MathF.PI * 2f)
				{
					dir *= -1;
				}
				break;
			case Name.Spiral:
				t += 0.1f;
				x += base.accel * 0.33f * 0.66f;
				if (t > MathF.PI * 2f)
				{
					t -= MathF.PI * 2f;
				}
				if (x > MathF.PI * 2f)
				{
					x -= MathF.PI * 2f;
				}
				break;
			default:
				if (base.WEAPON)
				{
					yield break;
				}
				t += base.accel * ratio;
				if (t > MathF.PI * 2f)
				{
					t -= MathF.PI * 2f;
				}
				break;
			}
			yield return Dungeon.Wait(1);
		}
	}
}
