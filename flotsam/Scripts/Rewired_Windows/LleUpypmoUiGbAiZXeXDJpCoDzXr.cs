using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal sealed class LleUpypmoUiGbAiZXeXDJpCoDzXr : rtcpRxBVLKAMkXCloKUnYbCBcUfE, IDisposable
{
	private delegate bAMLcXCOLNEyOpLJlObBIWMbGZTG ABOYkJldyyCWRaeOZkdGdKmcESziA(int timeout);

	private delegate MzAEeQvtcMiCvRVxsGhqGrZMXAFjA elOANEyjULCEUkpDBPLcadSzMgyMA(int timeout);

	private delegate bool mjKweZXqiFPralGmvHmAbHcANjEDb(byte[] data, int timeout);

	private delegate bool FFuPhkjMzqGJYGrgWmuyEbenyPNA(byte[] data, int timeout, bool setOutputReportDirectly);

	private delegate bool ptasUKesvsrbqYiTDzwaDDsWNKsl(MzAEeQvtcMiCvRVxsGhqGrZMXAFjA report, int timeout);

	private enum pxNhQBkncvqGdEaGzpwSPfMxrHwC
	{
		Closed = 0,
		Read = 1,
		Write = 2
	}

	private enum oxfCMyfzMgVWgmOvnxoNVpbJlzNKA
	{
		Success = 0,
		ReadError = 1,
		BufferTooSmall = 2,
		DeviceNotOpen = 3
	}

	private struct OIAivuiYswiRLOmdZxOUNhhpDqYk
	{
		public bool mTcZYbGCdRafVdLCDFTaREQLFjMHA;

		public int XpXKdwXVJuCldjiuaromNbEsNgUR;

		public int JIOLzSmZIGknJjROwwJdjcJKmHUp;
	}

	public const int OcAphPAQAdgyoshXUenyPjDKpXxI = 255;

	[CompilerGenerated]
	private qhrOhuDGsGAdaRXsmoTpALtdEjTi GCTVgMNheiroJUGNyustHKssbGOi;

	[CompilerGenerated]
	private bQFtYuoBtBaJFehLDUkcQBvycaVmA tDVhrSrTPmCbnzfFZcbhpavHyUog;

	private readonly string LSdzoGobwarCqybgWnAZCyIWPhuT;

	private readonly string GNugpKPaiWxcqTECHGQBrKzpfUN;

	private readonly string ElpQClKADnrfqjeZsaLPHkwWpxIw;

	private readonly string lkqdAgcivrOkPqlCRTRCUQfLXcRAA;

	private readonly IegeVwdBtiZGJTqtldaDMkExGYrW kbWlMbNxETbEbshdoonRODHBAbrG;

	private readonly string cBByAuocTALvBaQhwkDRfNsdaNneA;

	private readonly int OWVPgCBlVDCHmeHyIImYCCkLUkOT;

	private readonly int RbZNhHFmDBgYvrJyAwfeVKphqYCH;

	private readonly bool cJwIUtHtufUzEelbqsFvBXQjdQOD;

	private readonly string gIRloKdGiJmKOeSpcJmnpEASJXCA;

	private readonly uint NdbnBQsCXnCLGsJlrzUnfgjUvVRe;

	private readonly ycGgUdwHgcQyyOgrTFgwoMuaXMWV dZSJUugxTYGnoZHHrwAdxaLxJAyS;

	private readonly PooJpACaWffyuznpWZHvpYIMTVPm[] rPPDJqflfDOKXcozcUyLdiHKjqsdc;

	private readonly aTedyfCyjkFlTNoTgtYcHldvQSsDA[] JmvXxXOotyDPzUtTlLlnkJlqeZgU;

	private JGDhfUZBOiCuUelScgHsgeHJJnUPA QToFJnCkSCtcEHtoRewAeajcGUGnb;

	private JGDhfUZBOiCuUelScgHsgeHJJnUPA dTxePQBGmwQQpVAdvaCVgzqdFRJWA;

	private OFjGjmJvTsMMYZEcTJJanfOutjGaA TySbdriRNrQoJcizyLdjERTgoCqsB = OFjGjmJvTsMMYZEcTJJanfOutjGaA.ShareRead | OFjGjmJvTsMMYZEcTJJanfOutjGaA.ShareWrite;

	private readonly snrfMqbMLqcPnIVNKmjxmPEIeKUFb CkUrHChNHkEgocvdSShKEWdrBBWu;

	private bool kwxilOyCVPbzsbglLomfyGeFIWsr;

	private global::ptDAZOMgYivncCYMdWwaXadwMfL<loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA> JIdilxRfwBAMteKavRGbCfxksWqlc;

	private global::ptDAZOMgYivncCYMdWwaXadwMfL<loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP> uyUJDimwcHIaWJsjFUhHkWpxFUKl;

	private readonly Rewired.Utils.Classes.Utility.SpinLock CHdruwtlevugyTxyEPoOmIqwqDKP = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock vDAZgjdhqzRdnIDMkGWQUaYusIpr = new Rewired.Utils.Classes.Utility.SpinLock();

	private IntPtr VSnUgBnLgUDlCdjrjFYEWBjvJebib;

	private IntPtr uncJzuMMIAdkBEMufRKuwJdhUTHc;

	private pxNhQBkncvqGdEaGzpwSPfMxrHwC hmnxeqoSRmsgZwKqUdNRjnfUdhTt;

	private bool CEEARdckhNStNtLIyTPFVcMNVUWn;

	IntPtr rtcpRxBVLKAMkXCloKUnYbCBcUfE.CWePsONqFYJrIiPJfggylSnHDami => VSnUgBnLgUDlCdjrjFYEWBjvJebib;

	IntPtr rtcpRxBVLKAMkXCloKUnYbCBcUfE.LzABwYAeTdmbDrnCpwjpLiLLuvnu => uncJzuMMIAdkBEMufRKuwJdhUTHc;

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.UkkuthXqoVAttWjeUWfqLeOVjZEn
	{
		get
		{
			using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
			{
				using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
				{
					return hmnxeqoSRmsgZwKqUdNRjnfUdhTt != pxNhQBkncvqGdEaGzpwSPfMxrHwC.Closed;
				}
			}
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.vXLAcOehhZiOFpPmXOFjRdasGtvm => IEUIaTGMEWhWxjxHtLvNddZfncnz.kUlAfBmanCmtpidkKuZyIVparKhx(GNugpKPaiWxcqTECHGQBrKzpfUN);

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.bpyApTlqVpUmEQrXcDGLKlIuqSPIA => LSdzoGobwarCqybgWnAZCyIWPhuT;

	ycGgUdwHgcQyyOgrTFgwoMuaXMWV rtcpRxBVLKAMkXCloKUnYbCBcUfE.JuBzyupRnChnVoqFgGehMxJGZJqC => dZSJUugxTYGnoZHHrwAdxaLxJAyS;

	PooJpACaWffyuznpWZHvpYIMTVPm[] rtcpRxBVLKAMkXCloKUnYbCBcUfE.itrSWOTBIYprxLfmyqqFfbIUkld => rPPDJqflfDOKXcozcUyLdiHKjqsdc;

	aTedyfCyjkFlTNoTgtYcHldvQSsDA[] rtcpRxBVLKAMkXCloKUnYbCBcUfE.PBVcluCoclsKeVmKwfoJcyxZSAjiA => JmvXxXOotyDPzUtTlLlnkJlqeZgU;

	IegeVwdBtiZGJTqtldaDMkExGYrW rtcpRxBVLKAMkXCloKUnYbCBcUfE.xaViLQBiNdhAdIPbDaUpnSEAtzhhb => kbWlMbNxETbEbshdoonRODHBAbrG;

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.GxobafabAbpYxyCInTMkSLSRAzZbA => GNugpKPaiWxcqTECHGQBrKzpfUN;

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.MhoSpcrPRISuWhjKNmXmMouqihyh => ElpQClKADnrfqjeZsaLPHkwWpxIw;

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.kxwmpqIuDwCMlsafPZagruVINgbi => lkqdAgcivrOkPqlCRTRCUQfLXcRAA;

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.luUAiyABmhIiADBODwpktCoNQtODB => cBByAuocTALvBaQhwkDRfNsdaNneA;

	int rtcpRxBVLKAMkXCloKUnYbCBcUfE.DxJLaDuMAYGMSDLcbvCpJFIKarNU => OWVPgCBlVDCHmeHyIImYCCkLUkOT;

	int rtcpRxBVLKAMkXCloKUnYbCBcUfE.tHBcnhBMhZrpBzoHKEjVpxJXoBME => RbZNhHFmDBgYvrJyAwfeVKphqYCH;

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.PDGRktVJzyNVWHKUFtkHtKXJdthcA => cJwIUtHtufUzEelbqsFvBXQjdQOD;

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.VrYDeizNDCscbiYsEwezldnkeZZb => gIRloKdGiJmKOeSpcJmnpEASJXCA;

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.nDFVAvLaBSqDTePgfpyBIuIFHVoq
	{
		get
		{
			if (RbZNhHFmDBgYvrJyAwfeVKphqYCH >= 0)
			{
				return OWVPgCBlVDCHmeHyIImYCCkLUkOT >= 0;
			}
			return false;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.rMXZTwCyHepkogdzKZWkRVdcmoSp
	{
		get
		{
			return kwxilOyCVPbzsbglLomfyGeFIWsr;
		}
		set
		{
			if (flag & !kwxilOyCVPbzsbglLomfyGeFIWsr)
			{
				CkUrHChNHkEgocvdSShKEWdrBBWu.lufUJnlzxaoXxlmYccMLivMlxSxg();
			}
			kwxilOyCVPbzsbglLomfyGeFIWsr = flag;
		}
	}

	event qhrOhuDGsGAdaRXsmoTpALtdEjTi rtcpRxBVLKAMkXCloKUnYbCBcUfE.LZzHKxoUDbYRBMzQWEGsLEUxOTGi
	{
		[CompilerGenerated]
		add
		{
			qhrOhuDGsGAdaRXsmoTpALtdEjTi qhrOhuDGsGAdaRXsmoTpALtdEjTi2 = GCTVgMNheiroJUGNyustHKssbGOi;
			qhrOhuDGsGAdaRXsmoTpALtdEjTi qhrOhuDGsGAdaRXsmoTpALtdEjTi3;
			do
			{
				qhrOhuDGsGAdaRXsmoTpALtdEjTi3 = qhrOhuDGsGAdaRXsmoTpALtdEjTi2;
				qhrOhuDGsGAdaRXsmoTpALtdEjTi value2 = (qhrOhuDGsGAdaRXsmoTpALtdEjTi)Delegate.Combine(qhrOhuDGsGAdaRXsmoTpALtdEjTi3, b);
				qhrOhuDGsGAdaRXsmoTpALtdEjTi2 = Interlocked.CompareExchange(ref GCTVgMNheiroJUGNyustHKssbGOi, value2, qhrOhuDGsGAdaRXsmoTpALtdEjTi3);
			}
			while ((object)qhrOhuDGsGAdaRXsmoTpALtdEjTi2 != qhrOhuDGsGAdaRXsmoTpALtdEjTi3);
		}
		[CompilerGenerated]
		remove
		{
			qhrOhuDGsGAdaRXsmoTpALtdEjTi qhrOhuDGsGAdaRXsmoTpALtdEjTi2 = GCTVgMNheiroJUGNyustHKssbGOi;
			qhrOhuDGsGAdaRXsmoTpALtdEjTi qhrOhuDGsGAdaRXsmoTpALtdEjTi3;
			do
			{
				qhrOhuDGsGAdaRXsmoTpALtdEjTi3 = qhrOhuDGsGAdaRXsmoTpALtdEjTi2;
				qhrOhuDGsGAdaRXsmoTpALtdEjTi value2 = (qhrOhuDGsGAdaRXsmoTpALtdEjTi)Delegate.Remove(qhrOhuDGsGAdaRXsmoTpALtdEjTi3, value3);
				qhrOhuDGsGAdaRXsmoTpALtdEjTi2 = Interlocked.CompareExchange(ref GCTVgMNheiroJUGNyustHKssbGOi, value2, qhrOhuDGsGAdaRXsmoTpALtdEjTi3);
			}
			while ((object)qhrOhuDGsGAdaRXsmoTpALtdEjTi2 != qhrOhuDGsGAdaRXsmoTpALtdEjTi3);
		}
	}

	event bQFtYuoBtBaJFehLDUkcQBvycaVmA rtcpRxBVLKAMkXCloKUnYbCBcUfE.PdibTfFYkxhDWXOICOAjUwGfBxAv
	{
		[CompilerGenerated]
		add
		{
			bQFtYuoBtBaJFehLDUkcQBvycaVmA bQFtYuoBtBaJFehLDUkcQBvycaVmA2 = tDVhrSrTPmCbnzfFZcbhpavHyUog;
			bQFtYuoBtBaJFehLDUkcQBvycaVmA bQFtYuoBtBaJFehLDUkcQBvycaVmA3;
			do
			{
				bQFtYuoBtBaJFehLDUkcQBvycaVmA3 = bQFtYuoBtBaJFehLDUkcQBvycaVmA2;
				bQFtYuoBtBaJFehLDUkcQBvycaVmA value2 = (bQFtYuoBtBaJFehLDUkcQBvycaVmA)Delegate.Combine(bQFtYuoBtBaJFehLDUkcQBvycaVmA3, b);
				bQFtYuoBtBaJFehLDUkcQBvycaVmA2 = Interlocked.CompareExchange(ref tDVhrSrTPmCbnzfFZcbhpavHyUog, value2, bQFtYuoBtBaJFehLDUkcQBvycaVmA3);
			}
			while ((object)bQFtYuoBtBaJFehLDUkcQBvycaVmA2 != bQFtYuoBtBaJFehLDUkcQBvycaVmA3);
		}
		[CompilerGenerated]
		remove
		{
			bQFtYuoBtBaJFehLDUkcQBvycaVmA bQFtYuoBtBaJFehLDUkcQBvycaVmA2 = tDVhrSrTPmCbnzfFZcbhpavHyUog;
			bQFtYuoBtBaJFehLDUkcQBvycaVmA bQFtYuoBtBaJFehLDUkcQBvycaVmA3;
			do
			{
				bQFtYuoBtBaJFehLDUkcQBvycaVmA3 = bQFtYuoBtBaJFehLDUkcQBvycaVmA2;
				bQFtYuoBtBaJFehLDUkcQBvycaVmA value2 = (bQFtYuoBtBaJFehLDUkcQBvycaVmA)Delegate.Remove(bQFtYuoBtBaJFehLDUkcQBvycaVmA3, value3);
				bQFtYuoBtBaJFehLDUkcQBvycaVmA2 = Interlocked.CompareExchange(ref tDVhrSrTPmCbnzfFZcbhpavHyUog, value2, bQFtYuoBtBaJFehLDUkcQBvycaVmA3);
			}
			while ((object)bQFtYuoBtBaJFehLDUkcQBvycaVmA2 != bQFtYuoBtBaJFehLDUkcQBvycaVmA3);
		}
	}

	[CustomObfuscation(rename = false)]
	private LleUpypmoUiGbAiZXeXDJpCoDzXr()
	{
		NdbnBQsCXnCLGsJlrzUnfgjUvVRe = ObjectInstanceTracker.Default.Register(this);
		uyUJDimwcHIaWJsjFUhHkWpxFUKl = new global::ptDAZOMgYivncCYMdWwaXadwMfL<loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP>();
		JIdilxRfwBAMteKavRGbCfxksWqlc = new global::ptDAZOMgYivncCYMdWwaXadwMfL<loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA>();
	}

	[CustomObfuscation(rename = false)]
	internal LleUpypmoUiGbAiZXeXDJpCoDzXr(string P_0, string P_1, string P_2, string P_3, int P_4, int P_5, bool P_6, string P_7)
		: this()
	{
		CkUrHChNHkEgocvdSShKEWdrBBWu = new snrfMqbMLqcPnIVNKmjxmPEIeKUFb(this);
		CkUrHChNHkEgocvdSShKEWdrBBWu.vqIvSRxdXQlplQoVksBRBhkQPxJp += flJyDwQLZpHZLaDLHECFyZgdOSPU;
		CkUrHChNHkEgocvdSShKEWdrBBWu.eEQxQlROmPQzdexFrgaYFxXBrJAU += wPukzPcQhBWrqXGvaghnkpXmegigb;
		GNugpKPaiWxcqTECHGQBrKzpfUN = P_0;
		ElpQClKADnrfqjeZsaLPHkwWpxIw = hhqXWftVSepEXJfDXrNHeTqfcpYy.CGNqcnGMocfMrgtKlXxfHdNgbIXi(P_0);
		lkqdAgcivrOkPqlCRTRCUQfLXcRAA = P_1;
		LSdzoGobwarCqybgWnAZCyIWPhuT = StringTools.SanitizeDeviceString(P_2);
		cBByAuocTALvBaQhwkDRfNsdaNneA = StringTools.SanitizeDeviceString(P_3);
		OWVPgCBlVDCHmeHyIImYCCkLUkOT = P_4;
		RbZNhHFmDBgYvrJyAwfeVKphqYCH = P_5;
		cJwIUtHtufUzEelbqsFvBXQjdQOD = P_6;
		gIRloKdGiJmKOeSpcJmnpEASJXCA = StringTools.SanitizeDeviceString(P_7);
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = TKgrzJjjwBddtJuambUDZAQkjUEi(GNugpKPaiWxcqTECHGQBrKzpfUN, QToFJnCkSCtcEHtoRewAeajcGUGnb, 0u, TySbdriRNrQoJcizyLdjERTgoCqsB);
			kbWlMbNxETbEbshdoonRODHBAbrG = KQzDmlEBpeMKvySIYziZgaQsyRQQ(intPtr);
			dZSJUugxTYGnoZHHrwAdxaLxJAyS = ugChakPMfPTFNnNNpWZlavYwspSn(intPtr);
			rPPDJqflfDOKXcozcUyLdiHKjqsdc = YsdHXcFvcCKWdKQNIyLyRkcRAMt(intPtr, 0, dZSJUugxTYGnoZHHrwAdxaLxJAyS.GsbkLpDqYNzrqkCZVbkwYYmGPWsn);
			JmvXxXOotyDPzUtTlLlnkJlqeZgU = PvkUizgXxWmrXbdRxkLzWIYEtfjc(intPtr, 0, dZSJUugxTYGnoZHHrwAdxaLxJAyS.rUsgwLrxCYJAJEZwPHawXnCFeauj);
			KvOEGUrKsvsvricoyEGjxbqlDMEE(intPtr);
			intPtr = IntPtr.Zero;
		}
		catch (Exception ex)
		{
			throw new Exception($"Error querying HID device \"{P_0}\" at location {intPtr}.\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					KvOEGUrKsvsvricoyEGjxbqlDMEE(intPtr);
				}
				catch
				{
				}
			}
		}
	}

	private LleUpypmoUiGbAiZXeXDJpCoDzXr(IegeVwdBtiZGJTqtldaDMkExGYrW P_0, ycGgUdwHgcQyyOgrTFgwoMuaXMWV P_1, PooJpACaWffyuznpWZHvpYIMTVPm[] P_2, aTedyfCyjkFlTNoTgtYcHldvQSsDA[] P_3)
		: this()
	{
		string text = "SIMULATED DEVICE";
		string text2 = "MANUFACTURER";
		string text3 = "SIMULATED";
		string text4 = "SIMULATED";
		GNugpKPaiWxcqTECHGQBrKzpfUN = text3;
		ElpQClKADnrfqjeZsaLPHkwWpxIw = hhqXWftVSepEXJfDXrNHeTqfcpYy.CGNqcnGMocfMrgtKlXxfHdNgbIXi(text3);
		lkqdAgcivrOkPqlCRTRCUQfLXcRAA = text4;
		LSdzoGobwarCqybgWnAZCyIWPhuT = StringTools.SanitizeDeviceString(text);
		cBByAuocTALvBaQhwkDRfNsdaNneA = StringTools.SanitizeDeviceString(text2);
		OWVPgCBlVDCHmeHyIImYCCkLUkOT = 0;
		RbZNhHFmDBgYvrJyAwfeVKphqYCH = 0;
		cJwIUtHtufUzEelbqsFvBXQjdQOD = false;
		gIRloKdGiJmKOeSpcJmnpEASJXCA = StringTools.SanitizeDeviceString(text);
		kbWlMbNxETbEbshdoonRODHBAbrG = P_0;
		dZSJUugxTYGnoZHHrwAdxaLxJAyS = P_1;
		rPPDJqflfDOKXcozcUyLdiHKjqsdc = P_2;
		JmvXxXOotyDPzUtTlLlnkJlqeZgU = P_3;
	}

	public bool eJxDxJWyojLCwXdkkPQDYUyKwqdh(bool P_0, JGDhfUZBOiCuUelScgHsgeHJJnUPA P_1, bool P_2, JGDhfUZBOiCuUelScgHsgeHJJnUPA P_3, OFjGjmJvTsMMYZEcTJJanfOutjGaA P_4)
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
			{
				if (!P_0 && !P_2)
				{
					gfEBysvewrrRmqPYaFmBKprvgHbyA();
					return false;
				}
				if (hmnxeqoSRmsgZwKqUdNRjnfUdhTt != pxNhQBkncvqGdEaGzpwSPfMxrHwC.Closed)
				{
					if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) != 0 == P_0 && (hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Write) != 0 == P_2 && QToFJnCkSCtcEHtoRewAeajcGUGnb == P_1 && dTxePQBGmwQQpVAdvaCVgzqdFRJWA == P_3 && TySbdriRNrQoJcizyLdjERTgoCqsB == P_4)
					{
						return true;
					}
					gfEBysvewrrRmqPYaFmBKprvgHbyA();
				}
				QToFJnCkSCtcEHtoRewAeajcGUGnb = P_1;
				dTxePQBGmwQQpVAdvaCVgzqdFRJWA = P_3;
				TySbdriRNrQoJcizyLdjERTgoCqsB = P_4;
				if (P_0)
				{
					try
					{
						VSnUgBnLgUDlCdjrjFYEWBjvJebib = TKgrzJjjwBddtJuambUDZAQkjUEi(GNugpKPaiWxcqTECHGQBrKzpfUN, P_1, 2147483648u, P_4);
						if (VSnUgBnLgUDlCdjrjFYEWBjvJebib.ToInt32() == -1)
						{
							VSnUgBnLgUDlCdjrjFYEWBjvJebib = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						hmnxeqoSRmsgZwKqUdNRjnfUdhTt |= pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read;
					}
					catch (Exception innerException)
					{
						hmnxeqoSRmsgZwKqUdNRjnfUdhTt &= (pxNhQBkncvqGdEaGzpwSPfMxrHwC)(-2);
						gfEBysvewrrRmqPYaFmBKprvgHbyA();
						throw new Exception("Error opening HID device for reading.", innerException);
					}
				}
				if (P_2)
				{
					try
					{
						uncJzuMMIAdkBEMufRKuwJdhUTHc = TKgrzJjjwBddtJuambUDZAQkjUEi(GNugpKPaiWxcqTECHGQBrKzpfUN, P_3, 1073741824u, P_4);
						if (uncJzuMMIAdkBEMufRKuwJdhUTHc.ToInt32() == -1)
						{
							uncJzuMMIAdkBEMufRKuwJdhUTHc = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						hmnxeqoSRmsgZwKqUdNRjnfUdhTt |= pxNhQBkncvqGdEaGzpwSPfMxrHwC.Write;
					}
					catch (Exception innerException2)
					{
						hmnxeqoSRmsgZwKqUdNRjnfUdhTt &= (pxNhQBkncvqGdEaGzpwSPfMxrHwC)(-3);
						gfEBysvewrrRmqPYaFmBKprvgHbyA();
						throw new Exception("Error opening HID device for writing.", innerException2);
					}
				}
				return true;
			}
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.BxbIsCrBLQWCoXTlqeMQhDMccqHV(bool P_0, JGDhfUZBOiCuUelScgHsgeHJJnUPA P_1, bool P_2, JGDhfUZBOiCuUelScgHsgeHJJnUPA P_3, OFjGjmJvTsMMYZEcTJJanfOutjGaA P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in eJxDxJWyojLCwXdkkPQDYUyKwqdh
		return this.eJxDxJWyojLCwXdkkPQDYUyKwqdh(P_0, P_1, P_2, P_3, P_4);
	}

	public void GvteyyLpqXPEvRQqGptvbQZTIIIE()
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
			{
				gfEBysvewrrRmqPYaFmBKprvgHbyA();
			}
		}
	}

	void rtcpRxBVLKAMkXCloKUnYbCBcUfE.ktcTMGapBidkMkDeKllHbphFKYzWA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GvteyyLpqXPEvRQqGptvbQZTIIIE
		this.GvteyyLpqXPEvRQqGptvbQZTIIIE();
	}

	private void gfEBysvewrrRmqPYaFmBKprvgHbyA()
	{
		if (hmnxeqoSRmsgZwKqUdNRjnfUdhTt != pxNhQBkncvqGdEaGzpwSPfMxrHwC.Closed)
		{
			if (VSnUgBnLgUDlCdjrjFYEWBjvJebib != IntPtr.Zero)
			{
				KvOEGUrKsvsvricoyEGjxbqlDMEE(VSnUgBnLgUDlCdjrjFYEWBjvJebib);
				VSnUgBnLgUDlCdjrjFYEWBjvJebib = IntPtr.Zero;
			}
			if (uncJzuMMIAdkBEMufRKuwJdhUTHc != IntPtr.Zero)
			{
				KvOEGUrKsvsvricoyEGjxbqlDMEE(uncJzuMMIAdkBEMufRKuwJdhUTHc);
				uncJzuMMIAdkBEMufRKuwJdhUTHc = IntPtr.Zero;
			}
			hmnxeqoSRmsgZwKqUdNRjnfUdhTt = pxNhQBkncvqGdEaGzpwSPfMxrHwC.Closed;
		}
	}

	public bAMLcXCOLNEyOpLJlObBIWMbGZTG MRpsKwxHLMEizlCDsRLnACgJKxUA()
	{
		return KukYFAHdcxHVvALPiRTOKNPKBawEA(0);
	}

	bAMLcXCOLNEyOpLJlObBIWMbGZTG rtcpRxBVLKAMkXCloKUnYbCBcUfE.MbQwnkyvcJvQEHzCdaefSfeJHwXW()
	{
		//ILSpy generated this explicit interface implementation from .override directive in MRpsKwxHLMEizlCDsRLnACgJKxUA
		return this.MRpsKwxHLMEizlCDsRLnACgJKxUA();
	}

	public bAMLcXCOLNEyOpLJlObBIWMbGZTG KukYFAHdcxHVvALPiRTOKNPKBawEA(int P_0)
	{
		bAMLcXCOLNEyOpLJlObBIWMbGZTG bAMLcXCOLNEyOpLJlObBIWMbGZTG2 = new bAMLcXCOLNEyOpLJlObBIWMbGZTG(yhDVfFWUMFkjWudgGAnxaMjaBrqDb(), bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.NoDataRead);
		rhHweIFUOhfNAbgZRpRCYoFsNXwg(bAMLcXCOLNEyOpLJlObBIWMbGZTG2, P_0);
		return bAMLcXCOLNEyOpLJlObBIWMbGZTG2;
	}

	bAMLcXCOLNEyOpLJlObBIWMbGZTG rtcpRxBVLKAMkXCloKUnYbCBcUfE.JwIjxusChyePCMGMKHkdKIlNxGNJ(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in KukYFAHdcxHVvALPiRTOKNPKBawEA
		return this.KukYFAHdcxHVvALPiRTOKNPKBawEA(P_0);
	}

	public unsafe bool rhHweIFUOhfNAbgZRpRCYoFsNXwg(bAMLcXCOLNEyOpLJlObBIWMbGZTG P_0, int P_1)
	{
		try
		{
			byte[] array = P_0.ntJrojJcBTNJdbsBqOMANJWwXeDM;
			fixed (byte* ptr = array)
			{
				bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn rQbLqevBQLMjwkfpewZvFAkWwdcn;
				return DRLcwDlUcDSlrleMTcXXByDJgMmp((IntPtr)ptr, array.Length, P_1, out rQbLqevBQLMjwkfpewZvFAkWwdcn) == oxfCMyfzMgVWgmOvnxoNVpbJlzNKA.Success;
			}
		}
		catch (Exception)
		{
			P_0.ucWCWLGRSTvkenUGJnCkndZcNtTrA(P_0.ntJrojJcBTNJdbsBqOMANJWwXeDM, bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.ReadError);
			return false;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.OLeuPrSpyFEkESoiOlzEXjgFAUPe(bAMLcXCOLNEyOpLJlObBIWMbGZTG P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in rhHweIFUOhfNAbgZRpRCYoFsNXwg
		return this.rhHweIFUOhfNAbgZRpRCYoFsNXwg(P_0, P_1);
	}

	public bool lEzCJGyidvieaIAvpfCXYSQyrHyK(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		if (P_1 <= 0)
		{
			P_0 = EmptyObjects<byte>.array;
			return false;
		}
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[P_1];
			byte[] array = sWcCbKSeinWQebWsxOZfXGHrapRk(P_1);
			array[0] = P_2;
			bool flag = false;
			try
			{
				flag = loEvjCWOkdpreenQvwRgkkDojoaD.LvoWsCuNaVbOUvuYMqPRvGkAJchn(VSnUgBnLgUDlCdjrjFYEWBjvJebib, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, P_1));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{GNugpKPaiWxcqTECHGQBrKzpfUN}'.", innerException);
			}
			return flag;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.kVypSOfdHBZMuXxTWKnAfiDiEqbI(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in lEzCJGyidvieaIAvpfCXYSQyrHyK
		return this.lEzCJGyidvieaIAvpfCXYSQyrHyK(out P_0, P_1, P_2);
	}

	public string PCFdgGSBeZFRZAgVNKohVGkZmUBGA()
	{
		try
		{
			if (!pYfGaIKqcovTNUilzqoEYJtpkvBM(out var bytes))
			{
				return string.Empty;
			}
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.TkHKclWfPhnYOjxqnRTTyacPRLEE()
	{
		//ILSpy generated this explicit interface implementation from .override directive in PCFdgGSBeZFRZAgVNKohVGkZmUBGA
		return this.PCFdgGSBeZFRZAgVNKohVGkZmUBGA();
	}

	public unsafe bool pYfGaIKqcovTNUilzqoEYJtpkvBM(out byte[] P_0)
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool result = false;
			try
			{
				fixed (byte* ptr = P_0)
				{
					void* ptr2 = ptr;
					result = loEvjCWOkdpreenQvwRgkkDojoaD.YwTdUsyVwOUvXUQzsoMoGrakHghv(VSnUgBnLgUDlCdjrjFYEWBjvJebib, (IntPtr)ptr2, P_0.Length);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{GNugpKPaiWxcqTECHGQBrKzpfUN}'.", innerException);
			}
			return result;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.fUTlqRbeOjpwbboXmoVBONawYbwm(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in pYfGaIKqcovTNUilzqoEYJtpkvBM
		return this.pYfGaIKqcovTNUilzqoEYJtpkvBM(out P_0);
	}

	public string HIskqbHTGMeiptVwoDssSbgaurgy()
	{
		QAwbUyengpjZDImPiySqBfLZjReG(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.xMcTFUYAXWDfLmbIiyTYsXSwPBPv()
	{
		//ILSpy generated this explicit interface implementation from .override directive in HIskqbHTGMeiptVwoDssSbgaurgy
		return this.HIskqbHTGMeiptVwoDssSbgaurgy();
	}

	public bool QAwbUyengpjZDImPiySqBfLZjReG(out byte[] P_0)
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = loEvjCWOkdpreenQvwRgkkDojoaD.JzmORSbHAoZFUgjOKOXyHzjETgmu(VSnUgBnLgUDlCdjrjFYEWBjvJebib, gCHandle.AddrOfPinnedObject(), P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{GNugpKPaiWxcqTECHGQBrKzpfUN}'.", innerException);
			}
			return flag;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.DlsEhjywFERLfWwJNLiJyBoWboZX(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in QAwbUyengpjZDImPiySqBfLZjReG
		return this.QAwbUyengpjZDImPiySqBfLZjReG(out P_0);
	}

	public string pzBhBrScARVthAOmFrfzGihDeesX()
	{
		mfcGoxdIVVJQyhXZdafIrpftuuzoA(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.wDgetvIfUbaQhPZiMhgLSDFeqjXC()
	{
		//ILSpy generated this explicit interface implementation from .override directive in pzBhBrScARVthAOmFrfzGihDeesX
		return this.pzBhBrScARVthAOmFrfzGihDeesX();
	}

	public bool mfcGoxdIVVJQyhXZdafIrpftuuzoA(out byte[] P_0)
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			bool flag = false;
			try
			{
				flag = gsyyiHirryRHUmKgdNvcQfKCQTpw(VSnUgBnLgUDlCdjrjFYEWBjvJebib, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{GNugpKPaiWxcqTECHGQBrKzpfUN}'.", innerException);
			}
			return flag;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.vHbETMJYRKKYXwnLYAnNAZWFFeBX(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in mfcGoxdIVVJQyhXZdafIrpftuuzoA
		return this.mfcGoxdIVVJQyhXZdafIrpftuuzoA(out P_0);
	}

	public string eUeelHGgKEKcjyzuqsagbSsFqeffb()
	{
		YrrgfvhkJOpYLbqukWsgDxUjpSZzb(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string rtcpRxBVLKAMkXCloKUnYbCBcUfE.VnBArkTFhiPuKgMnKCQkcTWzcnQBA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in eUeelHGgKEKcjyzuqsagbSsFqeffb
		return this.eUeelHGgKEKcjyzuqsagbSsFqeffb();
	}

	public bool YrrgfvhkJOpYLbqukWsgDxUjpSZzb(out byte[] P_0)
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = loEvjCWOkdpreenQvwRgkkDojoaD.dOyiyIwKKgrWlGQXVUNURdCHJKyb(VSnUgBnLgUDlCdjrjFYEWBjvJebib, gCHandle.AddrOfPinnedObject(), (uint)P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{GNugpKPaiWxcqTECHGQBrKzpfUN}'.", innerException);
			}
			return flag;
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.pgTHJXprjoLhmtfMzfPxebLgnOL(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YrrgfvhkJOpYLbqukWsgDxUjpSZzb
		return this.YrrgfvhkJOpYLbqukWsgDxUjpSZzb(out P_0);
	}

	public bool kzqAwRCQuLgRNcRGXHFqismdPjQjA(byte[] P_0)
	{
		return wYoRMYJYoxWvpdPLNSiOcbPwHjggA(P_0, 0);
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.nNVOnOPuPNSKNmgQiGknTxcXqXoA(byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in kzqAwRCQuLgRNcRGXHFqismdPjQjA
		return this.kzqAwRCQuLgRNcRGXHFqismdPjQjA(P_0);
	}

	public unsafe bool wYoRMYJYoxWvpdPLNSiOcbPwHjggA(byte[] P_0, int P_1)
	{
		fixed (byte* ptr = P_0)
		{
			return wEmjPDfuGtopXwnwqjKeArfyHuUnA((IntPtr)ptr, P_0.Length, P_1, pFKEYBfdSFpyWlUlolJLZXZaRgbo.None, false);
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.DreExdyXhQCHzbcMiWRjYpVKYjeT(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in wYoRMYJYoxWvpdPLNSiOcbPwHjggA
		return this.wYoRMYJYoxWvpdPLNSiOcbPwHjggA(P_0, P_1);
	}

	public bool MfpyJWDqPlLdmzUUIjtXskODaPaf(IntPtr P_0, int P_1, int P_2, pFKEYBfdSFpyWlUlolJLZXZaRgbo P_3)
	{
		return wEmjPDfuGtopXwnwqjKeArfyHuUnA(P_0, P_1, P_2, P_3, true);
	}

	public bool YQvBQSBHSzKsrzSmOBPRmhqpavIWA(dQrAZjxmvMRuuUvHYPSsKegoCJrCA P_0, int P_1)
	{
		return MfpyJWDqPlLdmzUUIjtXskODaPaf(P_0.hIDtEbVnfedAcwbabdUQOxCSVaMm, P_0.JaUoCJvJieUwSVusZsZEvYfRaHVI, P_1, P_0.wZWZYdhupQABWZEQqexXIjnmCGhaA);
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.gouIYISrNbxTKzMzmnQPijDteFnKA(dQrAZjxmvMRuuUvHYPSsKegoCJrCA P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YQvBQSBHSzKsrzSmOBPRmhqpavIWA
		return this.YQvBQSBHSzKsrzSmOBPRmhqpavIWA(P_0, P_1);
	}

	public MzAEeQvtcMiCvRVxsGhqGrZMXAFjA SsbuJHAXqQFljindnjxUIehfoIhQ()
	{
		return new MzAEeQvtcMiCvRVxsGhqGrZMXAFjA(((rtcpRxBVLKAMkXCloKUnYbCBcUfE)this).JuBzyupRnChnVoqFgGehMxJGZJqC.qrowqcQSpZOsfBlrYcaCvvhzivMeA);
	}

	MzAEeQvtcMiCvRVxsGhqGrZMXAFjA rtcpRxBVLKAMkXCloKUnYbCBcUfE.PGACBHpLGbubZrrQOsFJPgeseBukA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SsbuJHAXqQFljindnjxUIehfoIhQ
		return this.SsbuJHAXqQFljindnjxUIehfoIhQ();
	}

	public bool JlxGIXCsXldmrmrqCIcybJXeRYGu(byte[] P_0, int P_1)
	{
		using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Write) == 0)
			{
				return false;
			}
			if (dZSJUugxTYGnoZHHrwAdxaLxJAyS.LyhSeHpeVAauwEzMJIKhOLPUGCdpA <= 0)
			{
				return false;
			}
			byte[] array = sWcCbKSeinWQebWsxOZfXGHrapRk(P_1);
			Array.Copy(P_0, 0, array, 0, Math.Min(P_0.Length, P_1));
			try
			{
				return loEvjCWOkdpreenQvwRgkkDojoaD.UqYMWohvbKzmDpAoLUIglQoDZuJc(uncJzuMMIAdkBEMufRKuwJdhUTHc, array, P_1);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{GNugpKPaiWxcqTECHGQBrKzpfUN}'.", innerException);
			}
		}
	}

	bool rtcpRxBVLKAMkXCloKUnYbCBcUfE.CqYhhIuuXAPinCTmLGgYMaSbhuycA(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in JlxGIXCsXldmrmrqCIcybJXeRYGu
		return this.JlxGIXCsXldmrmrqCIcybJXeRYGu(P_0, P_1);
	}

	private byte[] yhDVfFWUMFkjWudgGAnxaMjaBrqDb()
	{
		return OMxDsUcHfgvyUnKZgNxPSHYTowkN(((rtcpRxBVLKAMkXCloKUnYbCBcUfE)this).JuBzyupRnChnVoqFgGehMxJGZJqC.kClCEycIRnmyMCafrgYqInzObERS - 1);
	}

	private byte[] TWmAymMNpEMIiLQSWDZRfPuUtBP()
	{
		return OMxDsUcHfgvyUnKZgNxPSHYTowkN(((rtcpRxBVLKAMkXCloKUnYbCBcUfE)this).JuBzyupRnChnVoqFgGehMxJGZJqC.qrowqcQSpZOsfBlrYcaCvvhzivMeA - 1);
	}

	private static byte[] sWcCbKSeinWQebWsxOZfXGHrapRk(int P_0)
	{
		return OMxDsUcHfgvyUnKZgNxPSHYTowkN(P_0 - 1);
	}

	private unsafe bAMLcXCOLNEyOpLJlObBIWMbGZTG oEdGCwSTdCjyAfCLdAWQlPFOndal(int P_0)
	{
		byte[] array = yhDVfFWUMFkjWudgGAnxaMjaBrqDb();
		bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn rQbLqevBQLMjwkfpewZvFAkWwdcn;
		fixed (byte* ptr = array)
		{
			DRLcwDlUcDSlrleMTcXXByDJgMmp((IntPtr)ptr, array.Length, P_0, out rQbLqevBQLMjwkfpewZvFAkWwdcn);
		}
		return new bAMLcXCOLNEyOpLJlObBIWMbGZTG(array, rQbLqevBQLMjwkfpewZvFAkWwdcn);
	}

	private oxfCMyfzMgVWgmOvnxoNVpbJlzNKA DRLcwDlUcDSlrleMTcXXByDJgMmp(IntPtr P_0, int P_1, int P_2, out bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn P_3)
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Read) == 0)
			{
				P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.NotConnected;
				return oxfCMyfzMgVWgmOvnxoNVpbJlzNKA.DeviceNotOpen;
			}
			P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.NoDataRead;
			if (P_1 < ((rtcpRxBVLKAMkXCloKUnYbCBcUfE)this).JuBzyupRnChnVoqFgGehMxJGZJqC.kClCEycIRnmyMCafrgYqInzObERS)
			{
				return oxfCMyfzMgVWgmOvnxoNVpbJlzNKA.BufferTooSmall;
			}
			if (dZSJUugxTYGnoZHHrwAdxaLxJAyS.kClCEycIRnmyMCafrgYqInzObERS > 0)
			{
				uint num = 0u;
				if (QToFJnCkSCtcEHtoRewAeajcGUGnb == JGDhfUZBOiCuUelScgHsgeHJJnUPA.Overlapped)
				{
					int num2 = ((P_2 <= 0) ? 65535 : P_2);
					loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA wrIheicChoERvHEWMZSYoUsxgPlyA = new loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA
					{
						lcjTgoObJebEnaofBFNRsMggAipdA = IntPtr.Zero,
						gYCaXOwskhUDZZQoyjzxYIHFgYAR = true,
						cycQOqxokBDODpVOZDGadyhysxRhA = loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA.ANnWSSSDmkjBncuriYPufCPxGpSz
					};
					JIdilxRfwBAMteKavRGbCfxksWqlc.NBmCWVHOCQkVZZqJiqCbATHxvSeq = wrIheicChoERvHEWMZSYoUsxgPlyA;
					IntPtr intPtr = loEvjCWOkdpreenQvwRgkkDojoaD.fzYEixiAdsYwPDdUvxxJdZxRxfjNA(GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(JIdilxRfwBAMteKavRGbCfxksWqlc.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA), 0, 1, IntPtr.Zero);
					if (intPtr == IntPtr.Zero)
					{
						return oxfCMyfzMgVWgmOvnxoNVpbJlzNKA.ReadError;
					}
					loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP dRukELLOOoaJKBmJPAieGjGfpPGP = new loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP
					{
						ijzlcCFEoSDLxALbcqhUANMDPLYic = 0,
						htHyXPoOFbdyLcPIDirYnjedLuSF = 0,
						mCtgQZgBlhHKCjnbXTrfEuFuwVPM = intPtr
					};
					uyUJDimwcHIaWJsjFUhHkWpxFUKl.NBmCWVHOCQkVZZqJiqCbATHxvSeq = dRukELLOOoaJKBmJPAieGjGfpPGP;
					try
					{
						if (loEvjCWOkdpreenQvwRgkkDojoaD.UMCozTPMRWpUOuNREwpquMleUivq(VSnUgBnLgUDlCdjrjFYEWBjvJebib, P_0, (uint)P_1, out num, GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(uyUJDimwcHIaWJsjFUhHkWpxFUKl.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA)))
						{
							P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.Success;
						}
						else if ((long)Marshal.GetLastWin32Error() == 997)
						{
							switch (loEvjCWOkdpreenQvwRgkkDojoaD.GgDcGsNkWvuevIdaktEcQfSkekdCA(uyUJDimwcHIaWJsjFUhHkWpxFUKl.NBmCWVHOCQkVZZqJiqCbATHxvSeq.mCtgQZgBlhHKCjnbXTrfEuFuwVPM, num2))
							{
							case 0u:
							case 192u:
								if (JUcffnbUUIpygcbMFvGmfZKcYwgXc.cgsbrfcLESLVyoFjpAVXqKGXeQJh(VSnUgBnLgUDlCdjrjFYEWBjvJebib, GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(uyUJDimwcHIaWJsjFUhHkWpxFUKl.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA), out num, false))
								{
									if (num != 0)
									{
										P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.Success;
									}
									else
									{
										P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.NoDataRead;
									}
								}
								else
								{
									P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.ReadError;
								}
								break;
							case 258u:
								P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.WaitTimedOut;
								break;
							case uint.MaxValue:
								P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.WaitFail;
								break;
							case 128u:
								P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.WaitAbandoned;
								break;
							default:
								P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.NoDataRead;
								break;
							}
						}
						else
						{
							P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.ReadError;
						}
					}
					catch
					{
						P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.ReadError;
					}
					finally
					{
						loEvjCWOkdpreenQvwRgkkDojoaD.lKBKxdBAuIHMAxbEWRIyhphHdtbg(VSnUgBnLgUDlCdjrjFYEWBjvJebib);
						IntPtr mCtgQZgBlhHKCjnbXTrfEuFuwVPM = uyUJDimwcHIaWJsjFUhHkWpxFUKl.NBmCWVHOCQkVZZqJiqCbATHxvSeq.mCtgQZgBlhHKCjnbXTrfEuFuwVPM;
						if (mCtgQZgBlhHKCjnbXTrfEuFuwVPM != IntPtr.Zero)
						{
							jxSlZhCWSvGsjHMlHhWjVkCUnCYy(mCtgQZgBlhHKCjnbXTrfEuFuwVPM);
						}
					}
				}
				else
				{
					try
					{
						if (loEvjCWOkdpreenQvwRgkkDojoaD.UMCozTPMRWpUOuNREwpquMleUivq(VSnUgBnLgUDlCdjrjFYEWBjvJebib, P_0, (uint)P_1, out num, IntPtr.Zero))
						{
							P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.Success;
						}
						else
						{
							P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.Success;
							P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.ReadError;
						}
					}
					catch
					{
						P_3 = bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.ReadError;
					}
				}
			}
			return (P_3 != bAMLcXCOLNEyOpLJlObBIWMbGZTG.rQbLqevBQLMjwkfpewZvFAkWwdcn.Success) ? oxfCMyfzMgVWgmOvnxoNVpbJlzNKA.ReadError : oxfCMyfzMgVWgmOvnxoNVpbJlzNKA.Success;
		}
	}

	private bool wEmjPDfuGtopXwnwqjKeArfyHuUnA(IntPtr P_0, int P_1, int P_2, pFKEYBfdSFpyWlUlolJLZXZaRgbo P_3, bool P_4)
	{
		using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
		{
			if ((hmnxeqoSRmsgZwKqUdNRjnfUdhTt & pxNhQBkncvqGdEaGzpwSPfMxrHwC.Write) == 0)
			{
				return false;
			}
			if (P_0 == IntPtr.Zero || P_1 <= 0)
			{
				return false;
			}
			if (!P_4)
			{
				if (dZSJUugxTYGnoZHHrwAdxaLxJAyS.qrowqcQSpZOsfBlrYcaCvvhzivMeA <= 0)
				{
					return false;
				}
				P_1 = Math.Min(P_1, dZSJUugxTYGnoZHHrwAdxaLxJAyS.qrowqcQSpZOsfBlrYcaCvvhzivMeA);
			}
			uint num = 0u;
			if (dTxePQBGmwQQpVAdvaCVgzqdFRJWA == JGDhfUZBOiCuUelScgHsgeHJJnUPA.Overlapped)
			{
				try
				{
					if ((P_3 & pFKEYBfdSFpyWlUlolJLZXZaRgbo.WriteDirect) != pFKEYBfdSFpyWlUlolJLZXZaRgbo.None)
					{
						return loEvjCWOkdpreenQvwRgkkDojoaD.CtjpthwYhDbscVmRMVOGUGPODraIA(uncJzuMMIAdkBEMufRKuwJdhUTHc, P_0, P_1);
					}
				}
				catch (Exception)
				{
					return false;
				}
				int num2 = ((P_2 <= 0) ? 65535 : P_2);
				loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA wrIheicChoERvHEWMZSYoUsxgPlyA = new loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA
				{
					lcjTgoObJebEnaofBFNRsMggAipdA = IntPtr.Zero,
					gYCaXOwskhUDZZQoyjzxYIHFgYAR = true,
					cycQOqxokBDODpVOZDGadyhysxRhA = loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA.ANnWSSSDmkjBncuriYPufCPxGpSz
				};
				JIdilxRfwBAMteKavRGbCfxksWqlc.NBmCWVHOCQkVZZqJiqCbATHxvSeq = wrIheicChoERvHEWMZSYoUsxgPlyA;
				IntPtr intPtr = loEvjCWOkdpreenQvwRgkkDojoaD.fzYEixiAdsYwPDdUvxxJdZxRxfjNA(GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(JIdilxRfwBAMteKavRGbCfxksWqlc.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA), 0, 1, IntPtr.Zero);
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP dRukELLOOoaJKBmJPAieGjGfpPGP = new loEvjCWOkdpreenQvwRgkkDojoaD.dRukELLOOoaJKBmJPAieGjGfpPGP
				{
					ijzlcCFEoSDLxALbcqhUANMDPLYic = 0,
					htHyXPoOFbdyLcPIDirYnjedLuSF = 0,
					mCtgQZgBlhHKCjnbXTrfEuFuwVPM = intPtr
				};
				uyUJDimwcHIaWJsjFUhHkWpxFUKl.NBmCWVHOCQkVZZqJiqCbATHxvSeq = dRukELLOOoaJKBmJPAieGjGfpPGP;
				try
				{
					if (loEvjCWOkdpreenQvwRgkkDojoaD.lpTfrGifWnrQBAxbAiJKmYiacNjfb(uncJzuMMIAdkBEMufRKuwJdhUTHc, P_0, (uint)P_1, IntPtr.Zero, GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(uyUJDimwcHIaWJsjFUhHkWpxFUKl.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA)))
					{
						return true;
					}
					if ((long)Marshal.GetLastWin32Error() == 997)
					{
						switch (loEvjCWOkdpreenQvwRgkkDojoaD.GgDcGsNkWvuevIdaktEcQfSkekdCA(uyUJDimwcHIaWJsjFUhHkWpxFUKl.NBmCWVHOCQkVZZqJiqCbATHxvSeq.mCtgQZgBlhHKCjnbXTrfEuFuwVPM, num2))
						{
						case 0u:
						case 192u:
							if (JUcffnbUUIpygcbMFvGmfZKcYwgXc.cgsbrfcLESLVyoFjpAVXqKGXeQJh(uncJzuMMIAdkBEMufRKuwJdhUTHc, GhZlVkTHikiQVkHTKPgKHUKBJNyUb.sMzpVHLhNJhxYbjCJKIburwcqApD(uyUJDimwcHIaWJsjFUhHkWpxFUKl.vUAXvPDLVxGlQdUqLBWTVRmoHuFGA), out num, false))
							{
								return true;
							}
							return false;
						case 258u:
							return false;
						case uint.MaxValue:
							return false;
						case 128u:
							return false;
						default:
							return false;
						}
					}
					return false;
				}
				catch
				{
					return false;
				}
				finally
				{
					loEvjCWOkdpreenQvwRgkkDojoaD.lKBKxdBAuIHMAxbEWRIyhphHdtbg(uncJzuMMIAdkBEMufRKuwJdhUTHc);
					IntPtr mCtgQZgBlhHKCjnbXTrfEuFuwVPM = uyUJDimwcHIaWJsjFUhHkWpxFUKl.NBmCWVHOCQkVZZqJiqCbATHxvSeq.mCtgQZgBlhHKCjnbXTrfEuFuwVPM;
					if (mCtgQZgBlhHKCjnbXTrfEuFuwVPM != IntPtr.Zero)
					{
						jxSlZhCWSvGsjHMlHhWjVkCUnCYy(mCtgQZgBlhHKCjnbXTrfEuFuwVPM);
					}
				}
			}
			try
			{
				if ((P_3 & pFKEYBfdSFpyWlUlolJLZXZaRgbo.WriteDirect) != pFKEYBfdSFpyWlUlolJLZXZaRgbo.None)
				{
					return loEvjCWOkdpreenQvwRgkkDojoaD.CtjpthwYhDbscVmRMVOGUGPODraIA(uncJzuMMIAdkBEMufRKuwJdhUTHc, P_0, P_1);
				}
				return loEvjCWOkdpreenQvwRgkkDojoaD.GuLyDfQVEygnKkUVrdUzfLHzxANj(uncJzuMMIAdkBEMufRKuwJdhUTHc, P_0, (uint)P_1, out num, IntPtr.Zero);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private void flJyDwQLZpHZLaDLHECFyZgdOSPU()
	{
	}

	private void wPukzPcQhBWrqXGvaghnkpXmegigb()
	{
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
			{
				gfEBysvewrrRmqPYaFmBKprvgHbyA();
				if (tDVhrSrTPmCbnzfFZcbhpavHyUog != null)
				{
					tDVhrSrTPmCbnzfFZcbhpavHyUog();
				}
			}
		}
	}

	public void Dispose()
	{
		cfOgfGWhvvFxUUfIkglhEdEDFxDsA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void RaZUvqGQGKlLAcdGpJpnXOqHedkn()
	{
		try
		{
			cfOgfGWhvvFxUUfIkglhEdEDFxDsA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void cfOgfGWhvvFxUUfIkglhEdEDFxDsA(bool P_0)
	{
		if (CEEARdckhNStNtLIyTPFVcMNVUWn)
		{
			return;
		}
		using (CHdruwtlevugyTxyEPoOmIqwqDKP.Lock())
		{
			using (vDAZgjdhqzRdnIDMkGWQUaYusIpr.Lock())
			{
				if (((rtcpRxBVLKAMkXCloKUnYbCBcUfE)this).rMXZTwCyHepkogdzKZWkRVdcmoSp)
				{
					((rtcpRxBVLKAMkXCloKUnYbCBcUfE)this).rMXZTwCyHepkogdzKZWkRVdcmoSp = false;
				}
				if (hmnxeqoSRmsgZwKqUdNRjnfUdhTt != pxNhQBkncvqGdEaGzpwSPfMxrHwC.Closed)
				{
					gfEBysvewrrRmqPYaFmBKprvgHbyA();
				}
				ObjectInstanceTracker.Default.Unregister(NdbnBQsCXnCLGsJlrzUnfgjUvVRe);
				if (uyUJDimwcHIaWJsjFUhHkWpxFUKl != null)
				{
					uyUJDimwcHIaWJsjFUhHkWpxFUKl.Dispose();
				}
				if (JIdilxRfwBAMteKavRGbCfxksWqlc != null)
				{
					JIdilxRfwBAMteKavRGbCfxksWqlc.Dispose();
				}
			}
		}
		CEEARdckhNStNtLIyTPFVcMNVUWn = true;
	}

	public static bool gsyyiHirryRHUmKgdNvcQfKCQTpw(IntPtr P_0, out byte[] P_1)
	{
		P_1 = new byte[255];
		_ = string.Empty;
		bool flag = false;
		GCHandle gCHandle = GCHandle.Alloc(P_1, GCHandleType.Pinned);
		try
		{
			flag = loEvjCWOkdpreenQvwRgkkDojoaD.NSJNIrpHCSTpuLmqnHynJmCiNnVb(P_0, gCHandle.AddrOfPinnedObject(), P_1.Length);
			GC.KeepAlive(gCHandle);
			if (flag)
			{
				StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(P_1));
			}
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
		finally
		{
			gCHandle.Free();
		}
		return flag;
	}

	public static string JnqGjISvzEkFAaDCBVzdKORSrcKV(IntPtr P_0)
	{
		gsyyiHirryRHUmKgdNvcQfKCQTpw(P_0, out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public static bool JDwNBXoRJxMzRvpJhEubELazMQqw(IntPtr P_0, IntPtr P_1, int P_2)
	{
		if (P_2 < 255)
		{
			throw new Exception("Buffer length must be at least " + 255 + " bytes!");
		}
		try
		{
			return loEvjCWOkdpreenQvwRgkkDojoaD.NSJNIrpHCSTpuLmqnHynJmCiNnVb(P_0, P_1, P_2);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
	}

	public static IntPtr TKgrzJjjwBddtJuambUDZAQkjUEi(string P_0, JGDhfUZBOiCuUelScgHsgeHJJnUPA P_1, uint P_2, OFjGjmJvTsMMYZEcTJJanfOutjGaA P_3)
	{
		loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA wrIheicChoERvHEWMZSYoUsxgPlyA = default(loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA);
		int num = 0;
		if (P_1 == JGDhfUZBOiCuUelScgHsgeHJJnUPA.Overlapped)
		{
			num = 1073741824;
		}
		wrIheicChoERvHEWMZSYoUsxgPlyA.lcjTgoObJebEnaofBFNRsMggAipdA = IntPtr.Zero;
		wrIheicChoERvHEWMZSYoUsxgPlyA.gYCaXOwskhUDZZQoyjzxYIHFgYAR = true;
		wrIheicChoERvHEWMZSYoUsxgPlyA.cycQOqxokBDODpVOZDGadyhysxRhA = loEvjCWOkdpreenQvwRgkkDojoaD.WrIheicChoERvHEWMZSYoUsxgPlyA.ANnWSSSDmkjBncuriYPufCPxGpSz;
		return loEvjCWOkdpreenQvwRgkkDojoaD.PcEYVVPQARwtIBulnVeWGhUpxbKe(P_0, P_2, (int)P_3, ref wrIheicChoERvHEWMZSYoUsxgPlyA, 3, num, 0);
	}

	public static void KvOEGUrKsvsvricoyEGjxbqlDMEE(IntPtr P_0)
	{
		CycZUyCCaUFUjiKyCfgWAWfNvDiwA(P_0);
		loEvjCWOkdpreenQvwRgkkDojoaD.mBasMrAChNGDodAmtQZFPxNFdxaQA(P_0);
	}

	public static void CycZUyCCaUFUjiKyCfgWAWfNvDiwA(IntPtr P_0)
	{
		if (Environment.OSVersion.Version.Major > 5)
		{
			loEvjCWOkdpreenQvwRgkkDojoaD.ZkyzJmANLfRQePijFgbBnLeGdKRA(P_0, IntPtr.Zero);
		}
		else
		{
			loEvjCWOkdpreenQvwRgkkDojoaD.lKBKxdBAuIHMAxbEWRIyhphHdtbg(P_0);
		}
	}

	private static void jxSlZhCWSvGsjHMlHhWjVkCUnCYy(IntPtr P_0)
	{
		loEvjCWOkdpreenQvwRgkkDojoaD.lKBKxdBAuIHMAxbEWRIyhphHdtbg(P_0);
		loEvjCWOkdpreenQvwRgkkDojoaD.mBasMrAChNGDodAmtQZFPxNFdxaQA(P_0);
	}

	internal static LleUpypmoUiGbAiZXeXDJpCoDzXr NdYgkhTuLwdHcfGOHEVoTKblISLAA(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		PooJpACaWffyuznpWZHvpYIMTVPm[] array = new PooJpACaWffyuznpWZHvpYIMTVPm[P_3];
		for (int i = 0; i < P_3; i++)
		{
			loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC.JMrnMjpTATFUzMJwzDYRczImSskg pudHCylPnTzzGdwnyUfvnNFsIhmF = new loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC.JMrnMjpTATFUzMJwzDYRczImSskg
			{
				MDeAknGxEqTxoRkjxwfpoFKiTKHX = new ushort[8]
			};
			pudHCylPnTzzGdwnyUfvnNFsIhmF.MDeAknGxEqTxoRkjxwfpoFKiTKHX[0] = (ushort)i;
			array[i] = new PooJpACaWffyuznpWZHvpYIMTVPm(new loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC
			{
				NSwPfwPOCUuKHDiREnxdTzEIJkzL = 9,
				pudHCylPnTzzGdwnyUfvnNFsIhmF = pudHCylPnTzzGdwnyUfvnNFsIhmF
			});
		}
		int num = P_2 + P_4;
		aTedyfCyjkFlTNoTgtYcHldvQSsDA[] array2 = new aTedyfCyjkFlTNoTgtYcHldvQSsDA[num];
		for (int j = 0; j < num; j++)
		{
			loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo.QRVticqEWvBOSCTActuAROXEQrfw dMQBjGNUOcRyuFeQhmIukOPOdTwDA = new loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo.QRVticqEWvBOSCTActuAROXEQrfw
			{
				yjikeSHVSykHgRbyyWdqXkamikim = new ushort[8]
			};
			if (j < P_2)
			{
				dMQBjGNUOcRyuFeQhmIukOPOdTwDA.yjikeSHVSykHgRbyyWdqXkamikim[0] = 48;
			}
			else
			{
				dMQBjGNUOcRyuFeQhmIukOPOdTwDA.yjikeSHVSykHgRbyyWdqXkamikim[0] = 57;
			}
			array2[j] = new aTedyfCyjkFlTNoTgtYcHldvQSsDA(new loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo
			{
				eIEFhmEcCbInJOxRBVrVcpGDeoDc = 1,
				DMQBjGNUOcRyuFeQhmIukOPOdTwDA = dMQBjGNUOcRyuFeQhmIukOPOdTwDA
			});
		}
		return new LleUpypmoUiGbAiZXeXDJpCoDzXr(new IegeVwdBtiZGJTqtldaDMkExGYrW(new loEvjCWOkdpreenQvwRgkkDojoaD.ptEtycJdJjnFFFJUByoqWnBVqwhO
		{
			bsRijLyXYqUsLMMENQunPZusbGxD = (ushort)P_1,
			UaIDhunEIUxTJIQyoZtmeZEGVoll = (ushort)P_0
		}), new ycGgUdwHgcQyyOgrTFgwoMuaXMWV(new loEvjCWOkdpreenQvwRgkkDojoaD.HZfNqWuySzsctwuKgLzPJlOyZaUl
		{
			ZMjovxwyHnmbLDxYOBrrFaWNIuPB = (short)P_3,
			SuOmzLVJqklReKoLiCtsvKOiXoae = (short)P_2
		}), array, array2);
	}

	private static byte[] OMxDsUcHfgvyUnKZgNxPSHYTowkN(int P_0)
	{
		byte[] array = null;
		Array.Resize(ref array, P_0 + 1);
		return array;
	}

	public static IegeVwdBtiZGJTqtldaDMkExGYrW KQzDmlEBpeMKvySIYziZgaQsyRQQ(IntPtr P_0)
	{
		loEvjCWOkdpreenQvwRgkkDojoaD.ptEtycJdJjnFFFJUByoqWnBVqwhO ptEtycJdJjnFFFJUByoqWnBVqwhO = default(loEvjCWOkdpreenQvwRgkkDojoaD.ptEtycJdJjnFFFJUByoqWnBVqwhO);
		ptEtycJdJjnFFFJUByoqWnBVqwhO.lLyWBaEvHfzojnPqQxqgBglqnZgj = Marshal.SizeOf(ptEtycJdJjnFFFJUByoqWnBVqwhO);
		loEvjCWOkdpreenQvwRgkkDojoaD.WJAGklXMxImYWUjdZzmaPfAzZoxk(P_0, ref ptEtycJdJjnFFFJUByoqWnBVqwhO);
		return new IegeVwdBtiZGJTqtldaDMkExGYrW(ptEtycJdJjnFFFJUByoqWnBVqwhO);
	}

	public static ycGgUdwHgcQyyOgrTFgwoMuaXMWV ugChakPMfPTFNnNNpWZlavYwspSn(IntPtr P_0)
	{
		loEvjCWOkdpreenQvwRgkkDojoaD.HZfNqWuySzsctwuKgLzPJlOyZaUl hZfNqWuySzsctwuKgLzPJlOyZaUl = default(loEvjCWOkdpreenQvwRgkkDojoaD.HZfNqWuySzsctwuKgLzPJlOyZaUl);
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (loEvjCWOkdpreenQvwRgkkDojoaD.ZTzWBnWcSMEJfxKPAAHqrGRJgtCFA(P_0, ref zero))
			{
				loEvjCWOkdpreenQvwRgkkDojoaD.ugFCBbXYGZCbyUcxxEbMucRScCvc(zero, ref hZfNqWuySzsctwuKgLzPJlOyZaUl);
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					loEvjCWOkdpreenQvwRgkkDojoaD.ApGnTWWkBZVinxniFQFecispflzd(zero);
				}
			}
			catch
			{
			}
		}
		return new ycGgUdwHgcQyyOgrTFgwoMuaXMWV(hZfNqWuySzsctwuKgLzPJlOyZaUl);
	}

	public static PooJpACaWffyuznpWZHvpYIMTVPm[] YsdHXcFvcCKWdKQNIyLyRkcRAMt(IntPtr P_0, short P_1, short P_2)
	{
		PooJpACaWffyuznpWZHvpYIMTVPm[] array = new PooJpACaWffyuznpWZHvpYIMTVPm[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (loEvjCWOkdpreenQvwRgkkDojoaD.ZTzWBnWcSMEJfxKPAAHqrGRJgtCFA(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					loEvjCWOkdpreenQvwRgkkDojoaD.YyqfjbAAPmaaKyoRAhDxABiqwxmJA(intPtr, num2);
					loEvjCWOkdpreenQvwRgkkDojoaD.ZduXJSyblqkzShRAAFVZRHxcKyvO(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC[] array2 = new loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC)Marshal.PtrToStructure(intPtr2, typeof(loEvjCWOkdpreenQvwRgkkDojoaD.kGrazTvCtfFxSaYeofcMuMBqgKBC));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new PooJpACaWffyuznpWZHvpYIMTVPm(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					loEvjCWOkdpreenQvwRgkkDojoaD.ApGnTWWkBZVinxniFQFecispflzd(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}

	public static aTedyfCyjkFlTNoTgtYcHldvQSsDA[] PvkUizgXxWmrXbdRxkLzWIYEtfjc(IntPtr P_0, short P_1, short P_2)
	{
		aTedyfCyjkFlTNoTgtYcHldvQSsDA[] array = new aTedyfCyjkFlTNoTgtYcHldvQSsDA[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (loEvjCWOkdpreenQvwRgkkDojoaD.ZTzWBnWcSMEJfxKPAAHqrGRJgtCFA(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					loEvjCWOkdpreenQvwRgkkDojoaD.YyqfjbAAPmaaKyoRAhDxABiqwxmJA(intPtr, num2);
					loEvjCWOkdpreenQvwRgkkDojoaD.FltViqXMIEmhYpfFSNGZHxATquRT(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo[] array2 = new loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo)Marshal.PtrToStructure(intPtr2, typeof(loEvjCWOkdpreenQvwRgkkDojoaD.BTIhbYHhYeYBoLpEMYInQCHLgTbo));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new aTedyfCyjkFlTNoTgtYcHldvQSsDA(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					loEvjCWOkdpreenQvwRgkkDojoaD.ApGnTWWkBZVinxniFQFecispflzd(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}
}
