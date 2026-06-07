using Rewired.Utils;

internal class QKXAlowNpmmkcCKidMLBxmsteVme : ufceATEjpSRUYdfYDUvzCHYnyGXC
{
	public readonly int hDOnQeSKxGGbLMkQRMcBItIfVdr;

	public readonly int ScalzooAtVoPBEnEMmqglTvGnSi;

	public readonly int uDuCRIXDiJdYAcUJsgGStemDoZI;

	public readonly int AbksekjAjXcNpZTOhDkNtKNShoF;

	public readonly int PghwZnRmmIfaePDcpiXwmPaubGz;

	public readonly int GVHeWjdRAOSfAiABFEGtbrVgIlM;

	public readonly uint zUESHatBDEizbqEBmCnRdngCjNet;

	public readonly uint BoVKjAiHnJXWjnApDDhQKeUCJys;

	public readonly int OfifItGmJqvFzsNTowFSnGdiILS;

	private readonly int ZjUydFHDXUowBljGzPNFUWDLBTM;

	public uint wmSvsDuQKkgIZvbYXgCGTuPJLgF;

	public int value
	{
		get
		{
			if (wmSvsDuQKkgIZvbYXgCGTuPJLgF >= hDOnQeSKxGGbLMkQRMcBItIfVdr)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 1611413648;
					while (true)
					{
						switch (num ^ 0x600C3892)
						{
						case 3:
							break;
						case 2:
							goto IL_0032;
						case 1:
							goto end_IL_0010;
						default:
							goto IL_007c;
						}
						break;
						IL_0032:
						if (wmSvsDuQKkgIZvbYXgCGTuPJLgF > ScalzooAtVoPBEnEMmqglTvGnSi)
						{
							num = 1611413651;
							continue;
						}
						num2 = (int)((wmSvsDuQKkgIZvbYXgCGTuPJLgF - hDOnQeSKxGGbLMkQRMcBItIfVdr) / ZjUydFHDXUowBljGzPNFUWDLBTM * 4500);
						if (num2 >= 36000)
						{
							num2 = 0;
							num = 1611413650;
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

	public QKXAlowNpmmkcCKidMLBxmsteVme(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		hDOnQeSKxGGbLMkQRMcBItIfVdr = logicalMin;
		ScalzooAtVoPBEnEMmqglTvGnSi = logicalMax;
		zUESHatBDEizbqEBmCnRdngCjNet = units;
		BoVKjAiHnJXWjnApDDhQKeUCJys = unitsExp;
		OfifItGmJqvFzsNTowFSnGdiILS = reportIndex;
		uDuCRIXDiJdYAcUJsgGStemDoZI = logicalMin - 1;
		if (uDuCRIXDiJdYAcUJsgGStemDoZI < 0)
		{
			uDuCRIXDiJdYAcUJsgGStemDoZI = logicalMax + 1;
		}
		GVHeWjdRAOSfAiABFEGtbrVgIlM = -1;
		int num = logicalMax - logicalMin + 1;
		ZjUydFHDXUowBljGzPNFUWDLBTM = MathTools.Clamp(num / 8, 1, int.MaxValue);
		Clear();
	}

	public override void Clear()
	{
		wmSvsDuQKkgIZvbYXgCGTuPJLgF = (uint)uDuCRIXDiJdYAcUJsgGStemDoZI;
	}
}
