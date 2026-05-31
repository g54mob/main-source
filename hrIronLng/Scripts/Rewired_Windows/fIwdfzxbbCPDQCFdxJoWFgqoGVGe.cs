using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class fIwdfzxbbCPDQCFdxJoWFgqoGVGe : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr bzlLqTJAxhIKJodCgngLvqCPWrE(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct mGkTxzfvfcGrlDBWtihErHFhjlt
	{
		public uint vmjdfRhoBaqtVvlGCXrQnpWtlPS;

		public IntPtr OEbuGBVmOcSPwIabrPjTMLhUvAT;

		public int cqScHgwcRirqsuGMrYfhRgPgarZ;

		public int junNECBAiUAOzLggUlZkarkoHsi;

		public IntPtr TMqXsEJKICooMBQWoBEdAAkODIz;

		public IntPtr XvlBHoBotBNhNbxYFLkLecqeJGDV;

		public IntPtr EzuLQvnfAVVgNPPOXetuxxBUNfO;

		public IntPtr LiMkTsfPGiNXOaPXRMoHqGtBsYn;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string fqUHbGyINTHlgiQaFspBovTaLIr;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string sowdCeyXoWnzpHCzdIcxQPameFw;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct nWQBOdefALFlslwrqIvYKRfNNuiK
	{
		public IntPtr owRlvhHrFOPJgxCRkQEeJfGUUtp;

		public IntPtr TMqXsEJKICooMBQWoBEdAAkODIz;

		public IntPtr OYfpwtYcErMKYOGFhIonSeCQbjQ;

		public IntPtr sslIjPEtCvpRNPWZNoKvvqUGLXS;

		public int lWVNngcqstWjmjtFqkHZdnhrCBs;

		public int EEebCLBhtNhlOYvwQGEyyCAalzh;

		public int MKmfDOCnKHHrcTKliSnMlRgSRZBd;

		public int iyrAwKHmFdoTXpepDCReDBhghaPK;

		public int vmjdfRhoBaqtVvlGCXrQnpWtlPS;

		public IntPtr prqFxLEnSutxIXuIggNIKTlYIYGV;

		public IntPtr VKatodmnHjIAVbeQLQIboeJCwAD;

		public uint eyvlsFnPsuwywhjiZkloGmTCGVu;
	}

	private const int adbVgrkrBaGsnEdZfxJBBsUlrKG = 20;

	private const int XLVTswRTGMwjDuvKlGDoKnTLkhc = 1410;

	private readonly ushort DmKUQdBaMvYuFJrqnvHPqPPfldI;

	private readonly string krfQPhxQeypDhOdMRTFsfqqpGAk;

	private bool YSFXDtJXhALcAUKTlqeFIxdJpgw;

	private IntPtr kumbbCMZcEgPTIwoGGLcurFRSLg;

	private int RsFdYOsyZPBTJeiMZiuVjnqwnPj;

	private uint VxUhDlcjidEycVnEHXAILRBgalp;

	private bzlLqTJAxhIKJodCgngLvqCPWrE ZypLTnBVYYsUkYwtClRiIaLKHjf;

	private bzlLqTJAxhIKJodCgngLvqCPWrE WOyLPMKLMjazcsblQexQQNDSxXM;

	public IntPtr Handle => kumbbCMZcEgPTIwoGGLcurFRSLg;

	public uint Id => VxUhDlcjidEycVnEHXAILRBgalp;

	public bool Exists
	{
		get
		{
			if (!(kumbbCMZcEgPTIwoGGLcurFRSLg != IntPtr.Zero))
			{
				return false;
			}
			return tnpXovapZeMTkjrIXoysdQnNfdq(kumbbCMZcEgPTIwoGGLcurFRSLg);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort DvqtNnIBKXyczocYOOVKXnrQgYw([In] ref mGkTxzfvfcGrlDBWtihErHFhjlt P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool DpVaMobAxVmUzVVrpZGzWehNiZGD([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr iFDrnIrbHbmcUJjLorIDYEdNTiQ(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr mHJDbtyZENNTsOeuvwaPPccyYs(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool OpqeVvFwxxcPoKKVWAIvDGjhfkkX(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool tnpXovapZeMTkjrIXoysdQnNfdq(IntPtr P_0);

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~fIwdfzxbbCPDQCFdxJoWFgqoGVGe()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	private void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!YSFXDtJXhALcAUKTlqeFIxdJpgw)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(VxUhDlcjidEycVnEHXAILRBgalp);
			}
			if (kumbbCMZcEgPTIwoGGLcurFRSLg != IntPtr.Zero)
			{
				OpqeVvFwxxcPoKKVWAIvDGjhfkkX(kumbbCMZcEgPTIwoGGLcurFRSLg);
				kumbbCMZcEgPTIwoGGLcurFRSLg = IntPtr.Zero;
			}
			if (DmKUQdBaMvYuFJrqnvHPqPPfldI != 0 && !string.IsNullOrEmpty(krfQPhxQeypDhOdMRTFsfqqpGAk))
			{
				DpVaMobAxVmUzVVrpZGzWehNiZGD(krfQPhxQeypDhOdMRTFsfqqpGAk, IntPtr.Zero);
			}
			YSFXDtJXhALcAUKTlqeFIxdJpgw = true;
		}
	}

	public fIwdfzxbbCPDQCFdxJoWFgqoGVGe(string className, bool createMessageOnlyWindow, bzlLqTJAxhIKJodCgngLvqCPWrE staticCustomWndProcDelegate)
	{
		if (string.IsNullOrEmpty(className))
		{
			throw new ArgumentNullException("className");
		}
		if (staticCustomWndProcDelegate == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		VxUhDlcjidEycVnEHXAILRBgalp = ObjectInstanceTracker.Default.Register(this);
		krfQPhxQeypDhOdMRTFsfqqpGAk = className;
		ZypLTnBVYYsUkYwtClRiIaLKHjf = eDSWLuSEFnfqdNbFrKKqCfwwNLt;
		WOyLPMKLMjazcsblQexQQNDSxXM = staticCustomWndProcDelegate;
		RsFdYOsyZPBTJeiMZiuVjnqwnPj = 0;
		mGkTxzfvfcGrlDBWtihErHFhjlt mGkTxzfvfcGrlDBWtihErHFhjlt2 = new mGkTxzfvfcGrlDBWtihErHFhjlt
		{
			OEbuGBVmOcSPwIabrPjTMLhUvAT = Marshal.GetFunctionPointerForDelegate((Delegate)ZypLTnBVYYsUkYwtClRiIaLKHjf)
		};
		while (DmKUQdBaMvYuFJrqnvHPqPPfldI == 0 && RsFdYOsyZPBTJeiMZiuVjnqwnPj < 20)
		{
			mGkTxzfvfcGrlDBWtihErHFhjlt2.sowdCeyXoWnzpHCzdIcxQPameFw = className;
			DmKUQdBaMvYuFJrqnvHPqPPfldI = DvqtNnIBKXyczocYOOVKXnrQgYw(ref mGkTxzfvfcGrlDBWtihErHFhjlt2);
			if (DmKUQdBaMvYuFJrqnvHPqPPfldI != 0)
			{
				break;
			}
			RsFdYOsyZPBTJeiMZiuVjnqwnPj++;
			className = krfQPhxQeypDhOdMRTFsfqqpGAk + RsFdYOsyZPBTJeiMZiuVjnqwnPj;
		}
		if (DmKUQdBaMvYuFJrqnvHPqPPfldI == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (krfQPhxQeypDhOdMRTFsfqqpGAk != className)
		{
			krfQPhxQeypDhOdMRTFsfqqpGAk = className;
		}
		if (createMessageOnlyWindow)
		{
			kumbbCMZcEgPTIwoGGLcurFRSLg = oMRLBYjdihAhVZHfzaElKUtHBYol(className, new IntPtr((int)VxUhDlcjidEycVnEHXAILRBgalp));
		}
		else
		{
			kumbbCMZcEgPTIwoGGLcurFRSLg = oFhvXYNYrHtQOnOYqElZeBPBSsBo(className, new IntPtr((int)VxUhDlcjidEycVnEHXAILRBgalp));
		}
	}

	private IntPtr oFhvXYNYrHtQOnOYqElZeBPBSsBo(string P_0, IntPtr P_1)
	{
		return iFDrnIrbHbmcUJjLorIDYEdNTiQ(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr oMRLBYjdihAhVZHfzaElKUtHBYol(string P_0, IntPtr P_1)
	{
		return iFDrnIrbHbmcUJjLorIDYEdNTiQ(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, YZuduhHYdujZNQijkwygrqXwCpon.FRaLEQLIdFAiTDHnDBSiKFzLsTx, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(bzlLqTJAxhIKJodCgngLvqCPWrE))]
	private unsafe static IntPtr eDSWLuSEFnfqdNbFrKKqCfwwNLt(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return mHJDbtyZENNTsOeuvwaPPccyYs(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			nWQBOdefALFlslwrqIvYKRfNNuiK* ptr = (nWQBOdefALFlslwrqIvYKRfNNuiK*)(void*)P_3;
			if (ptr->owRlvhHrFOPJgxCRkQEeJfGUUtp != IntPtr.Zero)
			{
				AewjMoBLyBolnnNMhBXWHRooNZC.DRWfdJpjpYgVyRfznqMBraKjmlX(P_0, -21, ptr->owRlvhHrFOPJgxCRkQEeJfGUUtp);
			}
		}
		else
		{
			instanceId = (uint)AewjMoBLyBolnnNMhBXWHRooNZC.mIcfmROfUnqGxOdljRQshbYfeZD(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<fIwdfzxbbCPDQCFdxJoWFgqoGVGe>(instanceId, out var instance))
		{
			instance.WOyLPMKLMjazcsblQexQQNDSxXM(P_0, P_1, P_2, P_3);
		}
		return mHJDbtyZENNTsOeuvwaPPccyYs(P_0, P_1, P_2, P_3);
	}

	public void EjghPAITHKgbgXucFpSllyFoUZn(bzlLqTJAxhIKJodCgngLvqCPWrE P_0)
	{
		WOyLPMKLMjazcsblQexQQNDSxXM = P_0;
	}
}
