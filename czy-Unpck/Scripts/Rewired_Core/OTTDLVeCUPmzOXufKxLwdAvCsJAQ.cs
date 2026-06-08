using System;

internal static class OTTDLVeCUPmzOXufKxLwdAvCsJAQ
{
	public const int xQLnmLtZFTFllPynCDksSzvLaSs = 101;

	public const int PwVWsdJmPehUPIkNoSYoHamnprE = 2146435069;

	public static readonly int[] MMZBVHoTpLaGSRgHWrQPmVyGXtQ = new int[72]
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

	public static bool HGrzeuPMsUEcgmviNMsfvbJbwLZ(int P_0)
	{
		if ((P_0 & 1) != 0)
		{
			int num = (int)Math.Sqrt(P_0);
			int num2 = 3;
			while (num2 <= num)
			{
				while (true)
				{
					if (P_0 % num2 == 0)
					{
						return false;
					}
					num2 += 2;
					int num3 = -863410119;
					while (true)
					{
						switch (num3 ^ -863410120)
						{
						case 0:
							num3 = -863410118;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return true;
		}
		return P_0 == 2;
	}

	public static int zbeAceNSyGcZTUpJMPIRoiRaJUk(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentException("Arg_HTCapacityOverflow");
		}
		int num3 = default(int);
		while (true)
		{
			int num = 0;
			int num2 = 868934075;
			while (true)
			{
				switch (num2 ^ 0x33CAE1BE)
				{
				case 6:
					num2 = 868934077;
					continue;
				case 4:
					if (HGrzeuPMsUEcgmviNMsfvbJbwLZ(num3) && (num3 - 1) % 101 != 0)
					{
						num2 = 868934076;
						continue;
					}
					num3 += 2;
					num2 = 868934078;
					continue;
				case 2:
					return num3;
				case 5:
					if (num >= MMZBVHoTpLaGSRgHWrQPmVyGXtQ.Length)
					{
						num3 = P_0 | 1;
						num2 = 868934078;
						continue;
					}
					goto case 1;
				case 3:
					break;
				case 1:
				{
					int num4 = MMZBVHoTpLaGSRgHWrQPmVyGXtQ[num];
					if (num4 >= P_0)
					{
						return num4;
					}
					num++;
					num2 = 868934075;
					continue;
				}
				default:
					if (num3 >= int.MaxValue)
					{
						return P_0;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public static int zJjcQvFoQaOMXAojopVPwqPGsypn()
	{
		return MMZBVHoTpLaGSRgHWrQPmVyGXtQ[0];
	}

	public static int PRpOnHOTCSFgEJafMnrPgbBfWEC(int P_0)
	{
		int num = 2 * P_0;
		if ((uint)num > 2146435069u && 2146435069 > P_0)
		{
			return 2146435069;
		}
		return zbeAceNSyGcZTUpJMPIRoiRaJUk(num);
	}
}
