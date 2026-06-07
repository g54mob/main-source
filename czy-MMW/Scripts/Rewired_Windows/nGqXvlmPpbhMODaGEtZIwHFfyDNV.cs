using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class nGqXvlmPpbhMODaGEtZIwHFfyDNV : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class GrIFxXCMsvJKSmjHiGoLGIcWgJAP
	{
		private enum AFaydwXoGuDRaibCEkgNPWKjSrLO
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		public readonly UpdateLoopType WKZayraVokvvBhntzbeTZSNwyQVQA;

		public uint cMQsfkQWQijNPwJyGitHFTITUiaB;

		public uint rrhZnCyZIwSHBsPzjkziRdRMDJhy;

		public WtSbgdOQVINdAbgQfgTrJglSwUoX nyAWpQHdQnPeRAeshaIaFPNGbASYA;

		public float LKUCuxXmimeEYeuTcfSuXPscTMEt;

		public float PwmfvRDkutdZaXHAIuGyaiyldWFab;

		public float RwcFrRMyWvgxdancgcCSfimUBPDG;

		public float EtWwgRNFjAjVcjtdvobVAuoNFxlN;

		private bool[] PYlAwAVpqyftUHGHVnlpehJWkLKB;

		private bool[] DKOAhnNcUJXvfWyAYESiodgUUgiQ;

		private RkuaEdlPyruGgZcuMckNJuHbWldY xXRsnrMetyOuWYBabFASdRkJiTJd;

		private uint ivYTvfHDkbYLqcnxrAwjBHesDvVUA;

		private int prqRhjnYFZmOhtyroJmPGaOvPJzy;

		private int yFdOKMHAlQTLXTAzRFSxnsrBPSxJ;

		private bool xidWsAGSWfJnmeKecraKJAKEqNLn;

		public GrIFxXCMsvJKSmjHiGoLGIcWgJAP(RkuaEdlPyruGgZcuMckNJuHbWldY P_0, UpdateLoopType P_1)
		{
			xXRsnrMetyOuWYBabFASdRkJiTJd = P_0;
			WKZayraVokvvBhntzbeTZSNwyQVQA = P_1;
			PYlAwAVpqyftUHGHVnlpehJWkLKB = new bool[5];
			DKOAhnNcUJXvfWyAYESiodgUUgiQ = new bool[5];
		}

		public void hDxUTmKkuvIudylMAHgzbjLtYBSX(wDcCAhMQkCdHJFyOjbpKrYkYkUoC P_0)
		{
			NytLIexGcHpxZUVkKvVJLCnlErwP nytLIexGcHpxZUVkKvVJLCnlErwP = P_0.ynRnAutVHqSQXaicCSpxlKjuiZYW;
			if (nytLIexGcHpxZUVkKvVJLCnlErwP != NytLIexGcHpxZUVkKvVJLCnlErwP.None)
			{
				if ((nytLIexGcHpxZUVkKvVJLCnlErwP & NytLIexGcHpxZUVkKvVJLCnlErwP.LeftButtonDown) != NytLIexGcHpxZUVkKvVJLCnlErwP.None || (nytLIexGcHpxZUVkKvVJLCnlErwP & NytLIexGcHpxZUVkKvVJLCnlErwP.RightButtonDown) != NytLIexGcHpxZUVkKvVJLCnlErwP.None)
				{
					IntPtr intPtr = xhdeZTSXJnCGxNhwofNZQKbUYVkf.dMoylxvxjKLqXzqYCFnxmvNlHmFFA();
					if (xhdeZTSXJnCGxNhwofNZQKbUYVkf.jSsEoyCiXeWymrQCCFHpQUxMZmYnA() == intPtr && ixPqPvtPqTCeMEbWoMNMIbgWaaMuA(intPtr))
					{
						nytLIexGcHpxZUVkKvVJLCnlErwP &= ~NytLIexGcHpxZUVkKvVJLCnlErwP.LeftButtonDown;
						nytLIexGcHpxZUVkKvVJLCnlErwP &= ~NytLIexGcHpxZUVkKvVJLCnlErwP.RightButtonDown;
					}
				}
				int num = (int)nytLIexGcHpxZUVkKvVJLCnlErwP;
				if (xXRsnrMetyOuWYBabFASdRkJiTJd.LkHESOAtgVNgZMnEtEpFliNFaaGab && xXRsnrMetyOuWYBabFASdRkJiTJd.MmiRHYaLHnpykgBqjDkonvaUibZk)
				{
					RVXNaKAUfokphYSdgmUZxjMKRWmH(1, num, 1, 2);
					RVXNaKAUfokphYSdgmUZxjMKRWmH(0, num, 4, 8);
				}
				else
				{
					RVXNaKAUfokphYSdgmUZxjMKRWmH(0, num, 1, 2);
					RVXNaKAUfokphYSdgmUZxjMKRWmH(1, num, 4, 8);
				}
				RVXNaKAUfokphYSdgmUZxjMKRWmH(2, num, 16, 32);
				RVXNaKAUfokphYSdgmUZxjMKRWmH(3, num, 64, 128);
				RVXNaKAUfokphYSdgmUZxjMKRWmH(4, num, 256, 512);
			}
			cMQsfkQWQijNPwJyGitHFTITUiaB = P_0.MEpDvekLwdnNZRETtDpAFSXKEagKA;
			rrhZnCyZIwSHBsPzjkziRdRMDJhy = P_0.pVLNeXRjqPDhrxdMGZJnlKqYfaDj;
			WtSbgdOQVINdAbgQfgTrJglSwUoX wtSbgdOQVINdAbgQfgTrJglSwUoX = nyAWpQHdQnPeRAeshaIaFPNGbASYA;
			nyAWpQHdQnPeRAeshaIaFPNGbASYA = P_0.bRQAcaPhMXYkKFEuDOPrGYFHWkZC;
			if (nyAWpQHdQnPeRAeshaIaFPNGbASYA != wtSbgdOQVINdAbgQfgTrJglSwUoX)
			{
				xidWsAGSWfJnmeKecraKJAKEqNLn = false;
			}
			if (nyAWpQHdQnPeRAeshaIaFPNGbASYA == WtSbgdOQVINdAbgQfgTrJglSwUoX.MoveRelative)
			{
				LKUCuxXmimeEYeuTcfSuXPscTMEt += (float)P_0.KRvJOicARPJLyxoGGwCGahaxZwjB * 0.5f;
				PwmfvRDkutdZaXHAIuGyaiyldWFab += (float)P_0.oxTeFwvKiKUhDhEkeKSedBdaZpHX * 0.5f * -1f;
			}
			else if ((nyAWpQHdQnPeRAeshaIaFPNGbASYA & WtSbgdOQVINdAbgQfgTrJglSwUoX.MoveAbsolute) != WtSbgdOQVINdAbgQfgTrJglSwUoX.MoveRelative)
			{
				bool num2 = (nyAWpQHdQnPeRAeshaIaFPNGbASYA & WtSbgdOQVINdAbgQfgTrJglSwUoX.VirtualDesktop) != 0;
				int num3 = xhdeZTSXJnCGxNhwofNZQKbUYVkf.FiQztJUluIQTMypGcNiAChsoOgYN(num2 ? dAdQTYNMKSkiLMJVfSGtrASQhkQP.LlAniVHAWzKQUexOUyETLPaJvKqK : dAdQTYNMKSkiLMJVfSGtrASQhkQP.wnExlXXcKqOhYtDZLbqCSpXzZvbU);
				int num4 = xhdeZTSXJnCGxNhwofNZQKbUYVkf.FiQztJUluIQTMypGcNiAChsoOgYN(num2 ? dAdQTYNMKSkiLMJVfSGtrASQhkQP.cGDJBTXqeedwprPZddRsqilNcjAiA : dAdQTYNMKSkiLMJVfSGtrASQhkQP.STcWuehKcVQEafJEIlEoXRciCDAk);
				int num5 = (int)((float)P_0.KRvJOicARPJLyxoGGwCGahaxZwjB / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.oxTeFwvKiKUhDhEkeKSedBdaZpHX) / 65535f * (float)num4);
				if (!xidWsAGSWfJnmeKecraKJAKEqNLn)
				{
					prqRhjnYFZmOhtyroJmPGaOvPJzy = num5;
					yFdOKMHAlQTLXTAzRFSxnsrBPSxJ = num6;
					xidWsAGSWfJnmeKecraKJAKEqNLn = true;
				}
				LKUCuxXmimeEYeuTcfSuXPscTMEt += num5 - prqRhjnYFZmOhtyroJmPGaOvPJzy;
				PwmfvRDkutdZaXHAIuGyaiyldWFab += num6 - yFdOKMHAlQTLXTAzRFSxnsrBPSxJ;
				prqRhjnYFZmOhtyroJmPGaOvPJzy = num5;
				yFdOKMHAlQTLXTAzRFSxnsrBPSxJ = num6;
			}
			else
			{
				LKUCuxXmimeEYeuTcfSuXPscTMEt = P_0.KRvJOicARPJLyxoGGwCGahaxZwjB;
				PwmfvRDkutdZaXHAIuGyaiyldWFab = P_0.oxTeFwvKiKUhDhEkeKSedBdaZpHX;
			}
			if (P_0.aDDziAbuaEvinnoJgoIFmjNqqTKf != 0)
			{
				int num7 = ((MathTools.Abs(P_0.aDDziAbuaEvinnoJgoIFmjNqqTKf) < 120) ? MathTools.Sign(P_0.aDDziAbuaEvinnoJgoIFmjNqqTKf) : (P_0.aDDziAbuaEvinnoJgoIFmjNqqTKf / 120));
				if ((nytLIexGcHpxZUVkKvVJLCnlErwP & NytLIexGcHpxZUVkKvVJLCnlErwP.MouseWheel) != NytLIexGcHpxZUVkKvVJLCnlErwP.None)
				{
					RwcFrRMyWvgxdancgcCSfimUBPDG += num7;
				}
				else if ((nytLIexGcHpxZUVkKvVJLCnlErwP & (NytLIexGcHpxZUVkKvVJLCnlErwP)2048) != NytLIexGcHpxZUVkKvVJLCnlErwP.None)
				{
					EtWwgRNFjAjVcjtdvobVAuoNFxlN += num7;
				}
			}
		}

		public void ORgTZwfoxYPqQQVqMQKQnfnPnmxT(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = LKUCuxXmimeEYeuTcfSuXPscTMEt;
			axisValues[1] = PwmfvRDkutdZaXHAIuGyaiyldWFab;
			axisValues[2] = RwcFrRMyWvgxdancgcCSfimUBPDG;
			axisValues[3] = EtWwgRNFjAjVcjtdvobVAuoNFxlN;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = PYlAwAVpqyftUHGHVnlpehJWkLKB[i] || DKOAhnNcUJXvfWyAYESiodgUUgiQ[i];
			}
			GsgvTAYNofIwebluqBWCSnGexxDMA();
		}

		public void VdeBigkqCaMIaCxmmouhKydOkLQJ()
		{
			GsgvTAYNofIwebluqBWCSnGexxDMA();
		}

		private void GsgvTAYNofIwebluqBWCSnGexxDMA()
		{
			if (ivYTvfHDkbYLqcnxrAwjBHesDvVUA != ReInput.absFrame)
			{
				zEjcndKcfnlqRXGxenPfOQJeAjCF();
				ivYTvfHDkbYLqcnxrAwjBHesDvVUA = ReInput.absFrame;
			}
		}

		public void XehOYLxEIjaxjKhGwMjwRuicUUus()
		{
			LKUCuxXmimeEYeuTcfSuXPscTMEt = 0f;
			PwmfvRDkutdZaXHAIuGyaiyldWFab = 0f;
			rrhZnCyZIwSHBsPzjkziRdRMDJhy = 0u;
			nyAWpQHdQnPeRAeshaIaFPNGbASYA = WtSbgdOQVINdAbgQfgTrJglSwUoX.MoveRelative;
			RwcFrRMyWvgxdancgcCSfimUBPDG = 0f;
			EtWwgRNFjAjVcjtdvobVAuoNFxlN = 0f;
			Array.Clear(PYlAwAVpqyftUHGHVnlpehJWkLKB, 0, 5);
			Array.Clear(DKOAhnNcUJXvfWyAYESiodgUUgiQ, 0, 5);
			xidWsAGSWfJnmeKecraKJAKEqNLn = false;
		}

		public void zEjcndKcfnlqRXGxenPfOQJeAjCF()
		{
			LKUCuxXmimeEYeuTcfSuXPscTMEt = 0f;
			PwmfvRDkutdZaXHAIuGyaiyldWFab = 0f;
			RwcFrRMyWvgxdancgcCSfimUBPDG = 0f;
			EtWwgRNFjAjVcjtdvobVAuoNFxlN = 0f;
			Array.Clear(DKOAhnNcUJXvfWyAYESiodgUUgiQ, 0, 5);
		}

		private AFaydwXoGuDRaibCEkgNPWKjSrLO TpHCPMbVsJJFXaPRiGCLmVglMNuWB(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return AFaydwXoGuDRaibCEkgNPWKjSrLO.None;
				}
				return AFaydwXoGuDRaibCEkgNPWKjSrLO.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return AFaydwXoGuDRaibCEkgNPWKjSrLO.Up;
			}
			return AFaydwXoGuDRaibCEkgNPWKjSrLO.None;
		}

		private void RVXNaKAUfokphYSdgmUZxjMKRWmH(int P_0, int P_1, int P_2, int P_3)
		{
			AFaydwXoGuDRaibCEkgNPWKjSrLO aFaydwXoGuDRaibCEkgNPWKjSrLO = TpHCPMbVsJJFXaPRiGCLmVglMNuWB(P_1, P_2, P_3);
			if (PYlAwAVpqyftUHGHVnlpehJWkLKB[P_0])
			{
				if (aFaydwXoGuDRaibCEkgNPWKjSrLO == AFaydwXoGuDRaibCEkgNPWKjSrLO.Up)
				{
					PYlAwAVpqyftUHGHVnlpehJWkLKB[P_0] = false;
				}
			}
			else if (aFaydwXoGuDRaibCEkgNPWKjSrLO == AFaydwXoGuDRaibCEkgNPWKjSrLO.Down)
			{
				PYlAwAVpqyftUHGHVnlpehJWkLKB[P_0] = true;
			}
			if (aFaydwXoGuDRaibCEkgNPWKjSrLO == AFaydwXoGuDRaibCEkgNPWKjSrLO.Down)
			{
				DKOAhnNcUJXvfWyAYESiodgUUgiQ[P_0] = true;
			}
		}

		private static bool ixPqPvtPqTCeMEbWoMNMIbgWaaMuA(IntPtr P_0)
		{
			if (xhdeZTSXJnCGxNhwofNZQKbUYVkf.ZPfBRCEaRaDPsyjHiyKTWxsTAtiy(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!xhdeZTSXJnCGxNhwofNZQKbUYVkf.NHcZnwyeQmaCxpwyVHnwhzKjCZRP(P_0, out var nvuwChWsrdBgBqtkBKgIsEdeBSDFA))
			{
				return false;
			}
			if (!xhdeZTSXJnCGxNhwofNZQKbUYVkf.giJorwpiJJWErkwtXpTOZjLfXrcC(out var nvuwChWsrdBgBqtkBKgIsEdeBSDFA2))
			{
				return false;
			}
			if (!xhdeZTSXJnCGxNhwofNZQKbUYVkf.PnQDnlPvuSLRcxyPBbYoYfsiIjMH(P_0, out var qNliJNWDKfHiZYSTOzmCOyDFhWuE2))
			{
				return false;
			}
			int num = nvuwChWsrdBgBqtkBKgIsEdeBSDFA2.HyKWRJWNhxjnmpIEaBtFLdrcRTiL - nvuwChWsrdBgBqtkBKgIsEdeBSDFA.HyKWRJWNhxjnmpIEaBtFLdrcRTiL;
			int num2 = nvuwChWsrdBgBqtkBKgIsEdeBSDFA2.VGZiaIfaVlZKbiFvkooVnSwVBUEV - nvuwChWsrdBgBqtkBKgIsEdeBSDFA.VGZiaIfaVlZKbiFvkooVnSwVBUEV;
			if (num >= 0 && num2 >= 0 && num <= qNliJNWDKfHiZYSTOzmCOyDFhWuE2.ullBpWskflDlMIEQABtlGUnQktIlA && num2 <= qNliJNWDKfHiZYSTOzmCOyDFhWuE2.LwYssurpnUlnXUoiKQRlYLVxdZSdA)
			{
				return false;
			}
			if (!xhdeZTSXJnCGxNhwofNZQKbUYVkf.vawwOkBMVVyDZAPkdpXpdGtucsBD(P_0, out var qNliJNWDKfHiZYSTOzmCOyDFhWuE3))
			{
				return false;
			}
			if (nvuwChWsrdBgBqtkBKgIsEdeBSDFA2.HyKWRJWNhxjnmpIEaBtFLdrcRTiL >= qNliJNWDKfHiZYSTOzmCOyDFhWuE3.cUMEYoFpDwpucBKoxYRzKTjJyyBZ && nvuwChWsrdBgBqtkBKgIsEdeBSDFA2.HyKWRJWNhxjnmpIEaBtFLdrcRTiL <= qNliJNWDKfHiZYSTOzmCOyDFhWuE3.ullBpWskflDlMIEQABtlGUnQktIlA && nvuwChWsrdBgBqtkBKgIsEdeBSDFA2.VGZiaIfaVlZKbiFvkooVnSwVBUEV >= qNliJNWDKfHiZYSTOzmCOyDFhWuE3.LahlvXmTkQRPZlaEsHfTIMxOcYQCb)
			{
				return nvuwChWsrdBgBqtkBKgIsEdeBSDFA2.VGZiaIfaVlZKbiFvkooVnSwVBUEV <= qNliJNWDKfHiZYSTOzmCOyDFhWuE3.LwYssurpnUlnXUoiKQRlYLVxdZSdA;
			}
			return false;
		}
	}

	private class RkuaEdlPyruGgZcuMckNJuHbWldY
	{
		private bool XLwdxFAQwJwhySIcGpIwjlNgEZLKc;

		private bool uNmBERalweHdIdLqRuXnKFdWMEFVA;

		private bool NyKJSuYLdYeOhJVduKXJMgATxGxF;

		private int azOwckerakIkgsuZgkLiNNNFcTnf = 10;

		private readonly float VZrxgURsNqNkqCIOdwPtTVdwpbip;

		private double iJxiPKsUyyIwpbDWHVLAGYEKPeuT;

		public bool LkHESOAtgVNgZMnEtEpFliNFaaGab => XLwdxFAQwJwhySIcGpIwjlNgEZLKc;

		public bool MmiRHYaLHnpykgBqjDkonvaUibZk => uNmBERalweHdIdLqRuXnKFdWMEFVA;

		public RkuaEdlPyruGgZcuMckNJuHbWldY(bool P_0, float P_1)
		{
			XLwdxFAQwJwhySIcGpIwjlNgEZLKc = P_0;
			VZrxgURsNqNkqCIOdwPtTVdwpbip = P_1;
			cIDSoxgGVdbuqiJWrahjEMAZOOip(false);
		}

		public void FomKTCcEBVDBdJUPsQWggJiJqiHVA()
		{
			if (XLwdxFAQwJwhySIcGpIwjlNgEZLKc && !(ReInput.realTime < iJxiPKsUyyIwpbDWHVLAGYEKPeuT))
			{
				cIDSoxgGVdbuqiJWrahjEMAZOOip(true);
			}
		}

		private void cIDSoxgGVdbuqiJWrahjEMAZOOip(bool P_0)
		{
			if (NyKJSuYLdYeOhJVduKXJMgATxGxF)
			{
				xhdeZTSXJnCGxNhwofNZQKbUYVkf.BQGoKeTmKtxozOFnXVxHqPFSovXo(112u, 0u, ref azOwckerakIkgsuZgkLiNNNFcTnf, 0u);
			}
			uNmBERalweHdIdLqRuXnKFdWMEFVA = xhdeZTSXJnCGxNhwofNZQKbUYVkf.FiQztJUluIQTMypGcNiAChsoOgYN(dAdQTYNMKSkiLMJVfSGtrASQhkQP.VsuCboUwAeVqsRSQLCXoOccbYSMm) > 0;
			if (P_0)
			{
				iJxiPKsUyyIwpbDWHVLAGYEKPeuT = ReInput.realTime + (double)VZrxgURsNqNkqCIOdwPtTVdwpbip;
			}
		}
	}

	private readonly object TEaJsrIXjBJMlvlWkzqbnGgEbbBz = new object();

	private UpdateLoopDataSet<GrIFxXCMsvJKSmjHiGoLGIcWgJAP> OclHbgbSJdlZpCqmGhLLiaaUXeEfB;

	private HardwareControllerMap_Game xUToaKyTBHSKlkQCTwuWPDyixIcX;

	private RkuaEdlPyruGgZcuMckNJuHbWldY xXDBPArkKhrweBimGuQtFPBNSyab;

	private bool HQcGDXZxhDXoXQHUjBvQvngUNEdL;

	private int nsQBOeDvBuSUwLFKibVqmNBROTOeA;

	private bool BAGSztItmCTCHLqYlWfTrvciKRYw;

	private bool gwQsYBPIITPUlXTTCKMjkLrUPVkV;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return BAGSztItmCTCHLqYlWfTrvciKRYw;
		}
		set
		{
			if (BAGSztItmCTCHLqYlWfTrvciKRYw != value)
			{
				BAGSztItmCTCHLqYlWfTrvciKRYw = value;
				Clear();
				ThreadSafeUnityInput.mouse.Monitor(value);
			}
		}
	}

	InputSource IUnifiedMouseSource.inputSource => InputSource.RawInput;

	HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap
	{
		get
		{
			if (xUToaKyTBHSKlkQCTwuWPDyixIcX == null)
			{
				xUToaKyTBHSKlkQCTwuWPDyixIcX = vwedTjetoFSdyszkCfRzejgnkqPk();
			}
			return xUToaKyTBHSKlkQCTwuWPDyixIcX;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!BAGSztItmCTCHLqYlWfTrvciKRYw)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public nGqXvlmPpbhMODaGEtZIwHFfyDNV(UpdateLoopSetting P_0)
	{
		bxBkenLVuQsNRVqGyEiEkhqiFKiT();
		xXDBPArkKhrweBimGuQtFPBNSyab = new RkuaEdlPyruGgZcuMckNJuHbWldY(true, 2f);
		OclHbgbSJdlZpCqmGhLLiaaUXeEfB = new UpdateLoopDataSet<GrIFxXCMsvJKSmjHiGoLGIcWgJAP>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				OclHbgbSJdlZpCqmGhLLiaaUXeEfB[i] = new GrIFxXCMsvJKSmjHiGoLGIcWgJAP(xXDBPArkKhrweBimGuQtFPBNSyab, list[i]);
			}
		}
		HQcGDXZxhDXoXQHUjBvQvngUNEdL = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += gkGBDiNUHnmENDCuQfAVGrkOpOed;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += UKhgnIkRFyklAitZblsfmOtEAIlrc;
		ReInput.TimeScalePauseChangedEvent += SCRIYqmJMcHeLgpFPEXOsSuONurDb;
		ReInput.UpdateEndedEvent += NqvWEfxxboTvCXAeTzZStbXbgamv;
	}

	public void grggRcfEUhUQDuJnqApiEoDEIpAZB(UpdateLoopType P_0)
	{
		OclHbgbSJdlZpCqmGhLLiaaUXeEfB.SetUpdateLoop(P_0);
		xXDBPArkKhrweBimGuQtFPBNSyab.FomKTCcEBVDBdJUPsQWggJiJqiHVA();
		HQcGDXZxhDXoXQHUjBvQvngUNEdL = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void HpGWsAuNZHrrcIpWxBlQdXpWmpOAA(wDcCAhMQkCdHJFyOjbpKrYkYkUoC P_0)
	{
		if (!HQcGDXZxhDXoXQHUjBvQvngUNEdL)
		{
			return;
		}
		lock (TEaJsrIXjBJMlvlWkzqbnGgEbbBz)
		{
			int count = OclHbgbSJdlZpCqmGhLLiaaUXeEfB.Count;
			for (int i = 0; i < count; i++)
			{
				OclHbgbSJdlZpCqmGhLLiaaUXeEfB[i].hDxUTmKkuvIudylMAHgzbjLtYBSX(P_0);
			}
		}
	}

	public void jQbJOmCtLUEPZYUODjTCvnSMatrdA(bool P_0)
	{
		PQVKJMTsSlTIQzmUXeaAniaqmVTS();
	}

	public void HKRyXpawBsGroyQdXhSuOIopAZAL(bool P_0)
	{
		if (bxBkenLVuQsNRVqGyEiEkhqiFKiT() < 0)
		{
			PQVKJMTsSlTIQzmUXeaAniaqmVTS();
		}
	}

	private int bxBkenLVuQsNRVqGyEiEkhqiFKiT()
	{
		int num = nsQBOeDvBuSUwLFKibVqmNBROTOeA;
		if (lkHkoAuBtkzhXzuFmLvNvBuSoSoG.NRYmsXXKvnvAkFqcPPRCgZXGJfVV(vAdYpoomdykIToKJpOxIPJYSrXY.Mouse, out var num2))
		{
			nsQBOeDvBuSUwLFKibVqmNBROTOeA = num2;
		}
		else
		{
			nsQBOeDvBuSUwLFKibVqmNBROTOeA = ((xhdeZTSXJnCGxNhwofNZQKbUYVkf.FiQztJUluIQTMypGcNiAChsoOgYN(dAdQTYNMKSkiLMJVfSGtrASQhkQP.QaMkFyItGLvJNyNYwxDyewafdEsc) != 0) ? 1 : 0);
		}
		return nsQBOeDvBuSUwLFKibVqmNBROTOeA - num;
	}

	private void gkGBDiNUHnmENDCuQfAVGrkOpOed(bool P_0)
	{
		HQcGDXZxhDXoXQHUjBvQvngUNEdL = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !HQcGDXZxhDXoXQHUjBvQvngUNEdL)
		{
			PQVKJMTsSlTIQzmUXeaAniaqmVTS();
		}
	}

	private void UKhgnIkRFyklAitZblsfmOtEAIlrc(bool P_0)
	{
	}

	private void SCRIYqmJMcHeLgpFPEXOsSuONurDb(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		HQcGDXZxhDXoXQHUjBvQvngUNEdL = ReInput.IsInputAllowed(ControllerType.Mouse);
		lock (TEaJsrIXjBJMlvlWkzqbnGgEbbBz)
		{
			OclHbgbSJdlZpCqmGhLLiaaUXeEfB[OclHbgbSJdlZpCqmGhLLiaaUXeEfB.fixedUpdateSetIndex].zEjcndKcfnlqRXGxenPfOQJeAjCF();
		}
	}

	private void NqvWEfxxboTvCXAeTzZStbXbgamv(UpdateLoopType P_0)
	{
		lock (TEaJsrIXjBJMlvlWkzqbnGgEbbBz)
		{
			OclHbgbSJdlZpCqmGhLLiaaUXeEfB.Get(P_0).VdeBigkqCaMIaCxmmouhKydOkLQJ();
		}
	}

	private void PQVKJMTsSlTIQzmUXeaAniaqmVTS()
	{
		lock (TEaJsrIXjBJMlvlWkzqbnGgEbbBz)
		{
			int count = OclHbgbSJdlZpCqmGhLLiaaUXeEfB.Count;
			for (int i = 0; i < count; i++)
			{
				OclHbgbSJdlZpCqmGhLLiaaUXeEfB[i].XehOYLxEIjaxjKhGwMjwRuicUUus();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		OclHbgbSJdlZpCqmGhLLiaaUXeEfB.Current.ORgTZwfoxYPqQQVqMQKQnfnPnmxT(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		PQVKJMTsSlTIQzmUXeaAniaqmVTS();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game vwedTjetoFSdyszkCfRzejgnkqPk()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.rawInputUnifiedMouseElementIdentifiers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(Consts.rawInputUnifiedMouseElementIdentifiers[i]);
		}
		int[] array2 = new int[5];
		int[] array3 = new int[4];
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].elementType == ControllerElementType.Axis)
			{
				array3[num2++] = array[j].id;
			}
			else if (array[j].elementType == ControllerElementType.Button)
			{
				array2[num++] = array[j].id;
			}
		}
		AxisCalibrationData[] array4 = new AxisCalibrationData[4];
		AxisRange[] array5 = new AxisRange[4];
		HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
		HardwareButtonInfo[] array7 = new HardwareButtonInfo[5];
		for (int k = 0; k < 4; k++)
		{
			array4[k] = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float num3 = (((uint)k > 1u) ? 2f : 100f);
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
	}

	public void Dispose()
	{
		BaTSOvOFnmNauMiNGEpZqeTXQZGN(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void FFuFHQGSjtmVtDhxcGuSqxzxcMgG()
	{
		try
		{
			BaTSOvOFnmNauMiNGEpZqeTXQZGN(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void BaTSOvOFnmNauMiNGEpZqeTXQZGN(bool P_0)
	{
		if (!gwQsYBPIITPUlXTTCKMjkLrUPVkV)
		{
			ReInput.ApplicationFocusChangedEvent -= gkGBDiNUHnmENDCuQfAVGrkOpOed;
			ReInput.EditorPauseChangedEvent -= UKhgnIkRFyklAitZblsfmOtEAIlrc;
			ReInput.TimeScalePauseChangedEvent -= SCRIYqmJMcHeLgpFPEXOsSuONurDb;
			ReInput.UpdateEndedEvent -= NqvWEfxxboTvCXAeTzZStbXbgamv;
			if (P_0 && BAGSztItmCTCHLqYlWfTrvciKRYw)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			gwQsYBPIITPUlXTTCKMjkLrUPVkV = true;
		}
	}
}
