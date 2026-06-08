using Rewired.Utils;

internal class pyZQbMTATyVfguiHEyKaPAqwFRx : ptXOnWbeLmbselManuitCDvpKWb
{
	public readonly bool XkfkxXroKQbHSVTIsaPjhzZqDvA;

	private int reIklgCzgRJZXNKcwHQMgDRAAWV;

	private int ARciFdQqhbCNvoQaPvpJgvjMbgX;

	private bool GmUiSzDxorsWvsvmtgxaWjMqGos;

	public readonly int owpCzsOHowPtPCycfhXMJbMttXE;

	public readonly int NBXHlgsLiXQGxOdZyFrgeqmnFpcM;

	public readonly int nxHAIFHBMjrmySgnMFTEBePTrTkg;

	public readonly int BZXVyrhYVnUdNZAqBzzPqLoMJqv;

	public readonly int MuYzmmZEKyzPAXUERLMcftDwDIF;

	public readonly int RNsmyohBzmkmqgahpCBrEmwmRIcI;

	public readonly uint gIxCAbhzrilPVmUnYFeVFgFCkBWy;

	public readonly uint haREVXXTjbqlSbehufGPngmyHzi;

	public readonly int DFFttwWFbMiFZketOwjQRmGiZXuL;

	public uint lGpyvYcIyUaWjAtqbNROdSiPlaxt;

	public virtual int value
	{
		get
		{
			int num = (int)lGpyvYcIyUaWjAtqbNROdSiPlaxt;
			while (true)
			{
				int num2 = -1696650226;
				while (true)
				{
					switch (num2 ^ -1696650227)
					{
					case 2:
						break;
					case 3:
					{
						int num3;
						if (XkfkxXroKQbHSVTIsaPjhzZqDvA)
						{
							num2 = -1696650227;
							num3 = num2;
						}
						else
						{
							num2 = -1696650228;
							num3 = num2;
						}
						continue;
					}
					case 0:
						if (GmUiSzDxorsWvsvmtgxaWjMqGos && num > reIklgCzgRJZXNKcwHQMgDRAAWV)
						{
							num += ARciFdQqhbCNvoQaPvpJgvjMbgX;
							num2 = -1696650228;
							continue;
						}
						goto default;
					default:
						if (num == nxHAIFHBMjrmySgnMFTEBePTrTkg)
						{
							return RNsmyohBzmkmqgahpCBrEmwmRIcI;
						}
						return (int)dCxcdcydFMdbfDxBTARVVxtELbo((float)num, (float)owpCzsOHowPtPCycfhXMJbMttXE, (float)NBXHlgsLiXQGxOdZyFrgeqmnFpcM, (float)BZXVyrhYVnUdNZAqBzzPqLoMJqv, (float)MuYzmmZEKyzPAXUERLMcftDwDIF);
					}
					break;
				}
			}
		}
	}

