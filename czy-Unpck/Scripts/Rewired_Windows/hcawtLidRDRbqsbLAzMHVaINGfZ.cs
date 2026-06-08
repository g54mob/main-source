using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class hcawtLidRDRbqsbLAzMHVaINGfZ : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr FOuGhnqYlTUeadpnVWrBsIzYFWx(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct LBhVcfjltkEtpgmjVtHDKAXxHJdO
	{
		public uint hTfmFboyHjizzFQonKXVnpkAmMV;

		public IntPtr KLfYNfQxYdLmEuILYDkSSkLngPMK;

		public int gIUpQfHcdlnOMayGqXyLZzPjtC;

		public int ranWhgMFaFMHBlAWbckxeyUBsQx;

		public IntPtr XFiAWsGERPiTibevDQoaKOSdGhc;

		public IntPtr JCtjSGBzbQErtPwekcfSiuCXyRC;

		public IntPtr SoiEuminMNFnOjtsqxaDbVfdWZm;

		public IntPtr ToOhMSmZMprTgAipohpWieXinTmt;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string dWIKpuxTgQFVGKIlqncAipIRIEk;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string gojiSvbZTghVHrgSPHskErTxbhS;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct EcznjMSAFVtoQFRgtSUVVUBGhNf
	{
		public IntPtr kdBSoXIAJNdRUHshBbZnHVcdewiw;

		public IntPtr XFiAWsGERPiTibevDQoaKOSdGhc;

		public IntPtr QsbkiDHMWaGcagajUDsqSewvdsB;

		public IntPtr qYvBujFhIknytdprcbEqvqinSdB;

		public int jdHGNKpvmkWfINNjPbCStzNSFIf;

		public int WyiwyyMzEUzTQcZpPZBkskgdcGu;

		public int KrsdWwCcQOIbYsuFPdcBfPCapOQo;

		public int qelAlmYJXeHsrFlXmeOnXCPFUjE;

		public int hTfmFboyHjizzFQonKXVnpkAmMV;

		public IntPtr dkqaifgcItQlappqZJQZBRHIfJFr;

		public IntPtr HssydRvpPiXSzSAicMTuevvvKTE;

		public uint gRbNzziAkxEmECFGyumvQEzxSUja;
	}

	private const int wJnOCDnIRdGMLeSpWduAHQyAsOT = 20;

	private const int TSLYnIMKMVxfvOmeQrYpQLxktuf = 1410;

	private readonly ushort PtGzLFCREwhonjbKWIGKjkhAtsZA;

	private readonly string okbmAXebixCRTBgowgSzrfYGDVxd;

	private bool MLDSQRMGzDugisRrWddECYZsBll;

	private IntPtr onewGiZYyBPbdktAlIOjsHxsOQd;

	private int VlXDOmbADQhBfMJeqRfQvkARUyc;

	private uint TDSsDXrDcmOPWbTmgULNLRhBxfy;

	private FOuGhnqYlTUeadpnVWrBsIzYFWx XExAbBQPyJgkKaKHboGZIGldQmt;

	private FOuGhnqYlTUeadpnVWrBsIzYFWx IwgQCkTNEsIjYKTFtNuRKpzhnEZ;

	public IntPtr Handle => onewGiZYyBPbdktAlIOjsHxsOQd;

	public uint Id => TDSsDXrDcmOPWbTmgULNLRhBxfy;

	public bool Exists
	{
		get
		{
			if (!(onewGiZYyBPbdktAlIOjsHxsOQd != IntPtr.Zero))
			{
				return false;
			}
			return punIMLhHllGjATCFuAtzdfuyDkbA(onewGiZYyBPbdktAlIOjsHxsOQd);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort FOmwZZXRIQcLVIaEhThRHbDbtpl([In] ref LBhVcfjltkEtpgmjVtHDKAXxHJdO P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool PwNFHAERdYsKTbrRSCBmqELqsYLB([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr eMNcLuubnuwLuvZBLiwGYERuQfH(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr yiDWbZcqBLPfnECaRqDbVubNdUh(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool QImGIZAKpwnTYeurbyJmMIZEwdfw(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool punIMLhHllGjATCFuAtzdfuyDkbA(IntPtr P_0);

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~hcawtLidRDRbqsbLAzMHVaINGfZ()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	private void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (MLDSQRMGzDugisRrWddECYZsBll)
		{
			return;
		}
		while (true)
		{
			int num = 2019285790;
			while (true)
			{
				switch (num ^ 0x785BDB1F)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					MLDSQRMGzDugisRrWddECYZsBll = true;
					num = 2019285791;
					continue;
				case 5:
					PwNFHAERdYsKTbrRSCBmqELqsYLB(okbmAXebixCRTBgowgSzrfYGDVxd, IntPtr.Zero);
					num = 2019285788;
					continue;
				case 6:
					if (onewGiZYyBPbdktAlIOjsHxsOQd != IntPtr.Zero)
					{
						QImGIZAKpwnTYeurbyJmMIZEwdfw(onewGiZYyBPbdktAlIOjsHxsOQd);
						onewGiZYyBPbdktAlIOjsHxsOQd = IntPtr.Zero;
						num = 2019285787;
						continue;
					}
					goto case 4;
				case 4:
					if (PtGzLFCREwhonjbKWIGKjkhAtsZA != 0)
					{
						int num2;
						if (string.IsNullOrEmpty(okbmAXebixCRTBgowgSzrfYGDVxd))
						{
							num = 2019285788;
							num2 = num;
						}
						else
						{
							num = 2019285786;
							num2 = num;
						}
						continue;
					}
					goto case 3;
				case 1:
					if (P_0)
					{
						ObjectInstanceTracker.Default.Unregister(TDSsDXrDcmOPWbTmgULNLRhBxfy);
						num = 2019285785;
						continue;
					}
					goto case 6;
				case 0:
					return;
				}
				break;
			}
		}
	}

	public hcawtLidRDRbqsbLAzMHVaINGfZ(string className, bool createMessageOnlyWindow, FOuGhnqYlTUeadpnVWrBsIzYFWx staticCustomWndProcDelegate)
	{
		if (string.IsNullOrEmpty(className))
		{
			throw new ArgumentNullException("className");
		}
		if (staticCustomWndProcDelegate == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		TDSsDXrDcmOPWbTmgULNLRhBxfy = ObjectInstanceTracker.Default.Register(this);
		okbmAXebixCRTBgowgSzrfYGDVxd = className;
		XExAbBQPyJgkKaKHboGZIGldQmt = ckUPWKPZLgrbBfKrIHLdOkGPOfm;
		IwgQCkTNEsIjYKTFtNuRKpzhnEZ = staticCustomWndProcDelegate;
		VlXDOmbADQhBfMJeqRfQvkARUyc = 0;
		LBhVcfjltkEtpgmjVtHDKAXxHJdO lBhVcfjltkEtpgmjVtHDKAXxHJdO = new LBhVcfjltkEtpgmjVtHDKAXxHJdO
		{
			KLfYNfQxYdLmEuILYDkSSkLngPMK = Marshal.GetFunctionPointerForDelegate((Delegate)XExAbBQPyJgkKaKHboGZIGldQmt)
		};
		while (PtGzLFCREwhonjbKWIGKjkhAtsZA == 0 && VlXDOmbADQhBfMJeqRfQvkARUyc < 20)
		{
			lBhVcfjltkEtpgmjVtHDKAXxHJdO.gojiSvbZTghVHrgSPHskErTxbhS = className;
			PtGzLFCREwhonjbKWIGKjkhAtsZA = FOmwZZXRIQcLVIaEhThRHbDbtpl(ref lBhVcfjltkEtpgmjVtHDKAXxHJdO);
			if (PtGzLFCREwhonjbKWIGKjkhAtsZA != 0)
			{
				break;
			}
			VlXDOmbADQhBfMJeqRfQvkARUyc++;
			className = okbmAXebixCRTBgowgSzrfYGDVxd + VlXDOmbADQhBfMJeqRfQvkARUyc;
		}
		if (PtGzLFCREwhonjbKWIGKjkhAtsZA == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (okbmAXebixCRTBgowgSzrfYGDVxd != className)
		{
			okbmAXebixCRTBgowgSzrfYGDVxd = className;
		}
		if (createMessageOnlyWindow)
		{
			onewGiZYyBPbdktAlIOjsHxsOQd = cFLSCyatcazkzhENOEFuYqNcRPl(className, new IntPtr((int)TDSsDXrDcmOPWbTmgULNLRhBxfy));
		}
		else
		{
			onewGiZYyBPbdktAlIOjsHxsOQd = gZbvIaGsxUWUyPIgRMgQDNnmAfO(className, new IntPtr((int)TDSsDXrDcmOPWbTmgULNLRhBxfy));
		}
	}

	private IntPtr gZbvIaGsxUWUyPIgRMgQDNnmAfO(string P_0, IntPtr P_1)
	{
		return eMNcLuubnuwLuvZBLiwGYERuQfH(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr cFLSCyatcazkzhENOEFuYqNcRPl(string P_0, IntPtr P_1)
	{
		return eMNcLuubnuwLuvZBLiwGYERuQfH(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, WgyDhDKPtxBNfGUTiXnlxotcDalv.BYsPRuQnvIGejrNPasVbQeLwcAcb, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(FOuGhnqYlTUeadpnVWrBsIzYFWx))]
	private unsafe static IntPtr ckUPWKPZLgrbBfKrIHLdOkGPOfm(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return yiDWbZcqBLPfnECaRqDbVubNdUh(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		EcznjMSAFVtoQFRgtSUVVUBGhNf* ptr = default(EcznjMSAFVtoQFRgtSUVVUBGhNf*);
		if (P_1 == 1)
		{
			ptr = (EcznjMSAFVtoQFRgtSUVVUBGhNf*)(void*)P_3;
			goto IL_0029;
		}
		goto IL_00d8;
		IL_00d8:
		IntPtr intPtr = YksGHYKteMuhDXToEsEFZvCVfCJ.aBykNhFOmeeFXkLSUSFtbCoMARC(P_0, -21);
		int num = -844141495;
		goto IL_002e;
		IL_002e:
		while (true)
		{
			switch (num ^ -844141491)
			{
			case 2:
				break;
			case 1:
				if (ptr->kdBSoXIAJNdRUHshBbZnHVcdewiw != IntPtr.Zero)
				{
					YksGHYKteMuhDXToEsEFZvCVfCJ.HKQsEhmRzHHEChfVIFHCvpcQinY(P_0, -21, ptr->kdBSoXIAJNdRUHshBbZnHVcdewiw);
					num = -844141490;
					continue;
				}
				goto IL_0086;
			case 0:
				goto IL_0086;
			case 5:
			{
				if (ObjectInstanceTracker.Default.TryGetInstance<hcawtLidRDRbqsbLAzMHVaINGfZ>(instanceId, out var instance))
				{
					instance.IwgQCkTNEsIjYKTFtNuRKpzhnEZ(P_0, P_1, P_2, P_3);
					num = -844141494;
					continue;
				}
				goto default;
			}
			case 4:
				instanceId = (uint)intPtr.ToInt32();
				flag = true;
				num = -844141491;
				continue;
			case 6:
				goto IL_00d8;
			case 3:
				num = -844141491;
				continue;
			default:
				return yiDWbZcqBLPfnECaRqDbVubNdUh(P_0, P_1, P_2, P_3);
			}
			break;
			IL_0086:
			int num2;
			if (!flag)
			{
				num = -844141494;
				num2 = num;
			}
			else
			{
				num = -844141496;
				num2 = num;
			}
		}
		goto IL_0029;
		IL_0029:
		num = -844141492;
		goto IL_002e;
	}

	public void WCijCmDpBDffQnnIyeNkfZvNiMq(FOuGhnqYlTUeadpnVWrBsIzYFWx P_0)
	{
		IwgQCkTNEsIjYKTFtNuRKpzhnEZ = P_0;
	}
}
