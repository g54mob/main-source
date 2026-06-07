using UnityEngine;

internal static class DNaMLDBvOwMxHdDJJIVPimYrMrMFb
{
	private static int jlFwZNrSbxmrhGOnVsFziMDTqvQc;

	private static int hXbwTkGIglELkIvAOJmgZwYkqPGIA;

	private static double[] yocnOqmFYrJiFRHPRUIUdhgOMCEl;

	private static int LQtJryaHBfYUqLswYWVnKItvVEpf;

	private static double cSfGgQAxXGRLzkOxHgIQkxCwcAiwA;

	private static int KYDWeQUFOlCYToOsSyYrsHYKGXql;

	public static double NelZfWBRMbCMOVOzZbrpoPgyHriGA => cSfGgQAxXGRLzkOxHgIQkxCwcAiwA;

	public static int xCGoiqOwFxopqEAwjdDpExTvlVqoA
	{
		get
		{
			return jlFwZNrSbxmrhGOnVsFziMDTqvQc;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != jlFwZNrSbxmrhGOnVsFziMDTqvQc)
			{
				jlFwZNrSbxmrhGOnVsFziMDTqvQc = num;
				ooNidbhWzBcZZJydutNALDEuSswc();
			}
		}
	}

	static DNaMLDBvOwMxHdDJJIVPimYrMrMFb()
	{
		jlFwZNrSbxmrhGOnVsFziMDTqvQc = 30;
		ooNidbhWzBcZZJydutNALDEuSswc();
	}

	public static void sOLNzBCCbZmFXkMugfndpShqgrUP()
	{
		int frameCount = Time.frameCount;
		if (KYDWeQUFOlCYToOsSyYrsHYKGXql < frameCount)
		{
			yocnOqmFYrJiFRHPRUIUdhgOMCEl[hXbwTkGIglELkIvAOJmgZwYkqPGIA] = Time.deltaTime;
			if (LQtJryaHBfYUqLswYWVnKItvVEpf < jlFwZNrSbxmrhGOnVsFziMDTqvQc)
			{
				LQtJryaHBfYUqLswYWVnKItvVEpf++;
			}
			double num = 0.0;
			for (int i = 0; i < LQtJryaHBfYUqLswYWVnKItvVEpf; i++)
			{
				num += yocnOqmFYrJiFRHPRUIUdhgOMCEl[i];
			}
			cSfGgQAxXGRLzkOxHgIQkxCwcAiwA = num / (double)LQtJryaHBfYUqLswYWVnKItvVEpf;
			hXbwTkGIglELkIvAOJmgZwYkqPGIA++;
			if (hXbwTkGIglELkIvAOJmgZwYkqPGIA >= jlFwZNrSbxmrhGOnVsFziMDTqvQc)
			{
				hXbwTkGIglELkIvAOJmgZwYkqPGIA = 0;
			}
			KYDWeQUFOlCYToOsSyYrsHYKGXql = frameCount;
		}
	}

	public static void ooNidbhWzBcZZJydutNALDEuSswc()
	{
		if (yocnOqmFYrJiFRHPRUIUdhgOMCEl == null || yocnOqmFYrJiFRHPRUIUdhgOMCEl.Length != jlFwZNrSbxmrhGOnVsFziMDTqvQc)
		{
			yocnOqmFYrJiFRHPRUIUdhgOMCEl = new double[jlFwZNrSbxmrhGOnVsFziMDTqvQc];
		}
		LQtJryaHBfYUqLswYWVnKItvVEpf = 0;
		hXbwTkGIglELkIvAOJmgZwYkqPGIA = 0;
		KYDWeQUFOlCYToOsSyYrsHYKGXql = 0;
	}
}
