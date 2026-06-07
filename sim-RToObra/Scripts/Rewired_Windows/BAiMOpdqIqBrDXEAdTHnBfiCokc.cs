using System;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class BAiMOpdqIqBrDXEAdTHnBfiCokc : dDFAwakRIfhZuEMJAlIIyVPSACy
{
	internal class lSqmFCdBAuMymQQnNIAODTiydFm : WZmAcmTOKJBWCvtjWGhZBJHWdeXD
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int qlYfomfGhOZhAHtgwNzUjHruUxi(IntPtr thisObject, IntPtr guid, out IntPtr output);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int rXQITauACnXHTsyCCFfguoMlHJH(IntPtr thisObject);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int jcKCtDPBdCFnaMUqUYccESyeEMN(IntPtr thisObject);

		public lSqmFCdBAuMymQQnNIAODTiydFm(int numberOfCallbackMethods)
			: base(numberOfCallbackMethods + 3)
		{
			uDKiPoBQnnPQqLgqMdXgjXYVZsWq(new qlYfomfGhOZhAHtgwNzUjHruUxi(nAPsnlsMWRGTetGSwyhwltXaCxw));
			uDKiPoBQnnPQqLgqMdXgjXYVZsWq(new rXQITauACnXHTsyCCFfguoMlHJH(UhRDSttBjkZklEiAeinDDlsSxsQk));
			uDKiPoBQnnPQqLgqMdXgjXYVZsWq(new jcKCtDPBdCFnaMUqUYccESyeEMN(DpCvILKSLUiJfHGcckTSgbpeHrwc));
		}

		protected unsafe static int nAPsnlsMWRGTetGSwyhwltXaCxw(IntPtr P_0, IntPtr P_1, out IntPtr P_2)
		{
			BAiMOpdqIqBrDXEAdTHnBfiCokc bAiMOpdqIqBrDXEAdTHnBfiCokc = dDFAwakRIfhZuEMJAlIIyVPSACy.oDRriCDNYkKQfzGKkBdMcXKrcTKX<BAiMOpdqIqBrDXEAdTHnBfiCokc>(P_0);
			if (bAiMOpdqIqBrDXEAdTHnBfiCokc == null)
			{
				P_2 = IntPtr.Zero;
				return jYVOPQCYHiqgKMeoByaWkMeLSnl.ymSCQKXrphiDRDDeSCEbyPwyJtcG.Code;
			}
			return bAiMOpdqIqBrDXEAdTHnBfiCokc.nAPsnlsMWRGTetGSwyhwltXaCxw(P_0, ref *(Guid*)(void*)P_1, out P_2);
		}

		protected static int UhRDSttBjkZklEiAeinDDlsSxsQk(IntPtr P_0)
		{
			BAiMOpdqIqBrDXEAdTHnBfiCokc bAiMOpdqIqBrDXEAdTHnBfiCokc = dDFAwakRIfhZuEMJAlIIyVPSACy.oDRriCDNYkKQfzGKkBdMcXKrcTKX<BAiMOpdqIqBrDXEAdTHnBfiCokc>(P_0);
			if (bAiMOpdqIqBrDXEAdTHnBfiCokc == null)
			{
				return 0;
			}
			return bAiMOpdqIqBrDXEAdTHnBfiCokc.UhRDSttBjkZklEiAeinDDlsSxsQk(P_0);
		}

		protected static int DpCvILKSLUiJfHGcckTSgbpeHrwc(IntPtr P_0)
		{
			BAiMOpdqIqBrDXEAdTHnBfiCokc bAiMOpdqIqBrDXEAdTHnBfiCokc = dDFAwakRIfhZuEMJAlIIyVPSACy.oDRriCDNYkKQfzGKkBdMcXKrcTKX<BAiMOpdqIqBrDXEAdTHnBfiCokc>(P_0);
			if (bAiMOpdqIqBrDXEAdTHnBfiCokc == null)
			{
				return 0;
			}
			return bAiMOpdqIqBrDXEAdTHnBfiCokc.DpCvILKSLUiJfHGcckTSgbpeHrwc(P_0);
		}
	}

	private int LlGSLitmKucTsjicFBqvdrBawTmD = 1;

	public static Guid IsPfoeivlSuxhnsHEJvuHPtffwv = new Guid("00000000-0000-0000-C000-000000000046");

	protected int nAPsnlsMWRGTetGSwyhwltXaCxw(IntPtr P_0, ref Guid P_1, out IntPtr P_2)
	{
		BAiMOpdqIqBrDXEAdTHnBfiCokc bAiMOpdqIqBrDXEAdTHnBfiCokc = (BAiMOpdqIqBrDXEAdTHnBfiCokc)((gmwbVFwVVbYwAOUYGJvhsoowZxj)base.Callback.Shadow).JjoGRGdDBKzLHQSFbsVDtXyMvnpt(P_1);
		if (bAiMOpdqIqBrDXEAdTHnBfiCokc != null)
		{
			bAiMOpdqIqBrDXEAdTHnBfiCokc.UhRDSttBjkZklEiAeinDDlsSxsQk(P_0);
			P_2 = bAiMOpdqIqBrDXEAdTHnBfiCokc.NativePointer;
			return jYVOPQCYHiqgKMeoByaWkMeLSnl.YvXJmEatEqGvAjZvpFZGKdhOIJfG.Code;
		}
		P_2 = IntPtr.Zero;
		return jYVOPQCYHiqgKMeoByaWkMeLSnl.ymSCQKXrphiDRDDeSCEbyPwyJtcG.Code;
	}

	protected virtual int UhRDSttBjkZklEiAeinDDlsSxsQk(IntPtr P_0)
	{
		return Interlocked.Increment(ref LlGSLitmKucTsjicFBqvdrBawTmD);
	}

	protected virtual int DpCvILKSLUiJfHGcckTSgbpeHrwc(IntPtr P_0)
	{
		return Interlocked.Decrement(ref LlGSLitmKucTsjicFBqvdrBawTmD);
	}
}
