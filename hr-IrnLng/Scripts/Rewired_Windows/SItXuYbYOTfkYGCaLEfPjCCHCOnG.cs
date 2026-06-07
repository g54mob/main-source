using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class SItXuYbYOTfkYGCaLEfPjCCHCOnG : IDisposable, IUnifiedMouseSource
{
	private class cqjiWBpKMKtzTUkHdWfXYEfyigdA
	{
		private enum eLYikBdqhlRSSqrABmDbvjuJAeL
		{
			CEUjyvGIbsPgNjwVqrjvtItjjrS = 0,
			KyvYcVuHgpltaoATHEroKeMagqTG = 1,
			pihzgzYIlFnQqTeCpFwuFSxYPMk = 2
		}

		private const int tZikPIgxzztoVMePRBHfBWPoBrjl = 120;

		private const int DqPjvPoNjRGsTZVTnygmznvNagO = 2048;

		public readonly UpdateLoopType xlaANeYPvyhpTiakMhbNPdKQFqJ;

		public uint RFEYWtajsauiTobIabkTfZZfoIf;

		public uint ywgIJFxxTHiiMBKAFmOWIrjqpDL;

		public lBTdLSdFeugaINDoutzgnMmwqVAe YpkfnPySKPRQKbOSfceSiwGiPBMG;

		public float iyrAwKHmFdoTXpepDCReDBhghaPK;

		public float MKmfDOCnKHHrcTKliSnMlRgSRZBd;

		public float mRiGavISzPaTqXTpbfNSNHyivVP;

		public float XLzbhhAAwMwQFcKaiCLKIMiNFnP;

		private bool[] mTiETACZqghJRNgcmnKTRhSKcJUu;

		private bool[] DSwWqcUpyPOgHlwQYJNiEGALYCi;

		private ljheplajknnQZDbGVqryDnoulsg IRxEEBhVsgSZHXHEKqJozNVfJkP;

		private uint gNMmuYrggEkuYrNpLGhJfxgnJdW;

		private int oHukPcGuZtlYtzdtTXgcddkienD;

		private int cuLeupHXvvjERcThBqRCOgcQiaZ;

		private bool URJdVNlZUfuZkFaKSCqtFKWGvZJC;

		public cqjiWBpKMKtzTUkHdWfXYEfyigdA(ljheplajknnQZDbGVqryDnoulsg windowsPrefs, UpdateLoopType updateLoop)
		{
			IRxEEBhVsgSZHXHEKqJozNVfJkP = windowsPrefs;
			xlaANeYPvyhpTiakMhbNPdKQFqJ = updateLoop;
			mTiETACZqghJRNgcmnKTRhSKcJUu = new bool[5];
			DSwWqcUpyPOgHlwQYJNiEGALYCi = new bool[5];
		}

		public void YHswTwWqwjgaHZFKRxdOplcOvyY(BNfOmYDxvqNCLrrYukBTimTmfzA P_0)
		{
			mOgsBKyNExCRtuGALZKkCaZHuKL mOgsBKyNExCRtuGALZKkCaZHuKL2 = P_0.MDCedLVbSHjKrAHyrfGyhdqyOQWQ;
			if (mOgsBKyNExCRtuGALZKkCaZHuKL2 != mOgsBKyNExCRtuGALZKkCaZHuKL.CEUjyvGIbsPgNjwVqrjvtItjjrS)
			{
				if ((mOgsBKyNExCRtuGALZKkCaZHuKL2 & mOgsBKyNExCRtuGALZKkCaZHuKL.snlrLnuJOeiDBEViwqXymgDtWLhP) != mOgsBKyNExCRtuGALZKkCaZHuKL.CEUjyvGIbsPgNjwVqrjvtItjjrS || (mOgsBKyNExCRtuGALZKkCaZHuKL2 & mOgsBKyNExCRtuGALZKkCaZHuKL.GPjjIaWawJuoHafBHckBcqIQQJfm) != mOgsBKyNExCRtuGALZKkCaZHuKL.CEUjyvGIbsPgNjwVqrjvtItjjrS)
				{
					IntPtr intPtr = AewjMoBLyBolnnNMhBXWHRooNZC.YABwwXHSsTojcscsIpnzfwQpmnR();
					if (AewjMoBLyBolnnNMhBXWHRooNZC.LIKQoBfcynFjNAdlxkpqEkuDgNzq() == intPtr && BzoYNhIeuSplnpOmNgHuiQRhCyWh(intPtr))
					{
						mOgsBKyNExCRtuGALZKkCaZHuKL2 &= ~mOgsBKyNExCRtuGALZKkCaZHuKL.snlrLnuJOeiDBEViwqXymgDtWLhP;
						mOgsBKyNExCRtuGALZKkCaZHuKL2 &= ~mOgsBKyNExCRtuGALZKkCaZHuKL.GPjjIaWawJuoHafBHckBcqIQQJfm;
					}
				}
				int num = (int)mOgsBKyNExCRtuGALZKkCaZHuKL2;
				if (IRxEEBhVsgSZHXHEKqJozNVfJkP.enabled && IRxEEBhVsgSZHXHEKqJozNVfJkP.swapButtons)
				{
					BMmRMHhKgeLjXQByADGVqHLdcXof(1, num, 1, 2);
					BMmRMHhKgeLjXQByADGVqHLdcXof(0, num, 4, 8);
				}
				else
				{
					BMmRMHhKgeLjXQByADGVqHLdcXof(0, num, 1, 2);
					BMmRMHhKgeLjXQByADGVqHLdcXof(1, num, 4, 8);
				}
				BMmRMHhKgeLjXQByADGVqHLdcXof(2, num, 16, 32);
				BMmRMHhKgeLjXQByADGVqHLdcXof(3, num, 64, 128);
				BMmRMHhKgeLjXQByADGVqHLdcXof(4, num, 256, 512);
			}
			RFEYWtajsauiTobIabkTfZZfoIf = P_0.RFEYWtajsauiTobIabkTfZZfoIf;
			ywgIJFxxTHiiMBKAFmOWIrjqpDL = P_0.ywgIJFxxTHiiMBKAFmOWIrjqpDL;
			lBTdLSdFeugaINDoutzgnMmwqVAe ypkfnPySKPRQKbOSfceSiwGiPBMG = YpkfnPySKPRQKbOSfceSiwGiPBMG;
			YpkfnPySKPRQKbOSfceSiwGiPBMG = P_0.YpkfnPySKPRQKbOSfceSiwGiPBMG;
			if (YpkfnPySKPRQKbOSfceSiwGiPBMG != ypkfnPySKPRQKbOSfceSiwGiPBMG)
			{
				URJdVNlZUfuZkFaKSCqtFKWGvZJC = false;
			}
			if (YpkfnPySKPRQKbOSfceSiwGiPBMG == lBTdLSdFeugaINDoutzgnMmwqVAe.cpzpdAHvrkxQKIMLleeZDJFZzvAU)
			{
				iyrAwKHmFdoTXpepDCReDBhghaPK += (float)P_0.iyrAwKHmFdoTXpepDCReDBhghaPK * 0.5f;
				MKmfDOCnKHHrcTKliSnMlRgSRZBd += (float)P_0.MKmfDOCnKHHrcTKliSnMlRgSRZBd * 0.5f * -1f;
			}
			else if ((YpkfnPySKPRQKbOSfceSiwGiPBMG & lBTdLSdFeugaINDoutzgnMmwqVAe.fMSuKspWZVoFMmdhriHqrKQjPlM) != lBTdLSdFeugaINDoutzgnMmwqVAe.cpzpdAHvrkxQKIMLleeZDJFZzvAU)
			{
				bool flag = (YpkfnPySKPRQKbOSfceSiwGiPBMG & lBTdLSdFeugaINDoutzgnMmwqVAe.fsSNmavOuUxaMyKDzvOYUXISXKt) != 0;
				int num2 = AewjMoBLyBolnnNMhBXWHRooNZC.pCIXxPnkogJNwAtiuOTKosMWxNB(flag ? YZuduhHYdujZNQijkwygrqXwCpon.SDigCeYqNVSVvFfEJouLxhkuPCT : YZuduhHYdujZNQijkwygrqXwCpon.QXWxLvZZDoRuVdTGMZZeIpUVbCc);
				int num3 = AewjMoBLyBolnnNMhBXWHRooNZC.pCIXxPnkogJNwAtiuOTKosMWxNB(flag ? YZuduhHYdujZNQijkwygrqXwCpon.EVphpbkqeVPPZBbdYNwBjPjpedF : YZuduhHYdujZNQijkwygrqXwCpon.wrnFQSFqIbehfefpMWkCVRlkZlR);
				int num4 = (int)((float)P_0.iyrAwKHmFdoTXpepDCReDBhghaPK / 65535f * (float)num2);
				int num5 = (int)((65535f - (float)P_0.MKmfDOCnKHHrcTKliSnMlRgSRZBd) / 65535f * (float)num3);
				if (!URJdVNlZUfuZkFaKSCqtFKWGvZJC)
				{
					oHukPcGuZtlYtzdtTXgcddkienD = num4;
					cuLeupHXvvjERcThBqRCOgcQiaZ = num5;
					URJdVNlZUfuZkFaKSCqtFKWGvZJC = true;
				}
				iyrAwKHmFdoTXpepDCReDBhghaPK += num4 - oHukPcGuZtlYtzdtTXgcddkienD;
				MKmfDOCnKHHrcTKliSnMlRgSRZBd += num5 - cuLeupHXvvjERcThBqRCOgcQiaZ;
				oHukPcGuZtlYtzdtTXgcddkienD = num4;
				cuLeupHXvvjERcThBqRCOgcQiaZ = num5;
			}
			else
			{
				iyrAwKHmFdoTXpepDCReDBhghaPK = P_0.iyrAwKHmFdoTXpepDCReDBhghaPK;
				MKmfDOCnKHHrcTKliSnMlRgSRZBd = P_0.MKmfDOCnKHHrcTKliSnMlRgSRZBd;
			}
			if (P_0.eyLMLFcdNzeiQfrvTTJvxcwYUUU != 0)
			{
				int num6 = ((MathTools.Abs(P_0.eyLMLFcdNzeiQfrvTTJvxcwYUUU) < 120) ? MathTools.Sign(P_0.eyLMLFcdNzeiQfrvTTJvxcwYUUU) : (P_0.eyLMLFcdNzeiQfrvTTJvxcwYUUU / 120));
				if ((mOgsBKyNExCRtuGALZKkCaZHuKL2 & mOgsBKyNExCRtuGALZKkCaZHuKL.QxlEbpJOMmMkwBFUlkvtEMNYPTmg) != mOgsBKyNExCRtuGALZKkCaZHuKL.CEUjyvGIbsPgNjwVqrjvtItjjrS)
				{
					mRiGavISzPaTqXTpbfNSNHyivVP += num6;
				}
				else if ((mOgsBKyNExCRtuGALZKkCaZHuKL2 & (mOgsBKyNExCRtuGALZKkCaZHuKL)2048) != mOgsBKyNExCRtuGALZKkCaZHuKL.CEUjyvGIbsPgNjwVqrjvtItjjrS)
				{
					XLzbhhAAwMwQFcKaiCLKIMiNFnP += num6;
				}
			}
		}

		public void NbRHSKRDySxUtOnCxXuGoqccJvd(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = iyrAwKHmFdoTXpepDCReDBhghaPK;
			axisValues[1] = MKmfDOCnKHHrcTKliSnMlRgSRZBd;
			axisValues[2] = mRiGavISzPaTqXTpbfNSNHyivVP;
			axisValues[3] = XLzbhhAAwMwQFcKaiCLKIMiNFnP;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = mTiETACZqghJRNgcmnKTRhSKcJUu[i] || DSwWqcUpyPOgHlwQYJNiEGALYCi[i];
			}
			gPKYWvCNQJcdTVhdYLqWRhFPsbB();
		}

		public void xbrgbsymhweSXlyAZAqkvRqFNEB()
		{
			gPKYWvCNQJcdTVhdYLqWRhFPsbB();
		}

		private void gPKYWvCNQJcdTVhdYLqWRhFPsbB()
		{
			if (gNMmuYrggEkuYrNpLGhJfxgnJdW != ReInput.absFrame)
			{
				SgNHwJfnbTvcZSNNnwPNtMTymKZ();
				gNMmuYrggEkuYrNpLGhJfxgnJdW = ReInput.absFrame;
			}
		}

		public void TzBPrZngbKbHBhJPAmtHpHNMMTtf()
		{
			iyrAwKHmFdoTXpepDCReDBhghaPK = 0f;
			MKmfDOCnKHHrcTKliSnMlRgSRZBd = 0f;
			ywgIJFxxTHiiMBKAFmOWIrjqpDL = 0u;
			YpkfnPySKPRQKbOSfceSiwGiPBMG = lBTdLSdFeugaINDoutzgnMmwqVAe.cpzpdAHvrkxQKIMLleeZDJFZzvAU;
			mRiGavISzPaTqXTpbfNSNHyivVP = 0f;
			XLzbhhAAwMwQFcKaiCLKIMiNFnP = 0f;
			Array.Clear(mTiETACZqghJRNgcmnKTRhSKcJUu, 0, 5);
			Array.Clear(DSwWqcUpyPOgHlwQYJNiEGALYCi, 0, 5);
			URJdVNlZUfuZkFaKSCqtFKWGvZJC = false;
		}

		public void SgNHwJfnbTvcZSNNnwPNtMTymKZ()
		{
			iyrAwKHmFdoTXpepDCReDBhghaPK = 0f;
			MKmfDOCnKHHrcTKliSnMlRgSRZBd = 0f;
			mRiGavISzPaTqXTpbfNSNHyivVP = 0f;
			XLzbhhAAwMwQFcKaiCLKIMiNFnP = 0f;
			Array.Clear(DSwWqcUpyPOgHlwQYJNiEGALYCi, 0, 5);
		}

		private bool hCGghiHxSAcLADozffLtfQoDJspU(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1 && (P_0 & P_2) != P_2)
			{
				return true;
			}
			return false;
		}

		private eLYikBdqhlRSSqrABmDbvjuJAeL wLkNAuDAEDxXkVStDhMRJLasUDG(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return eLYikBdqhlRSSqrABmDbvjuJAeL.CEUjyvGIbsPgNjwVqrjvtItjjrS;
				}
				return eLYikBdqhlRSSqrABmDbvjuJAeL.KyvYcVuHgpltaoATHEroKeMagqTG;
			}
			if ((P_0 & P_2) == P_2)
			{
				return eLYikBdqhlRSSqrABmDbvjuJAeL.pihzgzYIlFnQqTeCpFwuFSxYPMk;
			}
			return eLYikBdqhlRSSqrABmDbvjuJAeL.CEUjyvGIbsPgNjwVqrjvtItjjrS;
		}

		private void BMmRMHhKgeLjXQByADGVqHLdcXof(int P_0, int P_1, int P_2, int P_3)
		{
			eLYikBdqhlRSSqrABmDbvjuJAeL eLYikBdqhlRSSqrABmDbvjuJAeL2 = wLkNAuDAEDxXkVStDhMRJLasUDG(P_1, P_2, P_3);
			if (mTiETACZqghJRNgcmnKTRhSKcJUu[P_0])
			{
				if (eLYikBdqhlRSSqrABmDbvjuJAeL2 == eLYikBdqhlRSSqrABmDbvjuJAeL.pihzgzYIlFnQqTeCpFwuFSxYPMk)
				{
					mTiETACZqghJRNgcmnKTRhSKcJUu[P_0] = false;
				}
			}
			else if (eLYikBdqhlRSSqrABmDbvjuJAeL2 == eLYikBdqhlRSSqrABmDbvjuJAeL.KyvYcVuHgpltaoATHEroKeMagqTG)
			{
				mTiETACZqghJRNgcmnKTRhSKcJUu[P_0] = true;
			}
			if (eLYikBdqhlRSSqrABmDbvjuJAeL2 == eLYikBdqhlRSSqrABmDbvjuJAeL.KyvYcVuHgpltaoATHEroKeMagqTG)
			{
				DSwWqcUpyPOgHlwQYJNiEGALYCi[P_0] = true;
			}
		}

		private static bool BzoYNhIeuSplnpOmNgHuiQRhCyWh(IntPtr P_0)
		{
			IntPtr intPtr = AewjMoBLyBolnnNMhBXWHRooNZC.ZNVvimhjgOKOeJFVlPbkJZYPvKU(0u, false, 0u);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			if (!AewjMoBLyBolnnNMhBXWHRooNZC.ICJtwqKDsECflbWCoByBkHyMvLVO(P_0, out var uZnqpMDzWBFfVWkOCMMLjIuYPQh2))
			{
				return false;
			}
			if (!AewjMoBLyBolnnNMhBXWHRooNZC.UNVbkCbPOSyQIerMafQiPsTwAZmU(out var uZnqpMDzWBFfVWkOCMMLjIuYPQh3))
			{
				return false;
			}
			if (!AewjMoBLyBolnnNMhBXWHRooNZC.nWNMUExEEPEGqadepwWpENreKECZ(P_0, out var xJwmEgVpkZbeNumcRaFRTtrzgxQ))
			{
				return false;
			}
			int num = uZnqpMDzWBFfVWkOCMMLjIuYPQh3.iyrAwKHmFdoTXpepDCReDBhghaPK - uZnqpMDzWBFfVWkOCMMLjIuYPQh2.iyrAwKHmFdoTXpepDCReDBhghaPK;
			int num2 = uZnqpMDzWBFfVWkOCMMLjIuYPQh3.MKmfDOCnKHHrcTKliSnMlRgSRZBd - uZnqpMDzWBFfVWkOCMMLjIuYPQh2.MKmfDOCnKHHrcTKliSnMlRgSRZBd;
			if (num >= 0 && num2 >= 0 && num <= xJwmEgVpkZbeNumcRaFRTtrzgxQ.iTkoHZTcvrXeYfhKUqvEuDgARvW && num2 <= xJwmEgVpkZbeNumcRaFRTtrzgxQ.cKBnRpuLfTbAtokXVlGsedMStWX)
			{
				return false;
			}
			if (!AewjMoBLyBolnnNMhBXWHRooNZC.FPdQBpWzlrVkFIinUHJZANlrMDN(P_0, out var xJwmEgVpkZbeNumcRaFRTtrzgxQ2))
			{
				return false;
			}
			if (uZnqpMDzWBFfVWkOCMMLjIuYPQh3.iyrAwKHmFdoTXpepDCReDBhghaPK >= xJwmEgVpkZbeNumcRaFRTtrzgxQ2.tqvaGOAybWCodxVpJuorDrEkWQJ && uZnqpMDzWBFfVWkOCMMLjIuYPQh3.iyrAwKHmFdoTXpepDCReDBhghaPK <= xJwmEgVpkZbeNumcRaFRTtrzgxQ2.iTkoHZTcvrXeYfhKUqvEuDgARvW && uZnqpMDzWBFfVWkOCMMLjIuYPQh3.MKmfDOCnKHHrcTKliSnMlRgSRZBd >= xJwmEgVpkZbeNumcRaFRTtrzgxQ2.nmmvpkJHyIFfVgaWWfZGODcFyZl)
			{
				return uZnqpMDzWBFfVWkOCMMLjIuYPQh3.MKmfDOCnKHHrcTKliSnMlRgSRZBd <= xJwmEgVpkZbeNumcRaFRTtrzgxQ2.cKBnRpuLfTbAtokXVlGsedMStWX;
			}
			return false;
		}
	}

	private class ljheplajknnQZDbGVqryDnoulsg
	{
		private bool YcdKgVIvzyGHwqIaUGvPeSfBUWwp;

		private bool vSzHdIFhkmWBzmSPPdJcecDLvuf;

		private bool qGVbBNIGSjCdBdsziJlJcQqHlDdO;

		private int EXPIDmCrJZitMZQjmsunYDaJQnA = 10;

		private readonly float RrcDAsdBbKobFlnZLChDwRVNRqmJ;

		private double QxebRJLcgHMACxioysezxHjYktB;

		public bool enabled
		{
			get
			{
				return YcdKgVIvzyGHwqIaUGvPeSfBUWwp;
			}
			set
			{
				if (value != YcdKgVIvzyGHwqIaUGvPeSfBUWwp)
				{
					IiILcjpBpzlksnvNRRvlfSzihMS(true);
				}
			}
		}

		public bool swapButtons => vSzHdIFhkmWBzmSPPdJcecDLvuf;

		public bool applySpeed
		{
			get
			{
				return qGVbBNIGSjCdBdsziJlJcQqHlDdO;
			}
			set
			{
				if (qGVbBNIGSjCdBdsziJlJcQqHlDdO != value)
				{
					qGVbBNIGSjCdBdsziJlJcQqHlDdO = value;
					IiILcjpBpzlksnvNRRvlfSzihMS(true);
				}
			}
		}

		public int speed => EXPIDmCrJZitMZQjmsunYDaJQnA;

		public ljheplajknnQZDbGVqryDnoulsg(bool enabled, float refreshInterval)
		{
			YcdKgVIvzyGHwqIaUGvPeSfBUWwp = enabled;
			RrcDAsdBbKobFlnZLChDwRVNRqmJ = refreshInterval;
			IiILcjpBpzlksnvNRRvlfSzihMS(false);
		}

		public void RMEkOMsGFSFWbHqrAFftMTIKNIHO()
		{
			if (YcdKgVIvzyGHwqIaUGvPeSfBUWwp && !(ReInput.realTime < QxebRJLcgHMACxioysezxHjYktB))
			{
				IiILcjpBpzlksnvNRRvlfSzihMS(true);
			}
		}

		private void IiILcjpBpzlksnvNRRvlfSzihMS(bool P_0)
		{
			if (qGVbBNIGSjCdBdsziJlJcQqHlDdO)
			{
				AewjMoBLyBolnnNMhBXWHRooNZC.izvqGuMVvxVdtpffXHZyruPHNcW(112u, 0u, ref EXPIDmCrJZitMZQjmsunYDaJQnA, 0u);
			}
			vSzHdIFhkmWBzmSPPdJcecDLvuf = AewjMoBLyBolnnNMhBXWHRooNZC.pCIXxPnkogJNwAtiuOTKosMWxNB(YZuduhHYdujZNQijkwygrqXwCpon.FNlfQakQskyKphLHbeHDlJnVnAQ) > 0;
			if (P_0)
			{
				QxebRJLcgHMACxioysezxHjYktB = ReInput.realTime + (double)RrcDAsdBbKobFlnZLChDwRVNRqmJ;
			}
		}
	}

	private const int vuyTlooAUBGfLIowoMRjuBpPWXd = 5;

	private const int fYrCprrGhahxdMsmAaEAnDtKESrB = 4;

	private const bool doozJKXaOyCCfOsEEhfclciYKEZ = true;

	private const float BTgqQhHHAHlOnSMNnekPdGyrgjh = 2f;

	private readonly object DYqmLYQWtnCkUZCOjwXSRkHXDqs = new object();

	private UpdateLoopDataSet<cqjiWBpKMKtzTUkHdWfXYEfyigdA> rBSQPHpAEpZjiGRosdEilOsbJXt;

	private HardwareControllerMap_Game xEHeCYbzZHcwCqXyRzEObXqDbVi;

	private ljheplajknnQZDbGVqryDnoulsg IRxEEBhVsgSZHXHEKqJozNVfJkP;

	private bool WJeRKxtTKsphDaGMsYlUloenxBg;

	private int chgHAMXDmXvtixEedAMhiatDaJz;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (xEHeCYbzZHcwCqXyRzEObXqDbVi == null)
			{
				xEHeCYbzZHcwCqXyRzEObXqDbVi = xymhxCjcTszQcNdaCAHXJrBYQlG();
			}
			return xEHeCYbzZHcwCqXyRzEObXqDbVi;
		}
	}

	public int buttonCount => 5;

	public int axisCount => 4;

	public Vector2 mousePosition => ThreadSafeUnityInput.mouse.mousePosition;

	public Controller.Extension controllerExtension => null;

	public SItXuYbYOTfkYGCaLEfPjCCHCOnG(UpdateLoopSetting updateLoopSetting)
	{
		TYWFVhuWwApaCJFploAcmSaXRQF();
		IRxEEBhVsgSZHXHEKqJozNVfJkP = new ljheplajknnQZDbGVqryDnoulsg(enabled: true, 2f);
		rBSQPHpAEpZjiGRosdEilOsbJXt = new UpdateLoopDataSet<cqjiWBpKMKtzTUkHdWfXYEfyigdA>(updateLoopSetting);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				rBSQPHpAEpZjiGRosdEilOsbJXt[i] = new cqjiWBpKMKtzTUkHdWfXYEfyigdA(IRxEEBhVsgSZHXHEKqJozNVfJkP, list[i]);
			}
		}
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += RbzPnjPKwnvkSOVQeEdrtPoybHi;
		ThreadSafeUnityInput.mouse.Monitor(state: true);
		ReInput.EditorPauseChangedEvent += QzTNlFpirLGoLVsrgGykIfjxeAh;
		ReInput.TimeScalePauseChangedEvent += cSDTWLpxUFauyuZmKkZyaygMBht;
		ReInput.UpdateEndedEvent += lrvLKEbMyRgDDiIWnAynFDrmFkWw;
	}

	public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(UpdateLoopType P_0)
	{
		rBSQPHpAEpZjiGRosdEilOsbJXt.SetUpdateLoop(P_0);
		IRxEEBhVsgSZHXHEKqJozNVfJkP.RMEkOMsGFSFWbHqrAFftMTIKNIHO();
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void pxuGNwZmtUejHeAPFpfZJLcwCmlw(BNfOmYDxvqNCLrrYukBTimTmfzA P_0)
	{
		if (!WJeRKxtTKsphDaGMsYlUloenxBg)
		{
			return;
		}
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			int count = rBSQPHpAEpZjiGRosdEilOsbJXt.Count;
			for (int i = 0; i < count; i++)
			{
				rBSQPHpAEpZjiGRosdEilOsbJXt[i].YHswTwWqwjgaHZFKRxdOplcOvyY(P_0);
			}
		}
	}

	public void wyrqFdOgaxQVgbBnFdlZHDmYRww(bool P_0)
	{
		kpNjGqkWcAcvOqQJPFvWLhFCJPk();
	}

	public void BaKUrWtSdbbeIHinStpYOpNkyeF(bool P_0)
	{
		int num = TYWFVhuWwApaCJFploAcmSaXRQF();
		if (num < 0)
		{
			kpNjGqkWcAcvOqQJPFvWLhFCJPk();
		}
	}

	private int TYWFVhuWwApaCJFploAcmSaXRQF()
	{
		int num = chgHAMXDmXvtixEedAMhiatDaJz;
		if (CDUDUtloSCOYNTanpthEeshuCdC.vTXbPWoRYRDlFArXUISNbPwbwMuJ(MAPTyOhgNVdBQSioUpquSdYiRkd.NcOiPCmfYWmxxojUswKfONTIHos, out var num2))
		{
			chgHAMXDmXvtixEedAMhiatDaJz = num2;
		}
		else
		{
			chgHAMXDmXvtixEedAMhiatDaJz = ((AewjMoBLyBolnnNMhBXWHRooNZC.pCIXxPnkogJNwAtiuOTKosMWxNB(YZuduhHYdujZNQijkwygrqXwCpon.lFtXvLwBYieUcYXYnMlIMHWxzxo) != 0) ? 1 : 0);
		}
		return chgHAMXDmXvtixEedAMhiatDaJz - num;
	}

	private void RbzPnjPKwnvkSOVQeEdrtPoybHi(bool P_0)
	{
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !WJeRKxtTKsphDaGMsYlUloenxBg)
		{
			kpNjGqkWcAcvOqQJPFvWLhFCJPk();
		}
	}

	private void QzTNlFpirLGoLVsrgGykIfjxeAh(bool P_0)
	{
	}

	private void cSDTWLpxUFauyuZmKkZyaygMBht(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		WJeRKxtTKsphDaGMsYlUloenxBg = ReInput.IsInputAllowed(ControllerType.Mouse);
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			rBSQPHpAEpZjiGRosdEilOsbJXt[rBSQPHpAEpZjiGRosdEilOsbJXt.fixedUpdateSetIndex].SgNHwJfnbTvcZSNNnwPNtMTymKZ();
		}
	}

	private void lrvLKEbMyRgDDiIWnAynFDrmFkWw(UpdateLoopType P_0)
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			rBSQPHpAEpZjiGRosdEilOsbJXt.Get(P_0).xbrgbsymhweSXlyAZAqkvRqFNEB();
		}
	}

	private void kpNjGqkWcAcvOqQJPFvWLhFCJPk()
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			int count = rBSQPHpAEpZjiGRosdEilOsbJXt.Count;
			for (int i = 0; i < count; i++)
			{
				rBSQPHpAEpZjiGRosdEilOsbJXt[i].TzBPrZngbKbHBhJPAmtHpHNMMTtf();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		rBSQPHpAEpZjiGRosdEilOsbJXt.Current.NbRHSKRDySxUtOnCxXuGoqccJvd(dataUpdater);
	}

	public void Clear()
	{
		kpNjGqkWcAcvOqQJPFvWLhFCJPk();
	}

	private HardwareControllerMap_Game xymhxCjcTszQcNdaCAHXJrBYQlG()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.rawInputUnifiedMouseElementIdentifiers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(Consts.rawInputUnifiedMouseElementIdentifiers[i]);
		}
		int[] array2 = new int[5];
		int[] array3 = new int[4];
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].elementType == ControllerElementType.Axis)
			{
				array3[num2++] = array[j].id;
			}
			else if (array[j].elementType == ControllerElementType.Button)
			{
				array2[num++] = array[j].id;
			}
		}
		AxisCalibrationData[] array4 = new AxisCalibrationData[4];
		AxisRange[] array5 = new AxisRange[4];
		HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
		HardwareButtonInfo[] array7 = new HardwareButtonInfo[5];
		for (int k = 0; k < 4; k++)
		{
			ref AxisCalibrationData reference = ref array4[k];
			reference = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float pollingDeadZone;
			switch (k)
			{
			case 0:
			case 1:
				pollingDeadZone = 100f;
				break;
			default:
				pollingDeadZone = 2f;
				break;
			}
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, excludeFromPolling: false, pollingDeadZone, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~SItXuYbYOTfkYGCaLEfPjCCHCOnG()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			ReInput.ApplicationFocusChangedEvent -= RbzPnjPKwnvkSOVQeEdrtPoybHi;
			ReInput.EditorPauseChangedEvent -= QzTNlFpirLGoLVsrgGykIfjxeAh;
			ReInput.TimeScalePauseChangedEvent -= cSDTWLpxUFauyuZmKkZyaygMBht;
			ReInput.UpdateEndedEvent -= lrvLKEbMyRgDDiIWnAynFDrmFkWw;
			if (P_0)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}
}
