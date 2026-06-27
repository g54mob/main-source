using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class QCMhwFAkemVHUWtsLnxYTCvaAOlv
{
	public class pExDtbvbiXceMDbRyEbWlvXmSOnPA
	{
		public readonly Action<InputActionEventData> jiEAwAmMnqAElwTuDRqqvROfobMD;

		public readonly UpdateLoopType REEGiPKAgjBkzgyxwRfLoGfZQpos;

		public readonly InputActionEventType BFrOROxbgOvlgRmzisYraGPcqrYL;

		public readonly int eXykOqgFwYGjbohviERCaKUpfDjYA;

		public readonly bool fDQEXzhPMLLlgLYTDlezoiwspBTC;

		public float[] pYQRQgBWIIWasOJfXZaAsOznabFn;

		public pExDtbvbiXceMDbRyEbWlvXmSOnPA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			REEGiPKAgjBkzgyxwRfLoGfZQpos = P_1;
			BFrOROxbgOvlgRmzisYraGPcqrYL = P_2;
			eXykOqgFwYGjbohviERCaKUpfDjYA = P_3;
			jiEAwAmMnqAElwTuDRqqvROfobMD = P_0;
			MpSqiXIPnfmFDqijGypGkVhFgBZq(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				fDQEXzhPMLLlgLYTDlezoiwspBTC = true;
				break;
			}
		}

		public bool tPAvhOojdUMwVVihLpToFdvIvWuM(int P_0, out float P_1)
		{
			if (pYQRQgBWIIWasOJfXZaAsOznabFn == null || pYQRQgBWIIWasOJfXZaAsOznabFn.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = pYQRQgBWIIWasOJfXZaAsOznabFn[P_0];
			return true;
		}

		private void MpSqiXIPnfmFDqijGypGkVhFgBZq(object[] P_0)
		{
			switch (BFrOROxbgOvlgRmzisYraGPcqrYL)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + BFrOROxbgOvlgRmzisYraGPcqrYL.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				pYQRQgBWIIWasOJfXZaAsOznabFn = new float[2];
				if (P_0[0] is float)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + BFrOROxbgOvlgRmzisYraGPcqrYL.ToString() + "\". Argument 0: time [float]");
					}
					pYQRQgBWIIWasOJfXZaAsOznabFn[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + BFrOROxbgOvlgRmzisYraGPcqrYL.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + BFrOROxbgOvlgRmzisYraGPcqrYL.ToString() + "\". Requires 1 argument: time [float]");
				}
				pYQRQgBWIIWasOJfXZaAsOznabFn = new float[1];
				if (P_0[0] is float)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + BFrOROxbgOvlgRmzisYraGPcqrYL.ToString() + "\". Argument 0: time [float]");
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
				pYQRQgBWIIWasOJfXZaAsOznabFn = new float[1];
				if (P_0[0] is float)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					pYQRQgBWIIWasOJfXZaAsOznabFn[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + BFrOROxbgOvlgRmzisYraGPcqrYL.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class ckSCCMVOHxkJBMufnXJHHNDVEYUe
	{
		public static readonly ckSCCMVOHxkJBMufnXJHHNDVEYUe _003C_003E9 = new ckSCCMVOHxkJBMufnXJHHNDVEYUe();

		public static Func<AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>> _003C_003E9__8_0;

		internal AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA> vSpCdFIFozXPShJgqRbzUkmJonFVA()
		{
			return new AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>();
		}
	}

	private sealed class thvDInKfHkquAGrSXjxXPDzRKkkFb
	{
		public Action<InputActionEventData> obwmUOJqGmUvEEqRXjcwvgGqPPUu;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> VTKQuUAyfiQjcRlpbXTHWhBaqnCu;

		internal bool DIoCpCdbItidgznKiLcpgRGDVibi(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			return P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == obwmUOJqGmUvEEqRXjcwvgGqPPUu;
		}
	}

	private sealed class MFyTvEqBQftevuEJaLXIuOGVsoJH
	{
		public Action<InputActionEventData> xriUntCcIbEXBgHRHQCzecusRUcUA;

		public int lHvaWmxUsTeeesMVZSBnVlCeRztR;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> TukmzzzJSoPnYMzOCiJVmhaCCnWA;

		internal bool ebZeTEEvxRfTmtXouUkrdrwDNiMy(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == xriUntCcIbEXBgHRHQCzecusRUcUA)
			{
				return P_0.eXykOqgFwYGjbohviERCaKUpfDjYA == lHvaWmxUsTeeesMVZSBnVlCeRztR;
			}
			return false;
		}
	}

	private sealed class xSNAhomOdkxjGALvKfpSFQuxedKYA
	{
		public Action<InputActionEventData> VMYdOYnktFEParBJhbFxjOKZnfAcA;

		public UpdateLoopType JewtMlSxUCZyzYCyIiOtAUjYSbNd;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> SGFRHALleKDXSCJLXdquefhtpRfcA;

		internal bool tqYghGoIZkiGofGfsrgyeHXArNfA(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == VMYdOYnktFEParBJhbFxjOKZnfAcA)
			{
				return P_0.REEGiPKAgjBkzgyxwRfLoGfZQpos == JewtMlSxUCZyzYCyIiOtAUjYSbNd;
			}
			return false;
		}
	}

	private sealed class hjvdwFWjOpfjUByEBPaWbEvNLOrhA
	{
		public Action<InputActionEventData> sSXRMHUHUEhtkgHOZJKruHgkqPYR;

		public InputActionEventType IStsILMeRwdBwGQXspsdmvbIeThG;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> HaJqmyCzPWaAMGIJKiTnccqTQCuo;

		internal bool JMKDGFHWoYsmIjJRxibyuecooZki(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == sSXRMHUHUEhtkgHOZJKruHgkqPYR)
			{
				return P_0.BFrOROxbgOvlgRmzisYraGPcqrYL == IStsILMeRwdBwGQXspsdmvbIeThG;
			}
			return false;
		}
	}

	private sealed class bIunHnYdbHGNqjhsAGYvTprSDpRfA
	{
		public Action<InputActionEventData> rMJBtUZFBhgJceTfjEaZYGYHlvYXA;

		public UpdateLoopType MrJiJNoRwvtjRCEOxPCpkChAVLdi;

		public int GLSAQQKGrmBMeGUJJSrpOTLpayoe;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> UgJchzGoDcMGajtHpJqcLKkqcWKAA;

		internal bool YFDlYslaPcqaKCveQdCucQsBWjRD(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == rMJBtUZFBhgJceTfjEaZYGYHlvYXA && P_0.REEGiPKAgjBkzgyxwRfLoGfZQpos == MrJiJNoRwvtjRCEOxPCpkChAVLdi)
			{
				return P_0.eXykOqgFwYGjbohviERCaKUpfDjYA == GLSAQQKGrmBMeGUJJSrpOTLpayoe;
			}
			return false;
		}
	}

	private sealed class qtpMHFiCOapBnpyLwgFHeMAporGV
	{
		public Action<InputActionEventData> uHzvcDwUibFraAlJbhoTeDuiqgcs;

		public UpdateLoopType jqbTguadBmVXKzdgeBrJMIKSRBby;

		public int TwDjDBpEKUDpAnbRPaOwwPrRDeyn;

		public InputActionEventType mIsXubbSLifjpdmNCFPEXgrXONJDb;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> KbDjzEhAvBiHIhhnrUPfjGAqgEAZA;

		internal bool uYkUtoXrBjqHdVNyZdZwTjnqXNfP(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == uHzvcDwUibFraAlJbhoTeDuiqgcs && P_0.REEGiPKAgjBkzgyxwRfLoGfZQpos == jqbTguadBmVXKzdgeBrJMIKSRBby && P_0.eXykOqgFwYGjbohviERCaKUpfDjYA == TwDjDBpEKUDpAnbRPaOwwPrRDeyn)
			{
				return P_0.BFrOROxbgOvlgRmzisYraGPcqrYL == mIsXubbSLifjpdmNCFPEXgrXONJDb;
			}
			return false;
		}
	}

	private sealed class PALGUubapOZfbPmeOmLuEiGuIcEfb
	{
		public Action<InputActionEventData> yNhXLYDYdRwZVVeMGcQATgOoXhZR;

		public UpdateLoopType DAEcMWxaIVRISzFLikKOiGdsjGSO;

		public InputActionEventType eGJBzIbjNZAolZgaxbeGHNhTKXuAA;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> fyyCUXMuLkLXkDVdwRDVPZyBREVr;

		internal bool NIBlfGBygauPogkGLZSrNbUxbpLM(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == yNhXLYDYdRwZVVeMGcQATgOoXhZR && P_0.REEGiPKAgjBkzgyxwRfLoGfZQpos == DAEcMWxaIVRISzFLikKOiGdsjGSO)
			{
				return P_0.BFrOROxbgOvlgRmzisYraGPcqrYL == eGJBzIbjNZAolZgaxbeGHNhTKXuAA;
			}
			return false;
		}
	}

	private sealed class crArhiaOiWwccWfBIBAQmQjNwLnm
	{
		public Action<InputActionEventData> BdqCaXfSnCYXisknsjkZfYuwmukeA;

		public int pdvHJRzxIxgxukpLeUtLWlvtihmM;

		public InputActionEventType apQaoMEnZpkqACKHjGeCrxyXmQMyB;

		public Predicate<pExDtbvbiXceMDbRyEbWlvXmSOnPA> xcAdohqijReNAdseprwxgMlUNZVbA;

		internal bool vGwBdAOSCQTTTBbxncQyBjlqpSwJ(pExDtbvbiXceMDbRyEbWlvXmSOnPA P_0)
		{
			if (P_0.jiEAwAmMnqAElwTuDRqqvROfobMD == BdqCaXfSnCYXisknsjkZfYuwmukeA && P_0.eXykOqgFwYGjbohviERCaKUpfDjYA == pdvHJRzxIxgxukpLeUtLWlvtihmM)
			{
				return P_0.BFrOROxbgOvlgRmzisYraGPcqrYL == apQaoMEnZpkqACKHjGeCrxyXmQMyB;
			}
			return false;
		}
	}

	private static pExDtbvbiXceMDbRyEbWlvXmSOnPA[] rCsOLTPDGiTCOjnEgDfpqGHDZjiN;

	private bool mCTkbhgoMIMawUGzyEjApWpZGMDM;

	private AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] gkAWROOskRVcsrTChBJLCFbIsCOG;

	private int[] woJtPKuhgUztGvDJfYQOgEHPdGNC;

	private int UNesrnKRdTIrpDuadvXDlXAQkjeI;

	public int vKXmnsaoHKwCVWoIpLcxGJMEprDJ;

	static QCMhwFAkemVHUWtsLnxYTCvaAOlv()
	{
		rCsOLTPDGiTCOjnEgDfpqGHDZjiN = new pExDtbvbiXceMDbRyEbWlvXmSOnPA[100];
	}

	private void CjdlIRPgyBpDRcnInFsLoamgMOIq()
	{
		if (!mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			IList<InputAction> list = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.gyJTduGYIhUqxuNheINoubncViuj;
			int num = list?.Count ?? 0;
			gkAWROOskRVcsrTChBJLCFbIsCOG = new AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[num + 1];
			woJtPKuhgUztGvDJfYQOgEHPdGNC = new int[ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.lbIKIrRqnTGlQhQzEopadSmEADDSA + 1];
			ArrayTools.Populate(gkAWROOskRVcsrTChBJLCFbIsCOG, 0, gkAWROOskRVcsrTChBJLCFbIsCOG.Length, ckSCCMVOHxkJBMufnXJHHNDVEYUe._003C_003E9.vSpCdFIFozXPShJgqRbzUkmJonFVA);
			for (int i = 0; i < num; i++)
			{
				woJtPKuhgUztGvDJfYQOgEHPdGNC[list[i].id] = i;
			}
			UNesrnKRdTIrpDuadvXDlXAQkjeI = num;
			mCTkbhgoMIMawUGzyEjApWpZGMDM = true;
		}
	}

	public void aAVNjJKCgfMfgWCaubnZKAHMzRCU(gjGAZYHMtBrBPTgtywbcfPTZqEdL P_0, UpdateLoopType P_1)
	{
		AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA> aList = gkAWROOskRVcsrTChBJLCFbIsCOG[woJtPKuhgUztGvDJfYQOgEHPdGNC[P_0.fpNeJlvLXuCAHJcOzFDinkAOhEsvA]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = gkAWROOskRVcsrTChBJLCFbIsCOG[UNesrnKRdTIrpDuadvXDlXAQkjeI];
			}
			int count = aList._count;
			if (rCsOLTPDGiTCOjnEgDfpqGHDZjiN.Length < count)
			{
				rCsOLTPDGiTCOjnEgDfpqGHDZjiN = new pExDtbvbiXceMDbRyEbWlvXmSOnPA[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, rCsOLTPDGiTCOjnEgDfpqGHDZjiN, count);
			}
			for (int j = 0; j < count; j++)
			{
				pExDtbvbiXceMDbRyEbWlvXmSOnPA pExDtbvbiXceMDbRyEbWlvXmSOnPA2 = rCsOLTPDGiTCOjnEgDfpqGHDZjiN[j];
				if (pExDtbvbiXceMDbRyEbWlvXmSOnPA2 == null || (!P_0.LmuaxpKcaNFlldWKbBZAAKPCejFqB && !pExDtbvbiXceMDbRyEbWlvXmSOnPA2.fDQEXzhPMLLlgLYTDlezoiwspBTC) || pExDtbvbiXceMDbRyEbWlvXmSOnPA2.REEGiPKAgjBkzgyxwRfLoGfZQpos != P_1 || (pExDtbvbiXceMDbRyEbWlvXmSOnPA2.eXykOqgFwYGjbohviERCaKUpfDjYA >= 0 && pExDtbvbiXceMDbRyEbWlvXmSOnPA2.eXykOqgFwYGjbohviERCaKUpfDjYA != P_0.fpNeJlvLXuCAHJcOzFDinkAOhEsvA))
				{
					continue;
				}
				bool flag = false;
				switch (pExDtbvbiXceMDbRyEbWlvXmSOnPA2.BFrOROxbgOvlgRmzisYraGPcqrYL)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.FuonpZfnMsIoctilHoaxyYdyBhPe())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.FuonpZfnMsIoctilHoaxyYdyBhPe())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num5);
					if (P_0.kGVFSQmZygeFnVSkIMyACXcsjYWn(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num11))
					{
						continue;
					}
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(1, out var num12);
					if (P_0.vqNJSnFQVahdImpeivdjhKUQqIsu(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.RdgEOnrsqnbnoGfNCoCLhpgdSwMI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.MIDVkEBmOouwYDzNPnAVakZFrYSM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.mZHiYnhZVMTDhjZLvRUEntHJjuHw())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.iqFazvtbRNuTyRjsZusNMBvfGFtk())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num9);
					if (P_0.tLnEeLgQKBjaCqeaCLrHJskehaDz(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num6);
					if (P_0.PgZCDPfFiDhZucAZhsJWDBAJMPxs(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num4))
					{
						continue;
					}
					if (P_0.ozTbjfKCrGMmVLCadArSyWqVaEObb(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.TQEUkSuCbHhTRsNYHVLHwiBiAJmv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.eNzEkBkljlqfudduKyxPNXKocpfeA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num15))
					{
						continue;
					}
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(1, out var num16);
					if (P_0.JyAydMepCujFNZILhDNDebzzCUXNA(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.nhyiJcforsMXtqvHiOplkNBDEfiw())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.lHIaTenSobuARamRaqWxXFuiuQLm())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.lHFTMgTyfAsIuMPvUDjKbrRCkFKdb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.LnEbufSAmJfOiJrZgUBgkniKbpvX())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.PJZLJevQXCnMsBKtiMDQTOvWZFnT())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.JALHxVPoifuEKIMLkheSGexBueSw())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.LJmoiCBrurlAHBkmMLoPOkULXlcW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.LJmoiCBrurlAHBkmMLoPOkULXlcW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num3);
					if (P_0.NMwEhakyyZNMHxttUYJeQiizHIVv(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num))
					{
						continue;
					}
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(1, out var num2);
					if (P_0.NwEDQpiPCmWnaFrueFvwiluVimmHA(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.sBAumCLTDURyhTfNUHsApUkQnXIU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.KrmAAGjLIditkgMZfoBjWGpOAsakc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.XBGdRySTTRFUMBwxafaWnApTtRmJA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.YVCTqAOcuTWFVseiADubHQfIHfvNA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num14);
					if (P_0.XyoIVcyTTAxYTlnfVDbUXDonhvTx(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num13);
					if (P_0.ngxWDFyCNcCegAzotQFUbmjKqQQL(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num10))
					{
						continue;
					}
					if (P_0.mItFFVLDNLBtTwmTiuhZPnTrMVfK(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.evftNegrlGWJROygXVZfWvcDcQTr())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.sSwnZwbvPqQCDbKtZFLHjyuaoFYWA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(0, out var num7))
					{
						continue;
					}
					pExDtbvbiXceMDbRyEbWlvXmSOnPA2.tPAvhOojdUMwVVihLpToFdvIvWuM(1, out var num8);
					if (P_0.BSgsdzxNmbuIKPqdoHPKJhjNAtmK(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.NZYxPhfNRFZLbmhUATIoHwFxWSLu())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.XYXatCuaXaSAkxfLudqJltsNhkhO())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.wiyiayBClpifliNehzHgFFTiWoTqA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.kVBACYjrkutBMvqbSDIGIJrfbfTH())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.YrNCuRzVhdeutyyIGfMETTxXEubP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.QgnCBglsGTlDpsjbieHyUVQwLeym())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.ZPNikWIZSmUXPbeCTkmoPmYwisik()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.ZPNikWIZSmUXPbeCTkmoPmYwisik()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.GxmEpxBgzHPvglBWBgWeIaoEfdAb()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.GxmEpxBgzHPvglBWBgWeIaoEfdAb()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.ZPNikWIZSmUXPbeCTkmoPmYwisik()) || !MathTools.ApproximatelyZero(P_0.tBoKoceMomaWNQNUUBYOAkRNkCYBb()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.GxmEpxBgzHPvglBWBgWeIaoEfdAb()) || !MathTools.ApproximatelyZero(P_0.RVNYFNnpJBJRpfldEntQCieHQtHUA()))
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
						InputActionEventData obj = P_0.XiLocXlVcPnXiItikSnrblUYaUCG(P_1);
						obj.eventType = pExDtbvbiXceMDbRyEbWlvXmSOnPA2.BFrOROxbgOvlgRmzisYraGPcqrYL;
						pExDtbvbiXceMDbRyEbWlvXmSOnPA2.jiEAwAmMnqAElwTuDRqqvROfobMD(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void XdfjOElOglXttuCMHpduSOhCfBuV(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			CjdlIRPgyBpDRcnInFsLoamgMOIq();
		}
		pExDtbvbiXceMDbRyEbWlvXmSOnPA item;
		try
		{
			if (P_3 > ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.lbIKIrRqnTGlQhQzEopadSmEADDSA)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new pExDtbvbiXceMDbRyEbWlvXmSOnPA(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			gkAWROOskRVcsrTChBJLCFbIsCOG[UNesrnKRdTIrpDuadvXDlXAQkjeI].Add(item);
		}
		else
		{
			gkAWROOskRVcsrTChBJLCFbIsCOG[woJtPKuhgUztGvDJfYQOgEHPdGNC[P_3]].Add(item);
		}
		HISqWyTYizrtkOjOeQUrJTRRETtJ();
	}

	public void rSBfqyiorrSgUZpqdemCEZwxKjYQ(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			CjdlIRPgyBpDRcnInFsLoamgMOIq();
		}
		pExDtbvbiXceMDbRyEbWlvXmSOnPA item;
		try
		{
			item = new pExDtbvbiXceMDbRyEbWlvXmSOnPA(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		gkAWROOskRVcsrTChBJLCFbIsCOG[UNesrnKRdTIrpDuadvXDlXAQkjeI].Add(item);
		HISqWyTYizrtkOjOeQUrJTRRETtJ();
	}

	public void uVXxCkXywkJUzwQTZuVQybGBjgHjA(Action<InputActionEventData> P_0)
	{
		thvDInKfHkquAGrSXjxXPDzRKkkFb thvDInKfHkquAGrSXjxXPDzRKkkFb2 = new thvDInKfHkquAGrSXjxXPDzRKkkFb();
		thvDInKfHkquAGrSXjxXPDzRKkkFb2.obwmUOJqGmUvEEqRXjcwvgGqPPUu = P_0;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(thvDInKfHkquAGrSXjxXPDzRKkkFb2.DIoCpCdbItidgznKiLcpgRGDVibi);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void ykNLpRfJFZcUUTLlGRQJOwxYepx(Action<InputActionEventData> P_0, int P_1)
	{
		MFyTvEqBQftevuEJaLXIuOGVsoJH mFyTvEqBQftevuEJaLXIuOGVsoJH = new MFyTvEqBQftevuEJaLXIuOGVsoJH();
		mFyTvEqBQftevuEJaLXIuOGVsoJH.xriUntCcIbEXBgHRHQCzecusRUcUA = P_0;
		mFyTvEqBQftevuEJaLXIuOGVsoJH.lHvaWmxUsTeeesMVZSBnVlCeRztR = P_1;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM && mFyTvEqBQftevuEJaLXIuOGVsoJH.lHvaWmxUsTeeesMVZSBnVlCeRztR <= ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.lbIKIrRqnTGlQhQzEopadSmEADDSA)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(mFyTvEqBQftevuEJaLXIuOGVsoJH.ebZeTEEvxRfTmtXouUkrdrwDNiMy);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void ozsvZcieTVbyZpIJbabNsFOmWrHN(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		xSNAhomOdkxjGALvKfpSFQuxedKYA xSNAhomOdkxjGALvKfpSFQuxedKYA2 = new xSNAhomOdkxjGALvKfpSFQuxedKYA();
		xSNAhomOdkxjGALvKfpSFQuxedKYA2.VMYdOYnktFEParBJhbFxjOKZnfAcA = P_0;
		xSNAhomOdkxjGALvKfpSFQuxedKYA2.JewtMlSxUCZyzYCyIiOtAUjYSbNd = P_1;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(xSNAhomOdkxjGALvKfpSFQuxedKYA2.tqYghGoIZkiGofGfsrgyeHXArNfA);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void joWkeUoHWKNWecRKzZGfpFPUAxmu(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		hjvdwFWjOpfjUByEBPaWbEvNLOrhA hjvdwFWjOpfjUByEBPaWbEvNLOrhA2 = new hjvdwFWjOpfjUByEBPaWbEvNLOrhA();
		hjvdwFWjOpfjUByEBPaWbEvNLOrhA2.sSXRMHUHUEhtkgHOZJKruHgkqPYR = P_0;
		hjvdwFWjOpfjUByEBPaWbEvNLOrhA2.IStsILMeRwdBwGQXspsdmvbIeThG = P_1;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(hjvdwFWjOpfjUByEBPaWbEvNLOrhA2.JMKDGFHWoYsmIjJRxibyuecooZki);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void tjSzIuiqPMBrdjaHqxOTLFnJpAnbA(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		bIunHnYdbHGNqjhsAGYvTprSDpRfA bIunHnYdbHGNqjhsAGYvTprSDpRfA2 = new bIunHnYdbHGNqjhsAGYvTprSDpRfA();
		bIunHnYdbHGNqjhsAGYvTprSDpRfA2.rMJBtUZFBhgJceTfjEaZYGYHlvYXA = P_0;
		bIunHnYdbHGNqjhsAGYvTprSDpRfA2.MrJiJNoRwvtjRCEOxPCpkChAVLdi = P_1;
		bIunHnYdbHGNqjhsAGYvTprSDpRfA2.GLSAQQKGrmBMeGUJJSrpOTLpayoe = P_2;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM && bIunHnYdbHGNqjhsAGYvTprSDpRfA2.GLSAQQKGrmBMeGUJJSrpOTLpayoe <= ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.lbIKIrRqnTGlQhQzEopadSmEADDSA)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(bIunHnYdbHGNqjhsAGYvTprSDpRfA2.YFDlYslaPcqaKCveQdCucQsBWjRD);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void xsaMKluLGKFdcBEfBFMflIuHBfSgA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		qtpMHFiCOapBnpyLwgFHeMAporGV qtpMHFiCOapBnpyLwgFHeMAporGV2 = new qtpMHFiCOapBnpyLwgFHeMAporGV();
		qtpMHFiCOapBnpyLwgFHeMAporGV2.uHzvcDwUibFraAlJbhoTeDuiqgcs = P_0;
		qtpMHFiCOapBnpyLwgFHeMAporGV2.jqbTguadBmVXKzdgeBrJMIKSRBby = P_1;
		qtpMHFiCOapBnpyLwgFHeMAporGV2.TwDjDBpEKUDpAnbRPaOwwPrRDeyn = P_3;
		qtpMHFiCOapBnpyLwgFHeMAporGV2.mIsXubbSLifjpdmNCFPEXgrXONJDb = P_2;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM && qtpMHFiCOapBnpyLwgFHeMAporGV2.TwDjDBpEKUDpAnbRPaOwwPrRDeyn <= ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.lbIKIrRqnTGlQhQzEopadSmEADDSA)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(qtpMHFiCOapBnpyLwgFHeMAporGV2.uYkUtoXrBjqHdVNyZdZwTjnqXNfP);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void PiQFIxZrevGpiKsziHBEElIbxyfKb(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		PALGUubapOZfbPmeOmLuEiGuIcEfb pALGUubapOZfbPmeOmLuEiGuIcEfb = new PALGUubapOZfbPmeOmLuEiGuIcEfb();
		pALGUubapOZfbPmeOmLuEiGuIcEfb.yNhXLYDYdRwZVVeMGcQATgOoXhZR = P_0;
		pALGUubapOZfbPmeOmLuEiGuIcEfb.DAEcMWxaIVRISzFLikKOiGdsjGSO = P_1;
		pALGUubapOZfbPmeOmLuEiGuIcEfb.eGJBzIbjNZAolZgaxbeGHNhTKXuAA = P_2;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(pALGUubapOZfbPmeOmLuEiGuIcEfb.NIBlfGBygauPogkGLZSrNbUxbpLM);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void ZydQKCFJHxZXOrDemwwoyWeJuOcC(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		crArhiaOiWwccWfBIBAQmQjNwLnm crArhiaOiWwccWfBIBAQmQjNwLnm2 = new crArhiaOiWwccWfBIBAQmQjNwLnm();
		crArhiaOiWwccWfBIBAQmQjNwLnm2.BdqCaXfSnCYXisknsjkZfYuwmukeA = P_0;
		crArhiaOiWwccWfBIBAQmQjNwLnm2.pdvHJRzxIxgxukpLeUtLWlvtihmM = P_2;
		crArhiaOiWwccWfBIBAQmQjNwLnm2.apQaoMEnZpkqACKHjGeCrxyXmQMyB = P_1;
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM && crArhiaOiWwccWfBIBAQmQjNwLnm2.pdvHJRzxIxgxukpLeUtLWlvtihmM <= ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.lbIKIrRqnTGlQhQzEopadSmEADDSA)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(crArhiaOiWwccWfBIBAQmQjNwLnm2.vGwBdAOSCQTTTBbxncQyBjlqpSwJ);
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	public void KnRGVyiPMMgwKDCgygXNcxUhCTgbc()
	{
		if (mCTkbhgoMIMawUGzyEjApWpZGMDM)
		{
			AList<pExDtbvbiXceMDbRyEbWlvXmSOnPA>[] array = gkAWROOskRVcsrTChBJLCFbIsCOG;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			HISqWyTYizrtkOjOeQUrJTRRETtJ();
		}
	}

	private void HISqWyTYizrtkOjOeQUrJTRRETtJ()
	{
		int num = 0;
		for (int i = 0; i < gkAWROOskRVcsrTChBJLCFbIsCOG.Length; i++)
		{
			num += gkAWROOskRVcsrTChBJLCFbIsCOG[i]._count;
		}
		vKXmnsaoHKwCVWoIpLcxGJMEprDJ = num;
	}
}
