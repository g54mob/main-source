using UnityEngine;

internal static class nKpZbkzjdbnVEmZNIvHXyOfDYnh
{
	private static int BGYXeyDLhslikXCMQMCvelvlBNEK;

	private static int VXgPrLiRFgJCxmeSHMjaqdvOBgr;

	private static double[] EIdTdTAIdomFECUHMQuYbITmNnr;

	private static int tgsuFPEGiwrMrWEmREmjaEfXPoYW;

	private static double MFkwUxeekDeXwtnfUfqQvUhIobD;

	private static int syIaurihYgWuUhghPkllybimxqR;

	public static double smoothDeltaTime => MFkwUxeekDeXwtnfUfqQvUhIobD;

	public static int framesToSmooth
	{
		get
		{
			return BGYXeyDLhslikXCMQMCvelvlBNEK;
		}
		set
		{
			if (value <= 0)
			{
				value = 1;
				goto IL_0007;
			}
			goto IL_002d;
			IL_002d:
			int num;
			int num2;
			if (value == BGYXeyDLhslikXCMQMCvelvlBNEK)
			{
				num = 899985536;
				num2 = num;
			}
			else
			{
				num = 899985543;
				num2 = num;
			}
			goto IL_000c;
			IL_0007:
			num = 899985537;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ 0x35A4B083)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_002d;
				case 3:
					return;
				case 4:
					BGYXeyDLhslikXCMQMCvelvlBNEK = value;
					CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
					num = 899985538;
					continue;
				case 1:
					return;
				}
				break;
			}
			goto IL_0007;
		}
	}

	static nKpZbkzjdbnVEmZNIvHXyOfDYnh()
	{
		BGYXeyDLhslikXCMQMCvelvlBNEK = 30;
		CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
	}

	public static void GzCliicOSMFLMvKajLgvnmGSSrh()
	{
		int frameCount = Time.frameCount;
		if (syIaurihYgWuUhghPkllybimxqR >= frameCount)
		{
			return;
		}
		double num2 = default(double);
		int num3 = default(int);
		while (true)
		{
			EIdTdTAIdomFECUHMQuYbITmNnr[VXgPrLiRFgJCxmeSHMjaqdvOBgr] = Time.deltaTime;
			int num;
			if (tgsuFPEGiwrMrWEmREmjaEfXPoYW < BGYXeyDLhslikXCMQMCvelvlBNEK)
			{
				tgsuFPEGiwrMrWEmREmjaEfXPoYW++;
				num = -2070897508;
				goto IL_0014;
			}
			goto IL_00b0;
			IL_0014:
			while (true)
			{
				switch (num ^ -2070897510)
				{
				case 3:
					num = -2070897505;
					continue;
				case 5:
					break;
				case 7:
					MFkwUxeekDeXwtnfUfqQvUhIobD = num2 / (double)tgsuFPEGiwrMrWEmREmjaEfXPoYW;
					VXgPrLiRFgJCxmeSHMjaqdvOBgr++;
					num = -2070897510;
					continue;
				case 0:
					if (VXgPrLiRFgJCxmeSHMjaqdvOBgr >= BGYXeyDLhslikXCMQMCvelvlBNEK)
					{
						VXgPrLiRFgJCxmeSHMjaqdvOBgr = 0;
						num = -2070897506;
						continue;
					}
					goto default;
				case 6:
					goto IL_00b0;
				case 2:
					num2 += EIdTdTAIdomFECUHMQuYbITmNnr[num3];
					num3++;
					num = -2070897509;
					continue;
				case 1:
					goto IL_00de;
				default:
					syIaurihYgWuUhghPkllybimxqR = frameCount;
					return;
				}
				break;
				IL_00de:
				int num4;
				if (num3 < tgsuFPEGiwrMrWEmREmjaEfXPoYW)
				{
					num = -2070897512;
					num4 = num;
				}
				else
				{
					num = -2070897507;
					num4 = num;
				}
			}
			continue;
			IL_00b0:
			num2 = 0.0;
			num3 = 0;
			num = -2070897509;
			goto IL_0014;
		}
	}

	public static void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
	{
		if (EIdTdTAIdomFECUHMQuYbITmNnr == null)
		{
			goto IL_0033;
		}
		if (EIdTdTAIdomFECUHMQuYbITmNnr.Length != BGYXeyDLhslikXCMQMCvelvlBNEK)
		{
			goto IL_0015;
		}
		goto IL_0049;
		IL_0049:
		tgsuFPEGiwrMrWEmREmjaEfXPoYW = 0;
		VXgPrLiRFgJCxmeSHMjaqdvOBgr = 0;
		syIaurihYgWuUhghPkllybimxqR = 0;
		return;
		IL_0015:
		int num = -1084795483;
		goto IL_001a;
		IL_001a:
		switch (num ^ -1084795484)
		{
		case 0:
			break;
		case 1:
			goto IL_0033;
		default:
			goto IL_0049;
		}
		goto IL_0015;
		IL_0033:
		EIdTdTAIdomFECUHMQuYbITmNnr = new double[BGYXeyDLhslikXCMQMCvelvlBNEK];
		num = -1084795482;
		goto IL_001a;
	}
}
