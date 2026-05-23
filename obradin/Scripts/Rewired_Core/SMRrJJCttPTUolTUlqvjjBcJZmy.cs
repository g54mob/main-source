using System;

internal static class SMRrJJCttPTUolTUlqvjjBcJZmy
{
	public const int hmICTkrXkJytNOAIAugbdNHgaqg = 101;

	public const int FQNOOxHBsuqNjVFtNGzvaDGaSve = 2146435069;

	public static readonly int[] QRZShJeFcXnQyOjztOMQFHWXWJk = new int[72]
	{
		3, 7, 11, 17, 23, 29, 37, 47, 59, 71,
		89, 107, 131, 163, 197, 239, 293, 353, 431, 521,
		631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371,
		4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023,
		25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363,
		156437, 187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403,
		968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559,
		5999471, 7199369
	};

	public static bool XAjQAkDOHUMWAtsIiXrwKlWqJdd(int P_0)
	{
		int num3 = default(int);
		int num2 = default(int);
		if ((P_0 & 1) != 0)
		{
			while (true)
			{
				int num = -1503822516;
				while (true)
				{
					switch (num ^ -1503822513)
					{
					case 0:
						break;
					case 3:
						num3 = (int)Math.Sqrt(P_0);
						num = -1503822518;
						continue;
					case 5:
						num2 = 3;
						num = -1503822514;
						continue;
					case 2:
						if (P_0 % num2 == 0)
						{
							return false;
						}
						num2 += 2;
						num = -1503822517;
						continue;
					case 1:
						num = -1503822517;
						continue;
					default:
						if (num2 > num3)
						{
							return true;
						}
						goto case 2;
					}
					break;
				}
			}
		}
		return P_0 == 2;
	}

	public static int ngezoiHnXAnMvZYTlmcQTlddhZKD(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentException("Arg_HTCapacityOverflow");
		}
		int num3 = default(int);
		while (true)
		{
			int num = 0;
			int num2 = -404816352;
			while (true)
			{
				switch (num2 ^ -404816352)
				{
				case 2:
					num2 = -404816347;
					continue;
				case 6:
					return num3;
				case 7:
				{
					int num5 = QRZShJeFcXnQyOjztOMQFHWXWJk[num];
					if (num5 >= P_0)
					{
						return num5;
					}
					num++;
					num2 = -404816352;
					continue;
				}
				case 0:
				{
					int num4;
					if (num < QRZShJeFcXnQyOjztOMQFHWXWJk.Length)
					{
						num2 = -404816345;
						num4 = num2;
					}
					else
					{
						num2 = -404816349;
						num4 = num2;
					}
					continue;
				}
				case 3:
					num3 = P_0 | 1;
					num2 = -404816348;
					continue;
				case 5:
					break;
				case 1:
					if (!XAjQAkDOHUMWAtsIiXrwKlWqJdd(num3) || (num3 - 1) % 101 == 0)
					{
						num3 += 2;
						num2 = -404816348;
					}
					else
					{
						num2 = -404816346;
					}
					continue;
				default:
					if (num3 >= int.MaxValue)
					{
						return P_0;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	public static int jbzudFcvqqwlcdPXBuAaNzJJcZk()
	{
		return QRZShJeFcXnQyOjztOMQFHWXWJk[0];
	}

	public static int DpJaovjEgIJtMJACfnCoETZbuAyD(int P_0)
	{
		int num = 2 * P_0;
		if ((uint)num > 2146435069u && 2146435069 > P_0)
		{
			return 2146435069;
		}
		return ngezoiHnXAnMvZYTlmcQTlddhZKD(num);
	}
}
