using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class xiZMFJaKprrLjxtEMQahBCVGvYER
{
	private class uOPnCZIvbqmCBFCYoATBhCVbavZr
	{
		[Flags]
		private enum CYOASRcBkMednnvbwodkMXMcVHpiA : byte
		{
			None = 0,
			IsOnPositive = 1,
			IsOnNegative = 2,
			WasOnPrevPositive = 4,
			WasOnPrevNegative = 8
		}

		private CYOASRcBkMednnvbwodkMXMcVHpiA zqlmAmRAWxhuzRtcELHICvssAvpy;

		private uint ZDIZDZDJyzFAudTMXGMNdVuktwqCA;

		private bool OPjUMjHhYjyuyHXqezxOrhROiazp;

		public bool iAlCwWiwKREIQsPjUCncdzPFQdCgA => OPjUMjHhYjyuyHXqezxOrhROiazp;

		public ButtonStateFlags KOonZeRJAKnjZeFdpIRXKghDSnUW(bool P_0)
		{
			ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
			if (P_0)
			{
				if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.IsOnPositive) != CYOASRcBkMednnvbwodkMXMcVHpiA.None)
				{
					buttonStateFlags |= ButtonStateFlags.On;
					if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.WasOnPrevPositive) == 0)
					{
						buttonStateFlags |= ButtonStateFlags.Down;
					}
				}
				else if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.WasOnPrevPositive) != CYOASRcBkMednnvbwodkMXMcVHpiA.None)
				{
					buttonStateFlags |= ButtonStateFlags.Up;
				}
			}
			else if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.IsOnNegative) != CYOASRcBkMednnvbwodkMXMcVHpiA.None)
			{
				buttonStateFlags |= ButtonStateFlags.On;
				if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.WasOnPrevNegative) == 0)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.WasOnPrevNegative) != CYOASRcBkMednnvbwodkMXMcVHpiA.None)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void sOLNzBCCbZmFXkMugfndpShqgrUP()
		{
			CYOASRcBkMednnvbwodkMXMcVHpiA cYOASRcBkMednnvbwodkMXMcVHpiA = CYOASRcBkMednnvbwodkMXMcVHpiA.None;
			if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.IsOnPositive) != CYOASRcBkMednnvbwodkMXMcVHpiA.None)
			{
				cYOASRcBkMednnvbwodkMXMcVHpiA |= CYOASRcBkMednnvbwodkMXMcVHpiA.WasOnPrevPositive;
			}
			if ((zqlmAmRAWxhuzRtcELHICvssAvpy & CYOASRcBkMednnvbwodkMXMcVHpiA.IsOnNegative) != CYOASRcBkMednnvbwodkMXMcVHpiA.None)
			{
				cYOASRcBkMednnvbwodkMXMcVHpiA |= CYOASRcBkMednnvbwodkMXMcVHpiA.WasOnPrevNegative;
			}
			zqlmAmRAWxhuzRtcELHICvssAvpy = cYOASRcBkMednnvbwodkMXMcVHpiA;
		}

		public void OJwRTvWKOprkrbxNjAvuBwrxssUE(uint P_0)
		{
			if (ZDIZDZDJyzFAudTMXGMNdVuktwqCA < P_0 - 1)
			{
				OPjUMjHhYjyuyHXqezxOrhROiazp = false;
			}
		}

		public void AOPGPeIJDRnFsspPPHHIIysuRBXlA(bool P_0)
		{
			if (P_0)
			{
				zqlmAmRAWxhuzRtcELHICvssAvpy |= CYOASRcBkMednnvbwodkMXMcVHpiA.IsOnPositive;
			}
			else
			{
				zqlmAmRAWxhuzRtcELHICvssAvpy |= CYOASRcBkMednnvbwodkMXMcVHpiA.IsOnNegative;
			}
			ZDIZDZDJyzFAudTMXGMNdVuktwqCA = ReInput.currentFrame;
			if (!OPjUMjHhYjyuyHXqezxOrhROiazp)
			{
				OPjUMjHhYjyuyHXqezxOrhROiazp = true;
			}
		}

		public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			zqlmAmRAWxhuzRtcELHICvssAvpy = CYOASRcBkMednnvbwodkMXMcVHpiA.None;
			ZDIZDZDJyzFAudTMXGMNdVuktwqCA = 0u;
			OPjUMjHhYjyuyHXqezxOrhROiazp = false;
		}
	}

	[Serializable]
	private sealed class vYVLBfKeDfctVsTbsFrtdXemlYxuA
	{
		public static readonly vYVLBfKeDfctVsTbsFrtdXemlYxuA _003C_003E9 = new vYVLBfKeDfctVsTbsFrtdXemlYxuA();

		public static Func<uOPnCZIvbqmCBFCYoATBhCVbavZr> _003C_003E9__19_0;

		internal xiZMFJaKprrLjxtEMQahBCVGvYER ZkyttlNTobFuESPsxTvfTcpNpBEg()
		{
			return new xiZMFJaKprrLjxtEMQahBCVGvYER();
		}

		internal void eLtgUzagSEDgCYbYYfvIVqsIerwu(xiZMFJaKprrLjxtEMQahBCVGvYER P_0)
		{
			P_0.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
		}

		internal uOPnCZIvbqmCBFCYoATBhCVbavZr PxGkUjUIbqiePBNIQlglmtdlgXGj()
		{
			return new uOPnCZIvbqmCBFCYoATBhCVbavZr();
		}
	}

	private const int weWFGFBDcTYrZqaxvaKeDcaenXepB = 20;

	private const int lwPlEUhGOMlOMvqritWWgejKXwat = 10;

	private static ObjectPool<xiZMFJaKprrLjxtEMQahBCVGvYER> IKtDdHGSViTdQEBchzDZHERSGXbX;

	private static xiZMFJaKprrLjxtEMQahBCVGvYER[] UHwrbFTHFncUvgjnDmcQAacqOIpEb;

	private static int HOSqtHSrEMHBVLolGGBpCiCZPChNA;

	public int HeLFpgOjUAcSLHCwLbTeOOxKxYGB;

	private UpdateLoopDataSet<uOPnCZIvbqmCBFCYoATBhCVbavZr> OILFqKTJosIuEQvfAMAgFuBFIsys;

	public bool iAlCwWiwKREIQsPjUCncdzPFQdCgA
	{
		get
		{
			int count = OILFqKTJosIuEQvfAMAgFuBFIsys.Count;
			for (int i = 0; i < count; i++)
			{
				if (OILFqKTJosIuEQvfAMAgFuBFIsys[i].iAlCwWiwKREIQsPjUCncdzPFQdCgA)
				{
					return true;
				}
			}
			return false;
		}
	}

	static xiZMFJaKprrLjxtEMQahBCVGvYER()
	{
		IKtDdHGSViTdQEBchzDZHERSGXbX = new ObjectPool<xiZMFJaKprrLjxtEMQahBCVGvYER>(20, vYVLBfKeDfctVsTbsFrtdXemlYxuA._003C_003E9.ZkyttlNTobFuESPsxTvfTcpNpBEg, vYVLBfKeDfctVsTbsFrtdXemlYxuA._003C_003E9.eLtgUzagSEDgCYbYYfvIVqsIerwu);
		UHwrbFTHFncUvgjnDmcQAacqOIpEb = new xiZMFJaKprrLjxtEMQahBCVGvYER[20];
	}

	public static void ooNidbhWzBcZZJydutNALDEuSswc()
	{
		HOSqtHSrEMHBVLolGGBpCiCZPChNA = 0;
		Array.Clear(UHwrbFTHFncUvgjnDmcQAacqOIpEb, 0, UHwrbFTHFncUvgjnDmcQAacqOIpEb.Length);
	}

	public static xiZMFJaKprrLjxtEMQahBCVGvYER ogSoWIxzvUDUVzjUjkNpiqjoeECDA(int P_0)
	{
		for (int i = 0; i < HOSqtHSrEMHBVLolGGBpCiCZPChNA; i++)
		{
			if (UHwrbFTHFncUvgjnDmcQAacqOIpEb[i] != null && UHwrbFTHFncUvgjnDmcQAacqOIpEb[i].HeLFpgOjUAcSLHCwLbTeOOxKxYGB == P_0)
			{
				return UHwrbFTHFncUvgjnDmcQAacqOIpEb[i];
			}
		}
		return null;
	}

	public static xiZMFJaKprrLjxtEMQahBCVGvYER jodeWACReFvZpoQyUvqnhZRwyafZ(int P_0)
	{
		xiZMFJaKprrLjxtEMQahBCVGvYER xiZMFJaKprrLjxtEMQahBCVGvYER2 = ogSoWIxzvUDUVzjUjkNpiqjoeECDA(P_0);
		if (xiZMFJaKprrLjxtEMQahBCVGvYER2 != null)
		{
			return xiZMFJaKprrLjxtEMQahBCVGvYER2;
		}
		xiZMFJaKprrLjxtEMQahBCVGvYER2 = IKtDdHGSViTdQEBchzDZHERSGXbX.Get();
		xiZMFJaKprrLjxtEMQahBCVGvYER2.BTTeANcpZxbIKMGHTZlOfKJhVHSmA(P_0);
		xiZMFJaKprrLjxtEMQahBCVGvYER2.OILFqKTJosIuEQvfAMAgFuBFIsys.SetUpdateLoop(ReInput.currentUpdateLoop);
		LvKcpUAPbSNlBKykQtLyvsMNHnkSA(xiZMFJaKprrLjxtEMQahBCVGvYER2);
		return xiZMFJaKprrLjxtEMQahBCVGvYER2;
	}

	public static void qnNBomBkJGYbSCteHxwELVAYlhvy(UpdateLoopType P_0)
	{
		for (int i = 0; i < HOSqtHSrEMHBVLolGGBpCiCZPChNA; i++)
		{
			if (UHwrbFTHFncUvgjnDmcQAacqOIpEb[i] != null)
			{
				UHwrbFTHFncUvgjnDmcQAacqOIpEb[i].sOLNzBCCbZmFXkMugfndpShqgrUP(P_0);
			}
		}
	}

	public static void OJwRTvWKOprkrbxNjAvuBwrxssUE(UpdateLoopType P_0, uint P_1)
	{
		for (int num = HOSqtHSrEMHBVLolGGBpCiCZPChNA - 1; num >= 0; num--)
		{
			if (UHwrbFTHFncUvgjnDmcQAacqOIpEb[num] == null)
			{
				if (num == HOSqtHSrEMHBVLolGGBpCiCZPChNA - 1)
				{
					HOSqtHSrEMHBVLolGGBpCiCZPChNA--;
				}
			}
			else
			{
				UHwrbFTHFncUvgjnDmcQAacqOIpEb[num].OJwRTvWKOprkrbxNjAvuBwrxssUE(P_1);
				if (!UHwrbFTHFncUvgjnDmcQAacqOIpEb[num].iAlCwWiwKREIQsPjUCncdzPFQdCgA)
				{
					XmaMoQJyxWKtOgbUyUCahKExsBqg(num);
				}
			}
		}
	}

	private static void LvKcpUAPbSNlBKykQtLyvsMNHnkSA(xiZMFJaKprrLjxtEMQahBCVGvYER P_0)
	{
		int num = NTatNTUoArFNZhXiEdnGimNZEiRG();
		if (num < 0)
		{
			if (HOSqtHSrEMHBVLolGGBpCiCZPChNA == UHwrbFTHFncUvgjnDmcQAacqOIpEb.Length)
			{
				xiZMFJaKprrLjxtEMQahBCVGvYER[] uHwrbFTHFncUvgjnDmcQAacqOIpEb = UHwrbFTHFncUvgjnDmcQAacqOIpEb;
				UHwrbFTHFncUvgjnDmcQAacqOIpEb = new xiZMFJaKprrLjxtEMQahBCVGvYER[UHwrbFTHFncUvgjnDmcQAacqOIpEb.Length + 10];
				Array.Copy(uHwrbFTHFncUvgjnDmcQAacqOIpEb, UHwrbFTHFncUvgjnDmcQAacqOIpEb, uHwrbFTHFncUvgjnDmcQAacqOIpEb.Length);
			}
			num = HOSqtHSrEMHBVLolGGBpCiCZPChNA;
			HOSqtHSrEMHBVLolGGBpCiCZPChNA++;
		}
		UHwrbFTHFncUvgjnDmcQAacqOIpEb[num] = P_0;
	}

	private static void XmaMoQJyxWKtOgbUyUCahKExsBqg(int P_0)
	{
		if (P_0 >= 0 && P_0 < HOSqtHSrEMHBVLolGGBpCiCZPChNA)
		{
			xiZMFJaKprrLjxtEMQahBCVGvYER xiZMFJaKprrLjxtEMQahBCVGvYER2 = UHwrbFTHFncUvgjnDmcQAacqOIpEb[P_0];
			if (xiZMFJaKprrLjxtEMQahBCVGvYER2 != null)
			{
				IKtDdHGSViTdQEBchzDZHERSGXbX.Return(xiZMFJaKprrLjxtEMQahBCVGvYER2);
				UHwrbFTHFncUvgjnDmcQAacqOIpEb[P_0] = null;
			}
			if (P_0 == HOSqtHSrEMHBVLolGGBpCiCZPChNA - 1)
			{
				HOSqtHSrEMHBVLolGGBpCiCZPChNA--;
			}
		}
	}

	private static int NTatNTUoArFNZhXiEdnGimNZEiRG()
	{
		for (int i = 0; i < HOSqtHSrEMHBVLolGGBpCiCZPChNA; i++)
		{
			if (UHwrbFTHFncUvgjnDmcQAacqOIpEb[i] == null)
			{
				return i;
			}
		}
		if (HOSqtHSrEMHBVLolGGBpCiCZPChNA >= UHwrbFTHFncUvgjnDmcQAacqOIpEb.Length)
		{
			return -1;
		}
		int hOSqtHSrEMHBVLolGGBpCiCZPChNA = HOSqtHSrEMHBVLolGGBpCiCZPChNA;
		HOSqtHSrEMHBVLolGGBpCiCZPChNA++;
		return hOSqtHSrEMHBVLolGGBpCiCZPChNA;
	}

	public ButtonStateFlags KOonZeRJAKnjZeFdpIRXKghDSnUW(bool P_0)
	{
		return OILFqKTJosIuEQvfAMAgFuBFIsys.Current.KOonZeRJAKnjZeFdpIRXKghDSnUW(P_0);
	}

	public xiZMFJaKprrLjxtEMQahBCVGvYER()
	{
		OILFqKTJosIuEQvfAMAgFuBFIsys = new UpdateLoopDataSet<uOPnCZIvbqmCBFCYoATBhCVbavZr>(ReInput.UserData.ConfigVars.updateLoop, vYVLBfKeDfctVsTbsFrtdXemlYxuA._003C_003E9.PxGkUjUIbqiePBNIQlglmtdlgXGj);
		HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
	}

	public void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
	{
		OILFqKTJosIuEQvfAMAgFuBFIsys.SetUpdateLoop(P_0);
		OILFqKTJosIuEQvfAMAgFuBFIsys.Current.sOLNzBCCbZmFXkMugfndpShqgrUP();
	}

	public void OJwRTvWKOprkrbxNjAvuBwrxssUE(uint P_0)
	{
		OILFqKTJosIuEQvfAMAgFuBFIsys.Current.OJwRTvWKOprkrbxNjAvuBwrxssUE(P_0);
	}

	public void AOPGPeIJDRnFsspPPHHIIysuRBXlA(UpdateLoopType P_0, bool P_1)
	{
		OILFqKTJosIuEQvfAMAgFuBFIsys.Current.AOPGPeIJDRnFsspPPHHIIysuRBXlA(P_1);
	}

	private void BTTeANcpZxbIKMGHTZlOfKJhVHSmA(int P_0)
	{
		HeLFpgOjUAcSLHCwLbTeOOxKxYGB = P_0;
	}

	private void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
	{
		HeLFpgOjUAcSLHCwLbTeOOxKxYGB = -1;
		for (int i = 0; i < OILFqKTJosIuEQvfAMAgFuBFIsys.Count; i++)
		{
			OILFqKTJosIuEQvfAMAgFuBFIsys[i].HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
		}
	}
}
