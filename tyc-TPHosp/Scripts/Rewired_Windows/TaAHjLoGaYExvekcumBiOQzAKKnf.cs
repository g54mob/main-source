using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class TaAHjLoGaYExvekcumBiOQzAKKnf : IDisposable, IUnifiedMouseSource
{
	private class NRaXwJPZSwGVXHIumErrfomyMOhM
	{
		private enum vcDUhdzhMPNENRSkAgwVLvtiBjf
		{
			XzhcXffXatYTRpTiRyDKgAvaprhV = 0,
			JlAKOWbcGyryFSDRaRoBRFtbIwV = 1,
			wUOlBsBaDAPtNloIYFfHeCWVNHe = 2
		}

		private const int mOBcbXlFHycemDiXgwzCEtkdzrhl = 120;

		private const int EpJBLiJfjmPARevHeQYRgCOyaamO = 2048;

		public readonly UpdateLoopType cELogrLUBvFlsKPopQTmofzNoqD;

		public uint YsnnmepqAlhakOnYZlSeWhiosIl;

		public uint zPDZwOqaXKkklzSEgoGlfgCvovF;

		public uGgnVVOYThenQhcTTVVgnXGhLIN XfTNlWtByUhWjZKIGBGvJcfpRDQ;

		public float piYIQHIxjkcqcJLfkQtPcRIracF;

		public float PUThFkwsTStPGwrINLnQiDQBLHl;

		public float tKPmaoNnLWCoHBltUiJbCiJrKtDf;

		public float GxSKTyJeIDBEmKCuPfjfhhFJMdXa;

		private bool[] hXZfgNUGfrDgcUkgLoCkSelVbNM;

		private bool[] SiVEinePJYwMTSBejaholjdYUGQn;

		private hiHtKrkQRqLlBJovxKUXWknhAEs RgOgIKgcQlEHmtSMfPvJWumgWkR;

		private uint hfvhGVyOKRikzTjduiFghOZcHbGK;

		private int rATNGpFqvqlnOFPxoEnTbABpuyDO;

		private int znstYcCylkRjqOaJuDObbhZDRsFM;

		private bool XBalbOwdkqeHJxXYzdEKfntJoVRb;

		public NRaXwJPZSwGVXHIumErrfomyMOhM(hiHtKrkQRqLlBJovxKUXWknhAEs windowsPrefs, UpdateLoopType updateLoop)
		{
			RgOgIKgcQlEHmtSMfPvJWumgWkR = windowsPrefs;
			cELogrLUBvFlsKPopQTmofzNoqD = updateLoop;
			hXZfgNUGfrDgcUkgLoCkSelVbNM = new bool[5];
			SiVEinePJYwMTSBejaholjdYUGQn = new bool[5];
		}

		public void ZwDhEUIRIissJLnFaGZCySURjdme(GAUEpREwZxMNaJbUVtjuRaurvUI P_0)
		{
			zeZgKSbrhcKAgDKEusrxNlXETyKn zeZgKSbrhcKAgDKEusrxNlXETyKn2 = P_0.TWdNKYQEuWcSSaucWRkFBWPGdIOo;
			if (zeZgKSbrhcKAgDKEusrxNlXETyKn2 != zeZgKSbrhcKAgDKEusrxNlXETyKn.XzhcXffXatYTRpTiRyDKgAvaprhV)
			{
				if ((zeZgKSbrhcKAgDKEusrxNlXETyKn2 & zeZgKSbrhcKAgDKEusrxNlXETyKn.juEjyyrkajJwqlqmJlNPLhwmGPz) != zeZgKSbrhcKAgDKEusrxNlXETyKn.XzhcXffXatYTRpTiRyDKgAvaprhV || (zeZgKSbrhcKAgDKEusrxNlXETyKn2 & zeZgKSbrhcKAgDKEusrxNlXETyKn.PzCCorVkMAfgsEiRyNMoVUzVlNx) != zeZgKSbrhcKAgDKEusrxNlXETyKn.XzhcXffXatYTRpTiRyDKgAvaprhV)
				{
					IntPtr intPtr = HuTamtUgOYxfCNLWEcbrfgTfOVKO.HHgObSYCASlxDMDexFzCKlSubXT();
					if (HuTamtUgOYxfCNLWEcbrfgTfOVKO.GxdGpOqTKipkqLMfQXpBPIJCDnf() == intPtr && IKVdMkLiYNvOQXAgijLZRYaagpS(intPtr))
					{
						zeZgKSbrhcKAgDKEusrxNlXETyKn2 &= ~zeZgKSbrhcKAgDKEusrxNlXETyKn.juEjyyrkajJwqlqmJlNPLhwmGPz;
						zeZgKSbrhcKAgDKEusrxNlXETyKn2 &= ~zeZgKSbrhcKAgDKEusrxNlXETyKn.PzCCorVkMAfgsEiRyNMoVUzVlNx;
					}
				}
				int num = (int)zeZgKSbrhcKAgDKEusrxNlXETyKn2;
				if (RgOgIKgcQlEHmtSMfPvJWumgWkR.enabled && RgOgIKgcQlEHmtSMfPvJWumgWkR.swapButtons)
				{
					GZXYdOmBKxtBaqBezNcyDjegGZa(1, num, 1, 2);
					GZXYdOmBKxtBaqBezNcyDjegGZa(0, num, 4, 8);
				}
				else
				{
					GZXYdOmBKxtBaqBezNcyDjegGZa(0, num, 1, 2);
					GZXYdOmBKxtBaqBezNcyDjegGZa(1, num, 4, 8);
				}
				GZXYdOmBKxtBaqBezNcyDjegGZa(2, num, 16, 32);
				GZXYdOmBKxtBaqBezNcyDjegGZa(3, num, 64, 128);
				GZXYdOmBKxtBaqBezNcyDjegGZa(4, num, 256, 512);
			}
			YsnnmepqAlhakOnYZlSeWhiosIl = P_0.YsnnmepqAlhakOnYZlSeWhiosIl;
			zPDZwOqaXKkklzSEgoGlfgCvovF = P_0.zPDZwOqaXKkklzSEgoGlfgCvovF;
			uGgnVVOYThenQhcTTVVgnXGhLIN xfTNlWtByUhWjZKIGBGvJcfpRDQ = XfTNlWtByUhWjZKIGBGvJcfpRDQ;
			XfTNlWtByUhWjZKIGBGvJcfpRDQ = P_0.XfTNlWtByUhWjZKIGBGvJcfpRDQ;
			if (XfTNlWtByUhWjZKIGBGvJcfpRDQ != xfTNlWtByUhWjZKIGBGvJcfpRDQ)
			{
				XBalbOwdkqeHJxXYzdEKfntJoVRb = false;
			}
			if (XfTNlWtByUhWjZKIGBGvJcfpRDQ == uGgnVVOYThenQhcTTVVgnXGhLIN.vdQJHNMpBpSZjwpFUUtycNwEnfG)
			{
				piYIQHIxjkcqcJLfkQtPcRIracF += (float)P_0.piYIQHIxjkcqcJLfkQtPcRIracF * 0.5f;
				PUThFkwsTStPGwrINLnQiDQBLHl += (float)P_0.PUThFkwsTStPGwrINLnQiDQBLHl * 0.5f * -1f;
			}
			else if ((XfTNlWtByUhWjZKIGBGvJcfpRDQ & uGgnVVOYThenQhcTTVVgnXGhLIN.etxqIhyfeAoovGjESrmVCtsorCC) != uGgnVVOYThenQhcTTVVgnXGhLIN.vdQJHNMpBpSZjwpFUUtycNwEnfG)
			{
				bool flag = (XfTNlWtByUhWjZKIGBGvJcfpRDQ & uGgnVVOYThenQhcTTVVgnXGhLIN.iGzFdraoiVBfLuGQUlXxizcBiXEt) != 0;
				int num2 = HuTamtUgOYxfCNLWEcbrfgTfOVKO.uNfctehaKjMNmyojDJiaMRFVqtVa(flag ? LDLICyXLtzNtgKlsBEQDDyrjfaq.BPDLEnVTbIlSKfxOwlKuScHvEXBh : LDLICyXLtzNtgKlsBEQDDyrjfaq.PKbxZeIyhrJOcFaVrrQLvBWOjEw);
				int num3 = HuTamtUgOYxfCNLWEcbrfgTfOVKO.uNfctehaKjMNmyojDJiaMRFVqtVa(flag ? LDLICyXLtzNtgKlsBEQDDyrjfaq.LIGwFobHOKXDezVrdddcApkevuR : LDLICyXLtzNtgKlsBEQDDyrjfaq.ngIaHXCfcyjlYMjbvUYxaCEnHlX);
				int num4 = (int)((float)P_0.piYIQHIxjkcqcJLfkQtPcRIracF / 65535f * (float)num2);
				int num5 = (int)((65535f - (float)P_0.PUThFkwsTStPGwrINLnQiDQBLHl) / 65535f * (float)num3);
				if (!XBalbOwdkqeHJxXYzdEKfntJoVRb)
				{
					rATNGpFqvqlnOFPxoEnTbABpuyDO = num4;
					znstYcCylkRjqOaJuDObbhZDRsFM = num5;
					XBalbOwdkqeHJxXYzdEKfntJoVRb = true;
				}
				piYIQHIxjkcqcJLfkQtPcRIracF += num4 - rATNGpFqvqlnOFPxoEnTbABpuyDO;
				PUThFkwsTStPGwrINLnQiDQBLHl += num5 - znstYcCylkRjqOaJuDObbhZDRsFM;
				rATNGpFqvqlnOFPxoEnTbABpuyDO = num4;
				znstYcCylkRjqOaJuDObbhZDRsFM = num5;
			}
			else
			{
				piYIQHIxjkcqcJLfkQtPcRIracF = P_0.piYIQHIxjkcqcJLfkQtPcRIracF;
				PUThFkwsTStPGwrINLnQiDQBLHl = P_0.PUThFkwsTStPGwrINLnQiDQBLHl;
			}
			if (P_0.jSgZqQtIzwScnPYbabvMQxNFuES != 0)
			{
				int num6 = ((MathTools.Abs(P_0.jSgZqQtIzwScnPYbabvMQxNFuES) < 120) ? MathTools.Sign(P_0.jSgZqQtIzwScnPYbabvMQxNFuES) : (P_0.jSgZqQtIzwScnPYbabvMQxNFuES / 120));
				if ((zeZgKSbrhcKAgDKEusrxNlXETyKn2 & zeZgKSbrhcKAgDKEusrxNlXETyKn.XhAJkoNomdiYFbEcGNdYnGuVFja) != zeZgKSbrhcKAgDKEusrxNlXETyKn.XzhcXffXatYTRpTiRyDKgAvaprhV)
				{
					tKPmaoNnLWCoHBltUiJbCiJrKtDf += num6;
				}
				else if ((zeZgKSbrhcKAgDKEusrxNlXETyKn2 & (zeZgKSbrhcKAgDKEusrxNlXETyKn)2048) != zeZgKSbrhcKAgDKEusrxNlXETyKn.XzhcXffXatYTRpTiRyDKgAvaprhV)
				{
					GxSKTyJeIDBEmKCuPfjfhhFJMdXa += num6;
				}
			}
		}

		public void QJikxZSCKXGTYwxWGSqzPgTltrl(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = piYIQHIxjkcqcJLfkQtPcRIracF;
			axisValues[1] = PUThFkwsTStPGwrINLnQiDQBLHl;
			axisValues[2] = tKPmaoNnLWCoHBltUiJbCiJrKtDf;
			axisValues[3] = GxSKTyJeIDBEmKCuPfjfhhFJMdXa;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
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
				DCmCdfavPGHjgckNMMEiKIrpwiNV();
				hfvhGVyOKRikzTjduiFghOZcHbGK = ReInput.absFrame;
			}
		}

		public void IgqBTMgoLLDsubFJdJZiejmTNfb()
		{
			piYIQHIxjkcqcJLfkQtPcRIracF = 0f;
			PUThFkwsTStPGwrINLnQiDQBLHl = 0f;
			zPDZwOqaXKkklzSEgoGlfgCvovF = 0u;
			XfTNlWtByUhWjZKIGBGvJcfpRDQ = uGgnVVOYThenQhcTTVVgnXGhLIN.vdQJHNMpBpSZjwpFUUtycNwEnfG;
			tKPmaoNnLWCoHBltUiJbCiJrKtDf = 0f;
			GxSKTyJeIDBEmKCuPfjfhhFJMdXa = 0f;
			Array.Clear(hXZfgNUGfrDgcUkgLoCkSelVbNM, 0, 5);
			Array.Clear(SiVEinePJYwMTSBejaholjdYUGQn, 0, 5);
			XBalbOwdkqeHJxXYzdEKfntJoVRb = false;
		}

		public void DCmCdfavPGHjgckNMMEiKIrpwiNV()
		{
			piYIQHIxjkcqcJLfkQtPcRIracF = 0f;
			PUThFkwsTStPGwrINLnQiDQBLHl = 0f;
			tKPmaoNnLWCoHBltUiJbCiJrKtDf = 0f;
			GxSKTyJeIDBEmKCuPfjfhhFJMdXa = 0f;
			Array.Clear(SiVEinePJYwMTSBejaholjdYUGQn, 0, 5);
		}

		private bool golTpfekpJZdxAtdMfSTzBKxebB(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1 && (P_0 & P_2) != P_2)
			{
				return true;
			}
			return false;
		}

		private vcDUhdzhMPNENRSkAgwVLvtiBjf hzFygbYLmWNBTxynqmMokzThBSY(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return vcDUhdzhMPNENRSkAgwVLvtiBjf.XzhcXffXatYTRpTiRyDKgAvaprhV;
				}
				return vcDUhdzhMPNENRSkAgwVLvtiBjf.JlAKOWbcGyryFSDRaRoBRFtbIwV;
			}
			if ((P_0 & P_2) == P_2)
			{
				return vcDUhdzhMPNENRSkAgwVLvtiBjf.wUOlBsBaDAPtNloIYFfHeCWVNHe;
			}
			return vcDUhdzhMPNENRSkAgwVLvtiBjf.XzhcXffXatYTRpTiRyDKgAvaprhV;
		}

		private void GZXYdOmBKxtBaqBezNcyDjegGZa(int P_0, int P_1, int P_2, int P_3)
		{
			vcDUhdzhMPNENRSkAgwVLvtiBjf vcDUhdzhMPNENRSkAgwVLvtiBjf2 = hzFygbYLmWNBTxynqmMokzThBSY(P_1, P_2, P_3);
			if (hXZfgNUGfrDgcUkgLoCkSelVbNM[P_0])
			{
				if (vcDUhdzhMPNENRSkAgwVLvtiBjf2 == vcDUhdzhMPNENRSkAgwVLvtiBjf.wUOlBsBaDAPtNloIYFfHeCWVNHe)
				{
					hXZfgNUGfrDgcUkgLoCkSelVbNM[P_0] = false;
				}
			}
			else if (vcDUhdzhMPNENRSkAgwVLvtiBjf2 == vcDUhdzhMPNENRSkAgwVLvtiBjf.JlAKOWbcGyryFSDRaRoBRFtbIwV)
			{
				hXZfgNUGfrDgcUkgLoCkSelVbNM[P_0] = true;
			}
			if (vcDUhdzhMPNENRSkAgwVLvtiBjf2 == vcDUhdzhMPNENRSkAgwVLvtiBjf.JlAKOWbcGyryFSDRaRoBRFtbIwV)
			{
				SiVEinePJYwMTSBejaholjdYUGQn[P_0] = true;
			}
		}

		private static bool IKVdMkLiYNvOQXAgijLZRYaagpS(IntPtr P_0)
		{
			IntPtr intPtr = HuTamtUgOYxfCNLWEcbrfgTfOVKO.WAoBFpJqWRwAFwbBUSrFmspUajCn(0u, false, 0u);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			if (!HuTamtUgOYxfCNLWEcbrfgTfOVKO.JraYAxRCOHhlIcuWZrGemQXTeNZc(P_0, out var jlEgGFCMyUABgeUYboncSgBLIPr2))
			{
				return false;
			}
			if (!HuTamtUgOYxfCNLWEcbrfgTfOVKO.PejAHrYkTvKfpLURpiTDTmjdPie(out var jlEgGFCMyUABgeUYboncSgBLIPr3))
			{
				return false;
			}
			if (!HuTamtUgOYxfCNLWEcbrfgTfOVKO.elqsZJwfkSOIZFYaEaUCkjQpUiQ(P_0, out var qQBoznIKEUwNqAfsulooweEksiS))
			{
				return false;
			}
			int num = jlEgGFCMyUABgeUYboncSgBLIPr3.piYIQHIxjkcqcJLfkQtPcRIracF - jlEgGFCMyUABgeUYboncSgBLIPr2.piYIQHIxjkcqcJLfkQtPcRIracF;
			int num2 = jlEgGFCMyUABgeUYboncSgBLIPr3.PUThFkwsTStPGwrINLnQiDQBLHl - jlEgGFCMyUABgeUYboncSgBLIPr2.PUThFkwsTStPGwrINLnQiDQBLHl;
			if (num >= 0 && num2 >= 0 && num <= qQBoznIKEUwNqAfsulooweEksiS.zaZrYQCRXmaahFvGfHFbPjDPDvY && num2 <= qQBoznIKEUwNqAfsulooweEksiS.jSshugjcLYIlGChNgcvRNjzVUrJ)
			{
				return false;
			}
			if (!HuTamtUgOYxfCNLWEcbrfgTfOVKO.IbKtucDLHgSPwsTtvPvyvQWutDH(P_0, out var qQBoznIKEUwNqAfsulooweEksiS2))
			{
				return false;
			}
			if (jlEgGFCMyUABgeUYboncSgBLIPr3.piYIQHIxjkcqcJLfkQtPcRIracF >= qQBoznIKEUwNqAfsulooweEksiS2.uaYjuDZMTDCgOXPdoUUCcbdvIMZ && jlEgGFCMyUABgeUYboncSgBLIPr3.piYIQHIxjkcqcJLfkQtPcRIracF <= qQBoznIKEUwNqAfsulooweEksiS2.zaZrYQCRXmaahFvGfHFbPjDPDvY && jlEgGFCMyUABgeUYboncSgBLIPr3.PUThFkwsTStPGwrINLnQiDQBLHl >= qQBoznIKEUwNqAfsulooweEksiS2.gzDNwfSYeVxLcYGlllYfiXNMNZv)
			{
				return jlEgGFCMyUABgeUYboncSgBLIPr3.PUThFkwsTStPGwrINLnQiDQBLHl <= qQBoznIKEUwNqAfsulooweEksiS2.jSshugjcLYIlGChNgcvRNjzVUrJ;
			}
			return false;
		}
	}

	private class hiHtKrkQRqLlBJovxKUXWknhAEs
	{
		private bool TrKCrYPaNheRTWpmzDDujGAYwAq;

		private bool mbSbPBYACnTRSGsFkqbPNccKYuh;

		private bool jxqipOBymstnoGJrTpNgvUJErHv;

		private int VmudvzFchItpflwzFeOGtpHAsnY = 10;

		private readonly float WbFenZIDKVnetFVJcRijkyDGcwR;

		private double ROZkxCCTEQdElBDaFjGKjSWPfnZz;

		public bool enabled
		{
			get
			{
				return TrKCrYPaNheRTWpmzDDujGAYwAq;
			}
			set
			{
				if (value != TrKCrYPaNheRTWpmzDDujGAYwAq)
				{
					LppEBgcxFikLHZuFqVTSYPOpKsI(true);
				}
			}
		}

		public bool swapButtons => mbSbPBYACnTRSGsFkqbPNccKYuh;

		public bool applySpeed
		{
			get
			{
				return jxqipOBymstnoGJrTpNgvUJErHv;
			}
			set
			{
				if (jxqipOBymstnoGJrTpNgvUJErHv != value)
				{
					jxqipOBymstnoGJrTpNgvUJErHv = value;
					LppEBgcxFikLHZuFqVTSYPOpKsI(true);
				}
			}
		}

		public int speed => VmudvzFchItpflwzFeOGtpHAsnY;

		public hiHtKrkQRqLlBJovxKUXWknhAEs(bool enabled, float refreshInterval)
		{
			TrKCrYPaNheRTWpmzDDujGAYwAq = enabled;
			WbFenZIDKVnetFVJcRijkyDGcwR = refreshInterval;
			LppEBgcxFikLHZuFqVTSYPOpKsI(false);
		}

		public void CWncwVbJhTWISMonvIVEimpDcKXc()
		{
			if (TrKCrYPaNheRTWpmzDDujGAYwAq && !(ReInput.realTime < ROZkxCCTEQdElBDaFjGKjSWPfnZz))
			{
				LppEBgcxFikLHZuFqVTSYPOpKsI(true);
			}
		}

		private void LppEBgcxFikLHZuFqVTSYPOpKsI(bool P_0)
		{
			if (jxqipOBymstnoGJrTpNgvUJErHv)
			{
				HuTamtUgOYxfCNLWEcbrfgTfOVKO.hjAHAxPMRcRXELyngDbVGWcIHcU(112u, 0u, ref VmudvzFchItpflwzFeOGtpHAsnY, 0u);
			}
			mbSbPBYACnTRSGsFkqbPNccKYuh = HuTamtUgOYxfCNLWEcbrfgTfOVKO.uNfctehaKjMNmyojDJiaMRFVqtVa(LDLICyXLtzNtgKlsBEQDDyrjfaq.YrKsJdPEpbQFCzFJCbogwbSUDCU) > 0;
			if (P_0)
			{
				ROZkxCCTEQdElBDaFjGKjSWPfnZz = ReInput.realTime + (double)WbFenZIDKVnetFVJcRijkyDGcwR;
			}
		}
	}

	private const int mNFUhlhxqAAuawAuReuEHReYhIr = 5;

	private const int kJYgycsRLxIrQqhudVexKeMNMUv = 4;

	private const bool iOTbTECGQTiCjFccBfXOnEDXXOAb = true;

	private const float AiZgWBcSfUnpfPaIWgURBEtinwlo = 2f;

	private readonly object WfTbITFnDgahnloEWtIracmCfqy = new object();

	private UpdateLoopDataSet<NRaXwJPZSwGVXHIumErrfomyMOhM> wObfRIyUgeboVabiJskVEuDuVsf;

	private HardwareControllerMap_Game uImkRkkxDCalFMiAimazUBVGBBs;

	private hiHtKrkQRqLlBJovxKUXWknhAEs RgOgIKgcQlEHmtSMfPvJWumgWkR;

	private bool NZFfxmeonndzgZSGBLcYGSBmvlqA;

	private int dBBwdHCvCQzUXBaqMjoQVtYGSJf;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

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

	public int buttonCount => 5;

	public int axisCount => 4;

	public Vector2 mousePosition => ThreadSafeUnityInput.mouse.mousePosition;

	public Controller.Extension controllerExtension => null;

	public TaAHjLoGaYExvekcumBiOQzAKKnf(UpdateLoopSetting updateLoopSetting)
	{
		SknprohKuNItxpkxAAIPKRDOsNVV();
		RgOgIKgcQlEHmtSMfPvJWumgWkR = new hiHtKrkQRqLlBJovxKUXWknhAEs(enabled: true, 2f);
		wObfRIyUgeboVabiJskVEuDuVsf = new UpdateLoopDataSet<NRaXwJPZSwGVXHIumErrfomyMOhM>(updateLoopSetting);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				wObfRIyUgeboVabiJskVEuDuVsf[i] = new NRaXwJPZSwGVXHIumErrfomyMOhM(RgOgIKgcQlEHmtSMfPvJWumgWkR, list[i]);
			}
		}
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += MPSJQoWnSijXncKIXuiQSTBnhmc;
		ThreadSafeUnityInput.mouse.Monitor(state: true);
		ReInput.EditorPauseChangedEvent += PjiHnEoBRQcgyItzJsIZJxSsMWju;
		ReInput.TimeScalePauseChangedEvent += xfiaNOwwuOeHRWmHbfrJXTlNhjb;
		ReInput.UpdateEndedEvent += qeAqePgMOUVKyWtOWYbIquUtaoU;
	}

	public void CWncwVbJhTWISMonvIVEimpDcKXc(UpdateLoopType P_0)
	{
		wObfRIyUgeboVabiJskVEuDuVsf.SetUpdateLoop(P_0);
		RgOgIKgcQlEHmtSMfPvJWumgWkR.CWncwVbJhTWISMonvIVEimpDcKXc();
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void oFXcnfERNBuhmyELcTDiktBteqh(GAUEpREwZxMNaJbUVtjuRaurvUI P_0)
	{
		if (!NZFfxmeonndzgZSGBLcYGSBmvlqA)
		{
			return;
		}
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			int count = wObfRIyUgeboVabiJskVEuDuVsf.Count;
			for (int i = 0; i < count; i++)
			{
				wObfRIyUgeboVabiJskVEuDuVsf[i].ZwDhEUIRIissJLnFaGZCySURjdme(P_0);
			}
		}
	}

	public void riSHQeDOIkBABkFvimBoHoVHLsiP(bool P_0)
	{
		tBsRFflpQHJsfOlVcBpxceuRjZgV();
	}

	public void EOfLvZeQNqcczljjrXLbjGczkeD(bool P_0)
	{
		int num = SknprohKuNItxpkxAAIPKRDOsNVV();
		if (num < 0)
		{
			tBsRFflpQHJsfOlVcBpxceuRjZgV();
		}
	}

	private int SknprohKuNItxpkxAAIPKRDOsNVV()
	{
		int num = dBBwdHCvCQzUXBaqMjoQVtYGSJf;
		if (TnbctswGyXOsohdhCkTtNqIlEbQG.eijXNrPqAlSwVXFbujqixZhYUi(TNuYvFcSdWFqveHgvUhHbRntguj.QWzvIXfHqDcsOQVtNnKAnsyXzLg, out var num2))
		{
			dBBwdHCvCQzUXBaqMjoQVtYGSJf = num2;
		}
		else
		{
			dBBwdHCvCQzUXBaqMjoQVtYGSJf = ((HuTamtUgOYxfCNLWEcbrfgTfOVKO.uNfctehaKjMNmyojDJiaMRFVqtVa(LDLICyXLtzNtgKlsBEQDDyrjfaq.qPAHzCljsroqZiFCKnqxvXksEli) != 0) ? 1 : 0);
		}
		return dBBwdHCvCQzUXBaqMjoQVtYGSJf - num;
	}

	private void MPSJQoWnSijXncKIXuiQSTBnhmc(bool P_0)
	{
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !NZFfxmeonndzgZSGBLcYGSBmvlqA)
		{
			tBsRFflpQHJsfOlVcBpxceuRjZgV();
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
		NZFfxmeonndzgZSGBLcYGSBmvlqA = ReInput.IsInputAllowed(ControllerType.Mouse);
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			wObfRIyUgeboVabiJskVEuDuVsf[wObfRIyUgeboVabiJskVEuDuVsf.fixedUpdateSetIndex].DCmCdfavPGHjgckNMMEiKIrpwiNV();
		}
	}

	private void qeAqePgMOUVKyWtOWYbIquUtaoU(UpdateLoopType P_0)
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			wObfRIyUgeboVabiJskVEuDuVsf.Get(P_0).gXADYrdzIttymTRoaKqLkIyUtDJ();
		}
	}

	private void tBsRFflpQHJsfOlVcBpxceuRjZgV()
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
		tBsRFflpQHJsfOlVcBpxceuRjZgV();
	}

	private HardwareControllerMap_Game sJDPNLgjzdbpLHncpwmaDsgHkAGK()
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
			ref AxisCalibrationData reference = ref array4[k];
			reference = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float pollingDeadZone;
			switch (k)
			{
			case 0:
			case 1:
				pollingDeadZone = 100f;
				break;
			default:
				pollingDeadZone = 2f;
				break;
			}
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, excludeFromPolling: false, pollingDeadZone, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~TaAHjLoGaYExvekcumBiOQzAKKnf()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			ReInput.ApplicationFocusChangedEvent -= MPSJQoWnSijXncKIXuiQSTBnhmc;
			ReInput.EditorPauseChangedEvent -= PjiHnEoBRQcgyItzJsIZJxSsMWju;
			ReInput.TimeScalePauseChangedEvent -= xfiaNOwwuOeHRWmHbfrJXTlNhjb;
			ReInput.UpdateEndedEvent -= qeAqePgMOUVKyWtOWYbIquUtaoU;
			if (P_0)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}
}
