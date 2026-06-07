using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class PmrZfrakdcsxJSCJTRJsLZsHYGLg : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr swQunYcAaPOYCSXFkUZftLKfXwUb(int nCode, IntPtr wParam, IntPtr lParam);

	private struct pzTBXHDeDmPtTLqtgsGrpLjiiqGF
	{
		public IntPtr iaJfNtmhxcewdVgBXleKKnfDyNAQ;

		public IntPtr GDONQZsKKrMRpypbdYpRfhGbAmLr;

		public uint mvZKNIXlexVdGNxCpxocxxUzgdYe;

		public IntPtr YueOfBnXviKfBzhCgjEDJtFFKFhdA;
	}

	private const int zsGaQvjAiTicXRuqkAKIEoMQjDlDA = 4;

	private static PmrZfrakdcsxJSCJTRJsLZsHYGLg VcHMtThXMOrYvYYPjcuHTFyyJWpR;

	private IntPtr POCujncgBVyyqXLIIDoZrlluVqEo = IntPtr.Zero;

	private swQunYcAaPOYCSXFkUZftLKfXwUb krVFkCdRKIblOvJtNZPvVamrPfgVA;

	private Action<FIXCKzgneAAFGzHVxItceEgisGfLA, OHRjBiOQHgDSIYOkYVxJaSngpGAe, uint, IntPtr> JWoxSqeyssnBVwCJPlnzBcyfDwObA;

	private byte[] XXzVssPsqIEBrBKYRPWZurkGNfuk;

	private readonly bool PoRDThbTfQnpEpZRYIHRnFVFCTEm;

	private pzTBXHDeDmPtTLqtgsGrpLjiiqGF MrGRQDGzixwEnWRakXgWAcuXGZTM;

	private bool LmymkhNYOLtNYVFTPoIBRCmeFkeBA;

	public PmrZfrakdcsxJSCJTRJsLZsHYGLg()
	{
		if (VcHMtThXMOrYvYYPjcuHTFyyJWpR != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		VcHMtThXMOrYvYYPjcuHTFyyJWpR = this;
		PoRDThbTfQnpEpZRYIHRnFVFCTEm = IntPtr.Size == 8;
		XXzVssPsqIEBrBKYRPWZurkGNfuk = new byte[IntPtr.Size * 3 + 4];
	}

	public void SxIrCOebkGaYhhznxPbjgLegASWI(Action<FIXCKzgneAAFGzHVxItceEgisGfLA, OHRjBiOQHgDSIYOkYVxJaSngpGAe, uint, IntPtr> P_0, bool P_1)
	{
		JWoxSqeyssnBVwCJPlnzBcyfDwObA = P_0;
		krVFkCdRKIblOvJtNZPvVamrPfgVA = vhCvMGKwDJyezokETkQHJBqnBefJ;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		POCujncgBVyyqXLIIDoZrlluVqEo = bqRgBmaoAFhCjMptoRhpEovlQLYgA(4, krVFkCdRKIblOvJtNZPvVamrPfgVA, IntPtr.Zero, num);
		if (POCujncgBVyyqXLIIDoZrlluVqEo == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void aEDhyqTVOZDdubQztfzdXCsUdyYD()
	{
		if (!(POCujncgBVyyqXLIIDoZrlluVqEo == IntPtr.Zero))
		{
			if (!sSsxEYzxojxCuCcMPNhkvwprSkls(POCujncgBVyyqXLIIDoZrlluVqEo))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				POCujncgBVyyqXLIIDoZrlluVqEo = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(swQunYcAaPOYCSXFkUZftLKfXwUb))]
	private static IntPtr vhCvMGKwDJyezokETkQHJBqnBefJ(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk, 0, VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk.Length);
		int num = 0;
		VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.iaJfNtmhxcewdVgBXleKKnfDyNAQ = FIXCKzgneAAFGzHVxItceEgisGfLA.jRliteUpMIrOZOxMWygWxCZQSgiE(FIXCKzgneAAFGzHVxItceEgisGfLA.qWnCaqbUFOCBswIFRlDCkgSoGxRfb(VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk, num));
		num += FIXCKzgneAAFGzHVxItceEgisGfLA.NmyrfXxjLuUrZHExlMArZEGMcHGQ;
		VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.GDONQZsKKrMRpypbdYpRfhGbAmLr = OHRjBiOQHgDSIYOkYVxJaSngpGAe.gEDIrApYDatuDUtmOMhOwLhqdJhG(OHRjBiOQHgDSIYOkYVxJaSngpGAe.RyOkPgTggMRnRBPKGefNIJPelevk(VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk, num));
		num += OHRjBiOQHgDSIYOkYVxJaSngpGAe.gNyFYBjOezjUTHkjcyIlWPJKctbeb;
		VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.mvZKNIXlexVdGNxCpxocxxUzgdYe = BitConverter.ToUInt32(VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk, num);
		num += 4;
		if (VcHMtThXMOrYvYYPjcuHTFyyJWpR.PoRDThbTfQnpEpZRYIHRnFVFCTEm)
		{
			VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.YueOfBnXviKfBzhCgjEDJtFFKFhdA = new IntPtr(BitConverter.ToInt32(VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk, num + 4));
		}
		else
		{
			VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.YueOfBnXviKfBzhCgjEDJtFFKFhdA = new IntPtr(BitConverter.ToInt32(VcHMtThXMOrYvYYPjcuHTFyyJWpR.XXzVssPsqIEBrBKYRPWZurkGNfuk, num));
		}
		if (P_0 >= 0)
		{
			VcHMtThXMOrYvYYPjcuHTFyyJWpR.JWoxSqeyssnBVwCJPlnzBcyfDwObA(FIXCKzgneAAFGzHVxItceEgisGfLA.buSKCRRJdTDIzKWmjyxakASJyjbr(VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.iaJfNtmhxcewdVgBXleKKnfDyNAQ), OHRjBiOQHgDSIYOkYVxJaSngpGAe.ZtoAmugAdPqDKVmpUbCCRQaCJxmo(VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.GDONQZsKKrMRpypbdYpRfhGbAmLr), VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.mvZKNIXlexVdGNxCpxocxxUzgdYe, VcHMtThXMOrYvYYPjcuHTFyyJWpR.MrGRQDGzixwEnWRakXgWAcuXGZTM.YueOfBnXviKfBzhCgjEDJtFFKFhdA);
		}
		return DvDvZdnREYgHdKoLxWDGGxXyISTA(VcHMtThXMOrYvYYPjcuHTFyyJWpR.POCujncgBVyyqXLIIDoZrlluVqEo, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		VfDCxUMcHSkKgjPtJnIBSVOzspyg(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void krYJJWnXIRfwbKZhCGLpMnCFASmeA()
	{
		try
		{
			VfDCxUMcHSkKgjPtJnIBSVOzspyg(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void VfDCxUMcHSkKgjPtJnIBSVOzspyg(bool P_0)
	{
		if (!LmymkhNYOLtNYVFTPoIBRCmeFkeBA)
		{
			aEDhyqTVOZDdubQztfzdXCsUdyYD();
			if (VcHMtThXMOrYvYYPjcuHTFyyJWpR == this)
			{
				VcHMtThXMOrYvYYPjcuHTFyyJWpR = null;
			}
			LmymkhNYOLtNYVFTPoIBRCmeFkeBA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr bqRgBmaoAFhCjMptoRhpEovlQLYgA(int P_0, swQunYcAaPOYCSXFkUZftLKfXwUb P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool sSsxEYzxojxCuCcMPNhkvwprSkls(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr DvDvZdnREYgHdKoLxWDGGxXyISTA(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
