using System;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class IPNZOvMlSasjEEMEsInJToOiseY : kiUcNJVlbDiUFZMANgySDecsoISU
{
	internal class iFROqoglgPldJfWtvQLpPoJmFbTg : DhfnTXocDlpvnmvADoLLNcCucRl
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int xzhOXxZjsHsEwXTRGdeRGCdNDCI(IntPtr thisObject, IntPtr guid, out IntPtr output);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int cYlZNnHbrTPoVGbtqvFpQTSUBzV(IntPtr thisObject);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int UUMvjYpTTvZkhjfCmrDqhtRiaca(IntPtr thisObject);

		public iFROqoglgPldJfWtvQLpPoJmFbTg(int numberOfCallbackMethods)
			: base(numberOfCallbackMethods + 3)
		{
			lBHNSZbAVNerRAfkRkIsFHtcvewn(new xzhOXxZjsHsEwXTRGdeRGCdNDCI(sSEbiKfBmtAoBIqUEfwkOxuBQpQg));
			lBHNSZbAVNerRAfkRkIsFHtcvewn(new cYlZNnHbrTPoVGbtqvFpQTSUBzV(LkQyRWOVPEANUVjKxZwLtSXwmJs));
			lBHNSZbAVNerRAfkRkIsFHtcvewn(new UUMvjYpTTvZkhjfCmrDqhtRiaca(UBBuctzjgaNSxImtaESQwISrtUD));
		}

		protected unsafe static int sSEbiKfBmtAoBIqUEfwkOxuBQpQg(IntPtr P_0, IntPtr P_1, out IntPtr P_2)
		{
			IPNZOvMlSasjEEMEsInJToOiseY iPNZOvMlSasjEEMEsInJToOiseY = kiUcNJVlbDiUFZMANgySDecsoISU.fOCcfhJusOxlKwqUfroEWJdFgRmw<IPNZOvMlSasjEEMEsInJToOiseY>(P_0);
			if (iPNZOvMlSasjEEMEsInJToOiseY == null)
			{
				P_2 = IntPtr.Zero;
				return oAEDXrvvcKPxxNzmMhHOiHFnkWH.tuLqLfyFLLDagfCyDYZzEDVWxvSJ.Code;
			}
			return iPNZOvMlSasjEEMEsInJToOiseY.sSEbiKfBmtAoBIqUEfwkOxuBQpQg(P_0, ref *(Guid*)(void*)P_1, out P_2);
		}

		protected static int LkQyRWOVPEANUVjKxZwLtSXwmJs(IntPtr P_0)
		{
			return kiUcNJVlbDiUFZMANgySDecsoISU.fOCcfhJusOxlKwqUfroEWJdFgRmw<IPNZOvMlSasjEEMEsInJToOiseY>(P_0)?.LkQyRWOVPEANUVjKxZwLtSXwmJs(P_0) ?? 0;
		}

		protected static int UBBuctzjgaNSxImtaESQwISrtUD(IntPtr P_0)
		{
			return kiUcNJVlbDiUFZMANgySDecsoISU.fOCcfhJusOxlKwqUfroEWJdFgRmw<IPNZOvMlSasjEEMEsInJToOiseY>(P_0)?.UBBuctzjgaNSxImtaESQwISrtUD(P_0) ?? 0;
		}
	}

	private int UaLjEPWmqQWsTdOsIYpzlleKhHQ = 1;

	public static Guid PtSWpVHSVmgYSmhRHbuiDnAFumD = new Guid("00000000-0000-0000-C000-000000000046");

	protected int sSEbiKfBmtAoBIqUEfwkOxuBQpQg(IntPtr P_0, ref Guid P_1, out IntPtr P_2)
	{
		IPNZOvMlSasjEEMEsInJToOiseY iPNZOvMlSasjEEMEsInJToOiseY = (IPNZOvMlSasjEEMEsInJToOiseY)((rbxRGgVbdVaTzhNUZzcznsHGKjRo)base.Callback.Shadow).YDpmQdsvnmlqyHPHyoYFZbXeodP(P_1);
		if (iPNZOvMlSasjEEMEsInJToOiseY != null)
		{
			iPNZOvMlSasjEEMEsInJToOiseY.LkQyRWOVPEANUVjKxZwLtSXwmJs(P_0);
			P_2 = iPNZOvMlSasjEEMEsInJToOiseY.NativePointer;
			return oAEDXrvvcKPxxNzmMhHOiHFnkWH.RDGxlxZiaMwWhuFlumYUYtWgHJJ.Code;
		}
		P_2 = IntPtr.Zero;
		return oAEDXrvvcKPxxNzmMhHOiHFnkWH.tuLqLfyFLLDagfCyDYZzEDVWxvSJ.Code;
	}

	protected virtual int LkQyRWOVPEANUVjKxZwLtSXwmJs(IntPtr P_0)
	{
		return Interlocked.Increment(ref UaLjEPWmqQWsTdOsIYpzlleKhHQ);
	}

	protected virtual int UBBuctzjgaNSxImtaESQwISrtUD(IntPtr P_0)
	{
		return Interlocked.Decrement(ref UaLjEPWmqQWsTdOsIYpzlleKhHQ);
	}
}
