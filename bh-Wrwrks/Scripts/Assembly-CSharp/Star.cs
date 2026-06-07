using System;
using System.Collections;

public class Star : Module
{
	public float angle = 90f;

	public float ratio = 0.5f;

	public float maxAmp = 4f;

	public float t;

	public float x = 0.5f;

	public int wing;

	public float points => UPGRADED ? 7 : 6;

	private float internalAccel
	{
		get
		{
			if (!UPGRADED)
			{
				return 0.1f;
			}
			return 0.125f;
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
			if (base.amp == 0f)
			{
				x = 0f;
				yield return Dungeon.Wait(1);
				continue;
			}
			t += internalAccel;
			x += base.accel * (float)counter;
			if (t > MathF.PI * 2f)
			{
				t -= MathF.PI * 2f;
			}
			if (x >= base.amp)
			{
				counter = -1;
			}
			if (x < 0f)
			{
				counter = 1;
				wing++;
				if ((float)wing == points)
				{
					wing = 0;
				}
			}
			yield return Dungeon.Wait(1);
		}
	}
}
