using System;
using System.Diagnostics;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class tGsCfcIZaFUYHZmkTOuxFfEHfNif : IDisposable
{
	private enum LPljXhZwlStJPwvaEEDXqfEZCffU
	{
		Idle = 0,
		Waiting = 1,
		ErrorPending = 2,
		FinishedError = 3,
		SuccessPending = 4,
		FinishedSuccess = 5
	}

	public enum GWDTUGgUPsUVJfFjnVfYOpezhWTL
	{
		Idle = 0,
		Success = 1,
		Error = 2,
		Waiting = 3,
		CriticalError = 4
	}

	public const int aqFfLHezAgEfbatuZwCSlmgJEjRK = 8;

	private const int DBSsavVnzbjwHawSkJoAQedDasnE = 10;

	private readonly string CNparbjNsMvkcnwcKbZxBnIOvTEnA;

	private IntPtr ikKnAXIqdTugPzGCZwbrtYcnTxFr = rsxoYEWMRdOVQQjoXiIedQYbgtAN.EPmpsgTfEqcUjaloANcFZoGCvlFO;

	private readonly NativeBuffer apcFScZPNLNgMYBSxEvpIURctzgQ;

	private readonly int FcliugawSyPKWNuXKMizIdgisEzzB;

	private readonly rsxoYEWMRdOVQQjoXiIedQYbgtAN.QCaMDAFchXLBwGIiKPvbtAgVcOiD GrxFjQQDWnVTUzFOQjeTqhMvhjyU;

	private readonly object lvKarXnLOuywlaLStJJPOujxKOoS;

	private readonly uint EqQiYRlMqNvasdrDxssCVqnyHhBiA;

	private global::pXEMtXAjzAdSPdYHscBwifOaLqDkA<rsxoYEWMRdOVQQjoXiIedQYbgtAN.dsBbcLDHXunOorlCxGYeVVeyPccK> JfqTSmTFrbiNCicIiZbvGcLuXAdf;

	private LPljXhZwlStJPwvaEEDXqfEZCffU JoMcsyEloQKCWtnnMjyUBsEIzVVPb;

	private int PFHwPcsfupIidTerHpuKCMaTgdYS;

	private bool ofSklnnTVZrwvPEJBuRMMFQkOLtk;

	private int OVtqKVuGjLYQdRZGjecPtyRwdOlQ;

	private int qMKPvBVIZJBdtHePuRLamgHQstxEA;

	public readonly int RWmXpltukFMGhrUnMviKlgiouPeY;

	private bool vCmDTuZNrAEKreJbbQfQFMYBmsUTB;

	private bool pjeAbloDVKQVivlVVMtZQTqmIUEQ => CDjRvZGPLAcfDJlYHLOLilziojJi.knCyOJaysYQJVIqtswnkBPDvDSTs(CNparbjNsMvkcnwcKbZxBnIOvTEnA);

	public tGsCfcIZaFUYHZmkTOuxFfEHfNif(string P_0, int P_1, int P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		EqQiYRlMqNvasdrDxssCVqnyHhBiA = ObjectInstanceTracker.Default.Register(this);
		CNparbjNsMvkcnwcKbZxBnIOvTEnA = P_0;
		if (!xcRltGXsviMSlHbGBMnrLuBhNkgn())
		{
			throw new Exception("Could not open HID device.");
		}
		FcliugawSyPKWNuXKMizIdgisEzzB = P_1;
		RWmXpltukFMGhrUnMviKlgiouPeY = P_1 + 8;
		apcFScZPNLNgMYBSxEvpIURctzgQ = new NativeBuffer(RWmXpltukFMGhrUnMviKlgiouPeY);
		JfqTSmTFrbiNCicIiZbvGcLuXAdf = new global::pXEMtXAjzAdSPdYHscBwifOaLqDkA<rsxoYEWMRdOVQQjoXiIedQYbgtAN.dsBbcLDHXunOorlCxGYeVVeyPccK>();
		JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.Idle;
		PFHwPcsfupIidTerHpuKCMaTgdYS = ((P_2 < 0) ? 65535 : P_2);
		lvKarXnLOuywlaLStJJPOujxKOoS = new object();
		GrxFjQQDWnVTUzFOQjeTqhMvhjyU = waeXylUNjzWgVmyEjuRaFVifJwLD;
		YNmsecpFcfvcCkZMwvfUVBIYXnpg();
	}

	public GWDTUGgUPsUVJfFjnVfYOpezhWTL KxCecyYasVJDPEEjFyFPAmYMHDih(byte[] P_0)
	{
		lock (lvKarXnLOuywlaLStJJPOujxKOoS)
		{
			if (vCmDTuZNrAEKreJbbQfQFMYBmsUTB)
			{
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.CriticalError;
			}
			if (!WlokyIobhFVeWIQppBUauEMSJSyx())
			{
				return (qMKPvBVIZJBdtHePuRLamgHQstxEA >= 10) ? GWDTUGgUPsUVJfFjnVfYOpezhWTL.CriticalError : GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < RWmXpltukFMGhrUnMviKlgiouPeY)
			{
				int rWmXpltukFMGhrUnMviKlgiouPeY = RWmXpltukFMGhrUnMviKlgiouPeY;
				throw new Exception("buffer must be at least " + rWmXpltukFMGhrUnMviKlgiouPeY + " bytes");
			}
			switch (JoMcsyEloQKCWtnnMjyUBsEIzVVPb)
			{
			case LPljXhZwlStJPwvaEEDXqfEZCffU.Idle:
				cIjKTfcDOnvMllDlZwSXKAPQYQbo();
				break;
			case LPljXhZwlStJPwvaEEDXqfEZCffU.Waiting:
				SDdLzSlMOURvuxpBLLNFQUQtOTkC();
				break;
			case LPljXhZwlStJPwvaEEDXqfEZCffU.ErrorPending:
				TUpYGVqncuaAZDvrvSGWMcZIEyXe();
				break;
			case LPljXhZwlStJPwvaEEDXqfEZCffU.SuccessPending:
				jpKSqRjfhQeVciaFCuxWEsASjNhF();
				break;
			}
			switch (JoMcsyEloQKCWtnnMjyUBsEIzVVPb)
			{
			case LPljXhZwlStJPwvaEEDXqfEZCffU.Idle:
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Idle;
			case LPljXhZwlStJPwvaEEDXqfEZCffU.Waiting:
			case LPljXhZwlStJPwvaEEDXqfEZCffU.ErrorPending:
			case LPljXhZwlStJPwvaEEDXqfEZCffU.SuccessPending:
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Waiting;
			case LPljXhZwlStJPwvaEEDXqfEZCffU.FinishedSuccess:
				apcFScZPNLNgMYBSxEvpIURctzgQ.TryReadBytes(P_0, RWmXpltukFMGhrUnMviKlgiouPeY);
				JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.Idle;
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Success;
			case LPljXhZwlStJPwvaEEDXqfEZCffU.FinishedError:
				JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.Idle;
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool cIjKTfcDOnvMllDlZwSXKAPQYQbo()
	{
		if (JoMcsyEloQKCWtnnMjyUBsEIzVVPb != LPljXhZwlStJPwvaEEDXqfEZCffU.Idle)
		{
			int joMcsyEloQKCWtnnMjyUBsEIzVVPb = (int)JoMcsyEloQKCWtnnMjyUBsEIzVVPb;
			throw new Exception("Cannot StartRead from this state. State = " + joMcsyEloQKCWtnnMjyUBsEIzVVPb);
		}
		try
		{
			RptKCiHzXFATzSkhEaPRfDJbMqhR();
			bool num = rsxoYEWMRdOVQQjoXiIedQYbgtAN.GRAoHAiqoODPzkmNWnNQLgchkDtAb(ikKnAXIqdTugPzGCZwbrtYcnTxFr, apcFScZPNLNgMYBSxEvpIURctzgQ, (uint)FcliugawSyPKWNuXKMizIdgisEzzB, WCkkisRdteszJrItqAKVBwrIDACB.iROEUBXKiHsLuFzmtEadvrVvfwBfA(JfqTSmTFrbiNCicIiZbvGcLuXAdf.dSbaYNVaWvdDoJwzbusNEPGxxkhu), GrxFjQQDWnVTUzFOQjeTqhMvhjyU);
			if (num)
			{
				JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.Waiting;
				ofSklnnTVZrwvPEJBuRMMFQkOLtk = true;
			}
			else
			{
				kzbmLwTiYnlRyKfhYCZFknOKbEyeA();
			}
			return num;
		}
		catch (Exception)
		{
			kzbmLwTiYnlRyKfhYCZFknOKbEyeA();
			return false;
		}
	}

	private void SDdLzSlMOURvuxpBLLNFQUQtOTkC()
	{
		if (JoMcsyEloQKCWtnnMjyUBsEIzVVPb != LPljXhZwlStJPwvaEEDXqfEZCffU.Waiting)
		{
			int joMcsyEloQKCWtnnMjyUBsEIzVVPb = (int)JoMcsyEloQKCWtnnMjyUBsEIzVVPb;
			throw new Exception("Cannot CheckReadStatus from this state. State = " + joMcsyEloQKCWtnnMjyUBsEIzVVPb);
		}
		switch (IRuuxqVjVQDmeWgwIjkdSmPwaRiDA())
		{
		case GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error:
			kzbmLwTiYnlRyKfhYCZFknOKbEyeA();
			break;
		case GWDTUGgUPsUVJfFjnVfYOpezhWTL.Success:
			RDFOUVXVqpuVtyrjKFfrfqQaFljBA();
			break;
		case GWDTUGgUPsUVJfFjnVfYOpezhWTL.Waiting:
			break;
		}
	}

	private GWDTUGgUPsUVJfFjnVfYOpezhWTL IRuuxqVjVQDmeWgwIjkdSmPwaRiDA()
	{
		if (JoMcsyEloQKCWtnnMjyUBsEIzVVPb != LPljXhZwlStJPwvaEEDXqfEZCffU.Waiting)
		{
			return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
		}
		try
		{
			switch (rsxoYEWMRdOVQQjoXiIedQYbgtAN.ETOCLEEWaBzXVtZThSyEmtkNJqnL(PFHwPcsfupIidTerHpuKCMaTgdYS, true))
			{
			case 0u:
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Waiting;
			case 192u:
			{
				if (!rsxoYEWMRdOVQQjoXiIedQYbgtAN.fRzrefwzaRkriOwVedzOPcoozfjU(ikKnAXIqdTugPzGCZwbrtYcnTxFr, WCkkisRdteszJrItqAKVBwrIDACB.iROEUBXKiHsLuFzmtEadvrVvfwBfA(JfqTSmTFrbiNCicIiZbvGcLuXAdf.dSbaYNVaWvdDoJwzbusNEPGxxkhu), out var num, false))
				{
					return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
				}
				return (num > 0) ? GWDTUGgUPsUVJfFjnVfYOpezhWTL.Success : GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Waiting;
			default:
				return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
			}
		}
		catch
		{
			return GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error;
		}
	}

	private void kzbmLwTiYnlRyKfhYCZFknOKbEyeA()
	{
		JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.ErrorPending;
		TUpYGVqncuaAZDvrvSGWMcZIEyXe();
	}

	private void TUpYGVqncuaAZDvrvSGWMcZIEyXe()
	{
		if (JoMcsyEloQKCWtnnMjyUBsEIzVVPb != LPljXhZwlStJPwvaEEDXqfEZCffU.ErrorPending)
		{
			int joMcsyEloQKCWtnnMjyUBsEIzVVPb = (int)JoMcsyEloQKCWtnnMjyUBsEIzVVPb;
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + joMcsyEloQKCWtnnMjyUBsEIzVVPb);
		}
		JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.FinishedError;
	}

	private void RDFOUVXVqpuVtyrjKFfrfqQaFljBA()
	{
		JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.SuccessPending;
		jpKSqRjfhQeVciaFCuxWEsASjNhF();
	}

	private void jpKSqRjfhQeVciaFCuxWEsASjNhF()
	{
		if (JoMcsyEloQKCWtnnMjyUBsEIzVVPb != LPljXhZwlStJPwvaEEDXqfEZCffU.SuccessPending)
		{
			int joMcsyEloQKCWtnnMjyUBsEIzVVPb = (int)JoMcsyEloQKCWtnnMjyUBsEIzVVPb;
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + joMcsyEloQKCWtnnMjyUBsEIzVVPb);
		}
		JoMcsyEloQKCWtnnMjyUBsEIzVVPb = LPljXhZwlStJPwvaEEDXqfEZCffU.FinishedSuccess;
		apcFScZPNLNgMYBSxEvpIURctzgQ.Write(ReInput.realTime, FcliugawSyPKWNuXKMizIdgisEzzB);
	}

	private void RptKCiHzXFATzSkhEaPRfDJbMqhR()
	{
		YNmsecpFcfvcCkZMwvfUVBIYXnpg();
		apcFScZPNLNgMYBSxEvpIURctzgQ.Clear();
		OVtqKVuGjLYQdRZGjecPtyRwdOlQ = 0;
		ofSklnnTVZrwvPEJBuRMMFQkOLtk = false;
	}

	private void YNmsecpFcfvcCkZMwvfUVBIYXnpg()
	{
		rsxoYEWMRdOVQQjoXiIedQYbgtAN.dsBbcLDHXunOorlCxGYeVVeyPccK dsBbcLDHXunOorlCxGYeVVeyPccK = default(rsxoYEWMRdOVQQjoXiIedQYbgtAN.dsBbcLDHXunOorlCxGYeVVeyPccK);
		dsBbcLDHXunOorlCxGYeVVeyPccK.afMTVDqkuvwakBgetMFpPXxbXrjk = new IntPtr((int)EqQiYRlMqNvasdrDxssCVqnyHhBiA);
		dsBbcLDHXunOorlCxGYeVVeyPccK.EGaVTRVWYHajbgGsaqKeidPJlWEC = IntPtr.Zero;
		dsBbcLDHXunOorlCxGYeVVeyPccK.IvmYNjEnFUSVeVfaPipfitSspdTFA = IntPtr.Zero;
		dsBbcLDHXunOorlCxGYeVVeyPccK.dJuGRJEsAtkVrgUDzDQGBcQdkHcVB = 0;
		dsBbcLDHXunOorlCxGYeVVeyPccK.aEDLQBBvgIpJAlqFABHOIkBANfyg = 0;
		JfqTSmTFrbiNCicIiZbvGcLuXAdf.DBBavThFHOYrxmjQYwmxgRtwFMUmA = dsBbcLDHXunOorlCxGYeVVeyPccK;
	}

	private bool WlokyIobhFVeWIQppBUauEMSJSyx()
	{
		if (qMKPvBVIZJBdtHePuRLamgHQstxEA >= 10)
		{
			return false;
		}
		if (!xcRltGXsviMSlHbGBMnrLuBhNkgn())
		{
			qMKPvBVIZJBdtHePuRLamgHQstxEA++;
			return false;
		}
		if (qMKPvBVIZJBdtHePuRLamgHQstxEA > 0)
		{
			qMKPvBVIZJBdtHePuRLamgHQstxEA = 0;
		}
		return true;
	}

	private bool xcRltGXsviMSlHbGBMnrLuBhNkgn()
	{
		if (ikKnAXIqdTugPzGCZwbrtYcnTxFr != rsxoYEWMRdOVQQjoXiIedQYbgtAN.EPmpsgTfEqcUjaloANcFZoGCvlFO)
		{
			return true;
		}
		if (!pjeAbloDVKQVivlVVMtZQTqmIUEQ)
		{
			return false;
		}
		IntPtr intPtr = ZrLZfadkjQbKLybIbLvPGHmrChbIA.XcLeSVfpnVpJZbjnkYBBREgvzrizb(CNparbjNsMvkcnwcKbZxBnIOvTEnA, RamiCIGPZqECmPKLELdsevddQdaEc.Overlapped, 3221225472u, YBAWjapfComXseAxdFzwoSejVvgq.ShareRead | YBAWjapfComXseAxdFzwoSejVvgq.ShareWrite);
		if (intPtr == rsxoYEWMRdOVQQjoXiIedQYbgtAN.EPmpsgTfEqcUjaloANcFZoGCvlFO)
		{
			return false;
		}
		ikKnAXIqdTugPzGCZwbrtYcnTxFr = intPtr;
		return true;
	}

	private void jfPuLYECgvrpMhLqcOnYkSCwEotv()
	{
		if (!(ikKnAXIqdTugPzGCZwbrtYcnTxFr == rsxoYEWMRdOVQQjoXiIedQYbgtAN.EPmpsgTfEqcUjaloANcFZoGCvlFO))
		{
			ZrLZfadkjQbKLybIbLvPGHmrChbIA.SKhjxCllJjURHOAxQCozcoVqFXyHA(ikKnAXIqdTugPzGCZwbrtYcnTxFr);
			ikKnAXIqdTugPzGCZwbrtYcnTxFr = rsxoYEWMRdOVQQjoXiIedQYbgtAN.EPmpsgTfEqcUjaloANcFZoGCvlFO;
		}
	}

	[MonoPInvokeCallback(typeof(rsxoYEWMRdOVQQjoXiIedQYbgtAN.QCaMDAFchXLBwGIiKPvbtAgVcOiD))]
	private static void waeXylUNjzWgVmyEjuRaFVifJwLD(int P_0, int P_1, IntPtr P_2)
	{
	}

	public void Dispose()
	{
		bJsHUdFwbNawsMtmROAHwFwhirWr(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void fsCQRCULIYcYZQyGtQubSGEjxrhE()
	{
		try
		{
			bJsHUdFwbNawsMtmROAHwFwhirWr(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void bJsHUdFwbNawsMtmROAHwFwhirWr(bool P_0)
	{
		if (vCmDTuZNrAEKreJbbQfQFMYBmsUTB)
		{
			return;
		}
		using (new Locker(lvKarXnLOuywlaLStJJPOujxKOoS))
		{
			if (P_0)
			{
				JfqTSmTFrbiNCicIiZbvGcLuXAdf.Dispose();
				ObjectInstanceTracker.Default.Unregister(EqQiYRlMqNvasdrDxssCVqnyHhBiA);
			}
			jfPuLYECgvrpMhLqcOnYkSCwEotv();
			vCmDTuZNrAEKreJbbQfQFMYBmsUTB = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void oTYGhKldQIUNFrKUdFveFmsOxZmL(string P_0)
	{
	}
}
