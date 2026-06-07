using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class ZzroRHnTCwjEFrMxSBybEKjuOhMOA
{
	private class QvrxyXViMzrebLzzkQTZsibPISFj
	{
		[Flags]
		private enum qFaGUBOXHFDiDCfCcNdglQkUkotab : byte
		{
			None = 0,
			IsOnPositive = 1,
			IsOnNegative = 2,
			WasOnPrevPositive = 4,
			WasOnPrevNegative = 8
		}

		private qFaGUBOXHFDiDCfCcNdglQkUkotab JKEzaCzuCiDiBdJWTFLChngDpWCs;

		private uint uCaJuNgAJxjxculReoaBSslevBIhA;

		private bool vkzZJjbXuPkkfCLRegEzGhnMBtII;

		public bool cPUOgStSwkWPTpKEREPciSqQtYZf => vkzZJjbXuPkkfCLRegEzGhnMBtII;

		public ButtonStateFlags ObdiNvUeMqmcsyebdPCUEilScUugA(bool P_0)
		{
			ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
			if (P_0)
			{
				if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.IsOnPositive) != qFaGUBOXHFDiDCfCcNdglQkUkotab.None)
				{
					buttonStateFlags |= ButtonStateFlags.On;
					if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.WasOnPrevPositive) == 0)
					{
						buttonStateFlags |= ButtonStateFlags.Down;
					}
				}
				else if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.WasOnPrevPositive) != qFaGUBOXHFDiDCfCcNdglQkUkotab.None)
				{
					buttonStateFlags |= ButtonStateFlags.Up;
				}
			}
			else if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.IsOnNegative) != qFaGUBOXHFDiDCfCcNdglQkUkotab.None)
			{
				buttonStateFlags |= ButtonStateFlags.On;
				if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.WasOnPrevNegative) == 0)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.WasOnPrevNegative) != qFaGUBOXHFDiDCfCcNdglQkUkotab.None)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void FOtFtoFRLKpbzOUsFOtFYPOiOJTmA()
		{
			qFaGUBOXHFDiDCfCcNdglQkUkotab qFaGUBOXHFDiDCfCcNdglQkUkotab2 = qFaGUBOXHFDiDCfCcNdglQkUkotab.None;
			if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.IsOnPositive) != qFaGUBOXHFDiDCfCcNdglQkUkotab.None)
			{
				qFaGUBOXHFDiDCfCcNdglQkUkotab2 |= qFaGUBOXHFDiDCfCcNdglQkUkotab.WasOnPrevPositive;
			}
			if ((JKEzaCzuCiDiBdJWTFLChngDpWCs & qFaGUBOXHFDiDCfCcNdglQkUkotab.IsOnNegative) != qFaGUBOXHFDiDCfCcNdglQkUkotab.None)
			{
				qFaGUBOXHFDiDCfCcNdglQkUkotab2 |= qFaGUBOXHFDiDCfCcNdglQkUkotab.WasOnPrevNegative;
			}
			JKEzaCzuCiDiBdJWTFLChngDpWCs = qFaGUBOXHFDiDCfCcNdglQkUkotab2;
		}

		public void NIeMoVMMEwOdVFwDnWzaIHXTFuGK(uint P_0)
		{
			if (uCaJuNgAJxjxculReoaBSslevBIhA < P_0 - 1)
			{
				vkzZJjbXuPkkfCLRegEzGhnMBtII = false;
			}
		}

		public void nCupEzYdxzCvqgiNXQUxDushRHkF(bool P_0)
		{
			if (P_0)
			{
				JKEzaCzuCiDiBdJWTFLChngDpWCs |= qFaGUBOXHFDiDCfCcNdglQkUkotab.IsOnPositive;
			}
			else
			{
				JKEzaCzuCiDiBdJWTFLChngDpWCs |= qFaGUBOXHFDiDCfCcNdglQkUkotab.IsOnNegative;
			}
			uCaJuNgAJxjxculReoaBSslevBIhA = ReInput.currentFrame;
			if (!vkzZJjbXuPkkfCLRegEzGhnMBtII)
			{
				vkzZJjbXuPkkfCLRegEzGhnMBtII = true;
			}
		}

		public void BPOjfBMgJhaOVInUwNCpcroKJGrDb()
		{
			JKEzaCzuCiDiBdJWTFLChngDpWCs = qFaGUBOXHFDiDCfCcNdglQkUkotab.None;
			uCaJuNgAJxjxculReoaBSslevBIhA = 0u;
			vkzZJjbXuPkkfCLRegEzGhnMBtII = false;
		}
	}

	[Serializable]
	private sealed class XPtRPvJEuqUcpsJWwqtvMWSEidxn
	{
		public static readonly XPtRPvJEuqUcpsJWwqtvMWSEidxn _003C_003E9 = new XPtRPvJEuqUcpsJWwqtvMWSEidxn();

		public static Func<QvrxyXViMzrebLzzkQTZsibPISFj> _003C_003E9__19_0;

		internal ZzroRHnTCwjEFrMxSBybEKjuOhMOA DTZUAaGAlMlvJxBXtyafcdOuhCwS()
		{
			return new ZzroRHnTCwjEFrMxSBybEKjuOhMOA();
		}

		internal void xSaGUBafsvwIanbFllAwhTRaJtgUA(ZzroRHnTCwjEFrMxSBybEKjuOhMOA P_0)
		{
			P_0.AvYGesOLnccmxjzhsitEfclOBcOX();
		}

		internal QvrxyXViMzrebLzzkQTZsibPISFj OtaEVQuAfmGUVVaZDIkKjdBohfEL()
		{
			return new QvrxyXViMzrebLzzkQTZsibPISFj();
		}
	}

	private const int oMdtNgPzqZapivTIbDkGQnBMpJso = 20;

	private const int NgCGhegWrvBaMEFylJwSBJUzembv = 10;

	private static ObjectPool<ZzroRHnTCwjEFrMxSBybEKjuOhMOA> olqOlrmaKYnDbmUeVaoAMLKpQdun;

	private static ZzroRHnTCwjEFrMxSBybEKjuOhMOA[] yYOZPtjZiiSCVeHkolqnbPXvoKNI;

	private static int rFazLIgqhbVdWBjGZVlbxFseGGWB;

	public int VMrlwgBbLcWVkNMolCZVncXvCfoEA;

	private UpdateLoopDataSet<QvrxyXViMzrebLzzkQTZsibPISFj> aJFfQdrXKdAfNTCJxJHjwdkTkZyU;

	public bool syLkHeDsHdcOKOvEKpySOMVpLzIP
	{
		get
		{
			int count = aJFfQdrXKdAfNTCJxJHjwdkTkZyU.Count;
			for (int i = 0; i < count; i++)
			{
				if (aJFfQdrXKdAfNTCJxJHjwdkTkZyU[i].cPUOgStSwkWPTpKEREPciSqQtYZf)
				{
					return true;
				}
			}
			return false;
		}
	}

	static ZzroRHnTCwjEFrMxSBybEKjuOhMOA()
	{
		olqOlrmaKYnDbmUeVaoAMLKpQdun = new ObjectPool<ZzroRHnTCwjEFrMxSBybEKjuOhMOA>(20, XPtRPvJEuqUcpsJWwqtvMWSEidxn._003C_003E9.DTZUAaGAlMlvJxBXtyafcdOuhCwS, XPtRPvJEuqUcpsJWwqtvMWSEidxn._003C_003E9.xSaGUBafsvwIanbFllAwhTRaJtgUA);
		yYOZPtjZiiSCVeHkolqnbPXvoKNI = new ZzroRHnTCwjEFrMxSBybEKjuOhMOA[20];
	}

	public static void JISCwsGWvSIpUwYyRPDmAPXtgUdgb()
	{
		rFazLIgqhbVdWBjGZVlbxFseGGWB = 0;
		Array.Clear(yYOZPtjZiiSCVeHkolqnbPXvoKNI, 0, yYOZPtjZiiSCVeHkolqnbPXvoKNI.Length);
	}

	public static ZzroRHnTCwjEFrMxSBybEKjuOhMOA yneohKrjuhLvstuWGDSZvOUZvcrb(int P_0)
	{
		for (int i = 0; i < rFazLIgqhbVdWBjGZVlbxFseGGWB; i++)
		{
			if (yYOZPtjZiiSCVeHkolqnbPXvoKNI[i] != null && yYOZPtjZiiSCVeHkolqnbPXvoKNI[i].VMrlwgBbLcWVkNMolCZVncXvCfoEA == P_0)
			{
				return yYOZPtjZiiSCVeHkolqnbPXvoKNI[i];
			}
		}
		return null;
	}

	public static ZzroRHnTCwjEFrMxSBybEKjuOhMOA ccTFdPklJvLJIBWULrfrCLmKraqgB(int P_0)
	{
		ZzroRHnTCwjEFrMxSBybEKjuOhMOA zzroRHnTCwjEFrMxSBybEKjuOhMOA = yneohKrjuhLvstuWGDSZvOUZvcrb(P_0);
		if (zzroRHnTCwjEFrMxSBybEKjuOhMOA != null)
		{
			return zzroRHnTCwjEFrMxSBybEKjuOhMOA;
		}
		zzroRHnTCwjEFrMxSBybEKjuOhMOA = olqOlrmaKYnDbmUeVaoAMLKpQdun.Get();
		zzroRHnTCwjEFrMxSBybEKjuOhMOA.KJSxDlzkBaWbzTrCsOFXSIceojHR(P_0);
		zzroRHnTCwjEFrMxSBybEKjuOhMOA.aJFfQdrXKdAfNTCJxJHjwdkTkZyU.SetUpdateLoop(ReInput.currentUpdateLoop);
		nHtHBmgqnDekoHvYjTqsaSocYEhGA(zzroRHnTCwjEFrMxSBybEKjuOhMOA);
		return zzroRHnTCwjEFrMxSBybEKjuOhMOA;
	}

	public static void MeHCklKLabtaaxkpfOVQeioYIVetA(UpdateLoopType P_0)
	{
		for (int i = 0; i < rFazLIgqhbVdWBjGZVlbxFseGGWB; i++)
		{
			if (yYOZPtjZiiSCVeHkolqnbPXvoKNI[i] != null)
			{
				yYOZPtjZiiSCVeHkolqnbPXvoKNI[i].NunDwgkzDvWUxOqZfjAoOljjpEuu(P_0);
			}
		}
	}

	public static void ADyiJZsPmgJPSCHQyEkJHGtRfKfH(UpdateLoopType P_0, uint P_1)
	{
		for (int num = rFazLIgqhbVdWBjGZVlbxFseGGWB - 1; num >= 0; num--)
		{
			if (yYOZPtjZiiSCVeHkolqnbPXvoKNI[num] == null)
			{
				if (num == rFazLIgqhbVdWBjGZVlbxFseGGWB - 1)
				{
					rFazLIgqhbVdWBjGZVlbxFseGGWB--;
				}
			}
			else
			{
				yYOZPtjZiiSCVeHkolqnbPXvoKNI[num].vJkUPettjdmrpjwxEOUhHQuZoQMs(P_1);
				if (!yYOZPtjZiiSCVeHkolqnbPXvoKNI[num].syLkHeDsHdcOKOvEKpySOMVpLzIP)
				{
					gdRjLRhQtmVmqOgFqeZnAaUIaNwvb(num);
				}
			}
		}
	}

	private static void nHtHBmgqnDekoHvYjTqsaSocYEhGA(ZzroRHnTCwjEFrMxSBybEKjuOhMOA P_0)
	{
		int num = QhdBiEFqKelNkmeDUwNYuYEZNDmE();
		if (num < 0)
		{
			if (rFazLIgqhbVdWBjGZVlbxFseGGWB == yYOZPtjZiiSCVeHkolqnbPXvoKNI.Length)
			{
				ZzroRHnTCwjEFrMxSBybEKjuOhMOA[] array = yYOZPtjZiiSCVeHkolqnbPXvoKNI;
				yYOZPtjZiiSCVeHkolqnbPXvoKNI = new ZzroRHnTCwjEFrMxSBybEKjuOhMOA[yYOZPtjZiiSCVeHkolqnbPXvoKNI.Length + 10];
				Array.Copy(array, yYOZPtjZiiSCVeHkolqnbPXvoKNI, array.Length);
			}
			num = rFazLIgqhbVdWBjGZVlbxFseGGWB;
			rFazLIgqhbVdWBjGZVlbxFseGGWB++;
		}
		yYOZPtjZiiSCVeHkolqnbPXvoKNI[num] = P_0;
	}

	private static void gdRjLRhQtmVmqOgFqeZnAaUIaNwvb(int P_0)
	{
		if (P_0 >= 0 && P_0 < rFazLIgqhbVdWBjGZVlbxFseGGWB)
		{
			ZzroRHnTCwjEFrMxSBybEKjuOhMOA zzroRHnTCwjEFrMxSBybEKjuOhMOA = yYOZPtjZiiSCVeHkolqnbPXvoKNI[P_0];
			if (zzroRHnTCwjEFrMxSBybEKjuOhMOA != null)
			{
				olqOlrmaKYnDbmUeVaoAMLKpQdun.Return(zzroRHnTCwjEFrMxSBybEKjuOhMOA);
				yYOZPtjZiiSCVeHkolqnbPXvoKNI[P_0] = null;
			}
			if (P_0 == rFazLIgqhbVdWBjGZVlbxFseGGWB - 1)
			{
				rFazLIgqhbVdWBjGZVlbxFseGGWB--;
			}
		}
	}

	private static int QhdBiEFqKelNkmeDUwNYuYEZNDmE()
	{
		for (int i = 0; i < rFazLIgqhbVdWBjGZVlbxFseGGWB; i++)
		{
			if (yYOZPtjZiiSCVeHkolqnbPXvoKNI[i] == null)
			{
				return i;
			}
		}
		if (rFazLIgqhbVdWBjGZVlbxFseGGWB >= yYOZPtjZiiSCVeHkolqnbPXvoKNI.Length)
		{
			return -1;
		}
		int result = rFazLIgqhbVdWBjGZVlbxFseGGWB;
		rFazLIgqhbVdWBjGZVlbxFseGGWB++;
		return result;
	}

	public ButtonStateFlags qeLEUclMEnTOtnCXubYugVlpfvFEA(bool P_0)
	{
		return aJFfQdrXKdAfNTCJxJHjwdkTkZyU.Current.ObdiNvUeMqmcsyebdPCUEilScUugA(P_0);
	}

	public ZzroRHnTCwjEFrMxSBybEKjuOhMOA()
	{
		aJFfQdrXKdAfNTCJxJHjwdkTkZyU = new UpdateLoopDataSet<QvrxyXViMzrebLzzkQTZsibPISFj>(ReInput.UserData.ConfigVars.updateLoop, XPtRPvJEuqUcpsJWwqtvMWSEidxn._003C_003E9.OtaEVQuAfmGUVVaZDIkKjdBohfEL);
		AvYGesOLnccmxjzhsitEfclOBcOX();
	}

	public void NunDwgkzDvWUxOqZfjAoOljjpEuu(UpdateLoopType P_0)
	{
		aJFfQdrXKdAfNTCJxJHjwdkTkZyU.SetUpdateLoop(P_0);
		aJFfQdrXKdAfNTCJxJHjwdkTkZyU.Current.FOtFtoFRLKpbzOUsFOtFYPOiOJTmA();
	}

	public void vJkUPettjdmrpjwxEOUhHQuZoQMs(uint P_0)
	{
		aJFfQdrXKdAfNTCJxJHjwdkTkZyU.Current.NIeMoVMMEwOdVFwDnWzaIHXTFuGK(P_0);
	}

	public void LknvtRUkPwmUCxDPCkdMcGEUccSKA(UpdateLoopType P_0, bool P_1)
	{
		aJFfQdrXKdAfNTCJxJHjwdkTkZyU.Current.nCupEzYdxzCvqgiNXQUxDushRHkF(P_1);
	}

	private void KJSxDlzkBaWbzTrCsOFXSIceojHR(int P_0)
	{
		VMrlwgBbLcWVkNMolCZVncXvCfoEA = P_0;
	}

	private void AvYGesOLnccmxjzhsitEfclOBcOX()
	{
		VMrlwgBbLcWVkNMolCZVncXvCfoEA = -1;
		for (int i = 0; i < aJFfQdrXKdAfNTCJxJHjwdkTkZyU.Count; i++)
		{
			aJFfQdrXKdAfNTCJxJHjwdkTkZyU[i].BPOjfBMgJhaOVInUwNCpcroKJGrDb();
		}
	}
}
