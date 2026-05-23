using Rewired.Utils;

internal class GdbsuUDypqSdpDKGWLJDomgHxLk : oOUJfnGBpWTsFejgentlKaCBYgD
{
	public readonly int voyPeMvTdKkhOBnssojXFaWVrih;

	public readonly int ExQYmZHPOpkfYFUTrPskytBTbhI;

	public readonly int uVANTgwnyBETHzfdRGWAguizIHCl;

	public readonly int ArMDlCYbxRqAwESkORqFatRqTsT;

	public readonly int LlPhdHqTkMNmjAbACfBehxyQwIbh;

	public readonly int QzdEpBJATCyLZsbnmhOnfuLFKEUx;

	public readonly uint vXwqBMMCDSoocvThZFrJwvogoDk;

	public readonly uint TZnQLoHUtRuUaszNufzQPtAoQuc;

	public readonly int GhCjwDzgPeRiilJpDjaIbcvQALMW;

	private readonly int XHyunzyVOltMZaaCpPLURNxITCM;

	public uint slcDutVbWmJxSkNwoiIYAENfAsLd;

	public int value
	{
		get
		{
			if (slcDutVbWmJxSkNwoiIYAENfAsLd >= voyPeMvTdKkhOBnssojXFaWVrih)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -1117550160;
					while (true)
					{
						switch (num ^ -1117550159)
						{
						case 0:
							break;
						case 1:
							goto IL_0032;
						case 3:
							goto end_IL_0010;
						default:
							goto IL_007c;
						}
						break;
						IL_0032:
						if (slcDutVbWmJxSkNwoiIYAENfAsLd > ExQYmZHPOpkfYFUTrPskytBTbhI)
						{
							num = -1117550158;
							continue;
						}
						num2 = (int)((slcDutVbWmJxSkNwoiIYAENfAsLd - voyPeMvTdKkhOBnssojXFaWVrih) / XHyunzyVOltMZaaCpPLURNxITCM * 4500);
						if (num2 >= 36000)
						{
							num2 = 0;
							num = -1117550157;
							continue;
						}
						goto IL_007c;
						IL_007c:
						return num2;
					}
					continue;
					end_IL_0010:
					break;
				}
			}
			return -1;
		}
	}

	public GdbsuUDypqSdpDKGWLJDomgHxLk(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		voyPeMvTdKkhOBnssojXFaWVrih = logicalMin;
		ExQYmZHPOpkfYFUTrPskytBTbhI = logicalMax;
		vXwqBMMCDSoocvThZFrJwvogoDk = units;
		TZnQLoHUtRuUaszNufzQPtAoQuc = unitsExp;
		GhCjwDzgPeRiilJpDjaIbcvQALMW = reportIndex;
		uVANTgwnyBETHzfdRGWAguizIHCl = logicalMin - 1;
		if (uVANTgwnyBETHzfdRGWAguizIHCl < 0)
		{
			uVANTgwnyBETHzfdRGWAguizIHCl = logicalMax + 1;
		}
		QzdEpBJATCyLZsbnmhOnfuLFKEUx = -1;
		int num = logicalMax - logicalMin + 1;
		XHyunzyVOltMZaaCpPLURNxITCM = MathTools.Clamp(num / 8, 1, int.MaxValue);
		Clear();
	}

	public override void Clear()
	{
		slcDutVbWmJxSkNwoiIYAENfAsLd = (uint)uVANTgwnyBETHzfdRGWAguizIHCl;
	}
}
