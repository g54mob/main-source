using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class wumjSNCZpiDBQIOgHXuMVdOhecvz : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class fhGwsQDWqOMnVsYHVYsfnjIbhuin
	{
		private enum eNyjgCmzywPjNQmEvwjxDGlSbftd
		{
			None = 0,
			Down = 1,
			Up = 2,
			DownAndUp = 3
		}

		private const int qNYGekFzKzLqJCwxeBTKDYIYONtgb = 120;

		private const int AalbVcfgTnvvKpFYGziSwDQvWOUC = 2048;

		public readonly UpdateLoopType QZNBdeKdKLzNkFUDyVuGJybtQGAVA;

		public uint oYlfRWWtkPVQJFzfRnMAZxKFyeUJ;

		public uint uhVtVXLjKnYBGuaeBYsrLZJIFfLJ;

		public WkyBRDjfvsDqvYSqXuzqGIrXfcXBA sqiPzVbjIIrpynJWVeeXgSPmjHzbA;

		public float rKgjoCwkrXffqoLSWzloffzZtfFf;

		public float EImRIrtrdiviauLxlBmFPrRcPVLo;

		public float MxPFBuGhNiZtrKifdVqcDwKJkfzpA;

		public float wIIGxBhzUIQVlcBvSmVhFHfQjktZA;

		private bool[] akLAKBOSJQBBPKOWdcTyoExjMWXQ;

		private bool[] EzFFrjBGahIgTWNiTbZPyKDMdChVA;

		private qAlyKzqKdNoyfnnnocGIcxMqKFzg YpGbyWEVzwshtpjLqbgpcNcfOGczA;

		private uint gcELOrqUPJqEJlEUmMkrOHpWPjTN;

		private int THiJjUugoouLUlYJskENJnsZYLzt;

		private int mInWqAqSjdmGWshNyWeiBZHcLIQQ;

		private bool uQaKPIECKILjQjOzQsZFVUZbTcDv;

		public fhGwsQDWqOMnVsYHVYsfnjIbhuin(qAlyKzqKdNoyfnnnocGIcxMqKFzg P_0, UpdateLoopType P_1)
		{
			YpGbyWEVzwshtpjLqbgpcNcfOGczA = P_0;
			QZNBdeKdKLzNkFUDyVuGJybtQGAVA = P_1;
			akLAKBOSJQBBPKOWdcTyoExjMWXQ = new bool[5];
			EzFFrjBGahIgTWNiTbZPyKDMdChVA = new bool[5];
		}

		public void WPMFgHgcZATdStCTDwkDOgMQNezfb(URmGtSDrQYsPWSJBMHOWDKqVndjw P_0)
		{
			TPJwEKUYvbKuilSfeHMSGfDiTeNg tPJwEKUYvbKuilSfeHMSGfDiTeNg = P_0.bommhrdnXtBEnZGUyHkfXFZSlyeF;
			if (tPJwEKUYvbKuilSfeHMSGfDiTeNg != TPJwEKUYvbKuilSfeHMSGfDiTeNg.None)
			{
				if ((tPJwEKUYvbKuilSfeHMSGfDiTeNg & TPJwEKUYvbKuilSfeHMSGfDiTeNg.LeftButtonDown) != TPJwEKUYvbKuilSfeHMSGfDiTeNg.None || (tPJwEKUYvbKuilSfeHMSGfDiTeNg & TPJwEKUYvbKuilSfeHMSGfDiTeNg.RightButtonDown) != TPJwEKUYvbKuilSfeHMSGfDiTeNg.None)
				{
					IntPtr intPtr = JUcffnbUUIpygcbMFvGmfZKcYwgXc.qWjERgEBhkYCmLqVtYTSraemSGCkA();
					if (JUcffnbUUIpygcbMFvGmfZKcYwgXc.ZLZaGWbwzmpMIjVooHavHBoFscUrc() == intPtr && hKANpGblvbqvrYjDLnRiLBHURDyH(intPtr))
					{
						tPJwEKUYvbKuilSfeHMSGfDiTeNg &= ~TPJwEKUYvbKuilSfeHMSGfDiTeNg.LeftButtonDown;
						tPJwEKUYvbKuilSfeHMSGfDiTeNg &= ~TPJwEKUYvbKuilSfeHMSGfDiTeNg.RightButtonDown;
					}
				}
				int num = (int)tPJwEKUYvbKuilSfeHMSGfDiTeNg;
				if (YpGbyWEVzwshtpjLqbgpcNcfOGczA.fSMZKENxtokIgggiljHXYxhyoICK && YpGbyWEVzwshtpjLqbgpcNcfOGczA.unrTbgDHtVDKObImKFtKbDRMXRqtA)
				{
					liFahldrUWfcqaEDWijVIEqcRXwWb(1, num, 1, 2);
					liFahldrUWfcqaEDWijVIEqcRXwWb(0, num, 4, 8);
				}
				else
				{
					liFahldrUWfcqaEDWijVIEqcRXwWb(0, num, 1, 2);
					liFahldrUWfcqaEDWijVIEqcRXwWb(1, num, 4, 8);
				}
				liFahldrUWfcqaEDWijVIEqcRXwWb(2, num, 16, 32);
				liFahldrUWfcqaEDWijVIEqcRXwWb(3, num, 64, 128);
				liFahldrUWfcqaEDWijVIEqcRXwWb(4, num, 256, 512);
			}
			oYlfRWWtkPVQJFzfRnMAZxKFyeUJ = P_0.sPNtDXSQcHMCtdiHWXvFKWWXLdqg;
			uhVtVXLjKnYBGuaeBYsrLZJIFfLJ = P_0.YVSgDEBfyKgpACBPDYapyZTAkVkUb;
			WkyBRDjfvsDqvYSqXuzqGIrXfcXBA wkyBRDjfvsDqvYSqXuzqGIrXfcXBA = sqiPzVbjIIrpynJWVeeXgSPmjHzbA;
			sqiPzVbjIIrpynJWVeeXgSPmjHzbA = P_0.FYuaqyeSviEnpqjbDsnvbDWZtmAS;
			if (sqiPzVbjIIrpynJWVeeXgSPmjHzbA != wkyBRDjfvsDqvYSqXuzqGIrXfcXBA)
			{
				uQaKPIECKILjQjOzQsZFVUZbTcDv = false;
			}
			if (sqiPzVbjIIrpynJWVeeXgSPmjHzbA == WkyBRDjfvsDqvYSqXuzqGIrXfcXBA.MoveRelative)
			{
				rKgjoCwkrXffqoLSWzloffzZtfFf += (float)P_0.VOXxryqEQNoEHTqrmGRPfveThRUqA * 0.5f;
				EImRIrtrdiviauLxlBmFPrRcPVLo += (float)P_0.uZRiSRcABYKJHrRJZfBLWfHUYNGH * 0.5f * -1f;
			}
			else if ((sqiPzVbjIIrpynJWVeeXgSPmjHzbA & WkyBRDjfvsDqvYSqXuzqGIrXfcXBA.MoveAbsolute) != WkyBRDjfvsDqvYSqXuzqGIrXfcXBA.MoveRelative)
			{
				bool num2 = (sqiPzVbjIIrpynJWVeeXgSPmjHzbA & WkyBRDjfvsDqvYSqXuzqGIrXfcXBA.VirtualDesktop) != 0;
				int num3 = JUcffnbUUIpygcbMFvGmfZKcYwgXc.xlfJQzZKkhHqggssjdXKlqEkbjfcb(num2 ? tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.cdLFHcecsWmvZKEVlQZYMqwEVMao : tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.mjHLwkebXDbKRdvFqtkotfLRaDoI);
				int num4 = JUcffnbUUIpygcbMFvGmfZKcYwgXc.xlfJQzZKkhHqggssjdXKlqEkbjfcb(num2 ? tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.pnqbEGfCkEJDghtctLtSxQqcxGKi : tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.udrtsgvGsakhZJZMLKqdABDssxmO);
				int num5 = (int)((float)P_0.VOXxryqEQNoEHTqrmGRPfveThRUqA / 65535f * (float)num3);
				int num6 = (int)((65535f - (float)P_0.uZRiSRcABYKJHrRJZfBLWfHUYNGH) / 65535f * (float)num4);
				if (!uQaKPIECKILjQjOzQsZFVUZbTcDv)
				{
					THiJjUugoouLUlYJskENJnsZYLzt = num5;
					mInWqAqSjdmGWshNyWeiBZHcLIQQ = num6;
					uQaKPIECKILjQjOzQsZFVUZbTcDv = true;
				}
				rKgjoCwkrXffqoLSWzloffzZtfFf += num5 - THiJjUugoouLUlYJskENJnsZYLzt;
				EImRIrtrdiviauLxlBmFPrRcPVLo += num6 - mInWqAqSjdmGWshNyWeiBZHcLIQQ;
				THiJjUugoouLUlYJskENJnsZYLzt = num5;
				mInWqAqSjdmGWshNyWeiBZHcLIQQ = num6;
			}
			else
			{
				rKgjoCwkrXffqoLSWzloffzZtfFf = P_0.VOXxryqEQNoEHTqrmGRPfveThRUqA;
				EImRIrtrdiviauLxlBmFPrRcPVLo = P_0.uZRiSRcABYKJHrRJZfBLWfHUYNGH;
			}
			if (P_0.mAPuBtmlAyEmwjEKVMJGFaBoouqQ != 0)
			{
				int num7 = ((MathTools.Abs(P_0.mAPuBtmlAyEmwjEKVMJGFaBoouqQ) < 120) ? MathTools.Sign(P_0.mAPuBtmlAyEmwjEKVMJGFaBoouqQ) : (P_0.mAPuBtmlAyEmwjEKVMJGFaBoouqQ / 120));
				if ((tPJwEKUYvbKuilSfeHMSGfDiTeNg & TPJwEKUYvbKuilSfeHMSGfDiTeNg.MouseWheel) != TPJwEKUYvbKuilSfeHMSGfDiTeNg.None)
				{
					MxPFBuGhNiZtrKifdVqcDwKJkfzpA += num7;
				}
				else if ((tPJwEKUYvbKuilSfeHMSGfDiTeNg & (TPJwEKUYvbKuilSfeHMSGfDiTeNg)2048) != TPJwEKUYvbKuilSfeHMSGfDiTeNg.None)
				{
					wIIGxBhzUIQVlcBvSmVhFHfQjktZA += num7;
				}
			}
		}

		public void ZrNkGrSsCCJSHVHzvBVNEDdENeXFA(ControllerDataUpdater P_0)
		{
			float[] axisValues = P_0.axisValues;
			axisValues[0] = rKgjoCwkrXffqoLSWzloffzZtfFf;
			axisValues[1] = EImRIrtrdiviauLxlBmFPrRcPVLo;
			axisValues[2] = MxPFBuGhNiZtrKifdVqcDwKJkfzpA;
			axisValues[3] = wIIGxBhzUIQVlcBvSmVhFHfQjktZA;
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = akLAKBOSJQBBPKOWdcTyoExjMWXQ[i] || EzFFrjBGahIgTWNiTbZPyKDMdChVA[i];
			}
			ZtwCbefToDkyFABUrdCrbyacbmHmB();
		}

		public void zvgPEqksCTOuSEWyRcDHwZdYgIjf()
		{
			ZtwCbefToDkyFABUrdCrbyacbmHmB();
		}

		private void ZtwCbefToDkyFABUrdCrbyacbmHmB()
		{
			if (gcELOrqUPJqEJlEUmMkrOHpWPjTN != ReInput.absFrame)
			{
				LeNDQKUSMeeEIgThfWayareQouGf();
				gcELOrqUPJqEJlEUmMkrOHpWPjTN = ReInput.absFrame;
			}
		}

		public void ESWBCDbwzAuRLDNoJjZOsVDJmBSl()
		{
			rKgjoCwkrXffqoLSWzloffzZtfFf = 0f;
			EImRIrtrdiviauLxlBmFPrRcPVLo = 0f;
			uhVtVXLjKnYBGuaeBYsrLZJIFfLJ = 0u;
			sqiPzVbjIIrpynJWVeeXgSPmjHzbA = WkyBRDjfvsDqvYSqXuzqGIrXfcXBA.MoveRelative;
			MxPFBuGhNiZtrKifdVqcDwKJkfzpA = 0f;
			wIIGxBhzUIQVlcBvSmVhFHfQjktZA = 0f;
			Array.Clear(akLAKBOSJQBBPKOWdcTyoExjMWXQ, 0, 5);
			Array.Clear(EzFFrjBGahIgTWNiTbZPyKDMdChVA, 0, 5);
			uQaKPIECKILjQjOzQsZFVUZbTcDv = false;
		}

		public void LeNDQKUSMeeEIgThfWayareQouGf()
		{
			rKgjoCwkrXffqoLSWzloffzZtfFf = 0f;
			EImRIrtrdiviauLxlBmFPrRcPVLo = 0f;
			MxPFBuGhNiZtrKifdVqcDwKJkfzpA = 0f;
			wIIGxBhzUIQVlcBvSmVhFHfQjktZA = 0f;
			Array.Clear(EzFFrjBGahIgTWNiTbZPyKDMdChVA, 0, 5);
		}

		private void liFahldrUWfcqaEDWijVIEqcRXwWb(int P_0, int P_1, int P_2, int P_3)
		{
			eNyjgCmzywPjNQmEvwjxDGlSbftd eNyjgCmzywPjNQmEvwjxDGlSbftd2 = xdWtTLEABCSENbRnVBxZOSsjnvWC(P_1, P_2, P_3);
			if (akLAKBOSJQBBPKOWdcTyoExjMWXQ[P_0])
			{
				if (eNyjgCmzywPjNQmEvwjxDGlSbftd2 == eNyjgCmzywPjNQmEvwjxDGlSbftd.Up || eNyjgCmzywPjNQmEvwjxDGlSbftd2 == eNyjgCmzywPjNQmEvwjxDGlSbftd.DownAndUp)
				{
					akLAKBOSJQBBPKOWdcTyoExjMWXQ[P_0] = false;
				}
			}
			else if (eNyjgCmzywPjNQmEvwjxDGlSbftd2 == eNyjgCmzywPjNQmEvwjxDGlSbftd.Down)
			{
				akLAKBOSJQBBPKOWdcTyoExjMWXQ[P_0] = true;
			}
			if (eNyjgCmzywPjNQmEvwjxDGlSbftd2 == eNyjgCmzywPjNQmEvwjxDGlSbftd.Down || eNyjgCmzywPjNQmEvwjxDGlSbftd2 == eNyjgCmzywPjNQmEvwjxDGlSbftd.DownAndUp)
			{
				EzFFrjBGahIgTWNiTbZPyKDMdChVA[P_0] = true;
			}
		}

		private static eNyjgCmzywPjNQmEvwjxDGlSbftd xdWtTLEABCSENbRnVBxZOSsjnvWC(int P_0, int P_1, int P_2)
		{
			if ((P_0 & P_1) == P_1)
			{
				if ((P_0 & P_2) == P_2)
				{
					return eNyjgCmzywPjNQmEvwjxDGlSbftd.DownAndUp;
				}
				return eNyjgCmzywPjNQmEvwjxDGlSbftd.Down;
			}
			if ((P_0 & P_2) == P_2)
			{
				return eNyjgCmzywPjNQmEvwjxDGlSbftd.Up;
			}
			return eNyjgCmzywPjNQmEvwjxDGlSbftd.None;
		}

		private static bool hKANpGblvbqvrYjDLnRiLBHURDyH(IntPtr P_0)
		{
			if (JUcffnbUUIpygcbMFvGmfZKcYwgXc.HcstHvuGPDSHuxjEFFjuKGoQGwKR(0u, false, 0u) == IntPtr.Zero)
			{
				return false;
			}
			if (!JUcffnbUUIpygcbMFvGmfZKcYwgXc.cfchARUgvyBGaCyICVanuYilfDpLA(P_0, out var zSIAQexwslkITPqvFeWWApalwIPF2))
			{
				return false;
			}
			if (!JUcffnbUUIpygcbMFvGmfZKcYwgXc.seLObhsqvGdwYVbHjXfRsZVjPeAB(out var zSIAQexwslkITPqvFeWWApalwIPF3))
			{
				return false;
			}
			if (!JUcffnbUUIpygcbMFvGmfZKcYwgXc.fsOeQDdacFvrXxdvKMEdvCLKcTZk(P_0, out var yDBkBjLxivCYkZnryBDfTzAZbUcO2))
			{
				return false;
			}
			int num = zSIAQexwslkITPqvFeWWApalwIPF3.stybIYcTRZtKomEJzyONREoNqQIL - zSIAQexwslkITPqvFeWWApalwIPF2.stybIYcTRZtKomEJzyONREoNqQIL;
			int num2 = zSIAQexwslkITPqvFeWWApalwIPF3.HvwgylgWBnZxirTsNKlfboGLcUEU - zSIAQexwslkITPqvFeWWApalwIPF2.HvwgylgWBnZxirTsNKlfboGLcUEU;
			if (num >= 0 && num2 >= 0 && num <= yDBkBjLxivCYkZnryBDfTzAZbUcO2.EfGGhNASvKRRmBtpSrpCzauTOqzN && num2 <= yDBkBjLxivCYkZnryBDfTzAZbUcO2.XjesyJMwDKQlxDGAsBhYcnOmZjbpA)
			{
				return false;
			}
			if (!JUcffnbUUIpygcbMFvGmfZKcYwgXc.PekGneaqwjeBPFGiHpacyMvOdgvJb(P_0, out var yDBkBjLxivCYkZnryBDfTzAZbUcO3))
			{
				return false;
			}
			if (zSIAQexwslkITPqvFeWWApalwIPF3.stybIYcTRZtKomEJzyONREoNqQIL >= yDBkBjLxivCYkZnryBDfTzAZbUcO3.drteaTIrwdAzyiQjzKvDjKanNYecA && zSIAQexwslkITPqvFeWWApalwIPF3.stybIYcTRZtKomEJzyONREoNqQIL <= yDBkBjLxivCYkZnryBDfTzAZbUcO3.EfGGhNASvKRRmBtpSrpCzauTOqzN && zSIAQexwslkITPqvFeWWApalwIPF3.HvwgylgWBnZxirTsNKlfboGLcUEU >= yDBkBjLxivCYkZnryBDfTzAZbUcO3.zZIDwfeiwvKMJCrZjUqZjgAZgNLbc)
			{
				return zSIAQexwslkITPqvFeWWApalwIPF3.HvwgylgWBnZxirTsNKlfboGLcUEU <= yDBkBjLxivCYkZnryBDfTzAZbUcO3.XjesyJMwDKQlxDGAsBhYcnOmZjbpA;
			}
			return false;
		}
	}

	private class qAlyKzqKdNoyfnnnocGIcxMqKFzg
	{
		private bool MRHBlBKqBjRWmGlsHKofEmvDQOhRe;

		private bool COQNXHWkfpECJzchmejcNuVuGTsW;

		private bool qVVgEOYXeSsErtRlvsCAtmNoxvcU;

		private int FhQJXeIPlEWySLczhZVSbFOFVoSk = 10;

		private readonly float midcCvUJTidTttzrjtOnorTPIlFD;

		private double WlfUFjUFZnTheNiPjuSqGEGXCozIA;

		public bool fSMZKENxtokIgggiljHXYxhyoICK
		{
			get
			{
				return MRHBlBKqBjRWmGlsHKofEmvDQOhRe;
			}
			set
			{
				if (flag != MRHBlBKqBjRWmGlsHKofEmvDQOhRe)
				{
					UOzSUyoJbWZztXErczcJyDfBAfLm(true);
				}
			}
		}

		public bool unrTbgDHtVDKObImKFtKbDRMXRqtA => COQNXHWkfpECJzchmejcNuVuGTsW;

		public bool gNFtlawmkYNHBTzkRrWlKioqWTGv
		{
			get
			{
				return qVVgEOYXeSsErtRlvsCAtmNoxvcU;
			}
			set
			{
				if (qVVgEOYXeSsErtRlvsCAtmNoxvcU != flag)
				{
					qVVgEOYXeSsErtRlvsCAtmNoxvcU = flag;
					UOzSUyoJbWZztXErczcJyDfBAfLm(true);
				}
			}
		}

		public int DQwfvpbzgGPeywYrZsQvbbKZbgibA => FhQJXeIPlEWySLczhZVSbFOFVoSk;

		public qAlyKzqKdNoyfnnnocGIcxMqKFzg(bool P_0, float P_1)
		{
			MRHBlBKqBjRWmGlsHKofEmvDQOhRe = P_0;
			midcCvUJTidTttzrjtOnorTPIlFD = P_1;
			UOzSUyoJbWZztXErczcJyDfBAfLm(false);
		}

		public void mkKkcEAWHYwCrhuliojYgxGiHVLe()
		{
			if (MRHBlBKqBjRWmGlsHKofEmvDQOhRe && !(ReInput.realTime < WlfUFjUFZnTheNiPjuSqGEGXCozIA))
			{
				UOzSUyoJbWZztXErczcJyDfBAfLm(true);
			}
		}

		private void UOzSUyoJbWZztXErczcJyDfBAfLm(bool P_0)
		{
			if (qVVgEOYXeSsErtRlvsCAtmNoxvcU)
			{
				JUcffnbUUIpygcbMFvGmfZKcYwgXc.QgQggraLMtJvAsuywvAqnyHxyrWLA(112u, 0u, ref FhQJXeIPlEWySLczhZVSbFOFVoSk, 0u);
			}
			COQNXHWkfpECJzchmejcNuVuGTsW = JUcffnbUUIpygcbMFvGmfZKcYwgXc.xlfJQzZKkhHqggssjdXKlqEkbjfcb(tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.xrAqerQPtMRjbqzzeBItZDIpjGgY) > 0;
			if (P_0)
			{
				WlfUFjUFZnTheNiPjuSqGEGXCozIA = ReInput.realTime + (double)midcCvUJTidTttzrjtOnorTPIlFD;
			}
		}
	}

	private const int TpUxKxNRgBtucIHFxEsiuOdrWjSN = 5;

	private const int HbcZOWTcTTKNQShnKFMWJxIKZCsi = 4;

	private readonly SpinLock chyXBuUrPRqquaNSbBmqdtmwmwIs = new SpinLock();

	private UpdateLoopDataSet<fhGwsQDWqOMnVsYHVYsfnjIbhuin> WjmiiQXEqrqyJYTDToGCRdyFgobBA;

	private HardwareControllerMap_Game GBSJgzfHmliapuSAEbGNDkBVdNB;

	private qAlyKzqKdNoyfnnnocGIcxMqKFzg lpWDbECIIlDQuOtnELfCXDaeIARkA;

	private bool wgYinJNXKiAxuzCIygDMbMRNCObvA;

	private int ZpsuHMedVvGUaBIiuLfjfDyHgiruA;

	private bool YOyrPELCfXzLgqkpTzSqpQdiWEAh;

	private const bool dolahdrJKlYgGVDkbtdXpLvjEaPKA = true;

	private const float mugKUMpkladCchWWMRvWFuJOvQfx = 2f;

	private bool ypVqmObiUDxyrnDiXDWRcpSXQvqe;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return YOyrPELCfXzLgqkpTzSqpQdiWEAh;
		}
		set
		{
			if (YOyrPELCfXzLgqkpTzSqpQdiWEAh != value)
			{
				YOyrPELCfXzLgqkpTzSqpQdiWEAh = value;
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
			if (GBSJgzfHmliapuSAEbGNDkBVdNB == null)
			{
				GBSJgzfHmliapuSAEbGNDkBVdNB = kYsFXcYNnsEGwAFwMKpWdOdRAjVPA();
			}
			return GBSJgzfHmliapuSAEbGNDkBVdNB;
		}
	}

	int IUnifiedMouseSource.buttonCount => 5;

	int IUnifiedMouseSource.axisCount => 4;

	Vector2 IUnifiedMouseSource.mousePosition
	{
		get
		{
			if (!YOyrPELCfXzLgqkpTzSqpQdiWEAh)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	Controller.Extension IUnifiedMouseSource.controllerExtension => null;

	public wumjSNCZpiDBQIOgHXuMVdOhecvz(UpdateLoopSetting P_0)
	{
		ZYgxknDBkeJlKZbCXFxhZoNSTsgw();
		lpWDbECIIlDQuOtnELfCXDaeIARkA = new qAlyKzqKdNoyfnnnocGIcxMqKFzg(true, 2f);
		WjmiiQXEqrqyJYTDToGCRdyFgobBA = new UpdateLoopDataSet<fhGwsQDWqOMnVsYHVYsfnjIbhuin>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				WjmiiQXEqrqyJYTDToGCRdyFgobBA[i] = new fhGwsQDWqOMnVsYHVYsfnjIbhuin(lpWDbECIIlDQuOtnELfCXDaeIARkA, list[i]);
			}
		}
		wgYinJNXKiAxuzCIygDMbMRNCObvA = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += jLEkbEZZiWFtIMkzrGiqdhkpRQJkA;
		ReInput.ApplicationPauseChangedEvent += HsZomUSreAhIKdlvaGAxJSPuxlvm;
		Rewired_002EInterfaces_002EIGetSetEnabled_002Eenabled = true;
		ReInput.EditorPauseChangedEvent += eRKGaxFBCQReEXTgjccfQArprUSgA;
		ReInput.TimeScalePauseChangedEvent += QDQPPrJMmCLqlheqyuzVAvwIGeHg;
		ReInput.UpdateEndedEvent += LMvEsIhcZbkecjZtZGTKIMvUFnxxA;
	}

	public void skwNgQPHpQzSxlaATGqBBCDfxaVH(UpdateLoopType P_0)
	{
		WjmiiQXEqrqyJYTDToGCRdyFgobBA.SetUpdateLoop(P_0);
		lpWDbECIIlDQuOtnELfCXDaeIARkA.mkKkcEAWHYwCrhuliojYgxGiHVLe();
		wgYinJNXKiAxuzCIygDMbMRNCObvA = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	public void UmTHxiXerFOeAuDgvDbVKjeaRIaV(URmGtSDrQYsPWSJBMHOWDKqVndjw P_0)
	{
		if (!wgYinJNXKiAxuzCIygDMbMRNCObvA)
		{
			return;
		}
		using (chyXBuUrPRqquaNSbBmqdtmwmwIs.Lock())
		{
			int count = WjmiiQXEqrqyJYTDToGCRdyFgobBA.Count;
			for (int i = 0; i < count; i++)
			{
				WjmiiQXEqrqyJYTDToGCRdyFgobBA[i].WPMFgHgcZATdStCTDwkDOgMQNezfb(P_0);
			}
		}
	}

	public void wGQMAuMWysQFWAyTBFBCQJQdNhVN(bool P_0)
	{
		vbqNgJSTBNNIoWXSBjqZteFPESwcA();
	}

	public void cxJYvOAvssABidjLnGGCUgIvwDzq(bool P_0)
	{
		if (ZYgxknDBkeJlKZbCXFxhZoNSTsgw() < 0)
		{
			vbqNgJSTBNNIoWXSBjqZteFPESwcA();
		}
	}

	private int ZYgxknDBkeJlKZbCXFxhZoNSTsgw()
	{
		int zpsuHMedVvGUaBIiuLfjfDyHgiruA = ZpsuHMedVvGUaBIiuLfjfDyHgiruA;
		if (BqakktYRwNvnDKTTjDQXbTstkBmA.aFsxvkDaLokAiLPHthmvqQwtFeRFA(hEwPeXHtAVoNjNQkbBuyQaRHvVmt.Mouse, out var zpsuHMedVvGUaBIiuLfjfDyHgiruA2))
		{
			ZpsuHMedVvGUaBIiuLfjfDyHgiruA = zpsuHMedVvGUaBIiuLfjfDyHgiruA2;
		}
		else
		{
			ZpsuHMedVvGUaBIiuLfjfDyHgiruA = ((JUcffnbUUIpygcbMFvGmfZKcYwgXc.xlfJQzZKkhHqggssjdXKlqEkbjfcb(tYCgPSGGUaNDSOBCZZnaWyTzrBYdA.iTNKqjztkzlkEQXMRBIFxnCsvAG) != 0) ? 1 : 0);
		}
		return ZpsuHMedVvGUaBIiuLfjfDyHgiruA - zpsuHMedVvGUaBIiuLfjfDyHgiruA;
	}

	private void jLEkbEZZiWFtIMkzrGiqdhkpRQJkA(bool P_0)
	{
		wgYinJNXKiAxuzCIygDMbMRNCObvA = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!P_0 && !wgYinJNXKiAxuzCIygDMbMRNCObvA)
		{
			vbqNgJSTBNNIoWXSBjqZteFPESwcA();
		}
	}

	private void HsZomUSreAhIKdlvaGAxJSPuxlvm(bool P_0)
	{
		wgYinJNXKiAxuzCIygDMbMRNCObvA = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!wgYinJNXKiAxuzCIygDMbMRNCObvA)
		{
			vbqNgJSTBNNIoWXSBjqZteFPESwcA();
		}
	}

	private void eRKGaxFBCQReEXTgjccfQArprUSgA(bool P_0)
	{
	}

	private void QDQPPrJMmCLqlheqyuzVAvwIGeHg(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		wgYinJNXKiAxuzCIygDMbMRNCObvA = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (chyXBuUrPRqquaNSbBmqdtmwmwIs.Lock())
		{
			WjmiiQXEqrqyJYTDToGCRdyFgobBA[WjmiiQXEqrqyJYTDToGCRdyFgobBA.fixedUpdateSetIndex].LeNDQKUSMeeEIgThfWayareQouGf();
		}
	}

	private void LMvEsIhcZbkecjZtZGTKIMvUFnxxA(UpdateLoopType P_0)
	{
		using (chyXBuUrPRqquaNSbBmqdtmwmwIs.Lock())
		{
			WjmiiQXEqrqyJYTDToGCRdyFgobBA.Get(P_0).zvgPEqksCTOuSEWyRcDHwZdYgIjf();
		}
	}

	private void vbqNgJSTBNNIoWXSBjqZteFPESwcA()
	{
		using (chyXBuUrPRqquaNSbBmqdtmwmwIs.Lock())
		{
			int count = WjmiiQXEqrqyJYTDToGCRdyFgobBA.Count;
			for (int i = 0; i < count; i++)
			{
				WjmiiQXEqrqyJYTDToGCRdyFgobBA[i].ESWBCDbwzAuRLDNoJjZOsVDJmBSl();
			}
		}
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		WjmiiQXEqrqyJYTDToGCRdyFgobBA.Current.ZrNkGrSsCCJSHVHzvBVNEDdENeXFA(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		vbqNgJSTBNNIoWXSBjqZteFPESwcA();
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private HardwareControllerMap_Game kYsFXcYNnsEGwAFwMKpWdOdRAjVPA()
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
		HardwareJoystickMap.CompoundElement[] array8 = new HardwareJoystickMap.CompoundElement[Consts.unifiedMouseCompoundElements_readOnly.Count];
		for (int m = 0; m < Consts.unifiedMouseCompoundElements_readOnly.Count; m++)
		{
			array8[m] = new HardwareJoystickMap.CompoundElement(Consts.unifiedMouseCompoundElements_readOnly[m]);
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, array8);
	}

	public void Dispose()
	{
		ZlQtjVTMnUudqnlywkOYduDulDew(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void HwzsQUcQUmEEFEEAWLHavjWmEbIP()
	{
		try
		{
			ZlQtjVTMnUudqnlywkOYduDulDew(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void ZlQtjVTMnUudqnlywkOYduDulDew(bool P_0)
	{
		if (!ypVqmObiUDxyrnDiXDWRcpSXQvqe)
		{
			ReInput.ApplicationFocusChangedEvent -= jLEkbEZZiWFtIMkzrGiqdhkpRQJkA;
			ReInput.ApplicationPauseChangedEvent -= HsZomUSreAhIKdlvaGAxJSPuxlvm;
			ReInput.EditorPauseChangedEvent -= eRKGaxFBCQReEXTgjccfQArprUSgA;
			ReInput.TimeScalePauseChangedEvent -= QDQPPrJMmCLqlheqyuzVAvwIGeHg;
			ReInput.UpdateEndedEvent -= LMvEsIhcZbkecjZtZGTKIMvUFnxxA;
			if (P_0 && YOyrPELCfXzLgqkpTzSqpQdiWEAh)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			ypVqmObiUDxyrnDiXDWRcpSXQvqe = true;
		}
	}
}
