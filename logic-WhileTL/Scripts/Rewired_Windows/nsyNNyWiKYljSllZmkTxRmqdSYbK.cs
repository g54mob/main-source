using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

internal class nsyNNyWiKYljSllZmkTxRmqdSYbK : IUnifiedMouseSource, IDisposable, IGetSetEnabled
{
	private class OYObnYkDRGcFMjdMYCYeneDUQMoy
	{
		private enum fzJlJXQkJtyodCMBMxJcuNmrGPeM
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int UjhZEuNOdualZzAkehKRoEtWrLff = 120;

		private const int uSpyrRTFVwJSwamwwuAUFsRRoWil = 2048;

		public readonly UpdateLoopType MZtiQUxntlKvFThTntRndJsqMyNL;

		public uint owNjIDDTotLqZLOrXNQrBipNtQrn;

		public uint XGzaYxOgjODmABctcfOkcyHbQnNGc;

		public GYYHVgmyozmVQqZaHNZEiAgEHVAd zjrdDvLxQGOCYSIhSYKkGdcEPzEF;

		public float HMqOacmZPahaVGMKoLtIrGLGaiBbA;

		public float jZtHLoGOcKxeqtCGBTnilRCaJNPG;

		public float XtvIKRjDtAVmueTMKOZovlSGNpNq;

		public float cOoLdJjBwNGWBHpBJAnabaKxwpXRA;

		private bool[] FTbTQwooHvXtPPDLTqgdFfggFsWG;

		private bool[] mqfWGMrijEGMqURXhWvrkeqrbAUKA;

		private IOoRZZnqwYrUkZxUUzUwxniMfski xksUdpUzmpNMRqAbbduYXxnNcbBF;

		private uint RxTNcmWPuLncUIqKqhJfDoIDplAO;

		private int JrvhkSrOLaGfhOTKkDnWXPCUtiVU;

		private int JSEGgXgyRaVlTcHkuPKehaKCkeRhB;

		private bool zSCMRtIbSkxRowhlviCRGeouABPgb;

		public OYObnYkDRGcFMjdMYCYeneDUQMoy(IOoRZZnqwYrUkZxUUzUwxniMfski P_0, UpdateLoopType P_1)
		{
			xksUdpUzmpNMRqAbbduYXxnNcbBF = P_0;
			MZtiQUxntlKvFThTntRndJsqMyNL = P_1;
			FTbTQwooHvXtPPDLTqgdFfggFsWG = new bool[5];
			mqfWGMrijEGMqURXhWvrkeqrbAUKA = new bool[5];
		}

