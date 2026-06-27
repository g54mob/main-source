using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class mvwlWjoNBZLoHgkpzwSLYSqKfyEM
{
	private class xXRgKTiwGHiNAqQdORvAXFKCexDK
	{
		private class zoZwFyjsbQNxRuuodPCJzCSyMNpi
		{
			private int BjFvXMZmIBUDduLaXcTiGIKicNhQ;

			private rEBxPfbkaiKhEIBZZAFmnfAQlPhK[] wvphwqfdisYkQizcXQmNVyRyFXtC;

			private kBGlPLvvpvGxmfJaCWnsPvckKgTS[] pFYuEYubNfDkjAZniRqYQCOCcIvY;

			public zoZwFyjsbQNxRuuodPCJzCSyMNpi(int P_0)
			{
				BjFvXMZmIBUDduLaXcTiGIKicNhQ = P_0;
				wvphwqfdisYkQizcXQmNVyRyFXtC = new rEBxPfbkaiKhEIBZZAFmnfAQlPhK[20];
				for (int i = 0; i < wvphwqfdisYkQizcXQmNVyRyFXtC.Length; i++)
				{
					wvphwqfdisYkQizcXQmNVyRyFXtC[i] = new rEBxPfbkaiKhEIBZZAFmnfAQlPhK();
				}
				pFYuEYubNfDkjAZniRqYQCOCcIvY = new kBGlPLvvpvGxmfJaCWnsPvckKgTS[29];
				for (int j = 0; j < pFYuEYubNfDkjAZniRqYQCOCcIvY.Length; j++)
				{
					pFYuEYubNfDkjAZniRqYQCOCcIvY[j] = new kBGlPLvvpvGxmfJaCWnsPvckKgTS(j);
				}
			}

			public void DdLTWhOBCoAUbHPFMprcyUgOlauW()
			{
				for (int i = 0; i < wvphwqfdisYkQizcXQmNVyRyFXtC.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(BjFvXMZmIBUDduLaXcTiGIKicNhQ, i);
					wvphwqfdisYkQizcXQmNVyRyFXtC[i].DJXlRgYPXjfVutRvBBxVbgXLVNNm(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < pFYuEYubNfDkjAZniRqYQCOCcIvY.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(BjFvXMZmIBUDduLaXcTiGIKicNhQ, j);
					pFYuEYubNfDkjAZniRqYQCOCcIvY[j].lgDCdktAyZRpMKdNJmpTeCQvSbpd(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void pdYmOVNVJiaaoRkvvcxpAAajefTw()
			{
				for (int i = 0; i < wvphwqfdisYkQizcXQmNVyRyFXtC.Length; i++)
				{
					wvphwqfdisYkQizcXQmNVyRyFXtC[i].LteureWoHdguzHzBRqJgIyeTDrCw = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(BjFvXMZmIBUDduLaXcTiGIKicNhQ, i);
				}
				for (int j = 0; j < pFYuEYubNfDkjAZniRqYQCOCcIvY.Length; j++)
				{
					pFYuEYubNfDkjAZniRqYQCOCcIvY[j].TelrsasAxQdVklqPvBAsJOyGUABh = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(BjFvXMZmIBUDduLaXcTiGIKicNhQ, j);
				}
			}

			public bool vJNMlFZKbrDqsgKMkxeZdxdHOtQlA(int P_0)
			{
				if (P_0 < 0 || P_0 >= wvphwqfdisYkQizcXQmNVyRyFXtC.Length)
				{
					return false;
				}
				return wvphwqfdisYkQizcXQmNVyRyFXtC[P_0].LteureWoHdguzHzBRqJgIyeTDrCw;
			}

			public bool GKyDUlCtCkONFVlDkbzuDcsEEtNLb(int P_0)
			{
				if (P_0 < 0 || P_0 >= wvphwqfdisYkQizcXQmNVyRyFXtC.Length)
				{
					return false;
				}
				return wvphwqfdisYkQizcXQmNVyRyFXtC[P_0].UTOFYgEBjeNfDIztUJYsMmMUnMzn;
			}

			public bool iiVKggLbSQHKHJQwbWaWfBGDiqmf(int P_0)
			{
				if (P_0 < 0 || P_0 >= wvphwqfdisYkQizcXQmNVyRyFXtC.Length)
				{
					return false;
				}
				return wvphwqfdisYkQizcXQmNVyRyFXtC[P_0].tKfKoJmDxbswEFioQaJDqDQFBWye;
			}

			public float XxzLfdOYXxoIxKEswwWqjFEOujcA(int P_0)
			{
				if (P_0 < 0 || P_0 >= pFYuEYubNfDkjAZniRqYQCOCcIvY.Length)
				{
					return 0f;
				}
				return pFYuEYubNfDkjAZniRqYQCOCcIvY[P_0].TelrsasAxQdVklqPvBAsJOyGUABh;
			}

			public bool eaSifBGdvJODruBSbDfPMLmlzeiX(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= pFYuEYubNfDkjAZniRqYQCOCcIvY.Length)
				{
					return false;
				}
				return pFYuEYubNfDkjAZniRqYQCOCcIvY[P_0].zdgiFNcESnIFisrqkExHskSLhbcJ(P_1);
			}

			public void eJbNvJdIOmLmZFksPlHMIHUwvgcP()
			{
				for (int i = 0; i < wvphwqfdisYkQizcXQmNVyRyFXtC.Length; i++)
				{
					wvphwqfdisYkQizcXQmNVyRyFXtC[i].mNHWBbCtFFVCihHgyUSVBnEWbxdh();
				}
				for (int j = 0; j < pFYuEYubNfDkjAZniRqYQCOCcIvY.Length; j++)
				{
					pFYuEYubNfDkjAZniRqYQCOCcIvY[j].nEYGXgGkZVbdiCNLAazihDzFwFrcc();
				}
			}
		}

		private class wcdjfKtGPsMMJgcvLRSMxhdDbffhA
		{
			private rEBxPfbkaiKhEIBZZAFmnfAQlPhK[] TrBUAjeaQEhACdadzAYyEMJxInDZA;

			public wcdjfKtGPsMMJgcvLRSMxhdDbffhA()
			{
				TrBUAjeaQEhACdadzAYyEMJxInDZA = new rEBxPfbkaiKhEIBZZAFmnfAQlPhK[7];
				for (int i = 0; i < TrBUAjeaQEhACdadzAYyEMJxInDZA.Length; i++)
				{
					TrBUAjeaQEhACdadzAYyEMJxInDZA[i] = new rEBxPfbkaiKhEIBZZAFmnfAQlPhK();
				}
			}

			public void fVfdJBZeKuggJGSpNSIuwLEIwnwx()
			{
				for (int i = 0; i < TrBUAjeaQEhACdadzAYyEMJxInDZA.Length; i++)
				{
					TrBUAjeaQEhACdadzAYyEMJxInDZA[i].LteureWoHdguzHzBRqJgIyeTDrCw = Input.GetButton("MouseButton" + i);
				}
			}

			public bool lDpGchzjJXgYMCfiXRCqzyaBqKdV(int P_0)
			{
				if (P_0 < 0 || P_0 >= TrBUAjeaQEhACdadzAYyEMJxInDZA.Length)
				{
					return false;
				}
				return TrBUAjeaQEhACdadzAYyEMJxInDZA[P_0].LteureWoHdguzHzBRqJgIyeTDrCw;
			}

			public bool FtjdjCkHUiHpwKnCsfRnvEPGNKsG(int P_0)
			{
				if (P_0 < 0 || P_0 >= TrBUAjeaQEhACdadzAYyEMJxInDZA.Length)
				{
					return false;
				}
				return TrBUAjeaQEhACdadzAYyEMJxInDZA[P_0].UTOFYgEBjeNfDIztUJYsMmMUnMzn;
			}

			public bool groCXRMBYqrwyQdjHxIpGHWRgQyf(int P_0)
			{
				if (P_0 < 0 || P_0 >= TrBUAjeaQEhACdadzAYyEMJxInDZA.Length)
				{
					return false;
				}
				return TrBUAjeaQEhACdadzAYyEMJxInDZA[P_0].tKfKoJmDxbswEFioQaJDqDQFBWye;
			}

			public void pnwqLUnFsQlfDLgbgEdRiWGFRGwGA()
			{
				for (int i = 0; i < TrBUAjeaQEhACdadzAYyEMJxInDZA.Length; i++)
				{
					TrBUAjeaQEhACdadzAYyEMJxInDZA[i].mNHWBbCtFFVCihHgyUSVBnEWbxdh();
				}
			}
		}

		private class rEBxPfbkaiKhEIBZZAFmnfAQlPhK
		{
			private bool CHQwiotGmMYwaDlgtdfuTGoqZKtH;

			private bool oqfoEALlurEwXUQJXDIhGhKZBILbb;

			public bool LteureWoHdguzHzBRqJgIyeTDrCw
			{
				get
				{
					return CHQwiotGmMYwaDlgtdfuTGoqZKtH;
				}
				set
				{
					oqfoEALlurEwXUQJXDIhGhKZBILbb = CHQwiotGmMYwaDlgtdfuTGoqZKtH;
					CHQwiotGmMYwaDlgtdfuTGoqZKtH = cHQwiotGmMYwaDlgtdfuTGoqZKtH;
				}
			}

			public bool UTOFYgEBjeNfDIztUJYsMmMUnMzn
			{
				get
				{
					if (CHQwiotGmMYwaDlgtdfuTGoqZKtH)
					{
						return !oqfoEALlurEwXUQJXDIhGhKZBILbb;
					}
					return false;
				}
			}

			public bool tKfKoJmDxbswEFioQaJDqDQFBWye
			{
				get
				{
					if (oqfoEALlurEwXUQJXDIhGhKZBILbb)
					{
						return !CHQwiotGmMYwaDlgtdfuTGoqZKtH;
					}
					return false;
				}
			}

			public void DJXlRgYPXjfVutRvBBxVbgXLVNNm(bool P_0)
			{
				CHQwiotGmMYwaDlgtdfuTGoqZKtH = P_0;
				oqfoEALlurEwXUQJXDIhGhKZBILbb = P_0;
			}

			public void mNHWBbCtFFVCihHgyUSVBnEWbxdh()
			{
				CHQwiotGmMYwaDlgtdfuTGoqZKtH = false;
				oqfoEALlurEwXUQJXDIhGhKZBILbb = false;
			}
		}

		private class kBGlPLvvpvGxmfJaCWnsPvckKgTS
		{
			private int bRsnnVOtGStJTFskSJrKbPjuVtNr;

			private float ocBnJUdaPlqqTHDWiluLLJXmgDWk;

			private float CZlcLRpoAppgYiOlufCCcqmShUOY;

			public float TelrsasAxQdVklqPvBAsJOyGUABh
			{
				get
				{
					return ocBnJUdaPlqqTHDWiluLLJXmgDWk;
				}
				set
				{
					ocBnJUdaPlqqTHDWiluLLJXmgDWk = num;
				}
			}

			public kBGlPLvvpvGxmfJaCWnsPvckKgTS(int P_0)
			{
				bRsnnVOtGStJTFskSJrKbPjuVtNr = P_0;
			}

			public void lgDCdktAyZRpMKdNJmpTeCQvSbpd(float P_0)
			{
				CZlcLRpoAppgYiOlufCCcqmShUOY = P_0;
				ocBnJUdaPlqqTHDWiluLLJXmgDWk = P_0;
			}

			public bool zdgiFNcESnIFisrqkExHskSLhbcJ(bool P_0)
			{
				float num = ocBnJUdaPlqqTHDWiluLLJXmgDWk - CZlcLRpoAppgYiOlufCCcqmShUOY;
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

			public void nEYGXgGkZVbdiCNLAazihDzFwFrcc()
			{
				ocBnJUdaPlqqTHDWiluLLJXmgDWk = 0f;
				CZlcLRpoAppgYiOlufCCcqmShUOY = 0f;
			}
		}

		private zoZwFyjsbQNxRuuodPCJzCSyMNpi[] DrMFBwgSQStOAdjWlUceKaQTEsLM;

		private wcdjfKtGPsMMJgcvLRSMxhdDbffhA pZayavZDKZCaCIZAfxGKQBNBziDqA;

		public xXRgKTiwGHiNAqQdORvAXFKCexDK()
		{
			DrMFBwgSQStOAdjWlUceKaQTEsLM = new zoZwFyjsbQNxRuuodPCJzCSyMNpi[16];
			for (int i = 0; i < DrMFBwgSQStOAdjWlUceKaQTEsLM.Length; i++)
			{
				DrMFBwgSQStOAdjWlUceKaQTEsLM[i] = new zoZwFyjsbQNxRuuodPCJzCSyMNpi(i);
			}
			pZayavZDKZCaCIZAfxGKQBNBziDqA = new wcdjfKtGPsMMJgcvLRSMxhdDbffhA();
		}

		public void vuYSfCAMnnBMiCSEQOtHgtpIdURwB()
		{
			for (int i = 0; i < DrMFBwgSQStOAdjWlUceKaQTEsLM.Length; i++)
			{
				DrMFBwgSQStOAdjWlUceKaQTEsLM[i].DdLTWhOBCoAUbHPFMprcyUgOlauW();
			}
		}

		public void OQuiUNTngrWdZbLoHchXiaouWTxuA()
		{
			for (int i = 0; i < DrMFBwgSQStOAdjWlUceKaQTEsLM.Length; i++)
			{
				DrMFBwgSQStOAdjWlUceKaQTEsLM[i].pdYmOVNVJiaaoRkvvcxpAAajefTw();
			}
			pZayavZDKZCaCIZAfxGKQBNBziDqA.fVfdJBZeKuggJGSpNSIuwLEIwnwx();
		}

		public bool oZFdNmHnBidkIEkUFfTEZLDCYdXtA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= DrMFBwgSQStOAdjWlUceKaQTEsLM.Length)
			{
				return false;
			}
			return DrMFBwgSQStOAdjWlUceKaQTEsLM[P_0].vJNMlFZKbrDqsgKMkxeZdxdHOtQlA(P_1);
		}

		public bool mUdKvVVnvmIERfJTUwlhqedxwpkS(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= DrMFBwgSQStOAdjWlUceKaQTEsLM.Length)
			{
				return false;
			}
			return DrMFBwgSQStOAdjWlUceKaQTEsLM[P_0].GKyDUlCtCkONFVlDkbzuDcsEEtNLb(P_1);
		}

		public bool flgkbCmaFQCqGGaGMOdMsXlMTKPS(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= DrMFBwgSQStOAdjWlUceKaQTEsLM.Length)
			{
				return false;
			}
			return DrMFBwgSQStOAdjWlUceKaQTEsLM[P_0].iiVKggLbSQHKHJQwbWaWfBGDiqmf(P_1);
		}

		public bool vBkDIqOPVzDvpaMJYGSjifgumZrCA(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= DrMFBwgSQStOAdjWlUceKaQTEsLM.Length)
			{
				return false;
			}
			return DrMFBwgSQStOAdjWlUceKaQTEsLM[P_0].eaSifBGdvJODruBSbDfPMLmlzeiX(P_1, P_2);
		}

		public bool UViFHPJJlDIBanowaTlQiPVYpxoc(int P_0)
		{
			return pZayavZDKZCaCIZAfxGKQBNBziDqA.lDpGchzjJXgYMCfiXRCqzyaBqKdV(P_0);
		}

		public bool vmMnzRcUkZbcAmNxvvvhXIBJmQt(int P_0)
		{
			return pZayavZDKZCaCIZAfxGKQBNBziDqA.FtjdjCkHUiHpwKnCsfRnvEPGNKsG(P_0);
		}

		public bool XLuGjMqcnDrgAosdwgslIyeWvygl(int P_0)
		{
			return pZayavZDKZCaCIZAfxGKQBNBziDqA.groCXRMBYqrwyQdjHxIpGHWRgQyf(P_0);
		}

		public void UKweaGaGzGZdyhJIWZTYFOaxCdly()
		{
			for (int i = 0; i < DrMFBwgSQStOAdjWlUceKaQTEsLM.Length; i++)
			{
				DrMFBwgSQStOAdjWlUceKaQTEsLM[i].eJbNvJdIOmLmZFksPlHMIHUwvgcP();
			}
			pZayavZDKZCaCIZAfxGKQBNBziDqA.pnwqLUnFsQlfDLgbgEdRiWGFRGwGA();
		}
	}

	private UpdateLoopType IiNncDWwgmWTPSnjTrkFbdSnNBkB;

	private xXRgKTiwGHiNAqQdORvAXFKCexDK pncmDZsnzqfopZqlKwdofWHwsLNx;

	private IndexedDictionary<int, xXRgKTiwGHiNAqQdORvAXFKCexDK> JKUNnZQgajvKgNypheeFiDaMMCHw;

	public mvwlWjoNBZLoHgkpzwSLYSqKfyEM(UpdateLoopSetting P_0)
	{
		JKUNnZQgajvKgNypheeFiDaMMCHw = new IndexedDictionary<int, xXRgKTiwGHiNAqQdORvAXFKCexDK>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				JKUNnZQgajvKgNypheeFiDaMMCHw.Add((int)list[i], new xXRgKTiwGHiNAqQdORvAXFKCexDK());
			}
		}
		IiNncDWwgmWTPSnjTrkFbdSnNBkB = UpdateLoopType.Update;
		pncmDZsnzqfopZqlKwdofWHwsLNx = JKUNnZQgajvKgNypheeFiDaMMCHw.GetValue(0);
	}

	public void BdPSoUDPSNSkoCyadMYcDgpbjwyb()
	{
		opEFCLgDaYNhTqDrHjBoaQkXppeJ(ReInput.currentUpdateLoop);
		pncmDZsnzqfopZqlKwdofWHwsLNx.vuYSfCAMnnBMiCSEQOtHgtpIdURwB();
	}

	public void dOsfZGDsBfwnEDBKJpxFXwvLctwo(UpdateLoopType P_0)
	{
		opEFCLgDaYNhTqDrHjBoaQkXppeJ(P_0);
		pncmDZsnzqfopZqlKwdofWHwsLNx.OQuiUNTngrWdZbLoHchXiaouWTxuA();
	}

	public bool uNbvGbtXrDIGWBWqFpwQWvgYMIQB(int P_0, int P_1)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.oZFdNmHnBidkIEkUFfTEZLDCYdXtA(P_0, P_1);
	}

	public bool ydcTKofqZoAlKwDwYnBZmDXnMELE(int P_0, int P_1)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.mUdKvVVnvmIERfJTUwlhqedxwpkS(P_0, P_1);
	}

	public bool FmaQpcMXkfOmAcSWSbWHIZCLzGje(int P_0, int P_1)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.flgkbCmaFQCqGGaGMOdMsXlMTKPS(P_0, P_1);
	}

	public bool CDDANtdiQOXuOADfwwGiqKvxkXQl(int P_0, int P_1, bool P_2)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.vBkDIqOPVzDvpaMJYGSjifgumZrCA(P_0, P_1, P_2);
	}

	public bool rQYVMEHjWcoAjjLaskCbXciubTss(int P_0)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.UViFHPJJlDIBanowaTlQiPVYpxoc(P_0);
	}

	public bool jMzdnFFxkERXKdFhqtNQLpNsqcvCb(int P_0)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.vmMnzRcUkZbcAmNxvvvhXIBJmQt(P_0);
	}

	public bool gqgEwMgdHNisCySsocUmRjCNzNANA(int P_0)
	{
		return pncmDZsnzqfopZqlKwdofWHwsLNx.XLuGjMqcnDrgAosdwgslIyeWvygl(P_0);
	}

	public void vhmkUPzhmbRuDpJUZdZVhdnHrobMA()
	{
		for (int i = 0; i < JKUNnZQgajvKgNypheeFiDaMMCHw.Count; i++)
		{
			JKUNnZQgajvKgNypheeFiDaMMCHw[i].UKweaGaGzGZdyhJIWZTYFOaxCdly();
		}
	}

	private void opEFCLgDaYNhTqDrHjBoaQkXppeJ(UpdateLoopType P_0)
	{
		if (IiNncDWwgmWTPSnjTrkFbdSnNBkB != P_0)
		{
			IiNncDWwgmWTPSnjTrkFbdSnNBkB = P_0;
			pncmDZsnzqfopZqlKwdofWHwsLNx = JKUNnZQgajvKgNypheeFiDaMMCHw.GetValue((int)P_0);
		}
	}
}
