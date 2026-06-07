using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class xgNwjoGvjRLepxLlpVshQmgSUfMw : IDisposable
{
	private enum VTSeGtHDuIkBzEWhqYgZdGwQrzXu
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum KkmhrUuwGszvhHimRNvYNBQinolL
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int ePcxCRkKLufgTYqbpWUGqUYICKzK = 8;

	private const int ZCtTJxHfgbPTxYIdYIzGLTEOlwJT = 10;

	private readonly string EZYQAdJnlCWdCJyrejsroDyFgJer;

	private IntPtr mxSpRRSqTgKlFFVGzNjYyAtuzjuB = loEvjCWOkdpreenQvwRgkkDojoaD.SRDTMiHdPawuBCJfaJOXKVaDLvlr;

	private readonly NativeBuffer uSRFooGLYBUzoNsFPWXvKBnlJfGAA;

	private readonly int NAEPgewETaBmuQIUsUCrivYfaKVw;

	private readonly loEvjCWOkdpreenQvwRgkkDojoaD.GGTltDXydFctWioJagrhkmkWrwKx CJUWeAGrNjenkPnDmaOVHdiyNtWhA;

	private readonly object rnhXCLpqRkEOHQMBLPjJZRPiVOSX;

	private readonly uint QNfpQRlxYVIAEXCZXUNAKJTxfbqc;

	private global::ptDAZOMgYivncCYMdWwaXadwMfL<loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP> LtXKoMVnYzmEhMknSljnVHClXTXw;

	private VTSeGtHDuIkBzEWhqYgZdGwQrzXu HndPBktSzUksuTkwgKYMlnkiTlhl;

	private int PgiwFmgdnrgOHdpyjGEYJTWKKbkaA;

	private bool uvfcPnivWHRNRFfQvbYSCPgIvMFJc;

	private int EEKlgXamETasRdPSNWAFupTbMSDE;

	private int utdWPPfOFGFTaSOMZlikzlJBlLJA;

	public readonly int HETCEjfWxLfiJHmgsBMQaIOpOPAT;

	private bool zfLYaqPpoYAcHrXgZEHCLqibUyqQ;

	private bool jyXSStedIEyvALKMlfTPHqIdLKyN => IEUIaTGMEWhWxjxHtLvNddZfncnz.kUlAfBmanCmtpidkKuZyIVparKhx(EZYQAdJnlCWdCJyrejsroDyFgJer);

	public xgNwjoGvjRLepxLlpVshQmgSUfMw(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		QNfpQRlxYVIAEXCZXUNAKJTxfbqc = ObjectInstanceTracker.Default.Register(this);
		EZYQAdJnlCWdCJyrejsroDyFgJer = P_0;
		if (!tCuAPWXhoyopDvUDfZCrYGbiGuWp())
		{
			throw new Exception("Could not open HID device.");
		}
		NAEPgewETaBmuQIUsUCrivYfaKVw = P_1;
		HETCEjfWxLfiJHmgsBMQaIOpOPAT = P_1 + 8;
		uSRFooGLYBUzoNsFPWXvKBnlJfGAA = new NativeBuffer(HETCEjfWxLfiJHmgsBMQaIOpOPAT);
		LtXKoMVnYzmEhMknSljnVHClXTXw = new global::ptDAZOMgYivncCYMdWwaXadwMfL<loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP>();
		HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Idle;
		PgiwFmgdnrgOHdpyjGEYJTWKKbkaA = ((P_2 < 0) ? 65535 : P_2);
		rnhXCLpqRkEOHQMBLPjJZRPiVOSX = new object();
		CJUWeAGrNjenkPnDmaOVHdiyNtWhA = yfZEklSJOxpuxUHzJKKyYOtmkLdX;
		YrTqNohLEnBXyOPYUaZQMNkHvNJX();
	}

	public KkmhrUuwGszvhHimRNvYNBQinolL IntkByEItJarlcuotJYXPCcDjFSKA(byte[] P_0)
	{
		lock (rnhXCLpqRkEOHQMBLPjJZRPiVOSX)
		{
			if (zfLYaqPpoYAcHrXgZEHCLqibUyqQ)
			{
				return KkmhrUuwGszvhHimRNvYNBQinolL.CriticalError;
			}
			if (!MtRJYMckaJWbcwkwFbjwbNiPIsUg())
			{
				return (utdWPPfOFGFTaSOMZlikzlJBlLJA >= 10) ? KkmhrUuwGszvhHimRNvYNBQinolL.CriticalError : KkmhrUuwGszvhHimRNvYNBQinolL.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < HETCEjfWxLfiJHmgsBMQaIOpOPAT)
			{
				int hETCEjfWxLfiJHmgsBMQaIOpOPAT = HETCEjfWxLfiJHmgsBMQaIOpOPAT;
				throw new Exception("buffer must be at least " + hETCEjfWxLfiJHmgsBMQaIOpOPAT + " bytes");
			}
			switch (HndPBktSzUksuTkwgKYMlnkiTlhl)
			{
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Idle:
				gwQcNtafHneyNNgkpqdBRrvFKfVl();
				break;
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Waiting:
				KgAfwQzRJEDlWZGwrSnVHNsebECIA();
				break;
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.ErrorPending:
				FIEQxVaQquQMnnlgRIoMaZzXeKdnA();
				break;
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.SuccessPending:
				bRpgbDvdoQUSWGZGiAVOFceXIbBx();
				break;
			}
			switch (HndPBktSzUksuTkwgKYMlnkiTlhl)
			{
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Idle:
				return KkmhrUuwGszvhHimRNvYNBQinolL.Idle;
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Waiting:
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.ErrorPending:
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.SuccessPending:
				return KkmhrUuwGszvhHimRNvYNBQinolL.Waiting;
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.FinishedSuccess:
				uSRFooGLYBUzoNsFPWXvKBnlJfGAA.TryReadBytes(P_0, HETCEjfWxLfiJHmgsBMQaIOpOPAT);
				HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Idle;
				return KkmhrUuwGszvhHimRNvYNBQinolL.Success;
			case VTSeGtHDuIkBzEWhqYgZdGwQrzXu.FinishedError:
				HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Idle;
				return KkmhrUuwGszvhHimRNvYNBQinolL.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool gwQcNtafHneyNNgkpqdBRrvFKfVl()
	{
		if (HndPBktSzUksuTkwgKYMlnkiTlhl != VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Idle)
		{
			int hndPBktSzUksuTkwgKYMlnkiTlhl = (int)HndPBktSzUksuTkwgKYMlnkiTlhl;
			throw new Exception("Cannot StartRead from this state. State = " + hndPBktSzUksuTkwgKYMlnkiTlhl);
		}
		try
		{
			BPYdBcRFOLxQTgmeepFDmXtcySVk();
			bool num = loEvjCWOkdpreenQvwRgkkDojoaD.QNvogKihJYvCBIHOypLWtFMkZsVi(mxSpRRSqTgKlFFVGzNjYyAtuzjuB, uSRFooGLYBUzoNsFPWXvKBnlJfGAA, (uint)NAEPgewETaBmuQIUsUCrivYfaKVw, GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(LtXKoMVnYzmEhMknSljnVHClXTXw.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA), CJUWeAGrNjenkPnDmaOVHdiyNtWhA);
			if (num)
			{
				HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Waiting;
				uvfcPnivWHRNRFfQvbYSCPgIvMFJc = true;
			}
			else
			{
				yCbiiPmHjqlEwzygbvJdbkVfYWK();
			}
			return num;
		}
		catch (Exception)
		{
			yCbiiPmHjqlEwzygbvJdbkVfYWK();
			return false;
		}
	}

	private void KgAfwQzRJEDlWZGwrSnVHNsebECIA()
	{
		if (HndPBktSzUksuTkwgKYMlnkiTlhl != VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Waiting)
		{
			int hndPBktSzUksuTkwgKYMlnkiTlhl = (int)HndPBktSzUksuTkwgKYMlnkiTlhl;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + hndPBktSzUksuTkwgKYMlnkiTlhl);
		}
		switch (QpXCvmXXQEOLKaEneQUjLonvXHIH())
		{
		case KkmhrUuwGszvhHimRNvYNBQinolL.Error:
			yCbiiPmHjqlEwzygbvJdbkVfYWK();
			break;
		case KkmhrUuwGszvhHimRNvYNBQinolL.Success:
			oQxDTVzjBtFfGuoKFxkSmnxtNM();
			break;
		case KkmhrUuwGszvhHimRNvYNBQinolL.Waiting:
			break;
		}
	}

	private KkmhrUuwGszvhHimRNvYNBQinolL QpXCvmXXQEOLKaEneQUjLonvXHIH()
	{
		if (HndPBktSzUksuTkwgKYMlnkiTlhl != VTSeGtHDuIkBzEWhqYgZdGwQrzXu.Waiting)
		{
			return KkmhrUuwGszvhHimRNvYNBQinolL.Error;
		}
		try
		{
			switch (loEvjCWOkdpreenQvwRgkkDojoaD.YirXiOSuhLtHbVwEDDqSvzCUJxVL(PgiwFmgdnrgOHdpyjGEYJTWKKbkaA, true))
			{
			case 0u:
				return KkmhrUuwGszvhHimRNvYNBQinolL.Waiting;
			case 192u:
			{
				if (!loEvjCWOkdpreenQvwRgkkDojoaD.lNQHhsuzGRTMCuSWIZMsYSMpnJQB(mxSpRRSqTgKlFFVGzNjYyAtuzjuB, GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(LtXKoMVnYzmEhMknSljnVHClXTXw.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA), out var num, false))
				{
					return KkmhrUuwGszvhHimRNvYNBQinolL.Error;
				}
				return (num > 0) ? KkmhrUuwGszvhHimRNvYNBQinolL.Success : KkmhrUuwGszvhHimRNvYNBQinolL.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return KkmhrUuwGszvhHimRNvYNBQinolL.Waiting;
			default:
				return KkmhrUuwGszvhHimRNvYNBQinolL.Error;
			}
		}
		catch
		{
			return KkmhrUuwGszvhHimRNvYNBQinolL.Error;
		}
	}

	private void yCbiiPmHjqlEwzygbvJdbkVfYWK()
	{
		HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.ErrorPending;
		FIEQxVaQquQMnnlgRIoMaZzXeKdnA();
	}

	private void FIEQxVaQquQMnnlgRIoMaZzXeKdnA()
	{
		if (HndPBktSzUksuTkwgKYMlnkiTlhl != VTSeGtHDuIkBzEWhqYgZdGwQrzXu.ErrorPending)
		{
			int hndPBktSzUksuTkwgKYMlnkiTlhl = (int)HndPBktSzUksuTkwgKYMlnkiTlhl;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + hndPBktSzUksuTkwgKYMlnkiTlhl);
		}
		HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.FinishedError;
	}

	private void oQxDTVzjBtFfGuoKFxkSmnxtNM()
	{
		HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.SuccessPending;
		bRpgbDvdoQUSWGZGiAVOFceXIbBx();
	}

	private void bRpgbDvdoQUSWGZGiAVOFceXIbBx()
	{
		if (HndPBktSzUksuTkwgKYMlnkiTlhl != VTSeGtHDuIkBzEWhqYgZdGwQrzXu.SuccessPending)
		{
			int hndPBktSzUksuTkwgKYMlnkiTlhl = (int)HndPBktSzUksuTkwgKYMlnkiTlhl;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + hndPBktSzUksuTkwgKYMlnkiTlhl);
		}
		HndPBktSzUksuTkwgKYMlnkiTlhl = VTSeGtHDuIkBzEWhqYgZdGwQrzXu.FinishedSuccess;
		uSRFooGLYBUzoNsFPWXvKBnlJfGAA.Write(ReInput.realTime, NAEPgewETaBmuQIUsUCrivYfaKVw);
	}

	private void BPYdBcRFOLxQTgmeepFDmXtcySVk()
	{
		YrTqNohLEnBXyOPYUaZQMNkHvNJX();
		uSRFooGLYBUzoNsFPWXvKBnlJfGAA.Clear();
		EEKlgXamETasRdPSNWAFupTbMSDE = 0;
		uvfcPnivWHRNRFfQvbYSCPgIvMFJc = false;
	}

	private void YrTqNohLEnBXyOPYUaZQMNkHvNJX()
	{
		loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP dRukELLOOoaJKBmJPAieGjGfpPGP = default(loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP);
		dRukELLOOoaJKBmJPAieGjGfpPGP.mCtgQZgBlhHKCjnbXTrfEuFuwVPM = new IntPtr((int)QNfpQRlxYVIAEXCZXUNAKJTxfbqc);
		dRukELLOOoaJKBmJPAieGjGfpPGP.KYVDqTPaRZWKRCmNEuAarfFYwjyT = IntPtr.Zero;
		dRukELLOOoaJKBmJPAieGjGfpPGP.USPoRjUgCKjuKbdrtbFdekefbfzo = IntPtr.Zero;
		dRukELLOOoaJKBmJPAieGjGfpPGP.htHyXPoOFbdyLcPIDirYnjedLuSF = 0;
		dRukELLOOoaJKBmJPAieGjGfpPGP.ijzlcCFEoSDLxALbcqhUANMDPLYic = 0;
		LtXKoMVnYzmEhMknSljnVHClXTXw.NBmCWVHOCQkVZZqJiqCbATHxvSeq = dRukELLOOoaJKBmJPAieGjGfpPGP;
	}

	private bool MtRJYMckaJWbcwkwFbjwbNiPIsUg()
	{
		if (utdWPPfOFGFTaSOMZlikzlJBlLJA >= 10)
		{
			return false;
		}
		if (!tCuAPWXhoyopDvUDfZCrYGbiGuWp())
		{
			utdWPPfOFGFTaSOMZlikzlJBlLJA++;
			return false;
		}
		if (utdWPPfOFGFTaSOMZlikzlJBlLJA > 0)
		{
			utdWPPfOFGFTaSOMZlikzlJBlLJA = 0;
		}
		return true;
	}

	private bool tCuAPWXhoyopDvUDfZCrYGbiGuWp()
	{
		if (mxSpRRSqTgKlFFVGzNjYyAtuzjuB != loEvjCWOkdpreenQvwRgkkDojoaD.SRDTMiHdPawuBCJfaJOXKVaDLvlr)
		{
			return true;
		}
		if (!jyXSStedIEyvALKMlfTPHqIdLKyN)
		{
			return false;
		}
		IntPtr intPtr = LleUpypmoUiGbAiZXeXDJpCoDzXr.TKgrzJjjwBddtJuambUDZAQkjUEi(EZYQAdJnlCWdCJyrejsroDyFgJer, JGDhfUZBOiCuUelScgHsgeHJJnUPA.Overlapped, 3221225472u, OFjGjmJvTsMMYZEcTJJanfOutjGaA.ShareRead | OFjGjmJvTsMMYZEcTJJanfOutjGaA.ShareWrite);
		if (intPtr == loEvjCWOkdpreenQvwRgkkDojoaD.SRDTMiHdPawuBCJfaJOXKVaDLvlr)
		{
			return false;
		}
		mxSpRRSqTgKlFFVGzNjYyAtuzjuB = intPtr;
		return true;
	}

	private void fCmoUQKcbhCXeJkdKIZAfworRsBV()
	{
		if (!(mxSpRRSqTgKlFFVGzNjYyAtuzjuB == loEvjCWOkdpreenQvwRgkkDojoaD.SRDTMiHdPawuBCJfaJOXKVaDLvlr))
		{
			LleUpypmoUiGbAiZXeXDJpCoDzXr.KvOEGUrKsvsvricoyEGjxbqlDMEE(mxSpRRSqTgKlFFVGzNjYyAtuzjuB);
			mxSpRRSqTgKlFFVGzNjYyAtuzjuB = loEvjCWOkdpreenQvwRgkkDojoaD.SRDTMiHdPawuBCJfaJOXKVaDLvlr;
		}
	}

	[MonoPInvokeCallback(typeof(loEvjCWOkdpreenQvwRgkkDojoaD.GGTltDXydFctWioJagrhkmkWrwKx))]
	private static void yfZEklSJOxpuxUHzJKKyYOtmkLdX(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		hZFekvkXeFkIUairrvqNcxMujnqUA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void fKtixGMVCIeWdkTzPamlRvcgFfZy()
	{
		try
		{
			hZFekvkXeFkIUairrvqNcxMujnqUA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hZFekvkXeFkIUairrvqNcxMujnqUA(bool P_0)
	{
		if (zfLYaqPpoYAcHrXgZEHCLqibUyqQ)
		{
			return;
		}
		using (new Locker(rnhXCLpqRkEOHQMBLPjJZRPiVOSX))
		{
			if (P_0)
			{
				LtXKoMVnYzmEhMknSljnVHClXTXw.Dispose();
				ObjectInstanceTracker.Default.Unregister(QNfpQRlxYVIAEXCZXUNAKJTxfbqc);
			}
			fCmoUQKcbhCXeJkdKIZAfworRsBV();
			zfLYaqPpoYAcHrXgZEHCLqibUyqQ = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void krdIvMjGFEfTvDpRBVrmGBYDFyWj(string P_0)
	{
	}
}