		public void drltkfbmyaNygyWycsTVVONmTpqV(aXmqsieDlbhOXGvbHDdlEFlUmtYq P_0)
		{
			NMlVwrDMFghSFNIbkSjcieKnasKKA nMlVwrDMFghSFNIbkSjcieKnasKKA = P_0.zELHodalQWKWjbaXYdmGeVUYHKCOA;
			if (nMlVwrDMFghSFNIbkSjcieKnasKKA != NMlVwrDMFghSFNIbkSjcieKnasKKA.None)
			{
				if ((nMlVwrDMFghSFNIbkSjcieKnasKKA & NMlVwrDMFghSFNIbkSjcieKnasKKA.LeftButtonDown) != NMlVwrDMFghSFNIbkSjcieKnasKKA.None || (nMlVwrDMFghSFNIbkSjcieKnasKKA & NMlVwrDMFghSFNIbkSjcieKnasKKA.RightButtonDown) != NMlVwrDMFghSFNIbkSjcieKnasKKA.None)
				{
					IntPtr intPtr = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.vXOctowsgMjuwZXcfPERVmiXpeTg();
					if (nxzMUSyCaMfSlEuvKxUcjBKIXFKl.gBBqUdSFcejTTQUMOBCKULCrNSfi() == intPtr && czDVYpcWPlfPGLpylGXEvILaClb(intPtr))
					{
						nMlVwrDMFghSFNIbkSjcieKnasKKA &= ~NMlVwrDMFghSFNIbkSjcieKnasKKA.LeftButtonDown;
						nMlVwrDMFghSFNIbkSjcieKnasKKA &= ~NMlVwrDMFghSFNIbkSjcieKnasKKA.RightButtonDown;
					}
				}
				int num = (int)nMlVwrDMFghSFNIbkSjcieKnasKKA;
				if (xksUdpUzmpNMRqAbbduYXxnNcbBF.jGufzHbsfIsxCdEfqHMBlrcWgGWjA && xksUdpUzmpNMRqAbbduYXxnNcbBF.SGCBpMEFzosNEWMfgMBwIvrciSos)
				{
					yQtZTbSGsxLDRlNDrXcvYphLjRuCA(1, num, 1, 2);
					yQtZTbSGsxLDRlNDrXcvYphLjRuCA(0, num, 4, 8);
				}
				else
				{
					yQtZTbSGsxLDRlNDrXcvYphLjRuCA(0, num, 1, 2);
					yQtZTbSGsxLDRlNDrXcvYphLjRuCA(1, num, 4, 8);
				}
				yQtZTbSGsxLDRlNDrXcvYphLjRuCA(2, num, 16, 32);
				yQtZTbSGsxLDRlNDrXcvYphLjRuCA(3, num, 64, 128);
				yQtZTbSGsxLDRlNDrXcvYphLjRuCA(4, num, 256, 512);
			}
			owNjIDDTotLqZLOrXNQrBipNtQrn = P_0.owNjIDDTotLqZLOrXNQrBipNtQrn;
			XGzaYxOgjODmABctcfOkcyHbQnNGc = P_0.XGzaYxOgjODmABctcfOkcyHbQnNGc;
			GYYHVgmyozmVQqZaHNZEiAgEHVAd gYYHVgmyozmVQqZaHNZEiAgEHVAd = zjrdDvLxQGOCYSIhSYKkGdcEPzEF;
			zjrdDvLxQGOCYSIhSYKkGdcEPzEF = P_0.zjrdDvLxQGOCYSIhSYKkGdcEPzEF;
			if (zjrdDvLxQGOCYSIhSYKkGdcEPzEF != gYYHVgmyozmVQqZaHNZEiAgEHVAd)
			{
				zSCMRtIbSkxRowhlviCRGeouABPgb = false;
			}
			if (zjrdDvLxQGOCYSIhSYKkGdcEPzEF == GYYHVgmyozmVQqZaHNZEiAgEHVAd.MoveRelative)
			{
				HMqOacmZPahaVGMKoLtIrGLGaiBbA += (float)P_0.HMqOacmZPahaVGMKoLtIrGLGaiBbA * 0.5f;
				jZtHLoGOcKxeqtCGBTnilRCaJNPG += (float)P_0.jZtHLoGOcKxeqtCGBTnilRCaJNPG * 0.5f * -1f;
			}
			else if ((zjrdDvLxQGOCYSIhSYKkGdcEPzEF & GYYHVgmyozmVQqZaHNZEiAgEHVAd.MoveAbsolute) != GYYHVgmyozmVQqZaHNZEiAgEHVAd.MoveRelative)
			{
				bool num2 = (zjrdDvLxQGOCYSIhSYKkGdcEPzEF & GYYHVgmyozmVQqZaHNZEiAgEHVAd.VirtualDesktop) != 0;
				int num3 = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.GRFyFNWTqfmVTzUYPOwfGYKyQfXu(num2 ? bNjyIBdgpdVpFZDGLcYCYJhSMleY.byhKuObzHUPQzkldceWdXWQKJHTn : bNjyIBdgpdVpFZDGLcYCYJhSMleY.nCRftHciNroNFvQubNpMagJpknedA);
				int num4 = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.GRFyFNWTqfmVTzUYPOwfGYKyQfXu(num2 ? bNjyIBdgpdVpFZDGLcYCYJhSMleY.xfcfnBGNqKbBVUiKzTxxQRxVOwXrA : bNjyIBdgpdVpFZDGLcYCYJhSMleY.VJgQZcoSMunztDdKtKHoroNCtIXJ);
				int num5 = (int)((float)P_0.HMqOacmZPahaVGMKoLtIrGLGaiBbA / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.jZtHLoGOcKxeqtCGBTnilRCaJNPG) / 65535f * (float)num4);
				if (!zSCMRtIbSkxRowhlviCRGeouABPgb)
				{
					JrvhkSrOLaGfhOTKkDnWXPCUtiVU = num5;
					JSEGgXgyRaVlTcHkuPKehaKCkeRhB = num6;
					zSCMRtIbSkxRowhlviCRGeouABPgb = true;
				}
				HMqOacmZPahaVGMKoLtIrGLGaiBbA += num5 - JrvhkSrOLaGfhOTKkDnWXPCUtiVU;
				jZtHLoGOcKxeqtCGBTnilRCaJNPG += num6 - JSEGgXgyRaVlTcHkuPKehaKCkeRhB;
				JrvhkSrOLaGfhOTKkDnWXPCUtiVU = num5;
				JSEGgXgyRaVlTcHkuPKehaKCkeRhB = num6;
			}
			else
			{
				HMqOacmZPahaVGMKoLtIrGLGaiBbA = P_0.HMqOacmZPahaVGMKoLtIrGLGaiBbA;
				jZtHLoGOcKxeqtCGBTnilRCaJNPG = P_0.jZtHLoGOcKxeqtCGBTnilRCaJNPG;
			}
			if (P_0.LOCAKjjPFkzcIjQCanhTmBYyKSQtA != 0)
			{
				int num7 = ((MathTools.Abs(P_0.LOCAKjjPFkzcIjQCanhTmBYyKSQtA) < 120) ? MathTools.Sign(P_0.LOCAKjjPFkzcIjQCanhTmBYyKSQtA) : (P_0.LOCAKjjPFkzcIjQCanhTmBYyKSQtA / 120));
				if ((nMlVwrDMFghSFNIbkSjcieKnasKKA & NMlVwrDMFghSFNIbkSjcieKnasKKA.MouseWheel) != NMlVwrDMFghSFNIbkSjcieKnasKKA.None)
				{
					XtvIKRjDtAVmueTMKOZovlSGNpNq += num7;
				}
				else if ((nMlVwrDMFghSFNIbkSjcieKnasKKA & (NMlVwrDMFghSFNIbkSjcieKnasKKA)2048) != NMlVwrDMFghSFNIbkSjcieKnasKKA.None)
				{
					cOoLdJjBwNGWBHpBJAnabaKxwpXRA += num7;
				}
			}
		}

