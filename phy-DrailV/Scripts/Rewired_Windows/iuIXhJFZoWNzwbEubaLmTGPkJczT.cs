using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct iuIXhJFZoWNzwbEubaLmTGPkJczT
{
	private int SUXtJZQbYfOFUDhdMUuCRXgmRIus;

	private const int UICtDlidKCwxIsXaufFepuHcdnYp = 65534;

	private const int rKzQKDbokQVwiinRmsxeglEGVXDK = 16776960;

	public AZnevqKCIWQlsGzMgiuOiXlPUErU PRRpOkhGRpmYTaxqZbRqgXTDKOHx => (AZnevqKCIWQlsGzMgiuOiXlPUErU)(SUXtJZQbYfOFUDhdMUuCRXgmRIus & -16776961);

	public int cJPhLbYRACzcUTltXgrTIYHidBCMA => (SUXtJZQbYfOFUDhdMUuCRXgmRIus >> 8) & 0xFFFF;

	public iuIXhJFZoWNzwbEubaLmTGPkJczT(AZnevqKCIWQlsGzMgiuOiXlPUErU P_0, int P_1)
	{
		this = default(iuIXhJFZoWNzwbEubaLmTGPkJczT);
		SUXtJZQbYfOFUDhdMUuCRXgmRIus = (int)(P_0 & ~AZnevqKCIWQlsGzMgiuOiXlPUErU.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int IBFxjPKSVGakniVxxRyuoOQSHIuC(iuIXhJFZoWNzwbEubaLmTGPkJczT P_0)
	{
		return P_0.SUXtJZQbYfOFUDhdMUuCRXgmRIus;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(iuIXhJFZoWNzwbEubaLmTGPkJczT P_0)
	{
		return P_0.SUXtJZQbYfOFUDhdMUuCRXgmRIus == SUXtJZQbYfOFUDhdMUuCRXgmRIus;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(iuIXhJFZoWNzwbEubaLmTGPkJczT))
		{
			return false;
		}
		return JRxBWnhQlwwPGktFTDexAbegXFrzB((iuIXhJFZoWNzwbEubaLmTGPkJczT)P_0);
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return SUXtJZQbYfOFUDhdMUuCRXgmRIus;
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", new object[3] { PRRpOkhGRpmYTaxqZbRqgXTDKOHx, cJPhLbYRACzcUTltXgrTIYHidBCMA, SUXtJZQbYfOFUDhdMUuCRXgmRIus });
	}
}
