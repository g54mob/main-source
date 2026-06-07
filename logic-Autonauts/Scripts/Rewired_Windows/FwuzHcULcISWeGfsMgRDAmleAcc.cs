using System;
using System.Runtime.InteropServices;
using System.Threading;

internal abstract class FwuzHcULcISWeGfsMgRDAmleAcc : jwzGTEgJThlahTtazxrQriNiTCg
{
	internal class gFBTZXZMVypVWokZQttSpDFLEoq : KOSpfYuVMNhRBqeDjgdReUZePoTb
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int kqlNocQnREmuEQgGGivapjAVTaO(IntPtr thisObject, IntPtr guid, out IntPtr output);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int JDbOpnhWDwVbGoWvJTJcXjSRFlW(IntPtr thisObject);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate int APYnJaGFYJfxQeMtcVftHbldJoZj(IntPtr thisObject);

		public gFBTZXZMVypVWokZQttSpDFLEoq(int numberOfCallbackMethods)
			: base(numberOfCallbackMethods + 3)
		{
			yOsCNUpjNbXuhxSXpVhyIGknimM(new kqlNocQnREmuEQgGGivapjAVTaO(fYxyOFPdARdCrgJuXanoqFJKmbk));
			yOsCNUpjNbXuhxSXpVhyIGknimM(new JDbOpnhWDwVbGoWvJTJcXjSRFlW(IqrTtZSlnafciDYiPzLXoggwciQ));
			yOsCNUpjNbXuhxSXpVhyIGknimM(new APYnJaGFYJfxQeMtcVftHbldJoZj(RDygandmZMvIaGGAXjNUhznUDhs));
		}

		protected unsafe static int fYxyOFPdARdCrgJuXanoqFJKmbk(IntPtr P_0, IntPtr P_1, out IntPtr P_2)
		{
			FwuzHcULcISWeGfsMgRDAmleAcc fwuzHcULcISWeGfsMgRDAmleAcc = jwzGTEgJThlahTtazxrQriNiTCg.ipxdwiyZIyRGswxsXxvYYDCBVUG<FwuzHcULcISWeGfsMgRDAmleAcc>(P_0);
			if (fwuzHcULcISWeGfsMgRDAmleAcc == null)
			{
				P_2 = IntPtr.Zero;
				return hbpFHugbKyodFCJCiZcKFruzcGvs.wGiXMyihhrKsYMCNzADnUfyUdLm.Code;
			}
			return fwuzHcULcISWeGfsMgRDAmleAcc.fYxyOFPdARdCrgJuXanoqFJKmbk(P_0, ref *(Guid*)(void*)P_1, out P_2);
		}

		protected static int IqrTtZSlnafciDYiPzLXoggwciQ(IntPtr P_0)
		{
			FwuzHcULcISWeGfsMgRDAmleAcc fwuzHcULcISWeGfsMgRDAmleAcc = jwzGTEgJThlahTtazxrQriNiTCg.ipxdwiyZIyRGswxsXxvYYDCBVUG<FwuzHcULcISWeGfsMgRDAmleAcc>(P_0);
			if (fwuzHcULcISWeGfsMgRDAmleAcc == null)
			{
				return 0;
			}
			return fwuzHcULcISWeGfsMgRDAmleAcc.IqrTtZSlnafciDYiPzLXoggwciQ(P_0);
		}

		protected static int RDygandmZMvIaGGAXjNUhznUDhs(IntPtr P_0)
		{
			FwuzHcULcISWeGfsMgRDAmleAcc fwuzHcULcISWeGfsMgRDAmleAcc = jwzGTEgJThlahTtazxrQriNiTCg.ipxdwiyZIyRGswxsXxvYYDCBVUG<FwuzHcULcISWeGfsMgRDAmleAcc>(P_0);
			if (fwuzHcULcISWeGfsMgRDAmleAcc == null)
			{
				return 0;
			}
			return fwuzHcULcISWeGfsMgRDAmleAcc.RDygandmZMvIaGGAXjNUhznUDhs(P_0);
		}
	}

	private int PiuIaEOMzaGghzEcmclrkXfALRi = 1;

	public static Guid OUpnBKDilEcqokAbrIlkhWvNrglR = new Guid("00000000-0000-0000-C000-000000000046");

	protected int fYxyOFPdARdCrgJuXanoqFJKmbk(IntPtr P_0, ref Guid P_1, out IntPtr P_2)
	{
		FwuzHcULcISWeGfsMgRDAmleAcc fwuzHcULcISWeGfsMgRDAmleAcc = (FwuzHcULcISWeGfsMgRDAmleAcc)((uIUGPlDgBlthVDXefxRhzAiUrij)base.Callback.Shadow).ZfIOhawRxGSAGZcpAROPEComjvb(P_1);
		if (fwuzHcULcISWeGfsMgRDAmleAcc != null)
		{
			fwuzHcULcISWeGfsMgRDAmleAcc.IqrTtZSlnafciDYiPzLXoggwciQ(P_0);
			P_2 = fwuzHcULcISWeGfsMgRDAmleAcc.NativePointer;
			return hbpFHugbKyodFCJCiZcKFruzcGvs.ArffBsNPEaehLmOZGRICZLxoNOj.Code;
		}
		P_2 = IntPtr.Zero;
		return hbpFHugbKyodFCJCiZcKFruzcGvs.wGiXMyihhrKsYMCNzADnUfyUdLm.Code;
	}

	protected virtual int IqrTtZSlnafciDYiPzLXoggwciQ(IntPtr P_0)
	{
		return Interlocked.Increment(ref PiuIaEOMzaGghzEcmclrkXfALRi);
	}

	protected virtual int RDygandmZMvIaGGAXjNUhznUDhs(IntPtr P_0)
	{
		return Interlocked.Decrement(ref PiuIaEOMzaGghzEcmclrkXfALRi);
	}
}
