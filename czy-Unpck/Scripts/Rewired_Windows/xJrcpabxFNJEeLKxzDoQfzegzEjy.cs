using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class xJrcpabxFNJEeLKxzDoQfzegzEjy
{
	public struct HgZMwhsohjWIBboQuvWWFfRgqgD
	{
		public string wBfZAprHjoVIsYRVRcKuXaLrCKU;

		public string NgwLeHXsiNEuQFNaUGBBFKnPZsm;

		public string YkyFjBfWTxOsPOCuRHOhQHSnuPM;

		public string nMscdkGKATnzAKPAikcirLuxBLs;

		public string KnZpXHBUqDIziSOUtvsQxsnEOP;

		public string rvQnZSVrubrJYjvqUNPhpGHukjV;

		public int iazejgWPovAgOFltZIdQbQSXeht;

		public int WcgTeWbfJEhSNnxCcVVixSsREdF;

		public bool jXJwqJxhAQYIcWlVSGRmrntxJuV;

		public string LYQMztlhbkFsNcEVBKxTgnhxfRF;

		public HgZMwhsohjWIBboQuvWWFfRgqgD(string path, string instanceId, string description, string manufacturer, string locationInfo, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			wBfZAprHjoVIsYRVRcKuXaLrCKU = path;
			NgwLeHXsiNEuQFNaUGBBFKnPZsm = fTvFFMKHyahmXrAOzQxsmenVpjI.bAsiNcmvQWMiTuiNtHATkYhgXzTP(path);
			YkyFjBfWTxOsPOCuRHOhQHSnuPM = instanceId;
			nMscdkGKATnzAKPAikcirLuxBLs = description;
			KnZpXHBUqDIziSOUtvsQxsnEOP = manufacturer;
			rvQnZSVrubrJYjvqUNPhpGHukjV = locationInfo;
			WcgTeWbfJEhSNnxCcVVixSsREdF = -1;
			iazejgWPovAgOFltZIdQbQSXeht = -1;
			jXJwqJxhAQYIcWlVSGRmrntxJuV = isBluetoothDevice;
			LYQMztlhbkFsNcEVBKxTgnhxfRF = bluetoothDeviceName;
			HXmtyxupLAKODmbUQczpgpOfxJBv();
		}

		private void HXmtyxupLAKODmbUQczpgpOfxJBv()
		{
			if (!string.IsNullOrEmpty(rvQnZSVrubrJYjvqUNPhpGHukjV))
			{
				int num = rvQnZSVrubrJYjvqUNPhpGHukjV.IndexOf("port_#", StringComparison.OrdinalIgnoreCase);
				int num2 = rvQnZSVrubrJYjvqUNPhpGHukjV.IndexOf("hub_#", StringComparison.OrdinalIgnoreCase);
				if (num >= 0 && num2 >= 0)
				{
					int.TryParse(rvQnZSVrubrJYjvqUNPhpGHukjV.Substring(num + 6, 4), out WcgTeWbfJEhSNnxCcVVixSsREdF);
					int.TryParse(rvQnZSVrubrJYjvqUNPhpGHukjV.Substring(num2 + 5, 4), out iazejgWPovAgOFltZIdQbQSXeht);
				}
			}
		}
	}

	private struct aaGPtYBFwUbzyDAAQGRNlFugLAB
	{
		public int KHNCZfdqokydWECDJwATbvPqlPlb;

		public uint LKYkhzYGkxMFtrROkOVBrUnzVzS;

		public string rvQnZSVrubrJYjvqUNPhpGHukjV;

		public aaGPtYBFwUbzyDAAQGRNlFugLAB(int parentIndex, uint deviceInstanceHandle, string locationInfo)
		{
			KHNCZfdqokydWECDJwATbvPqlPlb = parentIndex;
			LKYkhzYGkxMFtrROkOVBrUnzVzS = deviceInstanceHandle;
			rvQnZSVrubrJYjvqUNPhpGHukjV = locationInfo;
		}
	}

	private struct VQHxjMMLgcfVzjdiobDdDhkTDKM
	{
		public readonly uint LKYkhzYGkxMFtrROkOVBrUnzVzS;

		public readonly string WEGFjvGGCrhiHHRZBNEDpcIoBBGJ;

		public VQHxjMMLgcfVzjdiobDdDhkTDKM(uint deviceInstanceHandle, string friendlyName)
		{
			LKYkhzYGkxMFtrROkOVBrUnzVzS = deviceInstanceHandle;
			WEGFjvGGCrhiHHRZBNEDpcIoBBGJ = ((friendlyName == null) ? string.Empty : friendlyName);
		}
	}

	private sealed class GDivkJfxwuuCHJApgJQjFtDzpZr
	{
		public string WFQPFqMvofySWXGXchACMXAepIQ;

		public StringComparison mpYLeyCqpMszSFNAswQhBJaWOYB;

		public bool aREKxUfDrfAdHaKHcpBVEGsFpPRi(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
		{
			return P_0.NgwLeHXsiNEuQFNaUGBBFKnPZsm.Equals(WFQPFqMvofySWXGXchACMXAepIQ, mpYLeyCqpMszSFNAswQhBJaWOYB);
		}
	}

	private sealed class SLaoNGIUkbRNjwBkaKdPwsHxeIJ
	{
		public string WFQPFqMvofySWXGXchACMXAepIQ;

		public bool XdJphhVoJfUYiaiQDHrIRVtyOke(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
		{
			return P_0.NgwLeHXsiNEuQFNaUGBBFKnPZsm == WFQPFqMvofySWXGXchACMXAepIQ;
		}
	}

	private sealed class wrznnLpSncGNanGDyidGUxCcJkP
	{
		public int GbjlnZOlkxhZPSOBDicayQzeaoO;

		public int[] dxaDTcKgsMdrEdgLySdCQgFjVou;

		public bool jXZEbWpPXnxkIzjGAuQJYbPvPD(awBDVVAQrVojolizTQZQDabqRnX P_0)
		{
			if (P_0.Attributes.VendorId == GbjlnZOlkxhZPSOBDicayQzeaoO)
			{
				return dxaDTcKgsMdrEdgLySdCQgFjVou.Contains(P_0.Attributes.ProductId);
			}
			return false;
		}
	}

	private sealed class oNdLNuvOWnYGeSuKQhxwVHBoPpy
	{
		public int GbjlnZOlkxhZPSOBDicayQzeaoO;

		public bool kzbqGMukyXHIBEEekRmUpyDpWJe(awBDVVAQrVojolizTQZQDabqRnX P_0)
		{
			return P_0.Attributes.VendorId == GbjlnZOlkxhZPSOBDicayQzeaoO;
		}
	}

	private const string CTnmVFJWXWsJHpVOirvAFQHUDQS = "BTHENUM";

	private static Guid mkpCbhyXztCXisNvxFjpVmmStLI;

	private static List<awBDVVAQrVojolizTQZQDabqRnX> dIbeRINnFHuyiCJxXsjXBBStzjj;

	private static List<aaGPtYBFwUbzyDAAQGRNlFugLAB> lJmmISWqMGiiUJsqxrzNxnpvImo;

	private static List<HgZMwhsohjWIBboQuvWWFfRgqgD> tdVbLMpjKyUDOnDGMbCZJffBmksA;

	private static List<VQHxjMMLgcfVzjdiobDdDhkTDKM> LLLcqMAjRYbzgYcuWnjmyEkPbPli;

	private static VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi oudMdRfVeFNFLPJEDQVWliqxWoI;

	private static VqSFccEqDGfGMgdwzjgzGopfoSNj.DDdvrlpyFzimmHfZzxNowIasOxF yJOaLgDherlcmCcAfeWtwdJOWYq;

	private static NativeBuffer oSVBDwLSkNuEkEankWHUfIVPlvo;

	[CompilerGenerated]
	private static Func<HgZMwhsohjWIBboQuvWWFfRgqgD, awBDVVAQrVojolizTQZQDabqRnX> EgWyxHuxgebiCQCaqGFlopCufoj;

	[CompilerGenerated]
	private static Func<HgZMwhsohjWIBboQuvWWFfRgqgD, awBDVVAQrVojolizTQZQDabqRnX> jIUKpYMTcBkqRElkxPzjTjyyRLe;

	[CompilerGenerated]
	private static Func<HgZMwhsohjWIBboQuvWWFfRgqgD, awBDVVAQrVojolizTQZQDabqRnX> AvPlitmLCnJYUBoKTErwVMcDVes;

	[CompilerGenerated]
	private static Func<HgZMwhsohjWIBboQuvWWFfRgqgD, awBDVVAQrVojolizTQZQDabqRnX> deDLjwgGLIMCwFHrLaSGBUEncKYG;

	private static Guid HidClassGuid
	{
		get
		{
			if (mkpCbhyXztCXisNvxFjpVmmStLI.Equals(Guid.Empty))
			{
				UvOafjjHDydfBDHpjrlzeDLuZok.UlUCKRjuKMgAjfTGTqrHuAEHRrnX(ref mkpCbhyXztCXisNvxFjpVmmStLI);
			}
			return mkpCbhyXztCXisNvxFjpVmmStLI;
		}
	}

	static xJrcpabxFNJEeLKxzDoQfzegzEjy()
	{
		mkpCbhyXztCXisNvxFjpVmmStLI = Guid.Empty;
		dIbeRINnFHuyiCJxXsjXBBStzjj = new List<awBDVVAQrVojolizTQZQDabqRnX>();
		lJmmISWqMGiiUJsqxrzNxnpvImo = new List<aaGPtYBFwUbzyDAAQGRNlFugLAB>();
		tdVbLMpjKyUDOnDGMbCZJffBmksA = new List<HgZMwhsohjWIBboQuvWWFfRgqgD>();
		LLLcqMAjRYbzgYcuWnjmyEkPbPli = new List<VQHxjMMLgcfVzjdiobDdDhkTDKM>();
		oudMdRfVeFNFLPJEDQVWliqxWoI = new VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi
		{
			ZlwsNMmOwDtgQDskVCVzbvPohFF = (uint)Marshal.SizeOf(typeof(VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi)),
			VdsBvUMNQkKoXKbokltaMqpxEew = true,
			AQxWTkCCzQknGcWWqrVRNXtILFh = true,
			yCrBsLUIbJGRTOOBndhvEwWRzZo = false,
			FyvtZIWfDgPZdQzAJeIeEIGcGAo = true,
			lbNblCPSPMZZkdYlduYWnqBVgqX = IntPtr.Zero
		};
		yJOaLgDherlcmCcAfeWtwdJOWYq = VqSFccEqDGfGMgdwzjgzGopfoSNj.DDdvrlpyFzimmHfZzxNowIasOxF.ZyDMIRfUdtdyWWZsNvkwCISqzBR();
		oSVBDwLSkNuEkEankWHUfIVPlvo = new NativeBuffer((int)yJOaLgDherlcmCcAfeWtwdJOWYq.ZlwsNMmOwDtgQDskVCVzbvPohFF);
		oSVBDwLSkNuEkEankWHUfIVPlvo.Write(yJOaLgDherlcmCcAfeWtwdJOWYq.ZlwsNMmOwDtgQDskVCVzbvPohFF, 0);
	}

	public static bool ocdFackIqLzQDEipWGedjTPwenJl(string P_0)
	{
		bool flag = false;
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = UvOafjjHDydfBDHpjrlzeDLuZok.PTAZnqnxklDqUxQoKCxcAMreNDs(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI eMeZwvfXrxnIgRBXwTxzhUCxRFI = VLKjvCCfTdzXXrLfPiUUclkcDST();
			int num = 0;
			while (UvOafjjHDydfBDHpjrlzeDLuZok.FpKgDFGHbxGvILHMmHpkfFIzMWnC(intPtr, num, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI))
			{
				num++;
				UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp mWAjizYDDSIEaeosIMyfBqdvOPp = default(UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp);
				mWAjizYDDSIEaeosIMyfBqdvOPp.XBUVSQQiVDhcicgeaWCHmIDpIwv = Marshal.SizeOf((object)mWAjizYDDSIEaeosIMyfBqdvOPp);
				int num2 = 0;
				while (UvOafjjHDydfBDHpjrlzeDLuZok.pqFtvFxNMoGoWnfUYFiqDvZdPke(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI, ref hidClassGuid, num2, ref mWAjizYDDSIEaeosIMyfBqdvOPp))
				{
					num2++;
					if (P_0 == EQDvWXGTrKbTRFsrhoAWTiKfGrTk(intPtr, mWAjizYDDSIEaeosIMyfBqdvOPp))
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
			UvOafjjHDydfBDHpjrlzeDLuZok.QtHTLBhdaWOwgozTbslhaiJWCmC(intPtr);
		}
		return flag;
	}

	public static IList<HgZMwhsohjWIBboQuvWWFfRgqgD> ZFlFaOdoCSUuDlakJUzJGrreFGC()
	{
		return lPVBXKejpLCnWWeocfpLRylLcmJ();
	}

	public static awBDVVAQrVojolizTQZQDabqRnX nUIrDsrLbmAPfismjizkwjhdDsH(IList<HgZMwhsohjWIBboQuvWWFfRgqgD> P_0, string P_1, StringComparison P_2)
	{
		GDivkJfxwuuCHJApgJQjFtDzpZr gDivkJfxwuuCHJApgJQjFtDzpZr = new GDivkJfxwuuCHJApgJQjFtDzpZr();
		gDivkJfxwuuCHJApgJQjFtDzpZr.WFQPFqMvofySWXGXchACMXAepIQ = P_1;
		gDivkJfxwuuCHJApgJQjFtDzpZr.mpYLeyCqpMszSFNAswQhBJaWOYB = P_2;
		if (P_0 == null)
		{
			return null;
		}
		return liDgMZIvvyEcQqPySiFyJpfcchOf(P_0.FirstOrDefault(gDivkJfxwuuCHJApgJQjFtDzpZr.aREKxUfDrfAdHaKHcpBVEGsFpPRi));
	}

	public static awBDVVAQrVojolizTQZQDabqRnX liDgMZIvvyEcQqPySiFyJpfcchOf(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
	{
		try
		{
			if (string.IsNullOrEmpty(P_0.NgwLeHXsiNEuQFNaUGBBFKnPZsm))
			{
				return null;
			}
			return new awBDVVAQrVojolizTQZQDabqRnX(P_0.wBfZAprHjoVIsYRVRcKuXaLrCKU, P_0.YkyFjBfWTxOsPOCuRHOhQHSnuPM, P_0.nMscdkGKATnzAKPAikcirLuxBLs, P_0.KnZpXHBUqDIziSOUtvsQxsnEOP, P_0.iazejgWPovAgOFltZIdQbQSXeht, P_0.WcgTeWbfJEhSNnxCcVVixSsREdF, P_0.jXJwqJxhAQYIcWlVSGRmrntxJuV, P_0.LYQMztlhbkFsNcEVBKxTgnhxfRF);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static awBDVVAQrVojolizTQZQDabqRnX BgZQongBWtTKfmsnbdiKVLLtyaY(string P_0)
	{
		return KEDOmRnnXcsqMQcpTJzkEnSKMMs(P_0).FirstOrDefault();
	}

	public static IEnumerable<awBDVVAQrVojolizTQZQDabqRnX> KEDOmRnnXcsqMQcpTJzkEnSKMMs()
	{
		return from P_0 in lPVBXKejpLCnWWeocfpLRylLcmJ()
			select new awBDVVAQrVojolizTQZQDabqRnX(P_0.wBfZAprHjoVIsYRVRcKuXaLrCKU, P_0.YkyFjBfWTxOsPOCuRHOhQHSnuPM, P_0.nMscdkGKATnzAKPAikcirLuxBLs, P_0.KnZpXHBUqDIziSOUtvsQxsnEOP, P_0.iazejgWPovAgOFltZIdQbQSXeht, P_0.WcgTeWbfJEhSNnxCcVVixSsREdF, P_0.jXJwqJxhAQYIcWlVSGRmrntxJuV, P_0.LYQMztlhbkFsNcEVBKxTgnhxfRF);
	}

	public static IEnumerable<awBDVVAQrVojolizTQZQDabqRnX> KEDOmRnnXcsqMQcpTJzkEnSKMMs(string P_0)
	{
		SLaoNGIUkbRNjwBkaKdPwsHxeIJ sLaoNGIUkbRNjwBkaKdPwsHxeIJ = new SLaoNGIUkbRNjwBkaKdPwsHxeIJ();
		sLaoNGIUkbRNjwBkaKdPwsHxeIJ.WFQPFqMvofySWXGXchACMXAepIQ = P_0;
		return from hgZMwhsohjWIBboQuvWWFfRgqgD in lPVBXKejpLCnWWeocfpLRylLcmJ().Where(sLaoNGIUkbRNjwBkaKdPwsHxeIJ.XdJphhVoJfUYiaiQDHrIRVtyOke)
			select new awBDVVAQrVojolizTQZQDabqRnX(hgZMwhsohjWIBboQuvWWFfRgqgD.wBfZAprHjoVIsYRVRcKuXaLrCKU, hgZMwhsohjWIBboQuvWWFfRgqgD.YkyFjBfWTxOsPOCuRHOhQHSnuPM, hgZMwhsohjWIBboQuvWWFfRgqgD.nMscdkGKATnzAKPAikcirLuxBLs, hgZMwhsohjWIBboQuvWWFfRgqgD.KnZpXHBUqDIziSOUtvsQxsnEOP, hgZMwhsohjWIBboQuvWWFfRgqgD.iazejgWPovAgOFltZIdQbQSXeht, hgZMwhsohjWIBboQuvWWFfRgqgD.WcgTeWbfJEhSNnxCcVVixSsREdF, hgZMwhsohjWIBboQuvWWFfRgqgD.jXJwqJxhAQYIcWlVSGRmrntxJuV, hgZMwhsohjWIBboQuvWWFfRgqgD.LYQMztlhbkFsNcEVBKxTgnhxfRF);
	}

	public static IEnumerable<awBDVVAQrVojolizTQZQDabqRnX> KEDOmRnnXcsqMQcpTJzkEnSKMMs(int P_0, params int[] P_1)
	{
		wrznnLpSncGNanGDyidGUxCcJkP wrznnLpSncGNanGDyidGUxCcJkP2 = new wrznnLpSncGNanGDyidGUxCcJkP();
		wrznnLpSncGNanGDyidGUxCcJkP2.GbjlnZOlkxhZPSOBDicayQzeaoO = P_0;
		wrznnLpSncGNanGDyidGUxCcJkP2.dxaDTcKgsMdrEdgLySdCQgFjVou = P_1;
		return (from hgZMwhsohjWIBboQuvWWFfRgqgD in lPVBXKejpLCnWWeocfpLRylLcmJ()
			select new awBDVVAQrVojolizTQZQDabqRnX(hgZMwhsohjWIBboQuvWWFfRgqgD.wBfZAprHjoVIsYRVRcKuXaLrCKU, hgZMwhsohjWIBboQuvWWFfRgqgD.YkyFjBfWTxOsPOCuRHOhQHSnuPM, hgZMwhsohjWIBboQuvWWFfRgqgD.nMscdkGKATnzAKPAikcirLuxBLs, hgZMwhsohjWIBboQuvWWFfRgqgD.KnZpXHBUqDIziSOUtvsQxsnEOP, hgZMwhsohjWIBboQuvWWFfRgqgD.iazejgWPovAgOFltZIdQbQSXeht, hgZMwhsohjWIBboQuvWWFfRgqgD.WcgTeWbfJEhSNnxCcVVixSsREdF, hgZMwhsohjWIBboQuvWWFfRgqgD.jXJwqJxhAQYIcWlVSGRmrntxJuV, hgZMwhsohjWIBboQuvWWFfRgqgD.LYQMztlhbkFsNcEVBKxTgnhxfRF)).Where(wrznnLpSncGNanGDyidGUxCcJkP2.jXZEbWpPXnxkIzjGAuQJYbPvPD);
	}

	public static IEnumerable<awBDVVAQrVojolizTQZQDabqRnX> KEDOmRnnXcsqMQcpTJzkEnSKMMs(int P_0)
	{
		oNdLNuvOWnYGeSuKQhxwVHBoPpy oNdLNuvOWnYGeSuKQhxwVHBoPpy2 = new oNdLNuvOWnYGeSuKQhxwVHBoPpy();
		oNdLNuvOWnYGeSuKQhxwVHBoPpy2.GbjlnZOlkxhZPSOBDicayQzeaoO = P_0;
		return (from hgZMwhsohjWIBboQuvWWFfRgqgD in lPVBXKejpLCnWWeocfpLRylLcmJ()
			select new awBDVVAQrVojolizTQZQDabqRnX(hgZMwhsohjWIBboQuvWWFfRgqgD.wBfZAprHjoVIsYRVRcKuXaLrCKU, hgZMwhsohjWIBboQuvWWFfRgqgD.YkyFjBfWTxOsPOCuRHOhQHSnuPM, hgZMwhsohjWIBboQuvWWFfRgqgD.nMscdkGKATnzAKPAikcirLuxBLs, hgZMwhsohjWIBboQuvWWFfRgqgD.KnZpXHBUqDIziSOUtvsQxsnEOP, hgZMwhsohjWIBboQuvWWFfRgqgD.iazejgWPovAgOFltZIdQbQSXeht, hgZMwhsohjWIBboQuvWWFfRgqgD.WcgTeWbfJEhSNnxCcVVixSsREdF, hgZMwhsohjWIBboQuvWWFfRgqgD.jXJwqJxhAQYIcWlVSGRmrntxJuV, hgZMwhsohjWIBboQuvWWFfRgqgD.LYQMztlhbkFsNcEVBKxTgnhxfRF)).Where(oNdLNuvOWnYGeSuKQhxwVHBoPpy2.kzbqGMukyXHIBEEekRmUpyDpWJe);
	}

	public static bool ReJvInbBGFIOkILYWtjgnsCzoKCg()
	{
		foreach (awBDVVAQrVojolizTQZQDabqRnX item in KEDOmRnnXcsqMQcpTJzkEnSKMMs())
		{
			if (item.IsBluetoothDevice)
			{
				return true;
			}
		}
		return false;
	}

	public static int IEXPmNlUXBsTuJqdeOElowtTGYY()
	{
		return IEXPmNlUXBsTuJqdeOElowtTGYY(ref oudMdRfVeFNFLPJEDQVWliqxWoI, oSVBDwLSkNuEkEankWHUfIVPlvo);
	}

	public static int IEXPmNlUXBsTuJqdeOElowtTGYY(ref VqSFccEqDGfGMgdwzjgzGopfoSNj.BzpkqAlNnjifsUzvebxAiHHmeIi P_0, NativeBuffer P_1)
	{
		int num = 0;
		try
		{
			IntPtr intPtr = VqSFccEqDGfGMgdwzjgzGopfoSNj.AoJzhCIXimUoCuHLgjfHflBNcZaG(ref P_0, P_1);
			while (intPtr != IntPtr.Zero)
			{
				if (P_1.ReadInt(20) > 0)
				{
					num++;
				}
				if (!VqSFccEqDGfGMgdwzjgzGopfoSNj.sVYZQkzBAhXpPSrAPqtXHvjPAyT(intPtr, P_1))
				{
					VqSFccEqDGfGMgdwzjgzGopfoSNj.nucKvYUkAnPLrnmaZHcMkHFWnGgr(intPtr);
					break;
				}
			}
		}
		catch (Exception)
		{
		}
		return num;
	}

	private static IList<HgZMwhsohjWIBboQuvWWFfRgqgD> lPVBXKejpLCnWWeocfpLRylLcmJ()
	{
		dIbeRINnFHuyiCJxXsjXBBStzjj.Clear();
		tdVbLMpjKyUDOnDGMbCZJffBmksA.Clear();
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = UvOafjjHDydfBDHpjrlzeDLuZok.PTAZnqnxklDqUxQoKCxcAMreNDs(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI eMeZwvfXrxnIgRBXwTxzhUCxRFI = VLKjvCCfTdzXXrLfPiUUclkcDST();
			int num = 0;
			lJmmISWqMGiiUJsqxrzNxnpvImo.Clear();
			PWBQlEqmNABDIeKdlOMnxepYjbUb(lJmmISWqMGiiUJsqxrzNxnpvImo);
			List<aaGPtYBFwUbzyDAAQGRNlFugLAB> list = lJmmISWqMGiiUJsqxrzNxnpvImo;
			LLLcqMAjRYbzgYcuWnjmyEkPbPli.Clear();
			List<VQHxjMMLgcfVzjdiobDdDhkTDKM> lLLcqMAjRYbzgYcuWnjmyEkPbPli = LLLcqMAjRYbzgYcuWnjmyEkPbPli;
			while (UvOafjjHDydfBDHpjrlzeDLuZok.FpKgDFGHbxGvILHMmHpkfFIzMWnC(intPtr, num, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI))
			{
				num++;
				UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp mWAjizYDDSIEaeosIMyfBqdvOPp = default(UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp);
				mWAjizYDDSIEaeosIMyfBqdvOPp.XBUVSQQiVDhcicgeaWCHmIDpIwv = mWAjizYDDSIEaeosIMyfBqdvOPp.NativeSize;
				int num2 = 0;
				while (UvOafjjHDydfBDHpjrlzeDLuZok.pqFtvFxNMoGoWnfUYFiqDvZdPke(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI, ref hidClassGuid, num2, ref mWAjizYDDSIEaeosIMyfBqdvOPp))
				{
					num2++;
					string text = EQDvWXGTrKbTRFsrhoAWTiKfGrTk(intPtr, mWAjizYDDSIEaeosIMyfBqdvOPp);
					string instanceId = tjcAxFXRzMqNtVpgsROAkAoNdgaC(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI);
					string description = nWUCCLGgHkGKYeAaKgVTjcEUqPpI(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI) ?? MfQiOuKydLyTBLdJzdbKeinXOSz(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI);
					string manufacturer = VSkowYLNZqbbexoWnTOBDzjMtro(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI);
					string locationInfo = string.Empty;
					uint bdnuhiEDRYJmMEKrUVATZDBzLnX = (uint)eMeZwvfXrxnIgRBXwTxzhUCxRFI.BdnuhiEDRYJmMEKrUVATZDBzLnX;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						if (list[i].LKYkhzYGkxMFtrROkOVBrUnzVzS == bdnuhiEDRYJmMEKrUVATZDBzLnX)
						{
							int kHNCZfdqokydWECDJwATbvPqlPlb = list[i].KHNCZfdqokydWECDJwATbvPqlPlb;
							if (kHNCZfdqokydWECDJwATbvPqlPlb >= 0 && kHNCZfdqokydWECDJwATbvPqlPlb < count)
							{
								locationInfo = list[kHNCZfdqokydWECDJwATbvPqlPlb].rvQnZSVrubrJYjvqUNPhpGHukjV;
								break;
							}
							Logger.LogError("USB device index out of range.");
						}
					}
					YgWvNMHbnGigRlqcQDJiIPdrqWBF(bdnuhiEDRYJmMEKrUVATZDBzLnX, ref lLLcqMAjRYbzgYcuWnjmyEkPbPli, out var flag, out var bluetoothDeviceName);
					bool flag2 = false;
					if (flag)
					{
						flag2 = !BXMnPkixgNeioDjFqbAVduYDajT(text);
					}
					if (!flag2)
					{
						tdVbLMpjKyUDOnDGMbCZJffBmksA.Add(new HgZMwhsohjWIBboQuvWWFfRgqgD(text, instanceId, description, manufacturer, locationInfo, flag, bluetoothDeviceName));
					}
				}
			}
			UvOafjjHDydfBDHpjrlzeDLuZok.QtHTLBhdaWOwgozTbslhaiJWCmC(intPtr);
		}
		return tdVbLMpjKyUDOnDGMbCZJffBmksA;
	}

	private static void PWBQlEqmNABDIeKdlOMnxepYjbUb(List<aaGPtYBFwUbzyDAAQGRNlFugLAB> P_0)
	{
		Guid gUID_DEVINTERFACE_USB_DEVICE = UvOafjjHDydfBDHpjrlzeDLuZok.GUID_DEVINTERFACE_USB_DEVICE;
		IntPtr intPtr = UvOafjjHDydfBDHpjrlzeDLuZok.PTAZnqnxklDqUxQoKCxcAMreNDs(ref gUID_DEVINTERFACE_USB_DEVICE, null, 0, 18);
		if (intPtr.ToInt64() == -1)
		{
			return;
		}
		UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI eMeZwvfXrxnIgRBXwTxzhUCxRFI = VLKjvCCfTdzXXrLfPiUUclkcDST();
		int num = 0;
		while (UvOafjjHDydfBDHpjrlzeDLuZok.FpKgDFGHbxGvILHMmHpkfFIzMWnC(intPtr, num, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI))
		{
			num++;
			UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp mWAjizYDDSIEaeosIMyfBqdvOPp = default(UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp);
			mWAjizYDDSIEaeosIMyfBqdvOPp.XBUVSQQiVDhcicgeaWCHmIDpIwv = mWAjizYDDSIEaeosIMyfBqdvOPp.NativeSize;
			int num2 = 0;
			while (UvOafjjHDydfBDHpjrlzeDLuZok.pqFtvFxNMoGoWnfUYFiqDvZdPke(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI, ref gUID_DEVINTERFACE_USB_DEVICE, num2, ref mWAjizYDDSIEaeosIMyfBqdvOPp))
			{
				num2++;
				string locationInfo = OQtgjfKchjCnYfHlAolxkTMKnaWU(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI);
				P_0.Add(new aaGPtYBFwUbzyDAAQGRNlFugLAB(-1, (uint)eMeZwvfXrxnIgRBXwTxzhUCxRFI.BdnuhiEDRYJmMEKrUVATZDBzLnX, locationInfo));
				int parentIndex = P_0.Count - 1;
				List<uint> list = PcawTjYMlDxjIWUIITCGfYKtEID((uint)eMeZwvfXrxnIgRBXwTxzhUCxRFI.BdnuhiEDRYJmMEKrUVATZDBzLnX);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						P_0.Add(new aaGPtYBFwUbzyDAAQGRNlFugLAB(parentIndex, list[i], null));
					}
				}
			}
		}
		UvOafjjHDydfBDHpjrlzeDLuZok.QtHTLBhdaWOwgozTbslhaiJWCmC(intPtr);
	}

	private static List<VQHxjMMLgcfVzjdiobDdDhkTDKM> lnDzVfneOACOAsqBsusIyJLeoLz(List<VQHxjMMLgcfVzjdiobDdDhkTDKM> P_0)
	{
		Guid gUID_BluetoothClassGuid = UvOafjjHDydfBDHpjrlzeDLuZok.GUID_BluetoothClassGuid;
		IntPtr intPtr = UvOafjjHDydfBDHpjrlzeDLuZok.PTAZnqnxklDqUxQoKCxcAMreNDs(ref gUID_BluetoothClassGuid, null, 0, 2);
		if (intPtr.ToInt64() != -1)
		{
			UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI eMeZwvfXrxnIgRBXwTxzhUCxRFI = VLKjvCCfTdzXXrLfPiUUclkcDST();
			int num = 0;
			while (UvOafjjHDydfBDHpjrlzeDLuZok.FpKgDFGHbxGvILHMmHpkfFIzMWnC(intPtr, num, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI))
			{
				num++;
				P_0.Add(new VQHxjMMLgcfVzjdiobDdDhkTDKM((uint)eMeZwvfXrxnIgRBXwTxzhUCxRFI.BdnuhiEDRYJmMEKrUVATZDBzLnX, MwBiWwrWYjEivFDEYxyMAwppBYm(intPtr, ref eMeZwvfXrxnIgRBXwTxzhUCxRFI)));
			}
			UvOafjjHDydfBDHpjrlzeDLuZok.QtHTLBhdaWOwgozTbslhaiJWCmC(intPtr);
		}
		return P_0;
	}

	private static string xJRmRMvIqlVvmHRacuiVWABqKqa(uint P_0)
	{
		string empty = string.Empty;
		xJRmRMvIqlVvmHRacuiVWABqKqa(P_0, 0, ref empty);
		return empty;
	}

	private static bool xJRmRMvIqlVvmHRacuiVWABqKqa(uint P_0, int P_1, ref string P_2)
	{
		List<uint> list = kKVQxpVzkHvnWpMTAhNdAatoMdBc(P_0);
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
			P_2 = string.Concat(obj, text, "(", list[j], ") ", emyVSYIIWnKcLwcKLDEQilYAlIST(list[j]), "\n");
			xJRmRMvIqlVvmHRacuiVWABqKqa(list[j], P_1 + 1, ref P_2);
		}
		return true;
	}

	private static List<string> cigNoiwQxKqDZWUGvfXSJTtrjsO(uint P_0)
	{
		List<uint> list = PcawTjYMlDxjIWUIITCGfYKtEID(P_0);
		if (list == null)
		{
			return null;
		}
		List<string> list2 = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(emyVSYIIWnKcLwcKLDEQilYAlIST(list[i]));
		}
		return list2;
	}

	private static List<uint> PcawTjYMlDxjIWUIITCGfYKtEID(uint P_0)
	{
		List<uint> list = kKVQxpVzkHvnWpMTAhNdAatoMdBc(P_0);
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
			List<uint> list3 = kKVQxpVzkHvnWpMTAhNdAatoMdBc(num);
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

	private static List<string> QkasmpzARblYVgMHDbwgUgaVPhP(uint P_0)
	{
		if (UvOafjjHDydfBDHpjrlzeDLuZok.nRXCFrhmDNLlBPLLiyCjhXEQWIpd(out var num, P_0, 0u) != 0)
		{
			return null;
		}
		List<string> list = new List<string>();
		list.Add(emyVSYIIWnKcLwcKLDEQilYAlIST(num));
		while (UvOafjjHDydfBDHpjrlzeDLuZok.zxOzpLHWLjCqbOJaccUXyvljEoNf(out num, num, 0u) == 0)
		{
			list.Add(emyVSYIIWnKcLwcKLDEQilYAlIST(num));
		}
		return list;
	}

	private static List<uint> kKVQxpVzkHvnWpMTAhNdAatoMdBc(uint P_0)
	{
		if (UvOafjjHDydfBDHpjrlzeDLuZok.nRXCFrhmDNLlBPLLiyCjhXEQWIpd(out var num, P_0, 0u) != 0)
		{
			return null;
		}
		List<uint> list = new List<uint>();
		list.Add(num);
		while (UvOafjjHDydfBDHpjrlzeDLuZok.zxOzpLHWLjCqbOJaccUXyvljEoNf(out num, num, 0u) == 0)
		{
			list.Add(num);
		}
		return list;
	}

	private static string emyVSYIIWnKcLwcKLDEQilYAlIST(uint P_0)
	{
		if (UvOafjjHDydfBDHpjrlzeDLuZok.vJZdWfjCAleRIrvfagXLNTFhxjS(out var num, P_0, 0u) != 0)
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
		if (UvOafjjHDydfBDHpjrlzeDLuZok.UgOdJMHeGXDLujWLFIAViVWKQYZ(P_0, intPtr, (int)num, 0u) != 0)
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

	private static bool FQDQPcvbLpXGSrouTGxpAaOBmucC(uint P_0, uint P_1)
	{
		List<uint> list = PcawTjYMlDxjIWUIITCGfYKtEID(P_0);
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

	private static void YgWvNMHbnGigRlqcQDJiIPdrqWBF(uint P_0, ref List<VQHxjMMLgcfVzjdiobDdDhkTDKM> P_1, out bool P_2, out string P_3)
	{
		P_3 = string.Empty;
		try
		{
			if (!tLhOHnfCBBthkMBxEnEfvNvccLK(P_0, ref P_1, out P_2, out var num) || P_1 == null)
			{
				return;
			}
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_1[i].LKYkhzYGkxMFtrROkOVBrUnzVzS == num)
				{
					P_3 = P_1[i].WEGFjvGGCrhiHHRZBNEDpcIoBBGJ;
					break;
				}
			}
		}
		catch
		{
			P_2 = false;
		}
	}

	private static bool tLhOHnfCBBthkMBxEnEfvNvccLK(uint P_0, ref List<VQHxjMMLgcfVzjdiobDdDhkTDKM> P_1, out bool P_2, out uint P_3)
	{
		P_2 = false;
		P_3 = 0u;
		if (FJWMQldGsbIHbmzbZWzxsttoGjT(P_0, "BTHENUM", out var text, out var num))
		{
			P_2 = true;
			if (P_1.Count == 0)
			{
				lnDzVfneOACOAsqBsusIyJLeoLz(P_1);
			}
			if (sGcTqSDlFAyTyXjGkfCHesEkVez(text, out var text2) && sYAfxTmgdOqVivEQJRPTSBTxatuh(num, text2, out var num2))
			{
				P_3 = num2;
				return true;
			}
		}
		return false;
	}

	private static bool FJWMQldGsbIHbmzbZWzxsttoGjT(uint P_0, string P_1, out string P_2, out uint P_3)
	{
		P_2 = string.Empty;
		P_3 = 0u;
		uint num = P_0;
		uint num2;
		while (UvOafjjHDydfBDHpjrlzeDLuZok.tclJvnKoSZISLIdglUSoYPVogMM(out num2, num, 0u) == 0)
		{
			string text = emyVSYIIWnKcLwcKLDEQilYAlIST(num2);
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

	private static bool sGcTqSDlFAyTyXjGkfCHesEkVez(string P_0, out string P_1)
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

	private static bool sYAfxTmgdOqVivEQJRPTSBTxatuh(uint P_0, string P_1, out uint P_2)
	{
		P_2 = 0u;
		if (string.IsNullOrEmpty(P_1))
		{
			return false;
		}
		if (UvOafjjHDydfBDHpjrlzeDLuZok.tclJvnKoSZISLIdglUSoYPVogMM(out var num, P_0, 0u) != 0)
		{
			return false;
		}
		if (UvOafjjHDydfBDHpjrlzeDLuZok.nRXCFrhmDNLlBPLLiyCjhXEQWIpd(out var num2, num, 0u) != 0)
		{
			return false;
		}
		uint num3 = num2;
		if (num3 == P_0 && UvOafjjHDydfBDHpjrlzeDLuZok.zxOzpLHWLjCqbOJaccUXyvljEoNf(out num3, num3, 0u) != 0)
		{
			return false;
		}
		do
		{
			string text = emyVSYIIWnKcLwcKLDEQilYAlIST(num3);
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
		while (UvOafjjHDydfBDHpjrlzeDLuZok.zxOzpLHWLjCqbOJaccUXyvljEoNf(out num3, num3, 0u) == 0);
		return false;
	}

	private static bool BXMnPkixgNeioDjFqbAVduYDajT(string P_0, bool P_1 = true)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		string text = string.Empty;
		try
		{
			intPtr = awBDVVAQrVojolizTQZQDabqRnX.HKjJtpjhmoeUfTKHQqKHasPJhgi(P_0, wLgsatiSRzspXBQkeKrpifqDJhM.gnLHwEdBbfhRiUtWjjcmmKdeGsy, 3221225472u, rUSAwXbYObnIJBpUJPClFxhEcTAH.VsdksCukYWYYZgKCNnHZCjNeZgx | rUSAwXbYObnIJBpUJPClFxhEcTAH.fvdeABpWKzEvnyVAekRvohXyaXK);
			if (intPtr != IntPtr.Zero)
			{
				text = awBDVVAQrVojolizTQZQDabqRnX.NYcwJindAhRkFWwnCqKYYgxzixr(intPtr);
				flag = true;
			}
		}
		catch
		{
			if (intPtr != IntPtr.Zero)
			{
				awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
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
				awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
			}
			return true;
		}
		VqSFccEqDGfGMgdwzjgzGopfoSNj.nyaJxPRygcMUqbeZNPzxQRtrFQJ nyaJxPRygcMUqbeZNPzxQRtrFQJ = VqSFccEqDGfGMgdwzjgzGopfoSNj.nyaJxPRygcMUqbeZNPzxQRtrFQJ.WtxDkxbqiMAxGUPYmioqBYoePdwa(text, out flag);
		if (!flag)
		{
			if (intPtr != IntPtr.Zero)
			{
				awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
			}
			return true;
		}
		bool flag2 = false;
		try
		{
			IntPtr intPtr2 = VqSFccEqDGfGMgdwzjgzGopfoSNj.AoJzhCIXimUoCuHLgjfHflBNcZaG(ref oudMdRfVeFNFLPJEDQVWliqxWoI, ref yJOaLgDherlcmCcAfeWtwdJOWYq);
			if (intPtr2 == IntPtr.Zero)
			{
			}
			while (intPtr2 != IntPtr.Zero)
			{
				if (yJOaLgDherlcmCcAfeWtwdJOWYq.QlePJBcEQAOCsQEAvmbeNRMudIPg.RVMcxdGhngjiGDdRCrodYfgGzSiM(ref nyaJxPRygcMUqbeZNPzxQRtrFQJ))
				{
					flag2 = yJOaLgDherlcmCcAfeWtwdJOWYq.PjkuTHhiPJdvVGXBhSSGVODkLLf;
					VqSFccEqDGfGMgdwzjgzGopfoSNj.nucKvYUkAnPLrnmaZHcMkHFWnGgr(intPtr2);
					if (!P_1 || flag2)
					{
						break;
					}
					BNbkHUFhjdAedbtJHojnbgVaVcMu bNbkHUFhjdAedbtJHojnbgVaVcMu = awBDVVAQrVojolizTQZQDabqRnX.scuEzsqVoZKOmYQarjmPrsFlSgv(intPtr);
					if (bNbkHUFhjdAedbtJHojnbgVaVcMu.InputReportByteLength <= 0)
					{
						break;
					}
					int inputReportByteLength = bNbkHUFhjdAedbtJHojnbgVaVcMu.InputReportByteLength;
					IntPtr intPtr3 = Marshal.AllocHGlobal(inputReportByteLength);
					try
					{
						if (!UvOafjjHDydfBDHpjrlzeDLuZok.BjQovjBhtXnUISWPwzWwSyzLQQB(intPtr, intPtr3, inputReportByteLength))
						{
							Marshal.WriteByte(intPtr3, 1);
							UvOafjjHDydfBDHpjrlzeDLuZok.BjQovjBhtXnUISWPwzWwSyzLQQB(intPtr, intPtr3, inputReportByteLength);
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
				if (!VqSFccEqDGfGMgdwzjgzGopfoSNj.sVYZQkzBAhXpPSrAPqtXHvjPAyT(intPtr2, ref yJOaLgDherlcmCcAfeWtwdJOWYq))
				{
					VqSFccEqDGfGMgdwzjgzGopfoSNj.nucKvYUkAnPLrnmaZHcMkHFWnGgr(intPtr2);
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
				awBDVVAQrVojolizTQZQDabqRnX.OpSooMXoJcVRevXVvKUuePnULpV(intPtr);
			}
		}
		return flag2;
	}

	private static UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI VLKjvCCfTdzXXrLfPiUUclkcDST()
	{
		UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI result = default(UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI);
		result.XBUVSQQiVDhcicgeaWCHmIDpIwv = result.NativeSize;
		result.BdnuhiEDRYJmMEKrUVATZDBzLnX = 0;
		result.HgiGUhrrcnCtxzKVjxRiuoVJakh = Guid.Empty;
		result.sTmqEkhRSUkctkpBEmIUcrYqQFe = IntPtr.Zero;
		return result;
	}

	private static string EQDvWXGTrKbTRFsrhoAWTiKfGrTk(IntPtr P_0, UvOafjjHDydfBDHpjrlzeDLuZok.mWAjizYDDSIEaeosIMyfBqdvOPp P_1)
	{
		int num = 0;
		UvOafjjHDydfBDHpjrlzeDLuZok.WPYUqawdkRUUCzPzeeoCfMjouTii wPYUqawdkRUUCzPzeeoCfMjouTii = new UvOafjjHDydfBDHpjrlzeDLuZok.WPYUqawdkRUUCzPzeeoCfMjouTii
		{
			TLeVbTkHqlErgCNobbLVWJbiKpUB = ((IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8)
		};
		UvOafjjHDydfBDHpjrlzeDLuZok.HpWtYUqCFXiHDXRqOKnDdNnZlie(P_0, ref P_1, IntPtr.Zero, 0, ref num, IntPtr.Zero);
		if (!UvOafjjHDydfBDHpjrlzeDLuZok.HpWtYUqCFXiHDXRqOKnDdNnZlie(P_0, ref P_1, ref wPYUqawdkRUUCzPzeeoCfMjouTii, num, ref num, IntPtr.Zero))
		{
			return null;
		}
		return wPYUqawdkRUUCzPzeeoCfMjouTii.UfskYkUkjETwNXbgAZpOPZrPCJS;
	}

	private static string tjcAxFXRzMqNtVpgsROAkAoNdgaC(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(UvOafjjHDydfBDHpjrlzeDLuZok.MAX_DEVICE_ID_LEN_BufferSizeInBytes);
		uint len;
		string result = (UvOafjjHDydfBDHpjrlzeDLuZok.pRYdKWeyuTYtAqXBqdBXdwGIJpB(P_0, ref P_1, intPtr, (uint)UvOafjjHDydfBDHpjrlzeDLuZok.MAX_DEVICE_ID_LEN_BufferSizeInChars, out len) ? Marshal.PtrToStringUni(intPtr, (int)len) : "FAILED");
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string MfQiOuKydLyTBLdJzdbKeinXOSz(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 0);
	}

	private static string MwBiWwrWYjEivFDEYxyMAwppBYm(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 12);
	}

	private static string iPhkXkYpoDbWehdPHfIiqSGcrLv(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 14);
	}

	private static string FDSYptYfjpiutirFcqEHxKPMrGz(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 28);
	}

	private static string pTyhGycUJQhkPTJTgDKaMWCBlDp(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 21);
	}

	private static string qVcRwoKwsfkVpbRGnQsxEDJXywW(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 1);
	}

	private static string OQtgjfKchjCnYfHlAolxkTMKnaWU(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 13);
	}

	private static string VSkowYLNZqbbexoWnTOBDzjMtro(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		return zNvFXgmsBcFylDZHNowkaFdueJeQ(P_0, ref P_1, 11);
	}

	private static string zNvFXgmsBcFylDZHNowkaFdueJeQ(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1, int P_2)
	{
		int num = 0;
		int num2 = 0;
		UvOafjjHDydfBDHpjrlzeDLuZok.JQVBqjkiVpSzOQBEmdyjeiIIXghv(P_0, ref P_1, P_2, ref num2, IntPtr.Zero, 0, ref num);
		if (num == 0)
		{
			return null;
		}
		int num3 = num;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (UvOafjjHDydfBDHpjrlzeDLuZok.JQVBqjkiVpSzOQBEmdyjeiIIXghv(P_0, ref P_1, P_2, ref num2, intPtr, num3, ref num) ? GTPAhGInkBQTUcszeVNtCWZheShf.eafrxYrHibsUpicgkqFhVdRebFP(intPtr, num3) : string.Empty);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string nWUCCLGgHkGKYeAaKgVTjcEUqPpI(IntPtr P_0, ref UvOafjjHDydfBDHpjrlzeDLuZok.eMeZwvfXrxnIgRBXwTxzhUCxRFI P_1)
	{
		if (Environment.OSVersion.Version.Major <= 5)
		{
			return null;
		}
		ulong num = 0uL;
		int num2 = 0;
		UvOafjjHDydfBDHpjrlzeDLuZok.upmfGKmqoOHxrKaxnLFdvnTJoLw(P_0, ref P_1, ref UvOafjjHDydfBDHpjrlzeDLuZok.OGIvWvBvisJnGaJvMhPtckLTcIN, ref num, IntPtr.Zero, 0, ref num2, 0u);
		if (num2 == 0)
		{
			return string.Empty;
		}
		int num3 = num2;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (UvOafjjHDydfBDHpjrlzeDLuZok.upmfGKmqoOHxrKaxnLFdvnTJoLw(P_0, ref P_1, ref UvOafjjHDydfBDHpjrlzeDLuZok.OGIvWvBvisJnGaJvMhPtckLTcIN, ref num, intPtr, num3, ref num2, 0u) ? GTPAhGInkBQTUcszeVNtCWZheShf.eafrxYrHibsUpicgkqFhVdRebFP(intPtr, num3) : null);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	[CompilerGenerated]
	private static awBDVVAQrVojolizTQZQDabqRnX SfHDxfkpJPfIUJdToyOScrTICTfF(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
	{
		return new awBDVVAQrVojolizTQZQDabqRnX(P_0.wBfZAprHjoVIsYRVRcKuXaLrCKU, P_0.YkyFjBfWTxOsPOCuRHOhQHSnuPM, P_0.nMscdkGKATnzAKPAikcirLuxBLs, P_0.KnZpXHBUqDIziSOUtvsQxsnEOP, P_0.iazejgWPovAgOFltZIdQbQSXeht, P_0.WcgTeWbfJEhSNnxCcVVixSsREdF, P_0.jXJwqJxhAQYIcWlVSGRmrntxJuV, P_0.LYQMztlhbkFsNcEVBKxTgnhxfRF);
	}

	[CompilerGenerated]
	private static awBDVVAQrVojolizTQZQDabqRnX yOYGMvPGwUyaIHtYzAKnBMsfGcQ(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
	{
		return new awBDVVAQrVojolizTQZQDabqRnX(P_0.wBfZAprHjoVIsYRVRcKuXaLrCKU, P_0.YkyFjBfWTxOsPOCuRHOhQHSnuPM, P_0.nMscdkGKATnzAKPAikcirLuxBLs, P_0.KnZpXHBUqDIziSOUtvsQxsnEOP, P_0.iazejgWPovAgOFltZIdQbQSXeht, P_0.WcgTeWbfJEhSNnxCcVVixSsREdF, P_0.jXJwqJxhAQYIcWlVSGRmrntxJuV, P_0.LYQMztlhbkFsNcEVBKxTgnhxfRF);
	}

	[CompilerGenerated]
	private static awBDVVAQrVojolizTQZQDabqRnX suBpPHudKZBZldPhuOegccCpIJRN(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
	{
		return new awBDVVAQrVojolizTQZQDabqRnX(P_0.wBfZAprHjoVIsYRVRcKuXaLrCKU, P_0.YkyFjBfWTxOsPOCuRHOhQHSnuPM, P_0.nMscdkGKATnzAKPAikcirLuxBLs, P_0.KnZpXHBUqDIziSOUtvsQxsnEOP, P_0.iazejgWPovAgOFltZIdQbQSXeht, P_0.WcgTeWbfJEhSNnxCcVVixSsREdF, P_0.jXJwqJxhAQYIcWlVSGRmrntxJuV, P_0.LYQMztlhbkFsNcEVBKxTgnhxfRF);
	}

	[CompilerGenerated]
	private static awBDVVAQrVojolizTQZQDabqRnX NRiYtAUdcNIvppnqVCZXcbrzqJL(HgZMwhsohjWIBboQuvWWFfRgqgD P_0)
	{
		return new awBDVVAQrVojolizTQZQDabqRnX(P_0.wBfZAprHjoVIsYRVRcKuXaLrCKU, P_0.YkyFjBfWTxOsPOCuRHOhQHSnuPM, P_0.nMscdkGKATnzAKPAikcirLuxBLs, P_0.KnZpXHBUqDIziSOUtvsQxsnEOP, P_0.iazejgWPovAgOFltZIdQbQSXeht, P_0.WcgTeWbfJEhSNnxCcVVixSsREdF, P_0.jXJwqJxhAQYIcWlVSGRmrntxJuV, P_0.LYQMztlhbkFsNcEVBKxTgnhxfRF);
	}
}
