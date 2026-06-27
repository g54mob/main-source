using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class TiRNVNFzlgMyTptUhdyGLJthDkZC
{
	public unsafe static int VZFpaewZDKkXBwpQokgmliRYEYGC(int P_0, int P_1, out KAfviLikIngoPJtxceBahYTMIDcQA P_2)
	{
		if (xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT >= dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_4)
		{
			P_2 = default(KAfviLikIngoPJtxceBahYTMIDcQA);
			return 0;
		}
		P_2 = default(KAfviLikIngoPJtxceBahYTMIDcQA);
		int result;
		fixed (KAfviLikIngoPJtxceBahYTMIDcQA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = wdAKaGNbpDURCjHJoJIBJqxBBQlHA(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int wdAKaGNbpDURCjHJoJIBJqxBBQlHA(int P_0, int P_1, void* P_2)
	{
		return xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT switch
		{
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3 => HcVNnrFyTqIkfUOkClSWpuMztpeD(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2 => hiNESrkOfWEuAeLbwcNkewBVlvIsA(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1 => YbbCFbYiPjOiVHAKWTTZtirRkkuD(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0 => dYPoccpHxGrOIqmKTbnFiJYiUIvVA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dYPoccpHxGrOIqmKTbnFiJYiUIvVA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YbbCFbYiPjOiVHAKWTTZtirRkkuD(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hiNESrkOfWEuAeLbwcNkewBVlvIsA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HcVNnrFyTqIkfUOkClSWpuMztpeD(int P_0, int P_1, void* P_2);

	public unsafe static int LasFKeTkkbwalkbnfUEqLJDQJvDD(int P_0, fBHyZvHoVlntzUhFrgFfHdKvuXJV P_1)
	{
		return iCQrmCZFXXahfayCJjWTskdIafRpA(P_0, &P_1);
	}

	private unsafe static int iCQrmCZFXXahfayCJjWTskdIafRpA(int P_0, void* P_1)
	{
		return xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT switch
		{
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_4 => bghsVXwNGcwWhLmANIvTefQJqcNk(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3 => LtgfCSEwTrJljpQMsfTIZGFVnCgw(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2 => SzjfjnLpRLDJJtLtZaRefGmaUUBrA(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1 => xhActvQCrSSvBzMTsPbUQnnPrwYV(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0 => lJTeiSKGNFvfRJffviyRZKzMZqS(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lJTeiSKGNFvfRJffviyRZKzMZqS(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xhActvQCrSSvBzMTsPbUQnnPrwYV(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SzjfjnLpRLDJJtLtZaRefGmaUUBrA(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LtgfCSEwTrJljpQMsfTIZGFVnCgw(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bghsVXwNGcwWhLmANIvTefQJqcNk(int P_0, void* P_1);

	public unsafe static int vJtRYbfxcTfFOtEAdhDcIGWfkwGfA(int P_0, out Guid P_1, out Guid P_2)
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
				result = RCoAbKBjYUnnwcNTxeTCtKXIvvDSA(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int RCoAbKBjYUnnwcNTxeTCtKXIvvDSA(int P_0, void* P_1, void* P_2)
	{
		return xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT switch
		{
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3 => ssXjkRfXteQninrMDzbhfREtvzkI(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2 => SPfcXnrcIGBfmJQgXRqXRECXvJdVA(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1 => oCuPQgYpBeUXwCABbqMbqtWxExuD(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0 => bqENyPSIaXkOcrfPCSLbItEuwgfb(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bqENyPSIaXkOcrfPCSLbItEuwgfb(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oCuPQgYpBeUXwCABbqMbqtWxExuD(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SPfcXnrcIGBfmJQgXRqXRECXvJdVA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ssXjkRfXteQninrMDzbhfREtvzkI(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int fExrHzzuguglQXGpSnWRNAmtIFTdA(int P_0, out cUdaxzbKWYMFaUUhzEgTRmDfJGBeb P_1)
	{
		P_1 = default(cUdaxzbKWYMFaUUhzEgTRmDfJGBeb);
		int result;
		fixed (cUdaxzbKWYMFaUUhzEgTRmDfJGBeb* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = YYEdaTpFxRhonsAmayCWhqXusrnb(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int YYEdaTpFxRhonsAmayCWhqXusrnb(int P_0, void* P_1)
	{
		if (xYoDbOgqRzHthdFjePrhFpDaEuRD.zTfnfqZNtlxxDJYoDwbbxUUXrYPb && xYoDbOgqRzHthdFjePrhFpDaEuRD.zHamMvLagXUQICAHSsRnzqbMaiG != null)
		{
			return xYoDbOgqRzHthdFjePrhFpDaEuRD.zHamMvLagXUQICAHSsRnzqbMaiG(P_0, P_1);
		}
		return xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT switch
		{
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_4 => mWevaNEiKjextHxWkGTuMUzvkgilA(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3 => UkSMjBLJNZYbMkrnRHwDilFzVNmc(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2 => sgctCyuFLMSAPloMPrdQaoekjqTe(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1 => keeYRMobFahzLTzaCchayOzLgApDA(P_0, P_1), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0 => MfwgZjFAFmyOfSNtdxlgBuhJQdTaA(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MfwgZjFAFmyOfSNtdxlgBuhJQdTaA(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int keeYRMobFahzLTzaCchayOzLgApDA(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int sgctCyuFLMSAPloMPrdQaoekjqTe(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UkSMjBLJNZYbMkrnRHwDilFzVNmc(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mWevaNEiKjextHxWkGTuMUzvkgilA(int P_0, void* P_1);

	public unsafe static int rrHlOQuOJZawSEShFryNajlAMQrA(int P_0, CKzzXstLbLWeHDegzKeIKdCmmoDQ P_1, out zeUjBxbSTxpQeenLFPmXUASDQAJKb P_2)
	{
		P_2 = default(zeUjBxbSTxpQeenLFPmXUASDQAJKb);
		int result;
		fixed (zeUjBxbSTxpQeenLFPmXUASDQAJKb* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = XfteobsOXBfaczttSqUhSJLoduoK(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int XfteobsOXBfaczttSqUhSJLoduoK(int P_0, int P_1, void* P_2)
	{
		return xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT switch
		{
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_4 => qEQlsccnPrSSVUTYBuIdgsyFvXht(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3 => SbGcrKIXbeGoCEEJlOhdWbJtWcJTA(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2 => TeEzwsFWAlrQLSOyBJLfdlwlLPVF(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1 => ZYHmtmrrLdfVqdJeUOBGWjWnMaOm(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0 => sSuVxKRuiHvSllNawLzgbzbJizQS(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int sSuVxKRuiHvSllNawLzgbzbJizQS(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZYHmtmrrLdfVqdJeUOBGWjWnMaOm(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TeEzwsFWAlrQLSOyBJLfdlwlLPVF(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SbGcrKIXbeGoCEEJlOhdWbJtWcJTA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qEQlsccnPrSSVUTYBuIdgsyFvXht(int P_0, int P_1, void* P_2);

	public unsafe static int cWltfmrtfRTMyvhRJgxrguSxawrI(int P_0, xmVnUizPYRKWhjRqnsaVNRrcfScn P_1, out aDVaXERqbNFIqkDRFIcyDWUmCCyf P_2)
	{
		P_2 = default(aDVaXERqbNFIqkDRFIcyDWUmCCyf);
		int result;
		fixed (aDVaXERqbNFIqkDRFIcyDWUmCCyf* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = wMGmNdaVVEPgnTvkJhFaspTYbGgn(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int wMGmNdaVVEPgnTvkJhFaspTYbGgn(int P_0, int P_1, void* P_2)
	{
		return xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT switch
		{
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3 => vVhawfwyIFVnEVklnhvSKHvBAZgCA(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2 => DIAuIZhNiaKbMxSTSLXTAriwdHlC(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1 => KJBqQLpIyvjfWkPdqTfAphquOomU(P_0, P_1, P_2), 
			dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0 => jTOONwImOnVqbzIhZMZjdARVDQbN(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jTOONwImOnVqbzIhZMZjdARVDQbN(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int KJBqQLpIyvjfWkPdqTfAphquOomU(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DIAuIZhNiaKbMxSTSLXTAriwdHlC(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vVhawfwyIFVnEVklnhvSKHvBAZgCA(int P_0, int P_1, void* P_2);

	public static void lLLaCOkGlQQUdXPMYDalIKvllOlZ(DKIIzhMACWIemCHikiFxBDRSyXEo P_0)
	{
		YBhrxGxNytNjHDAFuWIboToBnjQC(P_0);
	}

	private static void YBhrxGxNytNjHDAFuWIboToBnjQC(DKIIzhMACWIemCHikiFxBDRSyXEo P_0)
	{
		switch (xYoDbOgqRzHthdFjePrhFpDaEuRD.HmXoCyiyGaaUtCYGfCNLXDWEQweT)
		{
		case dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3:
			ncVviepWnWEwucixspQFdaqYAuMV(P_0);
			break;
		case dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_2:
			hepmxrMcumCehypVcCuWNjxlNOgN(P_0);
			break;
		case dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_1:
			qWKTCRHisiAJZyccCUdszzUwJhvr(P_0);
			break;
		case dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_9_1_0:
			yEEimHbzjHYZABxNldikfguHdkLKb(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void yEEimHbzjHYZABxNldikfguHdkLKb(DKIIzhMACWIemCHikiFxBDRSyXEo P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void qWKTCRHisiAJZyccCUdszzUwJhvr(DKIIzhMACWIemCHikiFxBDRSyXEo P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void hepmxrMcumCehypVcCuWNjxlNOgN(DKIIzhMACWIemCHikiFxBDRSyXEo P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ncVviepWnWEwucixspQFdaqYAuMV(DKIIzhMACWIemCHikiFxBDRSyXEo P_0);
}
