using System;

internal static class nRDqiCujUTmvVJSpZialYeJXOSn
{
	public const int QuKSOrRHcFaWswfJovkfMpPeajl = 101;

	public const int wOPJuitsRkZIFruOvhfxJCwgkbQ = 2146435069;

	public static readonly int[] xOBdgQCOqNAhXsseXiEEwcMJWAvO = new int[72]
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

	public static bool aZrRdgzFTInfeBLHEJBsvxJsGDq(int P_0)
	{
		if ((P_0 & 1) != 0)
		{
			int num = (int)Math.Sqrt(P_0);
			int num2 = 3;
			while (true)
			{
				int num3;
				int num4;
				if (num2 <= num)
				{
					num3 = -2060730921;
					num4 = num3;
				}
				else
				{
					num3 = -2060730923;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -2060730924)
					{
					case 2:
						num3 = -2060730921;
						continue;
					case 3:
						if (P_0 % num2 == 0)
						{
							return false;
						}
						num2 += 2;
						num3 = -2060730924;
						continue;
					case 0:
						break;
					default:
						return true;
					}
					break;
				}
			}
		}
		return P_0 == 2;
	}

	public static int WdkjlnFdTQshWqxOBmwMHudtQKPd(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentException("Arg_HTCapacityOverflow");
		}
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num = 0;
			int num2 = -54042652;
			while (true)
			{
				switch (num2 ^ -54042653)
				{
				case 4:
					num2 = -54042654;
					continue;
				case 5:
					num3 = P_0 | 1;
					num2 = -54042651;
					continue;
				case 3:
					return num4;
				case 0:
					if (aZrRdgzFTInfeBLHEJBsvxJsGDq(num3) && (num3 - 1) % 101 != 0)
					{
						return num3;
					}
					num3 += 2;
					num2 = -54042651;
					continue;
				case 2:
					num4 = xOBdgQCOqNAhXsseXiEEwcMJWAvO[num];
					if (num4 < P_0)
					{
						num++;
						num2 = -54042652;
					}
					else
					{
						num2 = -54042656;
					}
					continue;
				case 1:
					break;
				case 7:
				{
					int num5;
					if (num < xOBdgQCOqNAhXsseXiEEwcMJWAvO.Length)
					{
						num2 = -54042655;
						num5 = num2;
					}
					else
					{
						num2 = -54042650;
						num5 = num2;
					}
					continue;
				}
				default:
					if (num3 >= int.MaxValue)
					{
						return P_0;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public static int SHjhbyIfroXIUDLQfcoIoUhTnuQ()
	{
		return xOBdgQCOqNAhXsseXiEEwcMJWAvO[0];
	}

	public static int iaLvtqyFwGxSfqcNREKgisZiGDjp(int P_0)
	{
		int num = 2 * P_0;
		while (true)
		{
			int num2 = 974116058;
			while (true)
			{
				switch (num2 ^ 0x3A0FD4DB)
				{
				case 3:
					break;
				case 1:
					if ((uint)num > 2146435069u)
					{
						num2 = 974116059;
						continue;
					}
					goto IL_004a;
				case 0:
					if (2146435069 > P_0)
					{
						num2 = 974116057;
						continue;
					}
					goto IL_004a;
				default:
					{
						return 2146435069;
					}
					IL_004a:
					return WdkjlnFdTQshWqxOBmwMHudtQKPd(num);
				}
				break;
			}
		}
	}
}
