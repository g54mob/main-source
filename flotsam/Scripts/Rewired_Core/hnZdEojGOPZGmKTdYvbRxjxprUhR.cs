using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class hnZdEojGOPZGmKTdYvbRxjxprUhR
{
	private class cjaEsYtrFXnmhAbhxagAazRpLYcl
	{
		private class ssstovqUxIQruSswWojFCgZVEiIx
		{
			private int OumPZqCLeJzDYGgOeHhchRuHvdQE;

			private iesIjcBytyKqhiwFeXluIoHdKZQK[] zgSKrjoeleqczMTcomxTyDlZtnAR;

			private nFtLeQwognPwHJnsrIUkkwnJMqsl[] eEfUgBhsElVSYiorBQNWlgJtpmEu;

			public ssstovqUxIQruSswWojFCgZVEiIx(int P_0)
			{
				OumPZqCLeJzDYGgOeHhchRuHvdQE = P_0;
				zgSKrjoeleqczMTcomxTyDlZtnAR = new iesIjcBytyKqhiwFeXluIoHdKZQK[20];
				for (int i = 0; i < zgSKrjoeleqczMTcomxTyDlZtnAR.Length; i++)
				{
					zgSKrjoeleqczMTcomxTyDlZtnAR[i] = new iesIjcBytyKqhiwFeXluIoHdKZQK();
				}
				eEfUgBhsElVSYiorBQNWlgJtpmEu = new nFtLeQwognPwHJnsrIUkkwnJMqsl[29];
				for (int j = 0; j < eEfUgBhsElVSYiorBQNWlgJtpmEu.Length; j++)
				{
					eEfUgBhsElVSYiorBQNWlgJtpmEu[j] = new nFtLeQwognPwHJnsrIUkkwnJMqsl(j);
				}
			}

			public void OBiRXgRCPyAgWhfBjlIyRXjhwCLEA()
			{
				for (int i = 0; i < zgSKrjoeleqczMTcomxTyDlZtnAR.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(OumPZqCLeJzDYGgOeHhchRuHvdQE, i);
					zgSKrjoeleqczMTcomxTyDlZtnAR[i].GvydVxLTMxkdJJTrkaeFGIQkYhmQ(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < eEfUgBhsElVSYiorBQNWlgJtpmEu.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(OumPZqCLeJzDYGgOeHhchRuHvdQE, j);
					eEfUgBhsElVSYiorBQNWlgJtpmEu[j].mbgwOjckJHlnpuNnsYNNFRHIVoGU(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void oErYySMeEgSPJtltADQvfDfWBZmf()
			{
				for (int i = 0; i < zgSKrjoeleqczMTcomxTyDlZtnAR.Length; i++)
				{
					zgSKrjoeleqczMTcomxTyDlZtnAR[i].GPDzevREWrIPEjXaomEcbkjaPWpG = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(OumPZqCLeJzDYGgOeHhchRuHvdQE, i);
				}
				for (int j = 0; j < eEfUgBhsElVSYiorBQNWlgJtpmEu.Length; j++)
				{
					eEfUgBhsElVSYiorBQNWlgJtpmEu[j].EzOZbdbMuACNJCRBIZycfahpHyuGb = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(OumPZqCLeJzDYGgOeHhchRuHvdQE, j);
				}
			}

			public bool uvichEUecjzGNoEMTyZTKWmiPAhk(int P_0)
			{
				if (P_0 < 0 || P_0 >= zgSKrjoeleqczMTcomxTyDlZtnAR.Length)
				{
					return false;
				}
				return zgSKrjoeleqczMTcomxTyDlZtnAR[P_0].GPDzevREWrIPEjXaomEcbkjaPWpG;
			}

			public bool XtXAaucPvqhGeZfVVWkgNNnlXVuj(int P_0)
			{
				if (P_0 < 0 || P_0 >= zgSKrjoeleqczMTcomxTyDlZtnAR.Length)
				{
					return false;
				}
				return zgSKrjoeleqczMTcomxTyDlZtnAR[P_0].NjdUUfJncsPzguDjlrlkdEXhBoWu;
			}

			public bool lasEEzkITMvlwNhAQNbAaWFgXERY(int P_0)
			{
				if (P_0 < 0 || P_0 >= zgSKrjoeleqczMTcomxTyDlZtnAR.Length)
				{
					return false;
				}
				return zgSKrjoeleqczMTcomxTyDlZtnAR[P_0].mSUFEAfvOzbItDvkvtRXTWKqBhRAA;
			}

			public float YNAzJaBmJNjEleqQRXJCQOEhfQIGA(int P_0)
			{
				if (P_0 < 0 || P_0 >= eEfUgBhsElVSYiorBQNWlgJtpmEu.Length)
				{
					return 0f;
				}
				return eEfUgBhsElVSYiorBQNWlgJtpmEu[P_0].EzOZbdbMuACNJCRBIZycfahpHyuGb;
			}

			public bool nEvEgGfZsVciYvWUIKSHQpbKyGJfA(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= eEfUgBhsElVSYiorBQNWlgJtpmEu.Length)
				{
					return false;
				}
				return eEfUgBhsElVSYiorBQNWlgJtpmEu[P_0].iFNFqOjSRtYcPSNyPztZXtXcpNPt(P_1);
			}

			public void lVYazWqABiaYyeleeWyMRfRNKGXjA()
			{
				for (int i = 0; i < zgSKrjoeleqczMTcomxTyDlZtnAR.Length; i++)
				{
					zgSKrjoeleqczMTcomxTyDlZtnAR[i].pOeTMsNkuLizNRCgBUlPmsBnEDUy();
				}
				for (int j = 0; j < eEfUgBhsElVSYiorBQNWlgJtpmEu.Length; j++)
				{
					eEfUgBhsElVSYiorBQNWlgJtpmEu[j].eavJYdnSgFZfJbVxPUHmqIwDpfUJ();
				}
			}
		}

		private class tACdsTopGwuBkGUnozJOASgyLnCi
		{
			private iesIjcBytyKqhiwFeXluIoHdKZQK[] GPkeCgfPZSckffBdAZhaJpMEuLmRA;

			public tACdsTopGwuBkGUnozJOASgyLnCi()
			{
				GPkeCgfPZSckffBdAZhaJpMEuLmRA = new iesIjcBytyKqhiwFeXluIoHdKZQK[7];
				for (int i = 0; i < GPkeCgfPZSckffBdAZhaJpMEuLmRA.Length; i++)
				{
					GPkeCgfPZSckffBdAZhaJpMEuLmRA[i] = new iesIjcBytyKqhiwFeXluIoHdKZQK();
				}
			}

			public void aoARxWYDXctSoqDbqWbaTCXxTLZq()
			{
				for (int i = 0; i < GPkeCgfPZSckffBdAZhaJpMEuLmRA.Length; i++)
				{
					GPkeCgfPZSckffBdAZhaJpMEuLmRA[i].GPDzevREWrIPEjXaomEcbkjaPWpG = Input.GetButton("MouseButton" + i);
				}
			}

			public bool kyMDQuyYAJjkxefuiqhaAobeagYAA(int P_0)
			{
				if (P_0 < 0 || P_0 >= GPkeCgfPZSckffBdAZhaJpMEuLmRA.Length)
				{
					return false;
				}
				return GPkeCgfPZSckffBdAZhaJpMEuLmRA[P_0].GPDzevREWrIPEjXaomEcbkjaPWpG;
			}

			public bool SkMCnBefLkVnJIsUHgUdJEQdEzDhb(int P_0)
			{
				if (P_0 < 0 || P_0 >= GPkeCgfPZSckffBdAZhaJpMEuLmRA.Length)
				{
					return false;
				}
				return GPkeCgfPZSckffBdAZhaJpMEuLmRA[P_0].NjdUUfJncsPzguDjlrlkdEXhBoWu;
			}

			public bool bmTKQCDQViVJLekpiIMpdKVckEVO(int P_0)
			{
				if (P_0 < 0 || P_0 >= GPkeCgfPZSckffBdAZhaJpMEuLmRA.Length)
				{
					return false;
				}
				return GPkeCgfPZSckffBdAZhaJpMEuLmRA[P_0].mSUFEAfvOzbItDvkvtRXTWKqBhRAA;
			}

			public void asZDqJwDrQBRqrrhLUMNnfLsdeXz()
			{
				for (int i = 0; i < GPkeCgfPZSckffBdAZhaJpMEuLmRA.Length; i++)
				{
					GPkeCgfPZSckffBdAZhaJpMEuLmRA[i].pOeTMsNkuLizNRCgBUlPmsBnEDUy();
				}
			}
		}

		private class iesIjcBytyKqhiwFeXluIoHdKZQK
		{
			private bool ZUvsmtwTLIwuFvobIvYowVlLGnOr;

			private bool nsUAxLKFlfhGwaiRiepxGoBeHoekA;

			public bool GPDzevREWrIPEjXaomEcbkjaPWpG
			{
				get
				{
					return ZUvsmtwTLIwuFvobIvYowVlLGnOr;
				}
				set
				{
					nsUAxLKFlfhGwaiRiepxGoBeHoekA = ZUvsmtwTLIwuFvobIvYowVlLGnOr;
					ZUvsmtwTLIwuFvobIvYowVlLGnOr = zUvsmtwTLIwuFvobIvYowVlLGnOr;
				}
			}

			public bool NjdUUfJncsPzguDjlrlkdEXhBoWu
			{
				get
				{
					if (ZUvsmtwTLIwuFvobIvYowVlLGnOr)
					{
						return !nsUAxLKFlfhGwaiRiepxGoBeHoekA;
					}
					return false;
				}
			}

			public bool mSUFEAfvOzbItDvkvtRXTWKqBhRAA
			{
				get
				{
					if (nsUAxLKFlfhGwaiRiepxGoBeHoekA)
					{
						return !ZUvsmtwTLIwuFvobIvYowVlLGnOr;
					}
					return false;
				}
			}

			public void GvydVxLTMxkdJJTrkaeFGIQkYhmQ(bool P_0)
			{
				ZUvsmtwTLIwuFvobIvYowVlLGnOr = P_0;
				nsUAxLKFlfhGwaiRiepxGoBeHoekA = P_0;
			}

			public void pOeTMsNkuLizNRCgBUlPmsBnEDUy()
			{
				ZUvsmtwTLIwuFvobIvYowVlLGnOr = false;
				nsUAxLKFlfhGwaiRiepxGoBeHoekA = false;
			}
		}

		private class nFtLeQwognPwHJnsrIUkkwnJMqsl
		{
			private int arDBvANmXKEvabbivuSWGGqFCRmXA;

			private float tGmelLCsCtoGmkfGPiCHlyGFGErxA;

			private float VDKMTOqwRzmYdYpxFezQFJrjSsfR;

			public float EzOZbdbMuACNJCRBIZycfahpHyuGb
			{
				get
				{
					return tGmelLCsCtoGmkfGPiCHlyGFGErxA;
				}
				set
				{
					tGmelLCsCtoGmkfGPiCHlyGFGErxA = num;
				}
			}

			public nFtLeQwognPwHJnsrIUkkwnJMqsl(int P_0)
			{
				arDBvANmXKEvabbivuSWGGqFCRmXA = P_0;
			}

			public void mbgwOjckJHlnpuNnsYNNFRHIVoGU(float P_0)
			{
				VDKMTOqwRzmYdYpxFezQFJrjSsfR = P_0;
				tGmelLCsCtoGmkfGPiCHlyGFGErxA = P_0;
			}

			public bool iFNFqOjSRtYcPSNyPztZXtXcpNPt(bool P_0)
			{
				float num = tGmelLCsCtoGmkfGPiCHlyGFGErxA - VDKMTOqwRzmYdYpxFezQFJrjSsfR;
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

			public void eavJYdnSgFZfJbVxPUHmqIwDpfUJ()
			{
				tGmelLCsCtoGmkfGPiCHlyGFGErxA = 0f;
				VDKMTOqwRzmYdYpxFezQFJrjSsfR = 0f;
			}
		}

		private ssstovqUxIQruSswWojFCgZVEiIx[] MmpjHdbNHYCFjBuYUgjydoXcROaR;

		private tACdsTopGwuBkGUnozJOASgyLnCi qXmisIkBDHSrIhWKWpSToCulKcXA;

		public cjaEsYtrFXnmhAbhxagAazRpLYcl()
		{
			MmpjHdbNHYCFjBuYUgjydoXcROaR = new ssstovqUxIQruSswWojFCgZVEiIx[16];
			for (int i = 0; i < MmpjHdbNHYCFjBuYUgjydoXcROaR.Length; i++)
			{
				MmpjHdbNHYCFjBuYUgjydoXcROaR[i] = new ssstovqUxIQruSswWojFCgZVEiIx(i);
			}
			qXmisIkBDHSrIhWKWpSToCulKcXA = new tACdsTopGwuBkGUnozJOASgyLnCi();
		}

		public void aJnbfDDsThehPaEplMTXWwAUesqE()
		{
			for (int i = 0; i < MmpjHdbNHYCFjBuYUgjydoXcROaR.Length; i++)
			{
				MmpjHdbNHYCFjBuYUgjydoXcROaR[i].OBiRXgRCPyAgWhfBjlIyRXjhwCLEA();
			}
		}

		public void NLNIkWAknxBPyNrgoCiXPKfLzRIh()
		{
			for (int i = 0; i < MmpjHdbNHYCFjBuYUgjydoXcROaR.Length; i++)
			{
				MmpjHdbNHYCFjBuYUgjydoXcROaR[i].oErYySMeEgSPJtltADQvfDfWBZmf();
			}
			qXmisIkBDHSrIhWKWpSToCulKcXA.aoARxWYDXctSoqDbqWbaTCXxTLZq();
		}

		public bool xeklFpSUEclAdSyUekcSuHUpOFwM(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= MmpjHdbNHYCFjBuYUgjydoXcROaR.Length)
			{
				return false;
			}
			return MmpjHdbNHYCFjBuYUgjydoXcROaR[P_0].uvichEUecjzGNoEMTyZTKWmiPAhk(P_1);
		}

		public bool dIYvvWGaauankNoLfEmzXgSODCFG(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= MmpjHdbNHYCFjBuYUgjydoXcROaR.Length)
			{
				return false;
			}
			return MmpjHdbNHYCFjBuYUgjydoXcROaR[P_0].XtXAaucPvqhGeZfVVWkgNNnlXVuj(P_1);
		}

		public bool mVVesJxpMMzItymKbOGEJmkrDmcaA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= MmpjHdbNHYCFjBuYUgjydoXcROaR.Length)
			{
				return false;
			}
			return MmpjHdbNHYCFjBuYUgjydoXcROaR[P_0].lasEEzkITMvlwNhAQNbAaWFgXERY(P_1);
		}

		public bool ygDnMrVTOjjDWGJXpcppDSnZyvMhA(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= MmpjHdbNHYCFjBuYUgjydoXcROaR.Length)
			{
				return false;
			}
			return MmpjHdbNHYCFjBuYUgjydoXcROaR[P_0].nEvEgGfZsVciYvWUIKSHQpbKyGJfA(P_1, P_2);
		}

		public bool BgZtHWInMZEiZLwwBEwKdDGxcDCCb(int P_0)
		{
			return qXmisIkBDHSrIhWKWpSToCulKcXA.kyMDQuyYAJjkxefuiqhaAobeagYAA(P_0);
		}

		public bool cZRyvoEKTmVJXeAJEWQfItBojQfO(int P_0)
		{
			return qXmisIkBDHSrIhWKWpSToCulKcXA.SkMCnBefLkVnJIsUHgUdJEQdEzDhb(P_0);
		}

		public bool MQHlnVnIgVQEtYehDiLhfpxbTAVv(int P_0)
		{
			return qXmisIkBDHSrIhWKWpSToCulKcXA.bmTKQCDQViVJLekpiIMpdKVckEVO(P_0);
		}

		public void LWFeBRdAsGaVNBMEtByUBsvOVFKFA()
		{
			for (int i = 0; i < MmpjHdbNHYCFjBuYUgjydoXcROaR.Length; i++)
			{
				MmpjHdbNHYCFjBuYUgjydoXcROaR[i].lVYazWqABiaYyeleeWyMRfRNKGXjA();
			}
			qXmisIkBDHSrIhWKWpSToCulKcXA.asZDqJwDrQBRqrrhLUMNnfLsdeXz();
		}
	}

	private UpdateLoopType RjNxbnTfzuyqcoQfuoKiEioMMveT;

	private cjaEsYtrFXnmhAbhxagAazRpLYcl qwTCLWlDswuGEfEfhiEskQAFNfcoA;

	private IndexedDictionary<int, cjaEsYtrFXnmhAbhxagAazRpLYcl> WYbbrWTzfdtyTjUtWfBZNKbtcamo;

	public hnZdEojGOPZGmKTdYvbRxjxprUhR(UpdateLoopSetting P_0)
	{
		WYbbrWTzfdtyTjUtWfBZNKbtcamo = new IndexedDictionary<int, cjaEsYtrFXnmhAbhxagAazRpLYcl>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				WYbbrWTzfdtyTjUtWfBZNKbtcamo.Add((int)list[i], new cjaEsYtrFXnmhAbhxagAazRpLYcl());
			}
		}
		RjNxbnTfzuyqcoQfuoKiEioMMveT = UpdateLoopType.Update;
		qwTCLWlDswuGEfEfhiEskQAFNfcoA = WYbbrWTzfdtyTjUtWfBZNKbtcamo.GetValue(0);
	}

	public void KfqyYhOEQNciLqeyKufSyGhIcTBjA()
	{
		bqvCXSbllCyvkMUvyWIgNVdwFFFdA(ReInput.currentUpdateLoop);
		qwTCLWlDswuGEfEfhiEskQAFNfcoA.aJnbfDDsThehPaEplMTXWwAUesqE();
	}

	public void goPBzRIpIzZCxfCIkBOVyRmqBPZt(UpdateLoopType P_0)
	{
		bqvCXSbllCyvkMUvyWIgNVdwFFFdA(P_0);
		qwTCLWlDswuGEfEfhiEskQAFNfcoA.NLNIkWAknxBPyNrgoCiXPKfLzRIh();
	}

	public bool hOGxnZcmOZggfAdIuLMwFlyphyboA(int P_0, int P_1)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.xeklFpSUEclAdSyUekcSuHUpOFwM(P_0, P_1);
	}

	public bool fYZsPduUbgounCMDdaYNFdIMfeoy(int P_0, int P_1)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.dIYvvWGaauankNoLfEmzXgSODCFG(P_0, P_1);
	}

	public bool QGJYEeXmUbCiFdYEdPQGOdGykNUFb(int P_0, int P_1)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.mVVesJxpMMzItymKbOGEJmkrDmcaA(P_0, P_1);
	}

	public bool REuPFkucNEAEbDulBGlaPBiAgYvYA(int P_0, int P_1, bool P_2)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.ygDnMrVTOjjDWGJXpcppDSnZyvMhA(P_0, P_1, P_2);
	}

	public bool isxbJPWXXwWQOBkkNgNdkphPDxXM(int P_0)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.BgZtHWInMZEiZLwwBEwKdDGxcDCCb(P_0);
	}

	public bool kVAjBIwcfAlvltUhNikWKDIFKEQx(int P_0)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.cZRyvoEKTmVJXeAJEWQfItBojQfO(P_0);
	}

	public bool nuTmTLkALRWUhcyJTzpcWNeqlUbd(int P_0)
	{
		return qwTCLWlDswuGEfEfhiEskQAFNfcoA.MQHlnVnIgVQEtYehDiLhfpxbTAVv(P_0);
	}

	public void swVQaUuPhfMqwTaKehsNWKcowOGS()
	{
		for (int i = 0; i < WYbbrWTzfdtyTjUtWfBZNKbtcamo.Count; i++)
		{
			WYbbrWTzfdtyTjUtWfBZNKbtcamo[i].LWFeBRdAsGaVNBMEtByUBsvOVFKFA();
		}
	}

	private void bqvCXSbllCyvkMUvyWIgNVdwFFFdA(UpdateLoopType P_0)
	{
		if (RjNxbnTfzuyqcoQfuoKiEioMMveT != P_0)
		{
			RjNxbnTfzuyqcoQfuoKiEioMMveT = P_0;
			qwTCLWlDswuGEfEfhiEskQAFNfcoA = WYbbrWTzfdtyTjUtWfBZNKbtcamo.GetValue((int)P_0);
		}
	}
}
