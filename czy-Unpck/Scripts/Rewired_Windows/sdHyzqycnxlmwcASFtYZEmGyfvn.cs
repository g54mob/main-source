using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class sdHyzqycnxlmwcASFtYZEmGyfvn
{
	public unsafe static int DqgcypcjmyraexwhzkfPfGGgmRi(int P_0, int P_1, out fthEscNhYoHQuOhUGTslPSWZsjY P_2)
	{
		if (KUyKlnXhioRvEgicKXqeSHavFyrH.version >= OAuxmLkIZODWmArmNvxTfYwIyXw.AOdilMPBLsItnnQORxUZqPdVbcPi)
		{
			P_2 = default(fthEscNhYoHQuOhUGTslPSWZsjY);
			return 0;
		}
		P_2 = default(fthEscNhYoHQuOhUGTslPSWZsjY);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<fthEscNhYoHQuOhUGTslPSWZsjY, IntPtr>(ref P_2))
		{
			result = UPqRNjufaPSluUQxbnpkxdixABG(P_0, P_1, ptr);
		}
		return result;
	}

	private unsafe static int UPqRNjufaPSluUQxbnpkxdixABG(int P_0, int P_1, void* P_2)
	{
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			return dATkwnZdqLIxXqBuqOnoGkIhqyB(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			return LDEaGBLhvXyqSLacCcQYVjVJfIb(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			return cDKuYTlKcUcreYWSWjHgYfBfUX(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			return VSFYWXFnFsUVkFDGFGgIdLlWXN(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VSFYWXFnFsUVkFDGFGgIdLlWXN(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cDKuYTlKcUcreYWSWjHgYfBfUX(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LDEaGBLhvXyqSLacCcQYVjVJfIb(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dATkwnZdqLIxXqBuqOnoGkIhqyB(int P_0, int P_1, void* P_2);

	public unsafe static int uNzcQNKfosbnGRQUXikCctyerRnF(int P_0, GcRlXKaXTkXGCNOcLcJaGHRyAbh P_1)
	{
		return yrJSdePlAzgwltxPHCmIdAXCMMWN(P_0, &P_1);
	}

	private unsafe static int yrJSdePlAzgwltxPHCmIdAXCMMWN(int P_0, void* P_1)
	{
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.AOdilMPBLsItnnQORxUZqPdVbcPi:
			return YyhFJgVAzOZamsRwPOSLbnPhNsq(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			return dIbunABJdqAhAgNmiuTdznPPPdU(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			return sSvIuvFwsSqlaycQDEAvfgfkRTwC(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			return kYSmBohzaxEqadYwNRwzWYLuvRO(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			return dVlffvInvloUIgtjkngCdwNjJYAi(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dVlffvInvloUIgtjkngCdwNjJYAi(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kYSmBohzaxEqadYwNRwzWYLuvRO(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int sSvIuvFwsSqlaycQDEAvfgfkRTwC(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dIbunABJdqAhAgNmiuTdznPPPdU(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YyhFJgVAzOZamsRwPOSLbnPhNsq(int P_0, void* P_1);

	public unsafe static int EossMgmktCNZSmYgUtmdFEsnxKU(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_1))
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_2))
			{
				result = PeufYPVGkJwHrcJDjRgnqmgXBsI(P_0, ptr, ptr2);
			}
		}
		return result;
	}

	private unsafe static int PeufYPVGkJwHrcJDjRgnqmgXBsI(int P_0, void* P_1, void* P_2)
	{
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			return oogGIdAiBkIuBBSZiiopdeSYDYw(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			return FPUlEQpzVbfliWMgQdlhtwbLmSV(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			return GGaxvQZUacPcnCJltnafoEhtjFV(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			return bbbOiiiCJLENihibHsFgfCgkpYyC(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bbbOiiiCJLENihibHsFgfCgkpYyC(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int GGaxvQZUacPcnCJltnafoEhtjFV(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int FPUlEQpzVbfliWMgQdlhtwbLmSV(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oogGIdAiBkIuBBSZiiopdeSYDYw(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int vIZHRoxYNnxHhlxJzLyohQxLXnK(int P_0, out DBlBEUzeGRAlBVSIViHWbmOkEipK P_1)
	{
		P_1 = default(DBlBEUzeGRAlBVSIViHWbmOkEipK);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DBlBEUzeGRAlBVSIViHWbmOkEipK, IntPtr>(ref P_1))
		{
			result = aUKVcdvWugaGZrACkdECUuAWUAY(P_0, ptr);
		}
		return result;
	}

	private unsafe static int aUKVcdvWugaGZrACkdECUuAWUAY(int P_0, void* P_1)
	{
		if (KUyKlnXhioRvEgicKXqeSHavFyrH.supportsGetStateEx && KUyKlnXhioRvEgicKXqeSHavFyrH.getStateExDelegate != null)
		{
			return KUyKlnXhioRvEgicKXqeSHavFyrH.getStateExDelegate(P_0, P_1);
		}
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.AOdilMPBLsItnnQORxUZqPdVbcPi:
			return PttNVbyIWLcZoCXwuzoOXXtJCOP(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			return mEUPqOkqvUzRFssOtYzzrFkYnIF(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			return pAclDVMoNBysZGhkFCZLPKdCobP(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			return spKSdGvVLkmpfrQGVghOhjEFmMws(P_0, P_1);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			return ackugDRCQpOHwILaLOALfFNmtrP(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ackugDRCQpOHwILaLOALfFNmtrP(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int spKSdGvVLkmpfrQGVghOhjEFmMws(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pAclDVMoNBysZGhkFCZLPKdCobP(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mEUPqOkqvUzRFssOtYzzrFkYnIF(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int PttNVbyIWLcZoCXwuzoOXXtJCOP(int P_0, void* P_1);

	public unsafe static int fyqreIaVuwTJYYidIEMBQxtNEYYD(int P_0, xKdAjFWSfKGIuJSLXJJHZXFdqYx P_1, out MsOtDChTRicNVkqupHmQHuLPitd P_2)
	{
		P_2 = default(MsOtDChTRicNVkqupHmQHuLPitd);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<MsOtDChTRicNVkqupHmQHuLPitd, IntPtr>(ref P_2))
		{
			result = gltaiUjDHMbNsZEGoLSilgjSiXm(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int gltaiUjDHMbNsZEGoLSilgjSiXm(int P_0, int P_1, void* P_2)
	{
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.AOdilMPBLsItnnQORxUZqPdVbcPi:
			return dainSZNCpOsHqvlkEcjqICFMCNhj(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			return YUrdirpBYHdSwSxSiGCgKWlZGIRm(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			return aoBXJKibGZKBzGLGVKUFoSEYieC(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			return COJTOimtoJjhWIaswaNNKTgAcMS(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			return kqRpUiKjcTyDmIfPecUPEvTRSBy(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kqRpUiKjcTyDmIfPecUPEvTRSBy(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int COJTOimtoJjhWIaswaNNKTgAcMS(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aoBXJKibGZKBzGLGVKUFoSEYieC(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YUrdirpBYHdSwSxSiGCgKWlZGIRm(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dainSZNCpOsHqvlkEcjqICFMCNhj(int P_0, int P_1, void* P_2);

	public unsafe static int tZczNlbxpVPDrflJxIiIlwcuwYu(int P_0, CgNsAFIMzGwISqPMHPtIIwzfySI P_1, out VVNgUfwXyOFzBdqgfAvdYaLlpgS P_2)
	{
		P_2 = default(VVNgUfwXyOFzBdqgfAvdYaLlpgS);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<VVNgUfwXyOFzBdqgfAvdYaLlpgS, IntPtr>(ref P_2))
		{
			result = henEPPEtkSqqIfaQSOVaNsjdHGc(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int henEPPEtkSqqIfaQSOVaNsjdHGc(int P_0, int P_1, void* P_2)
	{
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			return CNWDYNxIbAbJeBlAXJwVZaJXCTtS(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			return WvmlOSENZXoyqngNtRguqSlgCMj(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			return tAovsXdmrvcSAkMhvOrwpCNFqgQR(P_0, P_1, P_2);
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			return cQXAUcwPhkAnQogysYNWvPVylUm(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cQXAUcwPhkAnQogysYNWvPVylUm(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tAovsXdmrvcSAkMhvOrwpCNFqgQR(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WvmlOSENZXoyqngNtRguqSlgCMj(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int CNWDYNxIbAbJeBlAXJwVZaJXCTtS(int P_0, int P_1, void* P_2);

	public static void mlVfvbccbTKbQTGXUqnvEqwbcTyS(sRQFoGahINekTbXVfEgedOObPzBo P_0)
	{
		WRmLSoHzMpRaXfluMwtduPchwRY(P_0);
	}

	private static void WRmLSoHzMpRaXfluMwtduPchwRY(sRQFoGahINekTbXVfEgedOObPzBo P_0)
	{
		switch (KUyKlnXhioRvEgicKXqeSHavFyrH.version)
		{
		case OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg:
			GEVJPgvBlFuNGMbztvnToEdTBAt(P_0);
			break;
		case OAuxmLkIZODWmArmNvxTfYwIyXw.QXXASRMReEpqtOZeoDETIAFCexA:
			tjWOmFXtOPXYqdmjBsEWAdXXWrm(P_0);
			break;
		case OAuxmLkIZODWmArmNvxTfYwIyXw.WcYfIRwbPcsvbonpfRrPlHsqajG:
			AdltHvGdSocsVnBrnCoAefmgqFCm(P_0);
			break;
		case OAuxmLkIZODWmArmNvxTfYwIyXw.dvMKSpPqiSAEMAIGePOqmUORepEP:
			ULBsBVucjudSKgYvmBvcZgFQBScq(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ULBsBVucjudSKgYvmBvcZgFQBScq(sRQFoGahINekTbXVfEgedOObPzBo P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void AdltHvGdSocsVnBrnCoAefmgqFCm(sRQFoGahINekTbXVfEgedOObPzBo P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void tjWOmFXtOPXYqdmjBsEWAdXXWrm(sRQFoGahINekTbXVfEgedOObPzBo P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void GEVJPgvBlFuNGMbztvnToEdTBAt(sRQFoGahINekTbXVfEgedOObPzBo P_0);
}
