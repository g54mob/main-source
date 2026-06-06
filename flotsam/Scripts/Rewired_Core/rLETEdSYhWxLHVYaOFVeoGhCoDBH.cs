using UnityEngine;

internal static class rLETEdSYhWxLHVYaOFVeoGhCoDBH
{
	private static int qIYgBwSuoVmKbziCOlvCHYOrjDwM;

	private static int JHJJuRHXwsCJNwwZLWijUcajrkAE;

	private static double[] yafuXUgUOnRpzdLLIrdFYiQnoahm;

	private static int baRoMBxhkVhuSlyVyZyZtbtEgGvf;

	private static double gmkGAYpylQCrwpDOJecvZFfRzEDB;

	private static int mdwgBEbehQckBPkwTAWXshUJEgoMA;

	public static double rgGKXanYIOdPWNFfEKAZMHjYpYgs => gmkGAYpylQCrwpDOJecvZFfRzEDB;

	public static int cchffurDXgzVdRLxOybXaMlLzJCF
	{
		get
		{
			return qIYgBwSuoVmKbziCOlvCHYOrjDwM;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != qIYgBwSuoVmKbziCOlvCHYOrjDwM)
			{
				qIYgBwSuoVmKbziCOlvCHYOrjDwM = num;
				oNviCFwPeEOzGRomXURsHiZqEakq();
			}
		}
	}

	static rLETEdSYhWxLHVYaOFVeoGhCoDBH()
	{
		qIYgBwSuoVmKbziCOlvCHYOrjDwM = 30;
		oNviCFwPeEOzGRomXURsHiZqEakq();
	}

	public static void DUJElwEuhyJhkHNzgJmizoNKzzkgB()
	{
		int frameCount = Time.frameCount;
		if (mdwgBEbehQckBPkwTAWXshUJEgoMA < frameCount)
		{
			yafuXUgUOnRpzdLLIrdFYiQnoahm[JHJJuRHXwsCJNwwZLWijUcajrkAE] = Time.deltaTime;
			if (baRoMBxhkVhuSlyVyZyZtbtEgGvf < qIYgBwSuoVmKbziCOlvCHYOrjDwM)
			{
				baRoMBxhkVhuSlyVyZyZtbtEgGvf++;
			}
			double num = 0.0;
			for (int i = 0; i < baRoMBxhkVhuSlyVyZyZtbtEgGvf; i++)
			{
				num += yafuXUgUOnRpzdLLIrdFYiQnoahm[i];
			}
			gmkGAYpylQCrwpDOJecvZFfRzEDB = num / (double)baRoMBxhkVhuSlyVyZyZtbtEgGvf;
			JHJJuRHXwsCJNwwZLWijUcajrkAE++;
			if (JHJJuRHXwsCJNwwZLWijUcajrkAE >= qIYgBwSuoVmKbziCOlvCHYOrjDwM)
			{
				JHJJuRHXwsCJNwwZLWijUcajrkAE = 0;
			}
			mdwgBEbehQckBPkwTAWXshUJEgoMA = frameCount;
		}
	}

	public static void oNviCFwPeEOzGRomXURsHiZqEakq()
	{
		if (yafuXUgUOnRpzdLLIrdFYiQnoahm == null || yafuXUgUOnRpzdLLIrdFYiQnoahm.Length != qIYgBwSuoVmKbziCOlvCHYOrjDwM)
		{
			yafuXUgUOnRpzdLLIrdFYiQnoahm = new double[qIYgBwSuoVmKbziCOlvCHYOrjDwM];
		}
		baRoMBxhkVhuSlyVyZyZtbtEgGvf = 0;
		JHJJuRHXwsCJNwwZLWijUcajrkAE = 0;
		mdwgBEbehQckBPkwTAWXshUJEgoMA = 0;
	}
}
