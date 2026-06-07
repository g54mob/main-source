using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct ioMbqgBuzgMwjSpXgscYjfLuKToIA
{
	private int YcnCeIWaWyaVWaTrXrHdwCiVWdoT;

	private const int NhuXrHCWelwLdMrgHCXvcmBJjOhJA = 65534;

	private const int qqbuNzCTlJPggbqVZBTtfiZOhvhnA = 16776960;

	public YHfQBlzXCaSKvSbTpixeOhmZfxid MfuKxYoSWBOzmTFQkZMEBFQpIhEP => (YHfQBlzXCaSKvSbTpixeOhmZfxid)(YcnCeIWaWyaVWaTrXrHdwCiVWdoT & -16776961);

	public int YGRoEFHPlDhcWhFWfcmscHFqClYXA => (YcnCeIWaWyaVWaTrXrHdwCiVWdoT >> 8) & 0xFFFF;

	public ioMbqgBuzgMwjSpXgscYjfLuKToIA(YHfQBlzXCaSKvSbTpixeOhmZfxid P_0, int P_1)
	{
		this = default(ioMbqgBuzgMwjSpXgscYjfLuKToIA);
		YcnCeIWaWyaVWaTrXrHdwCiVWdoT = (int)(P_0 & ~YHfQBlzXCaSKvSbTpixeOhmZfxid.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int OPyAFCcOMsJOiebuissnngftmDtP(ioMbqgBuzgMwjSpXgscYjfLuKToIA P_0)
	{
		return P_0.YcnCeIWaWyaVWaTrXrHdwCiVWdoT;
	}

	public bool GgXePrHzPrAepoacjxQrowdxvmcKA(ioMbqgBuzgMwjSpXgscYjfLuKToIA P_0)
	{
		return P_0.YcnCeIWaWyaVWaTrXrHdwCiVWdoT == YcnCeIWaWyaVWaTrXrHdwCiVWdoT;
	}

	public bool IZbnJgEQOkIlKUZuzNQPsRsxlLxK(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(ioMbqgBuzgMwjSpXgscYjfLuKToIA))
		{
			return false;
		}
		return GgXePrHzPrAepoacjxQrowdxvmcKA((ioMbqgBuzgMwjSpXgscYjfLuKToIA)P_0);
	}

	public int YvFgmhdosUSMZgSFuPzoALJfivXlb()
	{
		return YcnCeIWaWyaVWaTrXrHdwCiVWdoT;
	}

	public string WdkIFXyWYFTrMJXmtsKDtimbQHYT()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", MfuKxYoSWBOzmTFQkZMEBFQpIhEP, YGRoEFHPlDhcWhFWfcmscHFqClYXA, YcnCeIWaWyaVWaTrXrHdwCiVWdoT);
	}
}
