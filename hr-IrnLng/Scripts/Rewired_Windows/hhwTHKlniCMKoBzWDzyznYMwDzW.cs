using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Libraries.SharpDX.DirectInput;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

[Guid("bf798031-483a-4da2-aa99-5d64ed369700")]
internal class hhwTHKlniCMKoBzWDzyznYMwDzW : vAWguSwtalYfBjVbuWSVCdiToKd
{
	private static class aRDhXaFQUpBzaYSkOqRPymoCMQUH
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private unsafe delegate int JGpmwACrpZQNbrULuYHhfgKfrzh(void* deviceInstance, IntPtr data);

		private static JGpmwACrpZQNbrULuYHhfgKfrzh tIfcxbGihlHDauFsvXKgPfSPacGb;

		private static IntPtr mgntfmLyqGTSYICSSUNPcLOgAGe;

		private static int pUvTpbWxbFZrmSPMkFEYxYQHHLv;

		public static IntPtr callbackPointer => mgntfmLyqGTSYICSSUNPcLOgAGe;

		public static int count => pUvTpbWxbFZrmSPMkFEYxYQHHLv;

		unsafe static aRDhXaFQUpBzaYSkOqRPymoCMQUH()
		{
			tIfcxbGihlHDauFsvXKgPfSPacGb = oTpuAHKvPmJCkwoPnPVGKMTwbDB;
			mgntfmLyqGTSYICSSUNPcLOgAGe = Marshal.GetFunctionPointerForDelegate((Delegate)tIfcxbGihlHDauFsvXKgPfSPacGb);
		}

		public static int sgvkdKsemtkHeUiTQBkxeDuSvDML()
		{
			int result = pUvTpbWxbFZrmSPMkFEYxYQHHLv;
			avkcOhFlGGeHrNSdTQlLZUnJDbw();
			return result;
		}

		public static void avkcOhFlGGeHrNSdTQlLZUnJDbw()
		{
			pUvTpbWxbFZrmSPMkFEYxYQHHLv = 0;
		}

