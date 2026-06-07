using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class wPobypBrGqJFMzpPsHcbxMDAdOQb
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class nAUwXKqOGiswasfrngyKSfzPKLM
	{
		public int nTIhiMaKbhmQLHbCazrEUMXbUnY;

		public int OPgZBaqLahDgHDjljpUZFBMhqatv;

		public int ymJjyOzUJvWYNpPZhOaSijrRbLJ;

		public int pcEeTLqIwlLimPrkQqIojdfqnfZ;

		public int vTDhSQcjEKZRgJEBMoLEOApHQYP;

		public byte JrjzVeqDvjZiCyKRjAgibRWggVxY;

		public byte FBKvVijGiknlsZPLGwOUKhgYNbK;

		public byte ANmgQZcbyvVuSAXkEKJgZDiDePDF;

		public byte GDPhAKHVNgBmMdnCaaWFqgGCqQcY;

		public byte DVkAbOMOPDCRoCcvpOsPymdkQMCc;

		public byte rRKGhmBMCMjpTMFcOAqGibpsHUhI;

		public byte KgwRjKYRPxuzgkqMQCdgUPZMEnp;

		public byte yBurxjfccmoDwTYQWXbskUrXxoJ;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string ejXpIOduzdPZZsbgLLvDJrqMHOL;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct goMfdAMNfGENitJxtuvMicbXQOU
	{
		public int zgSntFcPuveqAAGpPCrNEgtvfAg;

		public int RMBpEgDBsAPbNoRfsrXufzIPvhS;

		public int vvQCzKGGpzmOizMwPnDCbINDJSp;

		public int ESGbzONccYUbeabLlZTZqvOaPiV;

		public int VDigxggFZFmJJbVZDXwqVpDRboVC;

		public int zhWoOaYjyJhPKLcIXOKZSKTUCez;

		public int yElhwMgNPuoirlqrbnJCWrsMpNKe;

		public int RXwOOIIxkWFOMPvQXPXfjFSOYlY;

		public int ALoTMZYheGjBwydAzsiKwctgjHp;

		public int mLaUfUenARAFFBtRZmDMfFMCgjCP;

		public int bAFpLEvuzhFZvZLhMsadixToQGl;

		public char fdLSfztcvopznPFXfPyaNKdFmGL;

		public char rkUTIuFzfccqelIHrejcFZKGvSn;

		public char EKGnKpIgDbASaeoHseffgGjJqsK;

		public char hoiMqutRcrfApXHPpaIsnnWPFEH;

		public byte knVflsgjQXjErvnQMEHxaonCOghl;

		public byte zzGTjYqgQiVYZhMVUihcwRgtpcB;

		public byte sdOIGZVUFWfLvvgwgqDTDOCmUbC;

		public byte OIPBRoblsDRprhmYQbZnxronEYJ;

		public byte gJwlWwWCsAVcUrZrPefnkpEFIRkb;
	}

	internal enum zPOCPaHmHblMOcOAMgXFBQqlwUS
	{
		SKRvzQSHgIEBgwIYQAoOmdXStap = -4,
		zVBfaBMuSBAnXUnPsFYzARrrtKw = -6,
		QLNnDmdESJgdXiuWglrpMyrHCihz = -8,
		lukgeTeUHEJAxyCWqllxFvdUfqFx = -16,
		BCgXwauZcWKxUPjQttUjBzsqhBo = -20,
		MshxHuLZlJCAxRGMSXczZLezleh = -21,
		cpdoTOKDayDGZuebsJhRjhFeMsu = -12
	}

	internal delegate IntPtr bzufBQnWsEGlOeXXpgNTjrurwuMP(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool DOJalSDhdoWlzXCpjjGYTiXBwny(IntPtr hwnd, IntPtr lParam);

	private static IntPtr rMuaLDfFTUuFIHvODEHxuSzlVRy = IntPtr.Zero;

	private static List<IntPtr> YcgWdmExqqeQlgFoAoTLDgsfWAU;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int cPYpduNzJLaGcphoAeOxKBuhUUA(out rjVSeXOjUgeSNJOiiESvjCCOhGNc P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int OfFKVdNFRzvSKzFoZIfwDqAKkI(out rjVSeXOjUgeSNJOiiESvjCCOhGNc P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int VXehdLcArHUbNrOrWHBeozHxpYx(ref rjVSeXOjUgeSNJOiiESvjCCOhGNc P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ltYrwThCYSvFcWfZDRVcBMIMdeP(ref rjVSeXOjUgeSNJOiiESvjCCOhGNc P_0);

	public static IntPtr mIcfmROfUnqGxOdljRQshbYfeZD(HandleRef P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1)
	{
		if (IntPtr.Size == 4)
		{
			return IusSLkScnLiYofYAeHTdcCnJITk(P_0, P_1);
		}
		return AghYAcxDqPGxhOiXchSIHjUCUza(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr tQkqbzntvxhEpDXXGKbmrrmyrsj();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr IusSLkScnLiYofYAeHTdcCnJITk(HandleRef P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr AghYAcxDqPGxhOiXchSIHjUCUza(HandleRef P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1);

	public static IntPtr DRWfdJpjpYgVyRfznqMBraKjmlX(HandleRef P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return mjiNnqkcOKAcOdIbfWPwwmsLqoEb(P_0, P_1, P_2);
		}
		return RspFViTPqfwmTqRgqtiqzuIveXN(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr ipPOsMoBiryPuEaIXnIKeYeVpgB(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr mjiNnqkcOKAcOdIbfWPwwmsLqoEb(HandleRef P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1, IntPtr P_2);

	public static bool MKGQNfjfykwGXrioIwFyrFHXnFj(HandleRef P_0, bool P_1)
	{
		return MKGQNfjfykwGXrioIwFyrFHXnFj(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool MKGQNfjfykwGXrioIwFyrFHXnFj(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr RspFViTPqfwmTqRgqtiqzuIveXN(HandleRef P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr lmIFqBFHfPjoSGqaevsdloGxHlNe(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr MnYnUiyRhFiFpWhLyRxlFGptwaQ(string P_0);

	public static IntPtr mIcfmROfUnqGxOdljRQshbYfeZD(IntPtr P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1)
	{
		if (IntPtr.Size == 4)
		{
			return IusSLkScnLiYofYAeHTdcCnJITk(P_0, P_1);
		}
		return AghYAcxDqPGxhOiXchSIHjUCUza(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr IusSLkScnLiYofYAeHTdcCnJITk(IntPtr P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr AghYAcxDqPGxhOiXchSIHjUCUza(IntPtr P_0, zPOCPaHmHblMOcOAMgXFBQqlwUS P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool tnpXovapZeMTkjrIXoysdQnNfdq(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr uapcxzBOCaDXbFTZHierdwXxuwtY();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint aBoBNdLUrXDhQQzscRMlJddohqFB();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool aQeWLyLAJbiJSaGaxYhkYpuMiQI(IntPtr P_0, IntPtr P_1);

	private static bool FaNoEnlikvfrwHxKfgstgfjXmgdi(IntPtr P_0, IntPtr P_1)
	{
		lock (YcgWdmExqqeQlgFoAoTLDgsfWAU)
		{
			YcgWdmExqqeQlgFoAoTLDgsfWAU.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint EnKDFzjKNtdtPxoBsAaDicsmmhI(IntPtr P_0, out uint P_1);

	public static IntPtr YABwwXHSsTojcscsIpnzfwQpmnR()
	{
		if (rMuaLDfFTUuFIHvODEHxuSzlVRy != IntPtr.Zero)
		{
			return rMuaLDfFTUuFIHvODEHxuSzlVRy;
		}
		YcgWdmExqqeQlgFoAoTLDgsfWAU = new List<IntPtr>();
		uint num = aBoBNdLUrXDhQQzscRMlJddohqFB();
		DOJalSDhdoWlzXCpjjGYTiXBwny dOJalSDhdoWlzXCpjjGYTiXBwny = FaNoEnlikvfrwHxKfgstgfjXmgdi;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate((Delegate)dOJalSDhdoWlzXCpjjGYTiXBwny);
		aQeWLyLAJbiJSaGaxYhkYpuMiQI(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(dOJalSDhdoWlzXCpjjGYTiXBwny);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < YcgWdmExqqeQlgFoAoTLDgsfWAU.Count; i++)
		{
			if (tnpXovapZeMTkjrIXoysdQnNfdq(YcgWdmExqqeQlgFoAoTLDgsfWAU[i]))
			{
				EnKDFzjKNtdtPxoBsAaDicsmmhI(YcgWdmExqqeQlgFoAoTLDgsfWAU[i], out var num2);
				if (num2 == num)
				{
					rMuaLDfFTUuFIHvODEHxuSzlVRy = YcgWdmExqqeQlgFoAoTLDgsfWAU[i];
					YcgWdmExqqeQlgFoAoTLDgsfWAU.Clear();
					return rMuaLDfFTUuFIHvODEHxuSzlVRy;
				}
			}
		}
		return uapcxzBOCaDXbFTZHierdwXxuwtY();
	}
}
