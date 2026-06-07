using System;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class GwRCdDVnMlcbisRiTXyMToiJxJP : iOSaYhIovYBYpfiucOzLiKYFEPX
{
	internal class bOWmLRADAgGETaDjoImrwRTnVgv : PojoqhxAgqdkLQGTsHxSXVOZQji
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int wzwqGDBEjpciWofNKWkdtJruLUa(IntPtr thisObject, IntPtr guid, out IntPtr output);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int maveVuFGUbUAwFxOONfDXErjMac(IntPtr thisObject);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int AVTdypnmZeGOrzAtmCyNcRlViFY(IntPtr thisObject);

		public bOWmLRADAgGETaDjoImrwRTnVgv(int numberOfCallbackMethods)
			: base(numberOfCallbackMethods + 3)
		{
			nvNNNfyOPYahlcBQwANdYJXICvzR(new wzwqGDBEjpciWofNKWkdtJruLUa(oZOgdgiKioKuvPMsUIxvxzYpzsFg));
			nvNNNfyOPYahlcBQwANdYJXICvzR(new maveVuFGUbUAwFxOONfDXErjMac(JQAVCiLMFXvRunGuORdIpDnPytz));
			nvNNNfyOPYahlcBQwANdYJXICvzR(new AVTdypnmZeGOrzAtmCyNcRlViFY(GXBxFCedGpBtymKJWLKVmeyrsGB));
		}

		protected unsafe static int oZOgdgiKioKuvPMsUIxvxzYpzsFg(IntPtr P_0, IntPtr P_1, out IntPtr P_2)
		{
			GwRCdDVnMlcbisRiTXyMToiJxJP gwRCdDVnMlcbisRiTXyMToiJxJP = iOSaYhIovYBYpfiucOzLiKYFEPX.bVCGsFglwTnnkcMqICpTmFPpqIzw<GwRCdDVnMlcbisRiTXyMToiJxJP>(P_0);
			if (gwRCdDVnMlcbisRiTXyMToiJxJP == null)
			{
				P_2 = IntPtr.Zero;
				return cTKAHZacuViBRtnMbZwDuEpUfDCh.hnJlYDxoHONgQikKwHYqDqnldwP.Code;
			}
			return gwRCdDVnMlcbisRiTXyMToiJxJP.oZOgdgiKioKuvPMsUIxvxzYpzsFg(P_0, ref *(Guid*)(void*)P_1, out P_2);
		}

		protected static int JQAVCiLMFXvRunGuORdIpDnPytz(IntPtr P_0)
		{
			return iOSaYhIovYBYpfiucOzLiKYFEPX.bVCGsFglwTnnkcMqICpTmFPpqIzw<GwRCdDVnMlcbisRiTXyMToiJxJP>(P_0)?.JQAVCiLMFXvRunGuORdIpDnPytz(P_0) ?? 0;
		}

		protected static int GXBxFCedGpBtymKJWLKVmeyrsGB(IntPtr P_0)
		{
			return iOSaYhIovYBYpfiucOzLiKYFEPX.bVCGsFglwTnnkcMqICpTmFPpqIzw<GwRCdDVnMlcbisRiTXyMToiJxJP>(P_0)?.GXBxFCedGpBtymKJWLKVmeyrsGB(P_0) ?? 0;
		}
	}

	private int SGFhTdTxaZBwtXlKxvkwhwIprEL = 1;

	public static Guid NZAUcxSPDbaOkQBtuRztHciqezQ = new Guid("00000000-0000-0000-C000-000000000046");

	protected int oZOgdgiKioKuvPMsUIxvxzYpzsFg(IntPtr P_0, ref Guid P_1, out IntPtr P_2)
	{
		GwRCdDVnMlcbisRiTXyMToiJxJP gwRCdDVnMlcbisRiTXyMToiJxJP = (GwRCdDVnMlcbisRiTXyMToiJxJP)((zhfPNWSRlKRFPvTawRzkutbfsyG)base.Callback.Shadow).KldRLZzHdlIkGJfdHORAwJxVxqOh(P_1);
		if (gwRCdDVnMlcbisRiTXyMToiJxJP != null)
		{
			gwRCdDVnMlcbisRiTXyMToiJxJP.JQAVCiLMFXvRunGuORdIpDnPytz(P_0);
			P_2 = gwRCdDVnMlcbisRiTXyMToiJxJP.NativePointer;
			return cTKAHZacuViBRtnMbZwDuEpUfDCh.TxKWeNYuiFlAPAnHJjVLUemLHGGi.Code;
		}
		P_2 = IntPtr.Zero;
		return cTKAHZacuViBRtnMbZwDuEpUfDCh.hnJlYDxoHONgQikKwHYqDqnldwP.Code;
	}

	protected virtual int JQAVCiLMFXvRunGuORdIpDnPytz(IntPtr P_0)
	{
		return Interlocked.Increment(ref SGFhTdTxaZBwtXlKxvkwhwIprEL);
	}

	protected virtual int GXBxFCedGpBtymKJWLKVmeyrsGB(IntPtr P_0)
	{
		return Interlocked.Decrement(ref SGFhTdTxaZBwtXlKxvkwhwIprEL);
	}
}
