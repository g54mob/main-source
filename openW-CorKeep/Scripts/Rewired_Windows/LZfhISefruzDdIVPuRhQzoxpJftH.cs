using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct LZfhISefruzDdIVPuRhQzoxpJftH
{
	private int dJCfLkCUKwkMUVfnNuwjyPYOEtzr;

	private const int gXiHjQFcnSBzbLyFcylithYOYui = 65534;

	private const int XWSQZiObDFhJcGZrJkFlkrSPpUqE = 16776960;

	public vSIYNxlhLuRVvxutxhRoERRIotdU pGDeHoojINfTkjqOcpkEWPcgsbLeA => (vSIYNxlhLuRVvxutxhRoERRIotdU)(dJCfLkCUKwkMUVfnNuwjyPYOEtzr & -16776961);

	public int fVybPdBHpHAdIdQAliJeYZbxZdRLA => (dJCfLkCUKwkMUVfnNuwjyPYOEtzr >> 8) & 0xFFFF;

	public LZfhISefruzDdIVPuRhQzoxpJftH(vSIYNxlhLuRVvxutxhRoERRIotdU P_0, int P_1)
	{
		this = default(LZfhISefruzDdIVPuRhQzoxpJftH);
		dJCfLkCUKwkMUVfnNuwjyPYOEtzr = (int)(P_0 & ~vSIYNxlhLuRVvxutxhRoERRIotdU.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int zvNMOeshMmYXaRXqqTJnzELgBBcZ(LZfhISefruzDdIVPuRhQzoxpJftH P_0)
	{
		return P_0.dJCfLkCUKwkMUVfnNuwjyPYOEtzr;
	}

	public bool fWuCpFbLwxpWxTiPbdqzaVZmwfve(LZfhISefruzDdIVPuRhQzoxpJftH P_0)
	{
		return P_0.dJCfLkCUKwkMUVfnNuwjyPYOEtzr == dJCfLkCUKwkMUVfnNuwjyPYOEtzr;
	}

	public bool jLSeqKAxQcRwSjdophcPgqIkizmn(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(LZfhISefruzDdIVPuRhQzoxpJftH))
		{
			return false;
		}
		return fWuCpFbLwxpWxTiPbdqzaVZmwfve((LZfhISefruzDdIVPuRhQzoxpJftH)P_0);
	}

	public int hFsngFmDeIPrPnJZqCPcNsjttGUL()
	{
		return dJCfLkCUKwkMUVfnNuwjyPYOEtzr;
	}

	public string xhDGzteEtJadCygunzMPxLQwZtBH()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", pGDeHoojINfTkjqOcpkEWPcgsbLeA, fVybPdBHpHAdIdQAliJeYZbxZdRLA, dJCfLkCUKwkMUVfnNuwjyPYOEtzr);
	}
}
