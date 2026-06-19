using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class yIabpWBLUyYebHgTTZZdQbaydnSL
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class cozUfnyBOVQpvOvkorAyyREauPEt
	{
		public int ZJaCIRVrkwFCANIdCcHDBaNctzApA;

		public int NVePJNBAJqkHbPHJQvmXqeLLYDVP;

		public int iTuexUHhEKekGMJdPCPCDPqvzyNf;

		public int HKcBCawWIWDOSGrxJZQJRhKhxAVq;

		public int LMDOHjYmbSKfDItptUNNxUYaRJIm;

		public byte aLwaezNvoSVwhMrdiVAPBrYRbgJE;

		public byte mlWOKzdfjkVwJZbSqEXUFUWMYkkd;

		public byte OypzozSthoWpxANbtMJObFeQFMFkA;

		public byte olpqaffxyovDacTimfdCkbMOofgf;

		public byte WJplkVlwHTOkHOgZfkIZhOsvElZj;

		public byte dOzXzMKBiyLCDXqLAgeWDgXysgmW;

		public byte rbOLPVHVKgniZkGNlwBJFMZTKKGb;

		public byte VpfBocHSPcpnxXIqExfaqmhFahCgb;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string AkWJmZSmgkXqhJgZICDREnWWADmab;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct LxYUXrCTUlZntRjkkvPSDrslNgtD
	{
		public int fsdwPiWfCiZCXUcSonkRtPnkCkNR;

		public int NceGcmOmdKdhKomYCpuFkYgoOrdG;

		public int SnvAIrttTcFQoBHLDLGRqkiOcId;

		public int QdSGFFcdDtblzAeaksNXEtNARWOZb;

		public int rsGpNKNXlAXKkatLhvVlZTtufrVA;

		public int ZyrxQTMiDDIOMjvLOBavhaKporOb;

		public int OFDPbIxtliUSdMwAzsMUigGmNNfX;

		public int mqhizOXoHgGuhiBsedeqbxaXrbUl;

		public int DFWMRoGkRnaqUxLybWKInnlHetNjA;

		public int oAUocrhHDNMCTjYuAckRfVKeXqMf;

		public int GHWeJCVtTGMvVmpWsFebQWoBDFvHA;

		public char PGeQCZchCfypxVapqhAagriVYzfN;

		public char lGbcRoiYsZIpSANtvZJjCuSjClZb;

		public char BShaMmajIwCjWRKkhOSPzDJRUspk;

		public char wPywGzSzvvbXHbCcZBSsKJSbcJnGb;

		public byte PBdHcpaVTAJKGhOdPWiCLOgMxYPMA;

		public byte FfSueUMKWXBIvkEtfmOZpRXAVpJf;

		public byte mXyBlyEYPuvuhAonREKHAkwTBQhP;

		public byte MYyDMsaXAGLqYNPEmQHSOEKbeuVM;

		public byte owtjPDQWvhxZXgRBqYfXQKXtuliA;
	}

	internal enum ZxKaUtexgsAhCkglvMPOHVDhTZkgB
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr WtziNqjyhLqHsRFyDiRxmAAJWoft(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool yKwHCBTLqrRqGcJQECzbokQyqTBY(IntPtr hwnd, IntPtr lParam);

	private static IntPtr eWqYKnLKoxOiuNRCrWtLaiPHduSfA = IntPtr.Zero;

	private static List<IntPtr> RhMECWnfUdsNWuhyodmABPERtgzi;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int jhzqsRyssedUhMfjBDtCAhEwEqnV(out xvHrjcoZIaZsgveBPtDtIhdelGZi P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int RQJuOdNtsSfZfdMALfUAJavCpRFm(out xvHrjcoZIaZsgveBPtDtIhdelGZi P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int KgeIHkvMxGUxGFDEXxubrCmdLWji(ref xvHrjcoZIaZsgveBPtDtIhdelGZi P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int HJsAkMBqPGFIKZdxVtxFNGHDJquZ(ref xvHrjcoZIaZsgveBPtDtIhdelGZi P_0);

	public static IntPtr tnZrliYVvotHIyZbvPqcyXyBSsjv(HandleRef P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1)
	{
		if (IntPtr.Size == 4)
		{
			return kNeDnJhWDIaWEYWtxkrTbnqATKRBA(P_0, P_1);
		}
		return PyhFqkvofJtizrztlMpmYATiRegk(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr AgURTjAQiWrUsHDzYrMzZzUsMVPv();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr kNeDnJhWDIaWEYWtxkrTbnqATKRBA(HandleRef P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr PyhFqkvofJtizrztlMpmYATiRegk(HandleRef P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1);

	public static IntPtr bogZaOZFOfOkNuViCQXVJtxQeHWy(HandleRef P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return zBqUhTmjORBNIVxJWfIWfBnxsAbH(P_0, P_1, P_2);
		}
		return jClppxGVnXtGZHsNMZAnaETXjnFh(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr MykRIIcRSxwORnbmfuMIBGjFavVx(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr zBqUhTmjORBNIVxJWfIWfBnxsAbH(HandleRef P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1, IntPtr P_2);

	public static bool bfzmpySgATTWdRMVwGcEkZCvhteG(HandleRef P_0, bool P_1)
	{
		return hgWDdAayrjCYLrnCWMTJXPTPYSjO(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool hgWDdAayrjCYLrnCWMTJXPTPYSjO(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr jClppxGVnXtGZHsNMZAnaETXjnFh(HandleRef P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr ASZmikwpwVetTLWFzLTmnvGpBGds(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr rexTqgQuyEQsOaxzDDmXhLvPLagf(string P_0);

	public static IntPtr NSUBbOXNKqbLutKJMAtiJyeSclYTA(IntPtr P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1)
	{
		if (IntPtr.Size == 4)
		{
			return YrJFsiDyZvXCvjqmhiNSOpcuSdJCb(P_0, P_1);
		}
		return NdjHQcIAecixOOwoTgcqHZDlBwoVA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr YrJFsiDyZvXCvjqmhiNSOpcuSdJCb(IntPtr P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr NdjHQcIAecixOOwoTgcqHZDlBwoVA(IntPtr P_0, ZxKaUtexgsAhCkglvMPOHVDhTZkgB P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool BaqxZKyQrzUTLVLMucOHVjCHAUBV(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr MYGBIWbGohDgVyCRbfXFJxyovJuwA();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint hIALngykgiYAusYrwbitpSlajFOI();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool LIWHfWzbXyWtjSvaMivceNMSnqmr(IntPtr P_0, IntPtr P_1);

	private static bool VUnAparAVbFQzJoxachtdEumxSvWA(IntPtr P_0, IntPtr P_1)
	{
		lock (RhMECWnfUdsNWuhyodmABPERtgzi)
		{
			RhMECWnfUdsNWuhyodmABPERtgzi.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint LTHrHWOAshamqRByfpUHjWxnAJCj(IntPtr P_0, out uint P_1);

	public static IntPtr bireMZoXwzkZlObWpEWgbMwqITbs()
	{
		if (eWqYKnLKoxOiuNRCrWtLaiPHduSfA != IntPtr.Zero)
		{
			return eWqYKnLKoxOiuNRCrWtLaiPHduSfA;
		}
		RhMECWnfUdsNWuhyodmABPERtgzi = new List<IntPtr>();
		uint num = hIALngykgiYAusYrwbitpSlajFOI();
		yKwHCBTLqrRqGcJQECzbokQyqTBY obj = VUnAparAVbFQzJoxachtdEumxSvWA;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(obj);
		LIWHfWzbXyWtjSvaMivceNMSnqmr(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(obj);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < RhMECWnfUdsNWuhyodmABPERtgzi.Count; i++)
		{
			if (BaqxZKyQrzUTLVLMucOHVjCHAUBV(RhMECWnfUdsNWuhyodmABPERtgzi[i]))
			{
				LTHrHWOAshamqRByfpUHjWxnAJCj(RhMECWnfUdsNWuhyodmABPERtgzi[i], out var num2);
				if (num2 == num)
				{
					eWqYKnLKoxOiuNRCrWtLaiPHduSfA = RhMECWnfUdsNWuhyodmABPERtgzi[i];
					RhMECWnfUdsNWuhyodmABPERtgzi.Clear();
					return eWqYKnLKoxOiuNRCrWtLaiPHduSfA;
				}
			}
		}
		return MYGBIWbGohDgVyCRbfXFJxyovJuwA();
	}
}
