using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class TWxrygPadDakJYMiziCpkvpWZYPZ
{
	public class ogYPtKggriPBXblXEVUfByDUbCRw
	{
		public readonly Action<InputActionEventData> sbpMgdnFoRrpqoTOvweXJJPRaaud;

		public readonly UpdateLoopType OHpKseTmbIFcciZjOEIgGVrdjJMg;

		public readonly InputActionEventType ACIgpqztnAPlBqlAJCSUEDWhwmu;

		public readonly int zxNudHdgzdaIayEzIKgbgCAZnTRs;

		public readonly bool gThWaKkOLsqgjLEGfEmCWceIDxjV;

		public float[] oeniQHKYZjXHhSIrxFZpQytZClzS;

		public ogYPtKggriPBXblXEVUfByDUbCRw(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			OHpKseTmbIFcciZjOEIgGVrdjJMg = P_1;
			ACIgpqztnAPlBqlAJCSUEDWhwmu = P_2;
			zxNudHdgzdaIayEzIKgbgCAZnTRs = P_3;
			sbpMgdnFoRrpqoTOvweXJJPRaaud = P_0;
			DpjgicBoqWFaQfonkvIpdCvhpJxfb(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				gThWaKkOLsqgjLEGfEmCWceIDxjV = true;
				break;
			}
		}

		public bool oqlffljpgfSVYMXhzNaPuffeXGUuA(int P_0, out float P_1)
		{
			if (oeniQHKYZjXHhSIrxFZpQytZClzS == null || oeniQHKYZjXHhSIrxFZpQytZClzS.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = oeniQHKYZjXHhSIrxFZpQytZClzS[P_0];
			return true;
		}

		private void DpjgicBoqWFaQfonkvIpdCvhpJxfb(object[] P_0)
		{
			switch (ACIgpqztnAPlBqlAJCSUEDWhwmu)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + ACIgpqztnAPlBqlAJCSUEDWhwmu.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				oeniQHKYZjXHhSIrxFZpQytZClzS = new float[2];
				if (P_0[0] is float)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + ACIgpqztnAPlBqlAJCSUEDWhwmu.ToString() + "\". Argument 0: time [float]");
					}
					oeniQHKYZjXHhSIrxFZpQytZClzS[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + ACIgpqztnAPlBqlAJCSUEDWhwmu.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + ACIgpqztnAPlBqlAJCSUEDWhwmu.ToString() + "\". Requires 1 argument: time [float]");
				}
				oeniQHKYZjXHhSIrxFZpQytZClzS = new float[1];
				if (P_0[0] is float)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + ACIgpqztnAPlBqlAJCSUEDWhwmu.ToString() + "\". Argument 0: time [float]");
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
				oeniQHKYZjXHhSIrxFZpQytZClzS = new float[1];
				if (P_0[0] is float)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					oeniQHKYZjXHhSIrxFZpQytZClzS[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + ACIgpqztnAPlBqlAJCSUEDWhwmu.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class xHxGjjCBNSRwGKeqVciizuZdKKqH
	{
		public static readonly xHxGjjCBNSRwGKeqVciizuZdKKqH _003C_003E9 = new xHxGjjCBNSRwGKeqVciizuZdKKqH();

		public static Func<AList<ogYPtKggriPBXblXEVUfByDUbCRw>> _003C_003E9__8_0;

		internal AList<ogYPtKggriPBXblXEVUfByDUbCRw> wUOthwGabKvaBFKgClIKGTofSdxS()
		{
			return new AList<ogYPtKggriPBXblXEVUfByDUbCRw>();
		}
	}

	private sealed class qaEbAAfoEVJPPbdGaxMaDlpWvsUVB
	{
		public Action<InputActionEventData> vyLMEtOqRLbKXEgNlmNRBiGAaBwq;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> IjlhmtNUsHfInFelLxwywsTQhwkL;

		internal bool IKPOdAsRwOFxalMrCgOtOIqlPTcB(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			return P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == vyLMEtOqRLbKXEgNlmNRBiGAaBwq;
		}
	}

	private sealed class DMRLafzOsYEocwHiIeGhACDnqstE
	{
		public Action<InputActionEventData> gBHGnCaLFOjcCDRJezfSyQcMEKANA;

		public int eOKAbJcdhgfDfipZtwyCrdMKAlVN;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> OLVqPEkWThkJeQzRuTmwAleAWjTC;

		internal bool lzwDXvPeewijrxWqEJVUNHybupaF(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == gBHGnCaLFOjcCDRJezfSyQcMEKANA)
			{
				return P_0.zxNudHdgzdaIayEzIKgbgCAZnTRs == eOKAbJcdhgfDfipZtwyCrdMKAlVN;
			}
			return false;
		}
	}

	private sealed class kvitHXftcXOHPAJdwEtheKeLlZgg
	{
		public Action<InputActionEventData> QotQrtiMimmnhhmPTyLYynAjnvkg;

		public UpdateLoopType DHlGFHugjeijOIfqPjzoMgwGxnc;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> XfwEHjGIvjogZUdHjATLjRrVrBRJA;

		internal bool cUFydMXHQiXzNeKzBOaLKTGhphnF(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == QotQrtiMimmnhhmPTyLYynAjnvkg)
			{
				return P_0.OHpKseTmbIFcciZjOEIgGVrdjJMg == DHlGFHugjeijOIfqPjzoMgwGxnc;
			}
			return false;
		}
	}

	private sealed class usQYwwXHLIMGDuPKdbLdBqprnEHcA
	{
		public Action<InputActionEventData> hpmTpsZrDbOPrybQrrXGKzcSVGyl;

		public InputActionEventType DAOgsLJKHTKjgUZsOMELEhywgVNB;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> IauacJVhItaBZjORcmuYKxqjEOGeA;

		internal bool AvlAReYZrhTPDtoFLTRVOMoAjeKHA(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == hpmTpsZrDbOPrybQrrXGKzcSVGyl)
			{
				return P_0.ACIgpqztnAPlBqlAJCSUEDWhwmu == DAOgsLJKHTKjgUZsOMELEhywgVNB;
			}
			return false;
		}
	}

	private sealed class izNdnEVVkyubxxTeidKSpjrqxBnK
	{
		public Action<InputActionEventData> uoyhGxIoGQmYbJGrLHsyyfYrlbyl;

		public UpdateLoopType NAqqGutHSGKVUMBORkhEWAnkFtVl;

		public int LupQneRZXBmbGYIdvvdIuXJZozQd;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> BCezaMLTSBdljnyBPPZHpCaSWKwk;

		internal bool DNcxPfkCzLFLhCbzgOtZGaUxCBtK(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == uoyhGxIoGQmYbJGrLHsyyfYrlbyl && P_0.OHpKseTmbIFcciZjOEIgGVrdjJMg == NAqqGutHSGKVUMBORkhEWAnkFtVl)
			{
				return P_0.zxNudHdgzdaIayEzIKgbgCAZnTRs == LupQneRZXBmbGYIdvvdIuXJZozQd;
			}
			return false;
		}
	}

	private sealed class jSKiFejrFZfsefjLEMggLIUPEbgab
	{
		public Action<InputActionEventData> zzIFqcftpUYMrEKRRnZeAEkIRsIkA;

		public UpdateLoopType gkIALRrECDwqDxVsEFGkyGSwgLXbA;

		public int KmuzkaFTbvoLzoLrHjVCIhxCiIDb;

		public InputActionEventType rgJAuQcaIPXEeJaPyqatNUzzZFfmA;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> ZgaxlrPVesJmDpUnNaxIyACQHYqr;

		internal bool hCLjbJaAOOCgunXurzwZcrvOMZLHA(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == zzIFqcftpUYMrEKRRnZeAEkIRsIkA && P_0.OHpKseTmbIFcciZjOEIgGVrdjJMg == gkIALRrECDwqDxVsEFGkyGSwgLXbA && P_0.zxNudHdgzdaIayEzIKgbgCAZnTRs == KmuzkaFTbvoLzoLrHjVCIhxCiIDb)
			{
				return P_0.ACIgpqztnAPlBqlAJCSUEDWhwmu == rgJAuQcaIPXEeJaPyqatNUzzZFfmA;
			}
			return false;
		}
	}

	private sealed class KtmUUZjHepBGkjyeaPgNwWKGYuyMA
	{
		public Action<InputActionEventData> zoOcTxAOsiueYgZEgcdbUvOCkplIb;

		public UpdateLoopType YzQarevRixkTpiXWVXzChlAeQyV;

		public InputActionEventType hCarxlceUmVSqPQwDZmlrShxNrYh;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> wdVQqwFNUNqaxZebCGuovzqhWObY;

		internal bool YiuIxbUKrLBqpuOQdUwQxLYHLdjV(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == zoOcTxAOsiueYgZEgcdbUvOCkplIb && P_0.OHpKseTmbIFcciZjOEIgGVrdjJMg == YzQarevRixkTpiXWVXzChlAeQyV)
			{
				return P_0.ACIgpqztnAPlBqlAJCSUEDWhwmu == hCarxlceUmVSqPQwDZmlrShxNrYh;
			}
			return false;
		}
	}

	private sealed class xAfrcRhFFdRmfWvJyanfOdnxHyBR
	{
		public Action<InputActionEventData> WdHAiikBchBabhorIEDaVkaKTgOYA;

		public int sUAsZwovPAPYvwkTKbGsgytBfvIt;

		public InputActionEventType zElyivmhSECZDYRVcDTpTieYMOkx;

		public Predicate<ogYPtKggriPBXblXEVUfByDUbCRw> ikdkGCpouwoVPkCwJDfWwlbwLQrG;

		internal bool qcZlZrFGJxgoMJhjZhjRdVfMcxCr(ogYPtKggriPBXblXEVUfByDUbCRw P_0)
		{
			if (P_0.sbpMgdnFoRrpqoTOvweXJJPRaaud == WdHAiikBchBabhorIEDaVkaKTgOYA && P_0.zxNudHdgzdaIayEzIKgbgCAZnTRs == sUAsZwovPAPYvwkTKbGsgytBfvIt)
			{
				return P_0.ACIgpqztnAPlBqlAJCSUEDWhwmu == zElyivmhSECZDYRVcDTpTieYMOkx;
			}
			return false;
		}
	}

	private static ogYPtKggriPBXblXEVUfByDUbCRw[] qvPkBqENNVAbTitMWNCWfSPfUnIdb;

	private bool zgqckMjwJvortQHdOdOnRrrncUzFA;

	private AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] hAlKBpNdfyaubdZKZisFwVegwkqC;

	private int[] vrszmqhyIrWbilJHPzVjOpAvvOpJ;

	private int ZpZHpABDsqzQcFNuTFUcDLQqkiWJA;

	public int kLaCoVbHCptLIYHQDrsQefYogvjY;

	static TWxrygPadDakJYMiziCpkvpWZYPZ()
	{
		qvPkBqENNVAbTitMWNCWfSPfUnIdb = new ogYPtKggriPBXblXEVUfByDUbCRw[100];
	}

	private void BcSIIsElradaUimCPjRsyIsSlSmFb()
	{
		if (!zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			IList<InputAction> list = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.jyuLoFNATCeressrQgpNGCxIRXCeA;
			int num = list?.Count ?? 0;
			hAlKBpNdfyaubdZKZisFwVegwkqC = new AList<ogYPtKggriPBXblXEVUfByDUbCRw>[num + 1];
			vrszmqhyIrWbilJHPzVjOpAvvOpJ = new int[ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.elpMIISnqilIDGlbcGYXcsaqcTnO + 1];
			ArrayTools.Populate(hAlKBpNdfyaubdZKZisFwVegwkqC, 0, hAlKBpNdfyaubdZKZisFwVegwkqC.Length, xHxGjjCBNSRwGKeqVciizuZdKKqH._003C_003E9.wUOthwGabKvaBFKgClIKGTofSdxS);
			for (int i = 0; i < num; i++)
			{
				vrszmqhyIrWbilJHPzVjOpAvvOpJ[list[i].id] = i;
			}
			ZpZHpABDsqzQcFNuTFUcDLQqkiWJA = num;
			zgqckMjwJvortQHdOdOnRrrncUzFA = true;
		}
	}

	public void bmSHoZIdYnxvAucGWAqmnBaBFuCA(pDpcIvKINqIAQeDxKXPLLXNhacXfb P_0, UpdateLoopType P_1)
	{
		AList<ogYPtKggriPBXblXEVUfByDUbCRw> aList = hAlKBpNdfyaubdZKZisFwVegwkqC[vrszmqhyIrWbilJHPzVjOpAvvOpJ[P_0.uWwoJOoRGLpfYsRYNUiJYSEmuUSQ]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = hAlKBpNdfyaubdZKZisFwVegwkqC[ZpZHpABDsqzQcFNuTFUcDLQqkiWJA];
			}
			int count = aList._count;
			if (qvPkBqENNVAbTitMWNCWfSPfUnIdb.Length < count)
			{
				qvPkBqENNVAbTitMWNCWfSPfUnIdb = new ogYPtKggriPBXblXEVUfByDUbCRw[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, qvPkBqENNVAbTitMWNCWfSPfUnIdb, count);
			}
			for (int j = 0; j < count; j++)
			{
				ogYPtKggriPBXblXEVUfByDUbCRw ogYPtKggriPBXblXEVUfByDUbCRw2 = qvPkBqENNVAbTitMWNCWfSPfUnIdb[j];
				if (ogYPtKggriPBXblXEVUfByDUbCRw2 == null || (!P_0.IjLlaALGfscUuAHYRXkxkKJKIlvQ && !ogYPtKggriPBXblXEVUfByDUbCRw2.gThWaKkOLsqgjLEGfEmCWceIDxjV) || ogYPtKggriPBXblXEVUfByDUbCRw2.OHpKseTmbIFcciZjOEIgGVrdjJMg != P_1 || (ogYPtKggriPBXblXEVUfByDUbCRw2.zxNudHdgzdaIayEzIKgbgCAZnTRs >= 0 && ogYPtKggriPBXblXEVUfByDUbCRw2.zxNudHdgzdaIayEzIKgbgCAZnTRs != P_0.uWwoJOoRGLpfYsRYNUiJYSEmuUSQ))
				{
					continue;
				}
				bool flag = false;
				switch (ogYPtKggriPBXblXEVUfByDUbCRw2.ACIgpqztnAPlBqlAJCSUEDWhwmu)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.YQHfsMysqVjztjwtrTJFEIeKPird())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.YQHfsMysqVjztjwtrTJFEIeKPird())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num5);
					if (P_0.bKsRSxbtfTpamFQsojBxcIkAeIev(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num11))
					{
						continue;
					}
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(1, out var num12);
					if (P_0.mHwOISIcKLYELmfuIzMWVmQuGYSN(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.UXRCACstvUhSzSsNqQPqZVmZvEoP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.PSmFidGuPRXVZPuRjIzgWBTnKIqV())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.jrqnIQwfWvLcsfINFBfxTCLjSkbp())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.zXkcXAuzSiVuvHFqjJGyoytJKnVj())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num9);
					if (P_0.giKSymFnBekDXeKoefEobpuGompRA(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num6);
					if (P_0.QgeCOiegreCsvsCBPcovahClMBVmA(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num4))
					{
						continue;
					}
					if (P_0.ncabbIfRkvnLKsQgZnQbciyloOmfb(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.YWvQkhzwkcccOuvCrukmIILSCZYM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.jpOUeomRsCoKfdlsscOgcxMOCxVWA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num15))
					{
						continue;
					}
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(1, out var num16);
					if (P_0.OipdrlFpLTVyCpXDZzgoIHdLUKfKA(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.cfPlJFcsmJfsgdcDIMEUaUXDbjKob())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.eOzBxHcRvWjlQkJRYXNQjgwEcwvr())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.omigMRGRorchncQbopMtNSJoXBgN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.UjvvuWLmvgjYpZbBYeiDUBimhnLF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.KcijJVoMSdfrhAFbQSgjUvpyWTPAA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.KCmTzwSFlOBbJMDRKbTfAeflpmkPA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.YPJJifGpzKGpOHFiwhVoQgKlzzCdA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.YPJJifGpzKGpOHFiwhVoQgKlzzCdA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num3);
					if (P_0.MvTUmTtOfqkLMpnrmrmTekmLKmjK(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num))
					{
						continue;
					}
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(1, out var num2);
					if (P_0.IUlNISpQBLKTrVbaUExFDHkpdaCP(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.bXzEmfKpQvDHeXwRmNFlDUcorJaq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.TXZvEnCwDEJInMiFQLkEiGreusUX())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.KeraHXgHMqVrTuinGHPvxuntPHYeA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.PWnDobdZzmcwAbkseaPUoybpajTDc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num14);
					if (P_0.SXVAGXvfSlaIOhobhQqxpAqXefbfA(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num13);
					if (P_0.sgGOOklIMBhBhMuiVcunLYdccsgR(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num10))
					{
						continue;
					}
					if (P_0.nzKXiwKtOuYZEsvHGMKynCFVEhBj(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.dtOdLTararwkQAEqbloYduuveWbxA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.vRTDJRmXEZEfKfPbzLkaSmmUUVoO())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(0, out var num7))
					{
						continue;
					}
					ogYPtKggriPBXblXEVUfByDUbCRw2.oqlffljpgfSVYMXhzNaPuffeXGUuA(1, out var num8);
					if (P_0.UqRAuOeHxIPHVZFvSvqrzozjyIAt(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.KGnCXSdaSodcwVoWeIdTInDVQAvpA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.EqzadOhGBxxvhvLQcHgdTejBsTcb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.ziPlaNCCiOmYyLBmPfgPjsLWmVtL())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.jZiCUrcsbTGEXfgxqGopKopVvbhdA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.NJcypgkPuGBRciwSwxWrlIthaGZl())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.RHUCUDueBsZAoiLdSTqTowAUPoET())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.QoqRapVfNVFpGbfOnTBHEzMMMoAAA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.QoqRapVfNVFpGbfOnTBHEzMMMoAAA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.HgSolGqzrWgygyBlaPrrqoDQbdPe()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.HgSolGqzrWgygyBlaPrrqoDQbdPe()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.QoqRapVfNVFpGbfOnTBHEzMMMoAAA()) || !MathTools.ApproximatelyZero(P_0.uIZMyZpElPRhKSvEssphCHLzKWoT()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.HgSolGqzrWgygyBlaPrrqoDQbdPe()) || !MathTools.ApproximatelyZero(P_0.KFwDFmCqYqFyolxhyoAzmOmdbffNA()))
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
						InputActionEventData obj = P_0.UfassciDjqcSdSIuQdbEePSkKmkjA(P_1);
						obj.eventType = ogYPtKggriPBXblXEVUfByDUbCRw2.ACIgpqztnAPlBqlAJCSUEDWhwmu;
						ogYPtKggriPBXblXEVUfByDUbCRw2.sbpMgdnFoRrpqoTOvweXJJPRaaud(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void YnULYfgfnGWOiiHGzCUPCylcZRQm(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			BcSIIsElradaUimCPjRsyIsSlSmFb();
		}
		ogYPtKggriPBXblXEVUfByDUbCRw item;
		try
		{
			if (P_3 > ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.elpMIISnqilIDGlbcGYXcsaqcTnO)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new ogYPtKggriPBXblXEVUfByDUbCRw(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			hAlKBpNdfyaubdZKZisFwVegwkqC[ZpZHpABDsqzQcFNuTFUcDLQqkiWJA].Add(item);
		}
		else
		{
			hAlKBpNdfyaubdZKZisFwVegwkqC[vrszmqhyIrWbilJHPzVjOpAvvOpJ[P_3]].Add(item);
		}
		ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
	}

	public void itkpiJpsmAAPLLWgXpBhomoNAvagA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			BcSIIsElradaUimCPjRsyIsSlSmFb();
		}
		ogYPtKggriPBXblXEVUfByDUbCRw item;
		try
		{
			item = new ogYPtKggriPBXblXEVUfByDUbCRw(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		hAlKBpNdfyaubdZKZisFwVegwkqC[ZpZHpABDsqzQcFNuTFUcDLQqkiWJA].Add(item);
		ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
	}

	public void rfgCATbUdPGxemgZfharHOUpnonbb(Action<InputActionEventData> P_0)
	{
		qaEbAAfoEVJPPbdGaxMaDlpWvsUVB qaEbAAfoEVJPPbdGaxMaDlpWvsUVB2 = new qaEbAAfoEVJPPbdGaxMaDlpWvsUVB();
		qaEbAAfoEVJPPbdGaxMaDlpWvsUVB2.vyLMEtOqRLbKXEgNlmNRBiGAaBwq = P_0;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(qaEbAAfoEVJPPbdGaxMaDlpWvsUVB2.IKPOdAsRwOFxalMrCgOtOIqlPTcB);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void fCTJiEYEUmVtVERXVmcndvwVeePI(Action<InputActionEventData> P_0, int P_1)
	{
		DMRLafzOsYEocwHiIeGhACDnqstE dMRLafzOsYEocwHiIeGhACDnqstE = new DMRLafzOsYEocwHiIeGhACDnqstE();
		dMRLafzOsYEocwHiIeGhACDnqstE.gBHGnCaLFOjcCDRJezfSyQcMEKANA = P_0;
		dMRLafzOsYEocwHiIeGhACDnqstE.eOKAbJcdhgfDfipZtwyCrdMKAlVN = P_1;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA && dMRLafzOsYEocwHiIeGhACDnqstE.eOKAbJcdhgfDfipZtwyCrdMKAlVN <= ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.elpMIISnqilIDGlbcGYXcsaqcTnO)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(dMRLafzOsYEocwHiIeGhACDnqstE.lzwDXvPeewijrxWqEJVUNHybupaF);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void fqXZXRhgKsRXYflPVtYcOXAMxAvK(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		kvitHXftcXOHPAJdwEtheKeLlZgg kvitHXftcXOHPAJdwEtheKeLlZgg2 = new kvitHXftcXOHPAJdwEtheKeLlZgg();
		kvitHXftcXOHPAJdwEtheKeLlZgg2.QotQrtiMimmnhhmPTyLYynAjnvkg = P_0;
		kvitHXftcXOHPAJdwEtheKeLlZgg2.DHlGFHugjeijOIfqPjzoMgwGxnc = P_1;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(kvitHXftcXOHPAJdwEtheKeLlZgg2.cUFydMXHQiXzNeKzBOaLKTGhphnF);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void wbcgjphHnXctdwQPleEfNZcZhKdA(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		usQYwwXHLIMGDuPKdbLdBqprnEHcA usQYwwXHLIMGDuPKdbLdBqprnEHcA2 = new usQYwwXHLIMGDuPKdbLdBqprnEHcA();
		usQYwwXHLIMGDuPKdbLdBqprnEHcA2.hpmTpsZrDbOPrybQrrXGKzcSVGyl = P_0;
		usQYwwXHLIMGDuPKdbLdBqprnEHcA2.DAOgsLJKHTKjgUZsOMELEhywgVNB = P_1;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(usQYwwXHLIMGDuPKdbLdBqprnEHcA2.AvlAReYZrhTPDtoFLTRVOMoAjeKHA);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void ujfcGDfvGrOMmCoHSSfkcrpprKTiA(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		izNdnEVVkyubxxTeidKSpjrqxBnK izNdnEVVkyubxxTeidKSpjrqxBnK2 = new izNdnEVVkyubxxTeidKSpjrqxBnK();
		izNdnEVVkyubxxTeidKSpjrqxBnK2.uoyhGxIoGQmYbJGrLHsyyfYrlbyl = P_0;
		izNdnEVVkyubxxTeidKSpjrqxBnK2.NAqqGutHSGKVUMBORkhEWAnkFtVl = P_1;
		izNdnEVVkyubxxTeidKSpjrqxBnK2.LupQneRZXBmbGYIdvvdIuXJZozQd = P_2;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA && izNdnEVVkyubxxTeidKSpjrqxBnK2.LupQneRZXBmbGYIdvvdIuXJZozQd <= ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.elpMIISnqilIDGlbcGYXcsaqcTnO)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(izNdnEVVkyubxxTeidKSpjrqxBnK2.DNcxPfkCzLFLhCbzgOtZGaUxCBtK);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void uvPIKIjbFvbufBUbxglORkubMtio(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		jSKiFejrFZfsefjLEMggLIUPEbgab jSKiFejrFZfsefjLEMggLIUPEbgab2 = new jSKiFejrFZfsefjLEMggLIUPEbgab();
		jSKiFejrFZfsefjLEMggLIUPEbgab2.zzIFqcftpUYMrEKRRnZeAEkIRsIkA = P_0;
		jSKiFejrFZfsefjLEMggLIUPEbgab2.gkIALRrECDwqDxVsEFGkyGSwgLXbA = P_1;
		jSKiFejrFZfsefjLEMggLIUPEbgab2.KmuzkaFTbvoLzoLrHjVCIhxCiIDb = P_3;
		jSKiFejrFZfsefjLEMggLIUPEbgab2.rgJAuQcaIPXEeJaPyqatNUzzZFfmA = P_2;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA && jSKiFejrFZfsefjLEMggLIUPEbgab2.KmuzkaFTbvoLzoLrHjVCIhxCiIDb <= ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.elpMIISnqilIDGlbcGYXcsaqcTnO)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(jSKiFejrFZfsefjLEMggLIUPEbgab2.hCLjbJaAOOCgunXurzwZcrvOMZLHA);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void OGjtKCKmpINQvyznSfidDUKZBqBv(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		KtmUUZjHepBGkjyeaPgNwWKGYuyMA ktmUUZjHepBGkjyeaPgNwWKGYuyMA = new KtmUUZjHepBGkjyeaPgNwWKGYuyMA();
		ktmUUZjHepBGkjyeaPgNwWKGYuyMA.zoOcTxAOsiueYgZEgcdbUvOCkplIb = P_0;
		ktmUUZjHepBGkjyeaPgNwWKGYuyMA.YzQarevRixkTpiXWVXzChlAeQyV = P_1;
		ktmUUZjHepBGkjyeaPgNwWKGYuyMA.hCarxlceUmVSqPQwDZmlrShxNrYh = P_2;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(ktmUUZjHepBGkjyeaPgNwWKGYuyMA.YiuIxbUKrLBqpuOQdUwQxLYHLdjV);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void MYOQVhKEDQoGRrGPWDHBSpQvoJKh(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		xAfrcRhFFdRmfWvJyanfOdnxHyBR xAfrcRhFFdRmfWvJyanfOdnxHyBR2 = new xAfrcRhFFdRmfWvJyanfOdnxHyBR();
		xAfrcRhFFdRmfWvJyanfOdnxHyBR2.WdHAiikBchBabhorIEDaVkaKTgOYA = P_0;
		xAfrcRhFFdRmfWvJyanfOdnxHyBR2.sUAsZwovPAPYvwkTKbGsgytBfvIt = P_2;
		xAfrcRhFFdRmfWvJyanfOdnxHyBR2.zElyivmhSECZDYRVcDTpTieYMOkx = P_1;
		if (zgqckMjwJvortQHdOdOnRrrncUzFA && xAfrcRhFFdRmfWvJyanfOdnxHyBR2.sUAsZwovPAPYvwkTKbGsgytBfvIt <= ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.elpMIISnqilIDGlbcGYXcsaqcTnO)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(xAfrcRhFFdRmfWvJyanfOdnxHyBR2.qcZlZrFGJxgoMJhjZhjRdVfMcxCr);
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	public void XKwQXDlBRpLXDQOmGcSgHZUgNcGK()
	{
		if (zgqckMjwJvortQHdOdOnRrrncUzFA)
		{
			AList<ogYPtKggriPBXblXEVUfByDUbCRw>[] array = hAlKBpNdfyaubdZKZisFwVegwkqC;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			ShlDOFKgxMoCrGdGCpfYfHBvDIVV();
		}
	}

	private void ShlDOFKgxMoCrGdGCpfYfHBvDIVV()
	{
		int num = 0;
		for (int i = 0; i < hAlKBpNdfyaubdZKZisFwVegwkqC.Length; i++)
		{
			num += hAlKBpNdfyaubdZKZisFwVegwkqC[i]._count;
		}
		kLaCoVbHCptLIYHQDrsQefYogvjY = num;
	}
}
