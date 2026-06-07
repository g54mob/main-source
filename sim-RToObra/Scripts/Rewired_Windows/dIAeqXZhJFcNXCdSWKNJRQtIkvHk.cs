using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class dIAeqXZhJFcNXCdSWKNJRQtIkvHk
{
	public unsafe static int AsnjlSTgTWdKJsYqwwnPzhdAPuY(int P_0, int P_1, out uTwXnJcyUCtEFPYvPzVtNfexvWy P_2)
	{
		if (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version >= DnqsiELfdajLMTaVEuZEtXPemKJ.DPazsfamlIESCssSKEHPmwCjfux)
		{
			P_2 = default(uTwXnJcyUCtEFPYvPzVtNfexvWy);
			return 0;
		}
		P_2 = default(uTwXnJcyUCtEFPYvPzVtNfexvWy);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<uTwXnJcyUCtEFPYvPzVtNfexvWy, IntPtr>(ref P_2))
		{
			result = ZkjWQWNaKjajHLyniDkepMZXbKqD(P_0, P_1, ptr);
		}
		return result;
	}

	private unsafe static int ZkjWQWNaKjajHLyniDkepMZXbKqD(int P_0, int P_1, void* P_2)
	{
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			return oaCpHQyoOpYqepnyvwcoOHlDguv(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			return IWJdreeZPtDRjQPmPhXEFFqpOAXW(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			return lfYVWTssXCnRNhmSHDapixrzdGc(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			return EgRMblwIrvEBfbDLRSIAIhERrGd(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int EgRMblwIrvEBfbDLRSIAIhERrGd(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lfYVWTssXCnRNhmSHDapixrzdGc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int IWJdreeZPtDRjQPmPhXEFFqpOAXW(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oaCpHQyoOpYqepnyvwcoOHlDguv(int P_0, int P_1, void* P_2);

	public unsafe static int zmeQXcGXKOKOnNGMUWhGviFGXBX(int P_0, PTYoizLivOqKtIIuCrxoWaiEvuN P_1)
	{
		return tzKGgJkbaVUXMorTMtvGYzeoGEo(P_0, &P_1);
	}

	private unsafe static int tzKGgJkbaVUXMorTMtvGYzeoGEo(int P_0, void* P_1)
	{
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.DPazsfamlIESCssSKEHPmwCjfux:
			return JAwbSFaWViWZPrzyIiTTjPsFbgI(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			return wyabHfiRRMWydrwBfKSlxkBdrVk(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			return dluvpCaeGixINfuKMmVnySMQtPI(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			return tdZjAZhGKVSPFUwcOldjeOmEePkR(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			return ckioiSMPTPRzxySzoIzKoKylbCe(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ckioiSMPTPRzxySzoIzKoKylbCe(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tdZjAZhGKVSPFUwcOldjeOmEePkR(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dluvpCaeGixINfuKMmVnySMQtPI(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wyabHfiRRMWydrwBfKSlxkBdrVk(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JAwbSFaWViWZPrzyIiTTjPsFbgI(int P_0, void* P_1);

	public unsafe static int ZDzjLVNrHmAabbOyPUzrLYDDQKc(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_1))
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_2))
			{
				result = CWvBgqqSihdRijQPaAWtaJXnkTg(P_0, ptr, ptr2);
			}
		}
		return result;
	}

	private unsafe static int CWvBgqqSihdRijQPaAWtaJXnkTg(int P_0, void* P_1, void* P_2)
	{
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			return nunFAGfafMNcwSvBhhnjtLboSbA(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			return UxZwbpWgjJKmXTCoBgujziUfqmt(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			return XbpCchuheWYcANodmAgniKWPfNhf(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			return iFqhtLNUrbGkTHrrQFMmtSFQGQQP(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int iFqhtLNUrbGkTHrrQFMmtSFQGQQP(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XbpCchuheWYcANodmAgniKWPfNhf(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UxZwbpWgjJKmXTCoBgujziUfqmt(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nunFAGfafMNcwSvBhhnjtLboSbA(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int meAdQROsmFhWQebnodYodxnzkHVN(int P_0, out SqfIxCAexVGqxOUKUOOcddYeiFy P_1)
	{
		P_1 = default(SqfIxCAexVGqxOUKUOOcddYeiFy);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SqfIxCAexVGqxOUKUOOcddYeiFy, IntPtr>(ref P_1))
		{
			result = hMRWpOKIsEJRwgyIhRwQUMxkfOa(P_0, ptr);
		}
		return result;
	}

	private unsafe static int hMRWpOKIsEJRwgyIhRwQUMxkfOa(int P_0, void* P_1)
	{
		if (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.supportsGetStateEx && ZTjdkWAkGMFOlwjyFpjqdQDLngXx.getStateExDelegate != null)
		{
			return ZTjdkWAkGMFOlwjyFpjqdQDLngXx.getStateExDelegate(P_0, P_1);
		}
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.DPazsfamlIESCssSKEHPmwCjfux:
			return AuiEwGVoJlchRHwJtqrKHSopAep(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			return tOLAxbBVBwmmgjvMcQonApNoKAbW(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			return ozntGajypfCVwZPiMKQTVPEwedp(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			return pXJGavOejEoQQgiSKWcWxLvrcCU(P_0, P_1);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			return vZrbbeJuyZHgXfRcAtFPcbyFGvrJ(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vZrbbeJuyZHgXfRcAtFPcbyFGvrJ(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pXJGavOejEoQQgiSKWcWxLvrcCU(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ozntGajypfCVwZPiMKQTVPEwedp(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tOLAxbBVBwmmgjvMcQonApNoKAbW(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AuiEwGVoJlchRHwJtqrKHSopAep(int P_0, void* P_1);

	public unsafe static int uIbExzaVOCocdxTvLiVBfCCvFUiO(int P_0, eJugPclBScbZVNDoYEaDBafLGUP P_1, out XoPqnCWhcOFBqhsrkYMQVcYhaLt P_2)
	{
		P_2 = default(XoPqnCWhcOFBqhsrkYMQVcYhaLt);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<XoPqnCWhcOFBqhsrkYMQVcYhaLt, IntPtr>(ref P_2))
		{
			result = pMshVBEQzkEDqMYUJKpCfcHkcJj(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int pMshVBEQzkEDqMYUJKpCfcHkcJj(int P_0, int P_1, void* P_2)
	{
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.DPazsfamlIESCssSKEHPmwCjfux:
			return qadwRqyUDmviBqpaVikmdOkcuVR(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			return DZipqQOyvdvgXJCKbZGqYOSxEFb(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			return bSOWaiFQHtnBkJvPABNOwapuaos(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			return NKQQIJNAcpKvvRqArKgZKaFuSlu(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			return hutwSdzrZnZAsDAtrxtEYIWrMrz(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hutwSdzrZnZAsDAtrxtEYIWrMrz(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NKQQIJNAcpKvvRqArKgZKaFuSlu(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bSOWaiFQHtnBkJvPABNOwapuaos(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DZipqQOyvdvgXJCKbZGqYOSxEFb(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qadwRqyUDmviBqpaVikmdOkcuVR(int P_0, int P_1, void* P_2);

	public unsafe static int gfbiQOOQFvkeIapLkBdItTDIkKG(int P_0, ZeAxzgfHgkDkrtARISfAGqBVgcw P_1, out SPWtVIZoSyEUaAcweCynTWoVZoef P_2)
	{
		P_2 = default(SPWtVIZoSyEUaAcweCynTWoVZoef);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<SPWtVIZoSyEUaAcweCynTWoVZoef, IntPtr>(ref P_2))
		{
			result = kIuxOklUQsKTzcDYDUUsNKKHRQU(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int kIuxOklUQsKTzcDYDUUsNKKHRQU(int P_0, int P_1, void* P_2)
	{
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			return ZSVRXkOPVeLiHsBCQvvLiDabhZD(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			return TfxynnQjxXXDudBocSsagIOfWR(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			return cdpLxyYXJBKtvFEnkzcqIGgvhgcc(P_0, P_1, P_2);
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			return bHOPPPNVjSprLjkqdTGpfaEGfdS(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bHOPPPNVjSprLjkqdTGpfaEGfdS(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cdpLxyYXJBKtvFEnkzcqIGgvhgcc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TfxynnQjxXXDudBocSsagIOfWR(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZSVRXkOPVeLiHsBCQvvLiDabhZD(int P_0, int P_1, void* P_2);

	public static void jGALsCBnJpzGdHVLTOirgRHMMDG(rIDNnnMXkrSTyWtFHFduSktzqvC P_0)
	{
		XajfPRcmmXtXeGqeZfofmaRPdXkv(P_0);
	}

	private static void XajfPRcmmXtXeGqeZfofmaRPdXkv(rIDNnnMXkrSTyWtFHFduSktzqvC P_0)
	{
		switch (ZTjdkWAkGMFOlwjyFpjqdQDLngXx.version)
		{
		case DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE:
			XhGbCDQonjOXnRVnsjkvujnlaDJ(P_0);
			break;
		case DnqsiELfdajLMTaVEuZEtXPemKJ.BdQfPsfNvikSWZKDliEBYgeuPiu:
			alDPFLaIJdjktyHkSAzMaUAvjGDS(P_0);
			break;
		case DnqsiELfdajLMTaVEuZEtXPemKJ.LKTmjaNGvMiRApefmOOLjIBSYlw:
			LfgooKfCgAPSaitVelaOpKNAVIy(P_0);
			break;
		case DnqsiELfdajLMTaVEuZEtXPemKJ.ifBwXKkwOsajpLoGjETcQMjpVvy:
			LPADAobRFCfrpgHjbnyglmcueAWm(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void LPADAobRFCfrpgHjbnyglmcueAWm(rIDNnnMXkrSTyWtFHFduSktzqvC P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void LfgooKfCgAPSaitVelaOpKNAVIy(rIDNnnMXkrSTyWtFHFduSktzqvC P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void alDPFLaIJdjktyHkSAzMaUAvjGDS(rIDNnnMXkrSTyWtFHFduSktzqvC P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void XhGbCDQonjOXnRVnsjkvujnlaDJ(rIDNnnMXkrSTyWtFHFduSktzqvC P_0);
}
