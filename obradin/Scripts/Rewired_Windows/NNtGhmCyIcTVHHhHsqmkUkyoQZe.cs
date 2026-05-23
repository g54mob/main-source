using System;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class NNtGhmCyIcTVHHhHsqmkUkyoQZe : IDisposable
{
	private enum UEpojiHedJZnoTGFxwrYJBAxlwX
	{
		rFobbojpJYIzanfETPcXNoEpUYjh = 0,
		ZaJylzQsmYWLaerQmUHcXmkezBb = 1,
		OzmNjAtHFwrYRyQiXjrWEeVbydK = 2,
		IKTxtvTKXHcqEhXZdMaOIsyDjBW = 3,
		NEqotIlwpKwGcyqkctIuSIkjhekC = 4,
		xevWNOjbMXRouqmcGmbiEvDkENU = 5
	}

	public enum HNFrmcuxsvlQCudJezJFkfgEVpb
	{
		rFobbojpJYIzanfETPcXNoEpUYjh = 0,
		mmVARMJeNgPzFhCEbPdQSlTtUNt = 1,
		FWRVKWUtSLvoGvEHthzaKWOjYJH = 2,
		ZaJylzQsmYWLaerQmUHcXmkezBb = 3,
		PpIwuxfuETTZCOzlqbWdESbltdW = 4
	}

	public const int ogDxBkdGFLTCIDzwnzPaKJAtUyA = 4;

	private const int aHlbWTqULPUeqegcmMFFSQxYhIM = 10;

	private readonly string iufetWAkfsCRoMgLqadxMkhwFLWm;

	private IntPtr AWAUOziGBmNTEuhEcaHpkZywwUF = FAybFIUyhQQoIUWFiuSraaiMBJE.DQWXRKcyAVvigKGAwvwioqgMjPY;

	private readonly NativeBuffer RlrDFPWlIVBjihBXNSARRWgibHv;

	private readonly int lmdfYpnLigkkWkYhMXRIMcWkmvA;

	private readonly FAybFIUyhQQoIUWFiuSraaiMBJE.uMDGCDVqhCpkSZqAjCaSmJeGbpP veUKzYgVNteICDFvpbjlqFILAbG;

	private readonly object bOloMsZBnFBtLtUnNOrAbLOkiovJ;

	private readonly object VINZXWAbaPDqWfzSovoRGXPBoQkH;

	private readonly uint QWVdvsKoWWfEvuBabBDZBWElfvU;

	private NativeOverlapped eKrfJwrbMIbVFHKkxYXVOdWsrgRF;

	private UEpojiHedJZnoTGFxwrYJBAxlwX djuCKGrdSZWasYVTwUyXOvuznfq;

	private int OlqaTchTSDojmRCuWnpCErTJEFBf;

	private bool qwRDcDRGZpnstfChioBKgqxmlUg;

	private int bFalkQAezJwkKAJHWuweEgkjAwk;

	private int XRhPDxSMVKgfEjibTypWWclStpH;

	public readonly int juCkJFLIeAPcLFGJtXaEcgNdntF;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	private bool IsConnected
	{
		get
		{
			return qRcrmPWSlvohNRTlmCdEtNVJlYH.bxkbtDHUhtfxsVpGHlQtNwqQzBh(iufetWAkfsCRoMgLqadxMkhwFLWm);
		}
	}

	public NNtGhmCyIcTVHHhHsqmkUkyoQZe(string devicePath, int reportLength, int timeout)
	{
		if (string.IsNullOrEmpty(devicePath))
		{
			throw new ArgumentNullException("devicePath");
		}
		if (reportLength <= 0)
		{
			throw new ArgumentOutOfRangeException("reportLength must be > 0");
		}
		QWVdvsKoWWfEvuBabBDZBWElfvU = ObjectInstanceTracker.Default.Register(this);
		iufetWAkfsCRoMgLqadxMkhwFLWm = devicePath;
		if (!vgbQbpWhromgiukuSWYnItPaIXD())
		{
			throw new Exception("Could not open HID device.");
		}
		lmdfYpnLigkkWkYhMXRIMcWkmvA = reportLength;
		juCkJFLIeAPcLFGJtXaEcgNdntF = reportLength + 4;
		RlrDFPWlIVBjihBXNSARRWgibHv = new NativeBuffer(juCkJFLIeAPcLFGJtXaEcgNdntF);
		eKrfJwrbMIbVFHKkxYXVOdWsrgRF = default(NativeOverlapped);
		djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.rFobbojpJYIzanfETPcXNoEpUYjh;
		OlqaTchTSDojmRCuWnpCErTJEFBf = ((timeout < 0) ? 65535 : timeout);
		bOloMsZBnFBtLtUnNOrAbLOkiovJ = new object();
		VINZXWAbaPDqWfzSovoRGXPBoQkH = new object();
		veUKzYgVNteICDFvpbjlqFILAbG = dBxNCORYaWbhEENDvlAiTzOgbhb;
		qbpCLNKEvBOJKYdlcpNePfobhLw(eKrfJwrbMIbVFHKkxYXVOdWsrgRF);
	}

	public HNFrmcuxsvlQCudJezJFkfgEVpb NanoMDSNERLILwGbZOVIzaIWByQA(byte[] P_0)
	{
		lock (VINZXWAbaPDqWfzSovoRGXPBoQkH)
		{
			if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
			{
				return HNFrmcuxsvlQCudJezJFkfgEVpb.PpIwuxfuETTZCOzlqbWdESbltdW;
			}
			if (!aSUkkYTdGfEELMVBghjpBCftDoP())
			{
				return (XRhPDxSMVKgfEjibTypWWclStpH >= 10) ? HNFrmcuxsvlQCudJezJFkfgEVpb.PpIwuxfuETTZCOzlqbWdESbltdW : HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (P_0.Length < juCkJFLIeAPcLFGJtXaEcgNdntF)
			{
				throw new Exception("buffer must be at least " + juCkJFLIeAPcLFGJtXaEcgNdntF + " bytes");
			}
			switch (djuCKGrdSZWasYVTwUyXOvuznfq)
			{
			case UEpojiHedJZnoTGFxwrYJBAxlwX.rFobbojpJYIzanfETPcXNoEpUYjh:
				oXvCjKEPCpMpVKrCNuZWnnJOHBmR();
				break;
			case UEpojiHedJZnoTGFxwrYJBAxlwX.ZaJylzQsmYWLaerQmUHcXmkezBb:
				EHgRnJlVOkClotcMkdufcsPoInR();
				break;
			case UEpojiHedJZnoTGFxwrYJBAxlwX.OzmNjAtHFwrYRyQiXjrWEeVbydK:
				qobvPVpwMZourtuoozukCqlyULt();
				break;
			case UEpojiHedJZnoTGFxwrYJBAxlwX.NEqotIlwpKwGcyqkctIuSIkjhekC:
				qdeDwyobZScwuiUTXTryzYmJZfW();
				break;
			}
			switch (djuCKGrdSZWasYVTwUyXOvuznfq)
			{
			case UEpojiHedJZnoTGFxwrYJBAxlwX.rFobbojpJYIzanfETPcXNoEpUYjh:
				return HNFrmcuxsvlQCudJezJFkfgEVpb.rFobbojpJYIzanfETPcXNoEpUYjh;
			case UEpojiHedJZnoTGFxwrYJBAxlwX.ZaJylzQsmYWLaerQmUHcXmkezBb:
			case UEpojiHedJZnoTGFxwrYJBAxlwX.OzmNjAtHFwrYRyQiXjrWEeVbydK:
			case UEpojiHedJZnoTGFxwrYJBAxlwX.NEqotIlwpKwGcyqkctIuSIkjhekC:
				return HNFrmcuxsvlQCudJezJFkfgEVpb.ZaJylzQsmYWLaerQmUHcXmkezBb;
			case UEpojiHedJZnoTGFxwrYJBAxlwX.xevWNOjbMXRouqmcGmbiEvDkENU:
				RlrDFPWlIVBjihBXNSARRWgibHv.TryReadBytes(P_0, juCkJFLIeAPcLFGJtXaEcgNdntF);
				djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.rFobbojpJYIzanfETPcXNoEpUYjh;
				return HNFrmcuxsvlQCudJezJFkfgEVpb.mmVARMJeNgPzFhCEbPdQSlTtUNt;
			case UEpojiHedJZnoTGFxwrYJBAxlwX.IKTxtvTKXHcqEhXZdMaOIsyDjBW:
				djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.rFobbojpJYIzanfETPcXNoEpUYjh;
				return HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
			default:
				throw new NotImplementedException();
			}
		}
	}

	private bool oXvCjKEPCpMpVKrCNuZWnnJOHBmR()
	{
		if (djuCKGrdSZWasYVTwUyXOvuznfq != UEpojiHedJZnoTGFxwrYJBAxlwX.rFobbojpJYIzanfETPcXNoEpUYjh)
		{
			throw new Exception("Cannot StartRead from this state. State = " + (int)djuCKGrdSZWasYVTwUyXOvuznfq);
		}
		try
		{
			IbWidGCHJzvyGGwvigfCOXYPcWYT();
			lock (bOloMsZBnFBtLtUnNOrAbLOkiovJ)
			{
				bool flag = FAybFIUyhQQoIUWFiuSraaiMBJE.qletEBZUCuwMpHdQNgOUvJVODzT(AWAUOziGBmNTEuhEcaHpkZywwUF, RlrDFPWlIVBjihBXNSARRWgibHv, (uint)lmdfYpnLigkkWkYhMXRIMcWkmvA, ref eKrfJwrbMIbVFHKkxYXVOdWsrgRF, veUKzYgVNteICDFvpbjlqFILAbG);
				if (flag)
				{
					djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.ZaJylzQsmYWLaerQmUHcXmkezBb;
					qwRDcDRGZpnstfChioBKgqxmlUg = true;
				}
				else
				{
					FWRVKWUtSLvoGvEHthzaKWOjYJH();
				}
				return flag;
			}
		}
		catch (Exception)
		{
			FWRVKWUtSLvoGvEHthzaKWOjYJH();
			return false;
		}
	}

	private void EHgRnJlVOkClotcMkdufcsPoInR()
	{
		if (djuCKGrdSZWasYVTwUyXOvuznfq != UEpojiHedJZnoTGFxwrYJBAxlwX.ZaJylzQsmYWLaerQmUHcXmkezBb)
		{
			throw new Exception("Cannot CheckReadStatus from this state. State = " + (int)djuCKGrdSZWasYVTwUyXOvuznfq);
		}
		switch (bINgHkMnIrExRDesYQVBiTCenATa())
		{
		case HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH:
			FWRVKWUtSLvoGvEHthzaKWOjYJH();
			break;
		case HNFrmcuxsvlQCudJezJFkfgEVpb.mmVARMJeNgPzFhCEbPdQSlTtUNt:
			mmVARMJeNgPzFhCEbPdQSlTtUNt();
			break;
		case HNFrmcuxsvlQCudJezJFkfgEVpb.ZaJylzQsmYWLaerQmUHcXmkezBb:
			break;
		}
	}

	private HNFrmcuxsvlQCudJezJFkfgEVpb bINgHkMnIrExRDesYQVBiTCenATa()
	{
		if (djuCKGrdSZWasYVTwUyXOvuznfq != UEpojiHedJZnoTGFxwrYJBAxlwX.ZaJylzQsmYWLaerQmUHcXmkezBb)
		{
			return HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
		}
		try
		{
			switch (FAybFIUyhQQoIUWFiuSraaiMBJE.QxplxiIivBQVplrVWLqROOTUnDj(OlqaTchTSDojmRCuWnpCErTJEFBf, true))
			{
			case 0u:
				return HNFrmcuxsvlQCudJezJFkfgEVpb.ZaJylzQsmYWLaerQmUHcXmkezBb;
			case 192u:
			{
				int num;
				if (!FAybFIUyhQQoIUWFiuSraaiMBJE.vmpCTKkSqaWwekGwokgfBejYXGxT(AWAUOziGBmNTEuhEcaHpkZywwUF, ref eKrfJwrbMIbVFHKkxYXVOdWsrgRF, out num, false))
				{
					return HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
				}
				return (num > 0) ? HNFrmcuxsvlQCudJezJFkfgEVpb.mmVARMJeNgPzFhCEbPdQSlTtUNt : HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
			}
			case uint.MaxValue:
			case 128u:
			case 258u:
				return HNFrmcuxsvlQCudJezJFkfgEVpb.ZaJylzQsmYWLaerQmUHcXmkezBb;
			default:
				return HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
			}
		}
		catch
		{
			return HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH;
		}
	}

	private void FWRVKWUtSLvoGvEHthzaKWOjYJH()
	{
		djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.OzmNjAtHFwrYRyQiXjrWEeVbydK;
		qobvPVpwMZourtuoozukCqlyULt();
	}

	private void qobvPVpwMZourtuoozukCqlyULt()
	{
		if (djuCKGrdSZWasYVTwUyXOvuznfq != UEpojiHedJZnoTGFxwrYJBAxlwX.OzmNjAtHFwrYRyQiXjrWEeVbydK)
		{
			throw new Exception("Cannot CheckErrorFinished from this state. State = " + (int)djuCKGrdSZWasYVTwUyXOvuznfq);
		}
		djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.IKTxtvTKXHcqEhXZdMaOIsyDjBW;
	}

	private void mmVARMJeNgPzFhCEbPdQSlTtUNt()
	{
		djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.NEqotIlwpKwGcyqkctIuSIkjhekC;
		qdeDwyobZScwuiUTXTryzYmJZfW();
	}

	private void qdeDwyobZScwuiUTXTryzYmJZfW()
	{
		if (djuCKGrdSZWasYVTwUyXOvuznfq != UEpojiHedJZnoTGFxwrYJBAxlwX.NEqotIlwpKwGcyqkctIuSIkjhekC)
		{
			throw new Exception("Cannot CheckSuccessFinished from this state. State = " + (int)djuCKGrdSZWasYVTwUyXOvuznfq);
		}
		djuCKGrdSZWasYVTwUyXOvuznfq = UEpojiHedJZnoTGFxwrYJBAxlwX.xevWNOjbMXRouqmcGmbiEvDkENU;
		RlrDFPWlIVBjihBXNSARRWgibHv.Write(ReInput.realTime, lmdfYpnLigkkWkYhMXRIMcWkmvA);
	}

	private void IbWidGCHJzvyGGwvigfCOXYPcWYT()
	{
		qbpCLNKEvBOJKYdlcpNePfobhLw(eKrfJwrbMIbVFHKkxYXVOdWsrgRF);
		RlrDFPWlIVBjihBXNSARRWgibHv.Clear();
		bFalkQAezJwkKAJHWuweEgkjAwk = 0;
		qwRDcDRGZpnstfChioBKgqxmlUg = false;
	}

	private void qbpCLNKEvBOJKYdlcpNePfobhLw(NativeOverlapped P_0)
	{
		P_0.EventHandle = new IntPtr((int)QWVdvsKoWWfEvuBabBDZBWElfvU);
		P_0.InternalHigh = IntPtr.Zero;
		P_0.InternalLow = IntPtr.Zero;
		P_0.OffsetHigh = 0;
		P_0.OffsetLow = 0;
	}

	private bool aSUkkYTdGfEELMVBghjpBCftDoP()
	{
		if (XRhPDxSMVKgfEjibTypWWclStpH >= 10)
		{
			return false;
		}
		if (!vgbQbpWhromgiukuSWYnItPaIXD())
		{
			XRhPDxSMVKgfEjibTypWWclStpH++;
			return false;
		}
		if (XRhPDxSMVKgfEjibTypWWclStpH > 0)
		{
			XRhPDxSMVKgfEjibTypWWclStpH = 0;
		}
		return true;
	}

	private bool vgbQbpWhromgiukuSWYnItPaIXD()
	{
		if (AWAUOziGBmNTEuhEcaHpkZywwUF != FAybFIUyhQQoIUWFiuSraaiMBJE.DQWXRKcyAVvigKGAwvwioqgMjPY)
		{
			return true;
		}
		if (!IsConnected)
		{
			return false;
		}
		IntPtr intPtr = hdKCmGlHttTBdcjeWBCjBOXCTjJ.CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc, 3221225472u, utFNrkhqcRYjcoBIIPDdjrIEcTu.KdkAlnBkyoezudAOKFyDdMyEzPTm | utFNrkhqcRYjcoBIIPDdjrIEcTu.iQctmYQaAZvUIfEWvxxBsgVMmmY);
		if (intPtr == FAybFIUyhQQoIUWFiuSraaiMBJE.DQWXRKcyAVvigKGAwvwioqgMjPY)
		{
			return false;
		}
		AWAUOziGBmNTEuhEcaHpkZywwUF = intPtr;
		return true;
	}

	private void TSApgnckjiFbIGXJGqTSCpSNruA()
	{
		if (!(AWAUOziGBmNTEuhEcaHpkZywwUF == FAybFIUyhQQoIUWFiuSraaiMBJE.DQWXRKcyAVvigKGAwvwioqgMjPY))
		{
			hdKCmGlHttTBdcjeWBCjBOXCTjJ.BJCdvwujENgVreNoJVqDsUboZvX(AWAUOziGBmNTEuhEcaHpkZywwUF);
			AWAUOziGBmNTEuhEcaHpkZywwUF = FAybFIUyhQQoIUWFiuSraaiMBJE.DQWXRKcyAVvigKGAwvwioqgMjPY;
		}
	}

	[MonoPInvokeCallback(typeof(FAybFIUyhQQoIUWFiuSraaiMBJE.uMDGCDVqhCpkSZqAjCaSmJeGbpP))]
	private unsafe static void dBxNCORYaWbhEENDvlAiTzOgbhb(int P_0, int P_1, IntPtr P_2)
	{
		NativeOverlapped* ptr = (NativeOverlapped*)(void*)P_2;
		uint instanceId = (uint)ptr->EventHandle.ToInt32();
		NNtGhmCyIcTVHHhHsqmkUkyoQZe instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<NNtGhmCyIcTVHHhHsqmkUkyoQZe>(instanceId, out instance))
		{
			return;
		}
		lock (instance.bOloMsZBnFBtLtUnNOrAbLOkiovJ)
		{
			instance.bFalkQAezJwkKAJHWuweEgkjAwk = P_0;
			instance.qwRDcDRGZpnstfChioBKgqxmlUg = false;
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~NNtGhmCyIcTVHHhHsqmkUkyoQZe()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return;
		}
		using (new Locker(VINZXWAbaPDqWfzSovoRGXPBoQkH))
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(QWVdvsKoWWfEvuBabBDZBWElfvU);
			}
			TSApgnckjiFbIGXJGqTSCpSNruA();
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void HucVMWfyPbmJUcinWEkmKKBLBIA(string P_0)
	{
	}
}
