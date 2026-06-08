using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class QmmXwRrPsMGwaWyZpjTkGiVKEVE : IDisposable
{
	private enum VBSbhoGclPrdkiNfNrzEXFQZqAFH
	{
		qhpRgTSBpsOALeACGQvFkstXFKHA = 0,
		SySvZYvcSatfJvEjddJaJiLKorV = 1,
		DHfUMjMabKjQgnWcYTaCMYoDpya = 2,
		BgYekIwCfpYTvsDHmejEAUNbILqU = 3,
		AxnEoxCKFgBfVPtkvENabQBdHiYo = 4,
		ewikWnWYqzURFxPaXsoiYUeQoDo = 5
	}

	public enum IQCdOsTGUemNxgADmVUYmoZptuZ
	{
		qhpRgTSBpsOALeACGQvFkstXFKHA = 0,
		xiCSqbcCtIEKuyUvacFMSGcXNTJ = 1,
		EKrIvDpebmQjWiBgJqqbKnReIbq = 2,
		SySvZYvcSatfJvEjddJaJiLKorV = 3,
		OKVKpAAgmttazZRhpVPrQlSLena = 4
	}

	public const int rpWbeXAkzfSalWnkcsqeEJzJElw = 8;

	private const int pZgasuVHuxBnThKolFNPHMMaMnei = 10;

	private readonly string htaMilNTPYUsZhoBbkevwTQQsLi;

	private IntPtr JePRsKDzfKyifblWhjAzgrDWyvb = UvOafjjHDydfBDHpjrlzeDLuZok.UOTgSnHccjTLBHASvNpwkIZatFi;

	private readonly NativeBuffer EAkChchgpneGPakFUTPVByHUjQB;

	private readonly int wMyoGLEWhEHlyvfkNKIdOvjSeak;

	private readonly UvOafjjHDydfBDHpjrlzeDLuZok.XSQDJtDcVmmAiMIsdvnJleiueFYY gmLTyjDTxRpXzQOVmOctijblrYu;

	private readonly object sTqvGVmDRlMvomfhEsrSjdpChcT;

	private readonly object UkSQMxhWAfZWdyeGnHhHROmrpEC;

	private readonly uint TDSsDXrDcmOPWbTmgULNLRhBxfy;

	private NativeOverlapped xFozUZAkswavgJXymWbLdbfYIkt;

	private VBSbhoGclPrdkiNfNrzEXFQZqAFH sMvXvhOEihhzDXfFtUJBIgEBGnEe;

	private int XCpqOPoByxTKXNlaRMuUnKekHXz;

	private bool fVSVbysthXNRCkwppIAMegUQvIA;

	private int gHrwLxhBFrNohToHFzgwYZPPyQW;

	private int YTuIOMpFukbXbkKnAizSYzMkMvz;

	public readonly int smBlEeyQaayfgEcQoDQIykgTGhrb;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	private bool IsConnected => xJrcpabxFNJEeLKxzDoQfzegzEjy.ocdFackIqLzQDEipWGedjTPwenJl(htaMilNTPYUsZhoBbkevwTQQsLi);

	public QmmXwRrPsMGwaWyZpjTkGiVKEVE(string devicePath, int reportLength, int timeout)
	{
		if (string.IsNullOrEmpty(devicePath))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (reportLength <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		TDSsDXrDcmOPWbTmgULNLRhBxfy = ObjectInstanceTracker.Default.Register(this);
		htaMilNTPYUsZhoBbkevwTQQsLi = devicePath;
		if (!mGeamQKlJWYHZkhyRnLpcYadMTxi())
		{
			throw new Exception("Could not open HID device.");
		}
		wMyoGLEWhEHlyvfkNKIdOvjSeak = reportLength;
		smBlEeyQaayfgEcQoDQIykgTGhrb = reportLength + 8;
		EAkChchgpneGPakFUTPVByHUjQB = new NativeBuffer(smBlEeyQaayfgEcQoDQIykgTGhrb);
		xFozUZAkswavgJXymWbLdbfYIkt = default(NativeOverlapped);
		sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.qhpRgTSBpsOALeACGQvFkstXFKHA;
		XCpqOPoByxTKXNlaRMuUnKekHXz = ((timeout < 0) ? 65535 : timeout);
		sTqvGVmDRlMvomfhEsrSjdpChcT = new object();
		UkSQMxhWAfZWdyeGnHhHROmrpEC = new object();
		gmLTyjDTxRpXzQOVmOctijblrYu = mDuHZbfwWkWEtqHRaaFgDJxjMvFt;
		hmcZJavdRjdndRuzheyiFfLNpQS(xFozUZAkswavgJXymWbLdbfYIkt);
	}

	public IQCdOsTGUemNxgADmVUYmoZptuZ AFeHJojxqfbjmBllWvAWerjcLiqH(byte[] P_0)
	{
		lock (UkSQMxhWAfZWdyeGnHhHROmrpEC)
		{
			if (inweGjIgYacXYohFlYRlpMFkgKMi)
			{
				return IQCdOsTGUemNxgADmVUYmoZptuZ.OKVKpAAgmttazZRhpVPrQlSLena;
			}
			if (!dTJxVjyhLNHzuHuNbHanNnEFpHz())
			{
				return (YTuIOMpFukbXbkKnAizSYzMkMvz >= 10) ? IQCdOsTGUemNxgADmVUYmoZptuZ.OKVKpAAgmttazZRhpVPrQlSLena : IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < smBlEeyQaayfgEcQoDQIykgTGhrb)
			{
				throw new Exception("buffer must be at least " + smBlEeyQaayfgEcQoDQIykgTGhrb + " bytes");
			}
			switch (sMvXvhOEihhzDXfFtUJBIgEBGnEe)
			{
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.qhpRgTSBpsOALeACGQvFkstXFKHA:
				tpmlmhcQaFCOqyGCIbSSHbcaqJIF();
				break;
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.SySvZYvcSatfJvEjddJaJiLKorV:
				BqtMJmOkPYrfViMQfxhjcwTWplb();
				break;
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.DHfUMjMabKjQgnWcYTaCMYoDpya:
				xxsesqGbInDVKwUsjMquMEJIqWr();
				break;
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.AxnEoxCKFgBfVPtkvENabQBdHiYo:
				fSvKILXenaXMJpgVAYMirqBtTPo();
				break;
			}
			switch (sMvXvhOEihhzDXfFtUJBIgEBGnEe)
			{
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.qhpRgTSBpsOALeACGQvFkstXFKHA:
				return IQCdOsTGUemNxgADmVUYmoZptuZ.qhpRgTSBpsOALeACGQvFkstXFKHA;
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.SySvZYvcSatfJvEjddJaJiLKorV:
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.DHfUMjMabKjQgnWcYTaCMYoDpya:
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.AxnEoxCKFgBfVPtkvENabQBdHiYo:
				return IQCdOsTGUemNxgADmVUYmoZptuZ.SySvZYvcSatfJvEjddJaJiLKorV;
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.ewikWnWYqzURFxPaXsoiYUeQoDo:
				EAkChchgpneGPakFUTPVByHUjQB.TryReadBytes(P_0, smBlEeyQaayfgEcQoDQIykgTGhrb);
				sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.qhpRgTSBpsOALeACGQvFkstXFKHA;
				return IQCdOsTGUemNxgADmVUYmoZptuZ.xiCSqbcCtIEKuyUvacFMSGcXNTJ;
			case VBSbhoGclPrdkiNfNrzEXFQZqAFH.BgYekIwCfpYTvsDHmejEAUNbILqU:
				sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.qhpRgTSBpsOALeACGQvFkstXFKHA;
				return IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool tpmlmhcQaFCOqyGCIbSSHbcaqJIF()
	{
		if (sMvXvhOEihhzDXfFtUJBIgEBGnEe != VBSbhoGclPrdkiNfNrzEXFQZqAFH.qhpRgTSBpsOALeACGQvFkstXFKHA)
		{
			throw new Exception("Cannot StartRead from this state. State = " + (int)sMvXvhOEihhzDXfFtUJBIgEBGnEe);
		}
		try
		{
			RFDPexajhTcXvizzpCmOkHbzMGox();
			lock (sTqvGVmDRlMvomfhEsrSjdpChcT)
			{
				bool flag = UvOafjjHDydfBDHpjrlzeDLuZok.fAxaGuecUMZGGUOhGrhQjgssFZt(JePRsKDzfKyifblWhjAzgrDWyvb, EAkChchgpneGPakFUTPVByHUjQB, (uint)wMyoGLEWhEHlyvfkNKIdOvjSeak, ref xFozUZAkswavgJXymWbLdbfYIkt, gmLTyjDTxRpXzQOVmOctijblrYu);
				if (flag)
				{
					sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.SySvZYvcSatfJvEjddJaJiLKorV;
					fVSVbysthXNRCkwppIAMegUQvIA = true;
				}
				else
				{
					EKrIvDpebmQjWiBgJqqbKnReIbq();
				}
				return flag;
			}
		}
		catch (Exception)
		{
			EKrIvDpebmQjWiBgJqqbKnReIbq();
			return false;
		}
	}

	private void BqtMJmOkPYrfViMQfxhjcwTWplb()
	{
		if (sMvXvhOEihhzDXfFtUJBIgEBGnEe != VBSbhoGclPrdkiNfNrzEXFQZqAFH.SySvZYvcSatfJvEjddJaJiLKorV)
		{
			throw new Exception("Cannot CheckReadStatus from this state. State = " + (int)sMvXvhOEihhzDXfFtUJBIgEBGnEe);
		}
		switch (cRSyIBzlsVuWqbOwBOEXVGdGTQb())
		{
		case IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq:
			EKrIvDpebmQjWiBgJqqbKnReIbq();
			break;
		case IQCdOsTGUemNxgADmVUYmoZptuZ.xiCSqbcCtIEKuyUvacFMSGcXNTJ:
			xiCSqbcCtIEKuyUvacFMSGcXNTJ();
			break;
		case IQCdOsTGUemNxgADmVUYmoZptuZ.SySvZYvcSatfJvEjddJaJiLKorV:
			break;
		}
	}

	private IQCdOsTGUemNxgADmVUYmoZptuZ cRSyIBzlsVuWqbOwBOEXVGdGTQb()
	{
		if (sMvXvhOEihhzDXfFtUJBIgEBGnEe != VBSbhoGclPrdkiNfNrzEXFQZqAFH.SySvZYvcSatfJvEjddJaJiLKorV)
		{
			return IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
		}
		try
		{
			switch (UvOafjjHDydfBDHpjrlzeDLuZok.DxombHbHXlpJSaZKBEINAppgjFR(XCpqOPoByxTKXNlaRMuUnKekHXz, true))
			{
			case 0u:
				return IQCdOsTGUemNxgADmVUYmoZptuZ.SySvZYvcSatfJvEjddJaJiLKorV;
			case 192u:
			{
				if (!UvOafjjHDydfBDHpjrlzeDLuZok.ouoqUxxwUSHQBDYsnfjjaHOkcIN(JePRsKDzfKyifblWhjAzgrDWyvb, ref xFozUZAkswavgJXymWbLdbfYIkt, out var num, false))
				{
					return IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
				}
				return (num > 0) ? IQCdOsTGUemNxgADmVUYmoZptuZ.xiCSqbcCtIEKuyUvacFMSGcXNTJ : IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return IQCdOsTGUemNxgADmVUYmoZptuZ.SySvZYvcSatfJvEjddJaJiLKorV;
			default:
				return IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
			}
		}
		catch
		{
			return IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq;
		}
	}

	private void EKrIvDpebmQjWiBgJqqbKnReIbq()
	{
		sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.DHfUMjMabKjQgnWcYTaCMYoDpya;
		xxsesqGbInDVKwUsjMquMEJIqWr();
	}

	private void xxsesqGbInDVKwUsjMquMEJIqWr()
	{
		if (sMvXvhOEihhzDXfFtUJBIgEBGnEe != VBSbhoGclPrdkiNfNrzEXFQZqAFH.DHfUMjMabKjQgnWcYTaCMYoDpya)
		{
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + (int)sMvXvhOEihhzDXfFtUJBIgEBGnEe);
		}
		sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.BgYekIwCfpYTvsDHmejEAUNbILqU;
	}

	private void xiCSqbcCtIEKuyUvacFMSGcXNTJ()
	{
		sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.AxnEoxCKFgBfVPtkvENabQBdHiYo;
		fSvKILXenaXMJpgVAYMirqBtTPo();
	}

	private void fSvKILXenaXMJpgVAYMirqBtTPo()
	{
		if (sMvXvhOEihhzDXfFtUJBIgEBGnEe != VBSbhoGclPrdkiNfNrzEXFQZqAFH.AxnEoxCKFgBfVPtkvENabQBdHiYo)
		{
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + (int)sMvXvhOEihhzDXfFtUJBIgEBGnEe);
		}
		sMvXvhOEihhzDXfFtUJBIgEBGnEe = VBSbhoGclPrdkiNfNrzEXFQZqAFH.ewikWnWYqzURFxPaXsoiYUeQoDo;
		EAkChchgpneGPakFUTPVByHUjQB.Write(ReInput.realTime, wMyoGLEWhEHlyvfkNKIdOvjSeak);
	}

	private void RFDPexajhTcXvizzpCmOkHbzMGox()
	{
		hmcZJavdRjdndRuzheyiFfLNpQS(xFozUZAkswavgJXymWbLdbfYIkt);
		EAkChchgpneGPakFUTPVByHUjQB.Clear();
		gHrwLxhBFrNohToHFzgwYZPPyQW = 0;
		fVSVbysthXNRCkwppIAMegUQvIA = false;
	}

	private void hmcZJavdRjdndRuzheyiFfLNpQS(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)TDSsDXrDcmOPWbTmgULNLRhBxfy);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool dTJxVjyhLNHzuHuNbHanNnEFpHz()
	{
		if (YTuIOMpFukbXbkKnAizSYzMkMvz >= 10)
		{
			return false;
		}
		if (!mGeamQKlJWYHZkhyRnLpcYadMTxi())
		{
			YTuIOMpFukbXbkKnAizSYzMkMvz++;
			return false;
		}
		if (YTuIOMpFukbXbkKnAizSYzMkMvz > 0)
		{
			YTuIOMpFukbXbkKnAizSYzMkMvz = 0;
		}
		return true;
	}

	private bool mGeamQKlJWYHZkhyRnLpcYadMTxi()
	{
		if (JePRsKDzfKyifblWhjAzgrDWyvb != UvOafjjHDydfBDHpjrlzeDLuZok.UOTgSnHccjTLBHASvNpwkIZatFi)
		{
			return true;
		}
		if (!IsConnected)
		{
			return false;
		}
		IntPtr intPtr = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(htaMilNTPYUsZhoBbkevwTQQsLi, wLgsatiSRzspXBQkeKrpifqDJhM.CyOFIHNLpseSHfRtTBhWynOZqdbf, 3221225472u, rUSAwXbYObnIJBpUJPClFxhEcTAH.VsdksCukYWYYZgKCNnHZCjNeZgx | rUSAwXbYObnIJBpUJPClFxhEcTAH.fvdeABpWKzEvnyVAekRvohXyaXK);
		if (intPtr == UvOafjjHDydfBDHpjrlzeDLuZok.UOTgSnHccjTLBHASvNpwkIZatFi)
		{
			return false;
		}
		JePRsKDzfKyifblWhjAzgrDWyvb = intPtr;
		return true;
	}

	private void WOLsmFNlIJeAQHmPXjSXWDEbbnA()
	{
		if (!(JePRsKDzfKyifblWhjAzgrDWyvb == UvOafjjHDydfBDHpjrlzeDLuZok.UOTgSnHccjTLBHASvNpwkIZatFi))
		{
			awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(JePRsKDzfKyifblWhjAzgrDWyvb);
			JePRsKDzfKyifblWhjAzgrDWyvb = UvOafjjHDydfBDHpjrlzeDLuZok.UOTgSnHccjTLBHASvNpwkIZatFi;
		}
	}

	[MonoPInvokeCallback(typeof(UvOafjjHDydfBDHpjrlzeDLuZok.XSQDJtDcVmmAiMIsdvnJleiueFYY))]
	private unsafe static void mDuHZbfwWkWEtqHRaaFgDJxjMvFt(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<QmmXwRrPsMGwaWyZpjTkGiVKEVE>(instanceId, out var instance))
		{
			return;
		}
		lock (instance.sTqvGVmDRlMvomfhEsrSjdpChcT)
		{
			instance.gHrwLxhBFrNohToHFzgwYZPPyQW = P_0;
			instance.fVSVbysthXNRCkwppIAMegUQvIA = false;
		}
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~QmmXwRrPsMGwaWyZpjTkGiVKEVE()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		using (new Locker(UkSQMxhWAfZWdyeGnHhHROmrpEC))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(TDSsDXrDcmOPWbTmgULNLRhBxfy);
			}
			WOLsmFNlIJeAQHmPXjSXWDEbbnA();
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void AtheRvMnpVCgbttvPAbwOeshVKa(string P_0)
	{
	}
}
