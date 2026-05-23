internal static class gXcWZPmcMasVpNyHVanIaMnQphDy
{
	private class sLLDfLQwFUuDIPBAvdgYgsqYnKCQ
	{
		public readonly ushort FDsgIQiJYyRqYqEVlTFvlxiMEGeK;

		public readonly ushort LxkGTedFvoXfDRJDmDtDDefSkzNcb;

		public readonly string FESerMCNmsofoeSZUemYuecDfLyz;

		public readonly bool fsIJIYcmCmbCqgGKnmyuUyANXxicA;

		public readonly int AZiGWScmSRpzXCaRRYDYbjXvzCXJ;

		public readonly int rVOnerZKqALntrTUEjFOdNRMqLcE;

		public readonly int PaHBmSYQAjMftrcIBUzXnUsbDWSe;

		public readonly float KiknvDrTtmcNctgVcGZzlRtMQvND;

		public sLLDfLQwFUuDIPBAvdgYgsqYnKCQ(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
		{
			FDsgIQiJYyRqYqEVlTFvlxiMEGeK = P_0;
			LxkGTedFvoXfDRJDmDtDDefSkzNcb = P_1;
			if (string.IsNullOrEmpty(P_2))
			{
				P_2 = string.Empty;
			}
			FESerMCNmsofoeSZUemYuecDfLyz = P_2;
			fsIJIYcmCmbCqgGKnmyuUyANXxicA = P_3;
			AZiGWScmSRpzXCaRRYDYbjXvzCXJ = P_4;
			rVOnerZKqALntrTUEjFOdNRMqLcE = P_5;
			PaHBmSYQAjMftrcIBUzXnUsbDWSe = P_6;
			KiknvDrTtmcNctgVcGZzlRtMQvND = P_7;
		}

		public bool ZqKEjtgzwZliWGDtCJOXkVObnreaA(ushort P_0, ushort P_1)
		{
			if (FDsgIQiJYyRqYqEVlTFvlxiMEGeK == P_0)
			{
				return LxkGTedFvoXfDRJDmDtDDefSkzNcb == P_1;
			}
			return false;
		}

		public bool CjXbKHeZLwVcIivRqPEPfzUggzFvA(ushort P_0, ushort P_1, string P_2)
		{
			if (FDsgIQiJYyRqYqEVlTFvlxiMEGeK != P_0 || LxkGTedFvoXfDRJDmDtDDefSkzNcb != P_1)
			{
				if (!string.IsNullOrEmpty(P_2))
				{
					return FESerMCNmsofoeSZUemYuecDfLyz == P_2;
				}
				return false;
			}
			return true;
		}

		public bool OsQsAcmufuItlbjJSFhKAFrNrtax(string P_0)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				return FESerMCNmsofoeSZUemYuecDfLyz == P_0;
			}
			return false;
		}
	}

	private const float hXiMCRtFmeIxhonuOuMPwGhNSUwc = 0.034f;

	private static sLLDfLQwFUuDIPBAvdgYgsqYnKCQ[] xgtLsCtZksIRXIeXFdfnhukGDegQA = new sLLDfLQwFUuDIPBAvdgYgsqYnKCQ[3]
	{
		new sLLDfLQwFUuDIPBAvdgYgsqYnKCQ(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
		new sLLDfLQwFUuDIPBAvdgYgsqYnKCQ(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
		new sLLDfLQwFUuDIPBAvdgYgsqYnKCQ(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
	};

	public static bool ahONxUsHQhJADDqcIvOvLlWAwImh(ushort P_0, ushort P_1, string P_2 = null)
	{
		return veCeaMePicxTxnskoMEqbuMEHrrE(P_0, P_1, P_2)?.fsIJIYcmCmbCqgGKnmyuUyANXxicA ?? false;
	}

	public static float POVforFVXCkTxjTkPsosuiIuZEFFA(ushort P_0, ushort P_1, string P_2 = null)
	{
		return veCeaMePicxTxnskoMEqbuMEHrrE(P_0, P_1, P_2)?.KiknvDrTtmcNctgVcGZzlRtMQvND ?? 0f;
	}

	public static bool nXpyzCVsnjAaBEjFLCqmejAkyygA(ushort P_0, ushort P_1, out int P_2, out int P_3, out int P_4)
	{
		return meAcTtZJMqXvdWtysrkvXGcTAKtiA(P_0, P_1, null, out P_2, out P_3, out P_4);
	}

	public static bool meAcTtZJMqXvdWtysrkvXGcTAKtiA(ushort P_0, ushort P_1, string P_2, out int P_3, out int P_4, out int P_5)
	{
		for (int i = 0; i < xgtLsCtZksIRXIeXFdfnhukGDegQA.Length; i++)
		{
			if (xgtLsCtZksIRXIeXFdfnhukGDegQA[i].ZqKEjtgzwZliWGDtCJOXkVObnreaA(P_0, P_1) && xgtLsCtZksIRXIeXFdfnhukGDegQA[i].fsIJIYcmCmbCqgGKnmyuUyANXxicA)
			{
				P_3 = xgtLsCtZksIRXIeXFdfnhukGDegQA[i].AZiGWScmSRpzXCaRRYDYbjXvzCXJ;
				P_4 = xgtLsCtZksIRXIeXFdfnhukGDegQA[i].rVOnerZKqALntrTUEjFOdNRMqLcE;
				P_5 = xgtLsCtZksIRXIeXFdfnhukGDegQA[i].PaHBmSYQAjMftrcIBUzXnUsbDWSe;
				return true;
			}
		}
		P_3 = 0;
		P_4 = 0;
		P_5 = 0;
		return false;
	}

	public static bool uPPpTMJtogIuCnObVmmCrvjBDRzh(ushort P_0, ushort P_1, string P_2 = null)
	{
		return KOSRWTqoipJQduiEsOGYvpKVMSIp(P_0, P_1, P_2);
	}

	private static bool KOSRWTqoipJQduiEsOGYvpKVMSIp(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < xgtLsCtZksIRXIeXFdfnhukGDegQA.Length; i++)
		{
			if (xgtLsCtZksIRXIeXFdfnhukGDegQA[i].CjXbKHeZLwVcIivRqPEPfzUggzFvA(P_0, P_1, P_2))
			{
				return true;
			}
		}
		return false;
	}

	private static sLLDfLQwFUuDIPBAvdgYgsqYnKCQ veCeaMePicxTxnskoMEqbuMEHrrE(ushort P_0, ushort P_1, string P_2 = null)
	{
		for (int i = 0; i < xgtLsCtZksIRXIeXFdfnhukGDegQA.Length; i++)
		{
			if (xgtLsCtZksIRXIeXFdfnhukGDegQA[i].CjXbKHeZLwVcIivRqPEPfzUggzFvA(P_0, P_1, P_2))
			{
				return xgtLsCtZksIRXIeXFdfnhukGDegQA[i];
			}
		}
		return null;
	}
}
