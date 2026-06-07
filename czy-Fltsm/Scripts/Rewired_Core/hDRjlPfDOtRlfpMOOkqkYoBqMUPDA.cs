using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class hDRjlPfDOtRlfpMOOkqkYoBqMUPDA
{
	public class ZDLNsKAyinCTqKRVptpkFiYedeDkA
	{
		private class GCbgIELOPiCbhHSYdaKmUJhZpMiH : ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH>.RTEloVsLIxBnlmgnydAWcQJpbcvv, IComparable<GCbgIELOPiCbhHSYdaKmUJhZpMiH>
		{
			public KeyboardKeyCode CMcpsMavefBIivwFPezikKLhpSzi;

			public ModifierKeyFlags ZFGqhImRZbOZofRyQENKnBzhpzrn;

			public void xyipSRJeZKfBfSIAoZwzebNRftem(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				CMcpsMavefBIivwFPezikKLhpSzi = P_0;
				ZFGqhImRZbOZofRyQENKnBzhpzrn = P_1;
			}

			public void WQDnHbGGAElhjGqicVbQjfwlsyOe(GCbgIELOPiCbhHSYdaKmUJhZpMiH P_0)
			{
				CMcpsMavefBIivwFPezikKLhpSzi = P_0.CMcpsMavefBIivwFPezikKLhpSzi;
				ZFGqhImRZbOZofRyQENKnBzhpzrn = P_0.ZFGqhImRZbOZofRyQENKnBzhpzrn;
			}

			void ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH>.RTEloVsLIxBnlmgnydAWcQJpbcvv.DhWbxtCnVdbWhhlTnEwXftzdcZvEc(GCbgIELOPiCbhHSYdaKmUJhZpMiH P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in WQDnHbGGAElhjGqicVbQjfwlsyOe
				this.WQDnHbGGAElhjGqicVbQjfwlsyOe(P_0);
			}

			public bool EeiGYhcNOfnApaEqAiFrxUtqHCmLB(GCbgIELOPiCbhHSYdaKmUJhZpMiH P_0)
			{
				if (CMcpsMavefBIivwFPezikKLhpSzi == P_0.CMcpsMavefBIivwFPezikKLhpSzi && ZFGqhImRZbOZofRyQENKnBzhpzrn == P_0.ZFGqhImRZbOZofRyQENKnBzhpzrn)
				{
					return true;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH>.RTEloVsLIxBnlmgnydAWcQJpbcvv.KvxmGyafWWPVvqJpAvlxzoNLtLLt(GCbgIELOPiCbhHSYdaKmUJhZpMiH P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in EeiGYhcNOfnApaEqAiFrxUtqHCmLB
				return this.EeiGYhcNOfnApaEqAiFrxUtqHCmLB(P_0);
			}

			public void eluBGzcThNVgKGohiKBZKxRrjMKbA()
			{
				CMcpsMavefBIivwFPezikKLhpSzi = KeyboardKeyCode.None;
				ZFGqhImRZbOZofRyQENKnBzhpzrn = ModifierKeyFlags.None;
			}

			void ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH>.RTEloVsLIxBnlmgnydAWcQJpbcvv.aEOVnwwqDJMFXPmsMEqAGDVqEgWbb()
			{
				//ILSpy generated this explicit interface implementation from .override directive in eluBGzcThNVgKGohiKBZKxRrjMKbA
				this.eluBGzcThNVgKGohiKBZKxRrjMKbA();
			}

			public int CompareTo(GCbgIELOPiCbhHSYdaKmUJhZpMiH other)
			{
				return 0;
			}

			int IComparable<GCbgIELOPiCbhHSYdaKmUJhZpMiH>.CompareTo(GCbgIELOPiCbhHSYdaKmUJhZpMiH other)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CompareTo
				return this.CompareTo(other);
			}
		}

		private enum pvVqTBdKFZbmGJZfHqgVABOqPKPbb
		{
			Map = 0,
			ActiveSet = 1
		}

		private ModifierKeyFlags kMYArxojincaneRjCJfMgvXTEWUB;

		private ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH> bbDjvwgjNpSbLYTqsbihUSlUAIPz;

		private ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH> GBZaPkdkyBNtqQSxRqVrEETJhXUKb;

		private Keyboard vXeLEflrlDtUznpAHoMTqLieHZSgA;

		public ZDLNsKAyinCTqKRVptpkFiYedeDkA(Keyboard P_0)
		{
			vXeLEflrlDtUznpAHoMTqLieHZSgA = P_0;
			kMYArxojincaneRjCJfMgvXTEWUB = ModifierKeyFlags.None;
			bbDjvwgjNpSbLYTqsbihUSlUAIPz = new ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH>(132, false, 132);
			GBZaPkdkyBNtqQSxRqVrEETJhXUKb = new ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH>(5, false, 5);
		}

		public void BjVJrpvtDfgEucEOysueFACKjoKr()
		{
			kMYArxojincaneRjCJfMgvXTEWUB = ModifierKeyFlags.None;
			bbDjvwgjNpSbLYTqsbihUSlUAIPz.Clear();
			for (int num = GBZaPkdkyBNtqQSxRqVrEETJhXUKb.Length - 1; num >= 0; num--)
			{
				GCbgIELOPiCbhHSYdaKmUJhZpMiH gCbgIELOPiCbhHSYdaKmUJhZpMiH = GBZaPkdkyBNtqQSxRqVrEETJhXUKb[num];
				if (!vXeLEflrlDtUznpAHoMTqLieHZSgA.qvuGyewCFSjJvIbZGJIqlXpNmFcX(gCbgIELOPiCbhHSYdaKmUJhZpMiH.CMcpsMavefBIivwFPezikKLhpSzi))
				{
					GBZaPkdkyBNtqQSxRqVrEETJhXUKb.RemoveAt(num);
				}
			}
		}

		public void oXcFmwsBVCbaHLtBojMGJPiVCOzY(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				kMYArxojincaneRjCJfMgvXTEWUB |= P_0.modifierKeyFlags;
				bbDjvwgjNpSbLYTqsbihUSlUAIPz.injector.xyipSRJeZKfBfSIAoZwzebNRftem(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
				bbDjvwgjNpSbLYTqsbihUSlUAIPz.Inject();
			}
		}

		public bool bWDLEMwgSffZNAugZpkNPsEgMOqk(KeyboardKeyCode P_0, ModifierKeyFlags P_1, GPNEdVBuhanaiWVCDlGZFxWBuBir P_2, out bool P_3)
		{
			P_3 = false;
			if (kMYArxojincaneRjCJfMgvXTEWUB == ModifierKeyFlags.None && P_1 == ModifierKeyFlags.None)
			{
				return false;
			}
			int num = Keyboard.fDGfbsBGVPECuAvsJWvzHxAKnsWk(P_1);
			if (TvPQohdAtPMHFGBPBkDEDuTGguJD(bbDjvwgjNpSbLYTqsbihUSlUAIPz, P_0, P_1, num, pvVqTBdKFZbmGJZfHqgVABOqPKPbb.Map, P_2, ref P_3))
			{
				return true;
			}
			if (TvPQohdAtPMHFGBPBkDEDuTGguJD(GBZaPkdkyBNtqQSxRqVrEETJhXUKb, P_0, P_1, num, pvVqTBdKFZbmGJZfHqgVABOqPKPbb.ActiveSet, P_2, ref P_3))
			{
				return true;
			}
			return false;
		}

		private bool TvPQohdAtPMHFGBPBkDEDuTGguJD(ExpandableArray_DataContainer<GCbgIELOPiCbhHSYdaKmUJhZpMiH> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, pvVqTBdKFZbmGJZfHqgVABOqPKPbb P_4, GPNEdVBuhanaiWVCDlGZFxWBuBir P_5, ref bool P_6)
		{
			bool flag = Keyboard.YoFsTSELTmwdKYqdbKbSJjvlMyoA(P_1);
			int length = P_0.Length;
			for (int i = 0; i < length; i++)
			{
				GCbgIELOPiCbhHSYdaKmUJhZpMiH gCbgIELOPiCbhHSYdaKmUJhZpMiH = P_0[i];
				bool flag2 = gCbgIELOPiCbhHSYdaKmUJhZpMiH.CMcpsMavefBIivwFPezikKLhpSzi == P_1;
				if ((flag2 && gCbgIELOPiCbhHSYdaKmUJhZpMiH.ZFGqhImRZbOZofRyQENKnBzhpzrn == P_2) || (!flag2 && !Keyboard.ModifierKeyFlagsContain(gCbgIELOPiCbhHSYdaKmUJhZpMiH.ZFGqhImRZbOZofRyQENKnBzhpzrn, (KeyCode)P_1) && !MathTools.YxebIRhuPpYsoBotXPtKJBjVwYOc((int)gCbgIELOPiCbhHSYdaKmUJhZpMiH.ZFGqhImRZbOZofRyQENKnBzhpzrn, (int)P_2)))
				{
					continue;
				}
				if (!P_6)
				{
					P_6 = true;
				}
				if ((!flag && gCbgIELOPiCbhHSYdaKmUJhZpMiH.CMcpsMavefBIivwFPezikKLhpSzi != P_1) || Keyboard.fDGfbsBGVPECuAvsJWvzHxAKnsWk(gCbgIELOPiCbhHSYdaKmUJhZpMiH.ZFGqhImRZbOZofRyQENKnBzhpzrn) <= P_3)
				{
					continue;
				}
				bool flag3 = P_4 != pvVqTBdKFZbmGJZfHqgVABOqPKPbb.Map || vXeLEflrlDtUznpAHoMTqLieHZSgA.qqdvAhHPNsZIohampAoagYdZvzxD(gCbgIELOPiCbhHSYdaKmUJhZpMiH.CMcpsMavefBIivwFPezikKLhpSzi, gCbgIELOPiCbhHSYdaKmUJhZpMiH.ZFGqhImRZbOZofRyQENKnBzhpzrn);
				switch (P_5)
				{
				case GPNEdVBuhanaiWVCDlGZFxWBuBir.Normal:
					return flag3;
				case GPNEdVBuhanaiWVCDlGZFxWBuBir.OverlapModifiers:
					if (P_2 == ModifierKeyFlags.None)
					{
						if (flag3 && P_1 == gCbgIELOPiCbhHSYdaKmUJhZpMiH.CMcpsMavefBIivwFPezikKLhpSzi)
						{
							return true;
						}
						break;
					}
					return flag3;
				}
			}
			return false;
		}

		public void sCIaFsIjcfyTmuHPfxSamxImvFdK(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (P_1 != ModifierKeyFlags.None)
			{
				GBZaPkdkyBNtqQSxRqVrEETJhXUKb.injector.xyipSRJeZKfBfSIAoZwzebNRftem(P_0, P_1);
				GBZaPkdkyBNtqQSxRqVrEETJhXUKb.InjectIfUnique();
			}
		}

		public void PJuoXRMOvEHVFZjaPaYxwkVoouys()
		{
			kMYArxojincaneRjCJfMgvXTEWUB = ModifierKeyFlags.None;
			bbDjvwgjNpSbLYTqsbihUSlUAIPz.Clear();
			GBZaPkdkyBNtqQSxRqVrEETJhXUKb.Clear();
		}
	}

	public enum GPNEdVBuhanaiWVCDlGZFxWBuBir
	{
		Normal = 0,
		OverlapModifiers = 1
	}

	private readonly ZDLNsKAyinCTqKRVptpkFiYedeDkA[] YflilNHfGsJXwmWuuSvchTiGYNlFA;

	private UpdateLoopType wjshvncjkDnTaAUrfBfxUBYeLClC;

	private readonly Keyboard ZDqHpnKBmdWcxnaSIDZhAcTrEpOPA;

	private ZDLNsKAyinCTqKRVptpkFiYedeDkA YBdYqWCQuNBMwyyeZDMHTpBuwKMq;

	public hDRjlPfDOtRlfpMOOkqkYoBqMUPDA(UpdateLoopSetting P_0, Keyboard P_1)
	{
		ZDqHpnKBmdWcxnaSIDZhAcTrEpOPA = P_1;
		YflilNHfGsJXwmWuuSvchTiGYNlFA = new ZDLNsKAyinCTqKRVptpkFiYedeDkA[3];
		int num = 0;
		using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
		List<UpdateLoopType> list = tList.list;
		EnumConverter.ToUpdateLoopTypes(P_0, list);
		for (int i = 0; i < list.Count; i++)
		{
			ZDLNsKAyinCTqKRVptpkFiYedeDkA zDLNsKAyinCTqKRVptpkFiYedeDkA = new ZDLNsKAyinCTqKRVptpkFiYedeDkA(P_1);
			YflilNHfGsJXwmWuuSvchTiGYNlFA[(int)list[i]] = zDLNsKAyinCTqKRVptpkFiYedeDkA;
			num++;
			if (num == 1)
			{
				YBdYqWCQuNBMwyyeZDMHTpBuwKMq = zDLNsKAyinCTqKRVptpkFiYedeDkA;
			}
		}
	}

	public void PBIHfiikorHibkYrToyfflNCXOwI(UpdateLoopType P_0)
	{
		if (wjshvncjkDnTaAUrfBfxUBYeLClC != P_0)
		{
			wjshvncjkDnTaAUrfBfxUBYeLClC = P_0;
			YBdYqWCQuNBMwyyeZDMHTpBuwKMq = YflilNHfGsJXwmWuuSvchTiGYNlFA[(int)P_0];
		}
		YBdYqWCQuNBMwyyeZDMHTpBuwKMq.BjVJrpvtDfgEucEOysueFACKjoKr();
	}

	public void EsBeoLbmYUztEahrlZfOLFnjFYuhA(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		AList<ActionElementMap> aList = P_0.OurlyxeFzWBnIptcmgMKsPUxiwjO;
		int count = aList._count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = aList._items[i];
			if (actionElementMap.hasModifiers)
			{
				YBdYqWCQuNBMwyyeZDMHTpBuwKMq.oXcFmwsBVCbaHLtBojMGJPiVCOzY(actionElementMap);
			}
		}
	}

	public bool XOMztahPytDHXYdiiONMPUglMfIN(KeyboardKeyCode P_0, ModifierKeyFlags P_1, GPNEdVBuhanaiWVCDlGZFxWBuBir P_2, out bool P_3)
	{
		return YBdYqWCQuNBMwyyeZDMHTpBuwKMq.bWDLEMwgSffZNAugZpkNPsEgMOqk(P_0, P_1, P_2, out P_3);
	}

	public void iBxkGUQTfciyHIQJlpMouAvSXJsn(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		YBdYqWCQuNBMwyyeZDMHTpBuwKMq.sCIaFsIjcfyTmuHPfxSamxImvFdK(P_0, P_1);
	}

	public void gKONPLUsedyHqxfnAohSzTqtkBhk()
	{
		for (int i = 0; i < YflilNHfGsJXwmWuuSvchTiGYNlFA.Length; i++)
		{
			if (YflilNHfGsJXwmWuuSvchTiGYNlFA[i] != null)
			{
				YflilNHfGsJXwmWuuSvchTiGYNlFA[i].PJuoXRMOvEHVFZjaPaYxwkVoouys();
			}
		}
	}
}
