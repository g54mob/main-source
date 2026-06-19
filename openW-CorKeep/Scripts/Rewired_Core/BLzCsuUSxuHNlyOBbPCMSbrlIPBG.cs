using Rewired;
using Rewired.Internal.Localization;

internal sealed class BLzCsuUSxuHNlyOBbPCMSbrlIPBG : vRxehaImOeJEYZjAHzcTdGbMbGst, dwlFsOGQiNjyUmmpGChGeYMHRJMh
{
	private readonly hhwQItrOtauBvPHQAFLgRDRQAhcP qyfCPosRVSVAdiTrYSAsAZSBEUmC;

	private readonly int lBABVZpIqPZtKXceOiXMiasWcUgPA;

	private DeviceLocalizationInfo BPUfwhZNeivoTzQFECpwfAWBaIPN;

	string CrEdIhdRuEefdCHiQoLwiMECdkdvB.LoGZqdROKyuYHJXdnhuxPciDQjeL
	{
		get
		{
			gDrCmzJNXwFvGTMAYKGQspUqeYD gDrCmzJNXwFvGTMAYKGQspUqeYD2 = SziVqzkKQDCUaxwYTXWeECXAhhkz();
			if (gDrCmzJNXwFvGTMAYKGQspUqeYD2 == null)
			{
				return string.Empty;
			}
			if (!LocalizationManager.isEnabled)
			{
				return gDrCmzJNXwFvGTMAYKGQspUqeYD2.nonLocalizedDescriptiveName;
			}
			LocalizationManager.TryGetCachedLocalizedString(xReLXRqoDCNUkVraDkxZoEUHpFYT, gDrCmzJNXwFvGTMAYKGQspUqeYD2.nonLocalizedDescriptiveName, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
			if (!xReLXRqoDCNUkVraDkxZoEUHpFYT.hasCachedValue || localizationVersionChanged)
			{
				iiskKgDbWxOwEGnzrXYHgovqbhjF.OIWnUOZZgAeMkUCcYzUoHRRQqSEP(xReLXRqoDCNUkVraDkxZoEUHpFYT, gDrCmzJNXwFvGTMAYKGQspUqeYD2.key, iiskKgDbWxOwEGnzrXYHgovqbhjF.GcRciOobecVMnFHIqCCfelEheUtB(qyfCPosRVSVAdiTrYSAsAZSBEUmC), gDrCmzJNXwFvGTMAYKGQspUqeYD2.nonLocalizedDescriptiveName, LocalizationManager.version, BPUfwhZNeivoTzQFECpwfAWBaIPN, qyfCPosRVSVAdiTrYSAsAZSBEUmC, lBABVZpIqPZtKXceOiXMiasWcUgPA, AxisRange.Full, -1, out result);
			}
			return result;
		}
	}

	DeviceLocalizationInfo dwlFsOGQiNjyUmmpGChGeYMHRJMh.OugWsWZGTthCBvUMgYijtHxjXjOC => BPUfwhZNeivoTzQFECpwfAWBaIPN;

	public string KOYAdAXpXWYTAUnkKwHhJQMyFYro(int P_0)
	{
		if ((uint)P_0 >= (uint)base.PigQuqwlngXbAqDDYmfGLgmLqCnh || uZMktLKxVFgShqfHbKijMdtBCikg == null)
		{
			return string.Empty;
		}
		wOcwbdLCJaOhasRXtoPQFUPfsCvq wOcwbdLCJaOhasRXtoPQFUPfsCvq2 = SziVqzkKQDCUaxwYTXWeECXAhhkz();
		if (wOcwbdLCJaOhasRXtoPQFUPfsCvq2 == null)
		{
			return string.Empty;
		}
		if (!LocalizationManager.isEnabled)
		{
			return wOcwbdLCJaOhasRXtoPQFUPfsCvq2.GetSpecialElementNonLocalizedDescriptiveName(P_0);
		}
		LocalizedString localizedString = uZMktLKxVFgShqfHbKijMdtBCikg[P_0];
		string specialElementKey = wOcwbdLCJaOhasRXtoPQFUPfsCvq2.GetSpecialElementKey(P_0);
		LocalizationManager.TryGetCachedLocalizedString(localizedString, specialElementKey, LocalizationManager.version, 0u, out var localizationVersionChanged, out var result);
		if (!localizedString.hasCachedValue || localizationVersionChanged)
		{
			iiskKgDbWxOwEGnzrXYHgovqbhjF.OIWnUOZZgAeMkUCcYzUoHRRQqSEP(localizedString, specialElementKey, iiskKgDbWxOwEGnzrXYHgovqbhjF.GcRciOobecVMnFHIqCCfelEheUtB(qyfCPosRVSVAdiTrYSAsAZSBEUmC), wOcwbdLCJaOhasRXtoPQFUPfsCvq2.GetSpecialElementNonLocalizedDescriptiveName(P_0), LocalizationManager.version, BPUfwhZNeivoTzQFECpwfAWBaIPN, qyfCPosRVSVAdiTrYSAsAZSBEUmC, lBABVZpIqPZtKXceOiXMiasWcUgPA, AxisRange.Full, P_0, out result);
		}
		return result;
	}

	private BLzCsuUSxuHNlyOBbPCMSbrlIPBG(hhwQItrOtauBvPHQAFLgRDRQAhcP P_0, fyQKArxdnRgBFXnCTGFifmqgwogRA P_1, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_2, int P_3, DeviceLocalizationInfo P_4)
		: base(P_1, P_2)
	{
		qyfCPosRVSVAdiTrYSAsAZSBEUmC = P_0;
		lBABVZpIqPZtKXceOiXMiasWcUgPA = P_3;
		BPUfwhZNeivoTzQFECpwfAWBaIPN = P_4;
	}

	private BLzCsuUSxuHNlyOBbPCMSbrlIPBG(wOcwbdLCJaOhasRXtoPQFUPfsCvq P_0, hhwQItrOtauBvPHQAFLgRDRQAhcP P_1, fyQKArxdnRgBFXnCTGFifmqgwogRA P_2, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_3, int P_4, DeviceLocalizationInfo P_5)
		: base(P_0, P_2, P_3)
	{
		qyfCPosRVSVAdiTrYSAsAZSBEUmC = P_1;
		lBABVZpIqPZtKXceOiXMiasWcUgPA = P_4;
		BPUfwhZNeivoTzQFECpwfAWBaIPN = P_5;
	}

	public static BLzCsuUSxuHNlyOBbPCMSbrlIPBG QdPVTKzHhkPaYwXEGHjZvtFHqKkG(hhwQItrOtauBvPHQAFLgRDRQAhcP P_0, fyQKArxdnRgBFXnCTGFifmqgwogRA P_1, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_2, int P_3, DeviceLocalizationInfo P_4)
	{
		return new BLzCsuUSxuHNlyOBbPCMSbrlIPBG(P_0, P_1, P_2, P_3, P_4);
	}

	public static BLzCsuUSxuHNlyOBbPCMSbrlIPBG gIKoHCujqwzPDpPLMgDmBxpPValA(wOcwbdLCJaOhasRXtoPQFUPfsCvq P_0, hhwQItrOtauBvPHQAFLgRDRQAhcP P_1, fyQKArxdnRgBFXnCTGFifmqgwogRA P_2, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_3, int P_4, DeviceLocalizationInfo P_5)
	{
		BLzCsuUSxuHNlyOBbPCMSbrlIPBG bLzCsuUSxuHNlyOBbPCMSbrlIPBG = new BLzCsuUSxuHNlyOBbPCMSbrlIPBG(P_0, P_1, P_2, P_3, P_4, P_5);
		bLzCsuUSxuHNlyOBbPCMSbrlIPBG.ejeFbwGIxeayeqIPgvoDbHsqwDGGA();
		return bLzCsuUSxuHNlyOBbPCMSbrlIPBG;
	}

	public bool DwTruWEISWOFQdAWpFuIzsUncbbZ(CrEdIhdRuEefdCHiQoLwiMECdkdvB P_0, bool P_1)
	{
		if (!(P_0 is BLzCsuUSxuHNlyOBbPCMSbrlIPBG bLzCsuUSxuHNlyOBbPCMSbrlIPBG))
		{
			return false;
		}
		if (!cBDzOknBMPEjCbibXDhLHmNFzPEnb(P_0, P_1))
		{
			return false;
		}
		if (qyfCPosRVSVAdiTrYSAsAZSBEUmC == bLzCsuUSxuHNlyOBbPCMSbrlIPBG.qyfCPosRVSVAdiTrYSAsAZSBEUmC && lBABVZpIqPZtKXceOiXMiasWcUgPA == bLzCsuUSxuHNlyOBbPCMSbrlIPBG.lBABVZpIqPZtKXceOiXMiasWcUgPA)
		{
			return DeviceLocalizationInfo.DataMatches(BPUfwhZNeivoTzQFECpwfAWBaIPN, bLzCsuUSxuHNlyOBbPCMSbrlIPBG.BPUfwhZNeivoTzQFECpwfAWBaIPN);
		}
		return false;
	}
}
