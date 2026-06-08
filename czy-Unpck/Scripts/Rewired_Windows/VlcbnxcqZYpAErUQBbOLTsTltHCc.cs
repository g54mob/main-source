using Rewired.Utils;

internal class VlcbnxcqZYpAErUQBbOLTsTltHCc : ptXOnWbeLmbselManuitCDvpKWb
{
	public readonly int owpCzsOHowPtPCycfhXMJbMttXE;

	public readonly int NBXHlgsLiXQGxOdZyFrgeqmnFpcM;

	public readonly int nxHAIFHBMjrmySgnMFTEBePTrTkg;

	public readonly int BZXVyrhYVnUdNZAqBzzPqLoMJqv;

	public readonly int MuYzmmZEKyzPAXUERLMcftDwDIF;

	public readonly int RNsmyohBzmkmqgahpCBrEmwmRIcI;

	public readonly uint gIxCAbhzrilPVmUnYFeVFgFCkBWy;

	public readonly uint QAgCQFAkZzLrDcpXIjkSYVjjGwIq;

	public readonly int DFFttwWFbMiFZketOwjQRmGiZXuL;

	private readonly int CrnnuOPspuSfjzGaVCIRNiyJjTi;

	public uint lGpyvYcIyUaWjAtqbNROdSiPlaxt;

	public int value
	{
		get
		{
			if (lGpyvYcIyUaWjAtqbNROdSiPlaxt < owpCzsOHowPtPCycfhXMJbMttXE)
			{
				goto IL_003e;
			}
			if (lGpyvYcIyUaWjAtqbNROdSiPlaxt > NBXHlgsLiXQGxOdZyFrgeqmnFpcM)
			{
				goto IL_0020;
			}
			int num = (int)((lGpyvYcIyUaWjAtqbNROdSiPlaxt - owpCzsOHowPtPCycfhXMJbMttXE) / CrnnuOPspuSfjzGaVCIRNiyJjTi * 4500);
			int num2;
			if (num >= 36000)
			{
				num = 0;
				num2 = 1971799814;
				goto IL_0025;
			}
			goto IL_0071;
			IL_0025:
			switch (num2 ^ 0x75874707)
			{
			case 0:
				break;
			case 2:
				goto IL_003e;
			default:
				goto IL_0071;
			}
			goto IL_0020;
			IL_003e:
			return -1;
			IL_0071:
			return num;
			IL_0020:
			num2 = 1971799813;
			goto IL_0025;
		}
	}

	public VlcbnxcqZYpAErUQBbOLTsTltHCc(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		while (true)
		{
			int num = -876248222;
			while (true)
			{
				switch (num ^ -876248223)
				{
				case 0:
					break;
				case 5:
					if (nxHAIFHBMjrmySgnMFTEBePTrTkg < 0)
					{
						nxHAIFHBMjrmySgnMFTEBePTrTkg = logicalMax + 1;
						num = -876248219;
						continue;
					}
					goto default;
				case 1:
					NBXHlgsLiXQGxOdZyFrgeqmnFpcM = logicalMax;
					gIxCAbhzrilPVmUnYFeVFgFCkBWy = units;
					QAgCQFAkZzLrDcpXIjkSYVjjGwIq = unitsExp;
					DFFttwWFbMiFZketOwjQRmGiZXuL = reportIndex;
					num = -876248221;
					continue;
				case 3:
					owpCzsOHowPtPCycfhXMJbMttXE = logicalMin;
					num = -876248224;
					continue;
				case 2:
					nxHAIFHBMjrmySgnMFTEBePTrTkg = logicalMin - 1;
					num = -876248220;
					continue;
				default:
				{
					RNsmyohBzmkmqgahpCBrEmwmRIcI = -1;
					int num2 = logicalMax - logicalMin + 1;
					CrnnuOPspuSfjzGaVCIRNiyJjTi = MathTools.Clamp(num2 / 8, 1, int.MaxValue);
					ibajyEOvcZaAVvqbaVIEPkwcIqx();
					return;
				}
				}
				break;
			}
		}
	}

	public override void ibajyEOvcZaAVvqbaVIEPkwcIqx()
	{
		lGpyvYcIyUaWjAtqbNROdSiPlaxt = (uint)nxHAIFHBMjrmySgnMFTEBePTrTkg;
	}
}
