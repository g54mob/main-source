using System;
using Rewired;

internal static class GzUDgYjDOgnrtfxRQwsWQeValhgZA
{
	public enum MsctBIAJouaGMBSAvuNWusZTKQQd
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct BUxKLHjoernfotSNpoBuPFKarags
	{
		public enum mGpFrXCePbgHpmRpYVNRnttzHDPf
		{
			MatchAnyOption = 0,
			MatchAllOptions = 1,
			IgnoreOptions = 2
		}

		public PidVid tNjxagUrcnyzWbSOsVMIFxUTEAOE;

		public oTeeubsdtgUBkbEedSRoXqhHWiBd vVKRiokJGjZFUsDfHXTaxdFOMKfy;

		public mGpFrXCePbgHpmRpYVNRnttzHDPf mPDhaQTDVgDwMVbgKPmzdQRIqzMR;

		public BUxKLHjoernfotSNpoBuPFKarags(PidVid P_0, oTeeubsdtgUBkbEedSRoXqhHWiBd P_1, mGpFrXCePbgHpmRpYVNRnttzHDPf P_2)
		{
			tNjxagUrcnyzWbSOsVMIFxUTEAOE = P_0;
			vVKRiokJGjZFUsDfHXTaxdFOMKfy = P_1;
			mPDhaQTDVgDwMVbgKPmzdQRIqzMR = P_2;
		}

		public bool sKPmsOwrsqQUGaDeDiygzRJgUHm(ushort P_0, ushort P_1, oTeeubsdtgUBkbEedSRoXqhHWiBd P_2)
		{
			if (tNjxagUrcnyzWbSOsVMIFxUTEAOE.vendorId != P_0)
			{
				return false;
			}
			if (tNjxagUrcnyzWbSOsVMIFxUTEAOE.productId != P_1)
			{
				return false;
			}
			switch (mPDhaQTDVgDwMVbgKPmzdQRIqzMR)
			{
			case mGpFrXCePbgHpmRpYVNRnttzHDPf.MatchAnyOption:
				return (vVKRiokJGjZFUsDfHXTaxdFOMKfy & P_2) != 0;
			case mGpFrXCePbgHpmRpYVNRnttzHDPf.MatchAllOptions:
				return vVKRiokJGjZFUsDfHXTaxdFOMKfy == P_2;
			case mGpFrXCePbgHpmRpYVNRnttzHDPf.IgnoreOptions:
				return true;
			default:
				throw new NotImplementedException();
			}
		}
	}

	public enum oTeeubsdtgUBkbEedSRoXqhHWiBd
	{
		None = 0,
		Bluetooth = 1,
		USB = 2
	}

	private static Guid[] letNKvxxphGPOTMYetzEFVRKuKqn = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] ygcvfsZjUnUjhvvZhugwAsiMPurF = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string hkyBfRSFNDGaHweWEkanhWPDhHcX = ".*xbox[ \\-]one.*";

	private static readonly BUxKLHjoernfotSNpoBuPFKarags[] TgrgGQkiripnkgHKXRldoToxfNIR = new BUxKLHjoernfotSNpoBuPFKarags[1]
	{
		new BUxKLHjoernfotSNpoBuPFKarags(new PidVid(8201, 1406), oTeeubsdtgUBkbEedSRoXqhHWiBd.USB, BUxKLHjoernfotSNpoBuPFKarags.mGpFrXCePbgHpmRpYVNRnttzHDPf.MatchAnyOption)
	};

	public static string kxdzDxRnsrgfCvBzDwfkdynRPnCA(fmknYWuxIkOhtFkdpAUHgftPbHiiA P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		switch (wSmKnCvYvPwachawnChXpyZlLSP(P_0.iarrdhzPMulfUajipLKOuwWTgyXE, P_1, P_2, P_3))
		{
		case MsctBIAJouaGMBSAvuNWusZTKQQd.CombinedTriggers:
			return "[CombinedTriggers]";
		case MsctBIAJouaGMBSAvuNWusZTKQQd.SplitTriggers:
			return "[SplitTriggers]";
		default:
			return string.Empty;
		}
	}

	public static MsctBIAJouaGMBSAvuNWusZTKQQd wSmKnCvYvPwachawnChXpyZlLSP(cbwdFAJnqCMGYkkkxIGEIVddLrvEb[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!tlVeACdUzkJauHJcxAbQrFRViycuA(P_1, P_2, P_3))
		{
			return MsctBIAJouaGMBSAvuNWusZTKQQd.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].mfmnPLnoKcRvXQLIfmBFbZvcCOM == 1 && !P_0[i].mklabMkWWbxaUKOXlMIaDcJMkZHV && P_0[i].SyXloggNqWgXQDhDOTyMKCheSlRQA.cWhBJpdcIExibSMjYHItMpewxpwkA == 53)
			{
				return MsctBIAJouaGMBSAvuNWusZTKQQd.SplitTriggers;
			}
		}
		return MsctBIAJouaGMBSAvuNWusZTKQQd.CombinedTriggers;
	}

	public static bool tlVeACdUzkJauHJcxAbQrFRViycuA(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(letNKvxxphGPOTMYetzEFVRKuKqn, P_0) >= 0)
		{
			return true;
		}
		if (tlVeACdUzkJauHJcxAbQrFRViycuA(P_1))
		{
			return true;
		}
		if (tlVeACdUzkJauHJcxAbQrFRViycuA(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool tlVeACdUzkJauHJcxAbQrFRViycuA(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < ygcvfsZjUnUjhvvZhugwAsiMPurF.Length; i++)
		{
			if (ygcvfsZjUnUjhvvZhugwAsiMPurF[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool uvhnxHbAUPoUSMfSJByuGIBPvWHt(InputSource P_0, ushort P_1, ushort P_2, oTeeubsdtgUBkbEedSRoXqhHWiBd P_3)
	{
		if (P_0 == InputSource.DirectInput || P_0 == InputSource.RawInput)
		{
			for (int i = 0; i < TgrgGQkiripnkgHKXRldoToxfNIR.Length; i++)
			{
				if (TgrgGQkiripnkgHKXRldoToxfNIR[i].sKPmsOwrsqQUGaDeDiygzRJgUHm(P_1, P_2, P_3))
				{
					return true;
				}
			}
		}
		return false;
	}
}
