using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class qFNgDRrnPTMkkavmrIgfBeDFETAv
{
	private class hsLRYZHvNMdsAUrePmSTjMFskfHj
	{
		private ButtonStateFlags sMyBROKWPRHiPFlmSePhkNJpkAJU;

		private ButtonStateFlags fVHBdyacHaEJNXdageMuAXGGwUtX;

		private ButtonStateFlags xatXOWbDKbcymlrqAOmmgFVcHNJk;

		private ButtonStateFlags lYXaYAFnGezPokHayCVPDIPfLBls;

		private uint NeMHHfEYtAlTDgGHVYfPjZjPhaGg;

		private bool EUTwsjfqWwMiYRAGNHSdBZJdofKJA;

		private bool pAHIHAElKYRPHvyBMgIlihYxuneCb;

		private bool aBKahvIlxCXgouUCDKLvMHpblMbw;

		private WUHurmJAWFcLcGfYqOLliBIxfqzbA LeZiMwehrPLRJpguHbfyPiHhQalH;

		public bool TkmMxYpjvRCYkeOHivwyrWKrHJPu => EUTwsjfqWwMiYRAGNHSdBZJdofKJA;

		public bool GiBXapEhpPBodIbavgwDzozHrEEl
		{
			get
			{
				return pAHIHAElKYRPHvyBMgIlihYxuneCb;
			}
			set
			{
				pAHIHAElKYRPHvyBMgIlihYxuneCb = flag;
			}
		}

		public ButtonStateFlags nrNcspYUBPfaFbFaWUmQRbVfBeaBA(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (sMyBROKWPRHiPFlmSePhkNJpkAJU & ButtonStateFlags.On) != 0;
				flag2 = (fVHBdyacHaEJNXdageMuAXGGwUtX & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!pAHIHAElKYRPHvyBMgIlihYxuneCb) ? sMyBROKWPRHiPFlmSePhkNJpkAJU : ButtonStateFlags.Off);
			}
			else
			{
				flag = (xatXOWbDKbcymlrqAOmmgFVcHNJk & ButtonStateFlags.On) != 0;
				flag2 = (lYXaYAFnGezPokHayCVPDIPfLBls & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!pAHIHAElKYRPHvyBMgIlihYxuneCb) ? xatXOWbDKbcymlrqAOmmgFVcHNJk : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (pAHIHAElKYRPHvyBMgIlihYxuneCb)
				{
					if (flag2 && !aBKahvIlxCXgouUCDKLvMHpblMbw && LeZiMwehrPLRJpguHbfyPiHhQalH.wXGyLKxbaAgMtaRNDnQlqOTXiRAeA)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (aBKahvIlxCXgouUCDKLvMHpblMbw && LeZiMwehrPLRJpguHbfyPiHhQalH.wXGyLKxbaAgMtaRNDnQlqOTXiRAeA)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !pAHIHAElKYRPHvyBMgIlihYxuneCb && !aBKahvIlxCXgouUCDKLvMHpblMbw)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void iBTQiCLCdtrGINrdcPjZKsDBprTD()
		{
			fVHBdyacHaEJNXdageMuAXGGwUtX = sMyBROKWPRHiPFlmSePhkNJpkAJU;
			lYXaYAFnGezPokHayCVPDIPfLBls = xatXOWbDKbcymlrqAOmmgFVcHNJk;
			aBKahvIlxCXgouUCDKLvMHpblMbw = pAHIHAElKYRPHvyBMgIlihYxuneCb;
			sMyBROKWPRHiPFlmSePhkNJpkAJU = ButtonStateFlags.Off;
			xatXOWbDKbcymlrqAOmmgFVcHNJk = ButtonStateFlags.Off;
		}

		public void cWMZGZSPNFbqsAAIQFjwJJbitNIK(uint P_0)
		{
			if (NeMHHfEYtAlTDgGHVYfPjZjPhaGg < P_0 - 1)
			{
				EUTwsjfqWwMiYRAGNHSdBZJdofKJA = false;
			}
		}

		public void WPUyMbOruEKUVtDUiiqtWPKOarqGA(bool P_0)
		{
			XxaCwoWgUdFPEwqIgHHxWdxdWmnK((P_0 ? sMyBROKWPRHiPFlmSePhkNJpkAJU : xatXOWbDKbcymlrqAOmmgFVcHNJk) | ButtonStateFlags.On, P_0);
		}

		public void XxaCwoWgUdFPEwqIgHHxWdxdWmnK(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				sMyBROKWPRHiPFlmSePhkNJpkAJU = P_0;
			}
			else
			{
				xatXOWbDKbcymlrqAOmmgFVcHNJk = P_0;
			}
			NeMHHfEYtAlTDgGHVYfPjZjPhaGg = ReInput.currentFrame;
			if (!EUTwsjfqWwMiYRAGNHSdBZJdofKJA)
			{
				EUTwsjfqWwMiYRAGNHSdBZJdofKJA = true;
			}
		}

		public void sHGxwDtRgxeGPLLoiyHojDwzFrhx(ref WUHurmJAWFcLcGfYqOLliBIxfqzbA P_0)
		{
			LeZiMwehrPLRJpguHbfyPiHhQalH = P_0;
			pAHIHAElKYRPHvyBMgIlihYxuneCb = P_0.tPUCuutcqHBoOHChWCLykdSNCmwGA;
			aBKahvIlxCXgouUCDKLvMHpblMbw = P_0.tPUCuutcqHBoOHChWCLykdSNCmwGA;
		}

		public void wXcKsPWxYWExisFAXmlxyAOduUfe()
		{
			sMyBROKWPRHiPFlmSePhkNJpkAJU = ButtonStateFlags.Off;
			fVHBdyacHaEJNXdageMuAXGGwUtX = ButtonStateFlags.Off;
			xatXOWbDKbcymlrqAOmmgFVcHNJk = ButtonStateFlags.Off;
			lYXaYAFnGezPokHayCVPDIPfLBls = ButtonStateFlags.Off;
			NeMHHfEYtAlTDgGHVYfPjZjPhaGg = 0u;
			EUTwsjfqWwMiYRAGNHSdBZJdofKJA = false;
			pAHIHAElKYRPHvyBMgIlihYxuneCb = false;
			aBKahvIlxCXgouUCDKLvMHpblMbw = false;
		}
	}

	public struct WUHurmJAWFcLcGfYqOLliBIxfqzbA
	{
		public bool wXGyLKxbaAgMtaRNDnQlqOTXiRAeA;

		public bool tPUCuutcqHBoOHChWCLykdSNCmwGA;

		public static WUHurmJAWFcLcGfYqOLliBIxfqzbA BUxUmULGfUyLnforhBjrslpgGUJC => default(WUHurmJAWFcLcGfYqOLliBIxfqzbA);
	}

	[Serializable]
	private sealed class aXZmApLUnFyWQldDNRDzHqsvRibg
	{
		public static readonly aXZmApLUnFyWQldDNRDzHqsvRibg _003C_003E9 = new aXZmApLUnFyWQldDNRDzHqsvRibg();

		public static Func<hsLRYZHvNMdsAUrePmSTjMFskfHj> _003C_003E9__22_0;

		internal qFNgDRrnPTMkkavmrIgfBeDFETAv iGvudoIPgzpneyUIOoGppmmNyveL()
		{
			return new qFNgDRrnPTMkkavmrIgfBeDFETAv();
		}

		internal void SYvzJLfvYHGNMyAIBoutYrNCBccb(qFNgDRrnPTMkkavmrIgfBeDFETAv P_0)
		{
			P_0.pkeJocEHwPeHGmXoDCQAeuJjIaAL();
		}

		internal hsLRYZHvNMdsAUrePmSTjMFskfHj DwXrtsusITAXuTnqhQMtKJleqZBn()
		{
			return new hsLRYZHvNMdsAUrePmSTjMFskfHj();
		}
	}

	private const int TsByHkRfjwvPPkQZQIuALQbtbTuj = 20;

	private const int wmaCIkchyCJcvNcrWQMWCfcCRWjN = 10;

	private static ObjectPool<qFNgDRrnPTMkkavmrIgfBeDFETAv> XAKUhdqEXfVGErepmeKULmsUbJiEA;

	private static qFNgDRrnPTMkkavmrIgfBeDFETAv[] DTqXylzzIRWmyfelZZQjggfIfWDS;

	private static int QbKIKNeWzUEFABUoqdpdGedIHqOpB;

	public int esBFoiPpCLPZXMltChYVyjhOFdiI;

	private UpdateLoopDataSet<hsLRYZHvNMdsAUrePmSTjMFskfHj> ZvpWErzUGUJUoELEEfdrlaAglraq;

	public bool DNtuQqRbKMSUhNaZnGUCNnvWFFQjA
	{
		get
		{
			int count = ZvpWErzUGUJUoELEEfdrlaAglraq.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZvpWErzUGUJUoELEEfdrlaAglraq[i].TkmMxYpjvRCYkeOHivwyrWKrHJPu)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool MyIZVYTmyodvNZERGEqohVHhEkOs
	{
		get
		{
			return ZvpWErzUGUJUoELEEfdrlaAglraq.Current.GiBXapEhpPBodIbavgwDzozHrEEl;
		}
		set
		{
			ZvpWErzUGUJUoELEEfdrlaAglraq.Current.GiBXapEhpPBodIbavgwDzozHrEEl = flag;
		}
	}

	static qFNgDRrnPTMkkavmrIgfBeDFETAv()
	{
		XAKUhdqEXfVGErepmeKULmsUbJiEA = new ObjectPool<qFNgDRrnPTMkkavmrIgfBeDFETAv>(20, aXZmApLUnFyWQldDNRDzHqsvRibg._003C_003E9.iGvudoIPgzpneyUIOoGppmmNyveL, aXZmApLUnFyWQldDNRDzHqsvRibg._003C_003E9.SYvzJLfvYHGNMyAIBoutYrNCBccb);
		DTqXylzzIRWmyfelZZQjggfIfWDS = new qFNgDRrnPTMkkavmrIgfBeDFETAv[20];
	}

	public static void cJgFKmUqixrPxDvxevQaYldWsjtD()
	{
		QbKIKNeWzUEFABUoqdpdGedIHqOpB = 0;
		Array.Clear(DTqXylzzIRWmyfelZZQjggfIfWDS, 0, DTqXylzzIRWmyfelZZQjggfIfWDS.Length);
		XAKUhdqEXfVGErepmeKULmsUbJiEA.Clear();
	}

	public static qFNgDRrnPTMkkavmrIgfBeDFETAv PaIcNCEzwSbNPYsnjMfNFgwwfJynA(int P_0)
	{
		for (int i = 0; i < QbKIKNeWzUEFABUoqdpdGedIHqOpB; i++)
		{
			if (DTqXylzzIRWmyfelZZQjggfIfWDS[i] != null && DTqXylzzIRWmyfelZZQjggfIfWDS[i].esBFoiPpCLPZXMltChYVyjhOFdiI == P_0)
			{
				return DTqXylzzIRWmyfelZZQjggfIfWDS[i];
			}
		}
		return null;
	}

	public static qFNgDRrnPTMkkavmrIgfBeDFETAv jMGCLfspLbgwqGFqqaWdFfVsXnTr(int P_0, WUHurmJAWFcLcGfYqOLliBIxfqzbA P_1)
	{
		qFNgDRrnPTMkkavmrIgfBeDFETAv qFNgDRrnPTMkkavmrIgfBeDFETAv2 = PaIcNCEzwSbNPYsnjMfNFgwwfJynA(P_0);
		if (qFNgDRrnPTMkkavmrIgfBeDFETAv2 != null)
		{
			return qFNgDRrnPTMkkavmrIgfBeDFETAv2;
		}
		qFNgDRrnPTMkkavmrIgfBeDFETAv2 = XAKUhdqEXfVGErepmeKULmsUbJiEA.Get();
		qFNgDRrnPTMkkavmrIgfBeDFETAv2.hpwcrnfEiNjdOCFDJxjBLEAZhRFW(P_0);
		qFNgDRrnPTMkkavmrIgfBeDFETAv2.BKwAirbzETcAAyoMondDCYjOdqkf(ref P_1);
		qFNgDRrnPTMkkavmrIgfBeDFETAv2.ZvpWErzUGUJUoELEEfdrlaAglraq.SetUpdateLoop(ReInput.currentUpdateLoop);
		CZHcckyemoGmHieHMQGsBNGVqopz(qFNgDRrnPTMkkavmrIgfBeDFETAv2);
		return qFNgDRrnPTMkkavmrIgfBeDFETAv2;
	}

	public static void bJxLFzLpNIidRtiKQjxKpCWjlQod(UpdateLoopType P_0)
	{
		for (int i = 0; i < QbKIKNeWzUEFABUoqdpdGedIHqOpB; i++)
		{
			if (DTqXylzzIRWmyfelZZQjggfIfWDS[i] != null)
			{
				DTqXylzzIRWmyfelZZQjggfIfWDS[i].qZVaRaqcEAhQOEPMIqcwFVDGFmsz(P_0);
			}
		}
	}

	public static void jpAsTVmMfDpHvDpJDuqDQyBqFFvr(UpdateLoopType P_0, uint P_1)
	{
		for (int num = QbKIKNeWzUEFABUoqdpdGedIHqOpB - 1; num >= 0; num--)
		{
			if (DTqXylzzIRWmyfelZZQjggfIfWDS[num] == null)
			{
				if (num == QbKIKNeWzUEFABUoqdpdGedIHqOpB - 1)
				{
					QbKIKNeWzUEFABUoqdpdGedIHqOpB--;
				}
			}
			else
			{
				DTqXylzzIRWmyfelZZQjggfIfWDS[num].AqIyAqvoTGfBOkdobcojKXOognWi(P_1);
				if (!DTqXylzzIRWmyfelZZQjggfIfWDS[num].DNtuQqRbKMSUhNaZnGUCNnvWFFQjA)
				{
					TDhaDeIelBeNznOtPthFrgeZhhye(num);
				}
			}
		}
	}

	private static void CZHcckyemoGmHieHMQGsBNGVqopz(qFNgDRrnPTMkkavmrIgfBeDFETAv P_0)
	{
		int num = xgLccEkNtLjnRlbztAKUBtwfcnqpB();
		if (num < 0)
		{
			if (QbKIKNeWzUEFABUoqdpdGedIHqOpB == DTqXylzzIRWmyfelZZQjggfIfWDS.Length)
			{
				qFNgDRrnPTMkkavmrIgfBeDFETAv[] dTqXylzzIRWmyfelZZQjggfIfWDS = DTqXylzzIRWmyfelZZQjggfIfWDS;
				DTqXylzzIRWmyfelZZQjggfIfWDS = new qFNgDRrnPTMkkavmrIgfBeDFETAv[DTqXylzzIRWmyfelZZQjggfIfWDS.Length + 10];
				Array.Copy(dTqXylzzIRWmyfelZZQjggfIfWDS, DTqXylzzIRWmyfelZZQjggfIfWDS, dTqXylzzIRWmyfelZZQjggfIfWDS.Length);
			}
			num = QbKIKNeWzUEFABUoqdpdGedIHqOpB;
			QbKIKNeWzUEFABUoqdpdGedIHqOpB++;
		}
		DTqXylzzIRWmyfelZZQjggfIfWDS[num] = P_0;
	}

	private static void TDhaDeIelBeNznOtPthFrgeZhhye(int P_0)
	{
		if (P_0 >= 0 && P_0 < QbKIKNeWzUEFABUoqdpdGedIHqOpB)
		{
			qFNgDRrnPTMkkavmrIgfBeDFETAv qFNgDRrnPTMkkavmrIgfBeDFETAv2 = DTqXylzzIRWmyfelZZQjggfIfWDS[P_0];
			if (qFNgDRrnPTMkkavmrIgfBeDFETAv2 != null)
			{
				XAKUhdqEXfVGErepmeKULmsUbJiEA.Return(qFNgDRrnPTMkkavmrIgfBeDFETAv2);
				DTqXylzzIRWmyfelZZQjggfIfWDS[P_0] = null;
			}
			if (P_0 == QbKIKNeWzUEFABUoqdpdGedIHqOpB - 1)
			{
				QbKIKNeWzUEFABUoqdpdGedIHqOpB--;
			}
		}
	}

	private static int xgLccEkNtLjnRlbztAKUBtwfcnqpB()
	{
		for (int i = 0; i < QbKIKNeWzUEFABUoqdpdGedIHqOpB; i++)
		{
			if (DTqXylzzIRWmyfelZZQjggfIfWDS[i] == null)
			{
				return i;
			}
		}
		if (QbKIKNeWzUEFABUoqdpdGedIHqOpB >= DTqXylzzIRWmyfelZZQjggfIfWDS.Length)
		{
			return -1;
		}
		int qbKIKNeWzUEFABUoqdpdGedIHqOpB = QbKIKNeWzUEFABUoqdpdGedIHqOpB;
		QbKIKNeWzUEFABUoqdpdGedIHqOpB++;
		return qbKIKNeWzUEFABUoqdpdGedIHqOpB;
	}

	public ButtonStateFlags FVjAxchnFYwMYuxIVvqkbzNCaHRn(bool P_0)
	{
		return ZvpWErzUGUJUoELEEfdrlaAglraq.Current.nrNcspYUBPfaFbFaWUmQRbVfBeaBA(P_0);
	}

	public qFNgDRrnPTMkkavmrIgfBeDFETAv()
	{
		ZvpWErzUGUJUoELEEfdrlaAglraq = new UpdateLoopDataSet<hsLRYZHvNMdsAUrePmSTjMFskfHj>(ReInput.UserData.ConfigVars.updateLoop, aXZmApLUnFyWQldDNRDzHqsvRibg._003C_003E9.DwXrtsusITAXuTnqhQMtKJleqZBn);
		pkeJocEHwPeHGmXoDCQAeuJjIaAL();
	}

	public void qZVaRaqcEAhQOEPMIqcwFVDGFmsz(UpdateLoopType P_0)
	{
		ZvpWErzUGUJUoELEEfdrlaAglraq.SetUpdateLoop(P_0);
		ZvpWErzUGUJUoELEEfdrlaAglraq.Current.iBTQiCLCdtrGINrdcPjZKsDBprTD();
	}

	public void AqIyAqvoTGfBOkdobcojKXOognWi(uint P_0)
	{
		ZvpWErzUGUJUoELEEfdrlaAglraq.Current.cWMZGZSPNFbqsAAIQFjwJJbitNIK(P_0);
	}

	public void exRQOJMJCRmmhyMYfFaIvwulCeQJ(UpdateLoopType P_0, bool P_1)
	{
		ZvpWErzUGUJUoELEEfdrlaAglraq.Current.WPUyMbOruEKUVtDUiiqtWPKOarqGA(P_1);
	}

	public void lfKimNUJuYcKGCLemsfAxPNWOXgp(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		ZvpWErzUGUJUoELEEfdrlaAglraq.Current.XxaCwoWgUdFPEwqIgHHxWdxdWmnK(P_1, P_2);
	}

	private void BKwAirbzETcAAyoMondDCYjOdqkf(ref WUHurmJAWFcLcGfYqOLliBIxfqzbA P_0)
	{
		int count = ZvpWErzUGUJUoELEEfdrlaAglraq.Count;
		for (int i = 0; i < count; i++)
		{
			ZvpWErzUGUJUoELEEfdrlaAglraq[i].sHGxwDtRgxeGPLLoiyHojDwzFrhx(ref P_0);
		}
	}

	private void hpwcrnfEiNjdOCFDJxjBLEAZhRFW(int P_0)
	{
		esBFoiPpCLPZXMltChYVyjhOFdiI = P_0;
	}

	private void pkeJocEHwPeHGmXoDCQAeuJjIaAL()
	{
		esBFoiPpCLPZXMltChYVyjhOFdiI = -1;
		int count = ZvpWErzUGUJUoELEEfdrlaAglraq.Count;
		for (int i = 0; i < count; i++)
		{
			ZvpWErzUGUJUoELEEfdrlaAglraq[i].wXcKsPWxYWExisFAXmlxyAOduUfe();
		}
	}
}