		[MonoPInvokeCallback(typeof(JGpmwACrpZQNbrULuYHhfgKfrzh))]
		private unsafe static int oTpuAHKvPmJCkwoPnPVGKMTwbDB(void* P_0, IntPtr P_1)
		{
			pUvTpbWxbFZrmSPMkFEYxYQHHLv++;
			return 1;
		}
	}

	public hhwTHKlniCMKoBzWDzyznYMwDzW()
		: base(IntPtr.Zero)
	{
		KoyzTwBBvvpsKbbqTmThbBKpUOL.HPawGYxDUOSjuQumFktfIxUFABx(wPobypBrGqJFMzpPsHcbxMDAdOQb.MnYnUiyRhFiFpWhLyRxlFGptwaQ(null), 2048, JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(typeof(hhwTHKlniCMKoBzWDzyznYMwDzW)), out var nativePointer, null);
		base.NativePointer = nativePointer;
	}

	public IList<oavsBCpkURSQZhuDFrqXELCmmrM> yDqiGSkMQYxYBcosfJNCvDgVcTXc()
	{
		return yDqiGSkMQYxYBcosfJNCvDgVcTXc(QyuEnlbUowDKQRpThenvnYsTHrA.cXEeBjOXiiTJnTtduUOyunqeJia, acSaGRXzHfCbnAZWrzgPGuGjden.HqYfugFKoHaDJJxBPGFJIpAIgySe);
	}

	public IList<oavsBCpkURSQZhuDFrqXELCmmrM> yDqiGSkMQYxYBcosfJNCvDgVcTXc(QyuEnlbUowDKQRpThenvnYsTHrA P_0, acSaGRXzHfCbnAZWrzgPGuGjden P_1)
	{
		using ObjectInstanceTracker.Wrapper<kLwGLAbrAXUSnFCQmDvacTfCeHpl> wrapper = new ObjectInstanceTracker.Wrapper<kLwGLAbrAXUSnFCQmDvacTfCeHpl>(new kLwGLAbrAXUSnFCQmDvacTfCeHpl());
		kLwGLAbrAXUSnFCQmDvacTfCeHpl instance = wrapper.instance;
		SbkbWYvbgarXEfughPoKuIdLKGq((int)P_0, instance.NativePointer, new IntPtr((int)wrapper.instanceId), P_1);
		return instance.DeviceInstances;
	}

	public IList<oavsBCpkURSQZhuDFrqXELCmmrM> yDqiGSkMQYxYBcosfJNCvDgVcTXc(DeviceType P_0, acSaGRXzHfCbnAZWrzgPGuGjden P_1)
	{
		using ObjectInstanceTracker.Wrapper<kLwGLAbrAXUSnFCQmDvacTfCeHpl> wrapper = new ObjectInstanceTracker.Wrapper<kLwGLAbrAXUSnFCQmDvacTfCeHpl>(new kLwGLAbrAXUSnFCQmDvacTfCeHpl());
		kLwGLAbrAXUSnFCQmDvacTfCeHpl instance = wrapper.instance;
		SbkbWYvbgarXEfughPoKuIdLKGq((int)P_0, instance.NativePointer, new IntPtr((int)wrapper.instanceId), P_1);
		return instance.DeviceInstances;
	}

	public int tRnqqsboVUqGBCogAlxstdlVGjpa(QyuEnlbUowDKQRpThenvnYsTHrA P_0, acSaGRXzHfCbnAZWrzgPGuGjden P_1)
	{
		aRDhXaFQUpBzaYSkOqRPymoCMQUH.avkcOhFlGGeHrNSdTQlLZUnJDbw();
		SbkbWYvbgarXEfughPoKuIdLKGq((int)P_0, aRDhXaFQUpBzaYSkOqRPymoCMQUH.callbackPointer, IntPtr.Zero, P_1);
		return aRDhXaFQUpBzaYSkOqRPymoCMQUH.sgvkdKsemtkHeUiTQBkxeDuSvDML();
	}

	public int tRnqqsboVUqGBCogAlxstdlVGjpa(DeviceType P_0, acSaGRXzHfCbnAZWrzgPGuGjden P_1)
	{
		aRDhXaFQUpBzaYSkOqRPymoCMQUH.avkcOhFlGGeHrNSdTQlLZUnJDbw();
		SbkbWYvbgarXEfughPoKuIdLKGq((int)P_0, aRDhXaFQUpBzaYSkOqRPymoCMQUH.callbackPointer, IntPtr.Zero, P_1);
		return aRDhXaFQUpBzaYSkOqRPymoCMQUH.sgvkdKsemtkHeUiTQBkxeDuSvDML();
	}

	public bool DHmcXFAgLYfMVKfsvVmyMSVwNMPb(Guid P_0)
	{
		return UFbaWZatuexzUjCBpvHMbwyattK(P_0).Code == 0;
	}

	public void WNcAXlczNhSOFJApyCuQeTfEQxRl()
	{
		WNcAXlczNhSOFJApyCuQeTfEQxRl(IntPtr.Zero);
	}

	public void WNcAXlczNhSOFJApyCuQeTfEQxRl(IntPtr P_0)
	{
		WNcAXlczNhSOFJApyCuQeTfEQxRl(P_0, 0);
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SsEqEIRiYzsxxserAeIwCmHPggD(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Release")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern void vZNEiSxUdRdnxAGdYktUhbkscZEx(void* P_0);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_CreateDevice")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dvALKlvqHaIIzWlUvVLHjEDiBGVC(void* P_0, void* P_1, void* P_2, void* P_3);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_EnumDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LtmzGYeRhRJLNcMeOCThGiWkEwt(void* P_0, int P_1, void* P_2, void* P_3, int P_4);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_GetDeviceStatus")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DgwYTsKUdHuYRckWjkOyAsmyVmR(void* P_0, void* P_1);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_RunControlPanel")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HlfPhdNIbMRBKbaWJDQDcvQbPZO(void* P_0, void* P_1, int P_2);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Initialize")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BYwaTSkvFZLnUqFQdmPyvOcLiNN(void* P_0, void* P_1, int P_2);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_FindDevice")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int IwuaWRTJAhYdeJNRlUaReVZgFaR(void* P_0, void* P_1, string P_2, void* P_3);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_EnumDevicesBySemantics")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HizUwdBLWAEhtwOCVonOVOBIJqB(void* P_0, string P_1, void* P_2, void* P_3, void* P_4, int P_5);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_ConfigureDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yczMOVzrPZlKmbbNLNxQWVZmAkK(void* P_0, void* P_1, void* P_2, int P_3, void* P_4);

	public hhwTHKlniCMKoBzWDzyznYMwDzW(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator hhwTHKlniCMKoBzWDzyznYMwDzW(IntPtr nativePointer)
	{
		if (!(nativePointer == IntPtr.Zero))
		{
			return new hhwTHKlniCMKoBzWDzyznYMwDzW(nativePointer);
		}
		return null;
	}

	internal unsafe void QwlqMowzoTgatlScCCtMboXeJdt(Guid P_0, out IntPtr P_1, vAWguSwtalYfBjVbuWSVCdiToKd P_2)
	{
		cTKAHZacuViBRtnMbZwDuEpUfDCh cTKAHZacuViBRtnMbZwDuEpUfDCh2;
		fixed (IntPtr* ptr = &P_1)
		{
			cTKAHZacuViBRtnMbZwDuEpUfDCh2 = dvALKlvqHaIIzWlUvVLHjEDiBGVC(fRSdJIinkkjfuOwZLyQSrdGfQnO, &P_0, ptr, (void*)(P_2?.NativePointer ?? IntPtr.Zero));
		}
		cTKAHZacuViBRtnMbZwDuEpUfDCh2.zHpTMwuToxnnciRWweSPaClPGJQ();
	}

	internal unsafe void SbkbWYvbgarXEfughPoKuIdLKGq(int P_0, VzdDEQzWYAEPiDcEMhDDSBkBQPY P_1, IntPtr P_2, acSaGRXzHfCbnAZWrzgPGuGjden P_3)
	{
		((cTKAHZacuViBRtnMbZwDuEpUfDCh)LtmzGYeRhRJLNcMeOCThGiWkEwt(fRSdJIinkkjfuOwZLyQSrdGfQnO, P_0, P_1, (void*)P_2, (int)P_3)).zHpTMwuToxnnciRWweSPaClPGJQ();
	}

	internal unsafe cTKAHZacuViBRtnMbZwDuEpUfDCh UFbaWZatuexzUjCBpvHMbwyattK(Guid P_0)
	{
		return DgwYTsKUdHuYRckWjkOyAsmyVmR(fRSdJIinkkjfuOwZLyQSrdGfQnO, &P_0);
	}

	internal unsafe void WNcAXlczNhSOFJApyCuQeTfEQxRl(IntPtr P_0, int P_1)
	{
		((cTKAHZacuViBRtnMbZwDuEpUfDCh)HlfPhdNIbMRBKbaWJDQDcvQbPZO(fRSdJIinkkjfuOwZLyQSrdGfQnO, (void*)P_0, P_1)).zHpTMwuToxnnciRWweSPaClPGJQ();
	}

	internal unsafe void BVmTKMsAVVqdkfwNjSwlgNFzTsh(IntPtr P_0, int P_1)
	{
		((cTKAHZacuViBRtnMbZwDuEpUfDCh)BYwaTSkvFZLnUqFQdmPyvOcLiNN(fRSdJIinkkjfuOwZLyQSrdGfQnO, (void*)P_0, P_1)).zHpTMwuToxnnciRWweSPaClPGJQ();
	}

	public unsafe Guid bomphbyuEnSyibdDziyaEhYQzZk(Guid P_0, string P_1)
	{
		Guid result = default(Guid);
		((cTKAHZacuViBRtnMbZwDuEpUfDCh)IwuaWRTJAhYdeJNRlUaReVZgFaR(fRSdJIinkkjfuOwZLyQSrdGfQnO, &P_0, P_1, &result)).zHpTMwuToxnnciRWweSPaClPGJQ();
		return result;
	}

	internal unsafe void WBPFNGJVzavnofPnrNvqpBgEAUq(string P_0, ref kYqoEuRGCUeaPqPuAzhqXcQXMjm P_1, VzdDEQzWYAEPiDcEMhDDSBkBQPY P_2, IntPtr P_3, int P_4)
	{
		kYqoEuRGCUeaPqPuAzhqXcQXMjm.PEIrTCfrSLbLMJtrlXXfvEmbMt pEIrTCfrSLbLMJtrlXXfvEmbMt = default(kYqoEuRGCUeaPqPuAzhqXcQXMjm.PEIrTCfrSLbLMJtrlXXfvEmbMt);
		P_1.IxSdeKJbNNiZPCGfuTHHyPvyjTN(ref pEIrTCfrSLbLMJtrlXXfvEmbMt);
		cTKAHZacuViBRtnMbZwDuEpUfDCh cTKAHZacuViBRtnMbZwDuEpUfDCh2 = HizUwdBLWAEhtwOCVonOVOBIJqB(fRSdJIinkkjfuOwZLyQSrdGfQnO, P_0, &pEIrTCfrSLbLMJtrlXXfvEmbMt, P_2, (void*)P_3, P_4);
		P_1.pUePerxEkizOGEHkPEfPBMtCpTu(ref pEIrTCfrSLbLMJtrlXXfvEmbMt);
		cTKAHZacuViBRtnMbZwDuEpUfDCh2.zHpTMwuToxnnciRWweSPaClPGJQ();
	}
}
