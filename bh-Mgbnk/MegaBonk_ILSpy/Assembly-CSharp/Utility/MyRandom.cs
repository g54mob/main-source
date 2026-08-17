using System;

namespace Utility;

public class MyRandom
{
	public static Random random;

	static MyRandom()
	{
		Random random = new Random();
		MyRandom.random = random;
	}
}
