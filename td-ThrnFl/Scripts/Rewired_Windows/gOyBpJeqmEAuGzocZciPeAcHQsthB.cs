using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class gOyBpJeqmEAuGzocZciPeAcHQsthB : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr HiTZaQveKfSfdZGNRhBAKAkBCjzZA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct gWxHzoNctgDbcfJoYzuvqshjZqIjA
	{
		public uint DfqWGlYuCAaGZDJdxMtpBTNWhoeA;

		public IntPtr pCDOaNxOnOkBzOmOzvHchyWnUTVo;

		public int pxuhxAmmpsQgEXDxPZJcLcJmPLWw;

		public int vhDLEaGZRLPHkGqkmBjFJwwaIbkNA;

		public IntPtr KOcGgJqHUzzbwYkEpXqmpasFCqbr;

		public IntPtr XohDzwTeMidCPIHaIiNbJPSbRUskb;

		public IntPtr hCtHcUJvPHrZoaTsHOaYRmFEEoCKA;

		public IntPtr TTPRpFuUWFzbyfldiqpBMiFtbQGo;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string JpkTKBavivkJMBlNewdaQiEhsZse;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string YeIEFoAAkwVVkiKWsauohPLVtLet;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct NUzOggWwUzOnGypOFHUGadMEiAYfA
	{
		public IntPtr vsbDvnnhMpsvkwbOlknvbhtkbkvIA;

		public IntPtr cMzFhPjblAiAapaJcHxgSaEscQwZ;

		public IntPtr FHTLpNUKmDUcBnMHkeDPGAcVdhkF;

		public IntPtr xnpgfppRhgRoNqOdSZahgLuIbItp;

		public int yzDdNTHwWpCdIDxNRlpsFjVFTRHlb;

		public int XIrCJppSaKIrZayBBLvEJUahezar;

		public int ghKlZUmuUQOyFGFCELyVbEkMmHrA;

		public int XtlBdjDQfuelRTuBYyUsGmDFQqrdb;

		public int RXJnNXSUaEFqPPXIIItocFGdpYXE;

		public IntPtr AfjHFBEpWuPYmzjOyJNczObFYhSwA;

		public IntPtr HFUEhpfwzxyQWxcajEUDJjNZzIVb;

		public uint CunteDkuRJOZXPdgGbJliALDrVlC;
	}

	private const int uhujXrVqelussucyBtMASYOUTckT = 20;

	private const int cNWGYNWTpEaLgbvfHDTCFuzZHigwA = 1410;

	private readonly ushort FiMMoDkeYMINOOjUBqldjcxwppEr;

	private readonly string KvnmcvfZHsKaRtUJVqdvVPEJCaLZ;

	private bool coVHBYeKcXpMHHsLnOfLOObdhpWY;

	private IntPtr VwFISPUQnPpgmWZichOXvoAFiVSfA;

	private int sRbwdOfgLketOgiCMCzUhdSWBybS;

	private uint weIKxvPYLMfJfjzLeHCBdoIekMZy;

	private HiTZaQveKfSfdZGNRhBAKAkBCjzZA tDFvKaeVWOKjHDRxsHeOPSAGVYAc;

	private HiTZaQveKfSfdZGNRhBAKAkBCjzZA ufPXWXotecfntHnweZZUNmKWBTsN;

	public IntPtr vjPSWVWejQLUkQTJVQdBNsuoctNjA => VwFISPUQnPpgmWZichOXvoAFiVSfA;

	public uint DcozbPYDseGSfwkoWOXufpYLcFBD => weIKxvPYLMfJfjzLeHCBdoIekMZy;

	public bool FrXDzwYEqqiFDDrCdahgfKxeawMxA
	{
		get
		{
			if (!(VwFISPUQnPpgmWZichOXvoAFiVSfA != IntPtr.Zero))
			{
				return false;
			}
			return KGCYLjWOzOreLaUtgCQKrLRWemjM(VwFISPUQnPpgmWZichOXvoAFiVSfA);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort JiagAlAkgNALMXKovEtXcpPKJVTVA([In] ref gWxHzoNctgDbcfJoYzuvqshjZqIjA P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool xbFVOuSWgbleQRkFiQRxIalkbhHp([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr FLFDZItCwwIhBvcVJckgCJMEZuNDA(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr HDjEYDbZMLqKJjKBGzEkWimfjnJK(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool ZcHxzcbZTsNOHTTZADtjEFFPlALQ(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool KGCYLjWOzOreLaUtgCQKrLRWemjM(IntPtr P_0);

	public void Dispose()
	{
		zvNjXZHuzdAluezAScEvuOdJdvVn(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void UUJYftLzoSXxZnumIvHwYmxIcguh()
	{
		try
		{
			zvNjXZHuzdAluezAScEvuOdJdvVn(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void zvNjXZHuzdAluezAScEvuOdJdvVn(bool P_0)
	{
		if (!coVHBYeKcXpMHHsLnOfLOObdhpWY)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(weIKxvPYLMfJfjzLeHCBdoIekMZy);
			}
			if (VwFISPUQnPpgmWZichOXvoAFiVSfA != IntPtr.Zero)
			{
				ZcHxzcbZTsNOHTTZADtjEFFPlALQ(VwFISPUQnPpgmWZichOXvoAFiVSfA);
				VwFISPUQnPpgmWZichOXvoAFiVSfA = IntPtr.Zero;
			}
			if (FiMMoDkeYMINOOjUBqldjcxwppEr != 0 && !string.IsNullOrEmpty(KvnmcvfZHsKaRtUJVqdvVPEJCaLZ))
			{
				xbFVOuSWgbleQRkFiQRxIalkbhHp(KvnmcvfZHsKaRtUJVqdvVPEJCaLZ, IntPtr.Zero);
			}
			coVHBYeKcXpMHHsLnOfLOObdhpWY = true;
		}
	}

	public gOyBpJeqmEAuGzocZciPeAcHQsthB(string P_0, bool P_1, HiTZaQveKfSfdZGNRhBAKAkBCjzZA P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		weIKxvPYLMfJfjzLeHCBdoIekMZy = ObjectInstanceTracker.Default.Register(this);
		KvnmcvfZHsKaRtUJVqdvVPEJCaLZ = P_0;
		tDFvKaeVWOKjHDRxsHeOPSAGVYAc = WcTnjRICrQbIZrKxLaQMgNYWRnID;
		ufPXWXotecfntHnweZZUNmKWBTsN = P_2;
		sRbwdOfgLketOgiCMCzUhdSWBybS = 0;
		gWxHzoNctgDbcfJoYzuvqshjZqIjA gWxHzoNctgDbcfJoYzuvqshjZqIjA2 = new gWxHzoNctgDbcfJoYzuvqshjZqIjA
		{
			pCDOaNxOnOkBzOmOzvHchyWnUTVo = Marshal.GetFunctionPointerForDelegate(tDFvKaeVWOKjHDRxsHeOPSAGVYAc)
		};
		while (FiMMoDkeYMINOOjUBqldjcxwppEr == 0 && sRbwdOfgLketOgiCMCzUhdSWBybS < 20)
		{
			gWxHzoNctgDbcfJoYzuvqshjZqIjA2.YeIEFoAAkwVVkiKWsauohPLVtLet = P_0;
			FiMMoDkeYMINOOjUBqldjcxwppEr = JiagAlAkgNALMXKovEtXcpPKJVTVA(ref gWxHzoNctgDbcfJoYzuvqshjZqIjA2);
			if (FiMMoDkeYMINOOjUBqldjcxwppEr != 0)
			{
				break;
			}
			sRbwdOfgLketOgiCMCzUhdSWBybS++;
			P_0 = KvnmcvfZHsKaRtUJVqdvVPEJCaLZ + sRbwdOfgLketOgiCMCzUhdSWBybS;
		}
		if (FiMMoDkeYMINOOjUBqldjcxwppEr == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (KvnmcvfZHsKaRtUJVqdvVPEJCaLZ != P_0)
		{
			KvnmcvfZHsKaRtUJVqdvVPEJCaLZ = P_0;
		}
		if (P_1)
		{
			VwFISPUQnPpgmWZichOXvoAFiVSfA = XtvQRhtgelAOncOpTvXhlKVLHXUEb(P_0, new IntPtr((int)weIKxvPYLMfJfjzLeHCBdoIekMZy));
		}
		else
		{
			VwFISPUQnPpgmWZichOXvoAFiVSfA = SIYTznEkIXOhcXdJYcuPvPPyXiMJ(P_0, new IntPtr((int)weIKxvPYLMfJfjzLeHCBdoIekMZy));
		}
	}

	private IntPtr SIYTznEkIXOhcXdJYcuPvPPyXiMJ(string P_0, IntPtr P_1)
	{
		return FLFDZItCwwIhBvcVJckgCJMEZuNDA(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr XtvQRhtgelAOncOpTvXhlKVLHXUEb(string P_0, IntPtr P_1)
	{
		return FLFDZItCwwIhBvcVJckgCJMEZuNDA(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, nLFjDWhFFneDsZFBEEAqYlPBIetI.nCGkEeqgGGUCooXYKrYjjVHwThVU, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(HiTZaQveKfSfdZGNRhBAKAkBCjzZA))]
	private unsafe static IntPtr WcTnjRICrQbIZrKxLaQMgNYWRnID(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return HDjEYDbZMLqKJjKBGzEkWimfjnJK(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			NUzOggWwUzOnGypOFHUGadMEiAYfA* ptr = (NUzOggWwUzOnGypOFHUGadMEiAYfA*)(void*)P_3;
			if (ptr->vsbDvnnhMpsvkwbOlknvbhtkbkvIA != IntPtr.Zero)
			{
				FanHTnvZmXVTOfDHuteqdkMyhpJj.pOkPwnKdGKrxkSOhSkePjphyKevT(P_0, -21, ptr->vsbDvnnhMpsvkwbOlknvbhtkbkvIA);
			}
		}
		else
		{
			instanceId = (uint)FanHTnvZmXVTOfDHuteqdkMyhpJj.uhpcheHHHAMpwgxkuNWWXzmPTPqt(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<gOyBpJeqmEAuGzocZciPeAcHQsthB>(instanceId, out var instance))
		{
			instance.ufPXWXotecfntHnweZZUNmKWBTsN(P_0, P_1, P_2, P_3);
		}
		return HDjEYDbZMLqKJjKBGzEkWimfjnJK(P_0, P_1, P_2, P_3);
	}

	public void TLnIDQiNISnEpwadwMwxQfLxXsyf(HiTZaQveKfSfdZGNRhBAKAkBCjzZA P_0)
	{
		ufPXWXotecfntHnweZZUNmKWBTsN = P_0;
	}
}
