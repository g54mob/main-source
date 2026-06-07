using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class FEkVkkoNierUunlWUQcNWzWkNESt : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class wlQUWCKexwTWwnDVqlfOqBdPjWVR
	{
		private enum sduUepRiNtoJEpkMISFYrPTuGqYy
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int ehaMmISbNETabbvsUHywICCMQGJg = 120;

		private const int SlthWfDKSffUbljhAvOHfSWzFUSL = 2048;

		public readonly UpdateLoopType mzNEfaDRzdkvvsutbMHSikMgjRMHc;

		public uint YpYpmVCXqbhppdPNwBaMvMQQVvqb;

		public uint ZrvTsDsDLhHVjdxzzTYrDbAXuWaAA;

		public eLAaLuOmMZXossuCxkJsvCkJFVtN BnAxsFHTTyoxjLgcffpjtNYZHRNv;

		public float xVQxOuFzxjSvazPPujgbjQnfHfPL;

		public float fQyZiWgHzseROcOIQHhhtWjmBVYcb;

		public float fhgQVWMtCeesTfrEwFwTTpBBEWAe;

		public float unKBbWVyyZqPGiNnfPWKiNpOwggX;

		private bool[] fdhNpuByelfFiMAWBKcWUyPHvKLc;

		private bool[] fwWayiPbZAAhDeJQCYtnjGnLorrRA;

		private jwqADkfQfyNgASueUFJKzPWaFaer JdVnnwWbhrWvINvDdqBXTjUExqAi;

		private uint EqCZkaLatgcPWkvnrzRwTzvbbuIEb;

		private int TsqmyenvMYpIRywhaIPEysDoiWabA;

		private int KvdRPBRyIHJPpWnCHsryFkPOAeyc;

		private bool XaxznLSnDqZxCvmqkPXFrtRLVWAU;

		public wlQUWCKexwTWwnDVqlfOqBdPjWVR(jwqADkfQfyNgASueUFJKzPWaFaer P_0, UpdateLoopType P_1)
		{
			JdVnnwWbhrWvINvDdqBXTjUExqAi = P_0;
			mzNEfaDRzdkvvsutbMHSikMgjRMHc = P_1;
			fdhNpuByelfFiMAWBKcWUyPHvKLc = new bool[5];
			fwWayiPbZAAhDeJQCYtnjGnLorrRA = new bool[5];
		}

		public void JfzXMrOJfaAuPvWUQcDwCVAgMWNkA(EwOFaFOPgZbhcOkGdCIJXRKZxDtC P_0)
		{
			bjxqZhzRbEAhhPIuUKMArIqoUors bjxqZhzRbEAhhPIuUKMArIqoUors2 = P_0.MwXrFlbFMrHQjEluQAGsZJwdLUBFb;
			if (bjxqZhzRbEAhhPIuUKMArIqoUors2 != bjxqZhzRbEAhhPIuUKMArIqoUors.None)
			{
				if ((bjxqZhzRbEAhhPIuUKMArIqoUors2 & bjxqZhzRbEAhhPIuUKMArIqoUors.LeftButtonDown) != bjxqZhzRbEAhhPIuUKMArIqoUors.None || (bjxqZhzRbEAhhPIuUKMArIqoUors2 & bjxqZhzRbEAhhPIuUKMArIqoUors.RightButtonDown) != bjxqZhzRbEAhhPIuUKMArIqoUors.None)
				{
					IntPtr intPtr = FTdbbIUhAgYSHUHmiEJUirkRZXhf.NwoSuizDgFairJkCGeEaeWUEahWaB();
					if (FTdbbIUhAgYSHUHmiEJUirkRZXhf.DusapxwwStwmAFEWSdmyAkcNCjJcb() == intPtr && CMBmQqzNxOSwcywWkdmFXbrBMhFt(intPtr))
					{
						bjxqZhzRbEAhhPIuUKMArIqoUors2 &= ~bjxqZhzRbEAhhPIuUKMArIqoUors.LeftButtonDown;
						bjxqZhzRbEAhhPIuUKMArIqoUors2 &= ~bjxqZhzRbEAhhPIuUKMArIqoUors.RightButtonDown;
					}
				}
				int num = (int)bjxqZhzRbEAhhPIuUKMArIqoUors2;
				if (JdVnnwWbhrWvINvDdqBXTjUExqAi.daDdLNCjtYPwlkiSrOMQEWMQcpBCb && JdVnnwWbhrWvINvDdqBXTjUExqAi.uqoWAXkBAqnvQxyspcoxHobFjpCK)
				{
					vGDKwLSUatefXRsnmLbSVcVNGQnM(1, num, 1, 2);
					vGDKwLSUatefXRsnmLbSVcVNGQnM(0, num, 4, 8);
				}
				else
				{
					vGDKwLSUatefXRsnmLbSVcVNGQnM(0, num, 1, 2);
					vGDKwLSUatefXRsnmLbSVcVNGQnM(1, num, 4, 8);
				}
				vGDKwLSUatefXRsnmLbSVcVNGQnM(2, num, 16, 32);
				vGDKwLSUatefXRsnmLbSVcVNGQnM(3, num, 64, 128);
				vGDKwLSUatefXRsnmLbSVcVNGQnM(4, num, 256, 512);
			}
			YpYpmVCXqbhppdPNwBaMvMQQVvqb = P_0.aDfLmdwyjqdvbGCJrDKBcjSZaxbxA;
			ZrvTsDsDLhHVjdxzzTYrDbAXuWaAA = P_0.RfTKgILbyWNpZgMYAyFuBCvTeiAG;
			eLAaLuOmMZXossuCxkJsvCkJFVtN bnAxsFHTTyoxjLgcffpjtNYZHRNv = BnAxsFHTTyoxjLgcffpjtNYZHRNv;
			BnAxsFHTTyoxjLgcffpjtNYZHRNv = P_0.HUnNhPKwMEWsCYKHOjKmDNEILKz;
			if (BnAxsFHTTyoxjLgcffpjtNYZHRNv != bnAxsFHTTyoxjLgcffpjtNYZHRNv)
			{
				XaxznLSnDqZxCvmqkPXFrtRLVWAU = false;
			}
			if (BnAxsFHTTyoxjLgcffpjtNYZHRNv == eLAaLuOmMZXossuCxkJsvCkJFVtN.MoveRelative)
			{
				xVQxOuFzxjSvazPPujgbjQnfHfPL += (float)P_0.ikvYFvqBsURzKembIVBLAesgIdnc * 0.5f;
				fQyZiWgHzseROcOIQHhhtWjmBVYcb += (float)P_0.MHZnyfdNfRSvvySownHvPwulebOI * 0.5f * -1f;
			}
			else if ((BnAxsFHTTyoxjLgcffpjtNYZHRNv & eLAaLuOmMZXossuCxkJsvCkJFVtN.MoveAbsolute) != eLAaLuOmMZXossuCxkJsvCkJFVtN.MoveRelative)
			{
				bool num2 = (BnAxsFHTTyoxjLgcffpjtNYZHRNv & eLAaLuOmMZXossuCxkJsvCkJFVtN.VirtualDesktop) != 0;
				int num3 = FTdbbIUhAgYSHUHmiEJUirkRZXhf.jdCwmEEItDfPyFpYyVHZVordGlLgb(num2 ? FctNbXZaNPcyhHCDrwfgVeJXGxBEA.bVMciYJFBcdGepxCYaHWArpMnevQA : FctNbXZaNPcyhHCDrwfgVeJXGxBEA.ENAipQNFNbYbucVfFZCLebAommqF);
				int num4 = FTdbbIUhAgYSHUHmiEJUirkRZXhf.jdCwmEEItDfPyFpYyVHZVordGlLgb(num2 ? FctNbXZaNPcyhHCDrwfgVeJXGxBEA.GBXgGARszfkuLqvBjeovSfoSVwTQ : FctNbXZaNPcyhHCDrwfgVeJXGxBEA.cJgXUhrIZWSAIoSSYUwznlNfDFJf);
				int num5 = (int)((float)P_0.ikvYFvqBsURzKembIVBLAesgIdnc / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.MHZnyfdNfRSvvySownHvPwulebOI) / 65535f * (float)num4);
				if (!XaxznLSnDqZxCvmqkPXFrtRLVWAU)
				{
					TsqmyenvMYpIRywhaIPEysDoiWabA = num5;
					KvdRPBRyIHJPpWnCHsryFkPOAeyc = num6;
					XaxznLSnDqZxCvmqkPXFrtRLVWAU = true;
				}
				xVQxOuFzxjSvazPPujgbjQnfHfPL += num5 - TsqmyenvMYpIRywhaIPEysDoiWabA;
				fQyZiWgHzseROcOIQHhhtWjmBVYcb += num6 - KvdRPBRyIHJPpWnCHsryFkPOAeyc;
				TsqmyenvMYpIRywhaIPEysDoiWabA = num5;
				KvdRPBRyIHJPpWnCHsryFkPOAeyc = num6;
			}
			else
			{
				xVQxOuFzxjSvazPPujgbjQnfHfPL = P_0.ikvYFvqBsURzKembIVBLAesgIdnc;
				fQyZiWgHzseROcOIQHhhtWjmBVYcb = P_0.MHZnyfdNfRSvvySownHvPwulebOI;
			}
			if (P_0.EYTcfqzlcZliRmaIqDNEIAIfpsJC != 0)
			{
				int num7 = ((MathTools.Abs(P_0.EYTcfqzlcZliRmaIqDNEIAIfpsJC) < 120) ? MathTools.Sign(P_0.EYTcfqzlcZliRmaIqDNEIAIfpsJC) : (P_0.EYTcfqzlcZliRmaIqDNEIAIfpsJC / 120));
				if ((bjxqZhzRbEAhhPIuUKMArIqoUors2 & bjxqZhzRbEAhhPIuUKMArIqoUors.MouseWheel) != bjxqZhzRbEAhhPIuUKMArIqoUors.None)
				{
					fhgQVWMtCeesTfrEwFwTTpBBEWAe += num7;
				}
				else if ((bjxqZhzRbEAhhPIuUKMArIqoUors2 & (bjxqZhzRbEAhhPIuUKMArIqoUors)2048) != bjxqZhzRbEAhhPIuUKMArIqoUors.None)
				{
					unKBbWVyyZqPGiNnfPWKiNpOwggX += num7;
				}
			}
		}

		public void arozGfvRgLicoIVaUbhLHFoGQnoKB(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = xVQxOuFzxjSvazPPujgbjQnfHfPL;
			axisValues[1] = fQyZiWgHzseROcOIQHhhtWjmBVYcb;
			axisValues[2] = fhgQVWMtCeesTfrEwFwTTpBBEWAe;
			axisValues[3] = unKBbWVyyZqPGiNnfPWKiNpOwggX;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = fdhNpuByelfFiMAWBKcWUyPHvKLc[i] || fwWayiPbZAAhDeJQCYtnjGnLorrRA[i];
			}
			mQwVMFCPfaUeIkKgyufFZOFxLkKX();
		}

		public void fdgdVjoDRldOWTYacdFyyjuZUbDw()
		{
			mQwVMFCPfaUeIkKgyufFZOFxLkKX();
		}

		private void mQwVMFCPfaUeIkKgyufFZOFxLkKX()
		{
			if (EqCZkaLatgcPWkvnrzRwTzvbbuIEb != ReInput.absFrame)
			{
				BYxflaUDpajrvCeAaAOywVHzcLBn();
				EqCZkaLatgcPWkvnrzRwTzvbbuIEb = ReInput.absFrame;
			}
		}

		public void tfzRJEdpLyphLJpWsjGjrPvvhHtP()
		{
			xVQxOuFzxjSvazPPujgbjQnfHfPL = 0f;
			fQyZiWgHzseROcOIQHhhtWjmBVYcb = 0f;
			ZrvTsDsDLhHVjdxzzTYrDbAXuWaAA = 0u;
			BnAxsFHTTyoxjLgcffpjtNYZHRNv = eLAaLuOmMZXossuCxkJsvCkJFVtN.MoveRelative;
			fhgQVWMtCeesTfrEwFwTTpBBEWAe = 0f;
			unKBbWVyyZqPGiNnfPWKiNpOwggX = 0f;
			Array.Clear(fdhNpuByelfFiMAWBKcWUyPHvKLc, 0, 5);
			Array.Clear(fwWayiPbZAAhDeJQCYtnjGnLorrRA, 0, 5);
			XaxznLSnDqZxCvmqkPXFrtRLVWAU = false;
		}

		public void BYxflaUDpajrvCeAaAOywVHzcLBn()
		{
			xVQxOuFzxjSvazPPujgbjQnfHfPL = 0f;
			fQyZiWgHzseROcOIQHhhtWjmBVYcb = 0f;
			fhgQVWMtCeesTfrEwFwTTpBBEWAe = 0f;
			unKBbWVyyZqPGiNnfPWKiNpOwggX = 0f;
			Array.Clear(fwWayiPbZAAhDeJQCYtnjGnLorrRA, 0, 5);
		}

		private bool EZseEtCHfMNebpsisCYUAkPJSVnq(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1 && (P_0 & P_2) != P_2)
			{
				return true;
			}
			return false;
		}

		private sduUepRiNtoJEpkMISFYrPTuGqYy bXLdOBLVrCyNlGxLQKrGzhpDBIrKA(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return sduUepRiNtoJEpkMISFYrPTuGqYy.None;
				}
				return sduUepRiNtoJEpkMISFYrPTuGqYy.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return sduUepRiNtoJEpkMISFYrPTuGqYy.Up;
			}
			return sduUepRiNtoJEpkMISFYrPTuGqYy.None;
		}

		private void vGDKwLSUatefXRsnmLbSVcVNGQnM(int P_0, int P_1, int P_2, int P_3)
		{
			sduUepRiNtoJEpkMISFYrPTuGqYy sduUepRiNtoJEpkMISFYrPTuGqYy2 = bXLdOBLVrCyNlGxLQKrGzhpDBIrKA(P_1, P_2, P_3);
			if (fdhNpuByelfFiMAWBKcWUyPHvKLc[P_0])
			{
				if (sduUepRiNtoJEpkMISFYrPTuGqYy2 == sduUepRiNtoJEpkMISFYrPTuGqYy.Up)
				{
					fdhNpuByelfFiMAWBKcWUyPHvKLc[P_0] = false;
				}
			}
			else if (sduUepRiNtoJEpkMISFYrPTuGqYy2 == sduUepRiNtoJEpkMISFYrPTuGqYy.Down)
			{
				fdhNpuByelfFiMAWBKcWUyPHvKLc[P_0] = true;
			}
			if (sduUepRiNtoJEpkMISFYrPTuGqYy2 == sduUepRiNtoJEpkMISFYrPTuGqYy.Down)
			{
				fwWayiPbZAAhDeJQCYtnjGnLorrRA[P_0] = true;
			}
		}

		private static bool CMBmQqzNxOSwcywWkdmFXbrBMhFt(IntPtr P_0)
		{
			if (FTdbbIUhAgYSHUHmiEJUirkRZXhf.nQhCOTYIEvRXGhyZgtjCeirIibzj(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!FTdbbIUhAgYSHUHmiEJUirkRZXhf.twcdSxgcRlBMZgRoRfMnKTJiLKYGA(P_0, out var vngxFcEtcgLernSmRjFLWbynMHSQ2))
			{
				return false;
			}
			if (!FTdbbIUhAgYSHUHmiEJUirkRZXhf.AVVjthjFfIChXbQoFIlJtnksKixE(out var vngxFcEtcgLernSmRjFLWbynMHSQ3))
			{
				return false;
			}
			if (!FTdbbIUhAgYSHUHmiEJUirkRZXhf.tsEjuaHDfPQBSilFNpKxmTffVNHu(P_0, out var ohSxWWiKozRvNaYKgWPsnvMYgjO))
			{
				return false;
			}
			int num = vngxFcEtcgLernSmRjFLWbynMHSQ3.dhGToIYMsutuQaEQsoXEflsfQZjG - vngxFcEtcgLernSmRjFLWbynMHSQ2.dhGToIYMsutuQaEQsoXEflsfQZjG;
			int num2 = vngxFcEtcgLernSmRjFLWbynMHSQ3.tbVGfLnPIuyMRbfbwRLYBkjSlLPo - vngxFcEtcgLernSmRjFLWbynMHSQ2.tbVGfLnPIuyMRbfbwRLYBkjSlLPo;
			if (num >= 0 && num2 >= 0 && num <= ohSxWWiKozRvNaYKgWPsnvMYgjO.EvxkfZcWyqtowBcGKIjaaxeNwCDH && num2 <= ohSxWWiKozRvNaYKgWPsnvMYgjO.bMYXnrlosVavdFXiWbikasGduYVNc)
			{
				return false;
			}
			if (!FTdbbIUhAgYSHUHmiEJUirkRZXhf.JdkrHlPCRSoEtJNDlCOiPmZdfHUF(P_0, out var ohSxWWiKozRvNaYKgWPsnvMYgjO2))
			{
				return false;
			}
			if (vngxFcEtcgLernSmRjFLWbynMHSQ3.dhGToIYMsutuQaEQsoXEflsfQZjG >= ohSxWWiKozRvNaYKgWPsnvMYgjO2.OPYaDdkxIhcaWCNaJtgiclqLOzSqB && vngxFcEtcgLernSmRjFLWbynMHSQ3.dhGToIYMsutuQaEQsoXEflsfQZjG <= ohSxWWiKozRvNaYKgWPsnvMYgjO2.EvxkfZcWyqtowBcGKIjaaxeNwCDH && vngxFcEtcgLernSmRjFLWbynMHSQ3.tbVGfLnPIuyMRbfbwRLYBkjSlLPo >= ohSxWWiKozRvNaYKgWPsnvMYgjO2.vHnekAoXpDuBpacKkjCUCskLaBVCb)
			{
				return vngxFcEtcgLernSmRjFLWbynMHSQ3.tbVGfLnPIuyMRbfbwRLYBkjSlLPo <= ohSxWWiKozRvNaYKgWPsnvMYgjO2.bMYXnrlosVavdFXiWbikasGduYVNc;
			}
			return false;
		}
	}

	private class jwqADkfQfyNgASueUFJKzPWaFaer
	{
		private bool vymegQcUrAjdSgBoEehhARChDCQyB;

		private bool SwwFZADrpbHnybMgIJqmozoIPNCjB;

		private bool rfYORtAMxXkVXALbebgOmArOamoK;

		private int EgCtDniFnrCvUbgJcFZflCSGbpugA = 10;

		private readonly float plhtzDVYEnLyGJLEtUmqltupakzw;

		private double GwdHQTqYdhoyZgBCPziJuSBVchbR;

		public bool daDdLNCjtYPwlkiSrOMQEWMQcpBCb
		{
			get
			{
				return vymegQcUrAjdSgBoEehhARChDCQyB;
			}
			set
			{
				if (flag != vymegQcUrAjdSgBoEehhARChDCQyB)
				{
					EyDCZksbEgrwGlMQlIvkoIXMANdR(true);
				}
			}
		}

		public bool uqoWAXkBAqnvQxyspcoxHobFjpCK => SwwFZADrpbHnybMgIJqmozoIPNCjB;

		public bool GedWrJYycZBAikPAFHSmASuxbTdBb
		{
			get
			{
				return rfYORtAMxXkVXALbebgOmArOamoK;
			}
			set
			{
				if (rfYORtAMxXkVXALbebgOmArOamoK != flag)
				{
					rfYORtAMxXkVXALbebgOmArOamoK = flag;
					EyDCZksbEgrwGlMQlIvkoIXMANdR(true);
				}
			}
		}

		public int BqTWhXqOqiMfAMDlRyVGhkDkbMKU => EgCtDniFnrCvUbgJcFZflCSGbpugA;

		public jwqADkfQfyNgASueUFJKzPWaFaer(bool P_0, float P_1)
		{
			vymegQcUrAjdSgBoEehhARChDCQyB = P_0;
			plhtzDVYEnLyGJLEtUmqltupakzw = P_1;
			EyDCZksbEgrwGlMQlIvkoIXMANdR(false);
		}

		public void fumfMZmBSKzTTBtJyQdlfnlSSdCP()
		{
			if (vymegQcUrAjdSgBoEehhARChDCQyB && !(ReInput.realTime < GwdHQTqYdhoyZgBCPziJuSBVchbR))
			{
				EyDCZksbEgrwGlMQlIvkoIXMANdR(true);
			}
		}

		private void EyDCZksbEgrwGlMQlIvkoIXMANdR(bool P_0)
		{
			if (rfYORtAMxXkVXALbebgOmArOamoK)
			{
				FTdbbIUhAgYSHUHmiEJUirkRZXhf.htCNVrJrVaOuVTlhHxACMzATbuKy(112u, 0u, ref EgCtDniFnrCvUbgJcFZflCSGbpugA, 0u);
			}
			SwwFZADrpbHnybMgIJqmozoIPNCjB = FTdbbIUhAgYSHUHmiEJUirkRZXhf.jdCwmEEItDfPyFpYyVHZVordGlLgb(FctNbXZaNPcyhHCDrwfgVeJXGxBEA.lMcNffOfNvaHWSBCXOhpwQfshRHO) > 0;
			if (P_0)
			{
				GwdHQTqYdhoyZgBCPziJuSBVchbR = ReInput.realTime + (double)plhtzDVYEnLyGJLEtUmqltupakzw;
			}
		}
	}

	private const int CaDcFYaHarAnGczRjAjItckCLwjkA = 5;

	private const int rTmpOBDwwStBTsmDZdJWkQgSVYldA = 4;

	private readonly object rdygpwOMaKgOPuFIsXVmDZpTAcYw = new object();

	private UpdateLoopDataSet<wlQUWCKexwTWwnDVqlfOqBdPjWVR> gizZezCwOaALBlVinPsGGppGqbJt;

	private HardwareControllerMap_Game HOXNfVehCWHWLfdKFgVFOltjyVvmA;

	private jwqADkfQfyNgASueUFJKzPWaFaer BQHEJSIbfBlrCYaAcTVVlQNMVgpF;

	private bool tLoJCYNPsOByhViAzinLPitZeUwX;

	private int FsSFNjjhOxnOAlAGcqsfDvSOuENBA;

	private bool jGGmgeSynNsStOAAvXGIXnzjDOBz;

	private const bool jRDQoYwGgAtGSGUYIKMpjzxSEUyB = true;

	private const float eXMPUmpqJLXiCTEyRGRJlqwHcYTD = 2f;

	private bool MMGyHWXiPOFUFaIVSqnonEyHsIlAA;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return jGGmgeSynNsStOAAvXGIXnzjDOBz;
		}
		set
		{
			if (jGGmgeSynNsStOAAvXGIXnzjDOBz != value)
			{
				jGGmgeSynNsStOAAvXGIXnzjDOBz = value;
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
			if (HOXNfVehCWHWLfdKFgVFOltjyVvmA == null)
			{
				HOXNfVehCWHWLfdKFgVFOltjyVvmA = NgskpmeWpYWMIlYyKOjuWqvohnMH();
			}
			return HOXNfVehCWHWLfdKFgVFOltjyVvmA;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!jGGmgeSynNsStOAAvXGIXnzjDOBz)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public FEkVkkoNierUunlWUQcNWzWkNESt(UpdateLoopSetting P_0)
	{
		FiXfcgZFbFKkhUGQsWtBCPhdkNhr();
		BQHEJSIbfBlrCYaAcTVVlQNMVgpF = new jwqADkfQfyNgASueUFJKzPWaFaer(true, 2f);
		gizZezCwOaALBlVinPsGGppGqbJt = new UpdateLoopDataSet<wlQUWCKexwTWwnDVqlfOqBdPjWVR>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				gizZezCwOaALBlVinPsGGppGqbJt[i] = new wlQUWCKexwTWwnDVqlfOqBdPjWVR(BQHEJSIbfBlrCYaAcTVVlQNMVgpF, list[i]);
			}
		}
		tLoJCYNPsOByhViAzinLPitZeUwX = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += YROCSYFJloexkAYfAChYigbPmpTc;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += aZdBoZFLMxLjyiqRbKFwakmByXqSA;
		ReInput.TimeScalePauseChangedEvent += wJXBFdecVvmcnFeJaVqFikvfBpaYB;
		ReInput.UpdateEndedEvent += dSbwBqvgcnjzoiIkFfuFEXEHgrnmB;
	}

	public void EVcBKzkGRuuYdiQzwLSfbMMIVqZWB(UpdateLoopType P_0)
	{
		gizZezCwOaALBlVinPsGGppGqbJt.SetUpdateLoop(P_0);
		BQHEJSIbfBlrCYaAcTVVlQNMVgpF.fumfMZmBSKzTTBtJyQdlfnlSSdCP();
		tLoJCYNPsOByhViAzinLPitZeUwX = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void dwOwnFwPEAJjCkVSzMMJJlwLuoLKA(EwOFaFOPgZbhcOkGdCIJXRKZxDtC P_0)
	{
		if (!tLoJCYNPsOByhViAzinLPitZeUwX)
		{
			return;
		}
		lock (rdygpwOMaKgOPuFIsXVmDZpTAcYw)
		{
			int count = gizZezCwOaALBlVinPsGGppGqbJt.Count;
			for (int i = 0; i < count; i++)
			{
				gizZezCwOaALBlVinPsGGppGqbJt[i].JfzXMrOJfaAuPvWUQcDwCVAgMWNkA(P_0);
			}
		}
	}

	public void XrbeTdMbQJUJvZaGZwqRTvLNoUam(bool P_0)
	{
		nrFfWVVwHesCukiKDFXBBAbveEGCA();
	}

	public void zaLvKywoIpIbWvbhDSpncpjsOYPv(bool P_0)
	{
		if (FiXfcgZFbFKkhUGQsWtBCPhdkNhr() < 0)
		{
			nrFfWVVwHesCukiKDFXBBAbveEGCA();
		}
	}

	private int FiXfcgZFbFKkhUGQsWtBCPhdkNhr()
	{
		int fsSFNjjhOxnOAlAGcqsfDvSOuENBA = FsSFNjjhOxnOAlAGcqsfDvSOuENBA;
		if (PtZxJDakPjxrloDZyiNQFrvDzsve.vROsnIXqeeoCUOomBOuBQWADDgAT(HLIHggermciamhEKNxfavGKToBMk.Mouse, out var fsSFNjjhOxnOAlAGcqsfDvSOuENBA2))
		{
			FsSFNjjhOxnOAlAGcqsfDvSOuENBA = fsSFNjjhOxnOAlAGcqsfDvSOuENBA2;
		}
		else
		{
			FsSFNjjhOxnOAlAGcqsfDvSOuENBA = ((FTdbbIUhAgYSHUHmiEJUirkRZXhf.jdCwmEEItDfPyFpYyVHZVordGlLgb(FctNbXZaNPcyhHCDrwfgVeJXGxBEA.cBCvIUKuZStnOxLJkSMpUhBaugTD) != 0) ? 1 : 0);
		}
		return FsSFNjjhOxnOAlAGcqsfDvSOuENBA - fsSFNjjhOxnOAlAGcqsfDvSOuENBA;
	}

	private void YROCSYFJloexkAYfAChYigbPmpTc(bool P_0)
	{
		tLoJCYNPsOByhViAzinLPitZeUwX = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !tLoJCYNPsOByhViAzinLPitZeUwX)
		{
			nrFfWVVwHesCukiKDFXBBAbveEGCA();
		}
	}

	private void aZdBoZFLMxLjyiqRbKFwakmByXqSA(bool P_0)
	{
	}

	private void wJXBFdecVvmcnFeJaVqFikvfBpaYB(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		tLoJCYNPsOByhViAzinLPitZeUwX = ReInput.IsInputAllowed(ControllerType.Mouse);
		lock (rdygpwOMaKgOPuFIsXVmDZpTAcYw)
		{
			gizZezCwOaALBlVinPsGGppGqbJt[gizZezCwOaALBlVinPsGGppGqbJt.fixedUpdateSetIndex].BYxflaUDpajrvCeAaAOywVHzcLBn();
		}
	}

	private void dSbwBqvgcnjzoiIkFfuFEXEHgrnmB(UpdateLoopType P_0)
	{
		lock (rdygpwOMaKgOPuFIsXVmDZpTAcYw)
		{
			gizZezCwOaALBlVinPsGGppGqbJt.Get(P_0).fdgdVjoDRldOWTYacdFyyjuZUbDw();
		}
	}

	private void nrFfWVVwHesCukiKDFXBBAbveEGCA()
	{
		lock (rdygpwOMaKgOPuFIsXVmDZpTAcYw)
		{
			int count = gizZezCwOaALBlVinPsGGppGqbJt.Count;
			for (int i = 0; i < count; i++)
			{
				gizZezCwOaALBlVinPsGGppGqbJt[i].tfzRJEdpLyphLJpWsjGjrPvvhHtP();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		gizZezCwOaALBlVinPsGGppGqbJt.Current.arozGfvRgLicoIVaUbhLHFoGQnoKB(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		nrFfWVVwHesCukiKDFXBBAbveEGCA();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game NgskpmeWpYWMIlYyKOjuWqvohnMH()
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
		fhVLRcWlchykQFMTYFQMSjGIhGLJA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void dacMANYNkoPcBKSriaxNAAysxlxX()
	{
		try
		{
			fhVLRcWlchykQFMTYFQMSjGIhGLJA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void fhVLRcWlchykQFMTYFQMSjGIhGLJA(bool P_0)
	{
		if (!MMGyHWXiPOFUFaIVSqnonEyHsIlAA)
		{
			ReInput.ApplicationFocusChangedEvent -= YROCSYFJloexkAYfAChYigbPmpTc;
			ReInput.EditorPauseChangedEvent -= aZdBoZFLMxLjyiqRbKFwakmByXqSA;
			ReInput.TimeScalePauseChangedEvent -= wJXBFdecVvmcnFeJaVqFikvfBpaYB;
			ReInput.UpdateEndedEvent -= dSbwBqvgcnjzoiIkFfuFEXEHgrnmB;
			if (P_0 && jGGmgeSynNsStOAAvXGIXnzjDOBz)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			MMGyHWXiPOFUFaIVSqnonEyHsIlAA = true;
		}
	}
}
