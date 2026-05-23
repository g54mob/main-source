using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal class ZTjdkWAkGMFOlwjyFpjqdQDLngXx
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int SfmqORkwIwsJeyjKwzbhVsicett(int arg0, void* arg1);

	private static bool xmFAxXlJtKlTBSwJClTqGnusDVD;

	private static DnqsiELfdajLMTaVEuZEtXPemKJ yhFiMMHBatECzggDahWqaOVrrLZ;

	private static string UUZuMIihZMPVeBdDCwfRYJeiBLR;

	private static IntPtr LGDmmbJojBYtiUaRkyYERIYDoQA;

	private static SfmqORkwIwsJeyjKwzbhVsicett gIfogYzitjYtkMHzZQFfePugAVmD;

	private static SqfIxCAexVGqxOUKUOOcddYeiFy npLsMgfoNkbgLXjXKmiwgxWuMQR = default(SqfIxCAexVGqxOUKUOOcddYeiFy);

	public static bool supportsGetStateEx
	{
		get
		{
			return xmFAxXlJtKlTBSwJClTqGnusDVD;
		}
	}

	public static DnqsiELfdajLMTaVEuZEtXPemKJ version
	{
		get
		{
			return yhFiMMHBatECzggDahWqaOVrrLZ;
		}
		set
		{
			yhFiMMHBatECzggDahWqaOVrrLZ = value;
		}
	}

	public static string xInputLibraryName
	{
		get
		{
			return UUZuMIihZMPVeBdDCwfRYJeiBLR;
		}
	}

	public static SfmqORkwIwsJeyjKwzbhVsicett getStateExDelegate
	{
		get
		{
			return gIfogYzitjYtkMHzZQFfePugAVmD;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NVPWGsqaxkShimkRMUoiLHTkvoh(int P_0, void* P_1);

	private unsafe static int vZrbbeJuyZHgXfRcAtFPcbyFGvrJ(int P_0, void* P_1)
	{
		return NVPWGsqaxkShimkRMUoiLHTkvoh(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BkmCbhjzQkImLwwnXidiTqodnTW(int P_0, void* P_1);

	private unsafe static int pXJGavOejEoQQgiSKWcWxLvrcCU(int P_0, void* P_1)
	{
		return BkmCbhjzQkImLwwnXidiTqodnTW(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gkADVyJLIsjDnwrjwHOlmitJnif(int P_0, void* P_1);

	private unsafe static int ozntGajypfCVwZPiMKQTVPEwedp(int P_0, void* P_1)
	{
		return gkADVyJLIsjDnwrjwHOlmitJnif(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JstDhOBwhmaqqFwJzTLNeIphCGuN(int P_0, void* P_1);

	private unsafe static int tOLAxbBVBwmmgjvMcQonApNoKAbW(int P_0, void* P_1)
	{
		return JstDhOBwhmaqqFwJzTLNeIphCGuN(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JEaLtlbIhebgAYvftlGjfrSpTTW(int P_0, void* P_1);

	private unsafe static int AuiEwGVoJlchRHwJtqrKHSopAep(int P_0, void* P_1)
	{
		return JEaLtlbIhebgAYvftlGjfrSpTTW(P_0, P_1);
	}

	public static bool HtHLkuicvegUyNveVCXdfijLKttU(out DnqsiELfdajLMTaVEuZEtXPemKJ P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = DnqsiELfdajLMTaVEuZEtXPemKJ.FIZxYpycmNmDbQxAMdnkneLgidG;
		xmFAxXlJtKlTBSwJClTqGnusDVD = false;
		gIfogYzitjYtkMHzZQFfePugAVmD = null;
		if (BtzQIAiGlZVjaaCpabWtiuRtGjMg())
		{
			yhFiMMHBatECzggDahWqaOVrrLZ = DnqsiELfdajLMTaVEuZEtXPemKJ.DPazsfamlIESCssSKEHPmwCjfux;
			UUZuMIihZMPVeBdDCwfRYJeiBLR = "Xinput1_4.dll";
		}
		else if (nduIbTFIeMHlSUsObZVWGLMkblzk())
		{
			yhFiMMHBatECzggDahWqaOVrrLZ = DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE;
			UUZuMIihZMPVeBdDCwfRYJeiBLR = "Xinput1_3.dll";
		}
		else if (lPBAJsKcOlJIwjLGbAIuDACfkiqT())
		{
			yhFiMMHBatECzggDahWqaOVrrLZ = DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu;
			UUZuMIihZMPVeBdDCwfRYJeiBLR = "Xinput1_2.dll";
		}
		else if (eSeaDlivzQMJXFoLoPpPQQmBMwJ())
		{
			yhFiMMHBatECzggDahWqaOVrrLZ = DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw;
			UUZuMIihZMPVeBdDCwfRYJeiBLR = "Xinput1_1.dll";
		}
		else
		{
			if (!HNowRuSjiHeQbpaobeFsaYCZAfNi())
			{
				P_2 = 1;
				return false;
			}
			yhFiMMHBatECzggDahWqaOVrrLZ = DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy;
			UUZuMIihZMPVeBdDCwfRYJeiBLR = "Xinput9_1_0.dll";
		}
		P_1 = UUZuMIihZMPVeBdDCwfRYJeiBLR;
		P_0 = yhFiMMHBatECzggDahWqaOVrrLZ;
		if (xmFAxXlJtKlTBSwJClTqGnusDVD && !MVMlXlzVtQBjIeVaFqvqqjyKJUp())
		{
			xmFAxXlJtKlTBSwJClTqGnusDVD = false;
		}
		if (!pVVycpDwxIAWedBpvsQuZHVXNEq())
		{
			bRtdbPdGDddcrbNGvrUXEsYzzDpm();
			return false;
		}
		return true;
	}

	private unsafe static bool BtzQIAiGlZVjaaCpabWtiuRtGjMg()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SqfIxCAexVGqxOUKUOOcddYeiFy, IntPtr>(ref npLsMgfoNkbgLXjXKmiwgxWuMQR))
			{
				AuiEwGVoJlchRHwJtqrKHSopAep(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool nduIbTFIeMHlSUsObZVWGLMkblzk()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SqfIxCAexVGqxOUKUOOcddYeiFy, IntPtr>(ref npLsMgfoNkbgLXjXKmiwgxWuMQR))
			{
				tOLAxbBVBwmmgjvMcQonApNoKAbW(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool lPBAJsKcOlJIwjLGbAIuDACfkiqT()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SqfIxCAexVGqxOUKUOOcddYeiFy, IntPtr>(ref npLsMgfoNkbgLXjXKmiwgxWuMQR))
			{
				ozntGajypfCVwZPiMKQTVPEwedp(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool eSeaDlivzQMJXFoLoPpPQQmBMwJ()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SqfIxCAexVGqxOUKUOOcddYeiFy, IntPtr>(ref npLsMgfoNkbgLXjXKmiwgxWuMQR))
			{
				pXJGavOejEoQQgiSKWcWxLvrcCU(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool HNowRuSjiHeQbpaobeFsaYCZAfNi()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SqfIxCAexVGqxOUKUOOcddYeiFy, IntPtr>(ref npLsMgfoNkbgLXjXKmiwgxWuMQR))
			{
				vZrbbeJuyZHgXfRcAtFPcbyFGvrJ(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool MVMlXlzVtQBjIeVaFqvqqjyKJUp()
	{
		if (!xmFAxXlJtKlTBSwJClTqGnusDVD)
		{
			return false;
		}
		return false;
	}

	private static bool pVVycpDwxIAWedBpvsQuZHVXNEq()
	{
		try
		{
			sqXlWvYVilwtaUcCZHHGGlfPRRvA sqXlWvYVilwtaUcCZHHGGlfPRRvA2 = new sqXlWvYVilwtaUcCZHHGGlfPRRvA();
			bool isConnected = sqXlWvYVilwtaUcCZHHGGlfPRRvA2.IsConnected;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void bRtdbPdGDddcrbNGvrUXEsYzzDpm()
	{
		if (xmFAxXlJtKlTBSwJClTqGnusDVD)
		{
			gIfogYzitjYtkMHzZQFfePugAVmD = null;
		}
	}
}
