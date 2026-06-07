using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class eBtTLjQVbrrAMXmgeRiWszpFXAyd
{
	private class bZUDLdCeYvKIVHKsHOYPbDJPHpxk
	{
		private class rIIRxMHccuwQGVQhacWANrVznlHR
		{
			private int xOAjeWzKfzBIbGMiqccIklzUbliYA;

			private rkAhuVDrcSQTTxJKWCNxBMRRLWHp[] TfXhkdHigndULcPdipMrFYFFSpcge;

			private KkUyPwMtAyGOPBArSBJUdPoivtCM[] KEDjKHwyahDuXcTCSIcFnJhOTqLN;

			public rIIRxMHccuwQGVQhacWANrVznlHR(int P_0)
			{
				xOAjeWzKfzBIbGMiqccIklzUbliYA = P_0;
				TfXhkdHigndULcPdipMrFYFFSpcge = new rkAhuVDrcSQTTxJKWCNxBMRRLWHp[20];
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge[i] = new rkAhuVDrcSQTTxJKWCNxBMRRLWHp();
				}
				KEDjKHwyahDuXcTCSIcFnJhOTqLN = new KkUyPwMtAyGOPBArSBJUdPoivtCM[29];
				for (int j = 0; j < KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length; j++)
				{
					KEDjKHwyahDuXcTCSIcFnJhOTqLN[j] = new KkUyPwMtAyGOPBArSBJUdPoivtCM(j);
				}
			}

			public void CrGZoktgDmxlTHSjZWrxxhPdtStM()
			{
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(xOAjeWzKfzBIbGMiqccIklzUbliYA, i);
					TfXhkdHigndULcPdipMrFYFFSpcge[i].CrGZoktgDmxlTHSjZWrxxhPdtStM(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(xOAjeWzKfzBIbGMiqccIklzUbliYA, j);
					KEDjKHwyahDuXcTCSIcFnJhOTqLN[j].CrGZoktgDmxlTHSjZWrxxhPdtStM(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(xOAjeWzKfzBIbGMiqccIklzUbliYA, i);
				}
				for (int j = 0; j < KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length; j++)
				{
					KEDjKHwyahDuXcTCSIcFnJhOTqLN[j].ANnyYrpgRHgHrBXsbJxMFrsUzupD = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(xOAjeWzKfzBIbGMiqccIklzUbliYA, j);
				}
			}

			public bool aBjKkYedffJMBNyjOkVFOWaUaAhq(int P_0)
			{
				if (P_0 < 0 || P_0 >= TfXhkdHigndULcPdipMrFYFFSpcge.Length)
				{
					return false;
				}
				return TfXhkdHigndULcPdipMrFYFFSpcge[P_0].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
			}

			public bool jYWxpmOgglOGuxLGHjZnFKAvkMEVA(int P_0)
			{
				if (P_0 < 0 || P_0 >= TfXhkdHigndULcPdipMrFYFFSpcge.Length)
				{
					return false;
				}
				return TfXhkdHigndULcPdipMrFYFFSpcge[P_0].DaDKnRGgOMjNvbIxxlTQfhqTYBWu;
			}

			public bool NSCNnosVEfppjSDmbInqdnhriOUCb(int P_0)
			{
				if (P_0 < 0 || P_0 >= TfXhkdHigndULcPdipMrFYFFSpcge.Length)
				{
					return false;
				}
				return TfXhkdHigndULcPdipMrFYFFSpcge[P_0].CVtlCkydoxhirdTrieslqaaJclYmA;
			}

			public float bLjUqDJVGVSlWmxjKKTBRMkNFIFdA(int P_0)
			{
				if (P_0 < 0 || P_0 >= KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length)
				{
					return 0f;
				}
				return KEDjKHwyahDuXcTCSIcFnJhOTqLN[P_0].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
			}

			public bool GWsasTXaXNIJzzCDkGiveDDUtJnY(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length)
				{
					return false;
				}
				return KEDjKHwyahDuXcTCSIcFnJhOTqLN[P_0].XAnxKiEsqAoGaxLsQPiYTKBOAuBt(P_1);
			}

			public void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge[i].wJjPIIRJfHhEbGedUconecGfiwzgB();
				}
				for (int j = 0; j < KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length; j++)
				{
					KEDjKHwyahDuXcTCSIcFnJhOTqLN[j].wJjPIIRJfHhEbGedUconecGfiwzgB();
				}
			}
		}

		private class aTNRHaaGqGtBczOIEbIJOWxQyuSR
		{
			private rkAhuVDrcSQTTxJKWCNxBMRRLWHp[] TfXhkdHigndULcPdipMrFYFFSpcge;

			public aTNRHaaGqGtBczOIEbIJOWxQyuSR()
			{
				TfXhkdHigndULcPdipMrFYFFSpcge = new rkAhuVDrcSQTTxJKWCNxBMRRLWHp[7];
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge[i] = new rkAhuVDrcSQTTxJKWCNxBMRRLWHp();
				}
			}

			public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge[i].ANnyYrpgRHgHrBXsbJxMFrsUzupD = Input.GetButton("MouseButton" + i);
				}
			}

			public bool aBjKkYedffJMBNyjOkVFOWaUaAhq(int P_0)
			{
				if (P_0 < 0 || P_0 >= TfXhkdHigndULcPdipMrFYFFSpcge.Length)
				{
					return false;
				}
				return TfXhkdHigndULcPdipMrFYFFSpcge[P_0].ANnyYrpgRHgHrBXsbJxMFrsUzupD;
			}

			public bool jYWxpmOgglOGuxLGHjZnFKAvkMEVA(int P_0)
			{
				if (P_0 < 0 || P_0 >= TfXhkdHigndULcPdipMrFYFFSpcge.Length)
				{
					return false;
				}
				return TfXhkdHigndULcPdipMrFYFFSpcge[P_0].DaDKnRGgOMjNvbIxxlTQfhqTYBWu;
			}

			public bool NSCNnosVEfppjSDmbInqdnhriOUCb(int P_0)
			{
				if (P_0 < 0 || P_0 >= TfXhkdHigndULcPdipMrFYFFSpcge.Length)
				{
					return false;
				}
				return TfXhkdHigndULcPdipMrFYFFSpcge[P_0].CVtlCkydoxhirdTrieslqaaJclYmA;
			}

			public void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				for (int i = 0; i < TfXhkdHigndULcPdipMrFYFFSpcge.Length; i++)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge[i].wJjPIIRJfHhEbGedUconecGfiwzgB();
				}
			}
		}

		private class rkAhuVDrcSQTTxJKWCNxBMRRLWHp
		{
			private bool YZxUdzxmklZNPuQQfDdyVZJzmbxt;

			private bool fywDGWJNKifuxgxicvSZhrxKCkDob;

			public bool ANnyYrpgRHgHrBXsbJxMFrsUzupD
			{
				get
				{
					return YZxUdzxmklZNPuQQfDdyVZJzmbxt;
				}
				set
				{
					fywDGWJNKifuxgxicvSZhrxKCkDob = YZxUdzxmklZNPuQQfDdyVZJzmbxt;
					YZxUdzxmklZNPuQQfDdyVZJzmbxt = yZxUdzxmklZNPuQQfDdyVZJzmbxt;
				}
			}

			public bool DaDKnRGgOMjNvbIxxlTQfhqTYBWu
			{
				get
				{
					if (YZxUdzxmklZNPuQQfDdyVZJzmbxt)
					{
						return !fywDGWJNKifuxgxicvSZhrxKCkDob;
					}
					return false;
				}
			}

			public bool CVtlCkydoxhirdTrieslqaaJclYmA
			{
				get
				{
					if (fywDGWJNKifuxgxicvSZhrxKCkDob)
					{
						return !YZxUdzxmklZNPuQQfDdyVZJzmbxt;
					}
					return false;
				}
			}

			public void CrGZoktgDmxlTHSjZWrxxhPdtStM(bool P_0)
			{
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = P_0;
				fywDGWJNKifuxgxicvSZhrxKCkDob = P_0;
			}

			public void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = false;
				fywDGWJNKifuxgxicvSZhrxKCkDob = false;
			}
		}

		private class KkUyPwMtAyGOPBArSBJUdPoivtCM
		{
			private int CZvvEPfHAoDyTGNKlHShNVdsTjAt;

			private float YZxUdzxmklZNPuQQfDdyVZJzmbxt;

			private float dRbqyykVAfTEQVLMxXEcVAMGoAcy;

			public float ANnyYrpgRHgHrBXsbJxMFrsUzupD
			{
				get
				{
					return YZxUdzxmklZNPuQQfDdyVZJzmbxt;
				}
				set
				{
					YZxUdzxmklZNPuQQfDdyVZJzmbxt = yZxUdzxmklZNPuQQfDdyVZJzmbxt;
				}
			}

			public KkUyPwMtAyGOPBArSBJUdPoivtCM(int P_0)
			{
				CZvvEPfHAoDyTGNKlHShNVdsTjAt = P_0;
			}

			public void CrGZoktgDmxlTHSjZWrxxhPdtStM(float P_0)
			{
				dRbqyykVAfTEQVLMxXEcVAMGoAcy = P_0;
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = P_0;
			}

			public bool XAnxKiEsqAoGaxLsQPiYTKBOAuBt(bool P_0)
			{
				float num = YZxUdzxmklZNPuQQfDdyVZJzmbxt - dRbqyykVAfTEQVLMxXEcVAMGoAcy;
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

			public void wJjPIIRJfHhEbGedUconecGfiwzgB()
			{
				YZxUdzxmklZNPuQQfDdyVZJzmbxt = 0f;
				dRbqyykVAfTEQVLMxXEcVAMGoAcy = 0f;
			}
		}

		private rIIRxMHccuwQGVQhacWANrVznlHR[] FUWUMuBhggyFQEOUCASaOJmITfwR;

		private aTNRHaaGqGtBczOIEbIJOWxQyuSR THVedgpUrWBoBPyOJDjeuRVtdWvh;

		public bZUDLdCeYvKIVHKsHOYPbDJPHpxk()
		{
			FUWUMuBhggyFQEOUCASaOJmITfwR = new rIIRxMHccuwQGVQhacWANrVznlHR[16];
			for (int i = 0; i < FUWUMuBhggyFQEOUCASaOJmITfwR.Length; i++)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i] = new rIIRxMHccuwQGVQhacWANrVznlHR(i);
			}
			THVedgpUrWBoBPyOJDjeuRVtdWvh = new aTNRHaaGqGtBczOIEbIJOWxQyuSR();
		}

		public void CrGZoktgDmxlTHSjZWrxxhPdtStM()
		{
			for (int i = 0; i < FUWUMuBhggyFQEOUCASaOJmITfwR.Length; i++)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].CrGZoktgDmxlTHSjZWrxxhPdtStM();
			}
		}

		public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
		{
			for (int i = 0; i < FUWUMuBhggyFQEOUCASaOJmITfwR.Length; i++)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].DsDuSUaDcVanpNAhDLIRqjKndMGi();
			}
			THVedgpUrWBoBPyOJDjeuRVtdWvh.DsDuSUaDcVanpNAhDLIRqjKndMGi();
		}

		public bool wMGmyonHvpbeooiZoglZRJWqyTGx(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= FUWUMuBhggyFQEOUCASaOJmITfwR.Length)
			{
				return false;
			}
			return FUWUMuBhggyFQEOUCASaOJmITfwR[P_0].aBjKkYedffJMBNyjOkVFOWaUaAhq(P_1);
		}

		public bool XXPRSaFEksDfHHDrkEpnHUYPzOCfA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= FUWUMuBhggyFQEOUCASaOJmITfwR.Length)
			{
				return false;
			}
			return FUWUMuBhggyFQEOUCASaOJmITfwR[P_0].jYWxpmOgglOGuxLGHjZnFKAvkMEVA(P_1);
		}

		public bool ezTldQkDFJsUoiSjyUAtGvKlWCMd(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= FUWUMuBhggyFQEOUCASaOJmITfwR.Length)
			{
				return false;
			}
			return FUWUMuBhggyFQEOUCASaOJmITfwR[P_0].NSCNnosVEfppjSDmbInqdnhriOUCb(P_1);
		}

		public bool hQvfzEgCbkmSdRdpIMixOaWVxzbV(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= FUWUMuBhggyFQEOUCASaOJmITfwR.Length)
			{
				return false;
			}
			return FUWUMuBhggyFQEOUCASaOJmITfwR[P_0].GWsasTXaXNIJzzCDkGiveDDUtJnY(P_1, P_2);
		}

		public bool zmkDbqWjHCFcaAKSheOfHWjetDOHc(int P_0)
		{
			return THVedgpUrWBoBPyOJDjeuRVtdWvh.aBjKkYedffJMBNyjOkVFOWaUaAhq(P_0);
		}

		public bool oXaiGaxFHDEZzdSeuhGzvsAkRiVhb(int P_0)
		{
			return THVedgpUrWBoBPyOJDjeuRVtdWvh.jYWxpmOgglOGuxLGHjZnFKAvkMEVA(P_0);
		}

		public bool fLfxPqyBtdXZhjxRjfhAHVNeQJKu(int P_0)
		{
			return THVedgpUrWBoBPyOJDjeuRVtdWvh.NSCNnosVEfppjSDmbInqdnhriOUCb(P_0);
		}

		public void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			for (int i = 0; i < FUWUMuBhggyFQEOUCASaOJmITfwR.Length; i++)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i].wJjPIIRJfHhEbGedUconecGfiwzgB();
			}
			THVedgpUrWBoBPyOJDjeuRVtdWvh.wJjPIIRJfHhEbGedUconecGfiwzgB();
		}
	}

	private UpdateLoopType oLPSGLPrThUSDXxJlTVDuFNuQqAB;

	private bZUDLdCeYvKIVHKsHOYPbDJPHpxk dRcmHxiluCCHosWInyckHsUTuHRF;

	private IndexedDictionary<int, bZUDLdCeYvKIVHKsHOYPbDJPHpxk> bFWxHBjQsxHuYvNjQgQHYwACscWA;

	public eBtTLjQVbrrAMXmgeRiWszpFXAyd(UpdateLoopSetting P_0)
	{
		bFWxHBjQsxHuYvNjQgQHYwACscWA = new IndexedDictionary<int, bZUDLdCeYvKIVHKsHOYPbDJPHpxk>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				bFWxHBjQsxHuYvNjQgQHYwACscWA.Add((int)list[i], new bZUDLdCeYvKIVHKsHOYPbDJPHpxk());
			}
		}
		oLPSGLPrThUSDXxJlTVDuFNuQqAB = UpdateLoopType.Update;
		dRcmHxiluCCHosWInyckHsUTuHRF = bFWxHBjQsxHuYvNjQgQHYwACscWA.GetValue(0);
	}

	public void CrGZoktgDmxlTHSjZWrxxhPdtStM()
	{
		iXPqprzgMNDFdxLYCofDBgGuSeSV(ReInput.currentUpdateLoop);
		dRcmHxiluCCHosWInyckHsUTuHRF.CrGZoktgDmxlTHSjZWrxxhPdtStM();
	}

	public void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
	{
		iXPqprzgMNDFdxLYCofDBgGuSeSV(P_0);
		dRcmHxiluCCHosWInyckHsUTuHRF.DsDuSUaDcVanpNAhDLIRqjKndMGi();
	}

	public bool wMGmyonHvpbeooiZoglZRJWqyTGx(int P_0, int P_1)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.wMGmyonHvpbeooiZoglZRJWqyTGx(P_0, P_1);
	}

	public bool XXPRSaFEksDfHHDrkEpnHUYPzOCfA(int P_0, int P_1)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.XXPRSaFEksDfHHDrkEpnHUYPzOCfA(P_0, P_1);
	}

	public bool ezTldQkDFJsUoiSjyUAtGvKlWCMd(int P_0, int P_1)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.ezTldQkDFJsUoiSjyUAtGvKlWCMd(P_0, P_1);
	}

	public bool hQvfzEgCbkmSdRdpIMixOaWVxzbV(int P_0, int P_1, bool P_2)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.hQvfzEgCbkmSdRdpIMixOaWVxzbV(P_0, P_1, P_2);
	}

	public bool zmkDbqWjHCFcaAKSheOfHWjetDOHc(int P_0)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.zmkDbqWjHCFcaAKSheOfHWjetDOHc(P_0);
	}

	public bool oXaiGaxFHDEZzdSeuhGzvsAkRiVhb(int P_0)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.oXaiGaxFHDEZzdSeuhGzvsAkRiVhb(P_0);
	}

	public bool fLfxPqyBtdXZhjxRjfhAHVNeQJKu(int P_0)
	{
		return dRcmHxiluCCHosWInyckHsUTuHRF.fLfxPqyBtdXZhjxRjfhAHVNeQJKu(P_0);
	}

	public void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		for (int i = 0; i < bFWxHBjQsxHuYvNjQgQHYwACscWA.Count; i++)
		{
			bFWxHBjQsxHuYvNjQgQHYwACscWA[i].wJjPIIRJfHhEbGedUconecGfiwzgB();
		}
	}

	private void iXPqprzgMNDFdxLYCofDBgGuSeSV(UpdateLoopType P_0)
	{
		if (oLPSGLPrThUSDXxJlTVDuFNuQqAB != P_0)
		{
			oLPSGLPrThUSDXxJlTVDuFNuQqAB = P_0;
			dRcmHxiluCCHosWInyckHsUTuHRF = bFWxHBjQsxHuYvNjQgQHYwACscWA.GetValue((int)P_0);
		}
	}
}
