using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class bSpOfYCKbuoGmWWdYWRaFTvxjqc
{
	[CompilerGenerated]
	private string pfQaIgBapdxAjscHIKAeLhltRmH;

	[CompilerGenerated]
	private ZzynUvmlKytKEgmTHiivLRYPjoE RNEMcUAnIgGfdTJDBqeKRdgOiYa;

	[CompilerGenerated]
	private IntPtr FyAfxadeNUIHgiuVCFFBMleqaLuf;

	public string DeviceName
	{
		[CompilerGenerated]
		get
		{
			return pfQaIgBapdxAjscHIKAeLhltRmH;
		}
		[CompilerGenerated]
		set
		{
			pfQaIgBapdxAjscHIKAeLhltRmH = value;
		}
	}

	public ZzynUvmlKytKEgmTHiivLRYPjoE DeviceType
	{
		[CompilerGenerated]
		get
		{
			return RNEMcUAnIgGfdTJDBqeKRdgOiYa;
		}
		[CompilerGenerated]
		set
		{
			RNEMcUAnIgGfdTJDBqeKRdgOiYa = value;
		}
	}

	public IntPtr Handle
	{
		[CompilerGenerated]
		get
		{
			return FyAfxadeNUIHgiuVCFFBMleqaLuf;
		}
		[CompilerGenerated]
		set
		{
			FyAfxadeNUIHgiuVCFFBMleqaLuf = value;
		}
	}

	public bSpOfYCKbuoGmWWdYWRaFTvxjqc()
	{
	}

	internal bSpOfYCKbuoGmWWdYWRaFTvxjqc(ref zgagMKRQIXyQbOltCidVoMWOqST rawDeviceInfo, string deviceName, IntPtr deviceHandle)
	{
		DeviceName = deviceName;
		Handle = deviceHandle;
		DeviceType = rawDeviceInfo.PFyVjnGpmOklNfqHTmcjHyNFdUs;
	}

	internal static bSpOfYCKbuoGmWWdYWRaFTvxjqc GdjWAkldIAnBeAnyOFEvlJdSshh(ref zgagMKRQIXyQbOltCidVoMWOqST P_0, string P_1, IntPtr P_2)
	{
		bSpOfYCKbuoGmWWdYWRaFTvxjqc bSpOfYCKbuoGmWWdYWRaFTvxjqc2 = null;
		switch (P_0.PFyVjnGpmOklNfqHTmcjHyNFdUs)
		{
		case ZzynUvmlKytKEgmTHiivLRYPjoE.AXISQqlTXCgqZMiVvlFxhvyEMxo:
			return new lIwaFwjjdUQVLpcKYjYFLGDSfyjR(ref P_0, P_1, P_2);
		case ZzynUvmlKytKEgmTHiivLRYPjoE.lRyHJPXZVJHsfNLQMHpqapjyFUH:
			return new hvilRpkJGUOdckePRjHohhOxgpzF(ref P_0, P_1, P_2);
		case ZzynUvmlKytKEgmTHiivLRYPjoE.WibnlhrIoppUjEuxjomaVCUrgKFC:
			return new latZhBipOkqvpUGOFfaIEuxzBPfe(ref P_0, P_1, P_2);
		default:
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", new object[1] { (int)P_0.PFyVjnGpmOklNfqHTmcjHyNFdUs }));
		}
	}
}
