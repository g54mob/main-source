using UnityEngine;

internal static class fbRGONfHoLLBeLrxdjuYANIQPiggb
{
	private static int yrRGlODdwIqOGVHbhAWcqvpjXcZe;

	private static int RwSLIAIlKvlmiYprolnOfpFnUhxp;

	private static double[] mCkHxghpZspjYBLQlkEpHpbjYyATA;

	private static int jFQgrjGqdInBldLOjJepCWKdYseAe;

	private static double wQdMBikGfLEuEaBUsIVEZmqPktrCA;

	private static int wynKAwdDwJSJgCevwfzjEchRcyBs;

	public static double jTXtPAyDVFNNzdnwzsnrzvOOuKPo => wQdMBikGfLEuEaBUsIVEZmqPktrCA;

	public static int eggfmQgkAfPPWlkijoZjTKMXqflV
	{
		get
		{
			return yrRGlODdwIqOGVHbhAWcqvpjXcZe;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != yrRGlODdwIqOGVHbhAWcqvpjXcZe)
			{
				yrRGlODdwIqOGVHbhAWcqvpjXcZe = num;
				aMeJWxjfHHHTvptTaexSomDoiRBC();
			}
		}
	}

	static fbRGONfHoLLBeLrxdjuYANIQPiggb()
	{
		yrRGlODdwIqOGVHbhAWcqvpjXcZe = 30;
		aMeJWxjfHHHTvptTaexSomDoiRBC();
	}

	public static void TsYigUtlkxHLFnXaeJqWTwHjjDBG()
	{
		int frameCount = Time.frameCount;
		if (wynKAwdDwJSJgCevwfzjEchRcyBs < frameCount)
		{
			mCkHxghpZspjYBLQlkEpHpbjYyATA[RwSLIAIlKvlmiYprolnOfpFnUhxp] = Time.deltaTime;
			if (jFQgrjGqdInBldLOjJepCWKdYseAe < yrRGlODdwIqOGVHbhAWcqvpjXcZe)
			{
				jFQgrjGqdInBldLOjJepCWKdYseAe++;
			}
			double num = 0.0;
			for (int i = 0; i < jFQgrjGqdInBldLOjJepCWKdYseAe; i++)
			{
				num += mCkHxghpZspjYBLQlkEpHpbjYyATA[i];
			}
			wQdMBikGfLEuEaBUsIVEZmqPktrCA = num / (double)jFQgrjGqdInBldLOjJepCWKdYseAe;
			RwSLIAIlKvlmiYprolnOfpFnUhxp++;
			if (RwSLIAIlKvlmiYprolnOfpFnUhxp >= yrRGlODdwIqOGVHbhAWcqvpjXcZe)
			{
				RwSLIAIlKvlmiYprolnOfpFnUhxp = 0;
			}
			wynKAwdDwJSJgCevwfzjEchRcyBs = frameCount;
		}
	}

	public static void aMeJWxjfHHHTvptTaexSomDoiRBC()
	{
		if (mCkHxghpZspjYBLQlkEpHpbjYyATA == null || mCkHxghpZspjYBLQlkEpHpbjYyATA.Length != yrRGlODdwIqOGVHbhAWcqvpjXcZe)
		{
			mCkHxghpZspjYBLQlkEpHpbjYyATA = new double[yrRGlODdwIqOGVHbhAWcqvpjXcZe];
		}
		jFQgrjGqdInBldLOjJepCWKdYseAe = 0;
		RwSLIAIlKvlmiYprolnOfpFnUhxp = 0;
		wynKAwdDwJSJgCevwfzjEchRcyBs = 0;
	}
}
