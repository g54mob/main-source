using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class NCZNhrCupoGuOroTBBBCFKccmmyk : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class GSrdGmXaQQcGHJGFTdadpwsiahdK
	{
		private enum VLPwmmifbmcUXhfgvCBpXXaHHdctA
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int TnjvFIfbOzdqPVbfoJkOSMsNcNckA = 120;

		private const int lZEuiQlDwfcaOJIBQnCAfwfiIQXqA = 2048;

		public readonly UpdateLoopType haoebYznMZGUmjMDcHtYcPRkOqNK;

		public uint JcSMPiEfqPgMXsrlLRKCBKqCkqBM;

		public uint VdcIurDMfzaDCFTaTAfjFHfDXFIuB;

		public vAVAOrdfdutEvlNmPYuiUCLQqGEi JKJCubnGOIOyaAzMNJXJaXhrHJoR;

		public float CoXckkwXfXeoqdRAUOMohfVAibIcb;

		public float nCBXMZbbzyzRsXFbbBPFFqpdzLSo;

		public float zcqEyOnDlegdvHrxlTeaqAiEpoqj;

		public float XEvoqtlKtGKxjspxEiPzLRZLwoyc;

		private bool[] NrmrJxIGPOCWXexSxVquAePylGAcb;

		private bool[] vzqymTYckzbmNkuSZceXMlyRGdid;

		private TkGFrJJkYHhlbjKjAgXMWiNWtUsJB lKhovyCRxiyfhOFDaADvLZMgESzN;

		private uint PwvBuLgIJLXXXSEpsZGxMRNJbaGG;

		private int acPexmkhmiYSGQGPqbbBRGEOFLew;

		private int NOKhEekladBsYLVdiPeqHEpdCxRG;

		private bool DjNKOyMmSOyIOOBpEEcBNvriqsMS;

		public GSrdGmXaQQcGHJGFTdadpwsiahdK(TkGFrJJkYHhlbjKjAgXMWiNWtUsJB P_0, UpdateLoopType P_1)
		{
			lKhovyCRxiyfhOFDaADvLZMgESzN = P_0;
			haoebYznMZGUmjMDcHtYcPRkOqNK = P_1;
			NrmrJxIGPOCWXexSxVquAePylGAcb = new bool[5];
			vzqymTYckzbmNkuSZceXMlyRGdid = new bool[5];
		}

		public void xJxzXbePbMiCCfiHNNrBcfkVykcK(bURwuaJfGEQlKxePMfQYBYUKpoef P_0)
		{
			sJkWbyUGEvTTgACKarsIEDNhjXYhA sJkWbyUGEvTTgACKarsIEDNhjXYhA2 = P_0.YoRglNJptnxYnckYumgjcNfFjnhtA;
			if (sJkWbyUGEvTTgACKarsIEDNhjXYhA2 != sJkWbyUGEvTTgACKarsIEDNhjXYhA.None)
			{
				if ((sJkWbyUGEvTTgACKarsIEDNhjXYhA2 & sJkWbyUGEvTTgACKarsIEDNhjXYhA.LeftButtonDown) != sJkWbyUGEvTTgACKarsIEDNhjXYhA.None || (sJkWbyUGEvTTgACKarsIEDNhjXYhA2 & sJkWbyUGEvTTgACKarsIEDNhjXYhA.RightButtonDown) != sJkWbyUGEvTTgACKarsIEDNhjXYhA.None)
				{
					IntPtr intPtr = wfRybNWHWOpoyMQsxzdwHdiNgarj.DcEMACVJnwLAmZDRlamEsMKnjWNHA();
					if (wfRybNWHWOpoyMQsxzdwHdiNgarj.qBcPlmeDfgHLMerisBIrLbCpsbZk() == intPtr && CNxkMcbRplKntdwRLCOyHkbTHVpk(intPtr))
					{
						sJkWbyUGEvTTgACKarsIEDNhjXYhA2 &= ~sJkWbyUGEvTTgACKarsIEDNhjXYhA.LeftButtonDown;
						sJkWbyUGEvTTgACKarsIEDNhjXYhA2 &= ~sJkWbyUGEvTTgACKarsIEDNhjXYhA.RightButtonDown;
					}
				}
				int num = (int)sJkWbyUGEvTTgACKarsIEDNhjXYhA2;
				if (lKhovyCRxiyfhOFDaADvLZMgESzN.IHhdWuCFjqutcmDwvNOXlWXtAeHVA && lKhovyCRxiyfhOFDaADvLZMgESzN.DNIiWWFJjZbDAApoGqISJjzLDtbl)
				{
					YCmmoBngEIxncffJEQQHSSWMFtri(1, num, 1, 2);
					YCmmoBngEIxncffJEQQHSSWMFtri(0, num, 4, 8);
				}
				else
				{
					YCmmoBngEIxncffJEQQHSSWMFtri(0, num, 1, 2);
					YCmmoBngEIxncffJEQQHSSWMFtri(1, num, 4, 8);
				}
				YCmmoBngEIxncffJEQQHSSWMFtri(2, num, 16, 32);
				YCmmoBngEIxncffJEQQHSSWMFtri(3, num, 64, 128);
				YCmmoBngEIxncffJEQQHSSWMFtri(4, num, 256, 512);
			}
			JcSMPiEfqPgMXsrlLRKCBKqCkqBM = P_0.TJgWefOlEViBhgETKtwFqEwQtPrcA;
			VdcIurDMfzaDCFTaTAfjFHfDXFIuB = P_0.nGpUIupFsEooAkhJGbBfJSzbqBnq;
			vAVAOrdfdutEvlNmPYuiUCLQqGEi jKJCubnGOIOyaAzMNJXJaXhrHJoR = JKJCubnGOIOyaAzMNJXJaXhrHJoR;
			JKJCubnGOIOyaAzMNJXJaXhrHJoR = P_0.aPNndUmizuymnXtnXUVvdFuUDiHv;
			if (JKJCubnGOIOyaAzMNJXJaXhrHJoR != jKJCubnGOIOyaAzMNJXJaXhrHJoR)
			{
				DjNKOyMmSOyIOOBpEEcBNvriqsMS = false;
			}
			if (JKJCubnGOIOyaAzMNJXJaXhrHJoR == vAVAOrdfdutEvlNmPYuiUCLQqGEi.MoveRelative)
			{
				CoXckkwXfXeoqdRAUOMohfVAibIcb += (float)P_0.aJssYboGRPXXVubfiuJDhCzOLFmc * 0.5f;
				nCBXMZbbzyzRsXFbbBPFFqpdzLSo += (float)P_0.ZYsFbrKiGWzHPlARNmGThMlPWUZnA * 0.5f * -1f;
			}
			else if ((JKJCubnGOIOyaAzMNJXJaXhrHJoR & vAVAOrdfdutEvlNmPYuiUCLQqGEi.MoveAbsolute) != vAVAOrdfdutEvlNmPYuiUCLQqGEi.MoveRelative)
			{
				bool num2 = (JKJCubnGOIOyaAzMNJXJaXhrHJoR & vAVAOrdfdutEvlNmPYuiUCLQqGEi.VirtualDesktop) != 0;
				int num3 = wfRybNWHWOpoyMQsxzdwHdiNgarj.CoQNiNJmurxksRgofwmCczerfpem(num2 ? OZbSvqUUHiSzSuQfJGOouxVsZnLE.PiwImWuqJEyTRpNzjwQSMSmXIvbe : OZbSvqUUHiSzSuQfJGOouxVsZnLE.RaaJCEgrZJXaPEjNmoOerqxYgJfl);
				int num4 = wfRybNWHWOpoyMQsxzdwHdiNgarj.CoQNiNJmurxksRgofwmCczerfpem(num2 ? OZbSvqUUHiSzSuQfJGOouxVsZnLE.MNHGaqAfgEbEkFQwAjqEhbGljxDac : OZbSvqUUHiSzSuQfJGOouxVsZnLE.FvMQiYzvooaeXaoWXdTzAwbxHzxy);
				int num5 = (int)((float)P_0.aJssYboGRPXXVubfiuJDhCzOLFmc / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.ZYsFbrKiGWzHPlARNmGThMlPWUZnA) / 65535f * (float)num4);
				if (!DjNKOyMmSOyIOOBpEEcBNvriqsMS)
				{
					acPexmkhmiYSGQGPqbbBRGEOFLew = num5;
					NOKhEekladBsYLVdiPeqHEpdCxRG = num6;
					DjNKOyMmSOyIOOBpEEcBNvriqsMS = true;
				}
				CoXckkwXfXeoqdRAUOMohfVAibIcb += num5 - acPexmkhmiYSGQGPqbbBRGEOFLew;
				nCBXMZbbzyzRsXFbbBPFFqpdzLSo += num6 - NOKhEekladBsYLVdiPeqHEpdCxRG;
				acPexmkhmiYSGQGPqbbBRGEOFLew = num5;
				NOKhEekladBsYLVdiPeqHEpdCxRG = num6;
			}
			else
			{
				CoXckkwXfXeoqdRAUOMohfVAibIcb = P_0.aJssYboGRPXXVubfiuJDhCzOLFmc;
				nCBXMZbbzyzRsXFbbBPFFqpdzLSo = P_0.ZYsFbrKiGWzHPlARNmGThMlPWUZnA;
			}
			if (P_0.LzwGLPwdCyhvcKWAVrcCLabxKojQ != 0)
			{
				int num7 = ((MathTools.Abs(P_0.LzwGLPwdCyhvcKWAVrcCLabxKojQ) < 120) ? MathTools.Sign(P_0.LzwGLPwdCyhvcKWAVrcCLabxKojQ) : (P_0.LzwGLPwdCyhvcKWAVrcCLabxKojQ / 120));
				if ((sJkWbyUGEvTTgACKarsIEDNhjXYhA2 & sJkWbyUGEvTTgACKarsIEDNhjXYhA.MouseWheel) != sJkWbyUGEvTTgACKarsIEDNhjXYhA.None)
				{
					zcqEyOnDlegdvHrxlTeaqAiEpoqj += num7;
				}
				else if ((sJkWbyUGEvTTgACKarsIEDNhjXYhA2 & (sJkWbyUGEvTTgACKarsIEDNhjXYhA)2048) != sJkWbyUGEvTTgACKarsIEDNhjXYhA.None)
				{
					XEvoqtlKtGKxjspxEiPzLRZLwoyc += num7;
				}
			}
		}

		public void gJcPuFUrAAVpPcIphmQDJEZNqHIh(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = CoXckkwXfXeoqdRAUOMohfVAibIcb;
			axisValues[1] = nCBXMZbbzyzRsXFbbBPFFqpdzLSo;
			axisValues[2] = zcqEyOnDlegdvHrxlTeaqAiEpoqj;
			axisValues[3] = XEvoqtlKtGKxjspxEiPzLRZLwoyc;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = NrmrJxIGPOCWXexSxVquAePylGAcb[i] || vzqymTYckzbmNkuSZceXMlyRGdid[i];
			}
			atHomEFoLZjaDwGSpdjbsWssqLQD();
		}

		public void CSLBoCsDYHGJCbqgTDRTGwXFWsgDA()
		{
			atHomEFoLZjaDwGSpdjbsWssqLQD();
		}

		private void atHomEFoLZjaDwGSpdjbsWssqLQD()
		{
			if (PwvBuLgIJLXXXSEpsZGxMRNJbaGG != ReInput.absFrame)
			{
				ovwJUuOFKcRjARQfjlUaiECZeuVJ();
				PwvBuLgIJLXXXSEpsZGxMRNJbaGG = ReInput.absFrame;
			}
		}

		public void vUliIbdadGpbHgogHxYEqFhIWqDv()
		{
			CoXckkwXfXeoqdRAUOMohfVAibIcb = 0f;
			nCBXMZbbzyzRsXFbbBPFFqpdzLSo = 0f;
			VdcIurDMfzaDCFTaTAfjFHfDXFIuB = 0u;
			JKJCubnGOIOyaAzMNJXJaXhrHJoR = vAVAOrdfdutEvlNmPYuiUCLQqGEi.MoveRelative;
			zcqEyOnDlegdvHrxlTeaqAiEpoqj = 0f;
			XEvoqtlKtGKxjspxEiPzLRZLwoyc = 0f;
			Array.Clear(NrmrJxIGPOCWXexSxVquAePylGAcb, 0, 5);
			Array.Clear(vzqymTYckzbmNkuSZceXMlyRGdid, 0, 5);
			DjNKOyMmSOyIOOBpEEcBNvriqsMS = false;
		}

		public void ovwJUuOFKcRjARQfjlUaiECZeuVJ()
		{
			CoXckkwXfXeoqdRAUOMohfVAibIcb = 0f;
			nCBXMZbbzyzRsXFbbBPFFqpdzLSo = 0f;
			zcqEyOnDlegdvHrxlTeaqAiEpoqj = 0f;
			XEvoqtlKtGKxjspxEiPzLRZLwoyc = 0f;
			Array.Clear(vzqymTYckzbmNkuSZceXMlyRGdid, 0, 5);
		}

		private void YCmmoBngEIxncffJEQQHSSWMFtri(int P_0, int P_1, int P_2, int P_3)
		{
			VLPwmmifbmcUXhfgvCBpXXaHHdctA vLPwmmifbmcUXhfgvCBpXXaHHdctA = IIbtkfUeSCOHLSLTZjyRIQuepbHM(P_1, P_2, P_3);
			if (NrmrJxIGPOCWXexSxVquAePylGAcb[P_0])
			{
				if (vLPwmmifbmcUXhfgvCBpXXaHHdctA == VLPwmmifbmcUXhfgvCBpXXaHHdctA.Up || vLPwmmifbmcUXhfgvCBpXXaHHdctA == VLPwmmifbmcUXhfgvCBpXXaHHdctA.DownAndUp)
				{
					NrmrJxIGPOCWXexSxVquAePylGAcb[P_0] = false;
				}
			}
			else if (vLPwmmifbmcUXhfgvCBpXXaHHdctA == VLPwmmifbmcUXhfgvCBpXXaHHdctA.Down)
			{
				NrmrJxIGPOCWXexSxVquAePylGAcb[P_0] = true;
			}
			if (vLPwmmifbmcUXhfgvCBpXXaHHdctA == VLPwmmifbmcUXhfgvCBpXXaHHdctA.Down || vLPwmmifbmcUXhfgvCBpXXaHHdctA == VLPwmmifbmcUXhfgvCBpXXaHHdctA.DownAndUp)
			{
				vzqymTYckzbmNkuSZceXMlyRGdid[P_0] = true;
			}
		}

		private static VLPwmmifbmcUXhfgvCBpXXaHHdctA IIbtkfUeSCOHLSLTZjyRIQuepbHM(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return VLPwmmifbmcUXhfgvCBpXXaHHdctA.DownAndUp;
				}
				return VLPwmmifbmcUXhfgvCBpXXaHHdctA.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return VLPwmmifbmcUXhfgvCBpXXaHHdctA.Up;
			}
			return VLPwmmifbmcUXhfgvCBpXXaHHdctA.None;
		}

		private static bool CNxkMcbRplKntdwRLCOyHkbTHVpk(IntPtr P_0)
		{
			if (wfRybNWHWOpoyMQsxzdwHdiNgarj.iLXaeXGyHXCDmRKGFpkiFCCZzcHSA(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!wfRybNWHWOpoyMQsxzdwHdiNgarj.JTDTUlEUlsTDgTbUSbFbSoIcDPqz(P_0, out var wtheLCHlqxIfJcckbPJWrMXUecAfc))
			{
				return false;
			}
			if (!wfRybNWHWOpoyMQsxzdwHdiNgarj.ZIcSLJufeSekWAevnLkxoilsiPrPA(out var wtheLCHlqxIfJcckbPJWrMXUecAfc2))
			{
				return false;
			}
			if (!wfRybNWHWOpoyMQsxzdwHdiNgarj.CGjenjabkFDyRDMjfYhxzvvBuuCVA(P_0, out var thaEHJHRuxNOscsdomkrNbcSSKpJ))
			{
				return false;
			}
			int num = wtheLCHlqxIfJcckbPJWrMXUecAfc2.HuFDcoyKPPHeqFtDhgNFAZOEzmPaA - wtheLCHlqxIfJcckbPJWrMXUecAfc.HuFDcoyKPPHeqFtDhgNFAZOEzmPaA;
			int num2 = wtheLCHlqxIfJcckbPJWrMXUecAfc2.uFLzIDgjZrqhsKLeXYXndpaKYLJF - wtheLCHlqxIfJcckbPJWrMXUecAfc.uFLzIDgjZrqhsKLeXYXndpaKYLJF;
			if (num >= 0 && num2 >= 0 && num <= thaEHJHRuxNOscsdomkrNbcSSKpJ.ftpoSbQshMEemaStAGEKlbOAAggo && num2 <= thaEHJHRuxNOscsdomkrNbcSSKpJ.yCLhmtADZSecryQComCMjCgxVxcQ)
			{
				return false;
			}
			if (!wfRybNWHWOpoyMQsxzdwHdiNgarj.aJPyRYisTtYIPjmetXEgUDZagxuH(P_0, out var thaEHJHRuxNOscsdomkrNbcSSKpJ2))
			{
				return false;
			}
			if (wtheLCHlqxIfJcckbPJWrMXUecAfc2.HuFDcoyKPPHeqFtDhgNFAZOEzmPaA >= thaEHJHRuxNOscsdomkrNbcSSKpJ2.UIYrOlfEavmdmxGxrKuTKyAcMufg && wtheLCHlqxIfJcckbPJWrMXUecAfc2.HuFDcoyKPPHeqFtDhgNFAZOEzmPaA <= thaEHJHRuxNOscsdomkrNbcSSKpJ2.ftpoSbQshMEemaStAGEKlbOAAggo && wtheLCHlqxIfJcckbPJWrMXUecAfc2.uFLzIDgjZrqhsKLeXYXndpaKYLJF >= thaEHJHRuxNOscsdomkrNbcSSKpJ2.CpxntVmwqxXPPWRJMPcFcexjBIEG)
			{
				return wtheLCHlqxIfJcckbPJWrMXUecAfc2.uFLzIDgjZrqhsKLeXYXndpaKYLJF <= thaEHJHRuxNOscsdomkrNbcSSKpJ2.yCLhmtADZSecryQComCMjCgxVxcQ;
			}
			return false;
		}
	}

	private class TkGFrJJkYHhlbjKjAgXMWiNWtUsJB
	{
		private bool xteqcfufVnHMiAAuANofknTHUnSL;

		private bool vwfhAzMybfFBVIHneXUwFDhtPXdU;

		private bool ZNkHzcQjySJVlYpXrtbKfexhnAfi;

		private int kDheIUWDpAdTGfcvnkeCfjaOdPFXA = 10;

		private readonly float VqSUxNGYDofkhCNxheMtqMJKiSEZ;

		private double vBAQHPETVvkFgoHKbzFiAyxYgWqC;

		public bool IHhdWuCFjqutcmDwvNOXlWXtAeHVA
		{
			get
			{
				return xteqcfufVnHMiAAuANofknTHUnSL;
			}
			set
			{
				if (flag != xteqcfufVnHMiAAuANofknTHUnSL)
				{
					nKMgBMaNbKiElKsMyyMVcmZUEECsA(true);
				}
			}
		}

		public bool DNIiWWFJjZbDAApoGqISJjzLDtbl => vwfhAzMybfFBVIHneXUwFDhtPXdU;

		public bool DYkaUQmuEWQXKiiFRxlOAUDnTFND
		{
			get
			{
				return ZNkHzcQjySJVlYpXrtbKfexhnAfi;
			}
			set
			{
				if (ZNkHzcQjySJVlYpXrtbKfexhnAfi != flag)
				{
					ZNkHzcQjySJVlYpXrtbKfexhnAfi = flag;
					nKMgBMaNbKiElKsMyyMVcmZUEECsA(true);
				}
			}
		}

		public int kUFeNBdxuWbqaDpzXtmjtuiAeUjf => kDheIUWDpAdTGfcvnkeCfjaOdPFXA;

		public TkGFrJJkYHhlbjKjAgXMWiNWtUsJB(bool P_0, float P_1)
		{
			xteqcfufVnHMiAAuANofknTHUnSL = P_0;
			VqSUxNGYDofkhCNxheMtqMJKiSEZ = P_1;
			nKMgBMaNbKiElKsMyyMVcmZUEECsA(false);
		}

		public void HPpYtUMNEEdpndSkccLSLoLnrXYOA()
		{
			if (xteqcfufVnHMiAAuANofknTHUnSL && !(ReInput.realTime < vBAQHPETVvkFgoHKbzFiAyxYgWqC))
			{
				nKMgBMaNbKiElKsMyyMVcmZUEECsA(true);
			}
		}

		private void nKMgBMaNbKiElKsMyyMVcmZUEECsA(bool P_0)
		{
			if (ZNkHzcQjySJVlYpXrtbKfexhnAfi)
			{
				wfRybNWHWOpoyMQsxzdwHdiNgarj.nhpbxNDKtncgQDyQapsXadfongHD(112u, 0u, ref kDheIUWDpAdTGfcvnkeCfjaOdPFXA, 0u);
			}
			vwfhAzMybfFBVIHneXUwFDhtPXdU = wfRybNWHWOpoyMQsxzdwHdiNgarj.CoQNiNJmurxksRgofwmCczerfpem(OZbSvqUUHiSzSuQfJGOouxVsZnLE.EJzvuZEadAdybFZxoLtxVdiugMpY) > 0;
			if (P_0)
			{
				vBAQHPETVvkFgoHKbzFiAyxYgWqC = ReInput.realTime + (double)VqSUxNGYDofkhCNxheMtqMJKiSEZ;
			}
		}
	}

	private const int sjrZReRspResJdBBvTiPkPgmtDJe = 5;

	private const int olHBSuHJBNfNMxpxINmMxNoHHVxtA = 4;

	private readonly SpinLock DROUIWdJTjXiJiYxBLyrQflogBg = new SpinLock();

	private UpdateLoopDataSet<GSrdGmXaQQcGHJGFTdadpwsiahdK> fNNhbaXdijBbTnlFLlSORGQWfaqR;

	private HardwareControllerMap_Game nJzyZhxQnDDmkYmeGxrjLdfCHVsDA;

	private TkGFrJJkYHhlbjKjAgXMWiNWtUsJB WkxiMwAXOtbRohFzONEENPAzgKYkA;

	private bool VEzaXlTFSoiCiQxKqkmEIXnCINwJ;

	private int yvZAoLgXshFsStoAuIDbRQSYmOqe;

	private bool vZLCwwFQQLaookDyPKQizdmbeCJzA;

	private const bool CmGsmHztSvJfKsEexhELHfLwNiWWA = true;

	private const float JdTFpgbrpgHqcOwQOANARYbLOYyi = 2f;

	private bool ZjkCdoJnaLOgxIEPLesNUmVUNAxMA;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return vZLCwwFQQLaookDyPKQizdmbeCJzA;
		}
		set
		{
			if (vZLCwwFQQLaookDyPKQizdmbeCJzA != value)
			{
				vZLCwwFQQLaookDyPKQizdmbeCJzA = value;
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
			if (nJzyZhxQnDDmkYmeGxrjLdfCHVsDA == null)
			{
				nJzyZhxQnDDmkYmeGxrjLdfCHVsDA = XDPChAIdnaVKwkmVAIXUCLIKvbGf();
			}
			return nJzyZhxQnDDmkYmeGxrjLdfCHVsDA;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!vZLCwwFQQLaookDyPKQizdmbeCJzA)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public NCZNhrCupoGuOroTBBBCFKccmmyk(UpdateLoopSetting P_0)
	{
		eDJdyXFBoeKKECsAVVInwNbHoitjb();
		WkxiMwAXOtbRohFzONEENPAzgKYkA = new TkGFrJJkYHhlbjKjAgXMWiNWtUsJB(true, 2f);
		fNNhbaXdijBbTnlFLlSORGQWfaqR = new UpdateLoopDataSet<GSrdGmXaQQcGHJGFTdadpwsiahdK>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				fNNhbaXdijBbTnlFLlSORGQWfaqR[i] = new GSrdGmXaQQcGHJGFTdadpwsiahdK(WkxiMwAXOtbRohFzONEENPAzgKYkA, list[i]);
			}
		}
		VEzaXlTFSoiCiQxKqkmEIXnCINwJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += OovwroNwqGgGCbSpdHNcrVOoIHWI;
		ReInput.ApplicationPauseChangedEvent += mUkxIyWZeKRLAIulspopDMvbnYif;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += PhnbDNNdOUnnEoIcfNQbSAXkESJW;
		ReInput.TimeScalePauseChangedEvent += vUtJIVZkmYFSnKTywUBTSJHJASKx;
		ReInput.UpdateEndedEvent += mmIlayeGZrrjoyVnLuoCQmPJzFwh;
	}

	public void NPBgMecRhGuglPCWNIxHfJdJcdMTb(UpdateLoopType P_0)
	{
		fNNhbaXdijBbTnlFLlSORGQWfaqR.SetUpdateLoop(P_0);
		WkxiMwAXOtbRohFzONEENPAzgKYkA.HPpYtUMNEEdpndSkccLSLoLnrXYOA();
		VEzaXlTFSoiCiQxKqkmEIXnCINwJ = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void dYghGIJjhTMXEJfohLKDImUxAMvS(bURwuaJfGEQlKxePMfQYBYUKpoef P_0)
	{
		if (!VEzaXlTFSoiCiQxKqkmEIXnCINwJ)
		{
			return;
		}
		using (DROUIWdJTjXiJiYxBLyrQflogBg.Lock())
		{
			int count = fNNhbaXdijBbTnlFLlSORGQWfaqR.Count;
			for (int i = 0; i < count; i++)
			{
				fNNhbaXdijBbTnlFLlSORGQWfaqR[i].xJxzXbePbMiCCfiHNNrBcfkVykcK(P_0);
			}
		}
	}

	public void VfxcTYQfeqQCUnKLJgiAEvoyXrCo(bool P_0)
	{
		SZDcnbYMTNqZavFYZCJXDhhMSKvOA();
	}

	public void HeihVcCliymHoCXLpIxAUTyuFDsN(bool P_0)
	{
		if (eDJdyXFBoeKKECsAVVInwNbHoitjb() < 0)
		{
			SZDcnbYMTNqZavFYZCJXDhhMSKvOA();
		}
	}

	private int eDJdyXFBoeKKECsAVVInwNbHoitjb()
	{
		int num = yvZAoLgXshFsStoAuIDbRQSYmOqe;
		if (aVNwfEKFFkuytdgRDywStztpwdQi.LxVPcIDTXqaLyaVLfhPzuuSiFkKr(AiPfHfNfUBEMxcJwfjJwINhIhBdV.Mouse, out var num2))
		{
			yvZAoLgXshFsStoAuIDbRQSYmOqe = num2;
		}
		else
		{
			yvZAoLgXshFsStoAuIDbRQSYmOqe = ((wfRybNWHWOpoyMQsxzdwHdiNgarj.CoQNiNJmurxksRgofwmCczerfpem(OZbSvqUUHiSzSuQfJGOouxVsZnLE.JImXUOldfuoqwxUTOnkANULRCsVX) != 0) ? 1 : 0);
		}
		return yvZAoLgXshFsStoAuIDbRQSYmOqe - num;
	}

	private void OovwroNwqGgGCbSpdHNcrVOoIHWI(bool P_0)
	{
		VEzaXlTFSoiCiQxKqkmEIXnCINwJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !VEzaXlTFSoiCiQxKqkmEIXnCINwJ)
		{
			SZDcnbYMTNqZavFYZCJXDhhMSKvOA();
		}
	}

	private void mUkxIyWZeKRLAIulspopDMvbnYif(bool P_0)
	{
		VEzaXlTFSoiCiQxKqkmEIXnCINwJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!VEzaXlTFSoiCiQxKqkmEIXnCINwJ)
		{
			SZDcnbYMTNqZavFYZCJXDhhMSKvOA();
		}
	}

	private void PhnbDNNdOUnnEoIcfNQbSAXkESJW(bool P_0)
	{
	}

	private void vUtJIVZkmYFSnKTywUBTSJHJASKx(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		VEzaXlTFSoiCiQxKqkmEIXnCINwJ = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (DROUIWdJTjXiJiYxBLyrQflogBg.Lock())
		{
			fNNhbaXdijBbTnlFLlSORGQWfaqR[fNNhbaXdijBbTnlFLlSORGQWfaqR.fixedUpdateSetIndex].ovwJUuOFKcRjARQfjlUaiECZeuVJ();
		}
	}

	private void mmIlayeGZrrjoyVnLuoCQmPJzFwh(UpdateLoopType P_0)
	{
		using (DROUIWdJTjXiJiYxBLyrQflogBg.Lock())
		{
			fNNhbaXdijBbTnlFLlSORGQWfaqR.Get(P_0).CSLBoCsDYHGJCbqgTDRTGwXFWsgDA();
		}
	}

	private void SZDcnbYMTNqZavFYZCJXDhhMSKvOA()
	{
		using (DROUIWdJTjXiJiYxBLyrQflogBg.Lock())
		{
			int count = fNNhbaXdijBbTnlFLlSORGQWfaqR.Count;
			for (int i = 0; i < count; i++)
			{
				fNNhbaXdijBbTnlFLlSORGQWfaqR[i].vUliIbdadGpbHgogHxYEqFhIWqDv();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		fNNhbaXdijBbTnlFLlSORGQWfaqR.Current.gJcPuFUrAAVpPcIphmQDJEZNqHIh(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		SZDcnbYMTNqZavFYZCJXDhhMSKvOA();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game XDPChAIdnaVKwkmVAIXUCLIKvbGf()
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
		wBnsfXZtEYmikOsvwpRIxtpzZclE(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ogSeziwLUkbVVChCCpgsArmtPbJLA()
	{
		try
		{
			wBnsfXZtEYmikOsvwpRIxtpzZclE(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void wBnsfXZtEYmikOsvwpRIxtpzZclE(bool P_0)
	{
		if (!ZjkCdoJnaLOgxIEPLesNUmVUNAxMA)
		{
			ReInput.ApplicationFocusChangedEvent -= OovwroNwqGgGCbSpdHNcrVOoIHWI;
			ReInput.ApplicationPauseChangedEvent -= mUkxIyWZeKRLAIulspopDMvbnYif;
			ReInput.EditorPauseChangedEvent -= PhnbDNNdOUnnEoIcfNQbSAXkESJW;
			ReInput.TimeScalePauseChangedEvent -= vUtJIVZkmYFSnKTywUBTSJHJASKx;
			ReInput.UpdateEndedEvent -= mmIlayeGZrrjoyVnLuoCQmPJzFwh;
			if (P_0 && vZLCwwFQQLaookDyPKQizdmbeCJzA)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			ZjkCdoJnaLOgxIEPLesNUmVUNAxMA = true;
		}
	}
}
