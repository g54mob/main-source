using Rewired;
using Rewired.Internal.Localization;

internal sealed class kcVtlLkxxcCGEkDbOioGZBSsqBKy : UALPDVwKlaWvzBmvcCkXuwKZFpdj, YXZigdaiNFoGvsJGpzzOfUbYIYHI
{
	private readonly ILKhcCJzrmtoMHIdzHgcKloPCkpIA BtLzbXKOmAKrAidcvbPeNOcOZEvK;

	private readonly int AnmojaBVLRsqjBBIfyIUzRtXHWxD;

	private DeviceLocalizationInfo iYoIcCtfVqsGcttkhrlauSpMZJGJ;

	string xhsfjMHWBKokSPBLxdeojZhcJxoeA.qJkqRAxrrocPcPhIKAOpCMJUoZxfA
	{
		get
		{
			LnhaMJXLiFbdSGpizhhMTtFDjtXy lnhaMJXLiFbdSGpizhhMTtFDjtXy = vVErTYAbdFRRLfXjyMdwNEqFAmnGA();
			if (lnhaMJXLiFbdSGpizhhMTtFDjtXy == null)
			{
				return string.Empty;
			}
			if (!LocalizationManager.isEnabled)
			{
				return lnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName;
			}
			LocalizationManager.TryGetCachedLocalizedString(IgMwwqYoaShFZDOHgCAHernAcSRVA, lnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
			if (!IgMwwqYoaShFZDOHgCAHernAcSRVA.hasCachedValue || localizationVersionChanged)
			{
				RfUTDPxyvrJRnCbYKkuVrGRpezaF.pJuuvzvUVARJZSeFfOlsYhoTmRBW(IgMwwqYoaShFZDOHgCAHernAcSRVA, lnhaMJXLiFbdSGpizhhMTtFDjtXy.key, RfUTDPxyvrJRnCbYKkuVrGRpezaF.lzOFGJIGSobSfNDmrCbSilKctrNdA(BtLzbXKOmAKrAidcvbPeNOcOZEvK), lnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName, LocalizationManager.version, iYoIcCtfVqsGcttkhrlauSpMZJGJ, BtLzbXKOmAKrAidcvbPeNOcOZEvK, AnmojaBVLRsqjBBIfyIUzRtXHWxD, AxisRange.Full, -1, out result);
			}
			return result;
		}
	}

	DeviceLocalizationInfo YXZigdaiNFoGvsJGpzzOfUbYIYHI.jYOvZrbCtfurqnyzXvZtgilgSpNd => iYoIcCtfVqsGcttkhrlauSpMZJGJ;

	public string hkGKrbIeEKHdIfFbgafOnxzFUul(int P_0)
	{
		if ((uint)P_0 >= (uint)base.iKMpMPYbCeMTYyywlDwWOMTGxkgI || LncLyoofGJjkWktCWxMpDhEWRXph == null)
		{
			return string.Empty;
		}
		DEOLSCnqecUoFqpsMneIWaoyXVqt dEOLSCnqecUoFqpsMneIWaoyXVqt = vVErTYAbdFRRLfXjyMdwNEqFAmnGA();
		if (dEOLSCnqecUoFqpsMneIWaoyXVqt == null)
		{
			return string.Empty;
		}
		if (!LocalizationManager.isEnabled)
		{
			return dEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementNonLocalizedDescriptiveName(P_0);
		}
		LocalizedString localizedString = LncLyoofGJjkWktCWxMpDhEWRXph[P_0];
		string specialElementKey = dEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementKey(P_0);
		LocalizationManager.TryGetCachedLocalizedString(localizedString, specialElementKey, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
		if (!localizedString.hasCachedValue || localizationVersionChanged)
		{
			RfUTDPxyvrJRnCbYKkuVrGRpezaF.pJuuvzvUVARJZSeFfOlsYhoTmRBW(localizedString, specialElementKey, RfUTDPxyvrJRnCbYKkuVrGRpezaF.lzOFGJIGSobSfNDmrCbSilKctrNdA(BtLzbXKOmAKrAidcvbPeNOcOZEvK), dEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementNonLocalizedDescriptiveName(P_0), LocalizationManager.version, iYoIcCtfVqsGcttkhrlauSpMZJGJ, BtLzbXKOmAKrAidcvbPeNOcOZEvK, AnmojaBVLRsqjBBIfyIUzRtXHWxD, AxisRange.Full, P_0, out result);
		}
		return result;
	}

	private kcVtlLkxxcCGEkDbOioGZBSsqBKy(ILKhcCJzrmtoMHIdzHgcKloPCkpIA P_0, AqybaYFDSFEDwBRnsokwpBTdIblQ P_1, veVjxECKraSLRuRJUJeBWprfCtQDb P_2, int P_3, DeviceLocalizationInfo P_4)
		: base(P_1, P_2)
	{
		BtLzbXKOmAKrAidcvbPeNOcOZEvK = P_0;
		AnmojaBVLRsqjBBIfyIUzRtXHWxD = P_3;
		iYoIcCtfVqsGcttkhrlauSpMZJGJ = P_4;
	}

	private kcVtlLkxxcCGEkDbOioGZBSsqBKy(DEOLSCnqecUoFqpsMneIWaoyXVqt P_0, ILKhcCJzrmtoMHIdzHgcKloPCkpIA P_1, AqybaYFDSFEDwBRnsokwpBTdIblQ P_2, veVjxECKraSLRuRJUJeBWprfCtQDb P_3, int P_4, DeviceLocalizationInfo P_5)
		: base(P_0, P_2, P_3)
	{
		BtLzbXKOmAKrAidcvbPeNOcOZEvK = P_1;
		AnmojaBVLRsqjBBIfyIUzRtXHWxD = P_4;
		iYoIcCtfVqsGcttkhrlauSpMZJGJ = P_5;
	}

	public static kcVtlLkxxcCGEkDbOioGZBSsqBKy lJzggjPeKoCvdqethasXqagGfCtG(ILKhcCJzrmtoMHIdzHgcKloPCkpIA P_0, AqybaYFDSFEDwBRnsokwpBTdIblQ P_1, veVjxECKraSLRuRJUJeBWprfCtQDb P_2, int P_3, DeviceLocalizationInfo P_4)
	{
		return new kcVtlLkxxcCGEkDbOioGZBSsqBKy(P_0, P_1, P_2, P_3, P_4);
	}

	public static kcVtlLkxxcCGEkDbOioGZBSsqBKy BfmaPgSNOogkaBtkuIBFMEIqNWlEA(DEOLSCnqecUoFqpsMneIWaoyXVqt P_0, ILKhcCJzrmtoMHIdzHgcKloPCkpIA P_1, AqybaYFDSFEDwBRnsokwpBTdIblQ P_2, veVjxECKraSLRuRJUJeBWprfCtQDb P_3, int P_4, DeviceLocalizationInfo P_5)
	{
		kcVtlLkxxcCGEkDbOioGZBSsqBKy obj = new kcVtlLkxxcCGEkDbOioGZBSsqBKy(P_0, P_1, P_2, P_3, P_4, P_5);
		obj.DKMkEJwNUuDpLGWqVbXJUJJzEYRk();
		return obj;
	}

	public bool cxvvDtyZlGeQplBjGsRWysloaagu(xhsfjMHWBKokSPBLxdeojZhcJxoeA P_0, bool P_1)
	{
		if (!(P_0 is kcVtlLkxxcCGEkDbOioGZBSsqBKy kcVtlLkxxcCGEkDbOioGZBSsqBKy2))
		{
			return false;
		}
		if (!NypQjVFPpZoXpmgEkjSHxNkebUBgA(P_0, P_1))
		{
			return false;
		}
		if (BtLzbXKOmAKrAidcvbPeNOcOZEvK == kcVtlLkxxcCGEkDbOioGZBSsqBKy2.BtLzbXKOmAKrAidcvbPeNOcOZEvK && AnmojaBVLRsqjBBIfyIUzRtXHWxD == kcVtlLkxxcCGEkDbOioGZBSsqBKy2.AnmojaBVLRsqjBBIfyIUzRtXHWxD)
		{
			return DeviceLocalizationInfo.DataMatches(iYoIcCtfVqsGcttkhrlauSpMZJGJ, kcVtlLkxxcCGEkDbOioGZBSsqBKy2.iYoIcCtfVqsGcttkhrlauSpMZJGJ);
		}
		return false;
	}
}
