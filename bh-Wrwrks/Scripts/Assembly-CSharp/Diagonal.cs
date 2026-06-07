using System;
using System.Collections;

public class Diagonal : Module
{
	public float t;

	public float maxAmp = 4f;

	public float maxAccel = 0.2f;

	public float ratio = 0.5f;

	public float angle;

	public override void SetDial(float x)
	{
		angle = 360f * x;
	}

	public override IEnumerator Increment()
	{
		while (true)
		{
			t += base.accel * 0.5f;
			if (t > MathF.PI * 2f)
			{
				t -= MathF.PI * 2f;
			}
			yield return Dungeon.Wait(1);
		}
	}
}
