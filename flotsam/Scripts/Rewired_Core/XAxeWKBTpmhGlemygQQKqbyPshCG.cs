using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class XAxeWKBTpmhGlemygQQKqbyPshCG
{
	public class mXUfdaoyjRGkvVXXXIvSOTSXwoOG
	{
		public readonly Action<InputActionEventData> kazhQBHfXaQyKYWDwGayRQSAFErgb;

		public readonly UpdateLoopType CDzuUETglfySSEnjHSATVhiqBTJn;

		public readonly InputActionEventType AdWcKZawxOFBTqnnRKDnCVWCRWfec;

		public readonly int zgXqidjMlQsROKStNUaOvmPQLlMv;

		public readonly bool ufdhSgbgATmvRXnEaJUtJXxNuJmIA;

		public float[] kkjEFfGFJEfOXwhjsBDScHqEhZqQA;

		public mXUfdaoyjRGkvVXXXIvSOTSXwoOG(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			CDzuUETglfySSEnjHSATVhiqBTJn = P_1;
			AdWcKZawxOFBTqnnRKDnCVWCRWfec = P_2;
			zgXqidjMlQsROKStNUaOvmPQLlMv = P_3;
			kazhQBHfXaQyKYWDwGayRQSAFErgb = P_0;
			TudirCTDgtbtkWgvrYWSXUiaexaS(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				ufdhSgbgATmvRXnEaJUtJXxNuJmIA = true;
				break;
			}
		}

		public bool eRbnRipqFCQHynhzeqcoqwrfaaDC(int P_0, out float P_1)
		{
			if (kkjEFfGFJEfOXwhjsBDScHqEhZqQA == null || kkjEFfGFJEfOXwhjsBDScHqEhZqQA.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = kkjEFfGFJEfOXwhjsBDScHqEhZqQA[P_0];
			return true;
		}

		private void TudirCTDgtbtkWgvrYWSXUiaexaS(object[] P_0)
		{
			switch (AdWcKZawxOFBTqnnRKDnCVWCRWfec)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + AdWcKZawxOFBTqnnRKDnCVWCRWfec.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				kkjEFfGFJEfOXwhjsBDScHqEhZqQA = new float[2];
				if (P_0[0] is float)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + AdWcKZawxOFBTqnnRKDnCVWCRWfec.ToString() + "\". Argument 0: time [float]");
					}
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + AdWcKZawxOFBTqnnRKDnCVWCRWfec.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + AdWcKZawxOFBTqnnRKDnCVWCRWfec.ToString() + "\". Requires 1 argument: time [float]");
				}
				kkjEFfGFJEfOXwhjsBDScHqEhZqQA = new float[1];
				if (P_0[0] is float)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + AdWcKZawxOFBTqnnRKDnCVWCRWfec.ToString() + "\". Argument 0: time [float]");
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
				kkjEFfGFJEfOXwhjsBDScHqEhZqQA = new float[1];
				if (P_0[0] is float)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					kkjEFfGFJEfOXwhjsBDScHqEhZqQA[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + AdWcKZawxOFBTqnnRKDnCVWCRWfec.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class zszWCTCPZhHMcgDcOZeZmiKehsdbA
	{
		public static readonly zszWCTCPZhHMcgDcOZeZmiKehsdbA _003C_003E9 = new zszWCTCPZhHMcgDcOZeZmiKehsdbA();

		public static Func<AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>> _003C_003E9__8_0;

		internal AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> kKKhDSYFrdxfxtPeTOFhFjfkGPkP()
		{
			return new AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>();
		}
	}

	private sealed class ucYINcmfIiUqfDZQyAALewmkQaBK
	{
		public Action<InputActionEventData> zcDQaHQPDgPLzkeFyJZeGTHXfnbN;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> EpfcnDDjeeXUXpbxQAkXpjEZbLzm;

		internal bool OwBAEZEeHlXCVjFCHLurtLTahhMFb(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			return P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == zcDQaHQPDgPLzkeFyJZeGTHXfnbN;
		}
	}

	private sealed class LXBeFLetMzCNCuOPTncSYXVuVMqlA
	{
		public Action<InputActionEventData> aqZdbgTPpplsutPnifdUJnzVoDzB;

		public int yWAOEluKpNvMVMZTqHslyoHXcDUP;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> OIBwoykSMEhdAsrdvgFPVzkJTeIr;

		internal bool vHeMBTNKkVWhPDhaXjRrgWfqxCjPA(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == aqZdbgTPpplsutPnifdUJnzVoDzB)
			{
				return P_0.zgXqidjMlQsROKStNUaOvmPQLlMv == yWAOEluKpNvMVMZTqHslyoHXcDUP;
			}
			return false;
		}
	}

	private sealed class iQcNdrbwoafRvsVtluUOfTpWlLtv
	{
		public Action<InputActionEventData> YxxlWVeFoTUxRRoHWoclzaVmbHpjA;

		public UpdateLoopType OzZbluTXaKFbIGyMdVHQFjDjCieFb;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> ZXqRKLKFlSkrfuMTmEBkEMgEFtSjA;

		internal bool isNyomJeJFRAbGTSAqMoRgQipXeN(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == YxxlWVeFoTUxRRoHWoclzaVmbHpjA)
			{
				return P_0.CDzuUETglfySSEnjHSATVhiqBTJn == OzZbluTXaKFbIGyMdVHQFjDjCieFb;
			}
			return false;
		}
	}

	private sealed class quEsaQFkDbZvdCQYiNoAjVewsRMG
	{
		public Action<InputActionEventData> tlyQXWNoRUBPVERKwjtbDgdVErpZ;

		public InputActionEventType HMGBsMIRIkIZDbsJALAzjPkavMHMD;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> SGqeavXQWAiMrsfDfSknDoboGeZV;

		internal bool MpxINAIPjSbYtVyFCLpmZnvNUoRi(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == tlyQXWNoRUBPVERKwjtbDgdVErpZ)
			{
				return P_0.AdWcKZawxOFBTqnnRKDnCVWCRWfec == HMGBsMIRIkIZDbsJALAzjPkavMHMD;
			}
			return false;
		}
	}

	private sealed class wUFrpuFHsTgvLNXqvSfxqTcrhViN
	{
		public Action<InputActionEventData> uxmnpXExMlUdXpTdUWPBbaJmUXvs;

		public UpdateLoopType PliSaEfxEzGHqqrUQLatTQgfcrUn;

		public int RTxfWTVfPmfjVeoWyBzvstYAEIVib;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> XymMdkTXGaFyRVPTCJJoqbjBfsrFA;

		internal bool XXoVhVadfguSVoAltwEkTqVqeqoHA(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == uxmnpXExMlUdXpTdUWPBbaJmUXvs && P_0.CDzuUETglfySSEnjHSATVhiqBTJn == PliSaEfxEzGHqqrUQLatTQgfcrUn)
			{
				return P_0.zgXqidjMlQsROKStNUaOvmPQLlMv == RTxfWTVfPmfjVeoWyBzvstYAEIVib;
			}
			return false;
		}
	}

	private sealed class bLKbZAvyXolrKTFxVefBBHDKDLrJ
	{
		public Action<InputActionEventData> pAKoeCbxkbRsByVEOBqPXjNJKAVd;

		public UpdateLoopType iQGeTptkScNznNBgJBSDibBpRbKsA;

		public int MnsDbKKcDGcdtQFHeHryaTcHqYLpb;

		public InputActionEventType dPyistgUyNVQpSVtGuAPJksCrsYA;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> JjutJLXiMVlwpRbAWepnhJgFsIbh;

		internal bool pDXjAlWCYfzCOjebwqagwekTvjSF(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == pAKoeCbxkbRsByVEOBqPXjNJKAVd && P_0.CDzuUETglfySSEnjHSATVhiqBTJn == iQGeTptkScNznNBgJBSDibBpRbKsA && P_0.zgXqidjMlQsROKStNUaOvmPQLlMv == MnsDbKKcDGcdtQFHeHryaTcHqYLpb)
			{
				return P_0.AdWcKZawxOFBTqnnRKDnCVWCRWfec == dPyistgUyNVQpSVtGuAPJksCrsYA;
			}
			return false;
		}
	}

	private sealed class QIcCXnzwTGXoOEwJdwIcPfZDMhzE
	{
		public Action<InputActionEventData> xAALDvIiTqpyzWEhblGDmBJiZytA;

		public UpdateLoopType YHjDgLfyBLdrrfLDVtBMvNaZSetvA;

		public InputActionEventType nymnhPwzIZcACpimWaJMjkwevtHFA;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> omBlQYXlGuNlVxepBaeJjgjaOwiSA;

		internal bool GBwfnDESxiGzXWEYexilkBJYZLaR(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == xAALDvIiTqpyzWEhblGDmBJiZytA && P_0.CDzuUETglfySSEnjHSATVhiqBTJn == YHjDgLfyBLdrrfLDVtBMvNaZSetvA)
			{
				return P_0.AdWcKZawxOFBTqnnRKDnCVWCRWfec == nymnhPwzIZcACpimWaJMjkwevtHFA;
			}
			return false;
		}
	}

	private sealed class blrtxvvyLGWAHeaLbMaMDxwqTMIV
	{
		public Action<InputActionEventData> AFHyOQNdcArOFIbhTJgRlyfZWTBg;

		public int mzQRFWcqDtFIFKDBLgANzQqMWJXT;

		public InputActionEventType tvjuqHmjInGgxiwTbHXYChjZiMlj;

		public Predicate<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> kGxnkqjZeDwdxSqwYRVppqwrPxuT;

		internal bool cYTmlJDxTABfubKzGOvaihqTlFTp(mXUfdaoyjRGkvVXXXIvSOTSXwoOG P_0)
		{
			if (P_0.kazhQBHfXaQyKYWDwGayRQSAFErgb == AFHyOQNdcArOFIbhTJgRlyfZWTBg && P_0.zgXqidjMlQsROKStNUaOvmPQLlMv == mzQRFWcqDtFIFKDBLgANzQqMWJXT)
			{
				return P_0.AdWcKZawxOFBTqnnRKDnCVWCRWfec == tvjuqHmjInGgxiwTbHXYChjZiMlj;
			}
			return false;
		}
	}

	private static mXUfdaoyjRGkvVXXXIvSOTSXwoOG[] mbVBDWQKBkKubDmSVdWbTqQsMLZv;

	private bool jbwLyqdFXMUiFutjTtEYUrmsjogu;

	private AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] hZvgWRfRpVIxLMJXChmZXfUxKExjb;

	private int[] zpsWjYpGqKPDEBZXWblAJDVixXgR;

	private int FvBlHgZBgNGJIlIcUmIZOCNnZWVu;

	public int uskholhiOMnSsgUISoyhlEFbhHiAA;

	static XAxeWKBTpmhGlemygQQKqbyPshCG()
	{
		mbVBDWQKBkKubDmSVdWbTqQsMLZv = new mXUfdaoyjRGkvVXXXIvSOTSXwoOG[100];
	}

	private void DUWCAIAcjVMvyKJUQDLPZPhXuXxl()
	{
		if (!jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			IList<InputAction> list = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.jfcDDlHmBpYiSSIzFklkPMeTElLiA;
			int num = list?.Count ?? 0;
			hZvgWRfRpVIxLMJXChmZXfUxKExjb = new AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[num + 1];
			zpsWjYpGqKPDEBZXWblAJDVixXgR = new int[ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.echKJcMQeDVAxadtvbMojJnhdfmM + 1];
			ArrayTools.Populate(hZvgWRfRpVIxLMJXChmZXfUxKExjb, 0, hZvgWRfRpVIxLMJXChmZXfUxKExjb.Length, zszWCTCPZhHMcgDcOZeZmiKehsdbA._003C_003E9.kKKhDSYFrdxfxtPeTOFhFjfkGPkP);
			for (int i = 0; i < num; i++)
			{
				zpsWjYpGqKPDEBZXWblAJDVixXgR[list[i].id] = i;
			}
			FvBlHgZBgNGJIlIcUmIZOCNnZWVu = num;
			jbwLyqdFXMUiFutjTtEYUrmsjogu = true;
		}
	}

	public void tHceBCiJjxseLCuiHLSFjdEbjpnAb(lXvJAREcFJqTwbpbVaXyWnOsESQEA P_0, UpdateLoopType P_1)
	{
		AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG> aList = hZvgWRfRpVIxLMJXChmZXfUxKExjb[zpsWjYpGqKPDEBZXWblAJDVixXgR[P_0.iOyZywcMUeuWkANMAkueVLStqCBf]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = hZvgWRfRpVIxLMJXChmZXfUxKExjb[FvBlHgZBgNGJIlIcUmIZOCNnZWVu];
			}
			int count = aList._count;
			if (mbVBDWQKBkKubDmSVdWbTqQsMLZv.Length < count)
			{
				mbVBDWQKBkKubDmSVdWbTqQsMLZv = new mXUfdaoyjRGkvVXXXIvSOTSXwoOG[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, mbVBDWQKBkKubDmSVdWbTqQsMLZv, count);
			}
			for (int j = 0; j < count; j++)
			{
				mXUfdaoyjRGkvVXXXIvSOTSXwoOG mXUfdaoyjRGkvVXXXIvSOTSXwoOG2 = mbVBDWQKBkKubDmSVdWbTqQsMLZv[j];
				if (mXUfdaoyjRGkvVXXXIvSOTSXwoOG2 == null || (!P_0.MrBOpsHJnZsFCkTIKqwYzoIPeZuO && !mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.ufdhSgbgATmvRXnEaJUtJXxNuJmIA) || mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.CDzuUETglfySSEnjHSATVhiqBTJn != P_1 || (mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.zgXqidjMlQsROKStNUaOvmPQLlMv >= 0 && mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.zgXqidjMlQsROKStNUaOvmPQLlMv != P_0.iOyZywcMUeuWkANMAkueVLStqCBf))
				{
					continue;
				}
				bool flag = false;
				switch (mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.AdWcKZawxOFBTqnnRKDnCVWCRWfec)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.IPBglEDiskLyDaFoCmNkHNTILvkoD())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.IPBglEDiskLyDaFoCmNkHNTILvkoD())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num5);
					if (P_0.hckAhLzhvsGrGziwjLVYftlXjutR(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num11))
					{
						continue;
					}
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(1, out var num12);
					if (P_0.iLyUWcCExyFVnKqBTGfvQeHpisZi(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.UETjCacldnZLRsCFfOVVOpvGqwdQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.XTygVrQDMeWzdvNCcbVUNEDkwhfC())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.riuGhwaMOAdFGDFRYDzUUxYehYkQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.bSwJemwUEXGGBhhqyxFRvLmWIqGY())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num9);
					if (P_0.mXMcUQLDjZKLbSwyrIXXizIZMakC(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num6);
					if (P_0.KAqgQWsIxLEjXBUDMPaMLyXeYtAn(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num4))
					{
						continue;
					}
					if (P_0.jemjNeDdmCWQgidsYMLMtrxauMpI(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.ATbRCRlVsJgfySlKcqwDTzADtFRI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.lRGuwAswCvNtFPgHzSVLyVOVTlEC())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num15))
					{
						continue;
					}
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(1, out var num16);
					if (P_0.ItrlVrVHcgtqpFPEduZHYaUCqwsA(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.uVNPDdyMewbdUMNPZOzbJiEcBZXf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.yWxoBlcLzlemoOuRRYRbcWvDjOcV())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.saeQPtCwGGaeReinxCUMSwIrhYpF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.MsrPrsRShXkgVvDLLEcmCVbzOLQcA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.IVgCBhoYMSCaNnypJLyYwFolNdOM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.IgudzUOMbpcOxmaZREBGjJgoJIdR())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.EVDaaHKwprBiqlvanCLDzZZcIJDp())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.EVDaaHKwprBiqlvanCLDzZZcIJDp())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num3);
					if (P_0.YrTrWftClZWtgPLbnibohShAEeuZ(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num))
					{
						continue;
					}
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(1, out var num2);
					if (P_0.YLhODevbPifVPfCqHgMeDIrcXKTZ(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.xdtelTQZIAOrSbeDpLVYUthjzRlF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.HNTYPDOjRxFFLksZTwvjllazYDRK())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.KhxBPpPiOXgSvGNtPRGOvHsskrZq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.BljscRLzpNviyYundTExtmvpLKYc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num14);
					if (P_0.YfTFApbwCYgRwLFdqfiQjkzWPNuab(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num13);
					if (P_0.mASgYYxHWsnQZmJkMriECBovlKfw(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num10))
					{
						continue;
					}
					if (P_0.tUWRRMMUWPlLcOYXTSOBqCIELkSU(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.xhWVfrbsxAxhqeaigwQjfdPqaBad())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.tlDAVpqQQoUumHLpmFcRHXlNablBb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(0, out var num7))
					{
						continue;
					}
					mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.eRbnRipqFCQHynhzeqcoqwrfaaDC(1, out var num8);
					if (P_0.MlFIiayGhxVYtdBnJSeOifmmXqPP(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.KzMLkitOPOzISfQfTrceQUKGuebA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.SgsZyJhnWgsoZNcDPZVRIXrmkMEV())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.pZNwfbMswzBhQnSkWqbkqnETAquh())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.rGkjONohjkzPrXbjtneWnEsYAJiY())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.PssLqSiqevMTMMAUxerYquegHQSU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.TcMLIdmkPPhJICPtZbiektZPSCJSA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.MsemiDNvFwuvkRHSoRvueQDDCJHf()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.MsemiDNvFwuvkRHSoRvueQDDCJHf()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.DeKBwydovtExYTMFfxXAMhbNoHGib()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.DeKBwydovtExYTMFfxXAMhbNoHGib()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.MsemiDNvFwuvkRHSoRvueQDDCJHf()) || !MathTools.ApproximatelyZero(P_0.iARuJzhKfksmmefEbtjGLMIccAzj()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.DeKBwydovtExYTMFfxXAMhbNoHGib()) || !MathTools.ApproximatelyZero(P_0.MqeXSgkURrlITajbbOSBTjoHZyCA()))
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
						InputActionEventData obj = P_0.UaogyIuCrBSDJwnsRorrEeJrNAjX(P_1);
						obj.eventType = mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.AdWcKZawxOFBTqnnRKDnCVWCRWfec;
						mXUfdaoyjRGkvVXXXIvSOTSXwoOG2.kazhQBHfXaQyKYWDwGayRQSAFErgb(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void GEEQOJiOddPLKUrEaCzqncktpAVj(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			DUWCAIAcjVMvyKJUQDLPZPhXuXxl();
		}
		mXUfdaoyjRGkvVXXXIvSOTSXwoOG item;
		try
		{
			if (P_3 > ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.echKJcMQeDVAxadtvbMojJnhdfmM)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new mXUfdaoyjRGkvVXXXIvSOTSXwoOG(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			hZvgWRfRpVIxLMJXChmZXfUxKExjb[FvBlHgZBgNGJIlIcUmIZOCNnZWVu].Add(item);
		}
		else
		{
			hZvgWRfRpVIxLMJXChmZXfUxKExjb[zpsWjYpGqKPDEBZXWblAJDVixXgR[P_3]].Add(item);
		}
		MZdWRhSylhVPHqxOZxnraVKuwnWf();
	}

	public void wKasYrvMczYUldqoKZRAbQdSPLxG(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			DUWCAIAcjVMvyKJUQDLPZPhXuXxl();
		}
		mXUfdaoyjRGkvVXXXIvSOTSXwoOG item;
		try
		{
			item = new mXUfdaoyjRGkvVXXXIvSOTSXwoOG(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		hZvgWRfRpVIxLMJXChmZXfUxKExjb[FvBlHgZBgNGJIlIcUmIZOCNnZWVu].Add(item);
		MZdWRhSylhVPHqxOZxnraVKuwnWf();
	}

	public void heiGzYotuBgUHMLuokWCNJFoQsHc(Action<InputActionEventData> P_0)
	{
		ucYINcmfIiUqfDZQyAALewmkQaBK ucYINcmfIiUqfDZQyAALewmkQaBK2 = new ucYINcmfIiUqfDZQyAALewmkQaBK();
		ucYINcmfIiUqfDZQyAALewmkQaBK2.zcDQaHQPDgPLzkeFyJZeGTHXfnbN = P_0;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(ucYINcmfIiUqfDZQyAALewmkQaBK2.OwBAEZEeHlXCVjFCHLurtLTahhMFb);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void laZBFwhAUJiEdXiRYceCSwvKUGIeA(Action<InputActionEventData> P_0, int P_1)
	{
		LXBeFLetMzCNCuOPTncSYXVuVMqlA lXBeFLetMzCNCuOPTncSYXVuVMqlA = new LXBeFLetMzCNCuOPTncSYXVuVMqlA();
		lXBeFLetMzCNCuOPTncSYXVuVMqlA.aqZdbgTPpplsutPnifdUJnzVoDzB = P_0;
		lXBeFLetMzCNCuOPTncSYXVuVMqlA.yWAOEluKpNvMVMZTqHslyoHXcDUP = P_1;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu && lXBeFLetMzCNCuOPTncSYXVuVMqlA.yWAOEluKpNvMVMZTqHslyoHXcDUP <= ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.echKJcMQeDVAxadtvbMojJnhdfmM)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(lXBeFLetMzCNCuOPTncSYXVuVMqlA.vHeMBTNKkVWhPDhaXjRrgWfqxCjPA);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void zePRzIvQZHWyTVBgYINyDBdRXclc(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		iQcNdrbwoafRvsVtluUOfTpWlLtv iQcNdrbwoafRvsVtluUOfTpWlLtv2 = new iQcNdrbwoafRvsVtluUOfTpWlLtv();
		iQcNdrbwoafRvsVtluUOfTpWlLtv2.YxxlWVeFoTUxRRoHWoclzaVmbHpjA = P_0;
		iQcNdrbwoafRvsVtluUOfTpWlLtv2.OzZbluTXaKFbIGyMdVHQFjDjCieFb = P_1;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(iQcNdrbwoafRvsVtluUOfTpWlLtv2.isNyomJeJFRAbGTSAqMoRgQipXeN);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void opjdqTebTMptPGWAYFgxaQQjSVRZA(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		quEsaQFkDbZvdCQYiNoAjVewsRMG quEsaQFkDbZvdCQYiNoAjVewsRMG2 = new quEsaQFkDbZvdCQYiNoAjVewsRMG();
		quEsaQFkDbZvdCQYiNoAjVewsRMG2.tlyQXWNoRUBPVERKwjtbDgdVErpZ = P_0;
		quEsaQFkDbZvdCQYiNoAjVewsRMG2.HMGBsMIRIkIZDbsJALAzjPkavMHMD = P_1;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(quEsaQFkDbZvdCQYiNoAjVewsRMG2.MpxINAIPjSbYtVyFCLpmZnvNUoRi);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void gtLUndzKbIRAcYPFXdhXgkmyuOQC(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		wUFrpuFHsTgvLNXqvSfxqTcrhViN wUFrpuFHsTgvLNXqvSfxqTcrhViN2 = new wUFrpuFHsTgvLNXqvSfxqTcrhViN();
		wUFrpuFHsTgvLNXqvSfxqTcrhViN2.uxmnpXExMlUdXpTdUWPBbaJmUXvs = P_0;
		wUFrpuFHsTgvLNXqvSfxqTcrhViN2.PliSaEfxEzGHqqrUQLatTQgfcrUn = P_1;
		wUFrpuFHsTgvLNXqvSfxqTcrhViN2.RTxfWTVfPmfjVeoWyBzvstYAEIVib = P_2;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu && wUFrpuFHsTgvLNXqvSfxqTcrhViN2.RTxfWTVfPmfjVeoWyBzvstYAEIVib <= ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.echKJcMQeDVAxadtvbMojJnhdfmM)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(wUFrpuFHsTgvLNXqvSfxqTcrhViN2.XXoVhVadfguSVoAltwEkTqVqeqoHA);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void uqBHIcrfNCudZpVruNfnQdnacDpY(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		bLKbZAvyXolrKTFxVefBBHDKDLrJ bLKbZAvyXolrKTFxVefBBHDKDLrJ2 = new bLKbZAvyXolrKTFxVefBBHDKDLrJ();
		bLKbZAvyXolrKTFxVefBBHDKDLrJ2.pAKoeCbxkbRsByVEOBqPXjNJKAVd = P_0;
		bLKbZAvyXolrKTFxVefBBHDKDLrJ2.iQGeTptkScNznNBgJBSDibBpRbKsA = P_1;
		bLKbZAvyXolrKTFxVefBBHDKDLrJ2.MnsDbKKcDGcdtQFHeHryaTcHqYLpb = P_3;
		bLKbZAvyXolrKTFxVefBBHDKDLrJ2.dPyistgUyNVQpSVtGuAPJksCrsYA = P_2;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu && bLKbZAvyXolrKTFxVefBBHDKDLrJ2.MnsDbKKcDGcdtQFHeHryaTcHqYLpb <= ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.echKJcMQeDVAxadtvbMojJnhdfmM)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(bLKbZAvyXolrKTFxVefBBHDKDLrJ2.pDXjAlWCYfzCOjebwqagwekTvjSF);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void CWfKtmUxDjJeTOhlTsbWYiBSEVOF(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		QIcCXnzwTGXoOEwJdwIcPfZDMhzE qIcCXnzwTGXoOEwJdwIcPfZDMhzE = new QIcCXnzwTGXoOEwJdwIcPfZDMhzE();
		qIcCXnzwTGXoOEwJdwIcPfZDMhzE.xAALDvIiTqpyzWEhblGDmBJiZytA = P_0;
		qIcCXnzwTGXoOEwJdwIcPfZDMhzE.YHjDgLfyBLdrrfLDVtBMvNaZSetvA = P_1;
		qIcCXnzwTGXoOEwJdwIcPfZDMhzE.nymnhPwzIZcACpimWaJMjkwevtHFA = P_2;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(qIcCXnzwTGXoOEwJdwIcPfZDMhzE.GBwfnDESxiGzXWEYexilkBJYZLaR);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void SiYsIRSVSpLzxXZJLbLqXnFkAAJBA(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		blrtxvvyLGWAHeaLbMaMDxwqTMIV blrtxvvyLGWAHeaLbMaMDxwqTMIV2 = new blrtxvvyLGWAHeaLbMaMDxwqTMIV();
		blrtxvvyLGWAHeaLbMaMDxwqTMIV2.AFHyOQNdcArOFIbhTJgRlyfZWTBg = P_0;
		blrtxvvyLGWAHeaLbMaMDxwqTMIV2.mzQRFWcqDtFIFKDBLgANzQqMWJXT = P_2;
		blrtxvvyLGWAHeaLbMaMDxwqTMIV2.tvjuqHmjInGgxiwTbHXYChjZiMlj = P_1;
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu && blrtxvvyLGWAHeaLbMaMDxwqTMIV2.mzQRFWcqDtFIFKDBLgANzQqMWJXT <= ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.echKJcMQeDVAxadtvbMojJnhdfmM)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(blrtxvvyLGWAHeaLbMaMDxwqTMIV2.cYTmlJDxTABfubKzGOvaihqTlFTp);
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	public void ZpkTOvlNFIGDxqziVygJQiZdffDN()
	{
		if (jbwLyqdFXMUiFutjTtEYUrmsjogu)
		{
			AList<mXUfdaoyjRGkvVXXXIvSOTSXwoOG>[] array = hZvgWRfRpVIxLMJXChmZXfUxKExjb;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			MZdWRhSylhVPHqxOZxnraVKuwnWf();
		}
	}

	private void MZdWRhSylhVPHqxOZxnraVKuwnWf()
	{
		int num = 0;
		for (int i = 0; i < hZvgWRfRpVIxLMJXChmZXfUxKExjb.Length; i++)
		{
			num += hZvgWRfRpVIxLMJXChmZXfUxKExjb[i]._count;
		}
		uskholhiOMnSsgUISoyhlEFbhHiAA = num;
	}
}
