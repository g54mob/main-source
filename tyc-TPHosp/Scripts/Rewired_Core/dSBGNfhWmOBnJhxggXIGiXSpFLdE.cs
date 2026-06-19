using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class dSBGNfhWmOBnJhxggXIGiXSpFLdE
{
	internal enum ZokPvEPpGPbZixpzdMyWwRVcNWx
	{
		DnMrxsuUiLvwcNNUGPbMBafPdnq = 0,
		jasTeCPLFrfoLaDxyjJNoVklazd = 1,
		cUhrPrhdTFLhvqHJHOLHrPrInNm = 2
	}

	private class sqYdltDCKSVUNBeYEdsfnrWHHmM
	{
		internal class OKhGqTeCEyFXhvyElAcvUtsPqLyb
		{
			internal double YBfOwcrMhrWUDmjHdIVbDCjvwLF;

			private InputBehavior TuyABdnNXmGSpXEbASGgOwJcMGk;

			internal float WgrRnhMAvsCWGDqROQcQGpjllbYh;

			internal float hYagYvcguGwAgOlgRPUrmMzuChBt;

			internal AxisCoordinateMode xsXndYnsDYEZmSXyNiYhinTzVHV;

			internal AxisCoordinateMode aHEnlFATUfsIiVanulPDdDyPWCD;

			internal ButtonStateFlags foizlTVmYytexOFjtTkYhHmXiQC;

			internal ButtonStateFlags CWTocFPKDroGPRjfrMrlzhDmaVJ;

			internal ButtonStateFlags JqjHiTxSfvqzvuKfFnUxyoXyddE;

			internal ButtonStateFlags YSumELMlgkaZAEMUtUovfsDdCrqW;

			internal float GjLGrIcXtUadHvcKixNFLfdtHim;

			internal float KDkGspuGbcOUYvTsScbfzUSoOTW;

			internal float ygJgCdKIslEqPeeQhtUfpCfblhQn;

			internal float lTUdcEOmgJCHMPZVIBMszBtWuLp;

			private double pUKwVPGgjQkhgBKdaTvipVgnBIr;

			private double OkQBkNUogSeXnEoMhBvlcwfgPuqi;

			internal fJGmvZCQxKbsxKEBuDSxfzWxZRc QXJaAJvJKuyMeDJRFbPvkrFKUHb;

			internal fJGmvZCQxKbsxKEBuDSxfzWxZRc QQkFivSUKaHHakzyHZlXPqfOBJre;

			internal ButtonStateRecorder sOLDfEGCnVIUecIzhDXtjklHSzBq;

			internal ButtonStateRecorder diEurUXkpvVGbRKJDRIqdEdNeHOc;

			internal sisZYRvpqwMKSthUiliaLFMNQaj CzBhaDIoMRPFhHxFdRtzmmFikfo;

			internal sisZYRvpqwMKSthUiliaLFMNQaj KOGQGRYjlLIaxbuGjjrfEGNqmjas;

			internal TimerAbs sEufHiAsKMgHbqEzYAhrEgipzVin;

			internal TimerAbs HNBaPpKbrfdzFLWFpYmLEDtBZHEn;

			internal readonly rxizQcqELWjNcpUqFcayhKmEbqQ zHUZwTvTlhGQOvqTdZLxtCGnDLQ = new rxizQcqELWjNcpUqFcayhKmEbqQ();

			internal double vButtonTimePressed => sOLDfEGCnVIUecIzhDXtjklHSzBq.timePressed;

			internal double vButtonTimeUnpressed => sOLDfEGCnVIUecIzhDXtjklHSzBq.timeUnpressed;

			internal double negativeVButtonTimePressed => diEurUXkpvVGbRKJDRIqdEdNeHOc.timePressed;

			internal double negativeVButtonTimeUnpressed => diEurUXkpvVGbRKJDRIqdEdNeHOc.timeUnpressed;

			internal double vAxisTimeActive
			{
				get
				{
					if (WgrRnhMAvsCWGDqROQcQGpjllbYh == 0f && GjLGrIcXtUadHvcKixNFLfdtHim == 0f)
					{
						return 0.0;
					}
					double num = ynjANzJrXKZModnZDIcqqisQTavB - pUKwVPGgjQkhgBKdaTvipVgnBIr;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double vAxisTimeInactive
			{
				get
				{
					if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f || GjLGrIcXtUadHvcKixNFLfdtHim != 0f)
					{
						return 0.0;
					}
					double num = ynjANzJrXKZModnZDIcqqisQTavB - pUKwVPGgjQkhgBKdaTvipVgnBIr;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double vAxisRawTimeActive
			{
				get
				{
					if (WgrRnhMAvsCWGDqROQcQGpjllbYh == 0f && ygJgCdKIslEqPeeQhtUfpCfblhQn == 0f)
					{
						return 0.0;
					}
					double num = ynjANzJrXKZModnZDIcqqisQTavB - OkQBkNUogSeXnEoMhBvlcwfgPuqi;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double vAxisRawTimeInactive
			{
				get
				{
					if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f || ygJgCdKIslEqPeeQhtUfpCfblhQn != 0f)
					{
						return 0.0;
					}
					double num = ynjANzJrXKZModnZDIcqqisQTavB - OkQBkNUogSeXnEoMhBvlcwfgPuqi;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal OKhGqTeCEyFXhvyElAcvUtsPqLyb(InputBehavior inputBehavior)
			{
				TuyABdnNXmGSpXEbASGgOwJcMGk = inputBehavior;
				if (inputBehavior.buttonDownBuffer > 0f)
				{
					sEufHiAsKMgHbqEzYAhrEgipzVin = new TimerAbs(inputBehavior.buttonDownBuffer);
					HNBaPpKbrfdzFLWFpYmLEDtBZHEn = new TimerAbs(inputBehavior.buttonDownBuffer);
				}
				sOLDfEGCnVIUecIzhDXtjklHSzBq = new ButtonStateRecorder();
				diEurUXkpvVGbRKJDRIqdEdNeHOc = new ButtonStateRecorder();
				QXJaAJvJKuyMeDJRFbPvkrFKUHb = new fJGmvZCQxKbsxKEBuDSxfzWxZRc(inputBehavior.buttonDoublePressSpeed);
				QQkFivSUKaHHakzyHZlXPqfOBJre = new fJGmvZCQxKbsxKEBuDSxfzWxZRc(inputBehavior.buttonDoublePressSpeed);
				CzBhaDIoMRPFhHxFdRtzmmFikfo = new sisZYRvpqwMKSthUiliaLFMNQaj(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				KOGQGRYjlLIaxbuGjjrfEGNqmjas = new sisZYRvpqwMKSthUiliaLFMNQaj(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				DssCuBdWRUzcmOqXethsqWgGwvP();
			}

			internal void mLcadliumwIpfQEUswJFArNsqbe(double P_0)
			{
				if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f || GjLGrIcXtUadHvcKixNFLfdtHim != 0f)
				{
					if (hYagYvcguGwAgOlgRPUrmMzuChBt == 0f && KDkGspuGbcOUYvTsScbfzUSoOTW == 0f)
					{
						pUKwVPGgjQkhgBKdaTvipVgnBIr = ynjANzJrXKZModnZDIcqqisQTavB;
					}
				}
				else if (hYagYvcguGwAgOlgRPUrmMzuChBt != 0f || KDkGspuGbcOUYvTsScbfzUSoOTW != 0f)
				{
					pUKwVPGgjQkhgBKdaTvipVgnBIr = ynjANzJrXKZModnZDIcqqisQTavB;
				}
				if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f || ygJgCdKIslEqPeeQhtUfpCfblhQn != 0f)
				{
					if (hYagYvcguGwAgOlgRPUrmMzuChBt == 0f && lTUdcEOmgJCHMPZVIBMszBtWuLp == 0f)
					{
						OkQBkNUogSeXnEoMhBvlcwfgPuqi = ynjANzJrXKZModnZDIcqqisQTavB;
					}
				}
				else if (hYagYvcguGwAgOlgRPUrmMzuChBt != 0f || lTUdcEOmgJCHMPZVIBMszBtWuLp != 0f)
				{
					OkQBkNUogSeXnEoMhBvlcwfgPuqi = ynjANzJrXKZModnZDIcqqisQTavB;
				}
			}

			internal void cRwrrpvsiScmwCsnCOorxcvTJLa()
			{
				if (hYagYvcguGwAgOlgRPUrmMzuChBt != WgrRnhMAvsCWGDqROQcQGpjllbYh)
				{
					hYagYvcguGwAgOlgRPUrmMzuChBt = WgrRnhMAvsCWGDqROQcQGpjllbYh;
				}
				if (CWTocFPKDroGPRjfrMrlzhDmaVJ != foizlTVmYytexOFjtTkYhHmXiQC)
				{
					CWTocFPKDroGPRjfrMrlzhDmaVJ = foizlTVmYytexOFjtTkYhHmXiQC;
				}
				if (YSumELMlgkaZAEMUtUovfsDdCrqW != JqjHiTxSfvqzvuKfFnUxyoXyddE)
				{
					YSumELMlgkaZAEMUtUovfsDdCrqW = JqjHiTxSfvqzvuKfFnUxyoXyddE;
				}
				if (KDkGspuGbcOUYvTsScbfzUSoOTW != GjLGrIcXtUadHvcKixNFLfdtHim)
				{
					KDkGspuGbcOUYvTsScbfzUSoOTW = GjLGrIcXtUadHvcKixNFLfdtHim;
				}
				if (lTUdcEOmgJCHMPZVIBMszBtWuLp != ygJgCdKIslEqPeeQhtUfpCfblhQn)
				{
					lTUdcEOmgJCHMPZVIBMszBtWuLp = ygJgCdKIslEqPeeQhtUfpCfblhQn;
				}
				if (aHEnlFATUfsIiVanulPDdDyPWCD != xsXndYnsDYEZmSXyNiYhinTzVHV)
				{
					aHEnlFATUfsIiVanulPDdDyPWCD = xsXndYnsDYEZmSXyNiYhinTzVHV;
				}
				if (xsXndYnsDYEZmSXyNiYhinTzVHV != AxisCoordinateMode.Absolute)
				{
					xsXndYnsDYEZmSXyNiYhinTzVHV = AxisCoordinateMode.Absolute;
				}
			}

			internal void dmgjAahAeviGVNvRKpBOvvmCjU()
			{
				if (sEufHiAsKMgHbqEzYAhrEgipzVin != null)
				{
					sEufHiAsKMgHbqEzYAhrEgipzVin.Update();
					HNBaPpKbrfdzFLWFpYmLEDtBZHEn.Update();
				}
			}

			internal void bmnOEsGFYTkMTCNFzvxHifujiVh(bool P_0, bool P_1, bool P_2, bool P_3)
			{
				sOLDfEGCnVIUecIzhDXtjklHSzBq.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0, P_1, ynjANzJrXKZModnZDIcqqisQTavB);
				diEurUXkpvVGbRKJDRIqdEdNeHOc.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_2, P_3, ynjANzJrXKZModnZDIcqqisQTavB);
				float buttonDoublePressSpeed = TuyABdnNXmGSpXEbASGgOwJcMGk.buttonDoublePressSpeed;
				QXJaAJvJKuyMeDJRFbPvkrFKUHb.QTPiZFmnRsxmyQYmMuIoBQkOtfg(buttonDoublePressSpeed, P_0, P_1);
				QQkFivSUKaHHakzyHZlXPqfOBJre.QTPiZFmnRsxmyQYmMuIoBQkOtfg(buttonDoublePressSpeed, P_2, P_3);
				float buttonRepeatDelay = TuyABdnNXmGSpXEbASGgOwJcMGk.buttonRepeatDelay;
				float buttonRepeatRate = TuyABdnNXmGSpXEbASGgOwJcMGk.buttonRepeatRate;
				CzBhaDIoMRPFhHxFdRtzmmFikfo.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0, P_1, buttonRepeatDelay, buttonRepeatRate, ynjANzJrXKZModnZDIcqqisQTavB);
				KOGQGRYjlLIaxbuGjjrfEGNqmjas.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_2, P_3, buttonRepeatDelay, buttonRepeatRate, ynjANzJrXKZModnZDIcqqisQTavB);
			}

			internal bool ADBbsHHcwzpIoGLvhUkxpDnbIDl()
			{
				if (ynjANzJrXKZModnZDIcqqisQTavB < YBfOwcrMhrWUDmjHdIVbDCjvwLF + (double)TuyABdnNXmGSpXEbASGgOwJcMGk.buttonDoublePressSpeed + 2.0 * (double)RzegSOgDEdcalxxLIlidmpPPKpdA)
				{
					return false;
				}
				if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f)
				{
					return false;
				}
				if (hYagYvcguGwAgOlgRPUrmMzuChBt != 0f)
				{
					return false;
				}
				if (foizlTVmYytexOFjtTkYhHmXiQC == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
				{
					return false;
				}
				if (CWTocFPKDroGPRjfrMrlzhDmaVJ == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
				{
					return false;
				}
				if (JqjHiTxSfvqzvuKfFnUxyoXyddE == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
				{
					return false;
				}
				if (YSumELMlgkaZAEMUtUovfsDdCrqW == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
				{
					return false;
				}
				if (GjLGrIcXtUadHvcKixNFLfdtHim != 0f)
				{
					return false;
				}
				if (KDkGspuGbcOUYvTsScbfzUSoOTW != 0f)
				{
					return false;
				}
				if (ygJgCdKIslEqPeeQhtUfpCfblhQn != 0f)
				{
					return false;
				}
				if (lTUdcEOmgJCHMPZVIBMszBtWuLp != 0f)
				{
					return false;
				}
				if (sEufHiAsKMgHbqEzYAhrEgipzVin != null && sEufHiAsKMgHbqEzYAhrEgipzVin.running)
				{
					return false;
				}
				if (HNBaPpKbrfdzFLWFpYmLEDtBZHEn != null && HNBaPpKbrfdzFLWFpYmLEDtBZHEn.running)
				{
					return false;
				}
				return true;
			}

			internal void EjDfZkgyIkJerwWDoYxnQeFqTgK()
			{
				foizlTVmYytexOFjtTkYhHmXiQC &= ~ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg;
			}

			internal void CZmZbtMncLTjhIRiLRHSACUbiJg()
			{
				if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f || GjLGrIcXtUadHvcKixNFLfdtHim != 0f)
				{
					pUKwVPGgjQkhgBKdaTvipVgnBIr = ynjANzJrXKZModnZDIcqqisQTavB;
				}
				if (WgrRnhMAvsCWGDqROQcQGpjllbYh != 0f || ygJgCdKIslEqPeeQhtUfpCfblhQn != 0f)
				{
					OkQBkNUogSeXnEoMhBvlcwfgPuqi = ynjANzJrXKZModnZDIcqqisQTavB;
				}
				WgrRnhMAvsCWGDqROQcQGpjllbYh = 0f;
				hYagYvcguGwAgOlgRPUrmMzuChBt = 0f;
				xsXndYnsDYEZmSXyNiYhinTzVHV = AxisCoordinateMode.Absolute;
				foizlTVmYytexOFjtTkYhHmXiQC = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
				CWTocFPKDroGPRjfrMrlzhDmaVJ = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
				JqjHiTxSfvqzvuKfFnUxyoXyddE = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
				YSumELMlgkaZAEMUtUovfsDdCrqW = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
				GjLGrIcXtUadHvcKixNFLfdtHim = 0f;
				KDkGspuGbcOUYvTsScbfzUSoOTW = 0f;
				ygJgCdKIslEqPeeQhtUfpCfblhQn = 0f;
				lTUdcEOmgJCHMPZVIBMszBtWuLp = 0f;
				if (sEufHiAsKMgHbqEzYAhrEgipzVin != null)
				{
					sEufHiAsKMgHbqEzYAhrEgipzVin.Clear();
					HNBaPpKbrfdzFLWFpYmLEDtBZHEn.Clear();
				}
				QXJaAJvJKuyMeDJRFbPvkrFKUHb.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				QQkFivSUKaHHakzyHZlXPqfOBJre.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				sOLDfEGCnVIUecIzhDXtjklHSzBq.CZmZbtMncLTjhIRiLRHSACUbiJg(ynjANzJrXKZModnZDIcqqisQTavB);
				diEurUXkpvVGbRKJDRIqdEdNeHOc.CZmZbtMncLTjhIRiLRHSACUbiJg(ynjANzJrXKZModnZDIcqqisQTavB);
				CzBhaDIoMRPFhHxFdRtzmmFikfo.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				KOGQGRYjlLIaxbuGjjrfEGNqmjas.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				zHUZwTvTlhGQOvqTdZLxtCGnDLQ.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}

			internal void DssCuBdWRUzcmOqXethsqWgGwvP()
			{
				CZmZbtMncLTjhIRiLRHSACUbiJg();
				sOLDfEGCnVIUecIzhDXtjklHSzBq.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				diEurUXkpvVGbRKJDRIqdEdNeHOc.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				pUKwVPGgjQkhgBKdaTvipVgnBIr = ynjANzJrXKZModnZDIcqqisQTavB;
				OkQBkNUogSeXnEoMhBvlcwfgPuqi = ynjANzJrXKZModnZDIcqqisQTavB;
			}
		}

		public OKhGqTeCEyFXhvyElAcvUtsPqLyb[] cXZAhDQESebRdBDchpsjrHPyUmL;

		private readonly int[] GHpaksAgBLPWigDCHcBIJDZSGbTX;

		private int FMfGoswTmMzBNBPokzjvUBjQbHe;

		internal OKhGqTeCEyFXhvyElAcvUtsPqLyb bAihUPOaQoqOwOHZvtGkVuGzqqW;

		internal UpdateLoopType updateLoop
		{
			set
			{
				FMfGoswTmMzBNBPokzjvUBjQbHe = GHpaksAgBLPWigDCHcBIJDZSGbTX[(int)value];
				bAihUPOaQoqOwOHZvtGkVuGzqqW = cXZAhDQESebRdBDchpsjrHPyUmL[FMfGoswTmMzBNBPokzjvUBjQbHe];
			}
		}

		internal sqYdltDCKSVUNBeYEdsfnrWHHmM(UpdateLoopSetting updateLoopSetting, InputBehavior inputBehavior)
		{
			GHpaksAgBLPWigDCHcBIJDZSGbTX = new int[3];
			ArrayTools.Fill(GHpaksAgBLPWigDCHcBIJDZSGbTX, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					GHpaksAgBLPWigDCHcBIJDZSGbTX[(int)list[i]] = num;
					num++;
				}
			}
			cXZAhDQESebRdBDchpsjrHPyUmL = new OKhGqTeCEyFXhvyElAcvUtsPqLyb[num];
			for (int j = 0; j < num; j++)
			{
				cXZAhDQESebRdBDchpsjrHPyUmL[j] = new OKhGqTeCEyFXhvyElAcvUtsPqLyb(inputBehavior);
			}
			bAihUPOaQoqOwOHZvtGkVuGzqqW = cXZAhDQESebRdBDchpsjrHPyUmL[0];
		}

		internal bool ADBbsHHcwzpIoGLvhUkxpDnbIDl()
		{
			for (int i = 0; i < 3; i++)
			{
				if (GHpaksAgBLPWigDCHcBIJDZSGbTX[i] >= 0 && !cXZAhDQESebRdBDchpsjrHPyUmL[GHpaksAgBLPWigDCHcBIJDZSGbTX[i]].ADBbsHHcwzpIoGLvhUkxpDnbIDl())
				{
					return false;
				}
			}
			return true;
		}

		internal void QjNHfjHnCmaQyvCGKbwODraSxUWC()
		{
			for (int i = 0; i < cXZAhDQESebRdBDchpsjrHPyUmL.Length; i++)
			{
				cXZAhDQESebRdBDchpsjrHPyUmL[i].DssCuBdWRUzcmOqXethsqWgGwvP();
			}
		}

		internal void CZmZbtMncLTjhIRiLRHSACUbiJg()
		{
			for (int i = 0; i < cXZAhDQESebRdBDchpsjrHPyUmL.Length; i++)
			{
				cXZAhDQESebRdBDchpsjrHPyUmL[i].CZmZbtMncLTjhIRiLRHSACUbiJg();
			}
		}
	}

	private class wxLulOaWyMDmhYLCNbtqdrLSexBV
	{
		internal class XRKImCFESNFbntIkfkUzgYAcHKh
		{
			internal Vector3 eZSxXRfmrupzXJmTkNwFdesIrOX;

			internal Vector3 azJXxMbjLBeyLHcASdwfxsiBbYo;

			internal Vector3 DRVPBHOSBXDgtQSZnIQDJHVKQDO;

			internal void SIaRjOTRHOrvqQoRxNFbfBqjCIfd()
			{
				eZSxXRfmrupzXJmTkNwFdesIrOX = ReInput.controllers.Mouse.screenPosition;
				DRVPBHOSBXDgtQSZnIQDJHVKQDO = eZSxXRfmrupzXJmTkNwFdesIrOX - azJXxMbjLBeyLHcASdwfxsiBbYo;
			}

			internal void JtotbxjGktWRwpniLglujximcIf()
			{
				azJXxMbjLBeyLHcASdwfxsiBbYo.x = eZSxXRfmrupzXJmTkNwFdesIrOX.x;
				azJXxMbjLBeyLHcASdwfxsiBbYo.y = eZSxXRfmrupzXJmTkNwFdesIrOX.y;
				azJXxMbjLBeyLHcASdwfxsiBbYo.z = eZSxXRfmrupzXJmTkNwFdesIrOX.z;
			}
		}

		private ADictionary<int, XRKImCFESNFbntIkfkUzgYAcHKh> aYLjkEtchHYfxmcPaRErlbyjaeW;

		private XRKImCFESNFbntIkfkUzgYAcHKh yBhzronwNwfFPwTJswNiOmzYafA;

		private UpdateLoopType pYfkoKEDPHacnQemzFQkFSPPaeo;

		internal XRKImCFESNFbntIkfkUzgYAcHKh current => yBhzronwNwfFPwTJswNiOmzYafA;

		internal wxLulOaWyMDmhYLCNbtqdrLSexBV(UpdateLoopSetting updateLoopSetting)
		{
			yBhzronwNwfFPwTJswNiOmzYafA = null;
			aYLjkEtchHYfxmcPaRErlbyjaeW = new ADictionary<int, XRKImCFESNFbntIkfkUzgYAcHKh>();
			using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				XRKImCFESNFbntIkfkUzgYAcHKh value = new XRKImCFESNFbntIkfkUzgYAcHKh();
				aYLjkEtchHYfxmcPaRErlbyjaeW.Add((int)list[i], value);
				if (yBhzronwNwfFPwTJswNiOmzYafA == null)
				{
					yBhzronwNwfFPwTJswNiOmzYafA = value;
				}
			}
		}

		internal void SIaRjOTRHOrvqQoRxNFbfBqjCIfd(UpdateLoopType P_0)
		{
			if (pYfkoKEDPHacnQemzFQkFSPPaeo != P_0)
			{
				pYfkoKEDPHacnQemzFQkFSPPaeo = P_0;
			}
			yBhzronwNwfFPwTJswNiOmzYafA = aYLjkEtchHYfxmcPaRErlbyjaeW[(int)P_0];
			yBhzronwNwfFPwTJswNiOmzYafA.SIaRjOTRHOrvqQoRxNFbfBqjCIfd();
		}

		internal void JtotbxjGktWRwpniLglujximcIf()
		{
			yBhzronwNwfFPwTJswNiOmzYafA.JtotbxjGktWRwpniLglujximcIf();
		}
	}

	private const int mPYEbsFPhIkEriUYDHCCMsZOPBkB = 4;

	internal readonly string YckvCvRVVkCnFoBTmVxvWZVKnMr;

	internal readonly int sRbRrhSYcsdTbzpQQADExfvLSkq;

	internal readonly int ivfdKpZALpQIAdtIdHmkpPFkwfq;

	private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

	private InputBehavior TuyABdnNXmGSpXEbASGgOwJcMGk;

	private sqYdltDCKSVUNBeYEdsfnrWHHmM cKudGzHHquHGqGlsBvXxqMfrUSMT;

	private static ConfigVars zeOdvKvLepaDssBfYXvcNnfTGHoC;

	private static wxLulOaWyMDmhYLCNbtqdrLSexBV fhSGsMKEFltInlSSuCLmFvkNMcH;

	private static UpdateLoopType VxlgPAzxYBAGhdzzmKrRAokdIFJ;

	private static double ynjANzJrXKZModnZDIcqqisQTavB;

	private static float RzegSOgDEdcalxxLIlidmpPPKpdA;

	private static uint neTcCByjjCOmlddjENecmBjukYj;

	private float HgYuQHisDRnpxcdbVhkpElAUDBIi;

	private float fvxeQAAsHyQtOcZGZETaCtcIALdf;

	private float DCXWGiuPdLgSSorGHsRgmkwoVvA;

	private float ACewpHGoqomgeMlMArYjCNghuLl;

	private ButtonStateFlags gVbwUAxbMKXbQlbTPeZownWtNAG;

	private ButtonStateFlags ZDSGamSHUJOGkaIvNFCSrASJamS;

	private float dHAeMbKKXTSZciauMqoSihyHfJks;

	private bool ysdsrCJMIjcNTBvsYuJQSzvAaTkD;

	private AxisCoordinateMode KJdfixaafqvLgGwPxHxVlbNzQaxh;

	private AxisCoordinateMode SpAgGfmsDqYAIZzfVwJQCCpMKoA;

	private readonly rxizQcqELWjNcpUqFcayhKmEbqQ iciAwfdSaIWjIeJpmsbViLwFXoHV = new rxizQcqELWjNcpUqFcayhKmEbqQ();

	private uint vSFqWhzplwYuNKKQNyikNOBDMTq;

	private uint DBcvmWEfjUakKHQanhtzeNDUWri;

	private bool FaUCRxByEHlUiqKsikZVIKhDZje;

	private ZokPvEPpGPbZixpzdMyWwRVcNWx iUcBNsgMTwBTyshyoIALRtOkREUD;

	private int GJxygbMjSGaItAAdWxGSHmcbsBXc;

	private rxizQcqELWjNcpUqFcayhKmEbqQ[] xNAuLSChIGuEOCfpEQbbFrZrwBu;

	private List<InputActionSourceData> WShfNuDgvhHNpipxdvHbuuheMFzk;

	private ReadOnlyCollection<InputActionSourceData> jqfJOqErfelbaeAuRxXivsreKfU;

	private bool ryvEevrPqxGcDJkNthvEeRFFyrXX;

	internal bool cnfZfltfCQiONpFEGCqZjXcevaVW;

	internal ZokPvEPpGPbZixpzdMyWwRVcNWx RiGXprroBUtILpwRLFsBXFflBhS = ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm;

	internal static readonly IXIeKvaSORQFroTficHozSLyjLk eUaiPcvsYuDmCLEQtxOuILMawWB;

	static dSBGNfhWmOBnJhxggXIGiXSpFLdE()
	{
		eUaiPcvsYuDmCLEQtxOuILMawWB = new IXIeKvaSORQFroTficHozSLyjLk();
	}

	internal dSBGNfhWmOBnJhxggXIGiXSpFLdE(int playerId, InputAction action, InputBehavior inputBehavior, ConfigVars configVars)
	{
		fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput._id;
		zeOdvKvLepaDssBfYXvcNnfTGHoC = configVars;
		ivfdKpZALpQIAdtIdHmkpPFkwfq = playerId;
		sRbRrhSYcsdTbzpQQADExfvLSkq = action.id;
		YckvCvRVVkCnFoBTmVxvWZVKnMr = action.name;
		TuyABdnNXmGSpXEbASGgOwJcMGk = inputBehavior;
		cKudGzHHquHGqGlsBvXxqMfrUSMT = new sqYdltDCKSVUNBeYEdsfnrWHHmM(configVars.updateLoop, inputBehavior);
		xNAuLSChIGuEOCfpEQbbFrZrwBu = new rxizQcqELWjNcpUqFcayhKmEbqQ[4];
		ArrayTools.Populate(xNAuLSChIGuEOCfpEQbbFrZrwBu);
		WShfNuDgvhHNpipxdvHbuuheMFzk = new List<InputActionSourceData>();
		jqfJOqErfelbaeAuRxXivsreKfU = new ReadOnlyCollection<InputActionSourceData>(WShfNuDgvhHNpipxdvHbuuheMFzk);
	}

	internal static void vmSPQzZKqmITEagAYqDGuSxIOIQ(ConfigVars P_0)
	{
		fhSGsMKEFltInlSSuCLmFvkNMcH = new wxLulOaWyMDmhYLCNbtqdrLSexBV(P_0.updateLoop);
	}

	internal static void yYtCAhIquEbBOKtXcLzOaAnecRTE(UpdateLoopType P_0)
	{
		VxlgPAzxYBAGhdzzmKrRAokdIFJ = P_0;
		ynjANzJrXKZModnZDIcqqisQTavB = ReInput.unscaledTime;
		RzegSOgDEdcalxxLIlidmpPPKpdA = (float)ReInput.unscaledDeltaTime;
		neTcCByjjCOmlddjENecmBjukYj = ReInput.absFrame;
		fhSGsMKEFltInlSSuCLmFvkNMcH.SIaRjOTRHOrvqQoRxNFbfBqjCIfd(P_0);
	}

	internal static void xOOMkwRyMBBVqDgOCtdZuEfvbDn()
	{
		fhSGsMKEFltInlSSuCLmFvkNMcH.JtotbxjGktWRwpniLglujximcIf();
	}

	private void GAoIrcJNBzdIKwVBBgYrNAaWelip()
	{
		cKudGzHHquHGqGlsBvXxqMfrUSMT.updateLoop = VxlgPAzxYBAGhdzzmKrRAokdIFJ;
		cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.cRwrrpvsiScmwCsnCOorxcvTJLa();
		cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.dmgjAahAeviGVNvRKpBOvvmCjU();
		if (HgYuQHisDRnpxcdbVhkpElAUDBIi != 0f)
		{
			HgYuQHisDRnpxcdbVhkpElAUDBIi = 0f;
		}
		if (fvxeQAAsHyQtOcZGZETaCtcIALdf != 0f)
		{
			fvxeQAAsHyQtOcZGZETaCtcIALdf = 0f;
		}
		if (gVbwUAxbMKXbQlbTPeZownWtNAG != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			gVbwUAxbMKXbQlbTPeZownWtNAG = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
		}
		if (ZDSGamSHUJOGkaIvNFCSrASJamS != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			ZDSGamSHUJOGkaIvNFCSrASJamS = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
		}
		if (dHAeMbKKXTSZciauMqoSihyHfJks != 0f)
		{
			dHAeMbKKXTSZciauMqoSihyHfJks = 0f;
		}
		if (ysdsrCJMIjcNTBvsYuJQSzvAaTkD)
		{
			ysdsrCJMIjcNTBvsYuJQSzvAaTkD = false;
		}
		if (DCXWGiuPdLgSSorGHsRgmkwoVvA != 0f)
		{
			DCXWGiuPdLgSSorGHsRgmkwoVvA = 0f;
		}
		if (ACewpHGoqomgeMlMArYjCNghuLl != 0f)
		{
			ACewpHGoqomgeMlMArYjCNghuLl = 0f;
		}
		if (KJdfixaafqvLgGwPxHxVlbNzQaxh != AxisCoordinateMode.Absolute)
		{
			KJdfixaafqvLgGwPxHxVlbNzQaxh = AxisCoordinateMode.Absolute;
		}
		if (SpAgGfmsDqYAIZzfVwJQCCpMKoA != AxisCoordinateMode.Absolute)
		{
			SpAgGfmsDqYAIZzfVwJQCCpMKoA = AxisCoordinateMode.Absolute;
		}
		if (GJxygbMjSGaItAAdWxGSHmcbsBXc > 0)
		{
			SHdZEDwRTKGPgjsdTFinzyiLqzl();
		}
		if (iciAwfdSaIWjIeJpmsbViLwFXoHV.rkAjkyfvoRxILmntHviwzcLqjma)
		{
			iciAwfdSaIWjIeJpmsbViLwFXoHV.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
		}
	}

	internal void clmETOaSnIMZqfuDWIbhRhvcRVgd(bool P_0)
	{
		if (vSFqWhzplwYuNKKQNyikNOBDMTq != neTcCByjjCOmlddjENecmBjukYj)
		{
			vSFqWhzplwYuNKKQNyikNOBDMTq = neTcCByjjCOmlddjENecmBjukYj;
			if (iUcBNsgMTwBTyshyoIALRtOkREUD != RiGXprroBUtILpwRLFsBXFflBhS)
			{
				iUcBNsgMTwBTyshyoIALRtOkREUD = RiGXprroBUtILpwRLFsBXFflBhS;
			}
			if (cnfZfltfCQiONpFEGCqZjXcevaVW)
			{
				GAoIrcJNBzdIKwVBBgYrNAaWelip();
			}
			else if (RiGXprroBUtILpwRLFsBXFflBhS == ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm)
			{
				RiGXprroBUtILpwRLFsBXFflBhS = ZokPvEPpGPbZixpzdMyWwRVcNWx.jasTeCPLFrfoLaDxyjJNoVklazd;
			}
		}
		if (!P_0)
		{
			return;
		}
		if (DBcvmWEfjUakKHQanhtzeNDUWri != neTcCByjjCOmlddjENecmBjukYj)
		{
			DBcvmWEfjUakKHQanhtzeNDUWri = neTcCByjjCOmlddjENecmBjukYj;
			if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
			{
				ZqEEdiUDeOevjfnmGvhwDsnsnQm();
				GAoIrcJNBzdIKwVBBgYrNAaWelip();
			}
			cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.YBfOwcrMhrWUDmjHdIVbDCjvwLF = ynjANzJrXKZModnZDIcqqisQTavB;
		}
		IXIeKvaSORQFroTficHozSLyjLk iXIeKvaSORQFroTficHozSLyjLk = eUaiPcvsYuDmCLEQtxOuILMawWB;
		int ofrrxjPHuwNabkrGucUvSPRIAGB = iXIeKvaSORQFroTficHozSLyjLk.laNInwdlemPELucvBOGimoeNQfc.ofrrxjPHuwNabkrGucUvSPRIAGB;
		XBosVFkvIHvKqTpSkEunItpXipO(iXIeKvaSORQFroTficHozSLyjLk.pxFOUEuAQwwDMNyKdQhVGxLNflI, iXIeKvaSORQFroTficHozSLyjLk.XKsXMwpOxrVrFXsnXueqVpKoaEV, iXIeKvaSORQFroTficHozSLyjLk.laNInwdlemPELucvBOGimoeNQfc);
		if (iXIeKvaSORQFroTficHozSLyjLk.vfOgoNYdPlyNOyYmKzOzPipRXne == ControllerElementType.Button)
		{
			if (iXIeKvaSORQFroTficHozSLyjLk.isBfJTbCjlLXPjHJYiieAIxdKiCB)
			{
				if (iXIeKvaSORQFroTficHozSLyjLk.laNInwdlemPELucvBOGimoeNQfc._axisContribution == Pole.Positive)
				{
					YqThBgHlRhQJtSDaTcftkGasRti(ref gVbwUAxbMKXbQlbTPeZownWtNAG, iXIeKvaSORQFroTficHozSLyjLk.foizlTVmYytexOFjtTkYhHmXiQC);
				}
				else
				{
					YqThBgHlRhQJtSDaTcftkGasRti(ref ZDSGamSHUJOGkaIvNFCSrASJamS, iXIeKvaSORQFroTficHozSLyjLk.foizlTVmYytexOFjtTkYhHmXiQC);
				}
				if (KJdfixaafqvLgGwPxHxVlbNzQaxh == AxisCoordinateMode.Absolute)
				{
					HgYuQHisDRnpxcdbVhkpElAUDBIi += iXIeKvaSORQFroTficHozSLyjLk.HpxePuhaScltgSCBmgsrsCpjliL;
				}
				return;
			}
			if (iXIeKvaSORQFroTficHozSLyjLk.laNInwdlemPELucvBOGimoeNQfc._axisContribution == Pole.Positive)
			{
				YqThBgHlRhQJtSDaTcftkGasRti(ref gVbwUAxbMKXbQlbTPeZownWtNAG, iXIeKvaSORQFroTficHozSLyjLk.foizlTVmYytexOFjtTkYhHmXiQC);
			}
			else
			{
				YqThBgHlRhQJtSDaTcftkGasRti(ref ZDSGamSHUJOGkaIvNFCSrASJamS, iXIeKvaSORQFroTficHozSLyjLk.foizlTVmYytexOFjtTkYhHmXiQC);
			}
			if (iXIeKvaSORQFroTficHozSLyjLk.HpxePuhaScltgSCBmgsrsCpjliL != 0f)
			{
				dHAeMbKKXTSZciauMqoSihyHfJks += (int)(1f * MathTools.Sign(iXIeKvaSORQFroTficHozSLyjLk.HpxePuhaScltgSCBmgsrsCpjliL));
				iciAwfdSaIWjIeJpmsbViLwFXoHV.vJjhoRLlAcrjzWycVrrFomtsobA(iXIeKvaSORQFroTficHozSLyjLk);
			}
			if ((iXIeKvaSORQFroTficHozSLyjLk.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
			{
				ysdsrCJMIjcNTBvsYuJQSzvAaTkD = true;
			}
			return;
		}
		if (iXIeKvaSORQFroTficHozSLyjLk.vfOgoNYdPlyNOyYmKzOzPipRXne == ControllerElementType.Axis)
		{
			switch (iXIeKvaSORQFroTficHozSLyjLk.KuXUxnrnEEmYKlaMyJdtDYyuul)
			{
			case ControllerType.Mouse:
				if ((ofrrxjPHuwNabkrGucUvSPRIAGB < 2 && TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisMode == MouseXYAxisMode.DigitalAxis) || (ofrrxjPHuwNabkrGucUvSPRIAGB > 1 && TuyABdnNXmGSpXEbASGgOwJcMGk.mouseOtherAxisMode == MouseOtherAxisMode.DigitalAxis))
				{
					iZRgrHunvXPRAHSjigClsGkHNYJ(iXIeKvaSORQFroTficHozSLyjLk, 0f, true);
					break;
				}
				if (ofrrxjPHuwNabkrGucUvSPRIAGB < 2)
				{
					if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
					{
						DCXWGiuPdLgSSorGHsRgmkwoVvA += iXIeKvaSORQFroTficHozSLyjLk.HpxePuhaScltgSCBmgsrsCpjliL * TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisSensitivity;
					}
					else if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisMode == MouseXYAxisMode.ScreenPositionDelta || TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisMode == MouseXYAxisMode.Speed)
					{
						float num;
						float num2;
						if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.Normal)
						{
							num = Screen.width;
							num2 = Screen.height;
						}
						else if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenWidth)
						{
							num = Screen.width;
							num2 = num;
						}
						else
						{
							if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.ScreenHeight)
							{
								throw new NotImplementedException();
							}
							num2 = Screen.height;
							num = num2;
						}
						wxLulOaWyMDmhYLCNbtqdrLSexBV.XRKImCFESNFbntIkfkUzgYAcHKh current = fhSGsMKEFltInlSSuCLmFvkNMcH.current;
						if (ofrrxjPHuwNabkrGucUvSPRIAGB == 0)
						{
							float x = current.DRVPBHOSBXDgtQSZnIQDJHVKQDO.x;
							if (x != 0f)
							{
								float num3 = x / num;
								if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisMode == MouseXYAxisMode.Speed)
								{
									num3 /= RzegSOgDEdcalxxLIlidmpPPKpdA;
								}
								DCXWGiuPdLgSSorGHsRgmkwoVvA += num3;
							}
						}
						else
						{
							float y = current.DRVPBHOSBXDgtQSZnIQDJHVKQDO.y;
							if (y != 0f)
							{
								float num4 = y / num2;
								if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseXYAxisMode == MouseXYAxisMode.Speed)
								{
									num4 /= RzegSOgDEdcalxxLIlidmpPPKpdA;
								}
								DCXWGiuPdLgSSorGHsRgmkwoVvA += num4;
							}
						}
					}
				}
				else if (TuyABdnNXmGSpXEbASGgOwJcMGk.mouseOtherAxisMode == MouseOtherAxisMode.MouseAxis)
				{
					DCXWGiuPdLgSSorGHsRgmkwoVvA += iXIeKvaSORQFroTficHozSLyjLk.HpxePuhaScltgSCBmgsrsCpjliL * TuyABdnNXmGSpXEbASGgOwJcMGk.mouseOtherAxisSensitivity;
				}
				iZRgrHunvXPRAHSjigClsGkHNYJ(iXIeKvaSORQFroTficHozSLyjLk, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonDeadZone, false);
				break;
			case ControllerType.Joystick:
				kDgHLbQapBGJTotJViQPkosUYMxo(iXIeKvaSORQFroTficHozSLyjLk, TuyABdnNXmGSpXEbASGgOwJcMGk.joystickAxisSensitivity);
				break;
			case ControllerType.Custom:
				kDgHLbQapBGJTotJViQPkosUYMxo(iXIeKvaSORQFroTficHozSLyjLk, TuyABdnNXmGSpXEbASGgOwJcMGk.customControllerAxisSensitivity);
				break;
			default:
				throw new NotImplementedException();
			}
			return;
		}
		throw new NotImplementedException();
	}

	private void kDgHLbQapBGJTotJViQPkosUYMxo(IXIeKvaSORQFroTficHozSLyjLk P_0, float P_1)
	{
		float num = P_0.HpxePuhaScltgSCBmgsrsCpjliL * P_1;
		if (P_0.NxNFdaeaOElPXLgAPBoLILTJWNm)
		{
			if (P_0.xsXndYnsDYEZmSXyNiYhinTzVHV == AxisCoordinateMode.Absolute)
			{
				if (KJdfixaafqvLgGwPxHxVlbNzQaxh == AxisCoordinateMode.Absolute)
				{
					HgYuQHisDRnpxcdbVhkpElAUDBIi += num;
				}
			}
			else if (P_0.xsXndYnsDYEZmSXyNiYhinTzVHV == AxisCoordinateMode.Relative)
			{
				if (KJdfixaafqvLgGwPxHxVlbNzQaxh != AxisCoordinateMode.Relative)
				{
					HgYuQHisDRnpxcdbVhkpElAUDBIi = num;
					KJdfixaafqvLgGwPxHxVlbNzQaxh = AxisCoordinateMode.Relative;
				}
				else
				{
					HgYuQHisDRnpxcdbVhkpElAUDBIi = MathTools.MaxMagnitude(HgYuQHisDRnpxcdbVhkpElAUDBIi, num);
				}
			}
		}
		else if (P_0.xsXndYnsDYEZmSXyNiYhinTzVHV == AxisCoordinateMode.Absolute)
		{
			if (SpAgGfmsDqYAIZzfVwJQCCpMKoA == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(fvxeQAAsHyQtOcZGZETaCtcIALdf))
			{
				fvxeQAAsHyQtOcZGZETaCtcIALdf = num;
			}
		}
		else if (P_0.xsXndYnsDYEZmSXyNiYhinTzVHV == AxisCoordinateMode.Relative)
		{
			if (SpAgGfmsDqYAIZzfVwJQCCpMKoA != AxisCoordinateMode.Relative)
			{
				fvxeQAAsHyQtOcZGZETaCtcIALdf = num;
				SpAgGfmsDqYAIZzfVwJQCCpMKoA = AxisCoordinateMode.Relative;
			}
			else if (MathTools.Abs(num) > MathTools.Abs(fvxeQAAsHyQtOcZGZETaCtcIALdf))
			{
				fvxeQAAsHyQtOcZGZETaCtcIALdf = num;
			}
		}
		iZRgrHunvXPRAHSjigClsGkHNYJ(P_0, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonDeadZone, false);
	}

	private void iZRgrHunvXPRAHSjigClsGkHNYJ(IXIeKvaSORQFroTficHozSLyjLk P_0, float P_1, bool P_2)
	{
		JtVEtBYJhQtFKDuamlFmfbgoJGw jtVEtBYJhQtFKDuamlFmfbgoJGw = JtVEtBYJhQtFKDuamlFmfbgoJGw.DydAVEtKkgGfMIgCqQnyUpcWAgVj(P_0.laNInwdlemPELucvBOGimoeNQfc.fOjavGziuUSawAgvwyVARpyRBVx);
		if (P_0.laNInwdlemPELucvBOGimoeNQfc._axisRange == AxisRange.Full)
		{
			if (MathTools.Abs(P_0.HpxePuhaScltgSCBmgsrsCpjliL) > P_1)
			{
				jtVEtBYJhQtFKDuamlFmfbgoJGw.utTCsXoTKybVZQvBnSJsGJBQBnh(VxlgPAzxYBAGhdzzmKrRAokdIFJ, P_0.HpxePuhaScltgSCBmgsrsCpjliL > 0f);
			}
			ButtonStateFlags buttonStateFlags = jtVEtBYJhQtFKDuamlFmfbgoJGw.yLkyycxzClFhuAQFTWmGasObrdy(true);
			ButtonStateFlags buttonStateFlags2 = jtVEtBYJhQtFKDuamlFmfbgoJGw.yLkyycxzClFhuAQFTWmGasObrdy(false);
			YqThBgHlRhQJtSDaTcftkGasRti(ref gVbwUAxbMKXbQlbTPeZownWtNAG, buttonStateFlags);
			YqThBgHlRhQJtSDaTcftkGasRti(ref ZDSGamSHUJOGkaIvNFCSrASJamS, buttonStateFlags2);
			if (P_2 && ((buttonStateFlags & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF || (buttonStateFlags2 & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF))
			{
				if (P_0.HpxePuhaScltgSCBmgsrsCpjliL != 0f)
				{
					dHAeMbKKXTSZciauMqoSihyHfJks += (int)(1f * MathTools.Sign(P_0.HpxePuhaScltgSCBmgsrsCpjliL));
					iciAwfdSaIWjIeJpmsbViLwFXoHV.vJjhoRLlAcrjzWycVrrFomtsobA(P_0);
				}
				ysdsrCJMIjcNTBvsYuJQSzvAaTkD = true;
			}
			return;
		}
		ButtonStateFlags buttonStateFlags3;
		if (P_0.laNInwdlemPELucvBOGimoeNQfc._axisContribution == Pole.Positive)
		{
			if (P_0.HpxePuhaScltgSCBmgsrsCpjliL > P_1)
			{
				jtVEtBYJhQtFKDuamlFmfbgoJGw.utTCsXoTKybVZQvBnSJsGJBQBnh(VxlgPAzxYBAGhdzzmKrRAokdIFJ, true);
			}
			buttonStateFlags3 = jtVEtBYJhQtFKDuamlFmfbgoJGw.yLkyycxzClFhuAQFTWmGasObrdy(true);
			YqThBgHlRhQJtSDaTcftkGasRti(ref gVbwUAxbMKXbQlbTPeZownWtNAG, buttonStateFlags3);
		}
		else
		{
			if (MathTools.Abs(P_0.HpxePuhaScltgSCBmgsrsCpjliL) > P_1)
			{
				jtVEtBYJhQtFKDuamlFmfbgoJGw.utTCsXoTKybVZQvBnSJsGJBQBnh(VxlgPAzxYBAGhdzzmKrRAokdIFJ, false);
			}
			buttonStateFlags3 = jtVEtBYJhQtFKDuamlFmfbgoJGw.yLkyycxzClFhuAQFTWmGasObrdy(false);
			YqThBgHlRhQJtSDaTcftkGasRti(ref ZDSGamSHUJOGkaIvNFCSrASJamS, buttonStateFlags3);
		}
		if (P_2)
		{
			if (P_0.HpxePuhaScltgSCBmgsrsCpjliL != 0f)
			{
				dHAeMbKKXTSZciauMqoSihyHfJks += (int)(1f * MathTools.Sign(P_0.HpxePuhaScltgSCBmgsrsCpjliL));
				iciAwfdSaIWjIeJpmsbViLwFXoHV.vJjhoRLlAcrjzWycVrrFomtsobA(P_0);
			}
			if ((buttonStateFlags3 & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
			{
				ysdsrCJMIjcNTBvsYuJQSzvAaTkD = true;
			}
		}
	}

	internal void vvkCMKLUhZHDFkNfnGNwimTKnnwq()
	{
		if (vSFqWhzplwYuNKKQNyikNOBDMTq != neTcCByjjCOmlddjENecmBjukYj)
		{
			CZmZbtMncLTjhIRiLRHSACUbiJg(false);
		}
		else
		{
			if (RiGXprroBUtILpwRLFsBXFflBhS == ZokPvEPpGPbZixpzdMyWwRVcNWx.jasTeCPLFrfoLaDxyjJNoVklazd)
			{
				return;
			}
			sqYdltDCKSVUNBeYEdsfnrWHHmM.OKhGqTeCEyFXhvyElAcvUtsPqLyb bAihUPOaQoqOwOHZvtGkVuGzqqW = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW;
			bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC = gVbwUAxbMKXbQlbTPeZownWtNAG;
			bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE = ZDSGamSHUJOGkaIvNFCSrASJamS;
			if (DCXWGiuPdLgSSorGHsRgmkwoVvA != 0f)
			{
				bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh = DCXWGiuPdLgSSorGHsRgmkwoVvA;
				bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV = AxisCoordinateMode.Relative;
			}
			else if (fvxeQAAsHyQtOcZGZETaCtcIALdf != 0f)
			{
				bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh = fvxeQAAsHyQtOcZGZETaCtcIALdf;
				bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV = SpAgGfmsDqYAIZzfVwJQCCpMKoA;
			}
			else
			{
				float wgrRnhMAvsCWGDqROQcQGpjllbYh = MathTools.Clamp(HgYuQHisDRnpxcdbVhkpElAUDBIi, -1f, 1f);
				bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh = wgrRnhMAvsCWGDqROQcQGpjllbYh;
				bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV = KJdfixaafqvLgGwPxHxVlbNzQaxh;
			}
			if (FaUCRxByEHlUiqKsikZVIKhDZje)
			{
				bAihUPOaQoqOwOHZvtGkVuGzqqW.EjDfZkgyIkJerwWDoYxnQeFqTgK();
				FaUCRxByEHlUiqKsikZVIKhDZje = false;
			}
			UZmSAuoKYEjsGLnNcRDHzBFqcsf();
			bAihUPOaQoqOwOHZvtGkVuGzqqW.mLcadliumwIpfQEUswJFArNsqbe(ynjANzJrXKZModnZDIcqqisQTavB);
			if (bAihUPOaQoqOwOHZvtGkVuGzqqW.sEufHiAsKMgHbqEzYAhrEgipzVin != null)
			{
				if (mjLdsZfInpRZKvbaHDnESZInHjn())
				{
					bAihUPOaQoqOwOHZvtGkVuGzqqW.sEufHiAsKMgHbqEzYAhrEgipzVin.Start(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonDownBuffer);
				}
				if (bundOzXzxTCieXjHNxaVKIfqIqz())
				{
					bAihUPOaQoqOwOHZvtGkVuGzqqW.HNBaPpKbrfdzFLWFpYmLEDtBZHEn.Start(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonDownBuffer);
				}
			}
			bAihUPOaQoqOwOHZvtGkVuGzqqW.bmnOEsGFYTkMTCNFzvxHifujiVh(wyMTjzWuSYHxxwaQSHqUbLUGgKg(), tczGrLoSLQRKAWwrReBmbHatjKF(), KyvdceKirMVFNQGItYflXrFbvzb(), KpRTXcEtyGlzHQYXMAstvlyskee());
			if (ryvEevrPqxGcDJkNthvEeRFFyrXX)
			{
				huOLUGSphFoFRSzPdWolbKEpClJD();
			}
			if (DBcvmWEfjUakKHQanhtzeNDUWri != neTcCByjjCOmlddjENecmBjukYj && cKudGzHHquHGqGlsBvXxqMfrUSMT.ADBbsHHcwzpIoGLvhUkxpDnbIDl())
			{
				CZmZbtMncLTjhIRiLRHSACUbiJg(true);
			}
		}
	}

	internal void UZmSAuoKYEjsGLnNcRDHzBFqcsf()
	{
		if (iciAwfdSaIWjIeJpmsbViLwFXoHV.rkAjkyfvoRxILmntHviwzcLqjma)
		{
			cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.zHUZwTvTlhGQOvqTdZLxtCGnDLQ.vJjhoRLlAcrjzWycVrrFomtsobA(iciAwfdSaIWjIeJpmsbViLwFXoHV);
		}
		cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.ygJgCdKIslEqPeeQhtUfpCfblhQn = MathTools.Clamp(dHAeMbKKXTSZciauMqoSihyHfJks, -1f, 1f);
		if (!TuyABdnNXmGSpXEbASGgOwJcMGk.digitalAxisSimulation)
		{
			cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.ygJgCdKIslEqPeeQhtUfpCfblhQn;
			if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.zHUZwTvTlhGQOvqTdZLxtCGnDLQ.rkAjkyfvoRxILmntHviwzcLqjma)
			{
				cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.zHUZwTvTlhGQOvqTdZLxtCGnDLQ.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			return;
		}
		if (!ysdsrCJMIjcNTBvsYuJQSzvAaTkD)
		{
			if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim == 0f)
			{
				return;
			}
			float digitalAxisGravity = TuyABdnNXmGSpXEbASGgOwJcMGk.digitalAxisGravity;
			if (digitalAxisGravity != 0f)
			{
				float num = TuyABdnNXmGSpXEbASGgOwJcMGk.digitalAxisGravity * RzegSOgDEdcalxxLIlidmpPPKpdA;
				if (MathTools.Abs(num) >= MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim))
				{
					cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim = 0f;
					cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.zHUZwTvTlhGQOvqTdZLxtCGnDLQ.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
					return;
				}
				float num2 = ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim > 0f) ? (-1f) : 1f);
				cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim = MathTools.Clamp(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim + num2 * num, -1f, 1f);
				rxizQcqELWjNcpUqFcayhKmEbqQ zHUZwTvTlhGQOvqTdZLxtCGnDLQ = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.zHUZwTvTlhGQOvqTdZLxtCGnDLQ;
				XBosVFkvIHvKqTpSkEunItpXipO(zHUZwTvTlhGQOvqTdZLxtCGnDLQ.pxFOUEuAQwwDMNyKdQhVGxLNflI, zHUZwTvTlhGQOvqTdZLxtCGnDLQ.XKsXMwpOxrVrFXsnXueqVpKoaEV, zHUZwTvTlhGQOvqTdZLxtCGnDLQ.laNInwdlemPELucvBOGimoeNQfc);
			}
			return;
		}
		float num3 = MathTools.Clamp(dHAeMbKKXTSZciauMqoSihyHfJks, -1f, 1f);
		float num4 = ((num3 != 0f) ? MathTools.Sign(num3) : 0f);
		float num5 = ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim != 0f) ? MathTools.Sign(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim) : 0f);
		float digitalAxisSensitivity = TuyABdnNXmGSpXEbASGgOwJcMGk.digitalAxisSensitivity;
		if (digitalAxisSensitivity > 0f)
		{
			num3 *= digitalAxisSensitivity * RzegSOgDEdcalxxLIlidmpPPKpdA;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim != 0f)
		{
			if ((num3 != 0f && num4 != num5) ? true : false)
			{
				if (TuyABdnNXmGSpXEbASGgOwJcMGk.digitalAxisInstantReverse)
				{
					num3 += -1f * cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim;
				}
				else if (!TuyABdnNXmGSpXEbASGgOwJcMGk.digitalAxisSnap)
				{
					num3 += cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim;
				}
			}
			else
			{
				num3 += cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim;
			}
		}
		else
		{
			num3 += cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim;
		}
		cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim = MathTools.Clamp(num3, -1f, 1f);
	}

	public float aKtyyQJXaksGFdepXiicilcqmAz()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0f;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV == AxisCoordinateMode.Relative)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh;
		}
		return MathTools.MaxMagnitude(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim);
	}

	public float YuvFXJjoKbLzYOyrEHknhYlkvhl()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0f;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.aHEnlFATUfsIiVanulPDdDyPWCD == AxisCoordinateMode.Relative)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.hYagYvcguGwAgOlgRPUrmMzuChBt;
		}
		return MathTools.MaxMagnitude(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.hYagYvcguGwAgOlgRPUrmMzuChBt, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.KDkGspuGbcOUYvTsScbfzUSoOTW);
	}

	public float cArkNyzMOorWWSNzObtLqCsVBtr()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0f;
		}
		return aKtyyQJXaksGFdepXiicilcqmAz() - YuvFXJjoKbLzYOyrEHknhYlkvhl();
	}

	public double jBvTvekhPPSnTfOevseVOoANboiD()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0.0;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vAxisTimeActive;
	}

	public double lsDBpCjjvErUdqJrBXyEMtkgjQB()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			tYNQvUqwQIGSLDywneeZuyWZgCa();
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vAxisTimeInactive;
	}

	public AxisCoordinateMode goRWYwJTxXIwQvvlqTNFgLgQLGB()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh) >= MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.GjLGrIcXtUadHvcKixNFLfdtHim))
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode OLHQNyfSZNjlIVgYtdCCJpVzLZI()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.hYagYvcguGwAgOlgRPUrmMzuChBt) >= MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.KDkGspuGbcOUYvTsScbfzUSoOTW))
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.aHEnlFATUfsIiVanulPDdDyPWCD;
		}
		return AxisCoordinateMode.Absolute;
	}

	public float bvPTHnqrzMoGbcmasrUYlTzxMan()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0f;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV == AxisCoordinateMode.Relative)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh;
		}
		return MathTools.MaxMagnitude(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.ygJgCdKIslEqPeeQhtUfpCfblhQn);
	}

	public float aaRWGOqBZbRrpeNeRAkuZFnwpBQ()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0f;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.aHEnlFATUfsIiVanulPDdDyPWCD == AxisCoordinateMode.Relative)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.hYagYvcguGwAgOlgRPUrmMzuChBt;
		}
		return MathTools.MaxMagnitude(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.hYagYvcguGwAgOlgRPUrmMzuChBt, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.lTUdcEOmgJCHMPZVIBMszBtWuLp);
	}

	public float PEyjSkXKMLLKdhBrSUBseXpmtSe()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0f;
		}
		return bvPTHnqrzMoGbcmasrUYlTzxMan() - aaRWGOqBZbRrpeNeRAkuZFnwpBQ();
	}

	public double scNpoQFixNaoKeooFtxzugQJONOQ()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0.0;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vAxisRawTimeActive;
	}

	public double oFztjPFMuTUcIoFzBnKJwlnLemu()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			tYNQvUqwQIGSLDywneeZuyWZgCa();
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vAxisRawTimeInactive;
	}

	public AxisCoordinateMode XvpCdaFqDlxJucqISdVdcRymbYxK()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.WgrRnhMAvsCWGDqROQcQGpjllbYh) >= MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.ygJgCdKIslEqPeeQhtUfpCfblhQn))
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.xsXndYnsDYEZmSXyNiYhinTzVHV;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode gDpejzNTeeJRDkNPCyOtpfpYGmg()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.hYagYvcguGwAgOlgRPUrmMzuChBt) >= MathTools.Abs(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.lTUdcEOmgJCHMPZVIBMszBtWuLp))
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.aHEnlFATUfsIiVanulPDdDyPWCD;
		}
		return AxisCoordinateMode.Absolute;
	}

	public bool tczGrLoSLQRKAWwrReBmbHatjKF()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != 0;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) == 0)
		{
			return KpRTXcEtyGlzHQYXMAstvlyskee();
		}
		return true;
	}

	public bool wyMTjzWuSYHxxwaQSHqUbLUGgKg()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sEufHiAsKMgHbqEzYAhrEgipzVin == null)
		{
			return mjLdsZfInpRZKvbaHDnESZInHjn();
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sEufHiAsKMgHbqEzYAhrEgipzVin.running)
		{
			return true;
		}
		if (zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue && cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.HNBaPpKbrfdzFLWFpYmLEDtBZHEn.running)
		{
			return true;
		}
		return false;
	}

	public bool KsQmhhakoIMsmFFssFWZgAtACAmj()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.mDmdRkBMTphUlCvlBpKbpVxeKuBu) != 0;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.mDmdRkBMTphUlCvlBpKbpVxeKuBu) == 0 && (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.mDmdRkBMTphUlCvlBpKbpVxeKuBu) == 0)
		{
			return false;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			return false;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			return false;
		}
		return true;
	}

	public bool qGdIlqXDgmmfISyLXYdCpbxYquo()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressHold;
		}
		if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressHold)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressHold;
		}
		return true;
	}

	public bool bLTbjPpppdHjbxMklgpfIqXRyYp()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressDown;
		}
		bool singlePressDown = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressDown;
		bool singlePressDown2 = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressDown;
		if (!singlePressDown && !singlePressDown2)
		{
			return false;
		}
		if (!singlePressDown && cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressHold)
		{
			return false;
		}
		if (!singlePressDown2 && cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressHold)
		{
			return false;
		}
		return true;
	}

	public bool uTpONumFLTkWQBGLiuKkYLcPhqBe()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressUp;
		}
		bool singlePressUp = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressUp;
		bool singlePressUp2 = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressUp;
		if (!singlePressUp && !singlePressUp2)
		{
			return false;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.singlePressHold)
		{
			return false;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressHold)
		{
			return false;
		}
		return true;
	}

	public bool whhBjVbfHOZRjSSbvvVshFrslSsJ()
	{
		return whhBjVbfHOZRjSSbvvVshFrslSsJ(0f);
	}

	public bool whhBjVbfHOZRjSSbvvVshFrslSsJ(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
			{
				return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.EeMlJALivDnMblIcfunCQenlWlE(P_0);
			}
			if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.EeMlJALivDnMblIcfunCQenlWlE(P_0))
			{
				return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.EeMlJALivDnMblIcfunCQenlWlE(P_0);
			}
			return true;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.doublePressHold;
		}
		if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.doublePressHold)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.doublePressHold;
		}
		return true;
	}

	public bool QdNapEezgsjcIFSIbPqrnaMZYnq()
	{
		return QdNapEezgsjcIFSIbPqrnaMZYnq(0f);
	}

	public bool QdNapEezgsjcIFSIbPqrnaMZYnq(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!wyMTjzWuSYHxxwaQSHqUbLUGgKg())
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.EeMlJALivDnMblIcfunCQenlWlE(P_0);
			}
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.doublePressHold;
		}
		if (P_0 > 0f)
		{
			if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.EeMlJALivDnMblIcfunCQenlWlE(P_0))
			{
				return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.EeMlJALivDnMblIcfunCQenlWlE(P_0);
			}
			return true;
		}
		if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.doublePressHold)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.doublePressHold;
		}
		return true;
	}

	public bool TtNcTNwxGEmdaqaGhItPkYvZUdO()
	{
		return TtNcTNwxGEmdaqaGhItPkYvZUdO(0f);
	}

	public bool TtNcTNwxGEmdaqaGhItPkYvZUdO(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!KsQmhhakoIMsmFFssFWZgAtACAmj())
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.YKlOXJOWzwbhmdZaioDGEKIEsqz(P_0);
			}
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.doublePressUp;
		}
		if (P_0 > 0f)
		{
			if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.YKlOXJOWzwbhmdZaioDGEKIEsqz(P_0))
			{
				return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.YKlOXJOWzwbhmdZaioDGEKIEsqz(P_0);
			}
			return true;
		}
		if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QXJaAJvJKuyMeDJRFbPvkrFKUHb.doublePressUp)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.doublePressUp;
		}
		return true;
	}

	public bool aDlFclJjaCPQLDrdiNxmhIBTyMI(float P_0)
	{
		return aDlFclJjaCPQLDrdiNxmhIBTyMI(P_0, 0f);
	}

	public bool aDlFclJjaCPQLDrdiNxmhIBTyMI(float P_0, float P_1)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!tczGrLoSLQRKAWwrReBmbHatjKF())
		{
			return false;
		}
		double num = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vButtonTimePressed;
		if (zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			num = MathTools.Max(num, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.negativeVButtonTimePressed);
		}
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool sJWIGDsUFDoKbNAvyOYaskgwHl(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return mjLdsZfInpRZKvbaHDnESZInHjn();
		}
		if (!tczGrLoSLQRKAWwrReBmbHatjKF())
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			ButtonStateRecorder sOLDfEGCnVIUecIzhDXtjklHSzBq = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq;
			if (sOLDfEGCnVIUecIzhDXtjklHSzBq.timePressed < (double)P_0)
			{
				return false;
			}
			if (ReInput.unscaledTimePrev - sOLDfEGCnVIUecIzhDXtjklHSzBq.lastTimeUnpressed >= (double)P_0)
			{
				return false;
			}
			return true;
		}
		ButtonStateRecorder sOLDfEGCnVIUecIzhDXtjklHSzBq2 = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq;
		ButtonStateRecorder diEurUXkpvVGbRKJDRIqdEdNeHOc = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc;
		if (sOLDfEGCnVIUecIzhDXtjklHSzBq2.timePressed < (double)P_0 && diEurUXkpvVGbRKJDRIqdEdNeHOc.timePressed < (double)P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - sOLDfEGCnVIUecIzhDXtjklHSzBq2.lastTimeUnpressed >= (double)P_0 || ReInput.unscaledTimePrev - diEurUXkpvVGbRKJDRIqdEdNeHOc.lastTimeUnpressed >= (double)P_0)
		{
			return false;
		}
		return true;
	}

	public bool lCGBACeaSOuNLNMWNtxBERBspZZe(float P_0)
	{
		return lCGBACeaSOuNLNMWNtxBERBspZZe(P_0, 0f);
	}

	public bool lCGBACeaSOuNLNMWNtxBERBspZZe(float P_0, float P_1)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!KsQmhhakoIMsmFFssFWZgAtACAmj())
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			double num = ReInput.unscaledTime - cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.lastTimeStateChangedToPressed;
			if (num < (double)P_0)
			{
				return false;
			}
			if (P_1 > 0f && num >= (double)(P_0 + P_1))
			{
				return false;
			}
			return true;
		}
		double num2 = ReInput.unscaledTime - MathTools.Max(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.sOLDfEGCnVIUecIzhDXtjklHSzBq.lastTimeStateChangedToPressed, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.lastTimeStateChangedToPressed);
		if (num2 < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num2 >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool dKbahpClgHBuTgUPoelgHzAZVwQ()
	{
		return aDlFclJjaCPQLDrdiNxmhIBTyMI(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressExpiresIn);
	}

	public bool axtYUltftYAAjLPpUwFjQcEktUM()
	{
		return sJWIGDsUFDoKbNAvyOYaskgwHl(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressTime);
	}

	public bool OeXCqNiCLCaJzCiThgBniwNKGycT()
	{
		return lCGBACeaSOuNLNMWNtxBERBspZZe(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressExpiresIn);
	}

	public bool fgiCbahJbtQhKcuDieKIRhCuqUh()
	{
		return aDlFclJjaCPQLDrdiNxmhIBTyMI(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressExpiresIn);
	}

	public bool iixuPYZWCGdNerQwVyFULoIHNjd()
	{
		return sJWIGDsUFDoKbNAvyOYaskgwHl(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressTime);
	}

	public bool gGlIKclBCWWWrDZXIZMThojjQoM()
	{
		return lCGBACeaSOuNLNMWNtxBERBspZZe(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressExpiresIn);
	}

	public bool FmdAkBdCmGnmfuYHekqHitZeeAud()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.CzBhaDIoMRPFhHxFdRtzmmFikfo.state;
		}
		if (!cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.CzBhaDIoMRPFhHxFdRtzmmFikfo.state)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.KOGQGRYjlLIaxbuGjjrfEGNqmjas.state;
		}
		return true;
	}

	public bool hOuVCsfFccvyBzqOmUyNGejSnqg()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.CWTocFPKDroGPRjfrMrlzhDmaVJ & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != 0;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.CWTocFPKDroGPRjfrMrlzhDmaVJ & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) == 0)
		{
			return VdfXOJuqKRFlPuSWWCQbwWJCAGE();
		}
		return true;
	}

	public double WauVOxzcNMHVLRuwItTTKDEMssd()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0.0;
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vButtonTimePressed;
		}
		return MathTools.Max(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vButtonTimePressed, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.negativeVButtonTimePressed);
	}

	public double qspOkCVETJmjRdLTpzzGWWkmhaO()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			tYNQvUqwQIGSLDywneeZuyWZgCa();
		}
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vButtonTimeUnpressed;
		}
		return MathTools.Min(cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.vButtonTimeUnpressed, cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.negativeVButtonTimeUnpressed);
	}

	private bool mjLdsZfInpRZKvbaHDnESZInHjn()
	{
		if (!zeOdvKvLepaDssBfYXvcNnfTGHoC.activateActionButtonsOnNegativeValue)
		{
			return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) != 0;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) == 0 && (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) == 0)
		{
			return false;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF && (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.foizlTVmYytexOFjtTkYhHmXiQC & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) == 0)
		{
			return false;
		}
		if ((cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF && (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) == 0)
		{
			return false;
		}
		return true;
	}

	public bool KpRTXcEtyGlzHQYXMAstvlyskee()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != 0;
	}

	public bool KyvdceKirMVFNQGItYflXrFbvzb()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.HNBaPpKbrfdzFLWFpYmLEDtBZHEn == null)
		{
			return bundOzXzxTCieXjHNxaVKIfqIqz();
		}
		if (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.HNBaPpKbrfdzFLWFpYmLEDtBZHEn.running)
		{
			return true;
		}
		return false;
	}

	public bool ZwUMSLHJcuYAbRcebDaGJalfcRoE()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.mDmdRkBMTphUlCvlBpKbpVxeKuBu) != 0;
	}

	public bool IVMAHIftfIRpuOqIAGjgiDkkRjin()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressHold;
	}

	public bool HbNlUNgsylguLzJPkeRobqoYHepA()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressDown;
	}

	public bool lwafttAKnLnDHJihTAGtqqzlIeee()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.singlePressUp;
	}

	public bool OTglXCPZGItNKXZxLhhMYgiYbsV()
	{
		return OTglXCPZGItNKXZxLhhMYgiYbsV(0f);
	}

	public bool OTglXCPZGItNKXZxLhhMYgiYbsV(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.EeMlJALivDnMblIcfunCQenlWlE(P_0);
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.doublePressHold;
	}

	public bool WyLjqxgprRvoNWgecDgFAQkYIrgd()
	{
		return WyLjqxgprRvoNWgecDgFAQkYIrgd(0f);
	}

	public bool WyLjqxgprRvoNWgecDgFAQkYIrgd(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!KyvdceKirMVFNQGItYflXrFbvzb())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.EeMlJALivDnMblIcfunCQenlWlE(P_0);
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.doublePressHold;
	}

	public bool mjCeSzCOEPPLFcKnhpcBmZPiIPEW()
	{
		return mjCeSzCOEPPLFcKnhpcBmZPiIPEW(0f);
	}

	public bool mjCeSzCOEPPLFcKnhpcBmZPiIPEW(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (!ZwUMSLHJcuYAbRcebDaGJalfcRoE())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.YKlOXJOWzwbhmdZaioDGEKIEsqz(P_0);
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.QQkFivSUKaHHakzyHZlXPqfOBJre.doublePressUp;
	}

	public bool tmlloKqIdCfFITAoOYARyaxEtyv(float P_0)
	{
		return tmlloKqIdCfFITAoOYARyaxEtyv(P_0, 0f);
	}

	public bool tmlloKqIdCfFITAoOYARyaxEtyv(float P_0, float P_1)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!KpRTXcEtyGlzHQYXMAstvlyskee())
		{
			return false;
		}
		double negativeVButtonTimePressed = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.negativeVButtonTimePressed;
		if (negativeVButtonTimePressed < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && negativeVButtonTimePressed >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool YtrbEJJmdYiNtYonULizSHGocQq(float P_0)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return bundOzXzxTCieXjHNxaVKIfqIqz();
		}
		if (!KpRTXcEtyGlzHQYXMAstvlyskee())
		{
			return false;
		}
		ButtonStateRecorder diEurUXkpvVGbRKJDRIqdEdNeHOc = cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc;
		if (diEurUXkpvVGbRKJDRIqdEdNeHOc.timePressed < (double)P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - diEurUXkpvVGbRKJDRIqdEdNeHOc.lastTimeUnpressed >= (double)P_0)
		{
			return false;
		}
		return true;
	}

	public bool LIllZNjOorYAJCuobbEpGHmtgLG(float P_0)
	{
		return LIllZNjOorYAJCuobbEpGHmtgLG(P_0, 0f);
	}

	public bool LIllZNjOorYAJCuobbEpGHmtgLG(float P_0, float P_1)
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!ZwUMSLHJcuYAbRcebDaGJalfcRoE())
		{
			return false;
		}
		double num = ReInput.unscaledTime - cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.diEurUXkpvVGbRKJDRIqdEdNeHOc.lastTimeStateChangedToPressed;
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool TrIFGfGydgzIrCnTzSmtpMPcFRs()
	{
		return tmlloKqIdCfFITAoOYARyaxEtyv(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressExpiresIn);
	}

	public bool wUSQKFPgCYLyOVIaLcaREOOgaSd()
	{
		return YtrbEJJmdYiNtYonULizSHGocQq(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressTime);
	}

	public bool rUpFbmIxUmCKBTXGxQRfuvWzAnM()
	{
		return LIllZNjOorYAJCuobbEpGHmtgLG(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonShortPressExpiresIn);
	}

	public bool ibyWTTbBqaiJKzbJQgrdCnhaOoU()
	{
		return tmlloKqIdCfFITAoOYARyaxEtyv(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressExpiresIn);
	}

	public bool tQKWTalcnUHuIXUuxfVFuCyQaJWa()
	{
		return YtrbEJJmdYiNtYonULizSHGocQq(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressTime);
	}

	public bool zTPDXluCTGkSgLXaycbrprdTzeO()
	{
		return LIllZNjOorYAJCuobbEpGHmtgLG(TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressTime, TuyABdnNXmGSpXEbASGgOwJcMGk.buttonLongPressExpiresIn);
	}

	public bool TTtEvsDAazCbegtEELzSwGKHTrig()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.KOGQGRYjlLIaxbuGjjrfEGNqmjas.state;
	}

	public bool VdfXOJuqKRFlPuSWWCQbwWJCAGE()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return false;
		}
		return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.YSumELMlgkaZAEMUtUovfsDdCrqW & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != 0;
	}

	public double vNaIOWRfUBghmmOJTErOPayDneE()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			return 0.0;
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.negativeVButtonTimePressed;
	}

	public double xLNJqBNrswsjyXJMOJMtKTJstvH()
	{
		if (!cnfZfltfCQiONpFEGCqZjXcevaVW)
		{
			tYNQvUqwQIGSLDywneeZuyWZgCa();
		}
		return cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.negativeVButtonTimeUnpressed;
	}

	private bool bundOzXzxTCieXjHNxaVKIfqIqz()
	{
		return (cKudGzHHquHGqGlsBvXxqMfrUSMT.bAihUPOaQoqOwOHZvtGkVuGzqqW.JqjHiTxSfvqzvuKfFnUxyoXyddE & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) != 0;
	}

	public void nCyfiGAwfaexhffjMRONQMggEidH()
	{
		for (int i = 0; i < cKudGzHHquHGqGlsBvXxqMfrUSMT.cXZAhDQESebRdBDchpsjrHPyUmL.Length; i++)
		{
			cKudGzHHquHGqGlsBvXxqMfrUSMT.cXZAhDQESebRdBDchpsjrHPyUmL[i].sEufHiAsKMgHbqEzYAhrEgipzVin.Clear();
			cKudGzHHquHGqGlsBvXxqMfrUSMT.cXZAhDQESebRdBDchpsjrHPyUmL[i].HNBaPpKbrfdzFLWFpYmLEDtBZHEn.Clear();
		}
	}

	internal InputActionEventData PDMLXCKMrRsoRqWbKVJENBgjKZm(UpdateLoopType P_0)
	{
		return new InputActionEventData(this, ivfdKpZALpQIAdtIdHmkpPFkwfq, sRbRrhSYcsdTbzpQQADExfvLSkq, P_0);
	}

	public IList<InputActionSourceData> GFxJnxIrzgBDMuFACVhmcASDNQU()
	{
		if (!ryvEevrPqxGcDJkNthvEeRFFyrXX)
		{
			huOLUGSphFoFRSzPdWolbKEpClJD();
		}
		return jqfJOqErfelbaeAuRxXivsreKfU;
	}

	public bool elKCPWdvGzeJVgZCBKgGjZxHWHSK(ControllerType P_0)
	{
		if (!ryvEevrPqxGcDJkNthvEeRFFyrXX)
		{
			GFxJnxIrzgBDMuFACVhmcASDNQU();
		}
		for (int i = 0; i < GJxygbMjSGaItAAdWxGSHmcbsBXc; i++)
		{
			if (xNAuLSChIGuEOCfpEQbbFrZrwBu[i].pxFOUEuAQwwDMNyKdQhVGxLNflI.type == P_0)
			{
				return true;
			}
		}
		return false;
	}

	public bool elKCPWdvGzeJVgZCBKgGjZxHWHSK(ControllerType P_0, int P_1)
	{
		if (!ryvEevrPqxGcDJkNthvEeRFFyrXX)
		{
			GFxJnxIrzgBDMuFACVhmcASDNQU();
		}
		for (int i = 0; i < GJxygbMjSGaItAAdWxGSHmcbsBXc; i++)
		{
			Controller pxFOUEuAQwwDMNyKdQhVGxLNflI = xNAuLSChIGuEOCfpEQbbFrZrwBu[i].pxFOUEuAQwwDMNyKdQhVGxLNflI;
			if (pxFOUEuAQwwDMNyKdQhVGxLNflI.type == P_0 && pxFOUEuAQwwDMNyKdQhVGxLNflI.id == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public bool elKCPWdvGzeJVgZCBKgGjZxHWHSK(Controller P_0)
	{
		if (!ryvEevrPqxGcDJkNthvEeRFFyrXX)
		{
			GFxJnxIrzgBDMuFACVhmcASDNQU();
		}
		for (int i = 0; i < GJxygbMjSGaItAAdWxGSHmcbsBXc; i++)
		{
			if (xNAuLSChIGuEOCfpEQbbFrZrwBu[i].pxFOUEuAQwwDMNyKdQhVGxLNflI == P_0)
			{
				return true;
			}
		}
		return false;
	}

	internal void QjNHfjHnCmaQyvCGKbwODraSxUWC()
	{
		cKudGzHHquHGqGlsBvXxqMfrUSMT.QjNHfjHnCmaQyvCGKbwODraSxUWC();
	}

	private void ZqEEdiUDeOevjfnmGvhwDsnsnQm()
	{
		if (iUcBNsgMTwBTyshyoIALRtOkREUD == ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm)
		{
			FaUCRxByEHlUiqKsikZVIKhDZje = true;
		}
		RiGXprroBUtILpwRLFsBXFflBhS = ZokPvEPpGPbZixpzdMyWwRVcNWx.DnMrxsuUiLvwcNNUGPbMBafPdnq;
		cnfZfltfCQiONpFEGCqZjXcevaVW = true;
	}

	private void CZmZbtMncLTjhIRiLRHSACUbiJg(bool P_0)
	{
		cKudGzHHquHGqGlsBvXxqMfrUSMT.CZmZbtMncLTjhIRiLRHSACUbiJg();
		if (GJxygbMjSGaItAAdWxGSHmcbsBXc > 0)
		{
			SHdZEDwRTKGPgjsdTFinzyiLqzl();
		}
		RiGXprroBUtILpwRLFsBXFflBhS = (P_0 ? ZokPvEPpGPbZixpzdMyWwRVcNWx.jasTeCPLFrfoLaDxyjJNoVklazd : ZokPvEPpGPbZixpzdMyWwRVcNWx.cUhrPrhdTFLhvqHJHOLHrPrInNm);
		cnfZfltfCQiONpFEGCqZjXcevaVW = false;
	}

	private void tYNQvUqwQIGSLDywneeZuyWZgCa()
	{
		cKudGzHHquHGqGlsBvXxqMfrUSMT.updateLoop = VxlgPAzxYBAGhdzzmKrRAokdIFJ;
	}

	private void SHdZEDwRTKGPgjsdTFinzyiLqzl()
	{
		GJxygbMjSGaItAAdWxGSHmcbsBXc = 0;
		if (ryvEevrPqxGcDJkNthvEeRFFyrXX)
		{
			WShfNuDgvhHNpipxdvHbuuheMFzk.Clear();
		}
	}

	private void XBosVFkvIHvKqTpSkEunItpXipO(Controller P_0, ControllerMap P_1, ActionElementMap P_2)
	{
		if (GJxygbMjSGaItAAdWxGSHmcbsBXc + 1 > xNAuLSChIGuEOCfpEQbbFrZrwBu.Length)
		{
			EoujFxYmdFvAPyTACujqTeeYSIn();
		}
		rxizQcqELWjNcpUqFcayhKmEbqQ rxizQcqELWjNcpUqFcayhKmEbqQ2 = xNAuLSChIGuEOCfpEQbbFrZrwBu[GJxygbMjSGaItAAdWxGSHmcbsBXc];
		rxizQcqELWjNcpUqFcayhKmEbqQ2.rkAjkyfvoRxILmntHviwzcLqjma = true;
		rxizQcqELWjNcpUqFcayhKmEbqQ2.pxFOUEuAQwwDMNyKdQhVGxLNflI = P_0;
		rxizQcqELWjNcpUqFcayhKmEbqQ2.XKsXMwpOxrVrFXsnXueqVpKoaEV = P_1;
		rxizQcqELWjNcpUqFcayhKmEbqQ2.laNInwdlemPELucvBOGimoeNQfc = P_2;
		GJxygbMjSGaItAAdWxGSHmcbsBXc++;
	}

	private void EoujFxYmdFvAPyTACujqTeeYSIn()
	{
		ArrayTools.Expand(ref xNAuLSChIGuEOCfpEQbbFrZrwBu, 4);
		int num = GJxygbMjSGaItAAdWxGSHmcbsBXc + 4;
		for (int i = GJxygbMjSGaItAAdWxGSHmcbsBXc; i < num; i++)
		{
			xNAuLSChIGuEOCfpEQbbFrZrwBu[i] = new rxizQcqELWjNcpUqFcayhKmEbqQ();
		}
	}

	private void huOLUGSphFoFRSzPdWolbKEpClJD()
	{
		if (!ryvEevrPqxGcDJkNthvEeRFFyrXX)
		{
			ryvEevrPqxGcDJkNthvEeRFFyrXX = true;
		}
		for (int i = 0; i < GJxygbMjSGaItAAdWxGSHmcbsBXc; i++)
		{
			WShfNuDgvhHNpipxdvHbuuheMFzk.Add(new InputActionSourceData(xNAuLSChIGuEOCfpEQbbFrZrwBu[i]));
		}
	}

	private static void YqThBgHlRhQJtSDaTcftkGasRti(ref ButtonStateFlags P_0, ButtonStateFlags P_1)
	{
		if (P_0 == ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			P_0 = P_1;
		}
		else if ((P_1 & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			if ((P_0 & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) == 0 || (P_0 & ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
			{
				P_0 = ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW | ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg;
			}
		}
		else if ((P_1 & ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW) != ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF)
		{
			P_0 = ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW;
		}
	}
}
