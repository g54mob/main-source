using System.Collections;

public class Triangle : Module
{
	public float angle = 90f;

	public float ratio = 0.5f;

	public float maxAmp = 4f;

	public float t;

	public int maxT = 2;

	public int x;

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
			t += ratio * base.accel;
			if (t >= (float)maxT)
			{
				t = 0f;
				x++;
				if (x == 3)
				{
					x = 0;
				}
			}
			yield return Dungeon.Wait(1);
		}
	}
}
