using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal sealed class VEavlBCjlwYFgIYiKEZpvYEuUTOH : IDisposable, fmknYWuxIkOhtFkdpAUHgftPbHiiA
{
	private delegate zSYPqstKQppxFjZuepAvqmOjezCw OuUzxgKnjGvfYeFvYGjukByaKzwqA(int timeout);

	private delegate CFAcDfGMvgAnoRvOnWlGRTRORlWs qgOdohJHTbmlZoxqYbRYlVSzpBhPA(int timeout);

	private delegate bool oWOXumcjnzOjflpDmujinZkYOCBj(byte[] data, int timeout);

	private delegate bool RWcEaUOIXOKnIYmMbAiIAsfmKPGlA(byte[] data, int timeout, bool setOutputReportDirectly);

	private delegate bool SiHmxCPBawbfRvaaxiOorqEnYqUf(CFAcDfGMvgAnoRvOnWlGRTRORlWs report, int timeout);

	private enum bSXgQxRRaNVHwGgNaffohlvjREvUA
	{
		Closed = 0,
		Read = 1,
		Write = 2
	}

	private enum cctCtNMrJOWrhWROwnuhVClJCKEdA
	{
		Success = 0,
		ReadError = 1,
		BufferTooSmall = 2,
		DeviceNotOpen = 3
	}

	private struct xmLIQfrYXecaVHPeCTRkZvwFBVYK
	{
		public bool npDJeSKUwhTignbitSDZbBOBiPQt;

		public int ePylHodBtjXnQzPQEtQrKDhYCZxJ;

		public int uSUMAGYBszzgFcXwDbOJNaQBhAPT;
	}

	public const int cmebrrVPFWeBJiPkPsMQMKbpOAGGA = 255;

	[CompilerGenerated]
	private sYrOfToRfcbXzRdHpIoBiphrNbGP PpfsuOggLgPIgEiMmdQcQOeWfYxu;

	[CompilerGenerated]
	private fBJjfBPTobuZGfsiMqlGfKfcTqYI pkiMvJxnrhGnTRAlueBeYHUolwMR;

	private readonly string WdiAysdrtGMTJeSvOqqAkUzheosDb;

	private readonly string SSTCClPgTrDnBShUmazYUjvOcCfu;

	private readonly string SYlzLoRhyXKBlMaCMsxwUIDlJORO;

	private readonly string uUxrSJplaDEpWOwxloLgtQIVkefV;

	private readonly UoDwJHKuSqzSqLScKefxqMdnpcOA dkFygXrfdOlAuIujItYaOqtQElcy;

	private readonly string yKuuyRuuVERtdiPwYAfVUcKBgwPN;

	private readonly int MncGqQwQmyifaKRLiAlAkqtLHbUgA;

	private readonly int LyZesTNIbSKewQANTwKtaMJaAIBjA;

	private readonly bool AvoLJjHRjZMIiEoPLKJqEwptCyTu;

	private readonly string yWFhBVcmobmmyagHORiGehbgtwNR;

	private readonly uint feyfUxusytQNkXYleniaLrtnurww;

	private readonly kJWvYMLjQGVjMEOIYaiIMiQepABE rrfBhOZmlDrtYBmDiENzlKuJmeKh;

	private readonly FUkKatfPiTDRfnAuBLcDLCqAqdOG[] pMPRKDgcLwXbkqkTppUvEnHKSvXw;

	private readonly cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] vZZaQlcnhlVmHJuuLYlsDUqdcUyIA;

	private FBJyKviZPIDJRgxnjkLCYoNJwALW yshSjvpjJIsBRDEoVVLTjCrTbubX;

	private FBJyKviZPIDJRgxnjkLCYoNJwALW hRTcoUzNYoUYOihXXVILkQtwLgQh;

	private GTnUvTIDUEdlNImTKwVWFNCeIERq QoTJppLWUmpiOYdtVehJqWmjgDu = GTnUvTIDUEdlNImTKwVWFNCeIERq.ShareRead | GTnUvTIDUEdlNImTKwVWFNCeIERq.ShareWrite;

	private readonly wpfZLKQvIwScLcCFfCVzQtOdILG WFWhGYInvDxSyGTOeQSoIyOaxcsEA;

	private bool aICSChvaWJXGieAdIORmyVlEkBWw;

	private nSpfnmzmpqiBgkjhLLrIIdyzJDyx<xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB> WjwdFkLXPnaighNGwswisNBPYbyv;

	private nSpfnmzmpqiBgkjhLLrIIdyzJDyx<xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi> RGwmCduHbjKbJmqQxEAPkQjOtPaQ;

	private readonly Rewired.Utils.Classes.Utility.SpinLock lKvzyVTqmDQrKQExdfepjXXxBDItA = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock YupcQmhUHYJYANqDLkQNCNdWOPXvA = new Rewired.Utils.Classes.Utility.SpinLock();

	private IntPtr WAGlHFDoWwGMCDVjbDxoNYRnNkcL;

	private IntPtr NtEcJlNLnGpycVeQZeIYlMedGHHs;

	private bSXgQxRRaNVHwGgNaffohlvjREvUA wuanUeAGKIgdXJmXuFfrcwEoXHwJA;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	IntPtr fmknYWuxIkOhtFkdpAUHgftPbHiiA.nEsfysuWNaHxWWYdgAKIhfFNxAtO => WAGlHFDoWwGMCDVjbDxoNYRnNkcL;

	IntPtr fmknYWuxIkOhtFkdpAUHgftPbHiiA.XZIZpTyNwMFUIGcgAIJyMrTpsCZEA => NtEcJlNLnGpycVeQZeIYlMedGHHs;

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.KfWuRAuYCCgrHkqiEAvyznJvuqBD
	{
		get
		{
			using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
			{
				using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
				{
					return wuanUeAGKIgdXJmXuFfrcwEoXHwJA != bSXgQxRRaNVHwGgNaffohlvjREvUA.Closed;
				}
			}
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.JaUeIycumyWlPCjeNyhEexyqywGbA => ASYbPqxUNkljqzCsqWpbFAZdrPyP.JaUeIycumyWlPCjeNyhEexyqywGbA(SSTCClPgTrDnBShUmazYUjvOcCfu);

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.GMXrSaGXWkROSlDVpTdDBKZhOQbl => WdiAysdrtGMTJeSvOqqAkUzheosDb;

	kJWvYMLjQGVjMEOIYaiIMiQepABE fmknYWuxIkOhtFkdpAUHgftPbHiiA.gSKbQhPhCcxFkHCLeYWmJrvPjhbK => rrfBhOZmlDrtYBmDiENzlKuJmeKh;

	FUkKatfPiTDRfnAuBLcDLCqAqdOG[] fmknYWuxIkOhtFkdpAUHgftPbHiiA.OUhrMRVahpoDecVgSeEQMdltwHfd => pMPRKDgcLwXbkqkTppUvEnHKSvXw;

	cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] fmknYWuxIkOhtFkdpAUHgftPbHiiA.iarrdhzPMulfUajipLKOuwWTgyXE => vZZaQlcnhlVmHJuuLYlsDUqdcUyIA;

	UoDwJHKuSqzSqLScKefxqMdnpcOA fmknYWuxIkOhtFkdpAUHgftPbHiiA.cdntKXsQVsQYjNKdPBLuERqkYywG => dkFygXrfdOlAuIujItYaOqtQElcy;

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.bHXXIaSXftOsLmRzVkIpzmMPLvPk => SSTCClPgTrDnBShUmazYUjvOcCfu;

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.wloxucIZdTWcDUJXKVIBtfcnWFMX => SYlzLoRhyXKBlMaCMsxwUIDlJORO;

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.tzTLVddBHUhDFdrOIXHOsfpfIFVf => uUxrSJplaDEpWOwxloLgtQIVkefV;

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.hjKJnzLrHHJuMHKXDBoYDoKhMPDgb => yKuuyRuuVERtdiPwYAfVUcKBgwPN;

	int fmknYWuxIkOhtFkdpAUHgftPbHiiA.JXMjYfICPQNpsgKiWhPQLZvNFnkU => MncGqQwQmyifaKRLiAlAkqtLHbUgA;

	int fmknYWuxIkOhtFkdpAUHgftPbHiiA.vhLexAlwrxPMJUqylKKRBGvDXZUr => LyZesTNIbSKewQANTwKtaMJaAIBjA;

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.MpuQBNhsGfnlifDQFONVPCMzxEIi => AvoLJjHRjZMIiEoPLKJqEwptCyTu;

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.iAlThlvTdFBnLFoKOqPsWaWpHQQV => yWFhBVcmobmmyagHORiGehbgtwNR;

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.svyPtRQuOOdMhDWTVAqAzUrBPSDV
	{
		get
		{
			if (LyZesTNIbSKewQANTwKtaMJaAIBjA >= 0)
			{
				return MncGqQwQmyifaKRLiAlAkqtLHbUgA >= 0;
			}
			return false;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.OsNaPfSOZUqHgMjAlNIbKLrYAFfEA
	{
		get
		{
			return aICSChvaWJXGieAdIORmyVlEkBWw;
		}
		set
		{
			if (flag & !aICSChvaWJXGieAdIORmyVlEkBWw)
			{
				WFWhGYInvDxSyGTOeQSoIyOaxcsEA.WCFFzsHtLWMKfhauyUvHRdaBsqRcA();
			}
			aICSChvaWJXGieAdIORmyVlEkBWw = flag;
		}
	}

	event sYrOfToRfcbXzRdHpIoBiphrNbGP fmknYWuxIkOhtFkdpAUHgftPbHiiA.PpfsuOggLgPIgEiMmdQcQOeWfYxu
	{
		[CompilerGenerated]
		add
		{
			sYrOfToRfcbXzRdHpIoBiphrNbGP sYrOfToRfcbXzRdHpIoBiphrNbGP2 = this.PpfsuOggLgPIgEiMmdQcQOeWfYxu;
			sYrOfToRfcbXzRdHpIoBiphrNbGP sYrOfToRfcbXzRdHpIoBiphrNbGP3;
			do
			{
				sYrOfToRfcbXzRdHpIoBiphrNbGP3 = sYrOfToRfcbXzRdHpIoBiphrNbGP2;
				sYrOfToRfcbXzRdHpIoBiphrNbGP value2 = (sYrOfToRfcbXzRdHpIoBiphrNbGP)Delegate.Combine(sYrOfToRfcbXzRdHpIoBiphrNbGP3, b);
				sYrOfToRfcbXzRdHpIoBiphrNbGP2 = Interlocked.CompareExchange(ref this.PpfsuOggLgPIgEiMmdQcQOeWfYxu, value2, sYrOfToRfcbXzRdHpIoBiphrNbGP3);
			}
			while ((object)sYrOfToRfcbXzRdHpIoBiphrNbGP2 != sYrOfToRfcbXzRdHpIoBiphrNbGP3);
		}
		[CompilerGenerated]
		remove
		{
			sYrOfToRfcbXzRdHpIoBiphrNbGP sYrOfToRfcbXzRdHpIoBiphrNbGP2 = this.PpfsuOggLgPIgEiMmdQcQOeWfYxu;
			sYrOfToRfcbXzRdHpIoBiphrNbGP sYrOfToRfcbXzRdHpIoBiphrNbGP3;
			do
			{
				sYrOfToRfcbXzRdHpIoBiphrNbGP3 = sYrOfToRfcbXzRdHpIoBiphrNbGP2;
				sYrOfToRfcbXzRdHpIoBiphrNbGP value2 = (sYrOfToRfcbXzRdHpIoBiphrNbGP)Delegate.Remove(sYrOfToRfcbXzRdHpIoBiphrNbGP3, value3);
				sYrOfToRfcbXzRdHpIoBiphrNbGP2 = Interlocked.CompareExchange(ref this.PpfsuOggLgPIgEiMmdQcQOeWfYxu, value2, sYrOfToRfcbXzRdHpIoBiphrNbGP3);
			}
			while ((object)sYrOfToRfcbXzRdHpIoBiphrNbGP2 != sYrOfToRfcbXzRdHpIoBiphrNbGP3);
		}
	}

	event fBJjfBPTobuZGfsiMqlGfKfcTqYI fmknYWuxIkOhtFkdpAUHgftPbHiiA.pkiMvJxnrhGnTRAlueBeYHUolwMR
	{
		[CompilerGenerated]
		add
		{
			fBJjfBPTobuZGfsiMqlGfKfcTqYI fBJjfBPTobuZGfsiMqlGfKfcTqYI2 = this.pkiMvJxnrhGnTRAlueBeYHUolwMR;
			fBJjfBPTobuZGfsiMqlGfKfcTqYI fBJjfBPTobuZGfsiMqlGfKfcTqYI3;
			do
			{
				fBJjfBPTobuZGfsiMqlGfKfcTqYI3 = fBJjfBPTobuZGfsiMqlGfKfcTqYI2;
				fBJjfBPTobuZGfsiMqlGfKfcTqYI value2 = (fBJjfBPTobuZGfsiMqlGfKfcTqYI)Delegate.Combine(fBJjfBPTobuZGfsiMqlGfKfcTqYI3, b);
				fBJjfBPTobuZGfsiMqlGfKfcTqYI2 = Interlocked.CompareExchange(ref this.pkiMvJxnrhGnTRAlueBeYHUolwMR, value2, fBJjfBPTobuZGfsiMqlGfKfcTqYI3);
			}
			while ((object)fBJjfBPTobuZGfsiMqlGfKfcTqYI2 != fBJjfBPTobuZGfsiMqlGfKfcTqYI3);
		}
		[CompilerGenerated]
		remove
		{
			fBJjfBPTobuZGfsiMqlGfKfcTqYI fBJjfBPTobuZGfsiMqlGfKfcTqYI2 = this.pkiMvJxnrhGnTRAlueBeYHUolwMR;
			fBJjfBPTobuZGfsiMqlGfKfcTqYI fBJjfBPTobuZGfsiMqlGfKfcTqYI3;
			do
			{
				fBJjfBPTobuZGfsiMqlGfKfcTqYI3 = fBJjfBPTobuZGfsiMqlGfKfcTqYI2;
				fBJjfBPTobuZGfsiMqlGfKfcTqYI value2 = (fBJjfBPTobuZGfsiMqlGfKfcTqYI)Delegate.Remove(fBJjfBPTobuZGfsiMqlGfKfcTqYI3, value3);
				fBJjfBPTobuZGfsiMqlGfKfcTqYI2 = Interlocked.CompareExchange(ref this.pkiMvJxnrhGnTRAlueBeYHUolwMR, value2, fBJjfBPTobuZGfsiMqlGfKfcTqYI3);
			}
			while ((object)fBJjfBPTobuZGfsiMqlGfKfcTqYI2 != fBJjfBPTobuZGfsiMqlGfKfcTqYI3);
		}
	}

	[CustomObfuscation(rename = false)]
	private VEavlBCjlwYFgIYiKEZpvYEuUTOH()
	{
		feyfUxusytQNkXYleniaLrtnurww = ObjectInstanceTracker.Default.Register(this);
		RGwmCduHbjKbJmqQxEAPkQjOtPaQ = new nSpfnmzmpqiBgkjhLLrIIdyzJDyx<xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi>();
		WjwdFkLXPnaighNGwswisNBPYbyv = new nSpfnmzmpqiBgkjhLLrIIdyzJDyx<xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB>();
	}

	[CustomObfuscation(rename = false)]
	internal VEavlBCjlwYFgIYiKEZpvYEuUTOH(string P_0, string P_1, string P_2, string P_3, int P_4, int P_5, bool P_6, string P_7)
		: this()
	{
		WFWhGYInvDxSyGTOeQSoIyOaxcsEA = new wpfZLKQvIwScLcCFfCVzQtOdILG(this);
		WFWhGYInvDxSyGTOeQSoIyOaxcsEA.PpfsuOggLgPIgEiMmdQcQOeWfYxu += oyeMNkUDYxfTAKTMrsGVcgwJLtrf;
		WFWhGYInvDxSyGTOeQSoIyOaxcsEA.pkiMvJxnrhGnTRAlueBeYHUolwMR += uAMpoNboCLVaKhYmBwEjfwaMnWGI;
		SSTCClPgTrDnBShUmazYUjvOcCfu = P_0;
		SYlzLoRhyXKBlMaCMsxwUIDlJORO = lwshpSMnJWtuMNOqALbpKPklMmTj.KWVrgygWsvBoZLExmDoqwQDsyzMC(P_0);
		uUxrSJplaDEpWOwxloLgtQIVkefV = P_1;
		WdiAysdrtGMTJeSvOqqAkUzheosDb = StringTools.SanitizeDeviceString(P_2);
		yKuuyRuuVERtdiPwYAfVUcKBgwPN = StringTools.SanitizeDeviceString(P_3);
		MncGqQwQmyifaKRLiAlAkqtLHbUgA = P_4;
		LyZesTNIbSKewQANTwKtaMJaAIBjA = P_5;
		AvoLJjHRjZMIiEoPLKJqEwptCyTu = P_6;
		yWFhBVcmobmmyagHORiGehbgtwNR = StringTools.SanitizeDeviceString(P_7);
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = qRGErlebaNBrfzcIPJHwDGgcBztOb(SSTCClPgTrDnBShUmazYUjvOcCfu, yshSjvpjJIsBRDEoVVLTjCrTbubX, 0u, QoTJppLWUmpiOYdtVehJqWmjgDu);
			dkFygXrfdOlAuIujItYaOqtQElcy = TxlMvfgalChIEkGktxNOBYxmEiRhA(intPtr);
			rrfBhOZmlDrtYBmDiENzlKuJmeKh = TdLnsxypHVhnWfGTrmwBPgTXgJhBA(intPtr);
			pMPRKDgcLwXbkqkTppUvEnHKSvXw = lJCdHQMDfbFcFntIgsnIxtCFsGzy(intPtr, 0, rrfBhOZmlDrtYBmDiENzlKuJmeKh.SSSvXRAdhzynKDSzhRLewJHzCWICA);
			vZZaQlcnhlVmHJuuLYlsDUqdcUyIA = ASnNvtHJrhCqjufwHfimhAWbDllFA(intPtr, 0, rrfBhOZmlDrtYBmDiENzlKuJmeKh.AFMqfyKTWLZbnjGinMFKyEvfWbuC);
			nylTIQDqDLHmsQWIsXNPMMEUuYSL(intPtr);
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
					nylTIQDqDLHmsQWIsXNPMMEUuYSL(intPtr);
				}
				catch
				{
				}
			}
		}
	}

	private VEavlBCjlwYFgIYiKEZpvYEuUTOH(UoDwJHKuSqzSqLScKefxqMdnpcOA P_0, kJWvYMLjQGVjMEOIYaiIMiQepABE P_1, FUkKatfPiTDRfnAuBLcDLCqAqdOG[] P_2, cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] P_3)
		: this()
	{
		string text = "SIMULATED DEVICE";
		string text2 = "MANUFACTURER";
		string text3 = "SIMULATED";
		string text4 = "SIMULATED";
		SSTCClPgTrDnBShUmazYUjvOcCfu = text3;
		SYlzLoRhyXKBlMaCMsxwUIDlJORO = lwshpSMnJWtuMNOqALbpKPklMmTj.KWVrgygWsvBoZLExmDoqwQDsyzMC(text3);
		uUxrSJplaDEpWOwxloLgtQIVkefV = text4;
		WdiAysdrtGMTJeSvOqqAkUzheosDb = StringTools.SanitizeDeviceString(text);
		yKuuyRuuVERtdiPwYAfVUcKBgwPN = StringTools.SanitizeDeviceString(text2);
		MncGqQwQmyifaKRLiAlAkqtLHbUgA = 0;
		LyZesTNIbSKewQANTwKtaMJaAIBjA = 0;
		AvoLJjHRjZMIiEoPLKJqEwptCyTu = false;
		yWFhBVcmobmmyagHORiGehbgtwNR = StringTools.SanitizeDeviceString(text);
		dkFygXrfdOlAuIujItYaOqtQElcy = P_0;
		rrfBhOZmlDrtYBmDiENzlKuJmeKh = P_1;
		pMPRKDgcLwXbkqkTppUvEnHKSvXw = P_2;
		vZZaQlcnhlVmHJuuLYlsDUqdcUyIA = P_3;
	}

	public bool WGMjaiGhWpETbCqwJSpGoEQcpNTQ(bool P_0, FBJyKviZPIDJRgxnjkLCYoNJwALW P_1, bool P_2, FBJyKviZPIDJRgxnjkLCYoNJwALW P_3, GTnUvTIDUEdlNImTKwVWFNCeIERq P_4)
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
			{
				if (!P_0 && !P_2)
				{
					tYZREkWfNhbMhYTKHDFmietlMVEdA();
					return false;
				}
				if (wuanUeAGKIgdXJmXuFfrcwEoXHwJA != bSXgQxRRaNVHwGgNaffohlvjREvUA.Closed)
				{
					if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) != 0 == P_0 && (wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Write) != 0 == P_2 && yshSjvpjJIsBRDEoVVLTjCrTbubX == P_1 && hRTcoUzNYoUYOihXXVILkQtwLgQh == P_3 && QoTJppLWUmpiOYdtVehJqWmjgDu == P_4)
					{
						return true;
					}
					tYZREkWfNhbMhYTKHDFmietlMVEdA();
				}
				yshSjvpjJIsBRDEoVVLTjCrTbubX = P_1;
				hRTcoUzNYoUYOihXXVILkQtwLgQh = P_3;
				QoTJppLWUmpiOYdtVehJqWmjgDu = P_4;
				if (P_0)
				{
					try
					{
						WAGlHFDoWwGMCDVjbDxoNYRnNkcL = qRGErlebaNBrfzcIPJHwDGgcBztOb(SSTCClPgTrDnBShUmazYUjvOcCfu, P_1, 2147483648u, P_4);
						if (WAGlHFDoWwGMCDVjbDxoNYRnNkcL.ToInt32() == -1)
						{
							WAGlHFDoWwGMCDVjbDxoNYRnNkcL = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						wuanUeAGKIgdXJmXuFfrcwEoXHwJA |= bSXgQxRRaNVHwGgNaffohlvjREvUA.Read;
					}
					catch (Exception innerException)
					{
						wuanUeAGKIgdXJmXuFfrcwEoXHwJA &= (bSXgQxRRaNVHwGgNaffohlvjREvUA)(-2);
						tYZREkWfNhbMhYTKHDFmietlMVEdA();
						throw new Exception("Error opening HID device for reading.", innerException);
					}
				}
				if (P_2)
				{
					try
					{
						NtEcJlNLnGpycVeQZeIYlMedGHHs = qRGErlebaNBrfzcIPJHwDGgcBztOb(SSTCClPgTrDnBShUmazYUjvOcCfu, P_3, 1073741824u, P_4);
						if (NtEcJlNLnGpycVeQZeIYlMedGHHs.ToInt32() == -1)
						{
							NtEcJlNLnGpycVeQZeIYlMedGHHs = IntPtr.Zero;
							throw new Exception("Invalid File Handle");
						}
						wuanUeAGKIgdXJmXuFfrcwEoXHwJA |= bSXgQxRRaNVHwGgNaffohlvjREvUA.Write;
					}
					catch (Exception innerException2)
					{
						wuanUeAGKIgdXJmXuFfrcwEoXHwJA &= (bSXgQxRRaNVHwGgNaffohlvjREvUA)(-3);
						tYZREkWfNhbMhYTKHDFmietlMVEdA();
						throw new Exception("Error opening HID device for writing.", innerException2);
					}
				}
				return true;
			}
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.WGMjaiGhWpETbCqwJSpGoEQcpNTQ(bool P_0, FBJyKviZPIDJRgxnjkLCYoNJwALW P_1, bool P_2, FBJyKviZPIDJRgxnjkLCYoNJwALW P_3, GTnUvTIDUEdlNImTKwVWFNCeIERq P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in WGMjaiGhWpETbCqwJSpGoEQcpNTQ
		return this.WGMjaiGhWpETbCqwJSpGoEQcpNTQ(P_0, P_1, P_2, P_3, P_4);
	}

	public void zXktUZPPGodJAcfQSusogOzdeqFo()
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
			{
				tYZREkWfNhbMhYTKHDFmietlMVEdA();
			}
		}
	}

	void fmknYWuxIkOhtFkdpAUHgftPbHiiA.zXktUZPPGodJAcfQSusogOzdeqFo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in zXktUZPPGodJAcfQSusogOzdeqFo
		this.zXktUZPPGodJAcfQSusogOzdeqFo();
	}

	private void tYZREkWfNhbMhYTKHDFmietlMVEdA()
	{
		if (wuanUeAGKIgdXJmXuFfrcwEoXHwJA != bSXgQxRRaNVHwGgNaffohlvjREvUA.Closed)
		{
			if (WAGlHFDoWwGMCDVjbDxoNYRnNkcL != IntPtr.Zero)
			{
				nylTIQDqDLHmsQWIsXNPMMEUuYSL(WAGlHFDoWwGMCDVjbDxoNYRnNkcL);
				WAGlHFDoWwGMCDVjbDxoNYRnNkcL = IntPtr.Zero;
			}
			if (NtEcJlNLnGpycVeQZeIYlMedGHHs != IntPtr.Zero)
			{
				nylTIQDqDLHmsQWIsXNPMMEUuYSL(NtEcJlNLnGpycVeQZeIYlMedGHHs);
				NtEcJlNLnGpycVeQZeIYlMedGHHs = IntPtr.Zero;
			}
			wuanUeAGKIgdXJmXuFfrcwEoXHwJA = bSXgQxRRaNVHwGgNaffohlvjREvUA.Closed;
		}
	}

	public zSYPqstKQppxFjZuepAvqmOjezCw xWPdFkhEuYbKoMqaTzNbLlMyFnpGA()
	{
		return xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(0);
	}

	zSYPqstKQppxFjZuepAvqmOjezCw fmknYWuxIkOhtFkdpAUHgftPbHiiA.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xWPdFkhEuYbKoMqaTzNbLlMyFnpGA
		return this.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA();
	}

	public zSYPqstKQppxFjZuepAvqmOjezCw xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(int P_0)
	{
		zSYPqstKQppxFjZuepAvqmOjezCw zSYPqstKQppxFjZuepAvqmOjezCw2 = new zSYPqstKQppxFjZuepAvqmOjezCw(TUxLPZCrXcTEFieBhUHZdEKwbXaD(), zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.NoDataRead);
		xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(zSYPqstKQppxFjZuepAvqmOjezCw2, P_0);
		return zSYPqstKQppxFjZuepAvqmOjezCw2;
	}

	zSYPqstKQppxFjZuepAvqmOjezCw fmknYWuxIkOhtFkdpAUHgftPbHiiA.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xWPdFkhEuYbKoMqaTzNbLlMyFnpGA
		return this.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(P_0);
	}

	public unsafe bool xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(zSYPqstKQppxFjZuepAvqmOjezCw P_0, int P_1)
	{
		try
		{
			byte[] array = P_0.SSaCegYtbDtuwHgjNxDNXRzkPiIc;
			fixed (byte* ptr = array)
			{
				zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA bwvhenhOxyAwBobcXrnDjLNsHDbHA;
				return bvUMMiwimwawUQrsCXbJzmwvMuPf((IntPtr)ptr, array.Length, P_1, out bwvhenhOxyAwBobcXrnDjLNsHDbHA) == cctCtNMrJOWrhWROwnuhVClJCKEdA.Success;
			}
		}
		catch (Exception)
		{
			P_0.TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0.SSaCegYtbDtuwHgjNxDNXRzkPiIc, zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.ReadError);
			return false;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(zSYPqstKQppxFjZuepAvqmOjezCw P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xWPdFkhEuYbKoMqaTzNbLlMyFnpGA
		return this.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(P_0, P_1);
	}

	public bool NjyldkySiFMaUecgdZtdEmIrLMmj(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		if (P_1 <= 0)
		{
			P_0 = EmptyObjects<byte>.array;
			return false;
		}
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[P_1];
			byte[] array = ChttzmNTkDdFrPhnHcqkBqZSZJOBA(P_1);
			array[0] = P_2;
			bool flag = false;
			try
			{
				flag = xzEJGnblZZkOpksQsCkUEOgsHAvz.gqaMPObVmwCxQkFhjaBaFqaSjteFA(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, P_1));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{SSTCClPgTrDnBShUmazYUjvOcCfu}'.", innerException);
			}
			return flag;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.NjyldkySiFMaUecgdZtdEmIrLMmj(out byte[] P_0, int P_1, byte P_2 = 0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in NjyldkySiFMaUecgdZtdEmIrLMmj
		return this.NjyldkySiFMaUecgdZtdEmIrLMmj(out P_0, P_1, P_2);
	}

	public string VtOyODuAkLbWBEIfIgIXhIBTEMcF()
	{
		try
		{
			if (!VtOyODuAkLbWBEIfIgIXhIBTEMcF(out var bytes))
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

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.VtOyODuAkLbWBEIfIgIXhIBTEMcF()
	{
		//ILSpy generated this explicit interface implementation from .override directive in VtOyODuAkLbWBEIfIgIXhIBTEMcF
		return this.VtOyODuAkLbWBEIfIgIXhIBTEMcF();
	}

	public unsafe bool VtOyODuAkLbWBEIfIgIXhIBTEMcF(out byte[] P_0)
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) == 0)
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
					result = xzEJGnblZZkOpksQsCkUEOgsHAvz.jlwFXhUSyFGsudDIJFBurtgveAqyA(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, (IntPtr)ptr2, P_0.Length);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{SSTCClPgTrDnBShUmazYUjvOcCfu}'.", innerException);
			}
			return result;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.VtOyODuAkLbWBEIfIgIXhIBTEMcF(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in VtOyODuAkLbWBEIfIgIXhIBTEMcF
		return this.VtOyODuAkLbWBEIfIgIXhIBTEMcF(out P_0);
	}

	public string ZMOydhAEdwdFBJRxBtsvdSmtjCfeA()
	{
		ZMOydhAEdwdFBJRxBtsvdSmtjCfeA(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.ZMOydhAEdwdFBJRxBtsvdSmtjCfeA()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ZMOydhAEdwdFBJRxBtsvdSmtjCfeA
		return this.ZMOydhAEdwdFBJRxBtsvdSmtjCfeA();
	}

	public bool ZMOydhAEdwdFBJRxBtsvdSmtjCfeA(out byte[] P_0)
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = xzEJGnblZZkOpksQsCkUEOgsHAvz.xgZLnPrcUECiihDrfSojcRSojWQq(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, gCHandle.AddrOfPinnedObject(), P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{SSTCClPgTrDnBShUmazYUjvOcCfu}'.", innerException);
			}
			return flag;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.ZMOydhAEdwdFBJRxBtsvdSmtjCfeA(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ZMOydhAEdwdFBJRxBtsvdSmtjCfeA
		return this.ZMOydhAEdwdFBJRxBtsvdSmtjCfeA(out P_0);
	}

	public string aaLNIcbfUEbePcboBGxbnsGbodejb()
	{
		aaLNIcbfUEbePcboBGxbnsGbodejb(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.aaLNIcbfUEbePcboBGxbnsGbodejb()
	{
		//ILSpy generated this explicit interface implementation from .override directive in aaLNIcbfUEbePcboBGxbnsGbodejb
		return this.aaLNIcbfUEbePcboBGxbnsGbodejb();
	}

	public bool aaLNIcbfUEbePcboBGxbnsGbodejb(out byte[] P_0)
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			bool flag = false;
			try
			{
				flag = aaLNIcbfUEbePcboBGxbnsGbodejb(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{SSTCClPgTrDnBShUmazYUjvOcCfu}'.", innerException);
			}
			return flag;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.aaLNIcbfUEbePcboBGxbnsGbodejb(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in aaLNIcbfUEbePcboBGxbnsGbodejb
		return this.aaLNIcbfUEbePcboBGxbnsGbodejb(out P_0);
	}

	public string eWdibxHanKFwWBdtbApQhAKkdonw()
	{
		eWdibxHanKFwWBdtbApQhAKkdonw(out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	string fmknYWuxIkOhtFkdpAUHgftPbHiiA.eWdibxHanKFwWBdtbApQhAKkdonw()
	{
		//ILSpy generated this explicit interface implementation from .override directive in eWdibxHanKFwWBdtbApQhAKkdonw
		return this.eWdibxHanKFwWBdtbApQhAKkdonw();
	}

	public bool eWdibxHanKFwWBdtbApQhAKkdonw(out byte[] P_0)
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) == 0)
			{
				P_0 = EmptyObjects<byte>.array;
				return false;
			}
			P_0 = new byte[255];
			bool flag = false;
			try
			{
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = xzEJGnblZZkOpksQsCkUEOgsHAvz.bQQaFRanHsjWHsrMhCdiUKRMEQnx(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, gCHandle.AddrOfPinnedObject(), (uint)P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{SSTCClPgTrDnBShUmazYUjvOcCfu}'.", innerException);
			}
			return flag;
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.eWdibxHanKFwWBdtbApQhAKkdonw(out byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in eWdibxHanKFwWBdtbApQhAKkdonw
		return this.eWdibxHanKFwWBdtbApQhAKkdonw(out P_0);
	}

	public bool EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0)
	{
		return EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0, 0);
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in EvDntuhsTubUqbxfRrKDVdXsLcYv
		return this.EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0);
	}

	public unsafe bool EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0, int P_1)
	{
		fixed (byte* ptr = P_0)
		{
			return coDvoGLSkdJhgkQRaRHfvliANMPR((IntPtr)ptr, P_0.Length, P_1, nKtbafSXrnTNPtOvtJxfpVimFmOA.None, false);
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.EvDntuhsTubUqbxfRrKDVdXsLcYv(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in EvDntuhsTubUqbxfRrKDVdXsLcYv
		return this.EvDntuhsTubUqbxfRrKDVdXsLcYv(P_0, P_1);
	}

	public bool aclPpaLxnqyTLVJMfezZhuMzsQcg(IntPtr P_0, int P_1, int P_2, nKtbafSXrnTNPtOvtJxfpVimFmOA P_3)
	{
		return coDvoGLSkdJhgkQRaRHfvliANMPR(P_0, P_1, P_2, P_3, true);
	}

	public bool aclPpaLxnqyTLVJMfezZhuMzsQcg(xDlFkKEEsqHDzeOiaTIGueyqTccYA P_0, int P_1)
	{
		return aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0.QtXcZTickhBwGLYIAJbqpdfWpmzB, P_0.muWgIwfZykaHnaQEEYPetzSeXIsSA, P_1, P_0.vVKRiokJGjZFUsDfHXTaxdFOMKfy);
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.aclPpaLxnqyTLVJMfezZhuMzsQcg(xDlFkKEEsqHDzeOiaTIGueyqTccYA P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in aclPpaLxnqyTLVJMfezZhuMzsQcg
		return this.aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0, P_1);
	}

	public CFAcDfGMvgAnoRvOnWlGRTRORlWs mJeDIoISynnBYzEQICJSDQeSsSCv()
	{
		return new CFAcDfGMvgAnoRvOnWlGRTRORlWs(((fmknYWuxIkOhtFkdpAUHgftPbHiiA)this).gSKbQhPhCcxFkHCLeYWmJrvPjhbK.GnTzktXniHYlotJHHutLKBofjoVaA);
	}

	CFAcDfGMvgAnoRvOnWlGRTRORlWs fmknYWuxIkOhtFkdpAUHgftPbHiiA.mJeDIoISynnBYzEQICJSDQeSsSCv()
	{
		//ILSpy generated this explicit interface implementation from .override directive in mJeDIoISynnBYzEQICJSDQeSsSCv
		return this.mJeDIoISynnBYzEQICJSDQeSsSCv();
	}

	public bool xLKmohszEqBAEiZUsOJMlrfgpGeq(byte[] P_0, int P_1)
	{
		using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Write) == 0)
			{
				return false;
			}
			if (rrfBhOZmlDrtYBmDiENzlKuJmeKh.srXVOLvexgigReRBAhalEzTUmoEP <= 0)
			{
				return false;
			}
			byte[] array = ChttzmNTkDdFrPhnHcqkBqZSZJOBA(P_1);
			Array.Copy(P_0, 0, array, 0, Math.Min(P_0.Length, P_1));
			try
			{
				return xzEJGnblZZkOpksQsCkUEOgsHAvz.SdLcJRVDquyFtvtwLJLMNPzekirV(NtEcJlNLnGpycVeQZeIYlMedGHHs, array, P_1);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{SSTCClPgTrDnBShUmazYUjvOcCfu}'.", innerException);
			}
		}
	}

	bool fmknYWuxIkOhtFkdpAUHgftPbHiiA.xLKmohszEqBAEiZUsOJMlrfgpGeq(byte[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xLKmohszEqBAEiZUsOJMlrfgpGeq
		return this.xLKmohszEqBAEiZUsOJMlrfgpGeq(P_0, P_1);
	}

	private byte[] TUxLPZCrXcTEFieBhUHZdEKwbXaD()
	{
		return zWYmoCGKgpEzcRbJMVKsaRcingmj(((fmknYWuxIkOhtFkdpAUHgftPbHiiA)this).gSKbQhPhCcxFkHCLeYWmJrvPjhbK.BFzUjJhIGhHhGqmDyYcnjeMnqNBK - 1);
	}

	private byte[] swEiKVAhQIvGMaJkSoWDCfTyOgON()
	{
		return zWYmoCGKgpEzcRbJMVKsaRcingmj(((fmknYWuxIkOhtFkdpAUHgftPbHiiA)this).gSKbQhPhCcxFkHCLeYWmJrvPjhbK.GnTzktXniHYlotJHHutLKBofjoVaA - 1);
	}

	private static byte[] ChttzmNTkDdFrPhnHcqkBqZSZJOBA(int P_0)
	{
		return zWYmoCGKgpEzcRbJMVKsaRcingmj(P_0 - 1);
	}

	private unsafe zSYPqstKQppxFjZuepAvqmOjezCw bvUMMiwimwawUQrsCXbJzmwvMuPf(int P_0)
	{
		byte[] array = TUxLPZCrXcTEFieBhUHZdEKwbXaD();
		zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA bwvhenhOxyAwBobcXrnDjLNsHDbHA;
		fixed (byte* ptr = array)
		{
			bvUMMiwimwawUQrsCXbJzmwvMuPf((IntPtr)ptr, array.Length, P_0, out bwvhenhOxyAwBobcXrnDjLNsHDbHA);
		}
		return new zSYPqstKQppxFjZuepAvqmOjezCw(array, bwvhenhOxyAwBobcXrnDjLNsHDbHA);
	}

	private cctCtNMrJOWrhWROwnuhVClJCKEdA bvUMMiwimwawUQrsCXbJzmwvMuPf(IntPtr P_0, int P_1, int P_2, out zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA P_3)
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Read) == 0)
			{
				P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.NotConnected;
				return cctCtNMrJOWrhWROwnuhVClJCKEdA.DeviceNotOpen;
			}
			P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.NoDataRead;
			if (P_1 < ((fmknYWuxIkOhtFkdpAUHgftPbHiiA)this).gSKbQhPhCcxFkHCLeYWmJrvPjhbK.BFzUjJhIGhHhGqmDyYcnjeMnqNBK)
			{
				return cctCtNMrJOWrhWROwnuhVClJCKEdA.BufferTooSmall;
			}
			if (rrfBhOZmlDrtYBmDiENzlKuJmeKh.BFzUjJhIGhHhGqmDyYcnjeMnqNBK > 0)
			{
				uint num = 0u;
				if (yshSjvpjJIsBRDEoVVLTjCrTbubX == FBJyKviZPIDJRgxnjkLCYoNJwALW.Overlapped)
				{
					int num2 = ((P_2 <= 0) ? 65535 : P_2);
					xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB yYMTNNNoyMogyIlwZIqBicAzqoXB = new xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB
					{
						bYDCEEOaZviCHbNWcahoXbuKypNH = IntPtr.Zero,
						AuyFQvdGkoUHsaqrtlJtXllYCzBE = true,
						dVLrXkhlUTCupYmQxQJakObLpWTQ = xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB.bKFjyRTrjUCZHtswQeOEtYaivvKq
					};
					WjwdFkLXPnaighNGwswisNBPYbyv.pWRdAJigDslyLjNIYbVMMkTWOPgC = yYMTNNNoyMogyIlwZIqBicAzqoXB;
					IntPtr intPtr = xzEJGnblZZkOpksQsCkUEOgsHAvz.CgwooeGWbAYuCuhIAWCKdOaOEcfB(SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(WjwdFkLXPnaighNGwswisNBPYbyv.dXHcFyHeaDiigomrUnUCJYjMNGxM), Convert.ToInt32(value: false), Convert.ToInt32(value: true), IntPtr.Zero);
					if (intPtr == IntPtr.Zero)
					{
						return cctCtNMrJOWrhWROwnuhVClJCKEdA.ReadError;
					}
					xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi raofNouXMWakJRqhMsfMoESdiPTi = new xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi
					{
						FeyMtLCnVSEdrbiMlzlQGCYnKvGH = 0,
						PeNOekASTfSIuXooWbgIMEjUIORb = 0,
						IwLVHLCtIzimkIHSIsynzpsIhPgR = intPtr
					};
					RGwmCduHbjKbJmqQxEAPkQjOtPaQ.pWRdAJigDslyLjNIYbVMMkTWOPgC = raofNouXMWakJRqhMsfMoESdiPTi;
					try
					{
						if (xzEJGnblZZkOpksQsCkUEOgsHAvz.aOCgNLfCquVfguDOgCsJiQaFLuQu(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, P_0, (uint)P_1, out num, SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(RGwmCduHbjKbJmqQxEAPkQjOtPaQ.dXHcFyHeaDiigomrUnUCJYjMNGxM)))
						{
							P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.Success;
						}
						else if ((long)Marshal.GetLastWin32Error() == 997)
						{
							switch (xzEJGnblZZkOpksQsCkUEOgsHAvz.LqFeOiarzeRsGMIUDRVSZCRBcsrBA(RGwmCduHbjKbJmqQxEAPkQjOtPaQ.pWRdAJigDslyLjNIYbVMMkTWOPgC.IwLVHLCtIzimkIHSIsynzpsIhPgR, num2))
							{
							case 0u:
							case 192u:
								if (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.ZeDgZvfImvmDNmehqeKOIIrmPEGk(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(RGwmCduHbjKbJmqQxEAPkQjOtPaQ.dXHcFyHeaDiigomrUnUCJYjMNGxM), out num, false))
								{
									if (num != 0)
									{
										P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.Success;
									}
									else
									{
										P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.NoDataRead;
									}
								}
								else
								{
									P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.ReadError;
								}
								break;
							case 258u:
								P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.WaitTimedOut;
								break;
							case uint.MaxValue:
								P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.WaitFail;
								break;
							case 128u:
								P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.WaitAbandoned;
								break;
							default:
								P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.NoDataRead;
								break;
							}
						}
						else
						{
							P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.ReadError;
						}
					}
					catch
					{
						P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.ReadError;
					}
					finally
					{
						xzEJGnblZZkOpksQsCkUEOgsHAvz.kkoqfuBvkFeqRafJWSjcGLxooPxj(WAGlHFDoWwGMCDVjbDxoNYRnNkcL);
						IntPtr iwLVHLCtIzimkIHSIsynzpsIhPgR = RGwmCduHbjKbJmqQxEAPkQjOtPaQ.pWRdAJigDslyLjNIYbVMMkTWOPgC.IwLVHLCtIzimkIHSIsynzpsIhPgR;
						if (iwLVHLCtIzimkIHSIsynzpsIhPgR != IntPtr.Zero)
						{
							biwcMIgoJKBorTBdKPtkRrcVCIqH(iwLVHLCtIzimkIHSIsynzpsIhPgR);
						}
					}
				}
				else
				{
					try
					{
						if (xzEJGnblZZkOpksQsCkUEOgsHAvz.aOCgNLfCquVfguDOgCsJiQaFLuQu(WAGlHFDoWwGMCDVjbDxoNYRnNkcL, P_0, (uint)P_1, out num, IntPtr.Zero))
						{
							P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.Success;
						}
						else
						{
							P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.Success;
							P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.ReadError;
						}
					}
					catch
					{
						P_3 = zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.ReadError;
					}
				}
			}
			return (P_3 != zSYPqstKQppxFjZuepAvqmOjezCw.bwvhenhOxyAwBobcXrnDjLNsHDbHA.Success) ? cctCtNMrJOWrhWROwnuhVClJCKEdA.ReadError : cctCtNMrJOWrhWROwnuhVClJCKEdA.Success;
		}
	}

	private bool coDvoGLSkdJhgkQRaRHfvliANMPR(IntPtr P_0, int P_1, int P_2, nKtbafSXrnTNPtOvtJxfpVimFmOA P_3, bool P_4)
	{
		using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
		{
			if ((wuanUeAGKIgdXJmXuFfrcwEoXHwJA & bSXgQxRRaNVHwGgNaffohlvjREvUA.Write) == 0)
			{
				return false;
			}
			if (P_0 == IntPtr.Zero || P_1 <= 0)
			{
				return false;
			}
			if (!P_4)
			{
				if (rrfBhOZmlDrtYBmDiENzlKuJmeKh.GnTzktXniHYlotJHHutLKBofjoVaA <= 0)
				{
					return false;
				}
				P_1 = Math.Min(P_1, rrfBhOZmlDrtYBmDiENzlKuJmeKh.GnTzktXniHYlotJHHutLKBofjoVaA);
			}
			uint num = 0u;
			if (hRTcoUzNYoUYOihXXVILkQtwLgQh == FBJyKviZPIDJRgxnjkLCYoNJwALW.Overlapped)
			{
				try
				{
					if ((P_3 & nKtbafSXrnTNPtOvtJxfpVimFmOA.WriteDirect) != nKtbafSXrnTNPtOvtJxfpVimFmOA.None)
					{
						return xzEJGnblZZkOpksQsCkUEOgsHAvz.pggpAoRzNAXCrDZcKvZVpuhUbjPD(NtEcJlNLnGpycVeQZeIYlMedGHHs, P_0, P_1);
					}
				}
				catch (Exception)
				{
					return false;
				}
				int num2 = ((P_2 <= 0) ? 65535 : P_2);
				xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB yYMTNNNoyMogyIlwZIqBicAzqoXB = new xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB
				{
					bYDCEEOaZviCHbNWcahoXbuKypNH = IntPtr.Zero,
					AuyFQvdGkoUHsaqrtlJtXllYCzBE = true,
					dVLrXkhlUTCupYmQxQJakObLpWTQ = xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB.bKFjyRTrjUCZHtswQeOEtYaivvKq
				};
				WjwdFkLXPnaighNGwswisNBPYbyv.pWRdAJigDslyLjNIYbVMMkTWOPgC = yYMTNNNoyMogyIlwZIqBicAzqoXB;
				IntPtr intPtr = xzEJGnblZZkOpksQsCkUEOgsHAvz.CgwooeGWbAYuCuhIAWCKdOaOEcfB(SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(WjwdFkLXPnaighNGwswisNBPYbyv.dXHcFyHeaDiigomrUnUCJYjMNGxM), Convert.ToInt32(value: false), Convert.ToInt32(value: true), IntPtr.Zero);
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi raofNouXMWakJRqhMsfMoESdiPTi = new xzEJGnblZZkOpksQsCkUEOgsHAvz.raofNouXMWakJRqhMsfMoESdiPTi
				{
					FeyMtLCnVSEdrbiMlzlQGCYnKvGH = 0,
					PeNOekASTfSIuXooWbgIMEjUIORb = 0,
					IwLVHLCtIzimkIHSIsynzpsIhPgR = intPtr
				};
				RGwmCduHbjKbJmqQxEAPkQjOtPaQ.pWRdAJigDslyLjNIYbVMMkTWOPgC = raofNouXMWakJRqhMsfMoESdiPTi;
				try
				{
					if (xzEJGnblZZkOpksQsCkUEOgsHAvz.PnnCRRvnfrHjYjTevntVFhMZKzHZ(NtEcJlNLnGpycVeQZeIYlMedGHHs, P_0, (uint)P_1, IntPtr.Zero, SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(RGwmCduHbjKbJmqQxEAPkQjOtPaQ.dXHcFyHeaDiigomrUnUCJYjMNGxM)))
					{
						return true;
					}
					if ((long)Marshal.GetLastWin32Error() == 997)
					{
						switch (xzEJGnblZZkOpksQsCkUEOgsHAvz.LqFeOiarzeRsGMIUDRVSZCRBcsrBA(RGwmCduHbjKbJmqQxEAPkQjOtPaQ.pWRdAJigDslyLjNIYbVMMkTWOPgC.IwLVHLCtIzimkIHSIsynzpsIhPgR, num2))
						{
						case 0u:
						case 192u:
							if (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.ZeDgZvfImvmDNmehqeKOIIrmPEGk(NtEcJlNLnGpycVeQZeIYlMedGHHs, SoDaUPyxhCljCRyOJyRmuMKFqYxD.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(RGwmCduHbjKbJmqQxEAPkQjOtPaQ.dXHcFyHeaDiigomrUnUCJYjMNGxM), out num, false))
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
					xzEJGnblZZkOpksQsCkUEOgsHAvz.kkoqfuBvkFeqRafJWSjcGLxooPxj(NtEcJlNLnGpycVeQZeIYlMedGHHs);
					IntPtr iwLVHLCtIzimkIHSIsynzpsIhPgR = RGwmCduHbjKbJmqQxEAPkQjOtPaQ.pWRdAJigDslyLjNIYbVMMkTWOPgC.IwLVHLCtIzimkIHSIsynzpsIhPgR;
					if (iwLVHLCtIzimkIHSIsynzpsIhPgR != IntPtr.Zero)
					{
						biwcMIgoJKBorTBdKPtkRrcVCIqH(iwLVHLCtIzimkIHSIsynzpsIhPgR);
					}
				}
			}
			try
			{
				if ((P_3 & nKtbafSXrnTNPtOvtJxfpVimFmOA.WriteDirect) != nKtbafSXrnTNPtOvtJxfpVimFmOA.None)
				{
					return xzEJGnblZZkOpksQsCkUEOgsHAvz.pggpAoRzNAXCrDZcKvZVpuhUbjPD(NtEcJlNLnGpycVeQZeIYlMedGHHs, P_0, P_1);
				}
				return xzEJGnblZZkOpksQsCkUEOgsHAvz.PnnCRRvnfrHjYjTevntVFhMZKzHZ(NtEcJlNLnGpycVeQZeIYlMedGHHs, P_0, (uint)P_1, out num, IntPtr.Zero);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private void oyeMNkUDYxfTAKTMrsGVcgwJLtrf()
	{
	}

	private void uAMpoNboCLVaKhYmBwEjfwaMnWGI()
	{
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
			{
				tYZREkWfNhbMhYTKHDFmietlMVEdA();
				if (this.pkiMvJxnrhGnTRAlueBeYHUolwMR != null)
				{
					this.pkiMvJxnrhGnTRAlueBeYHUolwMR();
				}
			}
		}
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
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

	private void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		using (lKvzyVTqmDQrKQExdfepjXXxBDItA.Lock())
		{
			using (YupcQmhUHYJYANqDLkQNCNdWOPXvA.Lock())
			{
				if (((fmknYWuxIkOhtFkdpAUHgftPbHiiA)this).OsNaPfSOZUqHgMjAlNIbKLrYAFfEA)
				{
					((fmknYWuxIkOhtFkdpAUHgftPbHiiA)this).OsNaPfSOZUqHgMjAlNIbKLrYAFfEA = false;
				}
				if (wuanUeAGKIgdXJmXuFfrcwEoXHwJA != bSXgQxRRaNVHwGgNaffohlvjREvUA.Closed)
				{
					tYZREkWfNhbMhYTKHDFmietlMVEdA();
				}
				ObjectInstanceTracker.Default.Unregister(feyfUxusytQNkXYleniaLrtnurww);
				if (RGwmCduHbjKbJmqQxEAPkQjOtPaQ != null)
				{
					RGwmCduHbjKbJmqQxEAPkQjOtPaQ.Dispose();
				}
				if (WjwdFkLXPnaighNGwswisNBPYbyv != null)
				{
					WjwdFkLXPnaighNGwswisNBPYbyv.Dispose();
				}
			}
		}
		JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
	}

	public static bool aaLNIcbfUEbePcboBGxbnsGbodejb(IntPtr P_0, out byte[] P_1)
	{
		P_1 = new byte[255];
		_ = string.Empty;
		bool flag = false;
		GCHandle gCHandle = GCHandle.Alloc(P_1, GCHandleType.Pinned);
		try
		{
			flag = xzEJGnblZZkOpksQsCkUEOgsHAvz.xCJjNfXaZzDxzZdUTdoRUtDxrsCC(P_0, gCHandle.AddrOfPinnedObject(), P_1.Length);
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

	public static string aaLNIcbfUEbePcboBGxbnsGbodejb(IntPtr P_0)
	{
		aaLNIcbfUEbePcboBGxbnsGbodejb(P_0, out var bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public static bool aaLNIcbfUEbePcboBGxbnsGbodejb(IntPtr P_0, IntPtr P_1, int P_2)
	{
		if (P_2 < 255)
		{
			throw new Exception("Buffer length must be at least " + 255 + " bytes!");
		}
		try
		{
			return xzEJGnblZZkOpksQsCkUEOgsHAvz.xCJjNfXaZzDxzZdUTdoRUtDxrsCC(P_0, P_1, P_2);
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error accessing HID device at handle '{P_0}'.", innerException);
		}
	}

	public static IntPtr qRGErlebaNBrfzcIPJHwDGgcBztOb(string P_0, FBJyKviZPIDJRgxnjkLCYoNJwALW P_1, uint P_2, GTnUvTIDUEdlNImTKwVWFNCeIERq P_3)
	{
		xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB yYMTNNNoyMogyIlwZIqBicAzqoXB = default(xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB);
		int num = 0;
		if (P_1 == FBJyKviZPIDJRgxnjkLCYoNJwALW.Overlapped)
		{
			num = 1073741824;
		}
		yYMTNNNoyMogyIlwZIqBicAzqoXB.bYDCEEOaZviCHbNWcahoXbuKypNH = IntPtr.Zero;
		yYMTNNNoyMogyIlwZIqBicAzqoXB.AuyFQvdGkoUHsaqrtlJtXllYCzBE = true;
		yYMTNNNoyMogyIlwZIqBicAzqoXB.dVLrXkhlUTCupYmQxQJakObLpWTQ = xzEJGnblZZkOpksQsCkUEOgsHAvz.YYMTNNNoyMogyIlwZIqBicAzqoXB.bKFjyRTrjUCZHtswQeOEtYaivvKq;
		return xzEJGnblZZkOpksQsCkUEOgsHAvz.vJZkwQdJXCmqIorjiJSPYCwnGImc(P_0, P_2, (int)P_3, ref yYMTNNNoyMogyIlwZIqBicAzqoXB, 3, num, 0);
	}

	public static void nylTIQDqDLHmsQWIsXNPMMEUuYSL(IntPtr P_0)
	{
		wEaYRjATLzFuxgmvvbtAetSVbAzZA(P_0);
		xzEJGnblZZkOpksQsCkUEOgsHAvz.huSgqXhORpslUgixSgrlotTBroEq(P_0);
	}

	public static void wEaYRjATLzFuxgmvvbtAetSVbAzZA(IntPtr P_0)
	{
		if (Environment.OSVersion.Version.Major > 5)
		{
			xzEJGnblZZkOpksQsCkUEOgsHAvz.vBbxIPPUEgCYbMMVCeJGDJqZGLeJ(P_0, IntPtr.Zero);
		}
		else
		{
			xzEJGnblZZkOpksQsCkUEOgsHAvz.kkoqfuBvkFeqRafJWSjcGLxooPxj(P_0);
		}
	}

	private static void biwcMIgoJKBorTBdKPtkRrcVCIqH(IntPtr P_0)
	{
		xzEJGnblZZkOpksQsCkUEOgsHAvz.kkoqfuBvkFeqRafJWSjcGLxooPxj(P_0);
		xzEJGnblZZkOpksQsCkUEOgsHAvz.huSgqXhORpslUgixSgrlotTBroEq(P_0);
	}

	internal static VEavlBCjlwYFgIYiKEZpvYEuUTOH vnWaEmWDgfxkgTQQkFsjRjmPVnrM(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		FUkKatfPiTDRfnAuBLcDLCqAqdOG[] array = new FUkKatfPiTDRfnAuBLcDLCqAqdOG[P_3];
		for (int i = 0; i < P_3; i++)
		{
			xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu.JSxxnMSTiljbsMjPoYsvKQUerDhL swdzoMLvUIwNSujrRdQOlPFBQxwj = new xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu.JSxxnMSTiljbsMjPoYsvKQUerDhL
			{
				pEIAlUGxjZFXifzfbtrPIYHzceyHA = new ushort[8]
			};
			swdzoMLvUIwNSujrRdQOlPFBQxwj.pEIAlUGxjZFXifzfbtrPIYHzceyHA[0] = (ushort)i;
			array[i] = new FUkKatfPiTDRfnAuBLcDLCqAqdOG(new xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu
			{
				mfmnPLnoKcRvXQLIfmBFbZvcCOM = 9,
				swdzoMLvUIwNSujrRdQOlPFBQxwj = swdzoMLvUIwNSujrRdQOlPFBQxwj
			});
		}
		int num = P_2 + P_4;
		cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] array2 = new cbwdFAJnqCMGYkkkxIGEIVddLrvEb[num];
		for (int j = 0; j < num; j++)
		{
			xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA.QLPBMHHFDZRzFkIznkwcClPcEMiCB swdzoMLvUIwNSujrRdQOlPFBQxwj2 = new xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA.QLPBMHHFDZRzFkIznkwcClPcEMiCB
			{
				pEIAlUGxjZFXifzfbtrPIYHzceyHA = new ushort[8]
			};
			if (j < P_2)
			{
				swdzoMLvUIwNSujrRdQOlPFBQxwj2.pEIAlUGxjZFXifzfbtrPIYHzceyHA[0] = 48;
			}
			else
			{
				swdzoMLvUIwNSujrRdQOlPFBQxwj2.pEIAlUGxjZFXifzfbtrPIYHzceyHA[0] = 57;
			}
			array2[j] = new cbwdFAJnqCMGYkkkxIGEIVddLrvEb(new xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA
			{
				mfmnPLnoKcRvXQLIfmBFbZvcCOM = 1,
				swdzoMLvUIwNSujrRdQOlPFBQxwj = swdzoMLvUIwNSujrRdQOlPFBQxwj2
			});
		}
		return new VEavlBCjlwYFgIYiKEZpvYEuUTOH(new UoDwJHKuSqzSqLScKefxqMdnpcOA(new xzEJGnblZZkOpksQsCkUEOgsHAvz.ciSTvoybiqqtKdIunLXdJEnsctFc
		{
			kDPRZGYQtHlkZfqcupKpjBPofnfk = (ushort)P_1,
			acgHaHmspdbxlAvqbqCsvyxTpIoG = (ushort)P_0
		}), new kJWvYMLjQGVjMEOIYaiIMiQepABE(new xzEJGnblZZkOpksQsCkUEOgsHAvz.BnddotgLHLOFmaxprCDnJvEyKmNYA
		{
			SSSvXRAdhzynKDSzhRLewJHzCWICA = (short)P_3,
			AFMqfyKTWLZbnjGinMFKyEvfWbuC = (short)P_2
		}), array, array2);
	}

	private static byte[] zWYmoCGKgpEzcRbJMVKsaRcingmj(int P_0)
	{
		byte[] array = null;
		Array.Resize(ref array, P_0 + 1);
		return array;
	}

	public static UoDwJHKuSqzSqLScKefxqMdnpcOA TxlMvfgalChIEkGktxNOBYxmEiRhA(IntPtr P_0)
	{
		xzEJGnblZZkOpksQsCkUEOgsHAvz.ciSTvoybiqqtKdIunLXdJEnsctFc ciSTvoybiqqtKdIunLXdJEnsctFc = default(xzEJGnblZZkOpksQsCkUEOgsHAvz.ciSTvoybiqqtKdIunLXdJEnsctFc);
		ciSTvoybiqqtKdIunLXdJEnsctFc.woNJXLkWwUOBugYfuMGynSMoksFi = Marshal.SizeOf((object)ciSTvoybiqqtKdIunLXdJEnsctFc);
		xzEJGnblZZkOpksQsCkUEOgsHAvz.QXIllcSnxlcJDiNWxkpHpOilGdCu(P_0, ref ciSTvoybiqqtKdIunLXdJEnsctFc);
		return new UoDwJHKuSqzSqLScKefxqMdnpcOA(ciSTvoybiqqtKdIunLXdJEnsctFc);
	}

	public static kJWvYMLjQGVjMEOIYaiIMiQepABE TdLnsxypHVhnWfGTrmwBPgTXgJhBA(IntPtr P_0)
	{
		xzEJGnblZZkOpksQsCkUEOgsHAvz.BnddotgLHLOFmaxprCDnJvEyKmNYA bnddotgLHLOFmaxprCDnJvEyKmNYA = default(xzEJGnblZZkOpksQsCkUEOgsHAvz.BnddotgLHLOFmaxprCDnJvEyKmNYA);
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (xzEJGnblZZkOpksQsCkUEOgsHAvz.HTiaadmZMewihbaMFTECGIAsIZUj(P_0, ref zero))
			{
				xzEJGnblZZkOpksQsCkUEOgsHAvz.mHHBrpKARevAksHqieJnIqnCRaDCb(zero, ref bnddotgLHLOFmaxprCDnJvEyKmNYA);
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
					xzEJGnblZZkOpksQsCkUEOgsHAvz.iOIQSAaMEXcafpVgpDlKsgWCZQzJ(zero);
				}
			}
			catch
			{
			}
		}
		return new kJWvYMLjQGVjMEOIYaiIMiQepABE(bnddotgLHLOFmaxprCDnJvEyKmNYA);
	}

	public static FUkKatfPiTDRfnAuBLcDLCqAqdOG[] lJCdHQMDfbFcFntIgsnIxtCFsGzy(IntPtr P_0, short P_1, short P_2)
	{
		FUkKatfPiTDRfnAuBLcDLCqAqdOG[] array = new FUkKatfPiTDRfnAuBLcDLCqAqdOG[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (xzEJGnblZZkOpksQsCkUEOgsHAvz.HTiaadmZMewihbaMFTECGIAsIZUj(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					xzEJGnblZZkOpksQsCkUEOgsHAvz.JeJIpfjNIAhFmfUYoCsXcIacQhtCc(intPtr, num2);
					xzEJGnblZZkOpksQsCkUEOgsHAvz.OnlfUmHekkAWyTPqLLHGjmWjCKpsB(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu[] array2 = new xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu)Marshal.PtrToStructure(intPtr2, typeof(xzEJGnblZZkOpksQsCkUEOgsHAvz.kAngRKSPRNDcgcwzpzdCGFWgxNMu));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new FUkKatfPiTDRfnAuBLcDLCqAqdOG(array2[i]);
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
					xzEJGnblZZkOpksQsCkUEOgsHAvz.iOIQSAaMEXcafpVgpDlKsgWCZQzJ(zero);
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

	public static cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] ASnNvtHJrhCqjufwHfimhAWbDllFA(IntPtr P_0, short P_1, short P_2)
	{
		cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] array = new cbwdFAJnqCMGYkkkxIGEIVddLrvEb[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (xzEJGnblZZkOpksQsCkUEOgsHAvz.HTiaadmZMewihbaMFTECGIAsIZUj(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					xzEJGnblZZkOpksQsCkUEOgsHAvz.JeJIpfjNIAhFmfUYoCsXcIacQhtCc(intPtr, num2);
					xzEJGnblZZkOpksQsCkUEOgsHAvz.yxcCKyCOkdqSLIxnulBiVhPxUkscA(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA[] array2 = new xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA)Marshal.PtrToStructure(intPtr2, typeof(xzEJGnblZZkOpksQsCkUEOgsHAvz.XiKRQlmPLGSvvNepRhYFGaNJxymOA));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new cbwdFAJnqCMGYkkkxIGEIVddLrvEb(array2[i]);
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
					xzEJGnblZZkOpksQsCkUEOgsHAvz.iOIQSAaMEXcafpVgpDlKsgWCZQzJ(zero);
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
