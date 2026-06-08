using Rewired;
using Rewired.Utils;

internal class dpVtayQkMohBNIznVFukSTYbCqxv
{
	private class nScvCgMnDUGFOFHgrPcrCKjnQlc
	{
		public bool lTkuXDpBpsLxRBVaGMtdDZauGbI;

		public bool nuUsaiDejZRDtBfHlGgxzzfWtr;

		public double CSSejXCuztgiDHCfCQsxjZsGPQNg;

		public bool OcyCbxBIbFSQWrvtXHcHJAXSePuW;

		public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			lTkuXDpBpsLxRBVaGMtdDZauGbI = false;
			OcyCbxBIbFSQWrvtXHcHJAXSePuW = false;
		}
	}

	private const int ZqcIFQktMSrpseMCjiMgmOouqoU = 2;

	private bool HewmgBxnlqheeaCyBbxCmITSoEAX;

	private bool fgOtVqvIdspDizPVdzJLmCUIBKd;

	private bool iukbqPGRhdfvAHrGVhoNUahjQhxu;

	private float FPTaPYCrEVaOlOSyDQgtmLwJtra;

	private readonly nScvCgMnDUGFOFHgrPcrCKjnQlc[] eQHRRaFOBSqutLSewHfZnfQSWHR;

	private bool pNLDuLbBbmzkgBdeEnrTVcSXmBR;

	private bool GRJlIhQUNjLgMWziGRyzMFVtSKO;

	public bool doublePressHold => HewmgBxnlqheeaCyBbxCmITSoEAX;

	public bool doublePressUp
	{
		get
		{
			if (!HewmgBxnlqheeaCyBbxCmITSoEAX)
			{
				return fgOtVqvIdspDizPVdzJLmCUIBKd;
			}
			return false;
		}
	}

	public bool doublePressDown
	{
		get
		{
			if (HewmgBxnlqheeaCyBbxCmITSoEAX)
			{
				return !fgOtVqvIdspDizPVdzJLmCUIBKd;
			}
			return false;
		}
	}

	public float speed => FPTaPYCrEVaOlOSyDQgtmLwJtra;

	public bool singlePressHold => GRJlIhQUNjLgMWziGRyzMFVtSKO;

	public bool singlePressDown
	{
		get
		{
			if (GRJlIhQUNjLgMWziGRyzMFVtSKO)
			{
				return !pNLDuLbBbmzkgBdeEnrTVcSXmBR;
			}
			return false;
		}
	}

	public bool singlePressUp
	{
		get
		{
			if (!GRJlIhQUNjLgMWziGRyzMFVtSKO)
			{
				return pNLDuLbBbmzkgBdeEnrTVcSXmBR;
			}
			return false;
		}
	}

	public dpVtayQkMohBNIznVFukSTYbCqxv(float speed)
	{
		FPTaPYCrEVaOlOSyDQgtmLwJtra = speed;
		eQHRRaFOBSqutLSewHfZnfQSWHR = new nScvCgMnDUGFOFHgrPcrCKjnQlc[2];
		ArrayTools.Populate(eQHRRaFOBSqutLSewHfZnfQSWHR);
	}

	public void GzCliicOSMFLMvKajLgvnmGSSrh(float P_0, bool P_1, bool P_2)
	{
		bool flag = ((!iukbqPGRhdfvAHrGVhoNUahjQhxu) ? P_1 : P_2);
		if (P_0 != speed)
		{
			buUwnebVeshOowGIsGloTRnJlSy(P_0);
			goto IL_0020;
		}
		goto IL_0440;
		IL_0025:
		int num;
		int num4 = default(int);
		int num3 = default(int);
		double unscaledTime = default(double);
		int num5 = default(int);
		int num6 = default(int);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x592931A2)
			{
			case 30:
				break;
			case 2:
				if (GRJlIhQUNjLgMWziGRyzMFVtSKO)
				{
					GRJlIhQUNjLgMWziGRyzMFVtSKO = false;
					num = 1495871922;
					continue;
				}
				goto case 16;
			case 20:
				num4--;
				num = 1495871874;
				continue;
			case 14:
				eQHRRaFOBSqutLSewHfZnfQSWHR[num3].lTkuXDpBpsLxRBVaGMtdDZauGbI = true;
				eQHRRaFOBSqutLSewHfZnfQSWHR[num3].nuUsaiDejZRDtBfHlGgxzzfWtr = flag;
				eQHRRaFOBSqutLSewHfZnfQSWHR[num3].CSSejXCuztgiDHCfCQsxjZsGPQNg = unscaledTime;
				num5++;
				num = 1495871908;
				continue;
			case 35:
				goto IL_0130;
			case 5:
				if (num5 < 2)
				{
					return;
				}
				goto case 24;
			case 7:
				num = 1495871924;
				continue;
			case 10:
				num = 1495871873;
				continue;
			case 24:
				if (!HewmgBxnlqheeaCyBbxCmITSoEAX)
				{
					HewmgBxnlqheeaCyBbxCmITSoEAX = true;
					GRJlIhQUNjLgMWziGRyzMFVtSKO = false;
					num = 1495871875;
					continue;
				}
				goto case 33;
			case 12:
				num = 1495871921;
				continue;
			case 28:
				MiscTools.Swap(ref eQHRRaFOBSqutLSewHfZnfQSWHR[0], ref eQHRRaFOBSqutLSewHfZnfQSWHR[1]);
				num = 1495871931;
				continue;
			case 13:
				eQHRRaFOBSqutLSewHfZnfQSWHR[num6].tAgADqjTsMUxSqYXeDyJIdETYRAp();
				num = 1495871905;
				continue;
			case 21:
				goto IL_01d7;
			case 11:
				goto IL_01f4;
			case 31:
				eQHRRaFOBSqutLSewHfZnfQSWHR[num2].tAgADqjTsMUxSqYXeDyJIdETYRAp();
				num2++;
				num = 1495871921;
				continue;
			case 17:
				if (eQHRRaFOBSqutLSewHfZnfQSWHR[num6].lTkuXDpBpsLxRBVaGMtdDZauGbI)
				{
					goto IL_0248;
				}
				goto case 3;
			case 25:
				num5 = 0;
				num3 = 0;
				num = 1495871909;
				continue;
			case 26:
				return;
			case 27:
				num4 = 1;
				num = 1495871874;
				continue;
			case 22:
				goto IL_029b;
			case 34:
				goto IL_02b4;
			case 3:
				num6++;
				num = 1495871873;
				continue;
			case 33:
				num2 = 0;
				num = 1495871918;
				continue;
			case 6:
				num = 1495871911;
				continue;
			case 36:
				if (!flag && pNLDuLbBbmzkgBdeEnrTVcSXmBR)
				{
					GRJlIhQUNjLgMWziGRyzMFVtSKO = false;
					num = 1495871929;
					continue;
				}
				goto case 27;
			case 8:
				num5++;
				num = 1495871920;
				continue;
			case 23:
				goto IL_0321;
			case 0:
				iukbqPGRhdfvAHrGVhoNUahjQhxu = flag;
				if (!flag)
				{
					if (!HewmgBxnlqheeaCyBbxCmITSoEAX)
					{
						return;
					}
					HewmgBxnlqheeaCyBbxCmITSoEAX = false;
					num = 1495871928;
					continue;
				}
				goto case 2;
			case 4:
				num = 1495871927;
				continue;
			case 32:
				goto IL_0377;
			case 29:
				return;
			case 1:
				if (!eQHRRaFOBSqutLSewHfZnfQSWHR[num4].lTkuXDpBpsLxRBVaGMtdDZauGbI || !eQHRRaFOBSqutLSewHfZnfQSWHR[num4].nuUsaiDejZRDtBfHlGgxzzfWtr || eQHRRaFOBSqutLSewHfZnfQSWHR[num4].OcyCbxBIbFSQWrvtXHcHJAXSePuW)
				{
					goto case 20;
				}
				if (!GRJlIhQUNjLgMWziGRyzMFVtSKO && ReInput.unscaledTime - eQHRRaFOBSqutLSewHfZnfQSWHR[num4].CSSejXCuztgiDHCfCQsxjZsGPQNg > (double)P_0)
				{
					GRJlIhQUNjLgMWziGRyzMFVtSKO = true;
					eQHRRaFOBSqutLSewHfZnfQSWHR[num4].OcyCbxBIbFSQWrvtXHcHJAXSePuW = true;
					num = 1495871910;
					continue;
				}
				goto IL_01d7;
			case 9:
				num3++;
				num = 1495871924;
				continue;
			case 18:
				num = 1495871915;
				continue;
			case 16:
				unscaledTime = ReInput.unscaledTime;
				num6 = 0;
				num = 1495871912;
				continue;
			case 15:
				goto IL_0440;
			default:
				if (num2 >= 2)
				{
					return;
				}
				goto case 31;
			}
			break;
			IL_0377:
			int num7;
			if (num4 < 0)
			{
				num = 1495871927;
				num7 = num;
			}
			else
			{
				num = 1495871907;
				num7 = num;
			}
			continue;
			IL_01d7:
			int num8;
			if (iukbqPGRhdfvAHrGVhoNUahjQhxu != flag)
			{
				num = 1495871906;
				num8 = num;
			}
			else
			{
				num = 1495871935;
				num8 = num;
			}
			continue;
			IL_0130:
			int num9;
			if (num6 >= 2)
			{
				num = 1495871925;
				num9 = num;
			}
			else
			{
				num = 1495871923;
				num9 = num;
			}
			continue;
			IL_0321:
			int num10;
			if (!eQHRRaFOBSqutLSewHfZnfQSWHR[0].lTkuXDpBpsLxRBVaGMtdDZauGbI)
			{
				num = 1495871934;
				num10 = num;
			}
			else
			{
				num = 1495871931;
				num10 = num;
			}
			continue;
			IL_0248:
			int num11;
			if (unscaledTime - eQHRRaFOBSqutLSewHfZnfQSWHR[num6].CSSejXCuztgiDHCfCQsxjZsGPQNg <= (double)FPTaPYCrEVaOlOSyDQgtmLwJtra)
			{
				num = 1495871905;
				num11 = num;
			}
			else
			{
				num = 1495871919;
				num11 = num;
			}
			continue;
			IL_01f4:
			int num12;
			if (!eQHRRaFOBSqutLSewHfZnfQSWHR[num3].lTkuXDpBpsLxRBVaGMtdDZauGbI)
			{
				num = 1495871916;
				num12 = num;
			}
			else
			{
				num = 1495871914;
				num12 = num;
			}
			continue;
			IL_02b4:
			int num13;
			if (HewmgBxnlqheeaCyBbxCmITSoEAX)
			{
				num = 1495871927;
				num13 = num;
			}
			else
			{
				num = 1495871878;
				num13 = num;
			}
			continue;
			IL_029b:
			int num14;
			if (num3 >= 2)
			{
				num = 1495871911;
				num14 = num;
			}
			else
			{
				num = 1495871913;
				num14 = num;
			}
		}
		goto IL_0020;
		IL_0020:
		num = 1495871917;
		goto IL_0025;
		IL_0440:
		pNLDuLbBbmzkgBdeEnrTVcSXmBR = GRJlIhQUNjLgMWziGRyzMFVtSKO;
		fgOtVqvIdspDizPVdzJLmCUIBKd = HewmgBxnlqheeaCyBbxCmITSoEAX;
		num = 1495871872;
		goto IL_0025;
	}

	public void buUwnebVeshOowGIsGloTRnJlSy(float P_0)
	{
		CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
		FPTaPYCrEVaOlOSyDQgtmLwJtra = P_0;
	}

	public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
	{
		iukbqPGRhdfvAHrGVhoNUahjQhxu = false;
		HewmgBxnlqheeaCyBbxCmITSoEAX = false;
		GRJlIhQUNjLgMWziGRyzMFVtSKO = false;
		pNLDuLbBbmzkgBdeEnrTVcSXmBR = false;
		int num2 = default(int);
		while (true)
		{
			int num = 971623135;
			while (true)
			{
				switch (num ^ 0x39E9CADE)
				{
				case 3:
					break;
				case 1:
					num2 = 0;
					num = 971623132;
					continue;
				case 0:
					eQHRRaFOBSqutLSewHfZnfQSWHR[num2].tAgADqjTsMUxSqYXeDyJIdETYRAp();
					num2++;
					num = 971623132;
					continue;
				default:
					if (num2 >= 2)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}
}
