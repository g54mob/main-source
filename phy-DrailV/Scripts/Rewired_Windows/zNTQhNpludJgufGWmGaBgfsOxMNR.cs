using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class zNTQhNpludJgufGWmGaBgfsOxMNR : IDisposable
{
	private enum HbIcfOsCfqjmaGSUpKgrCPuSyKWQA
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum MBgDSvDSNKDYibXRWKLgWbEeWIqPA
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int GnxcKPKYtQERrsjfbLhTEaKCJJbPb = 8;

	private const int IOPbGkHVgUlCVBKvbgCyJwvsscdsb = 10;

	private readonly string SSTCClPgTrDnBShUmazYUjvOcCfu;

	private IntPtr iXafrGaJxrnLvEUDiasMbMuhAjsOB = xzEJGnblZZkOpksQsCkUEOgsHAvz.rikaApJklWsABgHiwwxLOaUwMhrc;

	private readonly NativeBuffer njPEqelkqUAXHcVOBySkfuuGgySaA;

	private readonly int PkFIEGYWQbqszSTaEpLhiCOIobbY;

	private readonly xzEJGnblZZkOpksQsCkUEOgsHAvz.UpJYSiqmZpMGPwsxjxHZMqhYZTTc PAqWzdZnbqklrdmKbtpCIoCzJPbL;

	private readonly object zAjqpvdKQYefhXIRewfqlrRvRmVJ;

	private readonly uint uUxrSJplaDEpWOwxloLgtQIVkefV;

	private nSpfnmzmpqiBgkjhLLrIIdyzJDyx<xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi> EHDwhRMwuFXukqFbvZboHpKYnyoF;

	private HbIcfOsCfqjmaGSUpKgrCPuSyKWQA ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb;

	private int wiEuMRiatEzRSeteUlHbXTVuKhuE;

	private bool WRzVwasglakdIDsmkNkdSjxARbFF;

	private int TeClUphEBGqelmPAAcgJEqiJqhZbA;

	private int fvJeeKhziJYqlrNaBzgbpwhsqamjA;

	public readonly int JbeYZmmGyNeFelOBrcXhcMVXtwaIA;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	private bool JaUeIycumyWlPCjeNyhEexyqywGbA => ASYbPqxUNkljqzCsqWpbFAZdrPyP.JaUeIycumyWlPCjeNyhEexyqywGbA(SSTCClPgTrDnBShUmazYUjvOcCfu);

	public zNTQhNpludJgufGWmGaBgfsOxMNR(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		uUxrSJplaDEpWOwxloLgtQIVkefV = ObjectInstanceTracker.Default.Register(this);
		SSTCClPgTrDnBShUmazYUjvOcCfu = P_0;
		if (!LHNbYAbAPpPeZIwnGCGUuHVAcIiq())
		{
			throw new Exception("Could not open HID device.");
		}
		PkFIEGYWQbqszSTaEpLhiCOIobbY = P_1;
		JbeYZmmGyNeFelOBrcXhcMVXtwaIA = P_1 + 8;
		njPEqelkqUAXHcVOBySkfuuGgySaA = new NativeBuffer(JbeYZmmGyNeFelOBrcXhcMVXtwaIA);
		EHDwhRMwuFXukqFbvZboHpKYnyoF = new nSpfnmzmpqiBgkjhLLrIIdyzJDyx<xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi>();
		ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Idle;
		wiEuMRiatEzRSeteUlHbXTVuKhuE = ((P_2 < 0) ? 65535 : P_2);
		zAjqpvdKQYefhXIRewfqlrRvRmVJ = new object();
		PAqWzdZnbqklrdmKbtpCIoCzJPbL = cnIpdkzvZakDDnlrlgBrzLORcxzM;
		WCFFzsHtLWMKfhauyUvHRdaBsqRcA();
	}

	public MBgDSvDSNKDYibXRWKLgWbEeWIqPA xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(byte[] P_0)
	{
		lock (zAjqpvdKQYefhXIRewfqlrRvRmVJ)
		{
			if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.CriticalError;
			}
			if (!UUaAHlGkBiPSmTqCcmlMwtbTvEkjA())
			{
				return (fvJeeKhziJYqlrNaBzgbpwhsqamjA >= 10) ? MBgDSvDSNKDYibXRWKLgWbEeWIqPA.CriticalError : MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < JbeYZmmGyNeFelOBrcXhcMVXtwaIA)
			{
				throw new Exception("buffer must be at least " + JbeYZmmGyNeFelOBrcXhcMVXtwaIA + " bytes");
			}
			switch (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb)
			{
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Idle:
				GWFAYxueMoxkvVJgRTetZTCiWGBg();
				break;
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Waiting:
				qHUHmuWOipDMDJRZmoLAEeVMByap();
				break;
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.ErrorPending:
				GRBaWoMOEQDyMCPnyPnLGaugSRafB();
				break;
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.SuccessPending:
				IgSNwVVLlXAsHEWELQZBTAmtTArt();
				break;
			}
			switch (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb)
			{
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Idle:
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Idle;
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Waiting:
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.ErrorPending:
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.SuccessPending:
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Waiting;
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.FinishedSuccess:
				njPEqelkqUAXHcVOBySkfuuGgySaA.TryReadBytes(P_0, JbeYZmmGyNeFelOBrcXhcMVXtwaIA);
				ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Idle;
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Success;
			case HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.FinishedError:
				ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Idle;
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool GWFAYxueMoxkvVJgRTetZTCiWGBg()
	{
		if (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb != HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Idle)
		{
			int zOGFzfbMwSbQXEoMgQOeZsvFgmZEb = (int)ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb;
			throw new Exception("Cannot StartRead from this state. State = " + zOGFzfbMwSbQXEoMgQOeZsvFgmZEb);
		}
		try
		{
			wSuERjejnukorMpeyvWlfiOlJujf();
			bool num = xzEJGnblZZkOpksQsCkUEOgsHAvz.MjOFGgcaalcoIhrTNRilRTHaTSciA(iXafrGaJxrnLvEUDiasMbMuhAjsOB, njPEqelkqUAXHcVOBySkfuuGgySaA, (uint)PkFIEGYWQbqszSTaEpLhiCOIobbY, SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(EHDwhRMwuFXukqFbvZboHpKYnyoF.dXHcFyHeaDiigomrUnUCJYjMNGxM), PAqWzdZnbqklrdmKbtpCIoCzJPbL);
			if (num)
			{
				ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Waiting;
				WRzVwasglakdIDsmkNkdSjxARbFF = true;
			}
			else
			{
				twtgkrpOoYbrjTaQpUrZgtQBNVqT();
			}
			return num;
		}
		catch (Exception)
		{
			twtgkrpOoYbrjTaQpUrZgtQBNVqT();
			return false;
		}
	}

	private void qHUHmuWOipDMDJRZmoLAEeVMByap()
	{
		if (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb != HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Waiting)
		{
			int zOGFzfbMwSbQXEoMgQOeZsvFgmZEb = (int)ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + zOGFzfbMwSbQXEoMgQOeZsvFgmZEb);
		}
		switch (TjzskHfxwgbXyMLnWTMcfLYKXImh())
		{
		case MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error:
			twtgkrpOoYbrjTaQpUrZgtQBNVqT();
			break;
		case MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Success:
			WQjpsdmbpxmvqTAFrYvxgMNLdWSBA();
			break;
		case MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Waiting:
			break;
		}
	}

	private MBgDSvDSNKDYibXRWKLgWbEeWIqPA TjzskHfxwgbXyMLnWTMcfLYKXImh()
	{
		if (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb != HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.Waiting)
		{
			return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
		}
		try
		{
			switch (xzEJGnblZZkOpksQsCkUEOgsHAvz.oAXGOJlTJGtUAZSGCFTywRYkuoQM(wiEuMRiatEzRSeteUlHbXTVuKhuE, true))
			{
			case 0u:
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Waiting;
			case 192u:
			{
				if (!xzEJGnblZZkOpksQsCkUEOgsHAvz.ZeDgZvfImvmDNmehqeKOIIrmPEGk(iXafrGaJxrnLvEUDiasMbMuhAjsOB, SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(EHDwhRMwuFXukqFbvZboHpKYnyoF.dXHcFyHeaDiigomrUnUCJYjMNGxM), out var num, false))
				{
					return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
				}
				return (num > 0) ? MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Success : MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Waiting;
			default:
				return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
			}
		}
		catch
		{
			return MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error;
		}
	}

	private void twtgkrpOoYbrjTaQpUrZgtQBNVqT()
	{
		ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.ErrorPending;
		GRBaWoMOEQDyMCPnyPnLGaugSRafB();
	}

	private void GRBaWoMOEQDyMCPnyPnLGaugSRafB()
	{
		if (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb != HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.ErrorPending)
		{
			int zOGFzfbMwSbQXEoMgQOeZsvFgmZEb = (int)ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + zOGFzfbMwSbQXEoMgQOeZsvFgmZEb);
		}
		ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.FinishedError;
	}

	private void WQjpsdmbpxmvqTAFrYvxgMNLdWSBA()
	{
		ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.SuccessPending;
		IgSNwVVLlXAsHEWELQZBTAmtTArt();
	}

	private void IgSNwVVLlXAsHEWELQZBTAmtTArt()
	{
		if (ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb != HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.SuccessPending)
		{
			int zOGFzfbMwSbQXEoMgQOeZsvFgmZEb = (int)ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + zOGFzfbMwSbQXEoMgQOeZsvFgmZEb);
		}
		ZOGFzfbMwSbQXEoMgQOeZsvFgmZEb = HbIcfOsCfqjmaGSUpKgrCPuSyKWQA.FinishedSuccess;
		njPEqelkqUAXHcVOBySkfuuGgySaA.Write(ReInput.realTime, PkFIEGYWQbqszSTaEpLhiCOIobbY);
	}

	private void wSuERjejnukorMpeyvWlfiOlJujf()
	{
		WCFFzsHtLWMKfhauyUvHRdaBsqRcA();
		njPEqelkqUAXHcVOBySkfuuGgySaA.Clear();
		TeClUphEBGqelmPAAcgJEqiJqhZbA = 0;
		WRzVwasglakdIDsmkNkdSjxARbFF = false;
	}

	private void WCFFzsHtLWMKfhauyUvHRdaBsqRcA()
	{
		xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi raofNouXMWakJRqhMsfMoESdiPTi = default(xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi);
		raofNouXMWakJRqhMsfMoESdiPTi.IwLVHLCtIzimkIHSIsynzpsIhPgR = new IntPtr((int)uUxrSJplaDEpWOwxloLgtQIVkefV);
		raofNouXMWakJRqhMsfMoESdiPTi.bWhMmLJyGcCLnYBWOnMSYcnkXleo = IntPtr.Zero;
		raofNouXMWakJRqhMsfMoESdiPTi.hPKVAdNUuHosKEQMJxPJMjDDinRl = IntPtr.Zero;
		raofNouXMWakJRqhMsfMoESdiPTi.PeNOekASTfSIuXooWbgIMEjUIORb = 0;
		raofNouXMWakJRqhMsfMoESdiPTi.FeyMtLCnVSEdrbiMlzlQGCYnKvGH = 0;
		EHDwhRMwuFXukqFbvZboHpKYnyoF.pWRdAJigDslyLjNIYbVMMkTWOPgC = raofNouXMWakJRqhMsfMoESdiPTi;
	}

	private bool UUaAHlGkBiPSmTqCcmlMwtbTvEkjA()
	{
		if (fvJeeKhziJYqlrNaBzgbpwhsqamjA >= 10)
		{
			return false;
		}
		if (!LHNbYAbAPpPeZIwnGCGUuHVAcIiq())
		{
			fvJeeKhziJYqlrNaBzgbpwhsqamjA++;
			return false;
		}
		if (fvJeeKhziJYqlrNaBzgbpwhsqamjA > 0)
		{
			fvJeeKhziJYqlrNaBzgbpwhsqamjA = 0;
		}
		return true;
	}

	private bool LHNbYAbAPpPeZIwnGCGUuHVAcIiq()
	{
		if (iXafrGaJxrnLvEUDiasMbMuhAjsOB != xzEJGnblZZkOpksQsCkUEOgsHAvz.rikaApJklWsABgHiwwxLOaUwMhrc)
		{
			return true;
		}
		if (!JaUeIycumyWlPCjeNyhEexyqywGbA)
		{
			return false;
		}
		IntPtr intPtr = VEavlBCjlwYFgIYiKEZpvYEuUTOH.qRGErlebaNBrfzcIPJHwDGgcBztOb(SSTCClPgTrDnBShUmazYUjvOcCfu, FBJyKviZPIDJRgxnjkLCYoNJwALW.Overlapped, 3221225472u, GTnUvTIDUEdlNImTKwVWFNCeIERq.ShareRead | GTnUvTIDUEdlNImTKwVWFNCeIERq.ShareWrite);
		if (intPtr == xzEJGnblZZkOpksQsCkUEOgsHAvz.rikaApJklWsABgHiwwxLOaUwMhrc)
		{
			return false;
		}
		iXafrGaJxrnLvEUDiasMbMuhAjsOB = intPtr;
		return true;
	}

	private void zXktUZPPGodJAcfQSusogOzdeqFo()
	{
		if (!(iXafrGaJxrnLvEUDiasMbMuhAjsOB == xzEJGnblZZkOpksQsCkUEOgsHAvz.rikaApJklWsABgHiwwxLOaUwMhrc))
		{
			VEavlBCjlwYFgIYiKEZpvYEuUTOH.nylTIQDqDLHmsQWIsXNPMMEUuYSL(iXafrGaJxrnLvEUDiasMbMuhAjsOB);
			iXafrGaJxrnLvEUDiasMbMuhAjsOB = xzEJGnblZZkOpksQsCkUEOgsHAvz.rikaApJklWsABgHiwwxLOaUwMhrc;
		}
	}

	[MonoPInvokeCallback(typeof(xzEJGnblZZkOpksQsCkUEOgsHAvz.UpJYSiqmZpMGPwsxjxHZMqhYZTTc))]
	private static void cnIpdkzvZakDDnlrlgBrzLORcxzM(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		using (new Locker(zAjqpvdKQYefhXIRewfqlrRvRmVJ))
		{
			if (P_0)
			{
				EHDwhRMwuFXukqFbvZboHpKYnyoF.Dispose();
				ObjectInstanceTracker.Default.Unregister(uUxrSJplaDEpWOwxloLgtQIVkefV);
			}
			zXktUZPPGodJAcfQSusogOzdeqFo();
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void xrAhtSQzgtFbfAidKmDjmPgpFAzc(string P_0)
	{
	}
}
