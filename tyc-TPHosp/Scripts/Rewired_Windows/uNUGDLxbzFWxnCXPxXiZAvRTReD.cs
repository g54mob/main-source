using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class uNUGDLxbzFWxnCXPxXiZAvRTReD
{
	public struct ZmXFQUItFfCeopshMNfCzCYqGWRT
	{
		public string dkOYsGfcBqjJtKGpPrHEqVMHAXL;

		public string QINdymBLIRcKJaTdWehjTiexQWpP;

		public string BBLDCyrjhriCIMUSPatTjPFDaMJ;

		public string sZTVNBCuaLCpFWwakJLSKjdBaQtD;

		public string BWWfqOGHzimTPJyuKMWFOzoTDFTp;

		public string whfLWjRAQlOxPrMOCusTYqWUczKe;

		public int zJUFHCGUdbCIfzJDVQhVSCDpvze;

		public int HEDDgbanPWSjQqpPkVaMOuDlZNA;

		public bool ujcVDandqSQmdWPvAsMWAutNffA;

		public string GzhOjAdMNgijAoffTkKrVXyBfEC;

		public ZmXFQUItFfCeopshMNfCzCYqGWRT(string path, string instanceId, string description, string manufacturer, string locationInfo, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			dkOYsGfcBqjJtKGpPrHEqVMHAXL = path;
			QINdymBLIRcKJaTdWehjTiexQWpP = usQKsbAGCyboWkvovXGOmVypyoBn.eeRbsFgjcGEcYbwbzwbvhdcMPuCo(path);
			BBLDCyrjhriCIMUSPatTjPFDaMJ = instanceId;
			sZTVNBCuaLCpFWwakJLSKjdBaQtD = description;
			BWWfqOGHzimTPJyuKMWFOzoTDFTp = manufacturer;
			whfLWjRAQlOxPrMOCusTYqWUczKe = locationInfo;
			HEDDgbanPWSjQqpPkVaMOuDlZNA = -1;
			zJUFHCGUdbCIfzJDVQhVSCDpvze = -1;
			ujcVDandqSQmdWPvAsMWAutNffA = isBluetoothDevice;
			GzhOjAdMNgijAoffTkKrVXyBfEC = bluetoothDeviceName;
			WrJFPYwfdOWFIuUeOAvHSbHXOUO();
		}

		private void WrJFPYwfdOWFIuUeOAvHSbHXOUO()
		{
			if (!string.IsNullOrEmpty(whfLWjRAQlOxPrMOCusTYqWUczKe))
			{
				int num = whfLWjRAQlOxPrMOCusTYqWUczKe.IndexOf("port_#", StringComparison.OrdinalIgnoreCase);
				int num2 = whfLWjRAQlOxPrMOCusTYqWUczKe.IndexOf("hub_#", StringComparison.OrdinalIgnoreCase);
				if (num >= 0 && num2 >= 0)
				{
					int.TryParse(whfLWjRAQlOxPrMOCusTYqWUczKe.Substring(num + 6, 4), out HEDDgbanPWSjQqpPkVaMOuDlZNA);
					int.TryParse(whfLWjRAQlOxPrMOCusTYqWUczKe.Substring(num2 + 5, 4), out zJUFHCGUdbCIfzJDVQhVSCDpvze);
				}
			}
		}
	}

	private struct lCGlcTJRGlrITVtUFSeNVGNeYQF
	{
		public int NGwwgCeMsknzPYfQRtXjIWZKKfc;

		public uint GnnQhACXOlBukhSoigbzYAqXksB;

		public string whfLWjRAQlOxPrMOCusTYqWUczKe;

		public lCGlcTJRGlrITVtUFSeNVGNeYQF(int parentIndex, uint deviceInstanceHandle, string locationInfo)
		{
			NGwwgCeMsknzPYfQRtXjIWZKKfc = parentIndex;
			GnnQhACXOlBukhSoigbzYAqXksB = deviceInstanceHandle;
			whfLWjRAQlOxPrMOCusTYqWUczKe = locationInfo;
		}
	}

	private struct GVmFwqSyMJtvWvIxvNsdgNTLALz
	{
		public readonly uint GnnQhACXOlBukhSoigbzYAqXksB;

		public readonly string LxfKiQYCsfycMVLnXczxhQDSoEBL;

		public GVmFwqSyMJtvWvIxvNsdgNTLALz(uint deviceInstanceHandle, string friendlyName)
		{
			GnnQhACXOlBukhSoigbzYAqXksB = deviceInstanceHandle;
			LxfKiQYCsfycMVLnXczxhQDSoEBL = ((friendlyName == null) ? string.Empty : friendlyName);
		}
	}

	private sealed class sqSlyiZktoHIngYgsICmOrbuktL
	{
		public string PrfPiHGhKrtcXNOrwmUoliXSVmH;

		public StringComparison tpxPqZIqNWaqRZvgskJXcpfyRFA;

		public bool hShGihnhRrJfGSgtgaclAfrxwUAA(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
		{
			return P_0.QINdymBLIRcKJaTdWehjTiexQWpP.Equals(PrfPiHGhKrtcXNOrwmUoliXSVmH, tpxPqZIqNWaqRZvgskJXcpfyRFA);
		}
	}

	private sealed class vkCqMlMsRxqeItPKVHivCwrRwwgN
	{
		public string PrfPiHGhKrtcXNOrwmUoliXSVmH;

		public bool MwcqIQNIvvFUfFmsJNamkwcCEFve(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
		{
			return P_0.QINdymBLIRcKJaTdWehjTiexQWpP == PrfPiHGhKrtcXNOrwmUoliXSVmH;
		}
	}

	private sealed class LKGvjNpKpRSeRckZSdQRpRbghmOG
	{
		public int HgIEIMWSDaFhIGVwBNVWCVPHunvR;

		public int[] efVXqTYAMCdbPktYyhvuKlMDhWlS;

		public bool cWwFmtIUJFzlwqQHYoxOyNLnjqY(nGuMwmGQLFierjbLPQhsmJwGfEIc P_0)
		{
			if (P_0.Attributes.VendorId == HgIEIMWSDaFhIGVwBNVWCVPHunvR)
			{
				return efVXqTYAMCdbPktYyhvuKlMDhWlS.Contains(P_0.Attributes.ProductId);
			}
			return false;
		}
	}

	private sealed class CmhEUMiXsNzegCGDHxvtdoRsJll
	{
		public int HgIEIMWSDaFhIGVwBNVWCVPHunvR;

		public bool vfKzgnsnIBGyYGGYmXroSlCHCct(nGuMwmGQLFierjbLPQhsmJwGfEIc P_0)
		{
			return P_0.Attributes.VendorId == HgIEIMWSDaFhIGVwBNVWCVPHunvR;
		}
	}

	private const string PeYMTyPCvMwiGdqqubQgqLAqHCR = "BTHENUM";

	private static Guid zMWeGIqjLpVVpoiDfsYVyxnoOKJ;

	private static List<nGuMwmGQLFierjbLPQhsmJwGfEIc> kuKoVxBGbFwgbKbTVERheqFTSumn;

	private static List<lCGlcTJRGlrITVtUFSeNVGNeYQF> yXJnXbQtoWohDJFEzONvWlsVlMh;

	private static List<ZmXFQUItFfCeopshMNfCzCYqGWRT> mbyHqpzwwopZHlEgKHbhCdcvAthe;

	private static List<GVmFwqSyMJtvWvIxvNsdgNTLALz> CrkJpldnXCblVgWIUMOabndUQkX;

	private static SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf tHSbzyftlNBVITHcFihgrGdFABFN;

	private static SmtbXLEQrGnIZlmUjbTNRZuCpJS.drSDytqeZpNRDgsxRnHgDVNKoGC lPxuRBZrUdllrKIonqlJLqUyRVv;

	private static NativeBuffer vOaDosbJgHzeFkCKsirvXGBzBoiR;

	[CompilerGenerated]
	private static Func<ZmXFQUItFfCeopshMNfCzCYqGWRT, nGuMwmGQLFierjbLPQhsmJwGfEIc> LupWRaaHBwNtBGVYkunNJGXKKyo;

	[CompilerGenerated]
	private static Func<ZmXFQUItFfCeopshMNfCzCYqGWRT, nGuMwmGQLFierjbLPQhsmJwGfEIc> wDpQQhYyETkYECbYbAyFiFhYIMf;

	[CompilerGenerated]
	private static Func<ZmXFQUItFfCeopshMNfCzCYqGWRT, nGuMwmGQLFierjbLPQhsmJwGfEIc> HpgJCQsXefKZFVeRRYeQsjTzhwz;

	[CompilerGenerated]
	private static Func<ZmXFQUItFfCeopshMNfCzCYqGWRT, nGuMwmGQLFierjbLPQhsmJwGfEIc> itsYZJqMpIGytVmNFxIquNTFXzN;

	private static Guid HidClassGuid
	{
		get
		{
			if (zMWeGIqjLpVVpoiDfsYVyxnoOKJ.Equals(Guid.Empty))
			{
				RGIgZGFrnmqngVujnbAVaLKYaInc.NQbfcXxktGOyrPmNHAzfbJqzmyu(ref zMWeGIqjLpVVpoiDfsYVyxnoOKJ);
			}
			return zMWeGIqjLpVVpoiDfsYVyxnoOKJ;
		}
	}

	static uNUGDLxbzFWxnCXPxXiZAvRTReD()
	{
		zMWeGIqjLpVVpoiDfsYVyxnoOKJ = Guid.Empty;
		kuKoVxBGbFwgbKbTVERheqFTSumn = new List<nGuMwmGQLFierjbLPQhsmJwGfEIc>();
		yXJnXbQtoWohDJFEzONvWlsVlMh = new List<lCGlcTJRGlrITVtUFSeNVGNeYQF>();
		mbyHqpzwwopZHlEgKHbhCdcvAthe = new List<ZmXFQUItFfCeopshMNfCzCYqGWRT>();
		CrkJpldnXCblVgWIUMOabndUQkX = new List<GVmFwqSyMJtvWvIxvNsdgNTLALz>();
		tHSbzyftlNBVITHcFihgrGdFABFN = new SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf
		{
			CyZqStgDIPaCFFuUFvMLYbSUmTA = (uint)Marshal.SizeOf(typeof(SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf)),
			ILBZqpUBdcwOCWrFqDMUfThBePpI = true,
			FwYcvZAFJCllLyaumofpiiVeOwR = true,
			dGSKygCEVJYNCGctpQYPlEDdwCh = false,
			YQQsOvGGdkTiyUZyJVlMfGBKJLv = true,
			ezyFEbZEpGjDhDxJvZhaDKYhntGf = IntPtr.Zero
		};
		lPxuRBZrUdllrKIonqlJLqUyRVv = SmtbXLEQrGnIZlmUjbTNRZuCpJS.drSDytqeZpNRDgsxRnHgDVNKoGC.KbsenlehkfKhrEUvGoQEltREagOX();
		vOaDosbJgHzeFkCKsirvXGBzBoiR = new NativeBuffer((int)lPxuRBZrUdllrKIonqlJLqUyRVv.CyZqStgDIPaCFFuUFvMLYbSUmTA);
		vOaDosbJgHzeFkCKsirvXGBzBoiR.Write(lPxuRBZrUdllrKIonqlJLqUyRVv.CyZqStgDIPaCFFuUFvMLYbSUmTA, 0);
	}

	public static bool pMGeVDkjCFSMYAWROAZNcnAMlkC(string P_0)
	{
		bool flag = false;
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = RGIgZGFrnmqngVujnbAVaLKYaInc.OvvYiDjcZnoJDbFoSBrUEpPUCUvo(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc ipZnMEIKtHtEQAVWLtBGUEevKdc = UolAnpQjddhVCziHRPnoVYpYBZS();
			int num = 0;
			while (RGIgZGFrnmqngVujnbAVaLKYaInc.CvbLTqIPVxYrFZZiwUvMoiDJdZw(intPtr, num, ref ipZnMEIKtHtEQAVWLtBGUEevKdc))
			{
				num++;
				RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd huzHBDdOIeZdvudQqgOXHuLJuByd = default(RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd);
				huzHBDdOIeZdvudQqgOXHuLJuByd.ICpvqdMkORrrrifEcpffDrWTtKc = Marshal.SizeOf((object)huzHBDdOIeZdvudQqgOXHuLJuByd);
				int num2 = 0;
				while (RGIgZGFrnmqngVujnbAVaLKYaInc.kVqMMwdlakEQDfEcGsXUaTCHulz(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc, ref hidClassGuid, num2, ref huzHBDdOIeZdvudQqgOXHuLJuByd))
				{
					num2++;
					if (P_0 == BwixhiWaRQPCUFBJxefmcsJRmyC(intPtr, huzHBDdOIeZdvudQqgOXHuLJuByd))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			RGIgZGFrnmqngVujnbAVaLKYaInc.RQeJmsjaQKQKtyjfxXBZNbMiDxVe(intPtr);
		}
		return flag;
	}

	public static IList<ZmXFQUItFfCeopshMNfCzCYqGWRT> OWKbVxrqgGFsIdUOFPIlbCgKOPX()
	{
		return uOaRmtsqJZFSXiSUmHIbmykvWhMV();
	}

	public static nGuMwmGQLFierjbLPQhsmJwGfEIc qunazVrBUyDwcuIHjOiYTeaFryQ(IList<ZmXFQUItFfCeopshMNfCzCYqGWRT> P_0, string P_1, StringComparison P_2)
	{
		sqSlyiZktoHIngYgsICmOrbuktL sqSlyiZktoHIngYgsICmOrbuktL2 = new sqSlyiZktoHIngYgsICmOrbuktL();
		sqSlyiZktoHIngYgsICmOrbuktL2.PrfPiHGhKrtcXNOrwmUoliXSVmH = P_1;
		sqSlyiZktoHIngYgsICmOrbuktL2.tpxPqZIqNWaqRZvgskJXcpfyRFA = P_2;
		if (P_0 == null)
		{
			return null;
		}
		return essAheQJZqwiPkHWQAaOqbmODgRi(P_0.FirstOrDefault(sqSlyiZktoHIngYgsICmOrbuktL2.hShGihnhRrJfGSgtgaclAfrxwUAA));
	}

	public static nGuMwmGQLFierjbLPQhsmJwGfEIc essAheQJZqwiPkHWQAaOqbmODgRi(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
	{
		try
		{
			if (string.IsNullOrEmpty(P_0.QINdymBLIRcKJaTdWehjTiexQWpP))
			{
				return null;
			}
			return new nGuMwmGQLFierjbLPQhsmJwGfEIc(P_0.dkOYsGfcBqjJtKGpPrHEqVMHAXL, P_0.BBLDCyrjhriCIMUSPatTjPFDaMJ, P_0.sZTVNBCuaLCpFWwakJLSKjdBaQtD, P_0.BWWfqOGHzimTPJyuKMWFOzoTDFTp, P_0.zJUFHCGUdbCIfzJDVQhVSCDpvze, P_0.HEDDgbanPWSjQqpPkVaMOuDlZNA, P_0.ujcVDandqSQmdWPvAsMWAutNffA, P_0.GzhOjAdMNgijAoffTkKrVXyBfEC);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static nGuMwmGQLFierjbLPQhsmJwGfEIc CbkPnOositGayySLpRdkqIQTIvL(string P_0)
	{
		return NJgRnafHbufsFBKJRzsIEfBsYFn(P_0).FirstOrDefault();
	}

	public static IEnumerable<nGuMwmGQLFierjbLPQhsmJwGfEIc> NJgRnafHbufsFBKJRzsIEfBsYFn()
	{
		return from P_0 in uOaRmtsqJZFSXiSUmHIbmykvWhMV()
			select new nGuMwmGQLFierjbLPQhsmJwGfEIc(P_0.dkOYsGfcBqjJtKGpPrHEqVMHAXL, P_0.BBLDCyrjhriCIMUSPatTjPFDaMJ, P_0.sZTVNBCuaLCpFWwakJLSKjdBaQtD, P_0.BWWfqOGHzimTPJyuKMWFOzoTDFTp, P_0.zJUFHCGUdbCIfzJDVQhVSCDpvze, P_0.HEDDgbanPWSjQqpPkVaMOuDlZNA, P_0.ujcVDandqSQmdWPvAsMWAutNffA, P_0.GzhOjAdMNgijAoffTkKrVXyBfEC);
	}

	public static IEnumerable<nGuMwmGQLFierjbLPQhsmJwGfEIc> NJgRnafHbufsFBKJRzsIEfBsYFn(string P_0)
	{
		vkCqMlMsRxqeItPKVHivCwrRwwgN vkCqMlMsRxqeItPKVHivCwrRwwgN2 = new vkCqMlMsRxqeItPKVHivCwrRwwgN();
		vkCqMlMsRxqeItPKVHivCwrRwwgN2.PrfPiHGhKrtcXNOrwmUoliXSVmH = P_0;
		return from zmXFQUItFfCeopshMNfCzCYqGWRT in uOaRmtsqJZFSXiSUmHIbmykvWhMV().Where(vkCqMlMsRxqeItPKVHivCwrRwwgN2.MwcqIQNIvvFUfFmsJNamkwcCEFve)
			select new nGuMwmGQLFierjbLPQhsmJwGfEIc(zmXFQUItFfCeopshMNfCzCYqGWRT.dkOYsGfcBqjJtKGpPrHEqVMHAXL, zmXFQUItFfCeopshMNfCzCYqGWRT.BBLDCyrjhriCIMUSPatTjPFDaMJ, zmXFQUItFfCeopshMNfCzCYqGWRT.sZTVNBCuaLCpFWwakJLSKjdBaQtD, zmXFQUItFfCeopshMNfCzCYqGWRT.BWWfqOGHzimTPJyuKMWFOzoTDFTp, zmXFQUItFfCeopshMNfCzCYqGWRT.zJUFHCGUdbCIfzJDVQhVSCDpvze, zmXFQUItFfCeopshMNfCzCYqGWRT.HEDDgbanPWSjQqpPkVaMOuDlZNA, zmXFQUItFfCeopshMNfCzCYqGWRT.ujcVDandqSQmdWPvAsMWAutNffA, zmXFQUItFfCeopshMNfCzCYqGWRT.GzhOjAdMNgijAoffTkKrVXyBfEC);
	}

	public static IEnumerable<nGuMwmGQLFierjbLPQhsmJwGfEIc> NJgRnafHbufsFBKJRzsIEfBsYFn(int P_0, params int[] P_1)
	{
		LKGvjNpKpRSeRckZSdQRpRbghmOG lKGvjNpKpRSeRckZSdQRpRbghmOG = new LKGvjNpKpRSeRckZSdQRpRbghmOG();
		lKGvjNpKpRSeRckZSdQRpRbghmOG.HgIEIMWSDaFhIGVwBNVWCVPHunvR = P_0;
		lKGvjNpKpRSeRckZSdQRpRbghmOG.efVXqTYAMCdbPktYyhvuKlMDhWlS = P_1;
		return (from zmXFQUItFfCeopshMNfCzCYqGWRT in uOaRmtsqJZFSXiSUmHIbmykvWhMV()
			select new nGuMwmGQLFierjbLPQhsmJwGfEIc(zmXFQUItFfCeopshMNfCzCYqGWRT.dkOYsGfcBqjJtKGpPrHEqVMHAXL, zmXFQUItFfCeopshMNfCzCYqGWRT.BBLDCyrjhriCIMUSPatTjPFDaMJ, zmXFQUItFfCeopshMNfCzCYqGWRT.sZTVNBCuaLCpFWwakJLSKjdBaQtD, zmXFQUItFfCeopshMNfCzCYqGWRT.BWWfqOGHzimTPJyuKMWFOzoTDFTp, zmXFQUItFfCeopshMNfCzCYqGWRT.zJUFHCGUdbCIfzJDVQhVSCDpvze, zmXFQUItFfCeopshMNfCzCYqGWRT.HEDDgbanPWSjQqpPkVaMOuDlZNA, zmXFQUItFfCeopshMNfCzCYqGWRT.ujcVDandqSQmdWPvAsMWAutNffA, zmXFQUItFfCeopshMNfCzCYqGWRT.GzhOjAdMNgijAoffTkKrVXyBfEC)).Where(lKGvjNpKpRSeRckZSdQRpRbghmOG.cWwFmtIUJFzlwqQHYoxOyNLnjqY);
	}

	public static IEnumerable<nGuMwmGQLFierjbLPQhsmJwGfEIc> NJgRnafHbufsFBKJRzsIEfBsYFn(int P_0)
	{
		CmhEUMiXsNzegCGDHxvtdoRsJll cmhEUMiXsNzegCGDHxvtdoRsJll = new CmhEUMiXsNzegCGDHxvtdoRsJll();
		cmhEUMiXsNzegCGDHxvtdoRsJll.HgIEIMWSDaFhIGVwBNVWCVPHunvR = P_0;
		return (from zmXFQUItFfCeopshMNfCzCYqGWRT in uOaRmtsqJZFSXiSUmHIbmykvWhMV()
			select new nGuMwmGQLFierjbLPQhsmJwGfEIc(zmXFQUItFfCeopshMNfCzCYqGWRT.dkOYsGfcBqjJtKGpPrHEqVMHAXL, zmXFQUItFfCeopshMNfCzCYqGWRT.BBLDCyrjhriCIMUSPatTjPFDaMJ, zmXFQUItFfCeopshMNfCzCYqGWRT.sZTVNBCuaLCpFWwakJLSKjdBaQtD, zmXFQUItFfCeopshMNfCzCYqGWRT.BWWfqOGHzimTPJyuKMWFOzoTDFTp, zmXFQUItFfCeopshMNfCzCYqGWRT.zJUFHCGUdbCIfzJDVQhVSCDpvze, zmXFQUItFfCeopshMNfCzCYqGWRT.HEDDgbanPWSjQqpPkVaMOuDlZNA, zmXFQUItFfCeopshMNfCzCYqGWRT.ujcVDandqSQmdWPvAsMWAutNffA, zmXFQUItFfCeopshMNfCzCYqGWRT.GzhOjAdMNgijAoffTkKrVXyBfEC)).Where(cmhEUMiXsNzegCGDHxvtdoRsJll.vfKzgnsnIBGyYGGYmXroSlCHCct);
	}

	public static bool SdkntCjhcZWIdBruWIkCZfJRJVT()
	{
		foreach (nGuMwmGQLFierjbLPQhsmJwGfEIc item in NJgRnafHbufsFBKJRzsIEfBsYFn())
		{
			if (item.IsBluetoothDevice)
			{
				return true;
			}
		}
		return false;
	}

	public static int FyyHFsnMdNTwjVEDmbXDLritDjL()
	{
		return FyyHFsnMdNTwjVEDmbXDLritDjL(ref tHSbzyftlNBVITHcFihgrGdFABFN, vOaDosbJgHzeFkCKsirvXGBzBoiR);
	}

	public static int FyyHFsnMdNTwjVEDmbXDLritDjL(ref SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf P_0, NativeBuffer P_1)
	{
		int num = 0;
		try
		{
			IntPtr intPtr = SmtbXLEQrGnIZlmUjbTNRZuCpJS.PmmKnnACgqmLJcxdoSspSMfzSZl(ref P_0, P_1);
			while (intPtr != IntPtr.Zero)
			{
				if (P_1.ReadInt(20) > 0)
				{
					num++;
				}
				if (!SmtbXLEQrGnIZlmUjbTNRZuCpJS.ponlJDpcnntiEIikZNHnyAsdEVQ(intPtr, P_1))
				{
					SmtbXLEQrGnIZlmUjbTNRZuCpJS.yCJQIbWacrILmfFULjBywDGsAJxC(intPtr);
					break;
				}
			}
		}
		catch (Exception)
		{
		}
		return num;
	}

	private static IList<ZmXFQUItFfCeopshMNfCzCYqGWRT> uOaRmtsqJZFSXiSUmHIbmykvWhMV()
	{
		kuKoVxBGbFwgbKbTVERheqFTSumn.Clear();
		mbyHqpzwwopZHlEgKHbhCdcvAthe.Clear();
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = RGIgZGFrnmqngVujnbAVaLKYaInc.OvvYiDjcZnoJDbFoSBrUEpPUCUvo(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc ipZnMEIKtHtEQAVWLtBGUEevKdc = UolAnpQjddhVCziHRPnoVYpYBZS();
			int num = 0;
			yXJnXbQtoWohDJFEzONvWlsVlMh.Clear();
			UCuUcvcsrMXYLOlRltkNPcesoVN(yXJnXbQtoWohDJFEzONvWlsVlMh);
			List<lCGlcTJRGlrITVtUFSeNVGNeYQF> list = yXJnXbQtoWohDJFEzONvWlsVlMh;
			CrkJpldnXCblVgWIUMOabndUQkX.Clear();
			List<GVmFwqSyMJtvWvIxvNsdgNTLALz> crkJpldnXCblVgWIUMOabndUQkX = CrkJpldnXCblVgWIUMOabndUQkX;
			while (RGIgZGFrnmqngVujnbAVaLKYaInc.CvbLTqIPVxYrFZZiwUvMoiDJdZw(intPtr, num, ref ipZnMEIKtHtEQAVWLtBGUEevKdc))
			{
				num++;
				RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd huzHBDdOIeZdvudQqgOXHuLJuByd = default(RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd);
				huzHBDdOIeZdvudQqgOXHuLJuByd.ICpvqdMkORrrrifEcpffDrWTtKc = huzHBDdOIeZdvudQqgOXHuLJuByd.NativeSize;
				int num2 = 0;
				while (RGIgZGFrnmqngVujnbAVaLKYaInc.kVqMMwdlakEQDfEcGsXUaTCHulz(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc, ref hidClassGuid, num2, ref huzHBDdOIeZdvudQqgOXHuLJuByd))
				{
					num2++;
					string text = BwixhiWaRQPCUFBJxefmcsJRmyC(intPtr, huzHBDdOIeZdvudQqgOXHuLJuByd);
					string instanceId = utTgCeDpVGZPmBRSwCrqNcdhaldF(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc);
					string description = sHbxycwlVsKXKGGeuuhXFPCLOaI(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc) ?? ThtbjBOMRRFsUTFbtGEkCRcldPur(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc);
					string manufacturer = UhBHQzFNpefqhlHwvvxtyVwsuwv(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc);
					string locationInfo = string.Empty;
					uint ceWCXHhWbEANPmWwGswbaPWXWMW = (uint)ipZnMEIKtHtEQAVWLtBGUEevKdc.CeWCXHhWbEANPmWwGswbaPWXWMW;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						if (list[i].GnnQhACXOlBukhSoigbzYAqXksB == ceWCXHhWbEANPmWwGswbaPWXWMW)
						{
							int nGwwgCeMsknzPYfQRtXjIWZKKfc = list[i].NGwwgCeMsknzPYfQRtXjIWZKKfc;
							if (nGwwgCeMsknzPYfQRtXjIWZKKfc >= 0 && nGwwgCeMsknzPYfQRtXjIWZKKfc < count)
							{
								locationInfo = list[nGwwgCeMsknzPYfQRtXjIWZKKfc].whfLWjRAQlOxPrMOCusTYqWUczKe;
								break;
							}
							Logger.LogError("USB device index out of range.");
						}
					}
					NYpjCbVxLClgAbbUIRuSwIgNMJC(ceWCXHhWbEANPmWwGswbaPWXWMW, ref crkJpldnXCblVgWIUMOabndUQkX, out var flag, out var bluetoothDeviceName);
					bool flag2 = false;
					if (flag)
					{
						flag2 = !KZbcYmBgBBRybcJFgNIrSOrvplUI(text);
					}
					if (!flag2)
					{
						mbyHqpzwwopZHlEgKHbhCdcvAthe.Add(new ZmXFQUItFfCeopshMNfCzCYqGWRT(text, instanceId, description, manufacturer, locationInfo, flag, bluetoothDeviceName));
					}
				}
			}
			RGIgZGFrnmqngVujnbAVaLKYaInc.RQeJmsjaQKQKtyjfxXBZNbMiDxVe(intPtr);
		}
		return mbyHqpzwwopZHlEgKHbhCdcvAthe;
	}

	private static void UCuUcvcsrMXYLOlRltkNPcesoVN(List<lCGlcTJRGlrITVtUFSeNVGNeYQF> P_0)
	{
		Guid gUID_DEVINTERFACE_USB_DEVICE = RGIgZGFrnmqngVujnbAVaLKYaInc.GUID_DEVINTERFACE_USB_DEVICE;
		IntPtr intPtr = RGIgZGFrnmqngVujnbAVaLKYaInc.OvvYiDjcZnoJDbFoSBrUEpPUCUvo(ref gUID_DEVINTERFACE_USB_DEVICE, null, 0, 18);
		if (intPtr.ToInt64() == -1)
		{
			return;
		}
		RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc ipZnMEIKtHtEQAVWLtBGUEevKdc = UolAnpQjddhVCziHRPnoVYpYBZS();
		int num = 0;
		while (RGIgZGFrnmqngVujnbAVaLKYaInc.CvbLTqIPVxYrFZZiwUvMoiDJdZw(intPtr, num, ref ipZnMEIKtHtEQAVWLtBGUEevKdc))
		{
			num++;
			RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd huzHBDdOIeZdvudQqgOXHuLJuByd = default(RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd);
			huzHBDdOIeZdvudQqgOXHuLJuByd.ICpvqdMkORrrrifEcpffDrWTtKc = huzHBDdOIeZdvudQqgOXHuLJuByd.NativeSize;
			int num2 = 0;
			while (RGIgZGFrnmqngVujnbAVaLKYaInc.kVqMMwdlakEQDfEcGsXUaTCHulz(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc, ref gUID_DEVINTERFACE_USB_DEVICE, num2, ref huzHBDdOIeZdvudQqgOXHuLJuByd))
			{
				num2++;
				string locationInfo = RQpCCiyJzAtHBDLmhIPZsNDylFJ(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc);
				P_0.Add(new lCGlcTJRGlrITVtUFSeNVGNeYQF(-1, (uint)ipZnMEIKtHtEQAVWLtBGUEevKdc.CeWCXHhWbEANPmWwGswbaPWXWMW, locationInfo));
				int parentIndex = P_0.Count - 1;
				List<uint> list = UxVXLWYgoTxrROYoOossOwFXORK((uint)ipZnMEIKtHtEQAVWLtBGUEevKdc.CeWCXHhWbEANPmWwGswbaPWXWMW);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						P_0.Add(new lCGlcTJRGlrITVtUFSeNVGNeYQF(parentIndex, list[i], null));
					}
				}
			}
		}
		RGIgZGFrnmqngVujnbAVaLKYaInc.RQeJmsjaQKQKtyjfxXBZNbMiDxVe(intPtr);
	}

	private static List<GVmFwqSyMJtvWvIxvNsdgNTLALz> wWshACpooYSUVushyCNqBJIScOsa(List<GVmFwqSyMJtvWvIxvNsdgNTLALz> P_0)
	{
		Guid gUID_BluetoothClassGuid = RGIgZGFrnmqngVujnbAVaLKYaInc.GUID_BluetoothClassGuid;
		IntPtr intPtr = RGIgZGFrnmqngVujnbAVaLKYaInc.OvvYiDjcZnoJDbFoSBrUEpPUCUvo(ref gUID_BluetoothClassGuid, null, 0, 2);
		if (intPtr.ToInt64() != -1)
		{
			RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc ipZnMEIKtHtEQAVWLtBGUEevKdc = UolAnpQjddhVCziHRPnoVYpYBZS();
			int num = 0;
			while (RGIgZGFrnmqngVujnbAVaLKYaInc.CvbLTqIPVxYrFZZiwUvMoiDJdZw(intPtr, num, ref ipZnMEIKtHtEQAVWLtBGUEevKdc))
			{
				num++;
				P_0.Add(new GVmFwqSyMJtvWvIxvNsdgNTLALz((uint)ipZnMEIKtHtEQAVWLtBGUEevKdc.CeWCXHhWbEANPmWwGswbaPWXWMW, RKkxtFdBajCieHPqCIJolNkNDXn(intPtr, ref ipZnMEIKtHtEQAVWLtBGUEevKdc)));
			}
			RGIgZGFrnmqngVujnbAVaLKYaInc.RQeJmsjaQKQKtyjfxXBZNbMiDxVe(intPtr);
		}
		return P_0;
	}

	private static string mPuSJllUQpdTzZCSoXBlfhUUwvv(uint P_0)
	{
		string empty = string.Empty;
		mPuSJllUQpdTzZCSoXBlfhUUwvv(P_0, 0, ref empty);
		return empty;
	}

	private static bool mPuSJllUQpdTzZCSoXBlfhUUwvv(uint P_0, int P_1, ref string P_2)
	{
		List<uint> list = teyYLCVTAFlSZhuxCouXJEaIwjG(P_0);
		if (list == null)
		{
			return false;
		}
		string text = "";
		for (int i = 0; i < P_1; i++)
		{
			text += "_____";
		}
		for (int j = 0; j < list.Count; j++)
		{
			object obj = P_2;
			P_2 = string.Concat(obj, text, "(", list[j], ") ", bSNjefYcwriiEgUaXfpyIqTuXzH(list[j]), "\n");
			mPuSJllUQpdTzZCSoXBlfhUUwvv(list[j], P_1 + 1, ref P_2);
		}
		return true;
	}

	private static List<string> lUFOaHqCJUnyQWagxoAmkbmHwkL(uint P_0)
	{
		List<uint> list = UxVXLWYgoTxrROYoOossOwFXORK(P_0);
		if (list == null)
		{
			return null;
		}
		List<string> list2 = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(bSNjefYcwriiEgUaXfpyIqTuXzH(list[i]));
		}
		return list2;
	}

	private static List<uint> UxVXLWYgoTxrROYoOossOwFXORK(uint P_0)
	{
		List<uint> list = teyYLCVTAFlSZhuxCouXJEaIwjG(P_0);
		if (list == null)
		{
			return null;
		}
		Queue<uint> queue = new Queue<uint>(list);
		List<uint> list2 = new List<uint>();
		while (queue.Count > 0)
		{
			uint num = queue.Dequeue();
			list2.Add(num);
			List<uint> list3 = teyYLCVTAFlSZhuxCouXJEaIwjG(num);
			if (list3 != null)
			{
				for (int i = 0; i < list3.Count; i++)
				{
					queue.Enqueue(list3[i]);
				}
			}
		}
		return list2;
	}

	private static List<string> LzVdJLKzqzzpPqLkHpQCdpljwIA(uint P_0)
	{
		if (RGIgZGFrnmqngVujnbAVaLKYaInc.kWoyEdijzDbGgFheebKVkTtyTex(out var num, P_0, 0u) != 0)
		{
			return null;
		}
		List<string> list = new List<string>();
		list.Add(bSNjefYcwriiEgUaXfpyIqTuXzH(num));
		while (RGIgZGFrnmqngVujnbAVaLKYaInc.kcxGlqJtvdqeaGOhebVzLyZRvKy(out num, num, 0u) == 0)
		{
			list.Add(bSNjefYcwriiEgUaXfpyIqTuXzH(num));
		}
		return list;
	}

	private static List<uint> teyYLCVTAFlSZhuxCouXJEaIwjG(uint P_0)
	{
		if (RGIgZGFrnmqngVujnbAVaLKYaInc.kWoyEdijzDbGgFheebKVkTtyTex(out var num, P_0, 0u) != 0)
		{
			return null;
		}
		List<uint> list = new List<uint>();
		list.Add(num);
		while (RGIgZGFrnmqngVujnbAVaLKYaInc.kcxGlqJtvdqeaGOhebVzLyZRvKy(out num, num, 0u) == 0)
		{
			list.Add(num);
		}
		return list;
	}

	private static string bSNjefYcwriiEgUaXfpyIqTuXzH(uint P_0)
	{
		if (RGIgZGFrnmqngVujnbAVaLKYaInc.ixwWSSjjydAeVjXNicNvCeUHYwPl(out var num, P_0, 0u) != 0)
		{
			return string.Empty;
		}
		if (num == 0)
		{
			return string.Empty;
		}
		num++;
		int cb = (int)num * Marshal.SystemDefaultCharSize;
		IntPtr intPtr = Marshal.AllocHGlobal(cb);
		if (RGIgZGFrnmqngVujnbAVaLKYaInc.JwTfKuCDIUsBKajcZenucFYBmPDM(P_0, intPtr, (int)num, 0u) != 0)
		{
			return string.Empty;
		}
		try
		{
			return Marshal.PtrToStringUni(intPtr, (int)num);
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	private static bool YqskdJzQnxACHpeWBbIBREJltfr(uint P_0, uint P_1)
	{
		List<uint> list = UxVXLWYgoTxrROYoOossOwFXORK(P_0);
		if (list == null)
		{
			return false;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i] == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private static void NYpjCbVxLClgAbbUIRuSwIgNMJC(uint P_0, ref List<GVmFwqSyMJtvWvIxvNsdgNTLALz> P_1, out bool P_2, out string P_3)
	{
		P_3 = string.Empty;
		try
		{
			if (!mSOiKOfqzPhQpEkDYlPLOfgGHYT(P_0, ref P_1, out P_2, out var num) || P_1 == null)
			{
				return;
			}
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_1[i].GnnQhACXOlBukhSoigbzYAqXksB == num)
				{
					P_3 = P_1[i].LxfKiQYCsfycMVLnXczxhQDSoEBL;
					break;
				}
			}
		}
		catch
		{
			P_2 = false;
		}
	}

	private static bool mSOiKOfqzPhQpEkDYlPLOfgGHYT(uint P_0, ref List<GVmFwqSyMJtvWvIxvNsdgNTLALz> P_1, out bool P_2, out uint P_3)
	{
		P_2 = false;
		P_3 = 0u;
		if (AvzHlKpeQxpDqgkBXdIFJBeClcS(P_0, "BTHENUM", out var text, out var num))
		{
			P_2 = true;
			if (P_1.Count == 0)
			{
				wWshACpooYSUVushyCNqBJIScOsa(P_1);
			}
			if (pvTesBFZVIzyOtNVsQKgbJlAtSyE(text, out var text2) && rAlcCkqFDAJRfHvuZZonHbWDZwbK(num, text2, out var num2))
			{
				P_3 = num2;
				return true;
			}
		}
		return false;
	}

	private static bool AvzHlKpeQxpDqgkBXdIFJBeClcS(uint P_0, string P_1, out string P_2, out uint P_3)
	{
		P_2 = string.Empty;
		P_3 = 0u;
		uint num = P_0;
		uint num2;
		while (RGIgZGFrnmqngVujnbAVaLKYaInc.qxKOkSQasPdSAGrIxBnCddWAuHBB(out num2, num, 0u) == 0)
		{
			string text = bSNjefYcwriiEgUaXfpyIqTuXzH(num2);
			if (text == string.Empty)
			{
				break;
			}
			if (text.StartsWith(P_1, StringComparison.OrdinalIgnoreCase))
			{
				P_2 = text;
				P_3 = num2;
				return true;
			}
			num = num2;
		}
		return false;
	}

	private static bool pvTesBFZVIzyOtNVsQKgbJlAtSyE(string P_0, out string P_1)
	{
		P_1 = null;
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		int num = P_0.LastIndexOf('\\');
		if (num <= 0 || num >= P_0.Length - 1)
		{
			return false;
		}
		string text = P_0.Substring(num + 1);
		num = text.LastIndexOf('_');
		if (num <= 0 || num >= text.Length - 1)
		{
			return false;
		}
		text = text.Substring(0, num);
		num = text.LastIndexOf('&');
		if (num <= 0 || num >= text.Length - 1)
		{
			return false;
		}
		text = text.Substring(num + 1);
		if (text.Length <= 1)
		{
			return false;
		}
		P_1 = text;
		return true;
	}

	private static bool rAlcCkqFDAJRfHvuZZonHbWDZwbK(uint P_0, string P_1, out uint P_2)
	{
		P_2 = 0u;
		if (string.IsNullOrEmpty(P_1))
		{
			return false;
		}
		if (RGIgZGFrnmqngVujnbAVaLKYaInc.qxKOkSQasPdSAGrIxBnCddWAuHBB(out var num, P_0, 0u) != 0)
		{
			return false;
		}
		if (RGIgZGFrnmqngVujnbAVaLKYaInc.kWoyEdijzDbGgFheebKVkTtyTex(out var num2, num, 0u) != 0)
		{
			return false;
		}
		uint num3 = num2;
		if (num3 == P_0 && RGIgZGFrnmqngVujnbAVaLKYaInc.kcxGlqJtvdqeaGOhebVzLyZRvKy(out num3, num3, 0u) != 0)
		{
			return false;
		}
		do
		{
			string text = bSNjefYcwriiEgUaXfpyIqTuXzH(num3);
			if (text == string.Empty)
			{
				return false;
			}
			if (text.EndsWith(P_1, StringComparison.OrdinalIgnoreCase))
			{
				P_2 = num3;
				return true;
			}
		}
		while (RGIgZGFrnmqngVujnbAVaLKYaInc.kcxGlqJtvdqeaGOhebVzLyZRvKy(out num3, num3, 0u) == 0);
		return false;
	}

	private static bool KZbcYmBgBBRybcJFgNIrSOrvplUI(string P_0, bool P_1 = true)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		string text = string.Empty;
		try
		{
			intPtr = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(P_0, vLFRVGoQdvLiGDEOuwvTRdjdROL.jnkRsbnZVdEnrWJTjbGGfLqWfFbT, 3221225472u, mmtXDuKsQlMiStwVPbFRUklSYaT.QEItTnuCeYaACEukHOCvGzKKmQem | mmtXDuKsQlMiStwVPbFRUklSYaT.yTIRHmzCmzyIeunckITFaREGrtXC);
			if (intPtr != IntPtr.Zero)
			{
				text = nGuMwmGQLFierjbLPQhsmJwGfEIc.OKJUZXbWmtKHCKBBILDyjkeFjvuc(intPtr);
				flag = true;
			}
		}
		catch
		{
			if (intPtr != IntPtr.Zero)
			{
				nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
			}
			return false;
		}
		if (!flag)
		{
			return false;
		}
		if (string.IsNullOrEmpty(text))
		{
			if (intPtr != IntPtr.Zero)
			{
				nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
			}
			return true;
		}
		SmtbXLEQrGnIZlmUjbTNRZuCpJS.KdNvaPLQRUVTxhSlJsfqHqGuVJf kdNvaPLQRUVTxhSlJsfqHqGuVJf = SmtbXLEQrGnIZlmUjbTNRZuCpJS.KdNvaPLQRUVTxhSlJsfqHqGuVJf.PDOXQTsQkUvVnBqCoBYjvtJhojh(text, out flag);
		if (!flag)
		{
			if (intPtr != IntPtr.Zero)
			{
				nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
			}
			return true;
		}
		bool flag2 = false;
		try
		{
			IntPtr intPtr2 = SmtbXLEQrGnIZlmUjbTNRZuCpJS.PmmKnnACgqmLJcxdoSspSMfzSZl(ref tHSbzyftlNBVITHcFihgrGdFABFN, ref lPxuRBZrUdllrKIonqlJLqUyRVv);
			if (intPtr2 == IntPtr.Zero)
			{
			}
			while (intPtr2 != IntPtr.Zero)
			{
				if (lPxuRBZrUdllrKIonqlJLqUyRVv.PtRoFkmSuMInhGFkpJEQwbFQBFUe.WGjCImbNbocZvlzChPbLUvUPPHt(ref kdNvaPLQRUVTxhSlJsfqHqGuVJf))
				{
					flag2 = lPxuRBZrUdllrKIonqlJLqUyRVv.YtBiJarvlNizGAAnfsrcgkYGhUq;
					SmtbXLEQrGnIZlmUjbTNRZuCpJS.yCJQIbWacrILmfFULjBywDGsAJxC(intPtr2);
					if (!P_1 || flag2)
					{
						break;
					}
					GOUqibZATrhkkfBhFGUPLtOGCtXc gOUqibZATrhkkfBhFGUPLtOGCtXc = nGuMwmGQLFierjbLPQhsmJwGfEIc.tdJfnKIwlmyKRFMqixSIaOrpcTnt(intPtr);
					if (gOUqibZATrhkkfBhFGUPLtOGCtXc.InputReportByteLength <= 0)
					{
						break;
					}
					int inputReportByteLength = gOUqibZATrhkkfBhFGUPLtOGCtXc.InputReportByteLength;
					IntPtr intPtr3 = Marshal.AllocHGlobal(inputReportByteLength);
					try
					{
						if (!RGIgZGFrnmqngVujnbAVaLKYaInc.OrfUnKLvTLCqDObryhKIplyhYJM(intPtr, intPtr3, inputReportByteLength))
						{
							Marshal.WriteByte(intPtr3, 1);
							RGIgZGFrnmqngVujnbAVaLKYaInc.OrfUnKLvTLCqDObryhKIplyhYJM(intPtr, intPtr3, inputReportByteLength);
						}
					}
					catch
					{
					}
					finally
					{
						Marshal.FreeHGlobal(intPtr3);
					}
					break;
				}
				if (!SmtbXLEQrGnIZlmUjbTNRZuCpJS.ponlJDpcnntiEIikZNHnyAsdEVQ(intPtr2, ref lPxuRBZrUdllrKIonqlJLqUyRVv))
				{
					SmtbXLEQrGnIZlmUjbTNRZuCpJS.yCJQIbWacrILmfFULjBywDGsAJxC(intPtr2);
					break;
				}
			}
		}
		catch
		{
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
			}
		}
		return flag2;
	}

	private static RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc UolAnpQjddhVCziHRPnoVYpYBZS()
	{
		RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc result = default(RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc);
		result.ICpvqdMkORrrrifEcpffDrWTtKc = result.NativeSize;
		result.CeWCXHhWbEANPmWwGswbaPWXWMW = 0;
		result.QiLCbYxoAzVtyvefbxqUNuKvKbc = Guid.Empty;
		result.vIJARJgljIoebHuPYkRuNPuGqJpx = IntPtr.Zero;
		return result;
	}

	private static string BwixhiWaRQPCUFBJxefmcsJRmyC(IntPtr P_0, RGIgZGFrnmqngVujnbAVaLKYaInc.huzHBDdOIeZdvudQqgOXHuLJuByd P_1)
	{
		int num = 0;
		RGIgZGFrnmqngVujnbAVaLKYaInc.hRHCpNTbNHbqkXrlVeKnLxdRpBv hRHCpNTbNHbqkXrlVeKnLxdRpBv = new RGIgZGFrnmqngVujnbAVaLKYaInc.hRHCpNTbNHbqkXrlVeKnLxdRpBv
		{
			MSHCgcyCMthFnRTIrchleRuEuVD = ((IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8)
		};
		RGIgZGFrnmqngVujnbAVaLKYaInc.YpprGpoKhJWyADwYOCdvUhmdNur(P_0, ref P_1, IntPtr.Zero, 0, ref num, IntPtr.Zero);
		if (!RGIgZGFrnmqngVujnbAVaLKYaInc.YpprGpoKhJWyADwYOCdvUhmdNur(P_0, ref P_1, ref hRHCpNTbNHbqkXrlVeKnLxdRpBv, num, ref num, IntPtr.Zero))
		{
			return null;
		}
		return hRHCpNTbNHbqkXrlVeKnLxdRpBv.LzTrZZOeXGUTMVkUYkqiuigjARLc;
	}

	private static string utTgCeDpVGZPmBRSwCrqNcdhaldF(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(RGIgZGFrnmqngVujnbAVaLKYaInc.MAX_DEVICE_ID_LEN_BufferSizeInBytes);
		uint len;
		string result = (RGIgZGFrnmqngVujnbAVaLKYaInc.qMnCUndiAJOKabepmSGtNKjwyCIe(P_0, ref P_1, intPtr, (uint)RGIgZGFrnmqngVujnbAVaLKYaInc.MAX_DEVICE_ID_LEN_BufferSizeInChars, out len) ? Marshal.PtrToStringUni(intPtr, (int)len) : "FAILED");
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string ThtbjBOMRRFsUTFbtGEkCRcldPur(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 0);
	}

	private static string RKkxtFdBajCieHPqCIJolNkNDXn(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 12);
	}

	private static string bkExDDMnDNvhtjMRVFCGPJZEQsm(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 14);
	}

	private static string EwdIvOOeNrXwguRxeDdvQiIcdPs(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 28);
	}

	private static string mPXdUpdgqEGrzoZvaBmyixJvOcwk(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 21);
	}

	private static string bcJJYBQcUxPYibgubFaLbSUzhfZ(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 1);
	}

	private static string RQpCCiyJzAtHBDLmhIPZsNDylFJ(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 13);
	}

	private static string UhBHQzFNpefqhlHwvvxtyVwsuwv(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		return kGFcHDepmlymHLfBhHUdggEJCpZ(P_0, ref P_1, 11);
	}

	private static string kGFcHDepmlymHLfBhHUdggEJCpZ(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1, int P_2)
	{
		int num = 0;
		int num2 = 0;
		RGIgZGFrnmqngVujnbAVaLKYaInc.AjaVaMurthtPZVcaiFFNXFkpbsy(P_0, ref P_1, P_2, ref num2, IntPtr.Zero, 0, ref num);
		if (num == 0)
		{
			return null;
		}
		int num3 = num;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (RGIgZGFrnmqngVujnbAVaLKYaInc.AjaVaMurthtPZVcaiFFNXFkpbsy(P_0, ref P_1, P_2, ref num2, intPtr, num3, ref num) ? ZKwGflbKMPJNuaHiguANvIMIHFg.bMOuCpvoIjCagBoKksDPWoCSpKKh(intPtr, num3) : string.Empty);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string sHbxycwlVsKXKGGeuuhXFPCLOaI(IntPtr P_0, ref RGIgZGFrnmqngVujnbAVaLKYaInc.ipZnMEIKtHtEQAVWLtBGUEevKdc P_1)
	{
		if (Environment.OSVersion.Version.Major <= 5)
		{
			return null;
		}
		ulong num = 0uL;
		int num2 = 0;
		RGIgZGFrnmqngVujnbAVaLKYaInc.nMZBnncbOUorqEsZzScXIsKhgQj(P_0, ref P_1, ref RGIgZGFrnmqngVujnbAVaLKYaInc.DrnhWQRTCoQDHmbRQmsRNZOhFDA, ref num, IntPtr.Zero, 0, ref num2, 0u);
		if (num2 == 0)
		{
			return string.Empty;
		}
		int num3 = num2;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (RGIgZGFrnmqngVujnbAVaLKYaInc.nMZBnncbOUorqEsZzScXIsKhgQj(P_0, ref P_1, ref RGIgZGFrnmqngVujnbAVaLKYaInc.DrnhWQRTCoQDHmbRQmsRNZOhFDA, ref num, intPtr, num3, ref num2, 0u) ? ZKwGflbKMPJNuaHiguANvIMIHFg.bMOuCpvoIjCagBoKksDPWoCSpKKh(intPtr, num3) : null);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	[CompilerGenerated]
	private static nGuMwmGQLFierjbLPQhsmJwGfEIc JecIeQgjcPUCPpKfwbOsCFAibMg(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
	{
		return new nGuMwmGQLFierjbLPQhsmJwGfEIc(P_0.dkOYsGfcBqjJtKGpPrHEqVMHAXL, P_0.BBLDCyrjhriCIMUSPatTjPFDaMJ, P_0.sZTVNBCuaLCpFWwakJLSKjdBaQtD, P_0.BWWfqOGHzimTPJyuKMWFOzoTDFTp, P_0.zJUFHCGUdbCIfzJDVQhVSCDpvze, P_0.HEDDgbanPWSjQqpPkVaMOuDlZNA, P_0.ujcVDandqSQmdWPvAsMWAutNffA, P_0.GzhOjAdMNgijAoffTkKrVXyBfEC);
	}

	[CompilerGenerated]
	private static nGuMwmGQLFierjbLPQhsmJwGfEIc hPnzpIHKeQeuFdHFlUbBtgHNmZRE(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
	{
		return new nGuMwmGQLFierjbLPQhsmJwGfEIc(P_0.dkOYsGfcBqjJtKGpPrHEqVMHAXL, P_0.BBLDCyrjhriCIMUSPatTjPFDaMJ, P_0.sZTVNBCuaLCpFWwakJLSKjdBaQtD, P_0.BWWfqOGHzimTPJyuKMWFOzoTDFTp, P_0.zJUFHCGUdbCIfzJDVQhVSCDpvze, P_0.HEDDgbanPWSjQqpPkVaMOuDlZNA, P_0.ujcVDandqSQmdWPvAsMWAutNffA, P_0.GzhOjAdMNgijAoffTkKrVXyBfEC);
	}

	[CompilerGenerated]
	private static nGuMwmGQLFierjbLPQhsmJwGfEIc pHueKmsssPVwkFUZsVwYHAVXQFS(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
	{
		return new nGuMwmGQLFierjbLPQhsmJwGfEIc(P_0.dkOYsGfcBqjJtKGpPrHEqVMHAXL, P_0.BBLDCyrjhriCIMUSPatTjPFDaMJ, P_0.sZTVNBCuaLCpFWwakJLSKjdBaQtD, P_0.BWWfqOGHzimTPJyuKMWFOzoTDFTp, P_0.zJUFHCGUdbCIfzJDVQhVSCDpvze, P_0.HEDDgbanPWSjQqpPkVaMOuDlZNA, P_0.ujcVDandqSQmdWPvAsMWAutNffA, P_0.GzhOjAdMNgijAoffTkKrVXyBfEC);
	}

	[CompilerGenerated]
	private static nGuMwmGQLFierjbLPQhsmJwGfEIc WHDiztIYCDdpovgKZTilLvgTbME(ZmXFQUItFfCeopshMNfCzCYqGWRT P_0)
	{
		return new nGuMwmGQLFierjbLPQhsmJwGfEIc(P_0.dkOYsGfcBqjJtKGpPrHEqVMHAXL, P_0.BBLDCyrjhriCIMUSPatTjPFDaMJ, P_0.sZTVNBCuaLCpFWwakJLSKjdBaQtD, P_0.BWWfqOGHzimTPJyuKMWFOzoTDFTp, P_0.zJUFHCGUdbCIfzJDVQhVSCDpvze, P_0.HEDDgbanPWSjQqpPkVaMOuDlZNA, P_0.ujcVDandqSQmdWPvAsMWAutNffA, P_0.GzhOjAdMNgijAoffTkKrVXyBfEC);
	}
}
