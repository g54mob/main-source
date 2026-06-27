using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class kEXzsJGBwwhisqDbvAUEGMcgkoBi : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class rEjTESHArUfLjYeYtdcbuvgkamOBA
	{
		private enum kRNoMAmNgoxnbkjjJyEbUeyJzhVW
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int euvVLqjTVjKuvAUcEnpSPbyVVIBG = 120;

		private const int UDCrIcjXfpnTkVhUwdVOGrbkmWkfb = 2048;

		public readonly UpdateLoopType CIgGYonJFDlJOqeUYFWYnANmBQweA;

		public uint sgKaMAEpEDbMpbgGtTTYOoSYsQiC;

		public uint wbgeSTIBcjHigAQzevsphCfMXBlRB;

		public KWLsyHpyrsWFBeJnrXTiTRTUgHhF oZkSHchLEiDGcLTxRYPGpngpJBvB;

		public float vzFiMIaUgHKHEKLRiqBckNHKJzrm;

		public float SUHrcplkfmUYUUofLGLZWxdnRGbE;

		public float CgcifyhcAqJHBSbiHOSgdEwITxNo;

		public float aSdSxBnOLAbVXfmIabAjWANDwKVh;

		private bool[] kwgtjHSMIQHnpiwTZQruDjReeGdZA;

		private bool[] UHwUddEzbjMvdlTrzrPFVGtJOZHF;

		private edIHTdeRRHXARXJwOYQAbiRfbARaA OufwVOYNukbRTRTGUkMdYRKamWWq;

		private uint cCndRxeCUHwLhLHPSOqrNuFDjLfj;

		private int XvHGUYwAhkvRuZiOSwATKOYWNeNm;

		private int kSOTHMuGyjEqgKyEIOWgEYtnIWko;

		private bool cOLqbKCgZYDkuJTwkfYJCjdeyXxg;

		public rEjTESHArUfLjYeYtdcbuvgkamOBA(edIHTdeRRHXARXJwOYQAbiRfbARaA P_0, UpdateLoopType P_1)
		{
			OufwVOYNukbRTRTGUkMdYRKamWWq = P_0;
			CIgGYonJFDlJOqeUYFWYnANmBQweA = P_1;
			kwgtjHSMIQHnpiwTZQruDjReeGdZA = new bool[5];
			UHwUddEzbjMvdlTrzrPFVGtJOZHF = new bool[5];
		}

		public void MYhNSNklAKFZgomSdGPHxGcRcwVu(OMJYRORIFUjhualKseRMOFMGjmDH P_0)
		{
			NTaNBMUpXxTiQRkRAOjOPHJxpZlS nTaNBMUpXxTiQRkRAOjOPHJxpZlS = P_0.tqJENjvgklbjBdlJGbldWKbHMlYCb;
			if (nTaNBMUpXxTiQRkRAOjOPHJxpZlS != NTaNBMUpXxTiQRkRAOjOPHJxpZlS.None)
			{
				if ((nTaNBMUpXxTiQRkRAOjOPHJxpZlS & NTaNBMUpXxTiQRkRAOjOPHJxpZlS.LeftButtonDown) != NTaNBMUpXxTiQRkRAOjOPHJxpZlS.None || (nTaNBMUpXxTiQRkRAOjOPHJxpZlS & NTaNBMUpXxTiQRkRAOjOPHJxpZlS.RightButtonDown) != NTaNBMUpXxTiQRkRAOjOPHJxpZlS.None)
				{
					IntPtr intPtr = NtPSOxELPOOaKLQRVmbwGRgHcLOL.mfAwakXZewqnIYzQRlaMvZSxMEgj();
					if (NtPSOxELPOOaKLQRVmbwGRgHcLOL.PVuzEAmmgekMahdvMMEpEdClaksR() == intPtr && prpZmOnlqnFCFkNGvTXeSNxFrHKp(intPtr))
					{
						nTaNBMUpXxTiQRkRAOjOPHJxpZlS &= ~NTaNBMUpXxTiQRkRAOjOPHJxpZlS.LeftButtonDown;
						nTaNBMUpXxTiQRkRAOjOPHJxpZlS &= ~NTaNBMUpXxTiQRkRAOjOPHJxpZlS.RightButtonDown;
					}
				}
				int num = (int)nTaNBMUpXxTiQRkRAOjOPHJxpZlS;
				if (OufwVOYNukbRTRTGUkMdYRKamWWq.jhbkyQNyuyFGKOrpXBTJFsXdIecU && OufwVOYNukbRTRTGUkMdYRKamWWq.gbYEuaAPgBIiuNZvoKDOuKfZzFYtA)
				{
					reqQpltmZECaOiUUkHqFJQWQZTSF(1, num, 1, 2);
					reqQpltmZECaOiUUkHqFJQWQZTSF(0, num, 4, 8);
				}
				else
				{
					reqQpltmZECaOiUUkHqFJQWQZTSF(0, num, 1, 2);
					reqQpltmZECaOiUUkHqFJQWQZTSF(1, num, 4, 8);
				}
				reqQpltmZECaOiUUkHqFJQWQZTSF(2, num, 16, 32);
				reqQpltmZECaOiUUkHqFJQWQZTSF(3, num, 64, 128);
				reqQpltmZECaOiUUkHqFJQWQZTSF(4, num, 256, 512);
			}
			sgKaMAEpEDbMpbgGtTTYOoSYsQiC = P_0.mTwnETApLXdkTfVCkRfNzVuKAFImA;
			wbgeSTIBcjHigAQzevsphCfMXBlRB = P_0.EspyJIvLzGZPinoCoCuzQlfzLiUg;
			KWLsyHpyrsWFBeJnrXTiTRTUgHhF kWLsyHpyrsWFBeJnrXTiTRTUgHhF = oZkSHchLEiDGcLTxRYPGpngpJBvB;
			oZkSHchLEiDGcLTxRYPGpngpJBvB = P_0.NoNXDesoksyDBEzsphZboisOlueX;
			if (oZkSHchLEiDGcLTxRYPGpngpJBvB != kWLsyHpyrsWFBeJnrXTiTRTUgHhF)
			{
				cOLqbKCgZYDkuJTwkfYJCjdeyXxg = false;
			}
			if (oZkSHchLEiDGcLTxRYPGpngpJBvB == KWLsyHpyrsWFBeJnrXTiTRTUgHhF.MoveRelative)
			{
				vzFiMIaUgHKHEKLRiqBckNHKJzrm += (float)P_0.JzeaCigcZZfutCxoMYpBOcWAiJivA * 0.5f;
				SUHrcplkfmUYUUofLGLZWxdnRGbE += (float)P_0.gEkeDNqJJIhydaNAzAZHjBjBoKqxA * 0.5f * -1f;
			}
			else if ((oZkSHchLEiDGcLTxRYPGpngpJBvB & KWLsyHpyrsWFBeJnrXTiTRTUgHhF.MoveAbsolute) != KWLsyHpyrsWFBeJnrXTiTRTUgHhF.MoveRelative)
			{
				bool num2 = (oZkSHchLEiDGcLTxRYPGpngpJBvB & KWLsyHpyrsWFBeJnrXTiTRTUgHhF.VirtualDesktop) != 0;
				int num3 = NtPSOxELPOOaKLQRVmbwGRgHcLOL.ntMjhzJDjrCxEIElPrQCzkevzPHJ(num2 ? jHxeSYMpHmzLkpJXlDMcvDxoJMih.izgcFgizvALdxcaIXzxQJzMNOfUl : jHxeSYMpHmzLkpJXlDMcvDxoJMih.odoDagJmCPUHlOZAMRVoegrKAqWAb);
				int num4 = NtPSOxELPOOaKLQRVmbwGRgHcLOL.ntMjhzJDjrCxEIElPrQCzkevzPHJ(num2 ? jHxeSYMpHmzLkpJXlDMcvDxoJMih.tPNDCMtmnOkvENQhBmjCsXKbutqW : jHxeSYMpHmzLkpJXlDMcvDxoJMih.aIOTIifBbwOVnvFFbbSleTzlWhSdA);
				int num5 = (int)((float)P_0.JzeaCigcZZfutCxoMYpBOcWAiJivA / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.gEkeDNqJJIhydaNAzAZHjBjBoKqxA) / 65535f * (float)num4);
				if (!cOLqbKCgZYDkuJTwkfYJCjdeyXxg)
				{
					XvHGUYwAhkvRuZiOSwATKOYWNeNm = num5;
					kSOTHMuGyjEqgKyEIOWgEYtnIWko = num6;
					cOLqbKCgZYDkuJTwkfYJCjdeyXxg = true;
				}
				vzFiMIaUgHKHEKLRiqBckNHKJzrm += num5 - XvHGUYwAhkvRuZiOSwATKOYWNeNm;
				SUHrcplkfmUYUUofLGLZWxdnRGbE += num6 - kSOTHMuGyjEqgKyEIOWgEYtnIWko;
				XvHGUYwAhkvRuZiOSwATKOYWNeNm = num5;
				kSOTHMuGyjEqgKyEIOWgEYtnIWko = num6;
			}
			else
			{
				vzFiMIaUgHKHEKLRiqBckNHKJzrm = P_0.JzeaCigcZZfutCxoMYpBOcWAiJivA;
				SUHrcplkfmUYUUofLGLZWxdnRGbE = P_0.gEkeDNqJJIhydaNAzAZHjBjBoKqxA;
			}
			if (P_0.gZeitFyXkuYYQLRThzUyAvTzeGzA != 0)
			{
				int num7 = ((MathTools.Abs(P_0.gZeitFyXkuYYQLRThzUyAvTzeGzA) < 120) ? MathTools.Sign(P_0.gZeitFyXkuYYQLRThzUyAvTzeGzA) : (P_0.gZeitFyXkuYYQLRThzUyAvTzeGzA / 120));
				if ((nTaNBMUpXxTiQRkRAOjOPHJxpZlS & NTaNBMUpXxTiQRkRAOjOPHJxpZlS.MouseWheel) != NTaNBMUpXxTiQRkRAOjOPHJxpZlS.None)
				{
					CgcifyhcAqJHBSbiHOSgdEwITxNo += num7;
				}
				else if ((nTaNBMUpXxTiQRkRAOjOPHJxpZlS & (NTaNBMUpXxTiQRkRAOjOPHJxpZlS)2048) != NTaNBMUpXxTiQRkRAOjOPHJxpZlS.None)
				{
					aSdSxBnOLAbVXfmIabAjWANDwKVh += num7;
				}
			}
		}

		public void LpsbZtELHWqafzBuZnXLCSFFqefm(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = vzFiMIaUgHKHEKLRiqBckNHKJzrm;
			axisValues[1] = SUHrcplkfmUYUUofLGLZWxdnRGbE;
			axisValues[2] = CgcifyhcAqJHBSbiHOSgdEwITxNo;
			axisValues[3] = aSdSxBnOLAbVXfmIabAjWANDwKVh;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = kwgtjHSMIQHnpiwTZQruDjReeGdZA[i] || UHwUddEzbjMvdlTrzrPFVGtJOZHF[i];
			}
			JPRKdiDDpDeKbtQNPPmnrLIqqgjN();
		}

		public void vOVvdsmZiFeBcyEbdMQPxPNVsIXJ()
		{
			JPRKdiDDpDeKbtQNPPmnrLIqqgjN();
		}

		private void JPRKdiDDpDeKbtQNPPmnrLIqqgjN()
		{
			if (cCndRxeCUHwLhLHPSOqrNuFDjLfj != ReInput.absFrame)
			{
				RieAsYEMBqTUuMAeREakyzSHBmyKA();
				cCndRxeCUHwLhLHPSOqrNuFDjLfj = ReInput.absFrame;
			}
		}

		public void EkzcgBdbeGXIvbbppVXCGvvMXouEA()
		{
			vzFiMIaUgHKHEKLRiqBckNHKJzrm = 0f;
			SUHrcplkfmUYUUofLGLZWxdnRGbE = 0f;
			wbgeSTIBcjHigAQzevsphCfMXBlRB = 0u;
			oZkSHchLEiDGcLTxRYPGpngpJBvB = KWLsyHpyrsWFBeJnrXTiTRTUgHhF.MoveRelative;
			CgcifyhcAqJHBSbiHOSgdEwITxNo = 0f;
			aSdSxBnOLAbVXfmIabAjWANDwKVh = 0f;
			Array.Clear(kwgtjHSMIQHnpiwTZQruDjReeGdZA, 0, 5);
			Array.Clear(UHwUddEzbjMvdlTrzrPFVGtJOZHF, 0, 5);
			cOLqbKCgZYDkuJTwkfYJCjdeyXxg = false;
		}

		public void RieAsYEMBqTUuMAeREakyzSHBmyKA()
		{
			vzFiMIaUgHKHEKLRiqBckNHKJzrm = 0f;
			SUHrcplkfmUYUUofLGLZWxdnRGbE = 0f;
			CgcifyhcAqJHBSbiHOSgdEwITxNo = 0f;
			aSdSxBnOLAbVXfmIabAjWANDwKVh = 0f;
			Array.Clear(UHwUddEzbjMvdlTrzrPFVGtJOZHF, 0, 5);
		}

		private void reqQpltmZECaOiUUkHqFJQWQZTSF(int P_0, int P_1, int P_2, int P_3)
		{
			kRNoMAmNgoxnbkjjJyEbUeyJzhVW kRNoMAmNgoxnbkjjJyEbUeyJzhVW2 = xUlrKRKyXOkJrNDGfvVBZxqufaik(P_1, P_2, P_3);
			if (kwgtjHSMIQHnpiwTZQruDjReeGdZA[P_0])
			{
				if (kRNoMAmNgoxnbkjjJyEbUeyJzhVW2 == kRNoMAmNgoxnbkjjJyEbUeyJzhVW.Up || kRNoMAmNgoxnbkjjJyEbUeyJzhVW2 == kRNoMAmNgoxnbkjjJyEbUeyJzhVW.DownAndUp)
				{
					kwgtjHSMIQHnpiwTZQruDjReeGdZA[P_0] = false;
				}
			}
			else if (kRNoMAmNgoxnbkjjJyEbUeyJzhVW2 == kRNoMAmNgoxnbkjjJyEbUeyJzhVW.Down)
			{
				kwgtjHSMIQHnpiwTZQruDjReeGdZA[P_0] = true;
			}
			if (kRNoMAmNgoxnbkjjJyEbUeyJzhVW2 == kRNoMAmNgoxnbkjjJyEbUeyJzhVW.Down || kRNoMAmNgoxnbkjjJyEbUeyJzhVW2 == kRNoMAmNgoxnbkjjJyEbUeyJzhVW.DownAndUp)
			{
				UHwUddEzbjMvdlTrzrPFVGtJOZHF[P_0] = true;
			}
		}

		private static kRNoMAmNgoxnbkjjJyEbUeyJzhVW xUlrKRKyXOkJrNDGfvVBZxqufaik(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return kRNoMAmNgoxnbkjjJyEbUeyJzhVW.DownAndUp;
				}
				return kRNoMAmNgoxnbkjjJyEbUeyJzhVW.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return kRNoMAmNgoxnbkjjJyEbUeyJzhVW.Up;
			}
			return kRNoMAmNgoxnbkjjJyEbUeyJzhVW.None;
		}

		private static bool prpZmOnlqnFCFkNGvTXeSNxFrHKp(IntPtr P_0)
		{
			if (NtPSOxELPOOaKLQRVmbwGRgHcLOL.XBNmGvceETjoKcLLdzbobVCDUcevA(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!NtPSOxELPOOaKLQRVmbwGRgHcLOL.ifDjvBKqaiexGCZRaKydZQmqDEJd(P_0, out var vlfgncxvllnAvfZfdwCSJhJwTmvu2))
			{
				return false;
			}
			if (!NtPSOxELPOOaKLQRVmbwGRgHcLOL.sVyRlxiLdQjBkBpkHPldkhpiOFCbA(out var vlfgncxvllnAvfZfdwCSJhJwTmvu3))
			{
				return false;
			}
			if (!NtPSOxELPOOaKLQRVmbwGRgHcLOL.dhjIPJzJjPHPbPkasogzeMnBigtBA(P_0, out var qbkmXxJfjjyFQragMfjpSdaEJOIr2))
			{
				return false;
			}
			int num = vlfgncxvllnAvfZfdwCSJhJwTmvu3.kUZgAOKaMXbTQnOGLZUFDAIKRymCA - vlfgncxvllnAvfZfdwCSJhJwTmvu2.kUZgAOKaMXbTQnOGLZUFDAIKRymCA;
			int num2 = vlfgncxvllnAvfZfdwCSJhJwTmvu3.DRLDknqpSlHFELcdxcBdcNaAfGmGA - vlfgncxvllnAvfZfdwCSJhJwTmvu2.DRLDknqpSlHFELcdxcBdcNaAfGmGA;
			if (num >= 0 && num2 >= 0 && num <= qbkmXxJfjjyFQragMfjpSdaEJOIr2.EFtEtVIoOOjhCteIqNwScStOktPe && num2 <= qbkmXxJfjjyFQragMfjpSdaEJOIr2.LVVBBLQYIOTBZhHFGHrMuubdnqNe)
			{
				return false;
			}
			if (!NtPSOxELPOOaKLQRVmbwGRgHcLOL.XXBCzeytpfvFbumhXUsiLGHcylVH(P_0, out var qbkmXxJfjjyFQragMfjpSdaEJOIr3))
			{
				return false;
			}
			if (vlfgncxvllnAvfZfdwCSJhJwTmvu3.kUZgAOKaMXbTQnOGLZUFDAIKRymCA >= qbkmXxJfjjyFQragMfjpSdaEJOIr3.xPOJYXrdqfPICgfeRNIPJhEmiIYn && vlfgncxvllnAvfZfdwCSJhJwTmvu3.kUZgAOKaMXbTQnOGLZUFDAIKRymCA <= qbkmXxJfjjyFQragMfjpSdaEJOIr3.EFtEtVIoOOjhCteIqNwScStOktPe && vlfgncxvllnAvfZfdwCSJhJwTmvu3.DRLDknqpSlHFELcdxcBdcNaAfGmGA >= qbkmXxJfjjyFQragMfjpSdaEJOIr3.pJtXSdqLbxibbVpAiWnXnEaxADrX)
			{
				return vlfgncxvllnAvfZfdwCSJhJwTmvu3.DRLDknqpSlHFELcdxcBdcNaAfGmGA <= qbkmXxJfjjyFQragMfjpSdaEJOIr3.LVVBBLQYIOTBZhHFGHrMuubdnqNe;
			}
			return false;
		}
	}

	private class edIHTdeRRHXARXJwOYQAbiRfbARaA
	{
		private bool SNuQiRaVIrmzCVhjcWObbwNNKdvj;

		private bool WsvDyFAEwpHmlxDiQrBsIIjtVJUeA;

		private bool gJuppOGdfScjFFiyTuZKepanfpId;

		private int HbzjgwGOeAGgaStqVDnGtesMFPcab = 10;

		private readonly float wySpXxUECkMBZFFaRqPxdYPKcUnP;

		private double OWEcltOgUbCRYpUCVryqVrsKbqFR;

		public bool jhbkyQNyuyFGKOrpXBTJFsXdIecU
		{
			get
			{
				return SNuQiRaVIrmzCVhjcWObbwNNKdvj;
			}
			set
			{
				if (flag != SNuQiRaVIrmzCVhjcWObbwNNKdvj)
				{
					AtOezqgweGPpTGdJMOLFjdBYZUrAA(true);
				}
			}
		}

		public bool gbYEuaAPgBIiuNZvoKDOuKfZzFYtA => WsvDyFAEwpHmlxDiQrBsIIjtVJUeA;

		public bool czoSpakcjCjjhfLxbbofVFInmPyU
		{
			get
			{
				return gJuppOGdfScjFFiyTuZKepanfpId;
			}
			set
			{
				if (gJuppOGdfScjFFiyTuZKepanfpId != flag)
				{
					gJuppOGdfScjFFiyTuZKepanfpId = flag;
					AtOezqgweGPpTGdJMOLFjdBYZUrAA(true);
				}
			}
		}

		public int ZNDKapbcpUQoIYjchEevoNmKiwCM => HbzjgwGOeAGgaStqVDnGtesMFPcab;

		public edIHTdeRRHXARXJwOYQAbiRfbARaA(bool P_0, float P_1)
		{
			SNuQiRaVIrmzCVhjcWObbwNNKdvj = P_0;
			wySpXxUECkMBZFFaRqPxdYPKcUnP = P_1;
			AtOezqgweGPpTGdJMOLFjdBYZUrAA(false);
		}

		public void govLTgGHDGiEReDbOPUIfjHxKJrYA()
		{
			if (SNuQiRaVIrmzCVhjcWObbwNNKdvj && !(ReInput.realTime < OWEcltOgUbCRYpUCVryqVrsKbqFR))
			{
				AtOezqgweGPpTGdJMOLFjdBYZUrAA(true);
			}
		}

		private void AtOezqgweGPpTGdJMOLFjdBYZUrAA(bool P_0)
		{
			if (gJuppOGdfScjFFiyTuZKepanfpId)
			{
				NtPSOxELPOOaKLQRVmbwGRgHcLOL.CanBjrLCNnfRmGQlAIqmrwjkRpwP(112u, 0u, ref HbzjgwGOeAGgaStqVDnGtesMFPcab, 0u);
			}
			WsvDyFAEwpHmlxDiQrBsIIjtVJUeA = NtPSOxELPOOaKLQRVmbwGRgHcLOL.ntMjhzJDjrCxEIElPrQCzkevzPHJ(jHxeSYMpHmzLkpJXlDMcvDxoJMih.tNzDvpYkqSBTEYmzOyhYUkgmMExB) > 0;
			if (P_0)
			{
				OWEcltOgUbCRYpUCVryqVrsKbqFR = ReInput.realTime + (double)wySpXxUECkMBZFFaRqPxdYPKcUnP;
			}
		}
	}

	private const int RzhajbVSzDCBYciKNtQuBhNqtxepA = 5;

	private const int VdDluQDvQVQcaaSkwCtIORcNuZSs = 4;

	private readonly SpinLock cUXCsiKQQVlYOWhBBVEkmQMjugmx = new SpinLock();

	private UpdateLoopDataSet<rEjTESHArUfLjYeYtdcbuvgkamOBA> KTTHpUNlErEXpwWRxujYIKCQqgDd;

	private HardwareControllerMap_Game KDdozTvKkFIDMPdzixgpSHbSNBZw;

	private edIHTdeRRHXARXJwOYQAbiRfbARaA rtlCkWCOVlJeYegimZTUnUMtTWtRA;

	private bool wTjGqXTPKuNFQXeZUbDWHGhIAcZh;

	private int LnZsTOgHWtdeAqJrEDJbhUKOGmJuA;

	private bool OOXiYSPAXLRIYGwvxFcuukivUqqj;

	private const bool pSKSMxpnVbfUunMtJvJZmmVygUbm = true;

	private const float oeTboYbuSouEKBdNuBOAUkdRSnBg = 2f;

	private bool ouwiFOlFfXxTXHxWxLfNvkXOjEOQ;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return OOXiYSPAXLRIYGwvxFcuukivUqqj;
		}
		set
		{
			if (OOXiYSPAXLRIYGwvxFcuukivUqqj != value)
			{
				OOXiYSPAXLRIYGwvxFcuukivUqqj = value;
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
			if (KDdozTvKkFIDMPdzixgpSHbSNBZw == null)
			{
				KDdozTvKkFIDMPdzixgpSHbSNBZw = mERwuiGtgyshIlqvwNFSVXVGnAfH();
			}
			return KDdozTvKkFIDMPdzixgpSHbSNBZw;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!OOXiYSPAXLRIYGwvxFcuukivUqqj)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public kEXzsJGBwwhisqDbvAUEGMcgkoBi(UpdateLoopSetting P_0)
	{
		NbHkAvNylqodidJRpTPdCZpDboYV();
		rtlCkWCOVlJeYegimZTUnUMtTWtRA = new edIHTdeRRHXARXJwOYQAbiRfbARaA(true, 2f);
		KTTHpUNlErEXpwWRxujYIKCQqgDd = new UpdateLoopDataSet<rEjTESHArUfLjYeYtdcbuvgkamOBA>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				KTTHpUNlErEXpwWRxujYIKCQqgDd[i] = new rEjTESHArUfLjYeYtdcbuvgkamOBA(rtlCkWCOVlJeYegimZTUnUMtTWtRA, list[i]);
			}
		}
		wTjGqXTPKuNFQXeZUbDWHGhIAcZh = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += jtlGzIXpgOVvmwykLOEsqUhyUpKc;
		ReInput.ApplicationPauseChangedEvent += XNsHKOEtLSeAiDaySiCdIWvxvvHH;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += iqdZLvTtHYSZklcxHGvpNDZyMNwf;
		ReInput.TimeScalePauseChangedEvent += EkbAgbIFtKPdXAJbITMRiLFPfGttA;
		ReInput.UpdateEndedEvent += LvGFNIepShGHCfaybCxUTtTTKnRO;
	}

	public void epTeoCLFuSRBTBJJjuuLYGzusddu(UpdateLoopType P_0)
	{
		KTTHpUNlErEXpwWRxujYIKCQqgDd.SetUpdateLoop(P_0);
		rtlCkWCOVlJeYegimZTUnUMtTWtRA.govLTgGHDGiEReDbOPUIfjHxKJrYA();
		wTjGqXTPKuNFQXeZUbDWHGhIAcZh = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void OqsDeifJsHlaqZYfLqXHrJKvpQYTA(OMJYRORIFUjhualKseRMOFMGjmDH P_0)
	{
		if (!wTjGqXTPKuNFQXeZUbDWHGhIAcZh)
		{
			return;
		}
		using (cUXCsiKQQVlYOWhBBVEkmQMjugmx.Lock())
		{
			int count = KTTHpUNlErEXpwWRxujYIKCQqgDd.Count;
			for (int i = 0; i < count; i++)
			{
				KTTHpUNlErEXpwWRxujYIKCQqgDd[i].MYhNSNklAKFZgomSdGPHxGcRcwVu(P_0);
			}
		}
	}

	public void gdjjmzMrbyjigqKShnCBJuFifcle(bool P_0)
	{
		xBkNPKQQHvoOejZfyAXwdjGoKQN();
	}

	public void kKwgtCFAteYsIOJKNEiECPibqRRic(bool P_0)
	{
		if (NbHkAvNylqodidJRpTPdCZpDboYV() < 0)
		{
			xBkNPKQQHvoOejZfyAXwdjGoKQN();
		}
	}

	private int NbHkAvNylqodidJRpTPdCZpDboYV()
	{
		int lnZsTOgHWtdeAqJrEDJbhUKOGmJuA = LnZsTOgHWtdeAqJrEDJbhUKOGmJuA;
		if (ZjPoFuIZYwHPNsNOdhdEqslfjobcA.oHJuCuBNKuCaQvoIFOMploWszypm(bAJJQXPTtXjCTdxqFSbmTHlYPoOG.Mouse, out var lnZsTOgHWtdeAqJrEDJbhUKOGmJuA2))
		{
			LnZsTOgHWtdeAqJrEDJbhUKOGmJuA = lnZsTOgHWtdeAqJrEDJbhUKOGmJuA2;
		}
		else
		{
			LnZsTOgHWtdeAqJrEDJbhUKOGmJuA = ((NtPSOxELPOOaKLQRVmbwGRgHcLOL.ntMjhzJDjrCxEIElPrQCzkevzPHJ(jHxeSYMpHmzLkpJXlDMcvDxoJMih.agkPuaxWseLXOciAsKbGGWPBWkwv) != 0) ? 1 : 0);
		}
		return LnZsTOgHWtdeAqJrEDJbhUKOGmJuA - lnZsTOgHWtdeAqJrEDJbhUKOGmJuA;
	}

	private void jtlGzIXpgOVvmwykLOEsqUhyUpKc(bool P_0)
	{
		wTjGqXTPKuNFQXeZUbDWHGhIAcZh = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !wTjGqXTPKuNFQXeZUbDWHGhIAcZh)
		{
			xBkNPKQQHvoOejZfyAXwdjGoKQN();
		}
	}

	private void XNsHKOEtLSeAiDaySiCdIWvxvvHH(bool P_0)
	{
		wTjGqXTPKuNFQXeZUbDWHGhIAcZh = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!wTjGqXTPKuNFQXeZUbDWHGhIAcZh)
		{
			xBkNPKQQHvoOejZfyAXwdjGoKQN();
		}
	}

	private void iqdZLvTtHYSZklcxHGvpNDZyMNwf(bool P_0)
	{
	}

	private void EkbAgbIFtKPdXAJbITMRiLFPfGttA(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		wTjGqXTPKuNFQXeZUbDWHGhIAcZh = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (cUXCsiKQQVlYOWhBBVEkmQMjugmx.Lock())
		{
			KTTHpUNlErEXpwWRxujYIKCQqgDd[KTTHpUNlErEXpwWRxujYIKCQqgDd.fixedUpdateSetIndex].RieAsYEMBqTUuMAeREakyzSHBmyKA();
		}
	}

	private void LvGFNIepShGHCfaybCxUTtTTKnRO(UpdateLoopType P_0)
	{
		using (cUXCsiKQQVlYOWhBBVEkmQMjugmx.Lock())
		{
			KTTHpUNlErEXpwWRxujYIKCQqgDd.Get(P_0).vOVvdsmZiFeBcyEbdMQPxPNVsIXJ();
		}
	}

	private void xBkNPKQQHvoOejZfyAXwdjGoKQN()
	{
		using (cUXCsiKQQVlYOWhBBVEkmQMjugmx.Lock())
		{
			int count = KTTHpUNlErEXpwWRxujYIKCQqgDd.Count;
			for (int i = 0; i < count; i++)
			{
				KTTHpUNlErEXpwWRxujYIKCQqgDd[i].EkzcgBdbeGXIvbbppVXCGvvMXouEA();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		KTTHpUNlErEXpwWRxujYIKCQqgDd.Current.LpsbZtELHWqafzBuZnXLCSFFqefm(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		xBkNPKQQHvoOejZfyAXwdjGoKQN();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game mERwuiGtgyshIlqvwNFSVXVGnAfH()
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
		VWtUpHZagGFVMBthYTcSwrnrVFUy(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void DIOIBCyKBaagvcuXcBhagWcjqfaP()
	{
		try
		{
			VWtUpHZagGFVMBthYTcSwrnrVFUy(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void VWtUpHZagGFVMBthYTcSwrnrVFUy(bool P_0)
	{
		if (!ouwiFOlFfXxTXHxWxLfNvkXOjEOQ)
		{
			ReInput.ApplicationFocusChangedEvent -= jtlGzIXpgOVvmwykLOEsqUhyUpKc;
			ReInput.ApplicationPauseChangedEvent -= XNsHKOEtLSeAiDaySiCdIWvxvvHH;
			ReInput.EditorPauseChangedEvent -= iqdZLvTtHYSZklcxHGvpNDZyMNwf;
			ReInput.TimeScalePauseChangedEvent -= EkbAgbIFtKPdXAJbITMRiLFPfGttA;
			ReInput.UpdateEndedEvent -= LvGFNIepShGHCfaybCxUTtTTKnRO;
			if (P_0 && OOXiYSPAXLRIYGwvxFcuukivUqqj)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			ouwiFOlFfXxTXHxWxLfNvkXOjEOQ = true;
		}
	}
}