		public void aaIQDywfqNeCltKvAbGcWTSCAlpkA(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = HMqOacmZPahaVGMKoLtIrGLGaiBbA;
			axisValues[1] = jZtHLoGOcKxeqtCGBTnilRCaJNPG;
			axisValues[2] = XtvIKRjDtAVmueTMKOZovlSGNpNq;
			axisValues[3] = cOoLdJjBwNGWBHpBJAnabaKxwpXRA;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = FTbTQwooHvXtPPDLTqgdFfggFsWG[i] || mqfWGMrijEGMqURXhWvrkeqrbAUKA[i];
			}
			LUTFKPKvVKfcDqyQjLnwrrNzhuTAb();
		}

		public void AAkveQLPaxEaDKEXsosCHmnfCXLT()
		{
			LUTFKPKvVKfcDqyQjLnwrrNzhuTAb();
		}

		private void LUTFKPKvVKfcDqyQjLnwrrNzhuTAb()
		{
			if (RxTNcmWPuLncUIqKqhJfDoIDplAO != ReInput.absFrame)
			{
				htOwBUKkzMNhRdwyILWfVLwYmEPK();
				RxTNcmWPuLncUIqKqhJfDoIDplAO = ReInput.absFrame;
			}
		}

		public void clOavfCHpNeTPfcwzgPdNbzmHFpz()
		{
			HMqOacmZPahaVGMKoLtIrGLGaiBbA = 0f;
			jZtHLoGOcKxeqtCGBTnilRCaJNPG = 0f;
			XGzaYxOgjODmABctcfOkcyHbQnNGc = 0u;
			zjrdDvLxQGOCYSIhSYKkGdcEPzEF = GYYHVgmyozmVQqZaHNZEiAgEHVAd.MoveRelative;
			XtvIKRjDtAVmueTMKOZovlSGNpNq = 0f;
			cOoLdJjBwNGWBHpBJAnabaKxwpXRA = 0f;
			Array.Clear(FTbTQwooHvXtPPDLTqgdFfggFsWG, 0, 5);
			Array.Clear(mqfWGMrijEGMqURXhWvrkeqrbAUKA, 0, 5);
			zSCMRtIbSkxRowhlviCRGeouABPgb = false;
		}

		public void htOwBUKkzMNhRdwyILWfVLwYmEPK()
		{
			HMqOacmZPahaVGMKoLtIrGLGaiBbA = 0f;
			jZtHLoGOcKxeqtCGBTnilRCaJNPG = 0f;
			XtvIKRjDtAVmueTMKOZovlSGNpNq = 0f;
			cOoLdJjBwNGWBHpBJAnabaKxwpXRA = 0f;
			Array.Clear(mqfWGMrijEGMqURXhWvrkeqrbAUKA, 0, 5);
		}

		private bool KXJdWAAUxLBpMBYcIbLVuKxtomne(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1 && (P_0 & P_2) != P_2)
			{
				return true;
			}
			return false;
		}

		private fzJlJXQkJtyodCMBMxJcuNmrGPeM BrvCTAmdWMaJculGiHonjdSAaVEcA(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return fzJlJXQkJtyodCMBMxJcuNmrGPeM.None;
				}
				return fzJlJXQkJtyodCMBMxJcuNmrGPeM.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return fzJlJXQkJtyodCMBMxJcuNmrGPeM.Up;
			}
			return fzJlJXQkJtyodCMBMxJcuNmrGPeM.None;
		}

		private void yQtZTbSGsxLDRlNDrXcvYphLjRuCA(int P_0, int P_1, int P_2, int P_3)
		{
			fzJlJXQkJtyodCMBMxJcuNmrGPeM fzJlJXQkJtyodCMBMxJcuNmrGPeM2 = BrvCTAmdWMaJculGiHonjdSAaVEcA(P_1, P_2, P_3);
			if (FTbTQwooHvXtPPDLTqgdFfggFsWG[P_0])
			{
				if (fzJlJXQkJtyodCMBMxJcuNmrGPeM2 == fzJlJXQkJtyodCMBMxJcuNmrGPeM.Up)
				{
					FTbTQwooHvXtPPDLTqgdFfggFsWG[P_0] = false;
				}
			}
			else if (fzJlJXQkJtyodCMBMxJcuNmrGPeM2 == fzJlJXQkJtyodCMBMxJcuNmrGPeM.Down)
			{
				FTbTQwooHvXtPPDLTqgdFfggFsWG[P_0] = true;
			}
			if (fzJlJXQkJtyodCMBMxJcuNmrGPeM2 == fzJlJXQkJtyodCMBMxJcuNmrGPeM.Down)
			{
				mqfWGMrijEGMqURXhWvrkeqrbAUKA[P_0] = true;
			}
		}

		private static bool czDVYpcWPlfPGLpylGXEvILaClb(IntPtr P_0)
		{
			if (nxzMUSyCaMfSlEuvKxUcjBKIXFKl.cxSAjYFEaPqWqYyuOapQijanTzKGb(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!nxzMUSyCaMfSlEuvKxUcjBKIXFKl.liCiISzfiFcvpnerVwWtpHGgJVJS(P_0, out var zCyrceaIGGUJPbqldbcnePGyMRtXA))
			{
				return false;
			}
			if (!nxzMUSyCaMfSlEuvKxUcjBKIXFKl.zWIgrmwkMRKwUIQlToXEIphSPJoh(out var zCyrceaIGGUJPbqldbcnePGyMRtXA2))
			{
				return false;
			}
			if (!nxzMUSyCaMfSlEuvKxUcjBKIXFKl.MQCdQcUgQAAUiAwLYBaTgdPASASKA(P_0, out var abrFAEsQiEEsHPrDgEzxnmXHfwQP2))
			{
				return false;
			}
			int num = zCyrceaIGGUJPbqldbcnePGyMRtXA2.HMqOacmZPahaVGMKoLtIrGLGaiBbA - zCyrceaIGGUJPbqldbcnePGyMRtXA.HMqOacmZPahaVGMKoLtIrGLGaiBbA;
			int num2 = zCyrceaIGGUJPbqldbcnePGyMRtXA2.jZtHLoGOcKxeqtCGBTnilRCaJNPG - zCyrceaIGGUJPbqldbcnePGyMRtXA.jZtHLoGOcKxeqtCGBTnilRCaJNPG;
			if (num >= 0 && num2 >= 0 && num <= abrFAEsQiEEsHPrDgEzxnmXHfwQP2.ZJzLsbmIjgJmIMEljxRaUxWurXCl && num2 <= abrFAEsQiEEsHPrDgEzxnmXHfwQP2.TCIfVVFKtUeIpPCakPiMUFaaQOTW)
			{
				return false;
			}
			if (!nxzMUSyCaMfSlEuvKxUcjBKIXFKl.eVyFQZbFvqXTPdxQdghxqvTRFVDu(P_0, out var abrFAEsQiEEsHPrDgEzxnmXHfwQP3))
			{
				return false;
			}
			if (zCyrceaIGGUJPbqldbcnePGyMRtXA2.HMqOacmZPahaVGMKoLtIrGLGaiBbA >= abrFAEsQiEEsHPrDgEzxnmXHfwQP3.CkqpKqbxlNJwhWtKqsKXnoaQgGDx && zCyrceaIGGUJPbqldbcnePGyMRtXA2.HMqOacmZPahaVGMKoLtIrGLGaiBbA <= abrFAEsQiEEsHPrDgEzxnmXHfwQP3.ZJzLsbmIjgJmIMEljxRaUxWurXCl && zCyrceaIGGUJPbqldbcnePGyMRtXA2.jZtHLoGOcKxeqtCGBTnilRCaJNPG >= abrFAEsQiEEsHPrDgEzxnmXHfwQP3.OPfjKgowsThRQXfarbsmbEkrFrCc)
			{
				return zCyrceaIGGUJPbqldbcnePGyMRtXA2.jZtHLoGOcKxeqtCGBTnilRCaJNPG <= abrFAEsQiEEsHPrDgEzxnmXHfwQP3.TCIfVVFKtUeIpPCakPiMUFaaQOTW;
			}
			return false;
		}
	}

	private class IOoRZZnqwYrUkZxUUzUwxniMfski
	{
		private bool vzuaBvpIbhXloHFBfRifuhXzDGqV;

		private bool KjcdqmsUohPObPCoihKMItwvsvzD;

		private bool BGIoFltfEoAvPbRUBLXhdyIbDJxQA;

		private int vBCRyQxhBWfXCeaULGHTqbOlhtUt = 10;

		private readonly float gTbEHEqKpNnwVUGuoBulpMbxilmI;

		private double ngbmNpuAqIUIKSFLRuYDNSRydlXy;

		public bool jGufzHbsfIsxCdEfqHMBlrcWgGWjA
		{
			get
			{
				return vzuaBvpIbhXloHFBfRifuhXzDGqV;
			}
			set
			{
				if (flag != vzuaBvpIbhXloHFBfRifuhXzDGqV)
				{
					hUJByROQriJskYNmuUJNLMTSBGYp(true);
				}
			}
		}

		public bool SGCBpMEFzosNEWMfgMBwIvrciSos => KjcdqmsUohPObPCoihKMItwvsvzD;

		public bool jgKXwcWkVEKxlbyyKMxBYGJxZWag
		{
			get
			{
				return BGIoFltfEoAvPbRUBLXhdyIbDJxQA;
			}
			set
			{
				if (BGIoFltfEoAvPbRUBLXhdyIbDJxQA != flag)
				{
					BGIoFltfEoAvPbRUBLXhdyIbDJxQA = flag;
					hUJByROQriJskYNmuUJNLMTSBGYp(true);
				}
			}
		}

		public int LHXfWNlsLjNOzXlLaFjMriObeeNG => vBCRyQxhBWfXCeaULGHTqbOlhtUt;

		public IOoRZZnqwYrUkZxUUzUwxniMfski(bool P_0, float P_1)
		{
			vzuaBvpIbhXloHFBfRifuhXzDGqV = P_0;
			gTbEHEqKpNnwVUGuoBulpMbxilmI = P_1;
			hUJByROQriJskYNmuUJNLMTSBGYp(false);
		}

		public void cmTGFsRmXJEFbLoGhVUXbOoqUnNg()
		{
			if (vzuaBvpIbhXloHFBfRifuhXzDGqV && !(ReInput.realTime < ngbmNpuAqIUIKSFLRuYDNSRydlXy))
			{
				hUJByROQriJskYNmuUJNLMTSBGYp(true);
			}
		}

		private void hUJByROQriJskYNmuUJNLMTSBGYp(bool P_0)
		{
			if (BGIoFltfEoAvPbRUBLXhdyIbDJxQA)
			{
				nxzMUSyCaMfSlEuvKxUcjBKIXFKl.RbwqeUbJjoaNtUgWuslWVLfdHuMdA(112u, 0u, ref vBCRyQxhBWfXCeaULGHTqbOlhtUt, 0u);
			}
			KjcdqmsUohPObPCoihKMItwvsvzD = nxzMUSyCaMfSlEuvKxUcjBKIXFKl.GRFyFNWTqfmVTzUYPOwfGYKyQfXu(bNjyIBdgpdVpFZDGLcYCYJhSMleY.wngKPGdgedGgpkBmElZbhUBxGNYK) > 0;
			if (P_0)
			{
				ngbmNpuAqIUIKSFLRuYDNSRydlXy = ReInput.realTime + (double)gTbEHEqKpNnwVUGuoBulpMbxilmI;
			}
		}
	}

	private const int AttfPYDUWICIDEdJBeqVvEfxtMdFA = 5;

	private const int YBmrOHWerrNjrpnPtBsyBgTkNAtu = 4;

	private readonly object cCndHwpyhmiyUcAhGQdqlqtbgioX = new object();

	private UpdateLoopDataSet<OYObnYkDRGcFMjdMYCYeneDUQMoy> MYVDgrMcWoexelkNDeTMJZIXLWhg;

	private HardwareControllerMap_Game SFGGRoEaDYcZKZuBaaxqNeYpRRqJ;

	private IOoRZZnqwYrUkZxUUzUwxniMfski xksUdpUzmpNMRqAbbduYXxnNcbBF;

	private bool hPlTVNQiLdbzFFHrHysLbZOBZvgEA;

	private int BTzcXsciwMXnqLYRSNwNPAHbNJxDb;

	private bool vzuaBvpIbhXloHFBfRifuhXzDGqV;

	private const bool KStxzfaJsPHMUpyZldZJLzSydSCp = true;

	private const float yPlVcauKXMfIOhFrKdOCLWgUturm = 2f;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public bool enabled
	{
		get
		{
			return vzuaBvpIbhXloHFBfRifuhXzDGqV;
		}
		set
		{
			if (vzuaBvpIbhXloHFBfRifuhXzDGqV != value)
			{
				vzuaBvpIbhXloHFBfRifuhXzDGqV = value;
				Clear();
				ThreadSafeUnityInput.mouse.Monitor(value);
			}
		}
	}

	public InputSource inputSource => InputSource.RawInput;

	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (SFGGRoEaDYcZKZuBaaxqNeYpRRqJ == null)
			{
				SFGGRoEaDYcZKZuBaaxqNeYpRRqJ = EAfjryUkPjwpqmQDbBmpnGrwOKAO();
			}
			return SFGGRoEaDYcZKZuBaaxqNeYpRRqJ;
		}
	}

	public int buttonCount => 5;

	public int axisCount => 4;

	public Vector2 mousePosition
	{
		get
		{
			if (!vzuaBvpIbhXloHFBfRifuhXzDGqV)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	public Controller.Extension controllerExtension => null;

	public nsyNNyWiKYljSllZmkTxRmqdSYbK(UpdateLoopSetting P_0)
	{
		kAVjNVFEKJcjMayGOvWAlUUhATRyA();
		xksUdpUzmpNMRqAbbduYXxnNcbBF = new IOoRZZnqwYrUkZxUUzUwxniMfski(true, 2f);
		MYVDgrMcWoexelkNDeTMJZIXLWhg = new UpdateLoopDataSet<OYObnYkDRGcFMjdMYCYeneDUQMoy>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				MYVDgrMcWoexelkNDeTMJZIXLWhg[i] = new OYObnYkDRGcFMjdMYCYeneDUQMoy(xksUdpUzmpNMRqAbbduYXxnNcbBF, list[i]);
			}
		}
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += izsxjNyxyktvAnVpBwNVRAUOxkcJ;
		enabled = true;
		ReInput.EditorPauseChangedEvent += jbYPDtSqdSxaDyKMNhAMwaVDmIlo;
		ReInput.TimeScalePauseChangedEvent += ZjMAJpWMjCgjaRLAzzaKAIUkbKtL;
		ReInput.UpdateEndedEvent += YJobGkINyGJLLBjbOaWTfJLMSwUN;
	}

	public void cmTGFsRmXJEFbLoGhVUXbOoqUnNg(UpdateLoopType P_0)
	{
		MYVDgrMcWoexelkNDeTMJZIXLWhg.SetUpdateLoop(P_0);
		xksUdpUzmpNMRqAbbduYXxnNcbBF.cmTGFsRmXJEFbLoGhVUXbOoqUnNg();
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void UNjTkGmulXtcDtUguRlvtYWMwrxg(aXmqsieDlbhOXGvbHDdlEFlUmtYq P_0)
	{
		if (!hPlTVNQiLdbzFFHrHysLbZOBZvgEA)
		{
			return;
		}
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			int count = MYVDgrMcWoexelkNDeTMJZIXLWhg.Count;
			for (int i = 0; i < count; i++)
			{
				MYVDgrMcWoexelkNDeTMJZIXLWhg[i].drltkfbmyaNygyWycsTVVONmTpqV(P_0);
			}
		}
	}

	public void LfoQuDdqyouAgYcQelFthkWoncwV(bool P_0)
	{
		RJEhbCPSaRQkCBnuyapsfmnmTXeU();
	}

	public void oKZjJsUfdokwGiyKjHVaqyvEQkZs(bool P_0)
	{
		if (kAVjNVFEKJcjMayGOvWAlUUhATRyA() < 0)
		{
			RJEhbCPSaRQkCBnuyapsfmnmTXeU();
		}
	}

	private int kAVjNVFEKJcjMayGOvWAlUUhATRyA()
	{
		int bTzcXsciwMXnqLYRSNwNPAHbNJxDb = BTzcXsciwMXnqLYRSNwNPAHbNJxDb;
		if (tVBWyZGsKPKvJuuMOPZiWmVEjMGK.EJKTrsPAGYfqDQnsfqkzzEnCYGmG(pkUmomIELOfJWzdNflUWcAcSmqxS.Mouse, out var bTzcXsciwMXnqLYRSNwNPAHbNJxDb2))
		{
			BTzcXsciwMXnqLYRSNwNPAHbNJxDb = bTzcXsciwMXnqLYRSNwNPAHbNJxDb2;
		}
		else
		{
			BTzcXsciwMXnqLYRSNwNPAHbNJxDb = ((nxzMUSyCaMfSlEuvKxUcjBKIXFKl.GRFyFNWTqfmVTzUYPOwfGYKyQfXu(bNjyIBdgpdVpFZDGLcYCYJhSMleY.CHwqVzTHEpikwHfbEAkiRshNPzktA) != 0) ? 1 : 0);
		}
		return BTzcXsciwMXnqLYRSNwNPAHbNJxDb - bTzcXsciwMXnqLYRSNwNPAHbNJxDb;
	}

	private void izsxjNyxyktvAnVpBwNVRAUOxkcJ(bool P_0)
	{
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !hPlTVNQiLdbzFFHrHysLbZOBZvgEA)
		{
			RJEhbCPSaRQkCBnuyapsfmnmTXeU();
		}
	}

	private void jbYPDtSqdSxaDyKMNhAMwaVDmIlo(bool P_0)
	{
	}

	private void ZjMAJpWMjCgjaRLAzzaKAIUkbKtL(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		hPlTVNQiLdbzFFHrHysLbZOBZvgEA = ReInput.IsInputAllowed(ControllerType.Mouse);
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			MYVDgrMcWoexelkNDeTMJZIXLWhg[MYVDgrMcWoexelkNDeTMJZIXLWhg.fixedUpdateSetIndex].htOwBUKkzMNhRdwyILWfVLwYmEPK();
		}
	}

	private void YJobGkINyGJLLBjbOaWTfJLMSwUN(UpdateLoopType P_0)
	{
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			MYVDgrMcWoexelkNDeTMJZIXLWhg.Get(P_0).AAkveQLPaxEaDKEXsosCHmnfCXLT();
		}
	}

	private void RJEhbCPSaRQkCBnuyapsfmnmTXeU()
	{
		lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
		{
			int count = MYVDgrMcWoexelkNDeTMJZIXLWhg.Count;
			for (int i = 0; i < count; i++)
			{
				MYVDgrMcWoexelkNDeTMJZIXLWhg[i].clOavfCHpNeTPfcwzgPdNbzmHFpz();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		MYVDgrMcWoexelkNDeTMJZIXLWhg.Current.aaIQDywfqNeCltKvAbGcWTSCAlpkA(dataUpdater);
	}

	public void Clear()
	{
		RJEhbCPSaRQkCBnuyapsfmnmTXeU();
	}

	private HardwareControllerMap_Game EAfjryUkPjwpqmQDbBmpnGrwOKAO()
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
			array4[k] = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float num3 = (((uint)k > 1u) ? 2f : 100f);
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			ReInput.ApplicationFocusChangedEvent -= izsxjNyxyktvAnVpBwNVRAUOxkcJ;
			ReInput.EditorPauseChangedEvent -= jbYPDtSqdSxaDyKMNhAMwaVDmIlo;
			ReInput.TimeScalePauseChangedEvent -= ZjMAJpWMjCgjaRLAzzaKAIUkbKtL;
			ReInput.UpdateEndedEvent -= YJobGkINyGJLLBjbOaWTfJLMSwUN;
			if (P_0 && vzuaBvpIbhXloHFBfRifuhXzDGqV)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}
}
