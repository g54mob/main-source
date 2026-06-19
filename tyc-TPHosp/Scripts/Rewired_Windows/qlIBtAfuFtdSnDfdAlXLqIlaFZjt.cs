using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Libraries.SharpDX.DirectInput;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

[Guid("bf798031-483a-4da2-aa99-5d64ed369700")]
internal class qlIBtAfuFtdSnDfdAlXLqIlaFZjt : gEzWBZtKpodhyJneHyYqvTiSSEh
{
	private static class iwhILbaYKnLCUeSeWOWSsvuUZcU
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private unsafe delegate int gJlnMRTLXORRjaVvdnqVrUMZcsn(void* deviceInstance, IntPtr data);

		private static gJlnMRTLXORRjaVvdnqVrUMZcsn iWJLmGxRkATRajaGxiTgAzQvcIb;

		private static IntPtr tcYfZxiISHyTbJkCxxciJPextWo;

		private static int wmEejqVnVEaFBiqSVHrxYetOWTn;

		public static IntPtr callbackPointer => tcYfZxiISHyTbJkCxxciJPextWo;

		public static int count => wmEejqVnVEaFBiqSVHrxYetOWTn;

		unsafe static iwhILbaYKnLCUeSeWOWSsvuUZcU()
		{
			iWJLmGxRkATRajaGxiTgAzQvcIb = fLILWIVczrkZXOeVWFvxfwcrGnZ;
			tcYfZxiISHyTbJkCxxciJPextWo = Marshal.GetFunctionPointerForDelegate((Delegate)iWJLmGxRkATRajaGxiTgAzQvcIb);
		}

		public static int zzUNIBdRAggPNAkDpmYEbaHJtFY()
		{
			int result = wmEejqVnVEaFBiqSVHrxYetOWTn;
			rKJfCRBWFLQsKCjGykmcumzKLPwE();
			return result;
		}

		public static void rKJfCRBWFLQsKCjGykmcumzKLPwE()
		{
			wmEejqVnVEaFBiqSVHrxYetOWTn = 0;
		}

