using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class eKRRFmBsqycdoBxbIwmnkNPvqmFI
{
	public class PNqCBKmnyNXSeaKUrenpSTbbefDk
	{
		public readonly Action<InputActionEventData> RxNAhpafSaWvHGrUKMWPzWloBEkyA;

		public readonly UpdateLoopType vQBMlmHRolKNVvnevkkuHTRWHNES;

		public readonly InputActionEventType rAyfvriakKSQMKIgvIvWlTzbWEiBA;

		public readonly int IJdOHJhXwEpKPrfqdqQpnnygFlXn;

		public readonly bool NSXDhAGiHZMgAUIBWpgCCTMvCDrpA;

		public float[] FoNBpDGdICNJCHpaAldjFpJmDDbo;

		public PNqCBKmnyNXSeaKUrenpSTbbefDk(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			vQBMlmHRolKNVvnevkkuHTRWHNES = P_1;
			rAyfvriakKSQMKIgvIvWlTzbWEiBA = P_2;
			IJdOHJhXwEpKPrfqdqQpnnygFlXn = P_3;
			RxNAhpafSaWvHGrUKMWPzWloBEkyA = P_0;
			axVCLuLhrrDcjFlkDzshFsXAWzfn(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				NSXDhAGiHZMgAUIBWpgCCTMvCDrpA = true;
				break;
			}
		}

		public bool FcTAvtldpKPnlOeIGGNceVITgeEE(int P_0, out float P_1)
		{
			if (FoNBpDGdICNJCHpaAldjFpJmDDbo == null || FoNBpDGdICNJCHpaAldjFpJmDDbo.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = FoNBpDGdICNJCHpaAldjFpJmDDbo[P_0];
			return true;
		}

		private void axVCLuLhrrDcjFlkDzshFsXAWzfn(object[] P_0)
		{
			switch (rAyfvriakKSQMKIgvIvWlTzbWEiBA)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + rAyfvriakKSQMKIgvIvWlTzbWEiBA.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				FoNBpDGdICNJCHpaAldjFpJmDDbo = new float[2];
				if (P_0[0] is float)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + rAyfvriakKSQMKIgvIvWlTzbWEiBA.ToString() + "\". Argument 0: time [float]");
					}
					FoNBpDGdICNJCHpaAldjFpJmDDbo[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + rAyfvriakKSQMKIgvIvWlTzbWEiBA.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + rAyfvriakKSQMKIgvIvWlTzbWEiBA.ToString() + "\". Requires 1 argument: time [float]");
				}
				FoNBpDGdICNJCHpaAldjFpJmDDbo = new float[1];
				if (P_0[0] is float)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + rAyfvriakKSQMKIgvIvWlTzbWEiBA.ToString() + "\". Argument 0: time [float]");
			case InputActionEventType.ButtonDoublePressed:
			case InputActionEventType.ButtonJustDoublePressed:
			case InputActionEventType.NegativeButtonDoublePressed:
			case InputActionEventType.NegativeButtonJustDoublePressed:
			case InputActionEventType.ButtonDoublePressJustReleased:
			case InputActionEventType.NegativeButtonDoublePressJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					break;
				}
				FoNBpDGdICNJCHpaAldjFpJmDDbo = new float[1];
				if (P_0[0] is float)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					FoNBpDGdICNJCHpaAldjFpJmDDbo[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + rAyfvriakKSQMKIgvIvWlTzbWEiBA.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class AFRwddYNUbvZdXJfoAUgimfGrkgR
	{
		public static readonly AFRwddYNUbvZdXJfoAUgimfGrkgR _003C_003E9 = new AFRwddYNUbvZdXJfoAUgimfGrkgR();

		public static Func<AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>> _003C_003E9__8_0;

		internal AList<PNqCBKmnyNXSeaKUrenpSTbbefDk> JYoQfaWGorkGcMrnjauEBxQORtjG()
		{
			return new AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>();
		}
	}

	private sealed class VLwxyGkTwsDcqgXWQaRssJmEKzSD
	{
		public Action<InputActionEventData> SpvbsfOQCkQKaLeMQhyFEvqpziyl;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> vCDFTrBencTKUObwaNMqbVvjHLeV;

		internal bool rwpEdfHeAlRHYbgFIlKAoViuYxNhB(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			return P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == SpvbsfOQCkQKaLeMQhyFEvqpziyl;
		}
	}

	private sealed class kbxdchhrVpvGXovEtgOxORaQoIfEb
	{
		public Action<InputActionEventData> JxClEVNYhkKpUKEYRpMVcOrBeMw;

		public int TYuldBiyoJmFQnLMYCSCCagrdPVrA;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> pihzPIaOVCBkDEPaJgbmIZHjtgBHb;

		internal bool YtEsotTVlZLaKwojfSrGAKWYTKkW(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == JxClEVNYhkKpUKEYRpMVcOrBeMw)
			{
				return P_0.IJdOHJhXwEpKPrfqdqQpnnygFlXn == TYuldBiyoJmFQnLMYCSCCagrdPVrA;
			}
			return false;
		}
	}

	private sealed class PDIQMNjFneaIycZoFCidDzOoOHemA
	{
		public Action<InputActionEventData> fXXQlzsCnBziAgOGuQXOtCgQIJaq;

		public UpdateLoopType hZfEUMHBxYmoXmDPZzvhnpwJkchMA;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> oUKkujSjaKceaTbQCgxJfWNaylVcA;

		internal bool RFnSNIXuKXnHirhLahuHgHzGqVhQA(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == fXXQlzsCnBziAgOGuQXOtCgQIJaq)
			{
				return P_0.vQBMlmHRolKNVvnevkkuHTRWHNES == hZfEUMHBxYmoXmDPZzvhnpwJkchMA;
			}
			return false;
		}
	}

	private sealed class TvyVJuLEVpCsapNDChCzzGNEeMVi
	{
		public Action<InputActionEventData> ElUlgqVHKSeEAgbVCnLCEPEexbmOB;

		public InputActionEventType uMyFTcFuDmiQOjPCvzcElRFXDGLLA;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> tsIIBVJPTKVFoDfKXjKEcNEQIuQvA;

		internal bool dfJEwwGWuARRamuQsLvBFlIjlQCo(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == ElUlgqVHKSeEAgbVCnLCEPEexbmOB)
			{
				return P_0.rAyfvriakKSQMKIgvIvWlTzbWEiBA == uMyFTcFuDmiQOjPCvzcElRFXDGLLA;
			}
			return false;
		}
	}

	private sealed class FUrMOKVifJYgYiCpVRDCmJNNTRlK
	{
		public Action<InputActionEventData> JXERAxWoDhLsIQrkaGnytKuODwaL;

		public UpdateLoopType kMIyLqfEDleOziTTmNIKCRDHejNDb;

		public int kFTZzdNWGmneCTqPUJTMdHbkTSIP;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> uxOPMWDfBqFlIGaUwPrHkoIxiuoXA;

		internal bool caKvUlkoqaNZORyaDtuTJRoULyrP(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == JXERAxWoDhLsIQrkaGnytKuODwaL && P_0.vQBMlmHRolKNVvnevkkuHTRWHNES == kMIyLqfEDleOziTTmNIKCRDHejNDb)
			{
				return P_0.IJdOHJhXwEpKPrfqdqQpnnygFlXn == kFTZzdNWGmneCTqPUJTMdHbkTSIP;
			}
			return false;
		}
	}

	private sealed class MhsoIixzGsgKNoEQdjGuJOowWXeu
	{
		public Action<InputActionEventData> EMqLaafmCjYKXZCcevesDSmxIEKe;

		public UpdateLoopType NcemeTdUJcHswozbzsRyxfuJhXJk;

		public int pkYGAkAaAAXmywkOGaRPLPDQiSMwA;

		public InputActionEventType ETvLQXeZVmSRotYvTClkLLQMjvMc;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> cmYIkbRIlXgZmosoyQzEluiraYcf;

		internal bool IEdOVGELWrsNHWbxWQRGsPOlhTmB(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == EMqLaafmCjYKXZCcevesDSmxIEKe && P_0.vQBMlmHRolKNVvnevkkuHTRWHNES == NcemeTdUJcHswozbzsRyxfuJhXJk && P_0.IJdOHJhXwEpKPrfqdqQpnnygFlXn == pkYGAkAaAAXmywkOGaRPLPDQiSMwA)
			{
				return P_0.rAyfvriakKSQMKIgvIvWlTzbWEiBA == ETvLQXeZVmSRotYvTClkLLQMjvMc;
			}
			return false;
		}
	}

	private sealed class zfEroNpElMCVRxAhXUiHVEojWmuj
	{
		public Action<InputActionEventData> ASysDvGtpDifpQFTHBFzicglJEhe;

		public UpdateLoopType tVNeFbHySLpisLgWhPtfePJfzegPA;

		public InputActionEventType EXGpUfsMVJqRFQFxckbdcyTSqbUO;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> FpfQtyLCVgrwGMEwtMEqevIElgdT;

		internal bool tqUQJpUfaesWMhGNQbSEgNyegTdAA(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == ASysDvGtpDifpQFTHBFzicglJEhe && P_0.vQBMlmHRolKNVvnevkkuHTRWHNES == tVNeFbHySLpisLgWhPtfePJfzegPA)
			{
				return P_0.rAyfvriakKSQMKIgvIvWlTzbWEiBA == EXGpUfsMVJqRFQFxckbdcyTSqbUO;
			}
			return false;
		}
	}

	private sealed class SmJXMDdmMKPxEDCEPeKhNJNWZIDM
	{
		public Action<InputActionEventData> pIrRGyPcdGoPShDkxipodjQlTUQS;

		public int PmyokoirClSTOdBUfyQwpgDmeNOo;

		public InputActionEventType CTRDSbgJOhFfwBgAHlVdOjQlyfsK;

		public Predicate<PNqCBKmnyNXSeaKUrenpSTbbefDk> JUBoXMbcvXlumjIneHdEKfXLQrnpA;

		internal bool VXvpYzTHEQTsjIMmmyTZysBhHNUy(PNqCBKmnyNXSeaKUrenpSTbbefDk P_0)
		{
			if (P_0.RxNAhpafSaWvHGrUKMWPzWloBEkyA == pIrRGyPcdGoPShDkxipodjQlTUQS && P_0.IJdOHJhXwEpKPrfqdqQpnnygFlXn == PmyokoirClSTOdBUfyQwpgDmeNOo)
			{
				return P_0.rAyfvriakKSQMKIgvIvWlTzbWEiBA == CTRDSbgJOhFfwBgAHlVdOjQlyfsK;
			}
			return false;
		}
	}

	private static PNqCBKmnyNXSeaKUrenpSTbbefDk[] RLpkSwWZCidNqyEBbsXGDhdWLUWi;

	private bool WnYDNUvCUAVpEPGatierdCZEoebbA;

	private AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] UXHcjvcHcRViWGeQciQcojnREAaab;

	private int[] KcMYGenWfWSIDiBQkzVvZMkSdXdbA;

	private int uWbcIGByrRPOBMsdoAqiKQqZeQUOA;

	public int VBCGNLzqPUvJpBcZqJWEjsyHmNlT;

	static eKRRFmBsqycdoBxbIwmnkNPvqmFI()
	{
		RLpkSwWZCidNqyEBbsXGDhdWLUWi = new PNqCBKmnyNXSeaKUrenpSTbbefDk[100];
	}

	private void uRwzluWcuLhalhALyGlycDKbZmyoA()
	{
		if (!WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			IList<InputAction> list = ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.GpGjcLJqOjgpHpNgraZJfJTtxhEz;
			int num = list?.Count ?? 0;
			UXHcjvcHcRViWGeQciQcojnREAaab = new AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[num + 1];
			KcMYGenWfWSIDiBQkzVvZMkSdXdbA = new int[ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.HpPlLEMphRQiePRaLceXxlEXrinm + 1];
			ArrayTools.Populate(UXHcjvcHcRViWGeQciQcojnREAaab, 0, UXHcjvcHcRViWGeQciQcojnREAaab.Length, AFRwddYNUbvZdXJfoAUgimfGrkgR._003C_003E9.JYoQfaWGorkGcMrnjauEBxQORtjG);
			for (int i = 0; i < num; i++)
			{
				KcMYGenWfWSIDiBQkzVvZMkSdXdbA[list[i].id] = i;
			}
			uWbcIGByrRPOBMsdoAqiKQqZeQUOA = num;
			WnYDNUvCUAVpEPGatierdCZEoebbA = true;
		}
	}

	public void YVUdcmFPuhgrUtPvvxgathnNMrugb(KvDFldULABgCdeUydTfHpQtIJWLLA P_0, UpdateLoopType P_1)
	{
		AList<PNqCBKmnyNXSeaKUrenpSTbbefDk> aList = UXHcjvcHcRViWGeQciQcojnREAaab[KcMYGenWfWSIDiBQkzVvZMkSdXdbA[P_0.JdGqeYyILodPpdfHuITJZurFyzEE]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = UXHcjvcHcRViWGeQciQcojnREAaab[uWbcIGByrRPOBMsdoAqiKQqZeQUOA];
			}
			int count = aList._count;
			if (RLpkSwWZCidNqyEBbsXGDhdWLUWi.Length < count)
			{
				RLpkSwWZCidNqyEBbsXGDhdWLUWi = new PNqCBKmnyNXSeaKUrenpSTbbefDk[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, RLpkSwWZCidNqyEBbsXGDhdWLUWi, count);
			}
			for (int j = 0; j < count; j++)
			{
				PNqCBKmnyNXSeaKUrenpSTbbefDk pNqCBKmnyNXSeaKUrenpSTbbefDk = RLpkSwWZCidNqyEBbsXGDhdWLUWi[j];
				if (pNqCBKmnyNXSeaKUrenpSTbbefDk == null || (!P_0.fEtNQSTyeJaSDFhZeGEhfbtrvRfiA && !pNqCBKmnyNXSeaKUrenpSTbbefDk.NSXDhAGiHZMgAUIBWpgCCTMvCDrpA) || pNqCBKmnyNXSeaKUrenpSTbbefDk.vQBMlmHRolKNVvnevkkuHTRWHNES != P_1 || (pNqCBKmnyNXSeaKUrenpSTbbefDk.IJdOHJhXwEpKPrfqdqQpnnygFlXn >= 0 && pNqCBKmnyNXSeaKUrenpSTbbefDk.IJdOHJhXwEpKPrfqdqQpnnygFlXn != P_0.JdGqeYyILodPpdfHuITJZurFyzEE))
				{
					continue;
				}
				bool flag = false;
				switch (pNqCBKmnyNXSeaKUrenpSTbbefDk.rAyfvriakKSQMKIgvIvWlTzbWEiBA)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.jonBMeBgjqmpKxavKozLAPygznlzb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.jonBMeBgjqmpKxavKozLAPygznlzb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num5);
					if (P_0.QoYnapdumcutNIkvTnBhtWWxoDqI(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num11))
					{
						continue;
					}
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(1, out var num12);
					if (P_0.NzQrTYSnDcGRqbNdniVOSQqJoqAG(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.bongdQqmupfQSHXCTmfmQNCkYumU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.qAzFnnISixTyoWOKoTqCFzESwanA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.AHAfXYajBSoiRkPUeJcdIbrWdSzT())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.QhIFFGmODJeZADKlMzrwrvViMkFFA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num9);
					if (P_0.TWgLCmJHQFLpcxWpHeDkkWKfOdtj(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num6);
					if (P_0.bYYGrmiMaVaqWzWEkxGjsYiEgnNS(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num4))
					{
						continue;
					}
					if (P_0.KfKWyEBfMWRJtXfkuyNnrMnWwSgd(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.tHJnnjrHfPYknbNDKOKeNLhbhpQu())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.OsyHPaidTpYBYijoDgHmuEybJsBh())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num15))
					{
						continue;
					}
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(1, out var num16);
					if (P_0.vkBYJdlMzighvOYTkGrsYDUmsodE(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.RvdqpLgLtagjFduEnuOEFivMTDAm())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.TYRlaLcnebEhljBSxanWDgYblAxxA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.VKhtDAKdScfYZJwREarPYfPRnkrA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.leJpQSBpsXypUKkUlFCVJOOJkVZW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.vrSuqTsbLGDvCIrahfArgEVLgbLiA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.jJOOiwSjatfNcHHSlzJnnXBSKHmJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.pXjVqdAzojvTbKvxXpykfDkEPpQj())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.pXjVqdAzojvTbKvxXpykfDkEPpQj())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num3);
					if (P_0.zEbnlZdaiDyetgJiLTFBfyCksxhK(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num))
					{
						continue;
					}
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(1, out var num2);
					if (P_0.jkHbbEpqSaAWWOfPzcBDKMxSWYOd(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.WPHBHjUnRAgFXAwQRWvlCCQRCpohA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.ccfbVnEYphSAKDcOvANEplTREnGG())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.lHHuINDJBTdpehTarhalhiDIerGx())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.cZnPzBTkHgebnurRTrMvxFZoHRQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num14);
					if (P_0.xplklLjFBUdExfyeGIYreySaXLpwA(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num13);
					if (P_0.ZywGlizWJkjZOJCxihYfIdZPfKmM(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num10))
					{
						continue;
					}
					if (P_0.IUwmguQiJVJAbdBMtRmgmQtufkZN(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.QcKgRpnjObkdVpdAhACjXQCKkbT())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.KBxcgZydRgMdteooSrGuDoCtzlkw())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(0, out var num7))
					{
						continue;
					}
					pNqCBKmnyNXSeaKUrenpSTbbefDk.FcTAvtldpKPnlOeIGGNceVITgeEE(1, out var num8);
					if (P_0.jJneXQoPwtMJsElqheSfDuRYcmEWA(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.zLRaEWaNUNqANdVnZVCXenCmgBzG())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.jtWfJjCxRaLtWlmSjupulMQKlEFlA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.SwdFNDSojvQADMMjyGKRyavbMKvL())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.OHEgpxkImiJCqolaVZUxvFDoULlV())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.icISRcgmlpGTPhvBVPBbXqHOwYNCA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.irkDtFaWCXlYTvtuvGUVfEsfFYIm())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.vDILMvZTSozNrqNZOlPRyQknMOMj()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.vDILMvZTSozNrqNZOlPRyQknMOMj()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.cSmTNGoDybvqVlYYDlRblGGxcFDQ()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.cSmTNGoDybvqVlYYDlRblGGxcFDQ()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.vDILMvZTSozNrqNZOlPRyQknMOMj()) || !MathTools.ApproximatelyZero(P_0.JrvFLXhmewpPhJaTZAZzRipCiguO()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.cSmTNGoDybvqVlYYDlRblGGxcFDQ()) || !MathTools.ApproximatelyZero(P_0.vHGqiugXaRiLTkkhTgchZCUUTHhC()))
					{
						flag = true;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				try
				{
					if (flag)
					{
						InputActionEventData obj = P_0.xzSGNmaaeRYUUBIxdYHWSRaFkGwR(P_1);
						obj.eventType = pNqCBKmnyNXSeaKUrenpSTbbefDk.rAyfvriakKSQMKIgvIvWlTzbWEiBA;
						pNqCBKmnyNXSeaKUrenpSTbbefDk.RxNAhpafSaWvHGrUKMWPzWloBEkyA(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void bRibQrgNavKeHjaJKaaHhMRRghMT(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			uRwzluWcuLhalhALyGlycDKbZmyoA();
		}
		PNqCBKmnyNXSeaKUrenpSTbbefDk item;
		try
		{
			if (P_3 > ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.HpPlLEMphRQiePRaLceXxlEXrinm)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new PNqCBKmnyNXSeaKUrenpSTbbefDk(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			UXHcjvcHcRViWGeQciQcojnREAaab[uWbcIGByrRPOBMsdoAqiKQqZeQUOA].Add(item);
		}
		else
		{
			UXHcjvcHcRViWGeQciQcojnREAaab[KcMYGenWfWSIDiBQkzVvZMkSdXdbA[P_3]].Add(item);
		}
		xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
	}

	public void VGWHTLvlubTIkSczclwfdrKcLqwh(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			uRwzluWcuLhalhALyGlycDKbZmyoA();
		}
		PNqCBKmnyNXSeaKUrenpSTbbefDk item;
		try
		{
			item = new PNqCBKmnyNXSeaKUrenpSTbbefDk(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		UXHcjvcHcRViWGeQciQcojnREAaab[uWbcIGByrRPOBMsdoAqiKQqZeQUOA].Add(item);
		xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
	}

	public void GiWbeRAgDipaLrUWIYIpPCoUCAzI(Action<InputActionEventData> P_0)
	{
		VLwxyGkTwsDcqgXWQaRssJmEKzSD vLwxyGkTwsDcqgXWQaRssJmEKzSD = new VLwxyGkTwsDcqgXWQaRssJmEKzSD();
		vLwxyGkTwsDcqgXWQaRssJmEKzSD.SpvbsfOQCkQKaLeMQhyFEvqpziyl = P_0;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(vLwxyGkTwsDcqgXWQaRssJmEKzSD.rwpEdfHeAlRHYbgFIlKAoViuYxNhB);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void UwxTiQONVJqVgFuOgVSrkfGocWXhA(Action<InputActionEventData> P_0, int P_1)
	{
		kbxdchhrVpvGXovEtgOxORaQoIfEb kbxdchhrVpvGXovEtgOxORaQoIfEb2 = new kbxdchhrVpvGXovEtgOxORaQoIfEb();
		kbxdchhrVpvGXovEtgOxORaQoIfEb2.JxClEVNYhkKpUKEYRpMVcOrBeMw = P_0;
		kbxdchhrVpvGXovEtgOxORaQoIfEb2.TYuldBiyoJmFQnLMYCSCCagrdPVrA = P_1;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA && kbxdchhrVpvGXovEtgOxORaQoIfEb2.TYuldBiyoJmFQnLMYCSCCagrdPVrA <= ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.HpPlLEMphRQiePRaLceXxlEXrinm)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(kbxdchhrVpvGXovEtgOxORaQoIfEb2.YtEsotTVlZLaKwojfSrGAKWYTKkW);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void YDjwhBzPqLFIhsjQakBkXVetLYxF(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		PDIQMNjFneaIycZoFCidDzOoOHemA pDIQMNjFneaIycZoFCidDzOoOHemA = new PDIQMNjFneaIycZoFCidDzOoOHemA();
		pDIQMNjFneaIycZoFCidDzOoOHemA.fXXQlzsCnBziAgOGuQXOtCgQIJaq = P_0;
		pDIQMNjFneaIycZoFCidDzOoOHemA.hZfEUMHBxYmoXmDPZzvhnpwJkchMA = P_1;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(pDIQMNjFneaIycZoFCidDzOoOHemA.RFnSNIXuKXnHirhLahuHgHzGqVhQA);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void RdDfDdcxQOMcKOtVwbGELGrNpPEiA(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		TvyVJuLEVpCsapNDChCzzGNEeMVi tvyVJuLEVpCsapNDChCzzGNEeMVi = new TvyVJuLEVpCsapNDChCzzGNEeMVi();
		tvyVJuLEVpCsapNDChCzzGNEeMVi.ElUlgqVHKSeEAgbVCnLCEPEexbmOB = P_0;
		tvyVJuLEVpCsapNDChCzzGNEeMVi.uMyFTcFuDmiQOjPCvzcElRFXDGLLA = P_1;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(tvyVJuLEVpCsapNDChCzzGNEeMVi.dfJEwwGWuARRamuQsLvBFlIjlQCo);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void XvPtXYnFKYGHBjUbbHmxuBBQgFjc(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		FUrMOKVifJYgYiCpVRDCmJNNTRlK fUrMOKVifJYgYiCpVRDCmJNNTRlK = new FUrMOKVifJYgYiCpVRDCmJNNTRlK();
		fUrMOKVifJYgYiCpVRDCmJNNTRlK.JXERAxWoDhLsIQrkaGnytKuODwaL = P_0;
		fUrMOKVifJYgYiCpVRDCmJNNTRlK.kMIyLqfEDleOziTTmNIKCRDHejNDb = P_1;
		fUrMOKVifJYgYiCpVRDCmJNNTRlK.kFTZzdNWGmneCTqPUJTMdHbkTSIP = P_2;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA && fUrMOKVifJYgYiCpVRDCmJNNTRlK.kFTZzdNWGmneCTqPUJTMdHbkTSIP <= ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.HpPlLEMphRQiePRaLceXxlEXrinm)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(fUrMOKVifJYgYiCpVRDCmJNNTRlK.caKvUlkoqaNZORyaDtuTJRoULyrP);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void HddKxCnNCYKsGKOyMAHOKPUMFZwfA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		MhsoIixzGsgKNoEQdjGuJOowWXeu mhsoIixzGsgKNoEQdjGuJOowWXeu = new MhsoIixzGsgKNoEQdjGuJOowWXeu();
		mhsoIixzGsgKNoEQdjGuJOowWXeu.EMqLaafmCjYKXZCcevesDSmxIEKe = P_0;
		mhsoIixzGsgKNoEQdjGuJOowWXeu.NcemeTdUJcHswozbzsRyxfuJhXJk = P_1;
		mhsoIixzGsgKNoEQdjGuJOowWXeu.pkYGAkAaAAXmywkOGaRPLPDQiSMwA = P_3;
		mhsoIixzGsgKNoEQdjGuJOowWXeu.ETvLQXeZVmSRotYvTClkLLQMjvMc = P_2;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA && mhsoIixzGsgKNoEQdjGuJOowWXeu.pkYGAkAaAAXmywkOGaRPLPDQiSMwA <= ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.HpPlLEMphRQiePRaLceXxlEXrinm)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(mhsoIixzGsgKNoEQdjGuJOowWXeu.IEdOVGELWrsNHWbxWQRGsPOlhTmB);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void htLxiMKEctWkErqQfQAdIoUkSCPg(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		zfEroNpElMCVRxAhXUiHVEojWmuj zfEroNpElMCVRxAhXUiHVEojWmuj2 = new zfEroNpElMCVRxAhXUiHVEojWmuj();
		zfEroNpElMCVRxAhXUiHVEojWmuj2.ASysDvGtpDifpQFTHBFzicglJEhe = P_0;
		zfEroNpElMCVRxAhXUiHVEojWmuj2.tVNeFbHySLpisLgWhPtfePJfzegPA = P_1;
		zfEroNpElMCVRxAhXUiHVEojWmuj2.EXGpUfsMVJqRFQFxckbdcyTSqbUO = P_2;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(zfEroNpElMCVRxAhXUiHVEojWmuj2.tqUQJpUfaesWMhGNQbSEgNyegTdAA);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void xTcyvtWyFlKikmmCxzbPNAmUGQOFA(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		SmJXMDdmMKPxEDCEPeKhNJNWZIDM smJXMDdmMKPxEDCEPeKhNJNWZIDM = new SmJXMDdmMKPxEDCEPeKhNJNWZIDM();
		smJXMDdmMKPxEDCEPeKhNJNWZIDM.pIrRGyPcdGoPShDkxipodjQlTUQS = P_0;
		smJXMDdmMKPxEDCEPeKhNJNWZIDM.PmyokoirClSTOdBUfyQwpgDmeNOo = P_2;
		smJXMDdmMKPxEDCEPeKhNJNWZIDM.CTRDSbgJOhFfwBgAHlVdOjQlyfsK = P_1;
		if (WnYDNUvCUAVpEPGatierdCZEoebbA && smJXMDdmMKPxEDCEPeKhNJNWZIDM.PmyokoirClSTOdBUfyQwpgDmeNOo <= ReInput.AwFNwGchWvDBRvqVRzmYbEJcoaxe.HpPlLEMphRQiePRaLceXxlEXrinm)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].RemoveAll(smJXMDdmMKPxEDCEPeKhNJNWZIDM.VXvpYzTHEQTsjIMmmyTZysBhHNUy);
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	public void scScQNlpGWHleZvpbWFmSIqTjsIK()
	{
		if (WnYDNUvCUAVpEPGatierdCZEoebbA)
		{
			AList<PNqCBKmnyNXSeaKUrenpSTbbefDk>[] uXHcjvcHcRViWGeQciQcojnREAaab = UXHcjvcHcRViWGeQciQcojnREAaab;
			for (int i = 0; i < uXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
			{
				uXHcjvcHcRViWGeQciQcojnREAaab[i].Clear();
			}
			xXXarLEyyrEwMFgXvGBEgtpKsaXQ();
		}
	}

	private void xXXarLEyyrEwMFgXvGBEgtpKsaXQ()
	{
		int num = 0;
		for (int i = 0; i < UXHcjvcHcRViWGeQciQcojnREAaab.Length; i++)
		{
			num += UXHcjvcHcRViWGeQciQcojnREAaab[i]._count;
		}
		VBCGNLzqPUvJpBcZqJWEjsyHmNlT = num;
	}
}
