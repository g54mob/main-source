using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ypRryIywRrvtKyGzmsiTAVfBgMf : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr yRxsQBSSzqeDQDwfDLSsblxFeaei(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct tuYODvcxMAcKBBgiLDSCUUHUFnr
	{
		public uint gsCwesgXvRUQVRWYZRFDgfNUsxh;

		public IntPtr VZCPtaILwVvremNbojCQDNopXnm;

		public int tPrhtHbwONEDgGCEuYGmSmYHyju;

		public int qSKmOxMhCfAqnFpkJqrjDljALQRE;

		public IntPtr SnPOUfUdehpGUzhQhxLaVxnffCC;

		public IntPtr OWAaKVduTuLFZTgWYYcCbYrLcRi;

		public IntPtr JEFhQxabTovpHjVNKoogonkbrGz;

		public IntPtr IpPAZwMcHnfKKODICmQromehLS;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string sptlYdffziTbuEbcAZoKbeSNRAO;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string xMVgwBrAbppHnhaUmlUoRDWFXhT;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct IqloiDwEOhHOoVrKcHodTIJzhhFe
	{
		public IntPtr pVskAUQejrljmDgNlIjzQDNrFcY;

		public IntPtr SnPOUfUdehpGUzhQhxLaVxnffCC;

		public IntPtr LyIyyOXviSpkSuPXqDKohLDdKolW;

		public IntPtr xQUtVkJOqIlJHdqFSUeaoaTjWEz;

		public int eWeUMPrqQUgewAPRbtuONmiCCPDi;

		public int NkZIgpSvZiKNliLvlBCXlwJrwkU;

		public int FkJGghiIyaeTycBdlqzNOIbbwCu;

		public int rWObvbgSvQIYDgZxAtBxdKuEJdeP;

		public int gsCwesgXvRUQVRWYZRFDgfNUsxh;

		public IntPtr kJLaukqYoJNhYzjShBfJEIohbHv;

		public IntPtr WFPhsShtjEcYDQmAWMuknNIhVFw;

		public uint fSUdmsqeSDSZaDBsWhOzVoEpAeL;
	}

	private const int peSYKGbdlVaixjyBcuxEAKFGBupD = 20;

	private const int KfuvcBUaixGLRCqMkSJpJxUiQiF = 1410;

	private readonly ushort EhzZZUCueCGKLbVmaZmMztIEyhb;

	private readonly string zlYUVWkQKLdMpqWPORIjyHdUZaZ;

	private bool VlkYlMKMHjWfQoPHqwGCVAoyduP;

	private IntPtr fzZaqhgVGbinXssyLZXdMdKuDGPa;

	private int KscDTdJlncKtHrCGWemKNqjLniMT;

	private uint IWfnwYlCIQwmoxlUAZFFYAYFWzI;

	private yRxsQBSSzqeDQDwfDLSsblxFeaei OfMfSeUHlnVAMmOyXUpOTGpdpEQ;

	private yRxsQBSSzqeDQDwfDLSsblxFeaei TqPSzdXuGMDooErWHhRNZAAhMid;

	public IntPtr Handle
	{
		get
		{
			return fzZaqhgVGbinXssyLZXdMdKuDGPa;
		}
	}

	public uint Id
	{
		get
		{
			return IWfnwYlCIQwmoxlUAZFFYAYFWzI;
		}
	}

	public bool Exists
	{
		get
		{
			if (!(fzZaqhgVGbinXssyLZXdMdKuDGPa != IntPtr.Zero))
			{
				return false;
			}
			return sUINSIpoBDQywHGfUGanihFqIuNi(fzZaqhgVGbinXssyLZXdMdKuDGPa);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort GVJqwUVAxaFIvGWSZNSDLUqlxbLb([In] ref tuYODvcxMAcKBBgiLDSCUUHUFnr P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool MiibFVPWPwMcblDhmyQoTWoafOn([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr bfgQabsoBWfMGbPhjDdCTXaozCp(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr bCcjOEyrOvbhTiAExpftaOWRWbTS(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool HQHCWOQDNOjtwCmLFfSymBuSFrRY(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool sUINSIpoBDQywHGfUGanihFqIuNi(IntPtr P_0);

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~ypRryIywRrvtKyGzmsiTAVfBgMf()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	private void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!VlkYlMKMHjWfQoPHqwGCVAoyduP)
		{
			if (P_0)
			{
				goto IL_000e;
			}
			goto IL_004d;
		}
		return;
		IL_003f:
		VlkYlMKMHjWfQoPHqwGCVAoyduP = true;
		int num = 1798391693;
		goto IL_0013;
		IL_000e:
		num = 1798391690;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ 0x6B31478C)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				goto IL_003f;
			case 4:
				goto IL_004d;
			case 5:
				fzZaqhgVGbinXssyLZXdMdKuDGPa = IntPtr.Zero;
				num = 1798391692;
				continue;
			case 0:
				goto IL_0084;
			case 6:
				ObjectInstanceTracker.Default.Unregister(IWfnwYlCIQwmoxlUAZFFYAYFWzI);
				num = 1798391688;
				continue;
			case 1:
				return;
			}
			break;
		}
		goto IL_000e;
		IL_004d:
		if (fzZaqhgVGbinXssyLZXdMdKuDGPa != IntPtr.Zero)
		{
			HQHCWOQDNOjtwCmLFfSymBuSFrRY(fzZaqhgVGbinXssyLZXdMdKuDGPa);
			num = 1798391689;
			goto IL_0013;
		}
		goto IL_0084;
		IL_0084:
		if (EhzZZUCueCGKLbVmaZmMztIEyhb != 0 && !string.IsNullOrEmpty(zlYUVWkQKLdMpqWPORIjyHdUZaZ))
		{
			MiibFVPWPwMcblDhmyQoTWoafOn(zlYUVWkQKLdMpqWPORIjyHdUZaZ, IntPtr.Zero);
			num = 1798391694;
			goto IL_0013;
		}
		goto IL_003f;
	}

	public ypRryIywRrvtKyGzmsiTAVfBgMf(string className, bool createMessageOnlyWindow, yRxsQBSSzqeDQDwfDLSsblxFeaei staticCustomWndProcDelegate)
	{
		if (string.IsNullOrEmpty(className))
		{
			throw new ArgumentNullException("className");
		}
		if (staticCustomWndProcDelegate == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		IWfnwYlCIQwmoxlUAZFFYAYFWzI = ObjectInstanceTracker.Default.Register(this);
		zlYUVWkQKLdMpqWPORIjyHdUZaZ = className;
		OfMfSeUHlnVAMmOyXUpOTGpdpEQ = fjfmBLHsjSDTxzYVyEQbNqzTWAU;
		TqPSzdXuGMDooErWHhRNZAAhMid = staticCustomWndProcDelegate;
		KscDTdJlncKtHrCGWemKNqjLniMT = 0;
		tuYODvcxMAcKBBgiLDSCUUHUFnr tuYODvcxMAcKBBgiLDSCUUHUFnr2 = new tuYODvcxMAcKBBgiLDSCUUHUFnr
		{
			VZCPtaILwVvremNbojCQDNopXnm = Marshal.GetFunctionPointerForDelegate((Delegate)OfMfSeUHlnVAMmOyXUpOTGpdpEQ)
		};
		while (EhzZZUCueCGKLbVmaZmMztIEyhb == 0 && KscDTdJlncKtHrCGWemKNqjLniMT < 20)
		{
			tuYODvcxMAcKBBgiLDSCUUHUFnr2.xMVgwBrAbppHnhaUmlUoRDWFXhT = className;
			EhzZZUCueCGKLbVmaZmMztIEyhb = GVJqwUVAxaFIvGWSZNSDLUqlxbLb(ref tuYODvcxMAcKBBgiLDSCUUHUFnr2);
			if (EhzZZUCueCGKLbVmaZmMztIEyhb != 0)
			{
				break;
			}
			KscDTdJlncKtHrCGWemKNqjLniMT++;
			className = zlYUVWkQKLdMpqWPORIjyHdUZaZ + KscDTdJlncKtHrCGWemKNqjLniMT;
		}
		if (EhzZZUCueCGKLbVmaZmMztIEyhb == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (zlYUVWkQKLdMpqWPORIjyHdUZaZ != className)
		{
			zlYUVWkQKLdMpqWPORIjyHdUZaZ = className;
		}
		if (createMessageOnlyWindow)
		{
			fzZaqhgVGbinXssyLZXdMdKuDGPa = jMaxEjuUEYbFXfmvulQkNFoeuPX(className, new IntPtr((int)IWfnwYlCIQwmoxlUAZFFYAYFWzI));
		}
		else
		{
			fzZaqhgVGbinXssyLZXdMdKuDGPa = vAGKJxQfTkfuCPHYzQdUKaUwphe(className, new IntPtr((int)IWfnwYlCIQwmoxlUAZFFYAYFWzI));
		}
	}

	private IntPtr vAGKJxQfTkfuCPHYzQdUKaUwphe(string P_0, IntPtr P_1)
	{
		return bfgQabsoBWfMGbPhjDdCTXaozCp(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr jMaxEjuUEYbFXfmvulQkNFoeuPX(string P_0, IntPtr P_1)
	{
		return bfgQabsoBWfMGbPhjDdCTXaozCp(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, VsBhOKFiHLExTQMhhdmldpUBgyL.WSDZerYBNoExXjAvEKolXjsuEuU, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(yRxsQBSSzqeDQDwfDLSsblxFeaei))]
	private unsafe static IntPtr fjfmBLHsjSDTxzYVyEQbNqzTWAU(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return bCcjOEyrOvbhTiAExpftaOWRWbTS(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			goto IL_001f;
		}
		goto IL_0092;
		IL_0092:
		IntPtr intPtr = JBXHRSYUePslTBUiRmNOkdLSed.xHBNqgPOuCeQzEsleLDbToBMqGyy(P_0, -21);
		int num = 1801462792;
		goto IL_0024;
		IL_001f:
		num = 1801462794;
		goto IL_0024;
		IL_0024:
		while (true)
		{
			switch (num ^ 0x6B60240E)
			{
			case 5:
				break;
			case 6:
				instanceId = (uint)intPtr.ToInt32();
				flag = true;
				num = 1801462797;
				continue;
			case 0:
				num = 1801462797;
				continue;
			case 3:
			{
				ypRryIywRrvtKyGzmsiTAVfBgMf instance;
				if (flag && ObjectInstanceTracker.Default.TryGetInstance<ypRryIywRrvtKyGzmsiTAVfBgMf>(instanceId, out instance))
				{
					instance.TqPSzdXuGMDooErWHhRNZAAhMid(P_0, P_1, P_2, P_3);
					num = 1801462799;
					continue;
				}
				goto default;
			}
			case 2:
				goto IL_0092;
			case 4:
			{
				IqloiDwEOhHOoVrKcHodTIJzhhFe* ptr = (IqloiDwEOhHOoVrKcHodTIJzhhFe*)(void*)P_3;
				if (ptr->pVskAUQejrljmDgNlIjzQDNrFcY != IntPtr.Zero)
				{
					JBXHRSYUePslTBUiRmNOkdLSed.WrvwiumnVpRrknOzqfIQjkRUvaiT(P_0, -21, ptr->pVskAUQejrljmDgNlIjzQDNrFcY);
					num = 1801462798;
					continue;
				}
				goto case 3;
			}
			default:
				return bCcjOEyrOvbhTiAExpftaOWRWbTS(P_0, P_1, P_2, P_3);
			}
			break;
		}
		goto IL_001f;
	}

	public void BKXMAnXhehZjsngcOWeeasMVARE(yRxsQBSSzqeDQDwfDLSsblxFeaei P_0)
	{
		TqPSzdXuGMDooErWHhRNZAAhMid = P_0;
	}
}
