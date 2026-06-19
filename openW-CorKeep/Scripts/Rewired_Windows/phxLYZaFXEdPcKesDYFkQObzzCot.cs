using System;
using Rewired;

internal static class phxLYZaFXEdPcKesDYFkQObzzCot
{
	public enum hNNROXhqMIYjPazjcNjuONAGtcYK
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct TalPNgjLORilpixeqmJeZgKEDVeHA
	{
		public enum TnQjGMjyQBAAiLxONexpHFRgsuZh
		{
			MatchAnyOption = 0,
			MatchAllOptions = 1,
			IgnoreOptions = 2
		}

		public PidVid YArbvweOzlAkzQtoUZVHjNNdobFN;

		public NaHcSyBcuEUglAJrulvAbOKAstXr QmIUoiqsNeoMecmAoICrNuWlLShf;

		public TnQjGMjyQBAAiLxONexpHFRgsuZh ekQLcSsqIbHrnQcznIjcJIvlzDdc;

		public TalPNgjLORilpixeqmJeZgKEDVeHA(PidVid P_0, NaHcSyBcuEUglAJrulvAbOKAstXr P_1, TnQjGMjyQBAAiLxONexpHFRgsuZh P_2)
		{
			YArbvweOzlAkzQtoUZVHjNNdobFN = P_0;
			QmIUoiqsNeoMecmAoICrNuWlLShf = P_1;
			ekQLcSsqIbHrnQcznIjcJIvlzDdc = P_2;
		}

		public bool eWrUivlTFWdDgKyOjBeWqEGgayZw(ushort P_0, ushort P_1, NaHcSyBcuEUglAJrulvAbOKAstXr P_2)
		{
			if (YArbvweOzlAkzQtoUZVHjNNdobFN.vendorId != P_0)
			{
				return false;
			}
			if (YArbvweOzlAkzQtoUZVHjNNdobFN.productId != P_1)
			{
				return false;
			}
			return ekQLcSsqIbHrnQcznIjcJIvlzDdc switch
			{
				TnQjGMjyQBAAiLxONexpHFRgsuZh.MatchAnyOption => (QmIUoiqsNeoMecmAoICrNuWlLShf & P_2) != 0, 
				TnQjGMjyQBAAiLxONexpHFRgsuZh.MatchAllOptions => QmIUoiqsNeoMecmAoICrNuWlLShf == P_2, 
				TnQjGMjyQBAAiLxONexpHFRgsuZh.IgnoreOptions => true, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public enum NaHcSyBcuEUglAJrulvAbOKAstXr
	{
		None = 0,
		Bluetooth = 1,
		USB = 2
	}

	private static Guid[] ncbkJhppzBBCMczOMVJZIUYOpkwf = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] WqpaIXHvHGRfSSQRiioXDMlHAUCnb = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string qYtRENfdfMMwqkevxuHdBtnajeiZ = ".*xbox[ \\-]one.*";

	private static readonly TalPNgjLORilpixeqmJeZgKEDVeHA[] XUCCYuBvLKwCMtemRTmLnYgoRqZLA = new TalPNgjLORilpixeqmJeZgKEDVeHA[1]
	{
		new TalPNgjLORilpixeqmJeZgKEDVeHA(new PidVid(8201, 1406), NaHcSyBcuEUglAJrulvAbOKAstXr.USB, TalPNgjLORilpixeqmJeZgKEDVeHA.TnQjGMjyQBAAiLxONexpHFRgsuZh.MatchAnyOption)
	};

	public static string WtVgDZcKWifevVrRwilhIQKEQwlfb(UuHCwHDuNGaBmByAoDpveWFIGyeGb P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return TEpWywsZzBcWSmczbCzhGECmHxuI(P_0.inoMiMYgwnsDaglQuqVZkMRSEScT, P_1, P_2, P_3) switch
		{
			hNNROXhqMIYjPazjcNjuONAGtcYK.CombinedTriggers => "[CombinedTriggers]", 
			hNNROXhqMIYjPazjcNjuONAGtcYK.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static hNNROXhqMIYjPazjcNjuONAGtcYK TEpWywsZzBcWSmczbCzhGECmHxuI(DtPrmXkrmceARDZkilDczGXmWArk[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!ayJarqrimvwEytJIXJSHdGACeykfA(P_1, P_2, P_3))
		{
			return hNNROXhqMIYjPazjcNjuONAGtcYK.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].qfRGRzSiRSmxYPNyjOHhZQLpuZl == 1 && !P_0[i].tFJaWObWchlqAhXmcyFbbxofzPGGA && P_0[i].jeOCDPGIcWuUuRzFNoiEWwbBONEsA.jIskKzoourGOJquzigzHFXdmHRNE == 53)
			{
				return hNNROXhqMIYjPazjcNjuONAGtcYK.SplitTriggers;
			}
		}
		return hNNROXhqMIYjPazjcNjuONAGtcYK.CombinedTriggers;
	}

	public static bool ayJarqrimvwEytJIXJSHdGACeykfA(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(ncbkJhppzBBCMczOMVJZIUYOpkwf, P_0) >= 0)
		{
			return true;
		}
		if (KbxyJjgCuBQvDQJSzTYffJdmAFGm(P_1))
		{
			return true;
		}
		if (KbxyJjgCuBQvDQJSzTYffJdmAFGm(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool KbxyJjgCuBQvDQJSzTYffJdmAFGm(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < WqpaIXHvHGRfSSQRiioXDMlHAUCnb.Length; i++)
		{
			if (WqpaIXHvHGRfSSQRiioXDMlHAUCnb[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool XhDVEHkaYdfdRoDEaWPBndRzzedc(InputSource P_0, ushort P_1, ushort P_2, NaHcSyBcuEUglAJrulvAbOKAstXr P_3)
	{
		if (P_0 == InputSource.DirectInput || P_0 == InputSource.RawInput)
		{
			for (int i = 0; i < XUCCYuBvLKwCMtemRTmLnYgoRqZLA.Length; i++)
			{
				if (XUCCYuBvLKwCMtemRTmLnYgoRqZLA[i].eWrUivlTFWdDgKyOjBeWqEGgayZw(P_1, P_2, P_3))
				{
					return true;
				}
			}
		}
		return false;
	}
}
