using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class hqRAtWkFwRMrUFQFfrqkRHWrrJl
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class lRgNsHfGHLhpqCtXJKWJBqDrfyP
	{
		public int ofkjdEzHYAmNCnQvavJLPYGnunJ;

		public int BJBWPVlUQMMoZXAlcEhEIhHGirC;

		public int zEcnzkolHQuNjTDIgyTLjkfqAIc;

		public int uirdYgcjICYGwWneZgKfwysTKgwu;

		public int qaHZvdEahZxavfVPXRJJMioIDwF;

		public byte UKCENTvqXQYuYSBNsujlAaJHYKW;

		public byte UvnWyZmrEZFTkvkPBYsXTKvxmSv;

		public byte HNPJBibAkKAECqaUJLEdMklaIie;

		public byte XcwXvpIZzREzYXOZvCSEfHqpDTv;

		public byte KuJbqtZxpgGtmhCjebmArpkRpBpO;

		public byte ejhkDjQwdYTNNckRiePRcoBmLM;

		public byte PGBQCxXzlIWEcWJqBLEbFREppVE;

		public byte dCNxwWuUQVISuhuMFAVnjPagbeqJ;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string vJmLpnubVCzLJGFuMpxYMEdbTyq;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct ClFnBvsonqwfvjHWYTtJRLyTtQT
	{
		public int wnzkuUhHnGDKgiUQMfOekFdMKajU;

		public int YqxhcfMabFxvpQvBsQdIkPkhswS;

		public int iWjXJvFDVSfYcDTeUghTFoCenLCd;

		public int RWdGoEUFYXWerCHnOaXMfSetlIL;

		public int YeReOHEafykrRfAJSboxJqIOOnkE;

		public int cnjnfXNKSqALUjtOYFAESZQhnPCW;

		public int dFSbTbOAtDJOzKGzwJPXubnbuUd;

		public int OwkhDbHpFPtRIpIzPaZQisChHTK;

		public int PRVoYiLOHhHRgEYGgEcTduxJDoU;

		public int xEPkZhnVkizqZXTgQRxPERXXgbQ;

		public int ebwZmbwsPEPvdlyDJeeexKoVbJG;

		public char uBsaBKmjZVHJvvAJeqOfEcckDoq;

		public char sknEOFCwFNCKidLRsTbfaCHzONQQ;

		public char JjfHgUDHCQekwYrchMoavPaiqrv;

		public char avDYLDkcMSHJxkpFuYCztiFkQBqz;

		public byte dOkwVqlaMywjJLGpBVkOjkxhpOG;

		public byte ogfMGhbQwDfrVLuLDJotrNvAgwg;

		public byte rlFaeUorvnJnPactJlIChVPgcj;

		public byte TooZCLokOatXpLCATMLyigbEULw;

		public byte bDXZmJPhSbSECDOlEnHqlENmEEP;
	}

	internal enum jbZexQRBEonlhkMWEPOKVfqhCpQd
	{
		FQwjqIFMlpBaZKMILwGdtlahNsN = -4,
		kWcdusBkFaVcHuJApKquPqnIJDJ = -6,
		NgaOrNsdqeLlTUtAhxnynHouzZW = -8,
		sNRAnqPFxdnmzwkWbndcmFyrshe = -16,
		EdZhYPDhEdleMxrtikdwGQefNoHr = -20,
		FMAAfPULFkgMtndMFoXsOFfQlPQ = -21,
		rvIPxxNehPltJECfrQJKgcUDATZF = -12
	}

	internal delegate IntPtr LwIwQAoiTCvmEhOaTpvaMNySbgka(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool MWqgGRaDQXFSPDqKgAqtCCfGwqlj(IntPtr hwnd, IntPtr lParam);

	private static IntPtr etBhGkiynzcvWfnGOFBmufcIzSBq = IntPtr.Zero;

	private static List<IntPtr> ZWXoYXBOWRsbnShoXNrAMzvIHaz;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int rOxwyNIYlwiCoTRmDVMwNLdOEVt(out eCunziDNsFuCFfjqzGGuHaFxpXo P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ZcMjWzqIpwMJrkclbIPoDxEvcZvc(out eCunziDNsFuCFfjqzGGuHaFxpXo P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int IFlmuSnNcORHfRbZdFxXtIIITAU(ref eCunziDNsFuCFfjqzGGuHaFxpXo P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int mmfdHmeHmjpfksPFIFPlYaThpQs(ref eCunziDNsFuCFfjqzGGuHaFxpXo P_0);

	public static IntPtr xHBNqgPOuCeQzEsleLDbToBMqGyy(HandleRef P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1)
	{
		if (IntPtr.Size == 4)
		{
			return VZZoZZNNUwuYqNAYfdXozmXueTX(P_0, P_1);
		}
		return DgOHeVoqSyHhvgJBlYaHcfZdCkX(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr sjRecMcgTOklbzOJZjMpwunTtII();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr VZZoZZNNUwuYqNAYfdXozmXueTX(HandleRef P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr DgOHeVoqSyHhvgJBlYaHcfZdCkX(HandleRef P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1);

	public static IntPtr WrvwiumnVpRrknOzqfIQjkRUvaiT(HandleRef P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return xjLiMJdFcjQCWgtreTDjztrafXt(P_0, P_1, P_2);
		}
		return GtEKTyWSTCUZHYwkdgdTgPAWpgg(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr zPqzrtfIICxOcooSOEmHzftobKe(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr xjLiMJdFcjQCWgtreTDjztrafXt(HandleRef P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1, IntPtr P_2);

	public static bool ZjdELCsIaVyBFVFkDZTbwLUaUuU(HandleRef P_0, bool P_1)
	{
		return ZjdELCsIaVyBFVFkDZTbwLUaUuU(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool ZjdELCsIaVyBFVFkDZTbwLUaUuU(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr GtEKTyWSTCUZHYwkdgdTgPAWpgg(HandleRef P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr gGxhDgOROiMLYGkWnwoVpXCUwEo(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr RUtOyDvBfqcIhiehjqJqIuNUMbr(string P_0);

	public static IntPtr xHBNqgPOuCeQzEsleLDbToBMqGyy(IntPtr P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1)
	{
		if (IntPtr.Size == 4)
		{
			return VZZoZZNNUwuYqNAYfdXozmXueTX(P_0, P_1);
		}
		return DgOHeVoqSyHhvgJBlYaHcfZdCkX(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr VZZoZZNNUwuYqNAYfdXozmXueTX(IntPtr P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr DgOHeVoqSyHhvgJBlYaHcfZdCkX(IntPtr P_0, jbZexQRBEonlhkMWEPOKVfqhCpQd P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool sUINSIpoBDQywHGfUGanihFqIuNi(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr bVQBuQKNiTydnjTTUAaqfzWItVQ();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint bhPZGUUMRgGZOstafjWcWqgBEdsB();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool lPDDNqGZsSnODCdEixQmZPafFvx(IntPtr P_0, IntPtr P_1);

	private static bool KvcTJSacYSVOixSMeufqmyamvEE(IntPtr P_0, IntPtr P_1)
	{
		lock (ZWXoYXBOWRsbnShoXNrAMzvIHaz)
		{
			ZWXoYXBOWRsbnShoXNrAMzvIHaz.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint BOnEWFgxPIHNRJLtWeCDpnjZyld(IntPtr P_0, out uint P_1);

	public static IntPtr BwcrcaWbYgaFuQmgRzzaiBJGcym()
	{
		if (etBhGkiynzcvWfnGOFBmufcIzSBq != IntPtr.Zero)
		{
			return etBhGkiynzcvWfnGOFBmufcIzSBq;
		}
		ZWXoYXBOWRsbnShoXNrAMzvIHaz = new List<IntPtr>();
		uint num = bhPZGUUMRgGZOstafjWcWqgBEdsB();
		MWqgGRaDQXFSPDqKgAqtCCfGwqlj mWqgGRaDQXFSPDqKgAqtCCfGwqlj = KvcTJSacYSVOixSMeufqmyamvEE;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate((Delegate)mWqgGRaDQXFSPDqKgAqtCCfGwqlj);
		lPDDNqGZsSnODCdEixQmZPafFvx(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(mWqgGRaDQXFSPDqKgAqtCCfGwqlj);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < ZWXoYXBOWRsbnShoXNrAMzvIHaz.Count; i++)
		{
			if (sUINSIpoBDQywHGfUGanihFqIuNi(ZWXoYXBOWRsbnShoXNrAMzvIHaz[i]))
			{
				uint num2;
				BOnEWFgxPIHNRJLtWeCDpnjZyld(ZWXoYXBOWRsbnShoXNrAMzvIHaz[i], out num2);
				if (num2 == num)
				{
					etBhGkiynzcvWfnGOFBmufcIzSBq = ZWXoYXBOWRsbnShoXNrAMzvIHaz[i];
					ZWXoYXBOWRsbnShoXNrAMzvIHaz.Clear();
					return etBhGkiynzcvWfnGOFBmufcIzSBq;
				}
			}
		}
		return bVQBuQKNiTydnjTTUAaqfzWItVQ();
	}
}
