using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class uMzEqmeDovostuZMLbBxECokhAXAA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr WNohiEFfMXnltdigDxvexNuusSAC(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct szVBojcdCwxvUmyFboFQCaNKJIFy
	{
		public uint OhGWExsqFGiLtkxnccXmRzHQSzAl;

		public IntPtr fOYbptQqAKwKANEAFpjdeQapQrLJ;

		public int RbxkHAzReSaQYnofVZMFzdYNqoPR;

		public int CzKRoeECucgpHiEXwXpKmEnTxPeDA;

		public IntPtr wfVRukEKYkhTkKLdMGVJmGvnBZrY;

		public IntPtr izKcQEpDfjHQzchvbNqxSIjRsYRO;

		public IntPtr zRBGqckkvpsmtIEydxaFZbwbNXWo;

		public IntPtr yjnqgIiQPSaixzwxnkvoIsbeYrLB;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string KcrtqmtlFnBoYzlZdyijOoCTDHdCA;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string RdBJSAlKDeIILKotDCGFwQYFtimW;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct lxdcVRGLcCqScjNBTTGxHOQTiHBuA
	{
		public IntPtr JwqOlFMTKsshMgumGCQIbTfrrCpg;

		public IntPtr wfVRukEKYkhTkKLdMGVJmGvnBZrY;

		public IntPtr lvISYTRnSTsnqHeiPhAHaeDbPrEcb;

		public IntPtr FcKabfIDSLNOjZAwpOgRmZDpIDWCA;

		public int MXsYaUzViZofKwfmUpchZImQXUeP;

		public int bmHEGoAmpfCINbNKCKEmLKNtgzvAb;

		public int hKNBoqqlWhZEGDOSGavmrJzzANJX;

		public int HyOGJyEMNRPNbRuUxYTAHdiHKkPbb;

		public int OhGWExsqFGiLtkxnccXmRzHQSzAl;

		public IntPtr AfNcUbatSYgOgMhnQCRkKraxCKOcb;

		public IntPtr iiZPINpNVNtQrdArlCMFSAEnhONR;

		public uint TuUHLzoezWDCsuPpdzEiwSnUDyDb;
	}

	private const int TqCxsDpjNSFlVGBwBPfztdPANvIvA = 20;

	private const int cioLoUQSSwYqfbJvHFnUcoGcfIwI = 1410;

	private readonly ushort ahjftDQpKJZmpQEXNiDrUPCETrON;

	private readonly string FbAcMDswREyjTPHnrRGABgdYCMgX;

	private bool pBaiUFKudoDgkNbiXiazoUmmSsww;

	private IntPtr PBREMafNqcMqdeZBytLCRSIqiRmEb;

	private int iDiGhkivPjmoxgvbCtwvcTlFFvDde;

	private uint uUxrSJplaDEpWOwxloLgtQIVkefV;

	private WNohiEFfMXnltdigDxvexNuusSAC osQKgpYnZmCNuBQNapbdkwlfiFpq;

	private WNohiEFfMXnltdigDxvexNuusSAC fCTebgZjGDULGndYeedsiQQbfJGX;

	public IntPtr sHRdaIqdzdvAIXdHntUyXVYsaYKg => PBREMafNqcMqdeZBytLCRSIqiRmEb;

	public uint ZcApTwLmLQFexjQQMAZpNfMZDCoo => uUxrSJplaDEpWOwxloLgtQIVkefV;

	public bool JbxJaIGfSdhCjEMiklIxHIHSAZcG
	{
		get
		{
			if (!(PBREMafNqcMqdeZBytLCRSIqiRmEb != IntPtr.Zero))
			{
				return false;
			}
			return YeMoeJrefQilMdoGlusMNFTcHjypA(PBREMafNqcMqdeZBytLCRSIqiRmEb);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort uxVLKFRkDrOJHflpojIueduhFwwqA([In] ref szVBojcdCwxvUmyFboFQCaNKJIFy P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool igspvYZFjngrXKKCLBIVIyqooNAZ([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr PMeNIucEjVUPcSgSYEnjhgcsFPODb(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr NOihoLoxqwVghdptMGzKfhOXMsqxA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool hFTupFUbvBBwKZtwkEKBsQqQWggv(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool YeMoeJrefQilMdoGlusMNFTcHjypA(IntPtr P_0);

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!pBaiUFKudoDgkNbiXiazoUmmSsww)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(uUxrSJplaDEpWOwxloLgtQIVkefV);
			}
			if (PBREMafNqcMqdeZBytLCRSIqiRmEb != IntPtr.Zero)
			{
				hFTupFUbvBBwKZtwkEKBsQqQWggv(PBREMafNqcMqdeZBytLCRSIqiRmEb);
				PBREMafNqcMqdeZBytLCRSIqiRmEb = IntPtr.Zero;
			}
			if (ahjftDQpKJZmpQEXNiDrUPCETrON != 0 && !string.IsNullOrEmpty(FbAcMDswREyjTPHnrRGABgdYCMgX))
			{
				igspvYZFjngrXKKCLBIVIyqooNAZ(FbAcMDswREyjTPHnrRGABgdYCMgX, IntPtr.Zero);
			}
			pBaiUFKudoDgkNbiXiazoUmmSsww = true;
		}
	}

	public uMzEqmeDovostuZMLbBxECokhAXAA(string P_0, bool P_1, WNohiEFfMXnltdigDxvexNuusSAC P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		uUxrSJplaDEpWOwxloLgtQIVkefV = ObjectInstanceTracker.Default.Register(this);
		FbAcMDswREyjTPHnrRGABgdYCMgX = P_0;
		osQKgpYnZmCNuBQNapbdkwlfiFpq = LOxqjCRyLTAEXQJuXgGSaEhXwXpR;
		fCTebgZjGDULGndYeedsiQQbfJGX = P_2;
		iDiGhkivPjmoxgvbCtwvcTlFFvDde = 0;
		szVBojcdCwxvUmyFboFQCaNKJIFy szVBojcdCwxvUmyFboFQCaNKJIFy2 = new szVBojcdCwxvUmyFboFQCaNKJIFy
		{
			fOYbptQqAKwKANEAFpjdeQapQrLJ = Marshal.GetFunctionPointerForDelegate((Delegate)osQKgpYnZmCNuBQNapbdkwlfiFpq)
		};
		while (ahjftDQpKJZmpQEXNiDrUPCETrON == 0 && iDiGhkivPjmoxgvbCtwvcTlFFvDde < 20)
		{
			szVBojcdCwxvUmyFboFQCaNKJIFy2.RdBJSAlKDeIILKotDCGFwQYFtimW = P_0;
			ahjftDQpKJZmpQEXNiDrUPCETrON = uxVLKFRkDrOJHflpojIueduhFwwqA(ref szVBojcdCwxvUmyFboFQCaNKJIFy2);
			if (ahjftDQpKJZmpQEXNiDrUPCETrON != 0)
			{
				break;
			}
			iDiGhkivPjmoxgvbCtwvcTlFFvDde++;
			P_0 = FbAcMDswREyjTPHnrRGABgdYCMgX + iDiGhkivPjmoxgvbCtwvcTlFFvDde;
		}
		if (ahjftDQpKJZmpQEXNiDrUPCETrON == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (FbAcMDswREyjTPHnrRGABgdYCMgX != P_0)
		{
			FbAcMDswREyjTPHnrRGABgdYCMgX = P_0;
		}
		if (P_1)
		{
			PBREMafNqcMqdeZBytLCRSIqiRmEb = ZHuYekyayZuQzUlSVcKTapikzOoU(P_0, new IntPtr((int)uUxrSJplaDEpWOwxloLgtQIVkefV));
		}
		else
		{
			PBREMafNqcMqdeZBytLCRSIqiRmEb = PnEcxiEBdpzmymhpGbPvjbOefiTw(P_0, new IntPtr((int)uUxrSJplaDEpWOwxloLgtQIVkefV));
		}
	}

	private IntPtr PnEcxiEBdpzmymhpGbPvjbOefiTw(string P_0, IntPtr P_1)
	{
		return PMeNIucEjVUPcSgSYEnjhgcsFPODb(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr ZHuYekyayZuQzUlSVcKTapikzOoU(string P_0, IntPtr P_1)
	{
		return PMeNIucEjVUPcSgSYEnjhgcsFPODb(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.maVdzuAxwrPWfIGPjOjQkehoTafh, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(WNohiEFfMXnltdigDxvexNuusSAC))]
	private unsafe static IntPtr LOxqjCRyLTAEXQJuXgGSaEhXwXpR(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return NOihoLoxqwVghdptMGzKfhOXMsqxA(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			lxdcVRGLcCqScjNBTTGxHOQTiHBuA* ptr = (lxdcVRGLcCqScjNBTTGxHOQTiHBuA*)(void*)P_3;
			if (ptr->JwqOlFMTKsshMgumGCQIbTfrrCpg != IntPtr.Zero)
			{
				VBqfSSvUBwCRtzUpeUWIfCWGfXliA.uCbZWteKxiuFGCiMTFQvFyBKgzHo(P_0, -21, ptr->JwqOlFMTKsshMgumGCQIbTfrrCpg);
			}
		}
		else
		{
			instanceId = (uint)VBqfSSvUBwCRtzUpeUWIfCWGfXliA.TJDQMdBXYDlRTRbQTzNOJNPOaLXS(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<uMzEqmeDovostuZMLbBxECokhAXAA>(instanceId, out var instance))
		{
			instance.fCTebgZjGDULGndYeedsiQQbfJGX(P_0, P_1, P_2, P_3);
		}
		return NOihoLoxqwVghdptMGzKfhOXMsqxA(P_0, P_1, P_2, P_3);
	}

	public void vFhsiFJZmNEAWETlAUZGPGTyJhOA(WNohiEFfMXnltdigDxvexNuusSAC P_0)
	{
		fCTebgZjGDULGndYeedsiQQbfJGX = P_0;
	}
}
