using UnityEngine;

internal static class YopKelPMGjywFBCaXKMAgjVMTVK
{
	private static int gZKVdojCIgtrkkncDdcFuVkwCpw;

	private static int makeqSfOesOCmoTnKnppZmDJCnQg;

	private static float[] nzGhIyYogEiNxqNXBEBpdrnaVK;

	private static int EwayIwpVkFOwhUXAHSuCuXOpwl;

	private static float lEuoTaWEPNcCpCCGVwZBenVVOgcH;

	private static int VaWeJwhMKanBLgEBdYVmzyHttyeq;

	public static float smoothDeltaTime
	{
		get
		{
			return lEuoTaWEPNcCpCCGVwZBenVVOgcH;
		}
	}

	public static int framesToSmooth
	{
		get
		{
			return gZKVdojCIgtrkkncDdcFuVkwCpw;
		}
		set
		{
			if (value <= 0)
			{
				value = 1;
				while (true)
				{
					switch (0x69409A3F ^ 0x69409A3E)
					{
					case 0:
						break;
					case 1:
						goto end_IL_0007;
					default:
						goto IL_0035;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			if (value == gZKVdojCIgtrkkncDdcFuVkwCpw)
			{
				return;
			}
			goto IL_0035;
			IL_0035:
			gZKVdojCIgtrkkncDdcFuVkwCpw = value;
			xaGVjRxEvIdELjjBskoGFDUNmrm();
		}
	}

	static YopKelPMGjywFBCaXKMAgjVMTVK()
	{
		gZKVdojCIgtrkkncDdcFuVkwCpw = 30;
		xaGVjRxEvIdELjjBskoGFDUNmrm();
	}

	public static void rdEJYvExbWYUXSDuseVgzyXPBhA()
	{
		int frameCount = Time.frameCount;
		float num2 = default(float);
		int num3 = default(int);
		while (true)
		{
			int num = 621596000;
			while (true)
			{
				switch (num ^ 0x250CCD6A)
				{
				case 9:
					break;
				default:
					return;
				case 10:
					if (VaWeJwhMKanBLgEBdYVmzyHttyeq >= frameCount)
					{
						return;
					}
					goto case 11;
				case 7:
					num2 += nzGhIyYogEiNxqNXBEBpdrnaVK[num3];
					num = 621596014;
					continue;
				case 4:
					num3++;
					num = 621596012;
					continue;
				case 6:
					if (num3 < EwayIwpVkFOwhUXAHSuCuXOpwl)
					{
						goto case 7;
					}
					lEuoTaWEPNcCpCCGVwZBenVVOgcH = num2 / (float)EwayIwpVkFOwhUXAHSuCuXOpwl;
					makeqSfOesOCmoTnKnppZmDJCnQg++;
					if (makeqSfOesOCmoTnKnppZmDJCnQg >= gZKVdojCIgtrkkncDdcFuVkwCpw)
					{
						makeqSfOesOCmoTnKnppZmDJCnQg = 0;
						num = 621596009;
						continue;
					}
					goto case 3;
				case 2:
				{
					int num4;
					if (EwayIwpVkFOwhUXAHSuCuXOpwl < gZKVdojCIgtrkkncDdcFuVkwCpw)
					{
						num = 621596011;
						num4 = num;
					}
					else
					{
						num = 621596015;
						num4 = num;
					}
					continue;
				}
				case 3:
					VaWeJwhMKanBLgEBdYVmzyHttyeq = frameCount;
					num = 621596002;
					continue;
				case 11:
					nzGhIyYogEiNxqNXBEBpdrnaVK[makeqSfOesOCmoTnKnppZmDJCnQg] = Time.deltaTime;
					num = 621596008;
					continue;
				case 1:
					EwayIwpVkFOwhUXAHSuCuXOpwl++;
					num = 621596015;
					continue;
				case 5:
					num2 = 0f;
					num3 = 0;
					num = 621596010;
					continue;
				case 0:
					num = 621596012;
					continue;
				case 8:
					return;
				}
				break;
			}
		}
	}

	public static void xaGVjRxEvIdELjjBskoGFDUNmrm()
	{
		if (nzGhIyYogEiNxqNXBEBpdrnaVK == null)
		{
			goto IL_0037;
		}
		if (nzGhIyYogEiNxqNXBEBpdrnaVK.Length != gZKVdojCIgtrkkncDdcFuVkwCpw)
		{
			goto IL_0015;
		}
		goto IL_004d;
		IL_0037:
		nzGhIyYogEiNxqNXBEBpdrnaVK = new float[gZKVdojCIgtrkkncDdcFuVkwCpw];
		int num = -1406857147;
		goto IL_001a;
		IL_0015:
		num = -1406857146;
		goto IL_001a;
		IL_001a:
		switch (num ^ -1406857147)
		{
		case 2:
			break;
		default:
			return;
		case 3:
			goto IL_0037;
		case 0:
			goto IL_004d;
		case 1:
			return;
		}
		goto IL_0015;
		IL_004d:
		EwayIwpVkFOwhUXAHSuCuXOpwl = 0;
		makeqSfOesOCmoTnKnppZmDJCnQg = 0;
		VaWeJwhMKanBLgEBdYVmzyHttyeq = 0;
		num = -1406857148;
		goto IL_001a;
	}
}
