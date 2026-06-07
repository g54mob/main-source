using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class ZRGagoAhzvcMXxRNltuRmQnomofb
{
	public unsafe static int sgvfdxeQjiGlYimbbxFwaXQGzvdQc(int P_0, int P_1, out UbeQNibbMmFSUGBLKKTSbjKGYwDSB P_2)
	{
		if (jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA >= vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_4)
		{
			P_2 = default(UbeQNibbMmFSUGBLKKTSbjKGYwDSB);
			return 0;
		}
		P_2 = default(UbeQNibbMmFSUGBLKKTSbjKGYwDSB);
		int result;
		fixed (UbeQNibbMmFSUGBLKKTSbjKGYwDSB* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = pbxhWzFGwJmYYkNibPSVKHsyRDXdA(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int pbxhWzFGwJmYYkNibPSVKHsyRDXdA(int P_0, int P_1, void* P_2)
	{
		return jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA switch
		{
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3 => SISpxdjggRWpzlrzohSNsOImAfSN(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2 => epDEhDKtzJceyEEbDEdvOfZKYBwVb(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1 => FsUtFubWrokCKpdLMazWEWCAnqTmA(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0 => krHTIUtLLHwgwbKIGtsbidbuvPWT(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int krHTIUtLLHwgwbKIGtsbidbuvPWT(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int FsUtFubWrokCKpdLMazWEWCAnqTmA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int epDEhDKtzJceyEEbDEdvOfZKYBwVb(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SISpxdjggRWpzlrzohSNsOImAfSN(int P_0, int P_1, void* P_2);

	public unsafe static int BCuPBRXFqcxTmDwPZDolHBkriQku(int P_0, tpSNqCAYHsNToWutFORZokHrSgaV P_1)
	{
		return JWydmtQNdkHwqAfNBbfcNpZPjHD(P_0, &P_1);
	}

	private unsafe static int JWydmtQNdkHwqAfNBbfcNpZPjHD(int P_0, void* P_1)
	{
		return jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA switch
		{
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_4 => tJiYoghvxIgDUfrzXbXqFSRolczK(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3 => AxoMtMnNjqldkxDfsRcGRXPCGeBw(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2 => RzgjzvfloGruKnvRDbVYGbvzIcdH(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1 => TILAKaRLszBmYoHjZMVIswZrcOJp(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0 => WYusNlVBtfCPgwicnVtzUzXMHcJk(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WYusNlVBtfCPgwicnVtzUzXMHcJk(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TILAKaRLszBmYoHjZMVIswZrcOJp(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RzgjzvfloGruKnvRDbVYGbvzIcdH(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AxoMtMnNjqldkxDfsRcGRXPCGeBw(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tJiYoghvxIgDUfrzXbXqFSRolczK(int P_0, void* P_1);

	public unsafe static int nzbZiQUvWaRsqxpWSFOLtocNZNYA(int P_0, out Guid P_1, out Guid P_2)
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
				result = iPpdeVGnILksdOfGhloWDMmGMGVHb(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int iPpdeVGnILksdOfGhloWDMmGMGVHb(int P_0, void* P_1, void* P_2)
	{
		return jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA switch
		{
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3 => RHhmHhoNPiGwbDAIcLBSyZSZVDlO(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2 => keNLcCDnLdffAJmpMtKUPIzOMfUp(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1 => xWfbuUCzAsDHVCZwfWQUIGbiDIQBA(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0 => MgizucUGFVHTInHyRVaNuEgtbBlgA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MgizucUGFVHTInHyRVaNuEgtbBlgA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xWfbuUCzAsDHVCZwfWQUIGbiDIQBA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int keNLcCDnLdffAJmpMtKUPIzOMfUp(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RHhmHhoNPiGwbDAIcLBSyZSZVDlO(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int OuWBUweXQxClDdoaCjyTnRUJSGeQb(int P_0, out urijYWHRYDjHpUIBTAkzPvMbdjsX P_1)
	{
		P_1 = default(urijYWHRYDjHpUIBTAkzPvMbdjsX);
		int result;
		fixed (urijYWHRYDjHpUIBTAkzPvMbdjsX* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = DmZgYlPXSodijEuZkMMxKcSZWRDDA(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int DmZgYlPXSodijEuZkMMxKcSZWRDDA(int P_0, void* P_1)
	{
		if (jltqidpcseDngtzbGSRBkcseLdeY.ViwoQVBqNLSHojKtWXDcHnONWejG && jltqidpcseDngtzbGSRBkcseLdeY.QgITUziuJMABpwIsqnYDteYIlETC != null)
		{
			return jltqidpcseDngtzbGSRBkcseLdeY.QgITUziuJMABpwIsqnYDteYIlETC(P_0, P_1);
		}
		return jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA switch
		{
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_4 => eBqRYrIPERfVYTNnuiQzpmhCtBOo(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3 => PqRhvUKdrCPUdbGRrfWCJtsXHLKn(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2 => MrrSWRcRBPqBpBOnBimozGbNJuWQ(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1 => NPonKBBXanNHyGBXMOrFaSCVYhi(P_0, P_1), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0 => ZsvcxJnGYpoDMHwtXJvkPKPxOkUR(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZsvcxJnGYpoDMHwtXJvkPKPxOkUR(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NPonKBBXanNHyGBXMOrFaSCVYhi(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MrrSWRcRBPqBpBOnBimozGbNJuWQ(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int PqRhvUKdrCPUdbGRrfWCJtsXHLKn(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int eBqRYrIPERfVYTNnuiQzpmhCtBOo(int P_0, void* P_1);

	public unsafe static int GJhdpYKkmotBwTTaGlrcuShSpHNU(int P_0, KFiOsXgXzCqGOJdSZfosebVofTizA P_1, out pLDfuOLDVkQentqphmwptMRCAfor P_2)
	{
		P_2 = default(pLDfuOLDVkQentqphmwptMRCAfor);
		int result;
		fixed (pLDfuOLDVkQentqphmwptMRCAfor* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = DemVteXeDGGptkEHWkmpNDuJtnGcA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int DemVteXeDGGptkEHWkmpNDuJtnGcA(int P_0, int P_1, void* P_2)
	{
		return jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA switch
		{
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_4 => AQpFARnFjAeDKsVfAxGFubNVOQeX(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3 => nPwrtpJqIXTYILfXopdZujrCoHQo(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2 => ReWXUTATpLaQtXIONKfpWsIPQlZQ(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1 => jdEiWgGRcJxbqPIpaRiyswwTTPZt(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0 => NqnveAsSpFAqfiPiyMFxswvMxFKR(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NqnveAsSpFAqfiPiyMFxswvMxFKR(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jdEiWgGRcJxbqPIpaRiyswwTTPZt(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ReWXUTATpLaQtXIONKfpWsIPQlZQ(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nPwrtpJqIXTYILfXopdZujrCoHQo(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AQpFARnFjAeDKsVfAxGFubNVOQeX(int P_0, int P_1, void* P_2);

	public unsafe static int QinWJjBjsTNGHmSqlLlzBqLvBPpd(int P_0, zYQVvPiWYONesdPOZOuzktswQjTp P_1, out ohADXpQoiCdVtyMfrQDOghTkhjZp P_2)
	{
		P_2 = default(ohADXpQoiCdVtyMfrQDOghTkhjZp);
		int result;
		fixed (ohADXpQoiCdVtyMfrQDOghTkhjZp* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = OomSxDyfwGoscsMFYykHpytmLMrh(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int OomSxDyfwGoscsMFYykHpytmLMrh(int P_0, int P_1, void* P_2)
	{
		return jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA switch
		{
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3 => bwNHvFHhzEJbGkPpNBPmQZBIEzgD(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2 => vJzkoYshDJrmAuaUbXmTMlhnYTew(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1 => MehrXrVjrbWyNLaHfYHHiRNOhwRD(P_0, P_1, P_2), 
			vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0 => FaWKRsOIxcGmildnuappZgJfbgtaA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int FaWKRsOIxcGmildnuappZgJfbgtaA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MehrXrVjrbWyNLaHfYHHiRNOhwRD(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vJzkoYshDJrmAuaUbXmTMlhnYTew(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bwNHvFHhzEJbGkPpNBPmQZBIEzgD(int P_0, int P_1, void* P_2);

	public static void XUGuXnMdRZpiyFIaMEiGOHmjKxnH(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0)
	{
		lEvBGyjVYpehraunAYZCOMiyGkPj(P_0);
	}

	private static void lEvBGyjVYpehraunAYZCOMiyGkPj(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0)
	{
		switch (jltqidpcseDngtzbGSRBkcseLdeY.BMtbPxEmstqRrlNtJAiRHdmhNphqA)
		{
		case vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3:
			nrCaUcgRNNVyynJizTSKKCIOuQeTA(P_0);
			break;
		case vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2:
			YFRWRydonHeFaodnXZVjotnSGDcT(P_0);
			break;
		case vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1:
			nqcmmvsfYepkjotmtlPrTPibDKRM(P_0);
			break;
		case vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0:
			dwMCKLQoteQQeJmagnUHImFFMVds(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void dwMCKLQoteQQeJmagnUHImFFMVds(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void nqcmmvsfYepkjotmtlPrTPibDKRM(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void YFRWRydonHeFaodnXZVjotnSGDcT(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void nrCaUcgRNNVyynJizTSKKCIOuQeTA(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0);
}
