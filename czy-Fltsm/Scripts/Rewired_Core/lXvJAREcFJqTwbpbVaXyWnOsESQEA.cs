using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class lXvJAREcFJqTwbpbVaXyWnOsESQEA
{
	internal enum SNwohbMULvtsqCoYLGoptSyIlJqI
	{
		Active = 0,
		Idle = 1,
		Disabled = 2
	}

	private class mdKeBwiojDNtQakLqIFsMDHnLJRd
	{
		internal class WVlnTdkcVUOeTOGOChgTmzQPwLSn
		{
			internal double jkoeOBeBQOxzCdNpDTwHNxCpYpTAA;

			private InputBehavior TpIMWRxCFfJFKJFNUnXGlOCWdmwx;

			internal float fepSIVMxGbmIMpGqzewBFnzSCrsY;

			internal float zHBeEKpGFqCAShieOcJNnPyahQkq;

			internal AxisCoordinateMode ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb;

			internal AxisCoordinateMode EvGWyIIAcKQuRHyOhhIlZXDFAMBe;

			internal ButtonStateFlags TXgDCqgTurLNBwUnvRFpoLPmHFgib;

			internal ButtonStateFlags DrucdMwCYeegKKEpsMVeSwnZfVvR;

			internal ButtonStateFlags zDoiJYHLSpVQjeOpXyUlHDQLgtFqA;

			internal ButtonStateFlags zzLCnLpwDPawIqjihCeYShbgQZEO;

			internal float wzxhYUevedjdyANywFGgXJsLAiky;

			internal float xBWwwSLXCOivcVxAcMQBBpprnErw;

			internal float urktPppRkFQXtEfRKKXOqQNOmMUS;

			internal float cpmbbGFKDyNaFBOaGTLtBNECuoHI;

			private double aNHgOlTAgwcHkaOHdXlMNJHKSfiQA;

			private double nMSbvAfdXroPriakCRXPZuYnBOgE;

			private double mLGndQeUswVkVwVsFSDPbEehGwmp;

			private double ZjGyAvJuZDIHhXgEBDwveIchfPTn;

			internal fSmSyrrmGXABUOhSZBWNiFWkyILxA IrulBVQnXVIsvdhGIKELnjsaaNHh;

			internal fSmSyrrmGXABUOhSZBWNiFWkyILxA HHdWUEsRAXfbCHNzAAqkFAvNLgaUA;

			internal ButtonStateRecorder NTyVHRurVPfGxytttpBqDiTQPmNf;

			internal ButtonStateRecorder DVWdQgSqhekYFgJFsNdapOuYUdXu;

			internal woMKzdEBUjsSnpoYVaJCbEaUHWYd uMHAXlRKRJGAAjdqnhvjWMUBvjqs;

			internal woMKzdEBUjsSnpoYVaJCbEaUHWYd JvNSIFDWKlEsQqGPjybQKzgbGzST;

			internal TimerAbs MRolaAhuSyEXdsFJIChVZhKZQaCV;

			internal TimerAbs NucjAiglLSlCwQTBdkJDGzHNOaTi;

			internal readonly vzOsYWLwkZfRLdvSwlWqPwvPltic XpfWEyHiQyxgaHNOispfZpdzHHql = new vzOsYWLwkZfRLdvSwlWqPwvPltic();

			internal double LprxXWrZPXMFMZUTlHPwrGgjakCAA => NTyVHRurVPfGxytttpBqDiTQPmNf.xAPUFiODnOIrnBJfTaxdkidFbPax;

			internal double IYFzIXMZztatvIpMCxTKqpOyhBGg => NTyVHRurVPfGxytttpBqDiTQPmNf.BPLieXJiEKCEeDSuukctyGyIgxPgA;

			internal double OQbjktutGMqFjhpGXhKbewptGLQg => DVWdQgSqhekYFgJFsNdapOuYUdXu.xAPUFiODnOIrnBJfTaxdkidFbPax;

			internal double KVreIfBqzENfbyYgVyNrqXeWoXKtA => DVWdQgSqhekYFgJFsNdapOuYUdXu.BPLieXJiEKCEeDSuukctyGyIgxPgA;

			internal double DfhGPObcbRbCbffruatJBTwAqmBsB
			{
				get
				{
					if ((TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) == 0 && (TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) == 0)
					{
						return 0.0;
					}
					return hYvcAstVbKiynNfzPuUEMGaWTRLV - aNHgOlTAgwcHkaOHdXlMNJHKSfiQA;
				}
			}

			internal double LapGzleouizLhlPwWavltwppRan
			{
				get
				{
					if ((TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) != ButtonStateFlags.Off || (TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) != ButtonStateFlags.Off)
					{
						return 0.0;
					}
					return hYvcAstVbKiynNfzPuUEMGaWTRLV - aNHgOlTAgwcHkaOHdXlMNJHKSfiQA;
				}
			}

			internal double AHeTcWbhnCWeajfaygIGpeGgBeSl
			{
				get
				{
					if ((zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) == 0 && (zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) == 0)
					{
						return 0.0;
					}
					return hYvcAstVbKiynNfzPuUEMGaWTRLV - nMSbvAfdXroPriakCRXPZuYnBOgE;
				}
			}

			internal double uaqXojvelTHUpFzNwjWmgdmIFkkl
			{
				get
				{
					if ((zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) != ButtonStateFlags.Off || (zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) != ButtonStateFlags.Off)
					{
						return 0.0;
					}
					return hYvcAstVbKiynNfzPuUEMGaWTRLV - nMSbvAfdXroPriakCRXPZuYnBOgE;
				}
			}

			internal double vbLPfQOMmEVJePkWVVgaYaminbxi
			{
				get
				{
					if (fepSIVMxGbmIMpGqzewBFnzSCrsY == 0f && wzxhYUevedjdyANywFGgXJsLAiky == 0f)
					{
						return 0.0;
					}
					double num = hYvcAstVbKiynNfzPuUEMGaWTRLV - mLGndQeUswVkVwVsFSDPbEehGwmp;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double YibEMuWKeIfErisMkEcFgYmmaUCz
			{
				get
				{
					if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f || wzxhYUevedjdyANywFGgXJsLAiky != 0f)
					{
						return 0.0;
					}
					double num = hYvcAstVbKiynNfzPuUEMGaWTRLV - mLGndQeUswVkVwVsFSDPbEehGwmp;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double mnsWKJruptoaJQIdQwpslZUgjxAg
			{
				get
				{
					if (fepSIVMxGbmIMpGqzewBFnzSCrsY == 0f && urktPppRkFQXtEfRKKXOqQNOmMUS == 0f)
					{
						return 0.0;
					}
					double num = hYvcAstVbKiynNfzPuUEMGaWTRLV - ZjGyAvJuZDIHhXgEBDwveIchfPTn;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double okrBIlKnBCusFRDGVtbbjXXJhjpgA
			{
				get
				{
					if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f || urktPppRkFQXtEfRKKXOqQNOmMUS != 0f)
					{
						return 0.0;
					}
					double num = hYvcAstVbKiynNfzPuUEMGaWTRLV - ZjGyAvJuZDIHhXgEBDwveIchfPTn;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal WVlnTdkcVUOeTOGOChgTmzQPwLSn(InputBehavior P_0)
			{
				TpIMWRxCFfJFKJFNUnXGlOCWdmwx = P_0;
				if (P_0.buttonDownBuffer > 0f)
				{
					MRolaAhuSyEXdsFJIChVZhKZQaCV = new TimerAbs(P_0.buttonDownBuffer);
					NucjAiglLSlCwQTBdkJDGzHNOaTi = new TimerAbs(P_0.buttonDownBuffer);
				}
				NTyVHRurVPfGxytttpBqDiTQPmNf = new ButtonStateRecorder();
				DVWdQgSqhekYFgJFsNdapOuYUdXu = new ButtonStateRecorder();
				IrulBVQnXVIsvdhGIKELnjsaaNHh = new fSmSyrrmGXABUOhSZBWNiFWkyILxA(P_0.buttonDoublePressSpeed);
				HHdWUEsRAXfbCHNzAAqkFAvNLgaUA = new fSmSyrrmGXABUOhSZBWNiFWkyILxA(P_0.buttonDoublePressSpeed);
				uMHAXlRKRJGAAjdqnhvjWMUBvjqs = new woMKzdEBUjsSnpoYVaJCbEaUHWYd(P_0.buttonRepeatDelay, P_0.buttonRepeatRate);
				JvNSIFDWKlEsQqGPjybQKzgbGzST = new woMKzdEBUjsSnpoYVaJCbEaUHWYd(P_0.buttonRepeatDelay, P_0.buttonRepeatRate);
				kaVyOJfeYohLlsaVHQmcsGHdgSUgA();
			}

			internal void ojyAaPnbMzkPmnaqsLGBruXVoJhs(double P_0)
			{
				if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f || wzxhYUevedjdyANywFGgXJsLAiky != 0f)
				{
					if (zHBeEKpGFqCAShieOcJNnPyahQkq == 0f && xBWwwSLXCOivcVxAcMQBBpprnErw == 0f)
					{
						mLGndQeUswVkVwVsFSDPbEehGwmp = hYvcAstVbKiynNfzPuUEMGaWTRLV;
					}
				}
				else if (zHBeEKpGFqCAShieOcJNnPyahQkq != 0f || xBWwwSLXCOivcVxAcMQBBpprnErw != 0f)
				{
					mLGndQeUswVkVwVsFSDPbEehGwmp = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f || urktPppRkFQXtEfRKKXOqQNOmMUS != 0f)
				{
					if (zHBeEKpGFqCAShieOcJNnPyahQkq == 0f && cpmbbGFKDyNaFBOaGTLtBNECuoHI == 0f)
					{
						ZjGyAvJuZDIHhXgEBDwveIchfPTn = hYvcAstVbKiynNfzPuUEMGaWTRLV;
					}
				}
				else if (zHBeEKpGFqCAShieOcJNnPyahQkq != 0f || cpmbbGFKDyNaFBOaGTLtBNECuoHI != 0f)
				{
					ZjGyAvJuZDIHhXgEBDwveIchfPTn = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				if (((TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) != ButtonStateFlags.Off || (TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) != 0) != ((DrucdMwCYeegKKEpsMVeSwnZfVvR & ButtonStateFlags.On) != ButtonStateFlags.Off || (DrucdMwCYeegKKEpsMVeSwnZfVvR & ButtonStateFlags.Down) != 0))
				{
					aNHgOlTAgwcHkaOHdXlMNJHKSfiQA = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				if (((zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) != ButtonStateFlags.Off || (zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) != 0) != ((zzLCnLpwDPawIqjihCeYShbgQZEO & ButtonStateFlags.On) != ButtonStateFlags.Off || (zzLCnLpwDPawIqjihCeYShbgQZEO & ButtonStateFlags.Down) != 0))
				{
					nMSbvAfdXroPriakCRXPZuYnBOgE = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
			}

			internal void UGWzOUPwmblcYFyWrFEnoNzhPzCq()
			{
				if (zHBeEKpGFqCAShieOcJNnPyahQkq != fepSIVMxGbmIMpGqzewBFnzSCrsY)
				{
					zHBeEKpGFqCAShieOcJNnPyahQkq = fepSIVMxGbmIMpGqzewBFnzSCrsY;
				}
				if (DrucdMwCYeegKKEpsMVeSwnZfVvR != TXgDCqgTurLNBwUnvRFpoLPmHFgib)
				{
					DrucdMwCYeegKKEpsMVeSwnZfVvR = TXgDCqgTurLNBwUnvRFpoLPmHFgib;
				}
				if (zzLCnLpwDPawIqjihCeYShbgQZEO != zDoiJYHLSpVQjeOpXyUlHDQLgtFqA)
				{
					zzLCnLpwDPawIqjihCeYShbgQZEO = zDoiJYHLSpVQjeOpXyUlHDQLgtFqA;
				}
				if (xBWwwSLXCOivcVxAcMQBBpprnErw != wzxhYUevedjdyANywFGgXJsLAiky)
				{
					xBWwwSLXCOivcVxAcMQBBpprnErw = wzxhYUevedjdyANywFGgXJsLAiky;
				}
				if (cpmbbGFKDyNaFBOaGTLtBNECuoHI != urktPppRkFQXtEfRKKXOqQNOmMUS)
				{
					cpmbbGFKDyNaFBOaGTLtBNECuoHI = urktPppRkFQXtEfRKKXOqQNOmMUS;
				}
				if (EvGWyIIAcKQuRHyOhhIlZXDFAMBe != ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb)
				{
					EvGWyIIAcKQuRHyOhhIlZXDFAMBe = ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb;
				}
				if (ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb != AxisCoordinateMode.Absolute)
				{
					ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb = AxisCoordinateMode.Absolute;
				}
			}

			internal void kmRtUcmuifbcONbyjJcwMSBfvhTO()
			{
				if (MRolaAhuSyEXdsFJIChVZhKZQaCV != null)
				{
					MRolaAhuSyEXdsFJIChVZhKZQaCV.Update();
					NucjAiglLSlCwQTBdkJDGzHNOaTi.Update();
				}
			}

			internal void xWzAfyfsoeGJcZmtHvcvwbXgPTVfb(bool P_0, bool P_1, bool P_2, bool P_3)
			{
				NTyVHRurVPfGxytttpBqDiTQPmNf.XqFAJKgfJJJYPBiYaIzGxMqFSGPDb(P_0, P_1, hYvcAstVbKiynNfzPuUEMGaWTRLV);
				DVWdQgSqhekYFgJFsNdapOuYUdXu.XqFAJKgfJJJYPBiYaIzGxMqFSGPDb(P_2, P_3, hYvcAstVbKiynNfzPuUEMGaWTRLV);
				float buttonDoublePressSpeed = TpIMWRxCFfJFKJFNUnXGlOCWdmwx.buttonDoublePressSpeed;
				IrulBVQnXVIsvdhGIKELnjsaaNHh.pPclsWppnxgEcowLOKgJhdxlDvKb(buttonDoublePressSpeed, P_0, P_1);
				HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.pPclsWppnxgEcowLOKgJhdxlDvKb(buttonDoublePressSpeed, P_2, P_3);
				float buttonRepeatDelay = TpIMWRxCFfJFKJFNUnXGlOCWdmwx.buttonRepeatDelay;
				float buttonRepeatRate = TpIMWRxCFfJFKJFNUnXGlOCWdmwx.buttonRepeatRate;
				uMHAXlRKRJGAAjdqnhvjWMUBvjqs.xDuBpZfJwJlWkSduSXUqUqWQceSW(P_0, P_1, buttonRepeatDelay, buttonRepeatRate, hYvcAstVbKiynNfzPuUEMGaWTRLV);
				JvNSIFDWKlEsQqGPjybQKzgbGzST.xDuBpZfJwJlWkSduSXUqUqWQceSW(P_2, P_3, buttonRepeatDelay, buttonRepeatRate, hYvcAstVbKiynNfzPuUEMGaWTRLV);
			}

			internal bool JVnRnFsYifhqvaeKCHjYebKMHblf()
			{
				if (hYvcAstVbKiynNfzPuUEMGaWTRLV < jkoeOBeBQOxzCdNpDTwHNxCpYpTAA + (double)TpIMWRxCFfJFKJFNUnXGlOCWdmwx.buttonDoublePressSpeed + 2.0 * (double)TfXgDSRscjWSaDAbswaEwsbJKctJ)
				{
					return false;
				}
				if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f)
				{
					return false;
				}
				if (zHBeEKpGFqCAShieOcJNnPyahQkq != 0f)
				{
					return false;
				}
				if (TXgDCqgTurLNBwUnvRFpoLPmHFgib == ButtonStateFlags.Off)
				{
					return false;
				}
				if (DrucdMwCYeegKKEpsMVeSwnZfVvR == ButtonStateFlags.Off)
				{
					return false;
				}
				if (zDoiJYHLSpVQjeOpXyUlHDQLgtFqA == ButtonStateFlags.Off)
				{
					return false;
				}
				if (zzLCnLpwDPawIqjihCeYShbgQZEO == ButtonStateFlags.Off)
				{
					return false;
				}
				if (wzxhYUevedjdyANywFGgXJsLAiky != 0f)
				{
					return false;
				}
				if (xBWwwSLXCOivcVxAcMQBBpprnErw != 0f)
				{
					return false;
				}
				if (urktPppRkFQXtEfRKKXOqQNOmMUS != 0f)
				{
					return false;
				}
				if (cpmbbGFKDyNaFBOaGTLtBNECuoHI != 0f)
				{
					return false;
				}
				if (MRolaAhuSyEXdsFJIChVZhKZQaCV != null && MRolaAhuSyEXdsFJIChVZhKZQaCV.running)
				{
					return false;
				}
				if (NucjAiglLSlCwQTBdkJDGzHNOaTi != null && NucjAiglLSlCwQTBdkJDGzHNOaTi.running)
				{
					return false;
				}
				return true;
			}

			internal void LtNUCtGOsEzFUvULxuRpSxboezBd()
			{
				TXgDCqgTurLNBwUnvRFpoLPmHFgib &= ~ButtonStateFlags.Down;
				zDoiJYHLSpVQjeOpXyUlHDQLgtFqA &= ~ButtonStateFlags.Down;
			}

			internal void KHarMKXAfpnzTrQEYiPqVIJTJwTj()
			{
				if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f || wzxhYUevedjdyANywFGgXJsLAiky != 0f)
				{
					mLGndQeUswVkVwVsFSDPbEehGwmp = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				if (fepSIVMxGbmIMpGqzewBFnzSCrsY != 0f || urktPppRkFQXtEfRKKXOqQNOmMUS != 0f)
				{
					ZjGyAvJuZDIHhXgEBDwveIchfPTn = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				if ((TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) != ButtonStateFlags.Off || (TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) != ButtonStateFlags.Off)
				{
					aNHgOlTAgwcHkaOHdXlMNJHKSfiQA = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				if ((zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) != ButtonStateFlags.Off || (zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) != ButtonStateFlags.Off)
				{
					nMSbvAfdXroPriakCRXPZuYnBOgE = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				}
				fepSIVMxGbmIMpGqzewBFnzSCrsY = 0f;
				zHBeEKpGFqCAShieOcJNnPyahQkq = 0f;
				ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb = AxisCoordinateMode.Absolute;
				TXgDCqgTurLNBwUnvRFpoLPmHFgib = ButtonStateFlags.Off;
				DrucdMwCYeegKKEpsMVeSwnZfVvR = ButtonStateFlags.Off;
				zDoiJYHLSpVQjeOpXyUlHDQLgtFqA = ButtonStateFlags.Off;
				zzLCnLpwDPawIqjihCeYShbgQZEO = ButtonStateFlags.Off;
				wzxhYUevedjdyANywFGgXJsLAiky = 0f;
				xBWwwSLXCOivcVxAcMQBBpprnErw = 0f;
				urktPppRkFQXtEfRKKXOqQNOmMUS = 0f;
				cpmbbGFKDyNaFBOaGTLtBNECuoHI = 0f;
				if (MRolaAhuSyEXdsFJIChVZhKZQaCV != null)
				{
					MRolaAhuSyEXdsFJIChVZhKZQaCV.Clear();
					NucjAiglLSlCwQTBdkJDGzHNOaTi.Clear();
				}
				IrulBVQnXVIsvdhGIKELnjsaaNHh.GouIlXJGzHteJoMUdxkdTEiiMxDg();
				HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.GouIlXJGzHteJoMUdxkdTEiiMxDg();
				NTyVHRurVPfGxytttpBqDiTQPmNf.smaQhjPaHkcSNDQNYKlayiKIJybd(hYvcAstVbKiynNfzPuUEMGaWTRLV);
				DVWdQgSqhekYFgJFsNdapOuYUdXu.smaQhjPaHkcSNDQNYKlayiKIJybd(hYvcAstVbKiynNfzPuUEMGaWTRLV);
				uMHAXlRKRJGAAjdqnhvjWMUBvjqs.IPePBSAiVeeDAjILCPckEFHjgGAz();
				JvNSIFDWKlEsQqGPjybQKzgbGzST.IPePBSAiVeeDAjILCPckEFHjgGAz();
				XpfWEyHiQyxgaHNOispfZpdzHHql.kdCMwhkHJRjOvRyUBRNKuTFNjcKv();
			}

			internal void kaVyOJfeYohLlsaVHQmcsGHdgSUgA()
			{
				KHarMKXAfpnzTrQEYiPqVIJTJwTj();
				NTyVHRurVPfGxytttpBqDiTQPmNf.tTnwtZXsmlRDknxdEZHazJkurNfH();
				DVWdQgSqhekYFgJFsNdapOuYUdXu.tTnwtZXsmlRDknxdEZHazJkurNfH();
				mLGndQeUswVkVwVsFSDPbEehGwmp = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				ZjGyAvJuZDIHhXgEBDwveIchfPTn = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				aNHgOlTAgwcHkaOHdXlMNJHKSfiQA = hYvcAstVbKiynNfzPuUEMGaWTRLV;
				nMSbvAfdXroPriakCRXPZuYnBOgE = hYvcAstVbKiynNfzPuUEMGaWTRLV;
			}
		}

		public WVlnTdkcVUOeTOGOChgTmzQPwLSn[] goXzbmHJbelpVHLIOIGIZyZZbQND;

		private readonly int[] tyfCipevwyUuWdkmBequAcUgAgNh;

		private int VSiWXrQKmRtsXLVxFVQSNoczqvpf;

		internal WVlnTdkcVUOeTOGOChgTmzQPwLSn xTujhIaItbDIZIUeYPNwvwUsXkDt;

		internal UpdateLoopType FdIBpvnOzEDGqOHJaZLSwLsIqORH
		{
			set
			{
				VSiWXrQKmRtsXLVxFVQSNoczqvpf = tyfCipevwyUuWdkmBequAcUgAgNh[(int)updateLoopType];
				xTujhIaItbDIZIUeYPNwvwUsXkDt = goXzbmHJbelpVHLIOIGIZyZZbQND[VSiWXrQKmRtsXLVxFVQSNoczqvpf];
			}
		}

		internal mdKeBwiojDNtQakLqIFsMDHnLJRd(UpdateLoopSetting P_0, InputBehavior P_1)
		{
			tyfCipevwyUuWdkmBequAcUgAgNh = new int[3];
			ArrayTools.Fill(tyfCipevwyUuWdkmBequAcUgAgNh, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list);
				for (int i = 0; i < list.Count; i++)
				{
					tyfCipevwyUuWdkmBequAcUgAgNh[(int)list[i]] = num;
					num++;
				}
			}
			goXzbmHJbelpVHLIOIGIZyZZbQND = new WVlnTdkcVUOeTOGOChgTmzQPwLSn[num];
			for (int j = 0; j < num; j++)
			{
				goXzbmHJbelpVHLIOIGIZyZZbQND[j] = new WVlnTdkcVUOeTOGOChgTmzQPwLSn(P_1);
			}
			xTujhIaItbDIZIUeYPNwvwUsXkDt = goXzbmHJbelpVHLIOIGIZyZZbQND[0];
		}

		internal bool gQgoWsNWSPyWZtAWPKraZzyAbZaf()
		{
			for (int i = 0; i < 3; i++)
			{
				if (tyfCipevwyUuWdkmBequAcUgAgNh[i] >= 0 && !goXzbmHJbelpVHLIOIGIZyZZbQND[tyfCipevwyUuWdkmBequAcUgAgNh[i]].JVnRnFsYifhqvaeKCHjYebKMHblf())
				{
					return false;
				}
			}
			return true;
		}

		internal void HFUWeAusKVmKtKmLLCYQoETqkEpm()
		{
			for (int i = 0; i < goXzbmHJbelpVHLIOIGIZyZZbQND.Length; i++)
			{
				goXzbmHJbelpVHLIOIGIZyZZbQND[i].kaVyOJfeYohLlsaVHQmcsGHdgSUgA();
			}
		}

		internal void ICIzEbtTXVFWKSgRhGQotkapmorJ()
		{
			for (int i = 0; i < goXzbmHJbelpVHLIOIGIZyZZbQND.Length; i++)
			{
				goXzbmHJbelpVHLIOIGIZyZZbQND[i].KHarMKXAfpnzTrQEYiPqVIJTJwTj();
			}
		}
	}

	private class FhkqWWlwwJhbffxVDQCIJIPwisNo
	{
		internal class hBwHXKipIrjsZkKyZBKzswINBdNL
		{
			internal Vector3 UVRBXcABKdqWtnCNajdOjvrzDVoSA;

			internal Vector3 kpoLkkKkzQSzpcvzBSRHraBbiNIGA;

			internal Vector3 EEdZOsguTTURWTeIeCwfpzQdBtnP;

			internal void DGTuRXZFSYHVlvlHTjisydFuaaEb()
			{
				UVRBXcABKdqWtnCNajdOjvrzDVoSA = ReInput.controllers.Mouse.screenPosition;
				EEdZOsguTTURWTeIeCwfpzQdBtnP = UVRBXcABKdqWtnCNajdOjvrzDVoSA - kpoLkkKkzQSzpcvzBSRHraBbiNIGA;
			}

			internal void UoAMoklLuhBkeexRiSUXByeEbtlrA()
			{
				kpoLkkKkzQSzpcvzBSRHraBbiNIGA.x = UVRBXcABKdqWtnCNajdOjvrzDVoSA.x;
				kpoLkkKkzQSzpcvzBSRHraBbiNIGA.y = UVRBXcABKdqWtnCNajdOjvrzDVoSA.y;
				kpoLkkKkzQSzpcvzBSRHraBbiNIGA.z = UVRBXcABKdqWtnCNajdOjvrzDVoSA.z;
			}
		}

		private ADictionary<int, hBwHXKipIrjsZkKyZBKzswINBdNL> ZrMYDnINtTaRwJebuaQjAKCaRZEV;

		private hBwHXKipIrjsZkKyZBKzswINBdNL glZSLEPizBWHUrQUAujmEMqlcail;

		private UpdateLoopType MEpeaAMiICnUXLqOnIPDRdcpyQFv;

		internal hBwHXKipIrjsZkKyZBKzswINBdNL JKVOTzKxEiwdlbtWzGRqErcdQbBN => glZSLEPizBWHUrQUAujmEMqlcail;

		internal FhkqWWlwwJhbffxVDQCIJIPwisNo(UpdateLoopSetting P_0)
		{
			glZSLEPizBWHUrQUAujmEMqlcail = null;
			ZrMYDnINtTaRwJebuaQjAKCaRZEV = new ADictionary<int, hBwHXKipIrjsZkKyZBKzswINBdNL>();
			using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				hBwHXKipIrjsZkKyZBKzswINBdNL value = new hBwHXKipIrjsZkKyZBKzswINBdNL();
				ZrMYDnINtTaRwJebuaQjAKCaRZEV.Add((int)list[i], value);
				if (glZSLEPizBWHUrQUAujmEMqlcail == null)
				{
					glZSLEPizBWHUrQUAujmEMqlcail = value;
				}
			}
		}

		internal void gILbdsgXCWIcEKGGFrCOtVsBAvtXA(UpdateLoopType P_0)
		{
			if (MEpeaAMiICnUXLqOnIPDRdcpyQFv != P_0)
			{
				MEpeaAMiICnUXLqOnIPDRdcpyQFv = P_0;
			}
			glZSLEPizBWHUrQUAujmEMqlcail = ZrMYDnINtTaRwJebuaQjAKCaRZEV[(int)P_0];
			glZSLEPizBWHUrQUAujmEMqlcail.DGTuRXZFSYHVlvlHTjisydFuaaEb();
		}

		internal void EDPxAjpZGgEOYHLdmdjUjsYVJnMl()
		{
			glZSLEPizBWHUrQUAujmEMqlcail.UoAMoklLuhBkeexRiSUXByeEbtlrA();
		}
	}

	internal readonly string aQefYrZzKroieRnxLzuudjcMOdPM;

	internal readonly int iOyZywcMUeuWkANMAkueVLStqCBf;

	internal readonly int fWObmMDyJQLjtMQVViswtczCLZDeb;

	private readonly int fMyKqIxBJjrXohkpmCnNMAFCexte;

	private InputBehavior kIOElRBhtNsYpnnSjSnGoIKNoQBkA;

	private mdKeBwiojDNtQakLqIFsMDHnLJRd BCsGtgAxASwOfYszbpskBSVZczIv;

	private static ConfigVars kixDWPjWFuaKAGXvRudbLOCHyGOmA;

	private static FhkqWWlwwJhbffxVDQCIJIPwisNo uVPHALnRyWPyZIPswGPefvhPuIvg;

	private static UpdateLoopType JvocSMbcsVCXgKoYxmuxIzmildeEA;

	private static double hYvcAstVbKiynNfzPuUEMGaWTRLV;

	private static float TfXgDSRscjWSaDAbswaEwsbJKctJ;

	private static uint cqsMudFFbwEzahIQRfsKgWihteuyB;

	private float GyYPyrCpRLVmbFSqOPWHWIpTIoMD;

	private float kLSAieQZQVbhoEbGxtaNyoMCqufu;

	private float oNSaFokAWSXpCNgOqwhNOxVAPvrhA;

	private float BkxPtFxxuVjtJufisjLCCUJhCbCG;

	private ButtonStateFlags DBbOsUmWkjsFyRpXSHgdHBiqNXRe;

	private ButtonStateFlags wqHBjdBgLHQWjgYcyoXKbdXrAhHm;

	private float FbExYpCaGkCIEANVkixCsucVcVJFA;

	private bool vMsqDjInivgCEGiHxBCewEKefqkbA;

	private AxisCoordinateMode ItAkeVJWkEelDlqAMkVzclupyUcS;

	private AxisCoordinateMode KbgCgQcfMYvHPgpmqwgfPJQLCTIK;

	private readonly vzOsYWLwkZfRLdvSwlWqPwvPltic uvMDMjbqrMyJDCdoxSgUMzjbuMaH = new vzOsYWLwkZfRLdvSwlWqPwvPltic();

	private uint ZwgLpCMMIyOgtLvJtiHafUUbBbdn;

	private uint rwEyCkTAjSPWLKAxAAfuavDMJPzXA;

	private bool uNQgqcFaupnIyuWoINNkBtYfuRXN;

	private SNwohbMULvtsqCoYLGoptSyIlJqI aouxRNSWdalJzuqbpsbwczLuwfYr;

	private const int zszLkFgWozizTDyeZCIDJBRmChdU = 4;

	private int CHajixFAUrMvFlVdRtKbcXqapEaO;

	private vzOsYWLwkZfRLdvSwlWqPwvPltic[] sfWfhnMQIrsylhkZeOGxgPcJyPVj;

	private List<InputActionSourceData> dBLwIEXZxfMKKneOOopDNoulAThu;

	private ReadOnlyCollection<InputActionSourceData> eAfdxshvqOTcPFxDJlXYpPQPAMdZA;

	private bool pniSluyPebNFsIouxpvojCqGZjoI;

	internal bool MrBOpsHJnZsFCkTIKqwYzoIPeZuO;

	internal SNwohbMULvtsqCoYLGoptSyIlJqI DQvudLTsOmnvZgNOnemtHoScpAHLA = SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled;

	internal static readonly GzcteHVAfAafMobmLlSAJXPvwqFL UdmQYSAbdznnxGatFkGbeSAHoaYM;

	static lXvJAREcFJqTwbpbVaXyWnOsESQEA()
	{
		UdmQYSAbdznnxGatFkGbeSAHoaYM = new GzcteHVAfAafMobmLlSAJXPvwqFL();
	}

	internal lXvJAREcFJqTwbpbVaXyWnOsESQEA(int P_0, InputAction P_1, InputBehavior P_2, ConfigVars P_3)
	{
		fMyKqIxBJjrXohkpmCnNMAFCexte = ReInput._id;
		kixDWPjWFuaKAGXvRudbLOCHyGOmA = P_3;
		fWObmMDyJQLjtMQVViswtczCLZDeb = P_0;
		iOyZywcMUeuWkANMAkueVLStqCBf = P_1.id;
		aQefYrZzKroieRnxLzuudjcMOdPM = P_1.name;
		kIOElRBhtNsYpnnSjSnGoIKNoQBkA = P_2;
		BCsGtgAxASwOfYszbpskBSVZczIv = new mdKeBwiojDNtQakLqIFsMDHnLJRd(P_3.updateLoop, P_2);
		sfWfhnMQIrsylhkZeOGxgPcJyPVj = new vzOsYWLwkZfRLdvSwlWqPwvPltic[4];
		ArrayTools.Populate(sfWfhnMQIrsylhkZeOGxgPcJyPVj);
		dBLwIEXZxfMKKneOOopDNoulAThu = new List<InputActionSourceData>();
		eAfdxshvqOTcPFxDJlXYpPQPAMdZA = new ReadOnlyCollection<InputActionSourceData>(dBLwIEXZxfMKKneOOopDNoulAThu);
	}

	internal static void NMlkFRMJiiZMLehFQWHoGfTcSKQH(ConfigVars P_0)
	{
		uVPHALnRyWPyZIPswGPefvhPuIvg = new FhkqWWlwwJhbffxVDQCIJIPwisNo(P_0.updateLoop);
	}

	internal static void rhfsIOZgFjqJHGaUKluSvUSDtwff(UpdateLoopType P_0)
	{
		JvocSMbcsVCXgKoYxmuxIzmildeEA = P_0;
		hYvcAstVbKiynNfzPuUEMGaWTRLV = ReInput.unscaledTime;
		TfXgDSRscjWSaDAbswaEwsbJKctJ = (float)ReInput.unscaledDeltaTime;
		cqsMudFFbwEzahIQRfsKgWihteuyB = ReInput.absFrame;
		uVPHALnRyWPyZIPswGPefvhPuIvg.gILbdsgXCWIcEKGGFrCOtVsBAvtXA(P_0);
	}

	internal static void nixqjcAcHwIpmyRKZsjmytSNcSUl()
	{
		uVPHALnRyWPyZIPswGPefvhPuIvg.EDPxAjpZGgEOYHLdmdjUjsYVJnMl();
	}

	private void vlDOAZosXVobrtIynZmUMMxaQHjo()
	{
		BCsGtgAxASwOfYszbpskBSVZczIv.FdIBpvnOzEDGqOHJaZLSwLsIqORH = JvocSMbcsVCXgKoYxmuxIzmildeEA;
		BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.UGWzOUPwmblcYFyWrFEnoNzhPzCq();
		BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.kmRtUcmuifbcONbyjJcwMSBfvhTO();
		if (GyYPyrCpRLVmbFSqOPWHWIpTIoMD != 0f)
		{
			GyYPyrCpRLVmbFSqOPWHWIpTIoMD = 0f;
		}
		if (kLSAieQZQVbhoEbGxtaNyoMCqufu != 0f)
		{
			kLSAieQZQVbhoEbGxtaNyoMCqufu = 0f;
		}
		if (DBbOsUmWkjsFyRpXSHgdHBiqNXRe != ButtonStateFlags.Off)
		{
			DBbOsUmWkjsFyRpXSHgdHBiqNXRe = ButtonStateFlags.Off;
		}
		if (wqHBjdBgLHQWjgYcyoXKbdXrAhHm != ButtonStateFlags.Off)
		{
			wqHBjdBgLHQWjgYcyoXKbdXrAhHm = ButtonStateFlags.Off;
		}
		if (FbExYpCaGkCIEANVkixCsucVcVJFA != 0f)
		{
			FbExYpCaGkCIEANVkixCsucVcVJFA = 0f;
		}
		if (vMsqDjInivgCEGiHxBCewEKefqkbA)
		{
			vMsqDjInivgCEGiHxBCewEKefqkbA = false;
		}
		if (oNSaFokAWSXpCNgOqwhNOxVAPvrhA != 0f)
		{
			oNSaFokAWSXpCNgOqwhNOxVAPvrhA = 0f;
		}
		if (BkxPtFxxuVjtJufisjLCCUJhCbCG != 0f)
		{
			BkxPtFxxuVjtJufisjLCCUJhCbCG = 0f;
		}
		if (ItAkeVJWkEelDlqAMkVzclupyUcS != AxisCoordinateMode.Absolute)
		{
			ItAkeVJWkEelDlqAMkVzclupyUcS = AxisCoordinateMode.Absolute;
		}
		if (KbgCgQcfMYvHPgpmqwgfPJQLCTIK != AxisCoordinateMode.Absolute)
		{
			KbgCgQcfMYvHPgpmqwgfPJQLCTIK = AxisCoordinateMode.Absolute;
		}
		if (CHajixFAUrMvFlVdRtKbcXqapEaO > 0)
		{
			RAvULHKPHcdoRCGrKnNYkGEujFUQ();
		}
		if (uvMDMjbqrMyJDCdoxSgUMzjbuMaH.XQjaCpicQwqpGbXUCLzOJfgiAdCkc)
		{
			uvMDMjbqrMyJDCdoxSgUMzjbuMaH.kdCMwhkHJRjOvRyUBRNKuTFNjcKv();
		}
	}

	internal void yIrELBjsOnHeYGHAADOiWSZOtwEiB(bool P_0)
	{
		if (ZwgLpCMMIyOgtLvJtiHafUUbBbdn != cqsMudFFbwEzahIQRfsKgWihteuyB)
		{
			ZwgLpCMMIyOgtLvJtiHafUUbBbdn = cqsMudFFbwEzahIQRfsKgWihteuyB;
			if (aouxRNSWdalJzuqbpsbwczLuwfYr != DQvudLTsOmnvZgNOnemtHoScpAHLA)
			{
				aouxRNSWdalJzuqbpsbwczLuwfYr = DQvudLTsOmnvZgNOnemtHoScpAHLA;
			}
			if (MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
			{
				vlDOAZosXVobrtIynZmUMMxaQHjo();
			}
			else if (DQvudLTsOmnvZgNOnemtHoScpAHLA == SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled)
			{
				DQvudLTsOmnvZgNOnemtHoScpAHLA = SNwohbMULvtsqCoYLGoptSyIlJqI.Idle;
			}
		}
		if (!P_0)
		{
			return;
		}
		if (rwEyCkTAjSPWLKAxAAfuavDMJPzXA != cqsMudFFbwEzahIQRfsKgWihteuyB)
		{
			rwEyCkTAjSPWLKAxAAfuavDMJPzXA = cqsMudFFbwEzahIQRfsKgWihteuyB;
			if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
			{
				DSROsmtnHWZATgFLMDbCsuIfVZhT();
				vlDOAZosXVobrtIynZmUMMxaQHjo();
			}
			BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.jkoeOBeBQOxzCdNpDTwHNxCpYpTAA = hYvcAstVbKiynNfzPuUEMGaWTRLV;
		}
		GzcteHVAfAafMobmLlSAJXPvwqFL udmQYSAbdznnxGatFkGbeSAHoaYM = UdmQYSAbdznnxGatFkGbeSAHoaYM;
		int fpLTJzOTpoUWkyThKhrqRzXDquMW = udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc.fpLTJzOTpoUWkyThKhrqRzXDquMW;
		QFXaNpoaOtYOhTeyzmxHGPTdIpMO(udmQYSAbdznnxGatFkGbeSAHoaYM.ybknGBKDxfcqoptlGzrmiunQcNQd, udmQYSAbdznnxGatFkGbeSAHoaYM.rvQeyYKKuOtqobffnuGgObRodBPG, udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc);
		if (udmQYSAbdznnxGatFkGbeSAHoaYM.iKxJuNMacuDbqIfJzRyJOHaTUoKh == ControllerElementType.Button)
		{
			if (udmQYSAbdznnxGatFkGbeSAHoaYM.kWUoNReOofPXiVuzclhTsWonzAKF)
			{
				if (udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc._axisContribution == Pole.Positive)
				{
					IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref DBbOsUmWkjsFyRpXSHgdHBiqNXRe, udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA);
				}
				else
				{
					IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref wqHBjdBgLHQWjgYcyoXKbdXrAhHm, udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA);
				}
				if (ItAkeVJWkEelDlqAMkVzclupyUcS == AxisCoordinateMode.Absolute)
				{
					GyYPyrCpRLVmbFSqOPWHWIpTIoMD += udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS;
				}
				return;
			}
			if (udmQYSAbdznnxGatFkGbeSAHoaYM.oINnxwklOGWjkmeFEwCWyrYLGwxc._axisContribution == Pole.Positive)
			{
				IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref DBbOsUmWkjsFyRpXSHgdHBiqNXRe, udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA);
			}
			else
			{
				IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref wqHBjdBgLHQWjgYcyoXKbdXrAhHm, udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA);
			}
			if (udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS != 0f)
			{
				FbExYpCaGkCIEANVkixCsucVcVJFA += (int)(1f * MathTools.Sign(udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS));
				uvMDMjbqrMyJDCdoxSgUMzjbuMaH.yHqcaowODFFwJPEvtKhtlPSSRZqu(udmQYSAbdznnxGatFkGbeSAHoaYM);
			}
			if ((udmQYSAbdznnxGatFkGbeSAHoaYM.dxmfwlBKyJgKTHhYIvbCzwuzluuxA & ButtonStateFlags.On) != ButtonStateFlags.Off)
			{
				vMsqDjInivgCEGiHxBCewEKefqkbA = true;
			}
			return;
		}
		if (udmQYSAbdznnxGatFkGbeSAHoaYM.iKxJuNMacuDbqIfJzRyJOHaTUoKh == ControllerElementType.Axis)
		{
			switch (udmQYSAbdznnxGatFkGbeSAHoaYM.WcxJgpdLbutPonSkkyogJpvoNTle)
			{
			case ControllerType.Mouse:
				if ((fpLTJzOTpoUWkyThKhrqRzXDquMW < 2 && kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisMode == MouseXYAxisMode.DigitalAxis) || (fpLTJzOTpoUWkyThKhrqRzXDquMW > 1 && kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseOtherAxisMode == MouseOtherAxisMode.DigitalAxis))
				{
					UhVrQRpUeiNJodhgbwttIbHjNxZs(udmQYSAbdznnxGatFkGbeSAHoaYM, 0f, true);
					break;
				}
				if (fpLTJzOTpoUWkyThKhrqRzXDquMW < 2)
				{
					if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
					{
						oNSaFokAWSXpCNgOqwhNOxVAPvrhA += udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS * kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisSensitivity;
					}
					else if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisMode == MouseXYAxisMode.ScreenPositionDelta || kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisMode == MouseXYAxisMode.Speed)
					{
						float num;
						float num2;
						if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.Normal)
						{
							num = Screen.width;
							num2 = Screen.height;
						}
						else if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenWidth)
						{
							num = Screen.width;
							num2 = num;
						}
						else
						{
							if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.ScreenHeight)
							{
								throw new NotImplementedException();
							}
							num2 = Screen.height;
							num = num2;
						}
						FhkqWWlwwJhbffxVDQCIJIPwisNo.hBwHXKipIrjsZkKyZBKzswINBdNL hBwHXKipIrjsZkKyZBKzswINBdNL = uVPHALnRyWPyZIPswGPefvhPuIvg.JKVOTzKxEiwdlbtWzGRqErcdQbBN;
						if (fpLTJzOTpoUWkyThKhrqRzXDquMW == 0)
						{
							float x = hBwHXKipIrjsZkKyZBKzswINBdNL.EEdZOsguTTURWTeIeCwfpzQdBtnP.x;
							if (x != 0f)
							{
								float num3 = x / num;
								if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisMode == MouseXYAxisMode.Speed)
								{
									num3 /= TfXgDSRscjWSaDAbswaEwsbJKctJ;
								}
								oNSaFokAWSXpCNgOqwhNOxVAPvrhA += num3;
							}
						}
						else
						{
							float y = hBwHXKipIrjsZkKyZBKzswINBdNL.EEdZOsguTTURWTeIeCwfpzQdBtnP.y;
							if (y != 0f)
							{
								float num4 = y / num2;
								if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseXYAxisMode == MouseXYAxisMode.Speed)
								{
									num4 /= TfXgDSRscjWSaDAbswaEwsbJKctJ;
								}
								oNSaFokAWSXpCNgOqwhNOxVAPvrhA += num4;
							}
						}
					}
				}
				else if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseOtherAxisMode == MouseOtherAxisMode.MouseAxis)
				{
					oNSaFokAWSXpCNgOqwhNOxVAPvrhA += udmQYSAbdznnxGatFkGbeSAHoaYM.nVgyBosFgMfEgEIRGJBOvhwPcECS * kIOElRBhtNsYpnnSjSnGoIKNoQBkA.mouseOtherAxisSensitivity;
				}
				UhVrQRpUeiNJodhgbwttIbHjNxZs(udmQYSAbdznnxGatFkGbeSAHoaYM, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonDeadZone, false);
				break;
			case ControllerType.Joystick:
				kspuGDpjumckOpHwGeiRoUrABvJgA(udmQYSAbdznnxGatFkGbeSAHoaYM, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.joystickAxisSensitivity);
				break;
			case ControllerType.Custom:
				kspuGDpjumckOpHwGeiRoUrABvJgA(udmQYSAbdznnxGatFkGbeSAHoaYM, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.customControllerAxisSensitivity);
				break;
			default:
				throw new NotImplementedException();
			}
			return;
		}
		throw new NotImplementedException();
	}

	private void kspuGDpjumckOpHwGeiRoUrABvJgA(GzcteHVAfAafMobmLlSAJXPvwqFL P_0, float P_1)
	{
		float num = P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS * P_1;
		if (P_0.MdZuMpKNfEqOTajQmIcoBxjeyrOg)
		{
			if (P_0.eTmTAeqmpDvAHPsCtSeuLWngFCNH == AxisCoordinateMode.Absolute)
			{
				if (ItAkeVJWkEelDlqAMkVzclupyUcS == AxisCoordinateMode.Absolute)
				{
					GyYPyrCpRLVmbFSqOPWHWIpTIoMD += num;
				}
			}
			else if (P_0.eTmTAeqmpDvAHPsCtSeuLWngFCNH == AxisCoordinateMode.Relative)
			{
				if (ItAkeVJWkEelDlqAMkVzclupyUcS != AxisCoordinateMode.Relative)
				{
					GyYPyrCpRLVmbFSqOPWHWIpTIoMD = num;
					ItAkeVJWkEelDlqAMkVzclupyUcS = AxisCoordinateMode.Relative;
				}
				else
				{
					GyYPyrCpRLVmbFSqOPWHWIpTIoMD = MathTools.MaxMagnitude(GyYPyrCpRLVmbFSqOPWHWIpTIoMD, num);
				}
			}
		}
		else if (P_0.eTmTAeqmpDvAHPsCtSeuLWngFCNH == AxisCoordinateMode.Absolute)
		{
			if (KbgCgQcfMYvHPgpmqwgfPJQLCTIK == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(kLSAieQZQVbhoEbGxtaNyoMCqufu))
			{
				kLSAieQZQVbhoEbGxtaNyoMCqufu = num;
			}
		}
		else if (P_0.eTmTAeqmpDvAHPsCtSeuLWngFCNH == AxisCoordinateMode.Relative)
		{
			if (KbgCgQcfMYvHPgpmqwgfPJQLCTIK != AxisCoordinateMode.Relative)
			{
				kLSAieQZQVbhoEbGxtaNyoMCqufu = num;
				KbgCgQcfMYvHPgpmqwgfPJQLCTIK = AxisCoordinateMode.Relative;
			}
			else if (MathTools.Abs(num) > MathTools.Abs(kLSAieQZQVbhoEbGxtaNyoMCqufu))
			{
				kLSAieQZQVbhoEbGxtaNyoMCqufu = num;
			}
		}
		UhVrQRpUeiNJodhgbwttIbHjNxZs(P_0, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonDeadZone, false);
	}

	private void UhVrQRpUeiNJodhgbwttIbHjNxZs(GzcteHVAfAafMobmLlSAJXPvwqFL P_0, float P_1, bool P_2)
	{
		XQbPBhlyQFBGpNmlFgFIDEslKZJP xQbPBhlyQFBGpNmlFgFIDEslKZJP = XQbPBhlyQFBGpNmlFgFIDEslKZJP.AlseqFygUpijvvuzMomIBteKutUo(P_0.oINnxwklOGWjkmeFEwCWyrYLGwxc.gjHUlVyQSQsjZEOHtHfmeehEQpiIA, XQbPBhlyQFBGpNmlFgFIDEslKZJP.xyrBiUFcLFiQhnXPGmvEmNtNzoeY.ivDtCkVBJEhQqUgjTpGImrOMMWOG);
		if (P_0.oINnxwklOGWjkmeFEwCWyrYLGwxc._axisRange == AxisRange.Full)
		{
			if (MathTools.Abs(P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS) > P_1)
			{
				xQbPBhlyQFBGpNmlFgFIDEslKZJP.VMzjUdUTFLzEoJGXHnthtJLVIjNk(JvocSMbcsVCXgKoYxmuxIzmildeEA, P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS > 0f);
			}
			ButtonStateFlags buttonStateFlags = xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(true);
			ButtonStateFlags buttonStateFlags2 = xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(false);
			IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref DBbOsUmWkjsFyRpXSHgdHBiqNXRe, buttonStateFlags);
			IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref wqHBjdBgLHQWjgYcyoXKbdXrAhHm, buttonStateFlags2);
			if (P_2 && ((buttonStateFlags & ButtonStateFlags.On) != ButtonStateFlags.Off || (buttonStateFlags2 & ButtonStateFlags.On) != ButtonStateFlags.Off))
			{
				if (P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS != 0f)
				{
					FbExYpCaGkCIEANVkixCsucVcVJFA += (int)(1f * MathTools.Sign(P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS));
					uvMDMjbqrMyJDCdoxSgUMzjbuMaH.yHqcaowODFFwJPEvtKhtlPSSRZqu(P_0);
				}
				vMsqDjInivgCEGiHxBCewEKefqkbA = true;
			}
			return;
		}
		ButtonStateFlags buttonStateFlags3;
		if (P_0.oINnxwklOGWjkmeFEwCWyrYLGwxc._axisContribution == Pole.Positive)
		{
			if (P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS > P_1)
			{
				xQbPBhlyQFBGpNmlFgFIDEslKZJP.VMzjUdUTFLzEoJGXHnthtJLVIjNk(JvocSMbcsVCXgKoYxmuxIzmildeEA, true);
			}
			buttonStateFlags3 = xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(true);
			IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref DBbOsUmWkjsFyRpXSHgdHBiqNXRe, buttonStateFlags3);
		}
		else
		{
			if (MathTools.Abs(P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS) > P_1)
			{
				xQbPBhlyQFBGpNmlFgFIDEslKZJP.VMzjUdUTFLzEoJGXHnthtJLVIjNk(JvocSMbcsVCXgKoYxmuxIzmildeEA, false);
			}
			buttonStateFlags3 = xQbPBhlyQFBGpNmlFgFIDEslKZJP.oXDUmGfgWGHrNNbJhHGRfncigPAV(false);
			IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref wqHBjdBgLHQWjgYcyoXKbdXrAhHm, buttonStateFlags3);
		}
		if (P_2)
		{
			if (P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS != 0f)
			{
				FbExYpCaGkCIEANVkixCsucVcVJFA += (int)(1f * MathTools.Sign(P_0.nVgyBosFgMfEgEIRGJBOvhwPcECS));
				uvMDMjbqrMyJDCdoxSgUMzjbuMaH.yHqcaowODFFwJPEvtKhtlPSSRZqu(P_0);
			}
			if ((buttonStateFlags3 & ButtonStateFlags.On) != ButtonStateFlags.Off)
			{
				vMsqDjInivgCEGiHxBCewEKefqkbA = true;
			}
		}
	}

	internal void JvrOmaaEiOtVPDHhZJADKqjIcAXH()
	{
		if (ZwgLpCMMIyOgtLvJtiHafUUbBbdn != cqsMudFFbwEzahIQRfsKgWihteuyB)
		{
			jqJLAWnWsAIJoGRJwiHMuudimrAN(false);
		}
		else
		{
			if (DQvudLTsOmnvZgNOnemtHoScpAHLA == SNwohbMULvtsqCoYLGoptSyIlJqI.Idle)
			{
				return;
			}
			mdKeBwiojDNtQakLqIFsMDHnLJRd.WVlnTdkcVUOeTOGOChgTmzQPwLSn xTujhIaItbDIZIUeYPNwvwUsXkDt = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt;
			xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib = DBbOsUmWkjsFyRpXSHgdHBiqNXRe;
			xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA = wqHBjdBgLHQWjgYcyoXKbdXrAhHm;
			if (oNSaFokAWSXpCNgOqwhNOxVAPvrhA != 0f)
			{
				xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY = oNSaFokAWSXpCNgOqwhNOxVAPvrhA;
				xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb = AxisCoordinateMode.Relative;
			}
			else if (kLSAieQZQVbhoEbGxtaNyoMCqufu != 0f)
			{
				xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY = kLSAieQZQVbhoEbGxtaNyoMCqufu;
				xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb = KbgCgQcfMYvHPgpmqwgfPJQLCTIK;
			}
			else
			{
				float fepSIVMxGbmIMpGqzewBFnzSCrsY = MathTools.Clamp(GyYPyrCpRLVmbFSqOPWHWIpTIoMD, -1f, 1f);
				xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY = fepSIVMxGbmIMpGqzewBFnzSCrsY;
				xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb = ItAkeVJWkEelDlqAMkVzclupyUcS;
			}
			if (uNQgqcFaupnIyuWoINNkBtYfuRXN)
			{
				xTujhIaItbDIZIUeYPNwvwUsXkDt.LtNUCtGOsEzFUvULxuRpSxboezBd();
				uNQgqcFaupnIyuWoINNkBtYfuRXN = false;
			}
			jXKWvkAdBxCYdfufEgFQrLWsgwQiA();
			xTujhIaItbDIZIUeYPNwvwUsXkDt.ojyAaPnbMzkPmnaqsLGBruXVoJhs(hYvcAstVbKiynNfzPuUEMGaWTRLV);
			if (xTujhIaItbDIZIUeYPNwvwUsXkDt.MRolaAhuSyEXdsFJIChVZhKZQaCV != null)
			{
				if (WbgyrFPQhbxQWxjDirEsquvUHPxh())
				{
					xTujhIaItbDIZIUeYPNwvwUsXkDt.MRolaAhuSyEXdsFJIChVZhKZQaCV.Start(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonDownBuffer);
				}
				if (eUjEFIHdXPbTfJKOTAchBQFcpERkc())
				{
					xTujhIaItbDIZIUeYPNwvwUsXkDt.NucjAiglLSlCwQTBdkJDGzHNOaTi.Start(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonDownBuffer);
				}
			}
			xTujhIaItbDIZIUeYPNwvwUsXkDt.xWzAfyfsoeGJcZmtHvcvwbXgPTVfb(riuGhwaMOAdFGDFRYDzUUxYehYkQ(), IPBglEDiskLyDaFoCmNkHNTILvkoD(), KhxBPpPiOXgSvGNtPRGOvHsskrZq(), EVDaaHKwprBiqlvanCLDzZZcIJDp());
			if (pniSluyPebNFsIouxpvojCqGZjoI)
			{
				KlHbbyIakfpBBCDKbWIOlqpkYEyZb();
			}
			if (rwEyCkTAjSPWLKAxAAfuavDMJPzXA != cqsMudFFbwEzahIQRfsKgWihteuyB && BCsGtgAxASwOfYszbpskBSVZczIv.gQgoWsNWSPyWZtAWPKraZzyAbZaf())
			{
				jqJLAWnWsAIJoGRJwiHMuudimrAN(true);
			}
		}
	}

	internal void jXKWvkAdBxCYdfufEgFQrLWsgwQiA()
	{
		if (uvMDMjbqrMyJDCdoxSgUMzjbuMaH.XQjaCpicQwqpGbXUCLzOJfgiAdCkc)
		{
			BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.XpfWEyHiQyxgaHNOispfZpdzHHql.jWLBrTqdFqMRmJrRgpJVUCbdkqEd(uvMDMjbqrMyJDCdoxSgUMzjbuMaH);
		}
		BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.urktPppRkFQXtEfRKKXOqQNOmMUS = MathTools.Clamp(FbExYpCaGkCIEANVkixCsucVcVJFA, -1f, 1f);
		if (!kIOElRBhtNsYpnnSjSnGoIKNoQBkA.digitalAxisSimulation)
		{
			BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.urktPppRkFQXtEfRKKXOqQNOmMUS;
			if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.XpfWEyHiQyxgaHNOispfZpdzHHql.XQjaCpicQwqpGbXUCLzOJfgiAdCkc)
			{
				BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.XpfWEyHiQyxgaHNOispfZpdzHHql.kdCMwhkHJRjOvRyUBRNKuTFNjcKv();
			}
			return;
		}
		if (!vMsqDjInivgCEGiHxBCewEKefqkbA)
		{
			if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky != 0f && kIOElRBhtNsYpnnSjSnGoIKNoQBkA.digitalAxisGravity != 0f)
			{
				float num = kIOElRBhtNsYpnnSjSnGoIKNoQBkA.digitalAxisGravity * TfXgDSRscjWSaDAbswaEwsbJKctJ;
				if (MathTools.Abs(num) >= MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky))
				{
					BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky = 0f;
					BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.XpfWEyHiQyxgaHNOispfZpdzHHql.kdCMwhkHJRjOvRyUBRNKuTFNjcKv();
					return;
				}
				float num2 = ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky > 0f) ? (-1f) : 1f);
				BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky = MathTools.Clamp(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky + num2 * num, -1f, 1f);
				vzOsYWLwkZfRLdvSwlWqPwvPltic xpfWEyHiQyxgaHNOispfZpdzHHql = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.XpfWEyHiQyxgaHNOispfZpdzHHql;
				QFXaNpoaOtYOhTeyzmxHGPTdIpMO(xpfWEyHiQyxgaHNOispfZpdzHHql.kYKazRsVgPALNGczLqXIRXTdCdqaA, xpfWEyHiQyxgaHNOispfZpdzHHql.YIARubiJuKAEMizOTgrNjuJLAHweb, xpfWEyHiQyxgaHNOispfZpdzHHql.zzEoexVONIGXsBPUmlUdyhDiwWzDA);
			}
			return;
		}
		float num3 = MathTools.Clamp(FbExYpCaGkCIEANVkixCsucVcVJFA, -1f, 1f);
		float num4 = ((num3 != 0f) ? MathTools.Sign(num3) : 0f);
		float num5 = ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky != 0f) ? MathTools.Sign(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky) : 0f);
		float digitalAxisSensitivity = kIOElRBhtNsYpnnSjSnGoIKNoQBkA.digitalAxisSensitivity;
		if (digitalAxisSensitivity > 0f)
		{
			num3 *= digitalAxisSensitivity * TfXgDSRscjWSaDAbswaEwsbJKctJ;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky != 0f)
		{
			if ((num3 != 0f && num4 != num5) ? true : false)
			{
				if (kIOElRBhtNsYpnnSjSnGoIKNoQBkA.digitalAxisInstantReverse)
				{
					num3 += -1f * BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky;
				}
				else if (!kIOElRBhtNsYpnnSjSnGoIKNoQBkA.digitalAxisSnap)
				{
					num3 += BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky;
				}
			}
			else
			{
				num3 += BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky;
			}
		}
		else
		{
			num3 += BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky;
		}
		BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky = MathTools.Clamp(num3, -1f, 1f);
	}

	public float MsemiDNvFwuvkRHSoRvueQDDCJHf()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0f;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb == AxisCoordinateMode.Relative)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY;
		}
		return MathTools.MaxMagnitude(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky);
	}

	public float iARuJzhKfksmmefEbtjGLMIccAzj()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0f;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.EvGWyIIAcKQuRHyOhhIlZXDFAMBe == AxisCoordinateMode.Relative)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zHBeEKpGFqCAShieOcJNnPyahQkq;
		}
		return MathTools.MaxMagnitude(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zHBeEKpGFqCAShieOcJNnPyahQkq, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.xBWwwSLXCOivcVxAcMQBBpprnErw);
	}

	public float ExxDOAmagHRcREqfGZQurrWsFuDc()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0f;
		}
		return MsemiDNvFwuvkRHSoRvueQDDCJHf() - iARuJzhKfksmmefEbtjGLMIccAzj();
	}

	public double XiKxkUgGTtihtRtvqpcwOGOecMTd()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0.0;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.vbLPfQOMmEVJePkWVVgaYaminbxi;
	}

	public double XuKFMGOoNSwfKUGeWhrwBSlRElRQ()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			QnvOWWqbCqbpQIghRDzbvGflhIKA();
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.YibEMuWKeIfErisMkEcFgYmmaUCz;
	}

	public AxisCoordinateMode LQaElQuMCTXqbYumMnzYmPARIRub()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY) >= MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.wzxhYUevedjdyANywFGgXJsLAiky))
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode FuQAMivUrksgreotkQRWeINQfpWi()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zHBeEKpGFqCAShieOcJNnPyahQkq) >= MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.xBWwwSLXCOivcVxAcMQBBpprnErw))
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.EvGWyIIAcKQuRHyOhhIlZXDFAMBe;
		}
		return AxisCoordinateMode.Absolute;
	}

	public float DeKBwydovtExYTMFfxXAMhbNoHGib()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0f;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb == AxisCoordinateMode.Relative)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY;
		}
		return MathTools.MaxMagnitude(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.urktPppRkFQXtEfRKKXOqQNOmMUS);
	}

	public float MqeXSgkURrlITajbbOSBTjoHZyCA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0f;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.EvGWyIIAcKQuRHyOhhIlZXDFAMBe == AxisCoordinateMode.Relative)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zHBeEKpGFqCAShieOcJNnPyahQkq;
		}
		return MathTools.MaxMagnitude(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zHBeEKpGFqCAShieOcJNnPyahQkq, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.cpmbbGFKDyNaFBOaGTLtBNECuoHI);
	}

	public float BdaHQfLkEvGBCUeozQWwIYuZHFar()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0f;
		}
		return DeKBwydovtExYTMFfxXAMhbNoHGib() - MqeXSgkURrlITajbbOSBTjoHZyCA();
	}

	public double KElJOkInzYZLQVwltsxzlrlgwXtM()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0.0;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.mnsWKJruptoaJQIdQwpslZUgjxAg;
	}

	public double roHxuXfMZhsRBUAwHVnNJcpuOWDc()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			QnvOWWqbCqbpQIghRDzbvGflhIKA();
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.okrBIlKnBCusFRDGVtbbjXXJhjpgA;
	}

	public AxisCoordinateMode vDulGhZlxqUzfkQBKWdlZKXfafgjA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.fepSIVMxGbmIMpGqzewBFnzSCrsY) >= MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.urktPppRkFQXtEfRKKXOqQNOmMUS))
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.ZcDBmwFLwFhnqBhCDTqPdjDnbGCTb;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode bNxKzNquaqGmLwDjtddfJNBiYgOuA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zHBeEKpGFqCAShieOcJNnPyahQkq) >= MathTools.Abs(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.cpmbbGFKDyNaFBOaGTLtBNECuoHI))
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.EvGWyIIAcKQuRHyOhhIlZXDFAMBe;
		}
		return AxisCoordinateMode.Absolute;
	}

	public bool IPBglEDiskLyDaFoCmNkHNTILvkoD()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) != 0;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) == 0)
		{
			return EVDaaHKwprBiqlvanCLDzZZcIJDp();
		}
		return true;
	}

	public bool riuGhwaMOAdFGDFRYDzUUxYehYkQ()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.MRolaAhuSyEXdsFJIChVZhKZQaCV == null)
		{
			return WbgyrFPQhbxQWxjDirEsquvUHPxh();
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.MRolaAhuSyEXdsFJIChVZhKZQaCV.running)
		{
			return true;
		}
		if (kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue && BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NucjAiglLSlCwQTBdkJDGzHNOaTi.running)
		{
			return true;
		}
		return false;
	}

	public bool bSwJemwUEXGGBhhqyxFRvLmWIqGY()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Up) != 0;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Up) == 0 && (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Up) == 0)
		{
			return false;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) != ButtonStateFlags.Off)
		{
			return false;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) != ButtonStateFlags.Off)
		{
			return false;
		}
		return true;
	}

	public bool MsrPrsRShXkgVvDLLEcmCVbzOLQcA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.QtEuCBvrlUqaxweyGZcCipcaBMYE;
		}
		if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.QtEuCBvrlUqaxweyGZcCipcaBMYE)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.QtEuCBvrlUqaxweyGZcCipcaBMYE;
		}
		return true;
	}

	public bool IVgCBhoYMSCaNnypJLyYwFolNdOM()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.ewokzfvfkXOlIRAVoyvfAUDHFAnp;
		}
		bool flag = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.ewokzfvfkXOlIRAVoyvfAUDHFAnp;
		bool flag2 = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.ewokzfvfkXOlIRAVoyvfAUDHFAnp;
		if (!flag && !flag2)
		{
			return false;
		}
		if (!flag && BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.QtEuCBvrlUqaxweyGZcCipcaBMYE)
		{
			return false;
		}
		if (!flag2 && BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.QtEuCBvrlUqaxweyGZcCipcaBMYE)
		{
			return false;
		}
		return true;
	}

	public bool IgudzUOMbpcOxmaZREBGjJgoJIdR()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.qzwhYwoPRnYezUAlRxLPqRHDGLMg;
		}
		bool num = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.qzwhYwoPRnYezUAlRxLPqRHDGLMg;
		bool flag = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.qzwhYwoPRnYezUAlRxLPqRHDGLMg;
		if (!num && !flag)
		{
			return false;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.QtEuCBvrlUqaxweyGZcCipcaBMYE)
		{
			return false;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.QtEuCBvrlUqaxweyGZcCipcaBMYE)
		{
			return false;
		}
		return true;
	}

	public bool pcSwGAONmZlhYxnjFhOxZFzCnXKf()
	{
		return hckAhLzhvsGrGziwjLVYftlXjutR(0f);
	}

	public bool hckAhLzhvsGrGziwjLVYftlXjutR(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
			{
				return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.iRPqIcIyucvLmbKsccANuaxbxfh(P_0);
			}
			if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.iRPqIcIyucvLmbKsccANuaxbxfh(P_0))
			{
				return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.iRPqIcIyucvLmbKsccANuaxbxfh(P_0);
			}
			return true;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
		}
		if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.uPNZLfUKuQIqNDQyZGTVXTClGoeD)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
		}
		return true;
	}

	public bool GWidDBskfsOUcIruxijQqOWxDSXeA()
	{
		return mXMcUQLDjZKLbSwyrIXXizIZMakC(0f);
	}

	public bool mXMcUQLDjZKLbSwyrIXXizIZMakC(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!riuGhwaMOAdFGDFRYDzUUxYehYkQ())
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.iRPqIcIyucvLmbKsccANuaxbxfh(P_0);
			}
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
		}
		if (P_0 > 0f)
		{
			if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.iRPqIcIyucvLmbKsccANuaxbxfh(P_0))
			{
				return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.iRPqIcIyucvLmbKsccANuaxbxfh(P_0);
			}
			return true;
		}
		if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.uPNZLfUKuQIqNDQyZGTVXTClGoeD)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
		}
		return true;
	}

	public bool KCDIMXAWapdXMarBIjGgyPDjYWOXB()
	{
		return KAqgQWsIxLEjXBUDMPaMLyXeYtAn(0f);
	}

	public bool KAqgQWsIxLEjXBUDMPaMLyXeYtAn(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!bSwJemwUEXGGBhhqyxFRvLmWIqGY())
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.uZrMtsKjYqLhTLfqQyZeeJfWZpwA(P_0);
			}
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.HCZYihrbtaWaZXuqoLXAASPuwygI;
		}
		if (P_0 > 0f)
		{
			if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.uZrMtsKjYqLhTLfqQyZeeJfWZpwA(P_0))
			{
				return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.uZrMtsKjYqLhTLfqQyZeeJfWZpwA(P_0);
			}
			return true;
		}
		if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.IrulBVQnXVIsvdhGIKELnjsaaNHh.HCZYihrbtaWaZXuqoLXAASPuwygI)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.HCZYihrbtaWaZXuqoLXAASPuwygI;
		}
		return true;
	}

	public bool sikVcbcbQDvtQkNhSaefNgXSbcuS(float P_0)
	{
		return iLyUWcCExyFVnKqBTGfvQeHpisZi(P_0, 0f);
	}

	public bool iLyUWcCExyFVnKqBTGfvQeHpisZi(float P_0, float P_1)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!IPBglEDiskLyDaFoCmNkHNTILvkoD())
		{
			return false;
		}
		double num = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.LprxXWrZPXMFMZUTlHPwrGgjakCAA;
		if (kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			num = MathTools.Max(num, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.OQbjktutGMqFjhpGXhKbewptGLQg);
		}
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool jemjNeDdmCWQgidsYMLMtrxauMpI(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return WbgyrFPQhbxQWxjDirEsquvUHPxh();
		}
		if (!IPBglEDiskLyDaFoCmNkHNTILvkoD())
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			ButtonStateRecorder nTyVHRurVPfGxytttpBqDiTQPmNf = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf;
			if (nTyVHRurVPfGxytttpBqDiTQPmNf.xAPUFiODnOIrnBJfTaxdkidFbPax < (double)P_0)
			{
				return false;
			}
			if (ReInput.unscaledTimePrev - nTyVHRurVPfGxytttpBqDiTQPmNf.ZfijfERTYsbMwqVNeqtqOgAVjgQIA >= (double)P_0)
			{
				return false;
			}
			return true;
		}
		ButtonStateRecorder nTyVHRurVPfGxytttpBqDiTQPmNf2 = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf;
		ButtonStateRecorder dVWdQgSqhekYFgJFsNdapOuYUdXu = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu;
		if (nTyVHRurVPfGxytttpBqDiTQPmNf2.xAPUFiODnOIrnBJfTaxdkidFbPax < (double)P_0 && dVWdQgSqhekYFgJFsNdapOuYUdXu.xAPUFiODnOIrnBJfTaxdkidFbPax < (double)P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - nTyVHRurVPfGxytttpBqDiTQPmNf2.ZfijfERTYsbMwqVNeqtqOgAVjgQIA >= (double)P_0 || ReInput.unscaledTimePrev - dVWdQgSqhekYFgJFsNdapOuYUdXu.ZfijfERTYsbMwqVNeqtqOgAVjgQIA >= (double)P_0)
		{
			return false;
		}
		return true;
	}

	public bool zlGdrGtgpztSDKNVsKGGFEoRRfHl(float P_0)
	{
		return ItrlVrVHcgtqpFPEduZHYaUCqwsA(P_0, 0f);
	}

	public bool ItrlVrVHcgtqpFPEduZHYaUCqwsA(float P_0, float P_1)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!bSwJemwUEXGGBhhqyxFRvLmWIqGY())
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			double num = ReInput.unscaledTime - BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.rHaMzQGpDBBiOIKJmRdebShfdaqeA;
			if (num < (double)P_0)
			{
				return false;
			}
			if (P_1 > 0f && num >= (double)(P_0 + P_1))
			{
				return false;
			}
			return true;
		}
		double num2 = ReInput.unscaledTime - MathTools.Max(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NTyVHRurVPfGxytttpBqDiTQPmNf.rHaMzQGpDBBiOIKJmRdebShfdaqeA, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.rHaMzQGpDBBiOIKJmRdebShfdaqeA);
		if (num2 < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num2 >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool UETjCacldnZLRsCFfOVVOpvGqwdQ()
	{
		return iLyUWcCExyFVnKqBTGfvQeHpisZi(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressExpiresIn);
	}

	public bool ATbRCRlVsJgfySlKcqwDTzADtFRI()
	{
		return jemjNeDdmCWQgidsYMLMtrxauMpI(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressTime);
	}

	public bool uVNPDdyMewbdUMNPZOzbJiEcBZXf()
	{
		return ItrlVrVHcgtqpFPEduZHYaUCqwsA(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressExpiresIn);
	}

	public bool XTygVrQDMeWzdvNCcbVUNEDkwhfC()
	{
		return iLyUWcCExyFVnKqBTGfvQeHpisZi(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressExpiresIn);
	}

	public bool lRGuwAswCvNtFPgHzSVLyVOVTlEC()
	{
		return jemjNeDdmCWQgidsYMLMtrxauMpI(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressTime);
	}

	public bool yWxoBlcLzlemoOuRRYRbcWvDjOcV()
	{
		return ItrlVrVHcgtqpFPEduZHYaUCqwsA(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressExpiresIn);
	}

	public bool saeQPtCwGGaeReinxCUMSwIrhYpF()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.uMHAXlRKRJGAAjdqnhvjWMUBvjqs.OmaOWPKbzSvMeBUfSRVOGLPbDnqP;
		}
		if (!BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.uMHAXlRKRJGAAjdqnhvjWMUBvjqs.OmaOWPKbzSvMeBUfSRVOGLPbDnqP)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.JvNSIFDWKlEsQqGPjybQKzgbGzST.OmaOWPKbzSvMeBUfSRVOGLPbDnqP;
		}
		return true;
	}

	public bool nEpMkgAlUKaHmxrXsfKeYHsLoBLs()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DrucdMwCYeegKKEpsMVeSwnZfVvR & ButtonStateFlags.On) != 0;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DrucdMwCYeegKKEpsMVeSwnZfVvR & ButtonStateFlags.On) == 0)
		{
			return wmkdKpTjlGQnDOmTMMrTrHwnIdMn();
		}
		return true;
	}

	public double zPnrApSpNsImmvGZMcFVanMSfpHKA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0.0;
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DfhGPObcbRbCbffruatJBTwAqmBsB;
		}
		return MathTools.Max(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DfhGPObcbRbCbffruatJBTwAqmBsB, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.AHeTcWbhnCWeajfaygIGpeGgBeSl);
	}

	public double KCXSSDWhrBKElyGJfiInJrZHDPlM()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			QnvOWWqbCqbpQIghRDzbvGflhIKA();
		}
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.LapGzleouizLhlPwWavltwppRan;
		}
		return MathTools.Min(BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.LapGzleouizLhlPwWavltwppRan, BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.uaqXojvelTHUpFzNwjWmgdmIFkkl);
	}

	private bool WbgyrFPQhbxQWxjDirEsquvUHPxh()
	{
		if (!kixDWPjWFuaKAGXvRudbLOCHyGOmA.activateActionButtonsOnNegativeValue)
		{
			return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) != 0;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) == 0 && (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) == 0)
		{
			return false;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.On) != ButtonStateFlags.Off && (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.TXgDCqgTurLNBwUnvRFpoLPmHFgib & ButtonStateFlags.Down) == 0)
		{
			return false;
		}
		if ((BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) != ButtonStateFlags.Off && (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) == 0)
		{
			return false;
		}
		return true;
	}

	public bool EVDaaHKwprBiqlvanCLDzZZcIJDp()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.On) != 0;
	}

	public bool KhxBPpPiOXgSvGNtPRGOvHsskrZq()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NucjAiglLSlCwQTBdkJDGzHNOaTi == null)
		{
			return eUjEFIHdXPbTfJKOTAchBQFcpERkc();
		}
		if (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.NucjAiglLSlCwQTBdkJDGzHNOaTi.running)
		{
			return true;
		}
		return false;
	}

	public bool BljscRLzpNviyYundTExtmvpLKYc()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Up) != 0;
	}

	public bool rGkjONohjkzPrXbjtneWnEsYAJiY()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.QtEuCBvrlUqaxweyGZcCipcaBMYE;
	}

	public bool PssLqSiqevMTMMAUxerYquegHQSU()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.ewokzfvfkXOlIRAVoyvfAUDHFAnp;
	}

	public bool TcMLIdmkPPhJICPtZbiektZPSCJSA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.qzwhYwoPRnYezUAlRxLPqRHDGLMg;
	}

	public bool rvGwiiqhiBZeaJVBVAOzSLZtxOjX()
	{
		return YrTrWftClZWtgPLbnibohShAEeuZ(0f);
	}

	public bool YrTrWftClZWtgPLbnibohShAEeuZ(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.iRPqIcIyucvLmbKsccANuaxbxfh(P_0);
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
	}

	public bool YoviFHAdcEKwAGpTGbJvXaPmsntn()
	{
		return YfTFApbwCYgRwLFdqfiQjkzWPNuab(0f);
	}

	public bool YfTFApbwCYgRwLFdqfiQjkzWPNuab(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!KhxBPpPiOXgSvGNtPRGOvHsskrZq())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.iRPqIcIyucvLmbKsccANuaxbxfh(P_0);
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
	}

	public bool vGLssieehRSnPXSswQKUWHAoyAsE()
	{
		return mASgYYxHWsnQZmJkMriECBovlKfw(0f);
	}

	public bool mASgYYxHWsnQZmJkMriECBovlKfw(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (!BljscRLzpNviyYundTExtmvpLKYc())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.uZrMtsKjYqLhTLfqQyZeeJfWZpwA(P_0);
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.HHdWUEsRAXfbCHNzAAqkFAvNLgaUA.HCZYihrbtaWaZXuqoLXAASPuwygI;
	}

	public bool AAJiCbFiHpVzbvgKgdPlfCVjrlyy(float P_0)
	{
		return YLhODevbPifVPfCqHgMeDIrcXKTZ(P_0, 0f);
	}

	public bool YLhODevbPifVPfCqHgMeDIrcXKTZ(float P_0, float P_1)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!EVDaaHKwprBiqlvanCLDzZZcIJDp())
		{
			return false;
		}
		double num = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.OQbjktutGMqFjhpGXhKbewptGLQg;
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool tUWRRMMUWPlLcOYXTSOBqCIELkSU(float P_0)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return eUjEFIHdXPbTfJKOTAchBQFcpERkc();
		}
		if (!EVDaaHKwprBiqlvanCLDzZZcIJDp())
		{
			return false;
		}
		ButtonStateRecorder dVWdQgSqhekYFgJFsNdapOuYUdXu = BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu;
		if (dVWdQgSqhekYFgJFsNdapOuYUdXu.xAPUFiODnOIrnBJfTaxdkidFbPax < (double)P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - dVWdQgSqhekYFgJFsNdapOuYUdXu.ZfijfERTYsbMwqVNeqtqOgAVjgQIA >= (double)P_0)
		{
			return false;
		}
		return true;
	}

	public bool LisaQvMsAvidOOkldncuYvDQOWEw(float P_0)
	{
		return MlFIiayGhxVYtdBnJSeOifmmXqPP(P_0, 0f);
	}

	public bool MlFIiayGhxVYtdBnJSeOifmmXqPP(float P_0, float P_1)
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!BljscRLzpNviyYundTExtmvpLKYc())
		{
			return false;
		}
		double num = ReInput.unscaledTime - BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.DVWdQgSqhekYFgJFsNdapOuYUdXu.rHaMzQGpDBBiOIKJmRdebShfdaqeA;
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool xdtelTQZIAOrSbeDpLVYUthjzRlF()
	{
		return YLhODevbPifVPfCqHgMeDIrcXKTZ(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressExpiresIn);
	}

	public bool xhWVfrbsxAxhqeaigwQjfdPqaBad()
	{
		return tUWRRMMUWPlLcOYXTSOBqCIELkSU(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressTime);
	}

	public bool KzMLkitOPOzISfQfTrceQUKGuebA()
	{
		return MlFIiayGhxVYtdBnJSeOifmmXqPP(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonShortPressExpiresIn);
	}

	public bool HNTYPDOjRxFFLksZTwvjllazYDRK()
	{
		return YLhODevbPifVPfCqHgMeDIrcXKTZ(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressExpiresIn);
	}

	public bool tlDAVpqQQoUumHLpmFcRHXlNablBb()
	{
		return tUWRRMMUWPlLcOYXTSOBqCIELkSU(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressTime);
	}

	public bool SgsZyJhnWgsoZNcDPZVRIXrmkMEV()
	{
		return MlFIiayGhxVYtdBnJSeOifmmXqPP(kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressTime, kIOElRBhtNsYpnnSjSnGoIKNoQBkA.buttonLongPressExpiresIn);
	}

	public bool pZNwfbMswzBhQnSkWqbkqnETAquh()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.JvNSIFDWKlEsQqGPjybQKzgbGzST.OmaOWPKbzSvMeBUfSRVOGLPbDnqP;
	}

	public bool wmkdKpTjlGQnDOmTMMrTrHwnIdMn()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return false;
		}
		return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zzLCnLpwDPawIqjihCeYShbgQZEO & ButtonStateFlags.On) != 0;
	}

	public double zNaDAwIDQVnPuTtpIZSukgwOvEWqA()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			return 0.0;
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.AHeTcWbhnCWeajfaygIGpeGgBeSl;
	}

	public double PhtHWpmnxNpVNzyigfJhEPPVAdcb()
	{
		if (!MrBOpsHJnZsFCkTIKqwYzoIPeZuO)
		{
			QnvOWWqbCqbpQIghRDzbvGflhIKA();
		}
		return BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.uaqXojvelTHUpFzNwjWmgdmIFkkl;
	}

	private bool eUjEFIHdXPbTfJKOTAchBQFcpERkc()
	{
		return (BCsGtgAxASwOfYszbpskBSVZczIv.xTujhIaItbDIZIUeYPNwvwUsXkDt.zDoiJYHLSpVQjeOpXyUlHDQLgtFqA & ButtonStateFlags.Down) != 0;
	}

	public void VBMPPCanzKJSbFkOkVDhZxxvmAMF()
	{
		for (int i = 0; i < BCsGtgAxASwOfYszbpskBSVZczIv.goXzbmHJbelpVHLIOIGIZyZZbQND.Length; i++)
		{
			BCsGtgAxASwOfYszbpskBSVZczIv.goXzbmHJbelpVHLIOIGIZyZZbQND[i].MRolaAhuSyEXdsFJIChVZhKZQaCV.Clear();
			BCsGtgAxASwOfYszbpskBSVZczIv.goXzbmHJbelpVHLIOIGIZyZZbQND[i].NucjAiglLSlCwQTBdkJDGzHNOaTi.Clear();
		}
	}

	internal InputActionEventData UaogyIuCrBSDJwnsRorrEeJrNAjX(UpdateLoopType P_0)
	{
		return new InputActionEventData(this, fWObmMDyJQLjtMQVViswtczCLZDeb, iOyZywcMUeuWkANMAkueVLStqCBf, P_0);
	}

	public IList<InputActionSourceData> eBQtUYNynlYApWIXWJsWoIZiGIVd()
	{
		if (!pniSluyPebNFsIouxpvojCqGZjoI)
		{
			KlHbbyIakfpBBCDKbWIOlqpkYEyZb();
		}
		return eAfdxshvqOTcPFxDJlXYpPQPAMdZA;
	}

	public bool jFAgNigHnmLKAJcfKPxPNnXhxbjAA(ControllerType P_0)
	{
		if (!pniSluyPebNFsIouxpvojCqGZjoI)
		{
			eBQtUYNynlYApWIXWJsWoIZiGIVd();
		}
		for (int i = 0; i < CHajixFAUrMvFlVdRtKbcXqapEaO; i++)
		{
			if (sfWfhnMQIrsylhkZeOGxgPcJyPVj[i].kYKazRsVgPALNGczLqXIRXTdCdqaA.type == P_0)
			{
				return true;
			}
		}
		return false;
	}

	public bool vjIfirZTXZjTihsQVnZfKGdMCzMO(ControllerType P_0, int P_1)
	{
		if (!pniSluyPebNFsIouxpvojCqGZjoI)
		{
			eBQtUYNynlYApWIXWJsWoIZiGIVd();
		}
		for (int i = 0; i < CHajixFAUrMvFlVdRtKbcXqapEaO; i++)
		{
			Controller kYKazRsVgPALNGczLqXIRXTdCdqaA = sfWfhnMQIrsylhkZeOGxgPcJyPVj[i].kYKazRsVgPALNGczLqXIRXTdCdqaA;
			if (kYKazRsVgPALNGczLqXIRXTdCdqaA.type == P_0 && kYKazRsVgPALNGczLqXIRXTdCdqaA.id == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public bool mejgJWIJguAiMBDakeUrxDLpVBwLb(Controller P_0)
	{
		if (!pniSluyPebNFsIouxpvojCqGZjoI)
		{
			eBQtUYNynlYApWIXWJsWoIZiGIVd();
		}
		for (int i = 0; i < CHajixFAUrMvFlVdRtKbcXqapEaO; i++)
		{
			if (sfWfhnMQIrsylhkZeOGxgPcJyPVj[i].kYKazRsVgPALNGczLqXIRXTdCdqaA == P_0)
			{
				return true;
			}
		}
		return false;
	}

	internal void xTCVrxRRkjvLhSMasbSuBUFKHAJB()
	{
		BCsGtgAxASwOfYszbpskBSVZczIv.HFUWeAusKVmKtKmLLCYQoETqkEpm();
	}

	private void DSROsmtnHWZATgFLMDbCsuIfVZhT()
	{
		if (aouxRNSWdalJzuqbpsbwczLuwfYr == SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled)
		{
			uNQgqcFaupnIyuWoINNkBtYfuRXN = true;
		}
		DQvudLTsOmnvZgNOnemtHoScpAHLA = SNwohbMULvtsqCoYLGoptSyIlJqI.Active;
		MrBOpsHJnZsFCkTIKqwYzoIPeZuO = true;
	}

	private void jqJLAWnWsAIJoGRJwiHMuudimrAN(bool P_0)
	{
		BCsGtgAxASwOfYszbpskBSVZczIv.ICIzEbtTXVFWKSgRhGQotkapmorJ();
		if (CHajixFAUrMvFlVdRtKbcXqapEaO > 0)
		{
			RAvULHKPHcdoRCGrKnNYkGEujFUQ();
		}
		DQvudLTsOmnvZgNOnemtHoScpAHLA = (P_0 ? SNwohbMULvtsqCoYLGoptSyIlJqI.Idle : SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled);
		MrBOpsHJnZsFCkTIKqwYzoIPeZuO = false;
	}

	private void QnvOWWqbCqbpQIghRDzbvGflhIKA()
	{
		BCsGtgAxASwOfYszbpskBSVZczIv.FdIBpvnOzEDGqOHJaZLSwLsIqORH = JvocSMbcsVCXgKoYxmuxIzmildeEA;
	}

	private void RAvULHKPHcdoRCGrKnNYkGEujFUQ()
	{
		CHajixFAUrMvFlVdRtKbcXqapEaO = 0;
		if (pniSluyPebNFsIouxpvojCqGZjoI)
		{
			dBLwIEXZxfMKKneOOopDNoulAThu.Clear();
		}
	}

	private void QFXaNpoaOtYOhTeyzmxHGPTdIpMO(Controller P_0, ControllerMap P_1, ActionElementMap P_2)
	{
		if (CHajixFAUrMvFlVdRtKbcXqapEaO + 1 > sfWfhnMQIrsylhkZeOGxgPcJyPVj.Length)
		{
			rtjGSpoBseqxHxwUcdRoOsKaMTbP();
		}
		vzOsYWLwkZfRLdvSwlWqPwvPltic obj = sfWfhnMQIrsylhkZeOGxgPcJyPVj[CHajixFAUrMvFlVdRtKbcXqapEaO];
		obj.XQjaCpicQwqpGbXUCLzOJfgiAdCkc = true;
		obj.kYKazRsVgPALNGczLqXIRXTdCdqaA = P_0;
		obj.YIARubiJuKAEMizOTgrNjuJLAHweb = P_1;
		obj.zzEoexVONIGXsBPUmlUdyhDiwWzDA = P_2;
		CHajixFAUrMvFlVdRtKbcXqapEaO++;
	}

	private void rtjGSpoBseqxHxwUcdRoOsKaMTbP()
	{
		ArrayTools.Expand(ref sfWfhnMQIrsylhkZeOGxgPcJyPVj, 4);
		int num = CHajixFAUrMvFlVdRtKbcXqapEaO + 4;
		for (int i = CHajixFAUrMvFlVdRtKbcXqapEaO; i < num; i++)
		{
			sfWfhnMQIrsylhkZeOGxgPcJyPVj[i] = new vzOsYWLwkZfRLdvSwlWqPwvPltic();
		}
	}

	private void KlHbbyIakfpBBCDKbWIOlqpkYEyZb()
	{
		if (!pniSluyPebNFsIouxpvojCqGZjoI)
		{
			pniSluyPebNFsIouxpvojCqGZjoI = true;
		}
		for (int i = 0; i < CHajixFAUrMvFlVdRtKbcXqapEaO; i++)
		{
			dBLwIEXZxfMKKneOOopDNoulAThu.Add(new InputActionSourceData(sfWfhnMQIrsylhkZeOGxgPcJyPVj[i]));
		}
	}

	private static void IQefCkdKfVZdHdsyzfvMnlGtOqQwA(ref ButtonStateFlags P_0, ButtonStateFlags P_1)
	{
		if (P_0 == ButtonStateFlags.Off)
		{
			P_0 = P_1;
		}
		else if ((P_1 & ButtonStateFlags.Down) != ButtonStateFlags.Off)
		{
			if ((P_0 & ButtonStateFlags.On) == 0 || (P_0 & ButtonStateFlags.Down) != ButtonStateFlags.Off)
			{
				P_0 = ButtonStateFlags.On | ButtonStateFlags.Down;
			}
		}
		else if ((P_1 & ButtonStateFlags.On) != ButtonStateFlags.Off)
		{
			P_0 = ButtonStateFlags.On;
		}
	}
}
