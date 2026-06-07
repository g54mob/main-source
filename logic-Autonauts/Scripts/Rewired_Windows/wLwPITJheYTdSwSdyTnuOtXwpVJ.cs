using Rewired.Utils;

internal class wLwPITJheYTdSwSdyTnuOtXwpVJ : ufceATEjpSRUYdfYDUvzCHYnyGXC
{
	public readonly bool MyAtAplkzyzucDuTAYhMusAinqv;

	private int eLvzhfKMorhWhTSPMECOzFuMYEn;

	private int TOoesAYyGNqVpaBcbagtriQQanK;

	private bool HtcGwDQOJcsVuNURqpiVtniVoC;

	public readonly int hDOnQeSKxGGbLMkQRMcBItIfVdr;

	public readonly int ScalzooAtVoPBEnEMmqglTvGnSi;

	public readonly int uDuCRIXDiJdYAcUJsgGStemDoZI;

	public readonly int AbksekjAjXcNpZTOhDkNtKNShoF;

	public readonly int PghwZnRmmIfaePDcpiXwmPaubGz;

	public readonly int GVHeWjdRAOSfAiABFEGtbrVgIlM;

	public readonly uint zUESHatBDEizbqEBmCnRdngCjNet;

	public readonly uint eoqXAEBFJHdIeBfFCYmTuwDkgfKB;

	public readonly int OfifItGmJqvFzsNTowFSnGdiILS;

	public uint wmSvsDuQKkgIZvbYXgCGTuPJLgF;

	public virtual int value
	{
		get
		{
			int num = (int)wmSvsDuQKkgIZvbYXgCGTuPJLgF;
			while (true)
			{
				int num2 = -155890398;
				while (true)
				{
					switch (num2 ^ -155890400)
					{
					case 3:
						break;
					case 2:
					{
						int num3;
						if (!MyAtAplkzyzucDuTAYhMusAinqv)
						{
							num2 = -155890399;
							num3 = num2;
						}
						else
						{
							num2 = -155890396;
							num3 = num2;
						}
						continue;
					}
					case 4:
					{
						int num4;
						if (HtcGwDQOJcsVuNURqpiVtniVoC)
						{
							num2 = -155890400;
							num4 = num2;
						}
						else
						{
							num2 = -155890399;
							num4 = num2;
						}
						continue;
					}
					case 0:
						if (num > eLvzhfKMorhWhTSPMECOzFuMYEn)
						{
							num += TOoesAYyGNqVpaBcbagtriQQanK;
							num2 = -155890399;
							continue;
						}
						goto default;
					default:
						if (num == uDuCRIXDiJdYAcUJsgGStemDoZI)
						{
							return GVHeWjdRAOSfAiABFEGtbrVgIlM;
						}
						return (int)eQIYezsvzkTXXHzhjtMFCkAUCnSh((float)num, (float)hDOnQeSKxGGbLMkQRMcBItIfVdr, (float)ScalzooAtVoPBEnEMmqglTvGnSi, (float)AbksekjAjXcNpZTOhDkNtKNShoF, (float)PghwZnRmmIfaePDcpiXwmPaubGz);
					}
					break;
				}
			}
		}
	}

