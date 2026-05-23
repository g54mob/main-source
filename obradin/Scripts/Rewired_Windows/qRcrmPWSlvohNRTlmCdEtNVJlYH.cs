using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class qRcrmPWSlvohNRTlmCdEtNVJlYH
{
	public struct RxfJJCYGwNNaCbrUpFZUeAqgADb
	{
		public string txubKOKkDYAiFBWTKezcTEiZEUga;

		public string GefOHkcRWvlvfGDHXVfHFyOtXRG;

		public string VFhYauUPnZBdwgDoKlHdHOvdZXgd;

		public string oNvdrZnsuduQdHREretkAdPJMPGe;

		public string ZFmEcYuCtIDsdnaKLMezECQPxKe;

		public string wcTyvakCbTEeluuAVKfdfFgIuZd;

		public int bSmdtMnTvJnnJApvGJifxgddcpD;

		public int RdxQvxOdJsEJeehpzcWklCzrCIla;

		public bool ipYFziCfquohTTpDXDYqlnMDTyb;

		public string SdLIcSiQJMELqAfVaCaBbiKHDHjz;

		public RxfJJCYGwNNaCbrUpFZUeAqgADb(string path, string instanceId, string description, string manufacturer, string locationInfo, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			txubKOKkDYAiFBWTKezcTEiZEUga = path;
			GefOHkcRWvlvfGDHXVfHFyOtXRG = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(path);
			VFhYauUPnZBdwgDoKlHdHOvdZXgd = instanceId;
			oNvdrZnsuduQdHREretkAdPJMPGe = description;
			ZFmEcYuCtIDsdnaKLMezECQPxKe = manufacturer;
			wcTyvakCbTEeluuAVKfdfFgIuZd = locationInfo;
			RdxQvxOdJsEJeehpzcWklCzrCIla = -1;
			bSmdtMnTvJnnJApvGJifxgddcpD = -1;
			ipYFziCfquohTTpDXDYqlnMDTyb = isBluetoothDevice;
			SdLIcSiQJMELqAfVaCaBbiKHDHjz = bluetoothDeviceName;
			KthgfCVyveqnkrvGTLarfqhZnRb();
		}

		private void KthgfCVyveqnkrvGTLarfqhZnRb()
		{
			if (!string.IsNullOrEmpty(wcTyvakCbTEeluuAVKfdfFgIuZd))
			{
				int num = wcTyvakCbTEeluuAVKfdfFgIuZd.IndexOf("port_#", StringComparison.OrdinalIgnoreCase);
				int num2 = wcTyvakCbTEeluuAVKfdfFgIuZd.IndexOf("hub_#", StringComparison.OrdinalIgnoreCase);
				if (num >= 0 && num2 >= 0)
				{
					int.TryParse(wcTyvakCbTEeluuAVKfdfFgIuZd.Substring(num + 6, 4), out RdxQvxOdJsEJeehpzcWklCzrCIla);
					int.TryParse(wcTyvakCbTEeluuAVKfdfFgIuZd.Substring(num2 + 5, 4), out bSmdtMnTvJnnJApvGJifxgddcpD);
				}
			}
		}
	}

	private struct JFPLZyKuGoOTrxCNBbkulqurpfP
	{
		public int FXGQOYTFAMaAxDDPIaHNefmeQRVZ;

		public uint EOFWiUtpGZZcKmLEjxCXfrQPtbg;

		public string wcTyvakCbTEeluuAVKfdfFgIuZd;

		public JFPLZyKuGoOTrxCNBbkulqurpfP(int parentIndex, uint deviceInstanceHandle, string locationInfo)
		{
			FXGQOYTFAMaAxDDPIaHNefmeQRVZ = parentIndex;
			EOFWiUtpGZZcKmLEjxCXfrQPtbg = deviceInstanceHandle;
			wcTyvakCbTEeluuAVKfdfFgIuZd = locationInfo;
		}
	}

	private struct eohaloxHIeyxTvAfWjneestVTmm
	{
		public readonly uint EOFWiUtpGZZcKmLEjxCXfrQPtbg;

		public readonly string HhLCnObivBTAgIeVUFxXfkzGVdu;

		public eohaloxHIeyxTvAfWjneestVTmm(uint deviceInstanceHandle, string friendlyName)
		{
			EOFWiUtpGZZcKmLEjxCXfrQPtbg = deviceInstanceHandle;
			HhLCnObivBTAgIeVUFxXfkzGVdu = ((friendlyName == null) ? string.Empty : friendlyName);
		}
	}

	private sealed class KKYioamLeGIAZIfafabhLlmrxhm
	{
		public string XoVACFnKRDDFzIRGrqvYUhBSzxw;

		public StringComparison pvPGRSjNWaFxgKYDbpHpDVUuGDd;

		public bool bjZwmzGuHBaCiPKVtAvDIABhJZl(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
		{
			return P_0.GefOHkcRWvlvfGDHXVfHFyOtXRG.Equals(XoVACFnKRDDFzIRGrqvYUhBSzxw, pvPGRSjNWaFxgKYDbpHpDVUuGDd);
		}
	}

	private sealed class RldDpmyfEREMUcjAIpBeEkGeZAhd
	{
		public string XoVACFnKRDDFzIRGrqvYUhBSzxw;

		public bool EdSeeOexZTvqFbAMUOgSDETQScA(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
		{
			return P_0.GefOHkcRWvlvfGDHXVfHFyOtXRG == XoVACFnKRDDFzIRGrqvYUhBSzxw;
		}
	}

	private sealed class ONPGXebdlDVkmvAkNOsMjyeBveQ
	{
		public int PbwglKnIRKBGqGPSCbbymWhNwoO;

		public int[] mcxfMHvoGieGlaMazpTMAYcLWZE;

		public bool sFOWsvnTPjUsETVzHRYwTMjvvOt(hdKCmGlHttTBdcjeWBCjBOXCTjJ P_0)
		{
			if (P_0.Attributes.VendorId == PbwglKnIRKBGqGPSCbbymWhNwoO)
			{
				return mcxfMHvoGieGlaMazpTMAYcLWZE.Contains(P_0.Attributes.ProductId);
			}
			return false;
		}
	}

	private sealed class XvdIfUwebSQiKlewKMRaPiMswDO
	{
		public int PbwglKnIRKBGqGPSCbbymWhNwoO;

		public bool zhsdPjFBOxzhaNJkhSxWpLyDGJSD(hdKCmGlHttTBdcjeWBCjBOXCTjJ P_0)
		{
			return P_0.Attributes.VendorId == PbwglKnIRKBGqGPSCbbymWhNwoO;
		}
	}

	private const string JAobcwardmZsNkQUfwWERySsLim = "BTHENUM";

	private static Guid jLykgYTgNXaMFrjpgsqdFGVoBKu;

	private static List<hdKCmGlHttTBdcjeWBCjBOXCTjJ> wqylGnmpEpPcLRdpWxlDXTjFbkL;

	private static List<JFPLZyKuGoOTrxCNBbkulqurpfP> aErGNrezoerJjHOikkmXrhMXriYc;

	private static List<RxfJJCYGwNNaCbrUpFZUeAqgADb> cIGINtCgAWigtyBKJHpLdACdGsM;

	private static List<eohaloxHIeyxTvAfWjneestVTmm> ETSQlhIvzaSGJzwcBAwuANXzRZX;

	private static SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP bfiTjsWKhvkLkCNKIDaCjyJRCam;

	private static SbNYhPrwpuilnaawmyzrqxOYOrb.xPIZmsiJWcOKbvMDvhnNNsuhCYqg xLBrwZiYCRGEDHiSkGFxkFscGISA;

	private static NativeBuffer rMUIUgiIkvFvzNOujFFXntvrpxL;

	[CompilerGenerated]
	private static Func<RxfJJCYGwNNaCbrUpFZUeAqgADb, hdKCmGlHttTBdcjeWBCjBOXCTjJ> FOTBnuTHDISWjHggxrFjubfWwxH;

	[CompilerGenerated]
	private static Func<RxfJJCYGwNNaCbrUpFZUeAqgADb, hdKCmGlHttTBdcjeWBCjBOXCTjJ> wILTuvzDAjFNyfFigVmjnTHENTAh;

	[CompilerGenerated]
	private static Func<RxfJJCYGwNNaCbrUpFZUeAqgADb, hdKCmGlHttTBdcjeWBCjBOXCTjJ> JTSCnYfNyJpvdAISMywuaZVxDkWQ;

	[CompilerGenerated]
	private static Func<RxfJJCYGwNNaCbrUpFZUeAqgADb, hdKCmGlHttTBdcjeWBCjBOXCTjJ> mjCfeJKXboLbBxWrACPYeFxaHUyN;

	private static Guid HidClassGuid
	{
		get
		{
			if (jLykgYTgNXaMFrjpgsqdFGVoBKu.Equals(Guid.Empty))
			{
				FAybFIUyhQQoIUWFiuSraaiMBJE.VTJqLaSQeotfUOFEKqcVUlnvttJ(ref jLykgYTgNXaMFrjpgsqdFGVoBKu);
			}
			return jLykgYTgNXaMFrjpgsqdFGVoBKu;
		}
	}

	static qRcrmPWSlvohNRTlmCdEtNVJlYH()
	{
		jLykgYTgNXaMFrjpgsqdFGVoBKu = Guid.Empty;
		wqylGnmpEpPcLRdpWxlDXTjFbkL = new List<hdKCmGlHttTBdcjeWBCjBOXCTjJ>();
		aErGNrezoerJjHOikkmXrhMXriYc = new List<JFPLZyKuGoOTrxCNBbkulqurpfP>();
		cIGINtCgAWigtyBKJHpLdACdGsM = new List<RxfJJCYGwNNaCbrUpFZUeAqgADb>();
		ETSQlhIvzaSGJzwcBAwuANXzRZX = new List<eohaloxHIeyxTvAfWjneestVTmm>();
		bfiTjsWKhvkLkCNKIDaCjyJRCam = new SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP
		{
			SbvjKtRMAnhJrOoaSiNhtdqQEdlB = (uint)Marshal.SizeOf(typeof(SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP)),
			MVhcMlblbUmneTVbxkiaQoRZAMWk = true,
			ZoqJQJdXDyPOhbaEzzCXFpAmLJP = true,
			pSyGmyrRIjyeqJdRkiTbKpzlJgE = false,
			ITogQjdhtEXaYFpYMBbmOJpSDYS = true,
			oFEyQdclJsciZibUoJTArgJtqmj = IntPtr.Zero
		};
		xLBrwZiYCRGEDHiSkGFxkFscGISA = SbNYhPrwpuilnaawmyzrqxOYOrb.xPIZmsiJWcOKbvMDvhnNNsuhCYqg.QGMHznQHkHQnTPTBloqkWdrurHv();
		rMUIUgiIkvFvzNOujFFXntvrpxL = new NativeBuffer((int)xLBrwZiYCRGEDHiSkGFxkFscGISA.SbvjKtRMAnhJrOoaSiNhtdqQEdlB);
		rMUIUgiIkvFvzNOujFFXntvrpxL.Write(xLBrwZiYCRGEDHiSkGFxkFscGISA.SbvjKtRMAnhJrOoaSiNhtdqQEdlB, 0);
	}

	public static bool bxkbtDHUhtfxsVpGHlQtNwqQzBh(string P_0)
	{
		bool flag = false;
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = FAybFIUyhQQoIUWFiuSraaiMBJE.WsDAUDGeXLegnwJYTTwgQyjKHoI(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo pSTAPHZotthAnMKYnqXsEnXfjZo = MnFvorhvfJcykaUhGaVGmsJCSWt();
			int num = 0;
			while (FAybFIUyhQQoIUWFiuSraaiMBJE.EDPdkUnTuHEjFMKHxgeuLnbXEEV(intPtr, num, ref pSTAPHZotthAnMKYnqXsEnXfjZo))
			{
				num++;
				FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw qbNYVpkEAPCodaPjUxAeaxqXBRw = default(FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw);
				qbNYVpkEAPCodaPjUxAeaxqXBRw.OkVYmxvFGrESPrFalzVFsUcRvgP = Marshal.SizeOf(qbNYVpkEAPCodaPjUxAeaxqXBRw);
				int num2 = 0;
				while (FAybFIUyhQQoIUWFiuSraaiMBJE.oHGgafMqTWjhGyGSRryGJctTsIH(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo, ref hidClassGuid, num2, ref qbNYVpkEAPCodaPjUxAeaxqXBRw))
				{
					num2++;
					if (P_0 == DOCJTqrqPezqwOAxkfZACPnXvvj(intPtr, qbNYVpkEAPCodaPjUxAeaxqXBRw))
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
			FAybFIUyhQQoIUWFiuSraaiMBJE.VOKWimCfGutIZfQFirWrqAcqarg(intPtr);
		}
		return flag;
	}

	public static IList<RxfJJCYGwNNaCbrUpFZUeAqgADb> CKeYpxOimceVqdsqIUoFDSUCpMms()
	{
		return mVUOrJLPGtnzKPatloBeLGjloip();
	}

	public static hdKCmGlHttTBdcjeWBCjBOXCTjJ mmTeSZfIZImoGtQuiwmicVAHNuf(IList<RxfJJCYGwNNaCbrUpFZUeAqgADb> P_0, string P_1, StringComparison P_2)
	{
		KKYioamLeGIAZIfafabhLlmrxhm kKYioamLeGIAZIfafabhLlmrxhm = new KKYioamLeGIAZIfafabhLlmrxhm();
		kKYioamLeGIAZIfafabhLlmrxhm.XoVACFnKRDDFzIRGrqvYUhBSzxw = P_1;
		kKYioamLeGIAZIfafabhLlmrxhm.pvPGRSjNWaFxgKYDbpHpDVUuGDd = P_2;
		if (P_0 == null)
		{
			return null;
		}
		return gQMyXuzcFWHDzrQuZAUeBNMALfuE(P_0.FirstOrDefault(kKYioamLeGIAZIfafabhLlmrxhm.bjZwmzGuHBaCiPKVtAvDIABhJZl));
	}

	public static hdKCmGlHttTBdcjeWBCjBOXCTjJ gQMyXuzcFWHDzrQuZAUeBNMALfuE(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
	{
		try
		{
			if (string.IsNullOrEmpty(P_0.GefOHkcRWvlvfGDHXVfHFyOtXRG))
			{
				return null;
			}
			return new hdKCmGlHttTBdcjeWBCjBOXCTjJ(P_0.txubKOKkDYAiFBWTKezcTEiZEUga, P_0.VFhYauUPnZBdwgDoKlHdHOvdZXgd, P_0.oNvdrZnsuduQdHREretkAdPJMPGe, P_0.ZFmEcYuCtIDsdnaKLMezECQPxKe, P_0.bSmdtMnTvJnnJApvGJifxgddcpD, P_0.RdxQvxOdJsEJeehpzcWklCzrCIla, P_0.ipYFziCfquohTTpDXDYqlnMDTyb, P_0.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static hdKCmGlHttTBdcjeWBCjBOXCTjJ YGWZvKZyyVQnQnhlmktMLZiJaXg(string P_0)
	{
		return FUYFkvWvvKHbFHzKCEkoUnCiWIh(P_0).FirstOrDefault();
	}

	public static IEnumerable<hdKCmGlHttTBdcjeWBCjBOXCTjJ> FUYFkvWvvKHbFHzKCEkoUnCiWIh()
	{
		return from P_0 in mVUOrJLPGtnzKPatloBeLGjloip()
			select new hdKCmGlHttTBdcjeWBCjBOXCTjJ(P_0.txubKOKkDYAiFBWTKezcTEiZEUga, P_0.VFhYauUPnZBdwgDoKlHdHOvdZXgd, P_0.oNvdrZnsuduQdHREretkAdPJMPGe, P_0.ZFmEcYuCtIDsdnaKLMezECQPxKe, P_0.bSmdtMnTvJnnJApvGJifxgddcpD, P_0.RdxQvxOdJsEJeehpzcWklCzrCIla, P_0.ipYFziCfquohTTpDXDYqlnMDTyb, P_0.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
	}

	public static IEnumerable<hdKCmGlHttTBdcjeWBCjBOXCTjJ> FUYFkvWvvKHbFHzKCEkoUnCiWIh(string P_0)
	{
		RldDpmyfEREMUcjAIpBeEkGeZAhd rldDpmyfEREMUcjAIpBeEkGeZAhd = new RldDpmyfEREMUcjAIpBeEkGeZAhd();
		rldDpmyfEREMUcjAIpBeEkGeZAhd.XoVACFnKRDDFzIRGrqvYUhBSzxw = P_0;
		return from rxfJJCYGwNNaCbrUpFZUeAqgADb in mVUOrJLPGtnzKPatloBeLGjloip().Where(rldDpmyfEREMUcjAIpBeEkGeZAhd.EdSeeOexZTvqFbAMUOgSDETQScA)
			select new hdKCmGlHttTBdcjeWBCjBOXCTjJ(rxfJJCYGwNNaCbrUpFZUeAqgADb.txubKOKkDYAiFBWTKezcTEiZEUga, rxfJJCYGwNNaCbrUpFZUeAqgADb.VFhYauUPnZBdwgDoKlHdHOvdZXgd, rxfJJCYGwNNaCbrUpFZUeAqgADb.oNvdrZnsuduQdHREretkAdPJMPGe, rxfJJCYGwNNaCbrUpFZUeAqgADb.ZFmEcYuCtIDsdnaKLMezECQPxKe, rxfJJCYGwNNaCbrUpFZUeAqgADb.bSmdtMnTvJnnJApvGJifxgddcpD, rxfJJCYGwNNaCbrUpFZUeAqgADb.RdxQvxOdJsEJeehpzcWklCzrCIla, rxfJJCYGwNNaCbrUpFZUeAqgADb.ipYFziCfquohTTpDXDYqlnMDTyb, rxfJJCYGwNNaCbrUpFZUeAqgADb.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
	}

	public static IEnumerable<hdKCmGlHttTBdcjeWBCjBOXCTjJ> FUYFkvWvvKHbFHzKCEkoUnCiWIh(int P_0, params int[] P_1)
	{
		ONPGXebdlDVkmvAkNOsMjyeBveQ oNPGXebdlDVkmvAkNOsMjyeBveQ = new ONPGXebdlDVkmvAkNOsMjyeBveQ();
		oNPGXebdlDVkmvAkNOsMjyeBveQ.PbwglKnIRKBGqGPSCbbymWhNwoO = P_0;
		oNPGXebdlDVkmvAkNOsMjyeBveQ.mcxfMHvoGieGlaMazpTMAYcLWZE = P_1;
		return (from rxfJJCYGwNNaCbrUpFZUeAqgADb in mVUOrJLPGtnzKPatloBeLGjloip()
			select new hdKCmGlHttTBdcjeWBCjBOXCTjJ(rxfJJCYGwNNaCbrUpFZUeAqgADb.txubKOKkDYAiFBWTKezcTEiZEUga, rxfJJCYGwNNaCbrUpFZUeAqgADb.VFhYauUPnZBdwgDoKlHdHOvdZXgd, rxfJJCYGwNNaCbrUpFZUeAqgADb.oNvdrZnsuduQdHREretkAdPJMPGe, rxfJJCYGwNNaCbrUpFZUeAqgADb.ZFmEcYuCtIDsdnaKLMezECQPxKe, rxfJJCYGwNNaCbrUpFZUeAqgADb.bSmdtMnTvJnnJApvGJifxgddcpD, rxfJJCYGwNNaCbrUpFZUeAqgADb.RdxQvxOdJsEJeehpzcWklCzrCIla, rxfJJCYGwNNaCbrUpFZUeAqgADb.ipYFziCfquohTTpDXDYqlnMDTyb, rxfJJCYGwNNaCbrUpFZUeAqgADb.SdLIcSiQJMELqAfVaCaBbiKHDHjz)).Where(oNPGXebdlDVkmvAkNOsMjyeBveQ.sFOWsvnTPjUsETVzHRYwTMjvvOt);
	}

	public static IEnumerable<hdKCmGlHttTBdcjeWBCjBOXCTjJ> FUYFkvWvvKHbFHzKCEkoUnCiWIh(int P_0)
	{
		XvdIfUwebSQiKlewKMRaPiMswDO xvdIfUwebSQiKlewKMRaPiMswDO = new XvdIfUwebSQiKlewKMRaPiMswDO();
		xvdIfUwebSQiKlewKMRaPiMswDO.PbwglKnIRKBGqGPSCbbymWhNwoO = P_0;
		return (from rxfJJCYGwNNaCbrUpFZUeAqgADb in mVUOrJLPGtnzKPatloBeLGjloip()
			select new hdKCmGlHttTBdcjeWBCjBOXCTjJ(rxfJJCYGwNNaCbrUpFZUeAqgADb.txubKOKkDYAiFBWTKezcTEiZEUga, rxfJJCYGwNNaCbrUpFZUeAqgADb.VFhYauUPnZBdwgDoKlHdHOvdZXgd, rxfJJCYGwNNaCbrUpFZUeAqgADb.oNvdrZnsuduQdHREretkAdPJMPGe, rxfJJCYGwNNaCbrUpFZUeAqgADb.ZFmEcYuCtIDsdnaKLMezECQPxKe, rxfJJCYGwNNaCbrUpFZUeAqgADb.bSmdtMnTvJnnJApvGJifxgddcpD, rxfJJCYGwNNaCbrUpFZUeAqgADb.RdxQvxOdJsEJeehpzcWklCzrCIla, rxfJJCYGwNNaCbrUpFZUeAqgADb.ipYFziCfquohTTpDXDYqlnMDTyb, rxfJJCYGwNNaCbrUpFZUeAqgADb.SdLIcSiQJMELqAfVaCaBbiKHDHjz)).Where(xvdIfUwebSQiKlewKMRaPiMswDO.zhsdPjFBOxzhaNJkhSxWpLyDGJSD);
	}

	public static bool CwGjVESmwrepLGmWTeaqgihDSYcj()
	{
		foreach (hdKCmGlHttTBdcjeWBCjBOXCTjJ item in FUYFkvWvvKHbFHzKCEkoUnCiWIh())
		{
			if (item.IsBluetoothDevice)
			{
				return true;
			}
		}
		return false;
	}

	public static int POIApcAGjfOoBdAvKfLhVcSifKmd()
	{
		return POIApcAGjfOoBdAvKfLhVcSifKmd(ref bfiTjsWKhvkLkCNKIDaCjyJRCam, rMUIUgiIkvFvzNOujFFXntvrpxL);
	}

	public static int POIApcAGjfOoBdAvKfLhVcSifKmd(ref SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP P_0, NativeBuffer P_1)
	{
		int num = 0;
		try
		{
			IntPtr intPtr = SbNYhPrwpuilnaawmyzrqxOYOrb.TmEHwxlqSYgRdzNFpboXGxcxOHI(ref P_0, P_1);
			while (intPtr != IntPtr.Zero)
			{
				if (P_1.ReadInt(20) > 0)
				{
					num++;
				}
				if (!SbNYhPrwpuilnaawmyzrqxOYOrb.xrZoTFKysPdQwNNGAGbJVdYhaQv(intPtr, P_1))
				{
					SbNYhPrwpuilnaawmyzrqxOYOrb.cfbWchfruJsvCoYqKrWGZFioIvQ(intPtr);
					break;
				}
			}
		}
		catch (Exception)
		{
		}
		return num;
	}

	private static IList<RxfJJCYGwNNaCbrUpFZUeAqgADb> mVUOrJLPGtnzKPatloBeLGjloip()
	{
		wqylGnmpEpPcLRdpWxlDXTjFbkL.Clear();
		cIGINtCgAWigtyBKJHpLdACdGsM.Clear();
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = FAybFIUyhQQoIUWFiuSraaiMBJE.WsDAUDGeXLegnwJYTTwgQyjKHoI(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo pSTAPHZotthAnMKYnqXsEnXfjZo = MnFvorhvfJcykaUhGaVGmsJCSWt();
			int num = 0;
			aErGNrezoerJjHOikkmXrhMXriYc.Clear();
			GfCCcbENhcVypPDxqlPnRqYsVpoD(aErGNrezoerJjHOikkmXrhMXriYc);
			List<JFPLZyKuGoOTrxCNBbkulqurpfP> list = aErGNrezoerJjHOikkmXrhMXriYc;
			ETSQlhIvzaSGJzwcBAwuANXzRZX.Clear();
			List<eohaloxHIeyxTvAfWjneestVTmm> eTSQlhIvzaSGJzwcBAwuANXzRZX = ETSQlhIvzaSGJzwcBAwuANXzRZX;
			while (FAybFIUyhQQoIUWFiuSraaiMBJE.EDPdkUnTuHEjFMKHxgeuLnbXEEV(intPtr, num, ref pSTAPHZotthAnMKYnqXsEnXfjZo))
			{
				num++;
				FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw qbNYVpkEAPCodaPjUxAeaxqXBRw = default(FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw);
				qbNYVpkEAPCodaPjUxAeaxqXBRw.OkVYmxvFGrESPrFalzVFsUcRvgP = qbNYVpkEAPCodaPjUxAeaxqXBRw.NativeSize;
				int num2 = 0;
				while (FAybFIUyhQQoIUWFiuSraaiMBJE.oHGgafMqTWjhGyGSRryGJctTsIH(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo, ref hidClassGuid, num2, ref qbNYVpkEAPCodaPjUxAeaxqXBRw))
				{
					num2++;
					string text = DOCJTqrqPezqwOAxkfZACPnXvvj(intPtr, qbNYVpkEAPCodaPjUxAeaxqXBRw);
					string instanceId = irvaOugJScqiEGewvLcIkbFliyY(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo);
					string description = gVNlZeNRpCepxPIwznUXemtCgNLK(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo) ?? DaLbTLHfBpQPwCQBwReKCgAEnGHa(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo);
					string manufacturer = MunafrhidUXWFBiSkoZDDMGqdbKd(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo);
					string locationInfo = string.Empty;
					uint yDotdNvqbaeFjJAKRDSZFwgTwPv = (uint)pSTAPHZotthAnMKYnqXsEnXfjZo.YDotdNvqbaeFjJAKRDSZFwgTwPv;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						if (list[i].EOFWiUtpGZZcKmLEjxCXfrQPtbg == yDotdNvqbaeFjJAKRDSZFwgTwPv)
						{
							int fXGQOYTFAMaAxDDPIaHNefmeQRVZ = list[i].FXGQOYTFAMaAxDDPIaHNefmeQRVZ;
							if (fXGQOYTFAMaAxDDPIaHNefmeQRVZ >= 0 && fXGQOYTFAMaAxDDPIaHNefmeQRVZ < count)
							{
								locationInfo = list[fXGQOYTFAMaAxDDPIaHNefmeQRVZ].wcTyvakCbTEeluuAVKfdfFgIuZd;
								break;
							}
							Logger.LogError("USB device index out of range.");
						}
					}
					bool flag;
					string bluetoothDeviceName;
					FFTesfchXsLumgosRGCsNFQTKGj(yDotdNvqbaeFjJAKRDSZFwgTwPv, ref eTSQlhIvzaSGJzwcBAwuANXzRZX, out flag, out bluetoothDeviceName);
					bool flag2 = false;
					if (flag)
					{
						flag2 = !MiTaakDtTfRXLUgbbwkXleXdyqh(text);
					}
					if (!flag2)
					{
						cIGINtCgAWigtyBKJHpLdACdGsM.Add(new RxfJJCYGwNNaCbrUpFZUeAqgADb(text, instanceId, description, manufacturer, locationInfo, flag, bluetoothDeviceName));
					}
				}
			}
			FAybFIUyhQQoIUWFiuSraaiMBJE.VOKWimCfGutIZfQFirWrqAcqarg(intPtr);
		}
		return cIGINtCgAWigtyBKJHpLdACdGsM;
	}

	private static void GfCCcbENhcVypPDxqlPnRqYsVpoD(List<JFPLZyKuGoOTrxCNBbkulqurpfP> P_0)
	{
		Guid gUID_DEVINTERFACE_USB_DEVICE = FAybFIUyhQQoIUWFiuSraaiMBJE.GUID_DEVINTERFACE_USB_DEVICE;
		IntPtr intPtr = FAybFIUyhQQoIUWFiuSraaiMBJE.WsDAUDGeXLegnwJYTTwgQyjKHoI(ref gUID_DEVINTERFACE_USB_DEVICE, null, 0, 18);
		if (intPtr.ToInt64() == -1)
		{
			return;
		}
		FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo pSTAPHZotthAnMKYnqXsEnXfjZo = MnFvorhvfJcykaUhGaVGmsJCSWt();
		int num = 0;
		while (FAybFIUyhQQoIUWFiuSraaiMBJE.EDPdkUnTuHEjFMKHxgeuLnbXEEV(intPtr, num, ref pSTAPHZotthAnMKYnqXsEnXfjZo))
		{
			num++;
			FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw qbNYVpkEAPCodaPjUxAeaxqXBRw = default(FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw);
			qbNYVpkEAPCodaPjUxAeaxqXBRw.OkVYmxvFGrESPrFalzVFsUcRvgP = qbNYVpkEAPCodaPjUxAeaxqXBRw.NativeSize;
			int num2 = 0;
			while (FAybFIUyhQQoIUWFiuSraaiMBJE.oHGgafMqTWjhGyGSRryGJctTsIH(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo, ref gUID_DEVINTERFACE_USB_DEVICE, num2, ref qbNYVpkEAPCodaPjUxAeaxqXBRw))
			{
				num2++;
				string locationInfo = NPypeIDjJPTQtKdpzaqbfHnFrgmw(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo);
				P_0.Add(new JFPLZyKuGoOTrxCNBbkulqurpfP(-1, (uint)pSTAPHZotthAnMKYnqXsEnXfjZo.YDotdNvqbaeFjJAKRDSZFwgTwPv, locationInfo));
				int parentIndex = P_0.Count - 1;
				List<uint> list = AfzCzAlvojgUxLcWDjYUfgdLiSp((uint)pSTAPHZotthAnMKYnqXsEnXfjZo.YDotdNvqbaeFjJAKRDSZFwgTwPv);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						P_0.Add(new JFPLZyKuGoOTrxCNBbkulqurpfP(parentIndex, list[i], null));
					}
				}
			}
		}
		FAybFIUyhQQoIUWFiuSraaiMBJE.VOKWimCfGutIZfQFirWrqAcqarg(intPtr);
	}

	private static List<eohaloxHIeyxTvAfWjneestVTmm> kIWoIASDsitnxhRoxdCIajyCHYP(List<eohaloxHIeyxTvAfWjneestVTmm> P_0)
	{
		Guid gUID_BluetoothClassGuid = FAybFIUyhQQoIUWFiuSraaiMBJE.GUID_BluetoothClassGuid;
		IntPtr intPtr = FAybFIUyhQQoIUWFiuSraaiMBJE.WsDAUDGeXLegnwJYTTwgQyjKHoI(ref gUID_BluetoothClassGuid, null, 0, 2);
		if (intPtr.ToInt64() != -1)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo pSTAPHZotthAnMKYnqXsEnXfjZo = MnFvorhvfJcykaUhGaVGmsJCSWt();
			int num = 0;
			while (FAybFIUyhQQoIUWFiuSraaiMBJE.EDPdkUnTuHEjFMKHxgeuLnbXEEV(intPtr, num, ref pSTAPHZotthAnMKYnqXsEnXfjZo))
			{
				num++;
				P_0.Add(new eohaloxHIeyxTvAfWjneestVTmm((uint)pSTAPHZotthAnMKYnqXsEnXfjZo.YDotdNvqbaeFjJAKRDSZFwgTwPv, VQGuTVKnsVgJUGUSZpxSiUKVlQCT(intPtr, ref pSTAPHZotthAnMKYnqXsEnXfjZo)));
			}
			FAybFIUyhQQoIUWFiuSraaiMBJE.VOKWimCfGutIZfQFirWrqAcqarg(intPtr);
		}
		return P_0;
	}

	private static string yLWavlCuELUwPIwyxBhXAOgMKsS(uint P_0)
	{
		string empty = string.Empty;
		yLWavlCuELUwPIwyxBhXAOgMKsS(P_0, 0, ref empty);
		return empty;
	}

	private static bool yLWavlCuELUwPIwyxBhXAOgMKsS(uint P_0, int P_1, ref string P_2)
	{
		List<uint> list = fIKZmEkAGfsKjcGTBbUjDmGOBhlQ(P_0);
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
			P_2 = string.Concat(obj, text, "(", list[j], ") ", hshIFhvScTDBkbYUWMJQfJnygCq(list[j]), "\n");
			yLWavlCuELUwPIwyxBhXAOgMKsS(list[j], P_1 + 1, ref P_2);
		}
		return true;
	}

	private static List<string> tPtIKFDVOiTMkBEZasnCVOhTlGq(uint P_0)
	{
		List<uint> list = AfzCzAlvojgUxLcWDjYUfgdLiSp(P_0);
		if (list == null)
		{
			return null;
		}
		List<string> list2 = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(hshIFhvScTDBkbYUWMJQfJnygCq(list[i]));
		}
		return list2;
	}

	private static List<uint> AfzCzAlvojgUxLcWDjYUfgdLiSp(uint P_0)
	{
		List<uint> list = fIKZmEkAGfsKjcGTBbUjDmGOBhlQ(P_0);
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
			List<uint> list3 = fIKZmEkAGfsKjcGTBbUjDmGOBhlQ(num);
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

	private static List<string> FJlbSDQLeBArfbfCIAiaEyFjALh(uint P_0)
	{
		uint num;
		if (FAybFIUyhQQoIUWFiuSraaiMBJE.sNWqWYLnpvaMmSaRfrHhFtlqQWF(out num, P_0, 0u) != 0)
		{
			return null;
		}
		List<string> list = new List<string>();
		list.Add(hshIFhvScTDBkbYUWMJQfJnygCq(num));
		while (FAybFIUyhQQoIUWFiuSraaiMBJE.mCPHuqydjNyPQLPotiNXEiIPschN(out num, num, 0u) == 0)
		{
			list.Add(hshIFhvScTDBkbYUWMJQfJnygCq(num));
		}
		return list;
	}

	private static List<uint> fIKZmEkAGfsKjcGTBbUjDmGOBhlQ(uint P_0)
	{
		uint num;
		if (FAybFIUyhQQoIUWFiuSraaiMBJE.sNWqWYLnpvaMmSaRfrHhFtlqQWF(out num, P_0, 0u) != 0)
		{
			return null;
		}
		List<uint> list = new List<uint>();
		list.Add(num);
		while (FAybFIUyhQQoIUWFiuSraaiMBJE.mCPHuqydjNyPQLPotiNXEiIPschN(out num, num, 0u) == 0)
		{
			list.Add(num);
		}
		return list;
	}

	private static string hshIFhvScTDBkbYUWMJQfJnygCq(uint P_0)
	{
		uint num;
		if (FAybFIUyhQQoIUWFiuSraaiMBJE.cLAcqAASuLeJfmyrnttJBJuLsdk(out num, P_0, 0u) != 0)
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
		if (FAybFIUyhQQoIUWFiuSraaiMBJE.ZrluQckoUeeqgmFGONXKoQoqCbe(P_0, intPtr, (int)num, 0u) != 0)
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

	private static bool IlACMRWVjDchtjooEmmlqkftKcOS(uint P_0, uint P_1)
	{
		List<uint> list = AfzCzAlvojgUxLcWDjYUfgdLiSp(P_0);
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

	private static void FFTesfchXsLumgosRGCsNFQTKGj(uint P_0, ref List<eohaloxHIeyxTvAfWjneestVTmm> P_1, out bool P_2, out string P_3)
	{
		P_3 = string.Empty;
		try
		{
			uint num;
			if (!yUuGAYjGtbEARNVvHKRzatSBMLeP(P_0, ref P_1, out P_2, out num) || P_1 == null)
			{
				return;
			}
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_1[i].EOFWiUtpGZZcKmLEjxCXfrQPtbg == num)
				{
					P_3 = P_1[i].HhLCnObivBTAgIeVUFxXfkzGVdu;
					break;
				}
			}
		}
		catch
		{
			P_2 = false;
		}
	}

	private static bool yUuGAYjGtbEARNVvHKRzatSBMLeP(uint P_0, ref List<eohaloxHIeyxTvAfWjneestVTmm> P_1, out bool P_2, out uint P_3)
	{
		P_2 = false;
		P_3 = 0u;
		string text;
		uint num;
		if (CPDVnUEWuPmgKzjxKgchemQSvIn(P_0, "BTHENUM", out text, out num))
		{
			P_2 = true;
			if (P_1.Count == 0)
			{
				kIWoIASDsitnxhRoxdCIajyCHYP(P_1);
			}
			string text2;
			uint num2;
			if (xsjGXVomTeJtkAtvhgnOgCPGaTV(text, out text2) && jBDcyeZsXwWwZqYSEAAJQKmVBzU(num, text2, out num2))
			{
				P_3 = num2;
				return true;
			}
		}
		return false;
	}

	private static bool CPDVnUEWuPmgKzjxKgchemQSvIn(uint P_0, string P_1, out string P_2, out uint P_3)
	{
		P_2 = string.Empty;
		P_3 = 0u;
		uint num = P_0;
		uint num2;
		while (FAybFIUyhQQoIUWFiuSraaiMBJE.gKeUiEjZmnsrkPWcwXWmWZoKCfk(out num2, num, 0u) == 0)
		{
			string text = hshIFhvScTDBkbYUWMJQfJnygCq(num2);
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

	private static bool xsjGXVomTeJtkAtvhgnOgCPGaTV(string P_0, out string P_1)
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

	private static bool jBDcyeZsXwWwZqYSEAAJQKmVBzU(uint P_0, string P_1, out uint P_2)
	{
		P_2 = 0u;
		if (string.IsNullOrEmpty(P_1))
		{
			return false;
		}
		uint num;
		if (FAybFIUyhQQoIUWFiuSraaiMBJE.gKeUiEjZmnsrkPWcwXWmWZoKCfk(out num, P_0, 0u) != 0)
		{
			return false;
		}
		uint num2;
		if (FAybFIUyhQQoIUWFiuSraaiMBJE.sNWqWYLnpvaMmSaRfrHhFtlqQWF(out num2, num, 0u) != 0)
		{
			return false;
		}
		uint num3 = num2;
		if (num3 == P_0 && FAybFIUyhQQoIUWFiuSraaiMBJE.mCPHuqydjNyPQLPotiNXEiIPschN(out num3, num3, 0u) != 0)
		{
			return false;
		}
		do
		{
			string text = hshIFhvScTDBkbYUWMJQfJnygCq(num3);
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
		while (FAybFIUyhQQoIUWFiuSraaiMBJE.mCPHuqydjNyPQLPotiNXEiIPschN(out num3, num3, 0u) == 0);
		return false;
	}

	private static bool MiTaakDtTfRXLUgbbwkXleXdyqh(string P_0, bool P_1 = true)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		string text = string.Empty;
		try
		{
			intPtr = hdKCmGlHttTBdcjeWBCjBOXCTjJ.CqgWnCWASUhKAQiZNHUBaEsvjsQ(P_0, rTzbEMDvKHZoPAqwvPfaoLyrXgi.zsEAbCQXtFYLJJvlswkmsKaYOfS, 3221225472u, utFNrkhqcRYjcoBIIPDdjrIEcTu.KdkAlnBkyoezudAOKFyDdMyEzPTm | utFNrkhqcRYjcoBIIPDdjrIEcTu.iQctmYQaAZvUIfEWvxxBsgVMmmY);
			if (intPtr != IntPtr.Zero)
			{
				text = hdKCmGlHttTBdcjeWBCjBOXCTjJ.IxpzKJSEkRAicNJjHalSOrWLwuN(intPtr);
				flag = true;
			}
		}
		catch
		{
			if (intPtr != IntPtr.Zero)
			{
				hdKCmGlHttTBdcjeWBCjBOXCTjJ.BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
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
				hdKCmGlHttTBdcjeWBCjBOXCTjJ.BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
			return true;
		}
		SbNYhPrwpuilnaawmyzrqxOYOrb.GdDHNowIUhXoGxIdCynqtXiEkGJ gdDHNowIUhXoGxIdCynqtXiEkGJ = SbNYhPrwpuilnaawmyzrqxOYOrb.GdDHNowIUhXoGxIdCynqtXiEkGJ.PUyMxMVdOkXYvYvIbxduIEXpbfYC(text, out flag);
		if (!flag)
		{
			if (intPtr != IntPtr.Zero)
			{
				hdKCmGlHttTBdcjeWBCjBOXCTjJ.BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
			return true;
		}
		bool flag2 = false;
		try
		{
			IntPtr intPtr2 = SbNYhPrwpuilnaawmyzrqxOYOrb.TmEHwxlqSYgRdzNFpboXGxcxOHI(ref bfiTjsWKhvkLkCNKIDaCjyJRCam, ref xLBrwZiYCRGEDHiSkGFxkFscGISA);
			if (intPtr2 == IntPtr.Zero)
			{
			}
			while (intPtr2 != IntPtr.Zero)
			{
				if (xLBrwZiYCRGEDHiSkGFxkFscGISA.XuxFYiGDuyhxTLDAyfwwNPrInCvD.CWVLkKYdHWNRdmkBqlzrncDXdMKh(ref gdDHNowIUhXoGxIdCynqtXiEkGJ))
				{
					flag2 = xLBrwZiYCRGEDHiSkGFxkFscGISA.ErfxNkCaphGHgDRByVlIVcwEZtH;
					SbNYhPrwpuilnaawmyzrqxOYOrb.cfbWchfruJsvCoYqKrWGZFioIvQ(intPtr2);
					if (!P_1 || flag2)
					{
						break;
					}
					WRmWIdgRNTmJYmlFGkqlcOyQAuac wRmWIdgRNTmJYmlFGkqlcOyQAuac = hdKCmGlHttTBdcjeWBCjBOXCTjJ.hzzRZCRvrUlctPxUbwHsbmFtIfM(intPtr);
					if (wRmWIdgRNTmJYmlFGkqlcOyQAuac.InputReportByteLength <= 0)
					{
						break;
					}
					int inputReportByteLength = wRmWIdgRNTmJYmlFGkqlcOyQAuac.InputReportByteLength;
					IntPtr intPtr3 = Marshal.AllocHGlobal(inputReportByteLength);
					try
					{
						if (!FAybFIUyhQQoIUWFiuSraaiMBJE.ARNEsCIcXhHtpOPJfoogZOKnNErB(intPtr, intPtr3, inputReportByteLength))
						{
							Marshal.WriteByte(intPtr3, 1);
							FAybFIUyhQQoIUWFiuSraaiMBJE.ARNEsCIcXhHtpOPJfoogZOKnNErB(intPtr, intPtr3, inputReportByteLength);
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
				if (!SbNYhPrwpuilnaawmyzrqxOYOrb.xrZoTFKysPdQwNNGAGbJVdYhaQv(intPtr2, ref xLBrwZiYCRGEDHiSkGFxkFscGISA))
				{
					SbNYhPrwpuilnaawmyzrqxOYOrb.cfbWchfruJsvCoYqKrWGZFioIvQ(intPtr2);
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
				hdKCmGlHttTBdcjeWBCjBOXCTjJ.BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
		return flag2;
	}

	private static FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo MnFvorhvfJcykaUhGaVGmsJCSWt()
	{
		FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo result = default(FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo);
		result.OkVYmxvFGrESPrFalzVFsUcRvgP = result.NativeSize;
		result.YDotdNvqbaeFjJAKRDSZFwgTwPv = 0;
		result.AzhXJWYwSTLUMkhJwFWcfiszhuBS = Guid.Empty;
		result.dexpPHWvlgXeBdBtZcdOwbWEwQC = IntPtr.Zero;
		return result;
	}

	private static string DOCJTqrqPezqwOAxkfZACPnXvvj(IntPtr P_0, FAybFIUyhQQoIUWFiuSraaiMBJE.qbNYVpkEAPCodaPjUxAeaxqXBRw P_1)
	{
		int num = 0;
		FAybFIUyhQQoIUWFiuSraaiMBJE.GFzPxQnZJkswlbBbXbDVmLSqfbN gFzPxQnZJkswlbBbXbDVmLSqfbN = new FAybFIUyhQQoIUWFiuSraaiMBJE.GFzPxQnZJkswlbBbXbDVmLSqfbN
		{
			URbjicLEKLuQBOXogMwFHYSSvns = ((IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8)
		};
		FAybFIUyhQQoIUWFiuSraaiMBJE.EvJuvPJhbdFaqYmXZXHApWDnddG(P_0, ref P_1, IntPtr.Zero, 0, ref num, IntPtr.Zero);
		if (!FAybFIUyhQQoIUWFiuSraaiMBJE.EvJuvPJhbdFaqYmXZXHApWDnddG(P_0, ref P_1, ref gFzPxQnZJkswlbBbXbDVmLSqfbN, num, ref num, IntPtr.Zero))
		{
			return null;
		}
		return gFzPxQnZJkswlbBbXbDVmLSqfbN.HfltaNpFkkwImYcMDEfAThIbQvs;
	}

	private static string irvaOugJScqiEGewvLcIkbFliyY(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(FAybFIUyhQQoIUWFiuSraaiMBJE.MAX_DEVICE_ID_LEN_BufferSizeInBytes);
		uint len;
		string result = (FAybFIUyhQQoIUWFiuSraaiMBJE.qTFafhHLSrbHKtnNlixZdEPuDVd(P_0, ref P_1, intPtr, (uint)FAybFIUyhQQoIUWFiuSraaiMBJE.MAX_DEVICE_ID_LEN_BufferSizeInChars, out len) ? Marshal.PtrToStringUni(intPtr, (int)len) : "FAILED");
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string DaLbTLHfBpQPwCQBwReKCgAEnGHa(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 0);
	}

	private static string VQGuTVKnsVgJUGUSZpxSiUKVlQCT(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 12);
	}

	private static string hRmvKXxaDdOUFoEtWhkymAbOZvB(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 14);
	}

	private static string MdHJOMjaTBTVStNTjVYTxrgaMAB(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 28);
	}

	private static string yLrivlZqSyEzFAXxbOvSWnGvzpP(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 21);
	}

	private static string xFperTkfAJMmKdmGBubvOUufRgsB(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 1);
	}

	private static string NPypeIDjJPTQtKdpzaqbfHnFrgmw(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 13);
	}

	private static string MunafrhidUXWFBiSkoZDDMGqdbKd(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		return sMgPEBFfzOgBGHGZQdledROhUBAA(P_0, ref P_1, 11);
	}

	private static string sMgPEBFfzOgBGHGZQdledROhUBAA(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1, int P_2)
	{
		int num = 0;
		int num2 = 0;
		FAybFIUyhQQoIUWFiuSraaiMBJE.GWKOxUDWvFCApUcCrefriRnpziX(P_0, ref P_1, P_2, ref num2, IntPtr.Zero, 0, ref num);
		if (num == 0)
		{
			return null;
		}
		int num3 = num;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (FAybFIUyhQQoIUWFiuSraaiMBJE.GWKOxUDWvFCApUcCrefriRnpziX(P_0, ref P_1, P_2, ref num2, intPtr, num3, ref num) ? JZINgvMPYvqwprOvdmSjOpaUHEF.xasgtlUXWJTxElKqvjYdHbuAJXr(intPtr, num3) : string.Empty);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string gVNlZeNRpCepxPIwznUXemtCgNLK(IntPtr P_0, ref FAybFIUyhQQoIUWFiuSraaiMBJE.pSTAPHZotthAnMKYnqXsEnXfjZo P_1)
	{
		if (Environment.OSVersion.Version.Major <= 5)
		{
			return null;
		}
		ulong num = 0uL;
		int num2 = 0;
		FAybFIUyhQQoIUWFiuSraaiMBJE.zAtzRjNlEwtUQHehkqWxdwmfoPC(P_0, ref P_1, ref FAybFIUyhQQoIUWFiuSraaiMBJE.JORmhOgKUWgmltofDYtrywanKpr, ref num, IntPtr.Zero, 0, ref num2, 0u);
		if (num2 == 0)
		{
			return string.Empty;
		}
		int num3 = num2;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (FAybFIUyhQQoIUWFiuSraaiMBJE.zAtzRjNlEwtUQHehkqWxdwmfoPC(P_0, ref P_1, ref FAybFIUyhQQoIUWFiuSraaiMBJE.JORmhOgKUWgmltofDYtrywanKpr, ref num, intPtr, num3, ref num2, 0u) ? JZINgvMPYvqwprOvdmSjOpaUHEF.xasgtlUXWJTxElKqvjYdHbuAJXr(intPtr, num3) : null);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	[CompilerGenerated]
	private static hdKCmGlHttTBdcjeWBCjBOXCTjJ JvKsyOFJthTnfsiHbDFEjhuyDHVM(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
	{
		return new hdKCmGlHttTBdcjeWBCjBOXCTjJ(P_0.txubKOKkDYAiFBWTKezcTEiZEUga, P_0.VFhYauUPnZBdwgDoKlHdHOvdZXgd, P_0.oNvdrZnsuduQdHREretkAdPJMPGe, P_0.ZFmEcYuCtIDsdnaKLMezECQPxKe, P_0.bSmdtMnTvJnnJApvGJifxgddcpD, P_0.RdxQvxOdJsEJeehpzcWklCzrCIla, P_0.ipYFziCfquohTTpDXDYqlnMDTyb, P_0.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
	}

	[CompilerGenerated]
	private static hdKCmGlHttTBdcjeWBCjBOXCTjJ byVBTMgeyaDTpUuzcOBrDqhLtCk(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
	{
		return new hdKCmGlHttTBdcjeWBCjBOXCTjJ(P_0.txubKOKkDYAiFBWTKezcTEiZEUga, P_0.VFhYauUPnZBdwgDoKlHdHOvdZXgd, P_0.oNvdrZnsuduQdHREretkAdPJMPGe, P_0.ZFmEcYuCtIDsdnaKLMezECQPxKe, P_0.bSmdtMnTvJnnJApvGJifxgddcpD, P_0.RdxQvxOdJsEJeehpzcWklCzrCIla, P_0.ipYFziCfquohTTpDXDYqlnMDTyb, P_0.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
	}

	[CompilerGenerated]
	private static hdKCmGlHttTBdcjeWBCjBOXCTjJ pYEBMiXTmdXyMEatrLvocohFyXb(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
	{
		return new hdKCmGlHttTBdcjeWBCjBOXCTjJ(P_0.txubKOKkDYAiFBWTKezcTEiZEUga, P_0.VFhYauUPnZBdwgDoKlHdHOvdZXgd, P_0.oNvdrZnsuduQdHREretkAdPJMPGe, P_0.ZFmEcYuCtIDsdnaKLMezECQPxKe, P_0.bSmdtMnTvJnnJApvGJifxgddcpD, P_0.RdxQvxOdJsEJeehpzcWklCzrCIla, P_0.ipYFziCfquohTTpDXDYqlnMDTyb, P_0.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
	}

	[CompilerGenerated]
	private static hdKCmGlHttTBdcjeWBCjBOXCTjJ GQlHppvOmvKSEwaGQGGXcCEDJyr(RxfJJCYGwNNaCbrUpFZUeAqgADb P_0)
	{
		return new hdKCmGlHttTBdcjeWBCjBOXCTjJ(P_0.txubKOKkDYAiFBWTKezcTEiZEUga, P_0.VFhYauUPnZBdwgDoKlHdHOvdZXgd, P_0.oNvdrZnsuduQdHREretkAdPJMPGe, P_0.ZFmEcYuCtIDsdnaKLMezECQPxKe, P_0.bSmdtMnTvJnnJApvGJifxgddcpD, P_0.RdxQvxOdJsEJeehpzcWklCzrCIla, P_0.ipYFziCfquohTTpDXDYqlnMDTyb, P_0.SdLIcSiQJMELqAfVaCaBbiKHDHjz);
	}
}
