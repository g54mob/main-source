using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class CKzrLWnyJZLZbfvmmNZunMSZGHsh
{
	private class PGQzbojcCLssivciVBIdulwPeEhHA
	{
		private class HDEaZNcmoGzarsbjcnIuCGedUeLpA
		{
			private int tGTapMGKPEuXejrMTxNxvwrDnBab;

			private ZTGcWCDewkcxsDXGGWZHVYstTXZcB[] AHqHOFqumaptkprhCcVqcsWdbtNo;

			private ArLgbgachtEWIesxJfsJshSloExR[] ZqDMFrndTnzNTJoujHxzhsyBtiNO;

			public HDEaZNcmoGzarsbjcnIuCGedUeLpA(int P_0)
			{
				tGTapMGKPEuXejrMTxNxvwrDnBab = P_0;
				AHqHOFqumaptkprhCcVqcsWdbtNo = new ZTGcWCDewkcxsDXGGWZHVYstTXZcB[20];
				for (int i = 0; i < AHqHOFqumaptkprhCcVqcsWdbtNo.Length; i++)
				{
					AHqHOFqumaptkprhCcVqcsWdbtNo[i] = new ZTGcWCDewkcxsDXGGWZHVYstTXZcB();
				}
				ZqDMFrndTnzNTJoujHxzhsyBtiNO = new ArLgbgachtEWIesxJfsJshSloExR[29];
				for (int j = 0; j < ZqDMFrndTnzNTJoujHxzhsyBtiNO.Length; j++)
				{
					ZqDMFrndTnzNTJoujHxzhsyBtiNO[j] = new ArLgbgachtEWIesxJfsJshSloExR(j);
				}
			}

			public void nNOPmKPVGaGdBAAYZkwNNCUHDAGkA()
			{
				for (int i = 0; i < AHqHOFqumaptkprhCcVqcsWdbtNo.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(tGTapMGKPEuXejrMTxNxvwrDnBab, i);
					AHqHOFqumaptkprhCcVqcsWdbtNo[i].rrYunJDzPbmPSygWEGboAbnYnuhH(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < ZqDMFrndTnzNTJoujHxzhsyBtiNO.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(tGTapMGKPEuXejrMTxNxvwrDnBab, j);
					ZqDMFrndTnzNTJoujHxzhsyBtiNO[j].JBIzrDkWUFHusXzaIexoHeooBeTaA(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void TrFrwyURDqFYOGucizoOxqUgRglm()
			{
				for (int i = 0; i < AHqHOFqumaptkprhCcVqcsWdbtNo.Length; i++)
				{
					AHqHOFqumaptkprhCcVqcsWdbtNo[i].djIwPVWFrTRBGDYGKkZzhQKTbck = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(tGTapMGKPEuXejrMTxNxvwrDnBab, i);
				}
				for (int j = 0; j < ZqDMFrndTnzNTJoujHxzhsyBtiNO.Length; j++)
				{
					ZqDMFrndTnzNTJoujHxzhsyBtiNO[j].rZuCYLhNxGbAIJuUySGLwmWZNwnab = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(tGTapMGKPEuXejrMTxNxvwrDnBab, j);
				}
			}

			public bool JRIYHoCgrjhBMFrZvOjsKVVULroL(int P_0)
			{
				if (P_0 < 0 || P_0 >= AHqHOFqumaptkprhCcVqcsWdbtNo.Length)
				{
					return false;
				}
				return AHqHOFqumaptkprhCcVqcsWdbtNo[P_0].djIwPVWFrTRBGDYGKkZzhQKTbck;
			}

			public bool sWvnnYcGfgwebcUYduTHDQwHBGbC(int P_0)
			{
				if (P_0 < 0 || P_0 >= AHqHOFqumaptkprhCcVqcsWdbtNo.Length)
				{
					return false;
				}
				return AHqHOFqumaptkprhCcVqcsWdbtNo[P_0].yHLnANDmnaUqxVDmPhTBxOcFWgPN;
			}

			public bool GDCdvPAUMGQahKKVaGBtOSuSbKIuA(int P_0)
			{
				if (P_0 < 0 || P_0 >= AHqHOFqumaptkprhCcVqcsWdbtNo.Length)
				{
					return false;
				}
				return AHqHOFqumaptkprhCcVqcsWdbtNo[P_0].JgcBpmglZtABqnOnHBpwAHbiQdKDB;
			}

			public float bkmUsSXyWFnNuNuXhdhjCdxXYYJq(int P_0)
			{
				if (P_0 < 0 || P_0 >= ZqDMFrndTnzNTJoujHxzhsyBtiNO.Length)
				{
					return 0f;
				}
				return ZqDMFrndTnzNTJoujHxzhsyBtiNO[P_0].rZuCYLhNxGbAIJuUySGLwmWZNwnab;
			}

			public bool SNBdFwhRpZjpFbbXuSsyfzYccMMQB(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= ZqDMFrndTnzNTJoujHxzhsyBtiNO.Length)
				{
					return false;
				}
				return ZqDMFrndTnzNTJoujHxzhsyBtiNO[P_0].ZshCRoIjWzdlYodzpgNcqHuMcNMxA(P_1);
			}

			public void IXwMjgmcSoEVfOrbCeMhjOibhGOCA()
			{
				for (int i = 0; i < AHqHOFqumaptkprhCcVqcsWdbtNo.Length; i++)
				{
					AHqHOFqumaptkprhCcVqcsWdbtNo[i].UCCBvEgBxHfcKHetdfFuNguiTPRJc();
				}
				for (int j = 0; j < ZqDMFrndTnzNTJoujHxzhsyBtiNO.Length; j++)
				{
					ZqDMFrndTnzNTJoujHxzhsyBtiNO[j].FPDqCJvJBTGjOYHWxyFPcvHtnaVj();
				}
			}
		}

		private class SqyGplmoVadKtroeIBQrCfNWIBFv
		{
			private ZTGcWCDewkcxsDXGGWZHVYstTXZcB[] pdWKdMztEGfdygNacaHJlynmQRzm;

			public SqyGplmoVadKtroeIBQrCfNWIBFv()
			{
				pdWKdMztEGfdygNacaHJlynmQRzm = new ZTGcWCDewkcxsDXGGWZHVYstTXZcB[7];
				for (int i = 0; i < pdWKdMztEGfdygNacaHJlynmQRzm.Length; i++)
				{
					pdWKdMztEGfdygNacaHJlynmQRzm[i] = new ZTGcWCDewkcxsDXGGWZHVYstTXZcB();
				}
			}

			public void NMinKkSDUkxZpJTiWqDDNpoRNHGx()
			{
				for (int i = 0; i < pdWKdMztEGfdygNacaHJlynmQRzm.Length; i++)
				{
					pdWKdMztEGfdygNacaHJlynmQRzm[i].djIwPVWFrTRBGDYGKkZzhQKTbck = Input.GetButton("MouseButton" + i);
				}
			}

			public bool FwoGpUmkZTKrmNvpMuFZSYSYTmBu(int P_0)
			{
				if (P_0 < 0 || P_0 >= pdWKdMztEGfdygNacaHJlynmQRzm.Length)
				{
					return false;
				}
				return pdWKdMztEGfdygNacaHJlynmQRzm[P_0].djIwPVWFrTRBGDYGKkZzhQKTbck;
			}

			public bool nioFOfbtGoIeQRZDfBgMcIhLnxEab(int P_0)
			{
				if (P_0 < 0 || P_0 >= pdWKdMztEGfdygNacaHJlynmQRzm.Length)
				{
					return false;
				}
				return pdWKdMztEGfdygNacaHJlynmQRzm[P_0].yHLnANDmnaUqxVDmPhTBxOcFWgPN;
			}

			public bool OitfriTuYoiWCHTcMUwIrwkIqMMy(int P_0)
			{
				if (P_0 < 0 || P_0 >= pdWKdMztEGfdygNacaHJlynmQRzm.Length)
				{
					return false;
				}
				return pdWKdMztEGfdygNacaHJlynmQRzm[P_0].JgcBpmglZtABqnOnHBpwAHbiQdKDB;
			}

			public void DvrCiforoYFYtIvmruFshVaKkvIg()
			{
				for (int i = 0; i < pdWKdMztEGfdygNacaHJlynmQRzm.Length; i++)
				{
					pdWKdMztEGfdygNacaHJlynmQRzm[i].UCCBvEgBxHfcKHetdfFuNguiTPRJc();
				}
			}
		}

		private class ZTGcWCDewkcxsDXGGWZHVYstTXZcB
		{
			private bool kWZXZFiWMWtQIWZmesPZulWprrXG;

			private bool WfyajfYHunpZpTRQWTNUObsUbopcA;

			public bool djIwPVWFrTRBGDYGKkZzhQKTbck
			{
				get
				{
					return kWZXZFiWMWtQIWZmesPZulWprrXG;
				}
				set
				{
					WfyajfYHunpZpTRQWTNUObsUbopcA = kWZXZFiWMWtQIWZmesPZulWprrXG;
					kWZXZFiWMWtQIWZmesPZulWprrXG = flag;
				}
			}

			public bool yHLnANDmnaUqxVDmPhTBxOcFWgPN
			{
				get
				{
					if (kWZXZFiWMWtQIWZmesPZulWprrXG)
					{
						return !WfyajfYHunpZpTRQWTNUObsUbopcA;
					}
					return false;
				}
			}

			public bool JgcBpmglZtABqnOnHBpwAHbiQdKDB
			{
				get
				{
					if (WfyajfYHunpZpTRQWTNUObsUbopcA)
					{
						return !kWZXZFiWMWtQIWZmesPZulWprrXG;
					}
					return false;
				}
			}

			public void rrYunJDzPbmPSygWEGboAbnYnuhH(bool P_0)
			{
				kWZXZFiWMWtQIWZmesPZulWprrXG = P_0;
				WfyajfYHunpZpTRQWTNUObsUbopcA = P_0;
			}

			public void UCCBvEgBxHfcKHetdfFuNguiTPRJc()
			{
				kWZXZFiWMWtQIWZmesPZulWprrXG = false;
				WfyajfYHunpZpTRQWTNUObsUbopcA = false;
			}
		}

		private class ArLgbgachtEWIesxJfsJshSloExR
		{
			private int JGpIJiLgAUaobUVdDTknCmLrpZvt;

			private float EXIDIbfkLdaThAGDJjaaJelixQCeE;

			private float wRosiwyHShINcrzoruBjXiYPYcer;

			public float rZuCYLhNxGbAIJuUySGLwmWZNwnab
			{
				get
				{
					return EXIDIbfkLdaThAGDJjaaJelixQCeE;
				}
				set
				{
					EXIDIbfkLdaThAGDJjaaJelixQCeE = eXIDIbfkLdaThAGDJjaaJelixQCeE;
				}
			}

			public ArLgbgachtEWIesxJfsJshSloExR(int P_0)
			{
				JGpIJiLgAUaobUVdDTknCmLrpZvt = P_0;
			}

			public void JBIzrDkWUFHusXzaIexoHeooBeTaA(float P_0)
			{
				wRosiwyHShINcrzoruBjXiYPYcer = P_0;
				EXIDIbfkLdaThAGDJjaaJelixQCeE = P_0;
			}

			public bool ZshCRoIjWzdlYodzpgNcqHuMcNMxA(bool P_0)
			{
				float num = EXIDIbfkLdaThAGDJjaaJelixQCeE - wRosiwyHShINcrzoruBjXiYPYcer;
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

			public void FPDqCJvJBTGjOYHWxyFPcvHtnaVj()
			{
				EXIDIbfkLdaThAGDJjaaJelixQCeE = 0f;
				wRosiwyHShINcrzoruBjXiYPYcer = 0f;
			}
		}

		private HDEaZNcmoGzarsbjcnIuCGedUeLpA[] diLDqVxWSYQKiikNkRZHrRqGWtpL;

		private SqyGplmoVadKtroeIBQrCfNWIBFv TLbZIKKIgHXQuMZGsHwfgvDQAbph;

		public PGQzbojcCLssivciVBIdulwPeEhHA()
		{
			diLDqVxWSYQKiikNkRZHrRqGWtpL = new HDEaZNcmoGzarsbjcnIuCGedUeLpA[16];
			for (int i = 0; i < diLDqVxWSYQKiikNkRZHrRqGWtpL.Length; i++)
			{
				diLDqVxWSYQKiikNkRZHrRqGWtpL[i] = new HDEaZNcmoGzarsbjcnIuCGedUeLpA(i);
			}
			TLbZIKKIgHXQuMZGsHwfgvDQAbph = new SqyGplmoVadKtroeIBQrCfNWIBFv();
		}

		public void NFAIrZWfzivWZGJZCcaJULqnclNA()
		{
			for (int i = 0; i < diLDqVxWSYQKiikNkRZHrRqGWtpL.Length; i++)
			{
				diLDqVxWSYQKiikNkRZHrRqGWtpL[i].nNOPmKPVGaGdBAAYZkwNNCUHDAGkA();
			}
		}

		public void oZrhKuALopYuhcDpEkvcDAMtbkZH()
		{
			for (int i = 0; i < diLDqVxWSYQKiikNkRZHrRqGWtpL.Length; i++)
			{
				diLDqVxWSYQKiikNkRZHrRqGWtpL[i].TrFrwyURDqFYOGucizoOxqUgRglm();
			}
			TLbZIKKIgHXQuMZGsHwfgvDQAbph.NMinKkSDUkxZpJTiWqDDNpoRNHGx();
		}

		public bool AsKQgTWhPguVcbOPKBAraVfJIBhv(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= diLDqVxWSYQKiikNkRZHrRqGWtpL.Length)
			{
				return false;
			}
			return diLDqVxWSYQKiikNkRZHrRqGWtpL[P_0].JRIYHoCgrjhBMFrZvOjsKVVULroL(P_1);
		}

		public bool IIyYuwYipgzCleeCTCeMFwPmbNUs(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= diLDqVxWSYQKiikNkRZHrRqGWtpL.Length)
			{
				return false;
			}
			return diLDqVxWSYQKiikNkRZHrRqGWtpL[P_0].sWvnnYcGfgwebcUYduTHDQwHBGbC(P_1);
		}

		public bool JxnITzjrRUjPqZmZPwelZzXTIqtR(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= diLDqVxWSYQKiikNkRZHrRqGWtpL.Length)
			{
				return false;
			}
			return diLDqVxWSYQKiikNkRZHrRqGWtpL[P_0].GDCdvPAUMGQahKKVaGBtOSuSbKIuA(P_1);
		}

		public bool PurrlNPJNrnOJfaQZWTSYSIlwvFP(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= diLDqVxWSYQKiikNkRZHrRqGWtpL.Length)
			{
				return false;
			}
			return diLDqVxWSYQKiikNkRZHrRqGWtpL[P_0].SNBdFwhRpZjpFbbXuSsyfzYccMMQB(P_1, P_2);
		}

		public bool srrXwgAOHDavCiMrdvOtXsdTCZHw(int P_0)
		{
			return TLbZIKKIgHXQuMZGsHwfgvDQAbph.FwoGpUmkZTKrmNvpMuFZSYSYTmBu(P_0);
		}

		public bool DxrSUYKJWciSMFAEwfyOCYyYwKuqA(int P_0)
		{
			return TLbZIKKIgHXQuMZGsHwfgvDQAbph.nioFOfbtGoIeQRZDfBgMcIhLnxEab(P_0);
		}

		public bool fbpIRtjmxXNqebcknlIQveQZdEOn(int P_0)
		{
			return TLbZIKKIgHXQuMZGsHwfgvDQAbph.OitfriTuYoiWCHTcMUwIrwkIqMMy(P_0);
		}

		public void mTrNDlppvESHCceHLYQniAKmEBJW()
		{
			for (int i = 0; i < diLDqVxWSYQKiikNkRZHrRqGWtpL.Length; i++)
			{
				diLDqVxWSYQKiikNkRZHrRqGWtpL[i].IXwMjgmcSoEVfOrbCeMhjOibhGOCA();
			}
			TLbZIKKIgHXQuMZGsHwfgvDQAbph.DvrCiforoYFYtIvmruFshVaKkvIg();
		}
	}

	private UpdateLoopType iMxvATTLqyfzrTZgCaONQkBmbvlH;

	private PGQzbojcCLssivciVBIdulwPeEhHA DvfgsspgliTVJEYiZcYTCufbhtrg;

	private IndexedDictionary<int, PGQzbojcCLssivciVBIdulwPeEhHA> nYZSLcDFsbDjISoqcfjqBHANdafSA;

	public CKzrLWnyJZLZbfvmmNZunMSZGHsh(UpdateLoopSetting P_0)
	{
		nYZSLcDFsbDjISoqcfjqBHANdafSA = new IndexedDictionary<int, PGQzbojcCLssivciVBIdulwPeEhHA>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				nYZSLcDFsbDjISoqcfjqBHANdafSA.Add((int)list[i], new PGQzbojcCLssivciVBIdulwPeEhHA());
			}
		}
		iMxvATTLqyfzrTZgCaONQkBmbvlH = UpdateLoopType.Update;
		DvfgsspgliTVJEYiZcYTCufbhtrg = nYZSLcDFsbDjISoqcfjqBHANdafSA.GetValue(0);
	}

	public void pQOvzBMALFerIgHviJPpCsMuRHYBb()
	{
		KdLEkwgteQSkxGpuQFgHATIKtFGhb(ReInput.currentUpdateLoop);
		DvfgsspgliTVJEYiZcYTCufbhtrg.NFAIrZWfzivWZGJZCcaJULqnclNA();
	}

	public void LDpwVlWbVjKAeIRJWypwqGFEBOWk(UpdateLoopType P_0)
	{
		KdLEkwgteQSkxGpuQFgHATIKtFGhb(P_0);
		DvfgsspgliTVJEYiZcYTCufbhtrg.oZrhKuALopYuhcDpEkvcDAMtbkZH();
	}

	public bool CdwYChcCHBmxwIhFGqqBfgNZccuJA(int P_0, int P_1)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.AsKQgTWhPguVcbOPKBAraVfJIBhv(P_0, P_1);
	}

	public bool OYfVaXuhoosbybbIVAgcCRtuTahDA(int P_0, int P_1)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.IIyYuwYipgzCleeCTCeMFwPmbNUs(P_0, P_1);
	}

	public bool nkpWfUZqBzErOhsTFsshhQlAIZDP(int P_0, int P_1)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.JxnITzjrRUjPqZmZPwelZzXTIqtR(P_0, P_1);
	}

	public bool gPAogUgrMGsVcPWyjRNTLtNceMqx(int P_0, int P_1, bool P_2)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.PurrlNPJNrnOJfaQZWTSYSIlwvFP(P_0, P_1, P_2);
	}

	public bool ZFVjslGWSaeBDUatjejAbcUFznAOB(int P_0)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.srrXwgAOHDavCiMrdvOtXsdTCZHw(P_0);
	}

	public bool VYuMIiusGOkRsOmqvWDhIralOAFG(int P_0)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.DxrSUYKJWciSMFAEwfyOCYyYwKuqA(P_0);
	}

	public bool IUhHphuiRZJJwDRjbFnTQzgUfHgm(int P_0)
	{
		return DvfgsspgliTVJEYiZcYTCufbhtrg.fbpIRtjmxXNqebcknlIQveQZdEOn(P_0);
	}

	public void ZvljicoTwzRMdciHGONoWZZAKwFF()
	{
		for (int i = 0; i < nYZSLcDFsbDjISoqcfjqBHANdafSA.Count; i++)
		{
			nYZSLcDFsbDjISoqcfjqBHANdafSA[i].mTrNDlppvESHCceHLYQniAKmEBJW();
		}
	}

	private void KdLEkwgteQSkxGpuQFgHATIKtFGhb(UpdateLoopType P_0)
	{
		if (iMxvATTLqyfzrTZgCaONQkBmbvlH != P_0)
		{
			iMxvATTLqyfzrTZgCaONQkBmbvlH = P_0;
			DvfgsspgliTVJEYiZcYTCufbhtrg = nYZSLcDFsbDjISoqcfjqBHANdafSA.GetValue((int)P_0);
		}
	}
}
