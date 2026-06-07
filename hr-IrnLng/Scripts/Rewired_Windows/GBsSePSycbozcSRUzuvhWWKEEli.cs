using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal class GBsSePSycbozcSRUzuvhWWKEEli
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int riSIqzAtzKExaQhcvmmiJHwuvGe(int arg0, void* arg1);

	private static bool abUpqUTJynwOChzkeDgdAjFtEFo;

	private static STemBjjrVJIdAePWymtErDMfxOd vMEboLrqAQYtiDUzWHKlexKsQIq;

	private static string DSKukRSXFvaZhkQXsitUIlvjGBg;

	private static IntPtr OrBwHlvlIcjhwvyYUeULFRLKbrf;

	private static riSIqzAtzKExaQhcvmmiJHwuvGe rKwZoRNeJSRArlDZtuPkyebdDWVF;

	private static RurWwwaiAKvkjxYcgOjFhSgRbOg glKgCdiZdPHLScRbcawpesJnIPuS = default(RurWwwaiAKvkjxYcgOjFhSgRbOg);

	public static bool supportsGetStateEx => abUpqUTJynwOChzkeDgdAjFtEFo;

	public static STemBjjrVJIdAePWymtErDMfxOd version
	{
		get
		{
			return vMEboLrqAQYtiDUzWHKlexKsQIq;
		}
		set
		{
			vMEboLrqAQYtiDUzWHKlexKsQIq = value;
		}
	}

	public static string xInputLibraryName => DSKukRSXFvaZhkQXsitUIlvjGBg;

	public static riSIqzAtzKExaQhcvmmiJHwuvGe getStateExDelegate => rKwZoRNeJSRArlDZtuPkyebdDWVF;

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MxCCGxScOHMhfXqnmpArNJWvYuI(int P_0, void* P_1);

	private unsafe static int oUqnbfSuWeqLEcTKueHClefVicQB(int P_0, void* P_1)
	{
		return MxCCGxScOHMhfXqnmpArNJWvYuI(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OfnnUaLJiJRYYNBqnfAzJnOoIXv(int P_0, void* P_1);

	private unsafe static int owWxqgsmDvUtPHLesQqJjPagEFz(int P_0, void* P_1)
	{
		return OfnnUaLJiJRYYNBqnfAzJnOoIXv(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hQtPEOpVjbEyMJvDXVTJyjjwwOZ(int P_0, void* P_1);

	private unsafe static int tTaeOhFmFIjgrcgIqNYAJHTjNyOF(int P_0, void* P_1)
	{
		return hQtPEOpVjbEyMJvDXVTJyjjwwOZ(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WhenvFSoLBXFbXYdRPBUYsoNsNH(int P_0, void* P_1);

	private unsafe static int uKWNfqdonFiTfEUwAdwwUfAhQBOj(int P_0, void* P_1)
	{
		return WhenvFSoLBXFbXYdRPBUYsoNsNH(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YxBHhcZtiSUnfdoPJnUBrSocGMi(int P_0, void* P_1);

	private unsafe static int XzzOmNteCWiDUwqQDGkDJvVwjTE(int P_0, void* P_1)
	{
		return YxBHhcZtiSUnfdoPJnUBrSocGMi(P_0, P_1);
	}

	public static bool QaUcwhGLRRBnjcaMjVHoGuyQzyU(out STemBjjrVJIdAePWymtErDMfxOd P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = STemBjjrVJIdAePWymtErDMfxOd.CEUjyvGIbsPgNjwVqrjvtItjjrS;
		abUpqUTJynwOChzkeDgdAjFtEFo = false;
		rKwZoRNeJSRArlDZtuPkyebdDWVF = null;
		if (AHyESZjORavWnTBZUsGimqMuocbh())
		{
			vMEboLrqAQYtiDUzWHKlexKsQIq = STemBjjrVJIdAePWymtErDMfxOd.CilKymGRVvllPTBgsWZIshRmoxS;
			DSKukRSXFvaZhkQXsitUIlvjGBg = "Xinput1_4.dll";
		}
		else if (suxyvKleMvnGLdjiHoZVIVFxokG())
		{
			vMEboLrqAQYtiDUzWHKlexKsQIq = STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb;
			DSKukRSXFvaZhkQXsitUIlvjGBg = "Xinput1_3.dll";
		}
		else if (mDWUwnweRQnhhWwsNWwlUJOudzJ())
		{
			vMEboLrqAQYtiDUzWHKlexKsQIq = STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD;
			DSKukRSXFvaZhkQXsitUIlvjGBg = "Xinput1_2.dll";
		}
		else if (dAlVdgKTRzsKSkrtIfNIGfrIlbq())
		{
			vMEboLrqAQYtiDUzWHKlexKsQIq = STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT;
			DSKukRSXFvaZhkQXsitUIlvjGBg = "Xinput1_1.dll";
		}
		else
		{
			if (!WebFTdeNSemdmIbEBiBncONEBimw())
			{
				P_2 = 1;
				return false;
			}
			vMEboLrqAQYtiDUzWHKlexKsQIq = STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf;
			DSKukRSXFvaZhkQXsitUIlvjGBg = "Xinput9_1_0.dll";
		}
		P_1 = DSKukRSXFvaZhkQXsitUIlvjGBg;
		P_0 = vMEboLrqAQYtiDUzWHKlexKsQIq;
		if (abUpqUTJynwOChzkeDgdAjFtEFo && !TDNdXiHBJnoUTERGDnzlBothBXDM())
		{
			abUpqUTJynwOChzkeDgdAjFtEFo = false;
		}
		if (!gIdwgJtRpelzLADPjuhEHQdMCXH())
		{
			sCgtROBexWTssqnqFGbMqaFuiIS();
			return false;
		}
		return true;
	}

	private unsafe static bool AHyESZjORavWnTBZUsGimqMuocbh()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<RurWwwaiAKvkjxYcgOjFhSgRbOg, IntPtr>(ref glKgCdiZdPHLScRbcawpesJnIPuS))
			{
				XzzOmNteCWiDUwqQDGkDJvVwjTE(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool suxyvKleMvnGLdjiHoZVIVFxokG()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<RurWwwaiAKvkjxYcgOjFhSgRbOg, IntPtr>(ref glKgCdiZdPHLScRbcawpesJnIPuS))
			{
				uKWNfqdonFiTfEUwAdwwUfAhQBOj(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool mDWUwnweRQnhhWwsNWwlUJOudzJ()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<RurWwwaiAKvkjxYcgOjFhSgRbOg, IntPtr>(ref glKgCdiZdPHLScRbcawpesJnIPuS))
			{
				tTaeOhFmFIjgrcgIqNYAJHTjNyOF(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool dAlVdgKTRzsKSkrtIfNIGfrIlbq()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<RurWwwaiAKvkjxYcgOjFhSgRbOg, IntPtr>(ref glKgCdiZdPHLScRbcawpesJnIPuS))
			{
				owWxqgsmDvUtPHLesQqJjPagEFz(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool WebFTdeNSemdmIbEBiBncONEBimw()
	{
		try
		{
			fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<RurWwwaiAKvkjxYcgOjFhSgRbOg, IntPtr>(ref glKgCdiZdPHLScRbcawpesJnIPuS))
			{
				oUqnbfSuWeqLEcTKueHClefVicQB(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool TDNdXiHBJnoUTERGDnzlBothBXDM()
	{
		if (!abUpqUTJynwOChzkeDgdAjFtEFo)
		{
			return false;
		}
		return false;
	}

	private static bool gIdwgJtRpelzLADPjuhEHQdMCXH()
	{
		try
		{
			biGdEyfgIQaWprfghoTBDxkfEGEU biGdEyfgIQaWprfghoTBDxkfEGEU2 = new biGdEyfgIQaWprfghoTBDxkfEGEU();
			_ = biGdEyfgIQaWprfghoTBDxkfEGEU2.IsConnected;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void sCgtROBexWTssqnqFGbMqaFuiIS()
	{
		if (abUpqUTJynwOChzkeDgdAjFtEFo)
		{
			rKwZoRNeJSRArlDZtuPkyebdDWVF = null;
		}
	}
}
