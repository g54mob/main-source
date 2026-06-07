using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class JEJaFVwkWOcccKykEkiJKkUxkCKxA
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class bpYoGSeohdBvKAkrFxJxNEzmEhOCA
	{
		public int QxhBFutllFnZvQngQjOoqAeYvOKe;

		public int jEHofAzAkHHNlgTKLTSdrSLApspP;

		public int LfiBcqyHmHxHbcksHwyaOAcaJnPl;

		public int KTnCmbbxeNfHKGALakOIiLagZzbNE;

		public int YxwpBqlYLswmUEaVgBQmosioCUVe;

		public byte eDIadYxvtHZoipZiFsDWxkXHXJfJ;

		public byte oRjsXUuAeOQOUAgcojKamJrxTpGn;

		public byte zHrydfgkDZOyZXIyXENdlhkLbND;

		public byte jSovsgSFXWFTyqRfSQEvEuFjoIqV;

		public byte waLjUobLBjxsGRxILEytLAsNKYIgb;

		public byte WYjGCEAGcoKalBDuygewRGkTSLdi;

		public byte nmVnkyZfVRZRClLFqESMkAArgSjCA;

		public byte LRXvSFgQuOdFQMJdiELGEfwasjDt;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string TjursqehYVyTnxXxllqnbfvlAlXe;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct KMjHAWrQOyALMqPPJEeMepqNZdgC
	{
		public int WkzEIPlcZDVLURVvxFGZibfYtzKo;

		public int oFbiCeOrBWNwPlFkXMrlFCujbllcA;

		public int YXrtvmJldZAXObyXndtcUHQgzCzLA;

		public int rZnEOLQlmCCrHBzUbYHrDUedGDwPA;

		public int yrJCUICeFfqshWnujIgAVcUWlqRp;

		public int GlbRTUTHmfWOcSYjzOKtwICjcWfq;

		public int VqKDRsMETSCDZpEMBaHkkNjxlBOY;

		public int eBcGhaNgnWRygEeUuZNjJRGbPQjV;

		public int rgRNgzJGrsLCMjMrDAquWFdBrphv;

		public int XHVEQefqMvujzeLkdTOgfOTXpMQG;

		public int ItktUskXnNSwJKlmaboNYTkHtAzX;

		public char QPoCZHipJMGVDCcRBaCSpoxkSKXe;

		public char OktCwUdIdKyXQsogBblMhvXlNExz;

		public char pGhKSPBBgNwzQndBOZaRWBoiQgQo;

		public char CFPutYgHqJbKTiImXfGIyNXktMFsA;

		public byte FdsQSbnManrbDqjuwFSJUgZbumfd;

		public byte GtfssczxWYsGtsxmgmdYSBrMlxBk;

		public byte RopzAfSFgkmHJyARGLQzvrTRpoAG;

		public byte fMsfaICacjyUBMsfkLTXKBzGJIXqA;

		public byte LiRxyOLmvgXFicYJrvRBYRHwVWqd;
	}

	internal enum XsKzfxboqaULYkgYNLISlWGrwLXF
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr FKaAmmJbofbKyuGKYHBapetrYFpRA(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool KqTRVpTIWvEnljdVWAXtsLnvKadF(IntPtr hwnd, IntPtr lParam);

	private static IntPtr EiBBsdJiTwHqmUCtjqJHAQyKnVevA = IntPtr.Zero;

	private static List<IntPtr> bRJEEOTUmKrZPjGDkVpzrJnGYiAi;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int FEzzQGMuPhVtGkIZoFSRgBlSoGUv(out SkoZJpTtQUzTxQhTSURXcPHnWzPi P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int lOKgamkOFtEEJKJOANZXKSCvIUQlA(out SkoZJpTtQUzTxQhTSURXcPHnWzPi P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int sSDUEfhbxnIuzkQpcDMMMIfAIobE(ref SkoZJpTtQUzTxQhTSURXcPHnWzPi P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int UzbRFrkAWqotEJtonZKAbNVroyTH(ref SkoZJpTtQUzTxQhTSURXcPHnWzPi P_0);

	public static IntPtr TJDQMdBXYDlRTRbQTzNOJNPOaLXS(HandleRef P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1)
	{
		if (IntPtr.Size == 4)
		{
			return zXXlzABvgfNNIqYzGPWDKdFyDEso(P_0, P_1);
		}
		return nOGdZYmjerQSZXySKEzaPNyjdwcD(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr CcHOlRojVXldFYFssbKCLJdVkkvF();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr zXXlzABvgfNNIqYzGPWDKdFyDEso(HandleRef P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr nOGdZYmjerQSZXySKEzaPNyjdwcD(HandleRef P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1);

	public static IntPtr uCbZWteKxiuFGCiMTFQvFyBKgzHo(HandleRef P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return PiHAlIzAqoTcmPWeVFxACrUkanOd(P_0, P_1, P_2);
		}
		return eUSkMxEoNwBxpnNYcaYnJPWAkDpA(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr ZCqZQytyaBoOIPvGbCWwKnCcoPJd(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr PiHAlIzAqoTcmPWeVFxACrUkanOd(HandleRef P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1, IntPtr P_2);

	public static bool jihemVgAwOlbzuYBsZHCNXUeNBzl(HandleRef P_0, bool P_1)
	{
		return jihemVgAwOlbzuYBsZHCNXUeNBzl(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool jihemVgAwOlbzuYBsZHCNXUeNBzl(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr eUSkMxEoNwBxpnNYcaYnJPWAkDpA(HandleRef P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr KEdRdjYbfzDgmzXyUeeZOTgKfIRD(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr fEbPKUlEZbtLLXTYYhZDdzRYyZYi(string P_0);

	public static IntPtr TJDQMdBXYDlRTRbQTzNOJNPOaLXS(IntPtr P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1)
	{
		if (IntPtr.Size == 4)
		{
			return zXXlzABvgfNNIqYzGPWDKdFyDEso(P_0, P_1);
		}
		return nOGdZYmjerQSZXySKEzaPNyjdwcD(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr zXXlzABvgfNNIqYzGPWDKdFyDEso(IntPtr P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr nOGdZYmjerQSZXySKEzaPNyjdwcD(IntPtr P_0, XsKzfxboqaULYkgYNLISlWGrwLXF P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool YeMoeJrefQilMdoGlusMNFTcHjypA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr LuMAgVUYOAkCNOfeteoTMKUCSohw();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint TTTfeRgYhxZYyZYJAhIRdDoXAcVjA();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool NaFLrnMHAHfZzxndNfEXCgsxGaOEb(IntPtr P_0, IntPtr P_1);

	private static bool wroxoRwqePYBIODnPgINNXewimfl(IntPtr P_0, IntPtr P_1)
	{
		lock (bRJEEOTUmKrZPjGDkVpzrJnGYiAi)
		{
			bRJEEOTUmKrZPjGDkVpzrJnGYiAi.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint ldjgPssVJFWlpyeXWotKCnHNnALb(IntPtr P_0, out uint P_1);

	public static IntPtr vscZBvMucbOyMfqJkbaPPOFWbTRj()
	{
		if (EiBBsdJiTwHqmUCtjqJHAQyKnVevA != IntPtr.Zero)
		{
			return EiBBsdJiTwHqmUCtjqJHAQyKnVevA;
		}
		bRJEEOTUmKrZPjGDkVpzrJnGYiAi = new List<IntPtr>();
		uint num = TTTfeRgYhxZYyZYJAhIRdDoXAcVjA();
		KqTRVpTIWvEnljdVWAXtsLnvKadF kqTRVpTIWvEnljdVWAXtsLnvKadF = wroxoRwqePYBIODnPgINNXewimfl;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate((Delegate)kqTRVpTIWvEnljdVWAXtsLnvKadF);
		NaFLrnMHAHfZzxndNfEXCgsxGaOEb(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(kqTRVpTIWvEnljdVWAXtsLnvKadF);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < bRJEEOTUmKrZPjGDkVpzrJnGYiAi.Count; i++)
		{
			if (YeMoeJrefQilMdoGlusMNFTcHjypA(bRJEEOTUmKrZPjGDkVpzrJnGYiAi[i]))
			{
				ldjgPssVJFWlpyeXWotKCnHNnALb(bRJEEOTUmKrZPjGDkVpzrJnGYiAi[i], out var num2);
				if (num2 == num)
				{
					EiBBsdJiTwHqmUCtjqJHAQyKnVevA = bRJEEOTUmKrZPjGDkVpzrJnGYiAi[i];
					bRJEEOTUmKrZPjGDkVpzrJnGYiAi.Clear();
					return EiBBsdJiTwHqmUCtjqJHAQyKnVevA;
				}
			}
		}
		return LuMAgVUYOAkCNOfeteoTMKUCSohw();
	}
}
