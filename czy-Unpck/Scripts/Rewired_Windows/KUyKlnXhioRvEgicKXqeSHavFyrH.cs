using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal class KUyKlnXhioRvEgicKXqeSHavFyrH
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int EixgDPDZlcZsQbYFHzxcgmNVJLIc(int arg0, void* arg1);

	private static bool wHSaOkSGFoefsNQDVQycGUDMFwd;

	private static OAuxmLkIZODWmArmNvxTfYwIyXw zFMtIxaeWXgjMtyFtXQosZaXHyd;

	private static string ZzSBnvPWXgBaVCgzRknNAhDSATzf;

	private static IntPtr AYNlDHsZQtjpEDgipxPIPffdovc;

	private static EixgDPDZlcZsQbYFHzxcgmNVJLIc nRyEhhfIXLWONBLdUVUlbgFInLUC;

	private static DBlBEUzeGRAlBVSIViHWbmOkEipK orGDJHfOjUlHsEMDRQboyuvQWCx = default(DBlBEUzeGRAlBVSIViHWbmOkEipK);

	public static bool supportsGetStateEx => wHSaOkSGFoefsNQDVQycGUDMFwd;

	public static OAuxmLkIZODWmArmNvxTfYwIyXw version
	{
		get
		{
			return zFMtIxaeWXgjMtyFtXQosZaXHyd;
		}
		set
		{
			zFMtIxaeWXgjMtyFtXQosZaXHyd = value;
		}
	}

	public static string xInputLibraryName => ZzSBnvPWXgBaVCgzRknNAhDSATzf;

	public static EixgDPDZlcZsQbYFHzxcgmNVJLIc getStateExDelegate => nRyEhhfIXLWONBLdUVUlbgFInLUC;

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QqMNMZVFIAjlFrmXLDFsRYgOdTV(int P_0, void* P_1);

	private unsafe static int ackugDRCQpOHwILaLOALfFNmtrP(int P_0, void* P_1)
	{
		return QqMNMZVFIAjlFrmXLDFsRYgOdTV(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WllkgCCHoOTqqxrbIuqcHAJLFtc(int P_0, void* P_1);

	private unsafe static int spKSdGvVLkmpfrQGVghOhjEFmMws(int P_0, void* P_1)
	{
		return WllkgCCHoOTqqxrbIuqcHAJLFtc(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tXvIdisCbiFKorMrqkASsCJDAdAa(int P_0, void* P_1);

	private unsafe static int pAclDVMoNBysZGhkFCZLPKdCobP(int P_0, void* P_1)
	{
		return tXvIdisCbiFKorMrqkASsCJDAdAa(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SoyRaxLmDAITVHhXsxULlWEerWEE(int P_0, void* P_1);

	private unsafe static int mEUPqOkqvUzRFssOtYzzrFkYnIF(int P_0, void* P_1)
	{
		return SoyRaxLmDAITVHhXsxULlWEerWEE(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QrPSrAGVoBEvZTShusQWtqCVRPl(int P_0, void* P_1);

	private unsafe static int PttNVbyIWLcZoCXwuzoOXXtJCOP(int P_0, void* P_1)
	{
		return QrPSrAGVoBEvZTShusQWtqCVRPl(P_0, P_1);
	}

	public static bool IuACrRLSXYCxPAGoMIMpLuEdZtDH(out OAuxmLkIZODWmArmNvxTfYwIyXw P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = OAuxmLkIZODWmArmNvxTfYwIyXw.UyGwCSXAdlJCSRSfHscRvehUkwi;
		wHSaOkSGFoefsNQDVQycGUDMFwd = false;
		nRyEhhfIXLWONBLdUVUlbgFInLUC = null;
		if (INucZngZZrmGTsfndQLzdooKPtwK())
		{
			zFMtIxaeWXgjMtyFtXQosZaXHyd = OAuxmLkIZODWmArmNvxTfYwIyXw.AOdilMPBLsItnnQORxUZqPdVbcPi;
			ZzSBnvPWXgBaVCgzRknNAhDSATzf = "Xinput1_4.dll";
		}
		else if (wnxSicuDSirKtPOScfGUCxtScrZ())
		{
			zFMtIxaeWXgjMtyFtXQosZaXHyd = OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg;
			ZzSBnvPWXgBaVCgzRknNAhDSATzf = "Xinput1_3.dll";
		}
		else if (eXSZyBjotHdPDmCAmZlgUxoTkFW())
		{
			zFMtIxaeWXgjMtyFtXQosZaXHyd = OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA;
			ZzSBnvPWXgBaVCgzRknNAhDSATzf = "Xinput1_2.dll";
		}
		else if (rtnQvSVHawwVcGJVnaeHQRhnoGv())
		{
			zFMtIxaeWXgjMtyFtXQosZaXHyd = OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG;
			ZzSBnvPWXgBaVCgzRknNAhDSATzf = "Xinput1_1.dll";
		}
		else
		{
			if (!ILpKMFbEIvjrYgsgiwAutOzfClxM())
			{
				P_2 = 1;
				return false;
			}
			zFMtIxaeWXgjMtyFtXQosZaXHyd = OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP;
			ZzSBnvPWXgBaVCgzRknNAhDSATzf = "Xinput9_1_0.dll";
		}
		P_1 = ZzSBnvPWXgBaVCgzRknNAhDSATzf;
		P_0 = zFMtIxaeWXgjMtyFtXQosZaXHyd;
		if (wHSaOkSGFoefsNQDVQycGUDMFwd && !VxVCQEKQRcFExFlwkYkmysZIwWBR())
		{
			wHSaOkSGFoefsNQDVQycGUDMFwd = false;
		}
		if (!sxQxgCaJOgfjVojnunfaRwUvZWW())
		{
			ajesCsGIfLHpYQEAwTJNkBnVPHN();
			return false;
		}
		return true;
	}

	private unsafe static bool INucZngZZrmGTsfndQLzdooKPtwK()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DBlBEUzeGRAlBVSIViHWbmOkEipK, IntPtr>(ref orGDJHfOjUlHsEMDRQboyuvQWCx))
			{
				PttNVbyIWLcZoCXwuzoOXXtJCOP(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool wnxSicuDSirKtPOScfGUCxtScrZ()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DBlBEUzeGRAlBVSIViHWbmOkEipK, IntPtr>(ref orGDJHfOjUlHsEMDRQboyuvQWCx))
			{
				mEUPqOkqvUzRFssOtYzzrFkYnIF(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool eXSZyBjotHdPDmCAmZlgUxoTkFW()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DBlBEUzeGRAlBVSIViHWbmOkEipK, IntPtr>(ref orGDJHfOjUlHsEMDRQboyuvQWCx))
			{
				pAclDVMoNBysZGhkFCZLPKdCobP(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool rtnQvSVHawwVcGJVnaeHQRhnoGv()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DBlBEUzeGRAlBVSIViHWbmOkEipK, IntPtr>(ref orGDJHfOjUlHsEMDRQboyuvQWCx))
			{
				spKSdGvVLkmpfrQGVghOhjEFmMws(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool ILpKMFbEIvjrYgsgiwAutOzfClxM()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DBlBEUzeGRAlBVSIViHWbmOkEipK, IntPtr>(ref orGDJHfOjUlHsEMDRQboyuvQWCx))
			{
				ackugDRCQpOHwILaLOALfFNmtrP(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool VxVCQEKQRcFExFlwkYkmysZIwWBR()
	{
		if (!wHSaOkSGFoefsNQDVQycGUDMFwd)
		{
			return false;
		}
		return false;
	}

	private static bool sxQxgCaJOgfjVojnunfaRwUvZWW()
	{
		try
		{
			tBYfLSCxOHBMTsBESxYMJzAlNDXv tBYfLSCxOHBMTsBESxYMJzAlNDXv2 = new tBYfLSCxOHBMTsBESxYMJzAlNDXv();
			_ = tBYfLSCxOHBMTsBESxYMJzAlNDXv2.IsConnected;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void ajesCsGIfLHpYQEAwTJNkBnVPHN()
	{
		if (wHSaOkSGFoefsNQDVQycGUDMFwd)
		{
			nRyEhhfIXLWONBLdUVUlbgFInLUC = null;
		}
	}
}
