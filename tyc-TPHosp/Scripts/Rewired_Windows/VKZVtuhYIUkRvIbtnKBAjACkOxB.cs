using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class VKZVtuhYIUkRvIbtnKBAjACkOxB : IDisposable
{
	private enum oNUxuLSknciUIfXyXvXKAwXtylUq
	{
		lcELicSuRuYVUoIwSUjbTsetXSS = 0,
		PDtrIhjJkaatGizTbBsYvaAyzgOw = 1,
		GaEmdIQZFECWbhYIUCFofEfzelf = 2,
		MWxcRdkqHndTscmpwNUcCzCDUAlB = 3,
		OGJCAKtgFxEFxQAvgILtIIlvBW = 4,
		fDDfKQQASzCTSjQGTbRItyrwqOf = 5
	}

	public enum ZDccNBdADAwvwuoiYFGISscbUcBW
	{
		lcELicSuRuYVUoIwSUjbTsetXSS = 0,
		upttnMmIHIUUzuVcmMNcpVfljKM = 1,
		HrxGpWgvKdROiCcbsQJYXnqnEDaA = 2,
		PDtrIhjJkaatGizTbBsYvaAyzgOw = 3,
		XmqAEbSiQvCuaTZZhJsLdYHrbeh = 4
	}

	public const int sszfZwAKFddueCGSccPOBdotcZpv = 8;

	private const int wxHEZPLVQpJjCnWQduxhrHFGDyn = 10;

	private readonly string cOVPWYHIxIeEGflbzRCBVoJkSmb;

	private IntPtr QHuKofBhFMjkiEtyhXKJsRYiRhoA = RGIgZGFrnmqngVujnbAVaLKYaInc.FxcAnKTOUbPXORXmfAKIVmAAUKz;

	private readonly NativeBuffer DBZCtHAzIvFuQOarCKsttoMaNgUG;

	private readonly int bBLGBdFCuMiRkixVFwdwutkwWnnC;

	private readonly RGIgZGFrnmqngVujnbAVaLKYaInc.UFQbnhtMiENOcEgtdrGvULXmuFn tZaFQOBIPVVEuOFncfFBZlcBiNj;

	private readonly object lnFvGeebhbfUtdiNYHTsMUyyslWV;

	private readonly object DebnnGnPuzDNiaLmtQApaSnJXOP;

	private readonly uint EKryPeznGehMNHjIiXptWumbdoxm;

	private NativeOverlapped ozXzLkKYciuQjVAqexTfMgkwncy;

	private oNUxuLSknciUIfXyXvXKAwXtylUq jWQHkUGbMrYxONcvbvwpraTjbePc;

	private int MWGxdqqRGxIYKZQXVVfwKddAWuy;

	private bool ihtQeHaFvFBJHoFJpjlqRbDgHJH;

	private int xhSWNGxyhvVFeVifXBWUDpGlFpLF;

	private int HSBIfljROuWVssmPMpGexFNOjoib;

	public readonly int zlkQCPmlWcXehOhwoZpqZithpmg;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	private bool IsConnected => uNUGDLxbzFWxnCXPxXiZAvRTReD.pMGeVDkjCFSMYAWROAZNcnAMlkC(cOVPWYHIxIeEGflbzRCBVoJkSmb);

	public VKZVtuhYIUkRvIbtnKBAjACkOxB(string devicePath, int reportLength, int timeout)
	{
		if (string.IsNullOrEmpty(devicePath))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (reportLength <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		EKryPeznGehMNHjIiXptWumbdoxm = ObjectInstanceTracker.Default.Register(this);
		cOVPWYHIxIeEGflbzRCBVoJkSmb = devicePath;
		if (!xSRLHvvbqMPCGxgSDcFNtpjwYls())
		{
			throw new Exception("Could not open HID device.");
		}
		bBLGBdFCuMiRkixVFwdwutkwWnnC = reportLength;
		zlkQCPmlWcXehOhwoZpqZithpmg = reportLength + 8;
		DBZCtHAzIvFuQOarCKsttoMaNgUG = new NativeBuffer(zlkQCPmlWcXehOhwoZpqZithpmg);
		ozXzLkKYciuQjVAqexTfMgkwncy = default(NativeOverlapped);
		jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.lcELicSuRuYVUoIwSUjbTsetXSS;
		MWGxdqqRGxIYKZQXVVfwKddAWuy = ((timeout < 0) ? 65535 : timeout);
		lnFvGeebhbfUtdiNYHTsMUyyslWV = new object();
		DebnnGnPuzDNiaLmtQApaSnJXOP = new object();
		tZaFQOBIPVVEuOFncfFBZlcBiNj = nJpgCkMsifAojVzgWsWkicsDeAM;
		wCHMeVtmpfgnaDbZjXJYwQMfteN(ozXzLkKYciuQjVAqexTfMgkwncy);
	}

	public ZDccNBdADAwvwuoiYFGISscbUcBW DTWqTxyQfjlbrIFGzfuUHiIHdt(byte[] P_0)
	{
		lock (DebnnGnPuzDNiaLmtQApaSnJXOP)
		{
			if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
			{
				return ZDccNBdADAwvwuoiYFGISscbUcBW.XmqAEbSiQvCuaTZZhJsLdYHrbeh;
			}
			if (!clmhYIchnVLxnJypnOHNgSTrFUy())
			{
				return (HSBIfljROuWVssmPMpGexFNOjoib >= 10) ? ZDccNBdADAwvwuoiYFGISscbUcBW.XmqAEbSiQvCuaTZZhJsLdYHrbeh : ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < zlkQCPmlWcXehOhwoZpqZithpmg)
			{
				throw new Exception("buffer must be at least " + zlkQCPmlWcXehOhwoZpqZithpmg + " bytes");
			}
			switch (jWQHkUGbMrYxONcvbvwpraTjbePc)
			{
			case oNUxuLSknciUIfXyXvXKAwXtylUq.lcELicSuRuYVUoIwSUjbTsetXSS:
				wKJNCEsdYPeOhwXcQhlgAAfMYCH();
				break;
			case oNUxuLSknciUIfXyXvXKAwXtylUq.PDtrIhjJkaatGizTbBsYvaAyzgOw:
				CzSZtVESIAmnCgMcxaKDDHdkyko();
				break;
			case oNUxuLSknciUIfXyXvXKAwXtylUq.GaEmdIQZFECWbhYIUCFofEfzelf:
				ipTiDLKJghzBDcnUvTRGdpOocPw();
				break;
			case oNUxuLSknciUIfXyXvXKAwXtylUq.OGJCAKtgFxEFxQAvgILtIIlvBW:
				gEAUlaFoFgDRCizrCXlSRSWRoIbw();
				break;
			}
			switch (jWQHkUGbMrYxONcvbvwpraTjbePc)
			{
			case oNUxuLSknciUIfXyXvXKAwXtylUq.lcELicSuRuYVUoIwSUjbTsetXSS:
				return ZDccNBdADAwvwuoiYFGISscbUcBW.lcELicSuRuYVUoIwSUjbTsetXSS;
			case oNUxuLSknciUIfXyXvXKAwXtylUq.PDtrIhjJkaatGizTbBsYvaAyzgOw:
			case oNUxuLSknciUIfXyXvXKAwXtylUq.GaEmdIQZFECWbhYIUCFofEfzelf:
			case oNUxuLSknciUIfXyXvXKAwXtylUq.OGJCAKtgFxEFxQAvgILtIIlvBW:
				return ZDccNBdADAwvwuoiYFGISscbUcBW.PDtrIhjJkaatGizTbBsYvaAyzgOw;
			case oNUxuLSknciUIfXyXvXKAwXtylUq.fDDfKQQASzCTSjQGTbRItyrwqOf:
				DBZCtHAzIvFuQOarCKsttoMaNgUG.TryReadBytes(P_0, zlkQCPmlWcXehOhwoZpqZithpmg);
				jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.lcELicSuRuYVUoIwSUjbTsetXSS;
				return ZDccNBdADAwvwuoiYFGISscbUcBW.upttnMmIHIUUzuVcmMNcpVfljKM;
			case oNUxuLSknciUIfXyXvXKAwXtylUq.MWxcRdkqHndTscmpwNUcCzCDUAlB:
				jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.lcELicSuRuYVUoIwSUjbTsetXSS;
				return ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool wKJNCEsdYPeOhwXcQhlgAAfMYCH()
	{
		if (jWQHkUGbMrYxONcvbvwpraTjbePc != oNUxuLSknciUIfXyXvXKAwXtylUq.lcELicSuRuYVUoIwSUjbTsetXSS)
		{
			throw new Exception("Cannot StartRead from this state. State = " + (int)jWQHkUGbMrYxONcvbvwpraTjbePc);
		}
		try
		{
			IgqBTMgoLLDsubFJdJZiejmTNfb();
			lock (lnFvGeebhbfUtdiNYHTsMUyyslWV)
			{
				bool flag = RGIgZGFrnmqngVujnbAVaLKYaInc.cBMCDVDiYOeNDTKoYRSoOIxSxEmO(QHuKofBhFMjkiEtyhXKJsRYiRhoA, DBZCtHAzIvFuQOarCKsttoMaNgUG, (uint)bBLGBdFCuMiRkixVFwdwutkwWnnC, ref ozXzLkKYciuQjVAqexTfMgkwncy, tZaFQOBIPVVEuOFncfFBZlcBiNj);
				if (flag)
				{
					jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.PDtrIhjJkaatGizTbBsYvaAyzgOw;
					ihtQeHaFvFBJHoFJpjlqRbDgHJH = true;
				}
				else
				{
					HrxGpWgvKdROiCcbsQJYXnqnEDaA();
				}
				return flag;
			}
		}
		catch (Exception)
		{
			HrxGpWgvKdROiCcbsQJYXnqnEDaA();
			return false;
		}
	}

	private void CzSZtVESIAmnCgMcxaKDDHdkyko()
	{
		if (jWQHkUGbMrYxONcvbvwpraTjbePc != oNUxuLSknciUIfXyXvXKAwXtylUq.PDtrIhjJkaatGizTbBsYvaAyzgOw)
		{
			throw new Exception("Cannot CheckReadStatus from this state. State = " + (int)jWQHkUGbMrYxONcvbvwpraTjbePc);
		}
		switch (hqtxqqlYgZCjtdOyTznfuqewXSe())
		{
		case ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA:
			HrxGpWgvKdROiCcbsQJYXnqnEDaA();
			break;
		case ZDccNBdADAwvwuoiYFGISscbUcBW.upttnMmIHIUUzuVcmMNcpVfljKM:
			upttnMmIHIUUzuVcmMNcpVfljKM();
			break;
		case ZDccNBdADAwvwuoiYFGISscbUcBW.PDtrIhjJkaatGizTbBsYvaAyzgOw:
			break;
		}
	}

	private ZDccNBdADAwvwuoiYFGISscbUcBW hqtxqqlYgZCjtdOyTznfuqewXSe()
	{
		if (jWQHkUGbMrYxONcvbvwpraTjbePc != oNUxuLSknciUIfXyXvXKAwXtylUq.PDtrIhjJkaatGizTbBsYvaAyzgOw)
		{
			return ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
		}
		try
		{
			switch (RGIgZGFrnmqngVujnbAVaLKYaInc.GKXbLqBpddvrHLcpJlxzbtkCIkMM(MWGxdqqRGxIYKZQXVVfwKddAWuy, true))
			{
			case 0u:
				return ZDccNBdADAwvwuoiYFGISscbUcBW.PDtrIhjJkaatGizTbBsYvaAyzgOw;
			case 192u:
			{
				if (!RGIgZGFrnmqngVujnbAVaLKYaInc.juHdDGtOgGXdWTaIdWuXBDLWDJS(QHuKofBhFMjkiEtyhXKJsRYiRhoA, ref ozXzLkKYciuQjVAqexTfMgkwncy, out var num, false))
				{
					return ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
				}
				return (num > 0) ? ZDccNBdADAwvwuoiYFGISscbUcBW.upttnMmIHIUUzuVcmMNcpVfljKM : ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return ZDccNBdADAwvwuoiYFGISscbUcBW.PDtrIhjJkaatGizTbBsYvaAyzgOw;
			default:
				return ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
			}
		}
		catch
		{
			return ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA;
		}
	}

	private void HrxGpWgvKdROiCcbsQJYXnqnEDaA()
	{
		jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.GaEmdIQZFECWbhYIUCFofEfzelf;
		ipTiDLKJghzBDcnUvTRGdpOocPw();
	}

	private void ipTiDLKJghzBDcnUvTRGdpOocPw()
	{
		if (jWQHkUGbMrYxONcvbvwpraTjbePc != oNUxuLSknciUIfXyXvXKAwXtylUq.GaEmdIQZFECWbhYIUCFofEfzelf)
		{
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + (int)jWQHkUGbMrYxONcvbvwpraTjbePc);
		}
		jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.MWxcRdkqHndTscmpwNUcCzCDUAlB;
	}

	private void upttnMmIHIUUzuVcmMNcpVfljKM()
	{
		jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.OGJCAKtgFxEFxQAvgILtIIlvBW;
		gEAUlaFoFgDRCizrCXlSRSWRoIbw();
	}

	private void gEAUlaFoFgDRCizrCXlSRSWRoIbw()
	{
		if (jWQHkUGbMrYxONcvbvwpraTjbePc != oNUxuLSknciUIfXyXvXKAwXtylUq.OGJCAKtgFxEFxQAvgILtIIlvBW)
		{
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + (int)jWQHkUGbMrYxONcvbvwpraTjbePc);
		}
		jWQHkUGbMrYxONcvbvwpraTjbePc = oNUxuLSknciUIfXyXvXKAwXtylUq.fDDfKQQASzCTSjQGTbRItyrwqOf;
		DBZCtHAzIvFuQOarCKsttoMaNgUG.Write(ReInput.realTime, bBLGBdFCuMiRkixVFwdwutkwWnnC);
	}

	private void IgqBTMgoLLDsubFJdJZiejmTNfb()
	{
		wCHMeVtmpfgnaDbZjXJYwQMfteN(ozXzLkKYciuQjVAqexTfMgkwncy);
		DBZCtHAzIvFuQOarCKsttoMaNgUG.Clear();
		xhSWNGxyhvVFeVifXBWUDpGlFpLF = 0;
		ihtQeHaFvFBJHoFJpjlqRbDgHJH = false;
	}

	private void wCHMeVtmpfgnaDbZjXJYwQMfteN(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)EKryPeznGehMNHjIiXptWumbdoxm);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool clmhYIchnVLxnJypnOHNgSTrFUy()
	{
		if (HSBIfljROuWVssmPMpGexFNOjoib >= 10)
		{
			return false;
		}
		if (!xSRLHvvbqMPCGxgSDcFNtpjwYls())
		{
			HSBIfljROuWVssmPMpGexFNOjoib++;
			return false;
		}
		if (HSBIfljROuWVssmPMpGexFNOjoib > 0)
		{
			HSBIfljROuWVssmPMpGexFNOjoib = 0;
		}
		return true;
	}

	private bool xSRLHvvbqMPCGxgSDcFNtpjwYls()
	{
		if (QHuKofBhFMjkiEtyhXKJsRYiRhoA != RGIgZGFrnmqngVujnbAVaLKYaInc.FxcAnKTOUbPXORXmfAKIVmAAUKz)
		{
			return true;
		}
		if (!IsConnected)
		{
			return false;
		}
		IntPtr intPtr = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(cOVPWYHIxIeEGflbzRCBVoJkSmb, vLFRVGoQdvLiGDEOuwvTRdjdROL.HBhbdeXAXovWKDrXRMfmCzHhcCa, 3221225472u, mmtXDuKsQlMiStwVPbFRUklSYaT.QEItTnuCeYaACEukHOCvGzKKmQem | mmtXDuKsQlMiStwVPbFRUklSYaT.yTIRHmzCmzyIeunckITFaREGrtXC);
		if (intPtr == RGIgZGFrnmqngVujnbAVaLKYaInc.FxcAnKTOUbPXORXmfAKIVmAAUKz)
		{
			return false;
		}
		QHuKofBhFMjkiEtyhXKJsRYiRhoA = intPtr;
		return true;
	}

	private void PikORwFFuZFgRBJdRDOdGnDFJuHQ()
	{
		if (!(QHuKofBhFMjkiEtyhXKJsRYiRhoA == RGIgZGFrnmqngVujnbAVaLKYaInc.FxcAnKTOUbPXORXmfAKIVmAAUKz))
		{
			nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(QHuKofBhFMjkiEtyhXKJsRYiRhoA);
			QHuKofBhFMjkiEtyhXKJsRYiRhoA = RGIgZGFrnmqngVujnbAVaLKYaInc.FxcAnKTOUbPXORXmfAKIVmAAUKz;
		}
	}

	[MonoPInvokeCallback(typeof(RGIgZGFrnmqngVujnbAVaLKYaInc.UFQbnhtMiENOcEgtdrGvULXmuFn))]
	private unsafe static void nJpgCkMsifAojVzgWsWkicsDeAM(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<VKZVtuhYIUkRvIbtnKBAjACkOxB>(instanceId, out var instance))
		{
			return;
		}
		lock (instance.lnFvGeebhbfUtdiNYHTsMUyyslWV)
		{
			instance.xhSWNGxyhvVFeVifXBWUDpGlFpLF = P_0;
			instance.ihtQeHaFvFBJHoFJpjlqRbDgHJH = false;
		}
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~VKZVtuhYIUkRvIbtnKBAjACkOxB()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return;
		}
		using (new Locker(DebnnGnPuzDNiaLmtQApaSnJXOP))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(EKryPeznGehMNHjIiXptWumbdoxm);
			}
			PikORwFFuZFgRBJdRDOdGnDFJuHQ();
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void JOEdwWIYRDhkkrcTXGCOktvPdHno(string P_0)
	{
	}
}