	public wLwPITJheYTdSwSdyTnuOtXwpVJ(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex, bool isAxisButton)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		hDOnQeSKxGGbLMkQRMcBItIfVdr = logicalMin;
		ScalzooAtVoPBEnEMmqglTvGnSi = logicalMax;
		zUESHatBDEizbqEBmCnRdngCjNet = units;
		eoqXAEBFJHdIeBfFCYmTuwDkgfKB = unitsExp;
		OfifItGmJqvFzsNTowFSnGdiILS = reportIndex;
		MyAtAplkzyzucDuTAYhMusAinqv = logicalMin < 0 || logicalMax < 0;
		if (logicalMin > logicalMax || logicalMax - logicalMin < 2)
		{
			if (logicalMin == 0 && logicalMax < 0 && physicalMin == 0 && physicalMax < 0)
			{
				MyAtAplkzyzucDuTAYhMusAinqv = false;
			}
			if (bitSize > 1 && bitSize < 32)
			{
				int num = 1 << bitSize;
				if (MyAtAplkzyzucDuTAYhMusAinqv)
				{
					uDuCRIXDiJdYAcUJsgGStemDoZI = 0;
					hDOnQeSKxGGbLMkQRMcBItIfVdr = num * -1;
					ScalzooAtVoPBEnEMmqglTvGnSi = num - 1;
				}
				else
				{
					uDuCRIXDiJdYAcUJsgGStemDoZI = num >> 1;
					hDOnQeSKxGGbLMkQRMcBItIfVdr = 0;
					ScalzooAtVoPBEnEMmqglTvGnSi = num - 1;
				}
			}
			else if (MyAtAplkzyzucDuTAYhMusAinqv)
			{
				uDuCRIXDiJdYAcUJsgGStemDoZI = 0;
				hDOnQeSKxGGbLMkQRMcBItIfVdr = -32768;
				ScalzooAtVoPBEnEMmqglTvGnSi = 32767;
			}
			else
			{
				uDuCRIXDiJdYAcUJsgGStemDoZI = 32768;
				hDOnQeSKxGGbLMkQRMcBItIfVdr = 0;
				ScalzooAtVoPBEnEMmqglTvGnSi = 65535;
			}
		}
		else
		{
			uDuCRIXDiJdYAcUJsgGStemDoZI = (ScalzooAtVoPBEnEMmqglTvGnSi - hDOnQeSKxGGbLMkQRMcBItIfVdr) / 2;
		}
		GVHeWjdRAOSfAiABFEGtbrVgIlM = 0;
		AbksekjAjXcNpZTOhDkNtKNShoF = -65535;
		PghwZnRmmIfaePDcpiXwmPaubGz = 65535;
		if (MyAtAplkzyzucDuTAYhMusAinqv)
		{
			QRGctLEkwDmqYcBvBnTUtBvekRe();
			uDuCRIXDiJdYAcUJsgGStemDoZI = logicalMax + 1 + logicalMin;
		}
		if (isAxisButton)
		{
			hDOnQeSKxGGbLMkQRMcBItIfVdr = 0;
			uDuCRIXDiJdYAcUJsgGStemDoZI = 0;
			AbksekjAjXcNpZTOhDkNtKNShoF = 0;
		}
		Clear();
	}

	public override void Clear()
	{
		wmSvsDuQKkgIZvbYXgCGTuPJLgF = (uint)uDuCRIXDiJdYAcUJsgGStemDoZI;
	}

	private static float eQIYezsvzkTXXHzhjtMFCkAUCnSh(float P_0, float P_1, float P_2, float P_3, float P_4)
	{
		float num = P_2 - P_1;
		float result = default(float);
		if (MathTools.Approximately(num, 0f))
		{
			result = P_3;
		}
		else
		{
			while (true)
			{
				float num2 = P_4 - P_3;
				int num3 = 477997473;
				while (true)
				{
					switch (num3 ^ 0x1C7DA9A3)
					{
					case 0:
						num3 = 477997472;
						continue;
					case 3:
						break;
					case 2:
						result = (P_0 - P_1) * num2 / num + P_3;
						num3 = 477997474;
						continue;
					default:
						goto end_IL_0037;
					}
					break;
				}
				continue;
				end_IL_0037:
				break;
			}
		}
		return result;
	}

	private static int eQIYezsvzkTXXHzhjtMFCkAUCnSh(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		int num = P_2 - P_1;
		long num2 = default(long);
		if (num == 0)
		{
			num2 = P_3;
		}
		else
		{
			while (true)
			{
				int num3 = P_4 - P_3;
				int num4 = -1136512520;
				while (true)
				{
					switch (num4 ^ -1136512519)
					{
					case 3:
						num4 = -1136512517;
						continue;
					case 2:
						break;
					case 1:
						num2 = (long)(P_0 - P_1) * (long)num3 / num + P_3;
						num4 = -1136512519;
						continue;
					default:
						goto end_IL_002e;
					}
					break;
				}
				continue;
				end_IL_002e:
				break;
			}
		}
		return (int)num2;
	}

	private void QRGctLEkwDmqYcBvBnTUtBvekRe()
	{
		if (DXozfWWANnRhnvfEzwSPPGXGvcX <= 0)
		{
			return;
		}
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num = -559023872;
			while (true)
			{
				switch (num ^ -559023871)
				{
				case 0:
					break;
				case 3:
					eLvzhfKMorhWhTSPMECOzFuMYEn = num4 - 1;
					num = -559023868;
					continue;
				case 2:
					num3 = 1 << DXozfWWANnRhnvfEzwSPPGXGvcX;
					num4 = num3 >> 1;
					num = -559023870;
					continue;
				case 5:
					TOoesAYyGNqVpaBcbagtriQQanK = num3 * -1;
					num = -559023867;
					continue;
				case 1:
				{
					int num2;
					if (DXozfWWANnRhnvfEzwSPPGXGvcX < 32)
					{
						num = -559023869;
						num2 = num;
					}
					else
					{
						num = -559023865;
						num2 = num;
					}
					continue;
				}
				case 6:
					return;
				default:
					HtcGwDQOJcsVuNURqpiVtniVoC = true;
					return;
				}
				break;
			}
		}
	}
}
