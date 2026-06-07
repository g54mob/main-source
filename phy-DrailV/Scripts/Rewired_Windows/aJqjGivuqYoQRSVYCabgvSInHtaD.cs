using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class aJqjGivuqYoQRSVYCabgvSInHtaD : IDisposable, IUnifiedMouseSource, IGetSetEnabled
{
	private class STZghMQPkVAKaGGudAIUUSTMdRRjA
	{
		private enum cacLChDrcKfgUCPJyEmFCvQKKKcFb
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int ARLqiTvfqJXfADgobXFkqQbVrxmc = 120;

		private const int sXPDYPxQFVAdSUngnRyUFNiYaqmV = 2048;

		public readonly UpdateLoopType WHDTzYTojOwKfxiTarplhaTxVeNq;

		public uint iohvtLjwwGlBjtKvMlonRZMUWWpp;

		public uint NWNNppyDrpeJuiYvjWaiHikJvfXOA;

		public KtqulkIzwYPngSZQClaIqIhJNmUF bAFOtTjYvthuIqrCNkasMXeFXhIf;

		public float HyOGJyEMNRPNbRuUxYTAHdiHKkPbb;

		public float hKNBoqqlWhZEGDOSGavmrJzzANJX;

		public float HBHVfDLlfjXTKQECBaheldjPbhBAA;

		public float wjCfKBZXomgfjIbRAFBayipoGvFTA;

		private bool[] DCFbyeGxqUTufdkZORKtNQLxKBGq;

		private bool[] aYVkrIVhdfurCscNoBRfJsHkmUEfA;

		private AIrWndcFLFnKbDCvnFghpSOUnMiI xCsfzzooYeadhMtBuPUKRYAEwkVd;

		private uint FHtaTkgagqxJcJyGzijxbNhExnIpA;

		private int FLBUBIXxBXSMBmiSlEJMGRjJNiVhb;

		private int PXkMDDCUHNaIznvgbRsqcBrzegTiA;

		private bool vemGedEeSRteSmQlenqFEcZEpFLVb;

		public STZghMQPkVAKaGGudAIUUSTMdRRjA(AIrWndcFLFnKbDCvnFghpSOUnMiI P_0, UpdateLoopType P_1)
		{
			xCsfzzooYeadhMtBuPUKRYAEwkVd = P_0;
			WHDTzYTojOwKfxiTarplhaTxVeNq = P_1;
			DCFbyeGxqUTufdkZORKtNQLxKBGq = new bool[5];
			aYVkrIVhdfurCscNoBRfJsHkmUEfA = new bool[5];
		}

		public void fjTIBpBcqDOXCISmvKbNXSkjvvux(UXcYhloThkwhTGaKNWDgnIoRMtyH P_0)
		{
			BcHlPvznLRsddttrnvLmclviOoWv bcHlPvznLRsddttrnvLmclviOoWv = P_0.fqhzXlApAlcvDRoNTJMGFajByIIM;
			if (bcHlPvznLRsddttrnvLmclviOoWv != BcHlPvznLRsddttrnvLmclviOoWv.None)
			{
				if ((bcHlPvznLRsddttrnvLmclviOoWv & BcHlPvznLRsddttrnvLmclviOoWv.LeftButtonDown) != BcHlPvznLRsddttrnvLmclviOoWv.None || (bcHlPvznLRsddttrnvLmclviOoWv & BcHlPvznLRsddttrnvLmclviOoWv.RightButtonDown) != BcHlPvznLRsddttrnvLmclviOoWv.None)
				{
					IntPtr intPtr = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.vscZBvMucbOyMfqJkbaPPOFWbTRj();
					if (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.uJlHmdwEmZILzmHAFnPMQfvwLnfH() == intPtr && wvRmpZLKegMETchJdJNYIHKKaoGQ(intPtr))
					{
						bcHlPvznLRsddttrnvLmclviOoWv &= ~BcHlPvznLRsddttrnvLmclviOoWv.LeftButtonDown;
						bcHlPvznLRsddttrnvLmclviOoWv &= ~BcHlPvznLRsddttrnvLmclviOoWv.RightButtonDown;
					}
				}
				int num = (int)bcHlPvznLRsddttrnvLmclviOoWv;
				if (xCsfzzooYeadhMtBuPUKRYAEwkVd.hBYYQVDLvlITuZbptweDvlFJcACGA && xCsfzzooYeadhMtBuPUKRYAEwkVd.ELcIPCahvNaEqspIbvsmIOzvUpwC)
				{
					ugRQifoHiAXaxNzDwbKpEHYCFLoAA(1, num, 1, 2);
					ugRQifoHiAXaxNzDwbKpEHYCFLoAA(0, num, 4, 8);
				}
				else
				{
					ugRQifoHiAXaxNzDwbKpEHYCFLoAA(0, num, 1, 2);
					ugRQifoHiAXaxNzDwbKpEHYCFLoAA(1, num, 4, 8);
				}
				ugRQifoHiAXaxNzDwbKpEHYCFLoAA(2, num, 16, 32);
				ugRQifoHiAXaxNzDwbKpEHYCFLoAA(3, num, 64, 128);
				ugRQifoHiAXaxNzDwbKpEHYCFLoAA(4, num, 256, 512);
			}
			iohvtLjwwGlBjtKvMlonRZMUWWpp = P_0.iohvtLjwwGlBjtKvMlonRZMUWWpp;
			NWNNppyDrpeJuiYvjWaiHikJvfXOA = P_0.NWNNppyDrpeJuiYvjWaiHikJvfXOA;
			KtqulkIzwYPngSZQClaIqIhJNmUF ktqulkIzwYPngSZQClaIqIhJNmUF = bAFOtTjYvthuIqrCNkasMXeFXhIf;
			bAFOtTjYvthuIqrCNkasMXeFXhIf = P_0.bAFOtTjYvthuIqrCNkasMXeFXhIf;
			if (bAFOtTjYvthuIqrCNkasMXeFXhIf != ktqulkIzwYPngSZQClaIqIhJNmUF)
			{
				vemGedEeSRteSmQlenqFEcZEpFLVb = false;
			}
			if (bAFOtTjYvthuIqrCNkasMXeFXhIf == KtqulkIzwYPngSZQClaIqIhJNmUF.MoveRelative)
			{
				HyOGJyEMNRPNbRuUxYTAHdiHKkPbb += (float)P_0.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb * 0.5f;
				hKNBoqqlWhZEGDOSGavmrJzzANJX += (float)P_0.hKNBoqqlWhZEGDOSGavmrJzzANJX * 0.5f * -1f;
			}
			else if ((bAFOtTjYvthuIqrCNkasMXeFXhIf & KtqulkIzwYPngSZQClaIqIhJNmUF.MoveAbsolute) != KtqulkIzwYPngSZQClaIqIhJNmUF.MoveRelative)
			{
				bool num2 = (bAFOtTjYvthuIqrCNkasMXeFXhIf & KtqulkIzwYPngSZQClaIqIhJNmUF.VirtualDesktop) != 0;
				int num3 = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.GzzDgJataKbslNPOWYXlGilxHlRw(num2 ? xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.hqLwDYBpPxQtFIZltlobVErVSNNp : xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.bubLCPMMLAEgzAuewjFWKwuqufomA);
				int num4 = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.GzzDgJataKbslNPOWYXlGilxHlRw(num2 ? xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.tWOLAHbugtGctMdKwpTrRqGSPgDY : xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.TOSpidMMFtEVDhEFiyotngiVlVNB);
				int num5 = (int)((float)P_0.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.hKNBoqqlWhZEGDOSGavmrJzzANJX) / 65535f * (float)num4);
				if (!vemGedEeSRteSmQlenqFEcZEpFLVb)
				{
					FLBUBIXxBXSMBmiSlEJMGRjJNiVhb = num5;
					PXkMDDCUHNaIznvgbRsqcBrzegTiA = num6;
					vemGedEeSRteSmQlenqFEcZEpFLVb = true;
				}
				HyOGJyEMNRPNbRuUxYTAHdiHKkPbb += num5 - FLBUBIXxBXSMBmiSlEJMGRjJNiVhb;
				hKNBoqqlWhZEGDOSGavmrJzzANJX += num6 - PXkMDDCUHNaIznvgbRsqcBrzegTiA;
				FLBUBIXxBXSMBmiSlEJMGRjJNiVhb = num5;
				PXkMDDCUHNaIznvgbRsqcBrzegTiA = num6;
			}
			else
			{
				HyOGJyEMNRPNbRuUxYTAHdiHKkPbb = P_0.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb;
				hKNBoqqlWhZEGDOSGavmrJzzANJX = P_0.hKNBoqqlWhZEGDOSGavmrJzzANJX;
			}
			if (P_0.BUqNphxbDPNDosbUhKTVNlhzhQMR != 0)
			{
				int num7 = ((MathTools.Abs(P_0.BUqNphxbDPNDosbUhKTVNlhzhQMR) < 120) ? MathTools.Sign(P_0.BUqNphxbDPNDosbUhKTVNlhzhQMR) : (P_0.BUqNphxbDPNDosbUhKTVNlhzhQMR / 120));
				if ((bcHlPvznLRsddttrnvLmclviOoWv & BcHlPvznLRsddttrnvLmclviOoWv.MouseWheel) != BcHlPvznLRsddttrnvLmclviOoWv.None)
				{
					HBHVfDLlfjXTKQECBaheldjPbhBAA += num7;
				}
				else if ((bcHlPvznLRsddttrnvLmclviOoWv & (BcHlPvznLRsddttrnvLmclviOoWv)2048) != BcHlPvznLRsddttrnvLmclviOoWv.None)
				{
					wjCfKBZXomgfjIbRAFBayipoGvFTA += num7;
				}
			}
		}

		public void cgXdoDGasbxLMLtXKouQWlVBfjiA(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = HyOGJyEMNRPNbRuUxYTAHdiHKkPbb;
			axisValues[1] = hKNBoqqlWhZEGDOSGavmrJzzANJX;
			axisValues[2] = HBHVfDLlfjXTKQECBaheldjPbhBAA;
			axisValues[3] = wjCfKBZXomgfjIbRAFBayipoGvFTA;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = DCFbyeGxqUTufdkZORKtNQLxKBGq[i] || aYVkrIVhdfurCscNoBRfJsHkmUEfA[i];
			}
			VBnPpPXWVpHXfYPMcmPqvsaonuJM();
		}

		public void MqQjLCryqEPDlgJVxyKAVvUubRHs()
		{
			VBnPpPXWVpHXfYPMcmPqvsaonuJM();
		}

		private void VBnPpPXWVpHXfYPMcmPqvsaonuJM()
		{
			if (FHtaTkgagqxJcJyGzijxbNhExnIpA != ReInput.absFrame)
			{
				nkoFaUglpzaIbCJqRMwvFmRNYaRR();
				FHtaTkgagqxJcJyGzijxbNhExnIpA = ReInput.absFrame;
			}
		}

		public void wSuERjejnukorMpeyvWlfiOlJujf()
		{
			HyOGJyEMNRPNbRuUxYTAHdiHKkPbb = 0f;
			hKNBoqqlWhZEGDOSGavmrJzzANJX = 0f;
			NWNNppyDrpeJuiYvjWaiHikJvfXOA = 0u;
			bAFOtTjYvthuIqrCNkasMXeFXhIf = KtqulkIzwYPngSZQClaIqIhJNmUF.MoveRelative;
			HBHVfDLlfjXTKQECBaheldjPbhBAA = 0f;
			wjCfKBZXomgfjIbRAFBayipoGvFTA = 0f;
			Array.Clear(DCFbyeGxqUTufdkZORKtNQLxKBGq, 0, 5);
			Array.Clear(aYVkrIVhdfurCscNoBRfJsHkmUEfA, 0, 5);
			vemGedEeSRteSmQlenqFEcZEpFLVb = false;
		}

		public void nkoFaUglpzaIbCJqRMwvFmRNYaRR()
		{
			HyOGJyEMNRPNbRuUxYTAHdiHKkPbb = 0f;
			hKNBoqqlWhZEGDOSGavmrJzzANJX = 0f;
			HBHVfDLlfjXTKQECBaheldjPbhBAA = 0f;
			wjCfKBZXomgfjIbRAFBayipoGvFTA = 0f;
			Array.Clear(aYVkrIVhdfurCscNoBRfJsHkmUEfA, 0, 5);
		}

		private void ugRQifoHiAXaxNzDwbKpEHYCFLoAA(int P_0, int P_1, int P_2, int P_3)
		{
			cacLChDrcKfgUCPJyEmFCvQKKKcFb cacLChDrcKfgUCPJyEmFCvQKKKcFb2 = VFNnmOGOxbgxWOGzhITjdzlVLqYC(P_1, P_2, P_3);
			if (DCFbyeGxqUTufdkZORKtNQLxKBGq[P_0])
			{
				if (cacLChDrcKfgUCPJyEmFCvQKKKcFb2 == cacLChDrcKfgUCPJyEmFCvQKKKcFb.Up || cacLChDrcKfgUCPJyEmFCvQKKKcFb2 == cacLChDrcKfgUCPJyEmFCvQKKKcFb.DownAndUp)
				{
					DCFbyeGxqUTufdkZORKtNQLxKBGq[P_0] = false;
				}
			}
			else if (cacLChDrcKfgUCPJyEmFCvQKKKcFb2 == cacLChDrcKfgUCPJyEmFCvQKKKcFb.Down)
			{
				DCFbyeGxqUTufdkZORKtNQLxKBGq[P_0] = true;
			}
			if (cacLChDrcKfgUCPJyEmFCvQKKKcFb2 == cacLChDrcKfgUCPJyEmFCvQKKKcFb.Down || cacLChDrcKfgUCPJyEmFCvQKKKcFb2 == cacLChDrcKfgUCPJyEmFCvQKKKcFb.DownAndUp)
			{
				aYVkrIVhdfurCscNoBRfJsHkmUEfA[P_0] = true;
			}
		}

		private static cacLChDrcKfgUCPJyEmFCvQKKKcFb VFNnmOGOxbgxWOGzhITjdzlVLqYC(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return cacLChDrcKfgUCPJyEmFCvQKKKcFb.DownAndUp;
				}
				return cacLChDrcKfgUCPJyEmFCvQKKKcFb.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return cacLChDrcKfgUCPJyEmFCvQKKKcFb.Up;
			}
			return cacLChDrcKfgUCPJyEmFCvQKKKcFb.None;
		}

		private static bool wvRmpZLKegMETchJdJNYIHKKaoGQ(IntPtr P_0)
		{
			if (VBqfSSvUBwCRtzUpeUWIfCWGfXliA.mfyPAQqXwgHfMIkcNHVUgtXuuvGrA(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!VBqfSSvUBwCRtzUpeUWIfCWGfXliA.dQmVAGRyTgYyBVdSGaghhxbnJGTG(P_0, out var zMEltZKvhNBHUFyDKRqiiLhnsXKs2))
			{
				return false;
			}
			if (!VBqfSSvUBwCRtzUpeUWIfCWGfXliA.hHsaHkEWAqSpycyfUjYWKeKLmRuq(out var zMEltZKvhNBHUFyDKRqiiLhnsXKs3))
			{
				return false;
			}
			if (!VBqfSSvUBwCRtzUpeUWIfCWGfXliA.UviztwmCsnhAMwDxNKwRpyRHUmCe(P_0, out var aRZgAkkxJJdjQDIJhTFilAsRxdob2))
			{
				return false;
			}
			int num = zMEltZKvhNBHUFyDKRqiiLhnsXKs3.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb - zMEltZKvhNBHUFyDKRqiiLhnsXKs2.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb;
			int num2 = zMEltZKvhNBHUFyDKRqiiLhnsXKs3.hKNBoqqlWhZEGDOSGavmrJzzANJX - zMEltZKvhNBHUFyDKRqiiLhnsXKs2.hKNBoqqlWhZEGDOSGavmrJzzANJX;
			if (num >= 0 && num2 >= 0 && num <= aRZgAkkxJJdjQDIJhTFilAsRxdob2.DZFompWatPBgaiXdstCcQFzlxiIk && num2 <= aRZgAkkxJJdjQDIJhTFilAsRxdob2.VHycgRjJnjpJFroidGuCWHHjUhFH)
			{
				return false;
			}
			if (!VBqfSSvUBwCRtzUpeUWIfCWGfXliA.cECYlZPepHLotRDMwcDrfiuMpNLEA(P_0, out var aRZgAkkxJJdjQDIJhTFilAsRxdob3))
			{
				return false;
			}
			if (zMEltZKvhNBHUFyDKRqiiLhnsXKs3.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb >= aRZgAkkxJJdjQDIJhTFilAsRxdob3.AfUIpuKZlaiDPqqChTqNAzNZPYDDA && zMEltZKvhNBHUFyDKRqiiLhnsXKs3.HyOGJyEMNRPNbRuUxYTAHdiHKkPbb <= aRZgAkkxJJdjQDIJhTFilAsRxdob3.DZFompWatPBgaiXdstCcQFzlxiIk && zMEltZKvhNBHUFyDKRqiiLhnsXKs3.hKNBoqqlWhZEGDOSGavmrJzzANJX >= aRZgAkkxJJdjQDIJhTFilAsRxdob3.WhPYwMAKmkAnnvbXwVyqpjheHrbd)
			{
				return zMEltZKvhNBHUFyDKRqiiLhnsXKs3.hKNBoqqlWhZEGDOSGavmrJzzANJX <= aRZgAkkxJJdjQDIJhTFilAsRxdob3.VHycgRjJnjpJFroidGuCWHHjUhFH;
			}
			return false;
		}
	}

	private class AIrWndcFLFnKbDCvnFghpSOUnMiI
	{
		private bool vOCRKtJjUKmNQpDZwbafkshoGskD;

		private bool OYSShwCakSqkLjwfxTXOWCoiaTre;

		private bool ZpyEuxCJGJKIlRvMIMnfOkdsFNdfb;

		private int fuqeWQLXDxGeoQMaOqTNctFqlIDc = 10;

		private readonly float uDFdnKWzhwOXjuAyvtHlhqSgueuj;

		private double jYLcirjMujsdugaXODuDvVqzYdLHA;

		public bool hBYYQVDLvlITuZbptweDvlFJcACGA
		{
			get
			{
				return vOCRKtJjUKmNQpDZwbafkshoGskD;
			}
			set
			{
				if (flag != vOCRKtJjUKmNQpDZwbafkshoGskD)
				{
					tjdDbPmdlNVfEyBynDrNTskTdAAM(true);
				}
			}
		}

		public bool ELcIPCahvNaEqspIbvsmIOzvUpwC => OYSShwCakSqkLjwfxTXOWCoiaTre;

		public bool lvkePsoqLfllFTHyXlaROTcmsZmM
		{
			get
			{
				return ZpyEuxCJGJKIlRvMIMnfOkdsFNdfb;
			}
			set
			{
				if (ZpyEuxCJGJKIlRvMIMnfOkdsFNdfb != flag)
				{
					ZpyEuxCJGJKIlRvMIMnfOkdsFNdfb = flag;
					tjdDbPmdlNVfEyBynDrNTskTdAAM(true);
				}
			}
		}

		public int DdnEAXJKqUDaVtRhjudUnIXskoVt => fuqeWQLXDxGeoQMaOqTNctFqlIDc;

		public AIrWndcFLFnKbDCvnFghpSOUnMiI(bool P_0, float P_1)
		{
			vOCRKtJjUKmNQpDZwbafkshoGskD = P_0;
			uDFdnKWzhwOXjuAyvtHlhqSgueuj = P_1;
			tjdDbPmdlNVfEyBynDrNTskTdAAM(false);
		}

		public void mefhGqvTkcrETnFSidhNngFjAYNV()
		{
			if (vOCRKtJjUKmNQpDZwbafkshoGskD && !(ReInput.realTime < jYLcirjMujsdugaXODuDvVqzYdLHA))
			{
				tjdDbPmdlNVfEyBynDrNTskTdAAM(true);
			}
		}

		private void tjdDbPmdlNVfEyBynDrNTskTdAAM(bool P_0)
		{
			if (ZpyEuxCJGJKIlRvMIMnfOkdsFNdfb)
			{
				VBqfSSvUBwCRtzUpeUWIfCWGfXliA.XvUaJYHNnVgqPBqKJhVErTEiqeYJB(112u, 0u, ref fuqeWQLXDxGeoQMaOqTNctFqlIDc, 0u);
			}
			OYSShwCakSqkLjwfxTXOWCoiaTre = VBqfSSvUBwCRtzUpeUWIfCWGfXliA.GzzDgJataKbslNPOWYXlGilxHlRw(xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.kIGBjORaqIWjFUpiFwHrbHgaIOGR) > 0;
			if (P_0)
			{
				jYLcirjMujsdugaXODuDvVqzYdLHA = ReInput.realTime + (double)uDFdnKWzhwOXjuAyvtHlhqSgueuj;
			}
		}
	}

	private const int CyZlyMvoGxSvfFEPCQWXSDYugSthA = 5;

	private const int AwUBlBIarYlMFWZXoHYmfVypiArhb = 4;

	private readonly SpinLock eTRoskBdTVJraCzYFXNyrUomeHqE = new SpinLock();

	private UpdateLoopDataSet<STZghMQPkVAKaGGudAIUUSTMdRRjA> YqtgmrqbQPIkQJUFMKiGJqhGNslH;

	private HardwareControllerMap_Game OqezqauiJzHPibkVlZIqPxfahHmv;

	private AIrWndcFLFnKbDCvnFghpSOUnMiI xCsfzzooYeadhMtBuPUKRYAEwkVd;

	private bool xhJKgJuhFOPEpnVzWdMTBCnMpdeW;

	private int PKNLyqAwojqSAqZLZvSJUycagVvV;

	private bool vOCRKtJjUKmNQpDZwbafkshoGskD;

	private const bool WxLEMhMWyoujgHaVgzrHXGjdoMWM = true;

	private const float iyJIJkSdBxXScXXbBAqEFNJRRahs = 2f;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public bool enabled
	{
		get
		{
			return vOCRKtJjUKmNQpDZwbafkshoGskD;
		}
		set
		{
			if (vOCRKtJjUKmNQpDZwbafkshoGskD != value)
			{
				vOCRKtJjUKmNQpDZwbafkshoGskD = value;
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
			if (OqezqauiJzHPibkVlZIqPxfahHmv == null)
			{
				OqezqauiJzHPibkVlZIqPxfahHmv = GURSYgsQJIKQUSvFwlKtfbGzZQCQ();
			}
			return OqezqauiJzHPibkVlZIqPxfahHmv;
		}
	}

	public int buttonCount => 5;

	public int axisCount => 4;

	public Vector2 mousePosition
	{
		get
		{
			if (!vOCRKtJjUKmNQpDZwbafkshoGskD)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	public Controller.Extension controllerExtension => null;

	public aJqjGivuqYoQRSVYCabgvSInHtaD(UpdateLoopSetting P_0)
	{
		gvbSoVtdUyQSsIkAVCaIaIdcpDZDA();
		xCsfzzooYeadhMtBuPUKRYAEwkVd = new AIrWndcFLFnKbDCvnFghpSOUnMiI(true, 2f);
		YqtgmrqbQPIkQJUFMKiGJqhGNslH = new UpdateLoopDataSet<STZghMQPkVAKaGGudAIUUSTMdRRjA>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				YqtgmrqbQPIkQJUFMKiGJqhGNslH[i] = new STZghMQPkVAKaGGudAIUUSTMdRRjA(xCsfzzooYeadhMtBuPUKRYAEwkVd, list[i]);
			}
		}
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += orUMILCIqROwyBKfAAnTVqdZfYkj;
		ReInput.ApplicationPauseChangedEvent += TNcWPrbERDuIJOeRurmdoMrAbUeN;
		enabled = true;
		ReInput.EditorPauseChangedEvent += fVsAsvbqlzfDdjOSAWqIHuaIUAvyB;
		ReInput.TimeScalePauseChangedEvent += HbahpfcvOpPnYxZFkJkAOBvbitdv;
		ReInput.UpdateEndedEvent += WAOrbusfizshnpxwFmgJjjqHioOJ;
	}

	public void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
	{
		YqtgmrqbQPIkQJUFMKiGJqhGNslH.SetUpdateLoop(P_0);
		xCsfzzooYeadhMtBuPUKRYAEwkVd.mefhGqvTkcrETnFSidhNngFjAYNV();
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void YtPyBCQxqyYSzFiSvpFtthKByQre(UXcYhloThkwhTGaKNWDgnIoRMtyH P_0)
	{
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			return;
		}
		using (eTRoskBdTVJraCzYFXNyrUomeHqE.Lock())
		{
			int count = YqtgmrqbQPIkQJUFMKiGJqhGNslH.Count;
			for (int i = 0; i < count; i++)
			{
				YqtgmrqbQPIkQJUFMKiGJqhGNslH[i].fjTIBpBcqDOXCISmvKbNXSkjvvux(P_0);
			}
		}
	}

	public void FxUZVZTmsPHdAmjAncfrdhvpHgkkA(bool P_0)
	{
		XEmZAIvhqsZTgpNqpBLgihEfgNsPA();
	}

	public void uSpAIgmdvPVFmEjMufooqHERiqRV(bool P_0)
	{
		if (gvbSoVtdUyQSsIkAVCaIaIdcpDZDA() < 0)
		{
			XEmZAIvhqsZTgpNqpBLgihEfgNsPA();
		}
	}

	private int gvbSoVtdUyQSsIkAVCaIaIdcpDZDA()
	{
		int pKNLyqAwojqSAqZLZvSJUycagVvV = PKNLyqAwojqSAqZLZvSJUycagVvV;
		if (BJkeDTpvKMtUyGqqYbRkHpVmhHYR.QbqauytRUvOCdsOckcSnCvrVAGyuA(jssTDwsNFlmgwNaDqygUqSPLaLlh.Mouse, out var pKNLyqAwojqSAqZLZvSJUycagVvV2))
		{
			PKNLyqAwojqSAqZLZvSJUycagVvV = pKNLyqAwojqSAqZLZvSJUycagVvV2;
		}
		else
		{
			PKNLyqAwojqSAqZLZvSJUycagVvV = ((VBqfSSvUBwCRtzUpeUWIfCWGfXliA.GzzDgJataKbslNPOWYXlGilxHlRw(xNEbcpbhBWdmPIJrWLnSEWFgzoVNb.QPUaezcvIOFNINPvJGGqEiWdEjuzB) != 0) ? 1 : 0);
		}
		return PKNLyqAwojqSAqZLZvSJUycagVvV - pKNLyqAwojqSAqZLZvSJUycagVvV;
	}

	private void orUMILCIqROwyBKfAAnTVqdZfYkj(bool P_0)
	{
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			XEmZAIvhqsZTgpNqpBLgihEfgNsPA();
		}
	}

	private void TNcWPrbERDuIJOeRurmdoMrAbUeN(bool P_0)
	{
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			XEmZAIvhqsZTgpNqpBLgihEfgNsPA();
		}
	}

	private void fVsAsvbqlzfDdjOSAWqIHuaIUAvyB(bool P_0)
	{
	}

	private void HbahpfcvOpPnYxZFkJkAOBvbitdv(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (eTRoskBdTVJraCzYFXNyrUomeHqE.Lock())
		{
			YqtgmrqbQPIkQJUFMKiGJqhGNslH[YqtgmrqbQPIkQJUFMKiGJqhGNslH.fixedUpdateSetIndex].nkoFaUglpzaIbCJqRMwvFmRNYaRR();
		}
	}

	private void WAOrbusfizshnpxwFmgJjjqHioOJ(UpdateLoopType P_0)
	{
		using (eTRoskBdTVJraCzYFXNyrUomeHqE.Lock())
		{
			YqtgmrqbQPIkQJUFMKiGJqhGNslH.Get(P_0).MqQjLCryqEPDlgJVxyKAVvUubRHs();
		}
	}

	private void XEmZAIvhqsZTgpNqpBLgihEfgNsPA()
	{
		using (eTRoskBdTVJraCzYFXNyrUomeHqE.Lock())
		{
			int count = YqtgmrqbQPIkQJUFMKiGJqhGNslH.Count;
			for (int i = 0; i < count; i++)
			{
				YqtgmrqbQPIkQJUFMKiGJqhGNslH[i].wSuERjejnukorMpeyvWlfiOlJujf();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		YqtgmrqbQPIkQJUFMKiGJqhGNslH.Current.cgXdoDGasbxLMLtXKouQWlVBfjiA(dataUpdater);
	}

	public void Clear()
	{
		XEmZAIvhqsZTgpNqpBLgihEfgNsPA();
	}

	private HardwareControllerMap_Game GURSYgsQJIKQUSvFwlKtfbGzZQCQ()
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
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			ReInput.ApplicationFocusChangedEvent -= orUMILCIqROwyBKfAAnTVqdZfYkj;
			ReInput.ApplicationPauseChangedEvent -= TNcWPrbERDuIJOeRurmdoMrAbUeN;
			ReInput.EditorPauseChangedEvent -= fVsAsvbqlzfDdjOSAWqIHuaIUAvyB;
			ReInput.TimeScalePauseChangedEvent -= HbahpfcvOpPnYxZFkJkAOBvbitdv;
			ReInput.UpdateEndedEvent -= WAOrbusfizshnpxwFmgJjjqHioOJ;
			if (P_0 && vOCRKtJjUKmNQpDZwbafkshoGskD)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
