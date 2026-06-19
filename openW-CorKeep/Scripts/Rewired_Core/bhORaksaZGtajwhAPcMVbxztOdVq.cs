using UnityEngine;

internal static class bhORaksaZGtajwhAPcMVbxztOdVq
{
	private static int ioMgBhIkUDgOVjCkgRsfxEUfGSuHB;

	private static int NoPdJhjGtkeKpITWMFZJvZyAjqEhA;

	private static double[] yCpeSDWqohZEJKIbJmTuZWvEbdhF;

	private static int bCTqxKLKhDrcaMKxpGuiejxhxbpl;

	private static double iraBKZZOAUAQLUXhCEjVQzRargUx;

	private static int oduDHTOuNShspXlCGhPsqPGaWnon;

	public static double diMWJlDaQMnKymFVZBeuDtanDIqh => iraBKZZOAUAQLUXhCEjVQzRargUx;

	public static int yazbfnJctyihFiSPTBhsAvfsGmWzA
	{
		get
		{
			return ioMgBhIkUDgOVjCkgRsfxEUfGSuHB;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != ioMgBhIkUDgOVjCkgRsfxEUfGSuHB)
			{
				ioMgBhIkUDgOVjCkgRsfxEUfGSuHB = num;
				ktdFACAYYOMfiJcGWuEFFYNDqbcBA();
			}
		}
	}

	static bhORaksaZGtajwhAPcMVbxztOdVq()
	{
		ioMgBhIkUDgOVjCkgRsfxEUfGSuHB = 30;
		ktdFACAYYOMfiJcGWuEFFYNDqbcBA();
	}

	public static void PoBHvhSNJgArKfyRCkzXlxXWgkaaA()
	{
		int frameCount = Time.frameCount;
		if (oduDHTOuNShspXlCGhPsqPGaWnon < frameCount)
		{
			yCpeSDWqohZEJKIbJmTuZWvEbdhF[NoPdJhjGtkeKpITWMFZJvZyAjqEhA] = Time.deltaTime;
			if (bCTqxKLKhDrcaMKxpGuiejxhxbpl < ioMgBhIkUDgOVjCkgRsfxEUfGSuHB)
			{
				bCTqxKLKhDrcaMKxpGuiejxhxbpl++;
			}
			double num = 0.0;
			for (int i = 0; i < bCTqxKLKhDrcaMKxpGuiejxhxbpl; i++)
			{
				num += yCpeSDWqohZEJKIbJmTuZWvEbdhF[i];
			}
			iraBKZZOAUAQLUXhCEjVQzRargUx = num / (double)bCTqxKLKhDrcaMKxpGuiejxhxbpl;
			NoPdJhjGtkeKpITWMFZJvZyAjqEhA++;
			if (NoPdJhjGtkeKpITWMFZJvZyAjqEhA >= ioMgBhIkUDgOVjCkgRsfxEUfGSuHB)
			{
				NoPdJhjGtkeKpITWMFZJvZyAjqEhA = 0;
			}
			oduDHTOuNShspXlCGhPsqPGaWnon = frameCount;
		}
	}

	public static void ktdFACAYYOMfiJcGWuEFFYNDqbcBA()
	{
		if (yCpeSDWqohZEJKIbJmTuZWvEbdhF == null || yCpeSDWqohZEJKIbJmTuZWvEbdhF.Length != ioMgBhIkUDgOVjCkgRsfxEUfGSuHB)
		{
			yCpeSDWqohZEJKIbJmTuZWvEbdhF = new double[ioMgBhIkUDgOVjCkgRsfxEUfGSuHB];
		}
		bCTqxKLKhDrcaMKxpGuiejxhxbpl = 0;
		NoPdJhjGtkeKpITWMFZJvZyAjqEhA = 0;
		oduDHTOuNShspXlCGhPsqPGaWnon = 0;
	}
}