	public pyZQbMTATyVfguiHEyKaPAqwFRx(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex, bool isAxisButton)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		owpCzsOHowPtPCycfhXMJbMttXE = logicalMin;
		NBXHlgsLiXQGxOdZyFrgeqmnFpcM = logicalMax;
		gIxCAbhzrilPVmUnYFeVFgFCkBWy = units;
		haREVXXTjbqlSbehufGPngmyHzi = unitsExp;
		DFFttwWFbMiFZketOwjQRmGiZXuL = reportIndex;
		XkfkxXroKQbHSVTIsaPjhzZqDvA = logicalMin < 0 || logicalMax < 0;
		if (logicalMin > logicalMax || logicalMax - logicalMin < 2)
		{
			if (logicalMin == 0 && logicalMax < 0 && physicalMin == 0 && physicalMax < 0)
			{
				XkfkxXroKQbHSVTIsaPjhzZqDvA = false;
			}
			if (bitSize > 1 && bitSize < 32)
			{
				int num = 1 << bitSize;
				if (XkfkxXroKQbHSVTIsaPjhzZqDvA)
				{
					nxHAIFHBMjrmySgnMFTEBePTrTkg = 0;
					owpCzsOHowPtPCycfhXMJbMttXE = num * -1;
					NBXHlgsLiXQGxOdZyFrgeqmnFpcM = num - 1;
				}
				else
				{
					nxHAIFHBMjrmySgnMFTEBePTrTkg = num >> 1;
					owpCzsOHowPtPCycfhXMJbMttXE = 0;
					NBXHlgsLiXQGxOdZyFrgeqmnFpcM = num - 1;
				}
			}
			else if (XkfkxXroKQbHSVTIsaPjhzZqDvA)
			{
				nxHAIFHBMjrmySgnMFTEBePTrTkg = 0;
				owpCzsOHowPtPCycfhXMJbMttXE = -32768;
				NBXHlgsLiXQGxOdZyFrgeqmnFpcM = 32767;
			}
			else
			{
				nxHAIFHBMjrmySgnMFTEBePTrTkg = 32768;
				owpCzsOHowPtPCycfhXMJbMttXE = 0;
				NBXHlgsLiXQGxOdZyFrgeqmnFpcM = 65535;
			}
		}
		else
		{
			nxHAIFHBMjrmySgnMFTEBePTrTkg = (NBXHlgsLiXQGxOdZyFrgeqmnFpcM - owpCzsOHowPtPCycfhXMJbMttXE) / 2;
		}
		RNsmyohBzmkmqgahpCBrEmwmRIcI = 0;
		BZXVyrhYVnUdNZAqBzzPqLoMJqv = -65535;
		MuYzmmZEKyzPAXUERLMcftDwDIF = 65535;
		if (XkfkxXroKQbHSVTIsaPjhzZqDvA)
		{
			NkpEfSbMUbOEiguBvaWWbgQgULCH();
			nxHAIFHBMjrmySgnMFTEBePTrTkg = logicalMax + 1 + logicalMin;
		}
		if (isAxisButton)
		{
			owpCzsOHowPtPCycfhXMJbMttXE = 0;
			nxHAIFHBMjrmySgnMFTEBePTrTkg = 0;
			BZXVyrhYVnUdNZAqBzzPqLoMJqv = 0;
		}
		ibajyEOvcZaAVvqbaVIEPkwcIqx();
	}

	public override void ibajyEOvcZaAVvqbaVIEPkwcIqx()
	{
		lGpyvYcIyUaWjAtqbNROdSiPlaxt = (uint)nxHAIFHBMjrmySgnMFTEBePTrTkg;
	}

	private static float dCxcdcydFMdbfDxBTARVVxtELbo(float P_0, float P_1, float P_2, float P_3, float P_4)
	{
		float num = P_2 - P_1;
		float result;
		if (MathTools.Approximately(num, 0f))
		{
			result = P_3;
			goto IL_0013;
		}
		goto IL_003c;
		IL_003c:
		float num2 = P_4 - P_3;
		result = (P_0 - P_1) * num2 / num + P_3;
		int num3 = -1939098304;
		goto IL_0018;
		IL_0013:
		num3 = -1939098302;
		goto IL_0018;
		IL_0018:
		while (true)
		{
			switch (num3 ^ -1939098303)
			{
			case 2:
				break;
			case 3:
				num3 = -1939098304;
				continue;
			case 0:
				goto IL_003c;
			default:
				return result;
			}
			break;
		}
		goto IL_0013;
	}

	private static int dCxcdcydFMdbfDxBTARVVxtELbo(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		int num = P_2 - P_1;
		int num4 = default(int);
		long num3 = default(long);
		while (true)
		{
			int num2 = -471424510;
			while (true)
			{
				switch (num2 ^ -471424509)
				{
				case 4:
					break;
				case 2:
					num4 = P_4 - P_3;
					num2 = -471424506;
					continue;
				case 0:
					num3 = P_3;
					num2 = -471424512;
					continue;
				case 1:
				{
					int num5;
					if (num == 0)
					{
						num2 = -471424509;
						num5 = num2;
					}
					else
					{
						num2 = -471424511;
						num5 = num2;
					}
					continue;
				}
				case 5:
					num3 = (long)(P_0 - P_1) * (long)num4 / num + P_3;
					num2 = -471424512;
					continue;
				default:
					return (int)num3;
				}
				break;
			}
		}
	}

	private void NkpEfSbMUbOEiguBvaWWbgQgULCH()
	{
		if (MDDurJKjkNmnDhHcVftFKYeQqjhI > 0)
		{
			if (MDDurJKjkNmnDhHcVftFKYeQqjhI >= 32)
			{
				goto IL_0013;
			}
			goto IL_003d;
		}
		return;
		IL_003d:
		int num = 1 << MDDurJKjkNmnDhHcVftFKYeQqjhI;
		int num2 = num >> 1;
		reIklgCzgRJZXNKcwHQMgDRAAWV = num2 - 1;
		ARciFdQqhbCNvoQaPvpJgvjMbgX = num * -1;
		int num3 = 568184218;
		goto IL_0018;
		IL_0013:
		num3 = 568184216;
		goto IL_0018;
		IL_0018:
		switch (num3 ^ 0x21DDCD99)
		{
		case 0:
			break;
		case 1:
			return;
		case 2:
			goto IL_003d;
		default:
			GmUiSzDxorsWvsvmtgxaWjMqGos = true;
			return;
		}
		goto IL_0013;
	}
}
