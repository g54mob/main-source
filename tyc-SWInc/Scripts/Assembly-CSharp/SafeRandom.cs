using System;

public static class SafeRandom
{
	[ThreadStatic]
	private static Random _rnd;

	public static Random Rnd
	{
		get
		{
			if (_rnd == null)
			{
				_rnd = new Random();
			}
			return _rnd;
		}
	}
}
