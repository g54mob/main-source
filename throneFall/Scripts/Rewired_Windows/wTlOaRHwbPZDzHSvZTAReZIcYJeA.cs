using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct wTlOaRHwbPZDzHSvZTAReZIcYJeA
{
	private int MUwNsItSLroVcezoOqRlUAabanVi;

	private const int LvzPcLvGxeavNCvxImmtABujRbIf = 65534;

	private const int kbobOpfsjITNQlYbGaDpKBxmmyMD = 16776960;

	public SBgCiXgUYzMrBAKimxFgjcthAaBfb UWpOyWLwHKPlYFYBrpyIxICBRkrM => (SBgCiXgUYzMrBAKimxFgjcthAaBfb)(MUwNsItSLroVcezoOqRlUAabanVi & -16776961);

	public int AnEwODsnsMHPczMTeHagpYHAsGrH => (MUwNsItSLroVcezoOqRlUAabanVi >> 8) & 0xFFFF;

	public wTlOaRHwbPZDzHSvZTAReZIcYJeA(SBgCiXgUYzMrBAKimxFgjcthAaBfb P_0, int P_1)
	{
		this = default(wTlOaRHwbPZDzHSvZTAReZIcYJeA);
		MUwNsItSLroVcezoOqRlUAabanVi = (int)(P_0 & ~SBgCiXgUYzMrBAKimxFgjcthAaBfb.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int AClIrUTtZnSnMoopvmPlFNrFqUWO(wTlOaRHwbPZDzHSvZTAReZIcYJeA P_0)
	{
		return P_0.MUwNsItSLroVcezoOqRlUAabanVi;
	}

	public bool WIYzjvMUynRXCsnKcvbnYxLRxDCB(wTlOaRHwbPZDzHSvZTAReZIcYJeA P_0)
	{
		return P_0.MUwNsItSLroVcezoOqRlUAabanVi == MUwNsItSLroVcezoOqRlUAabanVi;
	}

	public bool WSkPZyrvBzklgKMnsaWXUWgNcjCH(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(wTlOaRHwbPZDzHSvZTAReZIcYJeA))
		{
			return false;
		}
		return WIYzjvMUynRXCsnKcvbnYxLRxDCB((wTlOaRHwbPZDzHSvZTAReZIcYJeA)P_0);
	}

	public int YYCAffTldZxodSYBbQVkzHJQedaG()
	{
		return MUwNsItSLroVcezoOqRlUAabanVi;
	}

	public string OTzAxZHUNAjGmJmdeExBPPaTMOtx()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", UWpOyWLwHKPlYFYBrpyIxICBRkrM, AnEwODsnsMHPczMTeHagpYHAsGrH, MUwNsItSLroVcezoOqRlUAabanVi);
	}
}
