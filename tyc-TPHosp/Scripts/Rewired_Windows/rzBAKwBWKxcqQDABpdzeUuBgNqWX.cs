using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class rzBAKwBWKxcqQDABpdzeUuBgNqWX : IDisposable, IUnifiedKeyboardSource
{
	private class CpYFMCcdGoSEfnFowtRuZXhpmSa
	{
		private enum AgZExIwMJnxEtDVZqYLPzmVfJJc
		{
			XzhcXffXatYTRpTiRyDKgAvaprhV = 0,
			JlAKOWbcGyryFSDRaRoBRFtbIwV = 1,
			wUOlBsBaDAPtNloIYFfHeCWVNHe = 2
		}

		private const int ZfgIvDHAkgZajWGUZmUVnPHyScsk = 2;

		private static readonly KeyCode[] cEdOshEOhIistyPrusgEciaSLiD = new KeyCode[2];

		private readonly UpdateLoopType cELogrLUBvFlsKPopQTmofzNoqD;

		private bool[] hXZfgNUGfrDgcUkgLoCkSelVbNM;

		private bool[] SiVEinePJYwMTSBejaholjdYUGQn;

		private uint hfvhGVyOKRikzTjduiFghOZcHbGK;

		public CpYFMCcdGoSEfnFowtRuZXhpmSa(UpdateLoopType updateLoop)
		{
			cELogrLUBvFlsKPopQTmofzNoqD = updateLoop;
			hXZfgNUGfrDgcUkgLoCkSelVbNM = new bool[132];
			SiVEinePJYwMTSBejaholjdYUGQn = new bool[132];
		}

		public void ZwDhEUIRIissJLnFaGZCySURjdme(joIDPhdLsQJpsETSRAVogyJSANzE P_0)
		{
			int num = EJCeIreryoKQtXNRjmnpHekfzcM(P_0, cEdOshEOhIistyPrusgEciaSLiD);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)cEdOshEOhIistyPrusgEciaSLiD[i];
				if (num2 >= 0 && num2 < TJrhHbJGKrNDUmumDbbmRymZIJb.Length)
				{
					nIOQtGWwNgFUxaTsaZVmrvCuWsi dFNxfROGNaOFVytsVSPLipImjPV = P_0.dFNxfROGNaOFVytsVSPLipImjPV;
					nIOQtGWwNgFUxaTsaZVmrvCuWsi nIOQtGWwNgFUxaTsaZVmrvCuWsi2 = dFNxfROGNaOFVytsVSPLipImjPV;
					bool flag = ((nIOQtGWwNgFUxaTsaZVmrvCuWsi2 == nIOQtGWwNgFUxaTsaZVmrvCuWsi.NMBwYStqUhDhOAzmyDzjKHvfTPL || nIOQtGWwNgFUxaTsaZVmrvCuWsi2 == nIOQtGWwNgFUxaTsaZVmrvCuWsi.REylYSdzRqEjYfzhpThkUhvYItv) ? true : false);
					int num3 = TJrhHbJGKrNDUmumDbbmRymZIJb[num2];
					bool flag2 = hXZfgNUGfrDgcUkgLoCkSelVbNM[num3];
					hXZfgNUGfrDgcUkgLoCkSelVbNM[num3] = flag;
					if (!flag2 && flag)
					{
						SiVEinePJYwMTSBejaholjdYUGQn[num3] = true;
					}
				}
			}
		}

		public void QJikxZSCKXGTYwxWGSqzPgTltrl(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = hXZfgNUGfrDgcUkgLoCkSelVbNM[i] || SiVEinePJYwMTSBejaholjdYUGQn[i];
			}
			lkhSqaPojUpwozirzLtjaaEURgV();
		}

		public void gXADYrdzIttymTRoaKqLkIyUtDJ()
		{
			lkhSqaPojUpwozirzLtjaaEURgV();
		}

		private void lkhSqaPojUpwozirzLtjaaEURgV()
		{
			if (hfvhGVyOKRikzTjduiFghOZcHbGK != ReInput.absFrame)
			{
				ZhHsKlVDGKijXaeHFWinJZANINf();
				hfvhGVyOKRikzTjduiFghOZcHbGK = ReInput.absFrame;
			}
		}

		public void ZhHsKlVDGKijXaeHFWinJZANINf()
		{
			Array.Clear(SiVEinePJYwMTSBejaholjdYUGQn, 0, 132);
		}

		public void IgqBTMgoLLDsubFJdJZiejmTNfb()
		{
			Array.Clear(hXZfgNUGfrDgcUkgLoCkSelVbNM, 0, 132);
			Array.Clear(SiVEinePJYwMTSBejaholjdYUGQn, 0, 132);
		}
	}

	private const int xsBkIcjGHsHiphaUjsISnyqyZpBK = 132;

	private const int dpaUbRqqWhneESexHHuQVuBgmph = 256;

	private readonly object WfTbITFnDgahnloEWtIracmCfqy = new object();

	private UpdateLoopDataSet<CpYFMCcdGoSEfnFowtRuZXhpmSa> wObfRIyUgeboVabiJskVEuDuVsf;

	private HardwareControllerMap_Game uImkRkkxDCalFMiAimazUBVGBBs;

	private bool NZFfxmeonndzgZSGBLcYGSBmvlqA;

	private int pdkhzpzGZhGxcEDtNwUcLlpjXdzL;

	private bool[] OwNYwudLjnTpPDczNDwQaLJtFWSe = new bool[256];

	private readonly joIDPhdLsQJpsETSRAVogyJSANzE GtcOaZxqZPwKMHpeYOUmNZyEJka = new joIDPhdLsQJpsETSRAVogyJSANzE();

	private static readonly int[] TJrhHbJGKrNDUmumDbbmRymZIJb;

	private static readonly int RUIRouuHsgxAynpEwhoSsuSGxrB;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	private static IntPtr RIpdFKYlqhdGJnoAmecvmLYXtQz;

	private static LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL JwucMnERulgtbvkyUTVdYLfOCTyE;

	private static readonly int[] WnGfipwyhmQCpWrTxjBxiwRwhLO;

	private static Dictionary<int, Dictionary<int, KeyCode>> yeCxjQlqGNJzDLsCclbEzoYprII;

	private static readonly int[] ADEGHmrHREKxklbSSocWFonvaCe;

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (uImkRkkxDCalFMiAimazUBVGBBs == null)
			{
				uImkRkkxDCalFMiAimazUBVGBBs = sJDPNLgjzdbpLHncpwmaDsgHkAGK();
			}
			return uImkRkkxDCalFMiAimazUBVGBBs;
		}
	}

	public int buttonCount => 132;

	public Controller.Extension controllerExtension => null;

	static rzBAKwBWKxcqQDABpdzeUuBgNqWX()
	{
		JwucMnERulgtbvkyUTVdYLfOCTyE = LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL.tsUFrPinAvzjFWhbcuuVSDfZoNya;
		WnGfipwyhmQCpWrTxjBxiwRwhLO = (int[])Enum.GetValues(typeof(LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL));
		yeCxjQlqGNJzDLsCclbEzoYprII = new Dictionary<int, Dictionary<int, KeyCode>>
		{
			{
				1033,
				new Dictionary<int, KeyCode>
				{
					{
						222,
						KeyCode.Quote
					},
					{
						188,
						KeyCode.Comma
					},
					{
						189,
						KeyCode.Minus
					},
					{
						190,
						KeyCode.Period
					},
					{
						191,
						KeyCode.Slash
					},
					{
						186,
						KeyCode.Semicolon
					},
					{
						187,
						KeyCode.Equals
					},
					{
						219,
						KeyCode.LeftBracket
					},
					{
						220,
						KeyCode.Backslash
					},
					{
						221,
						KeyCode.RightBracket
					},
					{
						192,
						KeyCode.BackQuote
					},
					{
						223,
						KeyCode.BackQuote
					}
				}
			},
			{
				2057,
				new Dictionary<int, KeyCode>
				{
					{
						223,
						KeyCode.BackQuote
					},
					{
						192,
						KeyCode.Quote
					}
				}
			},
			{
				1106,
				new Dictionary<int, KeyCode>
				{
					{
						223,
						KeyCode.BackQuote
					},
					{
						192,
						KeyCode.Quote
					}
				}
			},
			{
				1031,
				new Dictionary<int, KeyCode>
				{
					{
						219,
						KeyCode.Backslash
					},
					{
						221,
						KeyCode.BackQuote
					}
				}
			}
		};
		ADEGHmrHREKxklbSSocWFonvaCe = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > RUIRouuHsgxAynpEwhoSsuSGxrB)
			{
				RUIRouuHsgxAynpEwhoSsuSGxrB = keyboardKeyValues[i];
			}
		}
		TJrhHbJGKrNDUmumDbbmRymZIJb = new int[RUIRouuHsgxAynpEwhoSsuSGxrB + 1];
		ArrayTools.Fill(TJrhHbJGKrNDUmumDbbmRymZIJb, -1);
		for (int j = 0; j < num; j++)
		{
			TJrhHbJGKrNDUmumDbbmRymZIJb[keyboardKeyValues[j]] = j;
		}
	}

	public rzBAKwBWKxcqQDABpdzeUuBgNqWX(UpdateLoopSetting updateLoopSetting)
	{
		SZShoeMiCJBaWBovCsXUKZcZgHus();
		wObfRIyUgeboVabiJskVEuDuVsf = new UpdateLoopDataSet<CpYFMCcdGoSEfnFowtRuZXhpmSa>(updateLoopSetting);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				wObfRIyUgeboVabiJskVEuDuVsf[i] = new CpYFMCcdGoSEfnFowtRuZXhpmSa(list[i]);
			}
		}
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		ReInput.ApplicationFocusChangedEvent += MPSJQoWnSijXncKIXuiQSTBnhmc;
		ReInput.EditorPauseChangedEvent += PjiHnEoBRQcgyItzJsIZJxSsMWju;
		ReInput.UpdateEndedEvent += qeAqePgMOUVKyWtOWYbIquUtaoU;
		ReInput.TimeScalePauseChangedEvent += xfiaNOwwuOeHRWmHbfrJXTlNhjb;
	}

	public unsafe void CWncwVbJhTWISMonvIVEimpDcKXc(UpdateLoopType P_0)
	{
		wObfRIyUgeboVabiJskVEuDuVsf.SetUpdateLoop(P_0);
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!HuTamtUgOYxfCNLWEcbrfgTfOVKO.iWnAybzvBLsyVukVqBUEgSnScxg((IntPtr)ptr))
				{
					return;
				}
				for (int i = 0; i < 256; i++)
				{
					switch (i)
					{
					case 1:
					case 2:
					case 4:
					case 5:
					case 6:
					case 16:
					case 17:
					case 18:
					case 65536:
					case 131072:
						continue;
					}
					if ((ptr[i] & 0x80) == 0)
					{
						if (OwNYwudLjnTpPDczNDwQaLJtFWSe[i])
						{
							GtcOaZxqZPwKMHpeYOUmNZyEJka.wCHMeVtmpfgnaDbZjXJYwQMfteN();
							GtcOaZxqZPwKMHpeYOUmNZyEJka.ijHkQHjOcOYoYhIOMWrPdUZbPdN = ReInput.realTime;
							GtcOaZxqZPwKMHpeYOUmNZyEJka.WCOCwqyfkjnBUIRfGRcBnsMqqvP = IntPtr.Zero;
							GtcOaZxqZPwKMHpeYOUmNZyEJka.ZCjhUSPqfoiPALEAEbozQexULrN = (rOQkeCDskVeDzgLRpzQFVuTjxqY)i;
							GtcOaZxqZPwKMHpeYOUmNZyEJka.jhOkAPKaoXhvvByLVxYIdDWfdxM = 0;
							GtcOaZxqZPwKMHpeYOUmNZyEJka.ujDJpjShnAhMpvbrxlInidiwNxY = hPpgKTejsVKbpVsRUJXHvsAaNAN.KsXGoXAiiLbfvrRpHnEmjeqFkKEi;
							GtcOaZxqZPwKMHpeYOUmNZyEJka.dFNxfROGNaOFVytsVSPLipImjPV = nIOQtGWwNgFUxaTsaZVmrvCuWsi.jpAffRhyXRIiDiTZAWQBLcHFxVOH;
							GtcOaZxqZPwKMHpeYOUmNZyEJka.zPDZwOqaXKkklzSEgoGlfgCvovF = 0;
							oFXcnfERNBuhmyELcTDiktBteqh(GtcOaZxqZPwKMHpeYOUmNZyEJka);
						}
					}
					else if (!OwNYwudLjnTpPDczNDwQaLJtFWSe[i])
					{
						GtcOaZxqZPwKMHpeYOUmNZyEJka.wCHMeVtmpfgnaDbZjXJYwQMfteN();
						GtcOaZxqZPwKMHpeYOUmNZyEJka.ijHkQHjOcOYoYhIOMWrPdUZbPdN = ReInput.realTime;
						GtcOaZxqZPwKMHpeYOUmNZyEJka.WCOCwqyfkjnBUIRfGRcBnsMqqvP = IntPtr.Zero;
						GtcOaZxqZPwKMHpeYOUmNZyEJka.ZCjhUSPqfoiPALEAEbozQexULrN = (rOQkeCDskVeDzgLRpzQFVuTjxqY)i;
						GtcOaZxqZPwKMHpeYOUmNZyEJka.jhOkAPKaoXhvvByLVxYIdDWfdxM = 0;
						GtcOaZxqZPwKMHpeYOUmNZyEJka.ujDJpjShnAhMpvbrxlInidiwNxY = hPpgKTejsVKbpVsRUJXHvsAaNAN.cnYKCoPGaynDOPVZUilkfGbvOrX;
						GtcOaZxqZPwKMHpeYOUmNZyEJka.dFNxfROGNaOFVytsVSPLipImjPV = nIOQtGWwNgFUxaTsaZVmrvCuWsi.NMBwYStqUhDhOAzmyDzjKHvfTPL;
						GtcOaZxqZPwKMHpeYOUmNZyEJka.zPDZwOqaXKkklzSEgoGlfgCvovF = 0;
						oFXcnfERNBuhmyELcTDiktBteqh(GtcOaZxqZPwKMHpeYOUmNZyEJka);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void oFXcnfERNBuhmyELcTDiktBteqh(joIDPhdLsQJpsETSRAVogyJSANzE P_0)
	{
		if (!NZFfxmeonndzgZSGBLcYGSBmvlqA)
		{
			return;
		}
		switch (P_0.ZCjhUSPqfoiPALEAEbozQexULrN)
		{
		case rOQkeCDskVeDzgLRpzQFVuTjxqY.jxeEVYhDBnAYicEBoeyQnOUpSNzD:
		{
			rOQkeCDskVeDzgLRpzQFVuTjxqY rOQkeCDskVeDzgLRpzQFVuTjxqY2 = (rOQkeCDskVeDzgLRpzQFVuTjxqY)HuTamtUgOYxfCNLWEcbrfgTfOVKO.RBdbNfRPligZYFUoycCeEOkEdxM((uint)P_0.jhOkAPKaoXhvvByLVxYIdDWfdxM, LDLICyXLtzNtgKlsBEQDDyrjfaq.geEcNeZyNKGLDDpOOpkYlFmNjAAg);
			if (rOQkeCDskVeDzgLRpzQFVuTjxqY2 != rOQkeCDskVeDzgLRpzQFVuTjxqY.KENIeTDgZOdepFGQVDXuOMWWrEh && rOQkeCDskVeDzgLRpzQFVuTjxqY2 != rOQkeCDskVeDzgLRpzQFVuTjxqY.gMQPbKQjcjEJcpwkiXVSxkTogCo)
			{
				return;
			}
			P_0.ZCjhUSPqfoiPALEAEbozQexULrN = (((P_0.ujDJpjShnAhMpvbrxlInidiwNxY & hPpgKTejsVKbpVsRUJXHvsAaNAN.iraaVecMIBKQuyBRdWNBOaVPOMf) != hPpgKTejsVKbpVsRUJXHvsAaNAN.cnYKCoPGaynDOPVZUilkfGbvOrX) ? rOQkeCDskVeDzgLRpzQFVuTjxqY.gMQPbKQjcjEJcpwkiXVSxkTogCo : rOQkeCDskVeDzgLRpzQFVuTjxqY.KENIeTDgZOdepFGQVDXuOMWWrEh);
			break;
		}
		case rOQkeCDskVeDzgLRpzQFVuTjxqY.CvQVajlANQUaiXTKhBJCNoYeuof:
			P_0.ZCjhUSPqfoiPALEAEbozQexULrN = (((P_0.ujDJpjShnAhMpvbrxlInidiwNxY & hPpgKTejsVKbpVsRUJXHvsAaNAN.iraaVecMIBKQuyBRdWNBOaVPOMf) != hPpgKTejsVKbpVsRUJXHvsAaNAN.cnYKCoPGaynDOPVZUilkfGbvOrX) ? rOQkeCDskVeDzgLRpzQFVuTjxqY.VbVwePzWNOoRkPlHqAKnqmCXECE : rOQkeCDskVeDzgLRpzQFVuTjxqY.ySZBjocskGujmWEctpODKDxjyxT);
			break;
		case rOQkeCDskVeDzgLRpzQFVuTjxqY.VVNoiAoXXENsDrQZpnrfKjMsCzF:
		{
			P_0.ZCjhUSPqfoiPALEAEbozQexULrN = (rOQkeCDskVeDzgLRpzQFVuTjxqY)HuTamtUgOYxfCNLWEcbrfgTfOVKO.RBdbNfRPligZYFUoycCeEOkEdxM((uint)P_0.jhOkAPKaoXhvvByLVxYIdDWfdxM, LDLICyXLtzNtgKlsBEQDDyrjfaq.geEcNeZyNKGLDDpOOpkYlFmNjAAg);
			if (P_0.ZCjhUSPqfoiPALEAEbozQexULrN == rOQkeCDskVeDzgLRpzQFVuTjxqY.sGbTCdBJDBDENPSTGVSMfXSUtEu || P_0.ZCjhUSPqfoiPALEAEbozQexULrN == rOQkeCDskVeDzgLRpzQFVuTjxqY.sYugGMppqdoGhjuQnHXjUIRcFqK)
			{
				break;
			}
			nIOQtGWwNgFUxaTsaZVmrvCuWsi dFNxfROGNaOFVytsVSPLipImjPV = P_0.dFNxfROGNaOFVytsVSPLipImjPV;
			bool flag = ((dFNxfROGNaOFVytsVSPLipImjPV == nIOQtGWwNgFUxaTsaZVmrvCuWsi.NMBwYStqUhDhOAzmyDzjKHvfTPL || dFNxfROGNaOFVytsVSPLipImjPV == nIOQtGWwNgFUxaTsaZVmrvCuWsi.REylYSdzRqEjYfzhpThkUhvYItv || dFNxfROGNaOFVytsVSPLipImjPV == nIOQtGWwNgFUxaTsaZVmrvCuWsi.NxaWvbBDBLyhrUfrzPjuIFZGKoy) ? true : false);
			bool flag2 = (HuTamtUgOYxfCNLWEcbrfgTfOVKO.gyquWDavfugAPRFDMYuAFdjgyqU(160) & 0x8000) != 0;
			bool flag3 = (HuTamtUgOYxfCNLWEcbrfgTfOVKO.gyquWDavfugAPRFDMYuAFdjgyqU(161) & 0x8000) != 0;
			if (flag)
			{
				bool flag4 = (HuTamtUgOYxfCNLWEcbrfgTfOVKO.LqWtFRtRQeHkUXWsiPERsYZmvRK(160) & 0x8000) != 0;
				bool flag5 = (HuTamtUgOYxfCNLWEcbrfgTfOVKO.LqWtFRtRQeHkUXWsiPERsYZmvRK(161) & 0x8000) != 0;
				if (flag4)
				{
					P_0.ZCjhUSPqfoiPALEAEbozQexULrN = rOQkeCDskVeDzgLRpzQFVuTjxqY.sGbTCdBJDBDENPSTGVSMfXSUtEu;
					oFXcnfERNBuhmyELcTDiktBteqh(P_0);
				}
				if (flag5)
				{
					P_0.ZCjhUSPqfoiPALEAEbozQexULrN = rOQkeCDskVeDzgLRpzQFVuTjxqY.sYugGMppqdoGhjuQnHXjUIRcFqK;
					oFXcnfERNBuhmyELcTDiktBteqh(P_0);
				}
				return;
			}
			if (flag2 && flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.ZCjhUSPqfoiPALEAEbozQexULrN = rOQkeCDskVeDzgLRpzQFVuTjxqY.sGbTCdBJDBDENPSTGVSMfXSUtEu;
				break;
			}
			if (flag3)
			{
				P_0.ZCjhUSPqfoiPALEAEbozQexULrN = rOQkeCDskVeDzgLRpzQFVuTjxqY.sYugGMppqdoGhjuQnHXjUIRcFqK;
				break;
			}
			P_0.ZCjhUSPqfoiPALEAEbozQexULrN = rOQkeCDskVeDzgLRpzQFVuTjxqY.sGbTCdBJDBDENPSTGVSMfXSUtEu;
			oFXcnfERNBuhmyELcTDiktBteqh(P_0);
			P_0.ZCjhUSPqfoiPALEAEbozQexULrN = rOQkeCDskVeDzgLRpzQFVuTjxqY.sYugGMppqdoGhjuQnHXjUIRcFqK;
			oFXcnfERNBuhmyELcTDiktBteqh(P_0);
			return;
		}
		}
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			nIOQtGWwNgFUxaTsaZVmrvCuWsi dFNxfROGNaOFVytsVSPLipImjPV2 = P_0.dFNxfROGNaOFVytsVSPLipImjPV;
			if (dFNxfROGNaOFVytsVSPLipImjPV2 == nIOQtGWwNgFUxaTsaZVmrvCuWsi.NMBwYStqUhDhOAzmyDzjKHvfTPL || dFNxfROGNaOFVytsVSPLipImjPV2 == nIOQtGWwNgFUxaTsaZVmrvCuWsi.REylYSdzRqEjYfzhpThkUhvYItv)
			{
				OwNYwudLjnTpPDczNDwQaLJtFWSe[(int)P_0.ZCjhUSPqfoiPALEAEbozQexULrN] = true;
			}
			else
			{
				OwNYwudLjnTpPDczNDwQaLJtFWSe[(int)P_0.ZCjhUSPqfoiPALEAEbozQexULrN] = false;
			}
			int count = wObfRIyUgeboVabiJskVEuDuVsf.Count;
			for (int i = 0; i < count; i++)
			{
				wObfRIyUgeboVabiJskVEuDuVsf[i].ZwDhEUIRIissJLnFaGZCySURjdme(P_0);
			}
		}
	}

	public void riSHQeDOIkBABkFvimBoHoVHLsiP(bool P_0)
	{
		JBaIltzmYFDAyRRCYXbgmOsWFgz();
	}

	public void EOfLvZeQNqcczljjrXLbjGczkeD(bool P_0)
	{
		int num = SZShoeMiCJBaWBovCsXUKZcZgHus();
		if (num < 0)
		{
			JBaIltzmYFDAyRRCYXbgmOsWFgz();
		}
	}

	private int SZShoeMiCJBaWBovCsXUKZcZgHus()
	{
		int num = pdkhzpzGZhGxcEDtNwUcLlpjXdzL;
		if (TnbctswGyXOsohdhCkTtNqIlEbQG.eijXNrPqAlSwVXFbujqixZhYUi(TNuYvFcSdWFqveHgvUhHbRntguj.bheAcljDHpoAOeHYhiVCoSJIEJwV, out var num2))
		{
			pdkhzpzGZhGxcEDtNwUcLlpjXdzL = num2;
		}
		else
		{
			pdkhzpzGZhGxcEDtNwUcLlpjXdzL = 1;
		}
		return pdkhzpzGZhGxcEDtNwUcLlpjXdzL - num;
	}

	private void MPSJQoWnSijXncKIXuiQSTBnhmc(bool P_0)
	{
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !NZFfxmeonndzgZSGBLcYGSBmvlqA)
		{
			JBaIltzmYFDAyRRCYXbgmOsWFgz();
		}
	}

	private void PjiHnEoBRQcgyItzJsIZJxSsMWju(bool P_0)
	{
	}

	private void xfiaNOwwuOeHRWmHbfrJXTlNhjb(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			wObfRIyUgeboVabiJskVEuDuVsf[wObfRIyUgeboVabiJskVEuDuVsf.fixedUpdateSetIndex].ZhHsKlVDGKijXaeHFWinJZANINf();
		}
	}

	private void qeAqePgMOUVKyWtOWYbIquUtaoU(UpdateLoopType P_0)
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			wObfRIyUgeboVabiJskVEuDuVsf.Get(P_0).gXADYrdzIttymTRoaKqLkIyUtDJ();
		}
	}

	private void JBaIltzmYFDAyRRCYXbgmOsWFgz()
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			int count = wObfRIyUgeboVabiJskVEuDuVsf.Count;
			for (int i = 0; i < count; i++)
			{
				wObfRIyUgeboVabiJskVEuDuVsf[i].IgqBTMgoLLDsubFJdJZiejmTNfb();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		wObfRIyUgeboVabiJskVEuDuVsf.Current.QJikxZSCKXGTYwxWGSqzPgTltrl(dataUpdater);
	}

	public void Clear()
	{
		JBaIltzmYFDAyRRCYXbgmOsWFgz();
	}

	private static HardwareControllerMap_Game sJDPNLgjzdbpLHncpwmaDsgHkAGK()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, isMappableOnPlatform: true);
		}
		int[] array2 = new int[132];
		for (int j = 0; j < 132; j++)
		{
			array2[j] = array[j].id;
		}
		HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
		for (int k = 0; k < 132; k++)
		{
			array3[k] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~rzBAKwBWKxcqQDABpdzeUuBgNqWX()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			ReInput.ApplicationFocusChangedEvent -= MPSJQoWnSijXncKIXuiQSTBnhmc;
			ReInput.EditorPauseChangedEvent -= PjiHnEoBRQcgyItzJsIZJxSsMWju;
			ReInput.UpdateEndedEvent -= qeAqePgMOUVKyWtOWYbIquUtaoU;
			ReInput.TimeScalePauseChangedEvent -= xfiaNOwwuOeHRWmHbfrJXTlNhjb;
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	public static int EJCeIreryoKQtXNRjmnpHekfzcM(joIDPhdLsQJpsETSRAVogyJSANzE P_0, KeyCode[] P_1)
	{
		rOQkeCDskVeDzgLRpzQFVuTjxqY zCjhUSPqfoiPALEAEbozQexULrN = P_0.ZCjhUSPqfoiPALEAEbozQexULrN;
		int result = 0;
		LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL upRcbuKqqHZOtsNqegEMdsWHhfL = YmxGgfbTyiKwOCLbdUuMRMFGbeYj();
		_ = RIpdFKYlqhdGJnoAmecvmLYXtQz;
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.RBdbNfRPligZYFUoycCeEOkEdxM((uint)P_0.ZCjhUSPqfoiPALEAEbozQexULrN, LDLICyXLtzNtgKlsBEQDDyrjfaq.pUIQWvTISgbGKOtBQARIqFmUSvY);
		if (jCPrSiHBGZqUWNnsWgKvtObDnUm(zCjhUSPqfoiPALEAEbozQexULrN))
		{
			if (dQhiiLzSLuRrmRekvRCEEpykIOQ(zCjhUSPqfoiPALEAEbozQexULrN, upRcbuKqqHZOtsNqegEMdsWHhfL, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (zCjhUSPqfoiPALEAEbozQexULrN)
			{
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.XzhcXffXatYTRpTiRyDKgAvaprhV:
				P_1[result++] = KeyCode.None;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.AGkeWNATEnOhxhshHmFfFoeStgvJ:
				P_1[result++] = KeyCode.A;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.NVenuJtRIDTVrIJisnDrjPlTTYU:
				P_1[result++] = KeyCode.B;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.WCksSwcpieaTmbVGNJclczLFXMcF:
				P_1[result++] = KeyCode.C;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.OGqyzhPXIHaPdEbWpNUavMBOoLl:
				P_1[result++] = KeyCode.D;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.etjMoWlXsHQgyjUBgAlUNPULYOa:
				P_1[result++] = KeyCode.E;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.HdwpmccXQEsQdmbujFnueNfUjXBD:
				P_1[result++] = KeyCode.F;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.hORNWJbBuqCJWYrgqwxQeJXGznT:
				P_1[result++] = KeyCode.G;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.WRuENyKSdlFajgPKtOAIaLNLEowr:
				P_1[result++] = KeyCode.H;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.TGLtJgNSlMCeoyzouzsdubaUTds:
				P_1[result++] = KeyCode.I;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.hcvZABpaQCzpCXwneOlyluuzjmm:
				P_1[result++] = KeyCode.J;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.fDwuQWVHJgvSdcjjzKnFLPAJQZi:
				P_1[result++] = KeyCode.K;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.oHsJXkSQoaluiohoEWsBuGMmjoe:
				P_1[result++] = KeyCode.L;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.tDzvyEbhzIUjRbslqviONCfoqRM:
				P_1[result++] = KeyCode.M;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.dXmiIFCguyWIhsIUAJaRTGrzgva:
				P_1[result++] = KeyCode.N;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.YmshlrVjrCCYvLUJADyMxJpVtrh:
				P_1[result++] = KeyCode.O;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.MlRxaLckhLDGIHBUDVvsjZedaQq:
				P_1[result++] = KeyCode.P;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.YPhNHSSLDyyYsFCdKIdiDSYYSAd:
				P_1[result++] = KeyCode.Q;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.FEYFKLpiFVWZfNCFEAFGHljhaYY:
				P_1[result++] = KeyCode.R;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.tNxFJOCabBULWkOaWmMafYlGmrL:
				P_1[result++] = KeyCode.S;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ALSYcbIqDOKryitzJhqEHsAGasv:
				P_1[result++] = KeyCode.T;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.HykYZFUPBxEmQwsxXpsVVKDzYGR:
				P_1[result++] = KeyCode.U;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.rMltqSvLsWlkwyzbQOdAUPgsyan:
				P_1[result++] = KeyCode.V;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.YncepcnYVOCKAswOYfLtiEuRaUH:
				P_1[result++] = KeyCode.W;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.lSOdwKYaTJSJyAWJnADwkSPKwkp:
				P_1[result++] = KeyCode.X;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ZqYMkLdonrbLPbHprxydzkIAizSD:
				P_1[result++] = KeyCode.Y;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ZCWmLKzOWxAhKMWTYgDsRddDcsH:
				P_1[result++] = KeyCode.Z;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.okZvsPTXUokxsCLhoZEKMJHfRsG:
				P_1[result++] = KeyCode.Alpha0;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.xAITNRfPvPbLIcZumBXGKpiwzJo:
				P_1[result++] = KeyCode.Alpha1;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.sIfvhpoOXMqrBqdHACACJAsWoXqq:
				P_1[result++] = KeyCode.Alpha2;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.YVRVOxgnCfOpXgfVrQQRjBzXbVL:
				P_1[result++] = KeyCode.Alpha3;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.SiBHrYpZXHazlkmwFUqpLYppWYr:
				P_1[result++] = KeyCode.Alpha4;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.qyPbNUhTLJWARZqvzKstAfhXVns:
				P_1[result++] = KeyCode.Alpha5;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.TWWDewJdjYWHtdsGhpFQTkKZhMG:
				P_1[result++] = KeyCode.Alpha6;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.aXZTTinsvoJlGDEOebXRxyGlPkJ:
				P_1[result++] = KeyCode.Alpha7;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.NAFieZxGBiwmJsGbnDKUcqwuevlr:
				P_1[result++] = KeyCode.Alpha8;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.fNCHvWpnCDEUOVqhikAItoRXmXo:
				P_1[result++] = KeyCode.Alpha9;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.SNOqXiIXOpueSYjxbXNgsOHADff:
				P_1[result++] = KeyCode.Keypad0;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ODeDmXWVzVPYfnrgvbflTOVXIst:
				P_1[result++] = KeyCode.Keypad1;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.TQnjKZEalRcCkvCKPPmKNyAMLbb:
				P_1[result++] = KeyCode.Keypad2;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.prvnLofYiSiudxqIdDlcWQhbtTk:
				P_1[result++] = KeyCode.Keypad3;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.QkMtCBUeoANhBQUhhLgnMwbptDa:
				P_1[result++] = KeyCode.Keypad4;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.IOjPXPSbCrXvuFWUPQLylVijBlQ:
				P_1[result++] = KeyCode.Keypad5;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.JGbmNTirEpTXBDlZHeWZLtqOIiD:
				P_1[result++] = KeyCode.Keypad6;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.YJMTkfxvZMvKIsLQMOqKMxzFldn:
				P_1[result++] = KeyCode.Keypad7;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.IAwuFoeMBuRgcSsfjeEdAoAKGiE:
				P_1[result++] = KeyCode.Keypad8;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.iUfTSPowPwjvBeZWVKsyejmZmFz:
				P_1[result++] = KeyCode.Keypad9;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.RhlRGpBYRNCAVCwTKglkZpUXgIX:
				P_1[result++] = KeyCode.KeypadPeriod;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.bGLjInPusHJnxprFWUJQhIOHeIDb:
				P_1[result++] = KeyCode.KeypadDivide;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.tZyydgNjCpvoMaZpIynVhhpmPbw:
				P_1[result++] = KeyCode.KeypadMultiply;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.VVOnvQwjVhCudcaXKicwUdLfDLj:
				P_1[result++] = KeyCode.KeypadMinus;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.iWIBGnFoTZKBQXySUtUicuMvsElb:
				P_1[result++] = KeyCode.KeypadPlus;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.qjdlWHfeuLMMfKiihjaKJdqrNIgB:
				if ((P_0.ujDJpjShnAhMpvbrxlInidiwNxY & hPpgKTejsVKbpVsRUJXHvsAaNAN.iraaVecMIBKQuyBRdWNBOaVPOMf) != hPpgKTejsVKbpVsRUJXHvsAaNAN.cnYKCoPGaynDOPVZUilkfGbvOrX)
				{
					P_1[result++] = KeyCode.KeypadEnter;
				}
				else
				{
					P_1[result++] = KeyCode.Return;
				}
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.LXbcFqeGcIUiwQzKThUFzsriXUS:
				P_1[result++] = KeyCode.Backspace;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.tlJcJZVaejZbzLLhwqiGRqpelZI:
				P_1[result++] = KeyCode.Tab;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.rKJfCRBWFLQsKCjGykmcumzKLPwE:
				P_1[result++] = KeyCode.Clear;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.MdYjXBcUMRWZkFtZZExwQxJyNSDQ:
				P_1[result++] = KeyCode.Pause;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.HtAZcZPGedSKaRFjtmgHvOnooTv:
				P_1[result++] = KeyCode.Escape;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ghJcQJHOPPlZAYEARHOCfuYdJxPS:
				P_1[result++] = KeyCode.Space;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.KqzHsxFZnrWYtSsbcCYhRWPJOVH:
				P_1[result++] = KeyCode.Delete;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.wUOlBsBaDAPtNloIYFfHeCWVNHe:
				P_1[result++] = KeyCode.UpArrow;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.JlAKOWbcGyryFSDRaRoBRFtbIwV:
				P_1[result++] = KeyCode.DownArrow;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.CwxkjoqFevGcrhuQvgvBQupeBZR:
				P_1[result++] = KeyCode.RightArrow;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.WDRoMbalWMXUdgmxMZqsXMmdhSq:
				P_1[result++] = KeyCode.LeftArrow;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.yvKUKXUtjuyFUJQKENTxJKcdJaI:
				P_1[result++] = KeyCode.Insert;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.aiXEIecoaVQPHZUtAPsvltevMMax:
				P_1[result++] = KeyCode.Home;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.LLWHKrpmvvlBHBJIntnWFFYFjIR:
				P_1[result++] = KeyCode.End;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.qANsSTzHFjmoKrSOmRBikjxNSgR:
				P_1[result++] = KeyCode.PageUp;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.cNCopYzehoUXNushPKBWRnBwpoq:
				P_1[result++] = KeyCode.PageDown;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.FJYBOmQadphpRDLjwyTcccXetkr:
				P_1[result++] = KeyCode.F1;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.GzsCDUGRwwJnvWmPvsboEbgGTKm:
				P_1[result++] = KeyCode.F2;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.KkdgLZZHXgnfKmvtPzqAkNTSwJw:
				P_1[result++] = KeyCode.F3;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.zDffDlIZwNKkxqqVbqQdXBLNwpb:
				P_1[result++] = KeyCode.F4;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.DVDgbChhOqYPARcJbhzidZNrbbN:
				P_1[result++] = KeyCode.F5;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ZZVqOfhpDziHncRlKJThkagORaF:
				P_1[result++] = KeyCode.F6;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.eSSFjXirfWZeFFCochVPXzxVNOt:
				P_1[result++] = KeyCode.F7;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ezFTndzooLIbsbQoHZThPSnyiDHT:
				P_1[result++] = KeyCode.F8;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.WXwXybxHPtAYpWHuPvajALLAIVL:
				P_1[result++] = KeyCode.F9;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.SWqSzipPPcIMtFxIMOgLfxIxia:
				P_1[result++] = KeyCode.F10;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.LzKQUPxjcHKohZXbDxEZaKAQqNu:
				P_1[result++] = KeyCode.F11;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.pNhNieogGLDggPjSSSPhGEJoDgO:
				P_1[result++] = KeyCode.F12;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.FPsvQRKUQQHtthbHFzZwjpUTqlO:
				P_1[result++] = KeyCode.F13;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.qHrqhNYInNNXLEeZGHciUgOXvsO:
				P_1[result++] = KeyCode.F14;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.LnBDyDkKDoYhPSFMVQvjaiwwHi:
				P_1[result++] = KeyCode.F15;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.NGHCvSfCRTmaqOeGfDgBRdcXdIGP:
				P_1[result++] = KeyCode.Numlock;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.akfojnHxGewevgAdUyaBBUSLpHU:
				P_1[result++] = KeyCode.CapsLock;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.tPeHPnACYTsKCFcRiuBTdShmdnP:
				P_1[result++] = KeyCode.ScrollLock;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.sYugGMppqdoGhjuQnHXjUIRcFqK:
				P_1[result++] = KeyCode.RightShift;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.sGbTCdBJDBDENPSTGVSMfXSUtEu:
				P_1[result++] = KeyCode.LeftShift;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.gMQPbKQjcjEJcpwkiXVSxkTogCo:
				P_1[result++] = KeyCode.RightControl;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.KENIeTDgZOdepFGQVDXuOMWWrEh:
				P_1[result++] = KeyCode.LeftControl;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.VbVwePzWNOoRkPlHqAKnqmCXECE:
				P_1[result++] = KeyCode.AltGr;
				P_1[result++] = KeyCode.RightAlt;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.ySZBjocskGujmWEctpODKDxjyxT:
				P_1[result++] = KeyCode.LeftAlt;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.NxuniePMmwqNBfYNWaeUNUkCSmz:
				P_1[result++] = KeyCode.RightCommand;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.lvhTnppzJxcJhxcIdhLyHIobCsd:
				P_1[result++] = KeyCode.LeftCommand;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.jiWeZreEnAiiFcrftAlpjHBDeGN:
				P_1[result++] = KeyCode.Help;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.nazAHadjmMkPKhkSITPdGzLfKNjo:
				P_1[result++] = KeyCode.Print;
				break;
			case rOQkeCDskVeDzgLRpzQFVuTjxqY.TAyXpIyaqHEfFvySGhidKesFDkmh:
				P_1[result++] = KeyCode.Menu;
				break;
			}
		}
		return result;
	}

	private unsafe static LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL YmxGgfbTyiKwOCLbdUuMRMFGbeYj()
	{
		IntPtr intPtr = HuTamtUgOYxfCNLWEcbrfgTfOVKO.ZOAWUuuQbgZujAikWAgvykBqjZU(0);
		if (intPtr == RIpdFKYlqhdGJnoAmecvmLYXtQz)
		{
			return JwucMnERulgtbvkyUTVdYLfOCTyE;
		}
		LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL upRcbuKqqHZOtsNqegEMdsWHhfL = LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL.tsUFrPinAvzjFWhbcuuVSDfZoNya;
		byte* ptr = stackalloc byte[128];
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.oOsfnjxmaAfQbZygxeUkFITgnGz((IntPtr)ptr);
		string s = Marshal.PtrToStringUni((IntPtr)ptr);
		if (int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			int num = ArrayTools.IndexOf(WnGfipwyhmQCpWrTxjBxiwRwhLO, result);
			if (num >= 0)
			{
				upRcbuKqqHZOtsNqegEMdsWHhfL = (LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL)WnGfipwyhmQCpWrTxjBxiwRwhLO[num];
			}
		}
		RIpdFKYlqhdGJnoAmecvmLYXtQz = intPtr;
		JwucMnERulgtbvkyUTVdYLfOCTyE = upRcbuKqqHZOtsNqegEMdsWHhfL;
		return upRcbuKqqHZOtsNqegEMdsWHhfL;
	}

	private static bool dQhiiLzSLuRrmRekvRCEEpykIOQ(rOQkeCDskVeDzgLRpzQFVuTjxqY P_0, LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!yeCxjQlqGNJzDLsCclbEzoYprII.TryGetValue((int)P_1, out var value))
		{
			value = yeCxjQlqGNJzDLsCclbEzoYprII[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != LDLICyXLtzNtgKlsBEQDDyrjfaq.UpRcbuKqqHZOtsNqegEMdsWHhfL.tsUFrPinAvzjFWhbcuuVSDfZoNya)
		{
			value = yeCxjQlqGNJzDLsCclbEzoYprII[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool jCPrSiHBGZqUWNnsWgKvtObDnUm(rOQkeCDskVeDzgLRpzQFVuTjxqY P_0)
	{
		return ArrayTools.Contains(ADEGHmrHREKxklbSSocWFonvaCe, (int)P_0);
	}
}
