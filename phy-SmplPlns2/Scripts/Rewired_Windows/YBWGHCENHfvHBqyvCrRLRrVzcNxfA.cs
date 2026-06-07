using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class YBWGHCENHfvHBqyvCrRLRrVzcNxfA
{
	public unsafe static int UIESzxairPBnLnvzZpCldikAYAsV(int P_0, int P_1, out ResmAOyxegdpBQdrDidnUjXIxPCQ P_2)
	{
		if (wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ >= akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_4)
		{
			P_2 = default(ResmAOyxegdpBQdrDidnUjXIxPCQ);
			return 0;
		}
		P_2 = default(ResmAOyxegdpBQdrDidnUjXIxPCQ);
		int result;
		fixed (ResmAOyxegdpBQdrDidnUjXIxPCQ* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = rDPRSTVuRCfVMuOJHDuGFTrBxIFjA(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int rDPRSTVuRCfVMuOJHDuGFTrBxIFjA(int P_0, int P_1, void* P_2)
	{
		return wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ switch
		{
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3 => KaEuXkDmOvOVvZUKhuPBxCyfRhWx(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2 => iSMEjeeZjLtiUtclXxjrobLNjqwE(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1 => JewiMsAWIwMVTWNQnRfEhHgPauAEA(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0 => wESwffdHRTJdUhCYwaRCXcEmzQZU(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wESwffdHRTJdUhCYwaRCXcEmzQZU(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JewiMsAWIwMVTWNQnRfEhHgPauAEA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int iSMEjeeZjLtiUtclXxjrobLNjqwE(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KaEuXkDmOvOVvZUKhuPBxCyfRhWx(int P_0, int P_1, void* P_2);

	public unsafe static int AFfhLxFvMyLtdvUzYjopXhRMaZvx(int P_0, wiMVRiZUpecBrLLXIdvoBrQxZgxk P_1)
	{
		return jZFwMLNbcMoydzYcaoDKyalSdizf(P_0, &P_1);
	}

	private unsafe static int jZFwMLNbcMoydzYcaoDKyalSdizf(int P_0, void* P_1)
	{
		return wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ switch
		{
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_4 => azsTsEuhqlffvDQGaLmYFsWHVgrzA(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3 => EHrWPuOlbiujjwIzDhSHNReNWFCf(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2 => TgoreXTdZEMHOqznedzhKamqUlAc(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1 => uCXexsAGRPagHikXFHZRISxfNwaDB(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0 => aWYiwnGAiImmvWghGCUdHBKfxFGtA(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aWYiwnGAiImmvWghGCUdHBKfxFGtA(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int uCXexsAGRPagHikXFHZRISxfNwaDB(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TgoreXTdZEMHOqznedzhKamqUlAc(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int EHrWPuOlbiujjwIzDhSHNReNWFCf(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int azsTsEuhqlffvDQGaLmYFsWHVgrzA(int P_0, void* P_1);

	public unsafe static int sxoUnqjUFYUTWaYNKbkhQCOtikod(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (Guid* ptr = &P_1)
		{
			void* ptr2 = ptr;
			fixed (Guid* ptr3 = &P_2)
			{
				void* ptr4 = ptr3;
				result = OclbGVbJkJqTgQgNMhYLWNBIvQjh(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int OclbGVbJkJqTgQgNMhYLWNBIvQjh(int P_0, void* P_1, void* P_2)
	{
		return wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ switch
		{
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3 => dnKEbKxwJrjTsCgGkiTkYbWnerEmA(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2 => ZpuBBwhjoBXuqfVmwNEWIOIFxLJgb(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1 => xFpyLpSFltaFegNJOXOelobhqYEFb(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0 => oktIJvGhchBrMoUxmdgUYWvWwqCy(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oktIJvGhchBrMoUxmdgUYWvWwqCy(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xFpyLpSFltaFegNJOXOelobhqYEFb(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZpuBBwhjoBXuqfVmwNEWIOIFxLJgb(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dnKEbKxwJrjTsCgGkiTkYbWnerEmA(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int uDmJXotUvjydYGfulikILkTfTQnC(int P_0, out pKkCzsEckBaUoBcvMDSUkuZdVCzgA P_1)
	{
		P_1 = default(pKkCzsEckBaUoBcvMDSUkuZdVCzgA);
		int result;
		fixed (pKkCzsEckBaUoBcvMDSUkuZdVCzgA* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = ZHDfvWrjxMZyhrJSRbONhKywBcNcA(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int ZHDfvWrjxMZyhrJSRbONhKywBcNcA(int P_0, void* P_1)
	{
		if (wHjfVJsrMiRUzqkXLzlmJabeEUxs.qGuinsZyvsIwtWKCiMUujAADchchA && wHjfVJsrMiRUzqkXLzlmJabeEUxs.caSmkZlhbthYMNYMgfgArSjdTIYM != null)
		{
			return wHjfVJsrMiRUzqkXLzlmJabeEUxs.caSmkZlhbthYMNYMgfgArSjdTIYM(P_0, P_1);
		}
		return wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ switch
		{
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_4 => pnvuOEIsmuqnpqjCLElrYdxvIyCO(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3 => DRBiOwNEdCERtKnnoChjuwtvlVzfA(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2 => tzbFzreXhZSTBeIsgLVTkImiLfrM(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1 => xcjiGNIehpoaHyMkhnXhFcfHMMXBb(P_0, P_1), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0 => BffBvsMebtdPbOUpWoVhelpRgpzM(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BffBvsMebtdPbOUpWoVhelpRgpzM(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xcjiGNIehpoaHyMkhnXhFcfHMMXBb(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tzbFzreXhZSTBeIsgLVTkImiLfrM(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DRBiOwNEdCERtKnnoChjuwtvlVzfA(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pnvuOEIsmuqnpqjCLElrYdxvIyCO(int P_0, void* P_1);

	public unsafe static int qomjhZagmOFxkhXEItLzssdrXAkU(int P_0, JymHAvrnPSxZRGvgWOgLWQQayzhF P_1, out ahTDkqWAlkFHaatFgCIQfUIUlUbYA P_2)
	{
		P_2 = default(ahTDkqWAlkFHaatFgCIQfUIUlUbYA);
		int result;
		fixed (ahTDkqWAlkFHaatFgCIQfUIUlUbYA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = EWaijccnAQzUwwnelayaWFBgdQSD(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int EWaijccnAQzUwwnelayaWFBgdQSD(int P_0, int P_1, void* P_2)
	{
		return wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ switch
		{
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_4 => nYVsQhuhxgBBRTaMmsAamhePdLLu(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3 => NDTxYVKaXrnBINZRWHnufCFhekxs(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2 => KhTGbnZUyuwuJZlokHfmtRazCFxhA(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1 => AJUqclbrLuyVooIRnEcHCGGhdCiDA(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0 => jmhfTBLOQSVkzqqaVRKbppnBziiK(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jmhfTBLOQSVkzqqaVRKbppnBziiK(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AJUqclbrLuyVooIRnEcHCGGhdCiDA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KhTGbnZUyuwuJZlokHfmtRazCFxhA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NDTxYVKaXrnBINZRWHnufCFhekxs(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nYVsQhuhxgBBRTaMmsAamhePdLLu(int P_0, int P_1, void* P_2);

	public unsafe static int nhuXlxfxXANOccVZiEYokDMjrqLs(int P_0, uPKEEnteyIXCpwwqUQpKLGbqjAGo P_1, out nDEReZDRAQTIszfTiwidLJKiQAMo P_2)
	{
		P_2 = default(nDEReZDRAQTIszfTiwidLJKiQAMo);
		int result;
		fixed (nDEReZDRAQTIszfTiwidLJKiQAMo* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = nuHVvuobdDzppQHcirkrkBRUACSq(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int nuHVvuobdDzppQHcirkrkBRUACSq(int P_0, int P_1, void* P_2)
	{
		return wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ switch
		{
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3 => aJqcaogiaImqAaQlASZVlIhvTTWIB(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2 => IsTegUpxjzLuUgAKjBfUUWtkgrZt(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1 => ZxUCsCpIjweICfllLNCNtIsiunWg(P_0, P_1, P_2), 
			akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0 => uJHBZdSkEurKpilKqlhkrRfDSURD(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int uJHBZdSkEurKpilKqlhkrRfDSURD(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZxUCsCpIjweICfllLNCNtIsiunWg(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int IsTegUpxjzLuUgAKjBfUUWtkgrZt(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aJqcaogiaImqAaQlASZVlIhvTTWIB(int P_0, int P_1, void* P_2);

	public static void sUCCIPmtFFhLxFUAzFWicSjEzSHUb(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0)
	{
		PfmrvRzTvafSZWNOLDkceyNPgjot(P_0);
	}

	private static void PfmrvRzTvafSZWNOLDkceyNPgjot(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0)
	{
		switch (wHjfVJsrMiRUzqkXLzlmJabeEUxs.SwAUHbwiWlRhjFcSIvOWVHKYyKUJ)
		{
		case akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_3:
			ygIicpxZLBrrsxxpTXuMlCuMcyof(P_0);
			break;
		case akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_2:
			whyGacKCOhHbfRlTViINjVbzIYWVA(P_0);
			break;
		case akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_1_1:
			lnZWSAFNKzMbNlRwfVgfvFGyBpXQ(P_0);
			break;
		case akrbRtVxdChjDUDDQVgNeGhDwOgV.XINPUT_9_1_0:
			tfTmOAtZDWCwEwaLKMblqXqlePlI(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void tfTmOAtZDWCwEwaLKMblqXqlePlI(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void lnZWSAFNKzMbNlRwfVgfvFGyBpXQ(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void whyGacKCOhHbfRlTViINjVbzIYWVA(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ygIicpxZLBrrsxxpTXuMlCuMcyof(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0);
}
