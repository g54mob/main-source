using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class LPcPDeVTWovbDEyKvGxlZQicvrvj
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class HAtRFDiyPVjYHBsrSOBylFEwYTdV
	{
		public int gmpgxVUbwjruJWoypKJxxTwaxtYA;

		public int oMadGdNAPqeFPWcAqtkZdhRLJoaI;

		public int BpeKPgZdZGFwmFdwrRrMKrophkik;

		public int qCyKeUkrLKkbwVpyriHHIIKdcCifA;

		public int uADzhXMSmSiOvPweJKsTkzGcBylJ;

		public byte XVkWrQNBcYAaEVToCqOPEbvNRlyQ;

		public byte XnCacNflugoJdEhuUDlCMGSAQFFK;

		public byte zfflOJUzmyRELJteJWSIudiGmOqv;

		public byte BwhMtQdgiqaSflTWMoyWtvtUkcBM;

		public byte bXhZGlzQGVzLzDQARtRxggHfMEcE;

		public byte KpnmZcGyfyetpAlKkbxQCCDqceFGA;

		public byte GgOdttNkQkDIKfzJPhjBGIYXqMxRA;

		public byte koziQCEVIetCLFVxqDsovDxXXrfX;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string jECdKbjUtaXDBVUSkISDtaWSFVRvA;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct mkAmNDApKhkYNGewGyDECKbdDeOI
	{
		public int ILbopWGLXaclvDtXAhzTeufmsqgfb;

		public int slahAQASeIkSknjPcDoRurwiNSQbb;

		public int nwpdNcfMqHDNcjnEnYQCKQiwgShLA;

		public int pkGgdhGoEriWVXpbOJEFseVJzWfaA;

		public int AnaBRjTlGfZqshHgtJqHQTJjUfMU;

		public int yYjTLyKcxPcfcazoyDSkgZgtDaAW;

		public int djFXButKykUjFZNZBXDSheEgvBGv;

		public int LrzEscROpohiRzjlUiBsaYcDlszg;

		public int cyWxrCGSIjCBkcfdTILUBwdXwfetA;

		public int BGICxBnNQPddhaehkDjNkIEeTLdR;

		public int txEghiENGQNCrjrPUKdxhLmHiBYIb;

		public char iQuqIjcPPfZdLUEqUFWwfyoVnoII;

		public char GsnaOpkgBNrfRFQIHDOBkRgfaGGYA;

		public char oOrUBIuDIsQSoIbQZHVToXEFOnUC;

		public char JXaOgJSHuvImrujvreFcBESxGJKjb;

		public byte qLvFELFlSUdxgPRsnUdAVboWEAufA;

		public byte eTEKKkYePPgvRdmuFtcZiCXWDlgH;

		public byte XwZEnKWmkVFVLyepPRpPmpNYMub;

		public byte tYgfQmoXPUioYWTqWTIrHYDxmeMb;

		public byte BSwCLnMoVjLMnhvAfATxTOGNZkWt;
	}

	internal enum srOKwTaHxmWxczYiTYYIEfTFLaTk
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr fpfAFKzgdTZXUIxwbGKjfAANaGOG(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool TTocafFFhnvZcbMFagojAjOevHiUA(IntPtr hwnd, IntPtr lParam);

	private static IntPtr VisLkBPtxfMTCAaZDKeFzHZVLazX = IntPtr.Zero;

	private static List<IntPtr> oqCclgbLJvByszCfIclKCRENveWK;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ABxWEjeClwEeTBUelCuEZEYemAUL(out MdZJfKqIUkawEmLdfacrPhtsFrun P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int sHHABRVAbMUZZosNbaSKEGnYdzcO(out MdZJfKqIUkawEmLdfacrPhtsFrun P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int zsqaLAhGyMzywYFwjyMrmqolRYMd(ref MdZJfKqIUkawEmLdfacrPhtsFrun P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int guokMgueUIOfwupkpwaPTpJJcuTcA(ref MdZJfKqIUkawEmLdfacrPhtsFrun P_0);

	public static IntPtr GRTtLWCZgqtqgjjuXPhgfnyFNoKS(HandleRef P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1)
	{
		if (IntPtr.Size == 4)
		{
			return HroGPhWEEYHlkDusVfgBKcwUAIiLA(P_0, P_1);
		}
		return uktrvYvgDVAYPacNTVeiXJNoHuLf(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr xhWUtZUkdUwfOAZiiCZxIAWyfNqS();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr HroGPhWEEYHlkDusVfgBKcwUAIiLA(HandleRef P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr uktrvYvgDVAYPacNTVeiXJNoHuLf(HandleRef P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1);

	public static IntPtr QQaLAyBmXbmVdxOxcoOVYGvKLHzV(HandleRef P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return GVicDdyRVPeOoAQUiiEUadrhkgUO(P_0, P_1, P_2);
		}
		return AwfHzLMDALEqfEGbuITzrxLThlcJ(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr xkknHwmBHxRclgjbPtqCIfjJfbel(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr GVicDdyRVPeOoAQUiiEUadrhkgUO(HandleRef P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1, IntPtr P_2);

	public static bool IDnUlIApTVcWXMrOAZUKfEApzdBL(HandleRef P_0, bool P_1)
	{
		return GXUGBeCaopJllSkJqHAHNAJNnQCcb(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool GXUGBeCaopJllSkJqHAHNAJNnQCcb(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr AwfHzLMDALEqfEGbuITzrxLThlcJ(HandleRef P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr rmLyIAoLrPjIbWsOBiQcegSdCSCyA(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr YChtkUAxXMfhgvCepEIPwHDZeHXr(string P_0);

	public static IntPtr wKZZqROTwxuIuWKmtgapdkAMprX(IntPtr P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1)
	{
		if (IntPtr.Size == 4)
		{
			return hwJfUCopQbnvJnqfVjEMjyauMtwlA(P_0, P_1);
		}
		return kkhFoEgCjypGcALhrlfmSxLdZgPP(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr hwJfUCopQbnvJnqfVjEMjyauMtwlA(IntPtr P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr kkhFoEgCjypGcALhrlfmSxLdZgPP(IntPtr P_0, srOKwTaHxmWxczYiTYYIEfTFLaTk P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool wxwXNekyUfrAtKLiEjwRQCqXOhoe(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr fqEIkqEblduDlNeYJMOBudmuHZJfA();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint CqGzBQoovgjAIfEuQbirouhkkjfv();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool owOcDygpQcAYHjXzskqcLrGKdmRsA(IntPtr P_0, IntPtr P_1);

	private static bool cMlHCrjQantJDhoUMuplHyDiWEWB(IntPtr P_0, IntPtr P_1)
	{
		lock (oqCclgbLJvByszCfIclKCRENveWK)
		{
			oqCclgbLJvByszCfIclKCRENveWK.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint qOHVIeStlhHYKKIbHqxNmaxrUlfG(IntPtr P_0, out uint P_1);

	public static IntPtr WfbIkbgaftliZzPPFKJiYesmZBCVA()
	{
		if (VisLkBPtxfMTCAaZDKeFzHZVLazX != IntPtr.Zero)
		{
			return VisLkBPtxfMTCAaZDKeFzHZVLazX;
		}
		oqCclgbLJvByszCfIclKCRENveWK = new List<IntPtr>();
		uint num = CqGzBQoovgjAIfEuQbirouhkkjfv();
		TTocafFFhnvZcbMFagojAjOevHiUA tTocafFFhnvZcbMFagojAjOevHiUA = cMlHCrjQantJDhoUMuplHyDiWEWB;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(tTocafFFhnvZcbMFagojAjOevHiUA);
		owOcDygpQcAYHjXzskqcLrGKdmRsA(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(tTocafFFhnvZcbMFagojAjOevHiUA);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < oqCclgbLJvByszCfIclKCRENveWK.Count; i++)
		{
			if (wxwXNekyUfrAtKLiEjwRQCqXOhoe(oqCclgbLJvByszCfIclKCRENveWK[i]))
			{
				qOHVIeStlhHYKKIbHqxNmaxrUlfG(oqCclgbLJvByszCfIclKCRENveWK[i], out var num2);
				if (num2 == num)
				{
					VisLkBPtxfMTCAaZDKeFzHZVLazX = oqCclgbLJvByszCfIclKCRENveWK[i];
					oqCclgbLJvByszCfIclKCRENveWK.Clear();
					return VisLkBPtxfMTCAaZDKeFzHZVLazX;
				}
			}
		}
		return fqEIkqEblduDlNeYJMOBudmuHZJfA();
	}
}
