using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class beXbfkRAyWuTdcGMFyRGnKNziCGb
{
	public class DiLyemSTuMKUSiNJadQZQiRlSwAI
	{
		private class OLpnmmHNTJETHDfYioeZZNqSgNfGb : ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb>.PpQQfpicOGaWTCknreSphUKsXKis, IComparable<OLpnmmHNTJETHDfYioeZZNqSgNfGb>
		{
			public KeyboardKeyCode CVilrwsSkYwGYPvJWQgPfhGwwFoS;

			public ModifierKeyFlags RWCvFkqYRQYPWZbuFCHvuKgenHeo;

			public void digXnbZoNjbaDolSntJMbdEINRtM(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
			{
				CVilrwsSkYwGYPvJWQgPfhGwwFoS = P_0;
				RWCvFkqYRQYPWZbuFCHvuKgenHeo = P_1;
			}

			public void GPTfhveGAxToRjwilXTnRieenKHcA(OLpnmmHNTJETHDfYioeZZNqSgNfGb P_0)
			{
				CVilrwsSkYwGYPvJWQgPfhGwwFoS = P_0.CVilrwsSkYwGYPvJWQgPfhGwwFoS;
				RWCvFkqYRQYPWZbuFCHvuKgenHeo = P_0.RWCvFkqYRQYPWZbuFCHvuKgenHeo;
			}

			void ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb>.PpQQfpicOGaWTCknreSphUKsXKis.HOazBFUNiKJXNHHAygiviaarpyHB(OLpnmmHNTJETHDfYioeZZNqSgNfGb P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in GPTfhveGAxToRjwilXTnRieenKHcA
				this.GPTfhveGAxToRjwilXTnRieenKHcA(P_0);
			}

			public bool YsaOCLVANWXkLaqsbXtSVmCOqyde(OLpnmmHNTJETHDfYioeZZNqSgNfGb P_0)
			{
				if (CVilrwsSkYwGYPvJWQgPfhGwwFoS == P_0.CVilrwsSkYwGYPvJWQgPfhGwwFoS && RWCvFkqYRQYPWZbuFCHvuKgenHeo == P_0.RWCvFkqYRQYPWZbuFCHvuKgenHeo)
				{
					return true;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb>.PpQQfpicOGaWTCknreSphUKsXKis.YMtEmYsKQrMORMjdPbvQqdEOfTIH(OLpnmmHNTJETHDfYioeZZNqSgNfGb P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in YsaOCLVANWXkLaqsbXtSVmCOqyde
				return this.YsaOCLVANWXkLaqsbXtSVmCOqyde(P_0);
			}

			public void giVOTdXlcurkyCbfnJoLgEcooDzB()
			{
				CVilrwsSkYwGYPvJWQgPfhGwwFoS = KeyboardKeyCode.None;
				RWCvFkqYRQYPWZbuFCHvuKgenHeo = ModifierKeyFlags.None;
			}

			void ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb>.PpQQfpicOGaWTCknreSphUKsXKis.aHGlQCeZKmWhtlqEHuAdKOMpQAVF()
			{
				//ILSpy generated this explicit interface implementation from .override directive in giVOTdXlcurkyCbfnJoLgEcooDzB
				this.giVOTdXlcurkyCbfnJoLgEcooDzB();
			}

			public int CompareTo(OLpnmmHNTJETHDfYioeZZNqSgNfGb other)
			{
				return 0;
			}

			int IComparable<OLpnmmHNTJETHDfYioeZZNqSgNfGb>.CompareTo(OLpnmmHNTJETHDfYioeZZNqSgNfGb other)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CompareTo
				return this.CompareTo(other);
			}
		}

		private enum lyQEtqJMdDtWjGuyLdnfqpTCanfX
		{
			Map = 0,
			ActiveSet = 1
		}

		private ModifierKeyFlags sXWAQHhklWLpSuMRRqJKHxkMxcPAA;

		private ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb> lBPpYsjXaMqclogOhoSMFimNqXUD;

		private ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb> CDFLsUyaweerAaItKRVQXJSqnHNK;

		private Keyboard rBwUcRlnbsBDZNIMCAMobOxjxMNJ;

		public DiLyemSTuMKUSiNJadQZQiRlSwAI(Keyboard P_0)
		{
			rBwUcRlnbsBDZNIMCAMobOxjxMNJ = P_0;
			sXWAQHhklWLpSuMRRqJKHxkMxcPAA = ModifierKeyFlags.None;
			lBPpYsjXaMqclogOhoSMFimNqXUD = new ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb>(132, false, 132);
			CDFLsUyaweerAaItKRVQXJSqnHNK = new ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb>(5, false, 5);
		}

		public void LRBlFHhILYLfYCsCvvgNMZHDSCJR()
		{
			sXWAQHhklWLpSuMRRqJKHxkMxcPAA = ModifierKeyFlags.None;
			lBPpYsjXaMqclogOhoSMFimNqXUD.Clear();
			for (int num = CDFLsUyaweerAaItKRVQXJSqnHNK.Length - 1; num >= 0; num--)
			{
				OLpnmmHNTJETHDfYioeZZNqSgNfGb oLpnmmHNTJETHDfYioeZZNqSgNfGb = CDFLsUyaweerAaItKRVQXJSqnHNK[num];
				if (!rBwUcRlnbsBDZNIMCAMobOxjxMNJ.kNqCeKujRhBOLgaHFpQHDqmKvnlHb(oLpnmmHNTJETHDfYioeZZNqSgNfGb.CVilrwsSkYwGYPvJWQgPfhGwwFoS))
				{
					CDFLsUyaweerAaItKRVQXJSqnHNK.RemoveAt(num);
				}
			}
		}

		public void qekERImnFhFpdDhFpkQrgIrUosgxA(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				sXWAQHhklWLpSuMRRqJKHxkMxcPAA |= P_0.modifierKeyFlags;
				lBPpYsjXaMqclogOhoSMFimNqXUD.injector.digXnbZoNjbaDolSntJMbdEINRtM(P_0._keyboardKeyCode, P_0.modifierKeyFlags);
				lBPpYsjXaMqclogOhoSMFimNqXUD.Inject();
			}
		}

		public bool sliSGvuaUaWwPUcwYxqcBBPAZvFk(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
		{
			if (sXWAQHhklWLpSuMRRqJKHxkMxcPAA == ModifierKeyFlags.None && P_1 == ModifierKeyFlags.None)
			{
				return false;
			}
			int num = Keyboard.hwUtGMJILscNAaSoWujSKdRPoRBT(P_1);
			if (rZUfugxmrwRMcmcxPUsDSZUmHcJX(lBPpYsjXaMqclogOhoSMFimNqXUD, P_0, P_1, num, lyQEtqJMdDtWjGuyLdnfqpTCanfX.Map))
			{
				return true;
			}
			if (rZUfugxmrwRMcmcxPUsDSZUmHcJX(CDFLsUyaweerAaItKRVQXJSqnHNK, P_0, P_1, num, lyQEtqJMdDtWjGuyLdnfqpTCanfX.ActiveSet))
			{
				return true;
			}
			if (P_1 != ModifierKeyFlags.None)
			{
				CDFLsUyaweerAaItKRVQXJSqnHNK.injector.digXnbZoNjbaDolSntJMbdEINRtM(P_0, P_1);
				CDFLsUyaweerAaItKRVQXJSqnHNK.InjectIfUnique();
			}
			return false;
		}

		private bool rZUfugxmrwRMcmcxPUsDSZUmHcJX(ExpandableArray_DataContainer<OLpnmmHNTJETHDfYioeZZNqSgNfGb> P_0, KeyboardKeyCode P_1, ModifierKeyFlags P_2, int P_3, lyQEtqJMdDtWjGuyLdnfqpTCanfX P_4)
		{
			bool flag = Keyboard.GQqeejAYZmrpBEukiKQMsAughgffA(P_1);
			int length = P_0.Length;
			for (int i = 0; i < length; i++)
			{
				OLpnmmHNTJETHDfYioeZZNqSgNfGb oLpnmmHNTJETHDfYioeZZNqSgNfGb = P_0[i];
				bool flag2 = oLpnmmHNTJETHDfYioeZZNqSgNfGb.CVilrwsSkYwGYPvJWQgPfhGwwFoS == P_1;
				if ((!flag2 || oLpnmmHNTJETHDfYioeZZNqSgNfGb.RWCvFkqYRQYPWZbuFCHvuKgenHeo != P_2) && (flag2 || Keyboard.ModifierKeyFlagsContain(oLpnmmHNTJETHDfYioeZZNqSgNfGb.RWCvFkqYRQYPWZbuFCHvuKgenHeo, (KeyCode)P_1) || MathTools.GWggvcBrwKxZYlpqIbHULSAMmQFTA((int)oLpnmmHNTJETHDfYioeZZNqSgNfGb.RWCvFkqYRQYPWZbuFCHvuKgenHeo, (int)P_2)) && (flag || oLpnmmHNTJETHDfYioeZZNqSgNfGb.CVilrwsSkYwGYPvJWQgPfhGwwFoS == P_1) && Keyboard.hwUtGMJILscNAaSoWujSKdRPoRBT(oLpnmmHNTJETHDfYioeZZNqSgNfGb.RWCvFkqYRQYPWZbuFCHvuKgenHeo) > P_3)
				{
					if (P_4 != lyQEtqJMdDtWjGuyLdnfqpTCanfX.Map)
					{
						return true;
					}
					if (rBwUcRlnbsBDZNIMCAMobOxjxMNJ.cCrGvDbJVDKMAGBaeXUHojDCcNqfb(oLpnmmHNTJETHDfYioeZZNqSgNfGb.CVilrwsSkYwGYPvJWQgPfhGwwFoS, oLpnmmHNTJETHDfYioeZZNqSgNfGb.RWCvFkqYRQYPWZbuFCHvuKgenHeo))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void NnaDdzOolbCFjnZwWGbWfDWnAghK()
		{
			sXWAQHhklWLpSuMRRqJKHxkMxcPAA = ModifierKeyFlags.None;
			lBPpYsjXaMqclogOhoSMFimNqXUD.Clear();
			CDFLsUyaweerAaItKRVQXJSqnHNK.Clear();
		}
	}

	private readonly DiLyemSTuMKUSiNJadQZQiRlSwAI[] SFxbErpAXPQaOokrzliLEjIBbRwC;

	private UpdateLoopType qTcUtJikjmakUakGgGFGTFAhOpyfA;

	private readonly Keyboard PjyfiZAaaYDvVJIOTcHUlkGqiHHR;

	private DiLyemSTuMKUSiNJadQZQiRlSwAI KsnuoeCCgiNqMUGmAGGuSyGnUyZp;

	public beXbfkRAyWuTdcGMFyRGnKNziCGb(UpdateLoopSetting P_0, Keyboard P_1)
	{
		PjyfiZAaaYDvVJIOTcHUlkGqiHHR = P_1;
		SFxbErpAXPQaOokrzliLEjIBbRwC = new DiLyemSTuMKUSiNJadQZQiRlSwAI[3];
		int num = 0;
		using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
		List<UpdateLoopType> list = tList.list;
		EnumConverter.ToUpdateLoopTypes(P_0, list);
		for (int i = 0; i < list.Count; i++)
		{
			DiLyemSTuMKUSiNJadQZQiRlSwAI diLyemSTuMKUSiNJadQZQiRlSwAI = new DiLyemSTuMKUSiNJadQZQiRlSwAI(P_1);
			SFxbErpAXPQaOokrzliLEjIBbRwC[(int)list[i]] = diLyemSTuMKUSiNJadQZQiRlSwAI;
			num++;
			if (num == 1)
			{
				KsnuoeCCgiNqMUGmAGGuSyGnUyZp = diLyemSTuMKUSiNJadQZQiRlSwAI;
			}
		}
	}

	public void VlGtLKgGyKBYRIMvKVcEqfGLjhdJA(UpdateLoopType P_0)
	{
		if (qTcUtJikjmakUakGgGFGTFAhOpyfA != P_0)
		{
			qTcUtJikjmakUakGgGFGTFAhOpyfA = P_0;
			KsnuoeCCgiNqMUGmAGGuSyGnUyZp = SFxbErpAXPQaOokrzliLEjIBbRwC[(int)P_0];
		}
		KsnuoeCCgiNqMUGmAGGuSyGnUyZp.LRBlFHhILYLfYCsCvvgNMZHDSCJR();
	}

	public void ElLAudxMQhhcgOpxeqrrUqaifmfjA(KeyboardMap P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		AList<ActionElementMap> aList = P_0.WlfiRVollhePcNcyfbYblQBgHIiM;
		int count = aList._count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = aList._items[i];
			if (actionElementMap.hasModifiers)
			{
				KsnuoeCCgiNqMUGmAGGuSyGnUyZp.qekERImnFhFpdDhFpkQrgIrUosgxA(actionElementMap);
			}
		}
	}

	public bool AXKadZISnwIbMZVKGfAzpgMeoAXab(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		return KsnuoeCCgiNqMUGmAGGuSyGnUyZp.sliSGvuaUaWwPUcwYxqcBBPAZvFk(P_0, P_1);
	}

	public void kIAWTtWHiGEbERhpZeotDapeoUeGb()
	{
		for (int i = 0; i < SFxbErpAXPQaOokrzliLEjIBbRwC.Length; i++)
		{
			if (SFxbErpAXPQaOokrzliLEjIBbRwC[i] != null)
			{
				SFxbErpAXPQaOokrzliLEjIBbRwC[i].NnaDdzOolbCFjnZwWGbWfDWnAghK();
			}
		}
	}
}
