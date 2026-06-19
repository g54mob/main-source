using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class edTUHywUTXJFvcLrQjKxoJZxDUQ : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr XpiEHHTMzPiIeoZcydWZQlFDxjx(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct reDKjDtPJOMdtNBGUgmiIKmlUjIR
	{
		public uint keGlBUmgrzYkiZeOfOvvYkrkglC;

		public IntPtr BLQcNSUaldZcPqfLYTmstKrPAjF;

		public int xFrhSbgvGvCnTUAYIJgOikohPyVj;

		public int shWxxVWYGBDQCdwkxQVNXDZdzFk;

		public IntPtr GbLZrHGMcVZsrltYTenEzMLZANx;

		public IntPtr SAgpphlVAAruPQQeNAyLHRhSKD;

		public IntPtr HuPGnZccJMFHsjrJySWKGWOgVBKs;

		public IntPtr MyhxXxudepZThWaLiWsyLeYUBYl;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string gddzvJvnxCfNDJIsaHUawVsfhRju;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string bdTINdkftHjfAMlIYkqCDbmadkeL;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct gWckfhihIVietqMNMtbFKLOznzP
	{
		public IntPtr vjiHikGSjTRPHReJJabBeilVatn;

		public IntPtr GbLZrHGMcVZsrltYTenEzMLZANx;

		public IntPtr XkKPHaDwkgcMdgWPUUkGrOfPghAk;

		public IntPtr xDAsyIJGsuavsbiLgHSAGPpDDPYh;

		public int wjcrhhvtScSENFyLBdAkAZOsbGo;

		public int VzPbZTCrXWvlAahxFnqlVfbBEprI;

		public int PUThFkwsTStPGwrINLnQiDQBLHl;

		public int piYIQHIxjkcqcJLfkQtPcRIracF;

		public int keGlBUmgrzYkiZeOfOvvYkrkglC;

		public IntPtr ivFTiYuwfpvdvpWVPhNncUYJANO;

		public IntPtr UrTQrkbzioYjwUHUwynGVzeLOLV;

		public uint lgUWQEgSSfaiRNVwsRuXfMcHLde;
	}

	private const int nPYlpeztprdMOqaHQGLybetmEjWQ = 20;

	private const int OraARvQeXPbikMANMlFBvqdUhks = 1410;

	private readonly ushort KSpcMqCopksHutkSIzimTfempnK;

	private readonly string nzKdBiqEGtXXQyYIcxlPIhVqAAe;

	private bool VyitvwERORwbzkfPUYcsdWIQitc;

	private IntPtr dKRkNJBwONjTkwQebwzXJecGOLe;

	private int IDwKyFhAvOLVsYvUyRCqKMXbrKp;

	private uint EKryPeznGehMNHjIiXptWumbdoxm;

	private XpiEHHTMzPiIeoZcydWZQlFDxjx MUYctCiUdVTifqycbaZctpHNeLbG;

	private XpiEHHTMzPiIeoZcydWZQlFDxjx BDFxDLToiglsFCrfbLWlzVgXJMK;

	public IntPtr Handle => dKRkNJBwONjTkwQebwzXJecGOLe;

	public uint Id => EKryPeznGehMNHjIiXptWumbdoxm;

	public bool Exists
	{
		get
		{
			if (!(dKRkNJBwONjTkwQebwzXJecGOLe != IntPtr.Zero))
			{
				return false;
			}
			return sHITbadrDpFMBHxnuKMTUMfAszw(dKRkNJBwONjTkwQebwzXJecGOLe);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort MjZwRkDdzMUiIINKbJsjbcSZbiky([In] ref reDKjDtPJOMdtNBGUgmiIKmlUjIR P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool OcOyzLLHMjMYVvtEkyIJhWYTXUP([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr hSiuTPuLZsoorfuzVSTitwKOEJG(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr lrsbvidsMJmFyIMSHfBRPgqfrget(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool LAXjwoMVigNTVyFhMoWBfYuXokz(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool sHITbadrDpFMBHxnuKMTUMfAszw(IntPtr P_0);

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~edTUHywUTXJFvcLrQjKxoJZxDUQ()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	private void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!VyitvwERORwbzkfPUYcsdWIQitc)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(EKryPeznGehMNHjIiXptWumbdoxm);
			}
			if (dKRkNJBwONjTkwQebwzXJecGOLe != IntPtr.Zero)
			{
				LAXjwoMVigNTVyFhMoWBfYuXokz(dKRkNJBwONjTkwQebwzXJecGOLe);
				dKRkNJBwONjTkwQebwzXJecGOLe = IntPtr.Zero;
			}
			if (KSpcMqCopksHutkSIzimTfempnK != 0 && !string.IsNullOrEmpty(nzKdBiqEGtXXQyYIcxlPIhVqAAe))
			{
				OcOyzLLHMjMYVvtEkyIJhWYTXUP(nzKdBiqEGtXXQyYIcxlPIhVqAAe, IntPtr.Zero);
			}
			VyitvwERORwbzkfPUYcsdWIQitc = true;
		}
	}

	public edTUHywUTXJFvcLrQjKxoJZxDUQ(string className, bool createMessageOnlyWindow, XpiEHHTMzPiIeoZcydWZQlFDxjx staticCustomWndProcDelegate)
	{
		if (string.IsNullOrEmpty(className))
		{
			throw new ArgumentNullException("className");
		}
		if (staticCustomWndProcDelegate == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		EKryPeznGehMNHjIiXptWumbdoxm = ObjectInstanceTracker.Default.Register(this);
		nzKdBiqEGtXXQyYIcxlPIhVqAAe = className;
		MUYctCiUdVTifqycbaZctpHNeLbG = bxbxsvJPherfEfrRAGcBjZTlrLn;
		BDFxDLToiglsFCrfbLWlzVgXJMK = staticCustomWndProcDelegate;
		IDwKyFhAvOLVsYvUyRCqKMXbrKp = 0;
		reDKjDtPJOMdtNBGUgmiIKmlUjIR reDKjDtPJOMdtNBGUgmiIKmlUjIR2 = new reDKjDtPJOMdtNBGUgmiIKmlUjIR
		{
			BLQcNSUaldZcPqfLYTmstKrPAjF = Marshal.GetFunctionPointerForDelegate((Delegate)MUYctCiUdVTifqycbaZctpHNeLbG)
		};
		while (KSpcMqCopksHutkSIzimTfempnK == 0 && IDwKyFhAvOLVsYvUyRCqKMXbrKp < 20)
		{
			reDKjDtPJOMdtNBGUgmiIKmlUjIR2.bdTINdkftHjfAMlIYkqCDbmadkeL = className;
			KSpcMqCopksHutkSIzimTfempnK = MjZwRkDdzMUiIINKbJsjbcSZbiky(ref reDKjDtPJOMdtNBGUgmiIKmlUjIR2);
			if (KSpcMqCopksHutkSIzimTfempnK != 0)
			{
				break;
			}
			IDwKyFhAvOLVsYvUyRCqKMXbrKp++;
			className = nzKdBiqEGtXXQyYIcxlPIhVqAAe + IDwKyFhAvOLVsYvUyRCqKMXbrKp;
		}
		if (KSpcMqCopksHutkSIzimTfempnK == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (nzKdBiqEGtXXQyYIcxlPIhVqAAe != className)
		{
			nzKdBiqEGtXXQyYIcxlPIhVqAAe = className;
		}
		if (createMessageOnlyWindow)
		{
			dKRkNJBwONjTkwQebwzXJecGOLe = jZarxNqRCkOrgvSxYccCpSKSdCi(className, new IntPtr((int)EKryPeznGehMNHjIiXptWumbdoxm));
		}
		else
		{
			dKRkNJBwONjTkwQebwzXJecGOLe = tmKjITAjVSIgrPmSLLpwmxuUkkF(className, new IntPtr((int)EKryPeznGehMNHjIiXptWumbdoxm));
		}
	}

	private IntPtr tmKjITAjVSIgrPmSLLpwmxuUkkF(string P_0, IntPtr P_1)
	{
		return hSiuTPuLZsoorfuzVSTitwKOEJG(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr jZarxNqRCkOrgvSxYccCpSKSdCi(string P_0, IntPtr P_1)
	{
		return hSiuTPuLZsoorfuzVSTitwKOEJG(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, LDLICyXLtzNtgKlsBEQDDyrjfaq.EgDiGDOqNKoCmbwdcmTZvrMUNXl, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(XpiEHHTMzPiIeoZcydWZQlFDxjx))]
	private unsafe static IntPtr bxbxsvJPherfEfrRAGcBjZTlrLn(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return lrsbvidsMJmFyIMSHfBRPgqfrget(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			gWckfhihIVietqMNMtbFKLOznzP* ptr = (gWckfhihIVietqMNMtbFKLOznzP*)(void*)P_3;
			if (ptr->vjiHikGSjTRPHReJJabBeilVatn != IntPtr.Zero)
			{
				HuTamtUgOYxfCNLWEcbrfgTfOVKO.WetSLYikTJdBLgzbAdiysCpcqhBU(P_0, -21, ptr->vjiHikGSjTRPHReJJabBeilVatn);
			}
		}
		else
		{
			instanceId = (uint)HuTamtUgOYxfCNLWEcbrfgTfOVKO.lVNYVAJgwqQqAqYxQMvJOhjcbXV(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<edTUHywUTXJFvcLrQjKxoJZxDUQ>(instanceId, out var instance))
		{
			instance.BDFxDLToiglsFCrfbLWlzVgXJMK(P_0, P_1, P_2, P_3);
		}
		return lrsbvidsMJmFyIMSHfBRPgqfrget(P_0, P_1, P_2, P_3);
	}

	public void LzNvmTHDlLjfPnSqyouQUJetaZp(XpiEHHTMzPiIeoZcydWZQlFDxjx P_0)
	{
		BDFxDLToiglsFCrfbLWlzVgXJMK = P_0;
	}
}
