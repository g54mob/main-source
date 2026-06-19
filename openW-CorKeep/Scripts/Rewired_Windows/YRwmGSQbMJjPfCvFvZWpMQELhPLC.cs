using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class YRwmGSQbMJjPfCvFvZWpMQELhPLC : IDisposable
{
	private enum qSdDtBRskGOOjxfusHgHjQLRliSd
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum dsBQuquASkcclcamBtgOtBcfEzwMA
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int XhBTixyDjszuLftKntGSusOTCzwd = 8;

	private const int gxUUPFBcsdFIhhDjAdIOKXcFycEUA = 10;

	private readonly string hbrnTZRNvIBBEdmtsPYvhaGAMDreb;

	private IntPtr PdEaybcWgXDLxbwFgpwrTyuPvhykB = AMvwysMQWfJeaNSrxAHwkwEtPxzP.xSuTYZNHSqzFpffRypPfSEjMhoob;

	private readonly NativeBuffer FIsrXUVCKXaxmXVMTmdpHJVajYPG;

	private readonly int mMnfWCmJLqgfclOIsojvovcwfEMw;

	private readonly AMvwysMQWfJeaNSrxAHwkwEtPxzP.zeccahTErHdsYbJZyRMxruEPBuHmA jqttFmGRkjkcwsBDkhpXrGxppsND;

	private readonly object MmUHpglDQeVJhtDqZQDHHfRzMJgb;

	private readonly uint nYICwvFpnTbHWouSZubANMbaLroWA;

	private global::YFMyTlGpqWfdvBPQCYKgauQgeieHA<AMvwysMQWfJeaNSrxAHwkwEtPxzP.UfZXMzTlUkCnQsdJXcDmOJwwFpDK> wsqluqXxIrZNhjIbIeSnNimwoXQT;

	private qSdDtBRskGOOjxfusHgHjQLRliSd ozYHUUrFzKIrgqrsyPxGtVYtqLeX;

	private int qHDQpSgWvbBZTKTmrfvIVNaPldbQ;

	private bool JsCKfFrbAZKJRIAUzrNYDYSqWbUH;

	private int ljhUkfupaHbfLFUHHahLDwXdqUMgc;

	private int HAMXVlZmAFzORxKYQnWanQFQmdCX;

	public readonly int oGmnPZfydXOrNioiaLpIgHakzPHw;

	private bool OedtGLHoYjbJiIeTWaIMBGyhoppA;

	private bool UpcTPkiUiOaMfwEKruZDZaymMtlb => hvnhVrGGJGHgzOeFnMnHvVzmekkF.DQQmotoepMiqtGNyIrykQYZzECeJA(hbrnTZRNvIBBEdmtsPYvhaGAMDreb);

	public YRwmGSQbMJjPfCvFvZWpMQELhPLC(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		nYICwvFpnTbHWouSZubANMbaLroWA = ObjectInstanceTracker.Default.Register(this);
		hbrnTZRNvIBBEdmtsPYvhaGAMDreb = P_0;
		if (!UmZBRmEBymwfLqCDhTutkOZpPkLoA())
		{
			throw new Exception("Could not open HID device.");
		}
		mMnfWCmJLqgfclOIsojvovcwfEMw = P_1;
		oGmnPZfydXOrNioiaLpIgHakzPHw = P_1 + 8;
		FIsrXUVCKXaxmXVMTmdpHJVajYPG = new NativeBuffer(oGmnPZfydXOrNioiaLpIgHakzPHw);
		wsqluqXxIrZNhjIbIeSnNimwoXQT = new global::YFMyTlGpqWfdvBPQCYKgauQgeieHA<AMvwysMQWfJeaNSrxAHwkwEtPxzP.UfZXMzTlUkCnQsdJXcDmOJwwFpDK>();
		ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.Idle;
		qHDQpSgWvbBZTKTmrfvIVNaPldbQ = ((P_2 < 0) ? 65535 : P_2);
		MmUHpglDQeVJhtDqZQDHHfRzMJgb = new object();
		jqttFmGRkjkcwsBDkhpXrGxppsND = NiqddTWdKhFfrvsrVcbqONFbUFux;
		hJqKXSxeWneEkpzWWpkQMmIOFBQJA();
	}

	public dsBQuquASkcclcamBtgOtBcfEzwMA nkEYpKWTrRaNxPXahvFBThCUhBVy(byte[] P_0)
	{
		lock (MmUHpglDQeVJhtDqZQDHHfRzMJgb)
		{
			if (OedtGLHoYjbJiIeTWaIMBGyhoppA)
			{
				return dsBQuquASkcclcamBtgOtBcfEzwMA.CriticalError;
			}
			if (!jssAWobmcNaPyxJiDCOkydEAmGHTA())
			{
				return (HAMXVlZmAFzORxKYQnWanQFQmdCX >= 10) ? dsBQuquASkcclcamBtgOtBcfEzwMA.CriticalError : dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < oGmnPZfydXOrNioiaLpIgHakzPHw)
			{
				int num = oGmnPZfydXOrNioiaLpIgHakzPHw;
				throw new Exception("buffer must be at least " + num + " bytes");
			}
			switch (ozYHUUrFzKIrgqrsyPxGtVYtqLeX)
			{
			case qSdDtBRskGOOjxfusHgHjQLRliSd.Idle:
				PgzcrHBgLzZzDOwajXHNEJXQKSUbb();
				break;
			case qSdDtBRskGOOjxfusHgHjQLRliSd.Waiting:
				jElrDcbdPIbkQqtiveWDPrMvMAVw();
				break;
			case qSdDtBRskGOOjxfusHgHjQLRliSd.ErrorPending:
				mCloffyaiacFzMOiVuNQZABGSIoo();
				break;
			case qSdDtBRskGOOjxfusHgHjQLRliSd.SuccessPending:
				ATEkafploUZIMtiEehZWTcGMfzEi();
				break;
			}
			switch (ozYHUUrFzKIrgqrsyPxGtVYtqLeX)
			{
			case qSdDtBRskGOOjxfusHgHjQLRliSd.Idle:
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Idle;
			case qSdDtBRskGOOjxfusHgHjQLRliSd.Waiting:
			case qSdDtBRskGOOjxfusHgHjQLRliSd.ErrorPending:
			case qSdDtBRskGOOjxfusHgHjQLRliSd.SuccessPending:
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Waiting;
			case qSdDtBRskGOOjxfusHgHjQLRliSd.FinishedSuccess:
				FIsrXUVCKXaxmXVMTmdpHJVajYPG.TryReadBytes(P_0, oGmnPZfydXOrNioiaLpIgHakzPHw);
				ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.Idle;
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Success;
			case qSdDtBRskGOOjxfusHgHjQLRliSd.FinishedError:
				ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.Idle;
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool PgzcrHBgLzZzDOwajXHNEJXQKSUbb()
	{
		if (ozYHUUrFzKIrgqrsyPxGtVYtqLeX != qSdDtBRskGOOjxfusHgHjQLRliSd.Idle)
		{
			int num = (int)ozYHUUrFzKIrgqrsyPxGtVYtqLeX;
			throw new Exception("Cannot StartRead from this state. State = " + num);
		}
		try
		{
			oypaaIdDWHIwHxZoaIKNIiBrEmKSA();
			bool num2 = AMvwysMQWfJeaNSrxAHwkwEtPxzP.hmCwhqiHjIIyXGzQqxUOrrevSXGJA(PdEaybcWgXDLxbwFgpwrTyuPvhykB, FIsrXUVCKXaxmXVMTmdpHJVajYPG, (uint)mMnfWCmJLqgfclOIsojvovcwfEMw, fFicYORCqoZwZowJIRdCWZeAXNjG.RnOfsfFHtBeuEBYfBKvjaaPcnokEB(wsqluqXxIrZNhjIbIeSnNimwoXQT.CfpozvRHgvwEKCcHNhGHLGvhabUC), jqttFmGRkjkcwsBDkhpXrGxppsND);
			if (num2)
			{
				ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.Waiting;
				JsCKfFrbAZKJRIAUzrNYDYSqWbUH = true;
			}
			else
			{
				DEzYlKBrNrNaCPLucAMVGpEIPSJyA();
			}
			return num2;
		}
		catch (Exception)
		{
			DEzYlKBrNrNaCPLucAMVGpEIPSJyA();
			return false;
		}
	}

	private void jElrDcbdPIbkQqtiveWDPrMvMAVw()
	{
		if (ozYHUUrFzKIrgqrsyPxGtVYtqLeX != qSdDtBRskGOOjxfusHgHjQLRliSd.Waiting)
		{
			int num = (int)ozYHUUrFzKIrgqrsyPxGtVYtqLeX;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + num);
		}
		switch (rngqXEJPSGIDSVijwvnhLYTmGFPw())
		{
		case dsBQuquASkcclcamBtgOtBcfEzwMA.Error:
			DEzYlKBrNrNaCPLucAMVGpEIPSJyA();
			break;
		case dsBQuquASkcclcamBtgOtBcfEzwMA.Success:
			oJBzujDcbzgcFfWsyBuzbcIqXjALA();
			break;
		case dsBQuquASkcclcamBtgOtBcfEzwMA.Waiting:
			break;
		}
	}

	private dsBQuquASkcclcamBtgOtBcfEzwMA rngqXEJPSGIDSVijwvnhLYTmGFPw()
	{
		if (ozYHUUrFzKIrgqrsyPxGtVYtqLeX != qSdDtBRskGOOjxfusHgHjQLRliSd.Waiting)
		{
			return dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
		}
		try
		{
			switch (AMvwysMQWfJeaNSrxAHwkwEtPxzP.tStlyKRbBMMbwvUTXmEjDeTNEOj(qHDQpSgWvbBZTKTmrfvIVNaPldbQ, true))
			{
			case 0u:
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Waiting;
			case 192u:
			{
				if (!AMvwysMQWfJeaNSrxAHwkwEtPxzP.SVttEPgFlPuGKNoMYRyWAukeFjGx(PdEaybcWgXDLxbwFgpwrTyuPvhykB, fFicYORCqoZwZowJIRdCWZeAXNjG.RnOfsfFHtBeuEBYfBKvjaaPcnokEB(wsqluqXxIrZNhjIbIeSnNimwoXQT.CfpozvRHgvwEKCcHNhGHLGvhabUC), out var num, false))
				{
					return dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
				}
				return (num > 0) ? dsBQuquASkcclcamBtgOtBcfEzwMA.Success : dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Waiting;
			default:
				return dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
			}
		}
		catch
		{
			return dsBQuquASkcclcamBtgOtBcfEzwMA.Error;
		}
	}

	private void DEzYlKBrNrNaCPLucAMVGpEIPSJyA()
	{
		ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.ErrorPending;
		mCloffyaiacFzMOiVuNQZABGSIoo();
	}

	private void mCloffyaiacFzMOiVuNQZABGSIoo()
	{
		if (ozYHUUrFzKIrgqrsyPxGtVYtqLeX != qSdDtBRskGOOjxfusHgHjQLRliSd.ErrorPending)
		{
			int num = (int)ozYHUUrFzKIrgqrsyPxGtVYtqLeX;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + num);
		}
		ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.FinishedError;
	}

	private void oJBzujDcbzgcFfWsyBuzbcIqXjALA()
	{
		ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.SuccessPending;
		ATEkafploUZIMtiEehZWTcGMfzEi();
	}

	private void ATEkafploUZIMtiEehZWTcGMfzEi()
	{
		if (ozYHUUrFzKIrgqrsyPxGtVYtqLeX != qSdDtBRskGOOjxfusHgHjQLRliSd.SuccessPending)
		{
			int num = (int)ozYHUUrFzKIrgqrsyPxGtVYtqLeX;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + num);
		}
		ozYHUUrFzKIrgqrsyPxGtVYtqLeX = qSdDtBRskGOOjxfusHgHjQLRliSd.FinishedSuccess;
		FIsrXUVCKXaxmXVMTmdpHJVajYPG.Write(ReInput.realTime, mMnfWCmJLqgfclOIsojvovcwfEMw);
	}

	private void oypaaIdDWHIwHxZoaIKNIiBrEmKSA()
	{
		hJqKXSxeWneEkpzWWpkQMmIOFBQJA();
		FIsrXUVCKXaxmXVMTmdpHJVajYPG.Clear();
		ljhUkfupaHbfLFUHHahLDwXdqUMgc = 0;
		JsCKfFrbAZKJRIAUzrNYDYSqWbUH = false;
	}

	private void hJqKXSxeWneEkpzWWpkQMmIOFBQJA()
	{
		AMvwysMQWfJeaNSrxAHwkwEtPxzP.UfZXMzTlUkCnQsdJXcDmOJwwFpDK ufZXMzTlUkCnQsdJXcDmOJwwFpDK = default(AMvwysMQWfJeaNSrxAHwkwEtPxzP.UfZXMzTlUkCnQsdJXcDmOJwwFpDK);
		ufZXMzTlUkCnQsdJXcDmOJwwFpDK.NYGQvneQppbJSKupZIQvKCrnBFCXA = new IntPtr((int)nYICwvFpnTbHWouSZubANMbaLroWA);
		ufZXMzTlUkCnQsdJXcDmOJwwFpDK.fckrKzBhPTALDjtTEFlerEbFUntr = IntPtr.Zero;
		ufZXMzTlUkCnQsdJXcDmOJwwFpDK.jToLnVChWOSkSGhxtVgvsgYsjber = IntPtr.Zero;
		ufZXMzTlUkCnQsdJXcDmOJwwFpDK.GfugtdeTZnomDLnMNzFInEYyYVTP = 0;
		ufZXMzTlUkCnQsdJXcDmOJwwFpDK.FcIcrgLYiUCMneJryrQWTooMCFTN = 0;
		wsqluqXxIrZNhjIbIeSnNimwoXQT.gnHnXpTsWWkENqJXmGbbCVbmgYnq = ufZXMzTlUkCnQsdJXcDmOJwwFpDK;
	}

	private bool jssAWobmcNaPyxJiDCOkydEAmGHTA()
	{
		if (HAMXVlZmAFzORxKYQnWanQFQmdCX >= 10)
		{
			return false;
		}
		if (!UmZBRmEBymwfLqCDhTutkOZpPkLoA())
		{
			HAMXVlZmAFzORxKYQnWanQFQmdCX++;
			return false;
		}
		if (HAMXVlZmAFzORxKYQnWanQFQmdCX > 0)
		{
			HAMXVlZmAFzORxKYQnWanQFQmdCX = 0;
		}
		return true;
	}

	private bool UmZBRmEBymwfLqCDhTutkOZpPkLoA()
	{
		if (PdEaybcWgXDLxbwFgpwrTyuPvhykB != AMvwysMQWfJeaNSrxAHwkwEtPxzP.xSuTYZNHSqzFpffRypPfSEjMhoob)
		{
			return true;
		}
		if (!UpcTPkiUiOaMfwEKruZDZaymMtlb)
		{
			return false;
		}
		IntPtr intPtr = aNTkFKnqqQjRlbXRHwhJJCyplUUJ.cCHIuvtjkJTeraHioOYVFwqnxKNi(hbrnTZRNvIBBEdmtsPYvhaGAMDreb, odsfecXDEoDvMBPYqzomScpSNlLgA.Overlapped, 3221225472u, lGUcqSnXRcXfCnwfZgFwfGkjnYPg.ShareRead | lGUcqSnXRcXfCnwfZgFwfGkjnYPg.ShareWrite);
		if (intPtr == AMvwysMQWfJeaNSrxAHwkwEtPxzP.xSuTYZNHSqzFpffRypPfSEjMhoob)
		{
			return false;
		}
		PdEaybcWgXDLxbwFgpwrTyuPvhykB = intPtr;
		return true;
	}

	private void EYXPloQwhhkEowcjOdaUgbOcPiMIb()
	{
		if (!(PdEaybcWgXDLxbwFgpwrTyuPvhykB == AMvwysMQWfJeaNSrxAHwkwEtPxzP.xSuTYZNHSqzFpffRypPfSEjMhoob))
		{
			aNTkFKnqqQjRlbXRHwhJJCyplUUJ.huxAVgapAdObjiRcmqhlcxXqLVRRA(PdEaybcWgXDLxbwFgpwrTyuPvhykB);
			PdEaybcWgXDLxbwFgpwrTyuPvhykB = AMvwysMQWfJeaNSrxAHwkwEtPxzP.xSuTYZNHSqzFpffRypPfSEjMhoob;
		}
	}

	[MonoPInvokeCallback(typeof(AMvwysMQWfJeaNSrxAHwkwEtPxzP.zeccahTErHdsYbJZyRMxruEPBuHmA))]
	private static void NiqddTWdKhFfrvsrVcbqONFbUFux(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		QpgbqXRovXTMWTbydFDVfwVfbtoc(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void SpAqDmCBEMGFhTvxNpZfXhWlmlQy()
	{
		try
		{
			QpgbqXRovXTMWTbydFDVfwVfbtoc(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void QpgbqXRovXTMWTbydFDVfwVfbtoc(bool P_0)
	{
		if (OedtGLHoYjbJiIeTWaIMBGyhoppA)
		{
			return;
		}
		using (new Locker(MmUHpglDQeVJhtDqZQDHHfRzMJgb))
		{
			if (P_0)
			{
				wsqluqXxIrZNhjIbIeSnNimwoXQT.Dispose();
				ObjectInstanceTracker.Default.Unregister(nYICwvFpnTbHWouSZubANMbaLroWA);
			}
			EYXPloQwhhkEowcjOdaUgbOcPiMIb();
			OedtGLHoYjbJiIeTWaIMBGyhoppA = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void LlKDFmbdVYpyfMyPDzcooGoQAHPpA(string P_0)
	{
	}
}
