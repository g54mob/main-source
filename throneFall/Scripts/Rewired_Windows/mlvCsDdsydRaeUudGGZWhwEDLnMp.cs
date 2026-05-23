using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class mlvCsDdsydRaeUudGGZWhwEDLnMp : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class vMPOZAcpjDUdfaEAQbzzJPYBzuZf
	{
		private enum wBhHDWILyblgddMxDyZxZhYsQmKfb
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int sRJSaeWFnaNOfeuzngrAsIuaWJAE = 120;

		private const int MUuEJmFCzqlOyqzWRPIKSSFPjTljA = 2048;

		public readonly UpdateLoopType EfAXeuKLGGaALOCDpLIGCnmVBWvC;

		public uint wgmbUGvdxOawhZVuOpECpnUdmlnP;

		public uint yTEMXHgBioGbqbijMKxdhdDAiOicB;

		public WndvDMUozRFBkYdIEKmAwxdWjylA qdnZgVWuHLOUItQHCDOLGiJOQKEi;

		public float fazbTQPTwEAEWiQTDCWkgHxlXcamA;

		public float YyhsJhWNuhPbEsYecPiLzbFAJCqS;

		public float WiSdEuCECrIXTsgHiZduYEIfgxIj;

		public float aTBDPyGThRaVeNopLavbjxWmpOGB;

		private bool[] gaAGaBxhQBcyxhGVsdceOGzXZXimA;

		private bool[] ALMXEfhrEkLCzLivUqpPejBgFCWH;

		private kQouUtRvZOrPLfSudMPAYPxOLhKL SaJnMUntmjkWVtMKrkNzvfcXOFVQ;

		private uint qsLCcpFrIQTtjxrHvRXhgpdkmigQ;

		private int BZbaJYVYjtVyunLOdptPvVgtSEYx;

		private int ywkCLGNcqqxTkgAupNfytNwWVnTB;

		private bool wYhBxOngZPKGqpBuLAsLHpJRormKA;

		public vMPOZAcpjDUdfaEAQbzzJPYBzuZf(kQouUtRvZOrPLfSudMPAYPxOLhKL P_0, UpdateLoopType P_1)
		{
			SaJnMUntmjkWVtMKrkNzvfcXOFVQ = P_0;
			EfAXeuKLGGaALOCDpLIGCnmVBWvC = P_1;
			gaAGaBxhQBcyxhGVsdceOGzXZXimA = new bool[5];
			ALMXEfhrEkLCzLivUqpPejBgFCWH = new bool[5];
		}

		public void IUVMEXDIILGmuIAiSDtHWAOgxBYf(KAhCTYewFHkouYHATztMvRchwmIs P_0)
		{
			VEGiQUbxRiUfELvNrLaKtslAUIcUA vEGiQUbxRiUfELvNrLaKtslAUIcUA = P_0.zFzUEzUNqwEoRaBNlbmfnrVsPyBCb;
			if (vEGiQUbxRiUfELvNrLaKtslAUIcUA != VEGiQUbxRiUfELvNrLaKtslAUIcUA.None)
			{
				if ((vEGiQUbxRiUfELvNrLaKtslAUIcUA & VEGiQUbxRiUfELvNrLaKtslAUIcUA.LeftButtonDown) != VEGiQUbxRiUfELvNrLaKtslAUIcUA.None || (vEGiQUbxRiUfELvNrLaKtslAUIcUA & VEGiQUbxRiUfELvNrLaKtslAUIcUA.RightButtonDown) != VEGiQUbxRiUfELvNrLaKtslAUIcUA.None)
				{
					IntPtr intPtr = FanHTnvZmXVTOfDHuteqdkMyhpJj.ijitjiayhvhWQoKCwerAUgHUVate();
					if (FanHTnvZmXVTOfDHuteqdkMyhpJj.VIXkMfLylzleLBdreNdjhcEErdNB() == intPtr && heVovIQPyaZjLEHMIHKqzDPetUJP(intPtr))
					{
						vEGiQUbxRiUfELvNrLaKtslAUIcUA &= ~VEGiQUbxRiUfELvNrLaKtslAUIcUA.LeftButtonDown;
						vEGiQUbxRiUfELvNrLaKtslAUIcUA &= ~VEGiQUbxRiUfELvNrLaKtslAUIcUA.RightButtonDown;
					}
				}
				int num = (int)vEGiQUbxRiUfELvNrLaKtslAUIcUA;
				if (SaJnMUntmjkWVtMKrkNzvfcXOFVQ.vnFzrCiCadLHCqqjioGTyArYprhR && SaJnMUntmjkWVtMKrkNzvfcXOFVQ.aXaQzauDmYhbadAzHNGIlONsWURr)
				{
					nQSBzJEHDGZWgICfTWLcckZbUZec(1, num, 1, 2);
					nQSBzJEHDGZWgICfTWLcckZbUZec(0, num, 4, 8);
				}
				else
				{
					nQSBzJEHDGZWgICfTWLcckZbUZec(0, num, 1, 2);
					nQSBzJEHDGZWgICfTWLcckZbUZec(1, num, 4, 8);
				}
				nQSBzJEHDGZWgICfTWLcckZbUZec(2, num, 16, 32);
				nQSBzJEHDGZWgICfTWLcckZbUZec(3, num, 64, 128);
				nQSBzJEHDGZWgICfTWLcckZbUZec(4, num, 256, 512);
			}
			wgmbUGvdxOawhZVuOpECpnUdmlnP = P_0.uECiLRjxBUwlTkpCJtsHTiUfgSNnA;
			yTEMXHgBioGbqbijMKxdhdDAiOicB = P_0.OYPxcACbxDAQsNKlXJpftNyQYLWB;
			WndvDMUozRFBkYdIEKmAwxdWjylA wndvDMUozRFBkYdIEKmAwxdWjylA = qdnZgVWuHLOUItQHCDOLGiJOQKEi;
			qdnZgVWuHLOUItQHCDOLGiJOQKEi = P_0.PIpjKoHJcdGMFBqiOsGnBHGtobjKA;
			if (qdnZgVWuHLOUItQHCDOLGiJOQKEi != wndvDMUozRFBkYdIEKmAwxdWjylA)
			{
				wYhBxOngZPKGqpBuLAsLHpJRormKA = false;
			}
			if (qdnZgVWuHLOUItQHCDOLGiJOQKEi == WndvDMUozRFBkYdIEKmAwxdWjylA.MoveRelative)
			{
				fazbTQPTwEAEWiQTDCWkgHxlXcamA += (float)P_0.LVKRUaTDJYtdnFugzuoRZLcdEkni * 0.5f;
				YyhsJhWNuhPbEsYecPiLzbFAJCqS += (float)P_0.ipGvKHJoRXbltdrGMOCNIuFgETxVA * 0.5f * -1f;
			}
			else if ((qdnZgVWuHLOUItQHCDOLGiJOQKEi & WndvDMUozRFBkYdIEKmAwxdWjylA.MoveAbsolute) != WndvDMUozRFBkYdIEKmAwxdWjylA.MoveRelative)
			{
				bool num2 = (qdnZgVWuHLOUItQHCDOLGiJOQKEi & WndvDMUozRFBkYdIEKmAwxdWjylA.VirtualDesktop) != 0;
				int num3 = FanHTnvZmXVTOfDHuteqdkMyhpJj.nucCadqwdmJJQehfaaoEWqEEitQl(num2 ? nLFjDWhFFneDsZFBEEAqYlPBIetI.mpYxgONjVZCjhKMbkaIjwgTcPPIc : nLFjDWhFFneDsZFBEEAqYlPBIetI.cxSMlcXpCGgOxAfCheGeNJJlCzDZA);
				int num4 = FanHTnvZmXVTOfDHuteqdkMyhpJj.nucCadqwdmJJQehfaaoEWqEEitQl(num2 ? nLFjDWhFFneDsZFBEEAqYlPBIetI.vgvVBUYdtVnuWpLbuywOFUaUjejW : nLFjDWhFFneDsZFBEEAqYlPBIetI.oquiHiIjxfSUrHMDGOFdywTWeWTl);
				int num5 = (int)((float)P_0.LVKRUaTDJYtdnFugzuoRZLcdEkni / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.ipGvKHJoRXbltdrGMOCNIuFgETxVA) / 65535f * (float)num4);
				if (!wYhBxOngZPKGqpBuLAsLHpJRormKA)
				{
					BZbaJYVYjtVyunLOdptPvVgtSEYx = num5;
					ywkCLGNcqqxTkgAupNfytNwWVnTB = num6;
					wYhBxOngZPKGqpBuLAsLHpJRormKA = true;
				}
				fazbTQPTwEAEWiQTDCWkgHxlXcamA += num5 - BZbaJYVYjtVyunLOdptPvVgtSEYx;
				YyhsJhWNuhPbEsYecPiLzbFAJCqS += num6 - ywkCLGNcqqxTkgAupNfytNwWVnTB;
				BZbaJYVYjtVyunLOdptPvVgtSEYx = num5;
				ywkCLGNcqqxTkgAupNfytNwWVnTB = num6;
			}
			else
			{
				fazbTQPTwEAEWiQTDCWkgHxlXcamA = P_0.LVKRUaTDJYtdnFugzuoRZLcdEkni;
				YyhsJhWNuhPbEsYecPiLzbFAJCqS = P_0.ipGvKHJoRXbltdrGMOCNIuFgETxVA;
			}
			if (P_0.oOAvwdRSRjFxKvkVQsNMduRKxcFL != 0)
			{
				int num7 = ((MathTools.Abs(P_0.oOAvwdRSRjFxKvkVQsNMduRKxcFL) < 120) ? MathTools.Sign(P_0.oOAvwdRSRjFxKvkVQsNMduRKxcFL) : (P_0.oOAvwdRSRjFxKvkVQsNMduRKxcFL / 120));
				if ((vEGiQUbxRiUfELvNrLaKtslAUIcUA & VEGiQUbxRiUfELvNrLaKtslAUIcUA.MouseWheel) != VEGiQUbxRiUfELvNrLaKtslAUIcUA.None)
				{
					WiSdEuCECrIXTsgHiZduYEIfgxIj += num7;
				}
				else if ((vEGiQUbxRiUfELvNrLaKtslAUIcUA & (VEGiQUbxRiUfELvNrLaKtslAUIcUA)2048) != VEGiQUbxRiUfELvNrLaKtslAUIcUA.None)
				{
					aTBDPyGThRaVeNopLavbjxWmpOGB += num7;
				}
			}
		}

		public void TyUBerxGLDjrlZtkyFiNFbpqrpeaA(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = fazbTQPTwEAEWiQTDCWkgHxlXcamA;
			axisValues[1] = YyhsJhWNuhPbEsYecPiLzbFAJCqS;
			axisValues[2] = WiSdEuCECrIXTsgHiZduYEIfgxIj;
			axisValues[3] = aTBDPyGThRaVeNopLavbjxWmpOGB;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = gaAGaBxhQBcyxhGVsdceOGzXZXimA[i] || ALMXEfhrEkLCzLivUqpPejBgFCWH[i];
			}
			RYpBscatEMPFrHFfitHvCkXBfHsh();
		}

		public void dcnsTcVnRGdvcOAxATERASpmbPCI()
		{
			RYpBscatEMPFrHFfitHvCkXBfHsh();
		}

		private void RYpBscatEMPFrHFfitHvCkXBfHsh()
		{
			if (qsLCcpFrIQTtjxrHvRXhgpdkmigQ != ReInput.absFrame)
			{
				ZpYNdEnwDtPTaofksvtoEVmgTzzK();
				qsLCcpFrIQTtjxrHvRXhgpdkmigQ = ReInput.absFrame;
			}
		}

		public void OIDLhTIKgTsRjNMbWAAMKnPrnspm()
		{
			fazbTQPTwEAEWiQTDCWkgHxlXcamA = 0f;
			YyhsJhWNuhPbEsYecPiLzbFAJCqS = 0f;
			yTEMXHgBioGbqbijMKxdhdDAiOicB = 0u;
			qdnZgVWuHLOUItQHCDOLGiJOQKEi = WndvDMUozRFBkYdIEKmAwxdWjylA.MoveRelative;
			WiSdEuCECrIXTsgHiZduYEIfgxIj = 0f;
			aTBDPyGThRaVeNopLavbjxWmpOGB = 0f;
			Array.Clear(gaAGaBxhQBcyxhGVsdceOGzXZXimA, 0, 5);
			Array.Clear(ALMXEfhrEkLCzLivUqpPejBgFCWH, 0, 5);
			wYhBxOngZPKGqpBuLAsLHpJRormKA = false;
		}

		public void ZpYNdEnwDtPTaofksvtoEVmgTzzK()
		{
			fazbTQPTwEAEWiQTDCWkgHxlXcamA = 0f;
			YyhsJhWNuhPbEsYecPiLzbFAJCqS = 0f;
			WiSdEuCECrIXTsgHiZduYEIfgxIj = 0f;
			aTBDPyGThRaVeNopLavbjxWmpOGB = 0f;
			Array.Clear(ALMXEfhrEkLCzLivUqpPejBgFCWH, 0, 5);
		}

		private void nQSBzJEHDGZWgICfTWLcckZbUZec(int P_0, int P_1, int P_2, int P_3)
		{
			wBhHDWILyblgddMxDyZxZhYsQmKfb wBhHDWILyblgddMxDyZxZhYsQmKfb2 = lYXeHREvHRbltBxOgAcLSwCkVqfzb(P_1, P_2, P_3);
			if (gaAGaBxhQBcyxhGVsdceOGzXZXimA[P_0])
			{
				if (wBhHDWILyblgddMxDyZxZhYsQmKfb2 == wBhHDWILyblgddMxDyZxZhYsQmKfb.Up || wBhHDWILyblgddMxDyZxZhYsQmKfb2 == wBhHDWILyblgddMxDyZxZhYsQmKfb.DownAndUp)
				{
					gaAGaBxhQBcyxhGVsdceOGzXZXimA[P_0] = false;
				}
			}
			else if (wBhHDWILyblgddMxDyZxZhYsQmKfb2 == wBhHDWILyblgddMxDyZxZhYsQmKfb.Down)
			{
				gaAGaBxhQBcyxhGVsdceOGzXZXimA[P_0] = true;
			}
			if (wBhHDWILyblgddMxDyZxZhYsQmKfb2 == wBhHDWILyblgddMxDyZxZhYsQmKfb.Down || wBhHDWILyblgddMxDyZxZhYsQmKfb2 == wBhHDWILyblgddMxDyZxZhYsQmKfb.DownAndUp)
			{
				ALMXEfhrEkLCzLivUqpPejBgFCWH[P_0] = true;
			}
		}

		private static wBhHDWILyblgddMxDyZxZhYsQmKfb lYXeHREvHRbltBxOgAcLSwCkVqfzb(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return wBhHDWILyblgddMxDyZxZhYsQmKfb.DownAndUp;
				}
				return wBhHDWILyblgddMxDyZxZhYsQmKfb.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return wBhHDWILyblgddMxDyZxZhYsQmKfb.Up;
			}
			return wBhHDWILyblgddMxDyZxZhYsQmKfb.None;
		}

		private static bool heVovIQPyaZjLEHMIHKqzDPetUJP(IntPtr P_0)
		{
			if (FanHTnvZmXVTOfDHuteqdkMyhpJj.FvbxZfLMEGQxWhHXMBkuqIyqztzu(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!FanHTnvZmXVTOfDHuteqdkMyhpJj.wOtoVHddetBxKwoJFqJzwvcBoKQp(P_0, out var rnRtokWNhetVhPChWiBQGmtLQvuqA2))
			{
				return false;
			}
			if (!FanHTnvZmXVTOfDHuteqdkMyhpJj.oXYDabjRpNXKwNPmsBwtnENPvWZZ(out var rnRtokWNhetVhPChWiBQGmtLQvuqA3))
			{
				return false;
			}
			if (!FanHTnvZmXVTOfDHuteqdkMyhpJj.fNTyGPGOnIOSrrbgHczbBuXmfbcR(P_0, out var cTSxvjkEvebjWJIefHofAvErEZLOA2))
			{
				return false;
			}
			int num = rnRtokWNhetVhPChWiBQGmtLQvuqA3.sDvrLURGYIxQAebIsOLJdYanhjvQ - rnRtokWNhetVhPChWiBQGmtLQvuqA2.sDvrLURGYIxQAebIsOLJdYanhjvQ;
			int num2 = rnRtokWNhetVhPChWiBQGmtLQvuqA3.RzlWdjBIRgOGQdJjCOArXuUfNFxk - rnRtokWNhetVhPChWiBQGmtLQvuqA2.RzlWdjBIRgOGQdJjCOArXuUfNFxk;
			if (num >= 0 && num2 >= 0 && num <= cTSxvjkEvebjWJIefHofAvErEZLOA2.EOPaVJzcgBTgUFHoZAKKBFgzUhKt && num2 <= cTSxvjkEvebjWJIefHofAvErEZLOA2.HXpYFZxqMZODDJMPzAkWBWQWeOSG)
			{
				return false;
			}
			if (!FanHTnvZmXVTOfDHuteqdkMyhpJj.BozFaTFxCkyxzKlIaVcjizZNxOlB(P_0, out var cTSxvjkEvebjWJIefHofAvErEZLOA3))
			{
				return false;
			}
			if (rnRtokWNhetVhPChWiBQGmtLQvuqA3.sDvrLURGYIxQAebIsOLJdYanhjvQ >= cTSxvjkEvebjWJIefHofAvErEZLOA3.hCcATlCnjoSSdUsukAXxgcABNXVb && rnRtokWNhetVhPChWiBQGmtLQvuqA3.sDvrLURGYIxQAebIsOLJdYanhjvQ <= cTSxvjkEvebjWJIefHofAvErEZLOA3.EOPaVJzcgBTgUFHoZAKKBFgzUhKt && rnRtokWNhetVhPChWiBQGmtLQvuqA3.RzlWdjBIRgOGQdJjCOArXuUfNFxk >= cTSxvjkEvebjWJIefHofAvErEZLOA3.jcBQehHfYcdLbtUCRPQLUMGKSneE)
			{
				return rnRtokWNhetVhPChWiBQGmtLQvuqA3.RzlWdjBIRgOGQdJjCOArXuUfNFxk <= cTSxvjkEvebjWJIefHofAvErEZLOA3.HXpYFZxqMZODDJMPzAkWBWQWeOSG;
			}
			return false;
		}
	}

	private class kQouUtRvZOrPLfSudMPAYPxOLhKL
	{
		private bool KAFhZRyEinoSrGdPEJfYPxqJvul;

		private bool UHZMdVlMiaEzbpoqhSEurMJEdCFu;

		private bool qgYCwYzftHRdNbDwkVrULSBGTuPR;

		private int ZZTOlsdQsHPfkHJysfgMZsWtaEvBA = 10;

		private readonly float mXogMzBtAhnIVOlwilGjqAvhlFobA;

		private double WPurJbhUpoCMSHEncjioiKibvwOd;

		public bool vnFzrCiCadLHCqqjioGTyArYprhR
		{
			get
			{
				return KAFhZRyEinoSrGdPEJfYPxqJvul;
			}
			set
			{
				if (flag != KAFhZRyEinoSrGdPEJfYPxqJvul)
				{
					GAguiiRLaHzeBJVJdqABIwrrNVol(true);
				}
			}
		}

		public bool aXaQzauDmYhbadAzHNGIlONsWURr => UHZMdVlMiaEzbpoqhSEurMJEdCFu;

		public bool iSKDtsNjVHcrrRtbKbwfoitMSOrE
		{
			get
			{
				return qgYCwYzftHRdNbDwkVrULSBGTuPR;
			}
			set
			{
				if (qgYCwYzftHRdNbDwkVrULSBGTuPR != flag)
				{
					qgYCwYzftHRdNbDwkVrULSBGTuPR = flag;
					GAguiiRLaHzeBJVJdqABIwrrNVol(true);
				}
			}
		}

		public int LgdRGdYHvVBHCwoeArddTiWhfhHZ => ZZTOlsdQsHPfkHJysfgMZsWtaEvBA;

		public kQouUtRvZOrPLfSudMPAYPxOLhKL(bool P_0, float P_1)
		{
			KAFhZRyEinoSrGdPEJfYPxqJvul = P_0;
			mXogMzBtAhnIVOlwilGjqAvhlFobA = P_1;
			GAguiiRLaHzeBJVJdqABIwrrNVol(false);
		}

		public void qELcSshxTRaDRljttLHKPSjMfUqWA()
		{
			if (KAFhZRyEinoSrGdPEJfYPxqJvul && !(ReInput.realTime < WPurJbhUpoCMSHEncjioiKibvwOd))
			{
				GAguiiRLaHzeBJVJdqABIwrrNVol(true);
			}
		}

		private void GAguiiRLaHzeBJVJdqABIwrrNVol(bool P_0)
		{
			if (qgYCwYzftHRdNbDwkVrULSBGTuPR)
			{
				FanHTnvZmXVTOfDHuteqdkMyhpJj.UQTSfDwNIeCoosnFfbykCHKHufmb(112u, 0u, ref ZZTOlsdQsHPfkHJysfgMZsWtaEvBA, 0u);
			}
			UHZMdVlMiaEzbpoqhSEurMJEdCFu = FanHTnvZmXVTOfDHuteqdkMyhpJj.nucCadqwdmJJQehfaaoEWqEEitQl(nLFjDWhFFneDsZFBEEAqYlPBIetI.fyHEgfjbgJhWTiIyltftxYYVoJLP) > 0;
			if (P_0)
			{
				WPurJbhUpoCMSHEncjioiKibvwOd = ReInput.realTime + (double)mXogMzBtAhnIVOlwilGjqAvhlFobA;
			}
		}
	}

	private const int DVNwvheddKEBGKVWeHFyYwvHazpG = 5;

	private const int FwrVtEgQSOWvkMfmRpgIhdQcSMNT = 4;

	private readonly SpinLock uvvlDcleMCNBCaeZiGBgRawQcrbgA = new SpinLock();

	private UpdateLoopDataSet<vMPOZAcpjDUdfaEAQbzzJPYBzuZf> UajURYmXpcHajYiMEIlCtyofNbCn;

	private HardwareControllerMap_Game GRDayXWKaSDUIHhlHGbbFtRIhYWOc;

	private kQouUtRvZOrPLfSudMPAYPxOLhKL raJtvYfYDiHhCGLqZDICzYqCNNoS;

	private bool awVAZDiqVxLMCpTBnaqEiBLdLDSU;

	private int DcxtLERQVkrCOAvnxYexbwPznFIe;

	private bool YhrTXSiRTQEOQqzvYOSgTaGUlJbt;

	private const bool xFkGVnKSDyDsqTEbwYsJPxpFdcoI = true;

	private const float mLlbgWGNapddWDpVJTUCTbLalZIcb = 2f;

	private bool ofKbKIkGdAbABhtCBUqRBMlVnLJmB;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return YhrTXSiRTQEOQqzvYOSgTaGUlJbt;
		}
		set
		{
			if (YhrTXSiRTQEOQqzvYOSgTaGUlJbt != value)
			{
				YhrTXSiRTQEOQqzvYOSgTaGUlJbt = value;
				Clear();
				ThreadSafeUnityInput.mouse.Monitor(value);
			}
		}
	}

	InputSource IUnifiedMouseSource.inputSource => InputSource.RawInput;

	HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap
	{
		get
		{
			if (GRDayXWKaSDUIHhlHGbbFtRIhYWOc == null)
			{
				GRDayXWKaSDUIHhlHGbbFtRIhYWOc = ohzddaroobvHUXhjDSXAejKlwRwd();
			}
			return GRDayXWKaSDUIHhlHGbbFtRIhYWOc;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!YhrTXSiRTQEOQqzvYOSgTaGUlJbt)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public mlvCsDdsydRaeUudGGZWhwEDLnMp(UpdateLoopSetting P_0)
	{
		TQlzTfornxukgLoPUhKrlhBqNxNS();
		raJtvYfYDiHhCGLqZDICzYqCNNoS = new kQouUtRvZOrPLfSudMPAYPxOLhKL(true, 2f);
		UajURYmXpcHajYiMEIlCtyofNbCn = new UpdateLoopDataSet<vMPOZAcpjDUdfaEAQbzzJPYBzuZf>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				UajURYmXpcHajYiMEIlCtyofNbCn[i] = new vMPOZAcpjDUdfaEAQbzzJPYBzuZf(raJtvYfYDiHhCGLqZDICzYqCNNoS, list[i]);
			}
		}
		awVAZDiqVxLMCpTBnaqEiBLdLDSU = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += ruNBRAcOzRCQeCwscbNicNyFLBaiA;
		ReInput.ApplicationPauseChangedEvent += ZaKUbErblFFzmjosnChfbtFAHgOP;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += myXWabaHMNNusRhHqVjbmffZDDfF;
		ReInput.TimeScalePauseChangedEvent += IqVNbximtRXwFlBjzUZVcBzssTaR;
		ReInput.UpdateEndedEvent += PtmAIMBMMkHCUBaWSseIkFxgojAI;
	}

	public void kEpvxCuYaJEVVhZJGfDXhDNFikcs(UpdateLoopType P_0)
	{
		UajURYmXpcHajYiMEIlCtyofNbCn.SetUpdateLoop(P_0);
		raJtvYfYDiHhCGLqZDICzYqCNNoS.qELcSshxTRaDRljttLHKPSjMfUqWA();
		awVAZDiqVxLMCpTBnaqEiBLdLDSU = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void GfWMjyyviGJvwmotmGETyqqEvNPy(KAhCTYewFHkouYHATztMvRchwmIs P_0)
	{
		if (!awVAZDiqVxLMCpTBnaqEiBLdLDSU)
		{
			return;
		}
		using (uvvlDcleMCNBCaeZiGBgRawQcrbgA.Lock())
		{
			int count = UajURYmXpcHajYiMEIlCtyofNbCn.Count;
			for (int i = 0; i < count; i++)
			{
				UajURYmXpcHajYiMEIlCtyofNbCn[i].IUVMEXDIILGmuIAiSDtHWAOgxBYf(P_0);
			}
		}
	}

	public void aPJuWczjrpwQeKpOUePKcHGJwmmL(bool P_0)
	{
		nIfOrVdoYMncWKmJCFAJVsZrDpLh();
	}

	public void sNYRcMxyjxUfMpUCybRYsaYXbUOQ(bool P_0)
	{
		if (TQlzTfornxukgLoPUhKrlhBqNxNS() < 0)
		{
			nIfOrVdoYMncWKmJCFAJVsZrDpLh();
		}
	}

	private int TQlzTfornxukgLoPUhKrlhBqNxNS()
	{
		int dcxtLERQVkrCOAvnxYexbwPznFIe = DcxtLERQVkrCOAvnxYexbwPznFIe;
		if (TLpaAyfjQfVEHNKGQCySwHFUzfaqA.yodHBmoEOrsbWTtOkcBdAbmBNriN(vSxAQNisZQkfHDRjqXHckjHjfUVv.Mouse, out var dcxtLERQVkrCOAvnxYexbwPznFIe2))
		{
			DcxtLERQVkrCOAvnxYexbwPznFIe = dcxtLERQVkrCOAvnxYexbwPznFIe2;
		}
		else
		{
			DcxtLERQVkrCOAvnxYexbwPznFIe = ((FanHTnvZmXVTOfDHuteqdkMyhpJj.nucCadqwdmJJQehfaaoEWqEEitQl(nLFjDWhFFneDsZFBEEAqYlPBIetI.oREbliCKcrfKGrGQNtcIEvjiMndeb) != 0) ? 1 : 0);
		}
		return DcxtLERQVkrCOAvnxYexbwPznFIe - dcxtLERQVkrCOAvnxYexbwPznFIe;
	}

	private void ruNBRAcOzRCQeCwscbNicNyFLBaiA(bool P_0)
	{
		awVAZDiqVxLMCpTBnaqEiBLdLDSU = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !awVAZDiqVxLMCpTBnaqEiBLdLDSU)
		{
			nIfOrVdoYMncWKmJCFAJVsZrDpLh();
		}
	}

	private void ZaKUbErblFFzmjosnChfbtFAHgOP(bool P_0)
	{
		awVAZDiqVxLMCpTBnaqEiBLdLDSU = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!awVAZDiqVxLMCpTBnaqEiBLdLDSU)
		{
			nIfOrVdoYMncWKmJCFAJVsZrDpLh();
		}
	}

	private void myXWabaHMNNusRhHqVjbmffZDDfF(bool P_0)
	{
	}

	private void IqVNbximtRXwFlBjzUZVcBzssTaR(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		awVAZDiqVxLMCpTBnaqEiBLdLDSU = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (uvvlDcleMCNBCaeZiGBgRawQcrbgA.Lock())
		{
			UajURYmXpcHajYiMEIlCtyofNbCn[UajURYmXpcHajYiMEIlCtyofNbCn.fixedUpdateSetIndex].ZpYNdEnwDtPTaofksvtoEVmgTzzK();
		}
	}

	private void PtmAIMBMMkHCUBaWSseIkFxgojAI(UpdateLoopType P_0)
	{
		using (uvvlDcleMCNBCaeZiGBgRawQcrbgA.Lock())
		{
			UajURYmXpcHajYiMEIlCtyofNbCn.Get(P_0).dcnsTcVnRGdvcOAxATERASpmbPCI();
		}
	}

	private void nIfOrVdoYMncWKmJCFAJVsZrDpLh()
	{
		using (uvvlDcleMCNBCaeZiGBgRawQcrbgA.Lock())
		{
			int count = UajURYmXpcHajYiMEIlCtyofNbCn.Count;
			for (int i = 0; i < count; i++)
			{
				UajURYmXpcHajYiMEIlCtyofNbCn[i].OIDLhTIKgTsRjNMbWAAMKnPrnspm();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		UajURYmXpcHajYiMEIlCtyofNbCn.Current.TyUBerxGLDjrlZtkyFiNFbpqrpeaA(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		nIfOrVdoYMncWKmJCFAJVsZrDpLh();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game ohzddaroobvHUXhjDSXAejKlwRwd()
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
		VPJDRNkylRMbGrDppzAGNeRSfSHX(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ZosXYUFqXzDvxYmTHBguDnIMnwtp()
	{
		try
		{
			VPJDRNkylRMbGrDppzAGNeRSfSHX(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void VPJDRNkylRMbGrDppzAGNeRSfSHX(bool P_0)
	{
		if (!ofKbKIkGdAbABhtCBUqRBMlVnLJmB)
		{
			ReInput.ApplicationFocusChangedEvent -= ruNBRAcOzRCQeCwscbNicNyFLBaiA;
			ReInput.ApplicationPauseChangedEvent -= ZaKUbErblFFzmjosnChfbtFAHgOP;
			ReInput.EditorPauseChangedEvent -= myXWabaHMNNusRhHqVjbmffZDDfF;
			ReInput.TimeScalePauseChangedEvent -= IqVNbximtRXwFlBjzUZVcBzssTaR;
			ReInput.UpdateEndedEvent -= PtmAIMBMMkHCUBaWSseIkFxgojAI;
			if (P_0 && YhrTXSiRTQEOQqzvYOSgTaGUlJbt)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			ofKbKIkGdAbABhtCBUqRBMlVnLJmB = true;
		}
	}
}
