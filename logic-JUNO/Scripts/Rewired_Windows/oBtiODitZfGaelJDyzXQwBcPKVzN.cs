using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class oBtiODitZfGaelJDyzXQwBcPKVzN : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr LwLvsEuaFFHvyIgNetbPTiOPrSSu(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct sWJPyewcqWPzBRjGfDXBwAggbHodA
	{
		public uint qwVxKLSnNdRSYdDmcfVWLgjhxozg;

		public IntPtr aaCFsJAlOlkEeigBKjQXxxpYDgzsA;

		public int eTiCPhcTbLSqVggkAcSpSVBlTaBMA;

		public int nmIjUnnTqtjchyKpTAStiFieZUOMA;

		public IntPtr ToVufocNFxCiqiDrEtGCGfGQUldGA;

		public IntPtr KhJULCLxUHFAWVMgOEvbQXbvpOXt;

		public IntPtr rbjOFHKaRyUZHWZOSbikxlvnnIyK;

		public IntPtr pUMEVwBTWKRDTjGPfWsuZiNWNYK;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pZvFTnPTeagkxcNBCHvTyJaQIxIZ;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string EUGBvFcVfrcQQJgROUEfdIPtOAjnA;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct dhOGJvHKxgGUjnJAVaSmBEMKOmvAc
	{
		public IntPtr uxTGFqPlQLRWbPiyuARJDrbihAOe;

		public IntPtr MhGCEqJYbivRPMmmNglZCCbSqdoE;

		public IntPtr HTZnECvQiTxtyDOfyKmmywEpVNdQ;

		public IntPtr xDYwkYHgdRmvbvevFISScGnQBOLS;

		public int CeGxNAseHXNAkTESryptvcYercOy;

		public int vNIacbgiAcSyLjVRvGNkzFlDXkEi;

		public int yNTNITgIJMSuCfwMaFLtpieCqtg;

		public int VtIvbEWWaIutoGfaSJqjzDuxbYeB;

		public int YwplrVOJrWLkKrtHMhIsorgptioe;

		public IntPtr noCpLEFjHupzzEHuQlfMmjyGuSkc;

		public IntPtr qwOocWJqJSqHRJNKMuXzfEYiGNzD;

		public uint hhLjAEmHoqnXLZbqzGJSBvbXdfkCb;
	}

	private const int yfUxPJhxQlIRpFRrSILyhficeoGg = 20;

	private const int FcVCcFaPJpAlYFeGBivmdcDnXVoL = 1410;

	private readonly ushort pJwYjsRMroTguklwyjsNepPjutTF;

	private readonly string wdhBIGogsKYVfsvJiMZGPBEodyhX;

	private bool FJIWAmUYEBnxadbIKKnJselPbrWO;

	private IntPtr jjbMIaIftkBbZraxIBkGLelYyDfc;

	private int gYzfdfFdLnfrGtItekXyYgUKmYtBb;

	private uint YRRkfpCcJtNAnqRawURDdEKNrfsu;

	private LwLvsEuaFFHvyIgNetbPTiOPrSSu fmczKqRIoIwDgBebocRfeEmDkbPR;

	private LwLvsEuaFFHvyIgNetbPTiOPrSSu flxDMEKcBmmdfgPUJzfvbYCXcVaE;

	public IntPtr bntmFzYHQNiHaeGyArRfeFoODXBJ => jjbMIaIftkBbZraxIBkGLelYyDfc;

	public uint VrRUgnmeTJlIBsGtClHDkCCMQXDR => YRRkfpCcJtNAnqRawURDdEKNrfsu;

	public bool dxYuFYOgfUfatBdhtCjuTRxVQQcOA
	{
		get
		{
			if (!(jjbMIaIftkBbZraxIBkGLelYyDfc != IntPtr.Zero))
			{
				return false;
			}
			return UhMfCSflMieyOaVveIVeEwYsqSTub(jjbMIaIftkBbZraxIBkGLelYyDfc);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort PYPLCyEhyJpmEYZfPsbWWNynAXiP([In] ref sWJPyewcqWPzBRjGfDXBwAggbHodA P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool CAqtYxkDNIgYjyMVKfTslTKqZjRl([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr bDjPXvKOEfHihDQhFeMQOPJpeCxs(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr JikZqIHRoDMJPbIhudninwFFeCCGA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool xsRVXZSLTsWYMjGpLosFIjXFZNhF(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool UhMfCSflMieyOaVveIVeEwYsqSTub(IntPtr P_0);

	public void Dispose()
	{
		GTmBAGkaIaSnLSPHJwtnxzzxQVbI(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void BcVRnJKRVogDjzYpCbdEAvREjbFf()
	{
		try
		{
			GTmBAGkaIaSnLSPHJwtnxzzxQVbI(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void GTmBAGkaIaSnLSPHJwtnxzzxQVbI(bool P_0)
	{
		if (!FJIWAmUYEBnxadbIKKnJselPbrWO)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(YRRkfpCcJtNAnqRawURDdEKNrfsu);
			}
			if (jjbMIaIftkBbZraxIBkGLelYyDfc != IntPtr.Zero)
			{
				xsRVXZSLTsWYMjGpLosFIjXFZNhF(jjbMIaIftkBbZraxIBkGLelYyDfc);
				jjbMIaIftkBbZraxIBkGLelYyDfc = IntPtr.Zero;
			}
			if (pJwYjsRMroTguklwyjsNepPjutTF != 0 && !string.IsNullOrEmpty(wdhBIGogsKYVfsvJiMZGPBEodyhX))
			{
				CAqtYxkDNIgYjyMVKfTslTKqZjRl(wdhBIGogsKYVfsvJiMZGPBEodyhX, IntPtr.Zero);
			}
			FJIWAmUYEBnxadbIKKnJselPbrWO = true;
		}
	}

	public oBtiODitZfGaelJDyzXQwBcPKVzN(string P_0, bool P_1, LwLvsEuaFFHvyIgNetbPTiOPrSSu P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		YRRkfpCcJtNAnqRawURDdEKNrfsu = ObjectInstanceTracker.Default.Register(this);
		wdhBIGogsKYVfsvJiMZGPBEodyhX = P_0;
		fmczKqRIoIwDgBebocRfeEmDkbPR = oSYcjAFhrLemDpjfsCmBzryOnPmcb;
		flxDMEKcBmmdfgPUJzfvbYCXcVaE = P_2;
		gYzfdfFdLnfrGtItekXyYgUKmYtBb = 0;
		sWJPyewcqWPzBRjGfDXBwAggbHodA sWJPyewcqWPzBRjGfDXBwAggbHodA2 = new sWJPyewcqWPzBRjGfDXBwAggbHodA
		{
			aaCFsJAlOlkEeigBKjQXxxpYDgzsA = Marshal.GetFunctionPointerForDelegate(fmczKqRIoIwDgBebocRfeEmDkbPR)
		};
		while (pJwYjsRMroTguklwyjsNepPjutTF == 0 && gYzfdfFdLnfrGtItekXyYgUKmYtBb < 20)
		{
			sWJPyewcqWPzBRjGfDXBwAggbHodA2.EUGBvFcVfrcQQJgROUEfdIPtOAjnA = P_0;
			pJwYjsRMroTguklwyjsNepPjutTF = PYPLCyEhyJpmEYZfPsbWWNynAXiP(ref sWJPyewcqWPzBRjGfDXBwAggbHodA2);
			if (pJwYjsRMroTguklwyjsNepPjutTF != 0)
			{
				break;
			}
			gYzfdfFdLnfrGtItekXyYgUKmYtBb++;
			P_0 = wdhBIGogsKYVfsvJiMZGPBEodyhX + gYzfdfFdLnfrGtItekXyYgUKmYtBb;
		}
		if (pJwYjsRMroTguklwyjsNepPjutTF == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (wdhBIGogsKYVfsvJiMZGPBEodyhX != P_0)
		{
			wdhBIGogsKYVfsvJiMZGPBEodyhX = P_0;
		}
		if (P_1)
		{
			jjbMIaIftkBbZraxIBkGLelYyDfc = pYDuRKFPpEfncGrklgwZIZymQuTpA(P_0, new IntPtr((int)YRRkfpCcJtNAnqRawURDdEKNrfsu));
		}
		else
		{
			jjbMIaIftkBbZraxIBkGLelYyDfc = OKvyZzJTSmYJxpdIYPMbVpqMpgzB(P_0, new IntPtr((int)YRRkfpCcJtNAnqRawURDdEKNrfsu));
		}
	}

	private IntPtr OKvyZzJTSmYJxpdIYPMbVpqMpgzB(string P_0, IntPtr P_1)
	{
		return bDjPXvKOEfHihDQhFeMQOPJpeCxs(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr pYDuRKFPpEfncGrklgwZIZymQuTpA(string P_0, IntPtr P_1)
	{
		return bDjPXvKOEfHihDQhFeMQOPJpeCxs(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, FctNbXZaNPcyhHCDrwfgVeJXGxBEA.edamZugXusqQwlDLwsBwvoJdwwRE, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(LwLvsEuaFFHvyIgNetbPTiOPrSSu))]
	private unsafe static IntPtr oSYcjAFhrLemDpjfsCmBzryOnPmcb(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return JikZqIHRoDMJPbIhudninwFFeCCGA(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			dhOGJvHKxgGUjnJAVaSmBEMKOmvAc* ptr = (dhOGJvHKxgGUjnJAVaSmBEMKOmvAc*)(void*)P_3;
			if (ptr->uxTGFqPlQLRWbPiyuARJDrbihAOe != IntPtr.Zero)
			{
				FTdbbIUhAgYSHUHmiEJUirkRZXhf.veBESITQlinQbnuypOCImPdVRaMx(P_0, -21, ptr->uxTGFqPlQLRWbPiyuARJDrbihAOe);
			}
		}
		else
		{
			instanceId = (uint)FTdbbIUhAgYSHUHmiEJUirkRZXhf.sboTJMTtQpIrdaDieGCOxLcNwErd(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<oBtiODitZfGaelJDyzXQwBcPKVzN>(instanceId, out var instance))
		{
			instance.flxDMEKcBmmdfgPUJzfvbYCXcVaE(P_0, P_1, P_2, P_3);
		}
		return JikZqIHRoDMJPbIhudninwFFeCCGA(P_0, P_1, P_2, P_3);
	}

	public void pdafkPESpAExgkYtCepzSRxmGLsy(LwLvsEuaFFHvyIgNetbPTiOPrSSu P_0)
	{
		flxDMEKcBmmdfgPUJzfvbYCXcVaE = P_0;
	}
}
