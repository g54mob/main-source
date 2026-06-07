using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class ZVeDITCkNUczQyzeiCRedgPnAJmWA
{
	private class UesqJbWPdJMwpJkuUrSRUBMwcvjb
	{
		[Flags]
		private enum qjrqRZDUOzfZUxWDCsMlimMLCODgA : byte
		{
			None = 0,
			IsOnPositive = 1,
			IsOnNegative = 2,
			WasOnPrevPositive = 4,
			WasOnPrevNegative = 8
		}

		private qjrqRZDUOzfZUxWDCsMlimMLCODgA BeZIbOmpFGQPChtXnNiRBkEEUayO;

		private uint cWxPdZVWMBnIdjAKKpPQCdXpKbsM;

		private bool lheYSnqAUlCTsUKIYeVewKBTatuHA;

		public bool gtJZCiylCUdgKfNPdbblYASTFahD => lheYSnqAUlCTsUKIYeVewKBTatuHA;

		public ButtonStateFlags CHevAlBdRUMBpqWeRSrLguBTeaMs(bool P_0)
		{
			ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
			if (P_0)
			{
				if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.IsOnPositive) != qjrqRZDUOzfZUxWDCsMlimMLCODgA.None)
				{
					buttonStateFlags |= ButtonStateFlags.On;
					if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.WasOnPrevPositive) == 0)
					{
						buttonStateFlags |= ButtonStateFlags.Down;
					}
				}
				else if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.WasOnPrevPositive) != qjrqRZDUOzfZUxWDCsMlimMLCODgA.None)
				{
					buttonStateFlags |= ButtonStateFlags.Up;
				}
			}
			else if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.IsOnNegative) != qjrqRZDUOzfZUxWDCsMlimMLCODgA.None)
			{
				buttonStateFlags |= ButtonStateFlags.On;
				if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.WasOnPrevNegative) == 0)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.WasOnPrevNegative) != qjrqRZDUOzfZUxWDCsMlimMLCODgA.None)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void PRyQukYLMudCejOxfiQSSlibAltuA()
		{
			qjrqRZDUOzfZUxWDCsMlimMLCODgA qjrqRZDUOzfZUxWDCsMlimMLCODgA2 = qjrqRZDUOzfZUxWDCsMlimMLCODgA.None;
			if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.IsOnPositive) != qjrqRZDUOzfZUxWDCsMlimMLCODgA.None)
			{
				qjrqRZDUOzfZUxWDCsMlimMLCODgA2 |= qjrqRZDUOzfZUxWDCsMlimMLCODgA.WasOnPrevPositive;
			}
			if ((BeZIbOmpFGQPChtXnNiRBkEEUayO & qjrqRZDUOzfZUxWDCsMlimMLCODgA.IsOnNegative) != qjrqRZDUOzfZUxWDCsMlimMLCODgA.None)
			{
				qjrqRZDUOzfZUxWDCsMlimMLCODgA2 |= qjrqRZDUOzfZUxWDCsMlimMLCODgA.WasOnPrevNegative;
			}
			BeZIbOmpFGQPChtXnNiRBkEEUayO = qjrqRZDUOzfZUxWDCsMlimMLCODgA2;
		}

		public void BpdAfXILVOyYOaFQDEOvHqvkEnerb(uint P_0)
		{
			if (cWxPdZVWMBnIdjAKKpPQCdXpKbsM < P_0 - 1)
			{
				lheYSnqAUlCTsUKIYeVewKBTatuHA = false;
			}
		}

		public void jzzyflNyaXhIlcMAftCelfEmCnQw(bool P_0)
		{
			if (P_0)
			{
				BeZIbOmpFGQPChtXnNiRBkEEUayO |= qjrqRZDUOzfZUxWDCsMlimMLCODgA.IsOnPositive;
			}
			else
			{
				BeZIbOmpFGQPChtXnNiRBkEEUayO |= qjrqRZDUOzfZUxWDCsMlimMLCODgA.IsOnNegative;
			}
			cWxPdZVWMBnIdjAKKpPQCdXpKbsM = ReInput.currentFrame;
			if (!lheYSnqAUlCTsUKIYeVewKBTatuHA)
			{
				lheYSnqAUlCTsUKIYeVewKBTatuHA = true;
			}
		}

		public void NmPYqZNaMPAxAdzBCblmuXGDPoVAA()
		{
			BeZIbOmpFGQPChtXnNiRBkEEUayO = qjrqRZDUOzfZUxWDCsMlimMLCODgA.None;
			cWxPdZVWMBnIdjAKKpPQCdXpKbsM = 0u;
			lheYSnqAUlCTsUKIYeVewKBTatuHA = false;
		}
	}

	[Serializable]
	private sealed class NMyEUreKrSSJuWsZKWWkswmHJBRSA
	{
		public static readonly NMyEUreKrSSJuWsZKWWkswmHJBRSA _003C_003E9 = new NMyEUreKrSSJuWsZKWWkswmHJBRSA();

		public static Func<UesqJbWPdJMwpJkuUrSRUBMwcvjb> _003C_003E9__19_0;

		internal ZVeDITCkNUczQyzeiCRedgPnAJmWA DqSNVyTXgsOOCxgCXJZwEacpmfKJ()
		{
			return new ZVeDITCkNUczQyzeiCRedgPnAJmWA();
		}

		internal void jMrqRToDhROlrnjIXVrfjWpzHBWS(ZVeDITCkNUczQyzeiCRedgPnAJmWA P_0)
		{
			P_0.SbHYxsZzqGBXkrZeMwRDLrBLEEoFA();
		}

		internal UesqJbWPdJMwpJkuUrSRUBMwcvjb SZnbRIrLwAknSVSQzHpVHcnzXRaY()
		{
			return new UesqJbWPdJMwpJkuUrSRUBMwcvjb();
		}
	}

	private const int kgqfAwMVnhaOthSLLSJFoklDTlGv = 20;

	private const int NCNWuqtNmJbDFKVpFVXVxZskNKNo = 10;

	private static ObjectPool<ZVeDITCkNUczQyzeiCRedgPnAJmWA> cRfdozzrNaAscDsrlpZVBgghoXWOb;

	private static ZVeDITCkNUczQyzeiCRedgPnAJmWA[] mfFAWdkgKCibCoIxKZMyFcrmaGzHA;

	private static int vmditDfvlLmMcRukbiCqHdhtAqoS;

	public int HJqBdaAOGKuefuBvZBqKLNbsjXYgb;

	private UpdateLoopDataSet<UesqJbWPdJMwpJkuUrSRUBMwcvjb> mgYeJnueKPilUTbCBYaoEvCKmdGt;

	public bool wEQaEsFIORhjNzOFwRTXCqnirTogA
	{
		get
		{
			int count = mgYeJnueKPilUTbCBYaoEvCKmdGt.Count;
			for (int i = 0; i < count; i++)
			{
				if (mgYeJnueKPilUTbCBYaoEvCKmdGt[i].gtJZCiylCUdgKfNPdbblYASTFahD)
				{
					return true;
				}
			}
			return false;
		}
	}

	static ZVeDITCkNUczQyzeiCRedgPnAJmWA()
	{
		cRfdozzrNaAscDsrlpZVBgghoXWOb = new ObjectPool<ZVeDITCkNUczQyzeiCRedgPnAJmWA>(20, NMyEUreKrSSJuWsZKWWkswmHJBRSA._003C_003E9.DqSNVyTXgsOOCxgCXJZwEacpmfKJ, NMyEUreKrSSJuWsZKWWkswmHJBRSA._003C_003E9.jMrqRToDhROlrnjIXVrfjWpzHBWS);
		mfFAWdkgKCibCoIxKZMyFcrmaGzHA = new ZVeDITCkNUczQyzeiCRedgPnAJmWA[20];
	}

	public static void RcLpnsFsgeNWBWYrxBojnJbaIcFFA()
	{
		vmditDfvlLmMcRukbiCqHdhtAqoS = 0;
		Array.Clear(mfFAWdkgKCibCoIxKZMyFcrmaGzHA, 0, mfFAWdkgKCibCoIxKZMyFcrmaGzHA.Length);
	}

	public static ZVeDITCkNUczQyzeiCRedgPnAJmWA yJdlzQowkVunjlXfmkoITHuOVkEK(int P_0)
	{
		for (int i = 0; i < vmditDfvlLmMcRukbiCqHdhtAqoS; i++)
		{
			if (mfFAWdkgKCibCoIxKZMyFcrmaGzHA[i] != null && mfFAWdkgKCibCoIxKZMyFcrmaGzHA[i].HJqBdaAOGKuefuBvZBqKLNbsjXYgb == P_0)
			{
				return mfFAWdkgKCibCoIxKZMyFcrmaGzHA[i];
			}
		}
		return null;
	}

	public static ZVeDITCkNUczQyzeiCRedgPnAJmWA kVAOkDyfOTCsVgEDxHEistYqhGEbA(int P_0)
	{
		ZVeDITCkNUczQyzeiCRedgPnAJmWA zVeDITCkNUczQyzeiCRedgPnAJmWA = yJdlzQowkVunjlXfmkoITHuOVkEK(P_0);
		if (zVeDITCkNUczQyzeiCRedgPnAJmWA != null)
		{
			return zVeDITCkNUczQyzeiCRedgPnAJmWA;
		}
		zVeDITCkNUczQyzeiCRedgPnAJmWA = cRfdozzrNaAscDsrlpZVBgghoXWOb.Get();
		zVeDITCkNUczQyzeiCRedgPnAJmWA.GdTKKzwMYMiOoNgFSfmYFqAhPBpVA(P_0);
		zVeDITCkNUczQyzeiCRedgPnAJmWA.mgYeJnueKPilUTbCBYaoEvCKmdGt.SetUpdateLoop(ReInput.currentUpdateLoop);
		boovOepaqhDPbnVDBjZbgwIxNaXKA(zVeDITCkNUczQyzeiCRedgPnAJmWA);
		return zVeDITCkNUczQyzeiCRedgPnAJmWA;
	}

	public static void IXQMnpMnfPvFvwuwJdwZAfOBSdUr(UpdateLoopType P_0)
	{
		for (int i = 0; i < vmditDfvlLmMcRukbiCqHdhtAqoS; i++)
		{
			if (mfFAWdkgKCibCoIxKZMyFcrmaGzHA[i] != null)
			{
				mfFAWdkgKCibCoIxKZMyFcrmaGzHA[i].NQyudejVGBwdqGHQVJtroQDkUcUm(P_0);
			}
		}
	}

	public static void SdIlTjrnDAqFOUJGQxfYhLdGXePd(UpdateLoopType P_0, uint P_1)
	{
		for (int num = vmditDfvlLmMcRukbiCqHdhtAqoS - 1; num >= 0; num--)
		{
			if (mfFAWdkgKCibCoIxKZMyFcrmaGzHA[num] == null)
			{
				if (num == vmditDfvlLmMcRukbiCqHdhtAqoS - 1)
				{
					vmditDfvlLmMcRukbiCqHdhtAqoS--;
				}
			}
			else
			{
				mfFAWdkgKCibCoIxKZMyFcrmaGzHA[num].dDjDGyyLcHXSshfuyrzsdaQQqukM(P_1);
				if (!mfFAWdkgKCibCoIxKZMyFcrmaGzHA[num].wEQaEsFIORhjNzOFwRTXCqnirTogA)
				{
					oWGqYDHCeOBRfhcMSgimeKgAhjMZb(num);
				}
			}
		}
	}

	private static void boovOepaqhDPbnVDBjZbgwIxNaXKA(ZVeDITCkNUczQyzeiCRedgPnAJmWA P_0)
	{
		int num = INeKYYSMnASldoHbyFNFOEaGKlSv();
		if (num < 0)
		{
			if (vmditDfvlLmMcRukbiCqHdhtAqoS == mfFAWdkgKCibCoIxKZMyFcrmaGzHA.Length)
			{
				ZVeDITCkNUczQyzeiCRedgPnAJmWA[] array = mfFAWdkgKCibCoIxKZMyFcrmaGzHA;
				mfFAWdkgKCibCoIxKZMyFcrmaGzHA = new ZVeDITCkNUczQyzeiCRedgPnAJmWA[mfFAWdkgKCibCoIxKZMyFcrmaGzHA.Length + 10];
				Array.Copy(array, mfFAWdkgKCibCoIxKZMyFcrmaGzHA, array.Length);
			}
			num = vmditDfvlLmMcRukbiCqHdhtAqoS;
			vmditDfvlLmMcRukbiCqHdhtAqoS++;
		}
		mfFAWdkgKCibCoIxKZMyFcrmaGzHA[num] = P_0;
	}

	private static void oWGqYDHCeOBRfhcMSgimeKgAhjMZb(int P_0)
	{
		if (P_0 >= 0 && P_0 < vmditDfvlLmMcRukbiCqHdhtAqoS)
		{
			ZVeDITCkNUczQyzeiCRedgPnAJmWA zVeDITCkNUczQyzeiCRedgPnAJmWA = mfFAWdkgKCibCoIxKZMyFcrmaGzHA[P_0];
			if (zVeDITCkNUczQyzeiCRedgPnAJmWA != null)
			{
				cRfdozzrNaAscDsrlpZVBgghoXWOb.Return(zVeDITCkNUczQyzeiCRedgPnAJmWA);
				mfFAWdkgKCibCoIxKZMyFcrmaGzHA[P_0] = null;
			}
			if (P_0 == vmditDfvlLmMcRukbiCqHdhtAqoS - 1)
			{
				vmditDfvlLmMcRukbiCqHdhtAqoS--;
			}
		}
	}

	private static int INeKYYSMnASldoHbyFNFOEaGKlSv()
	{
		for (int i = 0; i < vmditDfvlLmMcRukbiCqHdhtAqoS; i++)
		{
			if (mfFAWdkgKCibCoIxKZMyFcrmaGzHA[i] == null)
			{
				return i;
			}
		}
		if (vmditDfvlLmMcRukbiCqHdhtAqoS >= mfFAWdkgKCibCoIxKZMyFcrmaGzHA.Length)
		{
			return -1;
		}
		int result = vmditDfvlLmMcRukbiCqHdhtAqoS;
		vmditDfvlLmMcRukbiCqHdhtAqoS++;
		return result;
	}

	public ButtonStateFlags yKITVwafHDGnibrEGdrzgWPaUXtlA(bool P_0)
	{
		return mgYeJnueKPilUTbCBYaoEvCKmdGt.Current.CHevAlBdRUMBpqWeRSrLguBTeaMs(P_0);
	}

	public ZVeDITCkNUczQyzeiCRedgPnAJmWA()
	{
		mgYeJnueKPilUTbCBYaoEvCKmdGt = new UpdateLoopDataSet<UesqJbWPdJMwpJkuUrSRUBMwcvjb>(ReInput.UserData.ConfigVars.updateLoop, NMyEUreKrSSJuWsZKWWkswmHJBRSA._003C_003E9.SZnbRIrLwAknSVSQzHpVHcnzXRaY);
		SbHYxsZzqGBXkrZeMwRDLrBLEEoFA();
	}

	public void NQyudejVGBwdqGHQVJtroQDkUcUm(UpdateLoopType P_0)
	{
		mgYeJnueKPilUTbCBYaoEvCKmdGt.SetUpdateLoop(P_0);
		mgYeJnueKPilUTbCBYaoEvCKmdGt.Current.PRyQukYLMudCejOxfiQSSlibAltuA();
	}

	public void dDjDGyyLcHXSshfuyrzsdaQQqukM(uint P_0)
	{
		mgYeJnueKPilUTbCBYaoEvCKmdGt.Current.BpdAfXILVOyYOaFQDEOvHqvkEnerb(P_0);
	}

	public void VnuHeZNaQAlXPxqYmEJJCfgVeIat(UpdateLoopType P_0, bool P_1)
	{
		mgYeJnueKPilUTbCBYaoEvCKmdGt.Current.jzzyflNyaXhIlcMAftCelfEmCnQw(P_1);
	}

	private void GdTKKzwMYMiOoNgFSfmYFqAhPBpVA(int P_0)
	{
		HJqBdaAOGKuefuBvZBqKLNbsjXYgb = P_0;
	}

	private void SbHYxsZzqGBXkrZeMwRDLrBLEEoFA()
	{
		HJqBdaAOGKuefuBvZBqKLNbsjXYgb = -1;
		for (int i = 0; i < mgYeJnueKPilUTbCBYaoEvCKmdGt.Count; i++)
		{
			mgYeJnueKPilUTbCBYaoEvCKmdGt[i].NmPYqZNaMPAxAdzBCblmuXGDPoVAA();
		}
	}
}
