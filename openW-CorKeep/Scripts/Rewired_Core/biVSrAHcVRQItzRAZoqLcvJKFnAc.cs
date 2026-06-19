using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class biVSrAHcVRQItzRAZoqLcvJKFnAc
{
	private class mmwEnFNhnFtmJhEFyapxzkFUyBuo
	{
		private class cVmPsqAvPArrOhwYDzrqJBTkfhGy
		{
			private int CSoRKMaihHknsndExMSVcSNecqWW;

			private gfqgztWJBuaoDLCjpLgRDCVKUAIo[] tmGAneACBcqyHUdYlVykrQjadiQfA;

			private hCxRJXIcYxDHnkVQoJvLvMdyPquk[] qhvVyCNhynGMaHLNKCAtkaLUMlITA;

			public cVmPsqAvPArrOhwYDzrqJBTkfhGy(int P_0)
			{
				CSoRKMaihHknsndExMSVcSNecqWW = P_0;
				tmGAneACBcqyHUdYlVykrQjadiQfA = new gfqgztWJBuaoDLCjpLgRDCVKUAIo[20];
				for (int i = 0; i < tmGAneACBcqyHUdYlVykrQjadiQfA.Length; i++)
				{
					tmGAneACBcqyHUdYlVykrQjadiQfA[i] = new gfqgztWJBuaoDLCjpLgRDCVKUAIo();
				}
				qhvVyCNhynGMaHLNKCAtkaLUMlITA = new hCxRJXIcYxDHnkVQoJvLvMdyPquk[29];
				for (int j = 0; j < qhvVyCNhynGMaHLNKCAtkaLUMlITA.Length; j++)
				{
					qhvVyCNhynGMaHLNKCAtkaLUMlITA[j] = new hCxRJXIcYxDHnkVQoJvLvMdyPquk(j);
				}
			}

			public void UEiSLdbdhqbuihUzwhXNEAtbCTXaB()
			{
				for (int i = 0; i < tmGAneACBcqyHUdYlVykrQjadiQfA.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(CSoRKMaihHknsndExMSVcSNecqWW, i);
					tmGAneACBcqyHUdYlVykrQjadiQfA[i].EqaFyxdgvfbfquJnkhosXOZhauoA(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < qhvVyCNhynGMaHLNKCAtkaLUMlITA.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(CSoRKMaihHknsndExMSVcSNecqWW, j);
					qhvVyCNhynGMaHLNKCAtkaLUMlITA[j].kycqOaSIpPXtVLjRzMCiIFZrFlUHA(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void aAjUuXsegaEGlSwVRSiGyBffOLiI()
			{
				for (int i = 0; i < tmGAneACBcqyHUdYlVykrQjadiQfA.Length; i++)
				{
					tmGAneACBcqyHUdYlVykrQjadiQfA[i].INVAlirRkljSuQivhpnVoVhFeWnP = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(CSoRKMaihHknsndExMSVcSNecqWW, i);
				}
				for (int j = 0; j < qhvVyCNhynGMaHLNKCAtkaLUMlITA.Length; j++)
				{
					qhvVyCNhynGMaHLNKCAtkaLUMlITA[j].QUSJhiFaMMcRrevdBctLjrpUgzatA = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(CSoRKMaihHknsndExMSVcSNecqWW, j);
				}
			}

			public bool wgBvXGgYrSSteLwgCKaoRuENGjbc(int P_0)
			{
				if (P_0 < 0 || P_0 >= tmGAneACBcqyHUdYlVykrQjadiQfA.Length)
				{
					return false;
				}
				return tmGAneACBcqyHUdYlVykrQjadiQfA[P_0].INVAlirRkljSuQivhpnVoVhFeWnP;
			}

			public bool VrBCGxUlbqrPOoCrEeJLEAlScWiEA(int P_0)
			{
				if (P_0 < 0 || P_0 >= tmGAneACBcqyHUdYlVykrQjadiQfA.Length)
				{
					return false;
				}
				return tmGAneACBcqyHUdYlVykrQjadiQfA[P_0].BEjWfkzAEkNmQLfHqeFNmbRQbnWV;
			}

			public bool fvoEWqkrbCrtSUsiXCovXwHFaJBo(int P_0)
			{
				if (P_0 < 0 || P_0 >= tmGAneACBcqyHUdYlVykrQjadiQfA.Length)
				{
					return false;
				}
				return tmGAneACBcqyHUdYlVykrQjadiQfA[P_0].gNOgYFRXkbCUHMPOoiCueYMTzcDLA;
			}

			public float IjKNBtxizBTANFvuCLMvPsGCqRSV(int P_0)
			{
				if (P_0 < 0 || P_0 >= qhvVyCNhynGMaHLNKCAtkaLUMlITA.Length)
				{
					return 0f;
				}
				return qhvVyCNhynGMaHLNKCAtkaLUMlITA[P_0].QUSJhiFaMMcRrevdBctLjrpUgzatA;
			}

			public bool verEaZfPSREsqnneBrTwcxrzMHTr(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= qhvVyCNhynGMaHLNKCAtkaLUMlITA.Length)
				{
					return false;
				}
				return qhvVyCNhynGMaHLNKCAtkaLUMlITA[P_0].cGRFmBPXxxqKblAEKCwkARNNOKRs(P_1);
			}

			public void hKWdRHOtuKAGwCKvxrjIoPouFRkA()
			{
				for (int i = 0; i < tmGAneACBcqyHUdYlVykrQjadiQfA.Length; i++)
				{
					tmGAneACBcqyHUdYlVykrQjadiQfA[i].tsiNWnjWSVkjxuMGYhgctXFYBEUW();
				}
				for (int j = 0; j < qhvVyCNhynGMaHLNKCAtkaLUMlITA.Length; j++)
				{
					qhvVyCNhynGMaHLNKCAtkaLUMlITA[j].iXnJBsREgXJRjWvrMhDHnKqaKuQq();
				}
			}
		}

		private class vWQlnYIdeykKIdOLvqkfJLkLSACJ
		{
			private gfqgztWJBuaoDLCjpLgRDCVKUAIo[] YVoeYxfPlGNoBViBXWiHuiGjjKedb;

			public vWQlnYIdeykKIdOLvqkfJLkLSACJ()
			{
				YVoeYxfPlGNoBViBXWiHuiGjjKedb = new gfqgztWJBuaoDLCjpLgRDCVKUAIo[7];
				for (int i = 0; i < YVoeYxfPlGNoBViBXWiHuiGjjKedb.Length; i++)
				{
					YVoeYxfPlGNoBViBXWiHuiGjjKedb[i] = new gfqgztWJBuaoDLCjpLgRDCVKUAIo();
				}
			}

			public void qKOvnDiuhujOUPlBfkwDCZFOJIZO()
			{
				for (int i = 0; i < YVoeYxfPlGNoBViBXWiHuiGjjKedb.Length; i++)
				{
					YVoeYxfPlGNoBViBXWiHuiGjjKedb[i].INVAlirRkljSuQivhpnVoVhFeWnP = Input.GetButton("MouseButton" + i);
				}
			}

			public bool iyYFMrUweDiuNRrQddmVGFpBxdKLA(int P_0)
			{
				if (P_0 < 0 || P_0 >= YVoeYxfPlGNoBViBXWiHuiGjjKedb.Length)
				{
					return false;
				}
				return YVoeYxfPlGNoBViBXWiHuiGjjKedb[P_0].INVAlirRkljSuQivhpnVoVhFeWnP;
			}

			public bool AmCkpKXGpmGpxFLaQkRGCNEKIyJtA(int P_0)
			{
				if (P_0 < 0 || P_0 >= YVoeYxfPlGNoBViBXWiHuiGjjKedb.Length)
				{
					return false;
				}
				return YVoeYxfPlGNoBViBXWiHuiGjjKedb[P_0].BEjWfkzAEkNmQLfHqeFNmbRQbnWV;
			}

			public bool tkFdOBFjjsHTfBHRizTYfwTqNVPJB(int P_0)
			{
				if (P_0 < 0 || P_0 >= YVoeYxfPlGNoBViBXWiHuiGjjKedb.Length)
				{
					return false;
				}
				return YVoeYxfPlGNoBViBXWiHuiGjjKedb[P_0].gNOgYFRXkbCUHMPOoiCueYMTzcDLA;
			}

			public void qSZFYeYVQUFKgSHMMXipwLMTzLVb()
			{
				for (int i = 0; i < YVoeYxfPlGNoBViBXWiHuiGjjKedb.Length; i++)
				{
					YVoeYxfPlGNoBViBXWiHuiGjjKedb[i].tsiNWnjWSVkjxuMGYhgctXFYBEUW();
				}
			}
		}

		private class gfqgztWJBuaoDLCjpLgRDCVKUAIo
		{
			private bool ZypOqwCunGukfMjXXfXRAnhoBgUrA;

			private bool lOmEUkaDzNWCPLfpmaGFBDiJhaTb;

			public bool INVAlirRkljSuQivhpnVoVhFeWnP
			{
				get
				{
					return ZypOqwCunGukfMjXXfXRAnhoBgUrA;
				}
				set
				{
					lOmEUkaDzNWCPLfpmaGFBDiJhaTb = ZypOqwCunGukfMjXXfXRAnhoBgUrA;
					ZypOqwCunGukfMjXXfXRAnhoBgUrA = zypOqwCunGukfMjXXfXRAnhoBgUrA;
				}
			}

			public bool BEjWfkzAEkNmQLfHqeFNmbRQbnWV
			{
				get
				{
					if (ZypOqwCunGukfMjXXfXRAnhoBgUrA)
					{
						return !lOmEUkaDzNWCPLfpmaGFBDiJhaTb;
					}
					return false;
				}
			}

			public bool gNOgYFRXkbCUHMPOoiCueYMTzcDLA
			{
				get
				{
					if (lOmEUkaDzNWCPLfpmaGFBDiJhaTb)
					{
						return !ZypOqwCunGukfMjXXfXRAnhoBgUrA;
					}
					return false;
				}
			}

			public void EqaFyxdgvfbfquJnkhosXOZhauoA(bool P_0)
			{
				ZypOqwCunGukfMjXXfXRAnhoBgUrA = P_0;
				lOmEUkaDzNWCPLfpmaGFBDiJhaTb = P_0;
			}

			public void tsiNWnjWSVkjxuMGYhgctXFYBEUW()
			{
				ZypOqwCunGukfMjXXfXRAnhoBgUrA = false;
				lOmEUkaDzNWCPLfpmaGFBDiJhaTb = false;
			}
		}

		private class hCxRJXIcYxDHnkVQoJvLvMdyPquk
		{
			private int iLFzLynjnQdKmOSFiNjqPkKaMcJB;

			private float fCcLtSYOghFWCCnqAmLidEQouNzN;

			private float HCCXPLEWjpmIRzaTAQqzQDpGhtpEA;

			public float QUSJhiFaMMcRrevdBctLjrpUgzatA
			{
				get
				{
					return fCcLtSYOghFWCCnqAmLidEQouNzN;
				}
				set
				{
					fCcLtSYOghFWCCnqAmLidEQouNzN = num;
				}
			}

			public hCxRJXIcYxDHnkVQoJvLvMdyPquk(int P_0)
			{
				iLFzLynjnQdKmOSFiNjqPkKaMcJB = P_0;
			}

			public void kycqOaSIpPXtVLjRzMCiIFZrFlUHA(float P_0)
			{
				HCCXPLEWjpmIRzaTAQqzQDpGhtpEA = P_0;
				fCcLtSYOghFWCCnqAmLidEQouNzN = P_0;
			}

			public bool cGRFmBPXxxqKblAEKCwkARNNOKRs(bool P_0)
			{
				float num = fCcLtSYOghFWCCnqAmLidEQouNzN - HCCXPLEWjpmIRzaTAQqzQDpGhtpEA;
				if (P_0 && num < 0f)
				{
					return false;
				}
				if (MathTools.Abs(num) > 0.7f)
				{
					return true;
				}
				return false;
			}

			public void iXnJBsREgXJRjWvrMhDHnKqaKuQq()
			{
				fCcLtSYOghFWCCnqAmLidEQouNzN = 0f;
				HCCXPLEWjpmIRzaTAQqzQDpGhtpEA = 0f;
			}
		}

		private cVmPsqAvPArrOhwYDzrqJBTkfhGy[] OkheXmBLvSMZHNukJCiLycLJcNgRA;

		private vWQlnYIdeykKIdOLvqkfJLkLSACJ eiHbytqLvFSKJUPeROwrnmUNpPeN;

		public mmwEnFNhnFtmJhEFyapxzkFUyBuo()
		{
			OkheXmBLvSMZHNukJCiLycLJcNgRA = new cVmPsqAvPArrOhwYDzrqJBTkfhGy[16];
			for (int i = 0; i < OkheXmBLvSMZHNukJCiLycLJcNgRA.Length; i++)
			{
				OkheXmBLvSMZHNukJCiLycLJcNgRA[i] = new cVmPsqAvPArrOhwYDzrqJBTkfhGy(i);
			}
			eiHbytqLvFSKJUPeROwrnmUNpPeN = new vWQlnYIdeykKIdOLvqkfJLkLSACJ();
		}

		public void yhppSShxYtocvLbaaFqeZGoxanwW()
		{
			for (int i = 0; i < OkheXmBLvSMZHNukJCiLycLJcNgRA.Length; i++)
			{
				OkheXmBLvSMZHNukJCiLycLJcNgRA[i].UEiSLdbdhqbuihUzwhXNEAtbCTXaB();
			}
		}

		public void XOZEqDwaLlHACwZIvNmwWTbymeGi()
		{
			for (int i = 0; i < OkheXmBLvSMZHNukJCiLycLJcNgRA.Length; i++)
			{
				OkheXmBLvSMZHNukJCiLycLJcNgRA[i].aAjUuXsegaEGlSwVRSiGyBffOLiI();
			}
			eiHbytqLvFSKJUPeROwrnmUNpPeN.qKOvnDiuhujOUPlBfkwDCZFOJIZO();
		}

		public bool tCaYZkyUmmlEVzLurWvxnSQOCCaO(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= OkheXmBLvSMZHNukJCiLycLJcNgRA.Length)
			{
				return false;
			}
			return OkheXmBLvSMZHNukJCiLycLJcNgRA[P_0].wgBvXGgYrSSteLwgCKaoRuENGjbc(P_1);
		}

		public bool peIfqBqcSeeZKainmTkIGJivGmXJ(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= OkheXmBLvSMZHNukJCiLycLJcNgRA.Length)
			{
				return false;
			}
			return OkheXmBLvSMZHNukJCiLycLJcNgRA[P_0].VrBCGxUlbqrPOoCrEeJLEAlScWiEA(P_1);
		}

		public bool acZgiGFXyGiUXJJcuyNjGYcEEnulA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= OkheXmBLvSMZHNukJCiLycLJcNgRA.Length)
			{
				return false;
			}
			return OkheXmBLvSMZHNukJCiLycLJcNgRA[P_0].fvoEWqkrbCrtSUsiXCovXwHFaJBo(P_1);
		}

		public bool yEVXSwzhqzGDkzyxwQyGVBhiasSgA(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= OkheXmBLvSMZHNukJCiLycLJcNgRA.Length)
			{
				return false;
			}
			return OkheXmBLvSMZHNukJCiLycLJcNgRA[P_0].verEaZfPSREsqnneBrTwcxrzMHTr(P_1, P_2);
		}

		public bool ZCBsXXsomTUwloaWIrzxAJSMIGES(int P_0)
		{
			return eiHbytqLvFSKJUPeROwrnmUNpPeN.iyYFMrUweDiuNRrQddmVGFpBxdKLA(P_0);
		}

		public bool scHPnxamtgLZnXpjRkHMRmJVVPbn(int P_0)
		{
			return eiHbytqLvFSKJUPeROwrnmUNpPeN.AmCkpKXGpmGpxFLaQkRGCNEKIyJtA(P_0);
		}

		public bool SMZfJCREjXQJubVDCGiEexCOZOJC(int P_0)
		{
			return eiHbytqLvFSKJUPeROwrnmUNpPeN.tkFdOBFjjsHTfBHRizTYfwTqNVPJB(P_0);
		}

		public void LzZyJAVWiEDTjuwDurqnpngzATGd()
		{
			for (int i = 0; i < OkheXmBLvSMZHNukJCiLycLJcNgRA.Length; i++)
			{
				OkheXmBLvSMZHNukJCiLycLJcNgRA[i].hKWdRHOtuKAGwCKvxrjIoPouFRkA();
			}
			eiHbytqLvFSKJUPeROwrnmUNpPeN.qSZFYeYVQUFKgSHMMXipwLMTzLVb();
		}
	}

	private UpdateLoopType HmVmhkftZkooWTGFvZHLFlkhasas;

	private mmwEnFNhnFtmJhEFyapxzkFUyBuo sHETZzVMkVWkgUBisLBSBSuLesBb;

	private IndexedDictionary<int, mmwEnFNhnFtmJhEFyapxzkFUyBuo> IbojHThVjkcxzELNqOaCQvIIxkx;

	public biVSrAHcVRQItzRAZoqLcvJKFnAc(UpdateLoopSetting P_0)
	{
		IbojHThVjkcxzELNqOaCQvIIxkx = new IndexedDictionary<int, mmwEnFNhnFtmJhEFyapxzkFUyBuo>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				IbojHThVjkcxzELNqOaCQvIIxkx.Add((int)list[i], new mmwEnFNhnFtmJhEFyapxzkFUyBuo());
			}
		}
		HmVmhkftZkooWTGFvZHLFlkhasas = UpdateLoopType.Update;
		sHETZzVMkVWkgUBisLBSBSuLesBb = IbojHThVjkcxzELNqOaCQvIIxkx.GetValue(0);
	}

	public void UginGwknwLoyjXLCNkklrNfhSSJX()
	{
		rQbKHBJlPWBjEdADznHDYDjZrEVP(ReInput.currentUpdateLoop);
		sHETZzVMkVWkgUBisLBSBSuLesBb.yhppSShxYtocvLbaaFqeZGoxanwW();
	}

	public void mkFHIWiCkfHPFYOitDxahauVCbJF(UpdateLoopType P_0)
	{
		rQbKHBJlPWBjEdADznHDYDjZrEVP(P_0);
		sHETZzVMkVWkgUBisLBSBSuLesBb.XOZEqDwaLlHACwZIvNmwWTbymeGi();
	}

	public bool lsUQvYGNoDxyFExmxFXNqzuEfPhh(int P_0, int P_1)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.tCaYZkyUmmlEVzLurWvxnSQOCCaO(P_0, P_1);
	}

	public bool zvJrTgWUZqomHzczkKTuUwIvhdqx(int P_0, int P_1)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.peIfqBqcSeeZKainmTkIGJivGmXJ(P_0, P_1);
	}

	public bool CJDlCljamnculptmqFBtBkAJmMGSA(int P_0, int P_1)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.acZgiGFXyGiUXJJcuyNjGYcEEnulA(P_0, P_1);
	}

	public bool FjqTZpKcvOAYPTSNYhaNYRshYHtO(int P_0, int P_1, bool P_2)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.yEVXSwzhqzGDkzyxwQyGVBhiasSgA(P_0, P_1, P_2);
	}

	public bool uTxgVSaAxuMQuafKOtECbYhgByBO(int P_0)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.ZCBsXXsomTUwloaWIrzxAJSMIGES(P_0);
	}

	public bool wtUzEDOOXSjgJImJOvEzFcCuKDOy(int P_0)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.scHPnxamtgLZnXpjRkHMRmJVVPbn(P_0);
	}

	public bool hyDuMKAraNEQRZrMWotJDWTBgivI(int P_0)
	{
		return sHETZzVMkVWkgUBisLBSBSuLesBb.SMZfJCREjXQJubVDCGiEexCOZOJC(P_0);
	}

	public void asFAvTODZvWdSgemhgxyDAuXgPCeA()
	{
		for (int i = 0; i < IbojHThVjkcxzELNqOaCQvIIxkx.Count; i++)
		{
			IbojHThVjkcxzELNqOaCQvIIxkx[i].LzZyJAVWiEDTjuwDurqnpngzATGd();
		}
	}

	private void rQbKHBJlPWBjEdADznHDYDjZrEVP(UpdateLoopType P_0)
	{
		if (HmVmhkftZkooWTGFvZHLFlkhasas != P_0)
		{
			HmVmhkftZkooWTGFvZHLFlkhasas = P_0;
			sHETZzVMkVWkgUBisLBSBSuLesBb = IbojHThVjkcxzELNqOaCQvIIxkx.GetValue((int)P_0);
		}
	}
}