		[MonoPInvokeCallback(typeof(gJlnMRTLXORRjaVvdnqVrUMZcsn))]
		private unsafe static int fLILWIVczrkZXOeVWFvxfwcrGnZ(void* P_0, IntPtr P_1)
		{
			wmEejqVnVEaFBiqSVHrxYetOWTn++;
			return 1;
		}
	}

	public qlIBtAfuFtdSnDfdAlXLqIlaFZjt()
		: base(IntPtr.Zero)
	{
		TUTdkzWHZgwPvLCcgnNWOibcMrP.ACHgaXaFqNzLRoWaiZKCdCrIhBd(VSyukewrRBnJVtJQxKxaSTMtC.ZHvsVpdmdKNkQeHdLJhQghdegmUg(null), 2048, QvyMHYIdbHWMtWGQBjyLybggaNAi.wuSqkwcojnsLLKdCXbfAflWUpDa(typeof(qlIBtAfuFtdSnDfdAlXLqIlaFZjt)), out var nativePointer, null);
		base.NativePointer = nativePointer;
	}

	public IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> npLwcPNqCJKIqEewEfYdgbDGPcD()
	{
		return npLwcPNqCJKIqEewEfYdgbDGPcD(HiBJWeyeWfhElzlDChLUgQROjnAq.lKcDIMfHrbBBgTzhXBojeBKdnPsp, zTnRQWEjlkWYSgeKMuNijZncOjb.OEvYElWBEWfTmlOFcDxyzxlVZaC);
	}

	public IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> npLwcPNqCJKIqEewEfYdgbDGPcD(HiBJWeyeWfhElzlDChLUgQROjnAq P_0, zTnRQWEjlkWYSgeKMuNijZncOjb P_1)
	{
		using ObjectInstanceTracker.Wrapper<lxPxNnyqfSWYGcGZBFHqoAhnBnw> wrapper = new ObjectInstanceTracker.Wrapper<lxPxNnyqfSWYGcGZBFHqoAhnBnw>(new lxPxNnyqfSWYGcGZBFHqoAhnBnw());
		lxPxNnyqfSWYGcGZBFHqoAhnBnw instance = wrapper.instance;
		HUJZVBglMfIxtNioWsjpZLMGyGw((int)P_0, instance.NativePointer, new IntPtr((int)wrapper.instanceId), P_1);
		return instance.DeviceInstances;
	}

	public IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> npLwcPNqCJKIqEewEfYdgbDGPcD(DeviceType P_0, zTnRQWEjlkWYSgeKMuNijZncOjb P_1)
	{
		using ObjectInstanceTracker.Wrapper<lxPxNnyqfSWYGcGZBFHqoAhnBnw> wrapper = new ObjectInstanceTracker.Wrapper<lxPxNnyqfSWYGcGZBFHqoAhnBnw>(new lxPxNnyqfSWYGcGZBFHqoAhnBnw());
		lxPxNnyqfSWYGcGZBFHqoAhnBnw instance = wrapper.instance;
		HUJZVBglMfIxtNioWsjpZLMGyGw((int)P_0, instance.NativePointer, new IntPtr((int)wrapper.instanceId), P_1);
		return instance.DeviceInstances;
	}

	public int uYEAGtqGpXGOqyYytMRHARWYrtv(HiBJWeyeWfhElzlDChLUgQROjnAq P_0, zTnRQWEjlkWYSgeKMuNijZncOjb P_1)
	{
		iwhILbaYKnLCUeSeWOWSsvuUZcU.rKJfCRBWFLQsKCjGykmcumzKLPwE();
		HUJZVBglMfIxtNioWsjpZLMGyGw((int)P_0, iwhILbaYKnLCUeSeWOWSsvuUZcU.callbackPointer, IntPtr.Zero, P_1);
		return iwhILbaYKnLCUeSeWOWSsvuUZcU.zzUNIBdRAggPNAkDpmYEbaHJtFY();
	}

	public int uYEAGtqGpXGOqyYytMRHARWYrtv(DeviceType P_0, zTnRQWEjlkWYSgeKMuNijZncOjb P_1)
	{
		iwhILbaYKnLCUeSeWOWSsvuUZcU.rKJfCRBWFLQsKCjGykmcumzKLPwE();
		HUJZVBglMfIxtNioWsjpZLMGyGw((int)P_0, iwhILbaYKnLCUeSeWOWSsvuUZcU.callbackPointer, IntPtr.Zero, P_1);
		return iwhILbaYKnLCUeSeWOWSsvuUZcU.zzUNIBdRAggPNAkDpmYEbaHJtFY();
	}

	public bool YXHHdWXxvTPYwRhsUBWBnayhySV(Guid P_0)
	{
		return BYeqYBjEnmdjtFHSudtoYPjZtQ(P_0).Code == 0;
	}

	public void NZjveIihgBQaYgnHvGvCyOTPdRC()
	{
		NZjveIihgBQaYgnHvGvCyOTPdRC(IntPtr.Zero);
	}

	public void NZjveIihgBQaYgnHvGvCyOTPdRC(IntPtr P_0)
	{
		NZjveIihgBQaYgnHvGvCyOTPdRC(P_0, 0);
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LGlyILIQogNuCQCsjzQbrIFWteP(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Release")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern void ekcCJZyTJMrAYunCzTDxKTshZPU(void* P_0);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_CreateDevice")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int iidoGgaVnfMxCiQOCrRyQEotGXF(void* P_0, void* P_1, void* P_2, void* P_3);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_EnumDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KZRmiVvfNMZDmYdsjchSxmtxayf(void* P_0, int P_1, void* P_2, void* P_3, int P_4);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_GetDeviceStatus")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UuTssbJCoMHwcBUkWQQNppPfiRVd(void* P_0, void* P_1);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_RunControlPanel")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QhQdhwiCcPoJrCRsFgrccNGPoNMG(void* P_0, void* P_1, int P_2);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Initialize")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OJBJhPvwfUNfxCfYKkvBIFNYaLJ(void* P_0, void* P_1, int P_2);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_FindDevice")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RHPOUCIOucCEXtnDKDuiaRarSNFX(void* P_0, void* P_1, string P_2, void* P_3);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_EnumDevicesBySemantics")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UnMYfsOBqPpwMYoUuHdpiTuNosR(void* P_0, string P_1, void* P_2, void* P_3, void* P_4, int P_5);

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_ConfigureDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int trGbgGwmzGAMDEFVezNrQfitCeIf(void* P_0, void* P_1, void* P_2, int P_3, void* P_4);

	public qlIBtAfuFtdSnDfdAlXLqIlaFZjt(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator qlIBtAfuFtdSnDfdAlXLqIlaFZjt(IntPtr nativePointer)
	{
		if (!(nativePointer == IntPtr.Zero))
		{
			return new qlIBtAfuFtdSnDfdAlXLqIlaFZjt(nativePointer);
		}
		return null;
	}

	internal unsafe void VKCsEbdZYWymMBlwhZzpSHobnqb(Guid P_0, out IntPtr P_1, gEzWBZtKpodhyJneHyYqvTiSSEh P_2)
	{
		llpFqWliQEfHkPmCCWtyJDAPdFG llpFqWliQEfHkPmCCWtyJDAPdFG2;
		fixed (IntPtr* ptr = &P_1)
		{
			llpFqWliQEfHkPmCCWtyJDAPdFG2 = iidoGgaVnfMxCiQOCrRyQEotGXF(gBbLrXrPAfTbPiLRobgphErqzjOU, &P_0, ptr, (void*)(P_2?.NativePointer ?? IntPtr.Zero));
		}
		llpFqWliQEfHkPmCCWtyJDAPdFG2.oCKdtZanlshnKAQVdRIdxFviUCRp();
	}

	internal unsafe void HUJZVBglMfIxtNioWsjpZLMGyGw(int P_0, WuKgxXkLkVcMNnTwbyDazkJKWQQ P_1, IntPtr P_2, zTnRQWEjlkWYSgeKMuNijZncOjb P_3)
	{
		((llpFqWliQEfHkPmCCWtyJDAPdFG)KZRmiVvfNMZDmYdsjchSxmtxayf(gBbLrXrPAfTbPiLRobgphErqzjOU, P_0, P_1, (void*)P_2, (int)P_3)).oCKdtZanlshnKAQVdRIdxFviUCRp();
	}

	internal unsafe llpFqWliQEfHkPmCCWtyJDAPdFG BYeqYBjEnmdjtFHSudtoYPjZtQ(Guid P_0)
	{
		return UuTssbJCoMHwcBUkWQQNppPfiRVd(gBbLrXrPAfTbPiLRobgphErqzjOU, &P_0);
	}

	internal unsafe void NZjveIihgBQaYgnHvGvCyOTPdRC(IntPtr P_0, int P_1)
	{
		((llpFqWliQEfHkPmCCWtyJDAPdFG)QhQdhwiCcPoJrCRsFgrccNGPoNMG(gBbLrXrPAfTbPiLRobgphErqzjOU, (void*)P_0, P_1)).oCKdtZanlshnKAQVdRIdxFviUCRp();
	}

	internal unsafe void EhDmNHbdNOhARNgJSMpMFgeqbsn(IntPtr P_0, int P_1)
	{
		((llpFqWliQEfHkPmCCWtyJDAPdFG)OJBJhPvwfUNfxCfYKkvBIFNYaLJ(gBbLrXrPAfTbPiLRobgphErqzjOU, (void*)P_0, P_1)).oCKdtZanlshnKAQVdRIdxFviUCRp();
	}

	public unsafe Guid khVpXkrCgqXQBBdFCYKLvvpZkna(Guid P_0, string P_1)
	{
		Guid result = default(Guid);
		((llpFqWliQEfHkPmCCWtyJDAPdFG)RHPOUCIOucCEXtnDKDuiaRarSNFX(gBbLrXrPAfTbPiLRobgphErqzjOU, &P_0, P_1, &result)).oCKdtZanlshnKAQVdRIdxFviUCRp();
		return result;
	}

	internal unsafe void ZOiTjPQPphNtTBXTALdJMPuJEGsK(string P_0, ref rUBhSPUQuLAqiCKTvXZVpgPYcIgp P_1, WuKgxXkLkVcMNnTwbyDazkJKWQQ P_2, IntPtr P_3, int P_4)
	{
		rUBhSPUQuLAqiCKTvXZVpgPYcIgp.wwjdkwbeoCjTmudmiAHddkIdIWhZ wwjdkwbeoCjTmudmiAHddkIdIWhZ = default(rUBhSPUQuLAqiCKTvXZVpgPYcIgp.wwjdkwbeoCjTmudmiAHddkIdIWhZ);
		P_1.ZOrqRDWidYwRgwHrRQtkXoMvWTT(ref wwjdkwbeoCjTmudmiAHddkIdIWhZ);
		llpFqWliQEfHkPmCCWtyJDAPdFG llpFqWliQEfHkPmCCWtyJDAPdFG2 = UnMYfsOBqPpwMYoUuHdpiTuNosR(gBbLrXrPAfTbPiLRobgphErqzjOU, P_0, &wwjdkwbeoCjTmudmiAHddkIdIWhZ, P_2, (void*)P_3, P_4);
		P_1.kjBylwccExFrrDmokNVqqwIBbPgm(ref wwjdkwbeoCjTmudmiAHddkIdIWhZ);
		llpFqWliQEfHkPmCCWtyJDAPdFG2.oCKdtZanlshnKAQVdRIdxFviUCRp();
	}
}
