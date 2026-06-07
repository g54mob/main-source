using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct eCwyLHjKgvgUGHdeqEWwVNspiWbi
{
	private int SazioPgJOOZughqpZWSYVpDpFAwbA;

	private const int IycGmbSMCfxMiWSmbndwfxehEhAM = 65534;

	private const int lSLZbBVzelIHSWJNzuZeoFnJALVT = 16776960;

	public QuRXCgqlOlcEEHiUdqMIjqUfOWncc VLbBlajDRCKlfsUoYsvoOwmKeETSA => (QuRXCgqlOlcEEHiUdqMIjqUfOWncc)(SazioPgJOOZughqpZWSYVpDpFAwbA & -16776961);

	public int eEbckdByMhHXmLbbIORDTKabCFCcb => (SazioPgJOOZughqpZWSYVpDpFAwbA >> 8) & 0xFFFF;

	public eCwyLHjKgvgUGHdeqEWwVNspiWbi(QuRXCgqlOlcEEHiUdqMIjqUfOWncc P_0, int P_1)
	{
		this = default(eCwyLHjKgvgUGHdeqEWwVNspiWbi);
		SazioPgJOOZughqpZWSYVpDpFAwbA = (int)(P_0 & ~QuRXCgqlOlcEEHiUdqMIjqUfOWncc.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int EhlIBZuRXpPFFALwqxqKexCFDuzb(eCwyLHjKgvgUGHdeqEWwVNspiWbi P_0)
	{
		return P_0.SazioPgJOOZughqpZWSYVpDpFAwbA;
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(eCwyLHjKgvgUGHdeqEWwVNspiWbi P_0)
	{
		return P_0.SazioPgJOOZughqpZWSYVpDpFAwbA == SazioPgJOOZughqpZWSYVpDpFAwbA;
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(eCwyLHjKgvgUGHdeqEWwVNspiWbi))
		{
			return false;
		}
		return XGTrzxcWbPBiyHnRYfIhrjXAmNvN((eCwyLHjKgvgUGHdeqEWwVNspiWbi)P_0);
	}

	public int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return SazioPgJOOZughqpZWSYVpDpFAwbA;
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", new object[3] { VLbBlajDRCKlfsUoYsvoOwmKeETSA, eEbckdByMhHXmLbbIORDTKabCFCcb, SazioPgJOOZughqpZWSYVpDpFAwbA });
	}
}
