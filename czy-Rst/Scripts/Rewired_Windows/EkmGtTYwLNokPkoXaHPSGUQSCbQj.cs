using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class EkmGtTYwLNokPkoXaHPSGUQSCbQj : MTDdOUAQDDlORdpeJZWconHqnhGgA
{
	[CompilerGenerated]
	private cMDsIQfAdJNMqwKkEVWeEqUURztR[] GZyAaveCSNihnARWJrauVhXFFbzUA;

	public cMDsIQfAdJNMqwKkEVWeEqUURztR[] JkfEoNORkLvkoUYoHFRbejJRdhXd
	{
		[CompilerGenerated]
		get
		{
			return GZyAaveCSNihnARWJrauVhXFFbzUA;
		}
		[CompilerGenerated]
		set
		{
			GZyAaveCSNihnARWJrauVhXFFbzUA = gZyAaveCSNihnARWJrauVhXFFbzUA;
		}
	}

	unsafe int MTDdOUAQDDlORdpeJZWconHqnhGgA.ckSYfNvnjCgLabGSZghzoKsihUeEA
	{
		get
		{
			if (JkfEoNORkLvkoUYoHFRbejJRdhXd == null)
			{
				return 0;
			}
			return JkfEoNORkLvkoUYoHFRbejJRdhXd.Length * sizeof(cMDsIQfAdJNMqwKkEVWeEqUURztR);
		}
	}

	protected unsafe virtual MTDdOUAQDDlORdpeJZWconHqnhGgA tYcopYNbgPfevdswpntywPjGLSzM(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(cMDsIQfAdJNMqwKkEVWeEqUURztR) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(cMDsIQfAdJNMqwKkEVWeEqUURztR);
		JkfEoNORkLvkoUYoHFRbejJRdhXd = new cMDsIQfAdJNMqwKkEVWeEqUURztR[num];
		fixed (cMDsIQfAdJNMqwKkEVWeEqUURztR* ptr = JkfEoNORkLvkoUYoHFRbejJRdhXd)
		{
			klLdHAhsLOLqXXQXtowmGbeHymvN.YWRxEuxdXPFHNctXvomvIDJsuVkx((IntPtr)ptr, P_1, klLdHAhsLOLqXXQXtowmGbeHymvN.rVnpQEHUYioUOZUzhgsfNBDWKcVE<cMDsIQfAdJNMqwKkEVWeEqUURztR>() * JkfEoNORkLvkoUYoHFRbejJRdhXd.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr mtvHJWsjeawKuPAanANGGKFXRVCg()
	{
		if (ckSYfNvnjCgLabGSZghzoKsihUeEA == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(ckSYfNvnjCgLabGSZghzoKsihUeEA);
		fixed (cMDsIQfAdJNMqwKkEVWeEqUURztR* ptr = JkfEoNORkLvkoUYoHFRbejJRdhXd)
		{
			klLdHAhsLOLqXXQXtowmGbeHymvN.YWRxEuxdXPFHNctXvomvIDJsuVkx(intPtr, (IntPtr)ptr, klLdHAhsLOLqXXQXtowmGbeHymvN.rVnpQEHUYioUOZUzhgsfNBDWKcVE<cMDsIQfAdJNMqwKkEVWeEqUURztR>() * JkfEoNORkLvkoUYoHFRbejJRdhXd.Length);
		}
		return intPtr;
	}
}
