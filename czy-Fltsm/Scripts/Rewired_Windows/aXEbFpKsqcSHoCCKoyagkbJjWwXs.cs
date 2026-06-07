using System;
using System.Collections.Generic;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal abstract class aXEbFpKsqcSHoCCKoyagkbJjWwXs : JewImaRENcAhriGkgPvGEgPfnJHyb, IDisposable
{
	public sealed class jhCbnmgPXuaKrPvYOVdHLAYRRVMi
	{
		public struct TfeBlYvLaFqCjfqsnGMVuoGcxsZq
		{
			public UrMbpQUKaXalIhCJBFFlIUxHnmKDc XtlCUFnGoURWpdxxMNiUZeGWcyvU;

			public double WXGMGsEGcDaRacYTWpkaKotiHpmc;

			public TfeBlYvLaFqCjfqsnGMVuoGcxsZq(UrMbpQUKaXalIhCJBFFlIUxHnmKDc P_0, double P_1)
			{
				XtlCUFnGoURWpdxxMNiUZeGWcyvU = P_0;
				WXGMGsEGcDaRacYTWpkaKotiHpmc = P_1;
			}
		}

		public enum UrMbpQUKaXalIhCJBFFlIUxHnmKDc
		{
			None = 0,
			AsyncInitialization = 1,
			Unknown = 2
		}

		private class tajgiSAivoetJgveYzAcofdPOtwm
		{
			public const int ptnwNoBaRLssEthryecNewmCYVrt = 10;

			public readonly string gfqQuXvecYQsOzMZCsDXsCKbqrIl;

			public readonly List<TfeBlYvLaFqCjfqsnGMVuoGcxsZq> NmokJaJAVzYOoxgfBbSRgxysITDk;

			public bool yeFkNrOMdJUiCGpJpoIHRAVqYWNI;

			public tajgiSAivoetJgveYzAcofdPOtwm(string P_0)
			{
				NmokJaJAVzYOoxgfBbSRgxysITDk = new List<TfeBlYvLaFqCjfqsnGMVuoGcxsZq>();
				gfqQuXvecYQsOzMZCsDXsCKbqrIl = P_0;
			}
		}

		private static jhCbnmgPXuaKrPvYOVdHLAYRRVMi ndmPOZrEElFhHVkxgCOTfUbSBRgab;

		private readonly Dictionary<string, tajgiSAivoetJgveYzAcofdPOtwm> bazOWmcHvUVHteAGapqSWzrfTMvI = new Dictionary<string, tajgiSAivoetJgveYzAcofdPOtwm>();

		private readonly SpinLock HNxlDsyrprSfisgahukuIbknHizt = new SpinLock();

		public static jhCbnmgPXuaKrPvYOVdHLAYRRVMi nmKEiScSssTUneaJzSucuIBNHMUvA
		{
			get
			{
				if (ndmPOZrEElFhHVkxgCOTfUbSBRgab == null)
				{
					ndmPOZrEElFhHVkxgCOTfUbSBRgab = new jhCbnmgPXuaKrPvYOVdHLAYRRVMi();
					ReInput.ShutDownEvent += CTSrYBSvZtviuIJgrNfDanVkjxOe;
				}
				return ndmPOZrEElFhHVkxgCOTfUbSBRgab;
			}
		}

		public int OFGXBabrwtiYkrbvCmBxbffxDRuS(string P_0, UrMbpQUKaXalIhCJBFFlIUxHnmKDc P_1)
		{
			using (HNxlDsyrprSfisgahukuIbknHizt.Lock())
			{
				if (!bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
				{
					return 0;
				}
				int num = 0;
				for (int i = 0; i < value.NmokJaJAVzYOoxgfBbSRgxysITDk.Count; i++)
				{
					if ((value.NmokJaJAVzYOoxgfBbSRgxysITDk[i].XtlCUFnGoURWpdxxMNiUZeGWcyvU & P_1) == 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int LJNhujwMsQhlyhXinbUYWSKyoPhJ(string P_0, UrMbpQUKaXalIhCJBFFlIUxHnmKDc P_1, float P_2)
		{
			using (HNxlDsyrprSfisgahukuIbknHizt.Lock())
			{
				if (!bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
				{
					return 0;
				}
				double num = ReInput.realTime - (double)P_2;
				int num2 = 0;
				for (int i = 0; i < value.NmokJaJAVzYOoxgfBbSRgxysITDk.Count; i++)
				{
					if (!(value.NmokJaJAVzYOoxgfBbSRgxysITDk[i].WXGMGsEGcDaRacYTWpkaKotiHpmc < num) || (value.NmokJaJAVzYOoxgfBbSRgxysITDk[i].XtlCUFnGoURWpdxxMNiUZeGWcyvU & P_1) == 0)
					{
						num2++;
					}
				}
				return num2;
			}
		}

		public int oSEQhdldgoobkZvviVPTtHpKkjbf(string P_0, IList<TfeBlYvLaFqCjfqsnGMVuoGcxsZq> P_1)
		{
			int count = P_1.Count;
			if (bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
			{
				for (int i = 0; i < value.NmokJaJAVzYOoxgfBbSRgxysITDk.Count; i++)
				{
					P_1.Add(value.NmokJaJAVzYOoxgfBbSRgxysITDk[i]);
				}
			}
			return P_1.Count - count;
		}

		public void FZNbpJxeuTiZLEOSeoQQkVIsVcNk(string P_0, UrMbpQUKaXalIhCJBFFlIUxHnmKDc P_1)
		{
			using (HNxlDsyrprSfisgahukuIbknHizt.Lock())
			{
				if (!bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
				{
					value = new tajgiSAivoetJgveYzAcofdPOtwm(P_0);
					bazOWmcHvUVHteAGapqSWzrfTMvI.Add(P_0, value);
				}
				while (value.NmokJaJAVzYOoxgfBbSRgxysITDk.Count >= 10)
				{
					value.NmokJaJAVzYOoxgfBbSRgxysITDk.RemoveAt(0);
				}
				value.NmokJaJAVzYOoxgfBbSRgxysITDk.Add(new TfeBlYvLaFqCjfqsnGMVuoGcxsZq(P_1, ReInput.realTime));
			}
		}

		public void LdXSUyUhfZuAhiQLBROuXnrrDzMJ(string P_0)
		{
			using (HNxlDsyrprSfisgahukuIbknHizt.Lock())
			{
				if (bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
				{
					value.NmokJaJAVzYOoxgfBbSRgxysITDk.Clear();
				}
			}
		}

		public bool tuPyfGoeWNyfeaFdbIuDAVzxADQbA(string P_0)
		{
			using (HNxlDsyrprSfisgahukuIbknHizt.Lock())
			{
				if (bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
				{
					return value.yeFkNrOMdJUiCGpJpoIHRAVqYWNI;
				}
			}
			return false;
		}

		public void YdktHCxXoLyXVmDgbkABFRzAKBFO(string P_0, bool P_1)
		{
			using (HNxlDsyrprSfisgahukuIbknHizt.Lock())
			{
				if (!bazOWmcHvUVHteAGapqSWzrfTMvI.TryGetValue(P_0, out var value))
				{
					value = new tajgiSAivoetJgveYzAcofdPOtwm(P_0);
					bazOWmcHvUVHteAGapqSWzrfTMvI.Add(P_0, value);
				}
				value.yeFkNrOMdJUiCGpJpoIHRAVqYWNI = P_1;
			}
		}

		private static void CTSrYBSvZtviuIJgrNfDanVkjxOe()
		{
			ReInput.ShutDownEvent -= CTSrYBSvZtviuIJgrNfDanVkjxOe;
			ndmPOZrEElFhHVkxgCOTfUbSBRgab = null;
		}
	}

	protected readonly rtcpRxBVLKAMkXCloKUnYbCBcUfE TWGOZcGJKFXPgIhUkErFGomRgavIA;

	protected IntPtr UqQyKLlDTeDrRHmqMSqgrHCgiyhkA;

	protected readonly int AlBVmvJJYmRfcqQNQJJdYWJXLrnI;

	protected readonly int ziqenAVCYrdsqCmCwCRSiqtVHwHJ;

	protected readonly Guid GrGwgJZrZiBXCXpmdRnCvdtETKdN;

	protected readonly Guid PqmiUnfeFlHEuaRzGTrvlomFUuouA;

	protected readonly DeviceType DpEhBdPMTUaeTKAFVMsHJRzqoSfBb;

	protected readonly string qfZjeMolyPvbMVjcEestZDAdYsUH;

	private HIDDeviceDriver CnvfByEBtnFMTnkHUXeKXeZmenKs;

	protected Controller.Extension sxIZEtgOGuBRzhURyFOIEYWiCfbeB;

	private bool diWnuvzfCagrFjuwIwDsHoqUngjcA;

	private string lofWLyELMbQbCRudRERwVGtpfEzfA;

	private string FkwqyYPNxIhkMyLNQlsdsgyccQCz;

	private string lYWIYfPNXOMSCJDbJugkYLRYvwcF;

	private bool NBilHDfZybTkfWOOkmsqVMZwTpam;

	private bool OGeEJXQvEmsbDoXzwilCjxdQtMum;

	private bool VRYAEtrewQgUQjWJTeQUyDNdhcuR;

	rtcpRxBVLKAMkXCloKUnYbCBcUfE JewImaRENcAhriGkgPvGEgPfnJHyb.IMnQrWwmjOrMJOpkYIBxGzJAmxkgA => TWGOZcGJKFXPgIhUkErFGomRgavIA;

	IntPtr JewImaRENcAhriGkgPvGEgPfnJHyb.RdBPumndyiTIaxpKvywIPlRdSDeQ => UqQyKLlDTeDrRHmqMSqgrHCgiyhkA;

	string JewImaRENcAhriGkgPvGEgPfnJHyb.VhebEQKXpmCJgYSzUThqlsfqMoVkA
	{
		get
		{
			if (!string.IsNullOrEmpty(lofWLyELMbQbCRudRERwVGtpfEzfA))
			{
				return lofWLyELMbQbCRudRERwVGtpfEzfA;
			}
			lofWLyELMbQbCRudRERwVGtpfEzfA = TWGOZcGJKFXPgIhUkErFGomRgavIA.TkHKclWfPhnYOjxqnRTTyacPRLEE();
			if (string.IsNullOrEmpty(lofWLyELMbQbCRudRERwVGtpfEzfA))
			{
				lofWLyELMbQbCRudRERwVGtpfEzfA = "Unknown";
			}
			return lofWLyELMbQbCRudRERwVGtpfEzfA;
		}
	}

	string JewImaRENcAhriGkgPvGEgPfnJHyb.KGKfSGfhihPoTaTvZpYhkVDulWsxA
	{
		get
		{
			if (NBilHDfZybTkfWOOkmsqVMZwTpam)
			{
				return FkwqyYPNxIhkMyLNQlsdsgyccQCz;
			}
			FkwqyYPNxIhkMyLNQlsdsgyccQCz = TWGOZcGJKFXPgIhUkErFGomRgavIA.xMcTFUYAXWDfLmbIiyTYsXSwPBPv();
			NBilHDfZybTkfWOOkmsqVMZwTpam = true;
			return FkwqyYPNxIhkMyLNQlsdsgyccQCz;
		}
	}

	int JewImaRENcAhriGkgPvGEgPfnJHyb.ZmTpVjBHdSymNuhkHzqHwAFRNBHe => AlBVmvJJYmRfcqQNQJJdYWJXLrnI;

	int JewImaRENcAhriGkgPvGEgPfnJHyb.ZPmGRXCxBEwOQOdOWCuUXGtyzwneA => ziqenAVCYrdsqCmCwCRSiqtVHwHJ;

	Guid JewImaRENcAhriGkgPvGEgPfnJHyb.vSXXdZFcWHtbAwOjUQJqVgkyjHVT => GrGwgJZrZiBXCXpmdRnCvdtETKdN;

	Guid JewImaRENcAhriGkgPvGEgPfnJHyb.phjbIzJwpfaHndTsqJBOtHvTTudeA => PqmiUnfeFlHEuaRzGTrvlomFUuouA;

	DeviceType JewImaRENcAhriGkgPvGEgPfnJHyb.ghGDQestAGYUNKYdRaWNXafVGvwI => DpEhBdPMTUaeTKAFVMsHJRzqoSfBb;

	bool JewImaRENcAhriGkgPvGEgPfnJHyb.RYehePePOJhoDoBdQdzwgDtYfmccb => TWGOZcGJKFXPgIhUkErFGomRgavIA.PDGRktVJzyNVWHKUFtkHtKXJdthcA;

	string JewImaRENcAhriGkgPvGEgPfnJHyb.WBMgidYMSTZBedYHaRzndjzWWXzi => TWGOZcGJKFXPgIhUkErFGomRgavIA.VrYDeizNDCscbiYsEwezldnkeZZb;

	int JewImaRENcAhriGkgPvGEgPfnJHyb.CcFjusiPCDrcqAdueYjvoynTMnAl => TWGOZcGJKFXPgIhUkErFGomRgavIA.DxJLaDuMAYGMSDLcbvCpJFIKarNU;

	int JewImaRENcAhriGkgPvGEgPfnJHyb.TGDnMXhNOFSHvAzlRqbwVGKVbpGL => TWGOZcGJKFXPgIhUkErFGomRgavIA.tHBcnhBMhZrpBzoHKEjVpxJXoBME;

	string JewImaRENcAhriGkgPvGEgPfnJHyb.WGVcseBuHNOxlhHmrKTuEgZVlKQjA
	{
		get
		{
			if (OGeEJXQvEmsbDoXzwilCjxdQtMum)
			{
				return lYWIYfPNXOMSCJDbJugkYLRYvwcF;
			}
			lYWIYfPNXOMSCJDbJugkYLRYvwcF = GfUbVnmkDMGOixRoVBcgiAJcaCppA.hjiUIbMcAixefItPwKEhMmwPspqH(TWGOZcGJKFXPgIhUkErFGomRgavIA, GrGwgJZrZiBXCXpmdRnCvdtETKdN, VhebEQKXpmCJgYSzUThqlsfqMoVkA, WBMgidYMSTZBedYHaRzndjzWWXzi);
			OGeEJXQvEmsbDoXzwilCjxdQtMum = true;
			return lYWIYfPNXOMSCJDbJugkYLRYvwcF;
		}
	}

	HIDDeviceDriver JewImaRENcAhriGkgPvGEgPfnJHyb.EsivdIFkKegfviNHPBmLeAzWGwWCb
	{
		get
		{
			return CnvfByEBtnFMTnkHUXeKXeZmenKs;
		}
		protected set
		{
			if (CnvfByEBtnFMTnkHUXeKXeZmenKs != null)
			{
				CnvfByEBtnFMTnkHUXeKXeZmenKs.ErrorEvent -= pLrQtjcpoWJMYEwiCKqCzTSoinzc;
			}
			CnvfByEBtnFMTnkHUXeKXeZmenKs = cnvfByEBtnFMTnkHUXeKXeZmenKs;
			if (CnvfByEBtnFMTnkHUXeKXeZmenKs != null)
			{
				CnvfByEBtnFMTnkHUXeKXeZmenKs.ErrorEvent += pLrQtjcpoWJMYEwiCKqCzTSoinzc;
			}
		}
	}

	Controller.Extension JewImaRENcAhriGkgPvGEgPfnJHyb.poehLVjxTCUmWJulNQWVVDEBfczr => sxIZEtgOGuBRzhURyFOIEYWiCfbeB;

	virtual bool JewImaRENcAhriGkgPvGEgPfnJHyb.UKYpYtGSFXwPyzhtganWoERsyXVS
	{
		get
		{
			if (!VRYAEtrewQgUQjWJTeQUyDNdhcuR)
			{
				return !diWnuvzfCagrFjuwIwDsHoqUngjcA;
			}
			return false;
		}
	}

	public aXEbFpKsqcSHoCCKoyagkbJjWwXs(rtcpRxBVLKAMkXCloKUnYbCBcUfE P_0, IntPtr P_1)
	{
		TWGOZcGJKFXPgIhUkErFGomRgavIA = P_0;
		UqQyKLlDTeDrRHmqMSqgrHCgiyhkA = P_1;
		DpEhBdPMTUaeTKAFVMsHJRzqoSfBb = mWJeTWNgWzBJYJhWNjbVXUqkZBM((ushort)P_0.JuBzyupRnChnVoqFgGehMxJGZJqC.HFQlMhnHnhNAVzmIloAhwpeYEtvCA, (ushort)P_0.JuBzyupRnChnVoqFgGehMxJGZJqC.AhJAPyxVgqBvfsytfXQWrPiqjOAh);
		AlBVmvJJYmRfcqQNQJJdYWJXLrnI = P_0.xaViLQBiNdhAdIPbDaUpnSEAtzhhb.sPsgOeEHjUuDSbqwDjyrcGuuxCmp;
		ziqenAVCYrdsqCmCwCRSiqtVHwHJ = P_0.xaViLQBiNdhAdIPbDaUpnSEAtzhhb.LCTzDFJEdFVsYydVYLvaUqXdjALG;
		qfZjeMolyPvbMVjcEestZDAdYsUH = P_0.wDgetvIfUbaQhPZiMhgLSDFeqjXC();
		GrGwgJZrZiBXCXpmdRnCvdtETKdN = MiscTools.CreateHIDProductGuid(AlBVmvJJYmRfcqQNQJJdYWJXLrnI, ziqenAVCYrdsqCmCwCRSiqtVHwHJ);
		PqmiUnfeFlHEuaRzGTrvlomFUuouA = MiscTools.CreateGuidHashSHA1(TWGOZcGJKFXPgIhUkErFGomRgavIA.kxwmpqIuDwCMlsafPZagruVINgbi);
		sxIZEtgOGuBRzhURyFOIEYWiCfbeB = new RawInputControllerExtension(this);
	}

	public void iexDgxeoQnIGfMnDRSmDaUdrkFwI(IntPtr P_0)
	{
		UqQyKLlDTeDrRHmqMSqgrHCgiyhkA = P_0;
	}

	void JewImaRENcAhriGkgPvGEgPfnJHyb.iexDgxeoQnIGfMnDRSmDaUdrkFwI(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in iexDgxeoQnIGfMnDRSmDaUdrkFwI
		this.iexDgxeoQnIGfMnDRSmDaUdrkFwI(P_0);
	}

	public virtual void oUGLWJITioIxFVgdbnYybUYSCEUf(UpdateLoopType P_0)
	{
		if (CnvfByEBtnFMTnkHUXeKXeZmenKs != null)
		{
			CnvfByEBtnFMTnkHUXeKXeZmenKs.Update(P_0);
		}
	}

	void JewImaRENcAhriGkgPvGEgPfnJHyb.oUGLWJITioIxFVgdbnYybUYSCEUf(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in oUGLWJITioIxFVgdbnYybUYSCEUf
		this.oUGLWJITioIxFVgdbnYybUYSCEUf(P_0);
	}

	public abstract void PcawPdVcHvbirAoMFyDeENYohyAr();

	private void pLrQtjcpoWJMYEwiCKqCzTSoinzc(HIDDeviceDriver.DnxCacaTXSZEpeSgtDxoenPsQrOsA P_0)
	{
		if (HIDDeviceDriver.IsCriticalError(P_0))
		{
			diWnuvzfCagrFjuwIwDsHoqUngjcA = true;
		}
	}

	public void Dispose()
	{
		jYhjbyxpcwQaUEZExsoOuuYeWHof(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void SDVfBxHbXFwcGcTUsVXzWlGjryfF()
	{
		try
		{
			jYhjbyxpcwQaUEZExsoOuuYeWHof(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void jYhjbyxpcwQaUEZExsoOuuYeWHof(bool P_0)
	{
		if (VRYAEtrewQgUQjWJTeQUyDNdhcuR)
		{
			return;
		}
		if (P_0)
		{
			if (CnvfByEBtnFMTnkHUXeKXeZmenKs != null)
			{
				CnvfByEBtnFMTnkHUXeKXeZmenKs.ErrorEvent -= pLrQtjcpoWJMYEwiCKqCzTSoinzc;
				CnvfByEBtnFMTnkHUXeKXeZmenKs.Dispose();
			}
			if (TWGOZcGJKFXPgIhUkErFGomRgavIA != null)
			{
				TWGOZcGJKFXPgIhUkErFGomRgavIA.Dispose();
			}
		}
		VRYAEtrewQgUQjWJTeQUyDNdhcuR = true;
	}

	private static DeviceType mWJeTWNgWzBJYJhWNjbVXUqkZBM(ushort P_0, ushort P_1)
	{
		if (P_0 != 1)
		{
			return DeviceType.Unknown;
		}
		return P_1 switch
		{
			4 => DeviceType.Joystick, 
			5 => DeviceType.Gamepad, 
			6 => DeviceType.Keyboard, 
			2 => DeviceType.Mouse, 
			8 => DeviceType.MultiAxisController, 
			_ => DeviceType.Unknown, 
		};
	}

	public abstract void vxAebkHmVZCbhNjZXXsFPZJWBHOK();

	public abstract void LFubPekUlWjjnGGXgCSBpgQpWoqvB();

	public abstract bool YVlvuueoRIuPGvVVtTYKYiZFwCbI();
}
