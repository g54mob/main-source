using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class rACoEbOYRqZwIwjFrZCMRTeoChil
{
	public class LYjnoLbksjOLmQMAISUoxwcaEyC
	{
		private class OikZnaSSYjtcEbvXKTPYdCKVJxHq : ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq>.TVBgovhjLayvQrOmBMxqiXsndkMlA, IComparable<OikZnaSSYjtcEbvXKTPYdCKVJxHq>
		{
			public KeyboardKeyCode CszBcoGvfeGrZYPWeNLMfPyjVzIiA;

			public ModifierKeyFlags RaVwkanEKkhSVLzQfiOwOCevtDQh;

			public void lBfKenCJOLoPSimXZYkHVUgLtnVs(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				CszBcoGvfeGrZYPWeNLMfPyjVzIiA = P_0;
				RaVwkanEKkhSVLzQfiOwOCevtDQh = P_1;
			}

			public void KtGRizRiLXjZEafrHrwsQaCpSofW(OikZnaSSYjtcEbvXKTPYdCKVJxHq P_0)
			{
				CszBcoGvfeGrZYPWeNLMfPyjVzIiA = P_0.CszBcoGvfeGrZYPWeNLMfPyjVzIiA;
				RaVwkanEKkhSVLzQfiOwOCevtDQh = P_0.RaVwkanEKkhSVLzQfiOwOCevtDQh;
			}

			void ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq>.TVBgovhjLayvQrOmBMxqiXsndkMlA.VbTqOFRLGqiIOJyOYDrdMAAkHrCj(OikZnaSSYjtcEbvXKTPYdCKVJxHq P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in KtGRizRiLXjZEafrHrwsQaCpSofW
				this.KtGRizRiLXjZEafrHrwsQaCpSofW(P_0);
			}

			public bool GzhXDPKfPysTQibxLhoRxKWVQYVV(OikZnaSSYjtcEbvXKTPYdCKVJxHq P_0)
			{
				if (CszBcoGvfeGrZYPWeNLMfPyjVzIiA == P_0.CszBcoGvfeGrZYPWeNLMfPyjVzIiA && RaVwkanEKkhSVLzQfiOwOCevtDQh == P_0.RaVwkanEKkhSVLzQfiOwOCevtDQh)
				{
					return true;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq>.TVBgovhjLayvQrOmBMxqiXsndkMlA.QgkDGSvRNRxKxMuMbYBjOcyJRoub(OikZnaSSYjtcEbvXKTPYdCKVJxHq P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GzhXDPKfPysTQibxLhoRxKWVQYVV
				return this.GzhXDPKfPysTQibxLhoRxKWVQYVV(P_0);
			}

			public void wwjHiVQniQMJdWKyLqfpMOujAuvI()
			{
				CszBcoGvfeGrZYPWeNLMfPyjVzIiA = KeyboardKeyCode.None;
				RaVwkanEKkhSVLzQfiOwOCevtDQh = ModifierKeyFlags.None;
			}

			void ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq>.TVBgovhjLayvQrOmBMxqiXsndkMlA.wDPkJYfYYWdMcbWjbRouiAosDabW()
			{
				//ILSpy generated this explicit interface implementation from .override directive in wwjHiVQniQMJdWKyLqfpMOujAuvI
				this.wwjHiVQniQMJdWKyLqfpMOujAuvI();
			}

			public int CompareTo(OikZnaSSYjtcEbvXKTPYdCKVJxHq other)
			{
				return 0;
			}

			int IComparable<OikZnaSSYjtcEbvXKTPYdCKVJxHq>.CompareTo(OikZnaSSYjtcEbvXKTPYdCKVJxHq other)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CompareTo
				return this.CompareTo(other);
			}
		}

		private enum zeTVskWhwrcfigAptACmvYnFRHXpA
		{
			Map = 0,
			ActiveSet = 1
		}

		private ModifierKeyFlags eRDmHPhUwwpQNSWYpbiRXUWBiGnv;

		private ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq> diKadIceEibNocolBcXDlXSQtYot;

		private ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq> SaQBMQbkvWzRRmjymSyFfAylLghk;

		private Keyboard bzXURuAuUoWGFiDoEbbVhTkNNbQ;

		public LYjnoLbksjOLmQMAISUoxwcaEyC(Keyboard P_0)
		{
			bzXURuAuUoWGFiDoEbbVhTkNNbQ = P_0;
			eRDmHPhUwwpQNSWYpbiRXUWBiGnv = ModifierKeyFlags.None;
			diKadIceEibNocolBcXDlXSQtYot = new ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq>(132, false, 132);
			SaQBMQbkvWzRRmjymSyFfAylLghk = new ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq>(5, false, 5);
		}

		public void TyGcKDexMkXYLYuFDaNYcVhWBynU()
		{
			eRDmHPhUwwpQNSWYpbiRXUWBiGnv = ModifierKeyFlags.None;
			diKadIceEibNocolBcXDlXSQtYot.Clear();
			for (int num = SaQBMQbkvWzRRmjymSyFfAylLghk.Length - 1; num >= 0; num--)
			{
				OikZnaSSYjtcEbvXKTPYdCKVJxHq oikZnaSSYjtcEbvXKTPYdCKVJxHq = SaQBMQbkvWzRRmjymSyFfAylLghk[num];
				if (!bzXURuAuUoWGFiDoEbbVhTkNNbQ.orxplOtEWPddMakCbleQKnOLNaTJ(oikZnaSSYjtcEbvXKTPYdCKVJxHq.CszBcoGvfeGrZYPWeNLMfPyjVzIiA))
				{
					SaQBMQbkvWzRRmjymSyFfAylLghk.RemoveAt(num);
				}
			}
		}

		public void yKjTYObqKRSGatuKXJbkebJPLAWv(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				eRDmHPhUwwpQNSWYpbiRXUWBiGnv |= P_0.modifierKeyFlags;
				diKadIceEibNocolBcXDlXSQtYot.injector.lBfKenCJOLoPSimXZYkHVUgLtnVs(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
				diKadIceEibNocolBcXDlXSQtYot.Inject();
			}
		}

		public bool afnNtrvZrWbMpUbcoOdtbneXxBrd(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (eRDmHPhUwwpQNSWYpbiRXUWBiGnv == ModifierKeyFlags.None && P_1 == ModifierKeyFlags.None)
			{
				return false;
			}
			int num = Keyboard.hZJmtIKQvYcSDwdkaSaHsdlKdnUc(P_1);
			if (fgPvvsmEsWdpzaRmhjZMFwmlyEjFA(diKadIceEibNocolBcXDlXSQtYot, P_0, P_1, num, zeTVskWhwrcfigAptACmvYnFRHXpA.Map))
			{
				return true;
			}
			if (fgPvvsmEsWdpzaRmhjZMFwmlyEjFA(SaQBMQbkvWzRRmjymSyFfAylLghk, P_0, P_1, num, zeTVskWhwrcfigAptACmvYnFRHXpA.ActiveSet))
			{
				return true;
			}
			if (P_1 != ModifierKeyFlags.None)
			{
				SaQBMQbkvWzRRmjymSyFfAylLghk.injector.lBfKenCJOLoPSimXZYkHVUgLtnVs(P_0, P_1);
				SaQBMQbkvWzRRmjymSyFfAylLghk.InjectIfUnique();
			}
			return false;
		}

		private bool fgPvvsmEsWdpzaRmhjZMFwmlyEjFA(ExpandableArray_DataContainer<OikZnaSSYjtcEbvXKTPYdCKVJxHq> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, zeTVskWhwrcfigAptACmvYnFRHXpA P_4)
		{
			bool flag = Keyboard.SkfNhnJOGYVGCgQtCFzBiaMxvERy(P_1);
			int length = P_0.Length;
			for (int i = 0; i < length; i++)
			{
				OikZnaSSYjtcEbvXKTPYdCKVJxHq oikZnaSSYjtcEbvXKTPYdCKVJxHq = P_0[i];
				bool flag2 = oikZnaSSYjtcEbvXKTPYdCKVJxHq.CszBcoGvfeGrZYPWeNLMfPyjVzIiA == P_1;
				if ((!flag2 || oikZnaSSYjtcEbvXKTPYdCKVJxHq.RaVwkanEKkhSVLzQfiOwOCevtDQh != P_2) && (flag2 || Keyboard.ModifierKeyFlagsContain(oikZnaSSYjtcEbvXKTPYdCKVJxHq.RaVwkanEKkhSVLzQfiOwOCevtDQh, (KeyCode)P_1) || MathTools.KarteyoMnieaRjchgcgZkowBduppA((int)oikZnaSSYjtcEbvXKTPYdCKVJxHq.RaVwkanEKkhSVLzQfiOwOCevtDQh, (int)P_2)) && (flag || oikZnaSSYjtcEbvXKTPYdCKVJxHq.CszBcoGvfeGrZYPWeNLMfPyjVzIiA == P_1) && Keyboard.hZJmtIKQvYcSDwdkaSaHsdlKdnUc(oikZnaSSYjtcEbvXKTPYdCKVJxHq.RaVwkanEKkhSVLzQfiOwOCevtDQh) > P_3)
				{
					if (P_4 != zeTVskWhwrcfigAptACmvYnFRHXpA.Map)
					{
						return true;
					}
					if (bzXURuAuUoWGFiDoEbbVhTkNNbQ.yVcNqBAEUxlpRZSbUhvGHtzNLxSO(oikZnaSSYjtcEbvXKTPYdCKVJxHq.CszBcoGvfeGrZYPWeNLMfPyjVzIiA, oikZnaSSYjtcEbvXKTPYdCKVJxHq.RaVwkanEKkhSVLzQfiOwOCevtDQh))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void RteIvqXaBDhwYdrejfDNNkugcFlA()
		{
			eRDmHPhUwwpQNSWYpbiRXUWBiGnv = ModifierKeyFlags.None;
			diKadIceEibNocolBcXDlXSQtYot.Clear();
			SaQBMQbkvWzRRmjymSyFfAylLghk.Clear();
		}
	}

	private readonly LYjnoLbksjOLmQMAISUoxwcaEyC[] ICkcxdaMDttxPeunJCESuzVKFUYi;

	private UpdateLoopType ynrDsDzkoSoLHilXKkkTpXiqeVGN;

	private readonly Keyboard HCxasDZxByEpMJPPhyBNPEkztCvi;

	private LYjnoLbksjOLmQMAISUoxwcaEyC YyaCtsPFhGwgFQxjmdnlaeekpUpT;

	public rACoEbOYRqZwIwjFrZCMRTeoChil(UpdateLoopSetting P_0, Keyboard P_1)
	{
		HCxasDZxByEpMJPPhyBNPEkztCvi = P_1;
		ICkcxdaMDttxPeunJCESuzVKFUYi = new LYjnoLbksjOLmQMAISUoxwcaEyC[3];
		int num = 0;
		using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
		List<UpdateLoopType> list = tList.list;
		EnumConverter.ToUpdateLoopTypes(P_0, list);
		for (int i = 0; i < list.Count; i++)
		{
			LYjnoLbksjOLmQMAISUoxwcaEyC lYjnoLbksjOLmQMAISUoxwcaEyC = new LYjnoLbksjOLmQMAISUoxwcaEyC(P_1);
			ICkcxdaMDttxPeunJCESuzVKFUYi[(int)list[i]] = lYjnoLbksjOLmQMAISUoxwcaEyC;
			num++;
			if (num == 1)
			{
				YyaCtsPFhGwgFQxjmdnlaeekpUpT = lYjnoLbksjOLmQMAISUoxwcaEyC;
			}
		}
	}

	public void HfFfKYfjfkrxWQimaWRBYZeGaHNp(UpdateLoopType P_0)
	{
		if (ynrDsDzkoSoLHilXKkkTpXiqeVGN != P_0)
		{
			ynrDsDzkoSoLHilXKkkTpXiqeVGN = P_0;
			YyaCtsPFhGwgFQxjmdnlaeekpUpT = ICkcxdaMDttxPeunJCESuzVKFUYi[(int)P_0];
		}
		YyaCtsPFhGwgFQxjmdnlaeekpUpT.TyGcKDexMkXYLYuFDaNYcVhWBynU();
	}

	public void QEOvXbgTvRVAfGsNSUsokGWfQeZc(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		AList<ActionElementMap> aList = P_0.OEydHsjiiTRjhFtrBfeqPfyluIMc;
		int count = aList._count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = aList._items[i];
			if (actionElementMap.hasModifiers)
			{
				YyaCtsPFhGwgFQxjmdnlaeekpUpT.yKjTYObqKRSGatuKXJbkebJPLAWv(actionElementMap);
			}
		}
	}

	public bool SQPMkVXXuMMCRToVuxpmOxmjpipw(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		return YyaCtsPFhGwgFQxjmdnlaeekpUpT.afnNtrvZrWbMpUbcoOdtbneXxBrd(P_0, P_1);
	}

	public void yLHGEbNaloqILZDsnNDiMnLjpeES()
	{
		for (int i = 0; i < ICkcxdaMDttxPeunJCESuzVKFUYi.Length; i++)
		{
			if (ICkcxdaMDttxPeunJCESuzVKFUYi[i] != null)
			{
				ICkcxdaMDttxPeunJCESuzVKFUYi[i].RteIvqXaBDhwYdrejfDNNkugcFlA();
			}
		}
	}
}
