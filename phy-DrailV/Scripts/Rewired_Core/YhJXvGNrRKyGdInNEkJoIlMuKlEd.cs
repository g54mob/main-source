using Rewired;
using Rewired.Internal.Localization;

internal sealed class YhJXvGNrRKyGdInNEkJoIlMuKlEd : iiFvxWRSrSmoIrhnwAizbWrXGZxH, urVEweFPRbOeIIdMhHfayqASiHNDA
{
	private readonly urAVZRefROHDbvendscKLBZHGrdo cuogNTprNZNfGjDeNRQnoYxqstem;

	private readonly int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

	private DeviceLocalizationInfo epyWrMiKarPbsrBGIHCyAJPFVlJb;

	string JdcCLFiaJuoUfXzTzdwUYtOkZosQ.jXwgbYbEpdqHGeBdCbXEcskUaWaFA
	{
		get
		{
			jtAeQMwqfCHdCmeHvhaRCqwDmBxb jtAeQMwqfCHdCmeHvhaRCqwDmBxb2 = jfPgAiHCXDOsCqPqzSwgbROIKKdw();
			if (jtAeQMwqfCHdCmeHvhaRCqwDmBxb2 == null)
			{
				return string.Empty;
			}
			if (!LocalizationManager.isEnabled)
			{
				return jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.nonLocalizedDescriptiveName;
			}
			LocalizationManager.TryGetCachedLocalizedString(pBHGSdiKqWIcVIxiLTzkoXwKRJelA, jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.nonLocalizedDescriptiveName, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
			if (!pBHGSdiKqWIcVIxiLTzkoXwKRJelA.hasCachedValue || localizationVersionChanged)
			{
				bYUfoUKGpLnbYkcOYAkjmqgxLxsS.IoxvELplUvUJmABwClRPnPBntqcL(pBHGSdiKqWIcVIxiLTzkoXwKRJelA, jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.key, bYUfoUKGpLnbYkcOYAkjmqgxLxsS.JCFGlogpCHkdrSooohIxKLMgQkvOA(cuogNTprNZNfGjDeNRQnoYxqstem), jtAeQMwqfCHdCmeHvhaRCqwDmBxb2.nonLocalizedDescriptiveName, LocalizationManager.version, epyWrMiKarPbsrBGIHCyAJPFVlJb, cuogNTprNZNfGjDeNRQnoYxqstem, hkJhlFMpiETPSIkMyOmVuFxkJKlT, AxisRange.Full, -1, out result);
			}
			return result;
		}
	}

	DeviceLocalizationInfo urVEweFPRbOeIIdMhHfayqASiHNDA.mACczrXFRlrAJdooiJCGbwHueCkx => epyWrMiKarPbsrBGIHCyAJPFVlJb;

	public override string jzbdtVDIZOFSEAfWzRXPFuJyPfqpA(int P_0)
	{
		if ((uint)P_0 >= (uint)base.dhMPxgNIozGOSCWblPFvccnEWDJI || PROjQYrpgSIdZjYqEnOaDHUXyBjG == null)
		{
			return string.Empty;
		}
		jYOuwHQLkAMAsMhmCbimJoXgoSaP jYOuwHQLkAMAsMhmCbimJoXgoSaP2 = jfPgAiHCXDOsCqPqzSwgbROIKKdw();
		if (jYOuwHQLkAMAsMhmCbimJoXgoSaP2 == null)
		{
			return string.Empty;
		}
		if (!LocalizationManager.isEnabled)
		{
			return jYOuwHQLkAMAsMhmCbimJoXgoSaP2.GetSpecialElementNonLocalizedDescriptiveName(P_0);
		}
		LocalizedString localizedString = PROjQYrpgSIdZjYqEnOaDHUXyBjG[P_0];
		string specialElementKey = jYOuwHQLkAMAsMhmCbimJoXgoSaP2.GetSpecialElementKey(P_0);
		LocalizationManager.TryGetCachedLocalizedString(localizedString, specialElementKey, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
		if (!localizedString.hasCachedValue || localizationVersionChanged)
		{
			bYUfoUKGpLnbYkcOYAkjmqgxLxsS.IoxvELplUvUJmABwClRPnPBntqcL(localizedString, specialElementKey, bYUfoUKGpLnbYkcOYAkjmqgxLxsS.JCFGlogpCHkdrSooohIxKLMgQkvOA(cuogNTprNZNfGjDeNRQnoYxqstem), jYOuwHQLkAMAsMhmCbimJoXgoSaP2.GetSpecialElementNonLocalizedDescriptiveName(P_0), LocalizationManager.version, epyWrMiKarPbsrBGIHCyAJPFVlJb, cuogNTprNZNfGjDeNRQnoYxqstem, hkJhlFMpiETPSIkMyOmVuFxkJKlT, AxisRange.Full, P_0, out result);
		}
		return result;
	}

	private YhJXvGNrRKyGdInNEkJoIlMuKlEd(urAVZRefROHDbvendscKLBZHGrdo P_0, VwAEfXIfCgCiohhuMMznDzgWRhLp P_1, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_2, int P_3, DeviceLocalizationInfo P_4)
		: base(P_1, P_2)
	{
		cuogNTprNZNfGjDeNRQnoYxqstem = P_0;
		hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_3;
		epyWrMiKarPbsrBGIHCyAJPFVlJb = P_4;
	}

	private YhJXvGNrRKyGdInNEkJoIlMuKlEd(jYOuwHQLkAMAsMhmCbimJoXgoSaP P_0, urAVZRefROHDbvendscKLBZHGrdo P_1, VwAEfXIfCgCiohhuMMznDzgWRhLp P_2, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_3, int P_4, DeviceLocalizationInfo P_5)
		: base(P_0, P_2, P_3)
	{
		cuogNTprNZNfGjDeNRQnoYxqstem = P_1;
		hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_4;
		epyWrMiKarPbsrBGIHCyAJPFVlJb = P_5;
	}

	public static YhJXvGNrRKyGdInNEkJoIlMuKlEd VxSNvmooWfTkIVcICGUZnqoUJPDW(urAVZRefROHDbvendscKLBZHGrdo P_0, VwAEfXIfCgCiohhuMMznDzgWRhLp P_1, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_2, int P_3, DeviceLocalizationInfo P_4)
	{
		return new YhJXvGNrRKyGdInNEkJoIlMuKlEd(P_0, P_1, P_2, P_3, P_4);
	}

	public static YhJXvGNrRKyGdInNEkJoIlMuKlEd VxSNvmooWfTkIVcICGUZnqoUJPDW(jYOuwHQLkAMAsMhmCbimJoXgoSaP P_0, urAVZRefROHDbvendscKLBZHGrdo P_1, VwAEfXIfCgCiohhuMMznDzgWRhLp P_2, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_3, int P_4, DeviceLocalizationInfo P_5)
	{
		YhJXvGNrRKyGdInNEkJoIlMuKlEd yhJXvGNrRKyGdInNEkJoIlMuKlEd = new YhJXvGNrRKyGdInNEkJoIlMuKlEd(P_0, P_1, P_2, P_3, P_4, P_5);
		yhJXvGNrRKyGdInNEkJoIlMuKlEd.TlzckGoQDITHcUYaslQXPQBOhTwq();
		return yhJXvGNrRKyGdInNEkJoIlMuKlEd;
	}

	public override bool TUibHCXgdJpNwgxVPYRazOMZLYAI(JdcCLFiaJuoUfXzTzdwUYtOkZosQ P_0, bool P_1)
	{
		if (!(P_0 is YhJXvGNrRKyGdInNEkJoIlMuKlEd yhJXvGNrRKyGdInNEkJoIlMuKlEd))
		{
			return false;
		}
		if (!base.TUibHCXgdJpNwgxVPYRazOMZLYAI(P_0, P_1))
		{
			return false;
		}
		if (cuogNTprNZNfGjDeNRQnoYxqstem == yhJXvGNrRKyGdInNEkJoIlMuKlEd.cuogNTprNZNfGjDeNRQnoYxqstem && hkJhlFMpiETPSIkMyOmVuFxkJKlT == yhJXvGNrRKyGdInNEkJoIlMuKlEd.hkJhlFMpiETPSIkMyOmVuFxkJKlT)
		{
			return DeviceLocalizationInfo.DataMatches(epyWrMiKarPbsrBGIHCyAJPFVlJb, yhJXvGNrRKyGdInNEkJoIlMuKlEd.epyWrMiKarPbsrBGIHCyAJPFVlJb);
		}
		return false;
	}
}
