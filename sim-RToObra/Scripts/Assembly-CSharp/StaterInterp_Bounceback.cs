using System;
using UnityEngine;

public class StaterInterp_Bounceback : StaterInterp
{
	private float perc;

	private int count;

	public StaterInterp_Bounceback(float perc_, int count_)
	{
		perc = perc_;
		count = count_;
	}

	public override float InterpImpl(float interp)
	{
		float num = Mathf.Floor(((float)count + 0.5f) * interp + 0.5f) / (float)(count + 1);
		float num2 = 1f / (float)(count + 1);
		float num3 = ((!(num < num2)) ? Mathf.Lerp(perc, 0f, num - num2) : 1f);
		return 1f - Mathf.Abs(Mathf.Cos(((float)count + 0.5f) * (float)Math.PI * interp)) * num3;
	}
}
