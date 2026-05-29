using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal class DbBzCsDOVGLEomDEwbzsHlJbmLN
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int LKYrEsRQNvmhumcKFdBTGdTjKKy(int arg0, void* arg1);

	private static bool pczRyhMAzIgWIZUflzPuRAgCHFHe;

	private static FZLWxQmQzwLaQGKEhOiRyzHAEuI ylpCdwmVefANuHzvLOAgmfZTQDRt;

	private static string GadfleELdAfQtDMNHdeTPFsPCVTk;

	private static IntPtr XWuwjAsqkBiPqBTALSkKUbAbHkOE;

	private static LKYrEsRQNvmhumcKFdBTGdTjKKy mfXBfaUAxbfeliBLwnDtZfyOGHmr;

	private static ObUyRDnZkprNrHfwzvWOcaficyNA tJtZOIAELkHpGWjzfLqitoIKdCB = default(ObUyRDnZkprNrHfwzvWOcaficyNA);

	public static bool supportsGetStateEx
	{
		get
		{
			return pczRyhMAzIgWIZUflzPuRAgCHFHe;
		}
	}

	public static FZLWxQmQzwLaQGKEhOiRyzHAEuI version
	{
		get
		{
			return ylpCdwmVefANuHzvLOAgmfZTQDRt;
		}
		set
		{
			ylpCdwmVefANuHzvLOAgmfZTQDRt = value;
		}
	}

	public static string xInputLibraryName
	{
		get
		{
			return GadfleELdAfQtDMNHdeTPFsPCVTk;
		}
	}

	public static LKYrEsRQNvmhumcKFdBTGdTjKKy getStateExDelegate
	{
		get
		{
			return mfXBfaUAxbfeliBLwnDtZfyOGHmr;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XdneLQiNuazLpKnbbwWwoMJCzftK(int P_0, void* P_1);

	private unsafe static int tuHagCBguRbPYYGSbjJTqsmcEtj(int P_0, void* P_1)
	{
		return XdneLQiNuazLpKnbbwWwoMJCzftK(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JkMMcBKoEaMbKdvJuSjqCgmJBVWA(int P_0, void* P_1);

	private unsafe static int hVfvzXpfIKHhRxcaveIUoDhLGOM(int P_0, void* P_1)
	{
		return JkMMcBKoEaMbKdvJuSjqCgmJBVWA(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int eXMwStocJWwmChqBOAPYFfeRkdok(int P_0, void* P_1);

	private unsafe static int cuDTEHAbWpWhSWQFvAFsCIDKffE(int P_0, void* P_1)
	{
		return eXMwStocJWwmChqBOAPYFfeRkdok(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HATyosLFhwhqtvNdOBbVPjpuCfy(int P_0, void* P_1);

	private unsafe static int vkzqmNyiDevzpqNsZuhxyjNQYIv(int P_0, void* P_1)
	{
		return HATyosLFhwhqtvNdOBbVPjpuCfy(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VWsYYFChKlLktZyPEtdAgCzVYTZ(int P_0, void* P_1);

	private unsafe static int OYChPyHgixtxYESGORcEATOZAAbk(int P_0, void* P_1)
	{
		return VWsYYFChKlLktZyPEtdAgCzVYTZ(P_0, P_1);
	}

	public static bool XvxBvKVGveXRrGWIkrDzfJlxpVl(out FZLWxQmQzwLaQGKEhOiRyzHAEuI P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = FZLWxQmQzwLaQGKEhOiRyzHAEuI.PkbJcFPqmFczuJhwlfomqbZGagG;
		pczRyhMAzIgWIZUflzPuRAgCHFHe = false;
		mfXBfaUAxbfeliBLwnDtZfyOGHmr = null;
		if (NgHNjsXXnJcRbjGXZUxtxENFzFS())
		{
			ylpCdwmVefANuHzvLOAgmfZTQDRt = FZLWxQmQzwLaQGKEhOiRyzHAEuI.BApvHLbvQpDRhnmxDXPivKPTclR;
			GadfleELdAfQtDMNHdeTPFsPCVTk = "Xinput1_4.dll";
		}
		else if (hOQiJrmraKiVXXemONySBMwOvFp())
		{
			ylpCdwmVefANuHzvLOAgmfZTQDRt = FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA;
			GadfleELdAfQtDMNHdeTPFsPCVTk = "Xinput1_3.dll";
		}
		else if (lDbtPUnwIlPtteEmACImNUMJdaw())
		{
			ylpCdwmVefANuHzvLOAgmfZTQDRt = FZLWxQmQzwLaQGKEhOiRyzHAEuI.DQcMQQIxjuUDBIKbYEYZgJoKsikO;
			GadfleELdAfQtDMNHdeTPFsPCVTk = "Xinput1_2.dll";
		}
		else if (shKOMVHptOFOIfYdTYlNFRgxbiPe())
		{
			ylpCdwmVefANuHzvLOAgmfZTQDRt = FZLWxQmQzwLaQGKEhOiRyzHAEuI.JpvQjSgAlMLETwaFXaUNdqPoNfcg;
			GadfleELdAfQtDMNHdeTPFsPCVTk = "Xinput1_1.dll";
		}
		else
		{
			if (!ZzQOIMnstLLcJoOOYHkdVAblbNG())
			{
				P_2 = 1;
				return false;
			}
			ylpCdwmVefANuHzvLOAgmfZTQDRt = FZLWxQmQzwLaQGKEhOiRyzHAEuI.gNtIykZUkcaeUGgJKNstXxJHfap;
			GadfleELdAfQtDMNHdeTPFsPCVTk = "Xinput9_1_0.dll";
		}
		P_1 = GadfleELdAfQtDMNHdeTPFsPCVTk;
		P_0 = ylpCdwmVefANuHzvLOAgmfZTQDRt;
		if (pczRyhMAzIgWIZUflzPuRAgCHFHe && !GxcBUHKTpSFeJzWAgFzcdIgwEYz())
		{
			pczRyhMAzIgWIZUflzPuRAgCHFHe = false;
		}
		if (!hXpHtBuijEDJvGwJAKyobUHfOXu())
		{
			rHTnynWrPbsjkOsiGUEBtmUNgDv();
			return false;
		}
		return true;
	}

	private unsafe static bool NgHNjsXXnJcRbjGXZUxtxENFzFS()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ObUyRDnZkprNrHfwzvWOcaficyNA, IntPtr>(ref tJtZOIAELkHpGWjzfLqitoIKdCB))
			{
				OYChPyHgixtxYESGORcEATOZAAbk(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool hOQiJrmraKiVXXemONySBMwOvFp()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ObUyRDnZkprNrHfwzvWOcaficyNA, IntPtr>(ref tJtZOIAELkHpGWjzfLqitoIKdCB))
			{
				vkzqmNyiDevzpqNsZuhxyjNQYIv(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool lDbtPUnwIlPtteEmACImNUMJdaw()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ObUyRDnZkprNrHfwzvWOcaficyNA, IntPtr>(ref tJtZOIAELkHpGWjzfLqitoIKdCB))
			{
				cuDTEHAbWpWhSWQFvAFsCIDKffE(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool shKOMVHptOFOIfYdTYlNFRgxbiPe()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ObUyRDnZkprNrHfwzvWOcaficyNA, IntPtr>(ref tJtZOIAELkHpGWjzfLqitoIKdCB))
			{
				hVfvzXpfIKHhRxcaveIUoDhLGOM(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool ZzQOIMnstLLcJoOOYHkdVAblbNG()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<ObUyRDnZkprNrHfwzvWOcaficyNA, IntPtr>(ref tJtZOIAELkHpGWjzfLqitoIKdCB))
			{
				tuHagCBguRbPYYGSbjJTqsmcEtj(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool GxcBUHKTpSFeJzWAgFzcdIgwEYz()
	{
		if (!pczRyhMAzIgWIZUflzPuRAgCHFHe)
		{
			return false;
		}
		return false;
	}

	private static bool hXpHtBuijEDJvGwJAKyobUHfOXu()
	{
		try
		{
			aCvDNJpOutIyvBpeyJROsQvlGXr aCvDNJpOutIyvBpeyJROsQvlGXr2 = new aCvDNJpOutIyvBpeyJROsQvlGXr();
			bool isConnected = aCvDNJpOutIyvBpeyJROsQvlGXr2.IsConnected;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void rHTnynWrPbsjkOsiGUEBtmUNgDv()
	{
		if (pczRyhMAzIgWIZUflzPuRAgCHFHe)
		{
			mfXBfaUAxbfeliBLwnDtZfyOGHmr = null;
		}
	}
}
