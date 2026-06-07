using System;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class WDfkTImFSaQkAopFgARJAIdQhUmX : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr tkXyUTswGOzpAPdDeKWSvaDSjHTz(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
	private struct UkFpjlcRbDJndGqSvcaAOknlnWbT
	{
		public uint IgFcjWCNMmRfmySyqSaFfcukowcG;

		public IntPtr GMMClCCrTqJCUgbDGChQoHaMZpmmb;

		public int IQidOwBSoWIajjziOcziClGgNzOgb;

		public int XVMDNylChiSsNrufLszktajrVJFy;

		public IntPtr rWBYavocQafcUhKnOedFMDBTpusNA;

		public IntPtr iBRbUVBuVIgIqSQoQZYgcDucMRCr;

		public IntPtr VixRCYOTGdhNpXkSOEMbXDkaQmbN;

		public IntPtr FxETBOsAiPGcnSInNMWvIhKYJfHg;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string XFfkOyJCdxVaBnLLWgSAIgrRRiHx;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string qPCgiYbmgipCsjxVEEdmHwKaqZoGb;
	}

	[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
	private struct RFYDSqhAetKONmQEVNpnfwBfTpsyB
	{
		public IntPtr AcXZAADscUNHkKgyypPEleWrunLe;

		public IntPtr iWKFhlJPhirdUVcDSJWhyLHTzbbA;

		public IntPtr fqLoBXlBvQApEFEngFFvYGFcZGcRA;

		public IntPtr JxGnlXVgQEyRHelLBjEHAcDVPLSD;

		public int iESYULsUWOKIQUAQdbQgRITbhbJAA;

		public int FPWhwkgDjjCYtyNgrtUhDqQOIBFd;

		public int AWBUCTFBpGIgQDKgSVIMBuvlRGuI;

		public int nCliFmOJeVmATRenAaJjTwQyySLI;

		public int wGpmtAAjITTKaqCjMCALKwoeuqdo;

		public IntPtr LgaqCGVayhpHZHNhCSPuAgxThQJD;

		public IntPtr EQvtHZfnZqcrOqLQPpcLNDdLIol;

		public uint ZAJgHFoDthOZhQFspFkTkLgYDgjab;
	}

	private readonly ushort RvwDifNqqvPXKnoyeEbQEGMwczKU;

	private readonly string GdfBXDwEfLFBTbhTqvcNzGNvUbcX;

	private bool zSITftAoFMtnWsCSEthGKYqSqnJf;

	private IntPtr TtoRfoUyxpHdIikELuNJprXelWvA;

	private int AonZcozqKifbiRipmBwtDYFPqZesA;

	private uint qNDfcoMeIgLCXlOmqTsEHjPQjepeA;

	private tkXyUTswGOzpAPdDeKWSvaDSjHTz ZrcgPlHjeFaGGMJjqRqgSrWYwgUf;

	private tkXyUTswGOzpAPdDeKWSvaDSjHTz RotCBoGjTvmXujThFQuMPBgCznMB;

	public IntPtr DQlnccYfKAebOztsUYLkEkvPUtWj => TtoRfoUyxpHdIikELuNJprXelWvA;

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	private static extern ushort pKVPFhKnbWCcaZfpPAAJikxcwGhtA([In] ref UkFpjlcRbDJndGqSvcaAOknlnWbT P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	private static extern bool adseLygIGHuYJhHpMUPrDLhvUkSD([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	private static extern IntPtr RDdRKaCiDuWcDUUtRCpPsuMovBqU(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	private static extern IntPtr bcyHnNJZpAoRpIohqLEdEXYAITVxB(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	private static extern bool NMJEwAUEGvYHcyidZPwCceGIGwcF(IntPtr P_0);

	public void Dispose()
	{
		cKuZEDgXRlnjjHjBTaNcBrysqTyP(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void vbPEZOObIdaEZwBCAFYZixmZIiAp()
	{
		try
		{
			cKuZEDgXRlnjjHjBTaNcBrysqTyP(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void cKuZEDgXRlnjjHjBTaNcBrysqTyP(bool P_0)
	{
		if (!zSITftAoFMtnWsCSEthGKYqSqnJf)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(qNDfcoMeIgLCXlOmqTsEHjPQjepeA);
			}
			if (TtoRfoUyxpHdIikELuNJprXelWvA != IntPtr.Zero)
			{
				NMJEwAUEGvYHcyidZPwCceGIGwcF(TtoRfoUyxpHdIikELuNJprXelWvA);
				TtoRfoUyxpHdIikELuNJprXelWvA = IntPtr.Zero;
			}
			if (RvwDifNqqvPXKnoyeEbQEGMwczKU != 0 && !string.IsNullOrEmpty(GdfBXDwEfLFBTbhTqvcNzGNvUbcX))
			{
				adseLygIGHuYJhHpMUPrDLhvUkSD(GdfBXDwEfLFBTbhTqvcNzGNvUbcX, IntPtr.Zero);
			}
			zSITftAoFMtnWsCSEthGKYqSqnJf = true;
		}
	}

	public WDfkTImFSaQkAopFgARJAIdQhUmX(string P_0, bool P_1, tkXyUTswGOzpAPdDeKWSvaDSjHTz P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		qNDfcoMeIgLCXlOmqTsEHjPQjepeA = ObjectInstanceTracker.Default.Register(this);
		GdfBXDwEfLFBTbhTqvcNzGNvUbcX = P_0;
		ZrcgPlHjeFaGGMJjqRqgSrWYwgUf = UrSdsLJfiIZctpqnsqJECNzfFQpGc;
		RotCBoGjTvmXujThFQuMPBgCznMB = P_2;
		AonZcozqKifbiRipmBwtDYFPqZesA = 0;
		UkFpjlcRbDJndGqSvcaAOknlnWbT ukFpjlcRbDJndGqSvcaAOknlnWbT = new UkFpjlcRbDJndGqSvcaAOknlnWbT
		{
			GMMClCCrTqJCUgbDGChQoHaMZpmmb = Marshal.GetFunctionPointerForDelegate(ZrcgPlHjeFaGGMJjqRqgSrWYwgUf)
		};
		while (RvwDifNqqvPXKnoyeEbQEGMwczKU == 0 && AonZcozqKifbiRipmBwtDYFPqZesA < 20)
		{
			ukFpjlcRbDJndGqSvcaAOknlnWbT.qPCgiYbmgipCsjxVEEdmHwKaqZoGb = P_0;
			RvwDifNqqvPXKnoyeEbQEGMwczKU = pKVPFhKnbWCcaZfpPAAJikxcwGhtA(ref ukFpjlcRbDJndGqSvcaAOknlnWbT);
			if (RvwDifNqqvPXKnoyeEbQEGMwczKU != 0)
			{
				break;
			}
			AonZcozqKifbiRipmBwtDYFPqZesA++;
			P_0 = GdfBXDwEfLFBTbhTqvcNzGNvUbcX + AonZcozqKifbiRipmBwtDYFPqZesA;
		}
		if (RvwDifNqqvPXKnoyeEbQEGMwczKU == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (GdfBXDwEfLFBTbhTqvcNzGNvUbcX != P_0)
		{
			GdfBXDwEfLFBTbhTqvcNzGNvUbcX = P_0;
		}
		if (P_1)
		{
			TtoRfoUyxpHdIikELuNJprXelWvA = TJZzOLNoiDQbCkxcdWDMdBtlclUHA(P_0, new IntPtr((int)qNDfcoMeIgLCXlOmqTsEHjPQjepeA));
		}
		else
		{
			TtoRfoUyxpHdIikELuNJprXelWvA = ervhKqLAOtGnoglgImTibwHPcHnE(P_0, new IntPtr((int)qNDfcoMeIgLCXlOmqTsEHjPQjepeA));
		}
	}

	private IntPtr ervhKqLAOtGnoglgImTibwHPcHnE(string P_0, IntPtr P_1)
	{
		return RDdRKaCiDuWcDUUtRCpPsuMovBqU(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr TJZzOLNoiDQbCkxcdWDMdBtlclUHA(string P_0, IntPtr P_1)
	{
		return RDdRKaCiDuWcDUUtRCpPsuMovBqU(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, dAdQTYNMKSkiLMJVfSGtrASQhkQP.QaclKbiIItadGmAVkiPpTEzeghYFA, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(tkXyUTswGOzpAPdDeKWSvaDSjHTz))]
	private unsafe static IntPtr UrSdsLJfiIZctpqnsqJECNzfFQpGc(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return bcyHnNJZpAoRpIohqLEdEXYAITVxB(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			RFYDSqhAetKONmQEVNpnfwBfTpsyB* ptr = (RFYDSqhAetKONmQEVNpnfwBfTpsyB*)(void*)P_3;
			if (ptr->AcXZAADscUNHkKgyypPEleWrunLe != IntPtr.Zero)
			{
				xhdeZTSXJnCGxNhwofNZQKbUYVkf.PDZlNXLkufbQVEgmlxvLtYuCvzRx(P_0, -21, ptr->AcXZAADscUNHkKgyypPEleWrunLe);
			}
		}
		else
		{
			instanceId = (uint)xhdeZTSXJnCGxNhwofNZQKbUYVkf.IjbQBSTwFTKwLzTSkhcPPWCIlHkF(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<WDfkTImFSaQkAopFgARJAIdQhUmX>(instanceId, out var instance))
		{
			instance.RotCBoGjTvmXujThFQuMPBgCznMB(P_0, P_1, P_2, P_3);
		}
		return bcyHnNJZpAoRpIohqLEdEXYAITVxB(P_0, P_1, P_2, P_3);
	}

	public void TcqMxAUbmFShOljlGRKsuKytqAdr(tkXyUTswGOzpAPdDeKWSvaDSjHTz P_0)
	{
		RotCBoGjTvmXujThFQuMPBgCznMB = P_0;
	}
}
