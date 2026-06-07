using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class CvpDpDSxxZALGIbQWNQeutWMaNUNA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr rPvKOTMvthGMDKOEZOpdAkGwExuA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct YZBuBgAnSgMKxFPVHGqpjjIdvBPcA
	{
		public uint InkklnYYLxTgXWctzVvcBOgZddWbA;

		public IntPtr buoEhteCwrJccjUcWVXzePasEcFG;

		public int NVFueQHyurkjiRljMcRDhzvIapTi;

		public int GQuDZikfmPGMlsQVlFJCEUSEvXcU;

		public IntPtr yxnbTqFiGHPqMUmlBGtXToKanFneA;

		public IntPtr orsFpETCpOvCRKfbobOtOdIYDQZz;

		public IntPtr dJxSZaOvpSEFJssowdCHZKRoCDYs;

		public IntPtr gbJBrUQTYfXmEJseqWulYcVnOSnf;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string SMXcXoFHBUxDqLRZguYjhYxEUZtkA;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string XxdStMDQTZtrzcktYyiPczjMKcgU;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct GInmJptmaPKUmqYHaCiIVdYfarMn
	{
		public IntPtr NOWBzJgqTJRBaUMiNwgYhgomNbro;

		public IntPtr yxnbTqFiGHPqMUmlBGtXToKanFneA;

		public IntPtr hAmjrTfmCcJQSpuaGgaPsVowIrUN;

		public IntPtr HhgGUljfWwrxFeWeuwSTJLyggZSl;

		public int KMGiLIRPcgbAyQSaTMKhNmFZyOum;

		public int dvrUrqoYlUehftcQTBocbYscKxxY;

		public int jZtHLoGOcKxeqtCGBTnilRCaJNPG;

		public int HMqOacmZPahaVGMKoLtIrGLGaiBbA;

		public int InkklnYYLxTgXWctzVvcBOgZddWbA;

		public IntPtr KmbtmfIGRddNIuhlNhBctbRkARIi;

		public IntPtr waxqnZPNIcAvVRpKggFHCkzqEkVi;

		public uint BdkBodMOsvGegACDsLJEzktujXuzA;
	}

	private const int VywJFNZAXjUQfvCeYWLnfPsTPhUP = 20;

	private const int wZYyHIiEkDxIZXpSMbeQifatldsh = 1410;

	private readonly ushort iWNYfLqWRgywNuNPMfjdGbTXvLSe;

	private readonly string JVmBiPKEudfLfhJluGzSRHALEGeV;

	private bool rUNDXtafRpiCbfoAICfooVjrqfed;

	private IntPtr RGtLxkhmePeDVzPJdTnWSsxnIRas;

	private int wUYmCgRLLIGTRDopgiCdRLYGzxjr;

	private uint mpJerLFDgkxOsOetokrwzQxMFixJA;

	private rPvKOTMvthGMDKOEZOpdAkGwExuA oCawFnkADNeuEBbPbgXbWsYkkThWA;

	private rPvKOTMvthGMDKOEZOpdAkGwExuA tNtbTglKMiKrwHIKvhZkirvaCBUHA;

	public IntPtr uClDYCYpnKUIghlBmoPqJOntpoSQ => RGtLxkhmePeDVzPJdTnWSsxnIRas;

	public uint ZNmGqmfbNxPLJJPYLattLZbWQEoOA => mpJerLFDgkxOsOetokrwzQxMFixJA;

	public bool NJHboUuJGKPONkrqbJtbFGcBFCgr
	{
		get
		{
			if (!(RGtLxkhmePeDVzPJdTnWSsxnIRas != IntPtr.Zero))
			{
				return false;
			}
			return KncfVZCHlnVGaGAWkdKMOFojVdkmA(RGtLxkhmePeDVzPJdTnWSsxnIRas);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort ggpEzPApZWIuzwDtbPegUhXqOaaib([In] ref YZBuBgAnSgMKxFPVHGqpjjIdvBPcA P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool wySWkIhadMGxjoNMMatLoFRdNzWE([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr ZXCFnkIWjitoKNwCTbNtRcHrPXIUA(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr BaQZBZYOkFIZFBZnHXQWdjxQojki(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool xxnLCNeffeHMqlMuhgYDmLXLkzqj(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool KncfVZCHlnVGaGAWkdKMOFojVdkmA(IntPtr P_0);

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!rUNDXtafRpiCbfoAICfooVjrqfed)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(mpJerLFDgkxOsOetokrwzQxMFixJA);
			}
			if (RGtLxkhmePeDVzPJdTnWSsxnIRas != IntPtr.Zero)
			{
				xxnLCNeffeHMqlMuhgYDmLXLkzqj(RGtLxkhmePeDVzPJdTnWSsxnIRas);
				RGtLxkhmePeDVzPJdTnWSsxnIRas = IntPtr.Zero;
			}
			if (iWNYfLqWRgywNuNPMfjdGbTXvLSe != 0 && !string.IsNullOrEmpty(JVmBiPKEudfLfhJluGzSRHALEGeV))
			{
				wySWkIhadMGxjoNMMatLoFRdNzWE(JVmBiPKEudfLfhJluGzSRHALEGeV, IntPtr.Zero);
			}
			rUNDXtafRpiCbfoAICfooVjrqfed = true;
		}
	}

	public CvpDpDSxxZALGIbQWNQeutWMaNUNA(string P_0, bool P_1, rPvKOTMvthGMDKOEZOpdAkGwExuA P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		mpJerLFDgkxOsOetokrwzQxMFixJA = ObjectInstanceTracker.Default.Register(this);
		JVmBiPKEudfLfhJluGzSRHALEGeV = P_0;
		oCawFnkADNeuEBbPbgXbWsYkkThWA = JGTCMUJhXeIlvJgiUZaWQqSUdZptA;
		tNtbTglKMiKrwHIKvhZkirvaCBUHA = P_2;
		wUYmCgRLLIGTRDopgiCdRLYGzxjr = 0;
		YZBuBgAnSgMKxFPVHGqpjjIdvBPcA yZBuBgAnSgMKxFPVHGqpjjIdvBPcA = new YZBuBgAnSgMKxFPVHGqpjjIdvBPcA
		{
			buoEhteCwrJccjUcWVXzePasEcFG = Marshal.GetFunctionPointerForDelegate((Delegate)oCawFnkADNeuEBbPbgXbWsYkkThWA)
		};
		while (iWNYfLqWRgywNuNPMfjdGbTXvLSe == 0 && wUYmCgRLLIGTRDopgiCdRLYGzxjr < 20)
		{
			yZBuBgAnSgMKxFPVHGqpjjIdvBPcA.XxdStMDQTZtrzcktYyiPczjMKcgU = P_0;
			iWNYfLqWRgywNuNPMfjdGbTXvLSe = ggpEzPApZWIuzwDtbPegUhXqOaaib(ref yZBuBgAnSgMKxFPVHGqpjjIdvBPcA);
			if (iWNYfLqWRgywNuNPMfjdGbTXvLSe != 0)
			{
				break;
			}
			wUYmCgRLLIGTRDopgiCdRLYGzxjr++;
			P_0 = JVmBiPKEudfLfhJluGzSRHALEGeV + wUYmCgRLLIGTRDopgiCdRLYGzxjr;
		}
		if (iWNYfLqWRgywNuNPMfjdGbTXvLSe == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (JVmBiPKEudfLfhJluGzSRHALEGeV != P_0)
		{
			JVmBiPKEudfLfhJluGzSRHALEGeV = P_0;
		}
		if (P_1)
		{
			RGtLxkhmePeDVzPJdTnWSsxnIRas = FpGFTmAoocgrVhcMCJyDtmVpGQkvA(P_0, new IntPtr((int)mpJerLFDgkxOsOetokrwzQxMFixJA));
		}
		else
		{
			RGtLxkhmePeDVzPJdTnWSsxnIRas = BdmZCoeviCWMYQrYBZfNbbBlkaJd(P_0, new IntPtr((int)mpJerLFDgkxOsOetokrwzQxMFixJA));
		}
	}

	private IntPtr BdmZCoeviCWMYQrYBZfNbbBlkaJd(string P_0, IntPtr P_1)
	{
		return ZXCFnkIWjitoKNwCTbNtRcHrPXIUA(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr FpGFTmAoocgrVhcMCJyDtmVpGQkvA(string P_0, IntPtr P_1)
	{
		return ZXCFnkIWjitoKNwCTbNtRcHrPXIUA(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, bNjyIBdgpdVpFZDGLcYCYJhSMleY.olrBAwcHdOJwVaRSwAwIaADdnBho, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(rPvKOTMvthGMDKOEZOpdAkGwExuA))]
	private unsafe static IntPtr JGTCMUJhXeIlvJgiUZaWQqSUdZptA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return BaQZBZYOkFIZFBZnHXQWdjxQojki(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			GInmJptmaPKUmqYHaCiIVdYfarMn* ptr = (GInmJptmaPKUmqYHaCiIVdYfarMn*)(void*)P_3;
			if (ptr->NOWBzJgqTJRBaUMiNwgYhgomNbro != IntPtr.Zero)
			{
				nxzMUSyCaMfSlEuvKxUcjBKIXFKl.iuBfpjKtdDmHquXCKKybLgqZrfVt(P_0, -21, ptr->NOWBzJgqTJRBaUMiNwgYhgomNbro);
			}
		}
		else
		{
			instanceId = (uint)nxzMUSyCaMfSlEuvKxUcjBKIXFKl.RRpaxjhmOuyozjnUYCvOBsgPZsHm(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<CvpDpDSxxZALGIbQWNQeutWMaNUNA>(instanceId, out var instance))
		{
			instance.tNtbTglKMiKrwHIKvhZkirvaCBUHA(P_0, P_1, P_2, P_3);
		}
		return BaQZBZYOkFIZFBZnHXQWdjxQojki(P_0, P_1, P_2, P_3);
	}

	public void lPpFggdwVDbzowADsmATNtnIBwdh(rPvKOTMvthGMDKOEZOpdAkGwExuA P_0)
	{
		tNtbTglKMiKrwHIKvhZkirvaCBUHA = P_0;
	}
}
