using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class qhdGsmuaRZPOXBEZmmGhxzHSRVAx
{
	public class tbscsWMgeeRPOpQBWjTWuQuNXvMi
	{
		private class paFfPpSqeszHiebYrqFYkloPJUGh : ExpandableArray_DataContainer<paFfPpSqeszHiebYrqFYkloPJUGh>.UIocpiFNPBabRvfmEalBxiNHxOkJ, IComparable<paFfPpSqeszHiebYrqFYkloPJUGh>
		{
			public KeyboardKeyCode EqHcpXWaGauOvKqzuxjiUENyiiKN;

			public ModifierKeyFlags LIbcgZDIOipcppxNicnRCgolrvLFA;

			public void wktKiMTzgPuXyJzmAQdgBslXzykH(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				EqHcpXWaGauOvKqzuxjiUENyiiKN = P_0;
				LIbcgZDIOipcppxNicnRCgolrvLFA = P_1;
			}

			public void Set(paFfPpSqeszHiebYrqFYkloPJUGh P_0)
			{
				EqHcpXWaGauOvKqzuxjiUENyiiKN = P_0.EqHcpXWaGauOvKqzuxjiUENyiiKN;
				LIbcgZDIOipcppxNicnRCgolrvLFA = P_0.LIbcgZDIOipcppxNicnRCgolrvLFA;
			}

			public bool Equals(paFfPpSqeszHiebYrqFYkloPJUGh P_0)
			{
				if (EqHcpXWaGauOvKqzuxjiUENyiiKN == P_0.EqHcpXWaGauOvKqzuxjiUENyiiKN && LIbcgZDIOipcppxNicnRCgolrvLFA == P_0.LIbcgZDIOipcppxNicnRCgolrvLFA)
				{
					return true;
				}
				return false;
			}

			public void Clear()
			{
				EqHcpXWaGauOvKqzuxjiUENyiiKN = KeyboardKeyCode.None;
				LIbcgZDIOipcppxNicnRCgolrvLFA = ModifierKeyFlags.None;
			}

			public int CompareTo(paFfPpSqeszHiebYrqFYkloPJUGh other)
			{
				return 0;
			}
		}

		private enum GSpzmWgNEJOmeBXGBafyAeHdazhR
		{
			Map = 0,
			ActiveSet = 1
		}

		private ModifierKeyFlags yWzCjuehqrFDKhBcpEeatuGwKIKyA;

		private ExpandableArray_DataContainer<paFfPpSqeszHiebYrqFYkloPJUGh> rKXUEWaeoZbtCFViKvdcRartpHAJb;

		private ExpandableArray_DataContainer<paFfPpSqeszHiebYrqFYkloPJUGh> wPAUFisQlZLsZGmchcocbgKKcBhw;

		private Keyboard srFBkeklMLkzixCmDIziDiekVvFLc;

		public tbscsWMgeeRPOpQBWjTWuQuNXvMi(Keyboard P_0)
		{
			srFBkeklMLkzixCmDIziDiekVvFLc = P_0;
			yWzCjuehqrFDKhBcpEeatuGwKIKyA = ModifierKeyFlags.None;
			rKXUEWaeoZbtCFViKvdcRartpHAJb = new ExpandableArray_DataContainer<paFfPpSqeszHiebYrqFYkloPJUGh>(132, false, 132);
			wPAUFisQlZLsZGmchcocbgKKcBhw = new ExpandableArray_DataContainer<paFfPpSqeszHiebYrqFYkloPJUGh>(5, false, 5);
		}

		public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
		{
			yWzCjuehqrFDKhBcpEeatuGwKIKyA = ModifierKeyFlags.None;
			rKXUEWaeoZbtCFViKvdcRartpHAJb.Clear();
			for (int num = wPAUFisQlZLsZGmchcocbgKKcBhw.Length - 1; num >= 0; num--)
			{
				paFfPpSqeszHiebYrqFYkloPJUGh paFfPpSqeszHiebYrqFYkloPJUGh2 = wPAUFisQlZLsZGmchcocbgKKcBhw[num];
				if (!srFBkeklMLkzixCmDIziDiekVvFLc.vtOmEEXVokrjXeqhtDXDMqrjDhwE(paFfPpSqeszHiebYrqFYkloPJUGh2.EqHcpXWaGauOvKqzuxjiUENyiiKN))
				{
					wPAUFisQlZLsZGmchcocbgKKcBhw.RemoveAt(num);
				}
			}
		}

		public void WLDKgUANcMHcWGUdkcAqJUwgaObHA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				yWzCjuehqrFDKhBcpEeatuGwKIKyA |= P_0.modifierKeyFlags;
				rKXUEWaeoZbtCFViKvdcRartpHAJb.injector.wktKiMTzgPuXyJzmAQdgBslXzykH(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
				rKXUEWaeoZbtCFViKvdcRartpHAJb.Inject();
			}
		}

		public bool MFWbxwoqZEdCvebVzqqrorySkkUT(KeyboardKeyCode P_0, ModifierKeyFlags P_1, HLpggwfgeYKXOQPBzlqCYYEdkQtCA P_2, out bool P_3)
		{
			P_3 = false;
			if (yWzCjuehqrFDKhBcpEeatuGwKIKyA == ModifierKeyFlags.None && P_1 == ModifierKeyFlags.None)
			{
				return false;
			}
			int num = Keyboard.hGkZkBfOatFMqgMssMRWiDMvoUNdb(P_1);
			if (MFWbxwoqZEdCvebVzqqrorySkkUT(rKXUEWaeoZbtCFViKvdcRartpHAJb, P_0, P_1, num, GSpzmWgNEJOmeBXGBafyAeHdazhR.Map, P_2, ref P_3))
			{
				return true;
			}
			if (MFWbxwoqZEdCvebVzqqrorySkkUT(wPAUFisQlZLsZGmchcocbgKKcBhw, P_0, P_1, num, GSpzmWgNEJOmeBXGBafyAeHdazhR.ActiveSet, P_2, ref P_3))
			{
				return true;
			}
			if (P_1 != ModifierKeyFlags.None)
			{
				wPAUFisQlZLsZGmchcocbgKKcBhw.injector.wktKiMTzgPuXyJzmAQdgBslXzykH(P_0, P_1);
				wPAUFisQlZLsZGmchcocbgKKcBhw.InjectIfUnique();
			}
			return false;
		}

		private bool MFWbxwoqZEdCvebVzqqrorySkkUT(ExpandableArray_DataContainer<paFfPpSqeszHiebYrqFYkloPJUGh> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, GSpzmWgNEJOmeBXGBafyAeHdazhR P_4, HLpggwfgeYKXOQPBzlqCYYEdkQtCA P_5, ref bool P_6)
		{
			bool flag = Keyboard.JScIttmBkgMsHdfRTwQqHcXQGAnCA(P_1);
			int length = P_0.Length;
			for (int i = 0; i < length; i++)
			{
				paFfPpSqeszHiebYrqFYkloPJUGh paFfPpSqeszHiebYrqFYkloPJUGh2 = P_0[i];
				bool flag2 = paFfPpSqeszHiebYrqFYkloPJUGh2.EqHcpXWaGauOvKqzuxjiUENyiiKN == P_1;
				if ((flag2 && paFfPpSqeszHiebYrqFYkloPJUGh2.LIbcgZDIOipcppxNicnRCgolrvLFA == P_2) || (!flag2 && !Keyboard.ModifierKeyFlagsContain(paFfPpSqeszHiebYrqFYkloPJUGh2.LIbcgZDIOipcppxNicnRCgolrvLFA, (KeyCode)P_1) && !MathTools.IjhDMiBzAbbqETDrZFRybpPkwDpLA((int)paFfPpSqeszHiebYrqFYkloPJUGh2.LIbcgZDIOipcppxNicnRCgolrvLFA, (int)P_2)))
				{
					continue;
				}
				if (!P_6)
				{
					P_6 = true;
				}
				if ((!flag && paFfPpSqeszHiebYrqFYkloPJUGh2.EqHcpXWaGauOvKqzuxjiUENyiiKN != P_1) || Keyboard.hGkZkBfOatFMqgMssMRWiDMvoUNdb(paFfPpSqeszHiebYrqFYkloPJUGh2.LIbcgZDIOipcppxNicnRCgolrvLFA) <= P_3)
				{
					continue;
				}
				bool flag3 = P_4 != GSpzmWgNEJOmeBXGBafyAeHdazhR.Map || srFBkeklMLkzixCmDIziDiekVvFLc.JgbGnLHDygzucaRiXhLugJqAHZZv(paFfPpSqeszHiebYrqFYkloPJUGh2.EqHcpXWaGauOvKqzuxjiUENyiiKN, paFfPpSqeszHiebYrqFYkloPJUGh2.LIbcgZDIOipcppxNicnRCgolrvLFA);
				switch (P_5)
				{
				case HLpggwfgeYKXOQPBzlqCYYEdkQtCA.Normal:
					return flag3;
				case HLpggwfgeYKXOQPBzlqCYYEdkQtCA.OverlapModifiers:
					if (P_2 == ModifierKeyFlags.None)
					{
						if (flag3 && P_1 == paFfPpSqeszHiebYrqFYkloPJUGh2.EqHcpXWaGauOvKqzuxjiUENyiiKN)
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

		public void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			yWzCjuehqrFDKhBcpEeatuGwKIKyA = ModifierKeyFlags.None;
			rKXUEWaeoZbtCFViKvdcRartpHAJb.Clear();
			wPAUFisQlZLsZGmchcocbgKKcBhw.Clear();
		}
	}

	public enum HLpggwfgeYKXOQPBzlqCYYEdkQtCA
	{
		Normal = 0,
		OverlapModifiers = 1
	}

	private readonly tbscsWMgeeRPOpQBWjTWuQuNXvMi[] bFWxHBjQsxHuYvNjQgQHYwACscWA;

	private UpdateLoopType oLPSGLPrThUSDXxJlTVDuFNuQqAB;

	private readonly Keyboard srFBkeklMLkzixCmDIziDiekVvFLc;

	private tbscsWMgeeRPOpQBWjTWuQuNXvMi yVsKAUWymJvXlLdJcirLAkYCwgyuA;

	public qhdGsmuaRZPOXBEZmmGhxzHSRVAx(UpdateLoopSetting P_0, Keyboard P_1)
	{
		srFBkeklMLkzixCmDIziDiekVvFLc = P_1;
		bFWxHBjQsxHuYvNjQgQHYwACscWA = new tbscsWMgeeRPOpQBWjTWuQuNXvMi[3];
		int num = 0;
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				tbscsWMgeeRPOpQBWjTWuQuNXvMi tbscsWMgeeRPOpQBWjTWuQuNXvMi2 = new tbscsWMgeeRPOpQBWjTWuQuNXvMi(P_1);
				bFWxHBjQsxHuYvNjQgQHYwACscWA[(int)list[i]] = tbscsWMgeeRPOpQBWjTWuQuNXvMi2;
				num++;
				if (num == 1)
				{
					yVsKAUWymJvXlLdJcirLAkYCwgyuA = tbscsWMgeeRPOpQBWjTWuQuNXvMi2;
				}
			}
		}
	}

	public void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
	{
		if (oLPSGLPrThUSDXxJlTVDuFNuQqAB != P_0)
		{
			oLPSGLPrThUSDXxJlTVDuFNuQqAB = P_0;
			yVsKAUWymJvXlLdJcirLAkYCwgyuA = bFWxHBjQsxHuYvNjQgQHYwACscWA[(int)P_0];
		}
		yVsKAUWymJvXlLdJcirLAkYCwgyuA.DsDuSUaDcVanpNAhDLIRqjKndMGi();
	}

	public void hkRySjxCMKJHCrFpoPCVPoucjAGQ(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		AList<ActionElementMap> aList = P_0.UetWStxkTEpvtiiHkgsRzKetHbwDA;
		int count = aList._count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = aList._items[i];
			if (actionElementMap.hasModifiers)
			{
				yVsKAUWymJvXlLdJcirLAkYCwgyuA.WLDKgUANcMHcWGUdkcAqJUwgaObHA(actionElementMap);
			}
		}
	}

	public bool MFWbxwoqZEdCvebVzqqrorySkkUT(KeyboardKeyCode P_0, ModifierKeyFlags P_1, HLpggwfgeYKXOQPBzlqCYYEdkQtCA P_2, out bool P_3)
	{
		return yVsKAUWymJvXlLdJcirLAkYCwgyuA.MFWbxwoqZEdCvebVzqqrorySkkUT(P_0, P_1, P_2, out P_3);
	}

	public void jOzDnUFgdpxtcCytponbUMtjonO()
	{
		for (int i = 0; i < bFWxHBjQsxHuYvNjQgQHYwACscWA.Length; i++)
		{
			if (bFWxHBjQsxHuYvNjQgQHYwACscWA[i] != null)
			{
				bFWxHBjQsxHuYvNjQgQHYwACscWA[i].wJjPIIRJfHhEbGedUconecGfiwzgB();
			}
		}
	}
}
