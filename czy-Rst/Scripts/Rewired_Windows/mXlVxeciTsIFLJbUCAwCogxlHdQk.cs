using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct mXlVxeciTsIFLJbUCAwCogxlHdQk
{
	private int UDWHjQUXJaebeEKetwlbQpMCFzSEb;

	private const int RUBdCRQupbCnHoBxlLxrxxxMJQNs = 65534;

	private const int eLKmTtYxkXApGTGWthrztztTKlHr = 16776960;

	public WVKLnHnnIsWeFoDkVmYeRlTOGpEs QWXGfOKoRPqaKxdTGIdQAIsbirqIB => (WVKLnHnnIsWeFoDkVmYeRlTOGpEs)(UDWHjQUXJaebeEKetwlbQpMCFzSEb & -16776961);

	public int EcbiDJuaTWMwHCXJSAaABnjzTmK => (UDWHjQUXJaebeEKetwlbQpMCFzSEb >> 8) & 0xFFFF;

	public mXlVxeciTsIFLJbUCAwCogxlHdQk(WVKLnHnnIsWeFoDkVmYeRlTOGpEs P_0, int P_1)
	{
		this = default(mXlVxeciTsIFLJbUCAwCogxlHdQk);
		UDWHjQUXJaebeEKetwlbQpMCFzSEb = (int)(P_0 & ~WVKLnHnnIsWeFoDkVmYeRlTOGpEs.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int GsVyoOunFebkIKChWKQxCsHqvFBcA(mXlVxeciTsIFLJbUCAwCogxlHdQk P_0)
	{
		return P_0.UDWHjQUXJaebeEKetwlbQpMCFzSEb;
	}

	public bool MckuYtdFOtUjRWnXBqDztDFgoPSG(mXlVxeciTsIFLJbUCAwCogxlHdQk P_0)
	{
		return P_0.UDWHjQUXJaebeEKetwlbQpMCFzSEb == UDWHjQUXJaebeEKetwlbQpMCFzSEb;
	}

	public bool IdYiOkCQVqHwgaazbPxTNnESirJkc(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(mXlVxeciTsIFLJbUCAwCogxlHdQk))
		{
			return false;
		}
		return MckuYtdFOtUjRWnXBqDztDFgoPSG((mXlVxeciTsIFLJbUCAwCogxlHdQk)P_0);
	}

	public int YRwRhrmwzModdupEORreMTlzbWzG()
	{
		return UDWHjQUXJaebeEKetwlbQpMCFzSEb;
	}

	public string EbLeBBguXDXBgvLjLslDqUYaVXcf()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", QWXGfOKoRPqaKxdTGIdQAIsbirqIB, EcbiDJuaTWMwHCXJSAaABnjzTmK, UDWHjQUXJaebeEKetwlbQpMCFzSEb);
	}
}
