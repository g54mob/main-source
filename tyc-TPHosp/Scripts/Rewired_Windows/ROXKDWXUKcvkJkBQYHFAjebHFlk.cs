using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal class ROXKDWXUKcvkJkBQYHFAjebHFlk
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int XNzLgKopLzfsfDJYTFAmCNjsIyF(int arg0, void* arg1);

	private static bool ppdtHZKdboUwjFhdXonCvrAgdUuB;

	private static RLPLEmaTbAdCzEBENlKjSljwIxd oWzkWUcogRPnLngjjhqEBJvdzEqs;

	private static string CktfGAVNpkKuOIzHPWSnvmQkqQg;

	private static IntPtr JjylKesmivtnHFqKviGaKiwJnvpF;

	private static XNzLgKopLzfsfDJYTFAmCNjsIyF wNaYEMMnZpOWhJZFIdVkHShqQTQ;

	private static ANInovfBkTqpKTBiXBwqFKXAGniM rvfekrIHRGVjtWxGJOUjRqzoHaq = default(ANInovfBkTqpKTBiXBwqFKXAGniM);

	public static bool supportsGetStateEx => ppdtHZKdboUwjFhdXonCvrAgdUuB;

	public static RLPLEmaTbAdCzEBENlKjSljwIxd version
	{
		get
		{
			return oWzkWUcogRPnLngjjhqEBJvdzEqs;
		}
		set
		{
			oWzkWUcogRPnLngjjhqEBJvdzEqs = value;
		}
	}

	public static string xInputLibraryName => CktfGAVNpkKuOIzHPWSnvmQkqQg;

	public static XNzLgKopLzfsfDJYTFAmCNjsIyF getStateExDelegate => wNaYEMMnZpOWhJZFIdVkHShqQTQ;

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VOjjusNrcOFpInWfTPcGoxtmguC(int P_0, void* P_1);

	private unsafe static int hiJVVoHEupVIhOYAJdatYCKKkTY(int P_0, void* P_1)
	{
		return VOjjusNrcOFpInWfTPcGoxtmguC(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LYKvJlMLCOxPbhRDEIJSGcIbrQvm(int P_0, void* P_1);

	private unsafe static int tHlGtpfvUibAwhFqVMCuWuNhJPf(int P_0, void* P_1)
	{
		return LYKvJlMLCOxPbhRDEIJSGcIbrQvm(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qJAlvXkzJuUOnztHwMfuHNIlcoDi(int P_0, void* P_1);

	private unsafe static int mIRgPaMIjNhqQCMEJTghyiqucyMF(int P_0, void* P_1)
	{
		return qJAlvXkzJuUOnztHwMfuHNIlcoDi(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VoNPxGVhhULjYpQvsdWhzcXAFzR(int P_0, void* P_1);

	private unsafe static int bybXhxutDINvUarwzCBFSbnseDA(int P_0, void* P_1)
	{
		return VoNPxGVhhULjYpQvsdWhzcXAFzR(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZIwNvlEQIDZIWDoRyePqKUPxRAeN(int P_0, void* P_1);

	private unsafe static int YjChoAgGmTwXbGyCixSwcAmpWTG(int P_0, void* P_1)
	{
		return ZIwNvlEQIDZIWDoRyePqKUPxRAeN(P_0, P_1);
	}

	public static bool BFvKkxFvqMhQoGUuUjHmPRhFkAG(out RLPLEmaTbAdCzEBENlKjSljwIxd P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = RLPLEmaTbAdCzEBENlKjSljwIxd.XzhcXffXatYTRpTiRyDKgAvaprhV;
		ppdtHZKdboUwjFhdXonCvrAgdUuB = false;
		wNaYEMMnZpOWhJZFIdVkHShqQTQ = null;
		if (DRReSLVbXvWSufJrviLjNbBhunB())
		{
			oWzkWUcogRPnLngjjhqEBJvdzEqs = RLPLEmaTbAdCzEBENlKjSljwIxd.FyIWvzDdxecpozmsDSlrLnqhsxU;
			CktfGAVNpkKuOIzHPWSnvmQkqQg = "Xinput1_4.dll";
		}
		else if (bbWTAFyuaiQNoPieehNednooeeW())
		{
			oWzkWUcogRPnLngjjhqEBJvdzEqs = RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH;
			CktfGAVNpkKuOIzHPWSnvmQkqQg = "Xinput1_3.dll";
		}
		else if (tQtWqipXGXmhIwZagmTErfothpP())
		{
			oWzkWUcogRPnLngjjhqEBJvdzEqs = RLPLEmaTbAdCzEBENlKjSljwIxd.ReoXpcQzlGkpkWOlcwmvnLUyqlX;
			CktfGAVNpkKuOIzHPWSnvmQkqQg = "Xinput1_2.dll";
		}
		else if (gvYxhlNPvuuejQJznwLxvxQJize())
		{
			oWzkWUcogRPnLngjjhqEBJvdzEqs = RLPLEmaTbAdCzEBENlKjSljwIxd.JclxEyaijeZskoJBbZyxGQnMKiN;
			CktfGAVNpkKuOIzHPWSnvmQkqQg = "Xinput1_1.dll";
		}
		else
		{
			if (!BoWlGipIyvbvDuyUcHbAhjuTBkuJ())
			{
				P_2 = 1;
				return false;
			}
			oWzkWUcogRPnLngjjhqEBJvdzEqs = RLPLEmaTbAdCzEBENlKjSljwIxd.oCjfgUPFSGHKBCDkwxpIffBtlsP;
			CktfGAVNpkKuOIzHPWSnvmQkqQg = "Xinput9_1_0.dll";
		}
		P_1 = CktfGAVNpkKuOIzHPWSnvmQkqQg;
		P_0 = oWzkWUcogRPnLngjjhqEBJvdzEqs;
		if (ppdtHZKdboUwjFhdXonCvrAgdUuB && !QHazxbGdbkMbkzMEAXCEVGKCDOI())
		{
			ppdtHZKdboUwjFhdXonCvrAgdUuB = false;
		}
		if (!jmfaYfbczmJdEIuNcsOSvgdvRIZW())
		{
			lwRVDJGvRJeHBSOcsHqfbHazJCIy();
			return false;
		}
		return true;
	}

	private unsafe static bool DRReSLVbXvWSufJrviLjNbBhunB()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ANInovfBkTqpKTBiXBwqFKXAGniM, IntPtr>(ref rvfekrIHRGVjtWxGJOUjRqzoHaq))
			{
				YjChoAgGmTwXbGyCixSwcAmpWTG(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool bbWTAFyuaiQNoPieehNednooeeW()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ANInovfBkTqpKTBiXBwqFKXAGniM, IntPtr>(ref rvfekrIHRGVjtWxGJOUjRqzoHaq))
			{
				bybXhxutDINvUarwzCBFSbnseDA(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool tQtWqipXGXmhIwZagmTErfothpP()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ANInovfBkTqpKTBiXBwqFKXAGniM, IntPtr>(ref rvfekrIHRGVjtWxGJOUjRqzoHaq))
			{
				mIRgPaMIjNhqQCMEJTghyiqucyMF(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool gvYxhlNPvuuejQJznwLxvxQJize()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ANInovfBkTqpKTBiXBwqFKXAGniM, IntPtr>(ref rvfekrIHRGVjtWxGJOUjRqzoHaq))
			{
				tHlGtpfvUibAwhFqVMCuWuNhJPf(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool BoWlGipIyvbvDuyUcHbAhjuTBkuJ()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ANInovfBkTqpKTBiXBwqFKXAGniM, IntPtr>(ref rvfekrIHRGVjtWxGJOUjRqzoHaq))
			{
				hiJVVoHEupVIhOYAJdatYCKKkTY(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool QHazxbGdbkMbkzMEAXCEVGKCDOI()
	{
		if (!ppdtHZKdboUwjFhdXonCvrAgdUuB)
		{
			return false;
		}
		return false;
	}

	private static bool jmfaYfbczmJdEIuNcsOSvgdvRIZW()
	{
		try
		{
			knlslTnqsPKELXkpCvqaYPLNMCJ knlslTnqsPKELXkpCvqaYPLNMCJ2 = new knlslTnqsPKELXkpCvqaYPLNMCJ();
			_ = knlslTnqsPKELXkpCvqaYPLNMCJ2.IsConnected;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void lwRVDJGvRJeHBSOcsHqfbHazJCIy()
	{
		if (ppdtHZKdboUwjFhdXonCvrAgdUuB)
		{
			wNaYEMMnZpOWhJZFIdVkHShqQTQ = null;
		}
	}
}
