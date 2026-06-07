using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class tKapwnqQNTCwYutcvPPTXozijrR
{
	public unsafe static int YwPQksihNCQHYnaORVhXoRveAyM(int P_0, int P_1, out yYQFIbdTuUwcCRCqsYjnIYrLOrqG P_2)
	{
		if (DbBzCsDOVGLEomDEwbzsHlJbmLN.version >= FZLWxQmQzwLaQGKEhOiRyzHAEuI.BApvHLbvQpDRhnmxDXPivKPTclR)
		{
			P_2 = default(yYQFIbdTuUwcCRCqsYjnIYrLOrqG);
			return 0;
		}
		P_2 = default(yYQFIbdTuUwcCRCqsYjnIYrLOrqG);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<yYQFIbdTuUwcCRCqsYjnIYrLOrqG, IntPtr>(ref P_2))
		{
			result = XIDqZwyAKdvmOQWNRRiycJVdkYk(P_0, P_1, ptr);
		}
		return result;
	}

	private unsafe static int XIDqZwyAKdvmOQWNRRiycJVdkYk(int P_0, int P_1, void* P_2)
	{
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			return stgcqsfTMrzRjDqKAOyaCDzHjqvS(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			return QWtMgGFqTfCAmFSSaKDWAIwDHSJ(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			return thgGKtVsBSPiUmKocCPhpJjBepc(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			return AhpHPHXkfrqUoiZjiUEGXHWfwUv(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AhpHPHXkfrqUoiZjiUEGXHWfwUv(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int thgGKtVsBSPiUmKocCPhpJjBepc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QWtMgGFqTfCAmFSSaKDWAIwDHSJ(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int stgcqsfTMrzRjDqKAOyaCDzHjqvS(int P_0, int P_1, void* P_2);

	public unsafe static int riCIJKdgWUXHeOyoxxfEoHZgBNJ(int P_0, NukZzVajpShfwNPSbPfmPusaDdN P_1)
	{
		return xygxyjFbwBOSXtgtdhPQFgyIMsg(P_0, &P_1);
	}

	private unsafe static int xygxyjFbwBOSXtgtdhPQFgyIMsg(int P_0, void* P_1)
	{
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.BApvHLbvQpDRhnmxDXPivKPTclR:
			return NKgVtCJBsGSWQyOdDLZtywtFoAv(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			return oqYeuDdTLUPPuDaUAyKnTkyLVdcf(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			return dhKsbwZSyeLBMuorhZBfxYKaVCG(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			return nKhDxhbCdDOvQhChztBvPfmuPVc(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			return qIKBzqhHDJEoqdiDPAbAnfeBXQw(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qIKBzqhHDJEoqdiDPAbAnfeBXQw(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nKhDxhbCdDOvQhChztBvPfmuPVc(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dhKsbwZSyeLBMuorhZBfxYKaVCG(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oqYeuDdTLUPPuDaUAyKnTkyLVdcf(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NKgVtCJBsGSWQyOdDLZtywtFoAv(int P_0, void* P_1);

	public unsafe static int HoVUlxeITefJwyEAyavzKQFxPYc(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_1))
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_2))
			{
				result = UwFLrUHVydEAfuNjPxEpbPBJfXs(P_0, ptr, ptr2);
			}
		}
		return result;
	}

	private unsafe static int UwFLrUHVydEAfuNjPxEpbPBJfXs(int P_0, void* P_1, void* P_2)
	{
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			return lAVCGcAKtYvYzsDpEzrxfkpOrWMT(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			return KBhdtNIzxFvTACCMygwbysEJhwzD(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			return BMXOtBDtmUUtXAjXDvetloChtTd(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			return snYwjhudJbtCAqJFpMRkRHNkOLC(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int snYwjhudJbtCAqJFpMRkRHNkOLC(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BMXOtBDtmUUtXAjXDvetloChtTd(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KBhdtNIzxFvTACCMygwbysEJhwzD(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lAVCGcAKtYvYzsDpEzrxfkpOrWMT(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int qpypBtnhiTpDZzcRFRSmwHzVzPZ(int P_0, out ObUyRDnZkprNrHfwzvWOcaficyNA P_1)
	{
		P_1 = default(ObUyRDnZkprNrHfwzvWOcaficyNA);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ObUyRDnZkprNrHfwzvWOcaficyNA, IntPtr>(ref P_1))
		{
			result = tBhUXanVcSMWpjPiKEcULbfUIIgc(P_0, ptr);
		}
		return result;
	}

	private unsafe static int tBhUXanVcSMWpjPiKEcULbfUIIgc(int P_0, void* P_1)
	{
		if (DbBzCsDOVGLEomDEwbzsHlJbmLN.supportsGetStateEx && DbBzCsDOVGLEomDEwbzsHlJbmLN.getStateExDelegate != null)
		{
			return DbBzCsDOVGLEomDEwbzsHlJbmLN.getStateExDelegate(P_0, P_1);
		}
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.BApvHLbvQpDRhnmxDXPivKPTclR:
			return OYChPyHgixtxYESGORcEATOZAAbk(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			return vkzqmNyiDevzpqNsZuhxyjNQYIv(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			return cuDTEHAbWpWhSWQFvAFsCIDKffE(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			return hVfvzXpfIKHhRxcaveIUoDhLGOM(P_0, P_1);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			return tuHagCBguRbPYYGSbjJTqsmcEtj(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tuHagCBguRbPYYGSbjJTqsmcEtj(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hVfvzXpfIKHhRxcaveIUoDhLGOM(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cuDTEHAbWpWhSWQFvAFsCIDKffE(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vkzqmNyiDevzpqNsZuhxyjNQYIv(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OYChPyHgixtxYESGORcEATOZAAbk(int P_0, void* P_1);

	public unsafe static int crDoiLuaKSvdmIvFcDrDLdWPOGu(int P_0, olWbvGAQLilkGAutbhCRAOmvEGTw P_1, out DfxwvZbLdGnSpowODnIMWDoFhcBh P_2)
	{
		P_2 = default(DfxwvZbLdGnSpowODnIMWDoFhcBh);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DfxwvZbLdGnSpowODnIMWDoFhcBh, IntPtr>(ref P_2))
		{
			result = vlSewxvpbgcHjTxqsIvQydDWwRt(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int vlSewxvpbgcHjTxqsIvQydDWwRt(int P_0, int P_1, void* P_2)
	{
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.BApvHLbvQpDRhnmxDXPivKPTclR:
			return qsVCEOHDlqxOHdCsiioDNiTOJNy(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			return HUEDuscvqnJaSIQsYMNuKZEZFUrH(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			return bUgJVEcLBdSuzWPnbVTEfSlKCsc(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			return JNcUBjqOWdoFiOPMOcUPAHPUuMsc(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			return dtDDtVMPLhKEnEkNOptOLkILWEf(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dtDDtVMPLhKEnEkNOptOLkILWEf(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JNcUBjqOWdoFiOPMOcUPAHPUuMsc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bUgJVEcLBdSuzWPnbVTEfSlKCsc(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HUEDuscvqnJaSIQsYMNuKZEZFUrH(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qsVCEOHDlqxOHdCsiioDNiTOJNy(int P_0, int P_1, void* P_2);

	public unsafe static int gtFFQcbPFxxoTfepBpcQwMFmUzW(int P_0, LTsjcQGZsuJSikWpxnIWLdHjpua P_1, out YwuQCewIHuVffnUiDuCjTcmdsso P_2)
	{
		P_2 = default(YwuQCewIHuVffnUiDuCjTcmdsso);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<YwuQCewIHuVffnUiDuCjTcmdsso, IntPtr>(ref P_2))
		{
			result = oDYTCaAKggWkdlcnsQmIKUKfGQA(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int oDYTCaAKggWkdlcnsQmIKUKfGQA(int P_0, int P_1, void* P_2)
	{
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			return LgdIqAnXDcvsOndgtKtTpuaLKNB(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			return ZcTBhNeQdrEWMVlpZJWspnKceGTm(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			return cpZowStFBRemwWNEZaVuVytTkLg(P_0, P_1, P_2);
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			return zJkXYbczNOqykuLKIlDCyqgkQvO(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int zJkXYbczNOqykuLKIlDCyqgkQvO(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cpZowStFBRemwWNEZaVuVytTkLg(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZcTBhNeQdrEWMVlpZJWspnKceGTm(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LgdIqAnXDcvsOndgtKtTpuaLKNB(int P_0, int P_1, void* P_2);

	public static void htaBjwcwTrtTsAxlwBkjtEVsbPKG(hffboTtMgbbEhgBbkOhyJBfJupGf P_0)
	{
		VYPEltNawLQgrjONqwabrFwjBqe(P_0);
	}

	private static void VYPEltNawLQgrjONqwabrFwjBqe(hffboTtMgbbEhgBbkOhyJBfJupGf P_0)
	{
		switch (DbBzCsDOVGLEomDEwbzsHlJbmLN.version)
		{
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA:
			DmeNBfzZjdGQuOeLFIgvepdHhDZz(P_0);
			break;
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO:
			uinFYfNwXlJlelnQtChODyUPOGL(P_0);
			break;
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg:
			BJQCbshIgWeQvxbFBJxOqgPyORsG(P_0);
			break;
		case FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap:
			JysPdSoiJGyTiKGFYmJkpIqIGXW(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void JysPdSoiJGyTiKGFYmJkpIqIGXW(hffboTtMgbbEhgBbkOhyJBfJupGf P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void BJQCbshIgWeQvxbFBJxOqgPyORsG(hffboTtMgbbEhgBbkOhyJBfJupGf P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void uinFYfNwXlJlelnQtChODyUPOGL(hffboTtMgbbEhgBbkOhyJBfJupGf P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void DmeNBfzZjdGQuOeLFIgvepdHhDZz(hffboTtMgbbEhgBbkOhyJBfJupGf P_0);
}
