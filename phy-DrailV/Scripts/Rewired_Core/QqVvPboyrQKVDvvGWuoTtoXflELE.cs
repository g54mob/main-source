using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class QqVvPboyrQKVDvvGWuoTtoXflELE
{
	public class nFseyRFwdhddXABMtgpNHuGzhPFl
	{
		public readonly Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public readonly UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

		public readonly InputActionEventType smwzEToHFIYMvJurYhiHPgRjeoPC;

		public readonly int BOmXoDplzfnHtyBjNJvkkPzUlWST;

		public readonly bool tTqFANENmmrpwWMMUJhAckXynMXIb;

		public float[] AcYsmTcfyOjXsZCVhCxXzwJVfNPn;

		public nFseyRFwdhddXABMtgpNHuGzhPFl(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_1;
			smwzEToHFIYMvJurYhiHPgRjeoPC = P_2;
			BOmXoDplzfnHtyBjNJvkkPzUlWST = P_3;
			ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
			ocTtQTNqfTEbeGRhFnLJvuopJdQEA(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				tTqFANENmmrpwWMMUJhAckXynMXIb = true;
				break;
			}
		}

		public bool YreGIWuAeYSLwYOAQYVWEULYHCML(int P_0, out float P_1)
		{
			if (AcYsmTcfyOjXsZCVhCxXzwJVfNPn == null || AcYsmTcfyOjXsZCVhCxXzwJVfNPn.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = AcYsmTcfyOjXsZCVhCxXzwJVfNPn[P_0];
			return true;
		}

		private void ocTtQTNqfTEbeGRhFnLJvuopJdQEA(object[] P_0)
		{
			switch (smwzEToHFIYMvJurYhiHPgRjeoPC)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + smwzEToHFIYMvJurYhiHPgRjeoPC.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				AcYsmTcfyOjXsZCVhCxXzwJVfNPn = new float[2];
				if (P_0[0] is float)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + smwzEToHFIYMvJurYhiHPgRjeoPC.ToString() + "\". Argument 0: time [float]");
					}
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + smwzEToHFIYMvJurYhiHPgRjeoPC.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + smwzEToHFIYMvJurYhiHPgRjeoPC.ToString() + "\". Requires 1 argument: time [float]");
				}
				AcYsmTcfyOjXsZCVhCxXzwJVfNPn = new float[1];
				if (P_0[0] is float)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + smwzEToHFIYMvJurYhiHPgRjeoPC.ToString() + "\". Argument 0: time [float]");
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
				AcYsmTcfyOjXsZCVhCxXzwJVfNPn = new float[1];
				if (P_0[0] is float)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					AcYsmTcfyOjXsZCVhCxXzwJVfNPn[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + smwzEToHFIYMvJurYhiHPgRjeoPC.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class akXlZobzQJQnEvbtcxEGhaYKmjeQ
	{
		public static readonly akXlZobzQJQnEvbtcxEGhaYKmjeQ _003C_003E9 = new akXlZobzQJQnEvbtcxEGhaYKmjeQ();

		public static Func<AList<nFseyRFwdhddXABMtgpNHuGzhPFl>> _003C_003E9__8_0;

		internal AList<nFseyRFwdhddXABMtgpNHuGzhPFl> eOUfOhBAwwtbginHfvfEpNLQAzsXA()
		{
			return new AList<nFseyRFwdhddXABMtgpNHuGzhPFl>();
		}
	}

	private sealed class xTuVBZFqDGlWFSOHOgPShkcYNFWh
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			return P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp;
		}
	}

	private sealed class OElDAgMBXTEokiXUnqKXrKVUjZnyA
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public int BOmXoDplzfnHtyBjNJvkkPzUlWST;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp)
			{
				return P_0.BOmXoDplzfnHtyBjNJvkkPzUlWST == BOmXoDplzfnHtyBjNJvkkPzUlWST;
			}
			return false;
		}
	}

	private sealed class hzEziUWPrEFoNgtwDJiNZkvmrUeUA
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp)
			{
				return P_0.duvdeoIMbviHBoTTDYZbkoEpbLKZA == duvdeoIMbviHBoTTDYZbkoEpbLKZA;
			}
			return false;
		}
	}

	private sealed class bcopcpwKIPipNDXBMxlToFqSGbNO
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public InputActionEventType smwzEToHFIYMvJurYhiHPgRjeoPC;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp)
			{
				return P_0.smwzEToHFIYMvJurYhiHPgRjeoPC == smwzEToHFIYMvJurYhiHPgRjeoPC;
			}
			return false;
		}
	}

	private sealed class XyUREUJRdZjNcUlpHxvnMBIlncLg
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

		public int BOmXoDplzfnHtyBjNJvkkPzUlWST;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp && P_0.duvdeoIMbviHBoTTDYZbkoEpbLKZA == duvdeoIMbviHBoTTDYZbkoEpbLKZA)
			{
				return P_0.BOmXoDplzfnHtyBjNJvkkPzUlWST == BOmXoDplzfnHtyBjNJvkkPzUlWST;
			}
			return false;
		}
	}

	private sealed class ntgfpgWnJUCRbMDTenybpsxEcUCI
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

		public int BOmXoDplzfnHtyBjNJvkkPzUlWST;

		public InputActionEventType smwzEToHFIYMvJurYhiHPgRjeoPC;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp && P_0.duvdeoIMbviHBoTTDYZbkoEpbLKZA == duvdeoIMbviHBoTTDYZbkoEpbLKZA && P_0.BOmXoDplzfnHtyBjNJvkkPzUlWST == BOmXoDplzfnHtyBjNJvkkPzUlWST)
			{
				return P_0.smwzEToHFIYMvJurYhiHPgRjeoPC == smwzEToHFIYMvJurYhiHPgRjeoPC;
			}
			return false;
		}
	}

	private sealed class RACDQSWbnmfaoJnvZiSxKZTxGFuR
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

		public InputActionEventType smwzEToHFIYMvJurYhiHPgRjeoPC;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp && P_0.duvdeoIMbviHBoTTDYZbkoEpbLKZA == duvdeoIMbviHBoTTDYZbkoEpbLKZA)
			{
				return P_0.smwzEToHFIYMvJurYhiHPgRjeoPC == smwzEToHFIYMvJurYhiHPgRjeoPC;
			}
			return false;
		}
	}

	private sealed class gRJpiYWOGeGbtvvWLBCLKYkSNSLl
	{
		public Action<InputActionEventData> ELAgrvFVeGaxXkehkhmyIodmtbsp;

		public int BOmXoDplzfnHtyBjNJvkkPzUlWST;

		public InputActionEventType smwzEToHFIYMvJurYhiHPgRjeoPC;

		public Predicate<nFseyRFwdhddXABMtgpNHuGzhPFl> wOxQUvcuXvcJNuriTPSmcQeAGZQi;

		internal bool IODMlLXWdmTJpyvHcEwdzACkOWtP(nFseyRFwdhddXABMtgpNHuGzhPFl P_0)
		{
			if (P_0.ELAgrvFVeGaxXkehkhmyIodmtbsp == ELAgrvFVeGaxXkehkhmyIodmtbsp && P_0.BOmXoDplzfnHtyBjNJvkkPzUlWST == BOmXoDplzfnHtyBjNJvkkPzUlWST)
			{
				return P_0.smwzEToHFIYMvJurYhiHPgRjeoPC == smwzEToHFIYMvJurYhiHPgRjeoPC;
			}
			return false;
		}
	}

	private static nFseyRFwdhddXABMtgpNHuGzhPFl[] oladFWlbPujzdeTCArOGbrJmTTfE;

	private bool DlyzgeEtPbGSRivIvEmZhBSIEqiU;

	private AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] UkKytLDWKaRWlPDZrqECMMaiOWPD;

	private int[] LZQggyBDBcLASCZhKiWwexOqgExtA;

	private int xyZzcuzzhrlrVFPgbXTuVOoCVcwB;

	public int bsAehNdEpnVKupYvQvQtJltgYgtLA;

	static QqVvPboyrQKVDvvGWuoTtoXflELE()
	{
		oladFWlbPujzdeTCArOGbrJmTTfE = new nFseyRFwdhddXABMtgpNHuGzhPFl[100];
	}

	private void TlzckGoQDITHcUYaslQXPQBOhTwq()
	{
		if (!DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			IList<InputAction> list = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.JztSgslzhagKBJhbGNArekIIiZlf;
			int num = list?.Count ?? 0;
			UkKytLDWKaRWlPDZrqECMMaiOWPD = new AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[num + 1];
			LZQggyBDBcLASCZhKiWwexOqgExtA = new int[ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.WsnXzBfcMhAtQgXzLfeanZnPAyXtA + 1];
			ArrayTools.Populate(UkKytLDWKaRWlPDZrqECMMaiOWPD, 0, UkKytLDWKaRWlPDZrqECMMaiOWPD.Length, akXlZobzQJQnEvbtcxEGhaYKmjeQ._003C_003E9.eOUfOhBAwwtbginHfvfEpNLQAzsXA);
			for (int i = 0; i < num; i++)
			{
				LZQggyBDBcLASCZhKiWwexOqgExtA[list[i].id] = i;
			}
			xyZzcuzzhrlrVFPgbXTuVOoCVcwB = num;
			DlyzgeEtPbGSRivIvEmZhBSIEqiU = true;
		}
	}

	public void WzfEHiRbIfIOuCEwgAnvNCmNMKFbA(oQRCFcJpUjLqOkwwnIxnfTMKhLJWA P_0, UpdateLoopType P_1)
	{
		AList<nFseyRFwdhddXABMtgpNHuGzhPFl> aList = UkKytLDWKaRWlPDZrqECMMaiOWPD[LZQggyBDBcLASCZhKiWwexOqgExtA[P_0.nqrNxyIjKJnAagqUPKmjCYvwkyMr]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = UkKytLDWKaRWlPDZrqECMMaiOWPD[xyZzcuzzhrlrVFPgbXTuVOoCVcwB];
			}
			int count = aList._count;
			if (oladFWlbPujzdeTCArOGbrJmTTfE.Length < count)
			{
				oladFWlbPujzdeTCArOGbrJmTTfE = new nFseyRFwdhddXABMtgpNHuGzhPFl[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, oladFWlbPujzdeTCArOGbrJmTTfE, count);
			}
			for (int j = 0; j < count; j++)
			{
				nFseyRFwdhddXABMtgpNHuGzhPFl nFseyRFwdhddXABMtgpNHuGzhPFl2 = oladFWlbPujzdeTCArOGbrJmTTfE[j];
				if (nFseyRFwdhddXABMtgpNHuGzhPFl2 == null || (!P_0.tgvVmwfSudDgQeGCTgJwqomTwepU && !nFseyRFwdhddXABMtgpNHuGzhPFl2.tTqFANENmmrpwWMMUJhAckXynMXIb) || nFseyRFwdhddXABMtgpNHuGzhPFl2.duvdeoIMbviHBoTTDYZbkoEpbLKZA != P_1 || (nFseyRFwdhddXABMtgpNHuGzhPFl2.BOmXoDplzfnHtyBjNJvkkPzUlWST >= 0 && nFseyRFwdhddXABMtgpNHuGzhPFl2.BOmXoDplzfnHtyBjNJvkkPzUlWST != P_0.nqrNxyIjKJnAagqUPKmjCYvwkyMr))
				{
					continue;
				}
				bool flag = false;
				switch (nFseyRFwdhddXABMtgpNHuGzhPFl2.smwzEToHFIYMvJurYhiHPgRjeoPC)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.aBjKkYedffJMBNyjOkVFOWaUaAhq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.aBjKkYedffJMBNyjOkVFOWaUaAhq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num5);
					if (P_0.fGrfpCetbdrKqeHbFsuPvafPRESbB(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num11))
					{
						continue;
					}
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(1, out var num12);
					if (P_0.rYvZrqLIEfQSIYbjvmJRAFXiqciG(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.wKnbzcWwOaLrOzSBtGWFcSCeammv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.sLaxixlWJSqMBnbTfnalgnERAeXk())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.jYWxpmOgglOGuxLGHjZnFKAvkMEVA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.NSCNnosVEfppjSDmbInqdnhriOUCb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num9);
					if (P_0.RcXDvTiiILQzTCKEyfHSAYQmjxOV(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num6);
					if (P_0.GzDJQAgdenEgvphMsgEaElrcFvuTA(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num4))
					{
						continue;
					}
					if (P_0.dQHQTENqnyfFFiAjapdkHkNZNRzb(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.nvhKouvEJvdTwMHxRHsUnWQJpIqN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.jYqabKZmwtoSQsSFjJmkhmYbPIFD())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num15))
					{
						continue;
					}
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(1, out var num16);
					if (P_0.mhYvIBoWyhPMAFuOIKKgwRFPHBhy(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.PdHcAEwphxEAeVbNuimEHvTzFeWgA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.tAtdOjdZyxcBaKsDNFasfYtMXWcq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.QmlGqIFOMvtlmEVTrTFoiHXNYGYBA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.rHtSQnVSLBplJZRFObHrOFjzcoQK())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.csDrdChbJQIOmksuuVxOxEagdqDu())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.jVbQtlyEpufFHIoPlezNcnoiygzJA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.BUDvRzCDOdNgSDFFXUnYMQiVSgEo())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.BUDvRzCDOdNgSDFFXUnYMQiVSgEo())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num3);
					if (P_0.FzqOFPHPyvGIVUQrCGUhfYylwPxh(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num))
					{
						continue;
					}
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(1, out var num2);
					if (P_0.ctxzUBojHfaMDKluBWpwDbvbWeTO(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.UEfZNGvENjameDloZdGLWGDrNETA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.pAoCECnEGXfuTmEPNDDQlTrTSAoL())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.HelmxrCyZjEmODVCgMtGwDwOrjHf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.MwMEOSDIIFPGmIGayVPhiNpATkQH())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num14);
					if (P_0.DyBFksccVwqlIJdyxdRmDnwtBhAjb(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num13);
					if (P_0.xPOfYcFAqcbGQXNpkmPkGuHehRgWB(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num10))
					{
						continue;
					}
					if (P_0.TTdplYZkHbfsyVDzFsLCzAwVeYYD(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.rzYKbXTMvvIApGCKOLCHjMrDgBuf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.epYInvbADrkzNKygaikcJwafHBur())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(0, out var num7))
					{
						continue;
					}
					nFseyRFwdhddXABMtgpNHuGzhPFl2.YreGIWuAeYSLwYOAQYVWEULYHCML(1, out var num8);
					if (P_0.IibrkGxpYUNpGLFuwWQMdmaEFqwi(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.avyVqEOPNYRRSMRmPrcRJvCUOLZ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.aODPQqwcjhbzrAQcbMXYMkzoKxaq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.COhDpfBOOMpezHoIGQMbFrKVmpCnb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.LcUGNRHrNzbefybEPWAFRskoKhOvA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.QFDHMOeOEOExSdgRtNyXnQixJsHoA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.iPoDluKIPcUUSfnvMOzWXPhECoWjA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.mtDFbsoRVlrEoxEmreAlGujQTODw()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.mtDFbsoRVlrEoxEmreAlGujQTODw()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.bLjUqDJVGVSlWmxjKKTBRMkNFIFdA()) || !MathTools.ApproximatelyZero(P_0.NwhhRAfbaWNuJFqlJkXCStnDAvJS()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.mtDFbsoRVlrEoxEmreAlGujQTODw()) || !MathTools.ApproximatelyZero(P_0.hUkWLcyhKkGyVnBbrhNUuNsSzzfB()))
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
						InputActionEventData obj = P_0.CJCFhXKKNkdNUzyvRelpgDwGNRIm(P_1);
						obj.eventType = nFseyRFwdhddXABMtgpNHuGzhPFl2.smwzEToHFIYMvJurYhiHPgRjeoPC;
						nFseyRFwdhddXABMtgpNHuGzhPFl2.ELAgrvFVeGaxXkehkhmyIodmtbsp(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void fyeqCafQbFyflbNbajUvornPxfgy(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}
		nFseyRFwdhddXABMtgpNHuGzhPFl item;
		try
		{
			if (P_3 > ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.WsnXzBfcMhAtQgXzLfeanZnPAyXtA)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new nFseyRFwdhddXABMtgpNHuGzhPFl(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			UkKytLDWKaRWlPDZrqECMMaiOWPD[xyZzcuzzhrlrVFPgbXTuVOoCVcwB].Add(item);
		}
		else
		{
			UkKytLDWKaRWlPDZrqECMMaiOWPD[LZQggyBDBcLASCZhKiWwexOqgExtA[P_3]].Add(item);
		}
		yoXPNVfVepDGKBHauDQdDEOdzCkN();
	}

	public void fyeqCafQbFyflbNbajUvornPxfgy(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			TlzckGoQDITHcUYaslQXPQBOhTwq();
		}
		nFseyRFwdhddXABMtgpNHuGzhPFl item;
		try
		{
			item = new nFseyRFwdhddXABMtgpNHuGzhPFl(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		UkKytLDWKaRWlPDZrqECMMaiOWPD[xyZzcuzzhrlrVFPgbXTuVOoCVcwB].Add(item);
		yoXPNVfVepDGKBHauDQdDEOdzCkN();
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0)
	{
		xTuVBZFqDGlWFSOHOgPShkcYNFWh xTuVBZFqDGlWFSOHOgPShkcYNFWh2 = new xTuVBZFqDGlWFSOHOgPShkcYNFWh();
		xTuVBZFqDGlWFSOHOgPShkcYNFWh2.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(xTuVBZFqDGlWFSOHOgPShkcYNFWh2.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, int P_1)
	{
		OElDAgMBXTEokiXUnqKXrKVUjZnyA oElDAgMBXTEokiXUnqKXrKVUjZnyA = new OElDAgMBXTEokiXUnqKXrKVUjZnyA();
		oElDAgMBXTEokiXUnqKXrKVUjZnyA.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		oElDAgMBXTEokiXUnqKXrKVUjZnyA.BOmXoDplzfnHtyBjNJvkkPzUlWST = P_1;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU && oElDAgMBXTEokiXUnqKXrKVUjZnyA.BOmXoDplzfnHtyBjNJvkkPzUlWST <= ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.WsnXzBfcMhAtQgXzLfeanZnPAyXtA)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(oElDAgMBXTEokiXUnqKXrKVUjZnyA.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		hzEziUWPrEFoNgtwDJiNZkvmrUeUA hzEziUWPrEFoNgtwDJiNZkvmrUeUA2 = new hzEziUWPrEFoNgtwDJiNZkvmrUeUA();
		hzEziUWPrEFoNgtwDJiNZkvmrUeUA2.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		hzEziUWPrEFoNgtwDJiNZkvmrUeUA2.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_1;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(hzEziUWPrEFoNgtwDJiNZkvmrUeUA2.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		bcopcpwKIPipNDXBMxlToFqSGbNO bcopcpwKIPipNDXBMxlToFqSGbNO2 = new bcopcpwKIPipNDXBMxlToFqSGbNO();
		bcopcpwKIPipNDXBMxlToFqSGbNO2.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		bcopcpwKIPipNDXBMxlToFqSGbNO2.smwzEToHFIYMvJurYhiHPgRjeoPC = P_1;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(bcopcpwKIPipNDXBMxlToFqSGbNO2.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		XyUREUJRdZjNcUlpHxvnMBIlncLg xyUREUJRdZjNcUlpHxvnMBIlncLg = new XyUREUJRdZjNcUlpHxvnMBIlncLg();
		xyUREUJRdZjNcUlpHxvnMBIlncLg.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		xyUREUJRdZjNcUlpHxvnMBIlncLg.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_1;
		xyUREUJRdZjNcUlpHxvnMBIlncLg.BOmXoDplzfnHtyBjNJvkkPzUlWST = P_2;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU && xyUREUJRdZjNcUlpHxvnMBIlncLg.BOmXoDplzfnHtyBjNJvkkPzUlWST <= ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.WsnXzBfcMhAtQgXzLfeanZnPAyXtA)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(xyUREUJRdZjNcUlpHxvnMBIlncLg.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		ntgfpgWnJUCRbMDTenybpsxEcUCI ntgfpgWnJUCRbMDTenybpsxEcUCI2 = new ntgfpgWnJUCRbMDTenybpsxEcUCI();
		ntgfpgWnJUCRbMDTenybpsxEcUCI2.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		ntgfpgWnJUCRbMDTenybpsxEcUCI2.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_1;
		ntgfpgWnJUCRbMDTenybpsxEcUCI2.BOmXoDplzfnHtyBjNJvkkPzUlWST = P_3;
		ntgfpgWnJUCRbMDTenybpsxEcUCI2.smwzEToHFIYMvJurYhiHPgRjeoPC = P_2;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU && ntgfpgWnJUCRbMDTenybpsxEcUCI2.BOmXoDplzfnHtyBjNJvkkPzUlWST <= ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.WsnXzBfcMhAtQgXzLfeanZnPAyXtA)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(ntgfpgWnJUCRbMDTenybpsxEcUCI2.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		RACDQSWbnmfaoJnvZiSxKZTxGFuR rACDQSWbnmfaoJnvZiSxKZTxGFuR = new RACDQSWbnmfaoJnvZiSxKZTxGFuR();
		rACDQSWbnmfaoJnvZiSxKZTxGFuR.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		rACDQSWbnmfaoJnvZiSxKZTxGFuR.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_1;
		rACDQSWbnmfaoJnvZiSxKZTxGFuR.smwzEToHFIYMvJurYhiHPgRjeoPC = P_2;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(rACDQSWbnmfaoJnvZiSxKZTxGFuR.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		gRJpiYWOGeGbtvvWLBCLKYkSNSLl gRJpiYWOGeGbtvvWLBCLKYkSNSLl2 = new gRJpiYWOGeGbtvvWLBCLKYkSNSLl();
		gRJpiYWOGeGbtvvWLBCLKYkSNSLl2.ELAgrvFVeGaxXkehkhmyIodmtbsp = P_0;
		gRJpiYWOGeGbtvvWLBCLKYkSNSLl2.BOmXoDplzfnHtyBjNJvkkPzUlWST = P_2;
		gRJpiYWOGeGbtvvWLBCLKYkSNSLl2.smwzEToHFIYMvJurYhiHPgRjeoPC = P_1;
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU && gRJpiYWOGeGbtvvWLBCLKYkSNSLl2.BOmXoDplzfnHtyBjNJvkkPzUlWST <= ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.WsnXzBfcMhAtQgXzLfeanZnPAyXtA)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].RemoveAll(gRJpiYWOGeGbtvvWLBCLKYkSNSLl2.IODMlLXWdmTJpyvHcEwdzACkOWtP);
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	public void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		if (DlyzgeEtPbGSRivIvEmZhBSIEqiU)
		{
			AList<nFseyRFwdhddXABMtgpNHuGzhPFl>[] ukKytLDWKaRWlPDZrqECMMaiOWPD = UkKytLDWKaRWlPDZrqECMMaiOWPD;
			for (int i = 0; i < ukKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
			{
				ukKytLDWKaRWlPDZrqECMMaiOWPD[i].Clear();
			}
			yoXPNVfVepDGKBHauDQdDEOdzCkN();
		}
	}

	private void yoXPNVfVepDGKBHauDQdDEOdzCkN()
	{
		int num = 0;
		for (int i = 0; i < UkKytLDWKaRWlPDZrqECMMaiOWPD.Length; i++)
		{
			num += UkKytLDWKaRWlPDZrqECMMaiOWPD[i]._count;
		}
		bsAehNdEpnVKupYvQvQtJltgYgtLA = num;
	}
}
