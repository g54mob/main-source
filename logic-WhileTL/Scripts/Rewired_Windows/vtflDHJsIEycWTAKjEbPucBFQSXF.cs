using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class vtflDHJsIEycWTAKjEbPucBFQSXF : IDisposable
{
	private enum NKILhBSWcLxnPzdzDYzLlHzrhtrq
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum TjecpYQftmnOMpIEpGEZfqoayxlJ
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int CCRtpPaxtbisTNRxyAPXmptYrXju = 8;

	private const int CUvpdwpoczEfjgWbpQgagJYdaqdW = 10;

	private readonly string QKvdPdpcJCKanqJSfpBESrMXCIpx;

	private IntPtr ymOoSEjKtQPwHyzBjjQSQuZDFbsy = pJoUrtXZHaMrXASYbkCOEjZvGGlbA.xaMRLfpvorDUvKJDbGhDKjFvcKpP;

	private readonly NativeBuffer pshxLsVBaxPobdRQOPmmlqHPIgYt;

	private readonly int HExVhUiOKAERNasgNajfuixJPvtS;

	private readonly pJoUrtXZHaMrXASYbkCOEjZvGGlbA.BjrDBYzJlQbzHNfwzuSqrkTNVcPD BWaldTlbBODTKTMsdZUGOpFkVdFB;

	private readonly object JktFuLiGLzUIKRreKzDnvRhPmtGmA;

	private readonly object xVZLRvZzKxZqVtJVxKeatBsoBsNi;

	private readonly uint mpJerLFDgkxOsOetokrwzQxMFixJA;

	private NativeOverlapped GPxTNgkwqweSNOxoitozVfORxmLc;

	private NKILhBSWcLxnPzdzDYzLlHzrhtrq VgiNAdoPwxDtzAUEtKiqLqKEJkLEA;

	private int utcJWBEjszGSjWUfTuLhDOsbmCqq;

	private bool MXDakBUrLRXefjuavphxMIbRLKLC;

	private int RzqdbjILLhLZXKIYRjILdsZQLxVVA;

	private int rJbMJEPScufFFlKuQkInyHIztwsr;

	public readonly int VFWFmkYTeuScCJxTkzrnEFoAmTkK;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	private bool HssrrySHiNxIjRzaAsLIdCHlpsIn => QxownmDJIVIoCLmRvZGjHkikREmf.HssrrySHiNxIjRzaAsLIdCHlpsIn(QKvdPdpcJCKanqJSfpBESrMXCIpx);

	public vtflDHJsIEycWTAKjEbPucBFQSXF(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		mpJerLFDgkxOsOetokrwzQxMFixJA = ObjectInstanceTracker.Default.Register(this);
		QKvdPdpcJCKanqJSfpBESrMXCIpx = P_0;
		if (!DptvpOFNSMVrzgfnJgSAakaZKEuG())
		{
			throw new Exception("Could not open HID device.");
		}
		HExVhUiOKAERNasgNajfuixJPvtS = P_1;
		VFWFmkYTeuScCJxTkzrnEFoAmTkK = P_1 + 8;
		pshxLsVBaxPobdRQOPmmlqHPIgYt = new NativeBuffer(VFWFmkYTeuScCJxTkzrnEFoAmTkK);
		GPxTNgkwqweSNOxoitozVfORxmLc = default(NativeOverlapped);
		VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.Idle;
		utcJWBEjszGSjWUfTuLhDOsbmCqq = ((P_2 < 0) ? 65535 : P_2);
		JktFuLiGLzUIKRreKzDnvRhPmtGmA = new object();
		xVZLRvZzKxZqVtJVxKeatBsoBsNi = new object();
		BWaldTlbBODTKTMsdZUGOpFkVdFB = XndOKhEJSgUwFIFIewmXnbtZiGYg;
		WuflAoNgHfNrTWAitlHTduHQRmXo(GPxTNgkwqweSNOxoitozVfORxmLc);
	}

	public TjecpYQftmnOMpIEpGEZfqoayxlJ lpzCMyRwfnpZCqiMQhipRjGrjZfC(byte[] P_0)
	{
		lock (xVZLRvZzKxZqVtJVxKeatBsoBsNi)
		{
			if (TExNvhkEWsBWipIUjadCDaTpNNDG)
			{
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.CriticalError;
			}
			if (!EdIqcjSPDJhvWGkWbDNQfZAMOKak())
			{
				return (rJbMJEPScufFFlKuQkInyHIztwsr >= 10) ? TjecpYQftmnOMpIEpGEZfqoayxlJ.CriticalError : TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < VFWFmkYTeuScCJxTkzrnEFoAmTkK)
			{
				int vFWFmkYTeuScCJxTkzrnEFoAmTkK = VFWFmkYTeuScCJxTkzrnEFoAmTkK;
				throw new Exception("buffer must be at least " + vFWFmkYTeuScCJxTkzrnEFoAmTkK + " bytes");
			}
			switch (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA)
			{
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.Idle:
				ChlrJlAisVQUWnVRYlkvJaofbIHu();
				break;
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.Waiting:
				gCubBwGokAPtvjvXfIUMzIgVoqoz();
				break;
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.ErrorPending:
				YGjQnwwsOxRRunlnxrRNukFVzVwt();
				break;
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.SuccessPending:
				KpofNXFjpeFLhZaGOInPNBZwoObYA();
				break;
			}
			switch (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA)
			{
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.Idle:
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Idle;
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.Waiting:
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.ErrorPending:
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.SuccessPending:
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Waiting;
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.FinishedSuccess:
				pshxLsVBaxPobdRQOPmmlqHPIgYt.TryReadBytes(P_0, VFWFmkYTeuScCJxTkzrnEFoAmTkK);
				VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.Idle;
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Success;
			case NKILhBSWcLxnPzdzDYzLlHzrhtrq.FinishedError:
				VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.Idle;
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool ChlrJlAisVQUWnVRYlkvJaofbIHu()
	{
		if (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA != NKILhBSWcLxnPzdzDYzLlHzrhtrq.Idle)
		{
			int vgiNAdoPwxDtzAUEtKiqLqKEJkLEA = (int)VgiNAdoPwxDtzAUEtKiqLqKEJkLEA;
			throw new Exception("Cannot StartRead from this state. State = " + vgiNAdoPwxDtzAUEtKiqLqKEJkLEA);
		}
		try
		{
			clOavfCHpNeTPfcwzgPdNbzmHFpz();
			lock (JktFuLiGLzUIKRreKzDnvRhPmtGmA)
			{
				bool num = pJoUrtXZHaMrXASYbkCOEjZvGGlbA.OsowjeQMwIcPyDpNYFKlPzmbuOcS(ymOoSEjKtQPwHyzBjjQSQuZDFbsy, pshxLsVBaxPobdRQOPmmlqHPIgYt, (uint)HExVhUiOKAERNasgNajfuixJPvtS, ref GPxTNgkwqweSNOxoitozVfORxmLc, BWaldTlbBODTKTMsdZUGOpFkVdFB);
				if (num)
				{
					VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.Waiting;
					MXDakBUrLRXefjuavphxMIbRLKLC = true;
				}
				else
				{
					bhFtBdVxepoMBtaYucNLkezIwLgQA();
				}
				return num;
			}
		}
		catch (Exception)
		{
			bhFtBdVxepoMBtaYucNLkezIwLgQA();
			return false;
		}
	}

	private void gCubBwGokAPtvjvXfIUMzIgVoqoz()
	{
		if (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA != NKILhBSWcLxnPzdzDYzLlHzrhtrq.Waiting)
		{
			int vgiNAdoPwxDtzAUEtKiqLqKEJkLEA = (int)VgiNAdoPwxDtzAUEtKiqLqKEJkLEA;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + vgiNAdoPwxDtzAUEtKiqLqKEJkLEA);
		}
		switch (HYZBZVBkjHMAKsjqRpBkzhxBNneG())
		{
		case TjecpYQftmnOMpIEpGEZfqoayxlJ.Error:
			bhFtBdVxepoMBtaYucNLkezIwLgQA();
			break;
		case TjecpYQftmnOMpIEpGEZfqoayxlJ.Success:
			YZFGHfjOtOLQQxVFaBVjgomUbMSxA();
			break;
		case TjecpYQftmnOMpIEpGEZfqoayxlJ.Waiting:
			break;
		}
	}

	private TjecpYQftmnOMpIEpGEZfqoayxlJ HYZBZVBkjHMAKsjqRpBkzhxBNneG()
	{
		if (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA != NKILhBSWcLxnPzdzDYzLlHzrhtrq.Waiting)
		{
			return TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
		}
		try
		{
			switch (pJoUrtXZHaMrXASYbkCOEjZvGGlbA.iTxxxTFlDrgxivXOTMbqqUhxVuOP(utcJWBEjszGSjWUfTuLhDOsbmCqq, true))
			{
			case 0u:
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Waiting;
			case 192u:
			{
				if (!pJoUrtXZHaMrXASYbkCOEjZvGGlbA.BZbcFrHxMIAHjKAdrNSIMaOduDSR(ymOoSEjKtQPwHyzBjjQSQuZDFbsy, ref GPxTNgkwqweSNOxoitozVfORxmLc, out var num, false))
				{
					return TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
				}
				return (num > 0) ? TjecpYQftmnOMpIEpGEZfqoayxlJ.Success : TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Waiting;
			default:
				return TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
			}
		}
		catch
		{
			return TjecpYQftmnOMpIEpGEZfqoayxlJ.Error;
		}
	}

	private void bhFtBdVxepoMBtaYucNLkezIwLgQA()
	{
		VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.ErrorPending;
		YGjQnwwsOxRRunlnxrRNukFVzVwt();
	}

	private void YGjQnwwsOxRRunlnxrRNukFVzVwt()
	{
		if (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA != NKILhBSWcLxnPzdzDYzLlHzrhtrq.ErrorPending)
		{
			int vgiNAdoPwxDtzAUEtKiqLqKEJkLEA = (int)VgiNAdoPwxDtzAUEtKiqLqKEJkLEA;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + vgiNAdoPwxDtzAUEtKiqLqKEJkLEA);
		}
		VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.FinishedError;
	}

	private void YZFGHfjOtOLQQxVFaBVjgomUbMSxA()
	{
		VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.SuccessPending;
		KpofNXFjpeFLhZaGOInPNBZwoObYA();
	}

	private void KpofNXFjpeFLhZaGOInPNBZwoObYA()
	{
		if (VgiNAdoPwxDtzAUEtKiqLqKEJkLEA != NKILhBSWcLxnPzdzDYzLlHzrhtrq.SuccessPending)
		{
			int vgiNAdoPwxDtzAUEtKiqLqKEJkLEA = (int)VgiNAdoPwxDtzAUEtKiqLqKEJkLEA;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + vgiNAdoPwxDtzAUEtKiqLqKEJkLEA);
		}
		VgiNAdoPwxDtzAUEtKiqLqKEJkLEA = NKILhBSWcLxnPzdzDYzLlHzrhtrq.FinishedSuccess;
		pshxLsVBaxPobdRQOPmmlqHPIgYt.Write(ReInput.realTime, HExVhUiOKAERNasgNajfuixJPvtS);
	}

	private void clOavfCHpNeTPfcwzgPdNbzmHFpz()
	{
		WuflAoNgHfNrTWAitlHTduHQRmXo(GPxTNgkwqweSNOxoitozVfORxmLc);
		pshxLsVBaxPobdRQOPmmlqHPIgYt.Clear();
		RzqdbjILLhLZXKIYRjILdsZQLxVVA = 0;
		MXDakBUrLRXefjuavphxMIbRLKLC = false;
	}

	private void WuflAoNgHfNrTWAitlHTduHQRmXo(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)mpJerLFDgkxOsOetokrwzQxMFixJA);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool EdIqcjSPDJhvWGkWbDNQfZAMOKak()
	{
		if (rJbMJEPScufFFlKuQkInyHIztwsr >= 10)
		{
			return false;
		}
		if (!DptvpOFNSMVrzgfnJgSAakaZKEuG())
		{
			rJbMJEPScufFFlKuQkInyHIztwsr++;
			return false;
		}
		if (rJbMJEPScufFFlKuQkInyHIztwsr > 0)
		{
			rJbMJEPScufFFlKuQkInyHIztwsr = 0;
		}
		return true;
	}

	private bool DptvpOFNSMVrzgfnJgSAakaZKEuG()
	{
		if (ymOoSEjKtQPwHyzBjjQSQuZDFbsy != pJoUrtXZHaMrXASYbkCOEjZvGGlbA.xaMRLfpvorDUvKJDbGhDKjFvcKpP)
		{
			return true;
		}
		if (!HssrrySHiNxIjRzaAsLIdCHlpsIn)
		{
			return false;
		}
		IntPtr intPtr = HKAJMXiFvRMaCqAuDFvvhWrpDKIEA.mzcmSdJquoEYVAtYMllsWtPIpnpx(QKvdPdpcJCKanqJSfpBESrMXCIpx, LGnDrtKnTrdcpiYveqhQgKiIDQRQA.Overlapped, 3221225472u, KiVhLRgUBzWPdyXlNhqERbLdGETh.ShareRead | KiVhLRgUBzWPdyXlNhqERbLdGETh.ShareWrite);
		if (intPtr == pJoUrtXZHaMrXASYbkCOEjZvGGlbA.xaMRLfpvorDUvKJDbGhDKjFvcKpP)
		{
			return false;
		}
		ymOoSEjKtQPwHyzBjjQSQuZDFbsy = intPtr;
		return true;
	}

	private void vdSIvNfmMPOegCxURRKoaLQsEwZQ()
	{
		if (!(ymOoSEjKtQPwHyzBjjQSQuZDFbsy == pJoUrtXZHaMrXASYbkCOEjZvGGlbA.xaMRLfpvorDUvKJDbGhDKjFvcKpP))
		{
			HKAJMXiFvRMaCqAuDFvvhWrpDKIEA.nDJKtGvXPyIRAwxAlQlFSBfHdCWcA(ymOoSEjKtQPwHyzBjjQSQuZDFbsy);
			ymOoSEjKtQPwHyzBjjQSQuZDFbsy = pJoUrtXZHaMrXASYbkCOEjZvGGlbA.xaMRLfpvorDUvKJDbGhDKjFvcKpP;
		}
	}

	[MonoPInvokeCallback(typeof(pJoUrtXZHaMrXASYbkCOEjZvGGlbA.BjrDBYzJlQbzHNfwzuSqrkTNVcPD))]
	private unsafe static void XndOKhEJSgUwFIFIewmXnbtZiGYg(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<vtflDHJsIEycWTAKjEbPucBFQSXF>(instanceId, out var instance))
		{
			return;
		}
		lock (instance.JktFuLiGLzUIKRreKzDnvRhPmtGmA)
		{
			instance.RzqdbjILLhLZXKIYRjILdsZQLxVVA = P_0;
			instance.MXDakBUrLRXefjuavphxMIbRLKLC = false;
		}
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			return;
		}
		using (new Locker(xVZLRvZzKxZqVtJVxKeatBsoBsNi))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(mpJerLFDgkxOsOetokrwzQxMFixJA);
			}
			vdSIvNfmMPOegCxURRKoaLQsEwZQ();
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void zjsSydipTXaATqJqDGsDgNykXopi(string P_0)
	{
	}
}
