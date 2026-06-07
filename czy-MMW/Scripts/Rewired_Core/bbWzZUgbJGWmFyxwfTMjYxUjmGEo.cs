using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class bbWzZUgbJGWmFyxwfTMjYxUjmGEo
{
	private class qybcNagkCUzTKgQiQyHsJGidtMBT
	{
		private class aplhVHxjsHaXDmOxrFvhzhwFaujr
		{
			private int EnjsYfZZOOBBrqypDexGWaoTjfls;

			private aBpoBOteivGCMOXSTAWEtvytpNfT[] ttBiVTvCarGSEiBrXMljTFSTbmpg;

			private xHceWuHpboWbwSvfChnWTTYVNQLbA[] kBmxkjuNeaeTnCisiwCiUcspwchL;

			public aplhVHxjsHaXDmOxrFvhzhwFaujr(int P_0)
			{
				EnjsYfZZOOBBrqypDexGWaoTjfls = P_0;
				ttBiVTvCarGSEiBrXMljTFSTbmpg = new aBpoBOteivGCMOXSTAWEtvytpNfT[20];
				for (int i = 0; i < ttBiVTvCarGSEiBrXMljTFSTbmpg.Length; i++)
				{
					ttBiVTvCarGSEiBrXMljTFSTbmpg[i] = new aBpoBOteivGCMOXSTAWEtvytpNfT();
				}
				kBmxkjuNeaeTnCisiwCiUcspwchL = new xHceWuHpboWbwSvfChnWTTYVNQLbA[29];
				for (int j = 0; j < kBmxkjuNeaeTnCisiwCiUcspwchL.Length; j++)
				{
					kBmxkjuNeaeTnCisiwCiUcspwchL[j] = new xHceWuHpboWbwSvfChnWTTYVNQLbA(j);
				}
			}

			public void QWzKEAYSphYOxHOfKtHKgFOpQugJ()
			{
				for (int i = 0; i < ttBiVTvCarGSEiBrXMljTFSTbmpg.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(EnjsYfZZOOBBrqypDexGWaoTjfls, i);
					ttBiVTvCarGSEiBrXMljTFSTbmpg[i].AjxzAVAoDkcLoavaJjZfJjrwonLtA(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < kBmxkjuNeaeTnCisiwCiUcspwchL.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(EnjsYfZZOOBBrqypDexGWaoTjfls, j);
					kBmxkjuNeaeTnCisiwCiUcspwchL[j].yJdPmJtcQIFTYKpgLymfoBeCQafr(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void iHmdBygXHhsueLDylTaPMMMUCNPIb()
			{
				for (int i = 0; i < ttBiVTvCarGSEiBrXMljTFSTbmpg.Length; i++)
				{
					ttBiVTvCarGSEiBrXMljTFSTbmpg[i].AUUoaLGKHqbqpKHIDmBMJMWcrHMjA = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(EnjsYfZZOOBBrqypDexGWaoTjfls, i);
				}
				for (int j = 0; j < kBmxkjuNeaeTnCisiwCiUcspwchL.Length; j++)
				{
					kBmxkjuNeaeTnCisiwCiUcspwchL[j].UGZquXuzVHlHszkGtPjORtCvoXFI = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(EnjsYfZZOOBBrqypDexGWaoTjfls, j);
				}
			}

			public bool mIpykkFovcDqwCIHazabtkPeYJIN(int P_0)
			{
				if (P_0 < 0 || P_0 >= ttBiVTvCarGSEiBrXMljTFSTbmpg.Length)
				{
					return false;
				}
				return ttBiVTvCarGSEiBrXMljTFSTbmpg[P_0].AUUoaLGKHqbqpKHIDmBMJMWcrHMjA;
			}

			public bool NkAJVIbPUxnTBfvWirbYsUSxVQZk(int P_0)
			{
				if (P_0 < 0 || P_0 >= ttBiVTvCarGSEiBrXMljTFSTbmpg.Length)
				{
					return false;
				}
				return ttBiVTvCarGSEiBrXMljTFSTbmpg[P_0].NYkCVNfAzdCzNNGkUdYQWGkhgwdnA;
			}

			public bool zlnRSBPQUJBaPJbHhEEenqeogSqEA(int P_0)
			{
				if (P_0 < 0 || P_0 >= ttBiVTvCarGSEiBrXMljTFSTbmpg.Length)
				{
					return false;
				}
				return ttBiVTvCarGSEiBrXMljTFSTbmpg[P_0].yqLJOmsPNmiKANDvYHujiOrcGriEA;
			}

			public float YwLaAYSDQIbsShERkVugatzhEYpzA(int P_0)
			{
				if (P_0 < 0 || P_0 >= kBmxkjuNeaeTnCisiwCiUcspwchL.Length)
				{
					return 0f;
				}
				return kBmxkjuNeaeTnCisiwCiUcspwchL[P_0].UGZquXuzVHlHszkGtPjORtCvoXFI;
			}

			public bool lZkxTuMktMUofoTrptfbSAQUWRwH(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= kBmxkjuNeaeTnCisiwCiUcspwchL.Length)
				{
					return false;
				}
				return kBmxkjuNeaeTnCisiwCiUcspwchL[P_0].aaInKeiEMwGWaqfzwZGzwJqmkZaK(P_1);
			}

			public void fMTzwwduSvikNDvjFlDmOOwTQUgr()
			{
				for (int i = 0; i < ttBiVTvCarGSEiBrXMljTFSTbmpg.Length; i++)
				{
					ttBiVTvCarGSEiBrXMljTFSTbmpg[i].vKfaFKSAzIXJexqhmqWhVZepVTxP();
				}
				for (int j = 0; j < kBmxkjuNeaeTnCisiwCiUcspwchL.Length; j++)
				{
					kBmxkjuNeaeTnCisiwCiUcspwchL[j].ceuDOBcQPOcluVXOwIlSDONDPhfX();
				}
			}
		}

		private class tgZBgtHjNvRSPdgwXpUuOfZudJleb
		{
			private aBpoBOteivGCMOXSTAWEtvytpNfT[] KmlNAWmBQXQsQjkwzMbUWKtKJPLi;

			public tgZBgtHjNvRSPdgwXpUuOfZudJleb()
			{
				KmlNAWmBQXQsQjkwzMbUWKtKJPLi = new aBpoBOteivGCMOXSTAWEtvytpNfT[7];
				for (int i = 0; i < KmlNAWmBQXQsQjkwzMbUWKtKJPLi.Length; i++)
				{
					KmlNAWmBQXQsQjkwzMbUWKtKJPLi[i] = new aBpoBOteivGCMOXSTAWEtvytpNfT();
				}
			}

			public void qVJkaCTAdlmePYqpHKnCgsJjDGmf()
			{
				for (int i = 0; i < KmlNAWmBQXQsQjkwzMbUWKtKJPLi.Length; i++)
				{
					KmlNAWmBQXQsQjkwzMbUWKtKJPLi[i].AUUoaLGKHqbqpKHIDmBMJMWcrHMjA = Input.GetButton("MouseButton" + i);
				}
			}

			public bool yhZNKYhLaEAdKKGfZScUtfWeGsls(int P_0)
			{
				if (P_0 < 0 || P_0 >= KmlNAWmBQXQsQjkwzMbUWKtKJPLi.Length)
				{
					return false;
				}
				return KmlNAWmBQXQsQjkwzMbUWKtKJPLi[P_0].AUUoaLGKHqbqpKHIDmBMJMWcrHMjA;
			}

			public bool EsFwwtiFEpTkgGNRyzSRdrWzhVaD(int P_0)
			{
				if (P_0 < 0 || P_0 >= KmlNAWmBQXQsQjkwzMbUWKtKJPLi.Length)
				{
					return false;
				}
				return KmlNAWmBQXQsQjkwzMbUWKtKJPLi[P_0].NYkCVNfAzdCzNNGkUdYQWGkhgwdnA;
			}

			public bool tvCLHsYbOjfnyEpqPhCPSasmfSkv(int P_0)
			{
				if (P_0 < 0 || P_0 >= KmlNAWmBQXQsQjkwzMbUWKtKJPLi.Length)
				{
					return false;
				}
				return KmlNAWmBQXQsQjkwzMbUWKtKJPLi[P_0].yqLJOmsPNmiKANDvYHujiOrcGriEA;
			}

			public void uICxCjjjuFTxZFlgsqbdWagwLugt()
			{
				for (int i = 0; i < KmlNAWmBQXQsQjkwzMbUWKtKJPLi.Length; i++)
				{
					KmlNAWmBQXQsQjkwzMbUWKtKJPLi[i].vKfaFKSAzIXJexqhmqWhVZepVTxP();
				}
			}
		}

		private class aBpoBOteivGCMOXSTAWEtvytpNfT
		{
			private bool JhqnQFtEGVeKoDPgzWpMJYQRLzpl;

			private bool xtLYVpDNwuaaHMoAThQZdRcsDcPR;

			public bool AUUoaLGKHqbqpKHIDmBMJMWcrHMjA
			{
				get
				{
					return JhqnQFtEGVeKoDPgzWpMJYQRLzpl;
				}
				set
				{
					xtLYVpDNwuaaHMoAThQZdRcsDcPR = JhqnQFtEGVeKoDPgzWpMJYQRLzpl;
					JhqnQFtEGVeKoDPgzWpMJYQRLzpl = jhqnQFtEGVeKoDPgzWpMJYQRLzpl;
				}
			}

			public bool NYkCVNfAzdCzNNGkUdYQWGkhgwdnA
			{
				get
				{
					if (JhqnQFtEGVeKoDPgzWpMJYQRLzpl)
					{
						return !xtLYVpDNwuaaHMoAThQZdRcsDcPR;
					}
					return false;
				}
			}

			public bool yqLJOmsPNmiKANDvYHujiOrcGriEA
			{
				get
				{
					if (xtLYVpDNwuaaHMoAThQZdRcsDcPR)
					{
						return !JhqnQFtEGVeKoDPgzWpMJYQRLzpl;
					}
					return false;
				}
			}

			public void AjxzAVAoDkcLoavaJjZfJjrwonLtA(bool P_0)
			{
				JhqnQFtEGVeKoDPgzWpMJYQRLzpl = P_0;
				xtLYVpDNwuaaHMoAThQZdRcsDcPR = P_0;
			}

			public void vKfaFKSAzIXJexqhmqWhVZepVTxP()
			{
				JhqnQFtEGVeKoDPgzWpMJYQRLzpl = false;
				xtLYVpDNwuaaHMoAThQZdRcsDcPR = false;
			}
		}

		private class xHceWuHpboWbwSvfChnWTTYVNQLbA
		{
			private int yUKviiEyMXCRTRPpEHnslJHXBLPv;

			private float dejwfbrnRooWDLxNirSjHczJKhSI;

			private float BJUWibfIayeWXeekqSmHmGyxaOlb;

			public float UGZquXuzVHlHszkGtPjORtCvoXFI
			{
				get
				{
					return dejwfbrnRooWDLxNirSjHczJKhSI;
				}
				set
				{
					dejwfbrnRooWDLxNirSjHczJKhSI = num;
				}
			}

			public xHceWuHpboWbwSvfChnWTTYVNQLbA(int P_0)
			{
				yUKviiEyMXCRTRPpEHnslJHXBLPv = P_0;
			}

			public void yJdPmJtcQIFTYKpgLymfoBeCQafr(float P_0)
			{
				BJUWibfIayeWXeekqSmHmGyxaOlb = P_0;
				dejwfbrnRooWDLxNirSjHczJKhSI = P_0;
			}

			public bool aaInKeiEMwGWaqfzwZGzwJqmkZaK(bool P_0)
			{
				float num = dejwfbrnRooWDLxNirSjHczJKhSI - BJUWibfIayeWXeekqSmHmGyxaOlb;
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

			public void ceuDOBcQPOcluVXOwIlSDONDPhfX()
			{
				dejwfbrnRooWDLxNirSjHczJKhSI = 0f;
				BJUWibfIayeWXeekqSmHmGyxaOlb = 0f;
			}
		}

		private aplhVHxjsHaXDmOxrFvhzhwFaujr[] WvcObJkjSRnsCnuHtOPGIjwkaEJN;

		private tgZBgtHjNvRSPdgwXpUuOfZudJleb aaGOnSXEWOPkSFJBbCEabLleFWDRA;

		public qybcNagkCUzTKgQiQyHsJGidtMBT()
		{
			WvcObJkjSRnsCnuHtOPGIjwkaEJN = new aplhVHxjsHaXDmOxrFvhzhwFaujr[16];
			for (int i = 0; i < WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length; i++)
			{
				WvcObJkjSRnsCnuHtOPGIjwkaEJN[i] = new aplhVHxjsHaXDmOxrFvhzhwFaujr(i);
			}
			aaGOnSXEWOPkSFJBbCEabLleFWDRA = new tgZBgtHjNvRSPdgwXpUuOfZudJleb();
		}

		public void iyqOuzApnihWoSdFSVftbwLSEaLs()
		{
			for (int i = 0; i < WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length; i++)
			{
				WvcObJkjSRnsCnuHtOPGIjwkaEJN[i].QWzKEAYSphYOxHOfKtHKgFOpQugJ();
			}
		}

		public void LQEaVgCDqsGhLxldXNnbowQJejhJA()
		{
			for (int i = 0; i < WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length; i++)
			{
				WvcObJkjSRnsCnuHtOPGIjwkaEJN[i].iHmdBygXHhsueLDylTaPMMMUCNPIb();
			}
			aaGOnSXEWOPkSFJBbCEabLleFWDRA.qVJkaCTAdlmePYqpHKnCgsJjDGmf();
		}

		public bool phQGLYTHfNeGEkHDuXyCPbDnDFpB(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length)
			{
				return false;
			}
			return WvcObJkjSRnsCnuHtOPGIjwkaEJN[P_0].mIpykkFovcDqwCIHazabtkPeYJIN(P_1);
		}

		public bool xbNcuycLxxEIVUzGYVbLVyVUjDuSA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length)
			{
				return false;
			}
			return WvcObJkjSRnsCnuHtOPGIjwkaEJN[P_0].NkAJVIbPUxnTBfvWirbYsUSxVQZk(P_1);
		}

		public bool cIAxadseDXatQGLVCnDsiTLfaSZE(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length)
			{
				return false;
			}
			return WvcObJkjSRnsCnuHtOPGIjwkaEJN[P_0].zlnRSBPQUJBaPJbHhEEenqeogSqEA(P_1);
		}

		public bool iBQVVdCNiibFfkEnKYfDndOLbfbk(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length)
			{
				return false;
			}
			return WvcObJkjSRnsCnuHtOPGIjwkaEJN[P_0].lZkxTuMktMUofoTrptfbSAQUWRwH(P_1, P_2);
		}

		public bool NCESwgXXJCQFwputoZJieqtjNylG(int P_0)
		{
			return aaGOnSXEWOPkSFJBbCEabLleFWDRA.yhZNKYhLaEAdKKGfZScUtfWeGsls(P_0);
		}

		public bool oiGciOHeMbRteQWAdJpRzOeqaYMEA(int P_0)
		{
			return aaGOnSXEWOPkSFJBbCEabLleFWDRA.EsFwwtiFEpTkgGNRyzSRdrWzhVaD(P_0);
		}

		public bool OSYFkfHwnWYkQMgaqnkRpASjjMmlA(int P_0)
		{
			return aaGOnSXEWOPkSFJBbCEabLleFWDRA.tvCLHsYbOjfnyEpqPhCPSasmfSkv(P_0);
		}

		public void XlYFlxCopVNhkxfRIJHmEFWJMFlRc()
		{
			for (int i = 0; i < WvcObJkjSRnsCnuHtOPGIjwkaEJN.Length; i++)
			{
				WvcObJkjSRnsCnuHtOPGIjwkaEJN[i].fMTzwwduSvikNDvjFlDmOOwTQUgr();
			}
			aaGOnSXEWOPkSFJBbCEabLleFWDRA.uICxCjjjuFTxZFlgsqbdWagwLugt();
		}
	}

	private UpdateLoopType DwSbuXECsbuWXGPeXrxOnNLWThPn;

	private qybcNagkCUzTKgQiQyHsJGidtMBT okQYSqwIzxxmnRAyIgxGaxzVhvDiA;

	private IndexedDictionary<int, qybcNagkCUzTKgQiQyHsJGidtMBT> WqwzeeEIykmIaNKwxPyzsTAlTkFs;

	public bbWzZUgbJGWmFyxwfTMjYxUjmGEo(UpdateLoopSetting P_0)
	{
		WqwzeeEIykmIaNKwxPyzsTAlTkFs = new IndexedDictionary<int, qybcNagkCUzTKgQiQyHsJGidtMBT>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				WqwzeeEIykmIaNKwxPyzsTAlTkFs.Add((int)list[i], new qybcNagkCUzTKgQiQyHsJGidtMBT());
			}
		}
		DwSbuXECsbuWXGPeXrxOnNLWThPn = UpdateLoopType.Update;
		okQYSqwIzxxmnRAyIgxGaxzVhvDiA = WqwzeeEIykmIaNKwxPyzsTAlTkFs.GetValue(0);
	}

	public void KBfELZTTVAuSiIdjtUCyLIEQPRyl()
	{
		tncWaiotiZBmBqjcRfxIewMwmRqu(ReInput.currentUpdateLoop);
		okQYSqwIzxxmnRAyIgxGaxzVhvDiA.iyqOuzApnihWoSdFSVftbwLSEaLs();
	}

	public void wSKdYzCZTkwtADDTPynbwZDkCZwVA(UpdateLoopType P_0)
	{
		tncWaiotiZBmBqjcRfxIewMwmRqu(P_0);
		okQYSqwIzxxmnRAyIgxGaxzVhvDiA.LQEaVgCDqsGhLxldXNnbowQJejhJA();
	}

	public bool bNVapffZHSUtSPEHTxkYGeRxwpUj(int P_0, int P_1)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.phQGLYTHfNeGEkHDuXyCPbDnDFpB(P_0, P_1);
	}

	public bool lHOUeFfEuphAQcXYYhvpmGhKaqBP(int P_0, int P_1)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.xbNcuycLxxEIVUzGYVbLVyVUjDuSA(P_0, P_1);
	}

	public bool GTUcZMSxTuAQeyANMWloQCjaIDpbA(int P_0, int P_1)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.cIAxadseDXatQGLVCnDsiTLfaSZE(P_0, P_1);
	}

	public bool XZjUMRfEjTqeCWoDqUdKcEVQYOYH(int P_0, int P_1, bool P_2)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.iBQVVdCNiibFfkEnKYfDndOLbfbk(P_0, P_1, P_2);
	}

	public bool mMsMObJvMhgIvjproyrZHUKPdgsL(int P_0)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.NCESwgXXJCQFwputoZJieqtjNylG(P_0);
	}

	public bool knRjgyxqmJnRUBcwguLgfEdFeOrdA(int P_0)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.oiGciOHeMbRteQWAdJpRzOeqaYMEA(P_0);
	}

	public bool zKAipjplXAGaGIlnifEOvMseKjSS(int P_0)
	{
		return okQYSqwIzxxmnRAyIgxGaxzVhvDiA.OSYFkfHwnWYkQMgaqnkRpASjjMmlA(P_0);
	}

	public void ilKAVgBbkmjqBfvThPTxUvZQoSlFB()
	{
		for (int i = 0; i < WqwzeeEIykmIaNKwxPyzsTAlTkFs.Count; i++)
		{
			WqwzeeEIykmIaNKwxPyzsTAlTkFs[i].XlYFlxCopVNhkxfRIJHmEFWJMFlRc();
		}
	}

	private void tncWaiotiZBmBqjcRfxIewMwmRqu(UpdateLoopType P_0)
	{
		if (DwSbuXECsbuWXGPeXrxOnNLWThPn != P_0)
		{
			DwSbuXECsbuWXGPeXrxOnNLWThPn = P_0;
			okQYSqwIzxxmnRAyIgxGaxzVhvDiA = WqwzeeEIykmIaNKwxPyzsTAlTkFs.GetValue((int)P_0);
		}
	}
}
