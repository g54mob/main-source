using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct AnaDKTHMGVLMaRbxExNCSFSgbsQt
{
	private int qpHFdzBzfVZcLEIBnMAxeBrVNQGUA;

	private const int pPYdWgpyLSFomkCMzpYtHNCPGxZs = 65534;

	private const int AxPeECbYYgTpfLGjnCTtLPMKKWLf = 16776960;

	public ohTLfsCnqDzhumcBDNxmtssJOYWS yrYglbiJtyhblKhgSIEStyVbbMuYA => (ohTLfsCnqDzhumcBDNxmtssJOYWS)(qpHFdzBzfVZcLEIBnMAxeBrVNQGUA & -16776961);

	public int wnMbiTsSqdTFOZaPEtyBoImQGqCA => (qpHFdzBzfVZcLEIBnMAxeBrVNQGUA >> 8) & 0xFFFF;

	public AnaDKTHMGVLMaRbxExNCSFSgbsQt(ohTLfsCnqDzhumcBDNxmtssJOYWS P_0, int P_1)
	{
		this = default(AnaDKTHMGVLMaRbxExNCSFSgbsQt);
		qpHFdzBzfVZcLEIBnMAxeBrVNQGUA = (int)(P_0 & ~ohTLfsCnqDzhumcBDNxmtssJOYWS.AnyInstance) | ((!(P_1 < 0 || P_1 > 65534)) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	[SpecialName]
	public static int exWXebRZpLslzOPYYxdpEDmzZmFq(AnaDKTHMGVLMaRbxExNCSFSgbsQt P_0)
	{
		return P_0.qpHFdzBzfVZcLEIBnMAxeBrVNQGUA;
	}

	public bool wrdozIMGuEFLwGXMDRSjHuafXyKH(AnaDKTHMGVLMaRbxExNCSFSgbsQt P_0)
	{
		return P_0.qpHFdzBzfVZcLEIBnMAxeBrVNQGUA == qpHFdzBzfVZcLEIBnMAxeBrVNQGUA;
	}

	public bool qOJgWZnknNcdFeyWJiEFoTznbWLOA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(AnaDKTHMGVLMaRbxExNCSFSgbsQt))
		{
			return false;
		}
		return wrdozIMGuEFLwGXMDRSjHuafXyKH((AnaDKTHMGVLMaRbxExNCSFSgbsQt)P_0);
	}

	public int igdPWARULrvzIyojKgMcegGiYmxk()
	{
		return qpHFdzBzfVZcLEIBnMAxeBrVNQGUA;
	}

	public string eMUeOmTDnsCdZjWMFHvRWJtjkDcm()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", yrYglbiJtyhblKhgSIEStyVbbMuYA, wnMbiTsSqdTFOZaPEtyBoImQGqCA, qpHFdzBzfVZcLEIBnMAxeBrVNQGUA);
	}
}
