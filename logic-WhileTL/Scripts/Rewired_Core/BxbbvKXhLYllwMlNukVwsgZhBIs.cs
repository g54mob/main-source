using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class BxbbvKXhLYllwMlNukVwsgZhBIs
{
	public class npxgMiBmNHLqasnkibtFDenXzAAJ
	{
		private class aVBoosIxuMsUhbXreWkZIbGeQipn : ExpandableArray_DataContainer<aVBoosIxuMsUhbXreWkZIbGeQipn>.dFuptlhGpNzTzGvWxeUdsuiEinkQ, IComparable<aVBoosIxuMsUhbXreWkZIbGeQipn>
		{
			public KeyboardKeyCode xzRewGuNweXrZjgHBeZSFNenqiYrA;

			public ModifierKeyFlags ozthJQcfemADFYsbTXHdxRPuHbLAA;

			public void DNfbXjlUONZKgiGGpokWSKyQpSkC(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				xzRewGuNweXrZjgHBeZSFNenqiYrA = P_0;
				ozthJQcfemADFYsbTXHdxRPuHbLAA = P_1;
			}

			public void Set(aVBoosIxuMsUhbXreWkZIbGeQipn P_0)
			{
				xzRewGuNweXrZjgHBeZSFNenqiYrA = P_0.xzRewGuNweXrZjgHBeZSFNenqiYrA;
				ozthJQcfemADFYsbTXHdxRPuHbLAA = P_0.ozthJQcfemADFYsbTXHdxRPuHbLAA;
			}

			public bool Equals(aVBoosIxuMsUhbXreWkZIbGeQipn P_0)
			{
				if (xzRewGuNweXrZjgHBeZSFNenqiYrA == P_0.xzRewGuNweXrZjgHBeZSFNenqiYrA && ozthJQcfemADFYsbTXHdxRPuHbLAA == P_0.ozthJQcfemADFYsbTXHdxRPuHbLAA)
				{
					return true;
				}
				return false;
			}

			public void Clear()
			{
				xzRewGuNweXrZjgHBeZSFNenqiYrA = KeyboardKeyCode.None;
				ozthJQcfemADFYsbTXHdxRPuHbLAA = ModifierKeyFlags.None;
			}

			public int CompareTo(aVBoosIxuMsUhbXreWkZIbGeQipn other)
			{
				return 0;
			}
		}

		private enum DOBVTOzbWZJSXInwfQEzKAiUqTYb
		{
			Map = 0,
			ActiveSet = 1
		}

		private ModifierKeyFlags VgrfgjHKYpLgwFkQAyYKpfjfcGUGA;

		private ExpandableArray_DataContainer<aVBoosIxuMsUhbXreWkZIbGeQipn> EoPLdZCKKFUhiaBGhgXGdfSgfHWfA;

		private ExpandableArray_DataContainer<aVBoosIxuMsUhbXreWkZIbGeQipn> JMMVFnEzBVcqzzzMYpEKoFrZNXlo;

		private Keyboard THRtUdLBqPKCSvKIahLGAdLQOdVMA;

		public npxgMiBmNHLqasnkibtFDenXzAAJ(Keyboard P_0)
		{
			THRtUdLBqPKCSvKIahLGAdLQOdVMA = P_0;
			VgrfgjHKYpLgwFkQAyYKpfjfcGUGA = ModifierKeyFlags.None;
			EoPLdZCKKFUhiaBGhgXGdfSgfHWfA = new ExpandableArray_DataContainer<aVBoosIxuMsUhbXreWkZIbGeQipn>(132, false, 132);
			JMMVFnEzBVcqzzzMYpEKoFrZNXlo = new ExpandableArray_DataContainer<aVBoosIxuMsUhbXreWkZIbGeQipn>(5, false, 5);
		}

		public void sOLNzBCCbZmFXkMugfndpShqgrUP()
		{
			VgrfgjHKYpLgwFkQAyYKpfjfcGUGA = ModifierKeyFlags.None;
			EoPLdZCKKFUhiaBGhgXGdfSgfHWfA.Clear();
			for (int num = JMMVFnEzBVcqzzzMYpEKoFrZNXlo.Length - 1; num >= 0; num--)
			{
				aVBoosIxuMsUhbXreWkZIbGeQipn aVBoosIxuMsUhbXreWkZIbGeQipn2 = JMMVFnEzBVcqzzzMYpEKoFrZNXlo[num];
				if (!THRtUdLBqPKCSvKIahLGAdLQOdVMA.OqIVvNhSUckGdBVPATbxZKFuFBoR(aVBoosIxuMsUhbXreWkZIbGeQipn2.xzRewGuNweXrZjgHBeZSFNenqiYrA))
				{
					JMMVFnEzBVcqzzzMYpEKoFrZNXlo.RemoveAt(num);
				}
			}
		}

		public void hpPbDeiUQYPsDvDhFuCAUJkvSBde(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				VgrfgjHKYpLgwFkQAyYKpfjfcGUGA |= P_0.modifierKeyFlags;
				EoPLdZCKKFUhiaBGhgXGdfSgfHWfA.injector.DNfbXjlUONZKgiGGpokWSKyQpSkC(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
				EoPLdZCKKFUhiaBGhgXGdfSgfHWfA.Inject();
			}
		}

		public bool dCKIupBMxKqhLvPdSVYDavTVKoCz(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (VgrfgjHKYpLgwFkQAyYKpfjfcGUGA == ModifierKeyFlags.None && P_1 == ModifierKeyFlags.None)
			{
				return false;
			}
			int num = Keyboard.SxabNIXxQbdKAbhMVvfcMfjmjWBn(P_1);
			if (dCKIupBMxKqhLvPdSVYDavTVKoCz(EoPLdZCKKFUhiaBGhgXGdfSgfHWfA, P_0, P_1, num, DOBVTOzbWZJSXInwfQEzKAiUqTYb.Map))
			{
				return true;
			}
			if (dCKIupBMxKqhLvPdSVYDavTVKoCz(JMMVFnEzBVcqzzzMYpEKoFrZNXlo, P_0, P_1, num, DOBVTOzbWZJSXInwfQEzKAiUqTYb.ActiveSet))
			{
				return true;
			}
			if (P_1 != ModifierKeyFlags.None)
			{
				JMMVFnEzBVcqzzzMYpEKoFrZNXlo.injector.DNfbXjlUONZKgiGGpokWSKyQpSkC(P_0, P_1);
				JMMVFnEzBVcqzzzMYpEKoFrZNXlo.InjectIfUnique();
			}
			return false;
		}

		private bool dCKIupBMxKqhLvPdSVYDavTVKoCz(ExpandableArray_DataContainer<aVBoosIxuMsUhbXreWkZIbGeQipn> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, DOBVTOzbWZJSXInwfQEzKAiUqTYb P_4)
		{
			bool flag = Keyboard.wVmqsgOApqHhpSlhioGKGueFIHvD(P_1);
			int length = P_0.Length;
			for (int i = 0; i < length; i++)
			{
				aVBoosIxuMsUhbXreWkZIbGeQipn aVBoosIxuMsUhbXreWkZIbGeQipn2 = P_0[i];
				bool flag2 = aVBoosIxuMsUhbXreWkZIbGeQipn2.xzRewGuNweXrZjgHBeZSFNenqiYrA == P_1;
				if ((!flag2 || aVBoosIxuMsUhbXreWkZIbGeQipn2.ozthJQcfemADFYsbTXHdxRPuHbLAA != P_2) && (flag2 || Keyboard.ModifierKeyFlagsContain(aVBoosIxuMsUhbXreWkZIbGeQipn2.ozthJQcfemADFYsbTXHdxRPuHbLAA, (KeyCode)P_1) || MathTools.nrWVfWdyjLFcLcXwwhMVqwbJJzeA((int)aVBoosIxuMsUhbXreWkZIbGeQipn2.ozthJQcfemADFYsbTXHdxRPuHbLAA, (int)P_2)) && (flag || aVBoosIxuMsUhbXreWkZIbGeQipn2.xzRewGuNweXrZjgHBeZSFNenqiYrA == P_1) && Keyboard.SxabNIXxQbdKAbhMVvfcMfjmjWBn(aVBoosIxuMsUhbXreWkZIbGeQipn2.ozthJQcfemADFYsbTXHdxRPuHbLAA) > P_3)
				{
					if (P_4 != DOBVTOzbWZJSXInwfQEzKAiUqTYb.Map)
					{
						return true;
					}
					if (THRtUdLBqPKCSvKIahLGAdLQOdVMA.adWmGbiOufRWIJOuXfEhtFDuBHOA(aVBoosIxuMsUhbXreWkZIbGeQipn2.xzRewGuNweXrZjgHBeZSFNenqiYrA, aVBoosIxuMsUhbXreWkZIbGeQipn2.ozthJQcfemADFYsbTXHdxRPuHbLAA))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			VgrfgjHKYpLgwFkQAyYKpfjfcGUGA = ModifierKeyFlags.None;
			EoPLdZCKKFUhiaBGhgXGdfSgfHWfA.Clear();
			JMMVFnEzBVcqzzzMYpEKoFrZNXlo.Clear();
		}
	}

	private readonly npxgMiBmNHLqasnkibtFDenXzAAJ[] OILFqKTJosIuEQvfAMAgFuBFIsys;

	private UpdateLoopType HvFDPHvQHhAdkasJMjRxfxqlAkaF;

	private readonly Keyboard THRtUdLBqPKCSvKIahLGAdLQOdVMA;

	private npxgMiBmNHLqasnkibtFDenXzAAJ FzeFBTyCrPwRSotVRRvPtdRXkqzA;

	public BxbbvKXhLYllwMlNukVwsgZhBIs(UpdateLoopSetting P_0, Keyboard P_1)
	{
		THRtUdLBqPKCSvKIahLGAdLQOdVMA = P_1;
		OILFqKTJosIuEQvfAMAgFuBFIsys = new npxgMiBmNHLqasnkibtFDenXzAAJ[3];
		int num = 0;
		using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
		List<UpdateLoopType> list = tList.list;
		EnumConverter.ToUpdateLoopTypes(P_0, list);
		for (int i = 0; i < list.Count; i++)
		{
			npxgMiBmNHLqasnkibtFDenXzAAJ npxgMiBmNHLqasnkibtFDenXzAAJ2 = new npxgMiBmNHLqasnkibtFDenXzAAJ(P_1);
			OILFqKTJosIuEQvfAMAgFuBFIsys[(int)list[i]] = npxgMiBmNHLqasnkibtFDenXzAAJ2;
			num++;
			if (num == 1)
			{
				FzeFBTyCrPwRSotVRRvPtdRXkqzA = npxgMiBmNHLqasnkibtFDenXzAAJ2;
			}
		}
	}

	public void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
	{
		if (HvFDPHvQHhAdkasJMjRxfxqlAkaF != P_0)
		{
			HvFDPHvQHhAdkasJMjRxfxqlAkaF = P_0;
			FzeFBTyCrPwRSotVRRvPtdRXkqzA = OILFqKTJosIuEQvfAMAgFuBFIsys[(int)P_0];
		}
		FzeFBTyCrPwRSotVRRvPtdRXkqzA.sOLNzBCCbZmFXkMugfndpShqgrUP();
	}

	public void UtJbzcEZwAYqcEGTRrozuIHvHYCEb(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		AList<ActionElementMap> aList = P_0.fHfLawVRnAIjFLcvXQTtiXDuzgak;
		int count = aList._count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = aList._items[i];
			if (actionElementMap.hasModifiers)
			{
				FzeFBTyCrPwRSotVRRvPtdRXkqzA.hpPbDeiUQYPsDvDhFuCAUJkvSBde(actionElementMap);
			}
		}
	}

	public bool dCKIupBMxKqhLvPdSVYDavTVKoCz(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		return FzeFBTyCrPwRSotVRRvPtdRXkqzA.dCKIupBMxKqhLvPdSVYDavTVKoCz(P_0, P_1);
	}

	public void ChSGQysrQdGIBXwKGwUXspnaSifV()
	{
		for (int i = 0; i < OILFqKTJosIuEQvfAMAgFuBFIsys.Length; i++)
		{
			if (OILFqKTJosIuEQvfAMAgFuBFIsys[i] != null)
			{
				OILFqKTJosIuEQvfAMAgFuBFIsys[i].HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			}
		}
	}
}
