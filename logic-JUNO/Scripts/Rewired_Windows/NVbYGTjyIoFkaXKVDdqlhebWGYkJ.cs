using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class NVbYGTjyIoFkaXKVDdqlhebWGYkJ : IDisposable
{
	private enum fUchxQmSTheXkiKRWlvNSulQGgfL
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum giAuStDhnZLWodeMhsQUgNJyfUHBA
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int SlWxiwHyiNFNIsGXLBhMZxLWxfNI = 8;

	private const int lxNeGVeVIMgwaeLZeoAmwHyGDtec = 10;

	private readonly string mSqZbWyTWvTlXnoRQcszFXzZyKYh;

	private IntPtr SpDnYkdtBmfjudghVqQrHzXoSHFk = NGmQStzXlESSbMkZJEniTmbkeAACA.ualxvRieuNFTSwLZKmPJlndRpETm;

	private readonly NativeBuffer KedRCLebvcAXdWaplIWjsKudCIgR;

	private readonly int xnofwVCBqPHLbBssUfZfKZVjmllFA;

	private readonly NGmQStzXlESSbMkZJEniTmbkeAACA.qhtGsSoMleYVKMzeGkjQPlrONsyB sCeTKhffiQIMhjDrSRRXEFbuXCmU;

	private readonly object usvFiaXobzlXjMWmciUjsrdiQTLE;

	private readonly object DZDahiSAiThxKgutvcgNbcWgpvcQA;

	private readonly uint wbTHSyGvKmLzLrDsfTZYnFMvcCNu;

	private NativeOverlapped dapHvVwtjShcCgFcqaijcBRhcghh;

	private fUchxQmSTheXkiKRWlvNSulQGgfL tzNauNHMAbsDxGlWKUPYFUrwCeBTA;

	private int hlEWFPFpCGjlWRCUDjBQsiXExWIP;

	private bool CAVgjCSUpgyUMJqePJJOarrvfYdh;

	private int iQuPImRyRkxTWXwldATPVykfvffp;

	private int GXPMdmgSbwTgMuDeqFayjQuTgGbrA;

	public readonly int vspxjYQfOajDCGnISOFAUFVnseyUA;

	private bool TNxbBHyaBfbJKeHQzBGSoubtfVKvA;

	private bool NedbvAPhbzNSTxMkDoCRkTLrpfCs => oymLFibOtnrrwNkvVefVAYWlRuLG.AcJAGgjNQxGAaJAYeuAkUncKoxNKc(mSqZbWyTWvTlXnoRQcszFXzZyKYh);

	public NVbYGTjyIoFkaXKVDdqlhebWGYkJ(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		wbTHSyGvKmLzLrDsfTZYnFMvcCNu = ObjectInstanceTracker.Default.Register(this);
		mSqZbWyTWvTlXnoRQcszFXzZyKYh = P_0;
		if (!VnKIvpcDFFjPQcNvDlAfNhayTBmMA())
		{
			throw new Exception("Could not open HID device.");
		}
		xnofwVCBqPHLbBssUfZfKZVjmllFA = P_1;
		vspxjYQfOajDCGnISOFAUFVnseyUA = P_1 + 8;
		KedRCLebvcAXdWaplIWjsKudCIgR = new NativeBuffer(vspxjYQfOajDCGnISOFAUFVnseyUA);
		dapHvVwtjShcCgFcqaijcBRhcghh = default(NativeOverlapped);
		tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.Idle;
		hlEWFPFpCGjlWRCUDjBQsiXExWIP = ((P_2 < 0) ? 65535 : P_2);
		usvFiaXobzlXjMWmciUjsrdiQTLE = new object();
		DZDahiSAiThxKgutvcgNbcWgpvcQA = new object();
		sCeTKhffiQIMhjDrSRRXEFbuXCmU = lOdtoiRnJeHWcALcKGBawBeIeZDJA;
		rNnVsPTXxwBEqiFfWjEPLHOvhaDZ(dapHvVwtjShcCgFcqaijcBRhcghh);
	}

	public giAuStDhnZLWodeMhsQUgNJyfUHBA sBZcNJvaKiKEsQRSZLoVuAhTqVuh(byte[] P_0)
	{
		lock (DZDahiSAiThxKgutvcgNbcWgpvcQA)
		{
			if (TNxbBHyaBfbJKeHQzBGSoubtfVKvA)
			{
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.CriticalError;
			}
			if (!kApmwbDSXejtjOfEddayQopDonex())
			{
				return (GXPMdmgSbwTgMuDeqFayjQuTgGbrA >= 10) ? giAuStDhnZLWodeMhsQUgNJyfUHBA.CriticalError : giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < vspxjYQfOajDCGnISOFAUFVnseyUA)
			{
				int num = vspxjYQfOajDCGnISOFAUFVnseyUA;
				throw new Exception("buffer must be at least " + num + " bytes");
			}
			switch (tzNauNHMAbsDxGlWKUPYFUrwCeBTA)
			{
			case fUchxQmSTheXkiKRWlvNSulQGgfL.Idle:
				UTciBQPqoWVTYbgQFedXyAgXQxjn();
				break;
			case fUchxQmSTheXkiKRWlvNSulQGgfL.Waiting:
				cjkJYdSwIpOaDjDCXatZmBpcvKmh();
				break;
			case fUchxQmSTheXkiKRWlvNSulQGgfL.ErrorPending:
				dqmCjkPHjXdVgJYmrnbCwkrNbVRC();
				break;
			case fUchxQmSTheXkiKRWlvNSulQGgfL.SuccessPending:
				FTTYPgAGXjpMHwKuKPDGmFdPHMnv();
				break;
			}
			switch (tzNauNHMAbsDxGlWKUPYFUrwCeBTA)
			{
			case fUchxQmSTheXkiKRWlvNSulQGgfL.Idle:
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Idle;
			case fUchxQmSTheXkiKRWlvNSulQGgfL.Waiting:
			case fUchxQmSTheXkiKRWlvNSulQGgfL.ErrorPending:
			case fUchxQmSTheXkiKRWlvNSulQGgfL.SuccessPending:
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Waiting;
			case fUchxQmSTheXkiKRWlvNSulQGgfL.FinishedSuccess:
				KedRCLebvcAXdWaplIWjsKudCIgR.TryReadBytes(P_0, vspxjYQfOajDCGnISOFAUFVnseyUA);
				tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.Idle;
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Success;
			case fUchxQmSTheXkiKRWlvNSulQGgfL.FinishedError:
				tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.Idle;
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool UTciBQPqoWVTYbgQFedXyAgXQxjn()
	{
		if (tzNauNHMAbsDxGlWKUPYFUrwCeBTA != fUchxQmSTheXkiKRWlvNSulQGgfL.Idle)
		{
			int num = (int)tzNauNHMAbsDxGlWKUPYFUrwCeBTA;
			throw new Exception("Cannot StartRead from this state. State = " + num);
		}
		try
		{
			tuukWZmahuwUESoCKDgJHDckFVvfA();
			lock (usvFiaXobzlXjMWmciUjsrdiQTLE)
			{
				bool num2 = NGmQStzXlESSbMkZJEniTmbkeAACA.recIhIHiPqPoyzLtIdPQRKWJOzX(SpDnYkdtBmfjudghVqQrHzXoSHFk, KedRCLebvcAXdWaplIWjsKudCIgR, (uint)xnofwVCBqPHLbBssUfZfKZVjmllFA, ref dapHvVwtjShcCgFcqaijcBRhcghh, sCeTKhffiQIMhjDrSRRXEFbuXCmU);
				if (num2)
				{
					tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.Waiting;
					CAVgjCSUpgyUMJqePJJOarrvfYdh = true;
				}
				else
				{
					KNaoDJcKaMHMZIUSOqoXiWhTOvabb();
				}
				return num2;
			}
		}
		catch (Exception)
		{
			KNaoDJcKaMHMZIUSOqoXiWhTOvabb();
			return false;
		}
	}

	private void cjkJYdSwIpOaDjDCXatZmBpcvKmh()
	{
		if (tzNauNHMAbsDxGlWKUPYFUrwCeBTA != fUchxQmSTheXkiKRWlvNSulQGgfL.Waiting)
		{
			int num = (int)tzNauNHMAbsDxGlWKUPYFUrwCeBTA;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + num);
		}
		switch (endUzFuWfncpZAFTMpHhcQuzhmwt())
		{
		case giAuStDhnZLWodeMhsQUgNJyfUHBA.Error:
			KNaoDJcKaMHMZIUSOqoXiWhTOvabb();
			break;
		case giAuStDhnZLWodeMhsQUgNJyfUHBA.Success:
			fjGoSmiKECMSIusEYjQlLutvcGrQ();
			break;
		case giAuStDhnZLWodeMhsQUgNJyfUHBA.Waiting:
			break;
		}
	}

	private giAuStDhnZLWodeMhsQUgNJyfUHBA endUzFuWfncpZAFTMpHhcQuzhmwt()
	{
		if (tzNauNHMAbsDxGlWKUPYFUrwCeBTA != fUchxQmSTheXkiKRWlvNSulQGgfL.Waiting)
		{
			return giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
		}
		try
		{
			switch (NGmQStzXlESSbMkZJEniTmbkeAACA.cORcJrfjYcGsqxKwvezKCURUGmdfb(hlEWFPFpCGjlWRCUDjBQsiXExWIP, true))
			{
			case 0u:
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Waiting;
			case 192u:
			{
				if (!NGmQStzXlESSbMkZJEniTmbkeAACA.cTYeXALImXNhhGGeyvVZunZKMTii(SpDnYkdtBmfjudghVqQrHzXoSHFk, ref dapHvVwtjShcCgFcqaijcBRhcghh, out var num, false))
				{
					return giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
				}
				return (num > 0) ? giAuStDhnZLWodeMhsQUgNJyfUHBA.Success : giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Waiting;
			default:
				return giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
			}
		}
		catch
		{
			return giAuStDhnZLWodeMhsQUgNJyfUHBA.Error;
		}
	}

	private void KNaoDJcKaMHMZIUSOqoXiWhTOvabb()
	{
		tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.ErrorPending;
		dqmCjkPHjXdVgJYmrnbCwkrNbVRC();
	}

	private void dqmCjkPHjXdVgJYmrnbCwkrNbVRC()
	{
		if (tzNauNHMAbsDxGlWKUPYFUrwCeBTA != fUchxQmSTheXkiKRWlvNSulQGgfL.ErrorPending)
		{
			int num = (int)tzNauNHMAbsDxGlWKUPYFUrwCeBTA;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + num);
		}
		tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.FinishedError;
	}

	private void fjGoSmiKECMSIusEYjQlLutvcGrQ()
	{
		tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.SuccessPending;
		FTTYPgAGXjpMHwKuKPDGmFdPHMnv();
	}

	private void FTTYPgAGXjpMHwKuKPDGmFdPHMnv()
	{
		if (tzNauNHMAbsDxGlWKUPYFUrwCeBTA != fUchxQmSTheXkiKRWlvNSulQGgfL.SuccessPending)
		{
			int num = (int)tzNauNHMAbsDxGlWKUPYFUrwCeBTA;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + num);
		}
		tzNauNHMAbsDxGlWKUPYFUrwCeBTA = fUchxQmSTheXkiKRWlvNSulQGgfL.FinishedSuccess;
		KedRCLebvcAXdWaplIWjsKudCIgR.Write(ReInput.realTime, xnofwVCBqPHLbBssUfZfKZVjmllFA);
	}

	private void tuukWZmahuwUESoCKDgJHDckFVvfA()
	{
		rNnVsPTXxwBEqiFfWjEPLHOvhaDZ(dapHvVwtjShcCgFcqaijcBRhcghh);
		KedRCLebvcAXdWaplIWjsKudCIgR.Clear();
		iQuPImRyRkxTWXwldATPVykfvffp = 0;
		CAVgjCSUpgyUMJqePJJOarrvfYdh = false;
	}

	private void rNnVsPTXxwBEqiFfWjEPLHOvhaDZ(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)wbTHSyGvKmLzLrDsfTZYnFMvcCNu);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool kApmwbDSXejtjOfEddayQopDonex()
	{
		if (GXPMdmgSbwTgMuDeqFayjQuTgGbrA >= 10)
		{
			return false;
		}
		if (!VnKIvpcDFFjPQcNvDlAfNhayTBmMA())
		{
			GXPMdmgSbwTgMuDeqFayjQuTgGbrA++;
			return false;
		}
		if (GXPMdmgSbwTgMuDeqFayjQuTgGbrA > 0)
		{
			GXPMdmgSbwTgMuDeqFayjQuTgGbrA = 0;
		}
		return true;
	}

	private bool VnKIvpcDFFjPQcNvDlAfNhayTBmMA()
	{
		if (SpDnYkdtBmfjudghVqQrHzXoSHFk != NGmQStzXlESSbMkZJEniTmbkeAACA.ualxvRieuNFTSwLZKmPJlndRpETm)
		{
			return true;
		}
		if (!NedbvAPhbzNSTxMkDoCRkTLrpfCs)
		{
			return false;
		}
		IntPtr intPtr = tmIanFBEFfADwAijJlMTSoVSsCpuB.nrSeUiiAPuHIcpjSWdaXpgDuOCcRA(mSqZbWyTWvTlXnoRQcszFXzZyKYh, tvrfMxjunRwBDPIuEUKyFTEXjAaJb.Overlapped, 3221225472u, mnLIXNWRyZjuFosUbGJsMWJeUBsi.ShareRead | mnLIXNWRyZjuFosUbGJsMWJeUBsi.ShareWrite);
		if (intPtr == NGmQStzXlESSbMkZJEniTmbkeAACA.ualxvRieuNFTSwLZKmPJlndRpETm)
		{
			return false;
		}
		SpDnYkdtBmfjudghVqQrHzXoSHFk = intPtr;
		return true;
	}

	private void XtMUJlpOQYCqxdMVoKICYQxpfDjGA()
	{
		if (!(SpDnYkdtBmfjudghVqQrHzXoSHFk == NGmQStzXlESSbMkZJEniTmbkeAACA.ualxvRieuNFTSwLZKmPJlndRpETm))
		{
			tmIanFBEFfADwAijJlMTSoVSsCpuB.cacmzrQwrWGLuIkYCjDvYpejfscu(SpDnYkdtBmfjudghVqQrHzXoSHFk);
			SpDnYkdtBmfjudghVqQrHzXoSHFk = NGmQStzXlESSbMkZJEniTmbkeAACA.ualxvRieuNFTSwLZKmPJlndRpETm;
		}
	}

	[MonoPInvokeCallback(typeof(NGmQStzXlESSbMkZJEniTmbkeAACA.qhtGsSoMleYVKMzeGkjQPlrONsyB))]
	private unsafe static void lOdtoiRnJeHWcALcKGBawBeIeZDJA(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<NVbYGTjyIoFkaXKVDdqlhebWGYkJ>(instanceId, out var instance))
		{
			return;
		}
		lock (instance.usvFiaXobzlXjMWmciUjsrdiQTLE)
		{
			instance.iQuPImRyRkxTWXwldATPVykfvffp = P_0;
			instance.CAVgjCSUpgyUMJqePJJOarrvfYdh = false;
		}
	}

	public void Dispose()
	{
		RyrHXMaSJglmZIuDZrfVScHgDWIT(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void NDFQOtjtolfYoSPpdpNpyhkkOCdC()
	{
		try
		{
			RyrHXMaSJglmZIuDZrfVScHgDWIT(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void RyrHXMaSJglmZIuDZrfVScHgDWIT(bool P_0)
	{
		if (TNxbBHyaBfbJKeHQzBGSoubtfVKvA)
		{
			return;
		}
		using (new Locker(DZDahiSAiThxKgutvcgNbcWgpvcQA))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(wbTHSyGvKmLzLrDsfTZYnFMvcCNu);
			}
			XtMUJlpOQYCqxdMVoKICYQxpfDjGA();
			TNxbBHyaBfbJKeHQzBGSoubtfVKvA = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void IIPjndSRgbaKuxhrrjAilqVDFimM(string P_0)
	{
	}
}
